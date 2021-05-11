using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRTemplate : IBusinessLogic
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public ProcessAddSRTemplate()
        {
            this.SR_TEMPLATE = new SR_TEMPLATE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SRTemplateInsert processor = new SRTemplateInsert();
            processor.SR_TEMPLATE = this.SR_TEMPLATE;
            processor.InsertData();
        }

        #endregion
    }
}
