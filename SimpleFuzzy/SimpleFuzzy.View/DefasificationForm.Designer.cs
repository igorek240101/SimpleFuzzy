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
            MethodsOfInference.SuspendLayout();
            MethodsOfDefasification.SuspendLayout();
            SuspendLayout();
            // 
            // OutputVariables
            // 
            OutputVariables.FormattingEnabled = true;
            OutputVariables.Location = new Point(3, 3);
            OutputVariables.Name = "OutputVariables";
            OutputVariables.Size = new Size(151, 28);
            OutputVariables.TabIndex = 0;
            OutputVariables.SelectedIndexChanged += OutputVariables_SelectedIndexChanged;
            // 
            // MaxProd
            // 
            MaxProd.AutoSize = true;
            MaxProd.Location = new Point(10, 20);
            MaxProd.Name = "MaxProd";
            MaxProd.Size = new Size(95, 24);
            MaxProd.TabIndex = 1;
            MaxProd.TabStop = true;
            MaxProd.Text = "Max-Prod";
            MaxProd.UseVisualStyleBackColor = true;
            // 
            // MaxMin
            // 
            MaxMin.AutoSize = true;
            MaxMin.Location = new Point(10, 45);
            MaxMin.Name = "MaxMin";
            MaxMin.Size = new Size(89, 24);
            MaxMin.TabIndex = 2;
            MaxMin.TabStop = true;
            MaxMin.Text = "Max-Min";
            MaxMin.UseVisualStyleBackColor = true;
            // 
            // MaximumMethod
            // 
            MaximumMethod.AutoSize = true;
            MaximumMethod.Location = new Point(10, 20);
            MaximumMethod.Name = "MaximumMethod";
            MaximumMethod.Size = new Size(157, 24);
            MaximumMethod.TabIndex = 3;
            MaximumMethod.TabStop = true;
            MaximumMethod.Text = "Метод максимума";
            MaximumMethod.UseVisualStyleBackColor = true;
            // 
            // MethodAverageMax
            // 
            MethodAverageMax.AutoSize = true;
            MethodAverageMax.Location = new Point(10, 70);
            MethodAverageMax.Name = "MethodAverageMax";
            MethodAverageMax.Size = new Size(304, 24);
            MethodAverageMax.TabIndex = 4;
            MethodAverageMax.TabStop = true;
            MethodAverageMax.Text = "Метод среднего значения максимумов";
            MethodAverageMax.UseVisualStyleBackColor = true;
            // 
            // MetodLeftLineDef
            // 
            MetodLeftLineDef.AutoSize = true;
            MetodLeftLineDef.Location = new Point(10, 95);
            MetodLeftLineDef.Name = "MetodLeftLineDef";
            MetodLeftLineDef.Size = new Size(316, 24);
            MetodLeftLineDef.TabIndex = 5;
            MetodLeftLineDef.TabStop = true;
            MetodLeftLineDef.Text = "Метод линейной дефазификации (слева)";
            MetodLeftLineDef.UseVisualStyleBackColor = true;
            // 
            // MethodRightLineDef
            // 
            MethodRightLineDef.AutoSize = true;
            MethodRightLineDef.Location = new Point(10, 120);
            MethodRightLineDef.Name = "MethodRightLineDef";
            MethodRightLineDef.Size = new Size(326, 24);
            MethodRightLineDef.TabIndex = 6;
            MethodRightLineDef.TabStop = true;
            MethodRightLineDef.Text = "Метод линейной дефазификации (справа)";
            MethodRightLineDef.UseVisualStyleBackColor = true;
            // 
            // MethodSenterGravity
            // 
            MethodSenterGravity.AutoSize = true;
            MethodSenterGravity.Location = new Point(10, 45);
            MethodSenterGravity.Name = "MethodSenterGravity";
            MethodSenterGravity.Size = new Size(186, 24);
            MethodSenterGravity.TabIndex = 7;
            MethodSenterGravity.TabStop = true;
            MethodSenterGravity.Text = "Метод центра тяжести";
            MethodSenterGravity.UseVisualStyleBackColor = true;
            // 
            // MethodsOfInference
            // 
            MethodsOfInference.Controls.Add(MaxProd);
            MethodsOfInference.Controls.Add(MaxMin);
            MethodsOfInference.Location = new Point(3, 98);
            MethodsOfInference.Name = "MethodsOfInference";
            MethodsOfInference.Size = new Size(172, 77);
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
            MethodsOfDefasification.Location = new Point(3, 181);
            MethodsOfDefasification.Name = "MethodsOfDefasification";
            MethodsOfDefasification.Size = new Size(338, 151);
            MethodsOfDefasification.TabIndex = 9;
            MethodsOfDefasification.TabStop = false;
            MethodsOfDefasification.Text = "Методы дефазификации";
            // 
            // DefasificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MethodsOfDefasification);
            Controls.Add(MethodsOfInference);
            Controls.Add(OutputVariables);
            Name = "DefasificationForm";
            Size = new Size(870, 477);
            MethodsOfInference.ResumeLayout(false);
            MethodsOfInference.PerformLayout();
            MethodsOfDefasification.ResumeLayout(false);
            MethodsOfDefasification.PerformLayout();
            ResumeLayout(false);
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
    }
}
