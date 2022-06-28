using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class GBLErrorLogsInsertData: DataAccessBase 
    {
        public GBL_ERRORLOGS GBL_ERRORLOGS { get; set; }

        public GBLErrorLogsInsertData()
        {
            GBL_ERRORLOGS = new GBL_ERRORLOGS();
            StoredProcedureName = StoredProcedure.Prc_GBL_Errorlogs_InsertNew;
        }
        public bool Add()
        {
            ParameterList = buildParameter();
            DataTable dtt = ExecuteDataTable();
            if (dtt != null)
                if (dtt.Rows.Count > 0)
                    GBL_ERRORLOGS.ERROR_ID = Convert.ToInt32(dtt.Rows[0][0].ToString());

            return true;
        }
        public void AAASchedulelog()
        {
            StoredProcedureName = StoredProcedure.AAA_SCHEDULELOG_insert;
            ParameterList = buildParameterAAASchedulelog();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@USER_LOGIN",GBL_ERRORLOGS.USER_LOGIN),
                Parameter("@USER_HOST_ADDRESS",GBL_ERRORLOGS.USER_HOST_ADDRESS),
                Parameter("@ERROR_MESSAGE",GBL_ERRORLOGS.ERROR_MESSAGE),
                Parameter("@ERROR_SOURCE",GBL_ERRORLOGS.ERROR_SOURCE),
                Parameter("@PIC_PATH",GBL_ERRORLOGS.PIC_PATH),
                Parameter("@ERROR_FORM",GBL_ERRORLOGS.ERROR_FORM),
                Parameter("@CREATED_BY",GBL_ERRORLOGS.CREATED_BY)
            };
            return parameters;
        }
        private DbParameter[] buildParameterAAASchedulelog()
        {
            DbParameter[] parameters ={
                Parameter("@IS_SCHEDULE",GBL_ERRORLOGS.AAA_IS_SCHEDULE),
                Parameter("@SCHEDULE_ID",GBL_ERRORLOGS.AAA_SCHEDULE_ID),
                Parameter("@ORDER_ID",GBL_ERRORLOGS.AAA_ORDER_ID),
                Parameter("@SCHEDULELOG_DESC",GBL_ERRORLOGS.AAA_SCHEDULELOG_DESC),
                Parameter("@LAST_MODIFIED_BY",GBL_ERRORLOGS.AAA_LAST_MODIFIED_BY),
            };
            return parameters;
        }
    }
}
