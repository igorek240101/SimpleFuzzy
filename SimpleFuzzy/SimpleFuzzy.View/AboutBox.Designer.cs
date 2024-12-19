namespace SimpleFuzzy.View
{
    public partial class AboutBox
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            tableLayoutPanel = new TableLayoutPanel();
            logoPictureBox = new PictureBox();
            labelProductName = new Label();
            labelVersion = new Label();
            labelCopyright = new Label();
            labelCompanyName = new Label();
            okButton = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(labelProductName, 1, 0);
            tableLayoutPanel.Controls.Add(labelVersion, 1, 1);
            tableLayoutPanel.Controls.Add(labelCopyright, 1, 2);
            tableLayoutPanel.Controls.Add(labelCompanyName, 1, 3);
            tableLayoutPanel.Controls.Add(okButton, 1, 5);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(11, 60);
            tableLayoutPanel.Margin = new Padding(5);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.Size = new Size(559, 362);
            tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(5, 5);
            logoPictureBox.Margin = new Padding(5);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 6);
            logoPictureBox.Size = new Size(174, 352);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 12;
            logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            labelProductName.Dock = DockStyle.Fill;
            labelProductName.Location = new Point(192, 0);
            labelProductName.Margin = new Padding(8, 0, 5, 0);
            labelProductName.MaximumSize = new Size(0, 27);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(362, 27);
            labelProductName.TabIndex = 19;
            labelProductName.Text = "Название продукта: ";
            labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            labelVersion.Dock = DockStyle.Fill;
            labelVersion.Location = new Point(192, 36);
            labelVersion.Margin = new Padding(8, 0, 5, 0);
            labelVersion.MaximumSize = new Size(0, 27);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(362, 27);
            labelVersion.TabIndex = 0;
            labelVersion.Text = "Версия: ";
            labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            labelCopyright.Dock = DockStyle.Fill;
            labelCopyright.Location = new Point(192, 72);
            labelCopyright.Margin = new Padding(8, 0, 5, 0);
            labelCopyright.MaximumSize = new Size(0, 27);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(362, 27);
            labelCopyright.TabIndex = 21;
            labelCopyright.Text = "Авторские права: ";
            labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            labelCompanyName.Dock = DockStyle.Fill;
            labelCompanyName.Location = new Point(192, 108);
            labelCompanyName.Margin = new Padding(8, 0, 5, 0);
            labelCompanyName.MaximumSize = new Size(0, 27);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(362, 27);
            labelCompanyName.TabIndex = 22;
            labelCompanyName.Text = "Название организации: ";
            labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Location = new Point(453, 330);
            okButton.Margin = new Padding(5);
            okButton.Name = "okButton";
            okButton.Size = new Size(101, 27);
            okButton.TabIndex = 24;
            okButton.Text = "&ОК";
            okButton.Click += okButton_Click;
            // 
            // AboutBox
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 435);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            Padding = new Padding(11, 60, 11, 13);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private Button okButton;
        public const bool isChangableSize = false;
    }
}
