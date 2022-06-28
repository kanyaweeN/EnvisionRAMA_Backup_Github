using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddMGBreastMarkTemplate : IBusinessLogic
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }

        public ProcessAddMGBreastMarkTemplate()
        {
            this.MG_BREASTMARKTEMPLATE = new MG_BREASTMARKTEMPLATE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkTemplateInsert processor = new MGBreastMarkTemplateInsert();
            processor.MG_BREASTMARKTEMPLATE = this.MG_BREASTMARKTEMPLATE;
            processor.InsertData();
        }

        #endregion
    }
}
