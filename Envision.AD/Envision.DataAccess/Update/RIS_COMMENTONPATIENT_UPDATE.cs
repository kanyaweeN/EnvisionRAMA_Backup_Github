using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RIS_COMMENTONPATIENT_UPDATE : DataAccessBase
    {
        public RIS_COMMENTSONPATIENT RIS_COMMENTSONPATIENT { get; set; }
        public RIS_COMMENTONPATIENT_UPDATE()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTONPATIENT_UPDATE;
        }
        public void UpdateMaster()
        {
            ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }
        public void UpdateMaster(DbTransaction Trans)
        {
            Transaction = Trans;
            ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }
        public DbParameter[] BuildParameters()
        {
            DbParameter pOrderId = null;
            if (RIS_COMMENTSONPATIENT.ORDER_ID == 0)
                pOrderId = Parameter("@ORDER_ID", DBNull.Value);
            else
                pOrderId = Parameter("@ORDER_ID", RIS_COMMENTSONPATIENT.ORDER_ID);
            //schedule Id
            DbParameter pScheduleId = null;
            if (RIS_COMMENTSONPATIENT.SCHEDULE_ID == 0)
                pScheduleId = Parameter("@SCHEDULE_ID", DBNull.Value);
            else
                pScheduleId = Parameter("@SCHEDULE_ID", RIS_COMMENTSONPATIENT.SCHEDULE_ID);
            //Last modified on
            DbParameter pLastModifiedOn = null;
            if (RIS_COMMENTSONPATIENT.LAST_MODIFIED_ON == DateTime.MinValue)
                pLastModifiedOn = Parameter("@LAST_MODIFIED_ON", DBNull.Value);
            else
                pLastModifiedOn = Parameter("@LAST_MODIFIED_ON", RIS_COMMENTSONPATIENT.LAST_MODIFIED_ON);
            //Parent id
            DbParameter pParentId = null;
            if (RIS_COMMENTSONPATIENT.PARENT_ID == 0)
                pParentId = Parameter("@PARENT_ID", DBNull.Value);
            else
                pParentId = Parameter("@PARENT_ID", RIS_COMMENTSONPATIENT.PARENT_ID);

            DbParameter[] parameters = {
                                           Parameter("@COMMENT_ID", RIS_COMMENTSONPATIENT.COMMENT_ID),
                                           pParentId,
                                           pScheduleId,
                                           pOrderId,
                                           Parameter("@COMMENT_SUBJECT", RIS_COMMENTSONPATIENT.COMMENT_SUBJECT),
                                           Parameter("@COMMENT_BODY", RIS_COMMENTSONPATIENT.COMMENT_BODY),
                                           Parameter("@COMMENT_STATUS", RIS_COMMENTSONPATIENT.COMMENT_STATUS),
                                           Parameter("@COMMENT_PRIORITY", RIS_COMMENTSONPATIENT.COMMENT_PRIORITY),
                                           Parameter("@LAST_MODIFIED_BY", RIS_COMMENTSONPATIENT.LAST_MODIFIED_BY),
                                           pLastModifiedOn
                                       };
            return parameters;
        }
    }
}
