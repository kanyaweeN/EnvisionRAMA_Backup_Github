//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    04/11/2551 03:33:48
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class INVTransactionInsertData : DataAccessBase 
	{
		private INVTransaction	_invtransaction;
		private INVTransactionInsertDataParameters	_invtransactioninsertdataparameters;
		public  INVTransactionInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_TRANSACTION_Insert.ToString();
		}
		public  INVTransaction	INVTransaction
		{
			get{return _invtransaction;}
			set{_invtransaction=value;}
		}
		public void Add()
		{
			_invtransactioninsertdataparameters = new INVTransactionInsertDataParameters(INVTransaction);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invtransactioninsertdataparameters.Parameters);
		}
	}
	public class INVTransactionInsertDataParameters 
	{
		private INVTransaction _invtransaction;
		private SqlParameter[] _parameters;
		public INVTransactionInsertDataParameters(INVTransaction invtransaction)
		{
			INVTransaction=invtransaction;
			Build();
		}
		public  INVTransaction	INVTransaction
		{
			get{return _invtransaction;}
			set{_invtransaction=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter[] parameters ={			
                new SqlParameter("@TXN_TYPE",INVTransaction.TXN_TYPE.ToString())
                ,new SqlParameter("@REQUISITION_ID",INVTransaction.REQUISITION_ID)
                ,new SqlParameter("@PO_ID",INVTransaction.PO_ID)
                ,new SqlParameter("@FROM_UNIT",INVTransaction.FROM_UNIT)
                ,new SqlParameter("@TO_UNIT",INVTransaction.TO_UNIT)
                ,new SqlParameter("@COMMENTS",INVTransaction.COMMENTS)
                ,new SqlParameter("@ORG_ID",INVTransaction.ORG_ID)
                ,new SqlParameter("@CREATED_BY",INVTransaction.CREATED_BY)
                ,new SqlParameter("@LAST_MODIFIED_BY",INVTransaction.LAST_MODIFIED_BY)
                ,new SqlParameter("@Status",INVTransaction.STATUS.ToString())
                ,new SqlParameter("@Doc",INVTransaction.Doc)
                ,new SqlParameter("@xmlDoc",INVTransaction.xmlDoc)
			};
            Parameters = parameters;
		}
	}
}

