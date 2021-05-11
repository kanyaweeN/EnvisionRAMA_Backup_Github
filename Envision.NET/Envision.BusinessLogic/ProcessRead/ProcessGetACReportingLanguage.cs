using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetACReportingLanguage : IBusinessLogic
    {
        public int ORG_ID { get; set; }
        public DataSet Result { get; set; }


        #region IBusinessLogic Members

        public void Invoke()
        {
            ACReportingLanguageSelect processor = new ACReportingLanguageSelect();
            this.Result = processor.GetReportingLanguage(this.ORG_ID);
        }

        #endregion
    }
}
