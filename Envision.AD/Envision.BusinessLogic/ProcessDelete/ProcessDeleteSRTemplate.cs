using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSRTemplate : IBusinessLogic
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public ProcessDeleteSRTemplate()
        {
            this.SR_TEMPLATE = new SR_TEMPLATE();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            SrTemplateDelete processor = new SrTemplateDelete();
            processor.SR_TEMPLATE = this.SR_TEMPLATE;
            processor.DeleteData();
        }

        #endregion
    }
}
