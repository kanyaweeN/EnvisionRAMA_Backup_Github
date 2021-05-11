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
    public class ProcessAddSession : IBusinessLogic
    {
        private GBLSession _gblsession;

        public ProcessAddSession()
        {

        }

        public void Invoke()
        {
            SessionInsertData alertdata = new SessionInsertData();
            alertdata.GBLSession = this.GBLSession;
            alertdata.Add();

        }

        public GBLSession GBLSession
        {
            get { return _gblsession; }
            set { _gblsession = value; }
        }
    }
}
