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
	public class RISExamresulttemplatelogSelectData : DataAccessBase 
	{
		private RISExamresulttemplatelog	_risexamresulttemplatelog;
		private RISExamresulttemplatelogSelectDataParameters param;
		public  RISExamresulttemplatelogSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTTEMPLATELOG_Select.ToString();
		}
		public  RISExamresulttemplatelog	RISExamresulttemplatelog
		{
			get{return _risexamresulttemplatelog;}
			set{_risexamresulttemplatelog=value;}
		}
		public DataSet GetData()
		{
			param = new RISExamresulttemplatelogSelectDataParameters(RISExamresulttemplatelog);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISExamresulttemplatelogSelectDataParameters 
	{
		private RISExamresulttemplatelog _risexamresulttemplatelog;
		private SqlParameter[] _parameters;
		public RISExamresulttemplatelogSelectDataParameters(RISExamresulttemplatelog risexamresulttemplatelog)
		{
			RISExamresulttemplatelog=risexamresulttemplatelog;
			Build();
		}
		public  RISExamresulttemplatelog	RISExamresulttemplatelog
		{
			get{return _risexamresulttemplatelog;}
			set{_risexamresulttemplatelog=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@LOG_ID",RISExamresulttemplatelog.LOG_ID)
//,new SqlParameter("@EFFECTIVE_DT",RISExamresulttemplatelog.EFFECTIVE_DT)
//,new SqlParameter("@START_LSN",RISExamresulttemplatelog.START_LSN)
//,new SqlParameter("@SEQVAL",RISExamresulttemplatelog.SEQVAL)
//,new SqlParameter("@OPERATION",RISExamresulttemplatelog.OPERATION)
			
//,new SqlParameter("@UPDATE_MASK",RISExamresulttemplatelog.UPDATE_MASK)
//,new SqlParameter("@TEMPLATE_ID",RISExamresulttemplatelog.TEMPLATE_ID)
//,new SqlParameter("@TEMPLATE_UID",RISExamresulttemplatelog.TEMPLATE_UID)
//,new SqlParameter("@EXAM_ID",RISExamresulttemplatelog.EXAM_ID)
//,new SqlParameter("@TEMPLATE_NAME",RISExamresulttemplatelog.TEMPLATE_NAME)
			
//,new SqlParameter("@TEMPLATE_HEADER",RISExamresulttemplatelog.TEMPLATE_HEADER)
//,new SqlParameter("@TEMPLATE_TEXT",RISExamresulttemplatelog.TEMPLATE_TEXT)
//,new SqlParameter("@TEMPLATE_TEXT_RTF",RISExamresulttemplatelog.TEMPLATE_TEXT_RTF)
//,new SqlParameter("@TEMPLATE_BINARY",RISExamresulttemplatelog.TEMPLATE_BINARY)
//,new SqlParameter("@TEMPLATE_TYPE",RISExamresulttemplatelog.TEMPLATE_TYPE)
			
//,new SqlParameter("@SEVERITY_ID",RISExamresulttemplatelog.SEVERITY_ID)
//,new SqlParameter("@AUTO_APPLY",RISExamresulttemplatelog.AUTO_APPLY)
//,new SqlParameter("@IS_UPDATED",RISExamresulttemplatelog.IS_UPDATED)
//,new SqlParameter("@IS_DELETED",RISExamresulttemplatelog.IS_DELETED)
//,new SqlParameter("@ORG_ID",RISExamresulttemplatelog.ORG_ID)
			
//,new SqlParameter("@CREATED_BY",RISExamresulttemplatelog.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamresulttemplatelog.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISExamresulttemplatelog.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamresulttemplatelog.LAST_MODIFIED_ON)
                new SqlParameter("@FROMDATE",RISExamresulttemplatelog.FROMDATE)
                ,new SqlParameter("@TODATE",RISExamresulttemplatelog.TODATE)
			};
			_parameters=parameters;
		}
	}
}

