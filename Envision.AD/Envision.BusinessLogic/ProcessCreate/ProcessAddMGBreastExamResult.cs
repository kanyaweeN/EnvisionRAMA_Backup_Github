using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGBreastExamResult : IBusinessLogic
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddMGBreastExamResult()
        {
            this.MG_BREASTEXAMRESULT = new MG_BREASTEXAMRESULT();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastExamResultInsert processor = new MGBreastExamResultInsert();
            processor.MG_BREASTEXAMRESULT = this.MG_BREASTEXAMRESULT;
            if (this.UseTransaction)
                processor.Trans = this.Transaction;
            processor.InsertData(UseTransaction);
        }

        #endregion
    }
}
