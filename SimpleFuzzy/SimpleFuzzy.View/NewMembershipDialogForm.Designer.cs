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
            metroRadioButton1.Location = new Point(14, 16);
            metroRadioButton1.Margin = new Padding(3, 4, 3, 4);
            metroRadioButton1.Name = "metroRadioButton1";
            metroRadioButton1.Size = new Size(326, 24);
            metroRadioButton1.TabIndex = 0;
            metroRadioButton1.TabStop = true;
            metroRadioButton1.Text = "Сгенерировать функцию принадлежности";
            metroRadioButton1.UseVisualStyleBackColor = true;
            metroRadioButton1.CheckedChanged += metroRadioButton1_CheckedChanged;
            // 
            // metroRadioButton2
            // 
            metroRadioButton2.AutoSize = true;
            metroRadioButton2.Location = new Point(346, 16);
            metroRadioButton2.Margin = new Padding(3, 4, 3, 4);
            metroRadioButton2.Name = "metroRadioButton2";
            metroRadioButton2.Size = new Size(264, 24);
            metroRadioButton2.TabIndex = 1;
            metroRadioButton2.Text = "Задать терм нечеткой операцией";
            metroRadioButton2.UseVisualStyleBackColor = true;
            // 
            // NewMembershipDialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(806, 437);
            Controls.Add(metroRadioButton2);
            Controls.Add(metroRadioButton1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NewMembershipDialogForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton metroRadioButton1;
        private RadioButton metroRadioButton2;
    }
}