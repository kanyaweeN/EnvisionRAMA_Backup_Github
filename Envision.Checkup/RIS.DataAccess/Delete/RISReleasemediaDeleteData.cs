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
	public class RISReleasemediaDeleteData : DataAccessBase 
	{
		private RISReleasemedia	_risreleasemedia;
		private RISReleasemediaDeleteDataParameters param;
		public  RISReleasemediaDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_RELEASEMEDIA_Delete.ToString();
		}
		public  RISReleasemedia	RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public bool Delete()
		{
			param= new RISReleasemediaDeleteDataParameters(RISReleasemedia);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISReleasemediaDeleteDataParameters 
	{
		private RISReleasemedia _risreleasemedia;
		private SqlParameter[] _parameters;
		public RISReleasemediaDeleteDataParameters(RISReleasemedia risreleasemedia)
		{
			RISReleasemedia=risreleasemedia;
			Build();
		}
		public  RISReleasemedia	RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@RELEASE_ID",RISReleasemedia.RELEASE_ID)
			};
			_parameters = parameters;
		}
	}
}

