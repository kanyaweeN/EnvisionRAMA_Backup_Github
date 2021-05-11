using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvTransactionTypeInsertData : DataAccessBase
    {
        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE { get; set; }

        public InvTransactionTypeInsertData()
        {
            INV_TRANSACTIONTYPE = new INV_TRANSACTIONTYPE();
            this.StoredProcedureName = StoredProcedure.Prc_INV_TRANSACTIONTYPE_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                            Parameter("@TRANSACTIONTYPE_UID",INV_TRANSACTIONTYPE.TRANSACTIONTYPE_UID),
                            Parameter("@TRANSACTIONTYPE_NAME",INV_TRANSACTIONTYPE.TRANSACTIONTYPE_NAME),
                            Parameter("@ORG_ID",INV_TRANSACTIONTYPE.ORG_ID),
			            };
            return parameters;
        }
    }
}
