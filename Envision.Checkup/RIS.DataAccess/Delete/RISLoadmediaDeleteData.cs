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
	public class RISLoadmediaDeleteData : DataAccessBase 
	{
		private RISLoadmedia	_risloadmedia;
		private RISLoadmediaDeleteDataParameters param;
		public  RISLoadmediaDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_LOADMEDIA_Delete.ToString();
		}
		public  RISLoadmedia	RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public bool Delete()
		{
			param= new RISLoadmediaDeleteDataParameters(RISLoadmedia);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISLoadmediaDeleteDataParameters 
	{
		private RISLoadmedia _risloadmedia;
		private SqlParameter[] _parameters;
		public RISLoadmediaDeleteDataParameters(RISLoadmedia risloadmedia)
		{
			RISLoadmedia=risloadmedia;
			Build();
		}
		public  RISLoadmedia	RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@LOAD_ID",RISLoadmedia.LOAD_ID)
			};
			_parameters = parameters;
		}
	}
}

