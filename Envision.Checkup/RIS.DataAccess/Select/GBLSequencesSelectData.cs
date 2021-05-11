using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class GBLSequencesSelectData : DataAccessBase 
	{
		private GBLSequences	_gblsequences;
		private GBLSequencesInsertDataParameters	_gblsequencesinsertdataparameters;
		public  GBLSequencesSelectData()//(bool running)
		{
            //if(running)
                //StoredProcedureName = StoredProcedure.Name.GBL_Sequences_SelectRunNo.ToString();
		}
		public  GBLSequences	GBLSequences
		{
			get{return _gblsequences;}
			set{_gblsequences=value;}
		}
		public DataSet GetData()
		{
			_gblsequencesinsertdataparameters = new GBLSequencesInsertDataParameters(GBLSequences);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_gblsequencesinsertdataparameters.Parameters);
			return ds;
		}
        public int GetRunningNo() {
            StoredProcedureName = StoredProcedure.Name.GBL_Sequences_SelectRunNo.ToString();
            _gblsequencesinsertdataparameters = new GBLSequencesInsertDataParameters(GBLSequences);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, _gblsequencesinsertdataparameters.Parameters);
            int retID = 0;
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                        retID = ds.Tables[0].Rows[0][0].ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return retID;
        }
        public int GetRunning()
        {
            StoredProcedureName = StoredProcedure.Name.GBL_Sequences_HNRunning.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
            int retID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return retID;
        }
 
	}
	public class GBLSequencesInsertDataParameters 
	{
		private GBLSequences _gblsequences;
		private SqlParameter[] _parameters;
		public GBLSequencesInsertDataParameters(GBLSequences gblsequences)
		{
			GBLSequences=gblsequences;
			Build();
		}
		public  GBLSequences	GBLSequences
		{
			get{return _gblsequences;}
			set{_gblsequences=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter pRun = new SqlParameter();
            pRun.Value = 0;
            pRun.ParameterName = "@RUN";
            pRun.Direction = ParameterDirection.Output;
           
			SqlParameter[] parameters ={
                //new SqlParameter("@RUN",GBLSequences.Curr_val)
                //pRun
                new SqlParameter("@Seq_Name",GBLSequences.Seq_Name)
            };
			Parameters = parameters;
		}
	}
}

