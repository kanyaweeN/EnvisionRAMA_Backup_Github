//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:16
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
	public class GBLRadexperienceDeleteData : DataAccessBase 
	{
		private GBLRadexperience	_gblradexperience;
		private GBLRadexperienceDeleteDataParameters param;
		public  GBLRadexperienceDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_RADEXPERIENCE_Delete.ToString();
		}
		public  GBLRadexperience	GBLRadexperience
		{
			get{return _gblradexperience;}
			set{_gblradexperience=value;}
		}
		public bool Delete()
		{
			param= new GBLRadexperienceDeleteDataParameters(GBLRadexperience);
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
				param= new GBLRadexperienceDeleteDataParameters(GBLRadexperience);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class GBLRadexperienceDeleteDataParameters 
	{
		private GBLRadexperience _gblradexperience;
		private SqlParameter[] _parameters;
		public GBLRadexperienceDeleteDataParameters(GBLRadexperience gblradexperience)
		{
			GBLRadexperience=gblradexperience;
			Build();
		}
		public  GBLRadexperience	GBLRadexperience
		{
			get{return _gblradexperience;}
			set{_gblradexperience=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@RADIOLOGIST_ID",GBLRadexperience.RADIOLOGIST_ID)
			};
			_parameters = parameters;
		}
	}
}

