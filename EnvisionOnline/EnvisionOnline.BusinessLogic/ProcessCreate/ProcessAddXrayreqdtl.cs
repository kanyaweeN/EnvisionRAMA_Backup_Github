using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddXrayreqdtl : IBusinessLogic
    {
        public XRAYREQ XRAYREQ { get; set; }
        public ProcessAddXrayreqdtl()
        {
            XRAYREQ = new XRAYREQ();
        }

        public void Invoke()
        {
            XrayreqdtlInsertData add = new XrayreqdtlInsertData();
            add.XRAYREQ = XRAYREQ;
            add.Add();
        }
    }
}
