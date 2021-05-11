//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:43
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class FINPaymentdtlUpdateData_UpdateStatus : DataAccessBase 
	{
		private FIN_PAYMENTDTL	_finpaymentdtl;
        public FINPaymentdtlUpdateData_UpdateStatus()
		{
			StoredProcedureName = StoredProcedure.Prc_FIN_PAYMENTDTL_UpdateStatus;
		}
        public FIN_PAYMENTDTL FIN_PAYMENTDTL
		{
			get{return _finpaymentdtl;}
			set{_finpaymentdtl=value;}
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
		}

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
               Parameter("@PAY_ID",FIN_PAYMENTDTL.PAY_ID)
                ,Parameter("@EXAM_ID",FIN_PAYMENTDTL.EXAM_ID)
                ,Parameter("@STATUS",FIN_PAYMENTDTL.STATUS)
                ,Parameter("@ORG_ID",new GBLEnvVariable().OrgID)
                ,Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                                      };
            return parameters;
        }
	}
}

