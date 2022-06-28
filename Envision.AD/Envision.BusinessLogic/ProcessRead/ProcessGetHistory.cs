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
    public class ProcessGetHistory : IBusinessLogic
    {
        public ResultEntryWorkList ResultEntryWorkList { get; set; }
        private DataSet _resultset;

        public ProcessGetHistory()
        {
            ResultEntryWorkList = new ResultEntryWorkList();
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



    }
}
