using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;
using EnvisionOnline;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetGBLErrorLogs : IBusinessLogic
    {
        public GBL_ERRORLOGS GBL_ERRORLOGS { get; set; }
        private DataSet _resultset;

        public ProcessGetGBLErrorLogs()
        {
            GBL_ERRORLOGS = new GBL_ERRORLOGS();
        }

        public void Invoke()
        {
            
        }

        public DataSet get_ErrorLogsWorklistAll()
        {
            GBLErrorLogsSelectData envdata = new GBLErrorLogsSelectData();
            DataSet ds = new DataSet();
            ds = envdata.GetData();
            return ds;
        }

        public DataSet get_ErrorLogsWorklistByUserId()
        {
            GBLErrorLogsSelectData envdata = new GBLErrorLogsSelectData();
            DataSet ds = new DataSet();
            envdata.GBL_ERRORLOGS.USER_LOGIN = GBL_ERRORLOGS.USER_LOGIN;
            ds = envdata.GetDataByUserId();
            return ds;
        }

        public DataSet get_ErrorLogsWorklistByIP()
        {
            GBLErrorLogsSelectData envdata = new GBLErrorLogsSelectData();
            DataSet ds = new DataSet();
            envdata.GBL_ERRORLOGS.USER_HOST_ADDRESS = GBL_ERRORLOGS.USER_HOST_ADDRESS;
            ds = envdata.GetDataByIP();
            return ds;
        }

        public DataSet get_ErrorLogsWorklistByDate(DateTime date_start, DateTime date_end)
        {
            GBLErrorLogsSelectData envdata = new GBLErrorLogsSelectData();
            DataSet ds = new DataSet();
            ds = envdata.GetDataByDate(date_start, date_end);
            return ds;
        }
    }
}
