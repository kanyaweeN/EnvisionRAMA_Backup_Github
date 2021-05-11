using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class ScheduleReportSelectData : DataAccessBase
    {
        private ReportParameters _parameter;
        private ScheduleReportDataParameters _examResultSelectDataParameters;

        public ScheduleReportSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_REPORT.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _examResultSelectDataParameters = new ScheduleReportDataParameters(ReportParameters);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _examResultSelectDataParameters.Parameters);
            return ds;
        }
        public DataSet Get(DateTime dStart,DateTime dEnd,int SessionID)
        {
            DataSet ds;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_Rpt_AppointDate.ToString();
            //StoredProcedureName = "Prc_RIS_Rpt_AppointDate_Test";
            _examResultSelectDataParameters = new ScheduleReportDataParameters(ReportParameters, dStart, dEnd, SessionID);
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

    public class ScheduleReportDataParameters
    {
        private ReportParameters _parameter;
        private SqlParameter[] _parameters;

        public ScheduleReportDataParameters(ReportParameters result)
        {
            ReportParameters = result;
            Build();
        }
        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@HN"	, ReportParameters.PatientId ),
                new SqlParameter( "@APPOINT_DT"		    , ReportParameters.AppointDate ) ,
				new SqlParameter( "@MODALITY_ID"        , ReportParameters.ModalityId ),
                new SqlParameter( "@SCHEDULE_ID"        , ReportParameters.ScheduleID )
             				
				
		    };

            Parameters = parameters;
        }

        public ScheduleReportDataParameters(ReportParameters result,DateTime dStart,DateTime dEnd,int SessionID)
        {
            ReportParameters = result;
            Build(dStart, dEnd, SessionID);
        }
        private void Build(DateTime dStart, DateTime dEnd,int SessionID)
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@FromDate"	, dStart ),
                new SqlParameter( "@ToDate"		    , dEnd ) ,
                new SqlParameter( "@USER_ID"		    , ReportParameters.SpType ) ,
				new SqlParameter( "@MODALITY_ID"        , ReportParameters.ModalityId ),
			    new SqlParameter( "@SESSION_ID"        , SessionID )
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
