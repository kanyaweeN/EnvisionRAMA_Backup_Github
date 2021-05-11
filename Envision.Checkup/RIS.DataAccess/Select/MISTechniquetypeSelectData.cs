//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
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
	public class MISTechniquetypeSelectData : DataAccessBase 
	{
		private MISTechniquetype	_mistechniquetype;
		private MISTechniquetypeSelectDataParameters param;
		public  MISTechniquetypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_TECHNIQUETYPE_Select.ToString();
		}
		public  MISTechniquetype	MISTechniquetype
		{
			get{return _mistechniquetype;}
			set{_mistechniquetype=value;}
		}
		public DataSet GetData()
		{
			param = new MISTechniquetypeSelectDataParameters(MISTechniquetype);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class MISTechniquetypeSelectDataParameters 
	{
		private MISTechniquetype _mistechniquetype;
		private SqlParameter[] _parameters;
		public MISTechniquetypeSelectDataParameters(MISTechniquetype mistechniquetype)
		{
			MISTechniquetype=mistechniquetype;
			Build();
		}
		public  MISTechniquetype	MISTechniquetype
		{
			get{return _mistechniquetype;}
			set{_mistechniquetype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@TECHNIQUE_TYPE_ID",MISTechniquetype.TECHNIQUE_TYPE_ID)
//,new SqlParameter("@TECHNIQUE_TYPE_UID",MISTechniquetype.TECHNIQUE_TYPE_UID)
//,new SqlParameter("@TECHNIQUE_TYPE_DESC",MISTechniquetype.TECHNIQUE_TYPE_DESC)
//,new SqlParameter("@ORG_ID",MISTechniquetype.ORG_ID)
//,new SqlParameter("@CREATED_BY",MISTechniquetype.CREATED_BY)
			
//,new SqlParameter("@CREATED_ON",MISTechniquetype.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",MISTechniquetype.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",MISTechniquetype.LAST_MODIFIED_ON)
			};
			_parameters=parameters;
		}
	}
}

