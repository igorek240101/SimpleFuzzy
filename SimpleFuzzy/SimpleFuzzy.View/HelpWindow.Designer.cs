using System.Xml;

namespace SimpleFuzzy.View
{
    public partial class HelpWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Directory.GetCurrentDirectory() + "\\HelpWindowSource.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            treeView1 = new TreeView();
            var nodes = new TreeNode[xRoot.ChildNodes.Count];
            if (xRoot != null)
            {
                treeView1.Name = xRoot.Attributes.GetNamedItem("name").Value;
                int i = 0;
                foreach (XmlElement xnode in xRoot)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Name = xnode.Attributes.GetNamedItem("name").Value;
                    treeNode1.Text = xnode.Attributes.GetNamedItem("name").Value;
                    nodes[i] = treeNode1;
                    i++;
                }
            }
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 60);
            treeView1.Margin = new Padding(3, 4, 3, 4);
            treeView1.Nodes.AddRange(nodes);
            treeView1.ShowNodeToolTips = true;
            treeView1.Size = new Size(246, 228);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // HelpWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 288);
            Controls.Add(treeView1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(272, 335);
            Name = "HelpWindow";
            Padding = new Padding(0, 60, 0, 0);
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Справка";
            ResumeLayout(false);
        }

        #endregion

        public const bool isChangableSize = true;
        private TreeView treeView1;
    }
}