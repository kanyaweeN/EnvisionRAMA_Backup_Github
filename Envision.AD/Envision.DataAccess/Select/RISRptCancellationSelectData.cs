using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISRptCancellationSelectData : DataAccessBase
    {
        private string fromDate;
        private string toDate;
        
        public RISRptCancellationSelectData(String FromDate, String ToDate)
        {
            fromDate = FromDate;
            toDate = ToDate;
            StoredProcedureName = StoredProcedure.Prc_RIS_RptCancellation;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(fromDate, toDate);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(String fromDate, String toDate)
        {
            DbParameter[] parameters ={			
                                            Parameter( "@FromDate", fromDate ) ,
				                            Parameter( "@ToDate", toDate ),
			};
            return parameters;
        }
    }
}
