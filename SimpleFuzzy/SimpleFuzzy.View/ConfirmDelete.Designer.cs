namespace SimpleFuzzy.View
{
    partial class ConfirmDelete
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
            button2 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Highlight = false;
            button1.Location = new Point(16, 184);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.Style = MetroFramework.MetroColorStyle.Blue;
            button1.StyleManager = null;
            button1.TabIndex = 0;
            button1.Text = "Да";
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
            label1.Location = new Point(16, 161);
            label1.Name = "label1";
            label1.Size = new Size(436, 20);
            label1.Style = MetroFramework.MetroColorStyle.Blue;
            label1.StyleManager = null;
            label1.TabIndex = 2;
            label1.Text = "Вы действительно хотите безвозвратно удалить текущий проект?";
            label1.Theme = MetroFramework.MetroThemeStyle.Light;
            label1.UseStyleColors = false;
            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(358, 184);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 1;
            button2.Text = "Нет";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ConfirmDelete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ConfirmDelete";
            Size = new Size(561, 275);
            Load += ConfirmDelete_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroLabel label1;
    }
}
