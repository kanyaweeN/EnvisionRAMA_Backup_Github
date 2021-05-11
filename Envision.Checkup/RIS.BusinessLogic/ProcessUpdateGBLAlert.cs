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
    public class ProcessUpdateGBLAlert : IBusinessLogic
    {
        private GBLAlert _gblalert;

        public ProcessUpdateGBLAlert()
        {

        }

        public void Invoke()
        {
            GBLAlertUpdateData alertdata = new GBLAlertUpdateData();
            alertdata.GBLAlert = this.GBLAlert;
            alertdata.Add();

        }

        public GBLAlert GBLAlert
        {
            get { return _gblalert; }
            set { _gblalert = value; }
        }
    }
}
