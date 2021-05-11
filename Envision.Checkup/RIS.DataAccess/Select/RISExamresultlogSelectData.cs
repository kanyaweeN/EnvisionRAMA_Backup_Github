//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    04/06/2009 10:15:35
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
	public class RISExamresultlogSelectData : DataAccessBase 
	{
		private RISExamresultlog	_risexamresultlog;
		private RISExamresultlogSelectDataParameters param;
		public  RISExamresultlogSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTLOG_Select.ToString();
		}
		public  RISExamresultlog	RISExamresultlog
		{
			get{return _risexamresultlog;}
			set{_risexamresultlog=value;}
		}
		public DataSet GetData()
		{
			param = new RISExamresultlogSelectDataParameters(RISExamresultlog);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISExamresultlogSelectDataParameters 
	{
		private RISExamresultlog _risexamresultlog;
		private SqlParameter[] _parameters;
		public RISExamresultlogSelectDataParameters(RISExamresultlog risexamresultlog)
		{
			RISExamresultlog=risexamresultlog;
			Build();
		}
		public  RISExamresultlog	RISExamresultlog
		{
			get{return _risexamresultlog;}
			set{_risexamresultlog=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@LOG_ID",RISExamresultlog.LOG_ID)
//,new SqlParameter("@EFFECTIVE_DT",RISExamresultlog.EFFECTIVE_DT)
//,new SqlParameter("@START_LSN",RISExamresultlog.START_LSN)
//,new SqlParameter("@SEQVAL",RISExamresultlog.SEQVAL)
//,new SqlParameter("@OPERATION",RISExamresultlog.OPERATION)
			
//,new SqlParameter("@UPDATE_MASK",RISExamresultlog.UPDATE_MASK)
//,new SqlParameter("@ACCESSION_NO",RISExamresultlog.ACCESSION_NO)
//,new SqlParameter("@ORDER_ID",RISExamresultlog.ORDER_ID)
//,new SqlParameter("@EXAM_ID",RISExamresultlog.EXAM_ID)
//,new SqlParameter("@RESULT_TEXT_HTML",RISExamresultlog.RESULT_TEXT_HTML)
			
//,new SqlParameter("@RESULT_TEXT_PLAIN",RISExamresultlog.RESULT_TEXT_PLAIN)
//,new SqlParameter("@RESULT_TEXT_RTF",RISExamresultlog.RESULT_TEXT_RTF)
//,new SqlParameter("@RESULT_BINARY",RISExamresultlog.RESULT_BINARY)
//,new SqlParameter("@RESULT_STATUS",RISExamresultlog.RESULT_STATUS)
//,new SqlParameter("@ICD_ID",RISExamresultlog.ICD_ID)
			
//,new SqlParameter("@SEVERITY_ID",RISExamresultlog.SEVERITY_ID)
//,new SqlParameter("@HL7_TEXT",RISExamresultlog.HL7_TEXT)
//,new SqlParameter("@HL7_SEND",RISExamresultlog.HL7_SEND)
//,new SqlParameter("@RELEASED_BY",RISExamresultlog.RELEASED_BY)
//,new SqlParameter("@RELEASED_ON",RISExamresultlog.RELEASED_ON)
			
//,new SqlParameter("@FINALIZED_BY",RISExamresultlog.FINALIZED_BY)
//,new SqlParameter("@FINALIZED_ON",RISExamresultlog.FINALIZED_ON)
//,new SqlParameter("@ORG_ID",RISExamresultlog.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISExamresultlog.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamresultlog.CREATED_ON)
			
//,new SqlParameter("@LAST_MODIFIED_BY",RISExamresultlog.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamresultlog.LAST_MODIFIED_ON)
new SqlParameter("@FROM_DATE",RISExamresultlog.FROMDATE)
,new SqlParameter("@TO_DATE",RISExamresultlog.TODATE)
			};
			_parameters=parameters;
		}
	}
}

