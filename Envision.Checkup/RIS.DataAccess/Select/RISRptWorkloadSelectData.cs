using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISRptWorkloadSelectData : DataAccessBase
    {
        private int orderID;
        private DateTime fromDate;
        private DateTime toDate;
        private string jobTitle;

        RISRptWorkloadDataParameters _risrptworkloadparameter;

        public RISRptWorkloadSelectData(int OrderID, DateTime FromDate, DateTime ToDate, String JobTitle)
        {
            orderID = OrderID;
            fromDate = FromDate;
            toDate = ToDate;
            jobTitle = JobTitle;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RptWorkload.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _risrptworkloadparameter = new RISRptWorkloadDataParameters(orderID, fromDate, toDate, jobTitle);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _risrptworkloadparameter.Parameters);
            return ds;
        }
    }

    public class RISRptWorkloadDataParameters
    {
        private SqlParameter[] _parameters;
        private int orderID;
        private DateTime fromDate;
        private DateTime toDate;
        private string jobTitle;

        public RISRptWorkloadDataParameters(int OrderID, DateTime FromDate, DateTime ToDate, string JobTitle)
        {
            orderID = OrderID;
            fromDate = FromDate;
            toDate = ToDate;
            jobTitle = JobTitle;
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
                                            new SqlParameter("@UserID", orderID), 
                                            new SqlParameter( "@FromDate", fromDate ) ,
				                            new SqlParameter( "@ToDate", toDate ),
                                            new SqlParameter( "@JobTitle", jobTitle )
                                        };
            Parameters = parameters;
        }
    }
}
