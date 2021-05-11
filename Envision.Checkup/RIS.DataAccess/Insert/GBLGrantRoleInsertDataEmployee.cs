using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLGrantRoleInsertDataEmployee :DataAccessBase
    {
        private GBLGrantRole _grantrole;

        public GBLGrantRoleInsertDataEmployee()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLGrantRole_InsertByEmployee.ToString();
        }

        public void Get()
        {
            GBLGrantRoleInsertDataEmployeeParameters _GBLGrantRoleInsertDataParameters
                = new GBLGrantRoleInsertDataEmployeeParameters(this.GBLGrantRole);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLGrantRoleInsertDataParameters.Parameters);
        }

        public GBLGrantRole GBLGrantRole
        {
            get { return _grantrole; }
            set { _grantrole = value; }
        }
    }

    public class GBLGrantRoleInsertDataEmployeeParameters
    {
        private SqlParameter[] _parameters;
        private GBLGrantRole _grantrole;

        public GBLGrantRoleInsertDataEmployeeParameters(GBLGrantRole grantrole)
        {
            this._grantrole = grantrole;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter("Roleid"   ,GBLGrantRole.ROLE_ID),
                new SqlParameter("Empid"    ,GBLGrantRole.EMP_ID),
                new SqlParameter("Grantor"  ,GBLGrantRole.GRANTOR),
                new SqlParameter("Orgid"   ,GBLGrantRole.OrgID),
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
