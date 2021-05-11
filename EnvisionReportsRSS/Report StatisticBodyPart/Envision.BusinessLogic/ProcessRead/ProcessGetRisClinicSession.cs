using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRisClinicSession
    {
        private RisClinicSessionSelectData selecting { get; set; }
        public RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }
        public ProcessGetRisClinicSession()
        {
            RIS_CLINICSESSION = new RIS_CLINICSESSION();
            selecting = new RisClinicSessionSelectData();
        }
        public DataSet Select()
        {
            selecting.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return selecting.Select();
        }
    }
}
