
namespace SimpleFuzzy.View 
{ 
    partial class LoaderForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            filePathTextBox = new MetroFramework.Controls.MetroTextBox();
            browseButton = new MetroFramework.Controls.MetroButton();
            loadButton = new MetroFramework.Controls.MetroButton();
            messageTextBox = new MetroFramework.Controls.MetroTextBox();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // filePathTextBox
            // 
            filePathTextBox.BackColor = Color.White;
            filePathTextBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            filePathTextBox.FontSize = MetroFramework.MetroTextBoxSize.Small;
            filePathTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            filePathTextBox.ForeColor = Color.Black;
            filePathTextBox.Location = new Point(23, 63);
            filePathTextBox.Multiline = false;
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.SelectedText = "";
            filePathTextBox.Size = new Size(399, 23);
            filePathTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            filePathTextBox.StyleManager = null;
            filePathTextBox.TabIndex = 0;
            filePathTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            filePathTextBox.UseStyleColors = false;
            // 
            // browseButton
            // 
            browseButton.Highlight = false;
            browseButton.Location = new Point(428, 63);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(100, 23);
            browseButton.Style = MetroFramework.MetroColorStyle.Blue;
            browseButton.StyleManager = null;
            browseButton.TabIndex = 1;
            browseButton.Text = "Обзор";
            browseButton.Theme = MetroFramework.MetroThemeStyle.Light;
            browseButton.Click += browseButton_Click;
            // 
            // loadButton
            // 
            loadButton.Highlight = false;
            loadButton.Location = new Point(23, 92);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(200, 23);
            loadButton.Style = MetroFramework.MetroColorStyle.Blue;
            loadButton.StyleManager = null;
            loadButton.TabIndex = 2;
            loadButton.Text = "Загрузить модуль";
            loadButton.Theme = MetroFramework.MetroThemeStyle.Light;
            loadButton.Click += loadButton_Click;
            // 
            // messageTextBox
            // 
            messageTextBox.FontSize = MetroFramework.MetroTextBoxSize.Small;
            messageTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            messageTextBox.Location = new Point(23, 121);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.SelectedText = "";
            messageTextBox.Size = new Size(505, 100);
            messageTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            messageTextBox.StyleManager = null;
            messageTextBox.TabIndex = 3;
            messageTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            messageTextBox.UseStyleColors = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(23, 227);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(159, 36);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // LoaderForm
            // 
            BackColor = Color.White;
            Controls.Add(checkBox1);
            Controls.Add(messageTextBox);
            Controls.Add(loadButton);
            Controls.Add(browseButton);
            Controls.Add(filePathTextBox);
            Name = "LoaderForm";
            Size = new Size(621, 307);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroTextBox filePathTextBox;
        private MetroFramework.Controls.MetroButton browseButton;
        private MetroFramework.Controls.MetroButton loadButton;
        private MetroFramework.Controls.MetroTextBox messageTextBox;
        private CheckBox checkBox1;
    }
}
