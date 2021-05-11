using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetDistribution: IBusinessLogic
    {
        private DataSet _resultset;
        public DistributionCommon DistributionCommon { get; set; }

        public ProcessGetDistribution()
        {
            DistributionCommon = new DistributionCommon();
        }

        public void Invoke()
        {
            DistributionSelect distribution = new DistributionSelect();
            distribution.DistributionCommon = this.DistributionCommon;
            ResultSet = distribution.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
