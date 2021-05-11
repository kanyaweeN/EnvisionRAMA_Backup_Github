//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    20/05/2009 04:53:29
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
	public class RISQareasonUpdateData : DataAccessBase 
	{
		private RISQareason	_risqareason;
		private RISQareasonUpdateDataParameters param;
		public  RISQareasonUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_QAREASON_Update.ToString();
		}
		public  RISQareason	RISQareason
		{
			get{return _risqareason;}
			set{_risqareason=value;}
		}
		public bool Update()
		{
			param= new RISQareasonUpdateDataParameters(RISQareason);
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
				param= new RISQareasonUpdateDataParameters(RISQareason);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Update();
			return true;
		}
	}
	public class RISQareasonUpdateDataParameters 
	{
		private RISQareason _risqareason;
		private SqlParameter[] _parameters;
		public RISQareasonUpdateDataParameters(RISQareason risqareason)
		{
			RISQareason=risqareason;
			Build();
		}
		public  RISQareason	RISQareason
		{
			get{return _risqareason;}
			set{_risqareason=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@REASON_ID",RISQareason.REASON_ID)
                ,new SqlParameter("@REASON_UID",RISQareason.REASON_UID)
                ,new SqlParameter("@REASON_TEXT",RISQareason.REASON_TEXT)
                ,new SqlParameter("@REASON_ACTION",RISQareason.REASON_ACTION)
                ,new SqlParameter("@ORG_ID",RISQareason.ORG_ID)
                //,new SqlParameter("@CREATED_BY",RISQareason.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISQareason.CREATED_ON)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISQareason.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISQareason.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

