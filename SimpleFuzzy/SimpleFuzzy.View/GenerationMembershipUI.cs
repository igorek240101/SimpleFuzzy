using Antlr4.Runtime.Tree;
using Microsoft.CodeAnalysis.CSharp;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using SimpleFuzzy.Service;
using System.Numerics;

namespace SimpleFuzzy.View
{
    public partial class GenerationMembershipUI : UserControl
    {
        private List<(TextBox Condition, TextBox Value)> conditionControls = new List<(TextBox, TextBox)>();
        private IGenerationMembershipFunctionService generator;
        private IRepositoryService repositoryService;
        private ICompileService compileService;
        private IProjectListService projectListService;
        private IAssemblyLoaderService assemblyLoaderService;
        private Dictionary<string, IObjectSet> setsName = new Dictionary<string, IObjectSet>();
        private IObjectSet objectSet;
        private CSharpCompilation compilation;
        private Action close;

        private readonly List<(string Condition, string Value)> _conditions = new List<(string, string)>();

        public void AddCondition(string condition, string value)
        {
            _conditions.Add((condition, value));
        }

        public void RemoveCondition(int index)
        {
            if (index >= 0 && index < _conditions.Count)
            {
                _conditions.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public void ClearConditions()
        {
            _conditions.Clear();
        }

        public GenerationMembershipUI()
        {
            generator = AutofacIntegration.GetInstance<IGenerationMembershipFunctionService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            compileService = AutofacIntegration.GetInstance<ICompileService>();
            InitializeComponent();
            InitializeBaseSetComboBox();
        }

        public GenerationMembershipUI(IObjectSet objectSet, Action close)
        {
            this.close = close;
            this.objectSet = objectSet;
            generator = AutofacIntegration.GetInstance<IGenerationMembershipFunctionService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            compileService = AutofacIntegration.GetInstance<ICompileService>();
            projectListService = AutofacIntegration.GetInstance<IProjectListService>();
            assemblyLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            InitializeComponent();
            InitializeBaseSetComboBox();
        }

        private void InitializeBaseSetComboBox()
        {
            string selectName = null;
            var list = repositoryService.GetCollection<IObjectSet>();
            foreach (var value in repositoryService.GetCollection<IObjectSet>())
            {
                string name = value.Name;
                if (objectSet.GetType() == value.GetType())
                    selectName = name;
                if (list.Count(t => t.Name == value.Name) > 1)
                {
                    name = $"{value.Name} - {value.GetType()}";
                    if (list.Where(x => x.Name == value.Name).Count(x => x.GetType() == value.GetType()) > 1)
                    {
                        name = $"{value.Name} - {value.GetType()} - {value.GetType().Assembly.FullName}";
                    }
                }
                setsName.Add(name, value);
                comboBoxBaseSet.Items.Add(name);
            }
            if (selectName == null)
            {
                if (comboBoxBaseSet.Items.Count > 0)
                    comboBoxBaseSet.SelectedIndex = 0;
            }
            else
                comboBoxBaseSet.SelectedItem = selectName;
        }

        private void buttonAddCondition_Click(object sender, EventArgs e) => AddConditionRow();

        private void AddConditionRow()
        {
            int y = conditionControls.Count * 30;

            var conditionTextBox = new TextBox
            {
                Location = new Point(10, y),
                Size = new Size(110, 20),
                PlaceholderText = "Состояние"
            };

            var valueTextBox = new TextBox
            {
                Location = new Point(130, y),
                Size = new Size(110, 20),
                PlaceholderText = "Значение"
            };

            var removeButton = new Button
            {
                Location = new Point(250, y),
                Size = new Size(80, 27),
                Text = "Удалить"
            };
            removeButton.Click += (sender, e) => RemoveConditionRow((Button)sender);

            panelConditions.Controls.Add(conditionTextBox);
            panelConditions.Controls.Add(valueTextBox);
            panelConditions.Controls.Add(removeButton);

            conditionControls.Add((conditionTextBox, valueTextBox));
        }

        private void RemoveConditionRow(Button sender)
        {
            int index = sender.Location.Y / 30;
            if (index < conditionControls.Count)
            {
                panelConditions.Controls.Remove(conditionControls[index].Condition);
                panelConditions.Controls.Remove(conditionControls[index].Value);
                panelConditions.Controls.Remove(sender);
                conditionControls.RemoveAt(index);

                // Перестановка оставшихся условий
                for (int i = index; i < conditionControls.Count; i++)
                {
                    conditionControls[i].Condition.Location = new Point(10, i * 30);
                    conditionControls[i].Value.Location = new Point(170, i * 30);
                    var removeBtn = panelConditions.Controls.Find("removeButton" + (i + 1), true)[0];
                    removeBtn.Location = new Point(330, i * 30);
                }
            }
        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            ClearConditions();
            foreach (var control in conditionControls)
            {
                AddCondition(control.Condition.Text, control.Value.Text);
            }
            try
            {
                string generatedCode = generator.GenerateCode(objectSet[0].GetType(), textBox1.Text, _conditions);
                var compile = compileService.Compile(generatedCode);
                compilation = compile.Item1;
                VisualizeFunction(compile.Item2 as IMembershipFunction);
                compile.Item3.Unload();
            }
            catch (Exception ex) { MessageBox.Show("Неверный ввод условий.", "Ошибка"); };
        }

        private void buttonVisualize_Click(object sender, EventArgs e)
        {
            if (compilation != null)
            {
                string dllName = $"Function-{DateTime.Now.Ticks}";
                compileService.Save($"{projectListService.GivePath(projectListService.CurrentProjectName, true)}\\{dllName}.dll", compilation);
                assemblyLoaderService.AssemblyLoader($"{projectListService.GivePath(projectListService.CurrentProjectName, true)}\\{dllName}.dll");
                close();
            }
        }
        private void VisualizeFunction(IMembershipFunction function)
        {
            try
            {
                var plotModel = new PlotModel { Title = "Функция принадлежности" };
                plotModel.Axes.Clear();
                plotModel.Series.Clear();

                var lineSeries = new LineSeries { Title = "Функция", StrokeThickness = 2, Color = OxyColors.Blue };

                var baseSetValues = objectSet;

                for (int i = 0; i < baseSetValues.Count; i++)
                {
                    lineSeries.Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[i]), function != null ? function.MembershipFunction(baseSetValues[i]) : 0));
                }

                plotModel.Series.Add(lineSeries);

                var plotView = new PlotView
                {
                    Model = plotModel,
                    Dock = DockStyle.Fill
                };
                pictureBox1.Controls.Clear();
                pictureBox1.Controls.Add(plotView);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при визуализации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxBaseSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisualizeFunction(null);
        }
    }
}
