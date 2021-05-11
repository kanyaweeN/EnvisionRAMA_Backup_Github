using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common;
using EnvisionOnline;

namespace EnvisionOnline.DataAccess.Select
{
    public class GBLErrorLogsSelectData : DataAccessBase
    {
        public GBL_ERRORLOGS GBL_ERRORLOGS { get; set; }

        public GBLErrorLogsSelectData()
        {
            GBL_ERRORLOGS = new GBL_ERRORLOGS();
        }
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_ERRORLOGS_Select;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetDataByUserId()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_ERRORLOGS_SelectByUserId;
            ParameterList = buildParameter();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetDataByIP()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_ERRORLOGS_SelectByIP;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                          Parameter("@USER_HOST_ADDRESS",GBL_ERRORLOGS.USER_HOST_ADDRESS),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetDataByDate(DateTime date_start,DateTime date_end)
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_ERRORLOGS_SelectByDate;
            DataSet ds = new DataSet();
            ParameterList = buildParameterByDate(date_start, date_end);
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameterByDate(DateTime date_start, DateTime date_end)
        {
            DbParameter[] parameters = { 
                                          Parameter("@DATE_START",date_start),
                                          Parameter("@DATE_END",date_end)
                                       };
            return parameters;
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@USER_LOGIN",GBL_ERRORLOGS.USER_LOGIN),
                                       };
            return parameters;
        }
    }
}
