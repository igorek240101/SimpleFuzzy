
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
            this.filePathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.browseButton = new MetroFramework.Controls.MetroButton();
            this.loadButton = new MetroFramework.Controls.MetroButton();
            this.messageTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(23, 63);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(399, 23);
            this.filePathTextBox.TabIndex = 0;
            this.filePathTextBox.BackColor = System.Drawing.Color.White;
            this.filePathTextBox.ForeColor = System.Drawing.Color.Black;
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(428, 63);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(100, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Обзор";
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            this.browseButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#0B61A4");
            this.browseButton.ForeColor = System.Drawing.Color.White;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(23, 92);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(200, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Загрузить модуль";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            this.loadButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#00AF64");
            this.loadButton.ForeColor = System.Drawing.Color.White;
            this.loadButton.Font = new System.Drawing.Font("Microsoft Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(23, 121);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(505, 100);
            this.messageTextBox.TabIndex = 3;
            this.messageTextBox.BackColor = System.Drawing.Color.White;
            this.messageTextBox.ForeColor = System.Drawing.Color.Black;
            this.messageTextBox.Font = new System.Drawing.Font("Microsoft Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(551, 244);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Form1";
            this.Text = "Загрузчик модулей";
            this.BackColor = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox filePathTextBox;
        private MetroFramework.Controls.MetroButton browseButton;
        private MetroFramework.Controls.MetroButton loadButton;
        private MetroFramework.Controls.MetroTextBox messageTextBox;
    }
}
