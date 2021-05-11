//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    23/12/2551 12:15:50
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class INVPrdtlSelectData : DataAccessBase 
	{
		private INVPrdtl	_invprdtl;
		private INVPrdtlInsertDataParameters	_invprdtlinsertdataparameters;
		public  INVPrdtlSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PRDTL_Select.ToString();
		}
		public  INVPrdtl	INVPrdtl
		{
			get{return _invprdtl;}
			set{_invprdtl=value;}
		}
		public DataSet GetData()
		{
			_invprdtlinsertdataparameters = new INVPrdtlInsertDataParameters(INVPrdtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_invprdtlinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class INVPrdtlInsertDataParameters 
	{
		private INVPrdtl _invprdtl;
		private SqlParameter[] _parameters;
		public INVPrdtlInsertDataParameters(INVPrdtl invprdtl)
		{
			INVPrdtl=invprdtl;
			Build();
		}
		public  INVPrdtl	INVPrdtl
		{
			get{return _invprdtl;}
			set{_invprdtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@PRDTL_ID",INVPrdtl.PRDTL_ID)
//,new SqlParameter("@PR_ID",INVPrdtl.PR_ID)
//,new SqlParameter("@ITEM_ID",INVPrdtl.ITEM_ID)
//,new SqlParameter("@QTY",INVPrdtl.QTY)
//,new SqlParameter("@ORG_ID",INVPrdtl.ORG_ID)
			
//,new SqlParameter("@CREATED_BY",INVPrdtl.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVPrdtl.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",INVPrdtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",INVPrdtl.LAST_MODIFIED_ON)
			};
		}
	}
}

