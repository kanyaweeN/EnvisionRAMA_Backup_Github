using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ManageGroupsInsertData : DataAccessBase
    {
        public GBL_GROUP GBL_GROUP { get; set; }
        public ManageGroupsInsertData()
        {
            GBL_GROUP = new GBL_GROUP();
            StoredProcedureName = StoredProcedure.Prc_ManageGroups_Insert;
        }

        public void Set()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
		        Parameter ( "@Guid"      ,   GBL_GROUP.GROUP_UID          ),
		        Parameter ( "@Gname"     ,   GBL_GROUP.GROUP_NAME         ),
                Parameter ( "@Guser"     ,   GBL_GROUP.GROUP_USER_NAME    ),
                Parameter ( "@Gpass"     ,   GBL_GROUP.GROUP_PASS         ),
		        Parameter ( "@Gtype"     ,   GBL_GROUP.GROUP_TYPE         ),
		        Parameter ( "@Ghead"     ,   GBL_GROUP.GROUP_HEAD         ),
		        Parameter ( "@Gheadname" ,   GBL_GROUP.GROUP_HEAD_NAME    ),
		        Parameter ( "@Isactive"  ,   GBL_GROUP.IS_ACTIVE          ),
		        Parameter ( "@Gcontactno",   GBL_GROUP.GROUP_CONTACT_NO   ),
                Parameter ( "@Orgiid"    ,   new Common.GBLEnvVariable().OrgID),
			            };
            return parameters;
        }

    }
}
