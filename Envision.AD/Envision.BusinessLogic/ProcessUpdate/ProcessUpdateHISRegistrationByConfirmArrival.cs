using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateHISRegistrationByConfirmArrival : IBusinessLogic
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public ProcessUpdateHISRegistrationByConfirmArrival()
        {
            this.HIS_REGISTRATION = new HIS_REGISTRATION();
        }
        #region IBusinessLogic Members
        public void Invoke()
        {
            HISRegistrationUpdateDataByConfirmArrival processor = new HISRegistrationUpdateDataByConfirmArrival();
            processor.HIS_REGISTRATION = this.HIS_REGISTRATION;
            processor.UpdateData();
        }

        #endregion
    }
}
