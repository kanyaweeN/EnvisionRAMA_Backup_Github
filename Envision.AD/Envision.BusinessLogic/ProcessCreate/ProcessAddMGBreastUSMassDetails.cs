using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGBreastUSMassDetails : IBusinessLogic
    {
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddMGBreastUSMassDetails()
        {
            this.MG_BREASTUSMASSDETAILS = new MG_BREASTUSMASSDETAILS();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastUSMassDetailsInsert processor = new MGBreastUSMassDetailsInsert();
            processor.MG_BREASTUSMASSDETAILS = this.MG_BREASTUSMASSDETAILS;
            if (this.UseTransaction)
                processor.Trans = this.Transaction;
            processor.InsertData(UseTransaction);
        }

        #endregion
    }
}
