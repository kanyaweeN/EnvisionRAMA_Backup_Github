using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISExamresultFilterworklist : IBusinessLogic
    {
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }

        public ProcessUpdateRISExamresultFilterworklist()
        {
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST();
        }

        public void Invoke()
        {
            RISExamresultFilterworklistUpdateData resultdata = new RISExamresultFilterworklistUpdateData();
            resultdata.RIS_EXAMRESULT_FILTERWORKLIST = this.RIS_EXAMRESULT_FILTERWORKLIST;
            resultdata.Update();

        }
    }
}
