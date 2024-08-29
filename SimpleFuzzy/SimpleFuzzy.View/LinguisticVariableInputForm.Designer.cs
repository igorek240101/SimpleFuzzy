namespace SimpleFuzzy.View
{
    partial class LinguisticVariableInputForm
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
            textBox = new TextBox();
            label1 = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Location = new Point(15, 175);
            textBox.Margin = new Padding(2, 1, 2, 1);
            textBox.Name = "textBox";
            textBox.Size = new Size(275, 27);
            textBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 49);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(298, 171);
            buttonOK.Margin = new Padding(2, 1, 2, 1);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(93, 29);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "Создать";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(394, 171);
            buttonCancel.Margin = new Padding(2, 1, 2, 1);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(93, 29);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // LinguisticVariableInputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 281);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(label1);
            Controls.Add(textBox);
            Margin = new Padding(2, 1, 2, 1);
            Name = "LinguisticVariableInputForm";
            Text = "LinguisticVariableInputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox;
        private Label label1;
        private Button buttonOK;
        private Button buttonCancel;
    }
}