using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRisRiskIncidents : IBusinessLogic
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }
        public ProcessDeleteRisRiskIncidents()
        {
            this.RIS_RISKINCIDENTS = new RIS_RISKINCIDENTS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskIncidentsDelete processor = new RisRiskIncidentsDelete();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            processor.DeleteData();
        }

        #endregion
        public void DeleteRegID()
        {
            RisRiskIncidentsDelete processor = new RisRiskIncidentsDelete();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            processor.DeleteRegID();
        }
        public void DeleteOrderID()
        {
            RisRiskIncidentsDelete processor = new RisRiskIncidentsDelete();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            processor.DeleteOrderID();
        }
        public void DeleteScheduleID()
        {
            RisRiskIncidentsDelete processor = new RisRiskIncidentsDelete();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            processor.DeleteScheduleID();
        }
        public void DeleteXrayreqID()
        {
            RisRiskIncidentsDelete processor = new RisRiskIncidentsDelete();
            processor.RIS_RISKINCIDENTS = this.RIS_RISKINCIDENTS;
            processor.DeleteXrayreqID();
        }
    }
}
