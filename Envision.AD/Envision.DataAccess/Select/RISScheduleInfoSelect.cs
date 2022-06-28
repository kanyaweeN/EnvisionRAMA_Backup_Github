using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISScheduleInfoSelect : DataAccessBase
    {
        public RISScheduleInfoSelect()
        {
            //this.StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_GetScheduleInfo;
            this.StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_GetScheduleInfo2;
        }

        public DataSet GetScheduleInfo(int schedule_id, int org_id)
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@SCHEDULE_ID", schedule_id),
                Parameter("@ORG_ID", org_id),
            };
            return this.ExecuteDataSet();
        }
    }
}
