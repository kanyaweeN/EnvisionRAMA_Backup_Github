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

namespace Envision.DataAccess.Insert
{
	public class INVPrdtlInsertData : DataAccessBase 
	{
        public INV_PRDTL INV_PRDTL { get; set; }
		public  INVPrdtlInsertData()
		{
            INV_PRDTL = new INV_PRDTL();
			StoredProcedureName = StoredProcedure.Prc_INV_PRDTL_Insert;
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
Parameter("@PR_ID",INV_PRDTL.PR_ID)
,Parameter("@ITEM_ID",INV_PRDTL.ITEM_ID)
,Parameter("@QTY",INV_PRDTL.QTY)
,Parameter("@REMARK",INV_PRDTL.REMARK)
,Parameter("@ORG_ID",INV_PRDTL.ORG_ID)
,Parameter("@CREATED_BY",INV_PRDTL.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_PRDTL.LAST_MODIFIED_BY)
            };
            return parameters;
        }
	}
}

