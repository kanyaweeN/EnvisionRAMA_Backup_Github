using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISCommentOnPatient : IBusinessLogic
    {
        public RIS_COMMENTSONPATIENT RIS_COMMENTSONPATIENT { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessUpdateRISCommentOnPatient()
        {
            this.RIS_COMMENTSONPATIENT = new RIS_COMMENTSONPATIENT();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RIS_COMMENTONPATIENT_UPDATE processor = new RIS_COMMENTONPATIENT_UPDATE();
            processor.RIS_COMMENTSONPATIENT = this.RIS_COMMENTSONPATIENT;
            if(Transaction == null)
                processor.UpdateMaster();
            else
                processor.UpdateMaster(this.Transaction);
        }

        #endregion
    }
}
