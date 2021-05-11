using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class RisClinicSession
    {
        public RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }
        public RisClinicSession()
        {
            RIS_CLINICSESSION = new RIS_CLINICSESSION();
        }
        public DataSet Select()
        {
            ProcessGetRisClinicSession procRead = new ProcessGetRisClinicSession();
            procRead.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return procRead.Select();
        }
    }
}
