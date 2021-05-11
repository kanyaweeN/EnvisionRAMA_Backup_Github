using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class ACReportingLanguageUpdate : DataAccessBase
    {
        public AC_REPORTINGLANGUAGE AC_REPORTINGLANGUAGE { get; set; }

        public ACReportingLanguageUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_AC_REPORTINGLANGUAGE_UPDATE;
        }

        public void UpdateData()
        {
            this.ParameterList = new DbParameter[]{
                Parameter("@REPORT_LANG_LABEL", this.AC_REPORTINGLANGUAGE.REPORT_LANG_LABEL),
                Parameter("@REPORT_LANG_VALUE", this.AC_REPORTINGLANGUAGE.REPORT_LANG_VALUE),
                Parameter("@LAST_MODIFIED_BY", this.AC_REPORTINGLANGUAGE.LAST_MODIFIED_BY),
                Parameter("@ORG_ID", this.AC_REPORTINGLANGUAGE.ORG_ID),
                Parameter("@REPORT_LANG_ID", this.AC_REPORTINGLANGUAGE.REPORT_LANG_ID),
                Parameter("@SEND_MESSAGE", this.AC_REPORTINGLANGUAGE.SEND_MESSAGE)
            };
            this.ExecuteNonQuery();
        }
    }
}
