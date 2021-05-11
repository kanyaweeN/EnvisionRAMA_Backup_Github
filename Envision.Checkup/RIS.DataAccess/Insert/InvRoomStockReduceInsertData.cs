using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class InvRoomStockReduceInsertData : DataAccessBase
    {
        INV_ROOMSTOCKREDUCE common;

        public InvRoomStockReduceInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_INV_ROOMSTOCKREDUCE_Insert.ToString();
        }

        public void Insert()
        {
            InvRoomStockReduceInsertData_Parameter param = new InvRoomStockReduceInsertData_Parameter(common);
            DataBaseHelper dbhelper = new DataBaseHelper(this.StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString,param.SqlParameter);
        }

        public INV_ROOMSTOCKREDUCE INV_ROOMSTOCKREDUCE
        {
            get { return common; }
            set { common = value; }
        }
    }

    public class InvRoomStockReduceInsertData_Parameter
    {
        SqlParameter[] sqlparam;
        INV_ROOMSTOCKREDUCE common;

        public InvRoomStockReduceInsertData_Parameter(INV_ROOMSTOCKREDUCE _common)
        {
            common = _common;
            Build();
        }

        public void Build()
        {
            SqlParameter[] SqlParameter =  
                                {
                                    new SqlParameter("@ROOM_ID",common.ROOM_ID),
                                    new SqlParameter("@UNIT_ID",common.UNIT_ID),
                                    new SqlParameter("@SL_NO",common.SL_NO),
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
