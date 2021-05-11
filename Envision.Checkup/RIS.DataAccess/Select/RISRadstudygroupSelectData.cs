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

namespace RIS.DataAccess.Select
{
	public class RISRadstudygroupSelectData : DataAccessBase 
	{
		private RISRadstudygroup	_risradstudygroup;
		private RISRadstudygroupSelectDataParameters param;
		public  RISRadstudygroupSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_RADSTUDYGROUP_Select.ToString();
		}
		public  RISRadstudygroup	RISRadstudygroup
		{
			get{return _risradstudygroup;}
			set{_risradstudygroup=value;}
		}
		public DataSet GetData()
		{
			param = new RISRadstudygroupSelectDataParameters(RISRadstudygroup);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISRadstudygroupSelectDataParameters 
	{
		private RISRadstudygroup _risradstudygroup;
		private SqlParameter[] _parameters;
		public RISRadstudygroupSelectDataParameters(RISRadstudygroup risradstudygroup)
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
                new SqlParameter("@RADIOLOGIST_ID",RISRadstudygroup.RADIOLOGIST_ID)
                ,new SqlParameter("@ACCESSION_NO",RISRadstudygroup.ACCESSION_NO)
//,new SqlParameter("@IS_FAVOURITE",RISRadstudygroup.IS_FAVOURITE)
//,new SqlParameter("@IS_TEACHING",RISRadstudygroup.IS_TEACHING)
//,new SqlParameter("@IS_OTHERS",RISRadstudygroup.IS_OTHERS)
			
//,new SqlParameter("@ORG_ID",RISRadstudygroup.ORG_ID)
//,new SqlParameter("@CREATED_BY",RISRadstudygroup.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISRadstudygroup.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISRadstudygroup.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISRadstudygroup.LAST_MODIFIED_ON)
                ,new SqlParameter("@MODE",RISRadstudygroup.MODE)
			};
			_parameters=parameters;
		}
	}
}

