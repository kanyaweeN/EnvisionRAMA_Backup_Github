using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestionsAnswer : IBusinessLogic
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }

        public ProcessAddSRQuestionsAnswer()
        {
             SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
        }
        public void Invoke()
        {
            SR_QuestionsAnswerInsertData proc = new SR_QuestionsAnswerInsertData();
            proc.SR_QUESTIONSANSWERS = SR_QUESTIONSANSWERS;
            proc.Add();
        }
    }
}
