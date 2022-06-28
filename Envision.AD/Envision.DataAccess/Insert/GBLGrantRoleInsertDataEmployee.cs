using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLGrantRoleInsertDataEmployee :DataAccessBase
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }

        public GBLGrantRoleInsertDataEmployee()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_InsertByEmployee;
        }

        public void Get()
        {

            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("Roleid"   ,GBL_GRANTROLE.ROLE_ID),
                Parameter("Empid"    ,GBL_GRANTROLE.EMP_ID),
                Parameter("Grantor"  ,GBL_GRANTROLE.GRANTOR),
                Parameter("Orgid"   ,GBL_GRANTROLE.ORG_ID),
            };
            return parameters;
        }
    }

}
