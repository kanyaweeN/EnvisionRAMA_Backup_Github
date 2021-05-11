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
    public class ProcessAddGBLExceptionLog : IBusinessLogic
    {
        private GBLException _gblexception;

        public ProcessAddGBLExceptionLog()
        {

        }

        public void Invoke()
        {
            GBLExceptionLogInsertData alertdata = new GBLExceptionLogInsertData();
            alertdata.GBLException = this.GBLException;
            alertdata.Add();

        }

        public GBLException GBLException
        {
            get { return _gblexception; }
            set { _gblexception = value; }
        }
    }
}
