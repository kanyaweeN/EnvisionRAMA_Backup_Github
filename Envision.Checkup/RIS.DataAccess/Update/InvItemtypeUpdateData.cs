using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class InvItemtypeUpdateData : DataAccessBase
    {
        INV_ITEMTYPE common;

        public InvItemtypeUpdateData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEMTYPE_Update.ToString();
        }

        public void Update()
        {
            InvItemtypeUpdateData_Parameter param = new InvItemtypeUpdateData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_ITEMTYPE INV_ITEMTYPE
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvItemtypeUpdateData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_ITEMTYPE common;

        public InvItemtypeUpdateData_Parameter(INV_ITEMTYPE _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                                new SqlParameter("@ITEMTYPE_ID",common.ITEMTYPE_ID),
                                new SqlParameter("@ITEMTYPE_UID",common.ITEMTYPE_UID),
                                new SqlParameter("@ITEMTYPE_NAME",common.ITEMTYPE_NAME),
                                new SqlParameter("@ITEMTYPE_DESC",common.ITEMTYPE_DESC),
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
