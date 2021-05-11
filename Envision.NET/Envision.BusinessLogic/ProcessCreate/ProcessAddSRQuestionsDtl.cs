using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestionsDtl : IBusinessLogic
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }

        public ProcessAddSRQuestionsDtl()
        {
            this.SR_QUESTIONSDTL = new SR_QUESTIONSDTL();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRQuestionsDtlInsert processor = new SRQuestionsDtlInsert();
            processor.SR_QUESTIONSDTL = this.SR_QUESTIONSDTL;
            processor.InsertData();
        }

        #endregion
    }
}
