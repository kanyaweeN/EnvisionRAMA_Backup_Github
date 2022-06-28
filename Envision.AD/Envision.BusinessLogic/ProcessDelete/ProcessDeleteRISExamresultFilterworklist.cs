using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISExamresultFilterworklist : IBusinessLogic
    {
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }

        public ProcessDeleteRISExamresultFilterworklist()
        {
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST();
        }

        public void Invoke()
        {
            RISExamresultFilterworklistDeleteData data = new RISExamresultFilterworklistDeleteData();
            data.RIS_EXAMRESULT_FILTERWORKLIST = RIS_EXAMRESULT_FILTERWORKLIST;
            data.Delete();
        }


    }
}