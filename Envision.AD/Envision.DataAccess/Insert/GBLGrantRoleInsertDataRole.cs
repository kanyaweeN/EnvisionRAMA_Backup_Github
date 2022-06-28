using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLGrantRoleInsertDataRole :DataAccessBase
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }

        public GBLGrantRoleInsertDataRole()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_InsertByRole;
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
                Parameter("Cangrant" ,GBL_GRANTROLE.CAN_GRANT),
                Parameter("Grantor"  ,GBL_GRANTROLE.GRANTOR),
                Parameter("Grantdt"  ,GBL_GRANTROLE.GRANT_DT),
                Parameter("Isupdated",GBL_GRANTROLE.IS_UPDATED),
                Parameter("Isdeleted",GBL_GRANTROLE.IS_DELETED),
            };
            return parameters;
        }
    }

}
