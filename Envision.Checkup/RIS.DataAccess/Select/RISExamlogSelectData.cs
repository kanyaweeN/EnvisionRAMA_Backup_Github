//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:20:56
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISExamlogSelectData : DataAccessBase 
	{
		private RISExamlog	_risexamlog;
		private RISExamlogSelectDataParameters param;
		public  RISExamlogSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMLOG_Select.ToString();
		}
		public  RISExamlog	RISExamlog
		{
			get{return _risexamlog;}
			set{_risexamlog=value;}
		}
		public DataSet GetData()
		{
			param = new RISExamlogSelectDataParameters(RISExamlog);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISExamlogSelectDataParameters 
	{
		private RISExamlog _risexamlog;
		private SqlParameter[] _parameters;
		public RISExamlogSelectDataParameters(RISExamlog risexamlog)
		{
			RISExamlog=risexamlog;
			Build();
		}
		public  RISExamlog	RISExamlog
		{
			get{return _risexamlog;}
			set{_risexamlog=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@LOG_ID",RISExamlog.LOG_ID)
//,new SqlParameter("@EFFECTIVE_DT",RISExamlog.EFFECTIVE_DT)
//,new SqlParameter("@START_LSN",RISExamlog.START_LSN)
//,new SqlParameter("@SEQVAL",RISExamlog.SEQVAL)
//,new SqlParameter("@OPERATION",RISExamlog.OPERATION)
			
//,new SqlParameter("@UPDATE_MASK",RISExamlog.UPDATE_MASK)
//,new SqlParameter("@EXAM_ID",RISExamlog.EXAM_ID)
//,new SqlParameter("@EXAM_UID",RISExamlog.EXAM_UID)
//,new SqlParameter("@GOVT_ID",RISExamlog.GOVT_ID)
//,new SqlParameter("@EXAM_NAME",RISExamlog.EXAM_NAME)
			
//,new SqlParameter("@REPORT_HEADER",RISExamlog.REPORT_HEADER)
//,new SqlParameter("@REQ_SAMPLE",RISExamlog.REQ_SAMPLE)
//,new SqlParameter("@RATE",RISExamlog.RATE)
//,new SqlParameter("@GOVT_RATE",RISExamlog.GOVT_RATE)
//,new SqlParameter("@EXAM_TYPE",RISExamlog.EXAM_TYPE)
			
//,new SqlParameter("@SERVICE_TYPE",RISExamlog.SERVICE_TYPE)
//,new SqlParameter("@CLAIMABLE_AMT",RISExamlog.CLAIMABLE_AMT)
//,new SqlParameter("@NONCLAIMABLE_AMT",RISExamlog.NONCLAIMABLE_AMT)
//,new SqlParameter("@FREE_AMT",RISExamlog.FREE_AMT)
//,new SqlParameter("@SPECIAL_CLINIC",RISExamlog.SPECIAL_CLINIC)
			
//,new SqlParameter("@SPECIAL_RATE",RISExamlog.SPECIAL_RATE)
//,new SqlParameter("@VAT_APPLICABLE",RISExamlog.VAT_APPLICABLE)
//,new SqlParameter("@VAT_RATE",RISExamlog.VAT_RATE)
//,new SqlParameter("@UNIT_ID",RISExamlog.UNIT_ID)
//,new SqlParameter("@REV_HEAD_ID",RISExamlog.REV_HEAD_ID)
			
//,new SqlParameter("@IS_ACTIVE",RISExamlog.IS_ACTIVE)
//,new SqlParameter("@AVG_REQ_HRS",RISExamlog.AVG_REQ_HRS)
//,new SqlParameter("@MIN_REQ_HRS",RISExamlog.MIN_REQ_HRS)
//,new SqlParameter("@COST_PRICE",RISExamlog.COST_PRICE)
//,new SqlParameter("@RELEASE_AUTH_LEVEL",RISExamlog.RELEASE_AUTH_LEVEL)
			
//,new SqlParameter("@FINALIZE_AUTH_LEVEL",RISExamlog.FINALIZE_AUTH_LEVEL)
//,new SqlParameter("@PREPARATION_FLAG",RISExamlog.PREPARATION_FLAG)
//,new SqlParameter("@PREPARATION_TAT",RISExamlog.PREPARATION_TAT)
//,new SqlParameter("@REPEAT_FLAG",RISExamlog.REPEAT_FLAG)
//,new SqlParameter("@ICD_ID",RISExamlog.ICD_ID)
			
//,new SqlParameter("@ACR_ID",RISExamlog.ACR_ID)
//,new SqlParameter("@CPT_ID",RISExamlog.CPT_ID)
//,new SqlParameter("@DEF_CAPTURE",RISExamlog.DEF_CAPTURE)
//,new SqlParameter("@DEF_IMAGES",RISExamlog.DEF_IMAGES)
//,new SqlParameter("@IS_STRUCTURED_REPORT",RISExamlog.IS_STRUCTURED_REPORT)
			
//,new SqlParameter("@QA_REQUIRED",RISExamlog.QA_REQUIRED)
//,new SqlParameter("@IS_UPDATED",RISExamlog.IS_UPDATED)
//,new SqlParameter("@IS_DELETED",RISExamlog.IS_DELETED)
//,new SqlParameter("@ORG_ID",RISExamlog.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISExamlog.CREATED_BY)
			
//,new SqlParameter("@CREATED_ON",RISExamlog.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISExamlog.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamlog.LAST_MODIFIED_ON)
//,new SqlParameter("@BP_ID",RISExamlog.BP_ID)
//,new SqlParameter("@STAT_POSSIBLE",RISExamlog.STAT_POSSIBLE)
			
//,new SqlParameter("@STAT_TAT_MIN",RISExamlog.STAT_TAT_MIN)
//,new SqlParameter("@URGENT_POSSIBLE",RISExamlog.URGENT_POSSIBLE)
//,new SqlParameter("@URGENT_TAT_MIN",RISExamlog.URGENT_TAT_MIN)
//,new SqlParameter("@DEFER_HIS_RECONCILE",RISExamlog.DEFER_HIS_RECONCILE)
//,new SqlParameter("@IS_CHECKUP",RISExamlog.IS_CHECKUP)
			
//,new SqlParameter("@VIP_RATE",RISExamlog.VIP_RATE)
                new SqlParameter("@FROMDATE",RISExamlog.FROMDATE)
                ,new SqlParameter("@TODATE",RISExamlog.TODATE)
			};
			_parameters=parameters;
		}
	}
}

