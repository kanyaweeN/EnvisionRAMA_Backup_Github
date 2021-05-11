using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvTransactionTypeUpdateData : DataAccessBase
    {
        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE { get; set; }

        public InvTransactionTypeUpdateData()
        {
            INV_TRANSACTIONTYPE = new INV_TRANSACTIONTYPE();
            this.StoredProcedureName = StoredProcedure.Prc_INV_TRANSACTIONTYPE_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                           Parameter("@TRANSACTIONTYPE_ID",INV_TRANSACTIONTYPE.TRANSACTIONTYPE_ID),
                            Parameter("@TRANSACTIONTYPE_UID",INV_TRANSACTIONTYPE.TRANSACTIONTYPE_UID),
                            Parameter("@TRANSACTIONTYPE_NAME",INV_TRANSACTIONTYPE.TRANSACTIONTYPE_NAME),
                            Parameter("@ORG_ID",INV_TRANSACTIONTYPE.ORG_ID),
                                      };
            return parameters;
        }
    }
}
