using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
namespace Envision.BusinessLogic
{
    public class CommentManagement
    {
        //public delegate void onInsertCommentCompleted(object Sender, string Message);
        //public delegate void onUpdateCommentCompleted(object Sender, bool isCompleted);
        //public event onInsertCommentCompleted OnInsertCommentCompleted;
        //public event onUpdateCommentCompleted OnUpdateCommentCompleted;
        //private static CommentManagement _manager;
        public CommentManagement()
        {

        }
        //public static CommentManagement GetCommentManager()
        //{
        //    if (_manager == null)
        //    {
        //        _manager = new CommentManagement();
        //    }
        //    return _manager;
        //}

        #region Select Data
        /// <summary>
        /// This method use to get comment inbox
        /// </summary>
        /// <param name="HN">Hospital Number</param>
        /// <param name="EMP_ID">Employer Id</param>
        /// <returns>Comment in box dataset</returns>
        public DataSet GetCommentInBox(string pHN, int pEMP_ID)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.HN = pHN;
            queryParameters.EMP_ID = pEMP_ID;
            queryParameters.MODE = 1;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        /// <summary>
        /// This method use to get comment in trash
        /// </summary>
        /// <param name="pHN">Hospital number</param>
        /// <param name="pEMP_ID">Employer id</param>
        /// <returns>Comment in trash dataset</returns>
        public DataSet GetCommentInTrash(string pHN, int pEMP_ID)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.HN = pHN;
            queryParameters.EMP_ID = pEMP_ID;
            queryParameters.MODE = 2;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        /// <summary>
        /// This method use to get comment save draft
        /// </summary>
        /// <param name="pHN">Hospital number<</param>
        /// <param name="pEMP_ID">Employer id</param>
        /// <returns>Comment save draft dataset</returns>
        public DataSet GetCommentSaveDraft(string pHN, int pEMP_ID)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.HN = pHN;
            queryParameters.EMP_ID = pEMP_ID;
            queryParameters.MODE = 3;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        /// <summary>
        /// This method use to get patient demographic
        /// </summary>
        /// <param name="pHN">Hospital number</param>
        /// <returns>Demographic dataset</returns>
        public DataSet GetPatientDemographic(string pHN)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.HN = pHN;
            queryParameters.MODE = 0;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        /// <summary>
        /// This method use to get all allow contact to
        /// </summary>
        /// <returns>contact list dataset</returns>
        public DataSet GetContactTo()
        {
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetContact;
            processor.ORG_ID = 1;
            processor.Invoke();
            return processor.Result;
        }
        /// <summary>
        /// This method use to get order by patient
        /// </summary>
        /// <param name="pHN">Hospital Number</param>
        /// <returns>Order Dataset</returns>
        public DataSet GetOrderByPatient(string pHN)
        {

            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.HN = pHN;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetOrderByPatient;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;

        }
        /// <summary>
        /// This method use to get comment body
        /// </summary>
        /// <param name="comment_id">Comment id</param>
        /// <returns>Comment dataset</returns>
        public DataSet GetCommentBody(int comment_id)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.COMMENT_ID = comment_id;
            queryParameters.MODE = 4;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        /// <summary>
        /// This method use to get a order by order id and exam id
        /// </summary>
        /// <param name="order_id">Order Id</param>
        /// <param name="exam_id">Exam Id</param>
        /// <returns>Order DataSet</returns>
        public DataSet GetAOrder(int order_id, int exam_id)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.ORDER_ID = order_id;
            queryParameters.EXAM_ID = exam_id;
            queryParameters.MODE = 5;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        /// <summary>
        /// This method use to get a schedule by schedule id and exam id
        /// </summary>
        /// <param name="schedule_id">Schedule Id</param>
        /// <param name="exam_id">Exam Id</param>
        /// <returns>Schedule DataSet</returns>
        public DataSet GetASchedule(int schedule_id, int exam_id)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.SCHEDULE_ID = schedule_id;
            queryParameters.EXAM_ID = exam_id;
            queryParameters.MODE = 6;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        public DataSet GetCommentInSend(string pHN, int pEMP_ID)
        {
            RIS_COMMENTSONPATIENT queryParameters = new RIS_COMMENTSONPATIENT();
            queryParameters.HN = pHN;
            queryParameters.EMP_ID = pEMP_ID;
            queryParameters.MODE = 7;
            ProcessGetComment processor = new ProcessGetComment();
            processor.InvokeMode = ProcessGetComment.InvokModes.GetComment;
            processor.QueryParameters = queryParameters;
            processor.Invoke();
            return processor.Result;
        }
        public DataTable GetCommentDetails(int CommentId) {
            ProcessGetComment proc = new ProcessGetComment();
            proc.QueryParameters = new RIS_COMMENTSONPATIENT();
            proc.QueryParameters.COMMENT_ID = CommentId;
            return proc.GetCommentDetail();
        }
        #endregion

