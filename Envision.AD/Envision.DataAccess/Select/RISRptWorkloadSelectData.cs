using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISRptWorkloadSelectData : DataAccessBase
    {
        private int orderID;
        private string fromDate;
        private string toDate;
        private string jobTitle;
        public RISRptWorkloadSelectData(int OrderID, String FromDate, String ToDate, String JobTitle)
        {
            orderID = OrderID;
            fromDate = FromDate;
            toDate = ToDate;
            jobTitle = JobTitle;
            StoredProcedureName = StoredProcedure.Prc_RIS_RptWorkload;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                                            Parameter("@UserID", orderID), 
                                            Parameter( "@FromDate", fromDate ) ,
				                            Parameter( "@ToDate", toDate ),
                                            Parameter( "@JobTitle", jobTitle )
			};
            return parameters;
        }
    }
}
