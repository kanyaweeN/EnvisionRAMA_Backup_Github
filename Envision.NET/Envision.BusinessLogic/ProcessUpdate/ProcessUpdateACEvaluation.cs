using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateACEvaluation
    {
        public AC_EVALUATION AC_EVALUATION { get; set; }

        public ProcessUpdateACEvaluation()
        {
            AC_EVALUATION = new AC_EVALUATION();
        }

        public void Invoke()
        {
            ACEvaluationUpdateData _update = new ACEvaluationUpdateData();
            _update.AC_EVALUATION = this.AC_EVALUATION;
            _update.Update();
        }
    }
}
