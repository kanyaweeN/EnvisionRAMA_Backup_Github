//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2552 02:48:53
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISExamresulttemplateInsertData : DataAccessBase 
	{
		private RISExamresulttemplate	_risexamresulttemplate;
		private RISExamresulttemplateInsertDataParameters	param;
		public  RISExamresulttemplateInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTTEMPLATE_Insert.ToString();
		}
		public  RISExamresulttemplate	RISExamresulttemplate
		{
			get{return _risexamresulttemplate;}
			set{_risexamresulttemplate=value;}
		}
		public int Add()
		{
			param= new RISExamresulttemplateInsertDataParameters(RISExamresulttemplate);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(param.Parameters);
            return (int)param.Parameters[0].Value;
		}
		
	}
	public class RISExamresulttemplateInsertDataParameters 
	{
		private RISExamresulttemplate _risexamresulttemplate;
		private SqlParameter[] _parameters;
		public RISExamresulttemplateInsertDataParameters(RISExamresulttemplate risexamresulttemplate)
		{
			RISExamresulttemplate=risexamresulttemplate;
			Build();
		}
		public  RISExamresulttemplate	RISExamresulttemplate
		{
			get{return _risexamresulttemplate;}
			set{_risexamresulttemplate=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter param1 = new SqlParameter("@TEMPLATE_ID", RISExamresulttemplate.TEMPLATE_ID);
            param1.Direction = ParameterDirection.Output;

			SqlParameter[] parameters ={	
		        param1
                ,new SqlParameter("@TEMPLATE_UID",RISExamresulttemplate.TEMPLATE_UID)
                ,new SqlParameter("@EXAM_ID",RISExamresulttemplate.EXAM_ID)
                ,new SqlParameter("@TEMPLATE_NAME",RISExamresulttemplate.TEMPLATE_NAME)
                ,new SqlParameter("@TEMPLATE_TEXT",RISExamresulttemplate.TEMPLATE_TEXT)
                ,new SqlParameter("@TEMPLATE_TEXT_RTF",RISExamresulttemplate.TEMPLATE_TEXT_RTF)
                ,new SqlParameter("@TEMPLATE_TYPE",RISExamresulttemplate.TEMPLATE_TYPE)
                ,new SqlParameter("@AUTO_APPLY",RISExamresulttemplate.AUTO_APPLY)
                ,new SqlParameter("@ORG_ID",RISExamresulttemplate.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISExamresulttemplate.CREATED_BY)
                ,new SqlParameter("@SEVERITY_ID",RISExamresulttemplate.SEVERITY_ID)
			};
			_parameters = parameters;
		}
	}
}

