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

namespace Envision.DataAccess.Insert
{
	public class INVPodtlInsertData : DataAccessBase 
	{
        public INV_PODTL INV_PODTL { get; set; }
		public  INVPodtlInsertData()
		{
            INV_PODTL = new INV_PODTL();
			StoredProcedureName = StoredProcedure.Prc_INV_PODTL_Insert;
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
Parameter("@PO_ID",INV_PODTL.PO_ID)
,Parameter("@ITEM_ID",INV_PODTL.ITEM_ID)
,Parameter("@QTY",INV_PODTL.QTY)
,Parameter("@UNITPRICE",INV_PODTL.UNITPRICE)
,Parameter("@ORG_ID",INV_PODTL.ORG_ID)
,Parameter("@CREATED_BY",INV_PODTL.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_PODTL.LAST_MODIFIED_BY)
            };
            return parameters;
        }
	}
}

