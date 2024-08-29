using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class InferenceForm : UserControl
    {
        public IRepositoryService? repositoryService;
        public LinguisticVariable currentOutputVar;
        private int Id = 1;
        public InferenceForm()
        {
            InitializeComponent();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            foreach (LinguisticVariable variable in repositoryService.GetCollection<LinguisticVariable>())
            {
                if (!variable.IsInput) outputVariableComboBox.Items.Add(variable.Name);
                else inputVariablesComboBox.Items.Add(variable.Name);
            }
            if (outputVariableComboBox.Items.Count > 0)
            {
                outputVariableComboBox.SelectedIndex = 0;
            }
        }
        private void AddTable(string name)
        {
            if (dataTable != null) dataTable.Columns.Clear();
            dataTable.Columns.Add("", "ID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Rows[0].Cells[0].Value = Id;
            Id++;

            DataGridViewTextBoxColumn textBox = new DataGridViewTextBoxColumn();
            textBox.HeaderText = "Релевантность";
            dataTable.Columns.Add(textBox);

            DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
            comboBox.HeaderText = name;
            dataTable.Columns.Add(comboBox);
            Rule rule = new Rule(1);
            currentOutputVar.listRules.rules.Add(rule);

            List<string> term = new List<string>();
            foreach (var func in currentOutputVar.func) { term.Add(func.Item1.Name); }
            (dataTable.Columns[2] as DataGridViewComboBoxColumn).DataSource = term;

            dataTable.Rows[0].Cells[1].Value = currentOutputVar.listRules.rules[0].relevance;

        }
        private void OutputVariableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinguisticVariable temp = null;
            foreach (LinguisticVariable var in repositoryService.GetCollection<LinguisticVariable>())
            {
                if (currentOutputVar != null && var == currentOutputVar)
                {
                    outputVariableComboBox.Items.Add(var.Name);
                }
                if (var.Name == outputVariableComboBox.SelectedItem.ToString())
                {
                    temp = var;
                }
            }
            currentOutputVar = temp;
            // добавление таблицы
            SetRule setRule = new SetRule(currentOutputVar);
            currentOutputVar.listRules = setRule;
            AddTable(outputVariableComboBox.SelectedItem.ToString());
            outputVariableComboBox.Items.Remove(outputVariableComboBox.SelectedItem);
        }
        private void inputVariablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputVariablesComboBox.Text = inputVariablesComboBox.SelectedItem.ToString();
        }
        //////////////////// Добавление столбца
        private void AddInbutton_Click(object sender, EventArgs e)
        {
            if (inputVariablesComboBox.Text != null)
            {
                foreach (LinguisticVariable var in repositoryService.GetCollection<LinguisticVariable>())
                {
                    if (var.Name == inputVariablesComboBox.Text)
                    {
                        // добавление столбца
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.HeaderText = inputVariablesComboBox.Text;
                        dataTable.Columns.Insert(1, column);
                        currentOutputVar.listRules.AddInputVar(var);

                        List<string> term = new List<string>();
                        foreach (var func in currentOutputVar.func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            (dataTable.Columns[1] as DataGridViewComboBoxColumn).DataSource = term;
                        }
                        break;
                    }
                }
                inputVariablesComboBox.Items.Remove(inputVariablesComboBox.Text);
            }
        }
        private IMembershipFunction GiveFunc(string name, LinguisticVariable variable)
        {
            for (int i = 0; i < variable.func.Count; i++) 
            {
                if (variable.func[i].Item1.Name == name) { return variable.func[i].Item1; }
            }
            return null; // Сюда заходить не будет (надо чтобы все пути к коду возвращали значение)
        }

        ////////////////// Изменение значений
        private void dataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) { return; } // ID
            else if (e.ColumnIndex == dataTable.ColumnCount - 1) // ВЫХОДНАЯ ПЕРЕМЕНННАЯ
            {
                IMembershipFunction func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar);
                currentOutputVar.listRules.rules[e.RowIndex].RedactTerm(func, 0);
            }
            else if (e.ColumnIndex == dataTable.ColumnCount - 2) // РЕЛЕВАНТНОСТЬ
            {
                double n;
                if (double.TryParse(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out n) && n >= 0 && n <= 1)
                {
                    currentOutputVar.listRules.rules[e.RowIndex].relevance = n;
                }
                else
                {
                    MessageBox.Show("Релевантность должна находиться в диапазоне [0, 1]");
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                }
            }
            else // СТОЛБЦЫ С ВХОДНЫМИ ПЕРЕМЕННЫМИ
            {
                IMembershipFunction func = null;
                for (int i = 0; i < currentOutputVar.listRules.inputVariables.Count; i++)
                {
                    if (currentOutputVar.listRules.inputVariables[i].Name == dataTable.Columns[e.ColumnIndex].Name)
                    {
                        func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar.listRules.inputVariables[i]);
                        break;
                    }
                }
                currentOutputVar.listRules.rules[e.RowIndex].RedactTerm(func, e.ColumnIndex);
            }
        }
        //////////////////// Добавление строк
        private void dataTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Id != 1)
            {
                dataTable.Rows[e.RowIndex].Cells[0].Value = Id;
                Id++;
                Rule rule = new Rule(dataTable.ColumnCount - 2);
                currentOutputVar.listRules.rules.Add(rule);
            }
            for (int i = 0; i < dataTable.ColumnCount - 2; i++) 
            {
                List<string> term = new List<string>();
                foreach (var func in currentOutputVar.func)
                {
                    term.Add(func.Item1.Name);
                }
                if (i == 0)
                {
                    (dataTable.Columns[dataTable.ColumnCount - 1] as DataGridViewComboBoxColumn).DataSource = term;
                }
                else
                {
                    (dataTable.Columns[i] as DataGridViewComboBoxColumn).DataSource = term;
                }
            }
        }
    }
}
