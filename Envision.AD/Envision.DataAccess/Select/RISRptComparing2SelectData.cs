using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISRptComparing2SelectData : DataAccessBase
    {
        private string fromDate;
        private string toDate;
        private string fromDate2;
        private string toDate2;
        private string empid;
        public RISRptComparing2SelectData(String FromDate, String ToDate, String FromDate2, String ToDate2, String EmpID)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
            empid = EmpID;
            StoredProcedureName = StoredProcedure.Prc_RIS_RptComparing2;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(fromDate, toDate, fromDate2, toDate2, empid);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(string FromDate, string ToDate, string FromDate2, string ToDate2, string EmpID)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
            empid = EmpID;
            DbParameter[] parameters ={			
                                            Parameter( "@FromDate", fromDate ) ,
				                            Parameter( "@ToDate", toDate ),
                                            Parameter( "@FromDate2", fromDate2 ) ,
				                            Parameter( "@ToDate2", toDate2 ),
                                            Parameter( "@EmpID", empid )
			};
            return parameters;
        }
    }
}
