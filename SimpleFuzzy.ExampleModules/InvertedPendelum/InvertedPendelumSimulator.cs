using SimpleFuzzy.Abstract;
using System.Xml;

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

        public XmlNode SaveState(XmlDocument xmlDocument)
            => xmlDocument.CreateElement("");

        public void LoadState(XmlNode node)
        {
        }

        public void SetController(Func<List<object>, List<object>> controller)
        {
        }
    }
}
