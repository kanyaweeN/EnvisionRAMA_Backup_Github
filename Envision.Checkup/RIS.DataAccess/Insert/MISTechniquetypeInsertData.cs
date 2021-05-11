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

namespace RIS.DataAccess.Insert
{
	public class MISTechniquetypeInsertData : DataAccessBase 
	{
		private MISTechniquetype	_mistechniquetype;
		private MISTechniquetypeInsertDataParameters	param;
		public  MISTechniquetypeInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_TECHNIQUETYPE_Insert.ToString();
		}
		public  MISTechniquetype	MISTechniquetype
		{
			get{return _mistechniquetype;}
			set{_mistechniquetype=value;}
		}
		public bool Add()
		{
			param= new MISTechniquetypeInsertDataParameters(MISTechniquetype);
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
				param= new MISTechniquetypeInsertDataParameters(MISTechniquetype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Add();
			return true;
		}
	}
	public class MISTechniquetypeInsertDataParameters 
	{
		private MISTechniquetype _mistechniquetype;
		private SqlParameter[] _parameters;
		public MISTechniquetypeInsertDataParameters(MISTechniquetype mistechniquetype)
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
//new SqlParameter("@TECHNIQUE_TYPE_UID",MISTechniquetype.TECHNIQUE_TYPE_UID)
//,new SqlParameter("@TECHNIQUE_TYPE_DESC",MISTechniquetype.TECHNIQUE_TYPE_DESC)
//,new SqlParameter("@ORG_ID",MISTechniquetype.ORG_ID)
//,new SqlParameter("@CREATED_BY",MISTechniquetype.CREATED_BY)
//,new SqlParameter("@CREATED_ON",MISTechniquetype.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",MISTechniquetype.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",MISTechniquetype.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

