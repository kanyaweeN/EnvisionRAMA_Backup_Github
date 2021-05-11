using System;
using System.Configuration;
using System.IO.IsolatedStorage;
using System.IO;

namespace Envision.Common
{
    public class ConfigEngine
    {
        protected static int TryToInt(string value)
        {
            int result;

            if (!int.TryParse(value, out result))
                result = 1;

            return result;
        }
        protected static bool TryToBoolean(string value)
        {
            bool result;

            if (!bool.TryParse(value, out result))
                result = false;

            return result;
        }

        protected static string openLocalStorage(string key)
        {
            string result = openIsolatedStorageFile(key);

            if (string.IsNullOrEmpty(result))
                result = ConfigurationManager.AppSettings[key];

            return result;
        }
        protected static void saveLocalStorage(string key, object value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            createIsolatedStorageFile(string.Format("{0}.env", key), value.ToString());
        }

        private static void createIsolatedStorageFile(string path, string value)
        {
            try
            {
                using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (iso.GetDirectoryNames("Envision.NET").Length == 0)
                        iso.CreateDirectory("Envision.NET");

                    if (iso.GetFileNames(path).Length > 0)
                        iso.DeleteFile(path);

                    using (IsolatedStorageFileStream iso_stream = new IsolatedStorageFileStream(path, FileMode.Create, iso))
                    {
                        using (StreamWriter writer = new StreamWriter(iso_stream))
                        {
                            writer.Write(value);
                            writer.Flush();
                            writer.Close();
                        }

                        iso_stream.Flush();
                        iso_stream.Close();
                    }
                }
            }
            catch { }
        }
        private static void deleteIsolatedStorageFile(string path)
        {
            using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (iso.GetFileNames(path).Length > 0)
                    iso.DeleteFile(path);

                iso.Close();
            }
        }
        private static string openIsolatedStorageFile(string path)
        {
            string result = string.Empty;

            try
            {
                using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream iso_stream = new IsolatedStorageFileStream(path, FileMode.Open, iso))
                    {
                        using (StreamReader reader = new StreamReader(iso_stream))
                        {
                            result = reader.ReadToEnd();
                            reader.Close();
                        }

                        iso_stream.Flush();
                        iso_stream.Close();
                    }

                    iso.Close();
                }
            }
            catch { result = string.Empty; }

            return result;
        }
    }
    public class AppConfig : ConfigEngine
    {
        public static int LoginAuthMode
        {
            get { return Convert.ToInt32(openLocalStorage("LoginAuthMode")); }
            set { saveLocalStorage("LoginAuthMode", value); }
        }

        public static string ResultEntryPaperKind { get { return openLocalStorage("ResultEntryPaperKind"); } }
        public static bool UseAutoLoginSynapse { get { return TryToBoolean(openLocalStorage("UseAutoLoginSynapse")); } }
        public static bool MultiSite { get { return false; } }
        public static bool ResultWorklistCanViewAllExam { get { return true; } }

        public AppConfig() { }

    }
    public class ScanConfig : ConfigEngine
    {
        public string DeviceId
        {
            get { return openLocalStorage("Scan.DeviceId"); }
            set { saveLocalStorage("Scan.DeviceId", value); }
        }
        public string PageKind
        {
            get { return openLocalStorage("Scan.PageKind"); }
            set { saveLocalStorage("Scan.PageKind", value); }
        }
        public string ColorFormat
        {
            get { return openLocalStorage("Scan.ColorFormat"); }
            set { saveLocalStorage("Scan.ColorFormat", value); }
        }
        public int ResolutionDPI
        {
            get { return TryToInt(openLocalStorage("Scan.ResolutionDPI")); }
            set { saveLocalStorage("Scan.ResolutionDPI", value); }
        }
        public int Brightness
        {
            get { return TryToInt(openLocalStorage("Scan.Brightness")); }
            set { saveLocalStorage("Scan.Brightness", value); }
        }
        public int Contrast
        {
            get { return TryToInt(openLocalStorage("Scan.Contrast")); }
            set { saveLocalStorage("Scan.Contrast", value); }
        }
    }
}