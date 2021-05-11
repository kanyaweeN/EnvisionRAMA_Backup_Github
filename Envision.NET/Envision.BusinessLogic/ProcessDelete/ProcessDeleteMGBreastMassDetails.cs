using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteMGBreastMassDetails : IBusinessLogic
    {
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }
        public DbTransaction Transaction { get; set; }
        public bool UseTransaction { get; set; }
        public ProcessDeleteMGBreastMassDetails()
        {
            this.MG_BREASTMASSDETAILS = new MG_BREASTMASSDETAILS();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMassDetailsDelete processor = new MGBreastMassDetailsDelete();
            processor.MG_BREASTMASSDETAILS = this.MG_BREASTMASSDETAILS;
            if (this.UseTransaction)
                processor.Transaction = this.Transaction;
            processor.DeleteData();
        }

        #endregion
    }
}
