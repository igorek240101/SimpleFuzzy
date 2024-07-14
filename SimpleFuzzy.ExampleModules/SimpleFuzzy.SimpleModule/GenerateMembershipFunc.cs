using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.SimpleModule
{
    public class GenerateMembershipFunc : IMembershipFunction
    {
        private Type inputType;
        private List<Tuple<string,string>> conditions;
        private double result;

        public GenerateMembershipFunc(Type inputType)
        {
            this.inputType = inputType;
            conditions = new List<Tuple<string,string>>();
        }
        public Type InputType => inputType;
        public void AddCondition(string condition, string value)
        {
            conditions.Add(new Tuple<string, string>(condition, value));
        }
        public void RemoveCondition(int index)
        {
            if (index < 0 || index >= conditions.Count)
            {
                return;
            }
            conditions.RemoveAt(index);
        }
        public double MembershipFunction(object elem)
        {
            if (elem == null || !inputType.IsInstanceOfType(elem))
            {
                throw new ArgumentException("Invalid input element type.");
            }
            int responceCounter = 0;
            bool conditionResult;
            double value = 0;
            foreach (var condition in conditions)
            {
                try
                {

                    conditionResult = EvaluateCondition(elem, condition.Item1);
                    if (conditionResult)
                    {
                        responceCounter += 1;
                        if (responceCounter > 1)
                        {
                            value = Math.Max(value, EvaluateValue(elem, condition.Item2));
                        }
                        else
                        {
                            value = EvaluateValue(elem, condition.Item2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error evaluating condition or value: {ex.Message}");
                }
            }
            return Math.Max(0, Math.Min(1, value));
        }
        private bool EvaluateCondition(object elem, string condition)
        {
            // Приведение условия к нужному типу и совершение необходимых операций
            throw new NotImplementedException();
        }

        private double EvaluateValue(object elem, string value)
        {
            // Приведение значения к нужному типу и совершение необходимых операций
            throw new NotImplementedException();
        }
    }
}
