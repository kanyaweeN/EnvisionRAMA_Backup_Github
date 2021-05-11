//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/02/2009 11:11:57
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
	public class RISUserorgmapDeleteData : DataAccessBase 
	{
		private RISUserorgmap	_risuserorgmap;
		private RISUserorgmapDeleteDataParameters param;
		public  RISUserorgmapDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_USERORGMAP_Delete.ToString();
		}
		public  RISUserorgmap	RISUserorgmap
		{
			get{return _risuserorgmap;}
			set{_risuserorgmap=value;}
		}
		public bool Delete()
		{
			param= new RISUserorgmapDeleteDataParameters(RISUserorgmap);
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
				param= new RISUserorgmapDeleteDataParameters(RISUserorgmap);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class RISUserorgmapDeleteDataParameters 
	{
		private RISUserorgmap _risuserorgmap;
		private SqlParameter[] _parameters;
		public RISUserorgmapDeleteDataParameters(RISUserorgmap risuserorgmap)
		{
			RISUserorgmap=risuserorgmap;
			Build();
		}
		public  RISUserorgmap	RISUserorgmap
		{
			get{return _risuserorgmap;}
			set{_risuserorgmap=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
                new SqlParameter("@EMP_ID",RISUserorgmap.EMP_ID)
//,new SqlParameter("@ACCESS_ORG_ID",RISUserorgmap.ACCESS_ORG_ID)
                ,new SqlParameter("@UNIT_ID",RISUserorgmap.UNIT_ID)
			};
			_parameters = parameters;
		}
	}
}

