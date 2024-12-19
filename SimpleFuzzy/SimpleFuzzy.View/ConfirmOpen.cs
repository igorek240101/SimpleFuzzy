using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmOpen : UserControl
    {
        IProjectListService projectList;
        public ConfirmOpen()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            projectList.CheckAll();
            label2.Visible = false;
            string[] list = projectList.GiveList();
            for (int i = 1; i < list.Length; i += 3)
            {
                if (Directory.Exists(list[i])) { listBox1.Items.Add(list[i - 1]); }
                else { projectList.DeleteOnlyInList(list[i - 1]); }
            }
            if (listBox1.Items.Count == 0)
            {
                label2.Text = "Проектов пока нет, перейдите к созданию проекта";
                label2.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = Directory.GetCurrentDirectory() + "\\Projects\\";
            if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
            if (dialog.SelectedPath == "") { return; }
            try
            {
                // дальше по выбранной папке открывается проект
                projectList.OpenProjectfromPath(dialog.SelectedPath);
                if (Parent is MainWindow parent)
                {
                    parent.Locked();
                    parent.OpenLoader();
                    // Обновляем состояние симулятора после открытия проекта
                    parent.UpdateSimulatorState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка открытия", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (listBox1 == null) { return; }
            label2.Visible = false;
            string[] list = projectList.GiveList();
            bool isEmpty = true;
            listBox1.Items.Clear();
            for (int i = 0; i < list.Length; i += 3)
            {
                bool isContain = true;
                for (int j = 0; j < textBox1.Text.Length && j < list[i].Length; j++)
                {
                    if (list[i][j] != textBox1.Text[j])
                    {
                        isContain = false;
                        break;
                    }
                }
                if (isContain && textBox1.Text.Length <= list[i].Length)
                {
                    listBox1.Items.Add(list[i]);
                    isEmpty = false;
                }
            }
            if (isEmpty)
            {
                label2.Text = "Файлов с таким именем не найдено...";
                label2.Visible = true;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string projectName = listBox1.SelectedItem.ToString();
                // открытие проекта
                projectList.OpenProjectfromName(projectName);
                if (Parent is MainWindow parent)
                {
                    parent.Locked();
                    parent.OpenLoader();
                    // Обновляем состояние симулятора после открытия проекта
                    parent.UpdateSimulatorState();
                }
            }
        }
        private void ConfirmOpen_Load(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) parent.Locked();
        }
    }
}
