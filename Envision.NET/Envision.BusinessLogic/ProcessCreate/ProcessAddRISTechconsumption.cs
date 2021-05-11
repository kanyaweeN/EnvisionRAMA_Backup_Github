using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISTechconsumption : IBusinessLogic
	{
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }

		public ProcessAddRISTechconsumption()
		{
            RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
		}
		public void Invoke()
		{
			RISTechconsumptionInsertData _proc=new RISTechconsumptionInsertData();
            _proc.RIS_TECHCONSUMPTION = this.RIS_TECHCONSUMPTION;
			_proc.Add();
		}
	}
}

