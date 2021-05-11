//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    12/05/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class RISPaticdUpdateData : DataAccessBase 
	{
		private RISPaticd	_rispaticd;
		private RISPaticdInsertDataParameters	_rispaticdinsertdataparameters;
		public  RISPaticdUpdateData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATICD_Update.ToString();
		}
		public  RISPaticd	RISPaticd
		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public void Update()
		{
			_rispaticdinsertdataparameters = new RISPaticdInsertDataParameters(RISPaticd);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rispaticdinsertdataparameters.Parameters);
		}
        public void Update(SqlTransaction tran)
        {
            _rispaticdinsertdataparameters = new RISPaticdInsertDataParameters(RISPaticd);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _rispaticdinsertdataparameters.Parameters);
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
			SqlParameter[] parameters ={
                new SqlParameter("@PAT_ICD_ID",RISPaticd.PAT_ICD_ID)
                ,new SqlParameter("@ICD_ID",RISPaticd.ICD_ID)
                ,new SqlParameter("@HN",RISPaticd.HN)
                ,new SqlParameter("@ORDER_NO",RISPaticd.ORDER_NO)
                ,new SqlParameter("@ACCESSION_NO",RISPaticd.ACCESSION_NO)
                ,new SqlParameter("@ORDER_RESULT_FLAG",RISPaticd.ORDER_RESULT_FLAG)
                ,new SqlParameter("@ORG_ID",RISPaticd.ORG_ID)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISPaticd.LAST_MODIFIED_BY)
            };
			Parameters = parameters;
		}
	}
}

