using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RIS_SCHEDULEDeleteData : DataAccessBase
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }

        public RIS_SCHEDULEDeleteData()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Delete;
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Delete2;
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
                                           Parameter("@LAST_MODIFIED_BY"  ,RIS_SCHEDULE.LAST_MODIFIED_BY) ,
                                           Parameter("@HN"  ,RIS_SCHEDULE.HN) ,
                                       };
            return parameters;
        }
    }
	
}
