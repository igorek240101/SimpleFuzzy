
using OxyPlot.WindowsForms;

namespace SimpleFuzzy.View
{
    partial class GenerationMembershipUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBoxSettings = new GroupBox();
            textBox1 = new TextBox();
            label1 = new Label();
            labelBaseSet = new Label();
            comboBoxBaseSet = new ComboBox();
            groupBoxConditions = new GroupBox();
            panelConditions = new Panel();
            buttonAddCondition = new Button();
            groupBoxActions = new GroupBox();
            buttonGenerateCode = new Button();
            buttonVisualize = new Button();
            pictureBox1 = new PictureBox();
            groupBoxSettings.SuspendLayout();
            groupBoxConditions.SuspendLayout();
            groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Controls.Add(textBox1);
            groupBoxSettings.Controls.Add(label1);
            groupBoxSettings.Controls.Add(labelBaseSet);
            groupBoxSettings.Controls.Add(comboBoxBaseSet);
            groupBoxSettings.Location = new Point(14, 14);
            groupBoxSettings.Margin = new Padding(4);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Padding = new Padding(4);
            groupBoxSettings.Size = new Size(350, 122);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Настройки";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(152, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 23);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 32);
            label1.Name = "label1";
            label1.Size = new Size(84, 30);
            label1.TabIndex = 4;
            label1.Text = "Имя базового\r\nмножества";
            // 
            // labelBaseSet
            // 
            labelBaseSet.AutoSize = true;
            labelBaseSet.Location = new Point(7, 84);
            labelBaseSet.Margin = new Padding(4, 0, 4, 0);
            labelBaseSet.MaximumSize = new Size(116, 0);
            labelBaseSet.Name = "labelBaseSet";
            labelBaseSet.Size = new Size(72, 30);
            labelBaseSet.TabIndex = 2;
            labelBaseSet.Text = "Базовое множество:";
            // 
            // comboBoxBaseSet
            // 
            comboBoxBaseSet.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaseSet.FormattingEnabled = true;
            comboBoxBaseSet.Location = new Point(152, 91);
            comboBoxBaseSet.Margin = new Padding(4);
            comboBoxBaseSet.Name = "comboBoxBaseSet";
            comboBoxBaseSet.Size = new Size(197, 23);
            comboBoxBaseSet.TabIndex = 3;
            comboBoxBaseSet.SelectedIndexChanged += comboBoxBaseSet_SelectedIndexChanged;
            // 
            // groupBoxConditions
            // 
            groupBoxConditions.Controls.Add(panelConditions);
            groupBoxConditions.Controls.Add(buttonAddCondition);
            groupBoxConditions.Location = new Point(13, 144);
            groupBoxConditions.Margin = new Padding(4);
            groupBoxConditions.Name = "groupBoxConditions";
            groupBoxConditions.Padding = new Padding(4);
            groupBoxConditions.Size = new Size(350, 231);
            groupBoxConditions.TabIndex = 1;
            groupBoxConditions.TabStop = false;
            groupBoxConditions.Text = "Условия";
            // 
            // panelConditions
            // 
            panelConditions.AutoScroll = true;
            panelConditions.Location = new Point(7, 22);
            panelConditions.Margin = new Padding(4);
            panelConditions.Name = "panelConditions";
            panelConditions.Size = new Size(336, 169);
            panelConditions.TabIndex = 0;
            // 
            // buttonAddCondition
            // 
            buttonAddCondition.Location = new Point(8, 197);
            buttonAddCondition.Margin = new Padding(4);
            buttonAddCondition.Name = "buttonAddCondition";
            buttonAddCondition.Size = new Size(336, 26);
            buttonAddCondition.TabIndex = 1;
            buttonAddCondition.Text = "Добавить условие";
            buttonAddCondition.UseVisualStyleBackColor = true;
            buttonAddCondition.Click += buttonAddCondition_Click;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Controls.Add(buttonGenerateCode);
            groupBoxActions.Controls.Add(buttonVisualize);
            groupBoxActions.Location = new Point(13, 383);
            groupBoxActions.Margin = new Padding(4);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Padding = new Padding(4);
            groupBoxActions.Size = new Size(350, 57);
            groupBoxActions.TabIndex = 2;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Действия";
            // 
            // buttonGenerateCode
            // 
            buttonGenerateCode.Location = new Point(7, 22);
            buttonGenerateCode.Margin = new Padding(4);
            buttonGenerateCode.Name = "buttonGenerateCode";
            buttonGenerateCode.Size = new Size(164, 26);
            buttonGenerateCode.TabIndex = 0;
            buttonGenerateCode.Text = "Сгенерировать";
            buttonGenerateCode.UseVisualStyleBackColor = true;
            buttonGenerateCode.Click += buttonGenerateCode_Click;
            // 
            // buttonVisualize
            // 
            buttonVisualize.Location = new Point(178, 22);
            buttonVisualize.Margin = new Padding(4);
            buttonVisualize.Name = "buttonVisualize";
            buttonVisualize.Size = new Size(164, 26);
            buttonVisualize.TabIndex = 1;
            buttonVisualize.Text = "Сохранить";
            buttonVisualize.UseVisualStyleBackColor = true;
            buttonVisualize.Click += buttonVisualize_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(371, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(543, 408);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // GenerationMembershipUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(groupBoxActions);
            Controls.Add(groupBoxConditions);
            Controls.Add(groupBoxSettings);
            Margin = new Padding(4);
            MinimumSize = new Size(928, 454);
            Name = "GenerationMembershipUI";
            Size = new Size(928, 454);
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            groupBoxConditions.ResumeLayout(false);
            groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelBaseSet;
        private System.Windows.Forms.GroupBox groupBoxConditions;
        private System.Windows.Forms.Panel panelConditions;
        private System.Windows.Forms.Button buttonAddCondition;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonGenerateCode;
        private System.Windows.Forms.Button buttonVisualize;
        private ComboBox comboBoxBaseSet;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}

