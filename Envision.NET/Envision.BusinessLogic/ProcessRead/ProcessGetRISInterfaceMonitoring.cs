using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISInterfaceMonitoring: IBusinessLogic
	{
        public RIS_HL7IELOG RIS_HL7IELOG { get; set; }
		public DataSet Result { get; set; }

        public ProcessGetRISInterfaceMonitoring() { RIS_HL7IELOG = new RIS_HL7IELOG(); }

		public void Invoke()
		{
            RISInterfaceMonitoringSelectData prc = new RISInterfaceMonitoringSelectData();
            prc.RIS_HL7IELOG = RIS_HL7IELOG;
			Result = prc.GetData();
		}
	}
}