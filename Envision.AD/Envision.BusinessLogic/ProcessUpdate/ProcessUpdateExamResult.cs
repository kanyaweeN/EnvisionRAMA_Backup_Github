using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateExamResult : IBusinessLogic
    {
        public RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }

        public ProcessUpdateExamResult()
        {
            RIS_EXAMRESULT = new RIS_EXAMRESULT();
        }

        public void Invoke()
        {
            ExamResultUpdateData resultdata = new ExamResultUpdateData();
            resultdata.RIS_EXAMRESULT = this.RIS_EXAMRESULT;
            resultdata.Update();

        }
    }
}
