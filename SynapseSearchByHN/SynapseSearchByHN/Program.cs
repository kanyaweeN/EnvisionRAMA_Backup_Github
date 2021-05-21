using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace SynapseSearchByHN
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

            XMLClass xml = new XMLClass();
            try
            {
                string DirectoryName = Path.GetDirectoryName(xml.XmlPath);
                if (!Directory.Exists(DirectoryName))
                    Directory.CreateDirectory(DirectoryName);

                if (!File.Exists(xml.XmlPath))
                {
                    frmAppConfig frmSet = new frmAppConfig();
                    frmSet.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            xml.LoadData();
            switch (xml.LoginMode)
            {
                case "Not Login":
                    Application.Run(new frmMain());
                    break;
                case "Windows Authen":
                case "Domain Authen":
                case "HIS Authen":
                    Application.Run(new frmLogin());
                    break;
            }
        }
    }
}
