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
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISExamInsertData : DataAccessBase 
	{
		private RISExam	_risexam;
		private RISExamInsertDataParameters	_risexaminsertdataparameters;
		public  RISExamInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAM_Insert.ToString();
		}
		public  RISExam	RISExam
		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public void Add()
		{
			_risexaminsertdataparameters = new RISExamInsertDataParameters(RISExam);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risexaminsertdataparameters.Parameters);
		}
	}
	public class RISExamInsertDataParameters 
	{
		private RISExam _risexam;
		private SqlParameter[] _parameters;
		public RISExamInsertDataParameters(RISExam risexam)
		{
			RISExam=risexam;
			Build();
		}
		public  RISExam	RISExam
		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter paramCreateOn = new SqlParameter();
            paramCreateOn.ParameterName = "@CREATED_ON";
            if (RISExam.CREATED_ON == DateTime.MinValue)
                paramCreateOn.Value = DBNull.Value;
            else
                paramCreateOn.Value = RISExam.CREATED_ON;

            SqlParameter paramUnitID = new SqlParameter();
            paramUnitID.ParameterName = "@UNIT_ID";
            if (RISExam.UNIT_ID == 0)
                paramUnitID.Value = DBNull.Value;
            else
                paramUnitID.Value = RISExam.UNIT_ID;

            SqlParameter paramICD_ID = new SqlParameter();
            paramICD_ID.ParameterName = "@ICD_ID";
            if (RISExam.ICD_ID == 0)
                paramICD_ID.Value = DBNull.Value;
            else
                paramICD_ID.Value = RISExam.ICD_ID;

            SqlParameter paramACR_ID = new SqlParameter();
            paramACR_ID.ParameterName = "@ACR_ID";
            if (RISExam.ACR_ID == 0)
                paramACR_ID.Value = DBNull.Value;
            else
                paramACR_ID.Value = RISExam.ACR_ID;

            SqlParameter paramRELEASE_AUTH_LEVEL = new SqlParameter();
            paramRELEASE_AUTH_LEVEL.ParameterName = "@RELEASE_AUTH_LEVEL";
            if (RISExam.RELEASE_AUTH_LEVEL == 0)
                paramRELEASE_AUTH_LEVEL.Value = DBNull.Value;
            else
                paramRELEASE_AUTH_LEVEL.Value = RISExam.RELEASE_AUTH_LEVEL;

            SqlParameter paramFINALIZE_AUTH_LEVEL = new SqlParameter();
            paramFINALIZE_AUTH_LEVEL.ParameterName = "@FINALIZE_AUTH_LEVEL";
            if (RISExam.FINALIZE_AUTH_LEVEL == 0)
                paramFINALIZE_AUTH_LEVEL.Value = DBNull.Value;
            else
                paramFINALIZE_AUTH_LEVEL.Value = RISExam.FINALIZE_AUTH_LEVEL;

			SqlParameter[] parameters =
            {
                new SqlParameter("@EXAM_UID",RISExam.EXAM_UID),
                new SqlParameter("@GOVT_ID",RISExam.GOVT_ID),
                new SqlParameter("@EXAM_NAME",RISExam.EXAM_NAME),
                new SqlParameter("@REPORT_HEADER",RISExam.REPORT_HEADER),
                new SqlParameter("@REQ_SAMPLE",RISExam.REQ_SAMPLE),
                new SqlParameter("@RATE",RISExam.RATE),
                new SqlParameter("@GOVT_RATE",RISExam.GOVT_RATE),
                new SqlParameter("@EXAM_TYPE",RISExam.EXAM_TYPE),
                new SqlParameter("@SERVICE_TYPE",RISExam.SERVICE_TYPE),
                new SqlParameter("@CLAIMABLE_AMT",RISExam.CLAIMABLE_AMT),
                new SqlParameter("@NONCLAIMABLE_AMT",RISExam.NONCLAIMABLE_AMT),
                new SqlParameter("@FREE_AMT",RISExam.FREE_AMT),
                new SqlParameter("@SPECIAL_CLINIC",RISExam.SPECIAL_CLINIC),
                new SqlParameter("@SPECIAL_RATE",RISExam.SPECIAL_RATE),
                new SqlParameter("@VAT_APPLICABLE",RISExam.VAT_APPLICABLE),
                new SqlParameter("@VAT_RATE",RISExam.VAT_RATE),
                paramUnitID,
                new SqlParameter("@REV_HEAD_ID",null),
                new SqlParameter("@IS_ACTIVE",RISExam.IS_ACTIVE),
                new SqlParameter("@AVG_REQ_HRS",RISExam.AVG_REQ_HRS),
                new SqlParameter("@MIN_REQ_HRS",RISExam.MIN_REQ_HRS),
                new SqlParameter("@COST_PRICE",RISExam.COST_PRICE),
                //new SqlParameter("@STAT_FLAG",RISExam.STAT_FLAG),
                //new SqlParameter("@URGENT_FLAG",RISExam.URGENT_FLAG),
                paramRELEASE_AUTH_LEVEL,
                paramFINALIZE_AUTH_LEVEL,
                //new SqlParameter("@RELEASE_AUTH_LEVEL",RISExam.RELEASE_AUTH_LEVEL),
                //new SqlParameter("@FINALIZE_AUTH_LEVEL",RISExam.FINALIZE_AUTH_LEVEL),
                new SqlParameter("@PREPARATION_FLAG",RISExam.PREPARATION_FLAG),
                new SqlParameter("@PREPARATION_TAT",RISExam.PREPARATION_TAT),
                new SqlParameter("@REPEAT_FLAG",RISExam.REPEAT_FLAG),
                paramICD_ID,
                paramACR_ID,
                //new SqlParameter("@ICD_ID",RISExam.ICD_ID),
                //new SqlParameter("@ACR_ID",RISExam.ACR_ID),
                new SqlParameter("@CPT_ID",RISExam.CPT_ID),
                new SqlParameter("@DEF_CAPTURE",RISExam.DEF_CAPTURE),
                new SqlParameter("@DEF_IMAGES",RISExam.DEF_IMAGES),
                new SqlParameter("@IS_STRUCTURED_REPORT",RISExam.IS_STRUCTURED_REPORT),
                new SqlParameter("@QA_REQUIRED",RISExam.QA_REQUIRED),
                new SqlParameter("@IS_UPDATED",RISExam.IS_UPDATED),
                new SqlParameter("@IS_DELETED",RISExam.IS_DELETED),
                new SqlParameter("@ORG_ID",RISExam.ORG_ID),
                new SqlParameter("@CREATED_BY",RISExam.CREATED_BY),
                paramCreateOn,
                new SqlParameter("@BP_ID",RISExam.BP_ID),
                new SqlParameter("@VIP_RATE",RISExam.VIP_RATE),
                new SqlParameter("@IS_CHECKUP",RISExam.IS_CHECKUP),
            };
			Parameters = parameters;
		}
	}
}

