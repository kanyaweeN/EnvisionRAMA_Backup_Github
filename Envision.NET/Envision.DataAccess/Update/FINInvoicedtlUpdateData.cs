//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:43
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class FINInvoicedtlUpdateData : DataAccessBase 
	{

        public FIN_INVOICEDTL FIN_INVOICEDTL { get; set; }

		public  FINInvoicedtlUpdateData()
		{
            FIN_INVOICEDTL = new FIN_INVOICEDTL();
			StoredProcedureName = StoredProcedure.Prc_FIN_INVOICEDTL_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Update(DbTransaction tran) 
		{
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
//Parameter("@INV_ID",FIN_INVOICEDTL.INV_ID)
//,Parameter("@EXAM_ID",FIN_INVOICEDTL.EXAM_ID)
//,Parameter("@ITEM_ID",FIN_INVOICEDTL.ITEM_ID)
//,Parameter("@QTY",FIN_INVOICEDTL.QTY)
//,Parameter("@RATE",FIN_INVOICEDTL.RATE)
//,Parameter("@DISCOUNT",FIN_INVOICEDTL.DISCOUNT)
//,Parameter("@PAYABLE",FIN_INVOICEDTL.PAYABLE)
//,Parameter("@STATUS",FIN_INVOICEDTL.STATUS)
//,Parameter("@ORG_ID",FIN_INVOICEDTL.ORG_ID)
//,Parameter("@CREATED_BY",FIN_INVOICEDTL.CREATED_BY)
//,Parameter("@CREATED_ON",FIN_INVOICEDTL.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",FIN_INVOICEDTL.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",FIN_INVOICEDTL.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

