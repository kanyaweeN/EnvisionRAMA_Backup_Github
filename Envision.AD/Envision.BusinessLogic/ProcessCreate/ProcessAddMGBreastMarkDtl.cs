using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGBreastMarkDtl : IBusinessLogic
    {
        public MG_BREASTMARKDTL MG_BREASTMARKDTL { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddMGBreastMarkDtl()
        {
            this.MG_BREASTMARKDTL = new MG_BREASTMARKDTL();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkDtlInsert processor = new MGBreastMarkDtlInsert();
            processor.MG_BREASTMARKDTL = this.MG_BREASTMARKDTL;
            if (UseTransaction)
                processor.Trans = Transaction;
            processor.InsertData(UseTransaction);
        }

        #endregion
    }
}
