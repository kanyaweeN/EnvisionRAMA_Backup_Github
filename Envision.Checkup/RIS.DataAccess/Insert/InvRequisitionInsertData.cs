//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    04/11/2551 02:30:47
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class INVRequisitionInsertData : DataAccessBase 
	{
		private INVRequisition	_invrequisition;
        int _id = 0;
		private INVRequisitionInsertDataParameters	_invrequisitioninsertdataparameters;
		public  INVRequisitionInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_REQUISITION_Insert.ToString();
		}
		public  INVRequisition	INVRequisition
		{
			get{return _invrequisition;}
			set{_invrequisition=value;}
		}
		public void Add()
		{
			_invrequisitioninsertdataparameters = new INVRequisitionInsertDataParameters(INVRequisition);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(base.ConnectionString, _invrequisitioninsertdataparameters.Parameters);
            _id = (int)_invrequisitioninsertdataparameters.Parameters[0].Value;
		}
        public void Add(SqlTransaction tran)
        {
            _invrequisitioninsertdataparameters = new INVRequisitionInsertDataParameters(INVRequisition);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _invrequisitioninsertdataparameters.Parameters);
            _id = (int)_invrequisitioninsertdataparameters.Parameters[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
	}
	public class INVRequisitionInsertDataParameters 
	{
		private INVRequisition _invrequisition;
		private SqlParameter[] _parameters;
		public INVRequisitionInsertDataParameters(INVRequisition invrequisition)
		{
			INVRequisition=invrequisition;
			Build();
		}
		public  INVRequisition	INVRequisition
		{
			get{return _invrequisition;}
			set{_invrequisition=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter param1 = new SqlParameter("@REQUISITION_ID", INVRequisition.REQUISITION_ID);
            param1.Direction = ParameterDirection.Output;
			SqlParameter[] parameters ={
			param1
,new SqlParameter("@REQUISITION_UID",INVRequisition.REQUISITION_UID)
,new SqlParameter("@REQUISITION_TYPE",INVRequisition.REQUISITION_TYPE)
,new SqlParameter("@FROM_UNIT",INVRequisition.FROM_UNIT)
,new SqlParameter("@TO_UNIT",INVRequisition.TO_UNIT)
,new SqlParameter("@GENERATED_BY",INVRequisition.GENERATED_BY)
,new SqlParameter("@ORG_ID",INVRequisition.ORG_ID)
,new SqlParameter("@CREATED_BY",INVRequisition.CREATED_BY)
,new SqlParameter("@LAST_MODIFIED_BY",INVRequisition.LAST_MODIFIED_BY)
//,new SqlParameter("@CREATED_BY",INVRequisition.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVRequisition.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",INVRequisition.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",INVRequisition.LAST_MODIFIED_ON)
			};
			Parameters = parameters;
		}
	}
}

