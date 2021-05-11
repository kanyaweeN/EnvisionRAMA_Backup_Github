using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLQuicktext : IBusinessLogic
    {
        public GBL_QUICKTEXT GBL_QUICKTEXT { get; set; }
        public ProcessDeleteGBLQuicktext()
        {
            GBL_QUICKTEXT = new GBL_QUICKTEXT();
        }
        public void Invoke()
        {
            GBLQuicktextDeleteData _proc = new GBLQuicktextDeleteData();
            _proc.GBL_QUICKTEXT = this.GBL_QUICKTEXT;
            _proc.Delete();
        }
    }
}
