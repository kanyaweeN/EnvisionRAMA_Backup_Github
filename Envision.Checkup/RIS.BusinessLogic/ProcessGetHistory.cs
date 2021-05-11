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
    public class ProcessGetHistory : IBusinessLogic
    {
        private ResultEntryWorkList _worklist;
        private DataSet _resultset;

        public ProcessGetHistory()
        {

        }

        public void Invoke()
        {
            HistorySelectData rsentry = new HistorySelectData();
            rsentry.ResultEntryWorkList = this.ResultEntryWorkList;
            ResultSet = rsentry.Get();

        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public ResultEntryWorkList ResultEntryWorkList
        {
            get { return _worklist; }
            set { _worklist = value; }
        }



    }
}
