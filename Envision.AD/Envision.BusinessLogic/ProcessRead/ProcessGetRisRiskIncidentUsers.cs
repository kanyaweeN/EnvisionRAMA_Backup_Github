using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRisRiskIncidentUsers : IBusinessLogic
    {
        public RIS_RISKINCIDENTUSERS RIS_RISKINCIDENTUSERS { get; set; }
        public int Mode { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetRisRiskIncidentUsers()
        {
            this.RIS_RISKINCIDENTUSERS = new RIS_RISKINCIDENTUSERS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskIncidentUsersSelect processor = new RisRiskIncidentUsersSelect();
            processor.RIS_RISKINCIDENTUSERS = this.RIS_RISKINCIDENTUSERS;
            this.Result = processor.GetData(Mode);
        }

        #endregion
    }
}
