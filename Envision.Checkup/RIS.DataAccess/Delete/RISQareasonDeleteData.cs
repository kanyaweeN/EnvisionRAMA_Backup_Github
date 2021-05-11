//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    20/05/2009 04:53:30
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISQareasonDeleteData : DataAccessBase 
	{
		private RISQareason	_risqareason;
		private RISQareasonDeleteDataParameters param;
		public  RISQareasonDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_QAREASON_Delete.ToString();
		}
		public  RISQareason	RISQareason
		{
			get{return _risqareason;}
			set{_risqareason=value;}
		}
		public bool Delete()
		{
			param= new RISQareasonDeleteDataParameters(RISQareason);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		public bool Delete(bool flag,bool autocommit) 
		{
			if (flag)
			{
				DataAccess.DataAccessBase.BeginTransaction();
				SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
				param= new RISQareasonDeleteDataParameters(RISQareason);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class RISQareasonDeleteDataParameters 
	{
		private RISQareason _risqareason;
		private SqlParameter[] _parameters;
		public RISQareasonDeleteDataParameters(RISQareason risqareason)
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
			};
            _parameters = parameters;
        }
	}
}

