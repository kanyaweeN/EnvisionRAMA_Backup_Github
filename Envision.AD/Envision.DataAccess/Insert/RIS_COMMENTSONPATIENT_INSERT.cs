using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RIS_COMMENTSONPATIENT_INSERT : DataAccessBase
    {
        public RIS_COMMENTSONPATIENT RIS_COMMENTSONPATIENT { get; set; }
        public RIS_COMMENTSONPATIENT_INSERT()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTONPATIENT_INSERT;
        }
        public void InsertMasterComment()
        {
            ParameterList = this.BuilCommentParameters();
            //this.ExecuteNonQuery();
            DataSet ds = this.ExecuteDataSet();
            RIS_COMMENTSONPATIENT.COMMENT_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["COMMENT_ID"]);
        }
        public void InsertMasterComment(DbTransaction Trans)
        {
            Transaction = Trans;
            ParameterList = this.BuilCommentParameters();
            DataSet ds = new DataSet();
            ds = this.ExecuteDataSet();
            RIS_COMMENTSONPATIENT.COMMENT_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["COMMENT_ID"]);
        }
        public DbParameter[] BuilCommentParameters()
        {
            //Comment Id
            DbParameter cCommentId = Parameter("@COMMENT_ID", RIS_COMMENTSONPATIENT.COMMENT_ID);
            cCommentId.Direction = ParameterDirection.Output;
            //Parent Id
            DbParameter cParentId = null;
            if(RIS_COMMENTSONPATIENT.PARENT_ID == 0)
                cParentId = Parameter("@PARENT_ID", DBNull.Value);
            else
                cParentId = Parameter("@PARENT_ID", RIS_COMMENTSONPATIENT.PARENT_ID);
            //Order Id
            DbParameter cOrderId = null;
            if (RIS_COMMENTSONPATIENT.ORDER_ID == 0)
                cOrderId = Parameter("@ORDER_ID", DBNull.Value);
            else
                cOrderId = Parameter("@ORDER_ID", RIS_COMMENTSONPATIENT.ORDER_ID);

            //schedule Id
            DbParameter cScheduleId = null;
            if (RIS_COMMENTSONPATIENT.SCHEDULE_ID == 0)
                cScheduleId = Parameter("@SCHEDULE_ID", DBNull.Value);
            else
                cScheduleId = Parameter("@SCHEDULE_ID", RIS_COMMENTSONPATIENT.SCHEDULE_ID);
            //last modified on
            DbParameter cLastmodifyOn = null;
            if (RIS_COMMENTSONPATIENT.LAST_MODIFIED_ON == DateTime.MinValue)
                cLastmodifyOn = Parameter("@LAST_MODIFIED_ON", DBNull.Value);
            else
                cLastmodifyOn = Parameter("@LAST_MODIFIED_ON", RIS_COMMENTSONPATIENT.LAST_MODIFIED_ON);
            //created on
            DbParameter cCreatedOn = null;
            if (RIS_COMMENTSONPATIENT.CREATED_ON == DateTime.MinValue)
                cCreatedOn = Parameter("@CREATED_ON", DBNull.Value);
            else
                cCreatedOn = Parameter("@CREATED_ON", RIS_COMMENTSONPATIENT.CREATED_ON);

            DbParameter[] parameters = {
                                           cCommentId,
                                           cParentId,
                                           Parameter("@REG_ID", RIS_COMMENTSONPATIENT.REG_ID),
                                           cScheduleId,
                                           cOrderId,
                                           Parameter("@COMMENT_DT", RIS_COMMENTSONPATIENT.COMMENT_DT),
                                           Parameter("@COMMENT_FROM", RIS_COMMENTSONPATIENT.COMMENT_FROM),
                                           Parameter("@COMMENT_SUBJECT", RIS_COMMENTSONPATIENT.COMMENT_SUBJECT),
                                           Parameter("@COMMENT_BODY", RIS_COMMENTSONPATIENT.COMMENT_BODY),
                                           Parameter("@COMMENT_STATUS", RIS_COMMENTSONPATIENT.COMMENT_STATUS),
                                           Parameter("@COMMENT_PRIORITY", RIS_COMMENTSONPATIENT.COMMENT_PRIORITY),
                                           Parameter("@IS_DELETED", RIS_COMMENTSONPATIENT.IS_DELETED),
                                           Parameter("@ORG_ID", RIS_COMMENTSONPATIENT.ORG_ID),
                                           Parameter("@CREATED_BY", RIS_COMMENTSONPATIENT.CREATED_BY),
                                           cCreatedOn,
                                           Parameter("@LAST_MODIFIED_BY", RIS_COMMENTSONPATIENT.LAST_MODIFIED_BY),
                                           cLastmodifyOn
                                       };
            return parameters;
            
        }
    }
}
