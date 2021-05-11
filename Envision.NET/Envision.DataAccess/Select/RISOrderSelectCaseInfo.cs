using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISOrderSelectCaseInfo : DataAccessBase
    {
        public RISOrderSelectCaseInfo()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_GetCaseInfo;
        }

        public DataSet GetData(string accessionNo, int orgId)
        {
            this.ParameterList = new DbParameter[]{
                Parameter("@ACCESSION_NO", accessionNo),
                Parameter("@ORG_ID", orgId)
            };
            return this.ExecuteDataSet();
        }
    }
}
