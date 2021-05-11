//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/04/2009 12:35:35
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
	public class RISRadstudygroupDeleteData : DataAccessBase 
	{
		private RISRadstudygroup	_risradstudygroup;
		private RISRadstudygroupDeleteDataParameters param;
		public  RISRadstudygroupDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_RADSTUDYGROUP_Delete.ToString();
		}
		public  RISRadstudygroup	RISRadstudygroup
		{
			get{return _risradstudygroup;}
			set{_risradstudygroup=value;}
		}
		public bool Delete()
		{
			param= new RISRadstudygroupDeleteDataParameters(RISRadstudygroup);
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
				param= new RISRadstudygroupDeleteDataParameters(RISRadstudygroup);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class RISRadstudygroupDeleteDataParameters 
	{
		private RISRadstudygroup _risradstudygroup;
		private SqlParameter[] _parameters;
		public RISRadstudygroupDeleteDataParameters(RISRadstudygroup risradstudygroup)
		{
			RISRadstudygroup=risradstudygroup;
			Build();
		}
		public  RISRadstudygroup	RISRadstudygroup
		{
			get{return _risradstudygroup;}
			set{_risradstudygroup=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@RADIOLOGIST_ID",RISRadstudygroup.RADIOLOGIST_ID)
//,new SqlParameter("@ACCESSION_NO",RISRadstudygroup.ACCESSION_NO)
			};
			_parameters = parameters;
		}
	}
}

