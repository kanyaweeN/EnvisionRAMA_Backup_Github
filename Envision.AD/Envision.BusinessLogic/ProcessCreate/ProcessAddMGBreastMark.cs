using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGBreastMark : IBusinessLogic
    {
        public MG_BREASTMARK MG_BREASTMARK { get; set; }
        public bool UseTransaction { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddMGBreastMark()
        {
            this.MG_BREASTMARK = new MG_BREASTMARK();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkInsert processor = new MGBreastMarkInsert();
            processor.MG_BREASTMARK = this.MG_BREASTMARK;
            if (UseTransaction)
                processor.Trans = this.Transaction;
            processor.InsertData(UseTransaction);
        }

        #endregion
    }
}
