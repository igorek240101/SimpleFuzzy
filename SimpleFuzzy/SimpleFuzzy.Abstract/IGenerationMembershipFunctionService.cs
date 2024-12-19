namespace SimpleFuzzy.Abstract
{
    public interface IGenerationMembershipFunctionService
    {
        public string GenerateCode(Type inputType, string name, List<(string Condition, string Value)> conditions);
    }
}
