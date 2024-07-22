using SimpleFuzzy.Abstract;
namespace LinguisticVariableUI
{
    public partial class TermForm : Form
    {
        public IMembershipFunction Result { get; private set; }

        private ComboBox functionTypeComboBox;
        private TextBox nameTextBox;
        private Panel parametersPanel;
        private Button okButton;
        private Button cancelButton;

        public TermForm()
        {
            InitializeComponent();
            InitializeFunctionTypes();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Тип функции принадлежности
            Label functionTypeLabel = new Label
            {
                Text = "Тип функции принадлежности:",
                Location = new Point(10, 10),
                AutoSize = true
            };
            this.functionTypeComboBox = new ComboBox
            {
                Location = new Point(10, 30),
                Size = new Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.functionTypeComboBox.SelectedIndexChanged += FunctionTypeComboBox_SelectedIndexChanged;

            // Название терма
            Label nameLabel = new Label
            {
                Text = "Название терма:",
                Location = new Point(10, 60),
                AutoSize = true
            };
            this.nameTextBox = new TextBox
            {
                Location = new Point(10, 80),
                Size = new Size(200, 20)
            };

            // Панель для параметров
            this.parametersPanel = new Panel
            {
                Location = new Point(10, 110),
                Size = new Size(280, 100),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Кнопки
            this.okButton = new Button
            {
                Text = "OK",
                Location = new Point(10, 220),
                Size = new Size(75, 30)
            };
            this.okButton.Click += new EventHandler(this.OkButton_Click);

            this.cancelButton = new Button
            {
                Text = "Отмена",
                Location = new Point(100, 220),
                Size = new Size(75, 30)
            };
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // Настройки формы
            this.ClientSize = new Size(300, 260);
            this.Controls.AddRange(new Control[] {
                functionTypeLabel, this.functionTypeComboBox,
                nameLabel, this.nameTextBox,
                this.parametersPanel,
                this.okButton, this.cancelButton
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавить новый терм";
            this.ResumeLayout(false);
        }

        private void InitializeFunctionTypes()
        {
            functionTypeComboBox.Items.AddRange(new string[]
            {
                "Треугольная",
                "Трапециевидная",
                "Гауссова"
                // Функции бывают разные, поэтому можно добавить и другие
            });
        }


        private void FunctionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            parametersPanel.Controls.Clear();
            switch (functionTypeComboBox.SelectedItem.ToString())
            {
                case "Треугольная":
                    AddParameterFields("a", "b", "c");
                    break;
                case "Трапециевидная":
                    AddParameterFields("a", "b", "c", "d");
                    break;
                case "Гауссова":
                    AddParameterFields("m", "σ");
                    break;
            }
        }

        private void AddParameterFields(params string[] parameterNames)
        {
            int y = 10;
            foreach (var name in parameterNames)
            {
                parametersPanel.Controls.Add(new Label
                {
                    Text = name + ":",
                    Location = new Point(10, y),
                    AutoSize = true
                });
                parametersPanel.Controls.Add(new TextBox
                {
                    Name = name + "TextBox",
                    Location = new Point(35, y),
                    Size = new Size(50, 20)
                });
                y += 30;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || functionTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, введите название терма и выберите тип функции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Result = CreateMembershipFunction();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании функции принадлежности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IMembershipFunction CreateMembershipFunction()
        {
            string functionType = functionTypeComboBox.SelectedItem.ToString();
            string name = nameTextBox.Text;

            switch (functionType)
            {
                case "Треугольная":
                    double a = double.Parse(((TextBox)parametersPanel.Controls["aTextBox"]).Text);
                    double b = double.Parse(((TextBox)parametersPanel.Controls["bTextBox"]).Text);
                    double c = double.Parse(((TextBox)parametersPanel.Controls["CTextBox"]).Text);

                    return new TriangularMembershipFunction(name, a, b, c);
                case "Трапециевидная":
                    // Здесь нужно реализовать трапецевидную функцию, если такова понадобится
                    throw new NotImplementedException("Трапециевидная функция еще не реализована");
                case "Гауссова":
                    // Здесь гауссову функцию
                    throw new NotImplementedException("Гауссова функция еще не реализована");
                default:
                    // И далее по надобности другие функции
                    throw new NotImplementedException($"Тип функции {functionType} не реализован.");
            }
        }


        private void CancelButton_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
    }
}