using SimpleFuzzy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFuzzy.Service;
using System;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class MainWindow : Form
    {
        private LinguisticVariableUI linguisticVariableUI;
        ProjectListService projectList; 

        public MainWindow()
        {
            projectList = new ProjectListService(); 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmCreate confirm = new ConfirmCreate(this, projectList);
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmOpen confirm = new ConfirmOpen(this, projectList);
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfirmDelete confirm = new ConfirmDelete(this, projectList);
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConfirmRename confirm = new ConfirmRename(this, projectList);
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConfirmCopy confirm = new ConfirmCopy(this, projectList);
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // сохранение
        }
        public void Locked(object sender, EventArgs e)
        {
            if (projectList.currentProjectName == null)
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
        }
        public void BlockButtons(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }
        public void OpenButtons(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }
    }
}