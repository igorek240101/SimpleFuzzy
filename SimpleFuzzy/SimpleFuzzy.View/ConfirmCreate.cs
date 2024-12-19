using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmCreate : UserControl
    {
        IRepositoryService repositoryService;
        IProjectListService projectList;
        IFilesPathsNamesValidator validator;
        public ConfirmCreate()
        {
            InitializeComponent();
            textBox2.Text = Directory.GetCurrentDirectory() + "\\Projects";
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            validator = AutofacIntegration.GetInstance<IFilesPathsNamesValidator>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.TrimEnd('.');// Для файла
            textBox1.Text = textBox1.Text.Trim(' ');
            textBox2.Text = textBox2.Text.TrimEnd('/');//Для пути
            textBox2.Text = textBox2.Text.TrimEnd('.');
            if (validator.IsValidFileName(textBox1.Text)&&validator.IsValidDirectoryName(textBox2.Text))
            {

                try { projectList.AddProject(textBox1.Text, textBox2.Text + $"\\{textBox1.Text}"); }
catch (Exception ex)
{
    MessageBox.Show($"{ex.Message}", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;
}
            }
            else
            {
                MessageBox.Show("Неверное имя файла или путь к нему!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Дальше открывается проект
            projectList.OpenProjectfromName(projectList.CurrentProjectName);
            if (Parent is MainWindow parent)
            {
                parent.Locked();
                parent.OpenLoader();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Projects\\";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = path;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            else { textBox2.Text = dialog.SelectedPath; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent && parent.lastControlEnum != null)
            {
                parent.SwichUserControl(parent.lastControlEnum, parent.lastButton);
            }
            else if (Parent is MainWindow parent1) 
            {
                parent1.ColorDelete();
                Parent.Controls.Remove(this); 
            }
        }

        private void ConfirmCreate_Load(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) parent.Locked();
        }
    }
}
