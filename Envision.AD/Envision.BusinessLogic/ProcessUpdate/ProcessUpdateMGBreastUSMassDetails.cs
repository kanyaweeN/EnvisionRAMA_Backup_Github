using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateMGBreastUSMassDetails : IBusinessLogic
    {
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }
        public ProcessUpdateMGBreastUSMassDetails()
        {
            this.MG_BREASTUSMASSDETAILS = new MG_BREASTUSMASSDETAILS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastUSMassDetailsUpdate processor = new MGBreastUSMassDetailsUpdate();
            processor.MG_BREASTUSMASSDETAILS = this.MG_BREASTUSMASSDETAILS;
            processor.UpdateData();
        }

        #endregion
    }
}
