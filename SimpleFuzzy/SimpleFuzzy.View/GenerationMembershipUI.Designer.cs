
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
            labelType = new Label();
            comboBoxType = new ComboBox();
            labelBaseSet = new Label();
            comboBoxBaseSet = new ComboBox();
            groupBoxConditions = new GroupBox();
            panelConditions = new Panel();
            buttonAddCondition = new Button();
            groupBoxActions = new GroupBox();
            buttonGenerateCode = new Button();
            buttonVisualize = new Button();
            splitContainer = new SplitContainer();
            textBoxGeneratedCode = new TextBox();
            plotView = new PlotView();
            groupBoxSettings.SuspendLayout();
            groupBoxConditions.SuspendLayout();
            groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Controls.Add(labelType);
            groupBoxSettings.Controls.Add(comboBoxType);
            groupBoxSettings.Controls.Add(labelBaseSet);
            groupBoxSettings.Controls.Add(comboBoxBaseSet);
            groupBoxSettings.Location = new Point(16, 18);
            groupBoxSettings.Margin = new Padding(4, 5, 4, 5);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Padding = new Padding(4, 5, 4, 5);
            groupBoxSettings.Size = new Size(400, 155);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Настройки";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(8, 34);
            labelType.Margin = new Padding(4, 0, 4, 0);
            labelType.Name = "labelType";
            labelType.Size = new Size(38, 20);
            labelType.TabIndex = 0;
            labelType.Text = "Тип:";
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(160, 29);
            comboBoxType.Margin = new Padding(4, 5, 4, 5);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(225, 28);
            comboBoxType.TabIndex = 1;
            // 
            // labelBaseSet
            // 
            labelBaseSet.AutoSize = true;
            labelBaseSet.Location = new Point(8, 80);
            labelBaseSet.Margin = new Padding(4, 0, 4, 0);
            labelBaseSet.MaximumSize = new Size(133, 0);
            labelBaseSet.Name = "labelBaseSet";
            labelBaseSet.Size = new Size(90, 40);
            labelBaseSet.TabIndex = 2;
            labelBaseSet.Text = "Базовое множество:";
            // 
            // comboBoxBaseSet
            // 
            comboBoxBaseSet.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaseSet.FormattingEnabled = true;
            comboBoxBaseSet.Location = new Point(160, 92);
            comboBoxBaseSet.Margin = new Padding(4, 5, 4, 5);
            comboBoxBaseSet.Name = "comboBoxBaseSet";
            comboBoxBaseSet.Size = new Size(225, 28);
            comboBoxBaseSet.TabIndex = 3;
            // 
            // groupBoxConditions
            // 
            groupBoxConditions.Controls.Add(panelConditions);
            groupBoxConditions.Controls.Add(buttonAddCondition);
            groupBoxConditions.Location = new Point(16, 183);
            groupBoxConditions.Margin = new Padding(4, 5, 4, 5);
            groupBoxConditions.Name = "groupBoxConditions";
            groupBoxConditions.Padding = new Padding(4, 5, 4, 5);
            groupBoxConditions.Size = new Size(400, 308);
            groupBoxConditions.TabIndex = 1;
            groupBoxConditions.TabStop = false;
            groupBoxConditions.Text = "Условия";
            // 
            // panelConditions
            // 
            panelConditions.AutoScroll = true;
            panelConditions.Location = new Point(8, 29);
            panelConditions.Margin = new Padding(4, 5, 4, 5);
            panelConditions.Name = "panelConditions";
            panelConditions.Size = new Size(384, 225);
            panelConditions.TabIndex = 0;
            // 
            // buttonAddCondition
            // 
            buttonAddCondition.Location = new Point(8, 263);
            buttonAddCondition.Margin = new Padding(4, 5, 4, 5);
            buttonAddCondition.Name = "buttonAddCondition";
            buttonAddCondition.Size = new Size(384, 35);
            buttonAddCondition.TabIndex = 1;
            buttonAddCondition.Text = "Добавить условие";
            buttonAddCondition.UseVisualStyleBackColor = true;
            buttonAddCondition.Click += buttonAddCondition_Click;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Controls.Add(buttonGenerateCode);
            groupBoxActions.Controls.Add(buttonVisualize);
            groupBoxActions.Location = new Point(16, 501);
            groupBoxActions.Margin = new Padding(4, 5, 4, 5);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Padding = new Padding(4, 5, 4, 5);
            groupBoxActions.Size = new Size(400, 85);
            groupBoxActions.TabIndex = 2;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Действия";
            // 
            // buttonGenerateCode
            // 
            buttonGenerateCode.Location = new Point(8, 29);
            buttonGenerateCode.Margin = new Padding(4, 5, 4, 5);
            buttonGenerateCode.Name = "buttonGenerateCode";
            buttonGenerateCode.Size = new Size(188, 35);
            buttonGenerateCode.TabIndex = 0;
            buttonGenerateCode.Text = "Сгенерировать";
            buttonGenerateCode.UseVisualStyleBackColor = true;
            buttonGenerateCode.Click += buttonGenerateCode_Click;
            // 
            // buttonVisualize
            // 
            buttonVisualize.Location = new Point(204, 29);
            buttonVisualize.Margin = new Padding(4, 5, 4, 5);
            buttonVisualize.Name = "buttonVisualize";
            buttonVisualize.Size = new Size(188, 35);
            buttonVisualize.TabIndex = 1;
            buttonVisualize.Text = "Визуализировать";
            buttonVisualize.UseVisualStyleBackColor = true;
            buttonVisualize.Click += buttonVisualize_Click;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(424, 18);
            splitContainer.Margin = new Padding(4, 5, 4, 5);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(textBoxGeneratedCode);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(plotView);
            splitContainer.Size = new Size(605, 568);
            splitContainer.SplitterDistance = 284;
            splitContainer.SplitterWidth = 6;
            splitContainer.TabIndex = 3;
            // 
            // textBoxGeneratedCode
            // 
            textBoxGeneratedCode.Dock = DockStyle.Fill;
            textBoxGeneratedCode.Location = new Point(0, 0);
            textBoxGeneratedCode.Margin = new Padding(4, 5, 4, 5);
            textBoxGeneratedCode.Multiline = true;
            textBoxGeneratedCode.Name = "textBoxGeneratedCode";
            textBoxGeneratedCode.ReadOnly = true;
            textBoxGeneratedCode.ScrollBars = ScrollBars.Vertical;
            textBoxGeneratedCode.Size = new Size(605, 284);
            textBoxGeneratedCode.TabIndex = 0;
            // 
            // plotView
            // 
            plotView.Dock = DockStyle.Fill;
            plotView.Location = new Point(0, 0);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(605, 278);
            plotView.TabIndex = 1;
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // GenerationMembershipUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Controls.Add(groupBoxActions);
            Controls.Add(groupBoxConditions);
            Controls.Add(groupBoxSettings);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1061, 605);
            Name = "GenerationMembershipUI";
            Size = new Size(1061, 605);
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            groupBoxConditions.ResumeLayout(false);
            groupBoxActions.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxBaseSet;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelBaseSet;
        private System.Windows.Forms.GroupBox groupBoxConditions;
        private System.Windows.Forms.Panel panelConditions;
        private System.Windows.Forms.Button buttonAddCondition;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonGenerateCode;
        private System.Windows.Forms.Button buttonVisualize;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox textBoxGeneratedCode;
        private OxyPlot.WindowsForms.PlotView plotView;
    }
}

