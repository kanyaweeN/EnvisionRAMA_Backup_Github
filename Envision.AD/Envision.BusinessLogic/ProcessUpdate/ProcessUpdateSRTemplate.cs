using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateSRTemplate : IBusinessLogic
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public ProcessUpdateSRTemplate()
        {
            this.SR_TEMPLATE = new SR_TEMPLATE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRTemplateUpdate processor = new SRTemplateUpdate();
            processor.SR_TEMPLATE = this.SR_TEMPLATE;
            processor.UpdateData();
        }

        #endregion
    }
}
