using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSRQuestionsDtlChild : IBusinessLogic
    {
        public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }
        public ProcessDeleteSRQuestionsDtlChild() 
        {
            this.SR_QUESTIONSDTLCHILD = new SR_QUESTIONSDTLCHILD();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SrQuestionDtlChildDelete processor = new SrQuestionDtlChildDelete();
            processor.SR_QUESTIONSDTLCHILD = this.SR_QUESTIONSDTLCHILD;
            processor.DeleteData();
        }

        #endregion
    }
}
