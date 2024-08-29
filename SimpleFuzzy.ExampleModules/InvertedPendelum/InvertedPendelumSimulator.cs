using SimpleFuzzy.Abstract;

namespace InvertedPendelum
{
    public class InvertedPendelumSimulator : ISimulator
    {
        public bool Active { get ; set; }

        public string Name { get; } = "Inverted Pendelum";

        public List<LinguisticVariableDto> GetLinguisticVariables() => new List<LinguisticVariableDto>();

        public object GetVisualObject()
        {
            throw new NotImplementedException();
        }

        public void SetController(Func<List<object>, List<object>> controller)
        {
            throw new NotImplementedException();
        }
    }
}
