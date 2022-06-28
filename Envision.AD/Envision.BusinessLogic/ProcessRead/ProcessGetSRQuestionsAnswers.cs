using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetSRQuestionsAnswers : IBusinessLogic
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetSRQuestionsAnswers() {
            SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
            Result = null;
        }
        public void Invoke()
        {
            SRQuestionsAnswerSelectData proc = new SRQuestionsAnswerSelectData();
            proc.SR_QUESTIONSANSWERS = this.SR_QUESTIONSANSWERS;
            DataTable dtt = proc.GetData();
            Result = new DataSet();
            Result.Tables.Add(dtt);
            Result.AcceptChanges();
        }
        public DataTable GetTemplateByAccession() {
            SRQuestionsAnswerSelectData proc = new SRQuestionsAnswerSelectData();
            proc.SR_QUESTIONSANSWERS = this.SR_QUESTIONSANSWERS;
            return proc.GetTempalteByAccession();
        }
        public DataSet GetAnswers() {
            SRQuestionsAnswerSelectData proc = new SRQuestionsAnswerSelectData();
            proc.SR_QUESTIONSANSWERS = this.SR_QUESTIONSANSWERS;
            return proc.GetAnswersData();
        }
        public DataTable GetTemplateById(int TemplateId)
        {
            SRQuestionsAnswerSelectData proc = new SRQuestionsAnswerSelectData();
            return proc.GetTempalteById(TemplateId);
        }
    }
}
