using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Drawing;

namespace SimpleFuzzy.View
{
    public partial class LinguisticVariableUI : UserControl
    {
        ColorDialog colorDialog = new ColorDialog();
        private LinguisticVariable linguisticVariable;
        private Dictionary<string, IObjectSet> objectSetsName = new Dictionary<string, IObjectSet>();
        private Dictionary<string, IMembershipFunction> termsName = new Dictionary<string, IMembershipFunction>();
        IRepositoryService _repositoryService;
        string oldName;
        Action nameChange;
        IMembershipFunction nowFunction;
        object nowObject;

        Type objectSetType;

        public LinguisticVariableUI()
        {
            InitializeComponent();
        }

        public LinguisticVariableUI(LinguisticVariable linguisticVariable, Action nameChange)
        {
            _repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            this.linguisticVariable = linguisticVariable;
            this.nameChange = nameChange;
            oldName = linguisticVariable.Name;
            InitializeComponent();
            ListViewExtender extender = new ListViewExtender(termsListView);
            ListViewButtonColumn colorAction = new ListViewButtonColumn(1);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(2);
            colorAction.Click += OnColorActionClick;
            buttonAction.Click += OnButtonActionClick;
            colorAction.FixedWidth = true;
            buttonAction.FixedWidth = true;
            extender.AddColumn(colorAction);
            extender.AddColumn(buttonAction);
            SetObjectSet();
            nameTextBox.Text = linguisticVariable.Name;
            radioButton1.Checked = linguisticVariable.isInput;
            radioButton2.Checked = !linguisticVariable.isInput;
            if (linguisticVariable.baseSet == null)
            {
                if (baseSetComboBox.Items.Count > 0)
                    baseSetComboBox.SelectedIndex = 0;
            }
            else
            {
                baseSetComboBox.SelectedItem = objectSetsName.FirstOrDefault(t => t.Value == linguisticVariable.baseSet).Key;
            }
            FazificationObjectChaged(null, null);
            if (!linguisticVariable.isRedact)
            {
                baseSetComboBox.Enabled = false;
                nameTextBox.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        private void SetObjectSet()
        {
            var baseSets = _repositoryService.GetCollection<IObjectSet>().Where(x => x.Active || !linguisticVariable.isRedact);
            foreach (var baseSet in baseSets)
            {
                string name = baseSet.Name;
                if (baseSets.Count(t => t.Name == name) > 1)
                {
                    name = $"{baseSet.Name} - {baseSet.GetType()}";
                    if (baseSets.Where(t => t.Name == name).Count(x => x.GetType() == baseSet.GetType()) > 1)
                    {
                        name = $"{baseSet.Name} - {baseSet.GetType()} - {baseSet.GetType().Assembly.FullName}";
                    }
                }
                objectSetsName.Add(name, baseSet);
                baseSetComboBox.Items.Add(name);
            }
        }

        private void SetTerms()
        {
            termsName.Clear();
            termsComboBox.Items.Clear();
            termsListView.Items.Clear();
            var terms = _repositoryService.GetCollection<IMembershipFunction>().Where(x => 
            x.Active && 
            (x.GetType() != typeof(FuzzyOperation) || linguisticVariable.isInput) &&
            x.InputType.IsAssignableFrom(objectSetType));
            foreach (var term in terms)
            {
                string name = term.Name;
                if (terms.Count(t => t.Name == name) > 1)
                {
                    name = $"{term.Name} - {term.GetType()}";
                    if (terms.Where(x => x.InputType.IsAssignableFrom(objectSetType) && x.Name == name).Count(x => x.GetType() == term.GetType()) > 1)
                    {
                        name = $"{term.Name} - {term.GetType()} - {term.GetType().Assembly.FullName}";
                    }
                }
                if (linguisticVariable.ContainsFunc(term))
                {
                    ListViewItem item = new ListViewItem(name);
                    item.SubItems.Add("🎨");
                    item.SubItems.Add("X");
                    item.ForeColor = linguisticVariable.GetColor(term);
                    termsListView.Items.Add(item);
                }
                else
                {
                    termsComboBox.Items.Add(name);
                }
                termsName.Add(name, term);
            }
            UpdateGraph();
            if (termsComboBox.Items.Count > 0)
                termsComboBox.SelectedIndex = 0;
            else termsComboBox.Text = string.Empty;
        }

        private void AddTermButton_Click(object sender, EventArgs e)
        {
            if (termsComboBox.SelectedIndex != -1)
            {
                linguisticVariable.AddTerm((termsName[(string)termsComboBox.SelectedItem], GetColor(linguisticVariable.CountFunc)));
                termsComboBox.Text = "";
                SetTerms();
            }
        }

        private List<object> ObjectSetToList(IObjectSet objectSet)
        {
            var list = new List<object>();
            objectSet.ToFirst();
            while (!objectSet.IsEnd())
            {
                list.Add(objectSet.Extraction());
                objectSet.MoveNext();
            }
            return list;
        }

        private void UpdateGraph()
        {
            if (linguisticVariable.BaseSet == null)
            {
                graphPictureBox.Controls.Clear();
                return;
            }

            var plotModel = new PlotModel { Title = "Лингвистическая переменная" };

            var baseSetValues = ObjectSetToList(linguisticVariable.BaseSet);
            var data = linguisticVariable.Graphic();

            LineSeries[] lineSeries = new LineSeries[linguisticVariable.CountFunc];
            for (int i = 0; i < lineSeries.Length; i++)
            {
                Color color = linguisticVariable.GetColor(linguisticVariable[i]);
                lineSeries[i] = new LineSeries
                {
                    Title = linguisticVariable[i].Name,
                    Color = OxyColor.FromRgb(color.R, color.G, color.B)
                };
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < linguisticVariable.CountFunc; j++)
                {
                    lineSeries[j].Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[i]), data[i].Item2[j]));
                }
                if (baseSetValues[i].Equals(nowObject))
                {
                    LineSeries line = new LineSeries
                    {
                        Color = OxyColor.FromRgb(0, 0, 0)
                    };
                    line.Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[i]), 0));
                    line.Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[i]), 1));
                    plotModel.Series.Add(line);
                }
            }

            foreach (var value in lineSeries)
            {
                plotModel.Series.Add(value);
            }

            ScatterSeries series = new ScatterSeries();
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[0]), 0, 0));
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[^1]), 0, 0));
            plotModel.Series.Add(series);

            var plotView = new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };



            graphPictureBox.Controls.Clear();
            graphPictureBox.Controls.Add(plotView);
        }

        private Color GetColor(int index)
        {
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown };
            return colors[index % colors.Length];
        }

        private void NameChangedHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Имя переменной не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Text = oldName;
            }
            else if (_repositoryService.GetCollection<LinguisticVariable>().Exists(x => x.Name == nameTextBox.Text) && oldName != nameTextBox.Text)
            {
                MessageBox.Show("Переменная с таким именем уже существует. Пожалуйста, введите другое имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Text = oldName;
            }
            else
            {
                linguisticVariable.Name = nameTextBox.Text;
                nameChange();
            }
        }

        private void BaseSetChange(object sender, EventArgs e)
        {
            linguisticVariable.BaseSet = objectSetsName[(string)baseSetComboBox.SelectedItem];
            objectSetType = linguisticVariable.BaseSet.Extraction().GetType();
            int count = 0;
            for (linguisticVariable.BaseSet.ToFirst(); !linguisticVariable.BaseSet.IsEnd(); linguisticVariable.BaseSet.MoveNext())
                count++;
            count--;
            trackBar.Maximum = count;
            SetTerms();
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                var term = termsName[e.Item.Text];
                linguisticVariable.DeleteTerm(term);
                SetTerms();
                termView_SelectedIndexChanged(sender, null);
            }
        }

        private void OnColorActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            colorDialog.ShowDialog();
            var term = termsName[e.Item.Text];
            linguisticVariable.SetColor(term, colorDialog.Color);
            SetTerms();
            termView_SelectedIndexChanged(sender, null);
        }

        private void termView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (termsListView.SelectedIndices.Count == 1)
            {
                nowFunction = termsName[termsListView.SelectedItems[0].Text];
                HeightLabel.Visible = true;
                NumericUpDown1.Visible = true;
                trackBar.Visible = true;
                FazificationObjectChaged(null, null);
                var value = linguisticVariable.CalculationFuzzySetProperties(nowFunction, (double)NumericUpDown1.Value);
                SetProperty.Text = $"Тип нечеткого множества: {value.Item2}" +
                    $"\nВысота нечеткого множества: {value.Item1}" +
                    $"\n{value.Item3.AsQueryable().Aggregate("Область влияния нечеткого множества: ", (x, y) => x + " " + y.ToString())}" +
                    $"\n{value.Item4.AsQueryable().Aggregate("Ядро нечеткого множества: ", (x, y) => x + " " + y.ToString())}" +
                    $"\n{value.Item5.AsQueryable().Aggregate($"Сечение на выстое {(double)NumericUpDown1.Value}: ", (x, y) => x + " " + y.ToString())}";
            }
            else
            {
                nowFunction = null;
                HeightLabel.Visible = false;
                NumericUpDown1.Visible = false;
                SetProperty.Text = "";
            }
        }

        private void FazificationObjectChaged(object sender, EventArgs e)
        {
            if (linguisticVariable.BaseSet != null)
            {
                linguisticVariable.BaseSet.ToFirst();
                for (int i = 0; i < trackBar.Value; i++)
                    linguisticVariable.BaseSet.MoveNext();
                nowObject = linguisticVariable.BaseSet.Extraction();
                ObjectSetLabel.Text = nowObject.ToString();
                FazificationDescription.Text = linguisticVariable.GetResultofFuzzy(linguisticVariable.Fazzification(nowObject));
                UpdateGraph();
            }
        }

        private void GenerateMembershipFunction_Click(object sender, EventArgs e)
        {
            using (var inputBox = new NewMembershipDialogForm(linguisticVariable.BaseSet))
            {
                inputBox.ShowDialog();
                SetTerms();
            }
        }

        private void termsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (termsName[termsListView.SelectedItems[0].Text] is FuzzyOperation fuzzyOperation)
            {
                using (var inputBox = new NewMembershipDialogForm(fuzzyOperation, linguisticVariable.BaseSet))
                {
                    inputBox.ShowDialog();
                    SetTerms();
                }
            }
        }

        private void GenerateBaseSet_Click(object sender, EventArgs e)
        {
            using (var inputBox = new GenerationObjectSetUI())
            {
                inputBox.ShowDialog();
                SetTerms();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            linguisticVariable.isInput = radioButton1.Checked;
            if (!radioButton1.Checked)
                linguisticVariable.func = linguisticVariable.func.Where(t => t.Item1.GetType() != typeof(FuzzyOperation)).ToList();
            SetTerms();
        }
    }
}