//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    02/04/2551
//         Status     :    Not Update
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;
namespace RIS.DataAccess.Select
{
	public class RISScheduleSelectData : DataAccessBase 
	{
		private RISSchedule	_risschedule;
        private int action = 0;
		private RISScheduleInsertDataParameters	_risscheduleinsertdataparameters;

		public  RISScheduleSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SelectByHN.ToString();
            _risschedule = new RISSchedule();
            _risschedule.SCHEDULE_ID = 0;
		}
        public RISScheduleSelectData(int ScheduleID) {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SelectByID.ToString();
            _risschedule = new RISSchedule();
            _risschedule.SCHEDULE_ID = ScheduleID;
        }
        public RISScheduleSelectData(string HN)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SelectByHIS.ToString();
            _risschedule = new RISSchedule();
            _risschedule.HN = HN;
            action = 1;
        }
		public  RISSchedule	RISSchedule
		{
			get{return _risschedule;}
			set{_risschedule=value;}
		}
		public DataSet GetData()
		{
            DataSet ds = null;
			_risscheduleinsertdataparameters = new RISScheduleInsertDataParameters(RISSchedule);
            if (action == 1)
                _risscheduleinsertdataparameters = new RISScheduleInsertDataParameters(RISSchedule.HN);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            try
            {
                ds = dbhelper.Run(base.ConnectionString, _risscheduleinsertdataparameters.Parameters);
            }
            catch (Exception ex) { 
            
            }
			return ds;
		}
        public DataSet GetScheduleData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_Select.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = new DataSet();
            ds = dbhelper.Run(base.ConnectionString);
            return ds;
        }
        public DataSet CheckTime()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SelectTime.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = new DataSet();
            RISScheduleSelectCheckTimeDataParameters param = new RISScheduleSelectCheckTimeDataParameters(RISSchedule);
            ds = dbhelper.Run(base.ConnectionString,param.Parameters);
            return ds;
        }
        public DataSet CheckConflictTime()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_CheckConflict.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[] 
            { 
                    new SqlParameter("@SCHEDULE_ID", RISSchedule.SCHEDULE_ID) ,
                    new SqlParameter("@HN", RISSchedule.HN) ,
                    new SqlParameter("@APPOINT_DT", RISSchedule.APPOINT_DT),
                    new SqlParameter("@END_DATETIME", RISSchedule.END_DATETIME) 
            };
            ds = dbhelper.Run(base.ConnectionString, param);
            return ds;
        }
        public int CaseCount() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_Count.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            int count = 0;
            try
            {
                DataSet ds = new DataSet();
                RISScheduleSelectCheckTimeDataParameters param = new RISScheduleSelectCheckTimeDataParameters(RISSchedule,true);
                ds = dbhelper.Run(base.ConnectionString, param.Parameters);
                count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            catch { 

            }
            return count;
        }
        public DataSet GetScheduleLog() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULELOG_Select.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@SCHEDULE_ID", RISSchedule.SCHEDULE_ID) };
            ds = dbhelper.Run(base.ConnectionString,param);
            return ds;
        }
        public DataSet GetHNAppointment() {

            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SelectHNApp.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[] 
            { 
                    new SqlParameter("@HN", RISSchedule.HN) ,
                    new SqlParameter("@APPOINT_DT", RISSchedule.APPOINT_DT) 
            };
            ds = dbhelper.Run(base.ConnectionString, param);
            return ds;
        }
        public DataSet GetModality() {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@EMP_ID", new GBLEnvVariable().UserID) };
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SelectModality.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
           
            ds = dbhelper.Run(base.ConnectionString, param);
            return ds;
        }
        public DataSet GetSessionCount() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SessionTime.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = new DataSet();
            RISScheduleSelectCheckTimeDataParameters param = new RISScheduleSelectCheckTimeDataParameters(RISSchedule);
            param.BuildSessionCount();
            ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            return ds;
        }
        public DataSet GetByHN() {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@HN", RISSchedule.HN) };
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_SelectHN.ToString();
            DataSet ds = new DataSet();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, param);
            return ds;
        }
	}
	public class RISScheduleInsertDataParameters 
	{
		private RISSchedule _risschedule;
		private SqlParameter[] _parameters;

		public RISScheduleInsertDataParameters(RISSchedule risschedule)
		{
			RISSchedule=risschedule;
            if (risschedule.SCHEDULE_ID == 0)
                Build();
            else
                BuildByScheduleID();
		}
        public RISScheduleInsertDataParameters(string HN) {
            _risschedule = new RISSchedule();
            BuildByHN(HN);
        }

		public  RISSchedule	RISSchedule
		{
			get{return _risschedule;}
			set{_risschedule=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}

        public void BuildByScheduleID() {
            SqlParameter[] parameters ={
                 new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID)
            };
            Parameters = parameters;
        }
        public void BuildByHN(string HN) {
            SqlParameter[] parameters ={
                 new SqlParameter("@HN",HN)
            };
            Parameters = parameters;
        }
		public void Build()
		{
            //SqlParameter[] parameters ={new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID),new SqlParameter("@REG_ID",RISSchedule.REG_ID),new SqlParameter("@HN",RISSchedule.HN),new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID),new SqlParameter("@EXAM_UID",RISSchedule.EXAM_UID)
            //,new SqlParameter("@VISIT_NO",RISSchedule.VISIT_NO),new SqlParameter("@APPOINT_DT",RISSchedule.APPOINT_DT),new SqlParameter("@QTY",RISSchedule.QTY),new SqlParameter("@COMMENTS",RISSchedule.COMMENTS),new SqlParameter("@SPECIAL_CLINIC",RISSchedule.SPECIAL_CLINIC)
            //,new SqlParameter("@AllProperties",RISSchedule.AllProperties),new SqlParameter("@ADMISSION_NO",RISSchedule.ADMISSION_NO),new SqlParameter("@SCHEDULE_DT",RISSchedule.SCHEDULE_DT),new SqlParameter("@StartDateTime",RISSchedule.StartDateTime),new SqlParameter("@EndDateTime",RISSchedule.EndDateTime)
            //,new SqlParameter("@REFER_FROM",RISSchedule.REFER_FROM),new SqlParameter("@REF_DOC_INSTRUCTION",RISSchedule.REF_DOC_INSTRUCTION),new SqlParameter("@CLINICAL_INSTRUCTION",RISSchedule.CLINICAL_INSTRUCTION),new SqlParameter("@REASON",RISSchedule.REASON),new SqlParameter("@DIAGNOSIS",RISSchedule.DIAGNOSIS)
            //,new SqlParameter("@ICD_ID",RISSchedule.ICD_ID),new SqlParameter("@SCHEDULE_STATUS",RISSchedule.SCHEDULE_STATUS),new SqlParameter("@CONFIRMED_BY",RISSchedule.CONFIRMED_BY),new SqlParameter("@CONFIRMED_ON",RISSchedule.CONFIRMED_ON),new SqlParameter("@ORG_ID",RISSchedule.ORG_ID)
            //,new SqlParameter("@CREATED_BY",RISSchedule.CREATED_BY),new SqlParameter("@CREATED_ON",RISSchedule.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",RISSchedule.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISSchedule.LAST_MODIFIED_ON)};
         
            SqlParameter[] parameters ={
                 new SqlParameter("@REG_ID",RISSchedule.REG_ID)
                ,new SqlParameter("@HN",RISSchedule.HN)
                ,new SqlParameter("@APPOINT_DT",RISSchedule.APPOINT_DT)
            };
            Parameters = parameters;
		}
	}
    public class RISScheduleSelectCheckTimeDataParameters
    {
        private RISSchedule _risschedule;
        private SqlParameter[] _parameters;

        public RISScheduleSelectCheckTimeDataParameters(RISSchedule risschedule)
        {
            _risschedule = risschedule;
            Build();
        }
        public RISScheduleSelectCheckTimeDataParameters(RISSchedule risschedule,bool CaseCount)
        {
            _risschedule = risschedule;
            if (CaseCount)
                BuildCaseCount();
            else
                Build();
        }

        public RISSchedule RISSchedule
        {
            get { return _risschedule; }
            set { _risschedule = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters ={
                 new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID)
                ,new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)
                ,new SqlParameter("@START_DATETIME",RISSchedule.APPOINT_DT)
                ,new SqlParameter("@END_DATETIME",RISSchedule.END_DATETIME)
                ,new SqlParameter("@IS_BLOCK",RISSchedule.IS_BLOCK)
            };
            Parameters = parameters;
        }
        public void BuildCaseCount() {
            SqlParameter[] parameters ={
                 new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)
                ,new SqlParameter("@APPOINT_DT",RISSchedule.APPOINT_DT)
            };
            Parameters = parameters;
        }
        public void BuildSessionCount() {
            SqlParameter[] parameters ={
                 new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)
                ,new SqlParameter("@START_TIME",RISSchedule.APPOINT_DT)
                ,new SqlParameter("@END_TIME",RISSchedule.END_DATETIME)
            };
            Parameters = parameters;
        }
    }
}

