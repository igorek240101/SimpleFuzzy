using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : Form, IDisposable
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
        public UserControl currentControl = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SwichUserControl(UserControlsEnum? newWindowName)
        {
            var toRemove = new MainWindow();
            if (newWindowName.HasValue && currentControl == null) return;
            if (currentControl != null){
                toRemove.Controls.Remove(currentControl);
                toRemove.Dispose();
            }
            if(newWindowName.HasValue){
                currentControl = UserControls[newWindowName.Value]();
                toRemove.Controls.Add(currentControl);
            }
        }
    }
}
