using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSRQuestionsDtl : IBusinessLogic
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }
        public ProcessDeleteSRQuestionsDtl() 
        {
            this.SR_QUESTIONSDTL = new SR_QUESTIONSDTL();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SrQuestionsDtlDelete processor = new SrQuestionsDtlDelete();
            processor.SR_QUESTIONSDTL = this.SR_QUESTIONSDTL;
            processor.DeleteData();
        }

        #endregion
    }
}
