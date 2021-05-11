using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGMassDominantCyst : IBusinessLogic
    {
        public MG_DOMINANT MG_MASSDOMINANTCYST { get; set; }
        public DbTransaction Transaction { get; set; }
        public bool UseTransaction { get; set; }

        public ProcessAddMGMassDominantCyst()
        {
            this.MG_MASSDOMINANTCYST = new MG_DOMINANT();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGDominantInsert processor = new MGDominantInsert();
            
            processor.MG_DOMINANT = this.MG_MASSDOMINANTCYST;
            if (this.UseTransaction)
                processor.Transaction = this.Transaction;
            processor.InsertData();
        }

        #endregion
    }
}
