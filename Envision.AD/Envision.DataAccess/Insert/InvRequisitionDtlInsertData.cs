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

namespace Envision.DataAccess.Insert
{
	public class INVRequisitiondtlInsertData : DataAccessBase 
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }
		public  INVRequisitiondtlInsertData()
		{
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
			StoredProcedureName = StoredProcedure.Prc_INV_REQUISITIONDTL_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Add(DbTransaction tran)
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
,Parameter("@ORG_ID",INV_REQUISITIONDTL.ORG_ID)
,Parameter("@CREATED_BY",INV_REQUISITIONDTL.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_REQUISITIONDTL.LAST_MODIFIED_BY)
            };
            return parameters;
        }
	}
}

