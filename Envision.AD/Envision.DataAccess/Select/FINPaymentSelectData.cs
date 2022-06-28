using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class FINPaymentSelectData : DataAccessBase 
	{
        public FIN_PAYMENT FIN_PAYMENT { get; set; }

		public  FINPaymentSelectData()
		{
            FIN_PAYMENT = new FIN_PAYMENT();
            StoredProcedureName = StoredProcedure.Prc_FIN_PAYMENT_Select;
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
            if (FIN_PAYMENT.FROM_DATE == DateTime.MinValue)
                FIN_PAYMENT.FROM_DATE = DateTime.Now;
            if (FIN_PAYMENT.TO_DATE == DateTime.MinValue)
                FIN_PAYMENT.TO_DATE = DateTime.Now;
            DbParameter[] parameters = { 
                                               
                                                  Parameter("@PAY_ID",FIN_PAYMENT.PAY_ID)

                                                //,new SqlParameter("@PAY_DT",FINPayment.PAY_DT)
                                                //,new SqlParameter("@INV_ID",FINPayment.INV_ID)
                                                //,new SqlParameter("@HN",FINPayment.HN)
                                                //,new SqlParameter("@UNIT_ID",FINPayment.UNIT_ID)
                                                			
                                                //,new SqlParameter("@EMP_ID",FINPayment.EMP_ID)
                                                //,new SqlParameter("@STATUS",FINPayment.STATUS)
                                                //,new SqlParameter("@ORG_ID",FINPayment.ORG_ID)
                                                //,new SqlParameter("@CREATED_BY",FINPayment.CREATED_BY)
                                                //,new SqlParameter("@CREATED_ON",FINPayment.CREATED_ON)
                                                			
                                                //,new SqlParameter("@LAST_MODIFIED_BY",FINPayment.LAST_MODIFIED_BY)
                                                //,new SqlParameter("@LAST_MODIFIED_ON",FINPayment.LAST_MODIFIED_ON)
                                                , Parameter("@FROM_DATE", FIN_PAYMENT.FROM_DATE)
                                                , Parameter("@TO_DATE",FIN_PAYMENT.TO_DATE)
                                                , Parameter("@ORDER_ID",FIN_PAYMENT.ORDER_ID)
                                                , Parameter("@HN",FIN_PAYMENT.HN)
                                       };
            return parameters;
        }
	}
}

