using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmSaveAs : UserControl
    {
        IProjectListService projectList;
        public ConfirmSaveAs()
        {
            InitializeComponent();
            textBox1.Text = Directory.GetCurrentDirectory() + "\\Projects";
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Projects\\";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = path;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            else { textBox1.Text = dialog.SelectedPath; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (metroTextBox1 == null)
            {
                MessageBox.Show("Введите новое имя проекта");
                return;
            }
            try { projectList.CopyProject(metroTextBox1.Text, textBox1.Text + "\\" + metroTextBox1.Text, true); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            button3_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
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
