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

namespace RIS.DataAccess.Update
{
	public class MISLesiontypeUpdateData : DataAccessBase 
	{
		private MISLesiontype	_mislesiontype;
		private MISLesiontypeUpdateDataParameters param;
		public  MISLesiontypeUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_LESIONTYPE_Update.ToString();
		}
		public  MISLesiontype	MISLesiontype
		{
			get{return _mislesiontype;}
			set{_mislesiontype=value;}
		}
		public bool Update()
		{
			param= new MISLesiontypeUpdateDataParameters(MISLesiontype);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		public bool Update(bool flag,bool autocommit) 
		{
			if (flag)
			{
				DataAccess.DataAccessBase.BeginTransaction();
				SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
				param= new MISLesiontypeUpdateDataParameters(MISLesiontype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Update();
			return true;
		}
	}
	public class MISLesiontypeUpdateDataParameters 
	{
		private MISLesiontype _mislesiontype;
		private SqlParameter[] _parameters;
		public MISLesiontypeUpdateDataParameters(MISLesiontype mislesiontype)
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
//new SqlParameter("@LESION_TYPE_UID",MISLesiontype.LESION_TYPE_UID)
//,new SqlParameter("@LESION_TYPE_DESC",MISLesiontype.LESION_TYPE_DESC)
//,new SqlParameter("@ORG_ID",MISLesiontype.ORG_ID)
//,new SqlParameter("@CREATED_BY",MISLesiontype.CREATED_BY)
//,new SqlParameter("@CREATED_ON",MISLesiontype.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",MISLesiontype.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",MISLesiontype.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

