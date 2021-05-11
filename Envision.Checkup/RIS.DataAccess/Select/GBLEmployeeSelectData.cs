using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;
using RIS.DataAccess.Select;


namespace RIS.DataAccess.Select
{
    public class GBLEmployeeSelectData : DataAccessBase
    {
        private GBLEmployee _employee;

        public GBLEmployeeSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLEmployee_GetAccount.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            GBLEmployeeSelectDataParameters _parameter = new GBLEmployeeSelectDataParameters(GBLEmployee);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString,_parameter.Parameters);

            return ds;
        }

        public GBLEmployee GBLEmployee
        {
            get { return _employee; }
            set { _employee = value; }
        }
    }

    public class GBLEmployeeSelectDataParameters
    {
        private GBLEmployee _employee;
        private SqlParameter[] _parameters;

        public GBLEmployeeSelectDataParameters(GBLEmployee employee)
        {
            _employee = employee;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameter = 
            {
                new SqlParameter("@Authlevelid", GBLEmployee.Auth_Level_ID),
                new SqlParameter("@Unitid",GBLEmployee.Unit_ID)
            };

            Parameters = parameter;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public GBLEmployee GBLEmployee
        {
            get { return _employee; }
            set { _employee = value; }
        }
    }


}
