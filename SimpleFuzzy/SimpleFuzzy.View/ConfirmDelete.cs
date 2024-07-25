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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFuzzy.View
{
    public partial class ConfirmDelete : UserControl
    {
        ProjectList projectList;
        MainWindow window;
        public ConfirmDelete()
        {
            InitializeComponent();
            label1.Text = "Вы действительно хотите безвозвратно удалить текущий проект?";
            button1.Text = "Да";
            button2.Text = "Нет";
        }
        public ConfirmDelete(MainWindow mainWindow, ProjectList project) : this()
        {
            window = mainWindow;
            projectList = project;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(projectList.GivePath(projectList.currentProjectName, true));
            foreach (FileInfo file in directory.GetFiles()) { file.Delete(); }
            Directory.Delete(projectList.GivePath(projectList.currentProjectName, true), true);
            projectList.DeleteProject(projectList.currentProjectName);
            projectList.currentProjectName = null; // Обнуляeм имя текущего проекта
            window.OpenButtons(sender, e);
            window.Locked(sender, e);
            window.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            window.OpenButtons(sender, e);
            window.Controls.Remove(this);
        }

        private void ConfirmDelete_Load(object sender, EventArgs e)
        {
            window.BlockButtons(sender, e);
        }
    }
}
