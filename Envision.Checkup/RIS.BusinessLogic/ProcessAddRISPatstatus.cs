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

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddRISPatstatus : IBusinessLogic
    {
        private RISPatstatus _gbpatient;

        public ProcessAddRISPatstatus()
        {

        }

        public void Invoke()
        {
            PatientInsertData patientdata = new PatientInsertData();
            patientdata.RISPatstatus = this.RISPatstatus;
            patientdata.Add();

        }

        public RISPatstatus RISPatstatus
        {
            get { return _gbpatient; }
            set { _gbpatient = value; }
        }
    }
}
