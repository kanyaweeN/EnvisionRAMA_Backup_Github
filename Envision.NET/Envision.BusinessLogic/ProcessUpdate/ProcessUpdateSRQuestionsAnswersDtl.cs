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
    public class ProcessUpdateSRQuestionsAnswersDtl : IBusinessLogic
    {
        public SR_QUESTIONSANSWERSDTL SR_QUESTIONSANSWERSDTL { get; set; }
        
        public ProcessUpdateSRQuestionsAnswersDtl() {
            SR_QUESTIONSANSWERSDTL = new SR_QUESTIONSANSWERSDTL();
        }


        #region IBusinessLogic Members

        public void Invoke()
        {
            SR_QUESTIONSANSWERSDTLUpdateData proc = new SR_QUESTIONSANSWERSDTLUpdateData();
            proc.SR_QUESTIONSANSWERSDTL = SR_QUESTIONSANSWERSDTL;
            proc.Update();
        }

        #endregion
    }
}
