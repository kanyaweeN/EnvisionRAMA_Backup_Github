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
	public class RISModalityexamDeleteData : DataAccessBase 
	{
		private RISModalityexam	_rismodalityexam;
		private RISModalityexamInsertDataParameters	_rismodalityexaminsertdataparameters;
		public  RISModalityexamDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_Delete.ToString();
		}
		public  RISModalityexam	RISModalityexam
		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public void Delete()
		{
			_rismodalityexaminsertdataparameters = new RISModalityexamInsertDataParameters(RISModalityexam);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rismodalityexaminsertdataparameters.Parameters);
		}
	}
	public class RISModalityexamInsertDataParameters 
	{
		private RISModalityexam _rismodalityexam;
		private SqlParameter[] _parameters;
		public RISModalityexamInsertDataParameters(RISModalityexam rismodalityexam)
		{
			RISModalityexam=rismodalityexam;
			Build();
		}
		public  RISModalityexam	RISModalityexam
		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 
                new SqlParameter("@MODALITY_EXAM_ID",RISModalityexam.MODALITY_EXAM_ID)};
			Parameters = parameters;
		}
	}
}

