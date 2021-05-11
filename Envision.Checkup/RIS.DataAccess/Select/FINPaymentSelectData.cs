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

namespace RIS.DataAccess.Select
{
	public class FINPaymentSelectData : DataAccessBase 
	{
		private FINPayment	_finpayment;
		private FINPaymentSelectDataParameters param;
		public  FINPaymentSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_PAYMENT_Select.ToString();
		}
		public  FINPayment	FINPayment
		{
			get{return _finpayment;}
			set{_finpayment=value;}
		}
		public DataSet GetData()
		{
			param = new FINPaymentSelectDataParameters(FINPayment);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
			return ds;
		}
	}
	public class FINPaymentSelectDataParameters 
	{
		private FINPayment _finpayment;
		private SqlParameter[] _parameters;
		public FINPaymentSelectDataParameters(FINPayment finpayment)
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
                new SqlParameter("@PAY_ID",FINPayment.PAY_ID)
//,new SqlParameter("@PAY_DT",FINPayment.PAY_DT)
//,new SqlParameter("@INV_ID",FINPayment.INV_ID)
//,new SqlParameter("@HN",FINPayment.HN)
//,new SqlParameter("@UNIT_ID",FINPayment.UNIT_ID)
			
//,new SqlParameter("@EMP_ID",FINPayment.EMP_ID)
//,new SqlParameter("@STATUS",FINPayment.STATUS)
//,new SqlParameter("@ORG_ID",FINPayment.ORG_ID)
//,new SqlParameter("@CREATED_BY",FINPayment.CREATED_BY)
//,new SqlParameter("@CREATED_ON",FINPayment.CREATED_ON)
			
//,new SqlParameter("@LAST_MODIFIED_BY",FINPayment.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",FINPayment.LAST_MODIFIED_ON)
                ,new SqlParameter("@FROM_DATE", FINPayment.FROM_DATE)
                ,new SqlParameter("@TO_DATE",FINPayment.TO_DATE)
                ,new SqlParameter("@ORDER_ID",FINPayment.ORDER_ID)
			};
			_parameters=parameters;
		}
	}
}

