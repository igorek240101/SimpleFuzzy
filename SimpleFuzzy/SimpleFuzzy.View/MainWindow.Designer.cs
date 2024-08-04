
namespace SimpleFuzzy.View
{
    partial class MainWindow
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
            folderBrowserDialog1 = new FolderBrowserDialog();
            Create = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button13 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Location = new Point(0, 0);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Создать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(100, 0);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Открыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(200, 0);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.Enabled = false;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(300, 0);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "Переименовать";
            button4.Enabled = false;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(400, 0);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 5;
            button5.Text = "Копия";
            button5.Enabled = false;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(500, 0);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 6;
            button6.Text = "Сохранить";
            button6.Enabled = false;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button13
            // 
            button13.Location = new Point(600, 0);
            button13.Name = "button7";
            button13.Size = new Size(94, 29);
            button13.TabIndex = 8;
            button13.Text = "Справка";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            //
            // button7
            // 
            button7.Location = new Point(600, 0);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 8;
            button7.Text = "О программе";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            button7.AutoEllipsis = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button13);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button7);
            Controls.Add(Create);
            HelpButton = true;
            Name = "MainWindow";
            Text = "SimpleFuzzy";
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button Create;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button13;
        private Button button7;
    }
}