namespace SimpleFuzzy.View
{
    partial class DefasificationForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OutputVariables = new ComboBox();
            MaxProd = new RadioButton();
            MaxMin = new RadioButton();
            MaximumMethod = new RadioButton();
            MethodAverageMax = new RadioButton();
            MetodLeftLineDef = new RadioButton();
            MethodRightLineDef = new RadioButton();
            MethodSenterGravity = new RadioButton();
            MethodsOfInference = new GroupBox();
            MethodsOfDefasification = new GroupBox();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            MethodsOfInference.SuspendLayout();
            MethodsOfDefasification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // OutputVariables
            // 
            OutputVariables.FormattingEnabled = true;
            OutputVariables.Location = new Point(308, 17);
            OutputVariables.Margin = new Padding(3, 2, 3, 2);
            OutputVariables.Name = "OutputVariables";
            OutputVariables.Size = new Size(347, 23);
            OutputVariables.TabIndex = 0;
            OutputVariables.SelectedIndexChanged += OutputVariables_SelectedIndexChanged;
            // 
            // MaxProd
            // 
            MaxProd.AutoSize = true;
            MaxProd.Checked = true;
            MaxProd.Location = new Point(9, 15);
            MaxProd.Margin = new Padding(3, 2, 3, 2);
            MaxProd.Name = "MaxProd";
            MaxProd.Size = new Size(78, 19);
            MaxProd.TabIndex = 1;
            MaxProd.TabStop = true;
            MaxProd.Text = "Max-Prod";
            MaxProd.UseVisualStyleBackColor = true;
            MaxProd.CheckedChanged += MaxProd_CheckedChanged;
            // 
            // MaxMin
            // 
            MaxMin.AutoSize = true;
            MaxMin.Location = new Point(9, 34);
            MaxMin.Margin = new Padding(3, 2, 3, 2);
            MaxMin.Name = "MaxMin";
            MaxMin.Size = new Size(74, 19);
            MaxMin.TabIndex = 2;
            MaxMin.Text = "Max-Min";
            MaxMin.UseVisualStyleBackColor = true;
            // 
            // MaximumMethod
            // 
            MaximumMethod.AutoSize = true;
            MaximumMethod.Checked = true;
            MaximumMethod.Location = new Point(9, 15);
            MaximumMethod.Margin = new Padding(3, 2, 3, 2);
            MaximumMethod.Name = "MaximumMethod";
            MaximumMethod.Size = new Size(127, 19);
            MaximumMethod.TabIndex = 3;
            MaximumMethod.TabStop = true;
            MaximumMethod.Text = "Метод максимума";
            MaximumMethod.UseVisualStyleBackColor = true;
            MaximumMethod.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodAverageMax
            // 
            MethodAverageMax.AutoSize = true;
            MethodAverageMax.Location = new Point(9, 52);
            MethodAverageMax.Margin = new Padding(3, 2, 3, 2);
            MethodAverageMax.Name = "MethodAverageMax";
            MethodAverageMax.Size = new Size(241, 19);
            MethodAverageMax.TabIndex = 4;
            MethodAverageMax.Text = "Метод среднего значения максимумов";
            MethodAverageMax.UseVisualStyleBackColor = true;
            MethodAverageMax.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MetodLeftLineDef
            // 
            MetodLeftLineDef.AutoSize = true;
            MetodLeftLineDef.Location = new Point(9, 71);
            MetodLeftLineDef.Margin = new Padding(3, 2, 3, 2);
            MetodLeftLineDef.Name = "MetodLeftLineDef";
            MetodLeftLineDef.Size = new Size(251, 19);
            MetodLeftLineDef.TabIndex = 5;
            MetodLeftLineDef.Text = "Метод линейной дефазификации (слева)";
            MetodLeftLineDef.UseVisualStyleBackColor = true;
            MetodLeftLineDef.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodRightLineDef
            // 
            MethodRightLineDef.AutoSize = true;
            MethodRightLineDef.Location = new Point(9, 90);
            MethodRightLineDef.Margin = new Padding(3, 2, 3, 2);
            MethodRightLineDef.Name = "MethodRightLineDef";
            MethodRightLineDef.Size = new Size(258, 19);
            MethodRightLineDef.TabIndex = 6;
            MethodRightLineDef.Text = "Метод линейной дефазификации (справа)";
            MethodRightLineDef.UseVisualStyleBackColor = true;
            MethodRightLineDef.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodSenterGravity
            // 
            MethodSenterGravity.AutoSize = true;
            MethodSenterGravity.Location = new Point(9, 34);
            MethodSenterGravity.Margin = new Padding(3, 2, 3, 2);
            MethodSenterGravity.Name = "MethodSenterGravity";
            MethodSenterGravity.Size = new Size(148, 19);
            MethodSenterGravity.TabIndex = 7;
            MethodSenterGravity.Text = "Метод центра тяжести";
            MethodSenterGravity.UseVisualStyleBackColor = true;
            MethodSenterGravity.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodsOfInference
            // 
            MethodsOfInference.Controls.Add(MaxProd);
            MethodsOfInference.Controls.Add(MaxMin);
            MethodsOfInference.Location = new Point(6, 134);
            MethodsOfInference.Margin = new Padding(3, 2, 3, 2);
            MethodsOfInference.Name = "MethodsOfInference";
            MethodsOfInference.Padding = new Padding(3, 2, 3, 2);
            MethodsOfInference.Size = new Size(150, 58);
            MethodsOfInference.TabIndex = 8;
            MethodsOfInference.TabStop = false;
            MethodsOfInference.Text = "Методы инференции";
            // 
            // MethodsOfDefasification
            // 
            MethodsOfDefasification.Controls.Add(MaximumMethod);
            MethodsOfDefasification.Controls.Add(MethodAverageMax);
            MethodsOfDefasification.Controls.Add(MetodLeftLineDef);
            MethodsOfDefasification.Controls.Add(MethodRightLineDef);
            MethodsOfDefasification.Controls.Add(MethodSenterGravity);
            MethodsOfDefasification.Location = new Point(6, 17);
            MethodsOfDefasification.Margin = new Padding(3, 2, 3, 2);
            MethodsOfDefasification.Name = "MethodsOfDefasification";
            MethodsOfDefasification.Padding = new Padding(3, 2, 3, 2);
            MethodsOfDefasification.Size = new Size(296, 113);
            MethodsOfDefasification.TabIndex = 9;
            MethodsOfDefasification.TabStop = false;
            MethodsOfDefasification.Text = "Методы дефазификации";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(308, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(347, 231);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(308, 282);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(347, 23);
            textBox1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(308, 311);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(347, 237);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // DefasificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(pictureBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(MethodsOfDefasification);
            Controls.Add(MethodsOfInference);
            Controls.Add(OutputVariables);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DefasificationForm";
            Size = new Size(737, 566);
            MethodsOfInference.ResumeLayout(false);
            MethodsOfInference.PerformLayout();
            MethodsOfDefasification.ResumeLayout(false);
            MethodsOfDefasification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox OutputVariables;
        private RadioButton MaxProd;
        private RadioButton MaxMin;
        private RadioButton MaximumMethod;
        private RadioButton MethodAverageMax;
        private RadioButton MetodLeftLineDef;
        private RadioButton MethodRightLineDef;
        private RadioButton MethodSenterGravity;
        private GroupBox MethodsOfInference;
        private GroupBox MethodsOfDefasification;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private PictureBox pictureBox2;
    }
}
