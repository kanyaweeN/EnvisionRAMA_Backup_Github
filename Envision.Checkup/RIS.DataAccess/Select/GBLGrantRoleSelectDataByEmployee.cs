using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class GBLGrantRoleSelectDataByEmployee : DataAccessBase
    {
        private DataSet _dataset;
        private GBLGrantRole _gblgrantrole;
        public GBLGrantRoleSelectDataByEmployee()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLGrantRole_SelectByEmployee.ToString();
        }
        public DataSet Get()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            GBLGrantRoleSelectDataByEmployeeParameter para = new GBLGrantRoleSelectDataByEmployeeParameter(GBLGrantRole);
            _dataset = dbhelper.Run(base.ConnectionString,para.Parameter);
            return _dataset;
        }
        public GBLGrantRole GBLGrantRole
        {
            get { return _gblgrantrole; }
            set { _gblgrantrole = value; }
        }
    }
    public class GBLGrantRoleSelectDataByEmployeeParameter
    {
        private SqlParameter[] _parameter;
        private GBLGrantRole _gblgrantrole;

        public GBLGrantRoleSelectDataByEmployeeParameter(GBLGrantRole gblgrantrole)
        {
            this._gblgrantrole = gblgrantrole;
            Build();
        }
        private void Build()
        {
            SqlParameter[] parameter =  
            {                                   
                new SqlParameter("@Empid",_gblgrantrole.EMP_ID),
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
