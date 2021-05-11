using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class InvItemstatusDeleteData : DataAccessBase
    {
        INV_ITEMSTATUS common;

        public InvItemstatusDeleteData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEMSTATUS_Delete.ToString();
        }

        public void Delete()
        {
            InvItemstatusDeleteData_Parameter param = new InvItemstatusDeleteData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, param.SqlParameter);
        }

        public INV_ITEMSTATUS INV_ITEMSTATUS
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvItemstatusDeleteData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_ITEMSTATUS common;

        public InvItemstatusDeleteData_Parameter(INV_ITEMSTATUS _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@ITEMSTATUS_ID",common.ITEMSTATUS_ID),
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
