using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBLEmpScheduleDeleteData : DataAccessBase
    {
        public GBL_EMPSCHEDULE GBL_EMPSCHEDULE { get; set; }

        public GBLEmpScheduleDeleteData() {
            StoredProcedureName = StoredProcedure.GBLEmpSchedule_Delete;
            GBL_EMPSCHEDULE = new GBL_EMPSCHEDULE();
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                        Parameter("@SCHEDULE_ID"		,  GBL_EMPSCHEDULE.SCHEDULE_ID)
                                       };
            return parameters;
        }
    }
}
