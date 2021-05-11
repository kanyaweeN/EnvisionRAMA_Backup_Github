using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Update;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISScheduleSentToOrder : IBusinessLogic
    {
        public int SCHEDULE_ID { get; set; }
        public int ORG_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DbTransaction Transaction { get; set; }
        public int ORDER_ID { get; set; }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RISScheduleSendToOrder processor = new RISScheduleSendToOrder();
            processor.SCHEDULE_ID = this.SCHEDULE_ID;
            processor.LAST_MODIFIED_BY = this.LAST_MODIFIED_BY;
            processor.ORG_ID = this.ORG_ID;
            processor.ORDER_ID = this.ORDER_ID;
            if (this.Transaction == null)
                processor.SendToOrder();
            else
                processor.SendToOrder(Transaction);
        }

        #endregion
    }
}
