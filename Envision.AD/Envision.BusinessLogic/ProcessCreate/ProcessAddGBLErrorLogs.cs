using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLErrorLogs : IBusinessLogic
    {
        public GBL_ERRORLOGS GBL_ERRORLOGS { get; set; }
        public ProcessAddGBLErrorLogs()
        {
            GBL_ERRORLOGS = new GBL_ERRORLOGS();
        }
        public void Invoke()
        {
            GBLErrorLogsInsertData proc = new GBLErrorLogsInsertData();
            proc.GBL_ERRORLOGS = this.GBL_ERRORLOGS;
            proc.Add();
            GBL_ERRORLOGS.ERROR_ID = proc.GBL_ERRORLOGS.ERROR_ID;
        }

        public void InsertAAASchedulelog()
        {
            GBLErrorLogsInsertData proc = new GBLErrorLogsInsertData();
            proc.GBL_ERRORLOGS = this.GBL_ERRORLOGS;
            proc.AAASchedulelog();
        }
    }
}
