using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISTechconsumptionSelectData : DataAccessBase 
	{
		private RISTechconsumption	_ristechconsumption;
		private RISTechconsumptionInsertDataParameters	_ristechconsumptioninsertdataparameters;
		public  RISTechconsumptionSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_TECHCONSUMPTION_Select.ToString();
		}
		public  RISTechconsumption	RISTechconsumption
		{
			get{return _ristechconsumption;}
			set{_ristechconsumption=value;}
		}
		public DataSet GetData()
		{
			_ristechconsumptioninsertdataparameters = new RISTechconsumptionInsertDataParameters(RISTechconsumption);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_ristechconsumptioninsertdataparameters.Parameters);
			return ds;
		}
        public DataSet GetData(string HN) {
            _ristechconsumptioninsertdataparameters = new RISTechconsumptionInsertDataParameters(RISTechconsumption);
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_TECHCONSUMPTION_History.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, new SqlParameter[] { new SqlParameter("@HN", HN) });
            return ds;
        }
	}
	public class RISTechconsumptionInsertDataParameters 
	{
		private RISTechconsumption _ristechconsumption;
		private SqlParameter[] _parameters;
		public RISTechconsumptionInsertDataParameters(RISTechconsumption ristechconsumption)
		{
			RISTechconsumption=ristechconsumption;
			Build();
		}
		public  RISTechconsumption	RISTechconsumption
		{
			get{return _ristechconsumption;}
			set{_ristechconsumption=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={
                new SqlParameter("@ACCESSION_NO",RISTechconsumption.ACCESSION_NO)
                ,new SqlParameter("@TAKE",RISTechconsumption.TAKE)
            };
			Parameters = parameters;
		}
	}
}

