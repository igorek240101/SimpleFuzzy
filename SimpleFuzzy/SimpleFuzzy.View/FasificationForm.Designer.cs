using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SimpleFuzzy.View
{
    partial class FasificationForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("Термы");
            TreeNode treeNode2 = new TreeNode("Базовые множества");
            FileName = new ColumnHeader();
            CloseButton = new ColumnHeader();
            treeView1 = new TreeView();
            listView1 = new ListView();
            button1 = new Button();
            SuspendLayout();
            // 
            // FileName
            // 
            FileName.Text = "Лингвистические переменные";
            FileName.Width = 226;
            // 
            // CloseButton
            // 
            CloseButton.Text = "";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 2);
            treeView1.Margin = new Padding(3, 2, 3, 2);
            treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "Термы";
            treeNode2.Name = "";
            treeNode2.Text = "Базовые множества";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2 });
            treeView1.Size = new Size(318, 144);
            treeView1.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { FileName, CloseButton });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(3, 176);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(318, 252);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.MouseLeave += listView1_MouseLeave;
            listView1.MouseMove += listView1_MouseMove;
            // 
            // button1
            // 
            button1.Location = new Point(1, 150);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(320, 22);
            button1.TabIndex = 2;
            button1.Text = "Добавить лингвистическую переменную";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FasificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(treeView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FasificationForm";
            Size = new Size(833, 430);
            ResumeLayout(false);
        }

        #endregion
        private ColumnHeader CloseButton;
        private ColumnHeader FileName;
        private TreeView treeView1;
        private ListView listView1;
        private Button button1;
    }
}
