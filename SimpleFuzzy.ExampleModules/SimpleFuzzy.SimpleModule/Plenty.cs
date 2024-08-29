using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.SimpleModule
{
    public class Plenty : IMembershipFunction
    {
        public bool Active { get; set; }
        public string Name { get; } = "Много";

        public Type InputType => typeof(int);

        public double MembershipFunction(object elem)
        {
            int[] values = { 2800, 3000, 3800, 4000 };
            if (elem == null)
            {
                throw new ArgumentNullException(nameof(elem));
            }

            double doubleElem;
            try
            {
                doubleElem = Convert.ToDouble(elem);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to convert input to double", nameof(elem), ex);
            }
            double result;
            if (doubleElem <= values[0] || doubleElem >= values[3])
            {
                result = 0;
            }
            else if (doubleElem > values[0] && doubleElem <= values[1])
            {
                result = (doubleElem - values[0]) / (values[1] - values[0]);
            }
            else if (doubleElem > values[1] && doubleElem < values[2])
            {
                result = 1;
            }
            else // doubleElem >= values[2] && doubleElem < values[3]
            {
                result = (values[3] - doubleElem) / (values[3] - values[2]);
            }

            // Гарантируем, что результат находится в промежутке [0, 1]
            return Math.Max(0, Math.Min(1, result));

        }
    }
}