using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISTechConsumptionSelectForOrderSummary : DataAccessBase
    {
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }

        public RISTechConsumptionSelectForOrderSummary()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_TECHCONSUMPTION_SelectForOrderSummary;
        }

        public DataSet GetData()
        {
            this.ParameterList = new DbParameter[]
            {
                this.Parameter("@ACCESSION_NO", this.RIS_TECHCONSUMPTION.ACCESSION_NO),
                this.Parameter("@TAKE", this.RIS_TECHCONSUMPTION.TAKE),
                this.Parameter("@ORG_ID", this.RIS_TECHCONSUMPTION.ORG_ID)
            };
            return this.ExecuteDataSet();
        }

    }
}
