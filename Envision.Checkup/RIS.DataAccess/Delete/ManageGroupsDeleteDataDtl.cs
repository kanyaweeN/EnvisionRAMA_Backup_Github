using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class ManageGroupsDeleteDataDtl : DataAccessBase
    {
        ManageGroups _mng;
        public ManageGroupsDeleteDataDtl()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_Delete_Dtl.ToString();
        }

        public void Set()
        {
            ManageGroupsDeleteDataDtlParameters mngpara = new ManageGroupsDeleteDataDtlParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);

            dbhelper.RunScalar(base.ConnectionString, mngpara.Parameters);
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }

    public class ManageGroupsDeleteDataDtlParameters
    {
        ManageGroups _mng;
        SqlParameter[] _parameters;
        public ManageGroupsDeleteDataDtlParameters(ManageGroups mng)
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
