using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISOrderClinicalIndicationUpdateData : DataAccessBase
    {
        public int XRAY_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int ORG_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }

        public RISOrderClinicalIndicationUpdateData()
        {
        }
        public void UpdateOrderClinicalIndicationICDByOrderId(DbTransaction tran)
        {
            Transaction = tran;
            UpdateOrderClinicalIndicationICDByOrderId();
        }
        public void UpdateOrderClinicalIndicationICDByOrderId()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDERCLINICALINICATION_AND_ICD_UpdateOrderId;
            DbParameter[] parameters = { 
                                            Parameter("@XRAY_ID", this.XRAY_ID),
                                            Parameter("@ORDER_ID", this.ORDER_ID),
                                            Parameter("@ORG_ID", this.ORG_ID),
                                       };

            this.ParameterList = parameters;
            this.ExecuteNonQuery();
        }
        public void UpdateByScheduleId(DbTransaction tran)
        {
            Transaction = tran;
            UpdateByScheduleId();
        }
        public void UpdateByScheduleId()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDERCLINICALINICATION_UpdateOrderIdByScheduleId;
            DbParameter[] parameters = { 
                                            Parameter("@SCHEDULE_ID", this.SCHEDULE_ID),
                                            Parameter("@ORG_ID", this.ORG_ID),
                                            Parameter("@LAST_MODIFIED_BY", this.LAST_MODIFIED_BY),
                                            Parameter("@ORDER_ID", this.ORDER_ID),
                                       };

            this.ParameterList = parameters;
            this.ExecuteNonQuery();
        }
    }
}