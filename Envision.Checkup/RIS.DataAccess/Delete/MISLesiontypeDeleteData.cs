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
	public class MISLesiontypeDeleteData : DataAccessBase 
	{
		private MISLesiontype	_mislesiontype;
		private MISLesiontypeDeleteDataParameters param;
		public  MISLesiontypeDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_LESIONTYPE_Delete.ToString();
		}
		public  MISLesiontype	MISLesiontype
		{
			get{return _mislesiontype;}
			set{_mislesiontype=value;}
		}
		public bool Delete()
		{
			param= new MISLesiontypeDeleteDataParameters(MISLesiontype);
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
				param= new MISLesiontypeDeleteDataParameters(MISLesiontype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class MISLesiontypeDeleteDataParameters 
	{
		private MISLesiontype _mislesiontype;
		private SqlParameter[] _parameters;
		public MISLesiontypeDeleteDataParameters(MISLesiontype mislesiontype)
		{
			MISLesiontype=mislesiontype;
			Build();
		}
		public  MISLesiontype	MISLesiontype
		{
			get{return _mislesiontype;}
			set{_mislesiontype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@LESION_TYPE_ID",MISLesiontype.LESION_TYPE_ID)
			};
			_parameters = parameters;
		}
	}
}

