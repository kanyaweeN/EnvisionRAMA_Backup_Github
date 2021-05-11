using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISScheduleUpdateData : DataAccessBase
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }

        private int scheduleID;
        private int action = 0;

        public RISScheduleUpdateData()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Update;
            action = 0;
        }
        public RISScheduleUpdateData(RIS_SCHEDULE risschedule)
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE = risschedule;
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateStatus;
            scheduleID = risschedule.SCHEDULE_ID;
            action = 1;
        }
        public void Update()
        {
            if (action == 0)
                ParameterList = buildParameterInsertData();
            else
                ParameterList = buildParameterInsertDataUpdateStatus();
            ExecuteNonQuery();
        }
        public void Update(DbTransaction tran)
        {
            if (action == 0)
                ParameterList = buildParameterInsertData();
            else
                ParameterList = buildParameterInsertDataUpdateStatus();
            Transaction = tran;
            ExecuteNonQuery();
        }
        public void UpdatePatientStatus() {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdatePatientStatus;
            ParameterList = buildParameterUpdatePatientStatus();
            ds = ExecuteDataSet();
        }
        public void UpdateSchedule() {
            DataSet ds = new DataSet();
            ParameterList = buildParameterUpdateData();
            scheduleID = RIS_SCHEDULE.SCHEDULE_ID;
            ds = ExecuteDataSet();
            RIS_SCHEDULE.SCHEDULE_ID =string.IsNullOrEmpty(ParameterList[0].Value.ToString()) ? scheduleID:Convert.ToInt32(ParameterList[0].Value.ToString());
        }
        public void UpdateScheduleCNMI()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameterUpdateData();
            scheduleID = RIS_SCHEDULE.SCHEDULE_ID;
            ds = ExecuteDataSet2();
            RIS_SCHEDULE.SCHEDULE_ID = string.IsNullOrEmpty(ParameterList[0].Value.ToString()) ? scheduleID : Convert.ToInt32(ParameterList[0].Value.ToString());
        }
        public void UpdateScheduleBlock() {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateBlockNew;
            ParameterList = buildParameterUpdateDataBlock();
            ds = ExecuteDataSet();
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                        RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString());
        }
        public void UpdateScheduleComments()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateCommentsNew;
            ParameterList = buildParameterUpdateDataComments();
            ds = ExecuteDataSet();
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                        RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString());
        }
        public void UpdateScheduleTimer()
        {
            //RIS_SCHEDULE = new RIS_SCHEDULE();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateDragDrop;
            ParameterList = buildParameterUpdateTimer();
            ExecuteNonQuery();
        }
        public void UpdateModality() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateModality;
            //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateModalityAndSession;
            ParameterList = buildParameterUpdateModality();
            DataSet ds = new DataSet();
            ds=ExecuteDataSet();
            RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        }
        public void UpdateRecurrence()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateRecurrence;
            ParameterList = buildParameterUpdateRecurrence();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
        }

        private DbParameter[] buildParameterInsertData()
        {
            DbParameter[] parameters ={
                Parameter("@RIS_SCHEDULE", RIS_SCHEDULE.SCHEDULE_ID)
                , Parameter("@UserID", RIS_SCHEDULE.CREATED_BY) 
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterInsertDataUpdateStatus()
        {
            DbParameter ref_doc = Parameter();
            ref_doc.ParameterName = "@REF_DOC";
            if (RIS_SCHEDULE.REF_DOC == null)
                ref_doc.Value = DBNull.Value;
            else if (RIS_SCHEDULE.REF_DOC == 0)
                ref_doc.Value = DBNull.Value;
            else
                ref_doc.Value = RIS_SCHEDULE.REF_DOC;
            DbParameter ref_unit = Parameter();
            ref_unit.ParameterName = "@REF_UNIT";
            if (RIS_SCHEDULE.REF_UNIT == null)
                ref_unit.Value = DBNull.Value;
            else if (RIS_SCHEDULE.REF_UNIT == 0)
                ref_unit.Value = DBNull.Value;
            else
                ref_unit.Value = RIS_SCHEDULE.REF_UNIT;
            DbParameter[] parameters ={
                    Parameter("@SCHEDULE_ID", scheduleID)
                    ,Parameter("@SCHEDULE_STATUS",RIS_SCHEDULE.SCHEDULE_STATUS)
                   ,Parameter("@LAST_MODIFIED_BY", RIS_SCHEDULE.LAST_MODIFIED_BY)
                    ,ref_doc
                    ,ref_unit
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateData()
        {
            DbParameter Schedule_DT = Parameter();
            Schedule_DT.ParameterName = "@SCHEDULE_DT";
            if (RIS_SCHEDULE.SCHEDULE_DT == null)
                Schedule_DT.Value = DBNull.Value;
            else
                Schedule_DT.Value = RIS_SCHEDULE.SCHEDULE_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_SCHEDULE.SCHEDULE_DT;

            DbParameter End_Datetime = Parameter();
            End_Datetime.ParameterName = "@END_DATETIME";
            if (RIS_SCHEDULE.END_DATETIME == null)
                End_Datetime.Value = DBNull.Value;
            else
                End_Datetime.Value = RIS_SCHEDULE.END_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_SCHEDULE.END_DATETIME;

            DbParameter LMP_DT = Parameter();
            LMP_DT.ParameterName = "@LMP_DT";
            if (RIS_SCHEDULE.LMP_DT == null)
                LMP_DT.Value = DBNull.Value;
            else
                LMP_DT.Value = RIS_SCHEDULE.LMP_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_SCHEDULE.LMP_DT;


            DbParameter REF_UNIT = Parameter();
            REF_UNIT.ParameterName = "@REF_UNIT";
            if (RIS_SCHEDULE.REF_UNIT == null)
                REF_UNIT.Value = DBNull.Value;
            else if (RIS_SCHEDULE.REF_UNIT == 0)
                REF_UNIT.Value = DBNull.Value;
            else
                REF_UNIT.Value = RIS_SCHEDULE.REF_UNIT;

            DbParameter REF_DOC = Parameter();
            REF_DOC.ParameterName = "@REF_DOC";
            if (RIS_SCHEDULE.REF_DOC == null)
                REF_DOC.Value = DBNull.Value;
            else if (RIS_SCHEDULE.REF_DOC == 0)
                REF_DOC.Value = DBNull.Value;
            else
                REF_DOC.Value = RIS_SCHEDULE.REF_DOC;

            DbParameter SCHEDULE_ID = Parameter();
            SCHEDULE_ID.ParameterName = "@SCHEDULE_ID";
            SCHEDULE_ID.Value = RIS_SCHEDULE.SCHEDULE_ID;
            //SCHEDULE_ID.Direction = ParameterDirection.Output;

            DbParameter RETOP = Parameter();
            RETOP.ParameterName = "@RETOP";
            RETOP.Value = 0;
            RETOP.Direction = ParameterDirection.Output;

            DbParameter RECINFO = Parameter();
            RECINFO.ParameterName = "@RECURRENCEINFO";
            RECINFO.Value = DBNull.Value;

            DbParameter ALLDAY = Parameter();
            ALLDAY.ParameterName = "@ALLDAY";
            ALLDAY.Value = DBNull.Value;

            DbParameter STATUS = Parameter();
            STATUS.ParameterName = "@STATUS";
            STATUS.Value = DBNull.Value;

            DbParameter EVENTTYPE = Parameter();
            EVENTTYPE.ParameterName = "@EVENTTYPE";
            EVENTTYPE.Value = DBNull.Value;

            DbParameter LABEL = Parameter();
            LABEL.ParameterName = "@LABEL";
            LABEL.Value = DBNull.Value;


            if (!string.IsNullOrEmpty(RIS_SCHEDULE.RECURRENCEINFO)) {
                RECINFO.Value = RIS_SCHEDULE.RECURRENCEINFO;
                ALLDAY.Value = RIS_SCHEDULE.ALLDAY;
                STATUS.Value = RIS_SCHEDULE.STATUS;
                EVENTTYPE.Value = RIS_SCHEDULE.EVENTTYPE;
                LABEL.Value = RIS_SCHEDULE.LABEL;
            }

            DbParameter[] parameters ={
                                        //Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                                        RETOP,
                                        SCHEDULE_ID
                                        ,Parameter("@REG_ID",RIS_SCHEDULE.REG_ID)
                                        ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                                        ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                                        ,Schedule_DT
                                        ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                                        ,End_Datetime
                                        ,REF_UNIT
                                        ,REF_DOC
                                        ,Parameter("@REASON",RIS_SCHEDULE.REASON)
                                        ,Parameter("@REASON_CHANGE",RIS_SCHEDULE.REASON_CHANGE)
                                        ,Parameter("@ORG_ID",RIS_SCHEDULE.ORG_ID)
                                        ,Parameter("@PAT_STATUS",RIS_SCHEDULE.PAT_STATUS)
                                        ,LMP_DT
                                        ,Parameter("@SESSION_ID",RIS_SCHEDULE.SESSION_ID)
                                        ,Parameter("@IS_BLOCKED",RIS_SCHEDULE.IS_BLOCKED)
                                        ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                        ,Parameter("@INSURANCE_TYPE_ID",RIS_SCHEDULE.INSURANCE_TYPE_ID)
                                        
                                        ,RECINFO
                                        ,ALLDAY
                                        ,STATUS
                                        ,EVENTTYPE
                                        ,LABEL
                                        ,Parameter("@ENC_ID",RIS_SCHEDULE.ENC_ID)
                                        ,Parameter("@ENC_TYPE",RIS_SCHEDULE.ENC_TYPE)
                                        ,Parameter("@ENC_CLINIC",RIS_SCHEDULE.ENC_CLINIC)
                                        };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateDataBlock()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@REASON",RIS_SCHEDULE.REASON)
                ,Parameter("@REASON_CHANGE",RIS_SCHEDULE.REASON_CHANGE)
                ,Parameter("@ORG_ID",RIS_SCHEDULE.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateDataComments()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@REASON",RIS_SCHEDULE.REASON)
                ,Parameter("@REASON_CHANGE",RIS_SCHEDULE.REASON_CHANGE)
                ,Parameter("@ORG_ID",RIS_SCHEDULE.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateTimer()
        {
            DbParameter RECINFO = Parameter();
            RECINFO.ParameterName = "@RECURRENCEINFO";
            RECINFO.Value = DBNull.Value;

            DbParameter ALLDAY = Parameter();
            ALLDAY.ParameterName = "@ALLDAY";
            ALLDAY.Value = DBNull.Value;

            DbParameter STATUS = Parameter();
            STATUS.ParameterName = "@STATUS";
            STATUS.Value = DBNull.Value;

            DbParameter EVENTTYPE = Parameter();
            EVENTTYPE.ParameterName = "@EVENTTYPE";
            EVENTTYPE.Value = DBNull.Value;

            DbParameter LABEL = Parameter();
            LABEL.ParameterName = "@LABEL";
            LABEL.Value = DBNull.Value;

            if (!string.IsNullOrEmpty(RIS_SCHEDULE.RECURRENCEINFO))
            {
                RECINFO.Value = RIS_SCHEDULE.RECURRENCEINFO;
                ALLDAY.Value = RIS_SCHEDULE.ALLDAY;
                STATUS.Value = RIS_SCHEDULE.STATUS;
                EVENTTYPE.Value = RIS_SCHEDULE.EVENTTYPE;
                LABEL.Value = RIS_SCHEDULE.LABEL;
            }
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@REASON",RIS_SCHEDULE.REASON)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                ,RECINFO
                ,ALLDAY
                ,STATUS
                ,EVENTTYPE
                ,LABEL
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateModality()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@SESSION_ID",RIS_SCHEDULE.SESSION_ID)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@REASON",RIS_SCHEDULE.REASON)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                ,Parameter("@TEXT_SHOW",RIS_SCHEDULE.TEXT_SHOW)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateRecurrence()
        {
            DbParameter[] parameters ={	
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@HN",RIS_SCHEDULE.HN)
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@REASON",RIS_SCHEDULE.REASON)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@IS_BLOCKED",RIS_SCHEDULE.IS_BLOCKED)
                ,Parameter("@ALLDAY",RIS_SCHEDULE.ALLDAY)
                ,Parameter("@EVENTTYPE",RIS_SCHEDULE.EVENTTYPE)
                ,Parameter("@RECURRENCEINFO",RIS_SCHEDULE.RECURRENCEINFO)
                ,Parameter("@STATUS",RIS_SCHEDULE.STATUS)
                ,Parameter("@LABEL",RIS_SCHEDULE.LABEL)
                ,Parameter("@LOCATION",RIS_SCHEDULE.LOCATION)
                ,Parameter("@CREATED_BY",RIS_SCHEDULE.CREATED_BY)
                ,Parameter("@ORG_ID",RIS_SCHEDULE.ORG_ID)
			};
            return parameters;
        }
        private DbParameter[] buildParameterUpdatePatientStatus()
        {
            DbParameter[] parameters ={	
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@PAT_STATUS",RIS_SCHEDULE.PAT_STATUS)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                ,Parameter("@ORG_ID",RIS_SCHEDULE.ORG_ID)
			};
            return parameters;
        }

        public void UpdatePending()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdatePending;
            ParameterList = buildParameterUpdatePending();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterUpdatePending()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@SCHEDULE_STATUS",RIS_SCHEDULE.SCHEDULE_STATUS)
                ,Parameter("@PENDING_BY",RIS_SCHEDULE.PENDING_BY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        public void UpdatePendingComments()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdatePendingComments;
            ParameterList = buildParameterUpdateUpdatePendingComments();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterUpdateUpdatePendingComments()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@COMMENTS",RIS_SCHEDULE.COMMENTS)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        public void UpdateWatingComments()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateWaitingComments;
            ParameterList = buildParameterUpdateUpdateWatingComments();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterUpdateUpdateWatingComments()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                ,Parameter("@COMMENTS",RIS_SCHEDULE.COMMENTS)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        public void UpdateWatingList()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateWaitingList;
            ParameterList = buildParameterUpdateWaitingList();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterUpdateWaitingList()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@SCHEDULE_STATUS",RIS_SCHEDULE.SCHEDULE_STATUS)
                ,Parameter("@WL_CONFIRMED_BY",RIS_SCHEDULE.WL_CONFIRMED_BY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateBusy()
        {
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@IS_BUSY",RIS_SCHEDULE.IS_BUSY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        public void UpdateBusy()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateBusy;
            ParameterList = buildParameterUpdateBusy();
            ExecuteNonQuery();
        }
        public void UpdatePendingSchedule()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateSchedulePending;
            DbParameter[] parameters ={
                Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@SCHEDULE_STATUS",RIS_SCHEDULE.SCHEDULE_STATUS)
                ,Parameter("@LAST_MODIFIED_BY",RIS_SCHEDULE.LAST_MODIFIED_BY)
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }

        public void UpdateSessionID(int session_id,int schedule_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateSessionID;
             DbParameter[] parameters ={
                                        Parameter("@SESSION_ID",session_id)
                                        ,Parameter("@SCHEDULE_ID",schedule_id)
                                      };
             ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void UpdateTextShow(string textShow, int schedule_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateTextShow;
            DbParameter[] parameters ={
                                        Parameter("@TEXT_SHOW",textShow)
                                        ,Parameter("@SCHEDULE_ID",schedule_id)
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void TransferClincalIndication(int schedule_id, int xrayreq_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_TransferClinicalInstruction;
            DbParameter[] parameters ={
                                        Parameter("@SCHEDULE_ID",schedule_id),
                                        Parameter("@XRAYREQ_ID",xrayreq_id)
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void UpdateAppointmentMerge()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateAppointmentMerge;
            DbParameter[] parameters ={
                                        Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID),
                                        Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA),
                                        Parameter("@REASON",RIS_SCHEDULE.REASON),
                                        Parameter("@TEXT_SHOW",RIS_SCHEDULE.TEXT_SHOW),
                                        Parameter("@REF_DOC_INSTRUCTION",RIS_SCHEDULE.REF_DOC_INSTRUCTION),
                                        Parameter("@CLINICAL_INSTRUCTION",RIS_SCHEDULE.CLINICAL_INSTRUCTION),
                                        Parameter("@COMMENTS",RIS_SCHEDULE.COMMENTS)
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void UpdateRequestResult()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateRequestResult;
            DbParameter[] parameters ={
                                        Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID),
                                        Parameter("@REQUEST_RESULT_DATETIME",RIS_SCHEDULE.REQUEST_RESULT_DATETIME),
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void UpdateRequestResultCNMI()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateRequestResult;
            DbParameter[] parameters ={
                                        Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID),
                                        Parameter("@REQUEST_RESULT_DATETIME",RIS_SCHEDULE.REQUEST_RESULT_DATETIME),
                                      };
            ParameterList = parameters;
            ExecuteNonQuery2();
        }
        public void UpdateIsProtocal(string is_protocal, int schedule_id, int emp_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateIsProtocalByTech;
            DbParameter[] parameters ={
                                        Parameter("@SCHEDULE_ID",schedule_id),
                                        Parameter("@IS_PROTOCAL_BY_TECH",is_protocal),
                                        Parameter("@EMP_ID",emp_id),
	
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}
