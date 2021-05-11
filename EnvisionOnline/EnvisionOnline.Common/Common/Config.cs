using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EnvisionOnline.Common.Common
{
    public class Config
    {
        public static string ConnectionString { get { return ConfigurationManager.AppSettings["connStr"]; } }
        public static string VNAConnectionString { get { return ConfigurationManager.AppSettings["connStrVNA"]; } }
        public static string CNMIConnectionString { get { return ConfigurationManager.AppSettings["connStrCNMI"]; } }
        public static string ZeusIP { get { return ConfigurationManager.AppSettings["ZeusIP"]; } }
    }
}
