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

namespace RIS.DataAccess.Delete
{
	public class INVRequisitionDeleteData : DataAccessBase 
	{
		private INVRequisition	_invrequisition;
		private INVRequisitionInsertDataParameters	_invrequisitioninsertdataparameters;
		public  INVRequisitionDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_REQUISITION_Delete.ToString();
		}
		public  INVRequisition	INVRequisition
		{
			get{return _invrequisition;}
			set{_invrequisition=value;}
		}
		public void Delete()
		{
			_invrequisitioninsertdataparameters = new INVRequisitionInsertDataParameters(INVRequisition);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invrequisitioninsertdataparameters.Parameters);
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
			};
			Parameters = parameters;
		}
	}
}

