using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGBreastMassDetails : IBusinessLogic
    {
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddMGBreastMassDetails()
        {
            this.MG_BREASTMASSDETAILS = new MG_BREASTMASSDETAILS();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMessDetailsInsert processor = new MGBreastMessDetailsInsert();
            processor.MG_BREASTMASSDETAILS = this.MG_BREASTMASSDETAILS;
            if (this.UseTransaction)
                processor.Trans = this.Transaction;
            processor.InsertData(UseTransaction);
        }

        #endregion
    }
}
