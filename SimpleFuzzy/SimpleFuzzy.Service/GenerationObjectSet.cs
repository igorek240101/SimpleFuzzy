namespace SimpleFuzzy.Service
{
    public class GenerationObjectSet
    {
        public static string ReturnObjectSet(double first, double stepik, double last)
        {
            if (Math.Sign(last - first) != Math.Sign(stepik) || (last - first) % stepik != 0 || stepik == 0)
            {
                throw new InvalidOperationException("Создание множества с такими параметрами невозможно");
            }
            else
            {
                string classTemplate = $@"
namespace SimpleFuzzy.Abstract
{{
    public class ObjectSet : IObjectSet
    {{
        private double initalvalue = {first};
        private double currentvalue = {first};
        private double limitvalue = {last};
        private double step = {stepik};

        public object Extraction()
        {{
            return currentvalue;
        }}

        public void MoveNext()
        {{
            currentvalue = currentvalue + step;
            if (IsEnd())
            {{
                throw new InvalidOperationException(""Текущий элемент последний. Переход к следующему невозможен"");
            }}
        }}

        public void ToFirst() => currentvalue = initalvalue;

        public bool IsEnd() => currentvalue > limitvalue;
    }}
}}
";
                return classTemplate;
            }
        }
    }
}
