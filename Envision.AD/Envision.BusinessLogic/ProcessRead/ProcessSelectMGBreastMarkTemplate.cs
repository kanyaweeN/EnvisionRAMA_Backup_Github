using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessSelectMGBreastMarkTemplate : IBusinessLogic
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }
        public DataSet Result { get; set; }

        public ProcessSelectMGBreastMarkTemplate()
        {
            this.MG_BREASTMARKTEMPLATE = new MG_BREASTMARKTEMPLATE();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkTemplateSelect processor = new MGBreastMarkTemplateSelect();
            processor.MG_BREASTMARKTEMPLATE = this.MG_BREASTMARKTEMPLATE;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
