using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class RISCommentSystemInsertData : DataAccessBase
    {
        public RIS_COMMENTSYSTEM RIS_COMMENTSYSTEM { get; set; }
        public RISCommentSystemInsertData()
        {
            RIS_COMMENTSYSTEM = new RIS_COMMENTSYSTEM();
        }

        public int AddByOrder()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_Insert;
            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSet();
            int comment_id = 0;
            if(ds.Tables.Count>0)
                if(ds.Tables[0].Rows.Count>0)
                    comment_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return comment_id;
        }
        public int AddBySchedule()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_InsertBySchedule;
            ParameterList = buildParameterForSchedule();
            DataSet ds = ExecuteDataSet();
            int comment_id = 0;
            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                    comment_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return comment_id;
        }
        public int AddByXrayreq()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_InsertByXrayReq;
            ParameterList = buildParameterForXrayreq();
            DataSet ds = ExecuteDataSet();
            int comment_id = 0;
            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                    comment_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return comment_id;
        }


        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@SENDER_ID"	, RIS_COMMENTSYSTEM.SENDER_ID ) ,
                Parameter( "@MSG_TEXT"	, RIS_COMMENTSYSTEM.MSG_TEXT ) ,
                Parameter( "@MSG_STATUS"	, RIS_COMMENTSYSTEM.MSG_STATUS ) ,
                Parameter( "@ACCESSION_NO"	, RIS_COMMENTSYSTEM.ACCESSION_NO ) ,
                Parameter( "@ORDER_ID"	, RIS_COMMENTSYSTEM.ORDER_ID ) ,
                Parameter( "@EXAM_ID"	, RIS_COMMENTSYSTEM.EXAM_ID ) ,
                Parameter( "@SCHEDULE_ID"	, RIS_COMMENTSYSTEM.SCHEDULE_ID ) ,
            };
            return parameters;
        }

        private DbParameter[] buildParameterForSchedule()
        {
            DbParameter[] parameters ={
                Parameter( "@SENDER_ID"	, RIS_COMMENTSYSTEM.SENDER_ID ) ,
                Parameter( "@MSG_TEXT"	, RIS_COMMENTSYSTEM.MSG_TEXT ) ,
                Parameter( "@MSG_STATUS"	, RIS_COMMENTSYSTEM.MSG_STATUS ) ,
                Parameter( "@SCHEDULE_ID"	, RIS_COMMENTSYSTEM.SCHEDULE_ID ) ,
                Parameter( "@EXAM_ID"	, RIS_COMMENTSYSTEM.EXAM_ID ) ,
            };
            return parameters;
        }
        private DbParameter[] buildParameterForXrayreq()
        {
            DbParameter[] parameters ={
                Parameter( "@SENDER_ID"	, RIS_COMMENTSYSTEM.SENDER_ID ) ,
                Parameter( "@MSG_TEXT"	, RIS_COMMENTSYSTEM.MSG_TEXT ) ,
                Parameter( "@MSG_STATUS"	, RIS_COMMENTSYSTEM.MSG_STATUS ) ,
                Parameter( "@EXAM_ID"	, RIS_COMMENTSYSTEM.EXAM_ID ) ,
                Parameter( "@XRAYREQ_ID"	, RIS_COMMENTSYSTEM.XRAYREQ_ID ) ,
            };
            return parameters;
        }
    }
}
