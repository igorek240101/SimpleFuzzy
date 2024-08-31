using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmRename : UserControl
    {
        IProjectListService projectList;
        IFilesPathsNamesValidator validator;
        public ConfirmRename()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            validator = AutofacIntegration.GetInstance<IFilesPathsNamesValidator>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.TrimEnd('.');// Для файла
            textBox1.Text = textBox1.Text.Trim(' ');
            
            if (validator.IsValidFileName(textBox1.Text))
            {
                try
                {
                    projectList.RenameProject(textBox1.Text);
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "Ошибка переименования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверное имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
