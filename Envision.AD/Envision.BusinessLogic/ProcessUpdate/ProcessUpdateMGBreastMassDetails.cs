using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateMGBreastMassDetails : IBusinessLogic
    {
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }
        public ProcessUpdateMGBreastMassDetails()
        {
            this.MG_BREASTMASSDETAILS = new MG_BREASTMASSDETAILS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMassDetailsUpdate processor = new MGBreastMassDetailsUpdate();
            processor.MG_BREASTMASSDETAILS = this.MG_BREASTMASSDETAILS;
            processor.UpdateData();
        }

        #endregion
    }
}
