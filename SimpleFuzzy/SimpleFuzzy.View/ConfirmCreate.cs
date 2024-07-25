
using SimpleFuzzy.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class ConfirmCreate : UserControl
    {
        ProjectList projectList;
        MainWindow window;
        public ConfirmCreate()
        {
            InitializeComponent();
            label1.Text = "Введите имя проекта";
            label2.Text = "Расположение";
            textBox2.Text = Directory.GetCurrentDirectory() + "\\Projects";
            button1.Text = "Готово";
            button2.Text = "Открыть проводник";
            button3.Text = "Отмена";

        }
        public ConfirmCreate(MainWindow mainWindow, ProjectList project) : this()
        {
            window = mainWindow;
            projectList = project;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") throw new InvalidOperationException("Некорректное имя проекта");
                else
                {
                    projectList.currentProjectName = textBox1.Text; // Устанавливаем имя текущего проекта
                    projectList.AddProject(projectList.currentProjectName, textBox2.Text + $"\\{projectList.currentProjectName}");
                    textBox1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DirectoryInfo directory = new DirectoryInfo(textBox2.Text + $"\\{projectList.currentProjectName}");
            directory.Create();
            window.OpenButtons(sender, e);
            window.Locked(sender, e);
            window.Controls.Remove(this);
            // Дальше открывается проект
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Projects";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = path;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            else { textBox2.Text = dialog.SelectedPath; }
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            window.OpenButtons(sender, e);
            window.Locked(sender, e);
            window.Controls.Remove(this);
        }

        private void ConfirmCreate_Load(object sender, EventArgs e) 
        { 
            window.BlockButtons(sender, e);
        }
    }
}
