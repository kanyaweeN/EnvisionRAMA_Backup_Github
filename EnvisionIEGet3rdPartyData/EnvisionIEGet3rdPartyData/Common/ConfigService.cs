using System;
using System.Configuration;
using System.Text;

namespace EnvisionIEGet3rdPartyData.Common
{
    public class ConfigService
    {
        public static string RisIP { get { return ConfigurationManager.AppSettings["ConfigService.RisIP"]; } }
        public static int RisPort { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.RisPort"]); } }

        public static string ThirdPartyConnectionName { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyConnectionName"]; } }
        public static string ThirdPartyConnectionString { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyConnectionString"]; } }
        public static string ThirdPartyDomainWebService { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyDomainWebService"]; } }
        public static string ThirdPartyUncPath { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyUncPath"]; } }
        public static string ThirdPartyUserDomainName { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyUserDomainName"]; } }
        public static string ThirdPartyUserName { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyUserName"]; } }
        public static string ThirdPartyPassword { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyPassword"]; } }
        public static string ThirdPartyDirectorySent { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyDirectorySent"]; } }
        public static string ThirdPartyDirectorySentBackup { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyDirectorySentBackup"]; } }
        public static string ThirdPartyFileExtension { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyFileExtension"]; } }
        public static Encoding ThirdPartyEncoding { get { return Encoding.GetEncoding(Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.ThirdPartyEncoding"])); } }
        public static int DefaultOrgId { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultOrgId"]); } }
        public static int DefaultLastModifiedBy { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultLastModifiedBy"]); } }
    }
}