using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Delete;
using Envision.Common;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRisRiskIncidentUsers : IBusinessLogic
    {
        public RIS_RISKINCIDENTUSERS RIS_RISKINCIDENTUSERS { get; set; }
        public int Mode { get; set; }
        public ProcessDeleteRisRiskIncidentUsers()
        {
            this.RIS_RISKINCIDENTUSERS = new RIS_RISKINCIDENTUSERS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskIncidentUsersDelete processor = new RisRiskIncidentUsersDelete();
            processor.RIS_RISKINCIDENTUSERS = this.RIS_RISKINCIDENTUSERS;
            processor.DeleteData(Mode);
        }

        #endregion
    }
}
