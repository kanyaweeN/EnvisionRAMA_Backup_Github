using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSRTemplatePart : IBusinessLogic
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }
        public ProcessDeleteSRTemplatePart()
        {
            this.SR_TEMPLATEPART = new SR_TEMPLATEPART();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            SrTemplatePartDelete processor = new SrTemplatePartDelete();
            processor.SR_TEMPLATEPART = this.SR_TEMPLATEPART;
            processor.DeleteData();
        }

        #endregion
    }
}
