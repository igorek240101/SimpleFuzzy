
using System.Resources;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SimpleFuzzy.View
{
    partial class MainWindow
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new MenuStrip();
            button1 = new ToolStripMenuItem();
            button2 = new ToolStripMenuItem();
            button3 = new ToolStripMenuItem();
            button4 = new ToolStripMenuItem();
            button5 = new ToolStripMenuItem();
            button6 = new ToolStripMenuItem();
            button12 = new ToolStripMenuItem();
            button13 = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            button7 = new ToolStripMenuItem();
            button8 = new ToolStripMenuItem();
            button9 = new ToolStripMenuItem();
            button10 = new ToolStripMenuItem();
            button11 = new ToolStripMenuItem();
            logoBox = new PictureBox();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            timer1 = new System.Windows.Forms.Timer(components);
            Left = new Button();
            Right = new Button();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { button1, button2, button3, button4, button5, button6, button12, button13 });
            menuStrip1.Location = new Point(0, 60);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(914, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            button1.Name = "button1";
            button1.Size = new Size(78, 24);
            button1.Text = "Создать";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Name = "button2";
            button2.Size = new Size(81, 24);
            button2.Text = "Открыть";
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Name = "button3";
            button3.Size = new Size(79, 24);
            button3.Text = "Удалить";
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Name = "button4";
            button4.Size = new Size(135, 24);
            button4.Text = "Переименовать";
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Name = "button5";
            button5.Size = new Size(123, 24);
            button5.Text = "Сохранить как";
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Name = "button6";
            button6.Size = new Size(97, 24);
            button6.Text = "Сохранить";
            button6.Click += button6_Click;
            // 
            // button12
            // 
            button12.Name = "button12";
            button12.Size = new Size(118, 24);
            button12.Text = "О программе";
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Name = "button13";
            button13.Size = new Size(81, 24);
            button13.Text = "Справка";
            button13.Click += button13_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { button7, button8, button9, button10, button11 });
            menuStrip2.Location = new Point(0, 88);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(914, 28);
            menuStrip2.TabIndex = 1;
            menuStrip2.Text = "menuStrip2";
            // 
            // button7
            // 
            button7.Name = "button7";
            button7.Size = new Size(92, 24);
            button7.Text = "Загрузчик";
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Name = "button8";
            button8.Size = new Size(118, 24);
            button8.Text = "Фазификация";
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Name = "button9";
            button9.Size = new Size(113, 24);
            button9.Text = "Инференция";
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Name = "button10";
            button10.Size = new Size(135, 24);
            button10.Text = "Дефазификация";
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Name = "button11";
            button11.Size = new Size(101, 24);
            button11.Text = "Симуляция";
            button11.ToolTipText = "Симуляция не загружена в проект или отключена в окне загрузчика";
            button11.Click += button11_Click;
            // 
            // logoBox
            // 
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(3, 6);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(432, 51);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Left
            // 
            Left.Location = new Point(3, 119);
            Left.Name = "Left";
            Left.Size = new Size(94, 29);
            Left.TabIndex = 2;
            Left.Text = "Влево";
            Left.UseVisualStyleBackColor = true;
            Left.Click += Left_Click;
            // 
            // Right
            // 
            Right.Location = new Point(538, 119);
            Right.Name = "Right";
            Right.Size = new Size(94, 29);
            Right.TabIndex = 3;
            Right.Text = "Вправо";
            Right.UseVisualStyleBackColor = true;
            Right.Click += Right_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(490, 19);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 14;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(label1);
            Controls.Add(Right);
            Controls.Add(Left);
            Controls.Add(menuStrip2);
            Controls.Add(menuStrip1);
            Controls.Add(logoBox);
            Location = new Point(0, 0);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Padding = new Padding(0, 60, 0, 0);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem button1;
        private ToolStripMenuItem button2;
        private ToolStripMenuItem button3;
        private ToolStripMenuItem button4;
        private ToolStripMenuItem button5;
        private ToolStripMenuItem button6;
        private ToolStripMenuItem button7;
        private ToolStripMenuItem button8;
        private ToolStripMenuItem button9;
        private ToolStripMenuItem button10;
        private ToolStripMenuItem button11;
        private ToolStripMenuItem button12;
        private ToolStripMenuItem button13;
        private PictureBox logoBox;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private System.Windows.Forms.Timer timer1;
        private Button Left;
        private Button Right;
        private Label label1;
    }
}