//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:36:03
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
	public class RISSchedulelogSelectData : DataAccessBase 
	{
		private RISSchedulelog	_risschedulelog;
		private RISSchedulelogSelectDataParameters param;
		public  RISSchedulelogSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULELOG_Select2.ToString();
		}
		public  RISSchedulelog	RISSchedulelog
		{
			get{return _risschedulelog;}
			set{_risschedulelog=value;}
		}
		public DataSet GetData()
		{
			param = new RISSchedulelogSelectDataParameters(RISSchedulelog);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISSchedulelogSelectDataParameters 
	{
		private RISSchedulelog _risschedulelog;
		private SqlParameter[] _parameters;
		public RISSchedulelogSelectDataParameters(RISSchedulelog risschedulelog)
		{
			RISSchedulelog=risschedulelog;
			Build();
		}
		public  RISSchedulelog	RISSchedulelog
		{
			get{return _risschedulelog;}
			set{_risschedulelog=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@LOG_ID",RISSchedulelog.LOG_ID)
//,new SqlParameter("@EFFECTIVE_DT",RISSchedulelog.EFFECTIVE_DT)
//,new SqlParameter("@START_LSN",RISSchedulelog.START_LSN)
//,new SqlParameter("@SEQVAL",RISSchedulelog.SEQVAL)
//,new SqlParameter("@OPERATION",RISSchedulelog.OPERATION)
			
//,new SqlParameter("@UPDATE_MASK",RISSchedulelog.UPDATE_MASK)
//,new SqlParameter("@SCHEDULE_ID",RISSchedulelog.SCHEDULE_ID)
//,new SqlParameter("@REG_ID",RISSchedulelog.REG_ID)
//,new SqlParameter("@HN",RISSchedulelog.HN)
//,new SqlParameter("@MODALITY_ID",RISSchedulelog.MODALITY_ID)
			
//,new SqlParameter("@EXAM_ID",RISSchedulelog.EXAM_ID)
//,new SqlParameter("@VISIT_NO",RISSchedulelog.VISIT_NO)
//,new SqlParameter("@APPOINT_DT",RISSchedulelog.APPOINT_DT)
//,new SqlParameter("@QTY",RISSchedulelog.QTY)
//,new SqlParameter("@COMMENTS",RISSchedulelog.COMMENTS)
			
//,new SqlParameter("@SPECIAL_CLINIC",RISSchedulelog.SPECIAL_CLINIC)
//,new SqlParameter("@ALLPROPERTIES",RISSchedulelog.ALLPROPERTIES)
//,new SqlParameter("@SCHEDULE_DATA",RISSchedulelog.SCHEDULE_DATA)
//,new SqlParameter("@BLOCK_REASON",RISSchedulelog.BLOCK_REASON)
//,new SqlParameter("@ADMISSION_NO",RISSchedulelog.ADMISSION_NO)
			
//,new SqlParameter("@SCHEDULE_DT",RISSchedulelog.SCHEDULE_DT)
//,new SqlParameter("@START_DATETIME",RISSchedulelog.START_DATETIME)
//,new SqlParameter("@END_DATETIME",RISSchedulelog.END_DATETIME)
//,new SqlParameter("@REF_UNIT",RISSchedulelog.REF_UNIT)
//,new SqlParameter("@REF_DOC",RISSchedulelog.REF_DOC)
			
//,new SqlParameter("@REF_DOC_INSTRUCTION",RISSchedulelog.REF_DOC_INSTRUCTION)
//,new SqlParameter("@CLINICAL_INSTRUCTION",RISSchedulelog.CLINICAL_INSTRUCTION)
//,new SqlParameter("@REASON",RISSchedulelog.REASON)
//,new SqlParameter("@DIAGNOSIS",RISSchedulelog.DIAGNOSIS)
//,new SqlParameter("@ICD_ID",RISSchedulelog.ICD_ID)
			
//,new SqlParameter("@SCHEDULE_STATUS",RISSchedulelog.SCHEDULE_STATUS)
//,new SqlParameter("@CONFIRMED_BY",RISSchedulelog.CONFIRMED_BY)
//,new SqlParameter("@CONFIRMED_ON",RISSchedulelog.CONFIRMED_ON)
//,new SqlParameter("@ORG_ID",RISSchedulelog.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISSchedulelog.CREATED_BY)
			
//,new SqlParameter("@CREATED_ON",RISSchedulelog.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISSchedulelog.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISSchedulelog.LAST_MODIFIED_ON)
//,new SqlParameter("@CLINIC_TYPE",RISSchedulelog.CLINIC_TYPE)
//,new SqlParameter("@RATE",RISSchedulelog.RATE)
			
//,new SqlParameter("@IS_BLOCK",RISSchedulelog.IS_BLOCK)
//,new SqlParameter("@GEN_DTL_ID",RISSchedulelog.GEN_DTL_ID)
//,new SqlParameter("@RAD_ID",RISSchedulelog.RAD_ID)
//,new SqlParameter("@PAT_STATUS",RISSchedulelog.PAT_STATUS)
//,new SqlParameter("@LMP_DT",RISSchedulelog.LMP_DT)
                new SqlParameter("@FROMDATE",RISSchedulelog.FROMDATE)
                ,new SqlParameter("@TODATE",RISSchedulelog.TODATE)
			};
			_parameters=parameters;
		}
	}
}

