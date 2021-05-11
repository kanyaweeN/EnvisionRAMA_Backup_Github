using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISOrderLast3Orders : IBusinessLogic
    {
        public int REG_ID { get; set; }
        public int ORG_ID { get; set; }
        public DataSet Result { get; set; }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RISOrderLast3OrderSelect processor = new RISOrderLast3OrderSelect();
            this.Result = processor.GetData(this.REG_ID, this.ORG_ID);
        }

        #endregion
    }
}
