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
	public class FINPaymentUpdateData : DataAccessBase 
	{
        public FIN_PAYMENT FIN_PAYMENT { get; set; }

		public  FINPaymentUpdateData()
		{
            FIN_PAYMENT = new FIN_PAYMENT();
			StoredProcedureName = StoredProcedure.Prc_FIN_PAYMENT_Update;
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
//Parameter("@PAY_ID",FIN_PAYMENT.PAY_ID)
//,Parameter("@PAY_DT",FIN_PAYMENT.PAY_DT)
//,Parameter("@INV_ID",FIN_PAYMENT.INV_ID)
//,Parameter("@HN",FIN_PAYMENT.HN)
//,Parameter("@UNIT_ID",FIN_PAYMENT.UNIT_ID)
//,Parameter("@EMP_ID",FIN_PAYMENT.EMP_ID)
//,Parameter("@STATUS",FIN_PAYMENT.STATUS)
//,Parameter("@ORG_ID",FIN_PAYMENT.ORG_ID)
//,Parameter("@CREATED_BY",FIN_PAYMENT.CREATED_BY)
//,Parameter("@CREATED_ON",FIN_PAYMENT.CREATED_ON)
//,Parameter("@LAST_MODIFIED_BY",FIN_PAYMENT.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",FIN_PAYMENT.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
	}
}

