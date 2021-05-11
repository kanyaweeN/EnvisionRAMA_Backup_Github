using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRisRptRiskSystemReport : IBusinessLogic
    {
        public enum Catelogs
        {
            Statistic, RiskDetail, Summary, TopN
        }

        public Catelogs Catelog { get; set; }
        public int Mode { get; set; }
        public int TopN { get; set; }
        public int OrgId { get; set; }
        public DateTime FromDt { get; set; }
        public DateTime ToDt { get; set; }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRptRiskSystemReportSelect processor = new RisRptRiskSystemReportSelect();
            this.Result = processor.GetData(this.Catelog.ToString(), this.Mode, this.TopN, this.OrgId, this.FromDt, this.ToDt);
        }

        #endregion
    }
}
