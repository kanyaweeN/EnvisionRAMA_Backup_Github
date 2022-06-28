using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class ACReportingLanguageDelete : DataAccessBase
    {
        public AC_REPORTINGLANGUAGE AC_REPORTINGLANGUAGE { get; set; }
        public ACReportingLanguageDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_AC_REPORTINGLANGUAGE_DELETE;
        }
        public void DeleteData()
        {
            this.ParameterList = new DbParameter[]
            {
                Parameter("@REPORT_LANG_ID", this.AC_REPORTINGLANGUAGE.REPORT_LANG_ID),
                Parameter("@ORG_ID", this.AC_REPORTINGLANGUAGE.ORG_ID),
            };
            this.ExecuteNonQuery();
        }

    }
}
