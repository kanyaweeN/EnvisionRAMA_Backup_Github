using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLGrantObjectInsertData :DataAccessBase
    {
        public GBL_GRANTOBJECT GBL_GRANTOBJECT { get; set; }

        public GBLGrantObjectInsertData()
        {
            GBL_GRANTOBJECT = new GBL_GRANTOBJECT();
            StoredProcedureName = StoredProcedure.GBLGrantObject_Insert;
        }

        public void Get()
        {

            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@p_submenu_id"	, GBL_GRANTOBJECT.SUBMENU_ID ),
                Parameter( "@p_empid"	, GBL_GRANTOBJECT.EMP_ID ),
                Parameter( "@p_view"	, GBL_GRANTOBJECT.CAN_VIEW ),
                Parameter( "@p_create"	, GBL_GRANTOBJECT.CAN_CREATE ),
                Parameter( "@p_modify"	, GBL_GRANTOBJECT.CAN_MODIFY ),
                Parameter( "@p_removed"	, GBL_GRANTOBJECT.CAN_REMOVE ),
                Parameter( "@p_create_by"	, new GBLEnvVariable().UserID ),
                Parameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
            };
            return parameters;
        }
    }
}
