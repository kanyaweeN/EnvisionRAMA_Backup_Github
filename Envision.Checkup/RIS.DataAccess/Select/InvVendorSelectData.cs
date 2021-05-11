using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class InvVendorSelectData : DataAccessBase
    {
        INV_VENDOR common;

        public InvVendorSelectData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_VENDOR_Select.ToString();
        }

        public DataSet Query()
        {
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            DataSet ds = dbhelper.Run(this.ConnectionString);
            return ds;
        }
    }

    //public class INV_VENDOR_SelectData_Parameter
    //{
    //    SqlParameter[] sqlparam;

    //    public INV_VENDOR_SelectData_Parameter()
    //    {

    //        Build();
    //    }

    //    public void Build()
    //    {

    //    }

    //    public SqlParameter[] SqlParameter
    //    {
    //        get { return sqlparam; }
    //        set { sqlparam = value; }
    //    }

    //}
}
