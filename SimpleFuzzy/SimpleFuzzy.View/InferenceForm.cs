using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System;
using System.Collections.Specialized;
using System.Data.Common;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class InferenceForm : UserControl
    {
        //public List<Dictionary<string, IMembershipFunction>> listDic;
        public IRepositoryService? repositoryService;
        public LinguisticVariable currentOutputVar;
        public int Id = 0;
        private string lastValue;
        private int lastValueColumn;
        private bool wasDublicate;
        public InferenceForm()
        {
            InitializeComponent();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            dataTable.EditMode = DataGridViewEditMode.EditOnEnter;
            foreach (LinguisticVariable variable in repositoryService.GetCollection<LinguisticVariable>())
            {
                {
                    if (!variable.IsInput) outputVariableComboBox.Items.Add(variable.Name);
                }
            }
            if (outputVariableComboBox.Items.Count > 0)
            {
                outputVariableComboBox.SelectedIndex = 0;
            }
        }
        private void StartTable(SetRule setRule)
        {
            dataTable.ButtonsClear();
            if (dataTable != null) dataTable.Columns.Clear();
            Id = 0;
            dataTable.Columns.Add("", "Номер");
            dataTable.Columns[0].HeaderText = "Номер";
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns[0].Width = 70;
            dataTable.Columns[0].Name = "ID";

            DataGridViewTextBoxColumn textBox = new DataGridViewTextBoxColumn();
            textBox.HeaderText = "Релевантность";
            dataTable.Columns.Add(textBox);
            dataTable.Columns[1].Name = "Релевантность";

            DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
            comboBox.HeaderText = currentOutputVar.Name;
            comboBox.FlatStyle = FlatStyle.Flat;
            dataTable.Columns.Add(comboBox);
            dataTable.Columns[2].Name = currentOutputVar.Name;

            List<string> term = new List<string>();
            foreach (var func in currentOutputVar.func) { term.Add(func.Item1.Name); }
                (dataTable.Columns[2] as DataGridViewComboBoxColumn).DataSource = term;
            //(dataTable.Columns[2] as DataGridViewComboBoxColumn).DataSource = listDic[0].ToList().ConvertAll(x => x.Key);

            if (currentOutputVar.baseSet == null || currentOutputVar.func.Count == 0)
                dataTable.Columns[2].HeaderCell.Style.ForeColor = Color.Red;
            for (int i = 0; i < currentOutputVar.ListRules.inputVariables.Count; i++)
            {
                DataGridViewComboBoxColumn comboBoxInput = new DataGridViewComboBoxColumn();
                comboBoxInput.HeaderText = currentOutputVar.ListRules.inputVariables[i].Name;
                comboBoxInput.FlatStyle = FlatStyle.Flat;
                dataTable.AddColumn(comboBoxInput);
                dataTable.Columns[^3].Name = currentOutputVar.ListRules.inputVariables[i].Name;
                if (currentOutputVar.ListRules.inputVariables[i].baseSet == null || currentOutputVar.ListRules.inputVariables[i].func.Count == 0)
                    dataTable.Columns[2].HeaderCell.Style.ForeColor = Color.Red;

                List<string> termInput = new List<string>();
                foreach (var func in currentOutputVar.ListRules.inputVariables[i].func) { termInput.Add(func.Item1.Name); }
                (dataTable.Columns[i + 1] as DataGridViewComboBoxColumn).DataSource = termInput;
                //(dataTable.Columns[^3] as DataGridViewComboBoxColumn).DataSource = listDic[i].ToList().ConvertAll(x => x.Key);
            }
            // Далее заполнение значениями
            if (currentOutputVar.ListRules.rules.Count > 0)
            {
                for (int i = 0; i < currentOutputVar.ListRules.rules.Count; i++)
                {
                    int cells = 0;
                    dataTable.Rows.Add();
                    Id++;
                    dataTable.Rows[i].Cells[0].Value = Id;
                    cells++;
                    List<IMembershipFunction> list = currentOutputVar.ListRules.rules[i].GiveList();
                    for (int j = 1; j < list.Count; j++)
                    {
                        if (list[j] != null && IsContainsTermInRep(list[j].Name))
                        {
                            dataTable.Rows[i].Cells[cells].Value = list[j].Name;
                            dataTable.Rows[i].Cells[cells].Style.BackColor = SetColorTerm(dataTable.Columns[cells].Name, list[j], 1);
                            if (IsGoodView(dataTable.Rows[i].Cells[cells].Style.BackColor)) dataTable.Rows[i].Cells[cells].Style.ForeColor = Color.Black;
                            else dataTable.Rows[i].Cells[cells].Style.ForeColor = Color.White;
                        }
                        cells++;
                    }
                    dataTable.Rows[i].Cells[cells].Value = currentOutputVar.ListRules.rules[i].relevance.ToString().Replace(',', '.');
                    dataTable.Rows[i].Cells[cells].Style.BackColor = SetColorToRelevation(currentOutputVar.ListRules.rules[i].relevance, 1);
                    cells++;
                    if (list[0] != null && IsContainsTermInRep(list[0].Name))
                    {
                        dataTable.Rows[i].Cells[cells].Value = list[0].Name;
                        dataTable.Rows[i].Cells[cells].Style.BackColor = SetColorTerm(dataTable.Columns[cells].Name, list[0], 1);
                        if (IsGoodView(dataTable.Rows[i].Cells[cells].Style.BackColor)) dataTable.Rows[i].Cells[cells].Style.ForeColor = Color.Black;
                        else dataTable.Rows[i].Cells[cells].Style.ForeColor = Color.White;
                    }
                }
                for (int i = 0; i < currentOutputVar.ListRules.rules.Count; i++) ChangeActiveRules(i, currentOutputVar.ListRules.rules[i].IsDublicate);
            }
            foreach (DataGridViewColumn column in dataTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private bool IsContainsTermInRep(string name)
        {
            foreach (IMembershipFunction func in repositoryService.GetCollection<IMembershipFunction>())
            {
                if (func.Name == name) return true;
            }
            return false;
        }

        private bool IsGoodView(Color color)
        {
            if (color.R > 128 || color.G > 128 || color.B > 128) return true;
            else return false;
        }

        private Color SetColorTerm(string name, IMembershipFunction func, byte isActive)
        {
            if (currentOutputVar.Name == name)
            {
                for (int i = 0; i < currentOutputVar.func.Count; i++)
                {
                    if (currentOutputVar.func[i].Item1 == func)
                    {
                        return Color.FromArgb(currentOutputVar.func[i].Item2.R / isActive,
                            currentOutputVar.func[i].Item2.G / isActive,
                            currentOutputVar.func[i].Item2.B / isActive);
                    }
                }
            }
            for (int i = 0; i < currentOutputVar.ListRules.inputVariables.Count; i++)
            {
                if (currentOutputVar.ListRules.inputVariables[i].Name == name)
                {
                    for (int j = 0; j < currentOutputVar.ListRules.inputVariables[i].func.Count; j++)
                    {
                        if (currentOutputVar.ListRules.inputVariables[i].func[j].Item1 == func)
                        {
                            return Color.FromArgb(currentOutputVar.ListRules.inputVariables[i].func[j].Item2.R / isActive,
                                currentOutputVar.ListRules.inputVariables[i].func[j].Item2.G / isActive,
                                currentOutputVar.ListRules.inputVariables[i].func[j].Item2.B / isActive);
                        }
                    }
                }
            }
            return DefaultBackColor; // Чтобы все пути к коду возвращали значение
        }

        private Color SetColorToRelevation(double var, byte isActive)
        {
            return Color.FromArgb((int)((var > 0.5 ? ((1 - (var - 0.5) * 2) * 255) : 255) / isActive),
                (int)((var > 0.5 ? 255 : var * 511) / isActive), 0);
        }

        private void OutputVariableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputVariablesComboBox.Items.Clear();
            foreach (LinguisticVariable var in repositoryService.GetCollection<LinguisticVariable>())
            {
                if (var.Name == outputVariableComboBox.SelectedItem.ToString())
                {
                    currentOutputVar = var;
                    break;
                }
            }
            foreach (LinguisticVariable var in repositoryService.GetCollection<LinguisticVariable>())
            {
                if (currentOutputVar.ListRules == null)
                {
                    if (var.IsInput) inputVariablesComboBox.Items.Add(var.Name);
                }
                else if (!currentOutputVar.ListRules.inputVariables.Contains(var) && var.isInput)
                {
                    inputVariablesComboBox.Items.Add(var.Name);
                }
            }
            // отменяем подписку
            dataTable.RowsRemoved -= dataTable_RowsRemoved;
            dataTable.CellBeginEdit -= dataTable_CellBeginEdit;
            dataTable.CellValueChanged -= dataTable_CellValueChanged;
            dataTable.ColumnRemoved -= dataTable_ColumnRemoved;
            if (currentOutputVar.ListRules == null)
            {
                SetRule setRule = new SetRule(currentOutputVar);
                currentOutputVar.ListRules = setRule;
                currentOutputVar.UnloadAssembly += setRule.UnloadingHandler;
            }
            /*listDic = new List<Dictionary<string, IMembershipFunction>>();

            Dictionary<string, IMembershipFunction> newOutVar = new Dictionary<string, IMembershipFunction>();
            for (int i = 0; i < currentOutputVar.ListRules.outVariable.func.Count; i++)
            {
                if (currentOutputVar.ListRules.outVariable.func.Count(v => v.Item1.Name == currentOutputVar.ListRules.outVariable.func[i].Item1.Name) > 1)
                    newOutVar.Add(currentOutputVar.ListRules.outVariable.func[i].Item1.Name + " - " + currentOutputVar.ListRules.outVariable.func[i].Item1.GetType().Name +
                        " - " + currentOutputVar.ListRules.outVariable.func[i].Item1.GetType().Assembly.Location, currentOutputVar.ListRules.outVariable.func[i].Item1);
                else
                    newOutVar.Add(currentOutputVar.ListRules.outVariable.func[i].Item1.Name, currentOutputVar.ListRules.outVariable.func[i].Item1);
            }
            listDic.Add(newOutVar);*/

            StartTable(currentOutputVar.ListRules);
            dataTable.RowsRemoved += dataTable_RowsRemoved;
            dataTable.CellBeginEdit += dataTable_CellBeginEdit;
            dataTable.CellValueChanged += dataTable_CellValueChanged;
            dataTable.ColumnRemoved += dataTable_ColumnRemoved;
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
                        column.FlatStyle = FlatStyle.Flat;
                        dataTable.AddColumn(column);
                        dataTable.Columns[^3].Name = var.Name;
                        currentOutputVar.ListRules.AddInputVar(var);

                        List<string> term = new List<string>();
                        foreach (var func in var.func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        var combobox = (dataTable.Columns[^3] as DataGridViewComboBoxColumn);
                        combobox.DataSource = term;

                        /*Dictionary<string, IMembershipFunction> newInVar = new Dictionary<string, IMembershipFunction>();
                        for (int i = 0; i < currentOutputVar.ListRules.inputVariables[^1].func.Count; i++)
                        {
                            if (currentOutputVar.ListRules.inputVariables[^1].func.Count(v => v.Item1.Name == currentOutputVar.ListRules.inputVariables[^1].func[i].Item1.Name) > 1)
                                newInVar.Add(currentOutputVar.ListRules.inputVariables[^1].func[i].Item1.Name + " - " + currentOutputVar.ListRules.inputVariables[^1].func[i].Item1.GetType().Name +
                                    " - " + currentOutputVar.ListRules.inputVariables[^1].func[i].Item1.GetType().Assembly.Location, currentOutputVar.ListRules.inputVariables[^1].func[i].Item1);
                            else
                                newInVar.Add(currentOutputVar.ListRules.inputVariables[^1].func[i].Item1.Name, currentOutputVar.ListRules.inputVariables[^1].func[i].Item1);
                        }
                        listDic.Add(newInVar);*/
                        break;
                    }
                }
                inputVariablesComboBox.Items.Remove(inputVariablesComboBox.Text);
                inputVariablesComboBox.Text = null;
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
        private void ChangeActiveRules(int row, bool isDublicate)
        {
            if (isDublicate)
            {
                if (currentOutputVar.ListRules.OpenOrBlockedCurrentRule(row)) ChangeRuleDub(row, 1); // Возможно открыть текущее правило
                else ChangeRuleDub(row, 2); // Возможно закрыть текущее правило  
                int position = currentOutputVar.ListRules.CloseRuleNext(row);
                if (position != -1) ChangeRuleDub(position, 2); // Возможно закрыть правило дальше
            }
            else
            {
                if (!wasDublicate) // Возможно открыть правило дальше  !!!нужны старые данные!!!
                {
                    int position1 = currentOutputVar.ListRules.OpenRuleNext(row, lastValueColumn, lastValue);
                    if (position1 != -1) ChangeRuleDub(position1, 1);
                }
                if (!currentOutputVar.ListRules.OpenOrBlockedCurrentRule(row)) ChangeRuleDub(row, 2); // Возможно закрыть текущее правило  
                int position = currentOutputVar.ListRules.CloseRuleNext(row);
                if (position != -1) ChangeRuleDub(position, 2); // Возможно закрыть правило дальше
            }
        }
        private void ChangeRuleDub(int position, byte active)
        {
            for (int i = 1; i < dataTable.Columns.Count - 2; i++)
            {
                if (dataTable.Rows[position].Cells[i].Value != null)
                    dataTable.Rows[position].Cells[i].Style.BackColor = SetColorTerm(dataTable.Columns[i].Name,
                    GiveFunc(dataTable.Rows[position].Cells[i].Value.ToString(), currentOutputVar.ListRules.inputVariables[i - 1]), active);
                if (IsGoodView(dataTable.Rows[position].Cells[i].Style.BackColor)) dataTable.Rows[position].Cells[i].Style.ForeColor = Color.Black;
                else dataTable.Rows[position].Cells[i].Style.ForeColor = Color.White;
                if (dataTable.Rows[position].Cells[i].Value == null) dataTable.Rows[position].Cells[i].Style.ForeColor = Color.Black;
            }
            double n;
            if (double.TryParse(dataTable.Rows[position].Cells[dataTable.Columns.Count - 2].Value.ToString(), out n))
                dataTable.Rows[position].Cells[dataTable.Columns.Count - 2].Style.BackColor = SetColorToRelevation(n, active);
            if (dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Value != null)
            {
                string name = dataTable.Columns[dataTable.Columns.Count - 1].Name;
                string text = dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Value.ToString();
                LinguisticVariable var = currentOutputVar.ListRules.outVariable;
                IMembershipFunction func = GiveFunc(text, var);
                dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Style.BackColor = SetColorTerm(name, func, active);
                if (IsGoodView(dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Style.BackColor)) dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Style.ForeColor = Color.Black;
                else dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Style.ForeColor = Color.White;
                if (dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Value == null) 
                    dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Style.ForeColor = Color.Black;
            }
        }

        ////////////////// Изменение значений
        private void dataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return; // ID
            else if (e.ColumnIndex == dataTable.ColumnCount - 1) // ВЫХОДНАЯ ПЕРЕМЕНННАЯ
            {
                IMembershipFunction func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar);
                currentOutputVar.ListRules.rules[e.RowIndex].RedactTerm(func, 0);
                byte active = 1;
                if (currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate) active = 2;
                dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorTerm(dataTable.Columns[e.ColumnIndex].Name, func, active);
                if (IsGoodView(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor)) dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                else dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                if (dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) 
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                ChangeActiveRules(e.RowIndex, currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate);
                dataTable.AutoResizeColumn(e.ColumnIndex);
            }
            else if (e.ColumnIndex == dataTable.ColumnCount - 2) // РЕЛЕВАНТНОСТЬ
            {
                string rel = dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = rel.Replace(',', '.');
                double n;
                if (double.TryParse(rel.Replace('.', ','), out n) && n >= 0 && n <= 1)
                {
                    currentOutputVar.ListRules.rules[e.RowIndex].relevance = n;
                    byte active = 1;
                    if (currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate) active = 2;
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorToRelevation(n, active);
                }
                else
                {
                    MessageBox.Show("Релевантность должна находиться в диапазоне [0, 1]");
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    byte active = 1;
                    if (currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate) active = 2;
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorToRelevation(1, active);
                }
            }
            else // СТОЛБЦЫ С ВХОДНЫМИ ПЕРЕМЕННЫМИ
            {
                IMembershipFunction func = null;
                for (int i = 0; i < currentOutputVar.ListRules.inputVariables.Count; i++)
                {
                    if (currentOutputVar.ListRules.inputVariables[i].Name == dataTable.Columns[e.ColumnIndex].Name)
                    {
                        func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar.ListRules.inputVariables[i]);
                        byte active = 1;
                        if (currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate) active = 2;
                        dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorTerm(dataTable.Columns[e.ColumnIndex].Name, func, active);
                        if (IsGoodView(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor)) dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                        else dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
                        if (dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) 
                            dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                        break;
                    }
                }
                currentOutputVar.ListRules.rules[e.RowIndex].RedactTerm(func, e.ColumnIndex);
                ChangeActiveRules(e.RowIndex, currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate);
                dataTable.AutoResizeColumn(e.ColumnIndex);
            }
        }
        //////////////////// Добавление строк

        private void dataTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                lastValue = dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                lastValueColumn = e.ColumnIndex;
                wasDublicate = currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate;
            }
            else
            {
                lastValue = null;
                lastValueColumn = -1;
                wasDublicate = true;
            }
            if (e.RowIndex == dataTable.RowCount - 1 && Id != dataTable.RowCount)
            {
                Id++;
                dataTable.Rows[e.RowIndex].Cells[0].Value = Id;

                Rule rule = new Rule(dataTable.ColumnCount - 2, currentOutputVar.ListRules);
                currentOutputVar.ListRules.rules.Add(rule);

                for (int i = 0; i < dataTable.ColumnCount - 2; i++)
                {
                    List<string> term = new List<string>();
                    if (i == 0)
                    {
                        foreach (var func in currentOutputVar.func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        (dataTable.Columns[dataTable.ColumnCount - 1] as DataGridViewComboBoxColumn).DataSource = term;
                        //(dataTable.Columns[^1] as DataGridViewComboBoxColumn).DataSource = listDic[0].ToList().ConvertAll(x => x.Key);
                    }
                    else
                    {
                        foreach (var func in repositoryService.GetCollection<LinguisticVariable>().FirstOrDefault(t => t.Name == dataTable.Columns[i].Name).func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        (dataTable.Columns[i] as DataGridViewComboBoxColumn).DataSource = term;
                        //(dataTable.Columns[i] as DataGridViewComboBoxColumn).DataSource = listDic[i].ToList().ConvertAll(x => x.Key);
                    }
                }
                if (e.ColumnIndex != dataTable.Columns.Count - 2)
                {
                    dataTable.Rows[e.RowIndex].Cells[dataTable.Columns.Count - 2].Value = 1;
                    dataTable.Rows[e.RowIndex].Cells[dataTable.Columns.Count - 2].Style.BackColor = SetColorToRelevation(1, 1);
                }
            }
        }

        private void dataTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            List<IMembershipFunction> list = currentOutputVar.ListRules.rules[e.RowIndex].GiveList();
            bool dublicate = currentOutputVar.ListRules.rules[e.RowIndex].IsDublicate;
            currentOutputVar.ListRules.DeleteRule(e.RowIndex);
            //listDic.RemoveAt(e.RowIndex);
            Id--;
            if (!dublicate)
            {
                int position = currentOutputVar.ListRules.CheckAfterDelete(list, e.RowIndex);
                if (position != -1) { ChangeRuleDub(position, 1); }
            }
        }

        private void dataTable_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            string name = e.Column.HeaderText;
            foreach (LinguisticVariable var in currentOutputVar.ListRules.inputVariables)
            {
                if (var.Name == name)
                {
                    currentOutputVar.ListRules.inputVariables.Remove(var);
                    break;
                }
            }
            inputVariablesComboBox.Items.Add(name);
            currentOutputVar.ListRules.DeleteInputVar(name, e.Column.Index);

            for (int i = dataTable.RowCount - 2; i >= 0; i--)
            {
                if (currentOutputVar.ListRules.rules.Count > 0)
                {
                    int position = currentOutputVar.ListRules.CheckAfterDeleteColumn(i);
                    if (position != -1) { ChangeRuleDub(position, 2); }
                }
            }
        }

        private void dataTable_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.HeaderCell.Size.Width < 50) e.Column.Width = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentOutputVar.ListRules.inputVariables.Count > 0)
            {
                int[] counter = currentOutputVar.ListRules.inputVariables.ConvertAll(x => x.CountFunc).ToArray();
                for (int i = 0; i <= counter.Aggregate((x, y) => x * y); i++)
                {
                    int value = i;
                    currentOutputVar.ListRules.rules.Add(new Rule(counter.Length + 1, currentOutputVar.ListRules));
                    for (int j = 0; j < counter.Length; j++)
                    {
                        currentOutputVar.ListRules.rules[^1].RedactTerm(currentOutputVar.ListRules.inputVariables[j].func[value % counter[j]].Item1, j + 1);
                        value /= counter[j];
                    }
                }
            }
        }
    }
}
