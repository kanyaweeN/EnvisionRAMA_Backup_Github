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

namespace Envision.DataAccess.Update
{
	public class INVRequisitionUpdateData : DataAccessBase 
	{
        public INV_REQUISITION INV_REQUISITION { get; set; }

		public  INVRequisitionUpdateData()
		{
            INV_REQUISITION = new INV_REQUISITION();
			StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Update(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@REQUISITION_ID",INV_REQUISITION.REQUISITION_ID)
,Parameter("@REQUISITION_UID",INV_REQUISITION.REQUISITION_UID)
,Parameter("@REQUISITION_TYPE",INV_REQUISITION.REQUISITION_TYPE)
,Parameter("@FROM_UNIT",INV_REQUISITION.FROM_UNIT)
,Parameter("@TO_UNIT",INV_REQUISITION.TO_UNIT)
,Parameter("@LAST_MODIFIED_BY",INV_REQUISITION.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

