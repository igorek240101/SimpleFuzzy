using System;
using System.Windows.Forms;
using SimpleFuzzy.View;

namespace SimpleFuzzy
{
    public class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(800, 450);
            Name = "MainWindow";
            Text = "SimpleFuzzy";
            ResumeLayout(false);
        }

    }
}