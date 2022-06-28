using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class ACReportingLanguageInsert : DataAccessBase
    {
        public AC_REPORTINGLANGUAGE AC_REPORTINGLANGUAGE { get; set; }
        public ACReportingLanguageInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_AC_REPORTINGLANGUAGE_INSERT;
        }

        public DataSet InsertData()
        {
            this.ParameterList = new DbParameter[] 
            {
                Parameter("@REPORT_LANG_LABEL", this.AC_REPORTINGLANGUAGE.REPORT_LANG_LABEL),
                Parameter("@REPORT_LANG_VALUE", this.AC_REPORTINGLANGUAGE.REPORT_LANG_VALUE),
                Parameter("@ORG_ID", this.AC_REPORTINGLANGUAGE.ORG_ID),
                Parameter("@CREATED_BY", this.AC_REPORTINGLANGUAGE.CREATED_BY),
                Parameter("@SEND_MESSAGE", this.AC_REPORTINGLANGUAGE.SEND_MESSAGE)
            };
            return this.ExecuteDataSet();
        }
    }
}
