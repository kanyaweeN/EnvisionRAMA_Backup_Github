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
    public class ProcessAddRISPatstatus : IBusinessLogic
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        public ProcessAddRISPatstatus()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
        }

        public void Invoke()
        {
            PatientInsertData patientdata = new PatientInsertData();
            patientdata.RIS_PATSTATUS = this.RIS_PATSTATUS;
            patientdata.Add();

        }
    }
}
