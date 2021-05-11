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
	public class RISExamtemplateshareInsertData : DataAccessBase 
	{
		private RISExamtemplateshare	_risexamtemplateshare;
		private RISExamtemplateshareInsertDataParameters	param;
		public  RISExamtemplateshareInsertData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMTEMPLATESHARE_Insert.ToString();
		}
		public  RISExamtemplateshare	RISExamtemplateshare
		{
			get{return _risexamtemplateshare;}
			set{_risexamtemplateshare=value;}
		}
		public bool Add()
		{
			param= new RISExamtemplateshareInsertDataParameters(RISExamtemplateshare);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		
	}
	public class RISExamtemplateshareInsertDataParameters 
	{
		private RISExamtemplateshare _risexamtemplateshare;
		private SqlParameter[] _parameters;
		public RISExamtemplateshareInsertDataParameters(RISExamtemplateshare risexamtemplateshare)
		{
			RISExamtemplateshare=risexamtemplateshare;
			Build();
		}
		public  RISExamtemplateshare	RISExamtemplateshare
		{
			get{return _risexamtemplateshare;}
			set{_risexamtemplateshare=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@EXAM_ID",RISExamtemplateshare.EXAM_ID)
                ,new SqlParameter("@TEMPLATE_ID",RISExamtemplateshare.TEMPLATE_ID)
                ,new SqlParameter("@SHARE_WITH",RISExamtemplateshare.SHARE_WITH)
                ,new SqlParameter("@ORG_ID",RISExamtemplateshare.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISExamtemplateshare.CREATED_BY)
			};
			_parameters = parameters;
		}
	}
}

