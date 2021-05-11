//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/05/2552 03:39:04
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class RISExamresultlocksUpdateData : DataAccessBase 
	{
		private RISExamresultlocks	_risexamresultlocks;
		private RISExamresultlocksUpdateDataParameters param;
		public  RISExamresultlocksUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULTLOCKS_Update.ToString();
		}
		public  RISExamresultlocks	RISExamresultlocks
		{
			get{return _risexamresultlocks;}
			set{_risexamresultlocks=value;}
		}
		public bool Update()
		{
			param= new RISExamresultlocksUpdateDataParameters(RISExamresultlocks);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		public bool Update(bool flag,bool autocommit)
		{
			if (flag)
			{
				DataAccess.DataAccessBase.BeginTransaction();
				SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
				param= new RISExamresultlocksUpdateDataParameters(RISExamresultlocks);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Update();
			return true;
		}
	}
	public class RISExamresultlocksUpdateDataParameters 
	{
		private RISExamresultlocks _risexamresultlocks;
		private SqlParameter[] _parameters;
		public RISExamresultlocksUpdateDataParameters(RISExamresultlocks risexamresultlocks)
		{
			RISExamresultlocks=risexamresultlocks;
			Build();
		}
		public  RISExamresultlocks	RISExamresultlocks
		{
			get{return _risexamresultlocks;}
			set{_risexamresultlocks=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
new SqlParameter("@ACCESSION_NO",RISExamresultlocks.ACCESSION_NO)
,new SqlParameter("@SL_NO",RISExamresultlocks.SL_NO)
,new SqlParameter("@IS_LOCKED",RISExamresultlocks.IS_LOCKED)
//,new SqlParameter("@WORKING_RAD",RISExamresultlocks.WORKING_RAD)
,new SqlParameter("@UNLOCKED_BY",RISExamresultlocks.UNLOCKED_BY)
//,new SqlParameter("@UNLOCKED_ON",RISExamresultlocks.UNLOCKED_ON)
,new SqlParameter("@ORG_ID",RISExamresultlocks.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISExamresultlocks.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISExamresultlocks.CREATED_ON)
,new SqlParameter("@LAST_MODIFIED_BY",RISExamresultlocks.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISExamresultlocks.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

