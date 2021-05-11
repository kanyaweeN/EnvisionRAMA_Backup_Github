using System;
using System.Configuration;

namespace EnvisionIEGet3rdPartyData.Common.HomC
{
    public class ConfigServiceHomC
    {
        public static string UserName { get { return ConfigurationManager.AppSettings["ConfigServiceHomC.UserName"]; } }
        public static int HNLength { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigServiceHomC.HNLength"]); } }
    }
}