using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISRptOrderSelectData : DataAccessBase
    {
        private string fromDate;
        private string toDate;
        private string specialClinic;

        RISRptOrderDataParameters _risrptOrderparameter;

        public RISRptOrderSelectData(String FromDate, String ToDate, String SpecialClinic)
        {
            fromDate = FromDate;
            toDate = ToDate;
            specialClinic = SpecialClinic;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RptOrder.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _risrptOrderparameter = new RISRptOrderDataParameters(fromDate, toDate, specialClinic);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _risrptOrderparameter.Parameters);
            return ds;
        }
    }

    public class RISRptOrderDataParameters
    {
        private SqlParameter[] _parameters;
        private string fromDate;
        private string toDate;
        private string specialClinic;

        public RISRptOrderDataParameters(string FromDate, string ToDate, string SpecialClinic)
        {
            fromDate = FromDate;
            toDate = ToDate;
            specialClinic = SpecialClinic;
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
                                            new SqlParameter( "@SpecialClinic", specialClinic )
                                        };
            Parameters = parameters;
        }
    }
}
