using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddONLHISLinkLogs: IBusinessLogic
    {
        public ONL_HISLINKLOG ONL_HISLINKLOG { get; set; }
        public ProcessAddONLHISLinkLogs()
        {
            ONL_HISLINKLOG = new ONL_HISLINKLOG();
        }

        public void Invoke()
        {
            ONLHISlinklogInsertData add = new ONLHISlinklogInsertData();
            add.ONL_HISLINKLOG = ONL_HISLINKLOG;
            add.Add();
        }
    }
}