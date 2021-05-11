using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RIS_COMMENTONPATIENTDTL_UPDATE : DataAccessBase
    {
        public RIS_COMMENTSONPATIENTDTL RIS_COMMENTSONPATIENTDTL { get; set; }
        public RIS_COMMENTONPATIENTDTL_UPDATE()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTONPATIENTDTL_UPDATE;
        }

        public void UpdateDetail()
        {
            ParameterList = this.BuildPamaters();
            this.ExecuteNonQuery();
        }
        public void UpdateDetail(DbTransaction trans)
        {
            ParameterList = this.BuildPamaters();
            Transaction = trans;
            this.ExecuteNonQuery();
        }
        private DbParameter[] BuildPamaters()
        {
            DbParameter pCommentTo = null;
            if (RIS_COMMENTSONPATIENTDTL.COMMENT_TO == 0)
                pCommentTo = Parameter("@COMMENT_TO", DBNull.Value);
            else
                pCommentTo = Parameter("@COMMENT_TO", RIS_COMMENTSONPATIENTDTL.COMMENT_TO);

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

            DbParameter[] parameters = {
                                           Parameter("@COMMENT_ID", RIS_COMMENTSONPATIENTDTL.COMMENT_ID),
                                           Parameter("@SL_NO", RIS_COMMENTSONPATIENTDTL.SL_NO),
                                           Parameter("@EXAM_ID", RIS_COMMENTSONPATIENTDTL.EXAM_ID),
                                           pCommentTo,
                                           Parameter("@IS_DELETED", RIS_COMMENTSONPATIENTDTL.IS_DELETED),
                                           Parameter("@IS_TRASHED", RIS_COMMENTSONPATIENTDTL.IS_TRASHED),
                                           pAckOn,
                                           Parameter("@ORG_ID", RIS_COMMENTSONPATIENTDTL.ORG_ID),
                                           Parameter("@CREATED_BY", RIS_COMMENTSONPATIENTDTL.CREATED_BY),
                                           pCreatedOn,
                                           Parameter("@LAST_MODIFIED_BY", RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_BY),
                                           pLastmodifyOn
                                       };
            return parameters;
        }
    }
}
