using System;
using System.Windows.Forms;

namespace ProductivityKeyPress.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SneakyListener.Listen();
            Application.Run(new MainForm());
            SneakyListener.Stop();
        }
    }
}
