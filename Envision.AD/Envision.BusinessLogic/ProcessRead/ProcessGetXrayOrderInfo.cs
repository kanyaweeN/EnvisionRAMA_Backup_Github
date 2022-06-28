using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetXrayOrderInfo : IBusinessLogic
    {
        public int ORG_ID { get; set; }
        public int ORDER_ID { get; set; }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            XrayOrderInfoSelect processor = new XrayOrderInfoSelect();
            this.Result = processor.GetOrderInfo(this.ORDER_ID, this.ORG_ID);
        }

        #endregion
    }
}
