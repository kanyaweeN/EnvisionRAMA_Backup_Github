using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRTemplateAnswersPart : IBusinessLogic
    {
        public SR_TEMPLATEANSWERSPART SR_TEMPLATEANSWERSPART { get; set; }

        public ProcessAddSRTemplateAnswersPart()
        {
            SR_TEMPLATEANSWERSPART = new SR_TEMPLATEANSWERSPART();
        }

        public void Invoke()
        {
            SR_TemplateAnswersPartInsertData _proc = new SR_TemplateAnswersPartInsertData();
            _proc.SR_TEMPLATEANSWERSPART = SR_TEMPLATEANSWERSPART;
            _proc.Add();
        }
    }
}
