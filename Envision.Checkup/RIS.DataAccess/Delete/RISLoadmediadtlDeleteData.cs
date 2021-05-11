//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
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
	public class RISLoadmediadtlDeleteData : DataAccessBase 
	{
		private RISLoadmediadtl	_risloadmediadtl;
		private RISLoadmediadtlDeleteDataParameters param;
		public  RISLoadmediadtlDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_LOADMEDIADTL_Delete.ToString();
		}
		public  RISLoadmediadtl	RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public bool Delete()
		{
			param= new RISLoadmediadtlDeleteDataParameters(RISLoadmediadtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
        //public bool Delete(bool flag,bool autocommit) 
        //{
        //    if (flag)
        //    {
        //        DataAccess.DataAccessBase.BeginTransaction();
        //        SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
        //        param= new RISLoadmediadtlDeleteDataParameters(RISLoadmediadtl);
        //        DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
        //        dbhelper.Run(tran,param.Parameters);
        //        if(autocommit) DataAccess.DataAccessBase.Commit();
        //    }
        //    else Delete();
        //    return true;
        //}
	}
	public class RISLoadmediadtlDeleteDataParameters 
	{
		private RISLoadmediadtl _risloadmediadtl;
		private SqlParameter[] _parameters;
		public RISLoadmediadtlDeleteDataParameters(RISLoadmediadtl risloadmediadtl)
		{
			RISLoadmediadtl=risloadmediadtl;
			Build();
		}
		public  RISLoadmediadtl	RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@LOAD_ID",RISLoadmediadtl.LOAD_ID)
,new SqlParameter("@EXAM_ID",RISLoadmediadtl.EXAM_ID)
			};
			_parameters = parameters;
		}
	}
}

