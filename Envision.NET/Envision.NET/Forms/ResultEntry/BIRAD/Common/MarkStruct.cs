using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Common
{
    /// <summary>
    /// MarkStruct
    /// </summary>
    public class MarkStruct
    {
        public object MarkObject { get; set; }
        public MG_BREASTMASSDETAILS MassDetail { get; set; }
        public MG_BREASTUSMASSDETAILS MassUSDetail { get; set; }
        private string isUSMassDtl = "N";
        public string IsUsMassDetail
        {
            get { return isUSMassDtl; }
            set { isUSMassDtl = value; }
        }
    }
}
