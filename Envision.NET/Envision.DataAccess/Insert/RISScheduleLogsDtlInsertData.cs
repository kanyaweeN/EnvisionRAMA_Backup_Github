using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class RISScheduleLogsDtlInsertData: DataAccessBase
    {
        public RIS_SCHEDULELOGSDTL RIS_SCHEDULELOGSDTL { get; set; }
        public RISScheduleLogsDtlInsertData()
        {
            RIS_SCHEDULELOGSDTL = new RIS_SCHEDULELOGSDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULELOGSDTL_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Add(DbTransaction tran)
        {
            Transaction = tran;
            Add();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
Parameter("@SCHEDULELOG_ID",RIS_SCHEDULELOGSDTL.SCHEDULELOG_ID),
Parameter("@SCHEDULE_ID",RIS_SCHEDULELOGSDTL.SCHEDULE_ID),
Parameter("@EXAM_ID",RIS_SCHEDULELOGSDTL.EXAM_ID),
Parameter("@QTY",RIS_SCHEDULELOGSDTL.QTY),
Parameter("@RATE",RIS_SCHEDULELOGSDTL.RATE),
Parameter("@GEN_DTL_ID",RIS_SCHEDULELOGSDTL.GEN_DTL_ID),
Parameter("@RAD_ID",RIS_SCHEDULELOGSDTL.RAD_ID),
Parameter("@PREPARATION_ID",RIS_SCHEDULELOGSDTL.PREPARATION_ID),
Parameter("@BPVIEW_ID",RIS_SCHEDULELOGSDTL.BPVIEW_ID),
Parameter("@AVG_REQ_MIN",RIS_SCHEDULELOGSDTL.AVG_REQ_MIN),
Parameter("@PAT_DEST_ID",RIS_SCHEDULELOGSDTL.PAT_DEST_ID),
Parameter("@IS_PORTABLE",RIS_SCHEDULELOGSDTL.IS_PORTABLE),
			            };
            return parameters;
        }
    }
}


