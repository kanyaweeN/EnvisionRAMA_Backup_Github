//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:43
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class FINPaymentDeleteData : DataAccessBase 
	{
		private FINPayment	_finpayment;
		private FINPaymentDeleteDataParameters param;
		public  FINPaymentDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_PAYMENT_Delete.ToString();
		}
		public  FINPayment	FINPayment
		{
			get{return _finpayment;}
			set{_finpayment=value;}
		}
		public bool Delete()
		{
			param= new FINPaymentDeleteDataParameters(FINPayment);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		public bool Delete(bool flag,bool autocommit) 
		{
			if (flag)
			{
				DataAccess.DataAccessBase.BeginTransaction();
				SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
				param= new FINPaymentDeleteDataParameters(FINPayment);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class FINPaymentDeleteDataParameters 
	{
		private FINPayment _finpayment;
		private SqlParameter[] _parameters;
		public FINPaymentDeleteDataParameters(FINPayment finpayment)
		{
			FINPayment=finpayment;
			Build();
		}
		public  FINPayment	FINPayment
		{
			get{return _finpayment;}
			set{_finpayment=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@PAY_ID",FINPayment.PAY_ID)
			};
			_parameters = parameters;
		}
	}
}

