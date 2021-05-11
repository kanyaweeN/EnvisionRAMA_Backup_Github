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
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLAlert : IBusinessLogic
    {
        private GBLAlert _gblalert;

        public ProcessDeleteGBLAlert()
        {

        }

        public void Invoke()
        {
            GBLAlertDeleteData alertdata = new GBLAlertDeleteData();
            alertdata.GBLAlert = this.GBLAlert;
            alertdata.Delete();

        }

        public GBLAlert GBLAlert
        {
            get { return _gblalert; }
            set { _gblalert = value; }
        }
    }
}
