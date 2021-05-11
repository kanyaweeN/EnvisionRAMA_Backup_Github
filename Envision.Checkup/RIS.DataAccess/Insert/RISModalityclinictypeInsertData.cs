//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/04/2009 08:46:09
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
	public class RISModalityclinictypeInsertData : DataAccessBase 
	{
		private RISModalityclinictype	_rismodalityclinictype;
		private RISModalityclinictypeInsertDataParameters	param;
		public  RISModalityclinictypeInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYCLINICTYPE_Insert.ToString();
		}
		public  RISModalityclinictype	RISModalityclinictype
		{
			get{return _rismodalityclinictype;}
			set{_rismodalityclinictype=value;}
		}
		public bool Add()
		{
			param= new RISModalityclinictypeInsertDataParameters(RISModalityclinictype);
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
				param= new RISModalityclinictypeInsertDataParameters(RISModalityclinictype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Add();
			return true;
		}
	}
	public class RISModalityclinictypeInsertDataParameters 
	{
		private RISModalityclinictype _rismodalityclinictype;
		private SqlParameter[] _parameters;
		public RISModalityclinictypeInsertDataParameters(RISModalityclinictype rismodalityclinictype)
		{
			RISModalityclinictype=rismodalityclinictype;
			Build();
		}
		public  RISModalityclinictype	RISModalityclinictype
		{
			get{return _rismodalityclinictype;}
			set{_rismodalityclinictype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@CLINIC_TYPE_ID",RISModalityclinictype.CLINIC_TYPE_ID)
                ,new SqlParameter("@MODALITY_ID",RISModalityclinictype.MODALITY_ID)
                ,new SqlParameter("@START_DATETIME",RISModalityclinictype.START_DATETIME)
                ,new SqlParameter("@END_DATETIME",RISModalityclinictype.END_DATETIME)
                ,new SqlParameter("@MAX_APP",RISModalityclinictype.MAX_APP)
                ,new SqlParameter("@ORG_ID",RISModalityclinictype.ORG_ID)
                ,new SqlParameter("@CREATED_BY",RISModalityclinictype.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISModalityclinictype.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISModalityclinictype.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISModalityclinictype.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

