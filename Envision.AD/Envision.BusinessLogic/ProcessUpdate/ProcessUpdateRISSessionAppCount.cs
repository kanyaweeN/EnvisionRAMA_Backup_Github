using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISSessionAppCount: IBusinessLogic
    {
        public RIS_SESSIONAPPCOUNT RIS_SESSIONAPPCOUNT { get; set; }

        public ProcessUpdateRISSessionAppCount()
        {
            RIS_SESSIONAPPCOUNT = new RIS_SESSIONAPPCOUNT();
        }
        public void Invoke()
        {
            RISSessionAppCountUpdateData upData = new RISSessionAppCountUpdateData();
            upData.RIS_SESSIONAPPCOUNT = this.RIS_SESSIONAPPCOUNT;
            upData.Update();
        }
    }
}
