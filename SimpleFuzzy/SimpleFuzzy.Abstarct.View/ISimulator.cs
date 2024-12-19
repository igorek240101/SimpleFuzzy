
using System.Windows.Forms;

namespace SimpleFuzzy.Abstract
{
    public interface ISimulator : IModulable
    {
        UserControl GetVisualObject();
    }
}
