using System;
using System.Configuration;

namespace EnvisionIEReceiver
{
	public class ConfigService
	{
		public static string LocalIP { get { return ConfigurationManager.AppSettings["ConfigService.LocalIP"]; } }
		public static int LocalPort { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.LocalPort"]); } }
		public static int DefaultOrgId { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultOrgId"]); } }
		public static int DefaultLastModifiedBy { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultLastModifiedBy"]); } }
	}
}