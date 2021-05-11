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

namespace RIS.DataAccess.Update
{
	public class FINPaymentdtlUpdateData : DataAccessBase 
	{
		private FINPaymentdtl	_finpaymentdtl;
		private FINPaymentdtlUpdateDataParameters param;
		public  FINPaymentdtlUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_PAYMENTDTL_Update.ToString();
		}
		public  FINPaymentdtl	FINPaymentdtl
		{
			get{return _finpaymentdtl;}
			set{_finpaymentdtl=value;}
		}
		public bool Update()
		{
			param= new FINPaymentdtlUpdateDataParameters(FINPaymentdtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		public bool Update(bool flag,bool autocommit) 
		{
			if (flag)
			{
				DataAccess.DataAccessBase.BeginTransaction();
				SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
				param= new FINPaymentdtlUpdateDataParameters(FINPaymentdtl);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Update();
			return true;
		}
	}
	public class FINPaymentdtlUpdateDataParameters 
	{
		private FINPaymentdtl _finpaymentdtl;
		private SqlParameter[] _parameters;
		public FINPaymentdtlUpdateDataParameters(FINPaymentdtl finpaymentdtl)
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
                new SqlParameter("@PAY_ID",FINPaymentdtl.PAY_ID)
                ,new SqlParameter("@EXAM_ID",FINPaymentdtl.EXAM_ID)
                ,new SqlParameter("@ITEM_ID",FINPaymentdtl.ITEM_ID)
                ,new SqlParameter("@QTY",FINPaymentdtl.QTY)
                ,new SqlParameter("@RATE",FINPaymentdtl.RATE)
                ,new SqlParameter("@DISCOUNT",FINPaymentdtl.DISCOUNT)
                ,new SqlParameter("@PAYABLE",FINPaymentdtl.PAYABLE)
                ,new SqlParameter("@PAID",FINPaymentdtl.PAID)
                ,new SqlParameter("@STATUS",FINPaymentdtl.STATUS)
                ,new SqlParameter("@ORG_ID",FINPaymentdtl.ORG_ID)
                ,new SqlParameter("@CREATED_BY",FINPaymentdtl.CREATED_BY)
//,new SqlParameter("@CREATED_ON",FINPaymentdtl.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",FINPaymentdtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",FINPaymentdtl.LAST_MODIFIED_ON)
                ,new SqlParameter("@ORDER_ID",FINPaymentdtl.ORDER_ID)
			};
			_parameters = parameters;
		}
	}
}

