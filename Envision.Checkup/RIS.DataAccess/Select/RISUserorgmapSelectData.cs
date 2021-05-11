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

namespace RIS.DataAccess.Select
{
	public class RISUserorgmapSelectData : DataAccessBase 
	{
		private RISUserorgmap	_risuserorgmap;
		private RISUserorgmapSelectDataParameters param;
		public  RISUserorgmapSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_USERORGMAP_Select.ToString();
		}
		public  RISUserorgmap	RISUserorgmap
		{
			get{return _risuserorgmap;}
			set{_risuserorgmap=value;}
		}
		public DataSet GetData()
		{
			param = new RISUserorgmapSelectDataParameters(RISUserorgmap);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISUserorgmapSelectDataParameters 
	{
		private RISUserorgmap _risuserorgmap;
		private SqlParameter[] _parameters;
		public RISUserorgmapSelectDataParameters(RISUserorgmap risuserorgmap)
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
//,new SqlParameter("@ORG_ID",RISUserorgmap.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISUserorgmap.CREATED_BY)
			
//,new SqlParameter("@CREATED_ON",RISUserorgmap.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISUserorgmap.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISUserorgmap.LAST_MODIFIED_ON)
                ,new SqlParameter("@MODE",RISUserorgmap.MODE)
			};
			_parameters=parameters;
		}
	}
}