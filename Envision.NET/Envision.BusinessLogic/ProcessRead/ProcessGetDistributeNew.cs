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
    public class ProcessGetDistributeNew : IBusinessLogic
    {
        private DataSet _resultset;
        private DistributionNew _worklist;

        public ProcessGetDistributeNew()
        {
            _worklist = new DistributionNew();
        }

        public void Invoke()
        {
            DistributionNewSelect distribution = new DistributionNewSelect();
            distribution.DistributionNew = this.DistributionNew;
            ResultSet = distribution.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public DistributionNew DistributionNew
        {
            get { return _worklist; }
            set { _worklist = value; }
        }
    }
}
