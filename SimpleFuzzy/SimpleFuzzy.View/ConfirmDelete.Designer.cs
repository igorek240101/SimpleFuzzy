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
            groupBox1 = new GroupBox();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(5, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(541, 87);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Подтверждение удаления";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(33, 23);
            label1.Name = "label1";
            label1.Size = new Size(465, 20);
            label1.TabIndex = 2;
            label1.Text = "Вы действительно хотите безвозвратно удалить текущий проект?";
            // 
            // button2
            // 
            button2.Location = new Point(354, 46);
            button2.Name = "button2";
            button2.Size = new Size(144, 29);
            button2.TabIndex = 1;
            button2.Text = "Нет";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(33, 46);
            button1.Name = "button1";
            button1.Size = new Size(144, 29);
            button1.TabIndex = 0;
            button1.Text = "Да";
            button1.Click += button1_Click;
            // 
            // ConfirmDelete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ConfirmDelete";
            Size = new Size(549, 98);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Button button2;
        private Label label1;
    }
}
