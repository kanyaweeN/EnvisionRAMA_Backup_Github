using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISMPPS
    {
        public RIS_MPPS RIS_MPPS { get; set; }

        public ProcessGetRISMPPS()
        {
            RIS_MPPS = new RIS_MPPS();
        }

        public DataTable GetData()
        {
            RISMPPSSelectData select = new RISMPPSSelectData();
            select.RIS_MPPS = this.RIS_MPPS;
            return select.Get().Tables[0];
        }
    }
}
