using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvTxnunitInsertData : DataAccessBase
    {
        public INV_TXNUNIT INV_TXNUNIT { get; set; }
        public InvTxnunitInsertData()
        {
            INV_TXNUNIT = new INV_TXNUNIT();
            this.StoredProcedureName = StoredProcedure.Prc_INV_TXNUNIT_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                            Parameter("@TXN_UNIT_UID",INV_TXNUNIT.TXN_UNIT_UID),
                            Parameter("@TXN_UNIT_NAME",INV_TXNUNIT.TXN_UNIT_NAME),
                            Parameter("@TXN_UNIT_DESC",INV_TXNUNIT.TXN_UNIT_DESC),
                            Parameter("@ORG_ID",INV_TXNUNIT.ORG_ID),
			            };
            return parameters;
        }
    }
}
