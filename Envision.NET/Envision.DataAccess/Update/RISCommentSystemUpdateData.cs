using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update 
{
    public class RISCommentSystemUpdateData : DataAccessBase
    {
        public RIS_COMMENTSYSTEM RIS_COMMENTSYSTEM { get; set; }

        public RISCommentSystemUpdateData()
        {
            RIS_COMMENTSYSTEM = new RIS_COMMENTSYSTEM();
        }

        public void UpdateCompletedBySchedule()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_UpdateCompletedBySchedule;
            ParameterList = buildParameterCompletedBySchedule();
            ExecuteNonQuery();

        }
        public void UpdateCompletedByXrayreq()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_UpdateCompletedByXrayReq;
            ParameterList = buildParameterCompletedByXrayreq();
            ExecuteNonQuery();

        }
        public void UpdateCommentStatus()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_UpdateStatus;
            ParameterList = buildParameterCommentsystemStatus();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterCompletedBySchedule()
        {
            DbParameter[] parameters ={
                Parameter( "@ACCESSION_NO"         ,   RIS_COMMENTSYSTEM.ACCESSION_NO  ),
                Parameter( "@SCHEDULE_ID"        ,   RIS_COMMENTSYSTEM.SCHEDULE_ID  ),
                Parameter( "@ORDER_ID"        ,   RIS_COMMENTSYSTEM.ORDER_ID  ),
                 Parameter( "@EXAM_ID"        ,   RIS_COMMENTSYSTEM.EXAM_ID  ),
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterCompletedByXrayreq()
        {
            DbParameter[] parameters ={
                Parameter( "@ACCESSION_NO"         ,   RIS_COMMENTSYSTEM.ACCESSION_NO  ),
                Parameter( "@XRAYREQ_ID"        ,   RIS_COMMENTSYSTEM.XRAYREQ_ID  ),
                Parameter( "@ORDER_ID"        ,   RIS_COMMENTSYSTEM.ORDER_ID  ),
                 Parameter( "@EXAM_ID"        ,   RIS_COMMENTSYSTEM.EXAM_ID  ),
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterCommentsystemStatus()
        {
            DbParameter[] parameters ={
                Parameter( "@COMMENT_ID"         ,   RIS_COMMENTSYSTEM.COMMENT_ID  ),
                Parameter( "@MSG_STATUS"        ,   RIS_COMMENTSYSTEM.MSG_STATUS  ),
                Parameter( "@LAST_MODIFIED_BY"  ,   RIS_COMMENTSYSTEM.LAST_MODIFIED_BY  ),
                                      };
            return parameters;
        }
    }
}
