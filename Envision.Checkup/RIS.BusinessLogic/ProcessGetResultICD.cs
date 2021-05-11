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
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ProcessGetResultICD : IBusinessLogic
    {
        private ResultEntryICD _icd;
        private DataSet _resultset;

        public ProcessGetResultICD()
        {

        }

        public void Invoke()
        {
            ResultICDSelectData rsentry = new ResultICDSelectData();
            rsentry.ResultEntryICD = this.ResultEntryICD;
            ResultSet = rsentry.Get();

        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public ResultEntryICD ResultEntryICD
        {
            get { return _icd; }
            set { _icd = value; }
        }



    }
}
