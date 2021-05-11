using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class ManageGroupsUpdateData : DataAccessBase
    {
        ManageGroups _mng;
        public ManageGroupsUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_Update.ToString();
        }

        public void Set()
        {
            ManageGroupsUpdateDataParameters mngpara = new ManageGroupsUpdateDataParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);

            dbhelper.RunScalar(base.ConnectionString, mngpara.Parameters);
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }

    public class ManageGroupsUpdateDataParameters
    {
        ManageGroups _mng;
        SqlParameter[] _parameters;
        public ManageGroupsUpdateDataParameters(ManageGroups mng)
        {
            _mng = mng;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = 
            {
		        new SqlParameter ( "@Gid"       ,   _mng.GROUP_ID           ),
		        new SqlParameter ( "@Guid"      ,   _mng.GROUP_UID          ),
		        new SqlParameter ( "@Gname"     ,   _mng.GROUP_NAME         ),
                new SqlParameter ( "@Guser"     ,   _mng.GROUP_USER_NAME    ),
                new SqlParameter ( "@Gpass"     ,   _mng.GROUP_PASS         ),
		        new SqlParameter ( "@Gtype"     ,   _mng.GROUP_TYPE         ),
		        new SqlParameter ( "@Ghead"     ,   _mng.GROUP_HEAD         ),
		        new SqlParameter ( "@Gheadname" ,   _mng.GROUP_HEAD_NAME    ),
		        new SqlParameter ( "@Gcontactno",   _mng.GROUP_CONTACT_NO   ),
		        new SqlParameter ( "@Isactive"  ,   _mng.IS_ACTIVE          ),
                new SqlParameter ( "@Orgid"     ,   new Common.Common.GBLEnvVariable().OrgID),
            };

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
