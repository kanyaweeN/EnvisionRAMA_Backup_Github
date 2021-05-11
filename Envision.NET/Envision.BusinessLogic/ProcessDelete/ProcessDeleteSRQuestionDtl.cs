using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSRQuestionDtl : IBusinessLogic
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }
        public ProcessDeleteSRQuestionDtl() {
            SR_QUESTIONSDTL = new SR_QUESTIONSDTL();
        }


        #region IBusinessLogic Members

        public void Invoke()
        {
            SR_QUESTIONSDTLDeleteData proc = new SR_QUESTIONSDTLDeleteData();
            proc.SR_QUESTIONSDTL = SR_QUESTIONSDTL;
            proc.Delete();
        }

        #endregion
    }
}
