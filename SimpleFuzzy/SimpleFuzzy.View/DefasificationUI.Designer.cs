namespace SimpleFuzzy.View
{
    partial class DefasificationUI
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
            graphPictureBox = new PictureBox();
            ResultDef = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            SuspendLayout();
            // 
            // graphPictureBox
            // 
            graphPictureBox.Location = new Point(405, 0);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(430, 221);
            graphPictureBox.TabIndex = 8;
            graphPictureBox.TabStop = false;
            // 
            // ResultDef
            // 
            ResultDef.Location = new Point(659, 233);
            ResultDef.Name = "ResultDef";
            ResultDef.Size = new Size(125, 27);
            ResultDef.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(460, 236);
            label1.Name = "label1";
            label1.Size = new Size(193, 20);
            label1.TabIndex = 11;
            label1.Text = "Результат дефазификации:";
            // 
            // DefasificationUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(ResultDef);
            Controls.Add(graphPictureBox);
            Name = "DefasificationUI";
            Size = new Size(871, 542);
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox graphPictureBox;
        #endregion

        private Button button1;
        private TextBox ResultDef;
        private Label label1;
    }
}
