using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data;
using Envision.DataAccess.Select;
using Envision.DataAccess.Update;
using System.Data.Common;

namespace Envision.BusinessLogic
{
    public class MessageConversationManagement
    {
        public DbTransaction Transaction { get; set; }
        public RIS_COMMENTSYSTEM RIS_COMMENTSYSTEM { get; set; }
        public RIS_COMMENTSYSTEMDTL RIS_COMMENTSYSTEMDTL { get; set; }


        public MessageConversationManagement()
        {
            RIS_COMMENTSYSTEM = new RIS_COMMENTSYSTEM();
            RIS_COMMENTSYSTEMDTL = new RIS_COMMENTSYSTEMDTL();
        }

        public DataTable getPatientDetail(string accession_no)
        {
            RISCommentSystemSelectData msgSelect = new RISCommentSystemSelectData();
            msgSelect.RIS_COMMENTSYSTEM.ACCESSION_NO = accession_no;
            DataSet ds = msgSelect.GetPatientData();
            return ds.Tables[0];
        }
        public DataTable getPatientDetailByScheduleId(int scheduleId)
        {
            RISCommentSystemSelectData msgSelect    = new RISCommentSystemSelectData();
            msgSelect.RIS_COMMENTSYSTEM.SCHEDULE_ID = scheduleId;
            return msgSelect.GetPatientDataBySchedulId().Tables[0];
        }
        public DataTable getPatientDetailByXrayreq(int xrayreqId)
        {
            RISCommentSystemSelectData msgSelect = new RISCommentSystemSelectData();
            msgSelect.RIS_COMMENTSYSTEM.XRAYREQ_ID = xrayreqId;
            return msgSelect.GetPatientDataByXrayreqId().Tables[0];
        }
        public DataTable getMessageOrder(string accession_no)
        {
            RISCommentSystemSelectData msgSelect      = new RISCommentSystemSelectData();
            msgSelect.RIS_COMMENTSYSTEM.ACCESSION_NO  = accession_no;
            return msgSelect.GetData().Tables[0];
        }
        public DataTable getMessageSchedule(int schedule_id, int exam_id)
        {
            RISCommentSystemSelectData msgSelect = new RISCommentSystemSelectData();
            msgSelect.RIS_COMMENTSYSTEM.SCHEDULE_ID = schedule_id;
            msgSelect.RIS_COMMENTSYSTEM.EXAM_ID = exam_id;
            return msgSelect.GetDataForSchedule().Tables[0];
        }
        public bool checkMessageSchedule(int schedule_id, string listExam)
        {
            RISCommentSystemSelectData msgSelect = new RISCommentSystemSelectData();
            return msgSelect.CheckDataForSchedule(schedule_id, listExam);
        }
        public DataTable getMessageForAppointmentBar(int schedule_id)
        {
            RISCommentSystemSelectData msgSelect = new RISCommentSystemSelectData();
            msgSelect.RIS_COMMENTSYSTEM.SCHEDULE_ID = schedule_id;
            return msgSelect.GetDataByScheduleID().Tables[0];
        }
        public DataTable getMessageXrayreq(int xrayreq_id, int exam_id)
        {
            RISCommentSystemSelectData msgSelect = new RISCommentSystemSelectData();
            msgSelect.RIS_COMMENTSYSTEM.XRAYREQ_ID = xrayreq_id;
            msgSelect.RIS_COMMENTSYSTEM.EXAM_ID = exam_id;
            return msgSelect.GetDataForXrayreq().Tables[0];
        }
        
