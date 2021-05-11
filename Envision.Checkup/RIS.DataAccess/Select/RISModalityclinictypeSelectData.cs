//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/03/2552 08:28:35
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISModalityclinictypeSelectData : DataAccessBase 
	{
		private RISModalityclinictype	_rismodalityclinictype;
        private RISSchedule _risschedule;
        private RISModalityclinictypeCheckTimeDataParameters _paramCheckTime;

		public RISModalityclinictypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYCLINICTYPE_Select.ToString();
		}
		public RISModalityclinictype	RISModalityclinictype
		{
			get{return _rismodalityclinictype;}
			set{_rismodalityclinictype=value;}
		}
        public RISSchedule RISSchedule {
            get { return _risschedule; }
            set { _risschedule = value; }
        }
		public DataSet GetData()
		{
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
        public DataSet GetCheckTime() {
            _paramCheckTime = new RISModalityclinictypeCheckTimeDataParameters(RISSchedule);
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYCLINICTYPE_CheckMax.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString,_paramCheckTime.Parameters);
            return ds;
        }
        public DataSet GetExamClinicType()
        {
            RISModalityclinictypeCheckTimeDataParameters_GetExamClinicType
                param = new RISModalityclinictypeCheckTimeDataParameters_GetExamClinicType(RISModalityclinictype);
            DataBaseHelper dbhelper = new DataBaseHelper("Prc_RIS_MODALITYCLINICTYPE_Select_InExamForm");
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds;
        }
	}

    public class RISModalityclinictypeCheckTimeDataParameters {
        private RISSchedule _risschedule;
        private SqlParameter[] _parameters;

        public RISModalityclinictypeCheckTimeDataParameters(RISSchedule schedule) {
            _risschedule = schedule;
            Build();
        }
        public RISSchedule RISSchedule
		{
            get { return _risschedule; }
            set { _risschedule = value; }
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
        public void Build() {
            SqlParameter[] parameters ={
                new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID),
                new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID),
                new SqlParameter("@START_DATETIME",RISSchedule.APPOINT_DT),
                new SqlParameter("@END_DATETIME",RISSchedule.END_DATETIME),
            };
            Parameters = parameters;
        }
    }

    public class RISModalityclinictypeCheckTimeDataParameters_GetExamClinicType
    {
        private RISModalityclinictype _rismodalityclinictype;
        private SqlParameter[] _parameters;

        public RISModalityclinictypeCheckTimeDataParameters_GetExamClinicType(RISModalityclinictype rismodalityclinictype)
        {
            _rismodalityclinictype = rismodalityclinictype;
            Build();
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public void Build()
        {
            SqlParameter[] parameters ={
                new SqlParameter("@MODALITY_ID",_rismodalityclinictype.MODALITY_ID),
                new SqlParameter("@MODE",_rismodalityclinictype.MODE),
            };
            Parameters = parameters;
        }
    }
}

