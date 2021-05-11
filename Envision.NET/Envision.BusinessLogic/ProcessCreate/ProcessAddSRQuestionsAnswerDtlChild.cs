using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRQuestionsAnswerDtlChild :IBusinessLogic
    {
         public SR_QUESTIONSANSWERSDTLCHILD SR_QUESTIONSANSWERSDTLCHILD { get; set; }

         public ProcessAddSRQuestionsAnswerDtlChild()
         {
            SR_QUESTIONSANSWERSDTLCHILD = new SR_QUESTIONSANSWERSDTLCHILD();
        }
        public void Invoke()
        {
            SR_QuestionsAnswerDtlChildInsertData proc = new SR_QuestionsAnswerDtlChildInsertData();
            proc.SR_QUESTIONSANSWERSDTLCHILD = SR_QUESTIONSANSWERSDTLCHILD;
            proc.Add();
        }
    }
}
