using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class GBLGrantRoleUpdateDataISDeleted :DataAccessBase
    {
        private GBLGrantRole _grantrole;

        public GBLGrantRoleUpdateDataISDeleted()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLGrantRole_UpdateISDeleted.ToString();
        }

        public void Get()
        {
            GBLGrantRoleUpdateDataParametersISDeleted _GBLGrantRoleUpdateDataParameters
                = new GBLGrantRoleUpdateDataParametersISDeleted(this.GBLGrantRole);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLGrantRoleUpdateDataParameters.Parameters);
        }

        public GBLGrantRole GBLGrantRole
        {
            get { return _grantrole; }
            set { _grantrole = value; }
        }
    }

    public class GBLGrantRoleUpdateDataParametersISDeleted
    {
        private SqlParameter[] _parameters;
        private GBLGrantRole _grantrole;

        public GBLGrantRoleUpdateDataParametersISDeleted(GBLGrantRole grantrole)
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
