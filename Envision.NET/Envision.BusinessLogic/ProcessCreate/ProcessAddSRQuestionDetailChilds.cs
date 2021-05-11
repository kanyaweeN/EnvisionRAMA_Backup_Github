using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestionDetailChilds : IBusinessLogic
    {
        public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }

        public ProcessAddSRQuestionDetailChilds()
        {
            this.SR_QUESTIONSDTLCHILD = new SR_QUESTIONSDTLCHILD();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SR_QuestionDtlChildInsertData processor = new SR_QuestionDtlChildInsertData();
            processor.SR_QUESTIONSDTLCHILD = this.SR_QUESTIONSDTLCHILD;
            processor.InsertData();
        }

        #endregion
    }
}
