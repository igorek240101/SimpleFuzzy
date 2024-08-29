using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Collections.Generic;
using System.Data;

namespace SimpleFuzzy.View
{
    public partial class FuzzyOperationUI : UserControl
    {
        string[] unos = { "Нечеткое дополнение" };
        string[] bins = { "Нечеткое пересечение" };
        IRepositoryService repositoryService;
        IAssemblyLoaderService assemblyLoaderService;
        FuzzyOperation fuzzyOperation;
        IObjectSet ObjectSet { get; set; }
        private Dictionary<string, IMembershipFunction> termsName = new Dictionary<string, IMembershipFunction>();
        Action Close;
        string oldName;
        public FuzzyOperationUI()
        {
            InitializeComponent();
        }

        private void UnloadHandler(object sender, EventArgs e)
        {
            string context = sender as string;
            if (ObjectSet.GetType().Assembly.FullName == context)
                ObjectSet = null;
            for (int i = 0; i < termsName.Count; i++)
            {
                if (termsName.ElementAt(i).Value.GetType().Assembly.FullName == context)
                    termsName.Remove(termsName.ElementAt(i).Key);
            }
        }

        public FuzzyOperationUI(FuzzyOperation fuzzyOperation, IObjectSet objectSet, Action close)
        {
            assemblyLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            assemblyLoaderService.UseAssembly += UnloadHandler;
            this.ObjectSet = objectSet;
            this.fuzzyOperation = fuzzyOperation;
            oldName = fuzzyOperation.Name;
            Close = close;
            if (objectSet != null)
            {
                ObjectSet = objectSet;
            }
            InitializeComponent();
            nameTextBox.Text = fuzzyOperation.Name;
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            var list = repositoryService.GetCollection<IMembershipFunction>();
            if (ObjectSet != null)
            {
                ObjectSet.ToFirst();
                foreach (var item in list)
                {
                    if (item.InputType != ObjectSet.Extraction().GetType()) continue;
                    Queue<IMembershipFunction> queue = new Queue<IMembershipFunction>();
                    queue.Enqueue(item);
                    bool check = false;
                    while (queue.Count > 0)
                    {
                        var value = queue.Dequeue();
                        if (value != null && value.GetType() == typeof(FuzzyOperation))
                        {
                            if (value == fuzzyOperation)
                            {
                                check = true; break;
                            }
                            else
                            {
                                queue.Enqueue((value as FuzzyOperation).Operand1);
                                queue.Enqueue((value as FuzzyOperation).Operand2);
                            }
                        }
                    }
                    string name = $"{item.Name}";
                    if (list.Count(t => t.Name == item.Name) > 1)
                    {
                        name = $"{item.Name} - {item.GetType()}";
                        if (list.Where(x => x.Name == item.Name).Count(x => x.GetType() == item.GetType()) > 1)
                        {
                            name = $"{item.Name} - {item.GetType()} - {item.GetType().Assembly.FullName}";
                        }
                    }
                    termsName.Add(item.Name, item);
                }
            }
            if (fuzzyOperation.Operand1 == null)
            {
                operand1.DataSource = termsName.Keys.ToList();
                if (operand1.Items.Count > 0)
                    operand1.SelectedIndex = 0;
            }
            else 
            {
                operand1.DataSource = termsName.Keys.ToList();
                operand1.SelectedItem = termsName.FirstOrDefault(t => t.Value == fuzzyOperation.Operand1).Key;
            }
            if (fuzzyOperation.Operand2 == null)
            {
                operand2.DataSource = termsName.Keys.ToList();
                if (operand2.Items.Count > 0)
                    operand2.SelectedIndex = 0;
            }
            else
            {
                operand2.DataSource = termsName.Keys.ToList();
                operand2.SelectedItem = termsName.FirstOrDefault(t => t.Value == fuzzyOperation.Operand2).Key;
            }
            if (fuzzyOperation.Func == null)
                Uno.Checked = true;
            else
            {
                Uno.Checked = FuzzyOperation.operations[fuzzyOperation.Func].Item1;
                operations.SelectedItem = fuzzyOperation.Func;
            }
        }

