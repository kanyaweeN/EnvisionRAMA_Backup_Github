using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetHrUnit
    {
        private RISHrUnitSelectData selecting { get; set; }
        public HR_UNIT HR_UNIT { get; set; }
        public ProcessGetHrUnit()
        {
            HR_UNIT = new HR_UNIT();
            selecting = new RISHrUnitSelectData();
        }
        public DataSet Select()
        {
            selecting.HR_UNIT = this.HR_UNIT;
            return selecting.Select();
        }
    }
}
