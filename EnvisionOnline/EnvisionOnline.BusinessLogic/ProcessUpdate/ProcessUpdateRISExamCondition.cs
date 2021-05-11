using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISExamCondition: IBusinessLogic
    {
        public RIS_EXAM RIS_EXAM { get; set; }

        public ProcessUpdateRISExamCondition()
        {
            RIS_EXAM = new RIS_EXAM();
        }

        public void Invoke()
        {
            RISExamConditionUpdateData update = new RISExamConditionUpdateData();
            update.RIS_EXAM = this.RIS_EXAM;
            update.update();
        }
    }
}
