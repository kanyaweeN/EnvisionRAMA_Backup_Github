using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISPaticdDeleteData : DataAccessBase 
	{
		private RISPaticd	_rispaticd;
		private RISPaticdInsertDataParameters	_rispaticdinsertdataparameters;

		public  RISPaticdDeleteData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATICD_Delete.ToString();
		}
		public  RISPaticd	RISPaticd 
		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public void Delete()
		{
			_rispaticdinsertdataparameters = new RISPaticdInsertDataParameters(RISPaticd);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rispaticdinsertdataparameters.Parameters);
		}
        public void Delete(SqlTransaction tran)
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
			SqlParameter[] parameters ={ new SqlParameter("@PAT_ICD_ID",RISPaticd.PAT_ICD_ID)};
			Parameters = parameters;
		}
	}
}

