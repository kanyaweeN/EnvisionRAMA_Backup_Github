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

namespace RIS.DataAccess.Insert
{
	public class RISUserorgmapInsertData : DataAccessBase 
	{
		private RISUserorgmap	_risuserorgmap;
		private RISUserorgmapInsertDataParameters	param;
		public  RISUserorgmapInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_USERORGMAP_Insert.ToString();
		}
		public  RISUserorgmap	RISUserorgmap
		{
			get{return _risuserorgmap;}
			set{_risuserorgmap=value;}
		}
		public bool Add()
		{
			param= new RISUserorgmapInsertDataParameters(RISUserorgmap);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		public bool Add(bool flag,bool autocommit) 
		{
			if (flag)
			{
				DataAccess.DataAccessBase.BeginTransaction();
				SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
				param= new RISUserorgmapInsertDataParameters(RISUserorgmap);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Add();
			return true;
		}
	}
	public class RISUserorgmapInsertDataParameters 
	{
		private RISUserorgmap _risuserorgmap;
		private SqlParameter[] _parameters;
		public RISUserorgmapInsertDataParameters(RISUserorgmap risuserorgmap)
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
                ,new SqlParameter("@ACCESS_ORG_ID",RISUserorgmap.ACCESS_ORG_ID)
                ,new SqlParameter("@UNIT_ID",RISUserorgmap.UNIT_ID==0?null:RISUserorgmap.UNIT_ID)
                ,new SqlParameter("@ORG_ID",RISUserorgmap.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISUserorgmap.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISUserorgmap.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISUserorgmap.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISUserorgmap.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

