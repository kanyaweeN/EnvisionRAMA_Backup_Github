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
    public class ProcessAddRISPatstatusN : IBusinessLogic
    {
        private RISPatstatus _rispatstatus;
        public ProcessAddRISPatstatusN()
        {
            _rispatstatus = new RISPatstatus();
        }
        public RISPatstatus RISPatstatus
        {
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
        }
        public void Invoke()
        {
            RISPatstatusInsertDataN _proc = new RISPatstatusInsertDataN();
            _proc.RISPatstatus = this.RISPatstatus;
            _proc.Add();
        }
    }
}
