using SimpleFuzzy.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFuzzy.View
{
    public partial class ConfirmCopy : UserControl
    {
        MainWindow window;
        ProjectList projectList;
        public ConfirmCopy()
        {
            InitializeComponent();
            label1.Text = "Расположение";
            textBox1.Text = Directory.GetCurrentDirectory() + "\\Projects";
            button1.Text = "Открыть проводник";
            button2.Text = "Готово";
            button3.Text = "Отмена";
        }
        public ConfirmCopy(MainWindow mainWindow, ProjectList project) : this()
        {
            window = mainWindow;
            projectList = project;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Projects";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = path;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            else { textBox1.Text = dialog.SelectedPath; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { projectList.AddProject(projectList.currentProjectName + " - копия", textBox1.Text + $"\\{projectList.currentProjectName} - копия"); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DirectoryInfo directory = new DirectoryInfo(textBox1.Text + $"\\{projectList.currentProjectName} - копия");
            directory.Create();
            DirectoryInfo source = new DirectoryInfo(projectList.GivePath(projectList.currentProjectName, true));
            DirectoryInfo destin = new DirectoryInfo(textBox1.Text + $"\\{projectList.currentProjectName} - копия");
            foreach (var item in source.GetFiles()) { item.CopyTo(destin + item.Name, true); }
            window.OpenButtons(sender, e);
            window.Controls.Remove(this);
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            window.OpenButtons(sender, e);
            window.Controls.Remove(this);
        }

        private void ConfirmCopy_Load(object sender, EventArgs e)
        {
            window.BlockButtons(sender, e);
        }
    }
}
