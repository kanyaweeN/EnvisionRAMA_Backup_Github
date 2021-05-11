using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISClinicalIndicationWithUnit : IBusinessLogic
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessDeleteRISClinicalIndicationWithUnit()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
        }

        public void Invoke()
        {
            RISClinicalIndicationWithUnitDeleteData data = new RISClinicalIndicationWithUnitDeleteData();
            data.RIS_CLINICALINDICATION = this.RIS_CLINICALINDICATION;
            data.Delete();
        }
        public void DeleteAll()
        {
            RISClinicalIndicationWithUnitDeleteData data = new RISClinicalIndicationWithUnitDeleteData();
            data.RIS_CLINICALINDICATION = this.RIS_CLINICALINDICATION;
            data.DeleteAll();
        }
    }
}
