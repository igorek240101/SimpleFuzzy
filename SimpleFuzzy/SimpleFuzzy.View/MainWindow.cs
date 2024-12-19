using System.IO;
using System.Runtime.Loader;
using SimpleFuzzy.Abstract;
using WindowsFormsUtils;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : Form
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
        public static ColorDialog colorDialog = new ColorDialog();
        public UserControl currentControl = null;
        IProjectListService projectList;
        IRepositoryService repositoryService;
        private ToolStripMenuItem[] workspaceButtons;
        bool IsShownToolTip1 = false;
        bool IsShownToolTip2 = false;
        public bool isContainSimulator = false;

        public UserControlsEnum? currentControlEnum;
        public UserControlsEnum? lastControlEnum;
        public ToolStripMenuItem lastButton;
        public ToolStripMenuItem currentButton;
        public MainWindow()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            // Инициализация массива кнопок рабочего пространства
            workspaceButtons = new ToolStripMenuItem[] { button1, button2, button3, button4, button5, button7, button8,
                button9, button10, button11 };
            menuStrip1.Renderer = new CustomizedMenuRenderer();
            menuStrip2.Renderer = new CustomizedMenuRenderer();
            UserControls.Add(UserControlsEnum.Create, () => new ConfirmCreate());
            UserControls.Add(UserControlsEnum.Open, () => new ConfirmOpen());
            UserControls.Add(UserControlsEnum.Delete, () => new ConfirmDelete());
            UserControls.Add(UserControlsEnum.Rename, () => new ConfirmRename());
            UserControls.Add(UserControlsEnum.SaveAs, () => new ConfirmSaveAs());
            UserControls.Add(UserControlsEnum.Loader, () => new LoaderForm());
            UserControls.Add(UserControlsEnum.Fasification, () => new FasificationForm());
            UserControls.Add(UserControlsEnum.Inference, () => new InferenceForm());
            UserControls.Add(UserControlsEnum.Defasification, () => new DefasificationForm());
            UserControls.Add(UserControlsEnum.Simulation, () => AddSimulation());
            Left.Visible = false;
            Right.Visible = false;
            Locked();
            timer1.Start();
        }
        //////////////////// Выбор цвета
        private Color ActiveColor() { return Color.LightBlue; }
        //////////////////// Вспомогательные функции
        private UserControl AddSimulation()
        {
            ISimulator simulator = repositoryService.GetCollection<ISimulator>().FirstOrDefault(t => t.Active);
            if (simulator != null)
            {
                return simulator.GetVisualObject() as UserControl;
            }
            throw new Exception("Нет активной симуляции");
        }

        public void ChangeNameOfProject()
        {
            if (projectList.CurrentProjectName != null) label1.Text = "Имя текущего проекта: " + projectList.CurrentProjectName;
            else label1.Text = "";
        }
        public void OpenLoader()
        {
            if (projectList.CurrentProjectName != null) label1.Text = "Имя текущего проекта: " + projectList.CurrentProjectName;
            SwichUserControl(UserControlsEnum.Loader, button7);
        }
        public void UpdateSimulatorState()
        {
            isContainSimulator = repositoryService.GetCollection<ISimulator>().Any(t => t.Active);
            button11.Enabled = isContainSimulator;
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
                Left.Enabled = false;
                Right.Enabled = false;
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
                if (isContainSimulator) button11.Enabled = true;
                else button11.Enabled = false;
                Left.Enabled = true;
                Right.Enabled = true;
            }
        }

        public void EnableSimulationsButton(bool enable)
        {
            if (enable) button11.Enabled = true;
            else button11.Enabled = false;
        }
        public void ColorDelete()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            lastControlEnum = null;
            lastButton = null;
        }

        private bool IsSecondMenu(UserControlsEnum? control)
        {
            if (control == UserControlsEnum.Create || control == UserControlsEnum.Open ||
                control == UserControlsEnum.Delete || control == UserControlsEnum.Rename ||
                control == UserControlsEnum.SaveAs) return false;
            else return true;
        }
        ////////////////////// Нажатие кнопок на menuStrip
        private void button1_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Create, button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Open, button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Delete, button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Rename, button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.SaveAs, button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            projectList.SaveAll();
            // сохранение
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Loader, button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Fasification, button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Inference, button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Defasification, button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Simulation, button11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (aboutBox == null || aboutBox.IsDisposed)
            {
                aboutBox = new AboutBox();
                aboutBox.Show();
            }
            else
            {
                aboutBox.Show();
                aboutBox.Focus();
            }

        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (helpWindow == null || helpWindow.IsDisposed)
            {
                helpWindow = new HelpWindow();
                helpWindow.Show();
            }
            else
            {
                helpWindow.Show();
                helpWindow.Focus();
            }
        }

        ////////////////// Переход между элементами управления
        public void SwichUserControl(UserControlsEnum? newWindowName, ToolStripMenuItem clickedButton)
        {
            foreach (var item in workspaceButtons)
            {
                item.BackColor = DefaultBackColor;
                item.Enabled = true;
            }
            if (isContainSimulator) button11.Enabled = true;
            else button11.Enabled = false;
            clickedButton.BackColor = ActiveColor();
            clickedButton.Enabled = false;
            if (!isContainSimulator) button11.Enabled = false;
            if (IsSecondMenu(currentControlEnum))
            {
                lastControlEnum = currentControlEnum;
                lastButton = currentButton;
            }

            var toRemove = this;
            if (currentControl != null)
            {
                toRemove.Controls.Remove(currentControl);
                currentControl.Dispose();
            }
            if (newWindowName.HasValue)
            {
                currentControl = UserControls[newWindowName.Value]();
                currentControlEnum = newWindowName;
                currentButton = clickedButton;
                toRemove.Controls.Add(currentControl);
                currentControl.Location = new Point(0, 150);
            }
            RightLeftEnable(newWindowName);
        }

        private void RightLeftEnable(UserControlsEnum? newWindowName)
        {
            if (newWindowName == UserControlsEnum.Loader)
            {
                Left.Enabled = false;
                Right.Enabled = true;
                return;
            }
            if (newWindowName == UserControlsEnum.Inference || newWindowName == UserControlsEnum.Fasification)
            {
                Left.Enabled = true;
                Right.Enabled = true;
                return;
            }
            if (newWindowName == UserControlsEnum.Defasification)
            {
                Left.Enabled = true;
                if (isContainSimulator) Right.Enabled = true;
                else { Right.Enabled = false; }
                return;
            }
            if (newWindowName == UserControlsEnum.Simulation)
            {
                Left.Enabled = true;
                Right.Enabled = false;
                return;
            }
            else
            {
                Left.Enabled = false;
                Right.Enabled = false;
                return;
            }
        }

        //////////////////// Подсветка подсказки симулятора
        private void timer1_Tick(object sender, EventArgs e)
        {
            var v = new Point(MousePosition.X - (Location.X + menuStrip2.Location.X + button11.Bounds.Location.X),
                MousePosition.Y - (Location.Y + menuStrip2.Location.Y + button11.Bounds.Location.Y));
            if (v.X >= 0 && v.X <= button11.Width && v.Y >= 0 && v.Y <= button11.Height)
            {
                if (!IsShownToolTip1 && projectList.CurrentProjectName != null && !isContainSimulator)
                {
                    toolTip1.SetToolTip(menuStrip2, "Симуляция не загружена в проект или отключена в окне загрузчика");
                    string tipstring = toolTip1.GetToolTip(menuStrip2);
                    toolTip1.Show(tipstring, menuStrip2, menuStrip2.Width / 2, menuStrip2.Height / 2);
                    IsShownToolTip1 = true;
                }
            }
            else
            {
                toolTip1.Hide(menuStrip2);
                IsShownToolTip1 = false;
                toolTip1.SetToolTip(menuStrip2, null);
            }

            var t = new Point(MousePosition.X - (Location.X + Right.Location.X),
               MousePosition.Y - (Location.Y + Right.Location.Y));
            if (t.X >= 0 && t.X <= Right.Width && t.Y >= 0 && t.Y <= Right.Height)
            {
                if (!IsShownToolTip2 && !isContainSimulator && projectList.CurrentProjectName != null && Right.Enabled == false)
                {
                    toolTip2.SetToolTip(Right, "Симуляция не загружена в проект или отключена в окне загрузчика");
                    string tipstring = toolTip2.GetToolTip(Right);
                    toolTip2.Show(tipstring, Right, Right.Width / 2, Right.Height / 2);
                    IsShownToolTip2 = true;
                }
            }
            else
            {
                toolTip2.Hide(Right);
                IsShownToolTip2 = false;
                toolTip2.SetToolTip(Right, null);

            }
        }
        //////////////////// Кнопки вправо влево
        private void Left_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Loader, button7);
                Left.Enabled = false;
                return;
            }
            if (button9.BackColor == ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Fasification, button8);
                return;
            }
            if (button10.BackColor == ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Inference, button9);
                Right.Enabled = true;
                return;
            }
            if (button11.BackColor == ActiveColor() && isContainSimulator == true)
            {
                SwichUserControl(UserControlsEnum.Defasification, button10);
                Right.Enabled = true;
                return;
            }
        }

        private void Right_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Fasification, button8);
                return;
            }
            if (button8.BackColor == ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Inference, button9);
                return;
            }
            if (button9.BackColor == ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Defasification, button10);
                return;
            }
            if (button10.BackColor == ActiveColor() && isContainSimulator == true)
            {
                SwichUserControl(UserControlsEnum.Simulation, button11);
                return;
            }
        }
    }
}