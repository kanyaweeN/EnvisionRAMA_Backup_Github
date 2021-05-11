using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateSRQuestionsAnswers : IBusinessLogic
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }

        public ProcessUpdateSRQuestionsAnswers() {
            SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
        }

        public void Invoke()
        {
            SR_QUESTIONSANSWERSUpdateData proc = new SR_QUESTIONSANSWERSUpdateData();
            proc.SR_QUESTIONSANSWERS = SR_QUESTIONSANSWERS;
            proc.Update();
        }

        public void ClearAnswer() {
            SR_QUESTIONSANSWERSUpdateData proc = new SR_QUESTIONSANSWERSUpdateData();
            proc.SR_QUESTIONSANSWERS = SR_QUESTIONSANSWERS;
            proc.ClearAnswer();
        }
    }
}
