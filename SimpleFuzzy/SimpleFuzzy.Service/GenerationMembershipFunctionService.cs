using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Service
{
    public class GenerationMembershipFunctionService : IGenerationMembershipFunctionService
    {
        private readonly List<(string Condition, string Value)> _conditions = new List<(string, string)>();

        public void AddCondition(string condition, string value)
        {
            _conditions.Add((condition, value));
        }

        public void RemoveCondition(int index)
        {
            if (index >= 0 && index < _conditions.Count)
            {
                _conditions.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public void ClearConditions()
        {
            _conditions.Clear();
        }

        public string GenerateCode(Type inputType)
        {
            var conditionsCode = string.Join(", ", _conditions.Select(c => $"(({c.Condition}), ({c.Value}))"));

            return $@"
namespace SimpleFuzzy.SimpleModule
{{
    public class MembershipFunc : IMembershipFunction
    {{
        public Type InputType => typeof({inputType});
        public bool HasOverlappingConditions {{ get; private set; }}

        public double MembershipFunction(object elem)
        {{
            if (elem == null)
            {{
                throw new ArgumentNullException(nameof(elem));
            }}

            {inputType} inputValue;
            try
            {{
                inputValue = ({inputType})Convert.ChangeType(elem, typeof({inputType}));
            }}
            catch (Exception ex)
            {{
                throw new ArgumentException($""Unable to convert input to {inputType}"", nameof(elem), ex);
            }}

            double maxValue = double.MinValue;
            bool foundTrue = false;
            foreach (var condition in new [] {{ {conditionsCode} }})
            {{
                if (condition.Item1)
                {{
                    if (foundTrue)
                    {{
                        HasOverlappingConditions = true;
                    }}
                    foundTrue = true;
                    double value = condition.Item2;
                    if (value > maxValue)
                    {{
                        maxValue = value;
                    }}
                }}
            }}

            return maxValue;
        }}
    }}
}}";
        }
    }
}