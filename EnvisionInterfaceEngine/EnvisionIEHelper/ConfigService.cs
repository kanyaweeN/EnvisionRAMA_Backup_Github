using System;
using System.Configuration;
using System.Text;

namespace EnvisionIEHelper
{
	public class ConfigService
	{
		public static string UrlWebService { get { return ConfigurationManager.AppSettings["ConfigService.UrlWebService"]; } }
		public static string HowAction { get { return ConfigurationManager.AppSettings["ConfigService.HowAction"]; } }

		public static int FileSystemWatcherTimeout { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.FileSystemWatcherTimeout"]) * 1000; } }

		public static string ThirdPartyUncPath { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyUncPath"]; } }
		public static string ThirdPartyUserDomainName { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyUserDomainName"]; } }
		public static string ThirdPartyUserName { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyUserName"]; } }
		public static string ThirdPartyPassword { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyPassword"]; } }
		public static string ThirdPartyDirectoryReceive { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyDirectoryReceive"]; } }
		public static string[] ThirdPartySubdirectoriesReceive { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartySubdirectoriesReceive"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries); } }
		public static bool ThirdPartyIncludeSubdirectories { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.ThirdPartyIncludeSubdirectories"]); } }
		public static string ThirdPartyDirectoryReceiveBackup { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyDirectoryReceiveBackup"]; } }
		public static string[] ThirdPartyFileExtensions { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyFileExtensions"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries); } }
		public static string[] ThirdPartyExemptFiles { get { return ConfigurationManager.AppSettings["ConfigService.ThirdPartyExemptFiles"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries); } }
		public static Encoding ThirdPartyEncoding { get { return Encoding.GetEncoding(Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.ThirdPartyEncoding"])); } }
	}
}