using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISScheduleDefaultModalityInsertData : DataAccessBase
    {
        public RIS_SCHEDULEDEFAULTMODALITY RIS_SCHEDULEDEFAULTMODALITY { get; set; }

        public RISScheduleDefaultModalityInsertData() {
            RIS_SCHEDULEDEFAULTMODALITY = new RIS_SCHEDULEDEFAULTMODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULEDEFAULTMODALITY_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@SCH_DEF_DEST_ID",RIS_SCHEDULEDEFAULTMODALITY.SCH_DEF_DEST_ID),
                                            Parameter("@MODALITY_ID",RIS_SCHEDULEDEFAULTMODALITY.MODALITY_ID),
                                            Parameter("@ORG_ID",RIS_SCHEDULEDEFAULTMODALITY.ORG_ID),
                                            Parameter("@CREATED_BY",RIS_SCHEDULEDEFAULTMODALITY.CREATED_BY)
                                      };
            return parameters;
        }
    }
}
