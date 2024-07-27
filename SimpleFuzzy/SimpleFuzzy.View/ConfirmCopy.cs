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
        SimpleFuzzy window;
        ProjectListService projectList;
        public ConfirmCopy(SimpleFuzzy mainWindow, ProjectListService project) 
        {
            InitializeComponent();
            window = mainWindow;
            projectList = project;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = projectList.OpenExplorer(Directory.GetCurrentDirectory() + "\\Projects", textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { projectList.CopyProject(projectList.currentProjectName + " - копия", textBox1.Text + $"\\{projectList.currentProjectName} - копия"); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            button3_Click(sender, e);
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
