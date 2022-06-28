using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteMGBreastUSMassDetails : IBusinessLogic
    {
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteMGBreastUSMassDetails()
        {
            this.MG_BREASTUSMASSDETAILS = new MG_BREASTUSMASSDETAILS();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastUSMassDetailsDelete processor = new MGBreastUSMassDetailsDelete();
            processor.MG_BREASTUSMASSDETAILS = this.MG_BREASTUSMASSDETAILS;
            if (this.UseTransaction)
                processor.Transaction = this.Transaction;
            processor.DeleteData();
        }

        #endregion
    }
}
