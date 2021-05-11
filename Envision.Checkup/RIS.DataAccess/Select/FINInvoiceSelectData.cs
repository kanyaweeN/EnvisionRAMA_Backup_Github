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

namespace RIS.DataAccess.Select
{
	public class FINInvoiceSelectData : DataAccessBase 
	{
		private FINInvoice	_fininvoice;
		private FINInvoiceSelectDataParameters param;
		public  FINInvoiceSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_FIN_INVOICE_Select.ToString();
		}
		public  FINInvoice	FINInvoice
		{
			get{return _fininvoice;}
			set{_fininvoice=value;}
		}
		public DataSet GetData()
		{
			param = new FINInvoiceSelectDataParameters(FINInvoice);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class FINInvoiceSelectDataParameters 
	{
		private FINInvoice _fininvoice;
		private SqlParameter[] _parameters;
		public FINInvoiceSelectDataParameters(FINInvoice fininvoice)
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
			_parameters=parameters;
		}
	}
}

