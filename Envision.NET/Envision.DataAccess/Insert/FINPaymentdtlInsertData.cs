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

namespace Envision.DataAccess.Insert
{
	public class FINPaymentdtlInsertData : DataAccessBase 
	{
        public FIN_PAYMENTDTL FIN_PAYMENTDTL { get; set; }
		public  FINPaymentdtlInsertData()
		{
            FIN_PAYMENTDTL = new FIN_PAYMENTDTL();
			StoredProcedureName = StoredProcedure.Prc_FIN_PAYMENTDTL_Insert;
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Add(DbTransaction tran) 
		{
             ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
//Parameter("@PAY_ID",FIN_PAYMENTDTL.PAY_ID)
//,Parameter("@EXAM_ID",FIN_PAYMENTDTL.EXAM_ID)
//,Parameter("@ITEM_ID",FIN_PAYMENTDTL.ITEM_ID)
//,Parameter("@QTY",FIN_PAYMENTDTL.QTY)
//,Parameter("@RATE",FIN_PAYMENTDTL.RATE)
//,Parameter("@DISCOUNT",FIN_PAYMENTDTL.DISCOUNT)
//,Parameter("@PAYABLE",FIN_PAYMENTDTL.PAYABLE)
//,Parameter("@PAID",FIN_PAYMENTDTL.PAID)
//,Parameter("@STATUS",FIN_PAYMENTDTL.STATUS)
//,Parameter("@ORG_ID",FIN_PAYMENTDTL.ORG_ID)
//,Parameter("@CREATED_BY",FIN_PAYMENTDTL.CREATED_BY)
//,Parameter("@CREATED_ON",FIN_PAYMENTDTL.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",FIN_PAYMENTDTL.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",FIN_PAYMENTDTL.LAST_MODIFIED_ON)
            };
            return parameters;
        }
	}
}

