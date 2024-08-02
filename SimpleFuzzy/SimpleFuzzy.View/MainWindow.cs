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
        private Button[] workspaceButtons;
        public bool simulationLoaded = false; // Флаг загрузки симуляции
        public MainWindow()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();

            // Инициализация массива кнопок рабочего пространства
            workspaceButtons = new Button[] { button7, button8, button9, button10, button11 };

            UserControls.Add(UserControlsEnum.Create, () => new ConfirmCreate());
            UserControls.Add(UserControlsEnum.Open, () => new ConfirmOpen());
            UserControls.Add(UserControlsEnum.Delete, () => new ConfirmDelete());
            UserControls.Add(UserControlsEnum.Rename, () => new ConfirmRename());
            UserControls.Add(UserControlsEnum.Copy, () => new ConfirmCopy());
            UserControls.Add(UserControlsEnum.Loader, () => new LoaderForm());
            UserControls.Add(UserControlsEnum.Fasification, () => new FasificationForm());
            UserControls.Add(UserControlsEnum.Inference, () => new InferenceForm());
            UserControls.Add(UserControlsEnum.Defasification, () => new DefasificationForm());
            UserControls.Add(UserControlsEnum.Simulation, () => new SimulationForm());

            Locked();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Create);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Open);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Delete);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Rename);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Copy);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // сохранение
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Loader, button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Fasification, button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Inference, button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Defasification, button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (IsSimulationLoaded()) SwitchWorkspace(UserControlsEnum.Simulation, button11);
        }

        // Методы для переключения рабочего пространства
        private void SwitchWorkspace(UserControlsEnum workspace, Button clickedButton)
        {
            foreach (Button button in workspaceButtons)
            {
                button.BackColor = SystemColors.Control;
                button.Enabled = true;
            }
            // Выделение цветом нажатой кнопки и отключение ее
            clickedButton.BackColor = Color.LightGray;
            clickedButton.Enabled = false;

            // Переключение UserControl
            SwichUserControl(workspace);
        }
        private void SwitchWorkspace(UserControlsEnum workspace)
        {
            foreach (Button button in workspaceButtons)
            {
                button.BackColor = SystemColors.Control;
                button.Enabled = true;
            }
            // Переключение UserControl
            SwichUserControl(workspace);
        }
        public void OpenLoader()
        {
            SwitchWorkspace(UserControlsEnum.Loader, button7);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();

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
            if (currentControl != null)
            {
                toRemove.Controls.Remove(currentControl);
                currentControl.Dispose();
            }
            if (newWindowName.HasValue)
            {
                currentControl = UserControls[newWindowName.Value]();
                toRemove.Controls.Add(currentControl);
            }
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {

            if (!IsSimulationLoaded()) { textBox1.Visible = true; }
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Visible = false;
        }

        public bool IsSimulationLoaded() // полная проверка на наводимость
        {
            // НАДО НАПИСАТЬ ФУНКЦИЮ, ПРОВЕРЯЮЩУЮ СОДЕРЖАНИЕ ЗАГРУЖЕННЫХ СИМУЛЯЦИЙ
            if (simulationLoaded == true) return true;
            else return false;
        }
    }
}