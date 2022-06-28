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
    public class ProcessAddSession : IBusinessLogic
    {
        public GBL_SESSION GBL_SESSION { get; set; }

        public ProcessAddSession()
        {
            GBL_SESSION = new GBL_SESSION();
        }

        public void Invoke()
        {
            SessionInsertData alertdata = new SessionInsertData();
            alertdata.GBL_SESSION = this.GBL_SESSION;
            alertdata.Add();

        }
    }
}
