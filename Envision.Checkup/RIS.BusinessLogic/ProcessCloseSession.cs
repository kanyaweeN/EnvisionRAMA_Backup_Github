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
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessCloseSession : IBusinessLogic
    {
        private GBLSession _gblsession;

        public ProcessCloseSession()
        {

        }

        public void Invoke()
        {
            UpdateSessionData alertdata = new UpdateSessionData();
            alertdata.GBLSession = this.GBLSession;
            alertdata.Update();

        }

        public GBLSession GBLSession
        {
            get { return _gblsession; }
            set { _gblsession = value; }
        }
    }
}
