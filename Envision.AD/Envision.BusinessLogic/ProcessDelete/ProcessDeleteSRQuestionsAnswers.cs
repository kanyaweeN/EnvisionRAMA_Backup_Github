using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSRQuestionsAnswers : IBusinessLogic
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }

        public ProcessDeleteSRQuestionsAnswers() {
            SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
        }

        public void Invoke()
        {
            SR_QUESTIONSANSWERSDeleteData proc = new SR_QUESTIONSANSWERSDeleteData();
            proc.SR_QUESTIONSANSWERS = SR_QUESTIONSANSWERS;
            proc.Delete();
        }
    }
}
