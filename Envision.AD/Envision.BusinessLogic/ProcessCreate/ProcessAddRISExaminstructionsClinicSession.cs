using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExaminstructionsClinicSession: IBusinessLogic
	{
        public RIS_EXAMINSTRUCTIONCLINICSESSION RIS_EXAMINSTRUCTIONCLINICSESSION { get; set; }
        public ProcessAddRISExaminstructionsClinicSession()
        {
            RIS_EXAMINSTRUCTIONCLINICSESSION = new RIS_EXAMINSTRUCTIONCLINICSESSION();
        }
		public void Invoke()
		{
            RISExaminstructionsClinicSessionInsertData _proc = new RISExaminstructionsClinicSessionInsertData();
            _proc.RIS_EXAMINSTRUCTIONCLINICSESSION = this.RIS_EXAMINSTRUCTIONCLINICSESSION;
			_proc.Add();
		}
	}
}

