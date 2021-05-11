//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:41
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
	public class FINInvoiceDeleteData : DataAccessBase 
	{
		private FINInvoice	_fininvoice;
		private FINInvoiceDeleteDataParameters param;
		public  FINInvoiceDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_INVOICE_Delete.ToString();
		}
		public  FINInvoice	FINInvoice
		{
			get{return _fininvoice;}
			set{_fininvoice=value;}
		}
		public bool Delete()
		{
			param= new FINInvoiceDeleteDataParameters(FINInvoice);
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
				param= new FINInvoiceDeleteDataParameters(FINInvoice);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class FINInvoiceDeleteDataParameters 
	{
		private FINInvoice _fininvoice;
		private SqlParameter[] _parameters;
		public FINInvoiceDeleteDataParameters(FINInvoice fininvoice)
		{
			FINInvoice=fininvoice;
			Build();
		}
		public  FINInvoice	FINInvoice
		{
			get{return _fininvoice;}
			set{_fininvoice=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@INV_ID",FINInvoice.INV_ID)
			};
			_parameters = parameters;
		}
	}
}

