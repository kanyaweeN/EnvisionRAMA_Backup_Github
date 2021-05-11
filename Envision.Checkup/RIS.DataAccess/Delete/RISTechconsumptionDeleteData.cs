using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISTechconsumptionDeleteData : DataAccessBase 
	{
		private RISTechconsumption	_ristechconsumption;
		private RISTechconsumptionInsertDataParameters	_ristechconsumptioninsertdataparameters;
		public  RISTechconsumptionDeleteData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_TECHCONSUMPTION_Delete.ToString();
		}
		public  RISTechconsumption	RISTechconsumption
		{
			get{return _ristechconsumption;}
			set{_ristechconsumption=value;}
		}
		public void Delete()
		{
			_ristechconsumptioninsertdataparameters = new RISTechconsumptionInsertDataParameters(RISTechconsumption);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_ristechconsumptioninsertdataparameters.Parameters);
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
                //,new SqlParameter("@EXAM_ID",RISTechconsumption.EXAM_ID)
            };
			Parameters = parameters;
		}
	}
}

