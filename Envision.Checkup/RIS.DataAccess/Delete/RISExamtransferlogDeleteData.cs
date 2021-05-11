//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    27/05/2552 03:41:44
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISExamtransferlogDeleteData : DataAccessBase 
	{
		private RISExamtransferlog	_risexamtransferlog;
		private RISExamtransferlogInsertDataParameters	_risexamtransferloginsertdataparameters;
		public  RISExamtransferlogDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMTRANSFERLOG_Delete.ToString();
		}
		public  RISExamtransferlog	RISExamtransferlog
		{
			get{return _risexamtransferlog;}
			set{_risexamtransferlog=value;}
		}
		public void Delete()
		{
			_risexamtransferloginsertdataparameters = new RISExamtransferlogInsertDataParameters(RISExamtransferlog);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risexamtransferloginsertdataparameters.Parameters);
		}
	}
	public class RISExamtransferlogInsertDataParameters 
	{
		private RISExamtransferlog _risexamtransferlog;
		private SqlParameter[] _parameters;
		public RISExamtransferlogInsertDataParameters(RISExamtransferlog risexamtransferlog)
		{
			RISExamtransferlog=risexamtransferlog;
			Build();
		}
		public  RISExamtransferlog	RISExamtransferlog
		{
			get{return _risexamtransferlog;}
			set{_risexamtransferlog=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@ACCESSION_NO",RISExamtransferlog.ACCESSION_NO)
//,new SqlParameter("@SL_NO",RISExamtransferlog.SL_NO)
			};
			Parameters = parameters;
		}
	}
}

