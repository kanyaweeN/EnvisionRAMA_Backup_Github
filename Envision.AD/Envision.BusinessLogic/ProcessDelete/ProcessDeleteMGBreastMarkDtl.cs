using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteMGBreastMarkDtl : IBusinessLogic
    {
        public MG_BREASTMARKDTL MG_BREASTMARKDTL { get; set; }
        public int Mode { get; set; }
        public bool UserTransaction { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessDeleteMGBreastMarkDtl()
        {
            this.MG_BREASTMARKDTL = new MG_BREASTMARKDTL();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkDtlDelete processor = new MGBreastMarkDtlDelete();
            processor.MG_BREASTMARKDTL = this.MG_BREASTMARKDTL;
            if (UserTransaction)
                processor.Trans = this.Transaction;
            processor.DeleteData(this.UserTransaction, this.Mode);
        }

        #endregion
    }
}
