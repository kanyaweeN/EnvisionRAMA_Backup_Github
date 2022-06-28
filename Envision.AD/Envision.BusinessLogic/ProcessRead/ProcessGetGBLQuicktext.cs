using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetGBLQuicktext : IBusinessLogic
    {
        public GBL_QUICKTEXT GBL_QUICKTEXT { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetGBLQuicktext()
        {
            GBL_QUICKTEXT = new GBL_QUICKTEXT();
        }
        public void Invoke()
        {
            Result = new DataSet();
            GBLQuicktextSelectData _proc = new GBLQuicktextSelectData();
            _proc.GBL_QUICKTEXT = this.GBL_QUICKTEXT;
            Result = _proc.GetData();
        }
        public DataSet GetQuickTextFilterMode()
        {
            GBLQuicktextSelectData _proc = new GBLQuicktextSelectData();
            return _proc.GetQuickTextFilterMode();
        }
    }
}
