using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class FINPaymentdtlSelectData : DataAccessBase 
	{
        public FIN_PAYMENTDTL FIN_PAYMENTDTL { get; set; }

		public  FINPaymentdtlSelectData()
		{
            FIN_PAYMENTDTL = new FIN_PAYMENTDTL();
            StoredProcedureName = StoredProcedure.Prc_FIN_PAYMENTDTL_Select;
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
                                                Parameter("@PAY_ID"     ,   FIN_PAYMENTDTL.PAY_ID)
                                                ,Parameter("@EXAM_ID"   ,   FIN_PAYMENTDTL.EXAM_ID)
                                                ,Parameter("@FROM_DATE" ,   FIN_PAYMENTDTL.FROM_DATE)
                                                ,Parameter("@TO_DATE"   ,   FIN_PAYMENTDTL.TO_DATE)
                                                ,Parameter("@HN"        ,   FIN_PAYMENTDTL.HN)
                                       };
            return parameters;
        }
	}
}

