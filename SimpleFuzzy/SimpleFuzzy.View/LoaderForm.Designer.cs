
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
            filePathTextBox = new TextBox();
            browseButton = new Button();
            loadButton = new Button();
            messageTextBox = new TextBox();
            treeView1 = new NoClickTree();
            dllListView = new ListView();
            FileName = new ColumnHeader();
            CloseButton = new ColumnHeader();
            groupBoxLoader = new GroupBox();
            groupBoxModules = new GroupBox();
            groupBoxDLL = new GroupBox();
            groupBoxLoader.SuspendLayout();
            groupBoxModules.SuspendLayout();
            groupBoxDLL.SuspendLayout();
            SuspendLayout();
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(8, 51);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(358, 27);
            filePathTextBox.TabIndex = 0;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(372, 51);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(99, 27);
            browseButton.TabIndex = 1;
            browseButton.Text = "Обзор";
            browseButton.Click += browseButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(8, 18);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(463, 30);
            loadButton.TabIndex = 2;
            loadButton.Text = "Загрузить модуль";
            loadButton.Click += loadButton_Click;
            // 
            // messageTextBox
            // 
            messageTextBox.Enabled = false;
            messageTextBox.Location = new Point(8, 84);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(463, 163);
            messageTextBox.TabIndex = 3;
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new Point(10, 20);
            treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "Термы";
            treeNode2.Name = "";
            treeNode2.Text = "Базовые множества";
            treeNode3.Name = "";
            treeNode3.Text = "Симуляции";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeView1.ShowNodeToolTips = true;
            treeView1.Size = new Size(398, 227);
            treeView1.TabIndex = 0;
            treeView1.AfterCheck += treeView1_AfterCheck;
            // 
            // dllListView
            // 
            dllListView.FullRowSelect = true;
            dllListView.Location = new Point(10, 23);
            dllListView.Name = "dllListView";
            dllListView.ShowItemToolTips = true;
            dllListView.Size = new Size(881, 186);
            dllListView.TabIndex = 6;
            dllListView.UseCompatibleStateImageBehavior = false;
            dllListView.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            FileName.Text = "Имя";
            // 
            // CloseButton
            // 
            CloseButton.Text = "";
            // 
            // groupBoxLoader
            // 
            groupBoxLoader.Controls.Add(filePathTextBox);
            groupBoxLoader.Controls.Add(browseButton);
            groupBoxLoader.Controls.Add(loadButton);
            groupBoxLoader.Controls.Add(messageTextBox);
            groupBoxLoader.Location = new Point(430, 3);
            groupBoxLoader.Name = "groupBoxLoader";
            groupBoxLoader.Size = new Size(483, 256);
            groupBoxLoader.TabIndex = 0;
            groupBoxLoader.TabStop = false;
            groupBoxLoader.Text = "Загрузка модуля";
            // 
            // groupBoxModules
            // 
            groupBoxModules.Controls.Add(treeView1);
            groupBoxModules.Location = new Point(10, 3);
            groupBoxModules.Name = "groupBoxModules";
            groupBoxModules.Size = new Size(414, 256);
            groupBoxModules.TabIndex = 1;
            groupBoxModules.TabStop = false;
            groupBoxModules.Text = "Загруженные модули";
            // 
            // groupBoxDLL
            // 
            groupBoxDLL.Controls.Add(dllListView);
            groupBoxDLL.Location = new Point(10, 265);
            groupBoxDLL.Name = "groupBoxDLL";
            groupBoxDLL.Size = new Size(903, 215);
            groupBoxDLL.TabIndex = 7;
            groupBoxDLL.TabStop = false;
            groupBoxDLL.Text = "Загруженные DLL файлы";
            // 
            // LoaderForm
            // 
            BackColor = Color.White;
            Controls.Add(groupBoxLoader);
            Controls.Add(groupBoxModules);
            Controls.Add(groupBoxDLL);
            Name = "LoaderForm";
            Size = new Size(916, 490);
            groupBoxLoader.ResumeLayout(false);
            groupBoxLoader.PerformLayout();
            groupBoxModules.ResumeLayout(false);
            groupBoxDLL.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private TextBox filePathTextBox;
        private Button browseButton;
        private Button loadButton;
        private TextBox messageTextBox;
        private NoClickTree treeView1;
        public ListView dllListView;
        private ColumnHeader FileName;
        private ColumnHeader CloseButton;
        private GroupBox groupBoxLoader;
        private GroupBox groupBoxModules;
        private GroupBox groupBoxDLL;
    }
}

