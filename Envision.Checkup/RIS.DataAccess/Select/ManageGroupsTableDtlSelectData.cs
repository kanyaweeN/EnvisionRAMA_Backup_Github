using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class ManageGroupsTableDtlSelectData : DataAccessBase
    {
        private ManageGroups _managegroups;
        public ManageGroupsTableDtlSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_SelectGroupsDtlTable.ToString();
        }
        public DataSet Get()
        {
            ManageGroupsTableDtlSelectDataParameters _managegroupsselectdataparameters = new ManageGroupsTableDtlSelectDataParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, _managegroupsselectdataparameters.Parameters);
            return ds;
        }
        public ManageGroups ManageGroups
        {
            get { return _managegroups; }
            set { _managegroups = value; }
        }
    }

    public class ManageGroupsTableDtlSelectDataParameters
    {
        private SqlParameter[] _parameters;
        private ManageGroups _managegroups;
        public ManageGroupsTableDtlSelectDataParameters(ManageGroups managegroups)
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
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public ManageGroups ManageGroups
        {
            get { return _managegroups; }
            set { _managegroups = value; }
        }
    }
}
