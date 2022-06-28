using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISHL7MonitoringNew : IBusinessLogic
    {
        public HL7Monitoring HL7Monitoring { get; set; }
        private DataSet result;

        public ProcessGetRISHL7MonitoringNew()
		{
            HL7Monitoring = new HL7Monitoring();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            
			RISHL7MonitoringSelectDataNew _proc=new RISHL7MonitoringSelectDataNew();
            _proc.HL7Monitoring = this.HL7Monitoring;
			result=_proc.GetData();
		}
        public void Invoke_PlaymentChecking_forAIMC()
        {

            RISHL7MonitoringSelectDataNew _proc = new RISHL7MonitoringSelectDataNew();
            _proc.HL7Monitoring = this.HL7Monitoring;
            result = _proc.GetData_PlaymentChecking_forAIMC();
        }
    }
}
