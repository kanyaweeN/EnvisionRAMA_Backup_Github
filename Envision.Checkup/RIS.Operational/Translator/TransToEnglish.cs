using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common.Common;
using RIS.WebService;

namespace RIS.Operational.Translator
{
    public static  class TransToEnglish
    {
        public static string Trans(string thaiText) {
            try
            {
                return new EnvisionWebService(new GBLEnvVariable().WebServiceIP).ThaiToEng(thaiText);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
