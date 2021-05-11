using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateDistributionNew : IBusinessLogic
    {
        private DistributionNew _distributionnew;
        public ProcessUpdateDistributionNew()
        {
            _distributionnew = new DistributionNew();
        }
        public DistributionNew DistributionNew
        {
            get { return _distributionnew; }
            set { _distributionnew = value; }
        }
        public void Invoke()
        {
            DistributionNewUpdateData _disupdate = new DistributionNewUpdateData();
            _disupdate.DistributionNew = this.DistributionNew;
            _disupdate.Update();
        }

        #region IBusinessLogic Members

        void IBusinessLogic.Invoke()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
