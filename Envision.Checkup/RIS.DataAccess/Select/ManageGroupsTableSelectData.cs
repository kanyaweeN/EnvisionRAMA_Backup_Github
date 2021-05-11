using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class ManageGroupsTableSelectData : DataAccessBase
    {
        private ManageGroups _managegroups;

        public ManageGroupsTableSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_SelectGroupsTable.ToString();
        }

        public DataSet Get()
        {
            //ManageGroupsTableSelectDataParameters _managegroupsselectdataparameters = new ManageGroupsTableSelectDataParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);//,_managegroupsselectdataparameters.Parameters);
            return ds;
        }

        public ManageGroups ManageGroups
        {
            get { return _managegroups; }
            set { _managegroups = value; }
        }
    }

    public class ManageGroupsTableSelectDataParameters
    {
        private SqlParameter[] _parameters;
        private ManageGroups _managegroups;

        public ManageGroupsTableSelectDataParameters(ManageGroups managegroups)
        {
            _managegroups = managegroups;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@Gid"	, ManageGroups.GROUP_ID )
		    };
            Parameters = parameters;
        }

        public ManageGroups ManageGroups
        {
            get { return _managegroups; }
            set { _managegroups = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
