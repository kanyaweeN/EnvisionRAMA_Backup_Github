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

namespace RIS.DataAccess.Delete
{
	public class RISModalityclinictypeDeleteData : DataAccessBase 
	{
		private RISModalityclinictype	_rismodalityclinictype;
		private RISModalityclinictypeDeleteDataParameters param;
		public  RISModalityclinictypeDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYCLINICTYPE_Delete.ToString();
		}
		public  RISModalityclinictype	RISModalityclinictype
		{
			get{return _rismodalityclinictype;}
			set{_rismodalityclinictype=value;}
		}
		public bool Delete()
		{
			param= new RISModalityclinictypeDeleteDataParameters(RISModalityclinictype);
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
				param= new RISModalityclinictypeDeleteDataParameters(RISModalityclinictype);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Delete();
			return true;
		}
	}
	public class RISModalityclinictypeDeleteDataParameters 
	{
		private RISModalityclinictype _rismodalityclinictype;
		private SqlParameter[] _parameters;
		public RISModalityclinictypeDeleteDataParameters(RISModalityclinictype rismodalityclinictype)
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
                new SqlParameter("@MODALITY_CLINICTYPE_ID",RISModalityclinictype.MODALITY_CLINICTYPE_ID)
			};
			_parameters = parameters;
		}
	}
}

 