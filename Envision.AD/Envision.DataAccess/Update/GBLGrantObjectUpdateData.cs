using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLGrantObjectUpdateData :DataAccessBase
    {
        public GBL_GRANTOBJECT GBL_GRANTOBJECT { get; set; }


        public GBLGrantObjectUpdateData()
        {
            GBL_GRANTOBJECT = new GBL_GRANTOBJECT();
            StoredProcedureName = StoredProcedure.GBLGrantObject_Update;
        }

        public void Get()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@p_grantobject_id"	, this.GBL_GRANTOBJECT.GRANTOBJECT_ID ),
                Parameter( "@p_submenu_id"	, this.GBL_GRANTOBJECT.SUBMENU_ID ),
                Parameter( "@p_empid"	, this.GBL_GRANTOBJECT.EMP_ID ),
                Parameter( "@p_view"	, this.GBL_GRANTOBJECT.CAN_VIEW ),
                Parameter( "@p_create"	, this.GBL_GRANTOBJECT.CAN_CREATE ),
                Parameter( "@p_modify"	, this.GBL_GRANTOBJECT.CAN_MODIFY ),
                Parameter( "@p_removed"	, this.GBL_GRANTOBJECT.CAN_REMOVE ),
                Parameter( "@p_create_by"	, new GBLEnvVariable().UserID ),
                Parameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
                                      };
            return parameters;
        }
    }
}
