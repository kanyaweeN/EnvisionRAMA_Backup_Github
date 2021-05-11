//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:41
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
	public class FINInvoiceUpdateData : DataAccessBase 
	{
        public FIN_INVOICE FIN_INVOICE { get; set; }
		public  FINInvoiceUpdateData()
		{
            FIN_INVOICE = new FIN_INVOICE();
			StoredProcedureName = StoredProcedure.Prc_FIN_INVOICE_Update;
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
//Parameter("@INV_ID",FIN_INVOICE.INV_ID)
//,Parameter("@INV_DT",FIN_INVOICE.INV_DT)
//,Parameter("@HN",FIN_INVOICE.HN)
//,Parameter("@UNIT_ID",FIN_INVOICE.UNIT_ID)
//,Parameter("@EMP_ID",FIN_INVOICE.EMP_ID)
//,Parameter("@STATUS",FIN_INVOICE.STATUS)
//,Parameter("@ORG_ID",FIN_INVOICE.ORG_ID)
//,Parameter("@CREATED_BY",FIN_INVOICE.CREATED_BY)
//,Parameter("@CREATED_ON",FIN_INVOICE.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",FIN_INVOICE.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",FIN_INVOICE.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

