//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/05/2552 05:36:57
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
	public class RISInsurancetypeInsertData : DataAccessBase 
	{
		private RISInsurancetype	_risinsurancetype;
		private RISInsurancetypeInsertDataParameters	param;
		public  RISInsurancetypeInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_INSURANCETYPE_Insert.ToString();
		}
		public  RISInsurancetype	RISInsurancetype
		{
			get{return _risinsurancetype;}
			set{_risinsurancetype=value;}
		}
		public bool Add()
		{
			param= new RISInsurancetypeInsertDataParameters(RISInsurancetype);
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
				param= new RISInsurancetypeInsertDataParameters(RISInsurancetype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Add();
			return true;
		}
	}
	public class RISInsurancetypeInsertDataParameters 
	{
		private RISInsurancetype _risinsurancetype;
		private SqlParameter[] _parameters;
		public RISInsurancetypeInsertDataParameters(RISInsurancetype risinsurancetype)
		{
			RISInsurancetype=risinsurancetype;
			Build();
		}
		public  RISInsurancetype	RISInsurancetype
		{
			get{return _risinsurancetype;}
			set{_risinsurancetype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
new SqlParameter("@INSURANCE_TYPE_UID",RISInsurancetype.INSURANCE_TYPE_UID)
,new SqlParameter("@INSURANCE_TYPE_DESC",RISInsurancetype.INSURANCE_TYPE_DESC)
,new SqlParameter("@ORG_ID",RISInsurancetype.ORG_ID)
,new SqlParameter("@CREATED_BY",RISInsurancetype.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISInsurancetype.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISInsurancetype.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISInsurancetype.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

