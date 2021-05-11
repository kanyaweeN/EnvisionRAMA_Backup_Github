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

namespace RIS.DataAccess.Insert
{
	public class RISExamhospitalInsertData : DataAccessBase 
	{
		private RISExamhospital	_risexamhospital;
		private RISExamhospitalInsertDataParameters	_risexamhospitalinsertdataparameters;
		public  RISExamhospitalInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMHOSPITAL_Insert.ToString();
		}
		public  RISExamhospital	RISExamhospital
		{
			get{return _risexamhospital;}
			set{_risexamhospital=value;}
		}
		public void Add()
		{
			_risexamhospitalinsertdataparameters = new RISExamhospitalInsertDataParameters(RISExamhospital);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risexamhospitalinsertdataparameters.Parameters);
		}
        public void Add(SqlTransaction tran)
        {
            _risexamhospitalinsertdataparameters = new RISExamhospitalInsertDataParameters(RISExamhospital);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _risexamhospitalinsertdataparameters.Parameters);
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
new SqlParameter("@EXAM_ID",RISExamhospital.EXAM_ID)
,new SqlParameter("@HOS_ID",RISExamhospital.HOS_ID)
,new SqlParameter("@UC_RATE",RISExamhospital.UC_RATE)
,new SqlParameter("@CR_RATE",RISExamhospital.CR_RATE)
,new SqlParameter("@LAST_MODIFIED_BY",RISExamhospital.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamhospital.LAST_MODIFIED_ON)
,new SqlParameter("@CREATED_BY",RISExamhospital.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamhospital.CREATED_ON)
			};
			Parameters = parameters;
		}
	}
}

