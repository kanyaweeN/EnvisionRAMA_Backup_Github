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
    public class ProcessAddGBLAlert : IBusinessLogic
    {
        private GBLAlert _gblalert;

        public ProcessAddGBLAlert()
        {

        }

        public void Invoke()
        {
            GBLAlertInsertData alertdata = new GBLAlertInsertData();
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
