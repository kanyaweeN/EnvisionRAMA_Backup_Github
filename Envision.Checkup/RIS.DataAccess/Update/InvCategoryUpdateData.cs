using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvCategoryUpdateData : DataAccessBase
    {
        INV_CATEGORY common;

        public InvCategoryUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_CATEGORY_Update.ToString();
        }

        public void Update()
        {
            InvCategoryUpdateData_Parameter param = new InvCategoryUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_CATEGORY INV_CATEGORY
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvCategoryUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_CATEGORY common;

        public InvCategoryUpdateData_Parameter(INV_CATEGORY _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                                new SqlParameter("@CATEGORY_ID",common.CATEGORY_ID),
                                new SqlParameter("@CATEGORY_UID",common.CATEGORY_UID),
                                new SqlParameter("@CATEGORY_NAME",common.CATEGORY_NAME),
                                new SqlParameter("@CATEGORY_DESC",common.CATEGORY_DESC),
                                new SqlParameter("@ORG_ID",common.ORG_ID),
                                new SqlParameter("@PARENT",common.PARENT),
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
