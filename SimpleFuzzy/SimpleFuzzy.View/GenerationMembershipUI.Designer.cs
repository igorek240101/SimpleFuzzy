
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
            groupBoxSettings.Controls.Add(labelBaseSet);
            groupBoxSettings.Controls.Add(comboBoxBaseSet);
            groupBoxSettings.Location = new Point(14, 14);
            groupBoxSettings.Margin = new Padding(4);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Padding = new Padding(4);
            groupBoxSettings.Size = new Size(350, 67);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Настройки";
            // 
            // labelBaseSet
            // 
            labelBaseSet.AutoSize = true;
            labelBaseSet.Location = new Point(7, 20);
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
            comboBoxBaseSet.Location = new Point(145, 20);
            comboBoxBaseSet.Margin = new Padding(4);
            comboBoxBaseSet.Name = "comboBoxBaseSet";
            comboBoxBaseSet.Size = new Size(197, 23);
            comboBoxBaseSet.TabIndex = 3;
            // 
            // groupBoxConditions
            // 
            groupBoxConditions.Controls.Add(panelConditions);
            groupBoxConditions.Controls.Add(buttonAddCondition);
            groupBoxConditions.Location = new Point(14, 89);
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
            groupBoxActions.Location = new Point(14, 328);
            groupBoxActions.Margin = new Padding(4);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Padding = new Padding(4);
            groupBoxActions.Size = new Size(350, 64);
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
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(371, 14);
            splitContainer.Margin = new Padding(4);
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
            splitContainer.Size = new Size(529, 426);
            splitContainer.SplitterDistance = 213;
            splitContainer.TabIndex = 3;
            // 
            // textBoxGeneratedCode
            // 
            textBoxGeneratedCode.Dock = DockStyle.Fill;
            textBoxGeneratedCode.Location = new Point(0, 0);
            textBoxGeneratedCode.Margin = new Padding(4);
            textBoxGeneratedCode.Multiline = true;
            textBoxGeneratedCode.Name = "textBoxGeneratedCode";
            textBoxGeneratedCode.ReadOnly = true;
            textBoxGeneratedCode.ScrollBars = ScrollBars.Vertical;
            textBoxGeneratedCode.Size = new Size(529, 213);
            textBoxGeneratedCode.TabIndex = 0;
            // 
            // plotView
            // 
            plotView.Dock = DockStyle.Fill;
            plotView.Location = new Point(0, 0);
            plotView.Margin = new Padding(3, 2, 3, 2);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(529, 209);
            plotView.TabIndex = 1;
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // GenerationMembershipUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
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
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox textBoxGeneratedCode;
        private OxyPlot.WindowsForms.PlotView plotView;
        private ComboBox comboBoxBaseSet;
    }
}

