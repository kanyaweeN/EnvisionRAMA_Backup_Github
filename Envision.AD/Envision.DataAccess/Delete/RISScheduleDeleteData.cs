using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_SCHEDULEDeleteData : DataAccessBase 
	{
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }

        public RIS_SCHEDULEDeleteData()
		{
            RIS_SCHEDULE = new RIS_SCHEDULE();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Delete;
		}
		
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@SCHEDULE_ID"  ,RIS_SCHEDULE.SCHEDULE_ID) ,
                                           Parameter("@REASON"  ,RIS_SCHEDULE.REASON) ,
                                           Parameter("@LAST_MODIFIED_BY"  ,RIS_SCHEDULE.LAST_MODIFIED_BY) 
                                       };
            return parameters;
        }
        public bool InvokeReservation()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_RESERVATION_Delete;
            ParameterList = buildParameterReservation();
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameterReservation()
        {
            DbParameter[] parameters = { 
                                           Parameter("@SCHEDULE_ID"  ,RIS_SCHEDULE.SCHEDULE_ID) ,
                                       };
            return parameters;
        }
	}
	
}

