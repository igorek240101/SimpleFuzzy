using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Model
{
    public class LinguisticVariable
    {
        public string name; // Имя лингвистической переменной
        public IObjectSet baseSet; // Базовое множество
        public List<IMembershipFunction> func = new List<IMembershipFunction>(); // Список термов
        public readonly bool isRedact; // Возможность редактирования

        public LinguisticVariable(bool isRedact)
        {
            this.isRedact = isRedact;
        }

        public string Name
        {
            get { return name; }
            set { if (isRedact == true) { name = value; } }
        }

        public IObjectSet BaseSet
        {
            get { return baseSet; }
            set { if (isRedact == true) { baseSet = value; } }
        }

        public void AddTerm(IMembershipFunction term)
        {
            Type Type1 = baseSet.Extraction().GetType(), Type2 = func[0].GetType(); // Проверка типов данных
            if (Type1 != Type2)
            {
                throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают");
            }
            else
            {
                func.Add(term);
            }
        }

        public void DeleteTerm(IMembershipFunction term) => func.Remove(term);

        public Dictionary<object, List<double>> Graphic()  // Создание массива списков для графика
        {
            var graphicList = new Dictionary<object, List<double>>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                graphicList.Add(baseSet.Extraction(), Fazzification(baseSet.Extraction()));
                baseSet.MoveNext();
            }
            return graphicList;
        }

        public List<double> Fazzification(object elementBaseSet)
        {
            var list = new List<double>();
            foreach (var function in func)
            {
                list.Add(function.MembershipFunction(elementBaseSet));
            }
            return list;
        }
    }
}
