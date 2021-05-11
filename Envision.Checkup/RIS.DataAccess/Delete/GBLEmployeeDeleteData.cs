using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;
using RIS.DataAccess.Delete;
using RIS.Common.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLEmployeeDeleteData : DataAccessBase
    {
        GBLEmployee _gbelemp;

        public GBLEmployeeDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLEmployee_DeleteAccount.ToString();
        }

        public void Delete()
        {
            GBLEmployeeDeleteParameter parameters = new GBLEmployeeDeleteParameter(GBLEmployee);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(base.ConnectionString, parameters.Parameters);
        }

        public GBLEmployee GBLEmployee
        {
            get { return _gbelemp; }
            set { _gbelemp = value; }
        }
    }

    public class GBLEmployeeDeleteParameter
    {
        GBLEmployee gblemp;
        SqlParameter[] _parameters;

        public GBLEmployeeDeleteParameter(GBLEmployee gblemp)
        {
            this.gblemp = gblemp;
            Build();
        }

        public void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@EmpID"	, this.gblemp.Emp_ID )
		    };

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
