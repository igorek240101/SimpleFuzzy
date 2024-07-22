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
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            generationObjectSetUI = new GenerationObjectSetUI();
            generationObjectSetUI.Dock = DockStyle.Fill;
            this.Controls.Add(generationObjectSetUI);
        }
    }
}