using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestionsDtlChild : IBusinessLogic
    {
        public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }

        public ProcessAddSRQuestionsDtlChild()
        {
            this.SR_QUESTIONSDTLCHILD = new SR_QUESTIONSDTLCHILD();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRQuestionsDtlChildInsert processor = new SRQuestionsDtlChildInsert();
            processor.SR_QUESTIONSDTLCHILD = this.SR_QUESTIONSDTLCHILD;
            processor.InsertData();
        }

        #endregion
    }
}
