
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
            components = new System.ComponentModel.Container();
            folderBrowserDialog1 = new FolderBrowserDialog();
            Create = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            toolTip1 = new ToolTip(components);
            button13 = new Button();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Location = new Point(0, 0);
            Create.Margin = new Padding(3, 2, 3, 2);
            Create.Name = "Create";
            Create.Size = new Size(66, 17);
            Create.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 1;
            button1.Text = "Создать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(88, 0);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 2;
            button2.Text = "Открыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(175, 0);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(262, 0);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 22);
            button4.TabIndex = 4;
            button4.Text = "Переименовать";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(350, 0);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(82, 22);
            button5.TabIndex = 5;
            button5.Text = "Копия";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(438, 0);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(82, 22);
            button6.TabIndex = 6;
            button6.Text = "Сохранить";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(0, 26);
            button7.Margin = new Padding(2);
            button7.Name = "button7";
            button7.Size = new Size(122, 22);
            button7.TabIndex = 8;
            button7.Text = "Загрузчик";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(125, 26);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(122, 22);
            button8.TabIndex = 9;
            button8.Text = "Фазификация";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(250, 26);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(122, 22);
            button9.TabIndex = 10;
            button9.Text = "Инференция";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(374, 26);
            button10.Margin = new Padding(2);
            button10.Name = "button10";
            button10.Size = new Size(122, 22);
            button10.TabIndex = 11;
            button10.Text = "Дефазификация";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(500, 26);
            button11.Margin = new Padding(2);
            button11.Name = "button11";
            button11.RightToLeft = RightToLeft.No;
            button11.Size = new Size(122, 22);
            button11.TabIndex = 12;
            button11.Text = "Симуляция";
            toolTip1.SetToolTip(button11, "Симуляция не загружена в проект или отключена в окне загрузчика");
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.AutoEllipsis = true;
            button12.Location = new Point(525, 0);
            button12.Margin = new Padding(3, 2, 3, 2);
            button12.Name = "button12";
            button12.Size = new Size(82, 22);
            button12.TabIndex = 8;
            button12.Text = "О программе";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(612, 0);
            button13.Margin = new Padding(3, 2, 3, 2);
            button13.Name = "button13";
            button13.Size = new Size(82, 22);
            button13.TabIndex = 9;
            button13.Text = "Справка";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button13);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Create);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainWindow";
            Text = "SimpleFuzzy";
            MouseMove += MainWindow_MouseMove;
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
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private ToolTip toolTip1;
        private Button button13;
    }
}