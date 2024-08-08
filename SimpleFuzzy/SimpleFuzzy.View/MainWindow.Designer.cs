
using MetroFramework.Controls;
using System.Resources;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new MetroButton();
            button2 = new MetroButton();
            button3 = new MetroButton();
            button4 = new MetroButton();
            button5 = new MetroButton();
            button6 = new MetroButton();
            button7 = new MetroButton();
            button8 = new MetroButton();
            button9 = new MetroButton();
            button10 = new MetroButton();
            button11 = new MetroButton();
            button12 = new MetroButton();
            logoBox = new PictureBox();
            toolTip1 = new ToolTip(components);
            button13 = new MetroButton();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Highlight = false;
            button1.Location = new Point(6, 72);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(107, 39);
            button1.Style = MetroFramework.MetroColorStyle.Blue;
            button1.StyleManager = null;
            button1.TabIndex = 1;
            button1.Text = "Создать";
            button1.Theme = MetroFramework.MetroThemeStyle.Light;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(121, 72);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(107, 39);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 2;
            button2.Text = "Открыть";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Highlight = false;
            button3.Location = new Point(235, 72);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(107, 39);
            button3.Style = MetroFramework.MetroColorStyle.Blue;
            button3.StyleManager = null;
            button3.TabIndex = 3;
            button3.Text = "Удалить";
            button3.Theme = MetroFramework.MetroThemeStyle.Light;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Highlight = false;
            button4.Location = new Point(349, 72);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(107, 39);
            button4.Style = MetroFramework.MetroColorStyle.Blue;
            button4.StyleManager = null;
            button4.TabIndex = 4;
            button4.Text = "Переименовать";
            button4.Theme = MetroFramework.MetroThemeStyle.Light;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Highlight = false;
            button5.Location = new Point(463, 72);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(107, 39);
            button5.Style = MetroFramework.MetroColorStyle.Blue;
            button5.StyleManager = null;
            button5.TabIndex = 5;
            button5.Text = "Копия";
            button5.Theme = MetroFramework.MetroThemeStyle.Light;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Highlight = false;
            button6.Location = new Point(578, 72);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(107, 39);
            button6.Style = MetroFramework.MetroColorStyle.Blue;
            button6.StyleManager = null;
            button6.TabIndex = 6;
            button6.Text = "Сохранить";
            button6.Theme = MetroFramework.MetroThemeStyle.Light;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Highlight = false;
            button7.Location = new Point(6, 117);
            button7.Margin = new Padding(2, 3, 2, 3);
            button7.Name = "button7";
            button7.Size = new Size(159, 39);
            button7.Style = MetroFramework.MetroColorStyle.Blue;
            button7.StyleManager = null;
            button7.TabIndex = 8;
            button7.Text = "Загрузчик";
            button7.Theme = MetroFramework.MetroThemeStyle.Light;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Highlight = false;
            button8.Location = new Point(170, 117);
            button8.Margin = new Padding(2, 3, 2, 3);
            button8.Name = "button8";
            button8.Size = new Size(159, 39);
            button8.Style = MetroFramework.MetroColorStyle.Blue;
            button8.StyleManager = null;
            button8.TabIndex = 9;
            button8.Text = "Фазификация";
            button8.Theme = MetroFramework.MetroThemeStyle.Light;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Highlight = false;
            button9.Location = new Point(333, 117);
            button9.Margin = new Padding(2, 3, 2, 3);
            button9.Name = "button9";
            button9.Size = new Size(159, 39);
            button9.Style = MetroFramework.MetroColorStyle.Blue;
            button9.StyleManager = null;
            button9.TabIndex = 10;
            button9.Text = "Инференция";
            button9.Theme = MetroFramework.MetroThemeStyle.Light;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Highlight = false;
            button10.Location = new Point(495, 117);
            button10.Margin = new Padding(2, 3, 2, 3);
            button10.Name = "button10";
            button10.Size = new Size(159, 39);
            button10.Style = MetroFramework.MetroColorStyle.Blue;
            button10.StyleManager = null;
            button10.TabIndex = 11;
            button10.Text = "Дефазификация";
            button10.Theme = MetroFramework.MetroThemeStyle.Light;
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Highlight = false;
            button11.Location = new Point(659, 117);
            button11.Margin = new Padding(2, 3, 2, 3);
            button11.Name = "button11";
            button11.RightToLeft = RightToLeft.No;
            button11.Size = new Size(159, 39);
            button11.Style = MetroFramework.MetroColorStyle.Blue;
            button11.StyleManager = null;
            button11.TabIndex = 12;
            button11.Text = "Симуляция";
            button11.Theme = MetroFramework.MetroThemeStyle.Light;
            toolTip1.SetToolTip(button11, "Симуляция не загружена в проект или отключена в окне загрузчика");
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.AutoEllipsis = true;
            button12.Highlight = false;
            button12.Location = new Point(692, 72);
            button12.Margin = new Padding(3, 4, 3, 4);
            button12.Name = "button12";
            button12.Size = new Size(107, 39);
            button12.Style = MetroFramework.MetroColorStyle.Blue;
            button12.StyleManager = null;
            button12.TabIndex = 8;
            button12.Text = "О программе";
            button12.Theme = MetroFramework.MetroThemeStyle.Light;
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // logoBox
            // 
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(61, 9);
            logoBox.Margin = new Padding(3, 4, 3, 4);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(453, 59);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // button13
            // 
            button13.Highlight = false;
            button13.Location = new Point(806, 72);
            button13.Margin = new Padding(3, 4, 3, 4);
            button13.Name = "button13";
            button13.Size = new Size(97, 39);
            button13.Style = MetroFramework.MetroColorStyle.Blue;
            button13.StyleManager = null;
            button13.TabIndex = 9;
            button13.Text = "Справка";
            button13.Theme = MetroFramework.MetroThemeStyle.Light;
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
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
            Controls.Add(logoBox);
            Location = new Point(0, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainWindow";
            Padding = new Padding(23, 80, 23, 27);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button3;
        private MetroFramework.Controls.MetroButton button4;
        private MetroFramework.Controls.MetroButton button5;
        private MetroFramework.Controls.MetroButton button6;
        private MetroFramework.Controls.MetroButton button7;
        private MetroFramework.Controls.MetroButton button8;
        private MetroFramework.Controls.MetroButton button9;
        private MetroFramework.Controls.MetroButton button10;
        private MetroFramework.Controls.MetroButton button11;
        private MetroFramework.Controls.MetroButton button12;
        private PictureBox logoBox;
        private ToolTip toolTip1;
        private MetroFramework.Controls.MetroButton button13;
    }
}