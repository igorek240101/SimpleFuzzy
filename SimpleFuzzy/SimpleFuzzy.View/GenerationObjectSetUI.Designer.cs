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
            btnGenerate = new Button();
            lblError = new Label();
            lblFirst = new Label();
            lblStep = new Label();
            lblLast = new Label();
            grpInput = new GroupBox();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            nameTextBox = new TextBox();
            label1 = new Label();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(163, 156);
            btnGenerate.Margin = new Padding(4);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(116, 26);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Создать";
            btnGenerate.Click += ButtonGenerate_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(11, 167);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 7;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(10, 59);
            lblFirst.Margin = new Padding(4, 0, 4, 0);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(125, 15);
            lblFirst.TabIndex = 0;
            lblFirst.Text = "Начальное значение:";
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Location = new Point(10, 95);
            lblStep.Margin = new Padding(4, 0, 4, 0);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(32, 15);
            lblStep.TabIndex = 2;
            lblStep.Text = "Шаг:";
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(10, 129);
            lblLast.Margin = new Padding(4, 0, 4, 0);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(118, 15);
            lblLast.TabIndex = 4;
            lblLast.Text = "Конечное значение:";
            // 
            // grpInput
            // 
            grpInput.Controls.Add(numericUpDown3);
            grpInput.Controls.Add(numericUpDown2);
            grpInput.Controls.Add(numericUpDown1);
            grpInput.Controls.Add(nameTextBox);
            grpInput.Controls.Add(label1);
            grpInput.Controls.Add(lblFirst);
            grpInput.Controls.Add(lblStep);
            grpInput.Controls.Add(lblLast);
            grpInput.Controls.Add(btnGenerate);
            grpInput.Controls.Add(lblError);
            grpInput.Location = new Point(14, 14);
            grpInput.Margin = new Padding(4);
            grpInput.Name = "grpInput";
            grpInput.Padding = new Padding(4);
            grpInput.Size = new Size(304, 201);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Входные данные";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 5;
            numericUpDown3.Location = new Point(164, 121);
            numericUpDown3.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 12;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 5;
            numericUpDown2.Location = new Point(164, 87);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 11;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 5;
            numericUpDown1.Location = new Point(163, 51);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 10;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(164, 19);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(116, 23);
            nameTextBox.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 27);
            label1.Name = "label1";
            label1.Size = new Size(148, 15);
            label1.TabIndex = 8;
            label1.Text = "Имя базового множества";
            // 
            // GenerationObjectSetUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 232);
            Controls.Add(grpInput);
            Margin = new Padding(4);
            Name = "GenerationObjectSetUI";
            Text = "Генератор ObjectSet";
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.GroupBox grpInput;
        private TextBox nameTextBox;
        private Label label1;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        public const bool isChangableSize = true;
    }
}