using System.Diagnostics;
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("Приложение уже открыто!");
                return;
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}