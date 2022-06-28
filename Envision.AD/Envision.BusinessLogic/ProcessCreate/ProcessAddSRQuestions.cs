using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestions : IBusinessLogic
    {
        public SR_QUESTIONS SR_QUESTIONS { get; set; }

        public ProcessAddSRQuestions()
        {
            this.SR_QUESTIONS = new SR_QUESTIONS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRQuestionsInsert processor = new SRQuestionsInsert();
            processor.SR_QUESTIONS = this.SR_QUESTIONS;
            processor.InsertData();
        }

        #endregion
    }
}
