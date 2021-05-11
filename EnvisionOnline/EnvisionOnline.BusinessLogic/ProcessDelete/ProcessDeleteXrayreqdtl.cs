using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteXrayreqdtl : IBusinessLogic
    {

        public XRAYREQ XRAYREQ { get; set; }

        public ProcessDeleteXrayreqdtl()
        {
            XRAYREQ = new XRAYREQ();
        }

        public void Invoke()
        {

            XrayReqdtlDeleteData _proc = new XrayReqdtlDeleteData();
            _proc.XRAYREQ = XRAYREQ;
            _proc.Delete();
        }
    }
}
