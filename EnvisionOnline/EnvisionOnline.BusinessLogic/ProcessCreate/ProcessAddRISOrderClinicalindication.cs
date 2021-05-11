using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrderClinicalindication: IBusinessLogic
    {
        
        public RIS_ORDERCLINICALINDICATION RIS_ORDERCLINICALINDICATION { get; set; }
        public ProcessAddRISOrderClinicalindication()
        {
            RIS_ORDERCLINICALINDICATION = new RIS_ORDERCLINICALINDICATION();
        }

        public void Invoke()
        {
            RISOrderClinicalindicationInsert add = new RISOrderClinicalindicationInsert();
            add.RIS_ORDERCLINICALINDICATION = RIS_ORDERCLINICALINDICATION;
            add.Add();
        }
    }
}
