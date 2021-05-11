
using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvItemDeleteData : DataAccessBase
    {
        INV_ITEM common;

        public InvItemDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEM_Delete.ToString();
        }

        public void Delete()
        {
            InvItemDeleteData_Parameter param = new InvItemDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_ITEM INV_ITEM
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvItemDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_ITEM common;

        public InvItemDeleteData_Parameter(INV_ITEM _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@ITEM_ID",common.ITEM_ID),
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
