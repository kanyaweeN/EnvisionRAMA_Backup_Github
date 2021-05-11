using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLGrantRoleUpdateDataISUpdated :DataAccessBase
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }

        public GBLGrantRoleUpdateDataISUpdated()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_UpdateISUpdated;
        }

        public void Get()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@Grantroleid",GBL_GRANTROLE.GRANTROLE_ID),
                                      };
            return parameters;
        }
    }
}
