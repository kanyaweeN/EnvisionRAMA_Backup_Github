using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISScheduleLogsInsertData : DataAccessBase
    {
        public RIS_SCHEDULELOGS RIS_SCHEDULELOGS { get; set; }
        public RISScheduleLogsInsertData()
        {
            RIS_SCHEDULELOGS = new RIS_SCHEDULELOGS();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULELOGS_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSet();
        }
        public void AddCNMI()
        {
            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSetCNMI();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
Parameter("@SCHEDULE_ID",RIS_SCHEDULELOGS.SCHEDULE_ID),
Parameter("@LOGS_MODIFIED_BY",RIS_SCHEDULELOGS.LOGS_MODIFIED_BY),
Parameter("@LOGS_DESC",RIS_SCHEDULELOGS.LOGS_DESC),
Parameter("@LOGS_STATUS",RIS_SCHEDULELOGS.LOGS_STATUS),
			            };
            return parameters;
        }
    }
}

