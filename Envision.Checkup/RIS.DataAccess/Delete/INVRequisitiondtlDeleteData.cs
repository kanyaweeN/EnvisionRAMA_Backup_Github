//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    04/11/2551 02:30:46
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class INVRequisitiondtlDeleteData : DataAccessBase 
	{
		private INVRequisitiondtl	_invrequisitiondtl;
		private INVRequisitiondtlInsertDataParameters	_invrequisitiondtlinsertdataparameters;
		public  INVRequisitiondtlDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_REQUISITIONDTL_Delete.ToString();
		}
		public  INVRequisitiondtl	INVRequisitiondtl
		{
			get{return _invrequisitiondtl;}
			set{_invrequisitiondtl=value;}
		}
		public void Delete()
		{
			_invrequisitiondtlinsertdataparameters = new INVRequisitiondtlInsertDataParameters(INVRequisitiondtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invrequisitiondtlinsertdataparameters.Parameters);
		}
        public void Delete(SqlTransaction tran)
        {
            _invrequisitiondtlinsertdataparameters = new INVRequisitiondtlInsertDataParameters(INVRequisitiondtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _invrequisitiondtlinsertdataparameters.Parameters);
        }
	}
	public class INVRequisitiondtlInsertDataParameters 
	{
		private INVRequisitiondtl _invrequisitiondtl;
		private SqlParameter[] _parameters;
		public INVRequisitiondtlInsertDataParameters(INVRequisitiondtl invrequisitiondtl)
		{
			INVRequisitiondtl=invrequisitiondtl;
			Build();
		}
		public  INVRequisitiondtl	INVRequisitiondtl
		{
			get{return _invrequisitiondtl;}
			set{_invrequisitiondtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@REQUISITION_ID",INVRequisitiondtl.REQUISITION_ID)
,new SqlParameter("@ITEM_ID",INVRequisitiondtl.ITEM_ID)
			};
			Parameters = parameters;
		}
	}
}

