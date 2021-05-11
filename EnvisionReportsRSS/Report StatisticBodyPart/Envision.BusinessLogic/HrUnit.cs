using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class HrUnit
    {
        public HR_UNIT HR_UNIT { get; set; }
        public HrUnit()
        {
            HR_UNIT = new HR_UNIT();
        }
        public DataSet Select()
        {
            ProcessGetHrUnit procRead = new ProcessGetHrUnit();
            procRead.HR_UNIT = this.HR_UNIT;
            return procRead.Select();
        }
    }
}
