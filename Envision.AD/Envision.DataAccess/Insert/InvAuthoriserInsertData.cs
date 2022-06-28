using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvAuthoriserInsertData : DataAccessBase
    {
        public INV_AUTHORISER INV_AUTHORISER { get; set; }

        public InvAuthoriserInsertData()
        {
            INV_AUTHORISER = new INV_AUTHORISER();
            this.StoredProcedureName = StoredProcedure.Prc_INV_AUTHORISER_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@EMP_ID",INV_AUTHORISER.EMP_ID),
                                Parameter("@SERIAL",INV_AUTHORISER.SERIAL),
                                Parameter("@AUTH_TYPE",INV_AUTHORISER.AUTH_TYPE),
                                Parameter("@ORG_ID",INV_AUTHORISER.ORG_ID),
            };
            return parameters;
        }
    }
}
