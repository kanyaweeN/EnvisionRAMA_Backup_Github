using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISScheduleSendToOrder : DataAccessBase
    {
        public int SCHEDULE_ID { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public int ORDER_ID { get; set; }

        public RISScheduleSendToOrder()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SendToOrder; 
        }
        public void SendToOrder(DbTransaction tran)
        {
            Transaction = tran;
            SendToOrder();
        }
        public void SendToOrder()
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@SCHEDULE_ID", SCHEDULE_ID),
                Parameter("@ORG_ID", ORG_ID),
                Parameter("@LAST_MODIFIED_BY", LAST_MODIFIED_BY),
                Parameter("@ORDER_ID", ORDER_ID)
            };
            this.ExecuteNonQuery();
        }
    }
}