        public DataSet getResultMessage(DataTable dtData, int emp_id)
        {
            dtData.Columns.Add("ME");
            dtData.Columns.Add("TEXT_ME");
            dtData.Columns.Add("TEXT_OTHER");
            dtData.Columns.Add("OTHER");
            dtData.AcceptChanges();

            DataView dv = dtData.DefaultView;
            dv.Sort = "COMMENT_ID";
            dtData = dv.ToTable();
            dtData.AcceptChanges();

            string dateChk = string.Empty;
            string commentChk = string.Empty;
            #region check same comment
            foreach (DataRow row in dtData.Rows)
            {
                if (row["MSG_TEXT"].ToString() == commentChk)
                {
                    if (string.Format(Convert.ToDateTime(row["CREATED_ON"]).ToString("HH:mm:ss")) != dateChk)
                    {
                        if (Convert.ToInt32(row["SENDER_ID"]) == emp_id)
                        {
                            row["ME"] = row["FNAME"];
                            row["TEXT_ME"] = row["MSG_TEXT"] + Convert.ToDateTime(row["CREATED_ON"]).ToString(" " + "(HH:mm)");
                        }
                        else
                        {
                            row["OTHER"] = row["FNAME"];
                            row["TEXT_OTHER"] = row["MSG_TEXT"] + Convert.ToDateTime(row["CREATED_ON"]).ToString(" " + "(HH:mm)");
                        }
                    }
                    else
                    {
                        dateChk = string.Format(Convert.ToDateTime(row["CREATED_ON"]).ToString("HH:mm:ss"));
                        commentChk = row["MSG_TEXT"].ToString();
                        row.Delete();
                    }
                }
                else
                {
                    if (string.Format(Convert.ToDateTime(row["CREATED_ON"]).ToString("HH:mm:ss")) != dateChk && row["MSG_TEXT"].ToString() != commentChk)
                    {
                        if (Convert.ToInt32(row["SENDER_ID"]) == emp_id)
                        {
                            row["ME"] = row["FNAME"];
                            row["TEXT_ME"] = row["MSG_TEXT"] + Convert.ToDateTime(row["CREATED_ON"]).ToString(" " + "(HH:mm)");
                        }
                        else
                        {
                            row["OTHER"] = row["FNAME"];
                            row["TEXT_OTHER"] = row["MSG_TEXT"] + Convert.ToDateTime(row["CREATED_ON"]).ToString(" " + "(HH:mm)");
                        }
                    }
                    dateChk = string.Format(Convert.ToDateTime(row["CREATED_ON"]).ToString("HH:mm:ss"));
                    commentChk = row["MSG_TEXT"].ToString();
                }
            } 
            #endregion

            dtData.AcceptChanges();


            DataSet dsData = new DataSet();
            dsData.Tables.Add(dtData);
            dsData.AcceptChanges();

            return dsData;
        }


        public DataTable getDataTemplate()
        {
            RISCommentSystemSelectData msgSelect = new RISCommentSystemSelectData();
            return msgSelect.GetDataTemplate().Tables[0];
        }

        public DataTable getEmpCommentedAllByOrder(string accession_no)
        {
            RISCommentSystemDtlSelectData msgSelect = new RISCommentSystemDtlSelectData();
            DataSet ds = msgSelect.getEmpCommentedAllByOrder(accession_no);
            return ds.Tables[0];
        }
        public DataTable getEmpCommentedAllBySchedule(int schedule_id)
        {
            RISCommentSystemDtlSelectData msgSelect = new RISCommentSystemDtlSelectData();
            DataSet ds = msgSelect.getEmpCommentedAllBySchedule(schedule_id);
            return ds.Tables[0];
        }
        public DataTable getEmpCommentedAllByXrayreq(int xrayreq_id)
        {
            RISCommentSystemDtlSelectData msgSelect = new RISCommentSystemDtlSelectData();
            DataSet ds = msgSelect.getEmpCommentedAllByXrayreq(xrayreq_id);
            return ds.Tables[0];
        }
        
