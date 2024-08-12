
using System.Windows.Forms;

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
            TreeNode treeNode1 = new TreeNode("Термы");
            TreeNode treeNode2 = new TreeNode("Базовые множества");
            TreeNode treeNode3 = new TreeNode("Симуляции");
            filePathTextBox = new MetroFramework.Controls.MetroTextBox();
            browseButton = new MetroFramework.Controls.MetroButton();
            loadButton = new MetroFramework.Controls.MetroButton();
            messageTextBox = new MetroFramework.Controls.MetroTextBox();
            treeView1 = new TreeView();
            dllListView = new ListView();
            FileName = new ColumnHeader();
            groupBoxLoader = new GroupBox();
            groupBoxModules = new GroupBox();
            groupBoxLoader.SuspendLayout();
            groupBoxModules.SuspendLayout();
            SuspendLayout();
            // 
            // filePathTextBox
            // 
            filePathTextBox.FontSize = MetroFramework.MetroTextBoxSize.Small;
            filePathTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            filePathTextBox.Location = new Point(8, 49);
            filePathTextBox.Multiline = false;
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.SelectedText = "";
            filePathTextBox.Size = new Size(358, 23);
            filePathTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            filePathTextBox.StyleManager = null;
            filePathTextBox.TabIndex = 0;
            filePathTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            filePathTextBox.UseStyleColors = false;
            // 
            // browseButton
            // 
            browseButton.Highlight = false;
            browseButton.Location = new Point(372, 49);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(99, 23);
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
            loadButton.Location = new Point(8, 20);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(463, 23);
            loadButton.Style = MetroFramework.MetroColorStyle.Blue;
            loadButton.StyleManager = null;
            loadButton.TabIndex = 2;
            loadButton.Text = "Загрузить модуль";
            loadButton.Theme = MetroFramework.MetroThemeStyle.Light;
            loadButton.Click += loadButton_Click;
            // 
            // messageTextBox
            // 
            messageTextBox.Enabled = false;
            messageTextBox.FontSize = MetroFramework.MetroTextBoxSize.Small;
            messageTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            messageTextBox.Location = new Point(8, 78);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.SelectedText = "";
            messageTextBox.Size = new Size(463, 216);
            messageTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            messageTextBox.StyleManager = null;
            messageTextBox.TabIndex = 3;
            messageTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            messageTextBox.UseStyleColors = false;
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new Point(10, 20);
            treeView1.Name = "treeView1";
            treeNode1.Checked = false;
            treeNode1.Name = "";
            treeNode1.Text = "Термы";
            treeNode2.Checked = false;
            treeNode2.Name = "";
            treeNode2.Text = "Базовые множества";
            treeNode3.Name = "";
            treeNode3.Text = "Симуляции";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeView1.ShowNodeToolTips = true;
            treeView1.Size = new Size(398, 280);
            treeView1.TabIndex = 0;
            treeView1.AfterCheck += treeView1_AfterCheck;
            // 
            //  dllListView
            // 
            dllListView.Columns.AddRange(new ColumnHeader[] { FileName });
            dllListView.Location = new Point(647, 148);
            dllListView.Name = "listView1";
            dllListView.Size = new Size(222, 332);
            dllListView.TabIndex = 6;
            dllListView.UseCompatibleStateImageBehavior = false;
            dllListView.View = System.Windows.Forms.View.Details;
            dllListView.FullRowSelect = true;
            dllListView.Scrollable = true;
            ListViewExtender extender = new ListViewExtender(dllListView);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            extender.AddColumn(buttonAction);
            //
            // groupBoxLoader
            // 
            groupBoxLoader.Controls.Add(filePathTextBox);
            groupBoxLoader.Controls.Add(browseButton);
            groupBoxLoader.Controls.Add(loadButton);
            groupBoxLoader.Controls.Add(messageTextBox);
            groupBoxLoader.Location = new Point(430, 3);
            groupBoxLoader.Name = "groupBoxLoader";
            groupBoxLoader.Size = new Size(483, 306);
            groupBoxLoader.TabIndex = 0;
            groupBoxLoader.TabStop = false;
            groupBoxLoader.Text = "Загрузка модуля";
            // 
            // groupBoxModules
            // 
            groupBoxModules.Controls.Add(treeView1);
            groupBoxModules.Location = new Point(10, 3);
            groupBoxModules.Name = "groupBoxModules";
            groupBoxModules.Size = new Size(414, 306);
            groupBoxModules.TabIndex = 1;
            groupBoxModules.TabStop = false;
            groupBoxModules.Text = "Загруженные модули";
            // 
            // LoaderForm
            // 
            Controls.Add(dllListView);
            BackColor = Color.White;
            Controls.Add(groupBoxLoader);
            Controls.Add(groupBoxModules);
            Name = "LoaderForm";
            Size = new Size(916, 470);
            groupBoxLoader.ResumeLayout(false);
            groupBoxModules.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private MetroFramework.Controls.MetroTextBox filePathTextBox;
        private MetroFramework.Controls.MetroButton browseButton;
        private MetroFramework.Controls.MetroButton loadButton;
        private MetroFramework.Controls.MetroTextBox messageTextBox;
        private TreeView treeView1;
        public ListView dllListView;
        private ColumnHeader FileName;
        private GroupBox groupBoxLoader;
        private GroupBox groupBoxModules;
    }
}

