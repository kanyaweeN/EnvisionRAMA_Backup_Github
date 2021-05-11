//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISExamDeleteData : DataAccessBase 
	{
		private RISExam	_risexam;
		private RISExamInsertDataParameters	_risexaminsertdataparameters;
		public  RISExamDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAM_Delete.ToString();
		}
		public  RISExam	RISExam
		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public void Delete()
		{
			_risexaminsertdataparameters = new RISExamInsertDataParameters(RISExam);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risexaminsertdataparameters.Parameters);
		}
	}
	public class RISExamInsertDataParameters 
	{
		private RISExam _risexam;
		private SqlParameter[] _parameters;
		public RISExamInsertDataParameters(RISExam risexam)
		{
			RISExam=risexam;
			Build();
		}
		public  RISExam	RISExam
		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ new SqlParameter("@EXAM_ID",RISExam.EXAM_ID)};
			Parameters = parameters;
		}
	}
}

