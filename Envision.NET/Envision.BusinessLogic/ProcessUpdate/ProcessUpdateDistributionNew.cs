using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateDistributionNew : IBusinessLogic
    {
        public DistributionNew DistributionNew { get; set; }

        public ProcessUpdateDistributionNew()
        {
            DistributionNew = new DistributionNew();
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
