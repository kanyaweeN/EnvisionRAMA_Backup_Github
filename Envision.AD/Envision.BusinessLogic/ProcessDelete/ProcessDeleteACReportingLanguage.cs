using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteACReportingLanguage : IBusinessLogic
    {
        public AC_REPORTINGLANGUAGE AC_REPORTINGLANGUAGE { get; set; }

        public ProcessDeleteACReportingLanguage()
        {
            this.AC_REPORTINGLANGUAGE = new AC_REPORTINGLANGUAGE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            ACReportingLanguageDelete processor = new ACReportingLanguageDelete();
            processor.AC_REPORTINGLANGUAGE = this.AC_REPORTINGLANGUAGE;
            processor.DeleteData();
        }

        #endregion
    }
}
