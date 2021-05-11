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
	public class FINPaymentdtlDeleteData : DataAccessBase 
	{
		private FINPaymentdtl	_finpaymentdtl;
		private FINPaymentdtlDeleteDataParameters param;
		public  FINPaymentdtlDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_PAYMENTDTL_Delete.ToString();
		}
		public  FINPaymentdtl	FINPaymentdtl
		{
			get{return _finpaymentdtl;}
			set{_finpaymentdtl=value;}
		}
		public bool Delete()
		{
			param= new FINPaymentdtlDeleteDataParameters(FINPaymentdtl);
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
				param= new FINPaymentdtlDeleteDataParameters(FINPaymentdtl);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class FINPaymentdtlDeleteDataParameters 
	{
		private FINPaymentdtl _finpaymentdtl;
		private SqlParameter[] _parameters;
		public FINPaymentdtlDeleteDataParameters(FINPaymentdtl finpaymentdtl)
		{
			FINPaymentdtl=finpaymentdtl;
			Build();
		}
		public  FINPaymentdtl	FINPaymentdtl
		{
			get{return _finpaymentdtl;}
			set{_finpaymentdtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@PAY_ID",FINPaymentdtl.PAY_ID)
//,new SqlParameter("@EXAM_ID",FINPaymentdtl.EXAM_ID)
			};
			_parameters = parameters;
		}
	}
}

