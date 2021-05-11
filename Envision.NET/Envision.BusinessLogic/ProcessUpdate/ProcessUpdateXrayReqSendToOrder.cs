using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Update;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateXrayReqSendToOrder : IBusinessLogic
    {
        public int ORDER_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public int ORG_ID { get; set; }
        public DbTransaction Transaction { get; set; }
        public int XRAY_ID { get; set; }

        public int EXAM_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        #region IBusinessLogic Members

        public void Invoke()
        {
            XrayReqSendToOrder processor = new XrayReqSendToOrder();
            if(this.Transaction != null)
                processor.Transaction = this.Transaction;
            processor.SendToOrder(this.ORDER_ID, this.LAST_MODIFIED_BY, this.ORG_ID, this.XRAY_ID);
        }

        public void UpdateAccession()
        {
            XrayReqSendToOrder processor = new XrayReqSendToOrder();
            if (this.Transaction != null)
                processor.Transaction = this.Transaction;
            processor.UpdateAccession(this.XRAY_ID,this.EXAM_ID,this.ACCESSION_NO, this.LAST_MODIFIED_BY, this.ORG_ID);
        }
        #endregion
    }
}
