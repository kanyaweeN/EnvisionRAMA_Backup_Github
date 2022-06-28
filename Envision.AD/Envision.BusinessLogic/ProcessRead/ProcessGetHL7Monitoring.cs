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
    public class ProcessGetHL7Monitoring : IBusinessLogic
    {
        public HL7Monitoring HL7Monitoring { get; set; }
        private DataSet _resultset;

        public ProcessGetHL7Monitoring()
        {
            HL7Monitoring = new HL7Monitoring();
        }

        public void Invoke()
        {
            HL7MonitoringSelectData hl7data = new HL7MonitoringSelectData();
            hl7data.HL7Monitoring = this.HL7Monitoring;
            ResultSet = hl7data.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
