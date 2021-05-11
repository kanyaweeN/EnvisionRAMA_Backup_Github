using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISBillinglogWithHISSelectData: DataAccessBase 
	{
        public RIS_BILLINGLOG_WITH_HIS RIS_BILLINGLOG_WITH_HIS { get; set; }

        public RISBillinglogWithHISSelectData()
		{
            RIS_BILLINGLOG_WITH_HIS = new RIS_BILLINGLOG_WITH_HIS();
            StoredProcedureName = StoredProcedure.Prc_RIS_BILLINGLOG_WITH_HIS_Select;
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
                                        Parameter("@ORDER_ID",RIS_BILLINGLOG_WITH_HIS.ORDER_ID)
                                       };
            return parameters;
        }
	}
}

