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

namespace RIS.DataAccess.Update
{
	public class FINInvoiceUpdateData : DataAccessBase 
	{
		private FINInvoice	_fininvoice;
		private FINInvoiceUpdateDataParameters param;
		public  FINInvoiceUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_INVOICE_Update.ToString();
		}
		public  FINInvoice	FINInvoice
		{
			get{return _fininvoice;}
			set{_fininvoice=value;}
		}
		public bool Update()
		{
			param= new FINInvoiceUpdateDataParameters(FINInvoice);
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
				param= new FINInvoiceUpdateDataParameters(FINInvoice);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Update();
			return true;
		}
	}
	public class FINInvoiceUpdateDataParameters 
	{
		private FINInvoice _fininvoice;
		private SqlParameter[] _parameters;
		public FINInvoiceUpdateDataParameters(FINInvoice fininvoice)
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
//,new SqlParameter("@INV_DT",FINInvoice.INV_DT)
//,new SqlParameter("@HN",FINInvoice.HN)
//,new SqlParameter("@UNIT_ID",FINInvoice.UNIT_ID)
//,new SqlParameter("@EMP_ID",FINInvoice.EMP_ID)
//,new SqlParameter("@STATUS",FINInvoice.STATUS)
//,new SqlParameter("@ORG_ID",FINInvoice.ORG_ID)
//,new SqlParameter("@CREATED_BY",FINInvoice.CREATED_BY)
//,new SqlParameter("@CREATED_ON",FINInvoice.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",FINInvoice.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",FINInvoice.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

