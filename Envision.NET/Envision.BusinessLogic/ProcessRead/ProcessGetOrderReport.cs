using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetOrderReport : IBusinessLogic
    {
        public string HN { get; set; }
        public int ORDER_ID { get; set; }
        public int ORG_ID { get; set; }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISOrderGetReport processor = new RISOrderGetReport();
            this.Result = processor.GetData(this.HN, this.ORDER_ID, this.ORG_ID);
        }

        #endregion
    }
}
