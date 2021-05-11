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

namespace RIS.DataAccess.Delete
{
	public class RISExamresultseverityDeleteData : DataAccessBase 
	{
		private RISExamresultseverity	_risexamresultseverity;
		private RISExamresultseverityInsertDataParameters	_risexamresultseverityinsertdataparameters;
		public  RISExamresultseverityDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTSEVERITY_Delete.ToString();
		}
		public  RISExamresultseverity	RISExamresultseverity
		{
			get{return _risexamresultseverity;}
			set{_risexamresultseverity=value;}
		}
		public void Delete()
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
//new SqlParameter("@SEVERITY_ID",RISExamresultseverity.SEVERITY_ID)
			};
			Parameters = parameters;
		}
	}
}

