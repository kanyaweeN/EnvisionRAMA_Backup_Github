using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateSRTemplatePart : IBusinessLogic
    {

        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }

        public ProcessUpdateSRTemplatePart()
        {
            this.SR_TEMPLATEPART = new SR_TEMPLATEPART();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            SrTemplatePartUpdate processor = new SrTemplatePartUpdate();
            processor.SR_TEMPLATEPART = this.SR_TEMPLATEPART;
            processor.UpdateData();
        }

        #endregion
    }
}
