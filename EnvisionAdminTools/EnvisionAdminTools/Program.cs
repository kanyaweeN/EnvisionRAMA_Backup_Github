using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EnvisionAdminTools
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
            DevExpress.UserSkins.OfficeSkins.Register();
            Application.Run(new frmMain());
        }
    }
}