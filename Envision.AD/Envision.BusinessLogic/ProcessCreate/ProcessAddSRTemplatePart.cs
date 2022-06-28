using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRTemplatePart : IBusinessLogic
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }

        public ProcessAddSRTemplatePart()
        {
            this.SR_TEMPLATEPART = new SR_TEMPLATEPART();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            SRTemplatePartInsert processor = new SRTemplatePartInsert();
            processor.SR_TEMPLATEPART = this.SR_TEMPLATEPART;
            processor.InsertData();
        }

        #endregion
    }
}
