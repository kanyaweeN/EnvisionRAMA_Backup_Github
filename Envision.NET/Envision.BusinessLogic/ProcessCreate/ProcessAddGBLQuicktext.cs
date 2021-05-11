using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLQuicktext : IBusinessLogic
    {
        public GBL_QUICKTEXT GBL_QUICKTEXT { get; set; }
        public ProcessAddGBLQuicktext()
        {
            GBL_QUICKTEXT = new GBL_QUICKTEXT();
        }
        public void Invoke()
        {
            GBLQuicktextInsertData _proc = new GBLQuicktextInsertData();
            _proc.GBL_QUICKTEXT = this.GBL_QUICKTEXT;
            _proc.Add();
        }
    }
}
