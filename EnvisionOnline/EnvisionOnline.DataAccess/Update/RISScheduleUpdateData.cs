using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class RISScheduleUpdateData : DataAccessBase
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        private int scheduleID;

        public RISScheduleUpdateData()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Online_Update;
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Online_Update2;
        }
        public void UpdateSchedule() {
            DataSet ds = new DataSet();
            ParameterList = buildParameterUpdateData();
            scheduleID = RIS_SCHEDULE.SCHEDULE_ID;
            ds = ExecuteDataSet();
            RIS_SCHEDULE.SCHEDULE_ID =string.IsNullOrEmpty(ParameterList[0].Value.ToString()) ? scheduleID:Convert.ToInt32(ParameterList[0].Value.ToString());
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
            DbParameter CLINICAL_INSTRUCTION = Parameter();
            CLINICAL_INSTRUCTION.ParameterName = "@CLINICAL_INSTRUCTION";
            if (string.IsNullOrEmpty(RIS_SCHEDULE.CLINICAL_INSTRUCTION))
                CLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                CLINICAL_INSTRUCTION.Value = RIS_SCHEDULE.CLINICAL_INSTRUCTION;

            DbParameter pIS_ALERT_CLINICAL_INSTRUCTION = Parameter();
            pIS_ALERT_CLINICAL_INSTRUCTION.ParameterName = "@IS_ALERT_CLINICAL_INSTRUCTION";
            if (RIS_SCHEDULE.IS_ALERT_CLINICAL_INSTRUCTION == null)
                pIS_ALERT_CLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                pIS_ALERT_CLINICAL_INSTRUCTION.Value = RIS_SCHEDULE.IS_ALERT_CLINICAL_INSTRUCTION == string.Empty ? (object)DBNull.Value : RIS_SCHEDULE.IS_ALERT_CLINICAL_INSTRUCTION;

            DbParameter pCLINICAL_INSTRUCTION_TAG = Parameter();
            pCLINICAL_INSTRUCTION_TAG.ParameterName = "@CLINICAL_INSTRUCTION_TAG";
            if (RIS_SCHEDULE.CLINICAL_INSTRUCTION_TAG == null)
                pCLINICAL_INSTRUCTION_TAG.Value = DBNull.Value;
            else
                pCLINICAL_INSTRUCTION_TAG.Value = RIS_SCHEDULE.CLINICAL_INSTRUCTION_TAG == string.Empty ? (object)DBNull.Value : RIS_SCHEDULE.CLINICAL_INSTRUCTION_TAG;

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
                                        ,Parameter("@COMMENTS",RIS_SCHEDULE.COMMENTS)
                                        ,CLINICAL_INSTRUCTION
                                        ,pIS_ALERT_CLINICAL_INSTRUCTION
                                        ,pCLINICAL_INSTRUCTION_TAG
                                        };
            return parameters;
        }
        public void UpdateIsConsentForm()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_OnlineIsConsentForm_Update;
            ParameterList = buildParameterUpdateIsConsentForm();
            ds = ExecuteDataSet();
        }
        private DbParameter[] buildParameterUpdateIsConsentForm()
        {
            DbParameter SCHEDULE_ID = Parameter();
            SCHEDULE_ID.ParameterName = "@SCHEDULE_ID";
            SCHEDULE_ID.Value = RIS_SCHEDULE.SCHEDULE_ID;

            DbParameter[] parameters ={
                                        SCHEDULE_ID
                                        };
            return parameters;
        }

        public void UpdateBusy()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateBusy;
            ParameterList = buildParameterUpdateBusy();
            ds = ExecuteDataSet();
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
    }
}
