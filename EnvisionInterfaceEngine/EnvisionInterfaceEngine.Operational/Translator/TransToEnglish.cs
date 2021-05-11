using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.WebService;
using EnvisionInterfaceEngine.Common;

namespace EnvisionInterfaceEngine.Operational.Translator
{
	public class TransToEnglish
	{
		public static string Trans(string textThai)
		{
			try
			{
				return new EnvisionWebService(Config.DomainWebService).ThaiToEng(textThai);
			}
			catch
			{
				return string.Empty;
			}
		}
		public static string TransSalutation(string textThai)
		{
			try
			{
				return new EnvisionWebService(Config.DomainWebService).ThaiToEngSalutation(textThai);
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}
