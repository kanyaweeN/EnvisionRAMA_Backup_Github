using System.Text;
using System.Data;
using System.Data.Common;

using System.Collections.Generic;
using System;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISScheduleDtl :IBusinessLogic
    {
        public RIS_SCHEDULEDTL RIS_SCHEDULEDTL { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISScheduleDtl() {
            RIS_SCHEDULEDTL = new RIS_SCHEDULEDTL();
            Transaction = null;
        }
        public void Invoke()
        {
            RISScheduleDtlInsertData proc = new RISScheduleDtlInsertData();
            proc.RIS_SCHEDULEDTL = RIS_SCHEDULEDTL;
            proc.Add();
        }

    }
}
