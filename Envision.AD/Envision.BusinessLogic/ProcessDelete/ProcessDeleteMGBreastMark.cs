using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteMGBreastMark : IBusinessLogic
    {
        public MG_BREASTMARK MG_BREASTMARK { get; set; }
        public bool UserTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteMGBreastMark()
        {
            this.MG_BREASTMARK = new MG_BREASTMARK();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkDelete processor = new MGBreastMarkDelete();
            processor.MG_BREASTMARK = this.MG_BREASTMARK;
            if (UserTransaction)
                processor.Trans = this.Transaction;
            processor.DeleteData(UserTransaction);
        }

        #endregion
    }
}
