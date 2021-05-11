/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ProcessGetHL7Monitoring : IBusinessLogic
    {
        private HL7Monitoring _hl7monitoring;
        private DataSet _resultset;

        public ProcessGetHL7Monitoring()
        {

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

        public HL7Monitoring HL7Monitoring
        {
            get { return _hl7monitoring; }
            set { _hl7monitoring = value; }
        }



    }
}
