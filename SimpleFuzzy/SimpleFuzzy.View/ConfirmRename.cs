using SimpleFuzzy.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFuzzy.View
{
    public partial class ConfirmRename : UserControl
    {
        ProjectList projectList;
        MainWindow window;
        public ConfirmRename()
        {
            InitializeComponent();
            button1.Text = "Готово";
            button2.Text = "Отмена";
            label1.Text = "Введите новое имя";
        }
        public ConfirmRename(MainWindow mainWindow, ProjectList project) : this()
        {
            window = mainWindow;
            projectList = project;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = projectList.GivePath(projectList.currentProjectName, true), newPath = projectList.GivePath(projectList.currentProjectName, false) + $"\\{textBox1.Text}";
            try { projectList.RedactNameProject(projectList.currentProjectName, textBox1.Text, path, newPath); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            projectList.currentProjectName = textBox1.Text; // Присваивание нового имени текущего проекта
            DirectoryInfo directory = new DirectoryInfo(path);
            Directory.Move(path, newPath);
            window.OpenButtons(sender, e);
            window.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            window.OpenButtons(sender, e);
            window.Controls.Remove(this);
        }

        private void ConfirmRename_Load(object sender, EventArgs e)
        {
            window.BlockButtons(sender, e);
        }
    }
}
