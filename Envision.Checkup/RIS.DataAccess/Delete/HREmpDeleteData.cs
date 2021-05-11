//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    18/06/2009 04:37:11
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
	public class HREmpDeleteData : DataAccessBase 
	{
		private HREmp	_hremp;
		private HREmpDeleteDataParameters param;
		public  HREmpDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_HR_EMP_Delete.ToString();
		}
		public  HREmp	HREmp
		{
			get{return _hremp;}
			set{_hremp=value;}
		}
		public bool Delete()
		{
			param= new HREmpDeleteDataParameters(HREmp);
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
				param= new HREmpDeleteDataParameters(HREmp);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class HREmpDeleteDataParameters 
	{
		private HREmp _hremp;
		private SqlParameter[] _parameters;
		public HREmpDeleteDataParameters(HREmp hremp)
		{
			HREmp=hremp;
			Build();
		}
		public  HREmp	HREmp
		{
			get{return _hremp;}
			set{_hremp=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
                new SqlParameter("@EMP_ID",HREmp.EMP_ID)
			};
			_parameters = parameters;
		}
	}
}

