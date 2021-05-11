using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class MGBreastMarkSelect : DataAccessBase
    {
        public MGBreastMarkSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARK_SELECT;
        }

        public DataSet GetData(string accession, int orgId)
        {
            DataSet ds = null;
            this.ParameterList = this.BuildParameters(accession, orgId);
            ds = this.ExecuteDataSet();
            return ds;
        }

        private DbParameter[] BuildParameters(string accession, int OrgId)
        {
            DbParameter[] parameters = {
                                           Parameter("@ACCESSION_NO", accession),
                                           Parameter("@ORG_ID", OrgId)
                                       };

            return parameters;
        }
    }
}
