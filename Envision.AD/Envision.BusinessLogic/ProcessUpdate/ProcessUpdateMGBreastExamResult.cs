using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateMGBreastExamResult : IBusinessLogic
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateMGBreastExamResult()
        {
            this.MG_BREASTEXAMRESULT = new MG_BREASTEXAMRESULT();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastExamResultUpdate processor = new MGBreastExamResultUpdate();
            processor.MG_BREASTEXAMRESULT = this.MG_BREASTEXAMRESULT;
            if (this.UseTransaction)
                processor.Transaction = this.Transaction;
            processor.UpdateData(UseTransaction);
        }

        #endregion
    }
}
