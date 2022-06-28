using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetMGBreastExamResult : IBusinessLogic
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public int Mode { get; set; }
        public DataSet Result { get; set; }

        public ProcessGetMGBreastExamResult()
        {
            this.MG_BREASTEXAMRESULT = new MG_BREASTEXAMRESULT();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastExamResultSelect processor = new MGBreastExamResultSelect();
            processor.MG_BREASTEXAMRESULT = this.MG_BREASTEXAMRESULT;
            this.Result = processor.GetData(this.Mode);
        }

        #endregion
    }
}
