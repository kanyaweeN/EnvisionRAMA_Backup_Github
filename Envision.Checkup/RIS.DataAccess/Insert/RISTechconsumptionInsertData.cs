//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    27/05/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISTechconsumptionInsertData : DataAccessBase 
	{
		private RISTechconsumption	_ristechconsumption;
		private RISTechconsumptionInsertDataParameters	_ristechconsumptioninsertdataparameters;
		public  RISTechconsumptionInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_TECHCONSUMPTION_Insert.ToString();
		}
		public  RISTechconsumption	RISTechconsumption
		{
			get{return _ristechconsumption;}
			set{_ristechconsumption=value;}
		}
		public void Add()
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
            SqlParameter pORG_ID = new SqlParameter();
            pORG_ID.ParameterName = "@ORG_ID";
            if (RISTechconsumption.ORG_ID == 0)
                pORG_ID.Value = DBNull.Value;
            else
                pORG_ID.Value = RISTechconsumption.ORG_ID;

			SqlParameter[] parameters ={
                new SqlParameter("@ACCESSION_NO",RISTechconsumption.ACCESSION_NO)
                ,new SqlParameter("@TAKE",RISTechconsumption.TAKE)
                ,new SqlParameter("@EXAM_ID",RISTechconsumption.EXAM_ID)
                ,new SqlParameter("@QTY",RISTechconsumption.QTY)
                ,new SqlParameter("@RATE",RISTechconsumption.RATE)
                ,new SqlParameter("@ORG_ID",pORG_ID.Value)
                ,new SqlParameter("@CREATED_BY",RISTechconsumption.CREATED_BY)
            };
			Parameters = parameters;
		}
	}
}

