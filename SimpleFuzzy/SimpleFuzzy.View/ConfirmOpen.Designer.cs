namespace SimpleFuzzy.View
{
    partial class ConfirmOpen
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
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            button2 = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(715, 373);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Открытие проекта";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(356, 109);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 11;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(356, 21);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 10;
            label1.Text = "Введите имя проекта";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(356, 44);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.SelectedText = "";
            textBox1.Size = new Size(348, 27);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(3, 21);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(347, 344);
            listBox1.TabIndex = 7;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // button2
            // 
            button2.Location = new Point(356, 77);
            button2.Name = "button2";
            button2.Size = new Size(171, 29);
            button2.TabIndex = 5;
            button2.Text = "Отмена";
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(533, 77);
            button1.Name = "button1";
            button1.Size = new Size(171, 27);
            button1.TabIndex = 4;
            button1.Text = "Открыть проводник";
            button1.Click += button1_Click;
            // 
            // ConfirmOpen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ConfirmOpen";
            Size = new Size(721, 379);
            Load += ConfirmOpen_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button1;
        private Button button2;
        private ListBox listBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
    }
}
