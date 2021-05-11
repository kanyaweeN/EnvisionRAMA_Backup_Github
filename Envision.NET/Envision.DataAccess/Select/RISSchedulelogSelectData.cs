using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISSchedulelogSelectData : DataAccessBase 
	{
        public RIS_SCHEDULE_LOG RIS_SCHEDULE_LOG { get; set; }
		public  RISSchedulelogSelectData()
		{
            RIS_SCHEDULE_LOG = new RIS_SCHEDULE_LOG();
			StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULELOG_Select2;
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
                Parameter("@FROMDATE",RIS_SCHEDULE_LOG.FROMDATE)
                ,Parameter("@TODATE",RIS_SCHEDULE_LOG.TODATE)
			};
            return parameters;
        }
	}
}

