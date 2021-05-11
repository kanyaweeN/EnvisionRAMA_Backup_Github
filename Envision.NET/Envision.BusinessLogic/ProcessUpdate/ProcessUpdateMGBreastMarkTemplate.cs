using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Update;
using System.Data;


namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateMGBreastMarkTemplate : IBusinessLogic
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }
        /// <summary>
        /// Mode 1: Update marker template by id
        /// Mode 2: Update mark as default
        /// </summary>
        public int Mode { get; set; }

        public ProcessUpdateMGBreastMarkTemplate()
        {
            this.MG_BREASTMARKTEMPLATE = new MG_BREASTMARKTEMPLATE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkTemplateUpdate processor = new MGBreastMarkTemplateUpdate();
            processor.MG_BREASTMARKTEMPLATE = this.MG_BREASTMARKTEMPLATE;
            processor.UpdateData(Mode);
        }

        #endregion
    }
}
