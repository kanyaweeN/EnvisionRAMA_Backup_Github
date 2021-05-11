using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class ManageGroupsDeleteData : DataAccessBase
    {
        ManageGroups _mng;
        public ManageGroupsDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_Delete.ToString();
        }

        public void Set()
        {
            ManageGroupsDeleteDataParameters mngpara = new ManageGroupsDeleteDataParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);

            dbhelper.RunScalar(base.ConnectionString, mngpara.Parameters);
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }

    public class ManageGroupsDeleteDataParameters
    {
        ManageGroups _mng;
        SqlParameter[] _parameters;
        public ManageGroupsDeleteDataParameters(ManageGroups mng)
        {
            _mng = mng;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = 
            {
		        new SqlParameter ( "@Gid"       ,   _mng.GROUP_ID           ),
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
