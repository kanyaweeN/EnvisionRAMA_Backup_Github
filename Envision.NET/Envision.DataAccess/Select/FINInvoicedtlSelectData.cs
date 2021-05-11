using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class FINInvoicedtlSelectData : DataAccessBase 
	{
        public FIN_INVOICEDTL FIN_INVOICEDTL { get; set; }

		public  FINInvoicedtlSelectData()
		{
            FIN_INVOICEDTL = new FIN_INVOICEDTL();
            StoredProcedureName = StoredProcedure.Prc_FIN_INVOICEDTL_Select;
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
                                        //new SqlParameter("@INV_ID",FINInvoicedtl.INV_ID)
//,new SqlParameter("@EXAM_ID",FINInvoicedtl.EXAM_ID)
//,new SqlParameter("@ITEM_ID",FINInvoicedtl.ITEM_ID)
//,new SqlParameter("@QTY",FINInvoicedtl.QTY)
//,new SqlParameter("@RATE",FINInvoicedtl.RATE)
			
//,new SqlParameter("@DISCOUNT",FINInvoicedtl.DISCOUNT)
//,new SqlParameter("@PAYABLE",FINInvoicedtl.PAYABLE)
//,new SqlParameter("@STATUS",FINInvoicedtl.STATUS)
//,new SqlParameter("@ORG_ID",FINInvoicedtl.ORG_ID)
//,new SqlParameter("@CREATED_BY",FINInvoicedtl.CREATED_BY)
			
//,new SqlParameter("@CREATED_ON",FINInvoicedtl.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",FINInvoicedtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",FINInvoicedtl.LAST_MODIFIED_ON)
                                       };
            return parameters;
        }
	}
}

