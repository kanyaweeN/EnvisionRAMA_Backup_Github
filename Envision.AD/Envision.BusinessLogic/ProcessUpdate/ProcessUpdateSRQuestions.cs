using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateSRQuestions : IBusinessLogic
    {
        public SR_QUESTIONS SR_QUESTIONS { get; set; }

        public ProcessUpdateSRQuestions()
        {
            this.SR_QUESTIONS = new SR_QUESTIONS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRQuestionUpdate processor = new SRQuestionUpdate();
            processor.SR_QUESTIONS = this.SR_QUESTIONS;
            processor.UpdateData();
        }

        #endregion
    }
}
