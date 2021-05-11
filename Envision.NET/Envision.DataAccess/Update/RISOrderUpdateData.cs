using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISOrderUpdateData : DataAccessBase 
	{
        public RIS_ORDER RIS_ORDER { get; set; }
        private int action = 0;
        private bool cancelOrder;

		public RISOrderUpdateData()
		{
            RIS_ORDER = new RIS_ORDER();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateSelfArrivalStatus;
            action = 0;
		}
        public RISOrderUpdateData(RIS_ORDER risOrder)
        {
            RIS_ORDER = new RIS_ORDER();
            RIS_ORDER = risOrder;

            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Update;
            action = 1;
        }
        //public RISOrderUpdateData(RIS_ORDER risOrder, bool CancelOrder)
        //{
        //    RIS_ORDER = new RIS_ORDER();
        //    RIS_ORDER = risOrder;

        //    action = 0;
        //    if (CancelOrder)
        //    {
        //        cancelOrder = CancelOrder;
        //        StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Cancel;
        //        action = 2;
        //    }
        //    else 
        //        StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateSelfArrivalStatus;

        //}
        public RISOrderUpdateData(RIS_ORDER risOrder, bool CancelOrder) //แก้ไขในนี้ครับ
        {
            RIS_ORDER = new RIS_ORDER();
            RIS_ORDER = risOrder;

            action = 0;
            if (CancelOrder)
            {
                cancelOrder = CancelOrder;
                //StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_Cancel.ToString(); // comment อันนี้
                StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_CancelwithReason; // เพิ่มอันนี้
                action = 2;
            }
            else
                StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateSelfArrivalStatus;

        }

		public void Update()
		{
            try
            {
                switch (action)
                {
                    case 0:
                        ParameterList = buildParameterSelfArrival();
                        ExecuteNonQuery();
                        break;
                    case 1:
                        ParameterList = buildParameter();
                        ExecuteNonQuery();
                        break;
                    case 2:
                        ParameterList = buildParameterCancel();
                        ExecuteNonQuery();
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
		}
        public void Update(DbTransaction tran)
        {
            try
            {
                switch (action)
                {
                    case 0:
                        ParameterList = buildParameterSelfArrival();
                        Transaction = tran;
                        ExecuteNonQuery();
                        break;
                    case 1:
                        ParameterList = buildParameter();
                        Transaction = tran;
                        ExecuteNonQuery();
                        break;
                    case 2:
                        ParameterList = buildParameterCancel();
                        Transaction = tran;
                        ExecuteNonQuery();
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private DbParameter[] buildParameter()
        {
            DbParameter pUnit = Parameter();
            pUnit.ParameterName = "@REF_UNIT";
            if (RIS_ORDER.REF_UNIT == null)
                pUnit.Value = DBNull.Value;
            else
                pUnit.Value = RIS_ORDER.REF_UNIT == 0 ? (object)DBNull.Value : RIS_ORDER.REF_UNIT;

            DbParameter pDoc = Parameter();
            pDoc.ParameterName = "@REF_DOC";
            if (RIS_ORDER.REF_DOC == null)
                pDoc.Value = DBNull.Value;
            else
                pDoc.Value = RIS_ORDER.REF_DOC == 0 ? (object)DBNull.Value : RIS_ORDER.REF_DOC;

            DbParameter pICD = Parameter();
            pICD.ParameterName = "@ICD_ID";
            if (RIS_ORDER.REF_DOC == null)
                pICD.Value = DBNull.Value;
            else
                pICD.Value = RIS_ORDER.ICD_ID == 0 ? (object)DBNull.Value : RIS_ORDER.ICD_ID;

            DbParameter pSchedule_ID = Parameter();
            pSchedule_ID.ParameterName = "@SCHEDULE_ID";
            if (RIS_ORDER.SCHEDULE_ID == null)
                pSchedule_ID.Value = DBNull.Value;
            else
                pSchedule_ID.Value = RIS_ORDER.SCHEDULE_ID == 0 ? (object)DBNull.Value : RIS_ORDER.SCHEDULE_ID;

            DbParameter pINSURANCE_TYPE_ID = Parameter();
            pINSURANCE_TYPE_ID.ParameterName = "@INSURANCE_TYPE_ID";
            if (RIS_ORDER.INSURANCE_TYPE_ID == null)
                pINSURANCE_TYPE_ID.Value = DBNull.Value;
            else
                pINSURANCE_TYPE_ID.Value = RIS_ORDER.INSURANCE_TYPE_ID == 0 ? (object)DBNull.Value : RIS_ORDER.INSURANCE_TYPE_ID;

            DbParameter pPAT_STATUS = Parameter();
            pPAT_STATUS.ParameterName = "@PAT_STATUS";
            if (RIS_ORDER.PAT_STATUS == null)
                pPAT_STATUS.Value = DBNull.Value;
            else
                pPAT_STATUS.Value = RIS_ORDER.PAT_STATUS == string.Empty ? (object)DBNull.Value : RIS_ORDER.PAT_STATUS;

            DbParameter pARRIVAL_BY = Parameter();
            pARRIVAL_BY.ParameterName = "@ARRIVAL_BY";
            if (RIS_ORDER.ARRIVAL_BY == null)
                pARRIVAL_BY.Value = DBNull.Value;
            else
                pARRIVAL_BY.Value = RIS_ORDER.ARRIVAL_BY == 0 ? (object)DBNull.Value : RIS_ORDER.ARRIVAL_BY;

            DbParameter pARRIVAL_ON = Parameter();
            pARRIVAL_ON.ParameterName = "@ARRIVAL_ON";
            if (RIS_ORDER.ARRIVAL_ON == null)
                pARRIVAL_ON.Value = DBNull.Value;
            else
                pARRIVAL_ON.Value = RIS_ORDER.ARRIVAL_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDER.ARRIVAL_ON;

            DbParameter pLMP_DT = Parameter();
            pLMP_DT.ParameterName = "@LMP_DT";
            if (RIS_ORDER.LMP_DT == null)
                pLMP_DT.Value = DBNull.Value;
            else
                pLMP_DT.Value = RIS_ORDER.LMP_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDER.LMP_DT;

            DbParameter pADMISSION_NO = Parameter();
            pADMISSION_NO.ParameterName = "@ADMISSION_NO";
            if (RIS_ORDER.ADMISSION_NO == null)
                pADMISSION_NO.Value = DBNull.Value;
            else
                pADMISSION_NO.Value = RIS_ORDER.ADMISSION_NO == string.Empty ? (object)DBNull.Value : RIS_ORDER.ADMISSION_NO;

            DbParameter pREASON = Parameter();
            pREASON.ParameterName = "@REASON";
            if (RIS_ORDER.REASON == null)
                pREASON.Value = DBNull.Value;
            else
                pREASON.Value = RIS_ORDER.REASON == string.Empty ? (object)DBNull.Value : RIS_ORDER.REASON;

            DbParameter pDIAGNOSIS = Parameter();
            pDIAGNOSIS.ParameterName = "@DIAGNOSIS";
            if (RIS_ORDER.DIAGNOSIS == null)
                pDIAGNOSIS.Value = DBNull.Value;
            else
                pDIAGNOSIS.Value = RIS_ORDER.DIAGNOSIS == string.Empty ? (object)DBNull.Value : RIS_ORDER.DIAGNOSIS;

            DbParameter pREF_DOC_INSTRUCTION = Parameter();
            pREF_DOC_INSTRUCTION.ParameterName = "@REF_DOC_INSTRUCTION";
            if (RIS_ORDER.REF_DOC_INSTRUCTION == null)
                pREF_DOC_INSTRUCTION.Value = DBNull.Value;
            else
                pREF_DOC_INSTRUCTION.Value = RIS_ORDER.REF_DOC_INSTRUCTION == string.Empty ? (object)DBNull.Value : RIS_ORDER.REF_DOC_INSTRUCTION;

            DbParameter pCLINICAL_INSTRUCTION = Parameter();
            pCLINICAL_INSTRUCTION.ParameterName = "@CLINICAL_INSTRUCTION";
            if (RIS_ORDER.CLINICAL_INSTRUCTION == null)
                pCLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                pCLINICAL_INSTRUCTION.Value = RIS_ORDER.CLINICAL_INSTRUCTION == string.Empty ? (object)DBNull.Value : RIS_ORDER.CLINICAL_INSTRUCTION;

            DbParameter[] parameters ={
                      Parameter("@ORDER_ID", RIS_ORDER.ORDER_ID)
                    , Parameter("@REG_ID", RIS_ORDER.REG_ID)
                    , Parameter("@HN", RIS_ORDER.HN)
                    , Parameter("@VISIT_NO", RIS_ORDER.VISIT_NO)
                    ,pADMISSION_NO
                    , Parameter("@ORDER_DT", RIS_ORDER.ORDER_DT)
                    , Parameter("@ORDER_START_TIME", RIS_ORDER.ORDER_START_TIME)
                    ,pSchedule_ID
                    ,pUnit
                    ,pDoc
                    ,pREF_DOC_INSTRUCTION
                    ,pCLINICAL_INSTRUCTION
                    ,pREASON
                    ,pDIAGNOSIS
                    ,pICD
                    ,pARRIVAL_BY
                    ,pARRIVAL_ON
                    , Parameter("@ORG_ID", RIS_ORDER.ORG_ID)
                    , Parameter("@LAST_MODIFIED_BY", RIS_ORDER.LAST_MODIFIED_BY)
                    ,pINSURANCE_TYPE_ID
                    ,pPAT_STATUS
                    ,pLMP_DT
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterSelfArrival()
        {
            DbParameter[] parameters ={
                Parameter("@ORDER_ID", RIS_ORDER.ORDER_ID)
                ,Parameter("@SELF_ARRIVAL", RIS_ORDER.SELF_ARRIVAL)
                ,Parameter("@UserID", RIS_ORDER.LAST_MODIFIED_BY) 
                                      };
            return parameters;
        }
        //private DbParameter[] buildParameterCancel()
        //{
        //    DbParameter[] parameters ={
        //        Parameter("@ORDER_ID", RIS_ORDER.ORDER_ID)
        //        ,Parameter("@IS_CANCELED", RIS_ORDER.IS_CANCELED) 
        //        ,Parameter("@LAST_MODIFIED_BY",RIS_ORDER.LAST_MODIFIED_BY)
        //                              };
        //    return parameters;
        //}
        private DbParameter[] buildParameterCancel() // แก้ไขในนี้ครับ
        {
            DbParameter[] parameters ={
                Parameter("@ORDER_ID", RIS_ORDER.ORDER_ID)
                ,Parameter("@IS_CANCELED", RIS_ORDER.IS_CANCELED) 
                ,Parameter("@LAST_MODIFIED_BY",RIS_ORDER.LAST_MODIFIED_BY)
                ,Parameter("@REASON",RIS_ORDER.REASON)// เพิ่มตรงนี้ครับ
                                      };
            return parameters;
        }

        public void UpdateRequestResult()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateRequestResult;
            DbParameter pRequestResult = Parameter();
            pRequestResult.ParameterName = "@REQUEST_RESULT_DATETIME";
            if (RIS_ORDER.REQUEST_RESULT_DATETIME == null)
                pRequestResult.Value = DBNull.Value;
            else
                pRequestResult.Value = RIS_ORDER.REQUEST_RESULT_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDER.REQUEST_RESULT_DATETIME;

            DbParameter[] parameters ={
                                        Parameter("@ORDER_ID",RIS_ORDER.ORDER_ID),
                                        pRequestResult,
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
	}
}

