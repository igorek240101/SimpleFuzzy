namespace SimpleFuzzy.View
{
    partial class ConfirmCopy
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
            label1 = new MetroFramework.Controls.MetroLabel();
            button1 = new MetroFramework.Controls.MetroButton();
            textBox1 = new MetroFramework.Controls.MetroTextBox();
            button2 = new MetroFramework.Controls.MetroButton();
            button3 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.CustomBackground = false;
            label1.FontSize = MetroFramework.MetroLabelSize.Medium;
            label1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            label1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.Style = MetroFramework.MetroColorStyle.Blue;
            label1.StyleManager = null;
            label1.TabIndex = 0;
            label1.Text = "Расположение";
            label1.Theme = MetroFramework.MetroThemeStyle.Light;
            label1.UseStyleColors = false;
            // 
            // button1
            // 
            button1.Highlight = false;
            button1.Location = new Point(386, 6);
            button1.Name = "button1";
            button1.Size = new Size(134, 29);
            button1.Style = MetroFramework.MetroColorStyle.Blue;
            button1.StyleManager = null;
            button1.TabIndex = 1;
            button1.Text = "Открыть проводник";
            button1.Theme = MetroFramework.MetroThemeStyle.Light;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.FontSize = MetroFramework.MetroTextBoxSize.Small;
            textBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            textBox1.Location = new Point(112, 6);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.SelectedText = "";
            textBox1.Size = new Size(268, 27);
            textBox1.Style = MetroFramework.MetroColorStyle.Blue;
            textBox1.StyleManager = null;
            textBox1.TabIndex = 2;
            textBox1.Text = "C:\\Users\\User\\AppData\\Local\\Microsoft\\VisualStudio\\17.0_09e0b232\\WinFormsDesigner\\a1bqzmsp.eov\\Projects";
            textBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox1.UseStyleColors = false;
            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(112, 39);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 3;
            button2.Text = "Готово";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Highlight = false;
            button3.Location = new Point(212, 39);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.Style = MetroFramework.MetroColorStyle.Blue;
            button3.StyleManager = null;
            button3.TabIndex = 4;
            button3.Text = "Отмена";
            button3.Theme = MetroFramework.MetroThemeStyle.Light;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ConfirmCopy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ConfirmCopy";
            Size = new Size(686, 415);
            Load += ConfirmCopy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button3;
    }
}
