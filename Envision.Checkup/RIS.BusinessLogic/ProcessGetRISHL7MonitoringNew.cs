using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISHL7MonitoringNew : IBusinessLogic
    {
        
        private DataSet result;
		private HL7MonitoringNew _hl7monitoringnew;
        public ProcessGetRISHL7MonitoringNew()
		{
			_hl7monitoringnew = new  HL7MonitoringNew();
		}
		public HL7MonitoringNew HL7MonitoringNew
		{
			get{return _hl7monitoringnew;}
			set{_hl7monitoringnew=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            
			RISHL7MonitoringSelectDataNew _proc=new RISHL7MonitoringSelectDataNew();
			_proc.HL7MonitoringNew=this.HL7MonitoringNew;
			result=_proc.GetData();
		}
    }
}
