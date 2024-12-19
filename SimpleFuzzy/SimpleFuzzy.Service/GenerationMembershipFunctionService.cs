using SimpleFuzzy.Abstract;
using System.Xml.Linq;

namespace SimpleFuzzy.Service
{
    public class GenerationMembershipFunctionService : IGenerationMembershipFunctionService
    {

        public string GenerateCode(Type inputType, string name, List<(string Condition, string Value)> conditions)
        {
            var conditionsCode = string.Join(", ", conditions.Select(c => $"(({c.Condition}), ({c.Value}))"));

            return $@"
using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SimpleFuzzy.Abstract;
namespace SimpleFuzzy.GenerateModule
{{
    public class MembershipFunc : IMembershipFunction
    {{
        public Type InputType => typeof({inputType});
        public bool HasOverlappingConditions {{ get; private set; }}

        public bool Active {{ get; set; }}

        public string Name {{ get; set; }} = ""{name}"";

        public double MembershipFunction(object elem)
        {{
            if (elem == null)
            {{
                throw new ArgumentNullException(nameof(elem));
            }}

            {inputType} value;
            try
            {{
                value = ({inputType})Convert.ChangeType(elem, typeof({inputType}));
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
                    double resValue = condition.Item2;
                    if (resValue > maxValue)
                    {{
                        maxValue = resValue;
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