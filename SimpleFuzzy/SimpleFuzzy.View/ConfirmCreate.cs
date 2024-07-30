using SimpleFuzzy.Abstract;
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
        IProjectListService projectList;
        MainWindow window;
        public MainWindow Window { set { window = value; } }
        public ConfirmCreate()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try { projectList.AddProject(textBox1.Text, textBox2.Text + $"\\{textBox1.Text}"); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            button3_Click(sender, e);
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
