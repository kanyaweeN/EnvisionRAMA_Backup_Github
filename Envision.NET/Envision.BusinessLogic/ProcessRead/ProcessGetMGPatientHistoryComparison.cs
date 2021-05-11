using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetMGPatientHistoryComparison : IBusinessLogic
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }
        public int Mode { get; set; }
        public DataSet Result { get; set; }

        public ProcessGetMGPatientHistoryComparison()
        {
            this.MG_PATIENTHISTORYCOMPARISON = new MG_PATIENTHISTORYCOMPARISON();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGPatientStoryComparisonSelect processor = new MGPatientStoryComparisonSelect();
            processor.MG_PATIENTHISTORYCOMPARISON = this.MG_PATIENTHISTORYCOMPARISON;
            this.Result = processor.GetData(this.Mode);
        }

        #endregion
    }
}
