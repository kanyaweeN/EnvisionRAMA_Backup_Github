using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.Common.Common;
using RIS.BusinessLogic;
using Miracle.Util;

namespace RIS.Operational
{
    public class GBLExceptionLog
    {
        public GBLExceptionLog()
        {
        }
        public void LogException(string exception, int formid, string type)
        {
            GBLEnvVariable env = new GBLEnvVariable();
            Utilities utl = new Utilities();
            GBLException exlog = new GBLException();
            exlog.EXC_TYPE = type;
            exlog.EXC_TEXT = exception;
            exlog.EXC_IP = utl.IPAddress();
            exlog.EXC_PC_NAME = utl.MachineName();
            exlog.CURRENT_FORM_ID = formid;
            exlog.CURRENT_LANG_ID = env.CurrentLanguageID;
            exlog.CONNECTED_EMP_ID = env.UserID;
            exlog.ORG_ID = env.OrgID;
            exlog.CREATED_BY = env.UserID;
            
            ProcessAddGBLExceptionLog alog = new ProcessAddGBLExceptionLog();
            alog.GBLException = exlog;
            alog.Invoke();

        }



    }
}
