namespace SimpleFuzzy.Abstract
{
    public interface IGenerationMembershipFunctionService
    {
        public void AddCondition(string condition, string value);

        public void RemoveCondition(int index);

        public void ClearConditions();

        public string GenerateCode(Type inputType);
    }
}
