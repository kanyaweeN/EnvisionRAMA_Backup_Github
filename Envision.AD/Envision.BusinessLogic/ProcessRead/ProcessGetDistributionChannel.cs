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
    public class ProcessGetDistributionChannel : IBusinessLogic
    {
        private ResultEntryWorkList _worklist;
        private DataSet _resultset;

        public ProcessGetDistributionChannel()
        {

        }

        public void Invoke()
        {
            DistributionChannelSelectData distribution = new DistributionChannelSelectData();
            distribution.ResultEntryWorkList = this.ResultEntryWorkList;
            ResultSet = distribution.Get();
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
