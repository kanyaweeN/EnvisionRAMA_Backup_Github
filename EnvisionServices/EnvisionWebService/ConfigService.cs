using System;
using System.Configuration;

public class ConfigService
{
	public static string LogPath
	{
		get { return ConfigurationManager.AppSettings["ConfigService.LogPath"]; }
	}
	public static string ThaiRomanPath
	{
		get { return ConfigurationManager.AppSettings["ConfigService.ThaiRomanPath"]; }
	}
	public static string ClientLogPath
	{
		get { return ConfigurationManager.AppSettings["ConfigService.ClientLogPath"]; }
	}
	public static int ClientPort
	{
		get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.ClientPort"]); }
	}
}