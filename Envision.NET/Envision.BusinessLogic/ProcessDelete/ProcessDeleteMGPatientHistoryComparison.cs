using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteMGPatientHistoryComparison : IBusinessLogic
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }
        public DbTransaction Transaction { get; set; }
        public bool UseTransaction { get; set; }
        public ProcessDeleteMGPatientHistoryComparison()
        {
            this.MG_PATIENTHISTORYCOMPARISON = new MG_PATIENTHISTORYCOMPARISON();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGPatientHistoryComparisonDelete processor = new MGPatientHistoryComparisonDelete();
            processor.MG_PATIENTHISTORYCOMPARISON = this.MG_PATIENTHISTORYCOMPARISON;
            if (this.UseTransaction)
                processor.Transaction = this.Transaction;
            processor.DeleteData();
        }

        #endregion
    }
}
