using Scriban;

namespace SimpleFuzzy.Service
{
    public class GenerationObjectSet
    {
        public GenerationObjectSet(double first, double stepik, double last, string path)
        {
            if (Math.Sign(last - first) != Math.Sign(stepik) || (last - first) % stepik != 0 || stepik == 0)
            {
                throw new InvalidOperationException("Создание множества с такими параметрами невозможно");
            }
            else
            {
                string classTemplate = @"
namespace SimpleFuzzy.Abstract
{
    public class ObjectSet : IObjectSet
    {
        private double initalvalue = {{ initalvalue }};
        private double currentvalue = {{ initalvalue }};
        private double limitvalue = {{ limitvalue }};
        private double step = {{ step }};

        public object Extraction()
        {
            return currentvalue;
        }

        public void MoveNext()
        {
            currentvalue = currentvalue + step;
            if (IsEnd())
            {
                throw new InvalidOperationException(""Текущий элемент последний. Переход к следующему невозможен"");
            }
        }

        public void ToFirst() => currentvalue = initalvalue;

        public bool IsEnd() => currentvalue > limitvalue;
    }
}
";
                var data = new
                {
                    @initalvalue = $"{first}",
                    step = $"{stepik}",
                    limitvalue = $"{last}"
                };

                var template = Template.Parse(classTemplate);
                var result = template.Render(data);

                File.WriteAllText(path, result);
            }
        }
    }
}
