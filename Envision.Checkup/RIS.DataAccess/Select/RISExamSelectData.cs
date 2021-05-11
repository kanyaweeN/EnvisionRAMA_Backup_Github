//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    26/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISExamSelectData : DataAccessBase 
	{
		private RISExam	_risexam;
		private RISExamInsertDataParameters	_risexaminsertdataparameters;

		public  RISExamSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAM_Select.ToString();
		}
        public RISExamSelectData(bool selectAll) {
            if(selectAll)
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAM_SelectAll.ToString();
            else
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAM_Select.ToString();
        }
		public  RISExam	RISExam
		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public DataSet GetData()
		{
            //_risexaminsertdataparameters = new RISExamInsertDataParameters(RISExam);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
        public DataSet GetConsumable() {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAM_SelectConsumable.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
            return ds;
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
            SqlParameter[] parameters ={new SqlParameter("@EXAM_ID",RISExam.EXAM_ID),new SqlParameter("@EXAM_UID",RISExam.EXAM_UID),new SqlParameter("@GOVT_ID",RISExam.GOVT_ID),new SqlParameter("@EXAM_NAME",RISExam.EXAM_NAME),new SqlParameter("@REPORT_HEADER",RISExam.REPORT_HEADER)
            ,new SqlParameter("@REQ_SAMPLE",RISExam.REQ_SAMPLE),new SqlParameter("@RATE",RISExam.RATE),new SqlParameter("@GOVT_RATE",RISExam.GOVT_RATE),new SqlParameter("@EXAM_TYPE",RISExam.EXAM_TYPE),new SqlParameter("@SERVICE_TYPE",RISExam.SERVICE_TYPE)
            ,new SqlParameter("@CLAIMABLE_AMT",RISExam.CLAIMABLE_AMT),new SqlParameter("@NONCLAIMABLE_AMT",RISExam.NONCLAIMABLE_AMT),new SqlParameter("@FREE_AMT",RISExam.FREE_AMT),new SqlParameter("@SPECIAL_CLINIC",RISExam.SPECIAL_CLINIC),new SqlParameter("@SPECIAL_RATE",RISExam.SPECIAL_RATE)
            ,new SqlParameter("@VAT_APPLICABLE",RISExam.VAT_APPLICABLE),new SqlParameter("@VAT_RATE",RISExam.VAT_RATE),new SqlParameter("@UNIT_ID",RISExam.UNIT_ID),new SqlParameter("@REV_HEAD_ID",RISExam.REV_HEAD_ID),new SqlParameter("@IS_ACTIVE",RISExam.IS_ACTIVE)
            ,new SqlParameter("@AVG_REQ_HRS",RISExam.AVG_REQ_HRS),new SqlParameter("@MIN_REQ_HRS",RISExam.MIN_REQ_HRS),new SqlParameter("@COST_PRICE",RISExam.COST_PRICE),new SqlParameter("@STAT_FLAG",RISExam.STAT_FLAG),new SqlParameter("@URGENT_FLAG",RISExam.URGENT_FLAG)
            ,new SqlParameter("@RELEASE_AUTH_LEVEL",RISExam.RELEASE_AUTH_LEVEL),new SqlParameter("@FINALIZE_AUTH_LEVEL",RISExam.FINALIZE_AUTH_LEVEL),new SqlParameter("@PREPARATION_FLAG",RISExam.PREPARATION_FLAG),new SqlParameter("@PREPARATION_TAT",RISExam.PREPARATION_TAT),new SqlParameter("@REPEAT_FLAG",RISExam.REPEAT_FLAG)
            ,new SqlParameter("@ICD_ID",RISExam.ICD_ID),new SqlParameter("@ACR_ID",RISExam.ACR_ID),new SqlParameter("@CPT_ID",RISExam.CPT_ID),new SqlParameter("@DEF_CAPTURE",RISExam.DEF_CAPTURE),new SqlParameter("@DEF_IMAGES",RISExam.DEF_IMAGES)
            ,new SqlParameter("@IS_STRUCTURED_REPORT",RISExam.IS_STRUCTURED_REPORT),new SqlParameter("@QA_REQUIRED",RISExam.QA_REQUIRED),new SqlParameter("@IS_UPDATED",RISExam.IS_UPDATED),new SqlParameter("@IS_DELETED",RISExam.IS_DELETED),new SqlParameter("@ORG_ID",RISExam.ORG_ID)
            ,new SqlParameter("@CREATED_BY",RISExam.CREATED_BY),new SqlParameter("@CREATED_ON",RISExam.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",RISExam.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISExam.LAST_MODIFIED_ON)};
			Parameters = parameters;
		}
	}
}

