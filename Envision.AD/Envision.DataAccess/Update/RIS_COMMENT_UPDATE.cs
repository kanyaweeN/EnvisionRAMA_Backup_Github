using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RIS_COMMENT_UPDATE : DataAccessBase
    {
        public int COMMENT_ID { get; set; }
        public int EMP_ID { get; set; }
        public int MODE { get; set; }
        public string Result { get; set; }
        public RIS_COMMENT_UPDATE()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTS_UPDATE;
        }

        public void UpdateComment(DbTransaction trans)
        {
            this.Transaction = trans;
            this.ParameterList = BuildUpdateCommentParameters();
            this.ExecuteNonQuery();
        }

        public void UpdateComment()
        {
            this.ParameterList = BuildUpdateCommentParameters();
            this.ExecuteNonQuery();
        }
        public void UpdateTrashComment()
        {
            this.ParameterList = BuildUpdateCommentParameters();
            DataSet ds = new DataSet();
            ds = this.ExecuteDataSet();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Result = ds.Tables[0].Rows[0]["RESULT"].ToString();
                }
            }
        }

        public DbParameter[] BuildUpdateCommentParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("@COMMENT_ID", COMMENT_ID),
                                           Parameter("@EMP_ID", EMP_ID),
                                           Parameter("@MODE", MODE),
                                       };
            return parameters;
        }
    }
    
}
