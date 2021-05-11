using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvItemtypeDeleteData : DataAccessBase
    {
        INV_ITEMTYPE common;

        public InvItemtypeDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEMTYPE_Delete.ToString();
        }

        public void Delete()
        {
            InvItemtypeDeleteData_Parameter param = new InvItemtypeDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_ITEMTYPE INV_ITEMTYPE
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvItemtypeDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_ITEMTYPE common;

        public InvItemtypeDeleteData_Parameter(INV_ITEMTYPE _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@ITEMTYPE_ID",common.ITEMTYPE_ID),
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
