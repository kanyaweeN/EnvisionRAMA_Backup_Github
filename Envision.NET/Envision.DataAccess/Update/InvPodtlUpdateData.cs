//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/01/2552 12:10:28
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class INVPodtlUpdateData : DataAccessBase 
	{
        public INV_PODTL INV_PODTL { get; set; }

		public  INVPodtlUpdateData()
		{
            INV_PODTL = new INV_PODTL();
			StoredProcedureName = StoredProcedure.Prc_INV_PODTL_Update;
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
Parameter("@PO_ID",INV_PODTL.PO_ID)
,Parameter("@ITEM_ID",INV_PODTL.ITEM_ID)
,Parameter("@QTY",INV_PODTL.QTY)
,Parameter("@LAST_MODIFIED_BY",INV_PODTL.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

