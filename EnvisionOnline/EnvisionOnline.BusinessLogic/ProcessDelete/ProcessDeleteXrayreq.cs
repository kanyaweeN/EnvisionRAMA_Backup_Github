using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteXrayreq : IBusinessLogic
    {

        public XRAYREQ XRAYREQ { get; set; }

        public ProcessDeleteXrayreq()
        {
            XRAYREQ = new XRAYREQ();
        }

        public void Invoke()
        {

            XrayReqDeleteData _proc = new XrayReqDeleteData();
            _proc.XRAYREQ = XRAYREQ;
            _proc.Delete();
        }
    }
}
