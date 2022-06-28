using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateSRQuestionsDtlChild : IBusinessLogic
    {
        public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }

        public ProcessUpdateSRQuestionsDtlChild()
        {
            this.SR_QUESTIONSDTLCHILD = new SR_QUESTIONSDTLCHILD();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRQuestionDtlChildUpdate processor = new SRQuestionDtlChildUpdate();
            processor.SR_QUESTIONSDTLCHILD = this.SR_QUESTIONSDTLCHILD;
            processor.UpdateData();
        }

        #endregion
    }
}
