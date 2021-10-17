using configs;
using dtos;
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

            Permissions acl = new Permissions();
            acl.SetACLMode(FeaturesUnlocked.PREMIUM);
            swar converter = new swar();
            converter.permissions(acl);

            Application.Run(converter);
        }
    }
}
