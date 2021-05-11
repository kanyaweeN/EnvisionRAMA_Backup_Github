using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Helper
{
    public class RTFConverter
    {
        public static string Convert(string plan_text)
        {
            return plan_text.Replace("\t", @"\tab").Replace("\r\n", @"\par");
        }
    }
}
