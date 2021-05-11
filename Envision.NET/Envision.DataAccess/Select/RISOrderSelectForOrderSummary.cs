using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISOrderSelectForOrderSummary : DataAccessBase
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public RISOrderSelectForOrderSummary()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectForOrderSummary;
        }

        public DataSet GetData()
        {
            this.ParameterList = new DbParameter[]{
                Parameter("@ACCESSION_NO", this.RIS_ORDERDTL.ACCESSION_NO),
                Parameter("@ORG_ID", this.RIS_ORDERDTL.ORG_ID)
            };
            return this.ExecuteDataSet();
        }
    }
}