        private void Uno_CheckedChanged(object sender, EventArgs e)
        {
            if (Uno.Checked)
            {
                operations.DataSource = unos;
                operand2.Enabled = false;
                fuzzyOperation.Operand2 = null;
            }
            else
            {
                operations.DataSource = bins;
                operand2.Enabled = true;
                if (operand2.Items.Count > 0)
                {
                    operand2.SelectedIndex = 0;
                    fuzzyOperation.Operand2 = termsName[(string)operand2.SelectedItem];
                }
            }
            operations.SelectedIndex = 0;
            operand1_SelectedIndexChanged(sender, e);
        }

        private void operand1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (operand1.SelectedIndex != -1)
            {
                fuzzyOperation.Operand1 = termsName[(string)operand1.SelectedItem];
                GraphicUpdate();
            }
        }

        private void operand2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (operand2.SelectedIndex != -1)
            {
                fuzzyOperation.Operand2 = termsName[(string)operand2.SelectedItem];
                GraphicUpdate();
            }
        }

        private void GraphicUpdate()
        {
            if (ObjectSet == null)
            {
                pictureBox1.Controls.Clear();
                return;
            }

            var plotModel = new PlotModel { Title = "Нечеткая логическая опереация" };

            LineSeries operand1Series = new LineSeries()
            {
                Title = "Операнд - 1",
                Color = OxyColor.FromRgb(255, 0, 0)
            };
            LineSeries operand2Series = new LineSeries()
            {
                Title = "Операнд - 2",
                Color = OxyColor.FromRgb(0, 0, 255)
            };
            LineSeries resSeries = new LineSeries()
            {
                Title = "Результат операции",
                Color = OxyColor.FromRgb(0, 255, 0)
            };
            ObjectSet.ToFirst();
            while (!ObjectSet.IsEnd())
            {
                var x = ObjectSet.Extraction();
                operand1Series.Points.Add(new DataPoint(Convert.ToDouble(x), fuzzyOperation.Operand1.MembershipFunction(x)));
                if (fuzzyOperation.Operand2 != null)
                    operand2Series.Points.Add(new DataPoint(Convert.ToDouble(x), fuzzyOperation.Operand2.MembershipFunction(x)));
                if (fuzzyOperation.Operand2 != null || Uno.Checked)
                    resSeries.Points.Add(new DataPoint(Convert.ToDouble(x), fuzzyOperation.MembershipFunction(x)));
                ObjectSet.MoveNext();
            }
            plotModel.Series.Add(operand1Series);
            plotModel.Series.Add(operand2Series);
            plotModel.Series.Add(resSeries);
            var plotView = new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };

            pictureBox1.Controls.Clear();
            pictureBox1.Controls.Add(plotView);
        }

        private void operations_SelectedIndexChanged(object sender, EventArgs e)
        {
            fuzzyOperation.Func = (string)operations.SelectedItem;
            GraphicUpdate();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!repositoryService.GetCollection<IMembershipFunction>().Contains(fuzzyOperation))
            {
                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("Имя терма не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (repositoryService.GetCollection<LinguisticVariable>().Exists(x => x.Name == nameTextBox.Text))
                {
                    MessageBox.Show("Терм с таким именем уже существует. Пожалуйста, введите другое имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                repositoryService.GetCollection<IMembershipFunction>().Add(fuzzyOperation);
            }
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (repositoryService.GetCollection<IMembershipFunction>().Contains(fuzzyOperation))
            {
                repositoryService.GetCollection<IMembershipFunction>().Remove(fuzzyOperation);
                repositoryService.GetCollection<LinguisticVariable>().ForEach(t => t.DeleteTerm(fuzzyOperation));
            }
            Close();
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Имя терма не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Text = oldName;
            }
            else if (repositoryService.GetCollection<IMembershipFunction>().Exists(x => x.Name == nameTextBox.Text) && oldName != nameTextBox.Text)
            {
                MessageBox.Show("Терм с таким именем уже существует. Пожалуйста, введите другое имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Text = oldName;
            }
            else
            {
                fuzzyOperation.Name = nameTextBox.Text;
            }
        }
    }
}
