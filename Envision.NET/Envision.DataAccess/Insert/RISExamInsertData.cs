//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISExamInsertData : DataAccessBase 
	{
        public RIS_EXAM RIS_EXAM { get; set; }
        public RISExamInsertData()
		{
            RIS_EXAM = new RIS_EXAM();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void AddByHIS() {
            StoredProcedureName = StoredProcedure.XREGIST_ExamInsert;
            ParameterList = buildParameterHIS();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter paramCreateOn = Parameter();
            paramCreateOn.ParameterName = "@CREATED_ON";
            if (RIS_EXAM.CREATED_ON == null)
                paramCreateOn.Value = DBNull.Value;
            else
                paramCreateOn.Value = RIS_EXAM.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_EXAM.CREATED_ON;

            DbParameter paramUnitID = Parameter();
            paramUnitID.ParameterName = "@UNIT_ID";
            if (RIS_EXAM.UNIT_ID == null)
                paramUnitID.Value = DBNull.Value;
            else
                paramUnitID.Value = RIS_EXAM.UNIT_ID == 0 ? (object)DBNull.Value : RIS_EXAM.UNIT_ID;

            DbParameter paramICD_ID = Parameter();
            paramICD_ID.ParameterName = "@ICD_ID";
            if (RIS_EXAM.ICD_ID == null)
                paramICD_ID.Value = DBNull.Value;
            else
                paramICD_ID.Value = RIS_EXAM.ICD_ID == 0 ? (object)DBNull.Value : RIS_EXAM.ICD_ID;

            DbParameter paramACR_ID = Parameter();
            paramACR_ID.ParameterName = "@ACR_ID";
            if (RIS_EXAM.ACR_ID == null)
                paramACR_ID.Value = DBNull.Value;
            else
                paramACR_ID.Value = RIS_EXAM.ACR_ID == 0 ? (object)DBNull.Value : RIS_EXAM.ACR_ID;

            DbParameter paramRELEASE_AUTH_LEVEL = Parameter();
            paramRELEASE_AUTH_LEVEL.ParameterName = "@RELEASE_AUTH_LEVEL";
            if (RIS_EXAM.RELEASE_AUTH_LEVEL == null)
                paramRELEASE_AUTH_LEVEL.Value = DBNull.Value;
            else
                paramRELEASE_AUTH_LEVEL.Value = RIS_EXAM.RELEASE_AUTH_LEVEL == 0 ? (object)DBNull.Value : RIS_EXAM.RELEASE_AUTH_LEVEL;

            DbParameter paramFINALIZE_AUTH_LEVEL = Parameter();
            paramFINALIZE_AUTH_LEVEL.ParameterName = "@FINALIZE_AUTH_LEVEL";
            if (RIS_EXAM.FINALIZE_AUTH_LEVEL == null)
                paramFINALIZE_AUTH_LEVEL.Value = DBNull.Value;
            else
                paramFINALIZE_AUTH_LEVEL.Value = RIS_EXAM.FINALIZE_AUTH_LEVEL == 0 ? (object)DBNull.Value : RIS_EXAM.FINALIZE_AUTH_LEVEL;

            DbParameter[] parameters ={			
                Parameter("@EXAM_UID",RIS_EXAM.EXAM_UID),
                Parameter("@GOVT_ID",RIS_EXAM.GOVT_ID),
                Parameter("@EXAM_NAME",RIS_EXAM.EXAM_NAME),
                Parameter("@REPORT_HEADER",RIS_EXAM.REPORT_HEADER),
                Parameter("@REQ_SAMPLE",RIS_EXAM.REQ_SAMPLE),
                Parameter("@RATE",RIS_EXAM.RATE),
                Parameter("@GOVT_RATE",RIS_EXAM.GOVT_RATE),
                Parameter("@EXAM_TYPE",RIS_EXAM.EXAM_TYPE),
                Parameter("@SERVICE_TYPE",RIS_EXAM.SERVICE_TYPE),
                Parameter("@CLAIMABLE_AMT",RIS_EXAM.CLAIMABLE_AMT),
                Parameter("@NONCLAIMABLE_AMT",RIS_EXAM.NONCLAIMABLE_AMT),
                Parameter("@FREE_AMT",RIS_EXAM.FREE_AMT),
                Parameter("@SPECIAL_CLINIC",RIS_EXAM.SPECIAL_CLINIC),
                Parameter("@SPECIAL_RATE",RIS_EXAM.SPECIAL_RATE),
                Parameter("@VAT_APPLICABLE",RIS_EXAM.VAT_APPLICABLE),
                Parameter("@VAT_RATE",RIS_EXAM.VAT_RATE),
                paramUnitID,
                Parameter("@REV_HEAD_ID",null),
                Parameter("@IS_ACTIVE",RIS_EXAM.IS_ACTIVE),
                Parameter("@AVG_REQ_HRS",RIS_EXAM.AVG_REQ_HRS),
                Parameter("@MIN_REQ_HRS",RIS_EXAM.MIN_REQ_HRS),
                Parameter("@COST_PRICE",RIS_EXAM.COST_PRICE),
                paramRELEASE_AUTH_LEVEL,
                paramFINALIZE_AUTH_LEVEL,
                Parameter("@PREPARATION_FLAG",RIS_EXAM.PREPARATION_FLAG),
                Parameter("@PREPARATION_TAT",RIS_EXAM.PREPARATION_TAT),
                Parameter("@REPEAT_FLAG",RIS_EXAM.REPEAT_FLAG),
                paramICD_ID,
                paramACR_ID,
                Parameter("@CPT_ID",RIS_EXAM.CPT_ID),
                Parameter("@DEF_CAPTURE",RIS_EXAM.DEF_CAPTURE),
                Parameter("@DEF_IMAGES",RIS_EXAM.DEF_IMAGES),
                Parameter("@IS_STRUCTURED_REPORT",RIS_EXAM.IS_STRUCTURED_REPORT),
                Parameter("@QA_REQUIRED",RIS_EXAM.QA_REQUIRED),
                Parameter("@IS_UPDATED",RIS_EXAM.IS_UPDATED),
                Parameter("@IS_DELETED",RIS_EXAM.IS_DELETED),
                Parameter("@ORG_ID",RIS_EXAM.ORG_ID),
                Parameter("@CREATED_BY",RIS_EXAM.CREATED_BY),
                paramCreateOn,
                Parameter("@BP_ID",RIS_EXAM.BP_ID),
                Parameter("@VIP_RATE",RIS_EXAM.VIP_RATE),
                Parameter("@DEFER_HIS_RECONCILE", RIS_EXAM.DEFER_HIS_RECONCILE),
                Parameter("@DF_RAD", RIS_EXAM.DF_RAD),
                Parameter("@FOREIGN_RATE", RIS_EXAM.FOREIGN_RATE),
                Parameter("@BILLING_CODE",RIS_EXAM.BILLING_CODE),
                Parameter("@FOREIGN_SPCIAL_RATE", RIS_EXAM.FOREIGN_SPCIAL_RATE),
                Parameter("@FOREIGN_VIP_RATE", RIS_EXAM.FOREIGN_VIP_RATE),
			            };
            return parameters;
        }
        private DbParameter[] buildParameterHIS() {
            DbParameter[] parameters =
            {			
                Parameter("@EXAM_UID",RIS_EXAM.EXAM_UID),
                Parameter("@EXAM_NAME",RIS_EXAM.EXAM_NAME),
                Parameter("@RATE",RIS_EXAM.RATE),
                Parameter("@SPECIAL_RATE",RIS_EXAM.SPECIAL_RATE)
            };
            return parameters;
        }
	}
}

