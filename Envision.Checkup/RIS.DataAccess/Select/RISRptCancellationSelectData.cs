using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISRptCancellationSelectData : DataAccessBase
    {
        private string fromDate;
        private string toDate;
        
        RISRptCancellationDataParameters _risrptCancellationparameter;

        public RISRptCancellationSelectData(String FromDate, String ToDate)
        {
            fromDate = FromDate;
            toDate = ToDate;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RptCancellation.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _risrptCancellationparameter = new RISRptCancellationDataParameters(fromDate, toDate);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _risrptCancellationparameter.Parameters);
            return ds;
        }
    }

    public class RISRptCancellationDataParameters
    {
        private SqlParameter[] _parameters;
        private string fromDate;
        private string toDate;
        
        public RISRptCancellationDataParameters(string FromDate, string ToDate)
        {
            fromDate = FromDate;
            toDate = ToDate;
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
                                        };
            Parameters = parameters;
        }
    }
}
