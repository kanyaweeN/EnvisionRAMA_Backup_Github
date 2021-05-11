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
	public class FINInvoicedtlDeleteData : DataAccessBase 
	{
		private FINInvoicedtl	_fininvoicedtl;
		private FINInvoicedtlDeleteDataParameters param;
		public  FINInvoicedtlDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_INVOICEDTL_Delete.ToString();
		}
		public  FINInvoicedtl	FINInvoicedtl
		{
			get{return _fininvoicedtl;}
			set{_fininvoicedtl=value;}
		}
		public bool Delete()
		{
			param= new FINInvoicedtlDeleteDataParameters(FINInvoicedtl);
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
				param= new FINInvoicedtlDeleteDataParameters(FINInvoicedtl);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class FINInvoicedtlDeleteDataParameters 
	{
		private FINInvoicedtl _fininvoicedtl;
		private SqlParameter[] _parameters;
		public FINInvoicedtlDeleteDataParameters(FINInvoicedtl fininvoicedtl)
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
			};
			_parameters = parameters;
		}
	}
}

