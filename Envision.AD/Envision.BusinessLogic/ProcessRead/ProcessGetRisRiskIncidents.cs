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
    public class ProcessGetRisRiskIncidents : IBusinessLogic
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }
        public int Mode { get; set; }
        public DataSet Result { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public ProcessGetRisRiskIncidents()
        {
            this.RIS_RISKINCIDENTS = new RIS_RISKINCIDENTS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskIncidentsSelect processor = new RisRiskIncidentsSelect();
            processor.RIS_RISKINCIDENTS = RIS_RISKINCIDENTS;
            this.Result = processor.GetData(Mode, From, To);
        }
        public DataTable getDataByRegID()
        {
            RisRiskIncidentsSelect processor = new RisRiskIncidentsSelect();
            processor.RIS_RISKINCIDENTS = RIS_RISKINCIDENTS;
            return processor.getDataByRegID();
        }

        public DataTable getDataByScheduleID()
        {
            RisRiskIncidentsSelect processor = new RisRiskIncidentsSelect();
            processor.RIS_RISKINCIDENTS = RIS_RISKINCIDENTS;
            return processor.getDataByScheduleID();
        }
        public DataTable getDataByOrderID()
        {
            RisRiskIncidentsSelect processor = new RisRiskIncidentsSelect();
            processor.RIS_RISKINCIDENTS = RIS_RISKINCIDENTS;
            return processor.getDataByOrderID();
        }
        public DataTable getDataByXrayReqID()
        {
            RisRiskIncidentsSelect processor = new RisRiskIncidentsSelect();
            processor.RIS_RISKINCIDENTS = RIS_RISKINCIDENTS;
            return processor.getDataByXrayReqID();
        }
        #endregion
    }
}
