using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRisRiskIncidents : IBusinessLogic
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }
        public ProcessAddRisRiskIncidents()
        {
            this.RIS_RISKINCIDENTS = new RIS_RISKINCIDENTS();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskIncidentsInsert processor = new RisRiskIncidentsInsert();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            processor.InsertData();
        }

        #endregion
    }
}
