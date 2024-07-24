namespace SimpleFuzzy.View
{
    partial class GenerationObjectSetUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFirst.TextChanged += new System.EventHandler(this.ValidateInput);
            this.txtStep.TextChanged += new System.EventHandler(this.ValidateInput);
            this.txtLast.TextChanged += new System.EventHandler(this.ValidateInput);
            this.btnGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);

            txtFirst = new TextBox();
            txtStep = new TextBox();
            txtLast = new TextBox();
            btnGenerate = new Button();
            lblError = new Label();
            txtGeneratedCode = new TextBox();
            lblFirst = new Label();
            lblStep = new Label();
            lblLast = new Label();
            grpInput = new GroupBox();
            grpOutput = new GroupBox();
            grpInput.SuspendLayout();
            grpOutput.SuspendLayout();
            SuspendLayout();
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(187, 34);
            txtFirst.Margin = new Padding(4, 5, 4, 5);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(132, 27);
            txtFirst.TabIndex = 1;
            // 
            // txtStep
            // 
            txtStep.Location = new Point(187, 80);
            txtStep.Margin = new Padding(4, 5, 4, 5);
            txtStep.Name = "txtStep";
            txtStep.Size = new Size(132, 27);
            txtStep.TabIndex = 3;
            // 
            // txtLast
            // 
            txtLast.Location = new Point(187, 126);
            txtLast.Margin = new Padding(4, 5, 4, 5);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(132, 27);
            txtLast.TabIndex = 5;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(187, 172);
            btnGenerate.Margin = new Padding(4, 5, 4, 5);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(133, 35);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Создать";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(13, 223);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 7;
            // 
            // txtGeneratedCode
            // 
            txtGeneratedCode.Dock = DockStyle.Fill;
            txtGeneratedCode.Location = new Point(4, 25);
            txtGeneratedCode.Margin = new Padding(4, 5, 4, 5);
            txtGeneratedCode.Multiline = true;
            txtGeneratedCode.Name = "txtGeneratedCode";
            txtGeneratedCode.ReadOnly = true;
            txtGeneratedCode.ScrollBars = ScrollBars.Vertical;
            txtGeneratedCode.Size = new Size(339, 278);
            txtGeneratedCode.TabIndex = 0;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(13, 38);
            lblFirst.Margin = new Padding(4, 0, 4, 0);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(159, 20);
            lblFirst.TabIndex = 0;
            lblFirst.Text = "Начальное значение:";
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Location = new Point(13, 85);
            lblStep.Margin = new Padding(4, 0, 4, 0);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(40, 20);
            lblStep.TabIndex = 2;
            lblStep.Text = "Шаг:";
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(13, 131);
            lblLast.Margin = new Padding(4, 0, 4, 0);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(151, 20);
            lblLast.TabIndex = 4;
            lblLast.Text = "Конечное значение:";
            // 
            // grpInput
            // 
            grpInput.Controls.Add(lblFirst);
            grpInput.Controls.Add(txtFirst);
            grpInput.Controls.Add(lblStep);
            grpInput.Controls.Add(txtStep);
            grpInput.Controls.Add(lblLast);
            grpInput.Controls.Add(txtLast);
            grpInput.Controls.Add(btnGenerate);
            grpInput.Controls.Add(lblError);
            grpInput.Location = new Point(16, 18);
            grpInput.Margin = new Padding(4, 5, 4, 5);
            grpInput.Name = "grpInput";
            grpInput.Padding = new Padding(4, 5, 4, 5);
            grpInput.Size = new Size(347, 280);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Входные данные";
            // 
            // grpOutput
            // 
            grpOutput.Controls.Add(txtGeneratedCode);
            grpOutput.Location = new Point(16, 308);
            grpOutput.Margin = new Padding(4, 5, 4, 5);
            grpOutput.Name = "grpOutput";
            grpOutput.Padding = new Padding(4, 5, 4, 5);
            grpOutput.Size = new Size(347, 308);
            grpOutput.TabIndex = 1;
            grpOutput.TabStop = false;
            grpOutput.Text = "Сгенерированный код";
            // 
            // GenerationObjectSetUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 628);
            Controls.Add(grpInput);
            Controls.Add(grpOutput);
            Margin = new Padding(4, 5, 4, 5);
            Name = "GenerationObjectSetUI";
            Text = "Генератор ObjectSet";
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            grpOutput.ResumeLayout(false);
            grpOutput.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtGeneratedCode;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.GroupBox grpOutput;
    }
}