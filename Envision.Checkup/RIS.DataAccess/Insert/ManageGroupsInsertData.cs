using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class ManageGroupsInsertData : DataAccessBase
    {
        ManageGroups _mng;

        public ManageGroupsInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_Insert.ToString();
        }

        public void Set()
        {
            ManageGroupsInsertDataParameters mngpara = new ManageGroupsInsertDataParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);

            dbhelper.RunScalar(base.ConnectionString, mngpara.Parameters);
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }

    }

    public class ManageGroupsInsertDataParameters
    {
        ManageGroups _mng;
        SqlParameter[] _parameters;
        public ManageGroupsInsertDataParameters(ManageGroups mng)
        {
            _mng = mng;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = 
            {
		        new SqlParameter ( "@Guid"      ,   _mng.GROUP_UID          ),
		        new SqlParameter ( "@Gname"     ,   _mng.GROUP_NAME         ),
                new SqlParameter ( "@Guser"     ,   _mng.GROUP_USER_NAME    ),
                new SqlParameter ( "@Gpass"     ,   _mng.GROUP_PASS         ),
		        new SqlParameter ( "@Gtype"     ,   _mng.GROUP_TYPE         ),
		        new SqlParameter ( "@Ghead"     ,   _mng.GROUP_HEAD         ),
		        new SqlParameter ( "@Gheadname" ,   _mng.GROUP_HEAD_NAME    ),
		        new SqlParameter ( "@Isactive"  ,   _mng.IS_ACTIVE          ),
		        new SqlParameter ( "@Gcontactno",   _mng.GROUP_CONTACT_NO   ),
                new SqlParameter ( "@Orgiid"    ,   new Common.Common.GBLEnvVariable().OrgID),
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
