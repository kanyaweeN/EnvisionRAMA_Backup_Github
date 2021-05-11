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
    public class ProcessUpdateSRQuestionsAnswersDtlChild : IBusinessLogic
    {
        public SR_QUESTIONSANSWERSDTLCHILD SR_QUESTIONSANSWERSDTLCHILD { get; set; }
        public ProcessUpdateSRQuestionsAnswersDtlChild() {
            SR_QUESTIONSANSWERSDTLCHILD = new SR_QUESTIONSANSWERSDTLCHILD();
        }



        #region IBusinessLogic Members

        public void Invoke()
        {
            SR_QUESTIONSANSWERSDTLCHILDUpdateData proc = new SR_QUESTIONSANSWERSDTLCHILDUpdateData();
            proc.SR_QUESTIONSANSWERSDTLCHILD = SR_QUESTIONSANSWERSDTLCHILD;
            proc.Update();
        }

        #endregion
    }
}
