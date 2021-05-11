using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class RISExamConditionUpdateData: DataAccessBase
    {
        public RIS_EXAM RIS_EXAM { get; set; }
        public RISExamConditionUpdateData()
        {
            RIS_EXAM = new RIS_EXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_UpdateCondition;
        }
        public void update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",RIS_EXAM.EXAM_ID),
                Parameter("@CAN_REQONLINE",RIS_EXAM.CAN_REQONLINE),
                Parameter("@NEED_SCHEDULE",RIS_EXAM.NEED_SCHEDULE),
                Parameter("@NEED_APPROVE",RIS_EXAM.NEED_APPROVE),
                Parameter("@VISIBLE_REQONLINE",RIS_EXAM.VISIBLE_REQONLINE),
                Parameter("@REQONL_DISPLAY",RIS_EXAM.REQONL_DISPLAY),
                Parameter("@LAST_MODIFIED_BY",RIS_EXAM.LAST_MODIFIED_BY),
			            };
            return parameters;
        }
    }
}
