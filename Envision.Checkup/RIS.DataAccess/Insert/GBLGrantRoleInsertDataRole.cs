using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLGrantRoleInsertDataRole :DataAccessBase
    {
        private GBLGrantRole _grantrole;

        public GBLGrantRoleInsertDataRole()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLGrantRole_InsertByRole.ToString();
        }

        public void Get()
        {
            GBLGrantRoleInsertDataParametersRole _GBLGrantRoleInsertDataParameters
                = new GBLGrantRoleInsertDataParametersRole(this.GBLGrantRole);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _GBLGrantRoleInsertDataParameters.Parameters);
        }

        public GBLGrantRole GBLGrantRole
        {
            get { return _grantrole; }
            set { _grantrole = value; }
        }
    }

    public class GBLGrantRoleInsertDataParametersRole
    {
        private SqlParameter[] _parameters;
        private GBLGrantRole _grantrole;

        public GBLGrantRoleInsertDataParametersRole(GBLGrantRole grantrole)
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
                new SqlParameter("Cangrant" ,GBLGrantRole.CAN_GRANT),
                new SqlParameter("Grantor"  ,GBLGrantRole.GRANTOR),
                new SqlParameter("Grantdt"  ,GBLGrantRole.GRANT_DT),
                new SqlParameter("Isupdated",GBLGrantRole.IsUpdated),
                new SqlParameter("Isdeleted",GBLGrantRole.IsDeleted),
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
