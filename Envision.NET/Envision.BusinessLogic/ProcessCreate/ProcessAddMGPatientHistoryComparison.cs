using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGPatientHistoryComparison : IBusinessLogic
    {
        public MG_PATIENTHISTORYCOMPARISON MG_PATIENTHISTORYCOMPARISON { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddMGPatientHistoryComparison()
        {
            this.MG_PATIENTHISTORYCOMPARISON = new MG_PATIENTHISTORYCOMPARISON();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGPatientHistoryComparisonInsert processor = new MGPatientHistoryComparisonInsert();
            processor.MG_PATIENTHISTORYCOMPARISON = this.MG_PATIENTHISTORYCOMPARISON;
            if (this.UseTransaction)
                processor.Trans = this.Transaction;
            processor.InsertData(UseTransaction);
        }

        #endregion
    }
}
