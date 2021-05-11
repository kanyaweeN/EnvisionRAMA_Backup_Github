using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddXrayreq : IBusinessLogic
    {
        public XRAYREQ XRAYREQ { get; set; }
        public int order_id { get; set; }
        public ProcessAddXrayreq()
        {
            XRAYREQ = new XRAYREQ();
        }

        public void Invoke()
        {
            XrayreqInsertData add = new XrayreqInsertData();
            add.XRAYREQ = XRAYREQ;
            order_id = add.Add();
        }
    }
}
