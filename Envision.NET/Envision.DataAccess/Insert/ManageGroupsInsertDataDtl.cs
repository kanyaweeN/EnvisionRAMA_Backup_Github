using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ManageGroupsInsertDataDtl : DataAccessBase
    {
        public GBL_GROUPDTL GBL_GROUPDTL { get; set; }

        public ManageGroupsInsertDataDtl()
        {
            GBL_GROUPDTL = new GBL_GROUPDTL();
            StoredProcedureName = StoredProcedure.Prc_ManageGroups_Insert_Dtl;
        }

        public void Set()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter(   "@Gid"       ,   GBL_GROUPDTL.GROUP_ID  ),
                Parameter(   "@Gmemid"       ,   GBL_GROUPDTL.MEMBER_ID  ),
                Parameter(   "@Gsl"          ,   GBL_GROUPDTL.SL         ),
                Parameter(   "@Isactive"     ,   GBL_GROUPDTL.IS_ACTIVE  ),
                Parameter(   "@Orgid"    ,  new Common.GBLEnvVariable().OrgID),
			            };
            return parameters;
        }
    }
}
