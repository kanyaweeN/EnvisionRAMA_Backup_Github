using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISClinicalIndication: IBusinessLogic
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessDeleteRISClinicalIndication()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
        }

        public void Invoke()
        {
            RISClinicalIndicationDeleteData data = new RISClinicalIndicationDeleteData();
            data.RIS_CLINICALINDICATION = this.RIS_CLINICALINDICATION;
            data.Delete();
        }
    }
}