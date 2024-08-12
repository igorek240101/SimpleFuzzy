using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace SimpleFuzzy.View
{
    public partial class HelpWindow : MetroForm
    {
        MainWindow window;
        public HelpWindow(MainWindow mainWindow)
        {
            window = mainWindow;
            InitializeComponent();
        }
    }
}