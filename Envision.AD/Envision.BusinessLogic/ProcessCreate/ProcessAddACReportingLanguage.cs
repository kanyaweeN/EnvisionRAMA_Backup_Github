using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACReportingLanguage : IBusinessLogic
    {
        public AC_REPORTINGLANGUAGE AC_REPORTINGLANGUAGE { get; set; }

        public ProcessAddACReportingLanguage()
        {
            this.AC_REPORTINGLANGUAGE = new AC_REPORTINGLANGUAGE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            ACReportingLanguageInsert processor = new ACReportingLanguageInsert();
            processor.AC_REPORTINGLANGUAGE = this.AC_REPORTINGLANGUAGE;
            DataSet ds = processor.InsertData();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        this.AC_REPORTINGLANGUAGE.REPORT_LANG_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["REPORT_LANG_ID"]);
                    }
                }
            }
        }

        #endregion
    }
}
