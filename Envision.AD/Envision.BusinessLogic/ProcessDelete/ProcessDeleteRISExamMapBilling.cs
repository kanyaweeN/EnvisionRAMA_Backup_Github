using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISExamMapBilling: IBusinessLogic
    {
        public RIS_EXAMMAPBILLING RIS_EXAMMAPBILLING { get; set; }

        public ProcessDeleteRISExamMapBilling()
		{
            RIS_EXAMMAPBILLING = new RIS_EXAMMAPBILLING();
		}
        
		public void Invoke()
		{
            RISExamMapBillingDeleteData _proc = new RISExamMapBillingDeleteData();
            _proc.RIS_EXAMMAPBILLING = RIS_EXAMMAPBILLING;
			 _proc.Delete();
		}
    }
}
