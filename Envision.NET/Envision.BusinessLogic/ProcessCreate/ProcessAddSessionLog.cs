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
    public class ProcessAddSessionLog : IBusinessLogic
    {
        public GBL_SESSIONLOG GBL_SESSIONLOG { get; set; }

        public ProcessAddSessionLog()
        {
            GBL_SESSIONLOG = new GBL_SESSIONLOG();
        }

        public void Invoke()
        {
            SessionLogInsertData sessiondata = new SessionLogInsertData();
            sessiondata.GBL_SESSIONLOG = this.GBL_SESSIONLOG;
            sessiondata.Add();

        }
    }
}
