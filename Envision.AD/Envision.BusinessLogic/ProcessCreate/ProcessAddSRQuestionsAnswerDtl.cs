using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestionsAnswerDtl : IBusinessLogic
    {
        public SR_QUESTIONSANSWERSDTL SR_QUESTIONSANSWERSDTL { get; set; }

        public ProcessAddSRQuestionsAnswerDtl() {
            SR_QUESTIONSANSWERSDTL = new SR_QUESTIONSANSWERSDTL();
        }
        public void Invoke()
        {
            SR_QuestionsAnswerDTLInsertData proc = new SR_QuestionsAnswerDTLInsertData();
            proc.SR_QUESTIONSANSWERSDTL = SR_QUESTIONSANSWERSDTL;
            proc.Add();
        }
    }
}
