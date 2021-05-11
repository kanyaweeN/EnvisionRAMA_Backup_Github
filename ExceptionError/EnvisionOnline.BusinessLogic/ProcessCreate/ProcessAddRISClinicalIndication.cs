using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISClinicalIndication: IBusinessLogic
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessAddRISClinicalIndication()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
        }

        public void Invoke()
        {
            RISClinicalIndicationInsertData insert = new RISClinicalIndicationInsertData();
            insert.RIS_CLINICALINDICATION = this.RIS_CLINICALINDICATION;
            insert.Insert();
        }
    }
}
