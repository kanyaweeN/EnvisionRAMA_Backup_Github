using System;
using System.Configuration;

namespace EnvisionClearLog
{
	public class ConfigService
	{
		public static string LogPath
		{
			get { return ConfigurationManager.AppSettings["ConfigService.LogPath"]; }
		}

		public static double TimeInterval
		{
			get { return (DateTime.Today.AddDays(1).AddTicks(TimeSpan.Parse(ConfigurationManager.AppSettings["ConfigService.ClearTime"]).Ticks) - DateTime.Now).TotalMilliseconds; }
		}
		public static int ClearOverDays
		{
			get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.ClearOverDays"]); }
		}
		public static string[] ClearDirectories
		{
			get { return ConfigurationManager.AppSettings["ConfigService.ClearDirectories"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries); }
		}
		public static string[] ClearFileExtensions
		{
			get { return ConfigurationManager.AppSettings["ConfigService.ClearFileExtensions"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries); }
		}
	}
}
