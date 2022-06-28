using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamMapBilling: IBusinessLogic
    {
        public RIS_EXAMMAPBILLING RIS_EXAMMAPBILLING { get; set; }

        public ProcessAddRISExamMapBilling()
        {
            RIS_EXAMMAPBILLING = new RIS_EXAMMAPBILLING();
        }

        public void Invoke()
        {
            RISExamMapBillingInsertData data = new RISExamMapBillingInsertData();
            data.RIS_EXAMMAPBILLING = RIS_EXAMMAPBILLING;
            data.Add();
        }
    }
}
