
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
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Location = new Point(0, 0);
            Create.Margin = new Padding(5);
            Create.Name = "Create";
            Create.Size = new Size(122, 37);
            Create.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(153, 46);
            button1.TabIndex = 1;
            button1.Text = "Создать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(162, 0);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(153, 46);
            button2.TabIndex = 2;
            button2.Text = "Открыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(325, 0);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(153, 46);
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(488, 0);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(153, 46);
            button4.TabIndex = 4;
            button4.Text = "Переименовать";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(650, 0);
            button5.Margin = new Padding(5);
            button5.Name = "button5";
            button5.Size = new Size(153, 46);
            button5.TabIndex = 5;
            button5.Text = "Копия";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(812, 0);
            button6.Margin = new Padding(5);
            button6.Name = "button6";
            button6.Size = new Size(153, 46);
            button6.TabIndex = 6;
            button6.Text = "Сохранить";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(0, 54);
            button7.Name = "button7";
            button7.Size = new Size(226, 46);
            button7.TabIndex = 8;
            button7.Text = "Загрузчик";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(232, 54);
            button8.Name = "button8";
            button8.Size = new Size(226, 46);
            button8.TabIndex = 9;
            button8.Text = "Фазификация";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(464, 54);
            button9.Name = "button9";
            button9.Size = new Size(226, 46);
            button9.TabIndex = 10;
            button9.Text = "Инференция";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(696, 54);
            button10.Name = "button10";
            button10.Size = new Size(226, 46);
            button10.TabIndex = 11;
            button10.Text = "Дефазификация";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(928, 54);
            button11.Name = "button11";
            button11.RightToLeft = RightToLeft.No;
            button11.Size = new Size(226, 46);
            button11.TabIndex = 12;
            button11.Text = "Симуляция";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 720);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Create);
            Margin = new Padding(5);
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
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
    }
}