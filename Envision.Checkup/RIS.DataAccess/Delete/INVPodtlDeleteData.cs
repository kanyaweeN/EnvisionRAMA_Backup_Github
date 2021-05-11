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

namespace RIS.DataAccess.Delete
{
	public class INVPodtlDeleteData : DataAccessBase 
	{
		private INVPodtl	_invpodtl;
		private INVPodtlInsertDataParameters	_invpodtlinsertdataparameters;
		public  INVPodtlDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PODTL_Delete.ToString();
		}
		public  INVPodtl	INVPodtl
		{
			get{return _invpodtl;}
			set{_invpodtl=value;}
		}
		public void Delete()
		{
			_invpodtlinsertdataparameters = new INVPodtlInsertDataParameters(INVPodtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invpodtlinsertdataparameters.Parameters);
		}
        public void Delete(SqlTransaction tran)
        {
            _invpodtlinsertdataparameters = new INVPodtlInsertDataParameters(INVPodtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _invpodtlinsertdataparameters.Parameters);
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
new SqlParameter("@PO_ID",INVPodtl.PO_ID)
,new SqlParameter("@ITEM_ID",INVPodtl.ITEM_ID)
			};
			Parameters = parameters;
		}
	}
}

