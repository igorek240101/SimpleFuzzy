using System;
using System.Windows.Forms;
using SimpleFuzzy.View;

namespace SimpleFuzzy
{
    public class MainForm : Form
    {
        private LoaderForm loaderForm;

        public MainForm()
        {
            InitializeComponent();
            InitializeLoaderForm();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            ClientSize = new Size(510, 194);
            Name = "MainForm";
            Text = "SimpleFuzzy";
            ResumeLayout(false);
        }

        private void InitializeLoaderForm()
        {
            loaderForm = new LoaderForm();
            loaderForm.Dock = DockStyle.Fill;
            this.Controls.Add(loaderForm);
        }
    }
}