//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/02/2552 09:05:20
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
	public class RISScheduleDeleteData : DataAccessBase 
	{
		private RISSchedule	_risschedule;
		private RISScheduleDeleteDataParameters param;
		public  RISScheduleDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_Delete.ToString();
		}
		public  RISSchedule	RISSchedule
		{
			get{return _risschedule;}
			set{_risschedule=value;}
		}
		public bool Delete()
		{
			param= new RISScheduleDeleteDataParameters(RISSchedule);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		
	}
	public class RISScheduleDeleteDataParameters 
	{
		private RISSchedule _risschedule;
		private SqlParameter[] _parameters;
		public RISScheduleDeleteDataParameters(RISSchedule risschedule)
		{
			RISSchedule=risschedule;
			Build();
		}
		public  RISSchedule	RISSchedule
		{
			get{return _risschedule;}
			set{_risschedule=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
                new SqlParameter("@SCHEDULE_ID",RISSchedule.SCHEDULE_ID),
                new SqlParameter("@REASON",RISSchedule.REASON_CHANGE),
                new SqlParameter("@LAST_MODIFIED_BY",RISSchedule.LAST_MODIFIED_BY)
			};
			_parameters = parameters;
		}
	}
}

