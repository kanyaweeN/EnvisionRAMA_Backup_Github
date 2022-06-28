using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSRQuestions : IBusinessLogic
    {
        public SR_QUESTIONS SR_QUESTIONS { get; set; }

        public ProcessDeleteSRQuestions()
        {
            this.SR_QUESTIONS = new SR_QUESTIONS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SrQuestionsDelete processor = new SrQuestionsDelete();
            processor.SR_QUESTIONS = this.SR_QUESTIONS;
            processor.DeleteData();
        }

        #endregion
    }
}
