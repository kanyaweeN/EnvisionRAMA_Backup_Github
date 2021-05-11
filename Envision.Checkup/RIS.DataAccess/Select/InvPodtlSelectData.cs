//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/01/2552 12:10:28
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class INVPodtlSelectData : DataAccessBase 
	{
		private INVPodtl	_invpodtl;
		private INVPodtlInsertDataParameters	_invpodtlinsertdataparameters;
		public  INVPodtlSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PODTL_Select.ToString();
		}
		public  INVPodtl	INVPodtl
		{
			get{return _invpodtl;}
			set{_invpodtl=value;}
		}
		public DataSet GetData()
		{
			_invpodtlinsertdataparameters = new INVPodtlInsertDataParameters(INVPodtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_invpodtlinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class INVPodtlInsertDataParameters 
	{
		private INVPodtl _invpodtl;
		private SqlParameter[] _parameters;
		public INVPodtlInsertDataParameters(INVPodtl invpodtl)
		{
			INVPodtl=invpodtl;
			Build();
		}
		public  INVPodtl	INVPodtl
		{
			get{return _invpodtl;}
			set{_invpodtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@PO_ID",INVPodtl.PO_ID)
//,new SqlParameter("@ITEM_ID",INVPodtl.ITEM_ID)
//,new SqlParameter("@QTY",INVPodtl.QTY)
//,new SqlParameter("@PO_ITEM_STATUS",INVPodtl.PO_ITEM_STATUS)
//,new SqlParameter("@ORG_ID",INVPodtl.ORG_ID)
			
//,new SqlParameter("@CREATED_BY",INVPodtl.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVPodtl.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",INVPodtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",INVPodtl.LAST_MODIFIED_ON)
			};
		}
	}
}

