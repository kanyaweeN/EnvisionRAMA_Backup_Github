using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using Envision.Common;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISTechWorkForOrderSummary : IBusinessLogic
    {
        public RIS_TECHWORK RIS_TECHWORK { get; set; }
        public DataSet Result { get; set; }

        public ProcessGetRISTechWorkForOrderSummary()
        {
            this.RIS_TECHWORK = new RIS_TECHWORK();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RISTechWorksSelectForOrderSummary processor = new RISTechWorksSelectForOrderSummary();
            processor.RIS_TECHWORK = this.RIS_TECHWORK;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
