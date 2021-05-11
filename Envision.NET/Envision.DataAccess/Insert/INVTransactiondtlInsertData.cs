//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    04/11/2551 03:33:48
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class INVTransactiondtlInsertData : DataAccessBase 
	{
        public INV_TRANSACTIONDTL INV_TRANSACTIONDTL { get; set; }
        public INVTransactiondtlInsertData()
		{
            INV_TRANSACTIONDTL = new INV_TRANSACTIONDTL();
            StoredProcedureName = StoredProcedure.Prc_INV_TRANSACTIONDTL_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Add(DbTransaction tran)
        {
            Transaction = tran;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
Parameter("@TXN_ID",INV_TRANSACTIONDTL.TXN_ID)
,Parameter("@ITEM_ID",INV_TRANSACTIONDTL.ITEM_ID)
,Parameter("@REF_ITEM_ID",INV_TRANSACTIONDTL.REF_ITEM_ID)
,Parameter("@TXN_UNIT",INV_TRANSACTIONDTL.TXN_UNIT)
,Parameter("@BATCH",INV_TRANSACTIONDTL.BATCH)
,Parameter("@EXPIRY_DT",INV_TRANSACTIONDTL.EXPIRY_DT)
,Parameter("@QTY",INV_TRANSACTIONDTL.QTY)
,Parameter("@PRICE",INV_TRANSACTIONDTL.PRICE)
,Parameter("@COMMENTS",INV_TRANSACTIONDTL.COMMENTS)
,Parameter("@ORG_ID",INV_TRANSACTIONDTL.ORG_ID)
,Parameter("@CREATED_BY",INV_TRANSACTIONDTL.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_TRANSACTIONDTL.LAST_MODIFIED_BY)
,Parameter("@ITEMSTOCK_ID",INV_TRANSACTIONDTL.ITEMSTOCK_ID)
			            };
            return parameters;
        }
	}
}

