using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestionDetails
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }

        public ProcessAddSRQuestionDetails() {
            SR_QUESTIONSDTL = new SR_QUESTIONSDTL();
        }
        public void Invoke()
        {
            SR_QuestionDtlInsertData proc = new SR_QuestionDtlInsertData();
            proc.SR_QUESTIONSDTL = SR_QUESTIONSDTL;
            proc.InsertData();
        }
    }
}
