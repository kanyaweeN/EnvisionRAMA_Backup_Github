using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateMGBreastMark : IBusinessLogic
    {
        public MG_BREASTMARK MG_BREASTMARK { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateMGBreastMark()
        {
            this.MG_BREASTMARK = new MG_BREASTMARK();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkUpdate processor = new MGBreastMarkUpdate();
            processor.MG_BREASTMARK = this.MG_BREASTMARK;
            if (UseTransaction)
                processor.Trans = this.Transaction;
            processor.UpdateData(this.UseTransaction);
        }

        #endregion
    }
}
