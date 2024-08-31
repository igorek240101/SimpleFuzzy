namespace SimpleFuzzy.View
{
    partial class FuzzyOperationUI
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            operand1 = new ComboBox();
            Uno = new RadioButton();
            Bin = new RadioButton();
            nameLabel = new Label();
            pLabel = new Label();
            nameTextBox = new TextBox();
            operations = new ComboBox();
            operand2 = new ComboBox();
            okButton = new Button();
            cancelButton = new Button();
            pictureBox1 = new PictureBox();
            pNumericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // operand1
            // 
            operand1.FormattingEnabled = true;
            operand1.Location = new Point(3, 75);
            operand1.Name = "operand1";
            operand1.Size = new Size(123, 23);
            operand1.TabIndex = 0;
            operand1.SelectedIndexChanged += operand1_SelectedIndexChanged;
            // 
            // Uno
            // 
            Uno.AutoSize = true;
            Uno.Location = new Point(3, 51);
            Uno.Name = "Uno";
            Uno.Size = new Size(127, 19);
            Uno.TabIndex = 1;
            Uno.TabStop = true;
            Uno.Text = "Унарная операция";
            Uno.UseVisualStyleBackColor = true;
            Uno.CheckedChanged += Uno_CheckedChanged;
            // 
            // Bin
            // 
            Bin.AutoSize = true;
            Bin.Location = new Point(237, 51);
            Bin.Name = "Bin";
            Bin.Size = new Size(134, 19);
            Bin.TabIndex = 2;
            Bin.Text = "Бинарная операция";
            Bin.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(3, 3);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(111, 15);
            nameLabel.TabIndex = 12;
            nameLabel.Text = "Введите имя терма";
            // 
            // pLabel
            // 
            pLabel.Location = new Point(3, 116);
            pLabel.Name = "pLabel";
            pLabel.Size = new Size(166, 17);
            pLabel.TabIndex = 13;
            pLabel.Text = "Введите значение параметра \"p\"";
            pLabel.Visible = false;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(3, 18);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(378, 23);
            nameTextBox.TabIndex = 5;
            nameTextBox.Leave += nameTextBox_Leave;
            // 
            // operations
            // 
            operations.FormattingEnabled = true;
            operations.ItemHeight = 15;
            operations.Location = new Point(130, 75);
            operations.Name = "operations";
            operations.Size = new Size(123, 23);
            operations.TabIndex = 7;
            operations.SelectedIndexChanged += operations_SelectedIndexChanged;
            // 
            // operand2
            // 
            operand2.FormattingEnabled = true;
            operand2.ItemHeight = 15;
            operand2.Location = new Point(258, 75);
            operand2.Name = "operand2";
            operand2.Size = new Size(123, 23);
            operand2.TabIndex = 8;
            operand2.SelectedIndexChanged += operand2_SelectedIndexChanged;
            // 
            // okButton
            // 
            okButton.Location = new Point(3, 158);
            okButton.Name = "okButton";
            okButton.Size = new Size(87, 23);
            okButton.TabIndex = 9;
            okButton.Text = "Сохранить";
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(94, 158);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(87, 23);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Удалить";
            cancelButton.Click += cancelButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(386, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(320, 155);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pNumericUpDown
            // 
            pNumericUpDown.DecimalPlaces = 2;
            pNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            pNumericUpDown.Location = new Point(258, 116);
            pNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            pNumericUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            pNumericUpDown.Name = "pNumericUpDown";
            pNumericUpDown.Size = new Size(122, 23);
            pNumericUpDown.TabIndex = 14;
            pNumericUpDown.Visible = false;
            pNumericUpDown.ValueChanged += pNumericUpDown_ValueChanged;
            // 
            // FuzzyOperationUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(pNumericUpDown);
            Controls.Add(pictureBox1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(operand2);
            Controls.Add(operations);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(pLabel);
            Controls.Add(Bin);
            Controls.Add(Uno);
            Controls.Add(operand1);
            Name = "FuzzyOperationUI";
            Size = new Size(718, 184);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox operand1;
        private RadioButton Uno;
        private RadioButton Bin;
        private Label nameLabel;
        private Label pLabel;
        private TextBox nameTextBox;
        private ComboBox operations;
        private ComboBox operand2;
        private Button okButton;
        private Button cancelButton;
        private PictureBox pictureBox1;
        private NumericUpDown pNumericUpDown;
    }
}
