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
	public class MISBiopsyresultDeleteData : DataAccessBase 
	{
		private MISBiopsyresult	_misbiopsyresult;
		private MISBiopsyresultDeleteDataParameters param;
		public  MISBiopsyresultDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_BIOPSYRESULT_Delete.ToString();
		}
		public  MISBiopsyresult	MISBiopsyresult
		{
			get{return _misbiopsyresult;}
			set{_misbiopsyresult=value;}
		}
		public bool Delete()
		{
			param= new MISBiopsyresultDeleteDataParameters(MISBiopsyresult);
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
				param= new MISBiopsyresultDeleteDataParameters(MISBiopsyresult);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class MISBiopsyresultDeleteDataParameters 
	{
		private MISBiopsyresult _misbiopsyresult;
		private SqlParameter[] _parameters;
		public MISBiopsyresultDeleteDataParameters(MISBiopsyresult misbiopsyresult)
		{
			MISBiopsyresult=misbiopsyresult;
			Build();
		}
		public  MISBiopsyresult	MISBiopsyresult
		{
			get{return _misbiopsyresult;}
			set{_misbiopsyresult=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@ACCESSION_NO",MISBiopsyresult.ACCESSION_NO)
			};
			_parameters = parameters;
		}
	}
}

