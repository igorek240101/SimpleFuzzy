namespace SimpleFuzzy.View
{
    partial class ConfirmCreate
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
            button1 = new MetroFramework.Controls.MetroButton();
            label1 = new MetroFramework.Controls.MetroLabel();
            textBox1 = new MetroFramework.Controls.MetroTextBox();
            textBox2 = new MetroFramework.Controls.MetroTextBox();
            button2 = new MetroFramework.Controls.MetroButton();
            label2 = new MetroFramework.Controls.MetroLabel();
            button3 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Highlight = false;
            button1.Location = new Point(481, 197);
            button1.Name = "button1";
            button1.Size = new Size(94, 27);
            button1.Style = MetroFramework.MetroColorStyle.Blue;
            button1.StyleManager = null;
            button1.TabIndex = 0;
            button1.Text = "Готово";
            button1.Theme = MetroFramework.MetroThemeStyle.Light;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.CustomBackground = false;
            label1.FontSize = MetroFramework.MetroLabelSize.Medium;
            label1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            label1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            label1.Location = new Point(11, 200);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.Style = MetroFramework.MetroColorStyle.Blue;
            label1.StyleManager = null;
            label1.TabIndex = 2;
            label1.Text = "Введите имя проекта";
            label1.Theme = MetroFramework.MetroThemeStyle.Light;
            label1.UseStyleColors = false;
            // 
            // textBox1
            // 
            textBox1.FontSize = MetroFramework.MetroTextBoxSize.Small;
            textBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            textBox1.Location = new Point(175, 197);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.SelectedText = "";
            textBox1.Size = new Size(300, 27);
            textBox1.Style = MetroFramework.MetroColorStyle.Blue;
            textBox1.StyleManager = null;
            textBox1.TabIndex = 3;
            textBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox1.UseStyleColors = false;
            // 
            // textBox2
            // 
            textBox2.FontSize = MetroFramework.MetroTextBoxSize.Small;
            textBox2.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            textBox2.Location = new Point(130, 164);
            textBox2.Multiline = false;
            textBox2.Name = "textBox2";
            textBox2.SelectedText = "";
            textBox2.Size = new Size(345, 27);
            textBox2.Style = MetroFramework.MetroColorStyle.Blue;
            textBox2.StyleManager = null;
            textBox2.TabIndex = 4;
            textBox2.Text = Directory.GetCurrentDirectory() + "\\Projects";
            textBox2.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox2.UseStyleColors = false;
            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(481, 164);
            button2.Name = "button2";
            button2.Size = new Size(194, 27);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 5;
            button2.Text = "Открыть проводник";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.CustomBackground = false;
            label2.FontSize = MetroFramework.MetroLabelSize.Medium;
            label2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            label2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            label2.Location = new Point(11, 167);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.Style = MetroFramework.MetroColorStyle.Blue;
            label2.StyleManager = null;
            label2.TabIndex = 6;
            label2.Text = "Расположение";
            label2.Theme = MetroFramework.MetroThemeStyle.Light;
            label2.UseStyleColors = false;
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.Highlight = false;
            button3.Location = new Point(581, 197);
            button3.Name = "button3";
            button3.Size = new Size(94, 27);
            button3.Style = MetroFramework.MetroColorStyle.Blue;
            button3.StyleManager = null;
            button3.TabIndex = 7;
            button3.Text = "Отмена";
            button3.Theme = MetroFramework.MetroThemeStyle.Light;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ConfirmCreate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "ConfirmCreate";
            Size = new Size(1434, 559);
            Load += ConfirmCreate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroTextBox textBox2;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroButton button3;
    }
}
