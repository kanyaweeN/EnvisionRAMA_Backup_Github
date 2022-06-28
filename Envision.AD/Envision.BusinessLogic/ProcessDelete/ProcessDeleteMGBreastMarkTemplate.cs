using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Delete;
using System.Data;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteMGBreastMarkTemplate : IBusinessLogic
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }

        public ProcessDeleteMGBreastMarkTemplate()
        {
            this.MG_BREASTMARKTEMPLATE = new MG_BREASTMARKTEMPLATE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkTemplateDelete processor = new MGBreastMarkTemplateDelete();
            processor.MG_BREASTMARKTEMPLATE = this.MG_BREASTMARKTEMPLATE;
            processor.DeleteData();
        }

        #endregion
    }
}
