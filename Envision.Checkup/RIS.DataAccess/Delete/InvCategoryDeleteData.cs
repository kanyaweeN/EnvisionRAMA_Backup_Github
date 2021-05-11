using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvCategoryDeleteData : DataAccessBase
    {
        INV_CATEGORY common;

        public InvCategoryDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_CATEGORY_Delete.ToString();
        }

        public void Delete()
        {
            InvCategoryDeleteData_Parameter param = new InvCategoryDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_CATEGORY INV_CATEGORY
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvCategoryDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_CATEGORY common;

        public InvCategoryDeleteData_Parameter(INV_CATEGORY _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@CATEGORY_ID",common.CATEGORY_ID),
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
