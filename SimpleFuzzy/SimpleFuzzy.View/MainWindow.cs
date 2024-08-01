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
        private void button7_Click(object sender, EventArgs e)
        {
            LoaderForm form = new LoaderForm();
            Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FasificationForm form = new FasificationForm();
            Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InferenceForm form = new InferenceForm();
            Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DefasificationForm form = new DefasificationForm();
            Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SimulationForm form = new SimulationForm();
            Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        public void Locked()
        {
            if (projectList.CurrentProjectName == null)
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
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
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }
        public void OpenButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
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