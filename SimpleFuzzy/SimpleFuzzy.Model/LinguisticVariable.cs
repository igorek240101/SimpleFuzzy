using SimpleFuzzy.Abstract;
using System.Drawing;
using System.Xml;

namespace SimpleFuzzy.Model
{
    public class LinguisticVariable
    {
        public string name; // Имя лингвистической переменной
        public bool isInput; // входная или выходная переменная
        public bool IsActive => baseSet != null && func.Count > 0;
        public IObjectSet baseSet; // Базовое множество
        public List<(IMembershipFunction, Color)> func = new List<(IMembershipFunction, Color)>(); // Список термов
        public readonly bool isRedact; // Возможность редактирования
        public SetRule listRules; // Список правил для выходной переменной
        private Dictionary<IMembershipFunction, double> heightCache = new Dictionary<IMembershipFunction, double>();
        private Dictionary<IMembershipFunction, string> typeCache = new Dictionary<IMembershipFunction, string>();
        private Dictionary<IMembershipFunction, List<object>> areaOfInfluenceCache = new Dictionary<IMembershipFunction, List<object>>();
        private Dictionary<IMembershipFunction, List<object>> coreCache = new Dictionary<IMembershipFunction, List<object>>();

        public LinguisticVariable(bool isRedact, bool isInput)
        {
            this.isRedact = isRedact;
            this.isInput = isInput;
        }
        public LinguisticVariable(string name, bool isInput, bool isRedact, IObjectSet baseSet, List<(IMembershipFunction, Color)> func)
        {
            this.name = name;
            this.isInput = isInput;
            this.isRedact = isRedact;
            this.baseSet = baseSet;
            this.func = func;
        }

        public void UnloadingHandler(object sender, EventArgs e)
        {
            string context = sender as string;
            if (baseSet != null && baseSet.GetType().Assembly.Location == context)
                baseSet = null;
            func.RemoveAll(t => t.Item1.GetType().Assembly.Location == context);
            heightCache.Clear();
            typeCache.Clear();
            areaOfInfluenceCache.Clear();
            coreCache.Clear();
        }

        public string Name
        {
            get { return name; }
            set { if (isRedact == true) { name = value; } }
        }

        public bool IsInput
        {
            get { return isInput; }
            set { if (isRedact == true) { isInput = value; } }
        }

