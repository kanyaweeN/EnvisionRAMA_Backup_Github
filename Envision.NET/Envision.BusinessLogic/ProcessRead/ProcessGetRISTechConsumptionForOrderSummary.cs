using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISTechConsumptionForOrderSummary : IBusinessLogic
    {
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetRISTechConsumptionForOrderSummary()
        {
            this.RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RISTechConsumptionSelectForOrderSummary processor = new RISTechConsumptionSelectForOrderSummary();
            processor.RIS_TECHCONSUMPTION = this.RIS_TECHCONSUMPTION;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
