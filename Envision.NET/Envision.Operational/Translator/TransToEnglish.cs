using Envision.Common;
using Envision.WebService;

namespace Envision.Operational.Translator
{
    public static class TransToEnglish
    {
        public static string Trans(string textThai)
        {
            try
            {
                return new EnvisionWebService(new GBLEnvVariable().WebServiceIP).ThaiToEng(textThai);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
