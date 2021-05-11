using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetResultEntryWorkListByHN : IBusinessLogic
    {
        public ResultEntryWorkList ResultEntryWorkList { get; set; }
        private DataSet _resultset;

        public ProcessGetResultEntryWorkListByHN()
        {
            ResultEntryWorkList = new ResultEntryWorkList();
        }

        public void Invoke()
        {
            ResultEntryHNSelectData rsentry = new ResultEntryHNSelectData();
            rsentry.ResultEntryWorkList = this.ResultEntryWorkList;
            ResultSet = rsentry.GetData();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
