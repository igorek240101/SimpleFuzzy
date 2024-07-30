using System;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutofacConfig.ConfigureContainer();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }
    }
}
