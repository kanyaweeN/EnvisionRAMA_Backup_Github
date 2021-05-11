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
	public class INVPoUpdateData : DataAccessBase 
	{
        public INV_PO INV_PO { get; set; }

		public  INVPoUpdateData()
		{
            INV_PO = new INV_PO();
			StoredProcedureName = StoredProcedure.Prc_INV_PO_Update;
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
Parameter("@PO_ID",INV_PO.PO_ID)
,Parameter("@PO_UID",INV_PO.PO_UID)
,Parameter("@VENDOR_ID",INV_PO.VENDOR_ID)
,Parameter("@TOC",INV_PO.TOC)
,Parameter("@LAST_MODIFIED_BY",INV_PO.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

