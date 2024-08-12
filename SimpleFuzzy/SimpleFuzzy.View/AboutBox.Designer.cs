using MetroFramework;
using MetroFramework.Components;

namespace SimpleFuzzy.View
{
    partial class AboutBox
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
            labelProductName = new MetroFramework.Controls.MetroLabel();
            labelVersion = new MetroFramework.Controls.MetroLabel();
            labelCopyright = new MetroFramework.Controls.MetroLabel();
            labelCompanyName = new MetroFramework.Controls.MetroLabel();
            okButton = new MetroFramework.Controls.MetroButton();
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
            tableLayoutPanel.Location = new Point(12, 60);
            tableLayoutPanel.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.Size = new Size(556, 361);
            tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(4, 5);
            logoPictureBox.Margin = new Padding(4, 5, 4, 5);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 6);
            logoPictureBox.Size = new Size(175, 351);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 12;
            logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            labelProductName.CustomBackground = false;
            labelProductName.Dock = DockStyle.Fill;
            labelProductName.FontSize = MetroLabelSize.Medium;
            labelProductName.FontWeight = MetroLabelWeight.Bold;
            labelProductName.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            labelProductName.Location = new Point(191, 0);
            labelProductName.Margin = new Padding(8, 0, 4, 0);
            labelProductName.MaximumSize = new Size(0, 26);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(361, 26);
            labelProductName.Style = MetroColorStyle.Blue;
            labelProductName.StyleManager = null;
            labelProductName.TabIndex = 19;
            labelProductName.Text = "Название продукта";
            labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            labelProductName.Theme = MetroThemeStyle.Light;
            labelProductName.UseStyleColors = false;
            // 
            // labelVersion
            // 
            labelVersion.CustomBackground = false;
            labelVersion.Dock = DockStyle.Fill;
            labelVersion.FontSize = MetroLabelSize.Medium;
            labelVersion.FontWeight = MetroLabelWeight.Regular;
            labelVersion.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            labelVersion.Location = new Point(191, 36);
            labelVersion.Margin = new Padding(8, 0, 4, 0);
            labelVersion.MaximumSize = new Size(0, 26);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(361, 26);
            labelVersion.Style = MetroColorStyle.Blue;
            labelVersion.StyleManager = null;
            labelVersion.TabIndex = 0;
            labelVersion.Text = "Версия";
            labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            labelVersion.Theme = MetroThemeStyle.Light;
            labelVersion.UseStyleColors = false;
            // 
            // labelCopyright
            // 
            labelCopyright.CustomBackground = false;
            labelCopyright.Dock = DockStyle.Fill;
            labelCopyright.FontSize = MetroLabelSize.Medium;
            labelCopyright.FontWeight = MetroLabelWeight.Regular;
            labelCopyright.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            labelCopyright.Location = new Point(191, 72);
            labelCopyright.Margin = new Padding(8, 0, 4, 0);
            labelCopyright.MaximumSize = new Size(0, 26);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(361, 26);
            labelCopyright.Style = MetroColorStyle.Blue;
            labelCopyright.StyleManager = null;
            labelCopyright.TabIndex = 21;
            labelCopyright.Text = "Авторские права";
            labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            labelCopyright.Theme = MetroThemeStyle.Light;
            labelCopyright.UseStyleColors = false;
            // 
            // labelCompanyName
            // 
            labelCompanyName.CustomBackground = false;
            labelCompanyName.Dock = DockStyle.Fill;
            labelCompanyName.FontSize = MetroLabelSize.Medium;
            labelCompanyName.FontWeight = MetroLabelWeight.Regular;
            labelCompanyName.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            labelCompanyName.Location = new Point(191, 108);
            labelCompanyName.Margin = new Padding(8, 0, 4, 0);
            labelCompanyName.MaximumSize = new Size(0, 26);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(361, 26);
            labelCompanyName.Style = MetroColorStyle.Blue;
            labelCompanyName.StyleManager = null;
            labelCompanyName.TabIndex = 22;
            labelCompanyName.Text = "Название организации";
            labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            labelCompanyName.Theme = MetroThemeStyle.Light;
            labelCompanyName.UseStyleColors = false;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Highlight = true;
            okButton.Location = new Point(452, 329);
            okButton.Margin = new Padding(4, 5, 4, 5);
            okButton.Name = "okButton";
            okButton.Size = new Size(100, 27);
            okButton.Style = MetroColorStyle.Green;
            okButton.StyleManager = null;
            okButton.TabIndex = 24;
            okButton.Text = "&ОК";
            okButton.Theme = MetroThemeStyle.Light;
            // 
            // AboutBox
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 435);
            Controls.Add(tableLayoutPanel);
            Location = new Point(0, 0);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            Padding = new Padding(12, 60, 12, 14);
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
        private MetroFramework.Controls.MetroLabel labelProductName;
        private MetroFramework.Controls.MetroLabel labelVersion;
        private MetroFramework.Controls.MetroLabel labelCopyright;
        private MetroFramework.Controls.MetroLabel labelCompanyName;
        private MetroFramework.Controls.MetroTextBox textBoxDescription;
        private MetroFramework.Controls.MetroButton okButton;
    }
}
