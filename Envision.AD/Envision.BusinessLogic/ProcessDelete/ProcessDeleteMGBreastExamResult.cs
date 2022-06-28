using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteMGBreastExamResult : IBusinessLogic
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public ProcessDeleteMGBreastExamResult()
        {
            this.MG_BREASTEXAMRESULT = new MG_BREASTEXAMRESULT();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastExamResultDelete processor = new MGBreastExamResultDelete();
            processor.MG_BREASTEXAMRESULT = this.MG_BREASTEXAMRESULT;
            processor.DeleteData();
        }

        #endregion
    }
}
