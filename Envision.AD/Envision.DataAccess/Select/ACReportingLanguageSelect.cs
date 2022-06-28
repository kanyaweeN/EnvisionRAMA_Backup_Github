using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class ACReportingLanguageSelect : DataAccessBase
    {
        public ACReportingLanguageSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_AC_REPORTINGLANGUAGE_SELECT;
        }
        public DataSet GetReportingLanguage(int orgId)
        {
            this.ParameterList = new DbParameter[] { 
                this.Parameter("@ORG_ID", orgId)
            };
            return this.ExecuteDataSet();
        }
    }
}
