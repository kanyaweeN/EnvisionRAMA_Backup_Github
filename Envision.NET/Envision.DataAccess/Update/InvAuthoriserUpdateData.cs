using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvAuthoriserUpdateData : DataAccessBase
    {
        public INV_AUTHORISER INV_AUTHORISER { get; set; }

        public InvAuthoriserUpdateData()
        {
            INV_AUTHORISER = new INV_AUTHORISER();
            this.StoredProcedureName = StoredProcedure.Prc_INV_AUTHORISER_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@AUTHORISER_ID",INV_AUTHORISER.AUTHORISER_ID),
                                Parameter("@EMP_ID",INV_AUTHORISER.EMP_ID),
                                Parameter("@SERIAL",INV_AUTHORISER.SERIAL),
                                Parameter("@AUTH_TYPE",INV_AUTHORISER.AUTH_TYPE),
                                Parameter("@ORG_ID",INV_AUTHORISER.ORG_ID),
                                Parameter("@LAST_MODIFIED_BY",INV_AUTHORISER.LAST_MODIFIED_BY),
                                      };
            return parameters;
        }
    }
}
