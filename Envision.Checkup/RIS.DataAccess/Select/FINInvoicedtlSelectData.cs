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
	public class FINInvoicedtlSelectData : DataAccessBase 
	{
		private FINInvoicedtl	_fininvoicedtl;
		private FINInvoicedtlSelectDataParameters param;
		public  FINInvoicedtlSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_INVOICEDTL_Select.ToString();
		}
		public  FINInvoicedtl	FINInvoicedtl
		{
			get{return _fininvoicedtl;}
			set{_fininvoicedtl=value;}
		}
		public DataSet GetData()
		{
			param = new FINInvoicedtlSelectDataParameters(FINInvoicedtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class FINInvoicedtlSelectDataParameters 
	{
		private FINInvoicedtl _fininvoicedtl;
		private SqlParameter[] _parameters;
		public FINInvoicedtlSelectDataParameters(FINInvoicedtl fininvoicedtl)
		{
			FINInvoicedtl=fininvoicedtl;
			Build();
		}
		public  FINInvoicedtl	FINInvoicedtl
		{
			get{return _fininvoicedtl;}
			set{_fininvoicedtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@INV_ID",FINInvoicedtl.INV_ID)
//,new SqlParameter("@EXAM_ID",FINInvoicedtl.EXAM_ID)
//,new SqlParameter("@ITEM_ID",FINInvoicedtl.ITEM_ID)
//,new SqlParameter("@QTY",FINInvoicedtl.QTY)
//,new SqlParameter("@RATE",FINInvoicedtl.RATE)
			
//,new SqlParameter("@DISCOUNT",FINInvoicedtl.DISCOUNT)
//,new SqlParameter("@PAYABLE",FINInvoicedtl.PAYABLE)
//,new SqlParameter("@STATUS",FINInvoicedtl.STATUS)
//,new SqlParameter("@ORG_ID",FINInvoicedtl.ORG_ID)
//,new SqlParameter("@CREATED_BY",FINInvoicedtl.CREATED_BY)
			
//,new SqlParameter("@CREATED_ON",FINInvoicedtl.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",FINInvoicedtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",FINInvoicedtl.LAST_MODIFIED_ON)
			};
			_parameters=parameters;
		}
	}
}

