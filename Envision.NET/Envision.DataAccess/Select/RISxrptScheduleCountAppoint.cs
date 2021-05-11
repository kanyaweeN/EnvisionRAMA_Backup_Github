using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISxrptScheduleCountAppoint : DataAccessBase
    {
        public ReportParameters ReportParameters { get; set; }
        public RISxrptScheduleCountAppoint()
		{
            ReportParameters = new ReportParameters();
			StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_ScheduleCountAppoint;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
			return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY",ReportParameters.ModalityId)
                ,Parameter("@FROMDATE",ReportParameters.FromDate)
                ,Parameter("@ENDDATE",ReportParameters.ToDate)
			};
            return parameters;
        }
        public DataSet GetDataWithSession()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_ScheduleCountAppointWithSession;
            DataSet ds = new DataSet();
            ParameterList = buildParameterWithSession();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterWithSession()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY",ReportParameters.ModalityId)
                ,Parameter("@FROMDATE",ReportParameters.FromDate)
                ,Parameter("@ENDDATE",ReportParameters.ToDate)
                ,Parameter("@SESSION_ID",ReportParameters.Session)
			};
            return parameters;
        }
    }
}
