using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RIS_COMMENTSONPATIENTDTL_INSERT : DataAccessBase
    {
        public RIS_COMMENTSONPATIENTDTL RIS_COMMENTSONPATIENTDTL { get; set; }
        public RIS_COMMENTSONPATIENTDTL_INSERT()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTONPATIENTDTL_INSERT;
        }
        public void InsertDetailComment()
        {
            ParameterList = BuildCommentParameters();
            this.ExecuteNonQuery();
        }
        public void InsertDetailComment(DbTransaction Trans)
        {
            Transaction = Trans;
            ParameterList = BuildCommentParameters();
            this.ExecuteNonQuery();
        }
        public DbParameter[] BuildCommentParameters()
        {
            DbParameter pCommentTo = null;
            if (RIS_COMMENTSONPATIENTDTL.COMMENT_TO == 0)
                pCommentTo = Parameter("@COMMENT_TO", DBNull.Value);
            else
                pCommentTo = Parameter("@COMMENT_TO", RIS_COMMENTSONPATIENTDTL.COMMENT_TO);

            //exam Id
            DbParameter cExamId = null;
            if (RIS_COMMENTSONPATIENTDTL.EXAM_ID == 0)
                cExamId = Parameter("@EXAM_ID", DBNull.Value);
            else
                cExamId = Parameter("@EXAM_ID", RIS_COMMENTSONPATIENTDTL.EXAM_ID);

            //last modified on
            DbParameter pLastmodifyOn = null;
            if (RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_ON == DateTime.MinValue)
                pLastmodifyOn = Parameter("@LAST_MODIFIED_ON", DBNull.Value);
            else
                pLastmodifyOn = Parameter("@LAST_MODIFIED_ON", RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_ON);
            //created on
            DbParameter pCreatedOn = null;
            if (RIS_COMMENTSONPATIENTDTL.CREATED_ON == DateTime.MinValue)
                pCreatedOn = Parameter("@CREATED_ON", DBNull.Value);
            else
                pCreatedOn = Parameter("@CREATED_ON", RIS_COMMENTSONPATIENTDTL.CREATED_ON);
            //ack on
            DbParameter pAckOn = null;
            if (RIS_COMMENTSONPATIENTDTL.ACK_ON == DateTime.MinValue)
                pAckOn = Parameter("@ACK_ON", DBNull.Value);
            else
                pAckOn = Parameter("@ACK_ON", RIS_COMMENTSONPATIENTDTL.ACK_ON);

            DbParameter pRecipient = null;
            if (RIS_COMMENTSONPATIENTDTL.RECIPIENT_TYPE == string.Empty)
                pRecipient = Parameter("@RECIPIENT_TYPE", DBNull.Value);
            else
                pRecipient = Parameter("@RECIPIENT_TYPE", RIS_COMMENTSONPATIENTDTL.RECIPIENT_TYPE);

            DbParameter[] parameters = {
                                           Parameter("@COMMENT_ID", RIS_COMMENTSONPATIENTDTL.COMMENT_ID),
                                           Parameter("@SL_NO", RIS_COMMENTSONPATIENTDTL.SL_NO),
                                           cExamId,
                                           pCommentTo,
                                           Parameter("@IS_DELETED", RIS_COMMENTSONPATIENTDTL.IS_DELETED),
                                           Parameter("@IS_TRASHED", RIS_COMMENTSONPATIENTDTL.IS_TRASHED),
                                           pAckOn,
                                           Parameter("@ORG_ID", RIS_COMMENTSONPATIENTDTL.ORG_ID),
                                           Parameter("@CREATED_BY", RIS_COMMENTSONPATIENTDTL.CREATED_BY),
                                           pCreatedOn,
                                           Parameter("@LAST_MODIFIED_BY", RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_BY),
                                           pLastmodifyOn,
                                           pRecipient
                                       };
            return parameters;
        }
    }
}
