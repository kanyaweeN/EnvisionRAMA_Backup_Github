using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class FINInvoiceSelectData : DataAccessBase 
	{
        public FIN_INVOICE FIN_INVOICE { get; set; }

		public  FINInvoiceSelectData()
		{
            FIN_INVOICE = new FIN_INVOICE();
            StoredProcedureName = StoredProcedure.Prc_FIN_INVOICE_Select;
		}
		
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
//new SqlParameter("@INV_ID",FINInvoice.INV_ID)
//,new SqlParameter("@INV_DT",FINInvoice.INV_DT)
//,new SqlParameter("@HN",FINInvoice.HN)
//,new SqlParameter("@UNIT_ID",FINInvoice.UNIT_ID)
//,new SqlParameter("@EMP_ID",FINInvoice.EMP_ID)
			
//,new SqlParameter("@STATUS",FINInvoice.STATUS)
//,new SqlParameter("@ORG_ID",FINInvoice.ORG_ID)
//,new SqlParameter("@CREATED_BY",FINInvoice.CREATED_BY)
//,new SqlParameter("@CREATED_ON",FINInvoice.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",FINInvoice.LAST_MODIFIED_BY)
			
//,new SqlParameter("@LAST_MODIFIED_ON",FINInvoice.LAST_MODIFIED_ON)
                                       };
            return parameters;
        }
	}
}

