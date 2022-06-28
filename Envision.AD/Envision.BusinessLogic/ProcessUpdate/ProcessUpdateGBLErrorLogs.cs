using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLErrorLogs : IBusinessLogic
    {
        public GBL_ERRORLOGS GBL_ERRORLOGS { get; set; }

        public ProcessUpdateGBLErrorLogs()
        {
            GBL_ERRORLOGS = new GBL_ERRORLOGS();
        }
        public void Invoke()
        {
            GBLErrorLogsUpdateData proc = new GBLErrorLogsUpdateData();
            proc.GBL_ERRORLOGS = this.GBL_ERRORLOGS;
            proc.Update();
        }

    }
}
