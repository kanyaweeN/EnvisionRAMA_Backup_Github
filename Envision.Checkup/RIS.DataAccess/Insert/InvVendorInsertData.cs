using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class InvVendorInsertData : DataAccessBase
    {
        INV_VENDOR common;

        public InvVendorInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_VENDOR_Insert.ToString();
        }

        public void Insert()
        {
            InvVendorInsertData_Parameter param = new InvVendorInsertData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_VENDOR INV_VENDOR
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvVendorInsertData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_VENDOR common;

        public InvVendorInsertData_Parameter(INV_VENDOR _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@VENDOR_UID",common.VENDOR_UID),
                            new SqlParameter("@VENDOR_NAME",common.VENDOR_NAME),
                            new SqlParameter("@ORG_ID",common.ORG_ID),
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
