using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISScheduleReasonSelectData : DataAccessBase 
    {
        public RIS_SCHEDULE_LOG RIS_SCHEDULE_LOG { get; set; }
        public RISScheduleReasonSelectData()
		{
            RIS_SCHEDULE_LOG = new RIS_SCHEDULE_LOG();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_LOG_SelectNew;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
            Parameter("@MODE",RIS_SCHEDULE_LOG.MODE)    
            ,Parameter("@FROMDATE",RIS_SCHEDULE_LOG.FROMDATE)
                ,Parameter("@TODATE",RIS_SCHEDULE_LOG.TODATE)
                ,Parameter("@STATUS",RIS_SCHEDULE_LOG.STATUS)
                ,Parameter("@HN",RIS_SCHEDULE_LOG.HN)
			};
            return parameters;
        }
	}
}
