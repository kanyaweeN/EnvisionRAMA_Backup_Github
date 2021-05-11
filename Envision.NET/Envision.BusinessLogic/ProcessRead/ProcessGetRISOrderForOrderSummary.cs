using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISOrderForOrderSummary : IBusinessLogic
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public DataSet Result { get; set; }

        public ProcessGetRISOrderForOrderSummary()
        {
            this.RIS_ORDERDTL = new RIS_ORDERDTL();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISOrderSelectForOrderSummary processor = new RISOrderSelectForOrderSummary();
            processor.RIS_ORDERDTL = this.RIS_ORDERDTL;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
