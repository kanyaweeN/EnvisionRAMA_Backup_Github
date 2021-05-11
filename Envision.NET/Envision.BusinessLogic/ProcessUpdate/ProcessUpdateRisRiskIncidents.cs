using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.DataAccess.Update;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRisRiskIncidents : IBusinessLogic
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessUpdateRisRiskIncidents()
        {
            this.RIS_RISKINCIDENTS = new RIS_RISKINCIDENTS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskIncidentsUpdate processor = new RisRiskIncidentsUpdate();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            if (this.Transaction == null)
                processor.UpdateData();
            else
                processor.UpdateData(Transaction);
        }
        public void UpdateOrderIdByScheduleId()
        {
            RisRiskIncidentsUpdate processor = new RisRiskIncidentsUpdate();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            if (this.Transaction == null)
                processor.UpdateOrderIdByScheduleId();
            else
                processor.UpdateOrderIdByScheduleId(Transaction);
        }
        #endregion
    }
}
