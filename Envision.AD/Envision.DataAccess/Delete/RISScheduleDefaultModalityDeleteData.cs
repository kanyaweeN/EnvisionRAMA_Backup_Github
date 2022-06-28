using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RISScheduleDefaultModalityDeleteData : DataAccessBase
    {
        public RIS_SCHEDULEDEFAULTMODALITY RIS_SCHEDULEDEFAULTMODALITY { get; set; }

        public RISScheduleDefaultModalityDeleteData() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULEDEFAULTMODALITY_Delete;
            RIS_SCHEDULEDEFAULTMODALITY = new RIS_SCHEDULEDEFAULTMODALITY();
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@SCH_DEF_DEST_ID",RIS_SCHEDULEDEFAULTMODALITY.SCH_DEF_DEST_ID),
                                      };
            return parameters;
        }
    }
}
