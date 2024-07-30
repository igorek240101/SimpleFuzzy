internal static class Progra
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        AutofacConfig.ConfigureContainer();
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }
}
