using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISRptComparing2SelectData : DataAccessBase
    {
        private string fromDate;
        private string toDate;
        private string fromDate2;
        private string toDate2;
        private string empid;
        
        RISRptComparing2DataParameters _risrptComparing2parameter;

        public RISRptComparing2SelectData(String FromDate, String ToDate, String FromDate2, String ToDate2, String EmpID)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
            empid = EmpID;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RptComparing2.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _risrptComparing2parameter = new RISRptComparing2DataParameters(fromDate, toDate,fromDate2, toDate2, empid);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _risrptComparing2parameter.Parameters);
            return ds;
        }
    }

    public class RISRptComparing2DataParameters
    {
        private SqlParameter[] _parameters;
        private string fromDate;
        private string toDate;
        private string fromDate2;
        private string toDate2;
        private string empid;

        public RISRptComparing2DataParameters(string FromDate, string ToDate, string FromDate2, string ToDate2, string EmpID)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
            empid = EmpID;
            Build();
        }
        
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters = { 
                                            new SqlParameter( "@FromDate", fromDate ) ,
				                            new SqlParameter( "@ToDate", toDate ),
                                            new SqlParameter( "@FromDate2", fromDate2 ) ,
				                            new SqlParameter( "@ToDate2", toDate2 ),
                                            new SqlParameter( "@EmpID", empid )
                                        };
            Parameters = parameters;
        }
    }
}
