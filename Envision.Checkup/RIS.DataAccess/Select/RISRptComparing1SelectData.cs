using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISRptComparing1SelectData : DataAccessBase
    {
        private string fromDate;
        private string toDate;
        private string fromDate2;
        private string toDate2;
        
        RISRptComparing1DataParameters _risrptComparing1parameter;

        public RISRptComparing1SelectData(String FromDate, String ToDate, String FromDate2, String ToDate2)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RptComparing1.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _risrptComparing1parameter = new RISRptComparing1DataParameters(fromDate, toDate,fromDate2, toDate2);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _risrptComparing1parameter.Parameters);
            return ds;
        }
    }

    public class RISRptComparing1DataParameters
    {
        private SqlParameter[] _parameters;
        private string fromDate;
        private string toDate;
        private string fromDate2;
        private string toDate2;

        public RISRptComparing1DataParameters(string FromDate, string ToDate, string FromDate2, string ToDate2)
        {
            fromDate = FromDate;
            toDate = ToDate;
            fromDate2 = FromDate2;
            toDate2 = ToDate2;
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
				                            new SqlParameter( "@ToDate2", toDate2 )
                                        };
            Parameters = parameters;
        }
    }
}
