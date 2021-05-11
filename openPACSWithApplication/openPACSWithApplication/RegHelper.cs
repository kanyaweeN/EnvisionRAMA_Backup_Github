using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace openPACSWithApplication
{
    public class RegHelper
    {

        public RegHelper()
        {

        }

        /// <summary>
        /// Check run on startup status
        /// </summary>
        /// <returns></returns>
        public static bool IsRunOnStartup()
        {
            bool isStartup = false;
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);

            try
            {
                if (key.GetValue("EnvisionOpenPacsUrl") != null)
                    isStartup = true;
            }
            catch (NullReferenceException)
            {
            }

            key.Close();
            return isStartup;
        }

        /// <summary>
        /// Set or remove run on startup
        /// </summary>
        /// <param name="path"></param>
        /// <param name="remove"></param>
        public static void SetRunOnStartup(string path, bool remove)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (!remove)
                key.SetValue("EnvisionOpenPacsUrl", path);
            else
                key.DeleteValue("EnvisionOpenPacsUrl", false);

            key.Close();
        }
    }
}

