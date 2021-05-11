using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISOrderClinicalIndication : IBusinessLogic
    {
        public int XRAY_ID { get; set; }
        public int ORDER_ID { get; set; }
        public int ORG_ID { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DbTransaction Transaction { get; set; }

        #region IBusinessLogic Members
        public void Invoke()
        {
        }
        public void UpdateOrderClinicalIndicationICDByOrderId()
        {
            RISOrderClinicalIndicationUpdateData processor = new RISOrderClinicalIndicationUpdateData();
            processor.ORDER_ID = this.ORDER_ID;
            processor.ORG_ID = this.ORG_ID;
            processor.XRAY_ID = this.XRAY_ID;
            if (this.Transaction != null)
                processor.Transaction = this.Transaction;
            if (this.Transaction == null)
                processor.UpdateOrderClinicalIndicationICDByOrderId();
            else
                processor.UpdateOrderClinicalIndicationICDByOrderId(Transaction);

        }
        public void UpdateByScheduleId()
        {
            RISOrderClinicalIndicationUpdateData processor = new RISOrderClinicalIndicationUpdateData();
            processor.ORDER_ID = this.ORDER_ID;
            processor.ORG_ID = this.ORG_ID;
            processor.SCHEDULE_ID = this.SCHEDULE_ID;
            processor.LAST_MODIFIED_BY = this.LAST_MODIFIED_BY;
            if (this.Transaction == null)
                processor.UpdateByScheduleId();
            else
                processor.UpdateByScheduleId(Transaction);
        }
        #endregion
    }
}