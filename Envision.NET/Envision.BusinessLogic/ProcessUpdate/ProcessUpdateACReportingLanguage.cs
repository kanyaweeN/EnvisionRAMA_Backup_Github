using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Update;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateACReportingLanguage : IBusinessLogic
    {
        public AC_REPORTINGLANGUAGE AC_REPORTINGLANGUAGE { get; set; }

        public ProcessUpdateACReportingLanguage()
        {
            this.AC_REPORTINGLANGUAGE = new AC_REPORTINGLANGUAGE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            ACReportingLanguageUpdate processor = new ACReportingLanguageUpdate();
            processor.AC_REPORTINGLANGUAGE = this.AC_REPORTINGLANGUAGE;
            processor.UpdateData();
        }

        #endregion
    }
}
