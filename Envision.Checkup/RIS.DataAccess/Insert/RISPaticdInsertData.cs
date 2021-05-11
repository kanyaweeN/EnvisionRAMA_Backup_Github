using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISPaticdInsertData : DataAccessBase 
	{
		private RISPaticd	_rispaticd;
		private RISPaticdInsertDataParameters	_rispaticdinsertdataparameters;

		public  RISPaticdInsertData()
		{
            _rispaticd = new RISPaticd();
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATICD_Insert.ToString();
		}
		public  RISPaticd	RISPaticd
		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public void Add()
		{
			_rispaticdinsertdataparameters = new RISPaticdInsertDataParameters(RISPaticd);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rispaticdinsertdataparameters.Parameters);
		}
        public int Add(SqlTransaction tran)
        {
            _rispaticdinsertdataparameters = new RISPaticdInsertDataParameters(_rispaticd);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _rispaticdinsertdataparameters.Parameters);
            return (int)_rispaticdinsertdataparameters.Parameters[0].Value;
        }
	}
	public class RISPaticdInsertDataParameters 
	{
		private RISPaticd _rispaticd;
		private SqlParameter[] _parameters;

		public RISPaticdInsertDataParameters(RISPaticd rispaticd)
		{
			RISPaticd=rispaticd;
			Build();
		}
		public  RISPaticd	RISPaticd
		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter pPAT_ICD_ID = new SqlParameter();
            pPAT_ICD_ID.ParameterName = "@PAT_ICD_ID";
            pPAT_ICD_ID.Value = 0;
            pPAT_ICD_ID.Direction = ParameterDirection.Output;

            SqlParameter pACCESSION_NO = new SqlParameter();
            pACCESSION_NO.ParameterName = "@ACCESSION_NO";
            if (RISPaticd.ACCESSION_NO == string.Empty || RISPaticd.ACCESSION_NO == null)
                pACCESSION_NO.Value = DBNull.Value;
            else
                pACCESSION_NO.Value = RISPaticd.ACCESSION_NO;

			SqlParameter[] parameters ={
                //new SqlParameter("@PAT_ICD_ID",RISPaticd.PAT_ICD_ID)
                pPAT_ICD_ID
                ,new SqlParameter("@ICD_ID",RISPaticd.ICD_ID)
                ,new SqlParameter("@HN",RISPaticd.HN)
                ,new SqlParameter("@ORDER_NO",RISPaticd.ORDER_NO)
                //,new SqlParameter("@ACCESSION_NO",RISPaticd.ACCESSION_NO)
                ,pACCESSION_NO
                ,new SqlParameter("@ORDER_RESULT_FLAG",RISPaticd.ORDER_RESULT_FLAG)
                ,new SqlParameter("@ORG_ID",RISPaticd.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISPaticd.CREATED_BY)
                
            };
			Parameters = parameters;
		}
	}
}

