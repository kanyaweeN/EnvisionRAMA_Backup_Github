//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    12/02/2552 11:47:29
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISExamhospitalDeleteData : DataAccessBase 
	{
		private RISExamhospital	_risexamhospital;
		private RISExamhospitalInsertDataParameters	_risexamhospitalinsertdataparameters;
		public  RISExamhospitalDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMHOSPITAL_Delete.ToString();
		}
		public  RISExamhospital	RISExamhospital
		{
			get{return _risexamhospital;}
			set{_risexamhospital=value;}
		}
		public void Delete()
		{
			_risexamhospitalinsertdataparameters = new RISExamhospitalInsertDataParameters(RISExamhospital);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risexamhospitalinsertdataparameters.Parameters);
		}
	}
	public class RISExamhospitalInsertDataParameters 
	{
		private RISExamhospital _risexamhospital;
		private SqlParameter[] _parameters;
		public RISExamhospitalInsertDataParameters(RISExamhospital risexamhospital)
		{
			RISExamhospital=risexamhospital;
			Build();
		}
		public  RISExamhospital	RISExamhospital
		{
			get{return _risexamhospital;}
			set{_risexamhospital=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@EXAM_ID",RISExamhospital.EXAM_ID)
//,new SqlParameter("@HOS_ID",RISExamhospital.HOS_ID)
			};
			Parameters = parameters;
		}
	}
}