        public int createdNewMessageForOrder(int sender_id, string msg_text, string accession_no)
        {
            RISCommentSystemInsertData msgInsert = new RISCommentSystemInsertData();
            msgInsert.RIS_COMMENTSYSTEM.SENDER_ID = sender_id;
            msgInsert.RIS_COMMENTSYSTEM.MSG_TEXT = msg_text;
            msgInsert.RIS_COMMENTSYSTEM.MSG_STATUS = "New";
            msgInsert.RIS_COMMENTSYSTEM.ACCESSION_NO = accession_no;
            return msgInsert.AddByOrder();
        }
        public int createdNewMessageForSchedule(int sender_id, string msg_text, int schedule_id, int exam_id)
        {
            RISCommentSystemInsertData msgInsert = new RISCommentSystemInsertData();
            msgInsert.RIS_COMMENTSYSTEM.SENDER_ID = sender_id;
            msgInsert.RIS_COMMENTSYSTEM.MSG_TEXT = msg_text;
            msgInsert.RIS_COMMENTSYSTEM.MSG_STATUS = "New";
            msgInsert.RIS_COMMENTSYSTEM.SCHEDULE_ID = schedule_id;
            msgInsert.RIS_COMMENTSYSTEM.EXAM_ID = exam_id;
            return msgInsert.AddBySchedule();
        }
        public int createdNewMessageForXrayreq(int sender_id, string msg_text, int xrayreq_id, int exam_id)
        {
            RISCommentSystemInsertData msgInsert = new RISCommentSystemInsertData();
            msgInsert.RIS_COMMENTSYSTEM.SENDER_ID = sender_id;
            msgInsert.RIS_COMMENTSYSTEM.MSG_TEXT = msg_text;
            msgInsert.RIS_COMMENTSYSTEM.MSG_STATUS = "New";
            msgInsert.RIS_COMMENTSYSTEM.XRAYREQ_ID = xrayreq_id;
            msgInsert.RIS_COMMENTSYSTEM.EXAM_ID = exam_id;
            return msgInsert.AddByXrayreq();
        }




        public void updateReaderMessage(int reader_id, int commentId)
        {
            RISCommentSystemDtlInsertData msgReader = new RISCommentSystemDtlInsertData();
            msgReader.RIS_COMMENTSYSTEMDTL.READER_ID = reader_id;
            msgReader.RIS_COMMENTSYSTEMDTL.COMMENT_ID = commentId;
            msgReader.Add();
        }
        public void updateReaderMessage(int reader_id, int commentId,string accession_no)
        {
            RISCommentSystemDtlInsertData msgReader = new RISCommentSystemDtlInsertData();
            msgReader.RIS_COMMENTSYSTEMDTL.READER_ID = reader_id;
            msgReader.RIS_COMMENTSYSTEMDTL.COMMENT_ID = commentId;
            msgReader.RIS_COMMENTSYSTEMDTL.ACCESSION_NO = accession_no;
            msgReader.AddByAccession();
        }
        public void updateReaderMessage(int reader_id, int commentId,int ScheduleOrXrayreq,bool is_online)
        {
            RISCommentSystemDtlInsertData msgReader = new RISCommentSystemDtlInsertData();
            msgReader.RIS_COMMENTSYSTEMDTL.READER_ID = reader_id;
            msgReader.RIS_COMMENTSYSTEMDTL.COMMENT_ID = commentId;
            if (is_online)
            {
                msgReader.RIS_COMMENTSYSTEMDTL.XRAYREQ_ID = ScheduleOrXrayreq;
                msgReader.AddByXrayreq();
            }
            else
            {
                msgReader.RIS_COMMENTSYSTEMDTL.SCHEDULE_ID = ScheduleOrXrayreq;
                msgReader.AddBySchedule();
            }
        }

        public void updateAccessionCommentSystem(string accession_no, int schedule_xrayreq_id, int order_id,int exam_id,bool is_schedule)
        {
            RISCommentSystemUpdateData msg = new RISCommentSystemUpdateData();
            if (this.Transaction != null)
                msg.Transaction = this.Transaction;
            msg.RIS_COMMENTSYSTEM.ACCESSION_NO = accession_no;
            msg.RIS_COMMENTSYSTEM.ORDER_ID = order_id;
            msg.RIS_COMMENTSYSTEM.EXAM_ID = exam_id;
            if (is_schedule)
            {
                msg.RIS_COMMENTSYSTEM.SCHEDULE_ID = schedule_xrayreq_id;
                msg.UpdateCompletedBySchedule();
            }
            else
            {
                msg.RIS_COMMENTSYSTEM.XRAYREQ_ID = schedule_xrayreq_id;
                msg.UpdateCompletedByXrayreq();
            }
        }
        public void updateMessageStatus(int comment_id, string msg_status, int emp_id)
        {
            RISCommentSystemUpdateData msg = new RISCommentSystemUpdateData();
            msg.RIS_COMMENTSYSTEM.COMMENT_ID = comment_id;
            msg.RIS_COMMENTSYSTEM.MSG_STATUS = msg_status;
            msg.RIS_COMMENTSYSTEM.LAST_MODIFIED_BY = emp_id;
            msg.UpdateCommentStatus();
        }

        
    }
}
