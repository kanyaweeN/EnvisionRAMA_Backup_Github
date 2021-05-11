using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISRptServiceSelectData : DataAccessBase
    {
        private string roomID;
        private string fromDate;
        private string toDate;
        private string examType;

        RISRptServiceDataParameters _risrptServiceparameter;

        public RISRptServiceSelectData(string RoomID, String FromDate, String ToDate, String ExamType)
        {
            roomID = RoomID;
            fromDate = FromDate;
            toDate = ToDate;
            examType = ExamType;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RptService.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _risrptServiceparameter = new RISRptServiceDataParameters(roomID, fromDate, toDate, examType);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _risrptServiceparameter.Parameters);
            return ds;
        }
    }

    public class RISRptServiceDataParameters
    {
        private SqlParameter[] _parameters;
        private string roomID;
        private string fromDate;
        private string toDate;
        private string examType;

        public RISRptServiceDataParameters(string RoomID, string FromDate, string ToDate, string ExamType)
        {
            roomID = RoomID;
            fromDate = FromDate;
            toDate = ToDate;
            examType = ExamType;
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
                                            new SqlParameter( "@RoomID", roomID), 
                                            new SqlParameter( "@examType", examType )
                                        };
            Parameters = parameters;
        }
    }
}
