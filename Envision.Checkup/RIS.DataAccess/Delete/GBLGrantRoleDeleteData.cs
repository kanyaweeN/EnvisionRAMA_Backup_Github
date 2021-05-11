using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLGrantRoleDeleteData : DataAccessBase
    {
        private GBLGrantRole _grantrole;

        public GBLGrantRoleDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLGrantRole_Delete.ToString();
        }

        public void Get()
        {
            GBLGrantRoleDeleteDataParameters _GBLGrantRoleDeleteDataParameters
                = new GBLGrantRoleDeleteDataParameters(this.GBLGrantRole);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.RunScalar(base.ConnectionString, _GBLGrantRoleDeleteDataParameters.Parameters);
        }

        public GBLGrantRole GBLGrantRole
        {
            get { return _grantrole; }
            set { _grantrole = value; }
        }
    }

    public class GBLGrantRoleDeleteDataParameters
    {
        private SqlParameter[] _parameters;
        private GBLGrantRole _grantrole;

        public GBLGrantRoleDeleteDataParameters(GBLGrantRole grantrole)
        {
            this._grantrole = grantrole;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter("@Grantroleid",GBLGrantRole.GRANTROLE_ID),
		    };

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public GBLGrantRole GBLGrantRole
        {
            get { return _grantrole; }
            set { _grantrole = value; }
        }
    }
}
