using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISTechWorksSelectForOrderSummary : DataAccessBase
    {
        public RIS_TECHWORK RIS_TECHWORK { get; set; }
        public RISTechWorksSelectForOrderSummary()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_TECHWORKS_SelectForOrderSummary;
        }

        public DataSet GetData()
        {
            this.ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO", this.RIS_TECHWORK.ACCESSION_ON),
                Parameter("@TAKE", this.RIS_TECHWORK.TAKE),
                Parameter("@ORG_ID", this.RIS_TECHWORK.ORG_ID)
            };
            return this.ExecuteDataSet();
        }
    }
}
