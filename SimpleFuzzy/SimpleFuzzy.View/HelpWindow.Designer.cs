namespace SimpleFuzzy.View
{
    partial class HelpWindow
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
            TreeNode treeNode1 = new TreeNode("1. Создать");
            TreeNode treeNode2 = new TreeNode("2. Открыть");
            TreeNode treeNode3 = new TreeNode("3. Удалить");
            TreeNode treeNode4 = new TreeNode("4. Переименовать");
            TreeNode treeNode5 = new TreeNode("5. Копия");
            TreeNode treeNode6 = new TreeNode("6. Сохранить");
            TreeNode treeNode7 = new TreeNode("(1) Строка основных функций", new TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4, treeNode5, treeNode6 });
            TreeNode treeNode8 = new TreeNode("(2) Загрузчик");
            TreeNode treeNode9 = new TreeNode("(3) Фазификация");
            TreeNode treeNode10 = new TreeNode("(4) Редактор");
            TreeNode treeNode11 = new TreeNode("(5) Дефазификация");
            TreeNode treeNode12 = new TreeNode("(6) Симуляция");
            treeView1 = new TreeView();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeNode1.Name = "Create";
            treeNode1.Text = "1. Создать";
            treeNode1.ToolTipText = "Создает";
            treeNode2.Name = "Open";
            treeNode2.Text = "2. Открыть";
            treeNode2.ToolTipText = "Открывает";
            treeNode3.Name = "Delete";
            treeNode3.Text = "3. Удалить";
            treeNode3.ToolTipText = "Удаляет";
            treeNode4.Name = "Rename";
            treeNode4.Text = "4. Переименовать";
            treeNode4.ToolTipText = "Переименовывает";
            treeNode5.Name = "Copy";
            treeNode5.Text = "5. Копия";
            treeNode5.ToolTipText = "Копирует";
            treeNode6.Name = "Save";
            treeNode6.Text = "6. Сохранить";
            treeNode6.ToolTipText = "Сохраняет";
            treeNode7.Name = "StringOfBasicFunctions";
            treeNode7.Text = "(1) Строка основных функций";
            treeNode7.ToolTipText = "Основные функции";
            treeNode8.Name = "Loader";
            treeNode8.Text = "(2) Загрузчик";
            treeNode8.ToolTipText = "Згружает";
            treeNode9.Name = "Phasification";
            treeNode9.Text = "(3) Фазификация";
            treeNode9.ToolTipText = "Фазифицирует";
            treeNode10.Name = "Editor";
            treeNode10.Text = "(4) Редактор";
            treeNode10.ToolTipText = "Редактирует";
            treeNode11.Name = "Dephasification";
            treeNode11.Text = "(5) Дефазификация";
            treeNode11.ToolTipText = "Дефазифицирует";
            treeNode12.Name = "Simulation";
            treeNode12.Text = "(6) Симуляция";
            treeNode12.ToolTipText = "Симулирует";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode7, treeNode8, treeNode9, treeNode10, treeNode11, treeNode12 });
            treeView1.ShowNodeToolTips = true;
            treeView1.Size = new Size(216, 224);
            treeView1.TabIndex = 1;
            // 
            // HelpWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 251);
            Controls.Add(treeView1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpWindow";
            Text = "Справка";
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
    }
}