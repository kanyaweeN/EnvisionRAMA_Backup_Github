using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrderClinicalindicationType: IBusinessLogic
    {
        
        public RIS_ORDERCLINICALINDICATION RIS_ORDERCLINICALINDICATION { get; set; }
        public ProcessAddRISOrderClinicalindicationType()
        {
            RIS_ORDERCLINICALINDICATION = new RIS_ORDERCLINICALINDICATION();
        }

        public void Invoke()
        {
            RISOrderClinicalindicationTypeInsert add = new RISOrderClinicalindicationTypeInsert();
            add.RIS_ORDERCLINICALINDICATION = RIS_ORDERCLINICALINDICATION;
            add.Add();
        }
    }
}
