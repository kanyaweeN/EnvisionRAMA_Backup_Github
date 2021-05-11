using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvVendorDeleteData : DataAccessBase
    {
        INV_VENDOR common;

        public InvVendorDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_VENDOR_Delete.ToString();
        }

        public void Delete()
        {
            InvVendorDeleteData_Parameter param = new InvVendorDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_VENDOR INV_VENDOR
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvVendorDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_VENDOR common;

        public InvVendorDeleteData_Parameter(INV_VENDOR _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@VENDOR_ID",common.VENDOR_ID),
                        };
            sqlparam = SqlParameter;
        }

        public SqlParameter[] SqlParameter
        {
            get { return sqlparam; }
            set { sqlparam = value; }
        }

    }
}
