namespace SimpleFuzzy.View
{
    partial class LoaderForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox filePathTextBox;
        private Button browseButton;
        private Button loadButton;
        private TextBox messageTextBox;

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
            filePathTextBox = new TextBox();
            browseButton = new Button();
            loadButton = new Button();
            messageTextBox = new TextBox();
            SuspendLayout();
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(12, 12);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(399, 27);
            filePathTextBox.TabIndex = 1;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(417, 9);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 30);
            browseButton.TabIndex = 2;
            browseButton.Text = "Обзор";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(12, 45);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(200, 30);
            loadButton.TabIndex = 3;
            loadButton.Text = "Загрузить модуль";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // messageTextBox
            // 
            messageTextBox.Location = new Point(12, 80);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.ReadOnly = true;
            messageTextBox.ScrollBars = ScrollBars.Vertical;
            messageTextBox.Size = new Size(480, 100);
            messageTextBox.TabIndex = 4;
            // 
            // LoaderForm
            // 
            Controls.Add(filePathTextBox);
            Controls.Add(browseButton);
            Controls.Add(loadButton);
            Controls.Add(messageTextBox);
            Name = "LoaderForm";
            Size = new Size(504, 187);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
