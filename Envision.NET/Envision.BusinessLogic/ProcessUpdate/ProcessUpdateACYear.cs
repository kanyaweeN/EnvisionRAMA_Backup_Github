using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateACYear
    {
        public AC_YEAR AC_YEAR { get; set; }

         public ProcessUpdateACYear()
        {
            AC_YEAR = new AC_YEAR();
        }

        public void Invoke()
        {
            ACYearUpdateData _update = new ACYearUpdateData();
            _update.AC_YEAR = this.AC_YEAR;
            _update.Update();
        }
    }
}
