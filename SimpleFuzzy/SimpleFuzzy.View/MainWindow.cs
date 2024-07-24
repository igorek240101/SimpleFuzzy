using SimpleFuzzy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class MainWindow : Form
    {
        private LinguisticVariableUI linguisticVariableUI;
        public MainWindow()
        {
            InitializeComponent();

            linguisticVariableUI = new LinguisticVariableUI();
            linguisticVariableUI.Dock = DockStyle.Fill;
            this.Controls.Add(linguisticVariableUI);

            this.ClientSize = linguisticVariableUI.PreferredSize;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}
