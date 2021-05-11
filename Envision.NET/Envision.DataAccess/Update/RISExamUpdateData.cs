using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISExamUpdateData : DataAccessBase 
	{
        public RIS_EXAM RIS_EXAM { get; set; }

		public  RISExamUpdateData()
		{
            RIS_EXAM = new RIS_EXAM();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void UpdateBarcode(int EXAM_ID, string BARCODE)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Update_Barcode;
            ParameterList = buildParameter_Barcode(EXAM_ID,BARCODE);
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter pramUnitID = Parameter();
            pramUnitID.ParameterName = "@UNIT_ID";
            if (RIS_EXAM.UNIT_ID == null)
                pramUnitID.Value = DBNull.Value;
            else
                pramUnitID.Value = RIS_EXAM.UNIT_ID == 0 ? (object)DBNull.Value : RIS_EXAM.UNIT_ID;

            DbParameter pramICD_ID = Parameter();
            pramICD_ID.ParameterName = "@ICD_ID";
            if (RIS_EXAM.ICD_ID == null)
                pramICD_ID.Value = DBNull.Value;
            else
                pramICD_ID.Value = RIS_EXAM.ICD_ID == 0 ? (object)DBNull.Value : RIS_EXAM.ICD_ID;

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
                paramACR_ID.Value = RIS_EXAM.RELEASE_AUTH_LEVEL == 0 ? (object)DBNull.Value : RIS_EXAM.RELEASE_AUTH_LEVEL;
                    
            DbParameter paramFINALIZE_AUTH_LEVEL = Parameter();
            paramFINALIZE_AUTH_LEVEL.ParameterName = "@FINALIZE_AUTH_LEVEL";
            if (RIS_EXAM.FINALIZE_AUTH_LEVEL == null)
                paramFINALIZE_AUTH_LEVEL.Value = DBNull.Value;
            else
                paramFINALIZE_AUTH_LEVEL.Value = RIS_EXAM.FINALIZE_AUTH_LEVEL == 0 ? (object)DBNull.Value : RIS_EXAM.FINALIZE_AUTH_LEVEL;
                 
            DbParameter[] parameters ={
                Parameter("@EXAM_ID",RIS_EXAM.EXAM_ID),
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
                Parameter("@UNIT_ID",RIS_EXAM.UNIT_ID),
                //pramUnitID,
                Parameter("@REV_HEAD_ID",null),
                Parameter("@IS_ACTIVE",RIS_EXAM.IS_ACTIVE),
                Parameter("@AVG_REQ_HRS",RIS_EXAM.AVG_REQ_HRS),
                Parameter("@MIN_REQ_HRS",RIS_EXAM.MIN_REQ_HRS),
                Parameter("@COST_PRICE",RIS_EXAM.COST_PRICE),
                //Parameter("@STAT_FLAG",RIS_EXAM.STAT_FLAG),
                //Parameter("@URGENT_FLAG",RIS_EXAM.URGENT_FLAG),
                //paramRELEASE_AUTH_LEVEL,
                //paramFINALIZE_AUTH_LEVEL,
                Parameter("@RELEASE_AUTH_LEVEL",RIS_EXAM.RELEASE_AUTH_LEVEL),
                Parameter("@FINALIZE_AUTH_LEVEL",RIS_EXAM.FINALIZE_AUTH_LEVEL),
                Parameter("@PREPARATION_FLAG",RIS_EXAM.PREPARATION_FLAG),
                Parameter("@PREPARATION_TAT",RIS_EXAM.PREPARATION_TAT),
                Parameter("@REPEAT_FLAG",RIS_EXAM.REPEAT_FLAG),
                Parameter("@ICD_ID",RIS_EXAM.ICD_ID),
                //pramICD_ID,
                //paramACR_ID,
                Parameter("@ACR_ID",RIS_EXAM.ACR_ID),
                Parameter("@CPT_ID",DBNull.Value),
                Parameter("@DEF_CAPTURE",RIS_EXAM.DEF_CAPTURE),
                Parameter("@DEF_IMAGES",RIS_EXAM.DEF_IMAGES),
                Parameter("@IS_STRUCTURED_REPORT",RIS_EXAM.IS_STRUCTURED_REPORT),
                Parameter("@QA_REQUIRED",RIS_EXAM.QA_REQUIRED),
                Parameter("@IS_UPDATED",RIS_EXAM.IS_UPDATED),
                Parameter("@IS_DELETED",RIS_EXAM.IS_DELETED),
                Parameter("@ORG_ID",RIS_EXAM.ORG_ID),
                //Parameter("@CREATED_BY",RIS_EXAM.CREATED_BY),
                //Parameter("@CREATED_ON",RIS_EXAM.CREATED_ON),
                Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID),
                //Parameter("@LAST_MODIFIED_ON",RIS_EXAM.LAST_MODIFIED_ON)
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
        private DbParameter[] buildParameter_Barcode(int EXAM_ID, string BARCODE)
        {
            DbParameter[] parameters ={
                Parameter("@EXAM_ID",EXAM_ID),
                Parameter("@EXAM_BARCODE",BARCODE),
                Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                                      };
            return parameters;
        }
	}
}

