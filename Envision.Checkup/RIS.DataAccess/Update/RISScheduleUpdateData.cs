using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class RISScheduleUpdateData : DataAccessBase
    {
        private RISSchedule _risschedule;
        private RISScheduleInsertDataParameters _risscheduleinsertdataparameters;
        private int scheduleID;
        private int action = 0;

        public RISScheduleUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_Update.ToString();
            action = 0;
        }
        public RISScheduleUpdateData(RISSchedule risschedule)
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_UpdateStatus.ToString();
            scheduleID = risschedule.SCHEDULE_ID;
            action = 1;
            _risschedule = risschedule;
        }

        public RISSchedule RISSchedule
        {
            get { return _risschedule; }
            set { _risschedule = value; }
        }

        public void Update()
        {
            if (action == 0)
                _risscheduleinsertdataparameters = new RISScheduleInsertDataParameters(RISSchedule);
            else
                _risscheduleinsertdataparameters = new RISScheduleInsertDataParameters(scheduleID,_risschedule.SCHEDULE_STATUS,_risschedule.CREATED_BY,_risschedule.REF_DOC,_risschedule.REF_UNIT);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _risscheduleinsertdataparameters.Parameters);
        }
        public void Update(SqlTransaction tran)
        {
            if (action == 0)
                _risscheduleinsertdataparameters = new RISScheduleInsertDataParameters(RISSchedule);
            else
                _risscheduleinsertdataparameters = new RISScheduleInsertDataParameters(scheduleID, _risschedule.SCHEDULE_STATUS, _risschedule.CREATED_BY,_risschedule.REF_DOC,_risschedule.REF_UNIT);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, _risscheduleinsertdataparameters.Parameters);
        }

        /// <summary>
        /// add in schedule control.{ by dell }
        /// </summary>
        public void UpdateSchedule() {
            RISScheduleUpdateDataParameters param = new RISScheduleUpdateDataParameters(this.RISSchedule);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                        RISSchedule.SCHEDULE_ID = Convert.ToInt32(ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString());


        }
        public void UpdateScheduleBlock() {
            RISScheduleUpdateDataParameters param = new RISScheduleUpdateDataParameters(this.RISSchedule,true);
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_UpdateBlock.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                        RISSchedule.SCHEDULE_ID = Convert.ToInt32(ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString());
        }
        public void UpdateScheduleTimer() {
            try
            {
                RISScheduleUpdateTimerDataParameters param = new RISScheduleUpdateTimerDataParameters(RISSchedule);
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_UpdateTimer.ToString();
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                //dbhelper.RunScalar(base.ConnectionString, param.Parameters);
                dbhelper.Run(param.Parameters);
            }
            catch (Exception ex) 
            { 
            
            }
        }
    }

    public class RISScheduleInsertDataParameters
    {
        private RISSchedule _risschedule;
        private SqlParameter[] _parameters;

        public RISScheduleInsertDataParameters(RISSchedule risschedule)
        {
            RISSchedule = risschedule;
            Build();
        }
        public RISScheduleInsertDataParameters(int scheduleID, string status, int uid, int refDoc, int refUnit)
        {
            _risschedule = new RISSchedule();
            BuildUpdateStatus(scheduleID,status,uid,refDoc,refUnit);
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
                new SqlParameter("@RIS_SCHEDULE", RISSchedule.SCHEDULE_ID)
                , new SqlParameter("@UserID", RISSchedule.CREATED_BY) 
            };
            Parameters = parameters;
        }
        public void BuildUpdateStatus(int scheduleID,string status,int uid,int refDoc,int refUnit)
        {
            SqlParameter[] parameters ={
                    new SqlParameter("@SCHEDULE_ID", scheduleID)
                    ,new SqlParameter("@SCHEDULE_STATUS",status)
                   ,new SqlParameter("@LAST_MODIFIED_BY", uid)
                    ,new SqlParameter("@REF_DOC",refDoc)
                    ,new SqlParameter ("@REF_UNIT",refUnit)
            };
            Parameters = parameters;
        }
    }
    public class RISScheduleUpdateDataParameters {
        
        private RISSchedule _risschedule;
        private SqlParameter[] _parameters;

        public RISScheduleUpdateDataParameters(RISSchedule risSchedule)
        {
            _risschedule = risSchedule;
            Build();
        }
        public RISScheduleUpdateDataParameters(RISSchedule risSchedule,bool block)
        {
            _risschedule = risSchedule;
            if (block)
                BuildBlock();
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
            SqlParameter paramID = new SqlParameter();
            paramID.Value = RISSchedule.GEN_DTL_ID;
            paramID.ParameterName = "@GEN_DTL_ID";
            if (RISSchedule.GEN_DTL_ID == 0)
                paramID.Value = DBNull.Value;

            SqlParameter Appoint_DT = new SqlParameter();
            Appoint_DT.ParameterName = "@APPOINT_DT";
            if (RISSchedule.APPOINT_DT == DateTime.MinValue)
            {
                Appoint_DT.Value = DBNull.Value;
            }
            else
            {
                Appoint_DT.Value = RISSchedule.APPOINT_DT;
            }
            SqlParameter End_Datetime = new SqlParameter();
            End_Datetime.ParameterName = "@END_DATETIME";
            if (RISSchedule.END_DATETIME == DateTime.MinValue)
            {
                End_Datetime.Value = DBNull.Value;
            }
            else
            {
                End_Datetime.Value = RISSchedule.END_DATETIME;
            }
            SqlParameter LMP_DT = new SqlParameter();
            LMP_DT.ParameterName = "@LMP_DT";
            if (RISSchedule.LMP_DT == DateTime.MinValue)
            {
                LMP_DT.Value = DBNull.Value;
            }
            else
            {
                LMP_DT.Value = RISSchedule.LMP_DT;
            }
            SqlParameter[] parameters ={			
                new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID)
                ,new SqlParameter("@REG_ID",RISSchedule.REG_ID)
                ,new SqlParameter("@HN",RISSchedule.HN)
                ,new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)
                ,new SqlParameter("@EXAM_ID",RISSchedule.EXAM_ID)
                ,Appoint_DT
                ,new SqlParameter("@SCHEDULE_DATA",RISSchedule.SCHEDULE_DATA)
                ,End_Datetime
                ,new SqlParameter("@REF_UNIT",RISSchedule.REF_UNIT)
                ,new SqlParameter("@REF_DOC",RISSchedule.REF_DOC)
                ,new SqlParameter("@REASON",RISSchedule.REASON)
                ,new SqlParameter("@REASON_CHANGE",RISSchedule.REASON_CHANGE)
                ,new SqlParameter("@ORG_ID",RISSchedule.ORG_ID)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISSchedule.LAST_MODIFIED_BY)
                ,new SqlParameter("@CLINIC_TYPE",RISSchedule.CLINIC_TYPE)
                ,new SqlParameter("@RATE",RISSchedule.RATE)
                ,paramID
                ,new SqlParameter("@RAD_ID",RISSchedule.RAD_ID)
                ,new SqlParameter("@PAT_STATUS",RISSchedule.PATSTATUS_ID)
                ,LMP_DT
                ,new SqlParameter("@QTY",RISSchedule.QTY)
                ,new SqlParameter("@SESSION_ID",RISSchedule.SESSION_ID)
			};
            _parameters = parameters;
        }
        public void BuildBlock()
        {
            SqlParameter[] parameters ={			
                new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID)
                ,new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)
                ,new SqlParameter("@APPOINT_DT",RISSchedule.APPOINT_DT)
                ,new SqlParameter("@SCHEDULE_DATA",RISSchedule.SCHEDULE_DATA)
                ,new SqlParameter("@END_DATETIME",RISSchedule.END_DATETIME)
                ,new SqlParameter("@REASON",RISSchedule.REASON)
                ,new SqlParameter("@ORG_ID",RISSchedule.ORG_ID)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISSchedule.LAST_MODIFIED_BY)
			};
            _parameters = parameters;
        }
    }
    public class RISScheduleUpdateTimerDataParameters
    {

        private RISSchedule _risschedule;
        private SqlParameter[] _parameters;

        public RISScheduleUpdateTimerDataParameters(RISSchedule risSchedule)
        {
            _risschedule = risSchedule;
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
                ,new SqlParameter("@START_DATETIME",RISSchedule.APPOINT_DT)
                ,new SqlParameter("@END_DATETIME",RISSchedule.END_DATETIME)
                ,new SqlParameter("@MODALITY_ID",RISSchedule.MODALITY_ID)//@REASON
                ,new SqlParameter("@REASON",RISSchedule.REASON_CHANGE)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISSchedule.LAST_MODIFIED_BY)
			};
            _parameters = parameters;
        }
    }
}
