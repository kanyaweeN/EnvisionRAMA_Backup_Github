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
    public class ProcessGetReportStatusChange : IBusinessLogic
    {
        private HL7Monitoring _hl7monitoring;
        private DataSet _resultset;

        public ProcessGetReportStatusChange()
        {

        }

        public void Invoke()
        {
            ReportStatusSelectData hl7data = new ReportStatusSelectData();
            hl7data.HL7Monitoring = this.HL7Monitoring;
            ResultSet = hl7data.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public HL7Monitoring HL7Monitoring
        {
            get { return _hl7monitoring; }
            set { _hl7monitoring = value; }
        }

        public DataSet GetLog(string accession)
        {
            ReportStatusSelectData hl7data = new ReportStatusSelectData();
            hl7data.HL7Monitoring = this.HL7Monitoring;
            return hl7data.GetLog(accession);
        }

    }
}
