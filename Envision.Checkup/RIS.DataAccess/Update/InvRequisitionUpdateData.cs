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

namespace RIS.DataAccess.Update
{
	public class INVRequisitionUpdateData : DataAccessBase 
	{
		private INVRequisition	_invrequisition;
		private INVRequisitionInsertDataParameters	_invrequisitioninsertdataparameters;
		public  INVRequisitionUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_REQUISITION_Update.ToString();
		}
		public  INVRequisition	INVRequisition
		{
			get{return _invrequisition;}
			set{_invrequisition=value;}
		}
		public void Update()
		{
			_invrequisitioninsertdataparameters = new INVRequisitionInsertDataParameters(INVRequisition);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invrequisitioninsertdataparameters.Parameters);
		}
        public void Update(SqlTransaction tran)
        {
            _invrequisitioninsertdataparameters = new INVRequisitionInsertDataParameters(INVRequisition);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _invrequisitioninsertdataparameters.Parameters);
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
			SqlParameter[] parameters ={		
new SqlParameter("@REQUISITION_ID",INVRequisition.REQUISITION_ID)
,new SqlParameter("@REQUISITION_UID",INVRequisition.REQUISITION_UID)
,new SqlParameter("@REQUISITION_TYPE",INVRequisition.REQUISITION_TYPE)
//,new SqlParameter("@GENERATE_MODE",INVRequisition.GENERATE_MODE)
,new SqlParameter("@FROM_UNIT",INVRequisition.FROM_UNIT)
,new SqlParameter("@TO_UNIT",INVRequisition.TO_UNIT)
//,new SqlParameter("@GENERATED_BY",INVRequisition.GENERATED_BY)
//,new SqlParameter("@GENERATED_ON",INVRequisition.GENERATED_ON)
//,new SqlParameter("@STATUS",INVRequisition.STATUS)
//,new SqlParameter("@ORG_ID",INVRequisition.ORG_ID)
//,new SqlParameter("@CREATED_BY",INVRequisition.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVRequisition.CREATED_ON)
,new SqlParameter("@LAST_MODIFIED_BY",INVRequisition.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",INVRequisition.LAST_MODIFIED_ON)
			};
            Parameters = parameters;
		}
	}
}

