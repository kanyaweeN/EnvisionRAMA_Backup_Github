using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class InvCategoryInsertData : DataAccessBase
    {
        INV_CATEGORY common;

        public InvCategoryInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_CATEGORY_Insert.ToString();
        }

        public void Insert()
        {
            InvCategoryInsertData_Parameter param = new InvCategoryInsertData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_CATEGORY INV_CATEGORY
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvCategoryInsertData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_CATEGORY common;

        public InvCategoryInsertData_Parameter(INV_CATEGORY _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@VENDOR_UID",common.CATEGORY_UID),
                            new SqlParameter("@VENDOR_NAME",common.CATEGORY_NAME),
                            new SqlParameter("@CATEGORY_DESC",common.CATEGORY_DESC),
                            new SqlParameter("@PARENT",common.PARENT),
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
