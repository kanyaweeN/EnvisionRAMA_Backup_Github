using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using RIS.Forms.Admin;


namespace RIS
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
            Application.Run(new Form1());
        }
    }
}