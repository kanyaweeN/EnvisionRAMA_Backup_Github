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

namespace RIS.DataAccess.Delete
{
	public class RISExamresulttemplateDeleteData : DataAccessBase 
	{
		private RISExamresulttemplate	_risexamresulttemplate;
		private RISExamresulttemplateDeleteDataParameters param;
		public  RISExamresulttemplateDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTTEMPLATE_Delete.ToString();
            _risexamresulttemplate = new RISExamresulttemplate();
		}
		public  RISExamresulttemplate	RISExamresulttemplate
		{
			get{return _risexamresulttemplate;}
			set{_risexamresulttemplate=value;}
		}
		public bool Delete()
		{
			param= new RISExamresulttemplateDeleteDataParameters(RISExamresulttemplate);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		
	}
	public class RISExamresulttemplateDeleteDataParameters 
	{
		private RISExamresulttemplate _risexamresulttemplate;
		private SqlParameter[] _parameters;
		public RISExamresulttemplateDeleteDataParameters(RISExamresulttemplate risexamresulttemplate)
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
			SqlParameter[] parameters ={ 			
                new SqlParameter("@TEMPLATE_ID",RISExamresulttemplate.TEMPLATE_ID)
			};
			_parameters = parameters;
		}
	}
}

