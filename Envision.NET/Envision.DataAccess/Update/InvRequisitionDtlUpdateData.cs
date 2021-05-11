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
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class INVRequisitiondtlUpdateData : DataAccessBase 
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }

		public  INVRequisitiondtlUpdateData()
		{
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
			StoredProcedureName = StoredProcedure.Prc_INV_REQUISITIONDTL_Update;
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
Parameter("@REQUISITION_ID",INV_REQUISITIONDTL.REQUISITION_ID)
,Parameter("@ITEM_ID",INV_REQUISITIONDTL.ITEM_ID)
,Parameter("@QTY",INV_REQUISITIONDTL.QTY)
,Parameter("@LAST_MODIFIED_BY",INV_REQUISITIONDTL.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

