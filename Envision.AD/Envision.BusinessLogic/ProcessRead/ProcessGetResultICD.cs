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
