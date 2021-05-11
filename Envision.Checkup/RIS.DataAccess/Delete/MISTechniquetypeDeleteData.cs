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

namespace RIS.DataAccess.Delete
{
	public class MISTechniquetypeDeleteData : DataAccessBase 
	{
		private MISTechniquetype	_mistechniquetype;
		private MISTechniquetypeDeleteDataParameters param;
		public  MISTechniquetypeDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_TECHNIQUETYPE_Delete.ToString();
		}
		public  MISTechniquetype	MISTechniquetype
		{
			get{return _mistechniquetype;}
			set{_mistechniquetype=value;}
		}
		public bool Delete()
		{
			param= new MISTechniquetypeDeleteDataParameters(MISTechniquetype);
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
				param= new MISTechniquetypeDeleteDataParameters(MISTechniquetype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class MISTechniquetypeDeleteDataParameters 
	{
		private MISTechniquetype _mistechniquetype;
		private SqlParameter[] _parameters;
		public MISTechniquetypeDeleteDataParameters(MISTechniquetype mistechniquetype)
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
			};
			_parameters = parameters;
		}
	}
}