        public IObjectSet BaseSet
        {
            get { return baseSet; }
            set
            {
                if (isRedact == true)
                    if (func.Count == 0) { baseSet = value; }
                    else
                    {
                        if (func[0].Item1.InputType == value.Extraction().GetType()) { baseSet = value; }
                        else { throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают"); }
                    }
            }
        }

        public void AddTerm((IMembershipFunction, Color) term)
        {
            if (baseSet == null)
            {
                if (func.Count == 0) { func.Add(term); }
                else if (term.Item1.InputType == func[0].Item1.InputType) { func.Add(term); }
                else { throw new InvalidOperationException("Тип данных добавляемого терма не совпадает с уже имеющимися термами в списке"); }
            }
            else if (baseSet.Extraction().GetType() != term.Item1.InputType) { throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают"); }
            else { func.Add(term); } // Проверка типов данных
        }

        public void DeleteTerm(IMembershipFunction term) => func.RemoveAll(t => t.Item1 == term);

        public bool ContainsFunc(IMembershipFunction term) => func.Count(t => t.Item1 == term) > 0;

        public Color GetColor(IMembershipFunction term) => func.FirstOrDefault(t => t.Item1 == term).Item2;

        public void SetColor(IMembershipFunction term, Color color) => func[func.FindIndex(t => t.Item1 == term)] = (term, color);

        public int CountFunc => func.Count;

        public IMembershipFunction this[int index] => func[index].Item1;

        public double[] Fazzification(object elementBaseSet)
        {
            var list = new double[func.Count];
            for (int i = 0; i < func.Count; i++)
            {
                list[i] = (func[i].Item1.MembershipFunction(elementBaseSet));
            }
            return list;
        }

        public List<(object, double[])> Graphic()
        {
            var graphicList = new List<(object, double[])>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                graphicList.Add((baseSet.Extraction(), Fazzification(baseSet.Extraction())));
                baseSet.MoveNext();
            }
            return graphicList;
        }

        public string GetResultofFuzzy(double[] list)
        {
            string result = "";
            var toStringList = new (string, double)[func.Count];
            for (int i = 0; i < list.Length; i++)
            {
                toStringList[i] = (func[i].Item1.Name, list[i]);
            }
            toStringList = toStringList.OrderByDescending(x => x.Item2).ToArray();
            double sum = 0;
            foreach (var zeroValue in toStringList)
            {
                sum += zeroValue.Item2;
            }
            if (sum == 0)
            {
                return "Нет соответствия";
            }
            var listofRange = new (string, double[])[8]
            {
                ("Точно", new double[2]{1.01, 1}),
                ("Почти точно", new double[2] { 1, 0.9 }),
                ("Скорее", new double[2] { 0.9, 0.8 }),
                ("Не совсем", new double[2] { 0.8, 0.6 }),
                ("Наполовину", new double[2] { 0.6, 0.4 }),
                ("Немного", new double[2] { 0.4, 0.2 }),
                ("Совсем немного", new double[2] { 0.2, 0.1 }),
                ("Едва ли", new double[2] { 0.1, 0.01 })
            };
            int countTerms = 0;
            foreach (var pair in toStringList)
            {
                foreach (var range in listofRange)
                {
                    if (range.Item2[0] > pair.Item2 && pair.Item2 >= range.Item2[1])
                    {
                        result += $"{range.Item1} {pair.Item1}, ";
                        countTerms++;
                        break;
                    }
                }
            }
            result = result.Remove(result.Length - 2);
            if (countTerms > 1)
            {
                string and = " и ";
                int lastIndex = result.LastIndexOf(',');
                result = result.Remove(lastIndex, 2);
                result = result.Insert(lastIndex, and);
            }
            return result;
        }

        //Расчет свойств нечеткого множества
        public Tuple<double, string,List<object>, List<object>, List<object>> CalculationFuzzySetProperties(IMembershipFunction term, double sectionHeight) {

            if (!heightCache.ContainsKey(term))
            {
                heightCache[term] = CalculateHeight(term);
            }

            if (!typeCache.ContainsKey(term))
            {
                typeCache[term] = CalculateType(term);
            }
          
            if (!areaOfInfluenceCache.ContainsKey(term))
            {
                areaOfInfluenceCache[term] = CalculateAreaOfInfluence(term);
            }
            
            if (!coreCache.ContainsKey(term))
            {
                coreCache[term] = CalculateCore(term);
            }

            List<object> section = CalculateSection(term, sectionHeight);

            return Tuple.Create( heightCache[term], typeCache[term], areaOfInfluenceCache[term], coreCache[term], section);
        }
        private double CalculateHeight(IMembershipFunction term) {
            double maxHeight = 0;
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue > maxHeight)
                {
                    maxHeight = membershipValue;
                }
                baseSet.MoveNext();
            }
            return maxHeight;
        }

        private string CalculateType(IMembershipFunction term)
        {
            bool allZero = true;
            bool allOne = true;
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue != 0)
                {
                    allZero = false;
                }
                if (membershipValue != 1)
                {
                    allOne = false;
                }
                baseSet.MoveNext();
            }
            if (allZero)
            {
                return "Пустое";
            }
            else if (allOne)
            {
                return "Универсальное";
            }
            else if (heightCache[term] == 1)
            {
                return "Нормальное";
            }
            else
            {
                return "Субнормальное";
            }
        }

        private List<object> CalculateAreaOfInfluence(IMembershipFunction term)
        {
            var areaOfInfluence = new List<object>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue > 0)
                {
                    areaOfInfluence.Add(baseSet.Extraction());
                }
                baseSet.MoveNext();
            }
            return areaOfInfluence;
        }

        private List<object> CalculateCore(IMembershipFunction term)
        {
            List<object> result = new List<object>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue == 1)
                {
                    result.Add(baseSet.Extraction());
                }
                baseSet.MoveNext();
            }
            return result;
        }
        private List<object> CalculateSection(IMembershipFunction term, double sectionHeight)
        {
            var section = new List<object>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue > sectionHeight)
                {
                    section.Add(baseSet.Extraction());
                }
                baseSet.MoveNext();
            }
            return section;
        }
    }
}

