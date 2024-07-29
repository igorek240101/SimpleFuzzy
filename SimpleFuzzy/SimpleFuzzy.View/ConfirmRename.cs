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
        ProjectListService projectList;
        MainWindow window;
        public ConfirmRename(MainWindow mainWindow, ProjectListService project)
        {
            InitializeComponent();
            window = mainWindow;
            projectList = project;
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
            window.OpenButtons(sender, e);
            window.Controls.Remove(this);
        }

        private void ConfirmRename_Load(object sender, EventArgs e)
        {
            window.BlockButtons(sender, e);
        }
    }
}
