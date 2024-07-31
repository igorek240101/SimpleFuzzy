using SimpleFuzzy.Abstract;
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
        IProjectListService projectList;
        public ConfirmRename()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
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
            if (Parent is MainWindow parent) { parent.OpenButtons(); }
            Parent.Controls.Remove(this);
        }

        private void ConfirmRename_Load(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) { parent.BlockButtons(); }
        }
    }
}
