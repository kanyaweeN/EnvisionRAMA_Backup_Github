using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class RISSchedulePatientDestinationInsertData : DataAccessBase 
    {
        public RIS_SCHEDULEDEFAULTDESTINATION RIS_SCHEDULEDEFAULTDESTINATION { get; set; }

        public RISSchedulePatientDestinationInsertData() {
            RIS_SCHEDULEDEFAULTDESTINATION = new RIS_SCHEDULEDEFAULTDESTINATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULEDEFAULTDESTINATION_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            DataTable dtt = ExecuteDataTable();
            RIS_SCHEDULEDEFAULTDESTINATION.SCH_DEF_DEST_ID = Convert.ToInt32(dtt.Rows[0][0].ToString());
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@EMP_ID",RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID),
                                            Parameter("@PAT_DEST_ID",RIS_SCHEDULEDEFAULTDESTINATION.PAT_DEST_ID),
                                            Parameter("@ORG_ID",RIS_SCHEDULEDEFAULTDESTINATION.ORG_ID),
                                            Parameter("@CREATED_BY",RIS_SCHEDULEDEFAULTDESTINATION.CREATED_BY)
                                      };
            return parameters;
        }
    }
}
