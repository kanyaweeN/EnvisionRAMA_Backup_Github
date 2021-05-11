//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:23
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
	public class MISAsessmenttypeDeleteData : DataAccessBase 
	{
		private MISAsessmenttype	_misasessmenttype;
		private MISAsessmenttypeDeleteDataParameters param;
		public  MISAsessmenttypeDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_ASESSMENTTYPE_Delete.ToString();
		}
		public  MISAsessmenttype	MISAsessmenttype
		{
			get{return _misasessmenttype;}
			set{_misasessmenttype=value;}
		}
		public bool Delete()
		{
			param= new MISAsessmenttypeDeleteDataParameters(MISAsessmenttype);
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
				param= new MISAsessmenttypeDeleteDataParameters(MISAsessmenttype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class MISAsessmenttypeDeleteDataParameters 
	{
		private MISAsessmenttype _misasessmenttype;
		private SqlParameter[] _parameters;
		public MISAsessmenttypeDeleteDataParameters(MISAsessmenttype misasessmenttype)
		{
			MISAsessmenttype=misasessmenttype;
			Build();
		}
		public  MISAsessmenttype	MISAsessmenttype
		{
			get{return _misasessmenttype;}
			set{_misasessmenttype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
//new SqlParameter("@ASESSMENT_TYPE_ID",MISAsessmenttype.ASESSMENT_TYPE_ID)
			};
			_parameters = parameters;
		}
	}
}

