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

namespace RIS.DataAccess.Select
{
	public class RISExamtransferlogSelectData : DataAccessBase 
	{
		private RISExamtransferlog	_risexamtransferlog;
		private RISExamtransferlogInsertDataParameters	_risexamtransferloginsertdataparameters;
		public  RISExamtransferlogSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMTRANSFERLOG_Select.ToString();
		}
		public  RISExamtransferlog	RISExamtransferlog
		{
			get{return _risexamtransferlog;}
			set{_risexamtransferlog=value;}
		}
		public DataSet GetData()
		{
			_risexamtransferloginsertdataparameters = new RISExamtransferlogInsertDataParameters(RISExamtransferlog);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_risexamtransferloginsertdataparameters.Parameters);
			return ds;
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
//,new SqlParameter("@FROM_RAD",RISExamtransferlog.FROM_RAD)
//,new SqlParameter("@TO_RAD",RISExamtransferlog.TO_RAD)
//,new SqlParameter("@STATUS",RISExamtransferlog.STATUS)
			
//,new SqlParameter("@ORG_ID",RISExamtransferlog.ORG_ID)
new SqlParameter("@USER_ID",RISExamtransferlog.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamtransferlog.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISExamtransferlog.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamtransferlog.LAST_MODIFIED_ON)
			};
            Parameters = parameters;
		}
	}
}

