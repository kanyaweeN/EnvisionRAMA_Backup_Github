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

namespace RIS.DataAccess.Insert
{
	public class INVRequisitiondtlInsertData : DataAccessBase 
	{
		private INVRequisitiondtl	_invrequisitiondtl;
		private INVRequisitiondtlInsertDataParameters	_invrequisitiondtlinsertdataparameters;
		public  INVRequisitiondtlInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_REQUISITIONDTL_Insert.ToString();
		}
		public  INVRequisitiondtl	INVRequisitiondtl
		{
			get{return _invrequisitiondtl;}
			set{_invrequisitiondtl=value;}
		}
		public void Add()
		{
			_invrequisitiondtlinsertdataparameters = new INVRequisitiondtlInsertDataParameters(INVRequisitiondtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invrequisitiondtlinsertdataparameters.Parameters);
		}
        public void Add(SqlTransaction tran)
        {
            _invrequisitiondtlinsertdataparameters = new INVRequisitiondtlInsertDataParameters(INVRequisitiondtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _invrequisitiondtlinsertdataparameters.Parameters);
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
,new SqlParameter("@QTY",INVRequisitiondtl.QTY)
,new SqlParameter("@ORG_ID",INVRequisitiondtl.ORG_ID)
,new SqlParameter("@CREATED_BY",INVRequisitiondtl.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVRequisitiondtl.CREATED_ON)
,new SqlParameter("@LAST_MODIFIED_BY",INVRequisitiondtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",INVRequisitiondtl.LAST_MODIFIED_ON)
			};
			Parameters = parameters;
		}
	}
}

