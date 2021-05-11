using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamresultFilterworklist: IBusinessLogic
    {
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }

        public ProcessAddRISExamresultFilterworklist()
        {
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST();
        }

        public void Invoke()
        {
            RISExamresultFilterworklistInsertData data = new RISExamresultFilterworklistInsertData();
            data.RIS_EXAMRESULT_FILTERWORKLIST = RIS_EXAMRESULT_FILTERWORKLIST;
            data.Add();
        }
    }
}
