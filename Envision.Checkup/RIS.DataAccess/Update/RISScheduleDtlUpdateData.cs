using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class RISScheduleDtlUpdateData : DataAccessBase
    {
        private RISScheduledtl	_risscheduledtl;
        private RISScheduleDtlUpdateDataParameters param;
        public RISScheduleDtlUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULEDTL_Update.ToString();
		}
        public RISScheduledtl RISScheduledtl
		{
            get { return _risscheduledtl; }
            set { _risscheduledtl = value; }
		}
		public bool Update()
		{
            param = new RISScheduleDtlUpdateDataParameters(RISScheduledtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISScheduleDtlUpdateDataParameters 
	{
		private RISScheduledtl _risscheduledtl;
		private SqlParameter[] _parameters;
        public RISScheduleDtlUpdateDataParameters(RISScheduledtl risscheduledtl)
		{
            RISScheduledtl = risscheduledtl;
			Build();
		}
        public RISScheduledtl RISScheduledtl
		{
            get { return _risscheduledtl; }
            set { _risscheduledtl = value; }
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={
new SqlParameter("@SCHEDULE_ID" ,RISScheduledtl.SCHEDULE_ID)
,new SqlParameter("@MODALITY_ID",RISScheduledtl.MODALITY_ID)
,new SqlParameter("@PAT_STATUS",RISScheduledtl.PAT_STATUS)
                ,new SqlParameter("@Selectcase",RISScheduledtl.SELECTCASE)
			};
			_parameters = parameters;
		}
    }
}
