using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RISSchedulePatientDestinationDeleteData :DataAccessBase
    {
        public RIS_SCHEDULEDEFAULTDESTINATION RIS_SCHEDULEDEFAULTDESTINATION { get; set; }

        public RISSchedulePatientDestinationDeleteData() {
            RIS_SCHEDULEDEFAULTDESTINATION = new RIS_SCHEDULEDEFAULTDESTINATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULEDEFAULTDESTINATION_Delete;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@EMP_ID",RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID),
                                            Parameter("@PAT_DEST_ID",RIS_SCHEDULEDEFAULTDESTINATION.PAT_DEST_ID),
                                      };
            return parameters;
        }
    }
}
