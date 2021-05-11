using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateACGrade
    {
        public AC_GRADE AC_GRADE { get; set; }

        public ProcessUpdateACGrade()
        {
            AC_GRADE = new AC_GRADE();
        }

        public void Invoke()
        {
            ACGradeUpdateData _update = new ACGradeUpdateData();
            _update.AC_GRADE = this.AC_GRADE;
            _update.Update();
        }
    }
}
