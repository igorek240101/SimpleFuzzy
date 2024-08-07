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
    public partial class ConfirmSimulatorChange : UserControl
    {
        public ConfirmSimulatorChange(LoaderForm loader)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Parent is LoaderForm parent) { parent.isApprove = true; }
            Parent.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
    }
}
