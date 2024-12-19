namespace SimpleFuzzy.View
{
    partial class NewMembershipDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            metroRadioButton1 = new RadioButton();
            metroRadioButton2 = new RadioButton();
            SuspendLayout();
            // 
            // metroRadioButton1
            // 
            metroRadioButton1.AutoSize = true;
            metroRadioButton1.Checked = true;
            metroRadioButton1.Location = new Point(12, 12);
            metroRadioButton1.Name = "metroRadioButton1";
            metroRadioButton1.Size = new Size(260, 19);
            metroRadioButton1.TabIndex = 0;
            metroRadioButton1.TabStop = true;
            metroRadioButton1.Text = "Сгенерировать функцию принадлежности";
            metroRadioButton1.UseVisualStyleBackColor = true;
            metroRadioButton1.CheckedChanged += metroRadioButton1_CheckedChanged;
            // 
            // metroRadioButton2
            // 
            metroRadioButton2.AutoSize = true;
            metroRadioButton2.Location = new Point(303, 12);
            metroRadioButton2.Name = "metroRadioButton2";
            metroRadioButton2.Size = new Size(208, 19);
            metroRadioButton2.TabIndex = 1;
            metroRadioButton2.Text = "Задать терм нечеткой операцией";
            metroRadioButton2.UseVisualStyleBackColor = true;
            // 
            // NewMembershipDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(912, 461);
            Controls.Add(metroRadioButton2);
            Controls.Add(metroRadioButton1);
            Name = "NewMembershipDialogForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton metroRadioButton1;
        private RadioButton metroRadioButton2;
        public const bool isChangableSize = true;
    }
}