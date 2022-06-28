using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISCommentOnPatientDtl : IBusinessLogic
    {
        public RIS_COMMENTSONPATIENTDTL RIS_COMMENTSONPATIENTDTL { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISCommentOnPatientDtl()
        {
            this.RIS_COMMENTSONPATIENTDTL = new RIS_COMMENTSONPATIENTDTL();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RIS_COMMENTONPATIENTDTL_UPDATE processor = new RIS_COMMENTONPATIENTDTL_UPDATE();
            processor.RIS_COMMENTSONPATIENTDTL = RIS_COMMENTSONPATIENTDTL;
            if (this.Transaction == null)
                processor.UpdateDetail();
            else
                processor.UpdateDetail(this.Transaction);
        }

        #endregion
    }
}
