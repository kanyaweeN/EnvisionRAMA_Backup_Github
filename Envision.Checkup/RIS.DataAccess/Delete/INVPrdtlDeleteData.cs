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

namespace RIS.DataAccess.Delete
{
	public class INVPrdtlDeleteData : DataAccessBase 
	{
		private INVPrdtl	_invprdtl;
		private INVPrdtlInsertDataParameters	_invprdtlinsertdataparameters;
		public  INVPrdtlDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PRDTL_Delete.ToString();
		}
		public  INVPrdtl	INVPrdtl
		{
			get{return _invprdtl;}
			set{_invprdtl=value;}
		}
		public void Delete()
		{
			_invprdtlinsertdataparameters = new INVPrdtlInsertDataParameters(INVPrdtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _invprdtlinsertdataparameters.Parameters);
		}
        public void Delete(SqlTransaction tran)
        {
            _invprdtlinsertdataparameters = new INVPrdtlInsertDataParameters(INVPrdtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _invprdtlinsertdataparameters.Parameters);
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
new SqlParameter("@PR_ID",INVPrdtl.PR_ID)
                ,new SqlParameter("@ITEM_ID",INVPrdtl.ITEM_ID)
			};
			Parameters = parameters;
		}
	}
}

