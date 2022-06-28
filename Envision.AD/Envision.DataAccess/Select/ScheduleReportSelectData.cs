using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ScheduleReportSelectData : DataAccessBase
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        public ReportParameters ReportParameters { get; set; }
        public ScheduleReportSelectData()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            ReportParameters = new ReportParameters();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_REPORT;
        }

        public DataSet getReport()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_XRPTREPORT;
            DataSet ds = new DataSet();
            ParameterList = buildParameterXrptReport();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getReportAIMC()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_XRPTREPORT_AIMC;
            DataSet ds = new DataSet();
            ParameterList = buildParameterXrptReport();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterXrptReport()
        {
            DbParameter[] parameters ={			
				Parameter( "@ORG_ID"	, RIS_SCHEDULE.ORG_ID ),
                Parameter( "@SCHEDULE_ID"        , RIS_SCHEDULE.SCHEDULE_ID )
			};
            return parameters;
        }
        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
				Parameter( "@HN"	, RIS_SCHEDULE.HN ),
                Parameter( "@APPOINT_DT"		    , RIS_SCHEDULE.START_DATETIME ) ,
				Parameter( "@MODALITY_ID"        , RIS_SCHEDULE.MODALITY_ID ),
                Parameter( "@SCHEDULE_ID"        , RIS_SCHEDULE.SCHEDULE_ID )
			};
            return parameters;
        }
        public DataSet Get(DateTime dStart,DateTime dEnd,int SessionID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_AppointDate;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_RptAppoint(dStart, dEnd, SessionID);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_RptAppoint(DateTime dStart, DateTime dEnd, int SessionID)
        {
            DbParameter[] parameters ={			
				Parameter( "@FromDate"	, dStart ),
                Parameter( "@ToDate"		    , dEnd ) ,
                Parameter( "@USER_ID"		    , new  GBLEnvVariable().UserID) ,
				Parameter( "@MODALITY_ID"        , ReportParameters.ModalityId ),
			    Parameter( "@SESSION_ID"        , SessionID )
			};
            return parameters;
        }
    }
}
