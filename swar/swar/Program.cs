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

            License license = new License();
            int mode = license.mode(); // FeaturesUnlocked.PREMIUM

            Permissions acl = new Permissions();
            acl.SetACLMode(mode);

            swar converter = new swar();
            converter.permissions(acl);

            Application.Run(converter);
        }
    }
}
