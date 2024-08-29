using MetroFramework.Forms;
using System.IO;
using System.Runtime.Loader;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : Form
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
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
            Locked();
            timer1.Start();
        }
        //////////////////// Выбор цвета
        private Color EnabledColor() { return Color.LightGray; }
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
        public void Locked()
        {
            if (projectList.CurrentProjectName == null)
            {
                button3.BackColor = EnabledColor();
                button4.BackColor = EnabledColor();
                button5.BackColor = EnabledColor();
                button6.BackColor = EnabledColor();
                button7.BackColor = EnabledColor();
                button8.BackColor = EnabledColor();
                button9.BackColor = EnabledColor();
                button10.BackColor = EnabledColor();
                button11.BackColor = EnabledColor();
                Left.Enabled = false;
                Right.Enabled = false;
            }
            else
            {
                button3.BackColor = DefaultBackColor;
                button4.BackColor = DefaultBackColor;
                button5.BackColor = DefaultBackColor;
                button6.BackColor = DefaultBackColor;
                button7.BackColor = DefaultBackColor;
                button8.BackColor = DefaultBackColor;
                button9.BackColor = DefaultBackColor;
                button10.BackColor = DefaultBackColor;
                if (isContainSimulator) button11.BackColor = DefaultBackColor;
                else button11.BackColor = EnabledColor();
                Left.Enabled = true;
                Right.Enabled = true;
            }
        }

        public void EnableSimulationsButton(bool enable)
        {
            if (enable) button11.BackColor = DefaultBackColor;
            else button11.BackColor = EnabledColor();
        }
        public void ColorDelete()
        {
            button1.BackColor = DefaultBackColor;
            button2.BackColor = DefaultBackColor;
            button3.BackColor = EnabledColor();
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
            if (button1.BackColor != EnabledColor() && button1.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Create, button1);
                Left.Enabled = false;
                Right.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor != EnabledColor() && button2.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Open, button2);
                Left.Enabled = false;
                Right.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor != EnabledColor() && button3.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Delete, button3);
                Left.Enabled = false;
                Right.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor != EnabledColor() && button4.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Rename, button4);
                Left.Enabled = false;
                Right.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor != EnabledColor() && button5.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.SaveAs, button5);
                Left.Enabled = false;
                Right.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor != EnabledColor())
            {
                projectList.SaveAll();
            }
            // сохранение
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor != EnabledColor() && button7.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Loader, button7);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor != EnabledColor() && button8.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Fasification, button8);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor != EnabledColor() && button9.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Inference, button9);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor != EnabledColor() && button10.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Defasification, button10);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor != EnabledColor() && button11.BackColor != ActiveColor())
            {
                SwichUserControl(UserControlsEnum.Simulation, button11);
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();

        }
        private void button13_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.Show();
        }

        ////////////////// Переход между элементами управления
        public void SwichUserControl(UserControlsEnum? newWindowName, ToolStripMenuItem clickedButton)
        {
            foreach (var item in workspaceButtons)
            {
                item.BackColor = DefaultBackColor;
                if (isContainSimulator) button11.BackColor = DefaultBackColor;
                else button11.BackColor = EnabledColor();
            }
            clickedButton.BackColor = ActiveColor();
            if (!isContainSimulator) button11.BackColor = EnabledColor()
                    
                    ;
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