using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISClinicalIndicationType: IBusinessLogic
    {
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public ProcessAddRISClinicalIndicationType()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
        }

        public void Invoke()
        {
            RISClinicalIndicationTypeInsertData insert = new RISClinicalIndicationTypeInsertData();
            insert.RIS_CLINICALINDICATIONTYPE = this.RIS_CLINICALINDICATIONTYPE;
            insert.Insert();
        }
    }
}
