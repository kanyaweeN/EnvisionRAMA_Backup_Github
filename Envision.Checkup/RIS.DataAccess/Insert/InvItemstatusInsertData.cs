using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class InvItemstatusInsertData : DataAccessBase
    {
        INV_ITEMSTATUS common;

        public InvItemstatusInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ITEMSTATUS_Insert.ToString();
        }

        public void Insert()
        {
            InvItemstatusInsertData_Parameter param = new InvItemstatusInsertData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_ITEMSTATUS INV_ITEMSTATUS
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvItemstatusInsertData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_ITEMSTATUS common;

        public InvItemstatusInsertData_Parameter(INV_ITEMSTATUS _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                        {
                            new SqlParameter("@ITEMSTATUS_UID",common.ITEMSTATUS_UID),
                            new SqlParameter("@ITEMSTATUS_NAME",common.ITEMSTATUS_NAME),
                            //new SqlParameter("@ITEMTYPE_DESC",common.ITEMTYPE_DESC),
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
