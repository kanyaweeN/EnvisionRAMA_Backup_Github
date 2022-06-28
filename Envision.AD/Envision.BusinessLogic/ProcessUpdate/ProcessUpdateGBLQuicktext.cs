using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLQuicktext :IBusinessLogic
    {
        public GBL_QUICKTEXT GBL_QUICKTEXT { get; set; }
        public ProcessUpdateGBLQuicktext()
        {
            GBL_QUICKTEXT = new GBL_QUICKTEXT();
        }
        public void Invoke()
        {
            GBLQuicktextUpdateData _proc = new GBLQuicktextUpdateData();
            _proc.GBL_QUICKTEXT = this.GBL_QUICKTEXT;
            _proc.Update();
        }
    }
}
