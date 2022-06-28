using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRisRiskIncidentUsers : IBusinessLogic
    {
        public RIS_RISKINCIDENTUSERS RIS_RISKINCIDENTUSERS { get; set; }
        public ProcessAddRisRiskIncidentUsers()
        {
            this.RIS_RISKINCIDENTUSERS = new RIS_RISKINCIDENTUSERS();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskIncidentUsersInsert processor = new RisRiskIncidentUsersInsert();
            processor.RIS_RISKINCIDENTUSERS = this.RIS_RISKINCIDENTUSERS;
            processor.InsertData();
        }

        #endregion
    }
}
