using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using EnvisionOnline.Common;


namespace EnvisionOnline.DataAccess.Insert
{
	public class RISScheduleInsertData : DataAccessBase 
	{
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }

        public RISScheduleInsertData()
		{
            RIS_SCHEDULE = new RIS_SCHEDULE();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Online_Insert;
		}
		
        public bool Add()
		{
            ParameterList = buildParameter();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(ParameterList[0].Value);
            return true;
		}
        public void AddBlock() {
            ParameterList = buildParameterBlock();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_InsertBlock;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(ParameterList[0].Value);
        }
        public void AddRecurrence() {
            ParameterList = buildParameterRecurrence();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_InsertRecurrence;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        }

        private DbParameter[] buildParameter() {
            DbParameter param = Parameter();
            param.ParameterName = "@SCHEDULE_ID";
            param.Direction = ParameterDirection.Output;
            if (RIS_SCHEDULE.SCHEDULE_ID == 0)
                param.Value = 0;
            else
                param.Value = RIS_SCHEDULE.SCHEDULE_ID;

            DbParameter paramREG_ID = Parameter();
            paramREG_ID.ParameterName = "@REG_ID";
            if (RIS_SCHEDULE.REG_ID == 0)
                paramREG_ID.Value = 0;
            else
                paramREG_ID.Value = RIS_SCHEDULE.REG_ID;

            DbParameter paramHN = Parameter();
            paramHN.ParameterName = "@HN";
            if (string.IsNullOrEmpty(RIS_SCHEDULE.HN))
                paramHN.Value = RIS_SCHEDULE.HN;
            else
                paramHN.Value = DBNull.Value;

            DbParameter LMP_DT = Parameter();
            LMP_DT.ParameterName = "@LMP_DT";
            if (RIS_SCHEDULE.LMP_DT == null)
                LMP_DT.Value = DBNull.Value;
            else
                LMP_DT.Value = RIS_SCHEDULE.LMP_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_SCHEDULE.LMP_DT;

            DbParameter LABEL = Parameter();
            LABEL.ParameterName = "@LABEL";
            if (RIS_SCHEDULE.LABEL == null)
                LABEL.Value = DBNull.Value;
            else
                LABEL.Value = RIS_SCHEDULE.LABEL;

            DbParameter LOCATION = Parameter();
            LOCATION.ParameterName = "@LOCATION";
            if (string.IsNullOrEmpty(RIS_SCHEDULE.LOCATION))
                LOCATION.Value = DBNull.Value;
            else
                LOCATION.Value = RIS_SCHEDULE.LOCATION;

            DbParameter EVENTTYPE = Parameter();
            EVENTTYPE.ParameterName = "@EVENTTYPE";
            if (RIS_SCHEDULE.EVENTTYPE==null)
                EVENTTYPE.Value = DBNull.Value;
            else
                EVENTTYPE.Value = RIS_SCHEDULE.EVENTTYPE;

            DbParameter REF_DOC_INSTRUCTION = Parameter();
            REF_DOC_INSTRUCTION.ParameterName = "@REF_DOC_INSTRUCTION";
            if (string.IsNullOrEmpty(RIS_SCHEDULE.REF_DOC_INSTRUCTION))
                REF_DOC_INSTRUCTION.Value = DBNull.Value;
            else
                REF_DOC_INSTRUCTION.Value = RIS_SCHEDULE.REF_DOC_INSTRUCTION;

            DbParameter CLINICAL_INSTRUCTION = Parameter();
            CLINICAL_INSTRUCTION.ParameterName = "@CLINICAL_INSTRUCTION";
            if (string.IsNullOrEmpty(RIS_SCHEDULE.CLINICAL_INSTRUCTION))
                CLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                CLINICAL_INSTRUCTION.Value = RIS_SCHEDULE.CLINICAL_INSTRUCTION;

            DbParameter PAT_STATUS = Parameter();
            PAT_STATUS.ParameterName = "@PAT_STATUS";
            if (RIS_SCHEDULE.PAT_STATUS==null)
                PAT_STATUS.Value = DBNull.Value;
            else
                PAT_STATUS.Value = RIS_SCHEDULE.PAT_STATUS;

            DbParameter ICD = Parameter();
            ICD.ParameterName = "@ICD_ID";
            if (RIS_SCHEDULE.ICD_ID == null)
                ICD.Value = DBNull.Value;
            else
                ICD.Value = RIS_SCHEDULE.ICD_ID;

            DbParameter[] parameters ={	
		        param
                ,Parameter("@REG_ID",RIS_SCHEDULE.REG_ID)
                ,Parameter("@HN",RIS_SCHEDULE.HN)
                ,Parameter("@SCHEDULE_DT",RIS_SCHEDULE.SCHEDULE_DT)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                ,LABEL
                ,LOCATION
                ,EVENTTYPE
                ,Parameter("@SESSION_ID",RIS_SCHEDULE.SESSION_ID)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@REF_UNIT",RIS_SCHEDULE.REF_UNIT)
                ,Parameter("@REF_DOC",RIS_SCHEDULE.REF_DOC)
                ,REF_DOC_INSTRUCTION
                ,CLINICAL_INSTRUCTION
                ,Parameter("@REASON", RIS_SCHEDULE.REASON )
                ,Parameter("@DIAGNOSIS",RIS_SCHEDULE.DIAGNOSIS)
                ,PAT_STATUS
                ,LMP_DT
                ,ICD
                ,Parameter("@SCHEDULE_STATUS",RIS_SCHEDULE.SCHEDULE_STATUS)
                ,Parameter("@IS_BLOCKED",RIS_SCHEDULE.IS_BLOCKED)
                ,Parameter("@BLOCK_REASON",RIS_SCHEDULE.BLOCK_REASON)
                ,Parameter("@COMMENTS",RIS_SCHEDULE.COMMENTS)
                ,Parameter("@ORG_ID",RIS_SCHEDULE.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_SCHEDULE.CREATED_BY)
                ,Parameter("@INSURANCE_TYPE_ID",RIS_SCHEDULE.INSURANCE_TYPE_ID)
                ,Parameter("@RECURRENCEINFO",RIS_SCHEDULE.RECURRENCEINFO)
                ,Parameter("@ALLDAY",RIS_SCHEDULE.ALLDAY)
                ,Parameter("@STATUS",RIS_SCHEDULE.STATUS)
                ,Parameter("@ENC_ID",RIS_SCHEDULE.ENC_ID)
                ,Parameter("@ENC_TYPE",RIS_SCHEDULE.ENC_TYPE)
                ,Parameter("@ENC_CLINIC",RIS_SCHEDULE.ENC_CLINIC)
			};
            return parameters;
        }
        private DbParameter[] buildParameterBlock() {
            DbParameter Appoint_DT = Parameter();
            Appoint_DT.ParameterName = "@START_DATETIME";
            if (RIS_SCHEDULE.START_DATETIME == null)
            {
                Appoint_DT.Value = DBNull.Value;
            }
            else
            {
                Appoint_DT.Value = RIS_SCHEDULE.START_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_SCHEDULE.START_DATETIME;
            }
            DbParameter End_Datetime = Parameter();
            End_Datetime.ParameterName = "@END_DATETIME";
            if (RIS_SCHEDULE.END_DATETIME == null)
            {
                End_Datetime.Value = DBNull.Value;
            }
            else
            {
                End_Datetime.Value = RIS_SCHEDULE.END_DATETIME == DateTime.MinValue ? (object)DBNull.Value :RIS_SCHEDULE.END_DATETIME;
            }
            DbParameter SCHEDULE_ID = Parameter();
            SCHEDULE_ID.ParameterName = "@SCHEDULE_ID";
            SCHEDULE_ID.Value = 0;
            SCHEDULE_ID.Direction = ParameterDirection.Output;


            DbParameter[] parameters ={	
		        //Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                SCHEDULE_ID
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Appoint_DT
                ,Parameter("@SCHEDULE_DATA",RIS_SCHEDULE.SCHEDULE_DATA)
                ,End_Datetime
                ,Parameter("@REASON",RIS_SCHEDULE.REASON)
                ,Parameter("@SCHEDULE_STATUS",RIS_SCHEDULE.SCHEDULE_STATUS)
                ,Parameter("@ORG_ID",RIS_SCHEDULE.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_SCHEDULE.CREATED_BY)
                ,Parameter("@RECURRENCEINFO",RIS_SCHEDULE.RECURRENCEINFO)
                ,Parameter("@ALLDAY",RIS_SCHEDULE.ALLDAY)
                ,Parameter("@STATUS",RIS_SCHEDULE.STATUS)
                ,Parameter("@EVENTTYPE",RIS_SCHEDULE.EVENTTYPE)
                ,Parameter("@LABEL",RIS_SCHEDULE.LABEL)

			};
            return parameters;
        }
        private DbParameter[] buildParameterRecurrence()
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
	}
}

