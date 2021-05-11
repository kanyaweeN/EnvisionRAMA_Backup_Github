using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class ManageGroupsSelectData : DataAccessBase
    {
        private ManageGroups _mng;

        public ManageGroupsSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_Select.ToString();
        }

        public DataSet Get()
        {
            ManageGroupsSelectDataParameters _managegroupsselectdataparameters = new ManageGroupsSelectDataParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, _managegroupsselectdataparameters.Parameters);
            return ds;
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }

    public class ManageGroupsSelectDataParameters
    {
        private SqlParameter[] _parameters;
        private ManageGroups _mng;

        public ManageGroupsSelectDataParameters(ManageGroups mng)
        {
            _mng = mng;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@GroupType"	, ManageGroups.GROUP_TYPE )	
		    };

            Parameters = parameters;
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
