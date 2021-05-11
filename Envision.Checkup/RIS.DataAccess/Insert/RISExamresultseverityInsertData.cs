//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    21/05/2552 04:00:04
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISExamresultseverityInsertData : DataAccessBase 
	{
		private RISExamresultseverity	_risexamresultseverity;
		private RISExamresultseverityInsertDataParameters	_risexamresultseverityinsertdataparameters;
		public  RISExamresultseverityInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTSEVERITY_Insert.ToString();
		}
		public  RISExamresultseverity	RISExamresultseverity
		{
			get{return _risexamresultseverity;}
			set{_risexamresultseverity=value;}
		}
		public void Add()
		{
			_risexamresultseverityinsertdataparameters = new RISExamresultseverityInsertDataParameters(RISExamresultseverity);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risexamresultseverityinsertdataparameters.Parameters);
		}
	}
	public class RISExamresultseverityInsertDataParameters 
	{
		private RISExamresultseverity _risexamresultseverity;
		private SqlParameter[] _parameters;
		public RISExamresultseverityInsertDataParameters(RISExamresultseverity risexamresultseverity)
		{
			RISExamresultseverity=risexamresultseverity;
			Build();
		}
		public  RISExamresultseverity	RISExamresultseverity
		{
			get{return _risexamresultseverity;}
			set{_risexamresultseverity=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@SEVERITY_UID",RISExamresultseverity.SEVERITY_UID)
//,new SqlParameter("@SEVERITY_NAME",RISExamresultseverity.SEVERITY_NAME)
//,new SqlParameter("@SEVERITY_DESC",RISExamresultseverity.SEVERITY_DESC)
//,new SqlParameter("@ORG_ID",RISExamresultseverity.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISExamresultseverity.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamresultseverity.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISExamresultseverity.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamresultseverity.LAST_MODIFIED_ON)
			};
			Parameters = parameters;
		}
	}
}

