/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddResultStatusChangeLog : IBusinessLogic
    {
        public HL7Monitoring HL7Monitoring { get; set; }
        private DataSet ResultSet{get;set;}

        public ProcessAddResultStatusChangeLog()
        {
            HL7Monitoring = new HL7Monitoring();
            ResultSet = new DataSet();
        }

        public void Invoke()
        {
            ResultStatusChangeInsertData hl7data = new ResultStatusChangeInsertData();
            hl7data.HL7Monitoring = this.HL7Monitoring;
            hl7data.Add();
        }
    }
}
