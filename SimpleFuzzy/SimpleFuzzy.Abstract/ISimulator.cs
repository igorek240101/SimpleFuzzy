using System.Xml;

namespace SimpleFuzzy.Abstract
{
    public interface ISimulator : IModulable
    {
        object GetVisualObject();

        List<LinguisticVariableDto> GetLinguisticVariables();

        void SetController(Func<List<object>, List<object>> controller);

        XmlNode SaveState(XmlDocument xmlDocument);

        void LoadState(XmlNode node);
    }
}
