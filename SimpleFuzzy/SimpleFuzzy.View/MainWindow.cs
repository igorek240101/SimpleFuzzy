using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;
using System;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : Form
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
        public UserControl currentControl = null;
        IProjectListService projectList; 
        public MainWindow()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmCreate confirm = new ConfirmCreate();
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmOpen confirm = new ConfirmOpen();
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfirmDelete confirm = new ConfirmDelete();
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConfirmRename confirm = new ConfirmRename();
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConfirmCopy confirm = new ConfirmCopy();
            Controls.Add(confirm);
            confirm.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // сохранение
        }
        public void Locked()
        {
            if (projectList.CurrentProjectName == null)
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
        public void BlockButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }
        public void OpenButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow(this);
            help.Show();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SwichUserControl(UserControlsEnum? newWindowName)
        {
            var toRemove = this;
            if (currentControl != null){
                toRemove.Controls.Remove(currentControl);
                currentControl.Dispose();
            }
            if(newWindowName.HasValue){
                currentControl = UserControls[newWindowName.Value]();
                toRemove.Controls.Add(currentControl);
            }
        }
    }
}