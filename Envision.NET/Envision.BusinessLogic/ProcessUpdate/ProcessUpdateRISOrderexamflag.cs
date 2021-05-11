using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISOrderexamflag : IBusinessLogic
    {
        public RIS_ORDEREXAMFLAG RIS_ORDEREXAMFLAG { get; set; }

        public ProcessUpdateRISOrderexamflag()
        {
            RIS_ORDEREXAMFLAG = new RIS_ORDEREXAMFLAG();
        }
        public void Invoke()
        {
            RISOrderexamflagUpdateData _proc = new RISOrderexamflagUpdateData();
            _proc.RIS_ORDEREXAMFLAG = this.RIS_ORDEREXAMFLAG;
            _proc.Update();
        }
    }
}
