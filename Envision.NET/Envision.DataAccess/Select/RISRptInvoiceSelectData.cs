using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISRptInvoiceSelectData : DataAccessBase
    {
        public FIN_INVOICE FIN_INVOICE { get; set; }
        public RISRptInvoiceSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RptInvoice;
            FIN_INVOICE = new FIN_INVOICE();
        }
        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter( "@PAY_ID"	, FIN_INVOICE.PAY_ID)
                ,Parameter("@RefName",FIN_INVOICE.REF_NAME)
                ,Parameter("@RefAdr",FIN_INVOICE.REF_ADR)
                ,Parameter("@Status",FIN_INVOICE.STATUS)
			};
            return parameters;
        }
    }
}
