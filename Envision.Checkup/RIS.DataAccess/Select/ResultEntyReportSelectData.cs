using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class ResultEntyReportSelectData : DataAccessBase
    {
        private ReportParameters _parameter;
        private ExamResultReportDataParameters _examResultSelectDataParameters;

        public ResultEntyReportSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ReportExamResult.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _examResultSelectDataParameters = new ExamResultReportDataParameters(ReportParameters);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _examResultSelectDataParameters.Parameters);
            return ds;
        }
        public ReportParameters ReportParameters
        {
            get { return _parameter; }
            set { _parameter = value; }
        }
    }

    public class ExamResultReportDataParameters
    {
        private ReportParameters _parameter;
        private SqlParameter[] _parameters;

        public ExamResultReportDataParameters(ReportParameters result)
        {
            ReportParameters = result;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, ReportParameters.SpType ),
                new SqlParameter( "@ACCESSION_NO"		    , ReportParameters.AccessionNo ) ,
				new SqlParameter( "@ORG_ID"        , new RIS.Common.Common.GBLEnvVariable().OrgID )
             				
				
		    };

            Parameters = parameters;
        }

        public ReportParameters ReportParameters
        {
            get { return _parameter; }
            set { _parameter = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
