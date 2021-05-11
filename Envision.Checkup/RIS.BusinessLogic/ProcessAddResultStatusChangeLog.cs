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
using RIS.DataAccess.Insert;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ProcessAddResultStatusChangeLog : IBusinessLogic
    {
        private HL7Monitoring _hl7monitoring;
        private DataSet _resultset;

        public ProcessAddResultStatusChangeLog()
        {

        }

        public void Invoke()
        {
            ResultStatusChangeInsertData hl7data = new ResultStatusChangeInsertData();
            hl7data.HL7Monitoring = this.HL7Monitoring;
            hl7data.Add();
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
