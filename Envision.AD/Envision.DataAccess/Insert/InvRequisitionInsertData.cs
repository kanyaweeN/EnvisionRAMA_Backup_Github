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
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class INVRequisitionInsertData : DataAccessBase 
	{
        public INV_REQUISITION INV_REQUISITION { get; set; }
        int _id = 0;
		public  INVRequisitionInsertData()
		{
            INV_REQUISITION = new INV_REQUISITION();
			StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            _id =  (int)ParameterList[0].Value;
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@REQUISITION_ID", INV_REQUISITION.REQUISITION_ID);
            param1.Direction = ParameterDirection.Output;
           
            DbParameter[] parameters ={
			param1
,Parameter("@REQUISITION_UID",INV_REQUISITION.REQUISITION_UID)
,Parameter("@REQUISITION_TYPE",INV_REQUISITION.REQUISITION_TYPE)
,Parameter("@FROM_UNIT",INV_REQUISITION.FROM_UNIT)
,Parameter("@TO_UNIT",INV_REQUISITION.TO_UNIT)
,Parameter("@GENERATED_BY",INV_REQUISITION.GENERATED_BY)
,Parameter("@ORG_ID",INV_REQUISITION.ORG_ID)
,Parameter("@CREATED_BY",INV_REQUISITION.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_REQUISITION.LAST_MODIFIED_BY)
            };
            return parameters;
        }
	}
}

