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

namespace RIS.DataAccess.Select
{
	public class RISExamresultseveritySelectData : DataAccessBase 
	{
		private RISExamresultseverity	_risexamresultseverity;
		private RISExamresultseveritySelectDataParameters	_risexamresultseverityinsertdataparameters;
		public  RISExamresultseveritySelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTSEVERITY_Select.ToString();
		}
		public  RISExamresultseverity	RISExamresultseverity
		{
			get{return _risexamresultseverity;}
			set{_risexamresultseverity=value;}
		}
		public DataSet GetData()
		{
			_risexamresultseverityinsertdataparameters = new RISExamresultseveritySelectDataParameters(RISExamresultseverity);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_risexamresultseverityinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class RISExamresultseveritySelectDataParameters 
	{
		private RISExamresultseverity _risexamresultseverity;
		private SqlParameter[] _parameters;
		public RISExamresultseveritySelectDataParameters(RISExamresultseverity risexamresultseverity)
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
//,new SqlParameter("@SEVERITY_UID",RISExamresultseverity.SEVERITY_UID)
//,new SqlParameter("@SEVERITY_NAME",RISExamresultseverity.SEVERITY_NAME)
//,new SqlParameter("@SEVERITY_DESC",RISExamresultseverity.SEVERITY_DESC)
//,new SqlParameter("@ORG_ID",RISExamresultseverity.ORG_ID)
			
//,new SqlParameter("@CREATED_BY",RISExamresultseverity.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamresultseverity.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISExamresultseverity.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamresultseverity.LAST_MODIFIED_ON)
//,
                new SqlParameter("@UNIT_ID",RISExamresultseverity.UNIT_ID)
			};
            _parameters = parameters;
		}
	}
}

