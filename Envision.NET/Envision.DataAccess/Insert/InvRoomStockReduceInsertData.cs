using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvRoomStockReduceInsertData : DataAccessBase
    {
        public INV_ROOMSTOCKREDUCE INV_ROOMSTOCKREDUCE { get; set; }

        public InvRoomStockReduceInsertData()
        {
            INV_ROOMSTOCKREDUCE = new INV_ROOMSTOCKREDUCE();
            this.StoredProcedureName = StoredProcedure.Prc_INV_ROOMSTOCKREDUCE_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                                    Parameter("@ROOM_ID",INV_ROOMSTOCKREDUCE.ROOM_ID),
                                    Parameter("@UNIT_ID",INV_ROOMSTOCKREDUCE.UNIT_ID),
                                    Parameter("@SL_NO",INV_ROOMSTOCKREDUCE.SL_NO),
                                    Parameter("@ORG_ID",INV_ROOMSTOCKREDUCE.ORG_ID),
			            };
            return parameters;
        }

    }
}
