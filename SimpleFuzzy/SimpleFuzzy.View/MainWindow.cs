using System;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class MainWindow : Form
    {
        private GenerationObjectSetUI generationObjectSetUI;

        public MainWindow()
        {
            InitializeComponent();

            generationObjectSetUI = new GenerationObjectSetUI();
            generationObjectSetUI.Dock = DockStyle.Fill;
            this.Controls.Add(generationObjectSetUI);

            this.ClientSize = generationObjectSetUI.PreferredSize;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}