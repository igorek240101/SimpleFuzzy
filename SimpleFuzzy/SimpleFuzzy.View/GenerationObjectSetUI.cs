using System;
using System.Windows.Forms;
using SimpleFuzzy.Service;

namespace SimpleFuzzy.View
{
    public partial class GenerationObjectSetUI : UserControl
    {
        public GenerationObjectSetUI()
        {
            InitializeComponent();
        }

        private void ValidateInput(object sender, EventArgs e)
        {
            bool isValid = false;
            string errorMessage = "";
            if (double.TryParse(this.txtFirst.Text, out double first) &&
                double.TryParse(this.txtStep.Text, out double step) &&
                double.TryParse(this.txtLast.Text, out double last))
            {
                if (step == 0) errorMessage = "Шаг не может быть равен нулю.";
                else if (Math.Sign(last - first) != Math.Sign(step)) errorMessage = "Направление шага не соответствует начальному и конечному значению.";
                else if ((last - first) % step != 0) errorMessage = "Конечное значение не достижимо с заданным шагом.";
                else isValid = true;
            }
            else lblError.Text = "Пожалуйста, введите корректные числовые значения";
            btnGenerate.Enabled = isValid;
            lblError.Text = errorMessage;
            lblError.AutoSize = true;
            lblError.MaximumSize = new Size(lblError.Parent.ClientSize.Width - 20, 0);
        }

            private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            double first = double.Parse(txtFirst.Text);
            double step = double.Parse(txtStep.Text);
            double last = double.Parse(txtLast.Text);

            try
            {
                string generatedCode = GenerationObjectSet.ReturnObjectSet(first, step, last);
                txtGeneratedCode.Text = generatedCode;
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
