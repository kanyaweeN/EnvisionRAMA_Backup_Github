using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class GBLSequencesSelectData : DataAccessBase 
	{
        public GBL_SEQUENCE GBL_SEQUENCE { get; set; }

		public  GBLSequencesSelectData()
		{
            GBL_SEQUENCE = new GBL_SEQUENCE();
            StoredProcedureName = StoredProcedure.GBL_Sequences_SelectRunNo;
		}

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                    Parameter("@Seq_Name",GBL_SEQUENCE.Seq_Name)
                                       };
            return parameters;
        }
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        public int GetRunningNo() 
        {
            //StoredProcedureName = StoredProcedure.GBL_Sequences_SelectRunNo;
            StoredProcedureName = StoredProcedure.GBL_Sequences_SelectRunNo_OnlineArrivalWorklist;
            int retID = 0;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                        retID = ds.Tables[0].Rows[0][0].ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return retID;
        }
        public int GetRunning()
        {
            StoredProcedureName = StoredProcedure.GBL_Sequences_HNRunning;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            int retID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return retID;
        }
	}
}

