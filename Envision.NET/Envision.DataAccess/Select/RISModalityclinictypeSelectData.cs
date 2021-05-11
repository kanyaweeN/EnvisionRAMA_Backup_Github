using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISModalityclinictypeSelectData : DataAccessBase 
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }

		public RISModalityclinictypeSelectData()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
            RIS_SCHEDULE = new RIS_SCHEDULE();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYCLINICTYPE_Select;
		}
        public DataSet GetCheckTime() {
            DataSet ds = new DataSet();
            ParameterList = buildParameter_CheckTime();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_CheckTime()
        {
            DbParameter[] parameters ={			
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID),
                Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID),
                Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME),
                Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
			};
            return parameters;
        }
        public DataSet GetExamClinicType()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYCLINICTYPE_Select_InExamForm;
            ParameterList = buildParameter_ExamClinicType();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_ExamClinicType()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",RIS_MODALITYCLINICTYPE.MODALITY_ID),
                Parameter("@MODE",RIS_MODALITYCLINICTYPE.MODE)
			};
            return parameters;
        }
	}
}

