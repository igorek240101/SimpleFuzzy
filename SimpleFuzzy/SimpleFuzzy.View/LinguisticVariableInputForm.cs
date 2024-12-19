namespace SimpleFuzzy.View
{
    public partial class LinguisticVariableInputForm : Form
    {
        public string InputText { get; private set; }
        public LinguisticVariableInputForm(string prompt, string title)
        {
            InitializeComponent();
            this.Text = title;
            this.label1.Text = prompt;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.InputText = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
