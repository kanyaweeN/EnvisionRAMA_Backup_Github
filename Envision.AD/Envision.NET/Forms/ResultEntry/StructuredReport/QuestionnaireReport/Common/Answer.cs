using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireReport.Common
{
    public class Answer
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }
        public List<SR_QUESTIONSANSWERSDTL> SR_QUESTIONSANSWERSDTL { get; set; }
        public List<SR_QUESTIONSANSWERSDTLCHILD> SR_QUESTIONSANSWERSDTLCHILD { get; set; }

        public Answer()
        {
            SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
            SR_QUESTIONSANSWERSDTL = new List<SR_QUESTIONSANSWERSDTL>();
            SR_QUESTIONSANSWERSDTLCHILD = new List<SR_QUESTIONSANSWERSDTLCHILD>();
        }
        public class AnswerCollection
        {
            public List<Answer> Answer { get; set; }
            public AnswerCollection()
            {
                Answer = new List<Answer>();
            }
        }
    }
    public class AnswerCollection
    {
        public List<Answer> Answer { get; set; }
        public AnswerCollection()
        {
            Answer = new List<Answer>();
        }
    }
}