        #region Insert Data
        /// <summary>
        /// This method use to insert reply data
        /// </summary>
        /// <param name="parent_id">Parent comment id</param>
        /// <param name="reg_id">patient registation id</param>
        /// <param name="emp_id">employee id</param>
        /// <param name="order_id">Order id</param>
        /// <param name="schedule_id">Schedule id</param>
        /// <param name="exam_id">Exam id</param>
        /// <param name="priority">Comment priority</param>
        /// <param name="commentSubject">Comment subject</param>
        /// <param name="commentText">Comment text</param>
        /// <param name="dataRow">Contact To dataRow</param>
        public void AddComment(int parent_id, int reg_id, int emp_id, int order_id, int schedule_id, int exam_id, string priority, string commentSubject, string commentText, DataRow[] dataRow, string comment_status)
        {
            string message = string.Empty;
            DbConnection con = null;
            DbTransaction tran = null;
            DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
            con = db.Connection();
            con.Open();
            tran = con.BeginTransaction();
            try
            {
                ProcessAddRISCommentsOnPatient processMaster = new ProcessAddRISCommentsOnPatient();
                processMaster.Transaction = tran;
                ProcessAddRISCommentsOnPatientDtl processDetail = new ProcessAddRISCommentsOnPatientDtl();
                processDetail.Transaction = tran;
                //Insert to master
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_BODY = commentText;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_DT = DateTime.Now;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_FROM = emp_id;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_PRIORITY = priority;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_STATUS = comment_status;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_SUBJECT = commentSubject;
                processMaster.RIS_COMMENTSONPATIENT.CREATED_BY = emp_id;
                processMaster.RIS_COMMENTSONPATIENT.CREATED_ON = DateTime.Now;
                processMaster.RIS_COMMENTSONPATIENT.IS_DELETED = "N";
                processMaster.RIS_COMMENTSONPATIENT.ORDER_ID = order_id;
                processMaster.RIS_COMMENTSONPATIENT.ORG_ID = 1;
                processMaster.RIS_COMMENTSONPATIENT.PARENT_ID = parent_id;
                processMaster.RIS_COMMENTSONPATIENT.REG_ID = reg_id;
                processMaster.RIS_COMMENTSONPATIENT.SCHEDULE_ID = schedule_id;
                processMaster.Invoke();
                //Insert to detail
                if (dataRow != null)
                {
                    int sl_no = 1;
                    foreach (DataRow drContactTo in dataRow)
                    {
                        processDetail.RIS_COMMENTSONPATINETDTL.COMMENT_ID = processMaster.RIS_COMMENTSONPATIENT.COMMENT_ID;
                        processDetail.RIS_COMMENTSONPATINETDTL.COMMENT_TO = Convert.ToInt32(drContactTo["CONTACT_ID"]);
                        processDetail.RIS_COMMENTSONPATINETDTL.CREATED_BY = emp_id;
                        processDetail.RIS_COMMENTSONPATINETDTL.CREATED_ON = DateTime.Now;
                        processDetail.RIS_COMMENTSONPATINETDTL.EXAM_ID = exam_id;
                        processDetail.RIS_COMMENTSONPATINETDTL.IS_DELETED = "N";
                        processDetail.RIS_COMMENTSONPATINETDTL.IS_TRASHED = "N";
                        processDetail.RIS_COMMENTSONPATINETDTL.ORG_ID = 1;
                        processDetail.RIS_COMMENTSONPATINETDTL.SL_NO = sl_no;
                        processDetail.RIS_COMMENTSONPATINETDTL.RECIPIENT_TYPE = string.Empty;
                        processDetail.Invoke();
                        sl_no++;
                    }
                }
                else
                {
                    processDetail.RIS_COMMENTSONPATINETDTL.COMMENT_ID = processMaster.RIS_COMMENTSONPATIENT.COMMENT_ID;
                    processDetail.RIS_COMMENTSONPATINETDTL.COMMENT_TO = 0;
                    processDetail.RIS_COMMENTSONPATINETDTL.CREATED_BY = emp_id;
                    processDetail.RIS_COMMENTSONPATINETDTL.CREATED_ON = DateTime.Now;
                    processDetail.RIS_COMMENTSONPATINETDTL.EXAM_ID = exam_id;
                    processDetail.RIS_COMMENTSONPATINETDTL.IS_DELETED = "N";
                    processDetail.RIS_COMMENTSONPATINETDTL.IS_TRASHED = "N";
                    processDetail.RIS_COMMENTSONPATINETDTL.ORG_ID = 1;
                    processDetail.RIS_COMMENTSONPATINETDTL.SL_NO = 1;
                    processDetail.RIS_COMMENTSONPATINETDTL.RECIPIENT_TYPE = string.Empty;
                    processDetail.Invoke();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                message = ex.Message;
            }
            //if (this.OnInsertCommentCompleted != null)
            //    this.OnInsertCommentCompleted(this, message);
        }
        #endregion

        #region Update Data
        /// <summary>
        /// This method use to set update to read comment
        /// </summary>
        /// <param name="comment_id">Comment row id</param>
        /// <param name="emp_id">Employee id</param>
        public void SetToReadComment(int comment_id, int emp_id)
        {
            ProcessUpdateComment processor = new ProcessUpdateComment();
            processor.MODE = 1;
            processor.COMMENT_ID = comment_id;
            processor.EMP_ID = emp_id;
            processor.Invoke();
            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, true);
        }
        /// <summary>
        /// This method use to set update to unread comment
        /// </summary>
        /// <param name="comment_id">Comment row id</param>
        /// <param name="emp_id">Employee id</param>
        public void SetMarkAsReadComment(DataRow row, int emp_id)
        {
            ProcessAddRISCommentsOnPatientDtl processor = new ProcessAddRISCommentsOnPatientDtl();
            processor.RIS_COMMENTSONPATINETDTL.RECIPIENT_TYPE = "C";
            processor.RIS_COMMENTSONPATINETDTL.COMMENT_ID = Convert.ToInt32(row["COMMENT_ID"]);
            processor.RIS_COMMENTSONPATINETDTL.COMMENT_TO = emp_id;
            processor.RIS_COMMENTSONPATINETDTL.CREATED_BY = emp_id;
            processor.RIS_COMMENTSONPATINETDTL.CREATED_ON = DateTime.Now;
            processor.RIS_COMMENTSONPATINETDTL.EXAM_ID = Convert.ToInt32(row["EXAM_ID"]);
            processor.RIS_COMMENTSONPATINETDTL.IS_DELETED = "N";
            processor.RIS_COMMENTSONPATINETDTL.IS_TRASHED = "N";
            processor.RIS_COMMENTSONPATINETDTL.ORG_ID = 1;
            processor.RIS_COMMENTSONPATINETDTL.SL_NO = 0;
            processor.Invoke();
           
            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, true);
        }
        /// <summary>
        /// This method use to set unmark as read
        /// </summary>
        /// <param name="comment_id">comment id</param>
        /// <param name="emp_id">employee id</param>
        public void SetUnmarkAsReadComment(int comment_id, int emp_id)
        {
            ProcessUpdateComment processor = new ProcessUpdateComment();
            processor.MODE = 2;
            processor.COMMENT_ID = comment_id;
            processor.EMP_ID = emp_id;
            processor.Invoke();
            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, true);
        }
        public void SetMarkAsReadComment(DataRow row, int emp_id, string Type)
        {
            ProcessAddRISCommentsOnPatientDtl processor = new ProcessAddRISCommentsOnPatientDtl();
            processor.RIS_COMMENTSONPATINETDTL.RECIPIENT_TYPE = Type;// "C";
            processor.RIS_COMMENTSONPATINETDTL.COMMENT_ID = Convert.ToInt32(row["COMMENT_ID"]);
            processor.RIS_COMMENTSONPATINETDTL.COMMENT_TO = emp_id;
            processor.RIS_COMMENTSONPATINETDTL.CREATED_BY = emp_id;
            processor.RIS_COMMENTSONPATINETDTL.CREATED_ON = DateTime.Now;
            if (string.IsNullOrEmpty(row["EXAM_ID"].ToString()))
                processor.RIS_COMMENTSONPATINETDTL.EXAM_ID = 0;
            else
                processor.RIS_COMMENTSONPATINETDTL.EXAM_ID = Convert.ToInt32(row["EXAM_ID"]);
            processor.RIS_COMMENTSONPATINETDTL.IS_DELETED = "N";
            processor.RIS_COMMENTSONPATINETDTL.IS_TRASHED = "N";
            processor.RIS_COMMENTSONPATINETDTL.ORG_ID = 1;
            processor.RIS_COMMENTSONPATINETDTL.SL_NO = 0;
            processor.Invoke();

            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, true);
        }
        /// <summary>
        /// This method use to set update to unread comment
        /// </summary>
        /// <param name="comment_id">Comment row id</param>
        /// <param name="emp_id">Employee id</param>
        public void SetCommentToTrash(int comment_id, int emp_id)
        {
            ProcessUpdateComment processor = new ProcessUpdateComment();
            processor.MODE = 3;
            processor.COMMENT_ID = comment_id;
            processor.EMP_ID = emp_id;
            processor.Invoke();
            //if (this.OnUpdateCommentCompleted != null)
            //{
            //    if(processor.Result == "Y")
            //        this.OnUpdateCommentCompleted(this, true);
            //    else
            //        this.OnUpdateCommentCompleted(this, false);
            //}
        }
        /// <summary>
        /// This method use to remove comment
        /// </summary>
        /// <param name="comment_id">Comment row id</param>
        /// <param name="emp_id">Employee id</param>
        public void RemoveComment(int comment_id, int emp_id)
        {
            ProcessUpdateComment processor = new ProcessUpdateComment();
            processor.MODE = 4;
            processor.COMMENT_ID = comment_id;
            processor.EMP_ID = emp_id;
            processor.Invoke();
            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, true);
        }
        /// <summary>
        /// This method use to send draft comment
        /// </summary>
        /// <param name="comment_id">Comment row id</param>
        /// <param name="emp_id">Employee id</param>
        public void SendCommentByDraft(int comment_id, int emp_id)
        {
            ProcessUpdateComment processor = new ProcessUpdateComment();
            processor.MODE = 5;
            processor.COMMENT_ID = comment_id;
            processor.EMP_ID = emp_id;
            processor.Invoke();
            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, true);
        }
        /// <summary>
        /// This method use to retore comment in trash
        /// </summary>
        /// <param name="comment_id">Comment row id</param>
        /// <param name="emp_id">Employee id</param>
        public void RestoreCommentInTrash(int comment_id, int emp_id)
        {
            ProcessUpdateComment processor = new ProcessUpdateComment();
            processor.MODE = 6;
            processor.COMMENT_ID = comment_id;
            processor.EMP_ID = emp_id;
            processor.Invoke();
            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, true);
        }

        public void UpdateDraftComment(int comment_id, int parent_id, int oldExam_id, int reg_id, int emp_id, int order_id, int schedule_id, int exam_id, string priority, string commentSubject, string commentText, DataRow[] dataRow, string comment_status)
        {
            bool isCompleted = false;
            DbConnection con = null;
            DbTransaction tran = null;
            DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
            con = db.Connection();
            con.Open();
            tran = con.BeginTransaction();

            try
            {
                ProcessUpdateComment processor = new ProcessUpdateComment();
                processor.Transaction = tran;
                ProcessUpdateRISCommentOnPatient processMaster = new ProcessUpdateRISCommentOnPatient();
                processor.Transaction = tran;
                ProcessUpdateRISCommentOnPatientDtl processDetail = new ProcessUpdateRISCommentOnPatientDtl();
                processDetail.Transaction = tran;
                //Set remove comment to
                processor.MODE = 7;
                processor.EMP_ID = emp_id;
                processor.COMMENT_ID = comment_id;
                processor.Invoke();
                // update to master
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_ID = comment_id;
                if (oldExam_id == exam_id)
                    processMaster.RIS_COMMENTSONPATIENT.PARENT_ID = parent_id;
                else
                    processMaster.RIS_COMMENTSONPATIENT.PARENT_ID = 0;
                processMaster.RIS_COMMENTSONPATIENT.SCHEDULE_ID = schedule_id;
                processMaster.RIS_COMMENTSONPATIENT.ORDER_ID = order_id;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_SUBJECT = commentSubject;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_BODY = commentText;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_STATUS = comment_status;
                processMaster.RIS_COMMENTSONPATIENT.COMMENT_PRIORITY = priority;
                processMaster.RIS_COMMENTSONPATIENT.LAST_MODIFIED_BY = emp_id;
                processMaster.RIS_COMMENTSONPATIENT.LAST_MODIFIED_ON = DateTime.Now;
                processMaster.Invoke();
                // update to detail
                if (dataRow != null)
                {
                    foreach (DataRow drContactTo in dataRow)
                    {
                        processDetail.RIS_COMMENTSONPATIENTDTL.COMMENT_ID = processMaster.RIS_COMMENTSONPATIENT.COMMENT_ID;
                        processDetail.RIS_COMMENTSONPATIENTDTL.COMMENT_TO = Convert.ToInt32(drContactTo["CONTACT_ID"]);
                        processDetail.RIS_COMMENTSONPATIENTDTL.CREATED_BY = emp_id;
                        processDetail.RIS_COMMENTSONPATIENTDTL.CREATED_ON = DateTime.Now;
                        processDetail.RIS_COMMENTSONPATIENTDTL.EXAM_ID = exam_id;
                        processDetail.RIS_COMMENTSONPATIENTDTL.IS_DELETED = "N";
                        processDetail.RIS_COMMENTSONPATIENTDTL.IS_TRASHED = "N";
                        processDetail.RIS_COMMENTSONPATIENTDTL.ORG_ID = 1;
                        processDetail.RIS_COMMENTSONPATIENTDTL.SL_NO = 0;
                        processDetail.RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_BY = emp_id;
                        processDetail.RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_ON = DateTime.Now;
                        processDetail.Invoke();
                    }
                }
                else
                {
                    processDetail.RIS_COMMENTSONPATIENTDTL.COMMENT_ID = processMaster.RIS_COMMENTSONPATIENT.COMMENT_ID;
                    processDetail.RIS_COMMENTSONPATIENTDTL.COMMENT_TO = 0;
                    processDetail.RIS_COMMENTSONPATIENTDTL.CREATED_BY = emp_id;
                    processDetail.RIS_COMMENTSONPATIENTDTL.CREATED_ON = DateTime.Now;
                    processDetail.RIS_COMMENTSONPATIENTDTL.EXAM_ID = exam_id;
                    processDetail.RIS_COMMENTSONPATIENTDTL.IS_DELETED = "N";
                    processDetail.RIS_COMMENTSONPATIENTDTL.IS_TRASHED = "N";
                    processDetail.RIS_COMMENTSONPATIENTDTL.ORG_ID = 1;
                    processDetail.RIS_COMMENTSONPATIENTDTL.SL_NO = 1;
                    processDetail.RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_BY = emp_id;
                    processDetail.RIS_COMMENTSONPATIENTDTL.LAST_MODIFIED_ON = DateTime.Now;
                    processDetail.Invoke();
                }
                tran.Commit();
                isCompleted = true;
            }
            catch (Exception)
            {
                tran.Rollback();
                isCompleted = false;
            }

            //if (this.OnUpdateCommentCompleted != null)
            //    this.OnUpdateCommentCompleted(this, isCompleted);
        }
        #endregion
    }
}
