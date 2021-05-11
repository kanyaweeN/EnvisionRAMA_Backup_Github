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
    public class ProcessAddSessionLog : IBusinessLogic
    {
        private GBLSessionLog _gblsession;

        public ProcessAddSessionLog()
        {

        }

        public void Invoke()
        {
            SessionLogInsertData sessiondata = new SessionLogInsertData();
            sessiondata.GBLSessionLog = this.GBLSessionLog;
            sessiondata.Add();

        }

        public GBLSessionLog GBLSessionLog
        {
            get { return _gblsession; }
            set { _gblsession = value; }
        }
    }
}
