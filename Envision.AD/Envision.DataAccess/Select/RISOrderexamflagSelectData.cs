using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISOrderexamflagSelectData : DataAccessBase 
	{
        public RIS_ORDEREXAMFLAG RIS_ORDEREXAMFLAG { get; set; }

        public RISOrderexamflagSelectData()
		{
            RIS_ORDEREXAMFLAG = new RIS_ORDEREXAMFLAG();
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDEREXAMFLAG_Select;
            ParameterList = new DbParameter[] { 
                Parameter("@ORDER_ID",RIS_ORDEREXAMFLAG.ORDER_ID),
            };
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetDataSchedule()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDEREXAMFLAG_SelectSchedule;
            ParameterList = new DbParameter[] { 
                Parameter("@SCHEDULE_ID",RIS_ORDEREXAMFLAG.SCHEDULE_ID),
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataXrayreq()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDEREXAMFLAG_SelectXrayreq;
            ParameterList = new DbParameter[] { 
                Parameter("@XRAYREQ_ID",RIS_ORDEREXAMFLAG.XRAYREQ_ID),
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDetail()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDEREXAMFLAG_SelectDetail;
            ds = ExecuteDataSet();
            return ds;
        }
	}
}


