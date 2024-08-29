using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmRename : UserControl
    {
        IProjectListService projectList;
        public ConfirmRename()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                projectList.RenameProject(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent && parent.lastControlEnum != null)
            {
                parent.ChangeNameOfProject();
                parent.SwichUserControl(parent.lastControlEnum, parent.lastButton);
            }
            else { Parent.Controls.Remove(this); }
        }
    }
}
