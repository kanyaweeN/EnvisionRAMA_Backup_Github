using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISSessionmaxapp: IBusinessLogic
    {
        public RIS_SESSIONMAXAPP RIS_SESSIONMAXAPP { get; set; }

        public ProcessUpdateRISSessionmaxapp()
        {
            RIS_SESSIONMAXAPP = new RIS_SESSIONMAXAPP();
        }
        public void Invoke()
        {
            RISSessionmaxappUpdateData _proc = new RISSessionmaxappUpdateData();
            _proc.RIS_SESSIONMAXAPP = this.RIS_SESSIONMAXAPP;
            _proc.Update();
        }
    }
}
