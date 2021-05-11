using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateSRQuestionsDtl : IBusinessLogic
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }

        public ProcessUpdateSRQuestionsDtl()
        {
            this.SR_QUESTIONSDTL = new SR_QUESTIONSDTL();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRQuestionsDtlUpdate processor = new SRQuestionsDtlUpdate();
            processor.SR_QUESTIONSDTL = this.SR_QUESTIONSDTL;
            processor.UpdateData();
        }

        #endregion
    }
}
