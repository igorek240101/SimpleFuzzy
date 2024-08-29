using System.DirectoryServices.ActiveDirectory;

namespace SimpleFuzzy.View
{
    partial class InferenceForm
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            outputVariableComboBox = new ComboBox();
            outputVariableLabel = new Label();
            windowHeaderLabel = new Label();
            AddInbutton = new Button();
            inputVariablesComboBox = new ComboBox();
            label1 = new Label();
            dataTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataTable).BeginInit();
            SuspendLayout();
            // 
            // outputVariableComboBox
            // 
            outputVariableComboBox.Location = new Point(181, 49);
            outputVariableComboBox.Name = "outputVariableComboBox";
            outputVariableComboBox.Size = new Size(194, 28);
            outputVariableComboBox.TabIndex = 0;
            outputVariableComboBox.SelectedIndexChanged += OutputVariableComboBox_SelectedIndexChanged;
            // 
            // outputVariableLabel
            // 
            outputVariableLabel.AutoSize = true;
            outputVariableLabel.Location = new Point(3, 52);
            outputVariableLabel.Name = "outputVariableLabel";
            outputVariableLabel.Size = new Size(175, 20);
            outputVariableLabel.TabIndex = 1;
            outputVariableLabel.Text = "Выходные переменные";
            // 
            // windowHeaderLabel
            // 
            windowHeaderLabel.AutoSize = true;
            windowHeaderLabel.Location = new Point(384, 10);
            windowHeaderLabel.Name = "windowHeaderLabel";
            windowHeaderLabel.Size = new Size(144, 20);
            windowHeaderLabel.TabIndex = 2;
            windowHeaderLabel.Text = "РЕДАКТОР ПРАВИЛ";
            // 
            // AddInbutton
            // 
            AddInbutton.Location = new Point(381, 95);
            AddInbutton.Name = "AddInbutton";
            AddInbutton.Size = new Size(152, 29);
            AddInbutton.TabIndex = 3;
            AddInbutton.Text = "Добавить ЛП";
            AddInbutton.UseVisualStyleBackColor = true;
            AddInbutton.Click += AddInbutton_Click;
            // 
            // inputVariablesComboBox
            // 
            inputVariablesComboBox.FormattingEnabled = true;
            inputVariablesComboBox.Location = new Point(181, 95);
            inputVariablesComboBox.Name = "inputVariablesComboBox";
            inputVariablesComboBox.Size = new Size(194, 28);
            inputVariablesComboBox.TabIndex = 4;
            inputVariablesComboBox.SelectedIndexChanged += inputVariablesComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 95);
            label1.Name = "label1";
            label1.Size = new Size(164, 20);
            label1.TabIndex = 5;
            label1.Text = "Входные переменные";
            // 
            // dataTable
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataTable.DefaultCellStyle = dataGridViewCellStyle2;
            dataTable.Location = new Point(3, 129);
            dataTable.Name = "dataTable";
            dataTable.RowHeadersVisible = false;
            dataTable.RowHeadersWidth = 51;
            dataTable.RowTemplate.Height = 29;
            dataTable.Size = new Size(753, 345);
            dataTable.TabIndex = 7;
            dataTable.CellValueChanged += dataTable_CellValueChanged;
            dataTable.RowsAdded += dataTable_RowsAdded;
            // 
            // InferenceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataTable);
            Controls.Add(label1);
            Controls.Add(inputVariablesComboBox);
            Controls.Add(AddInbutton);
            Controls.Add(windowHeaderLabel);
            Controls.Add(outputVariableLabel);
            Controls.Add(outputVariableComboBox);
            Name = "InferenceForm";
            Size = new Size(941, 490);
            ((System.ComponentModel.ISupportInitialize)dataTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox outputVariableComboBox;
        private Label outputVariableLabel;
        private Label windowHeaderLabel;
        private Button AddInbutton;
        private ComboBox inputVariablesComboBox;
        private Label label1;
        private DataGridView dataTable;
    }
}
