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
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class INVPrdtlUpdateData : DataAccessBase 
	{
        public INV_PRDTL INV_PRDTL { get; set; }

		public  INVPrdtlUpdateData()
		{
            INV_PRDTL = new INV_PRDTL();
			StoredProcedureName = StoredProcedure.Prc_INV_PRDTL_Update;
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
Parameter("@PR_ID",INV_PRDTL.PR_ID)
,Parameter("@ITEM_ID",INV_PRDTL.ITEM_ID)
,Parameter("@QTY",INV_PRDTL.QTY)
,Parameter("@LAST_MODIFIED_BY",INV_PRDTL.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

