using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISBillingMessageSelect : DataAccessBase
    {
        public RISBillingMessageSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_BillingGenMessage;
        }

        public DataSet GetBillingMessage(string AcessionNo, string created_by)
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@ACCESSION_NO", AcessionNo),
                Parameter("@CREATED_BY", created_by),
            };
            return this.ExecuteDataSet();
        }
    }
}
