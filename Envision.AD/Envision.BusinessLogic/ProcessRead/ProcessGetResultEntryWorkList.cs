using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetResultEntryWorkList : IBusinessLogic
    {
        private ResultEntryWorkList _worklist;
        private DataSet _resultset;

        public ProcessGetResultEntryWorkList()
        {

        }

        public void Invoke()
        {
            ResultEntyWorkListSelectData rsentry = new ResultEntyWorkListSelectData();
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
