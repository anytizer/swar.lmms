using configs;
using dtos;
using libraries;
using System;
using System.Windows.Forms;

namespace swar
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SwarConverter converter = new SwarConverter();
            Application.Run(converter);
        }
    }
}
