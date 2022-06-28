using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class XrayAndRISScheduleSelectSummary : DataAccessBase
    {
        public XrayAndRISScheduleSelectSummary()
        {
            this.StoredProcedureName = StoredProcedure.Prc_XRAY_SCHEDULE_GetSummary;
        }

        public DataSet GetData(int regId, string HN, int id, int examId, int mode, int orgId)
        {
            this.ParameterList = new DbParameter[]{
                this.Parameter("@ID", id),
                this.Parameter("@REG_ID", regId),
                this.Parameter("@HN", HN),
                this.Parameter("@EXAM_ID", examId),
                this.Parameter("@MODE", mode),
                this.Parameter("@ORG_ID", orgId)
            };
            return this.ExecuteDataSet();
        }
    }
}
