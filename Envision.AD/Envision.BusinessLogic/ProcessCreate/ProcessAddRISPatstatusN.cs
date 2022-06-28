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
    public class ProcessAddRISPatstatusN : IBusinessLogic
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }

        public ProcessAddRISPatstatusN()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
        }
        public void Invoke()
        {
            RISPatstatusInsertDataN _proc = new RISPatstatusInsertDataN();
            _proc.RIS_PATSTATUS = this.RIS_PATSTATUS;
            _proc.Add();
        }
    }
}
