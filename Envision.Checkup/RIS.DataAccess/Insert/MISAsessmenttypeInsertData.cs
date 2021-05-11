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

namespace RIS.DataAccess.Insert
{
	public class MISAsessmenttypeInsertData : DataAccessBase 
	{
		private MISAsessmenttype	_misasessmenttype;
		private MISAsessmenttypeInsertDataParameters	param;
		public  MISAsessmenttypeInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_ASESSMENTTYPE_Insert.ToString();
		}
		public  MISAsessmenttype	MISAsessmenttype
		{
			get{return _misasessmenttype;}
			set{_misasessmenttype=value;}
		}
		public bool Add()
		{
			param= new MISAsessmenttypeInsertDataParameters(MISAsessmenttype);
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
				param= new MISAsessmenttypeInsertDataParameters(MISAsessmenttype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Add();
			return true;
		}
	}
	public class MISAsessmenttypeInsertDataParameters 
	{
		private MISAsessmenttype _misasessmenttype;
		private SqlParameter[] _parameters;
		public MISAsessmenttypeInsertDataParameters(MISAsessmenttype misasessmenttype)
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
//new SqlParameter("@ASESSMENT_TYPE_UID",MISAsessmenttype.ASESSMENT_TYPE_UID)
//,new SqlParameter("@ASESSMENT_TYPE_DESC",MISAsessmenttype.ASESSMENT_TYPE_DESC)
//,new SqlParameter("@ORG_ID",MISAsessmenttype.ORG_ID)
//,new SqlParameter("@CREATED_BY",MISAsessmenttype.CREATED_BY)
//,new SqlParameter("@CREATED_ON",MISAsessmenttype.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",MISAsessmenttype.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",MISAsessmenttype.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

