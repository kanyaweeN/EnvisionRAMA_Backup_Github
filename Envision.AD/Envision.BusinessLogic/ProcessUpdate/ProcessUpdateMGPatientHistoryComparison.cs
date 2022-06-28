using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateMGPatientHistoryComparison : IBusinessLogic
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }

        public ProcessUpdateMGPatientHistoryComparison()
        {
            this.MG_PATIENTHISTORYCOMPARISON = new MG_PATIENTHISTORYCOMPARISON();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGPatientHistoryComparisonUpdate processor = new MGPatientHistoryComparisonUpdate();
            processor.MG_PATIENTHISTORYCOMPARISON = this.MG_PATIENTHISTORYCOMPARISON;
            processor.UpdateData();
        }

        #endregion
    }
}
