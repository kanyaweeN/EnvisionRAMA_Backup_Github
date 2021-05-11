using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessDeleteRISClinicalIndicationType: IBusinessLogic
    {
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public ProcessDeleteRISClinicalIndicationType()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
        }

        public void Invoke()
        {
            RISClinicalIndicationTypeDeleteData data = new RISClinicalIndicationTypeDeleteData();
            data.RIS_CLINICALINDICATIONTYPE = this.RIS_CLINICALINDICATIONTYPE;
            data.Delete();
        }
    }
}