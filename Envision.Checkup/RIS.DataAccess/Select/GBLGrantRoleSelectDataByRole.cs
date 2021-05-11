using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class GBLGrantRoleSelectDataByRole : DataAccessBase
    {
        private DataSet _dataset;
        private GBLGrantRole _gblgrantrole;
        public GBLGrantRoleSelectDataByRole()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLGrantRole_SelectByRole.ToString();
        }
        public DataSet Get()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            GBLGrantRoleSelectDataParameterByRole para = new GBLGrantRoleSelectDataParameterByRole(GBLGrantRole);
            _dataset = dbhelper.Run(base.ConnectionString,para.Parameter);
            return _dataset;
        }
        public GBLGrantRole GBLGrantRole
        {
            get { return _gblgrantrole; }
            set { _gblgrantrole = value; }
        }
    }
    public class GBLGrantRoleSelectDataParameterByRole
    {
        private SqlParameter[] _parameter;
        private GBLGrantRole _gblgrantrole;

        public GBLGrantRoleSelectDataParameterByRole(GBLGrantRole gblgrantrole)
        {
            _gblgrantrole = gblgrantrole;
            Build();
        }
        public void Build()
        {
            SqlParameter[] parameter = 
            {
                new SqlParameter("@Roleid",_gblgrantrole.ROLE_ID),
            };
            Parameter = parameter;
        }
        public SqlParameter[] Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
        }
    }
}
