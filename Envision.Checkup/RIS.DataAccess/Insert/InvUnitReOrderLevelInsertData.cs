using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class InvUnitReOrderLevelInsertData : DataAccessBase
    {
        INV_UNITREORDERLEVEL common;

        public InvUnitReOrderLevelInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_UNITREORDERLEVEL_Insert.ToString();
        }

        public void Insert()
        {
            InvUnitReOrderLevelInsertData_Parameter param = new InvUnitReOrderLevelInsertData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_UNITREORDERLEVEL INV_UNITREORDERLEVEL
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvUnitReOrderLevelInsertData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_UNITREORDERLEVEL common;

        public InvUnitReOrderLevelInsertData_Parameter(INV_UNITREORDERLEVEL _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                            {
                                new SqlParameter("@UNIT_ID",common.UNIT_ID),
                                new SqlParameter("@ITEM_ID",common.ITEM_ID),
                                new SqlParameter("@REORDER_DAYS",common.REORDER_DAYS),
                                new SqlParameter("@REORDER_QTY",common.REORDER_QTY),
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
