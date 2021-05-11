using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EnvisionInterface.Common.Common
{
    public class Config
    {
        public static string ConnectionString { get { return ConfigurationManager.AppSettings["connStr"]; } }
        public static string ZeusIP { get { return ConfigurationManager.AppSettings["ZeusIP"]; } }
        public static string NMWebserviceURL { get { return ConfigurationManager.AppSettings["NMWebserviceURL"]; } }
        public static string HNTest { get { return ConfigurationManager.AppSettings["HNTest"]; } }
        public static bool IsActiveNM { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["IsActiveNM"]); } }
    }

}
