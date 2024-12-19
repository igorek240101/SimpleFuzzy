namespace SimpleFuzzy.View
{
    partial class ConfirmSaveAs
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
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            metroLabel1 = new Label();
            metroTextBox1 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Location = new Point(677, 20);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(206, 34);
            button1.TabIndex = 1;
            button1.Text = "Открыть проводник";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.ControlText;
            textBox1.Location = new Point(9, 20);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(660, 34);
            textBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(467, 63);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(206, 29);
            button2.TabIndex = 3;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(681, 63);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(206, 29);
            button3.TabIndex = 4;
            button3.Text = "Отмена";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(4, 4);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(893, 100);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Сохранить проект как";
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Location = new Point(13, 63);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(97, 20);
            metroLabel1.TabIndex = 6;
            metroLabel1.Text = "Введите имя";
            // 
            // metroTextBox1
            // 
            metroTextBox1.Location = new Point(110, 63);
            metroTextBox1.Name = "metroTextBox1";
            metroTextBox1.Size = new Size(350, 27);
            metroTextBox1.TabIndex = 7;
            // 
            // ConfirmSaveAs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroTextBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(metroLabel1);
            Controls.Add(groupBox1);
            Name = "ConfirmSaveAs";
            Size = new Size(901, 113);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Label metroLabel1;
        private TextBox metroTextBox1;
    }
}
