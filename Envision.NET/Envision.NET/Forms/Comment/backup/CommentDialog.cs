using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraBars;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.Common;

namespace Envision.NET.Forms.Comment
{
    public partial class CommentDialog : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public struct CloseDialogEventArgs
        {
            public bool IsUpdate { get; set; }
            public CloseWith CloseWith { get; set; }
        }
        public delegate void onDialogClosed(object Sender, CloseDialogEventArgs args);
        public event onDialogClosed OnDialogClosed;
        public enum CloseWith
        {
            Reply, New, Draft, None
        }
        public enum ShowDialogMode
        {
            Open, Reply, New, Draft, ReadOnly
        }
        private static CommentDialog commenctdialog;
        private CommentManagement commentManager;
        private ContactLookUp contactLookUp;
        private ShowDialogMode _dialogMode;
        //private bool IsRecordChanged = false;
        private string commentTextSource;
        private DataRow tempRow;
        private DataRow[] contactDataRow;
        private DataTable dttStudy;
        private bool CanShowLookUp;
        public int EMP_ID { get { return env.UserID; } set { EMP_ID = value; } }
        public int REG_ID { get; set; }
        public CloseWith closeWith = CloseWith.None;
        public ShowDialogMode DialogMode
        {
            get { return _dialogMode; }
            set 
            { 
                _dialogMode = value;
                if (_dialogMode == ShowDialogMode.Open)
                {
                    gSend.Visible = true;
                    gDraft.Visible = true;
                    gReply.Visible = true;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.CanShowLookUp = false;
                    this.grdExam.Properties.ReadOnly = true;
                    this.tbSubject.Properties.ReadOnly = true;
                    this.mmComment.ReadOnly = true;
                    this.btnSend.Enabled = false;
                    this.btnSaveDraft.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnReply.Enabled = true;
                    this.cbPriorityImage.Properties.ReadOnly = true;
                    this.bteCommentTo.KeyDown -= new KeyEventHandler(bteCommentTo_KeyDown);
                    this.bteCommentTo.BackColor = Color.FromArgb(227, 239, 255);

                    gSend.Visible = false;
                    gDraft.Visible = false;
                    btnCancel.Enabled = true;
                }
                else if (_dialogMode == ShowDialogMode.Reply)
                {
                    gSend.Visible = true;
                    gDraft.Visible = true;
                    gReply.Visible = true;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.CanShowLookUp = true;
                    this.tbSubject.Properties.ReadOnly = false;
                    this.btnSaveDraft.Enabled = true;
                    this.btnSend.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnReply.Enabled = false;
                    this.grdExam.Properties.ReadOnly = true;
                    this.cbPriorityImage.Properties.ReadOnly = false;
                    this.mmComment.ReadOnly = false;
                    //this.CanDoAction();
                    this.bteCommentTo.KeyDown += new KeyEventHandler(bteCommentTo_KeyDown);
                    this.bteCommentTo.BackColor = Color.FromArgb(227, 239, 255);
                    gReply.Visible = false;
                }
                else if (_dialogMode == ShowDialogMode.New || _dialogMode == ShowDialogMode.Draft)
                {
                    gSend.Visible = true;
                    gDraft.Visible = true;
                    gReply.Visible = true;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.CanShowLookUp = true;
                    this.tbSubject.Properties.ReadOnly = false;
                    this.btnSend.Enabled = true;
                    this.btnSaveDraft.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnReply.Enabled = false;
                    this.grdExam.Properties.ReadOnly = false;
                    this.cbPriorityImage.Properties.ReadOnly = false;
                    this.cbPriorityImage.SelectedIndex = 1;
                    this.mmComment.ReadOnly = false;
                    //this.CanDoAction();
                    this.bteCommentTo.KeyDown -= new KeyEventHandler(bteCommentTo_KeyDown);
                    this.bteCommentTo.BackColor = Color.White;
                    
                    gReply.Visible = false;
                }
                else if (_dialogMode == ShowDialogMode.ReadOnly)
                {
                    gSend.Visible = false;
                    gDraft.Visible = false;
                    gReply.Visible = false;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.CanShowLookUp = false;
                    this.tbSubject.Properties.ReadOnly = true;
                    this.btnSend.Enabled = false;
                    this.btnSaveDraft.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnReply.Enabled = false;
                    this.grdExam.Properties.ReadOnly = true;
                    this.cbPriorityImage.Properties.ReadOnly = true;
                    this.mmComment.ReadOnly = true;
                    this.bteCommentTo.KeyDown -= new KeyEventHandler(bteCommentTo_KeyDown);
                    this.bteCommentTo.BackColor = Color.FromArgb(227, 239, 255);
                    btnCancel.Enabled = true;

                }
            }
        }
        public MyMessageBox msg = new MyMessageBox();
        private static GBLEnvVariable env;
        private int commentId;

        private CommentDialog()
        {
            env = new GBLEnvVariable();
            InitializeComponent();
            this.contactLookUp = ContactLookUp.GetContactLookUp();
            this.contactLookUp.OnContactLookUpClose += new ContactLookUp.onContactLookUpClose(contactLookUp_OnContactLookUpClose);
            this.commentManager = CommentManagement.GetCommentManager();
            this.commentManager.OnInsertCommentCompleted += new CommentManagement.onInsertCommentCompleted(commentManager_OnInsertCommentCompleted);
            this.commentManager.OnUpdateCommentCompleted += new CommentManagement.onUpdateCommentCompleted(commentManager_OnUpdateCommentCompleted);
            this.DialogMode = ShowDialogMode.Open;
            this.mmComment.BackColor = Color.White;
            this.btnReply.ItemClick += new ItemClickEventHandler(btnReply_ItemClick);
            this.btnCancel.ItemClick +=new ItemClickEventHandler(btnCancel_ItemClick);
            this.mmComment.TextChanged += new EventHandler(mmComment_TextChanged);
            this.bteCommentTo.TextChanged += new EventHandler(bteCommentTo_TextChanged);
            this.bteCommentTo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(bteCommentTo_ButtonClick);
            this.btnSend.ItemClick +=new ItemClickEventHandler(btnSend_ItemClick);
            this.btnSaveDraft.ItemClick +=new ItemClickEventHandler(btnSaveDraft_ItemClick);
            this.bteCommentTo.Properties.ReadOnly = true;
            this.commentTextSource = string.Empty;
            commentId = 0;
        }

        void btnSaveDraft_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSaveDraft_Click(sender, EventArgs.Empty);
        }

        void btnSend_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSend_Click(sender, EventArgs.Empty);
        }

        void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCancel_Click(sender, EventArgs.Empty);
        }

        void btnReply_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnReply_Click(sender, EventArgs.Empty);
        }

        #region Update Complete event
        private void commentManager_OnUpdateCommentCompleted(object Sender, bool isCompleted)
        {
            if (isCompleted)
            {
                if (this.OnDialogClosed != null && this.closeWith != CloseWith.None)
                {
                    CloseDialogEventArgs args = new CloseDialogEventArgs();
                    args.CloseWith = this.closeWith;
                    args.IsUpdate = true;
                    this.OnDialogClosed(this, args);
                }
            }
            else
            {
                //if (this.OnDialogClosed != null && this.closeWith != CloseWith.None)
                //{
                //    MessageBox.Show("เกิดข้อผิดพลาด. กรุณาติดต่อผู้ดูแลระบบ", "Comment system error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
        #endregion

        #region Insert complete event
        private void commentManager_OnInsertCommentCompleted(object Sender, string Message)
        {
            if (Message == string.Empty)
            {
                if (this.OnDialogClosed != null && this.closeWith != CloseWith.None)
                {
                    CloseDialogEventArgs args = new CloseDialogEventArgs();
                    args.CloseWith = this.closeWith;
                    args.IsUpdate = true;
                    this.OnDialogClosed(this, args);
                }
            }
            else
            {
                MessageBox.Show(string.Format("เกิดข้อผิดพลาด {0} \r\nกรุณาติดต่อผู้ดูแลระบบ", Message), "Comment system error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// Get class instance object
        /// </summary>
        /// <returns>class object</returns>
        public static CommentDialog GetCommentDialog()
        {
            if (commenctdialog == null)
                commenctdialog = new CommentDialog();
            else if (commenctdialog.IsDisposed)
                commenctdialog = new CommentDialog();
            return commenctdialog;
        }
        public static CommentDialog GetCommentDialog(bool flag)
        {
            commenctdialog = new CommentDialog();
            return commenctdialog;
        }

        #region Initial Comment Dialog
        private void setStudyByPatient(string HN) {
            dttStudy = new DataTable();
            dttStudy = this.commentManager.GetOrderByPatient(HN).Tables[0];
            dttStudy.Columns.Add("Id", typeof(int));
            dttStudy.AcceptChanges();
            for (int i = 0; i < dttStudy.Rows.Count; i++) dttStudy.Rows[i]["Id"] = i;

            grdExam.Properties.DisplayMember = "EXAM";
            grdExam.Properties.ValueMember = "Id";
            grdExam.Properties.DataSource = dttStudy;

            for (int i = 0; i < dttStudy.Columns.Count; i++) grdExam.Properties.View.Columns[i].Visible = false;
            grdExam.Properties.PopupFormSize = new Size(600, 350);

            grdExam.Properties.View.Columns["ORDER_ID"].Caption = "Study Id";
            grdExam.Properties.View.Columns["ORDER_ID"].Visible = true;
            grdExam.Properties.View.Columns["ORDER_ID"].VisibleIndex = 1;
            grdExam.Properties.View.Columns["ORDER_ID"].Width = 100;

            grdExam.Properties.View.Columns["ORDER_FROM"].Caption = "Source";
            grdExam.Properties.View.Columns["ORDER_FROM"].Visible = true;
            grdExam.Properties.View.Columns["ORDER_FROM"].VisibleIndex = 2;
            grdExam.Properties.View.Columns["ORDER_FROM"].Width = 100;

            grdExam.Properties.View.Columns["STATUS"].Caption = "Status";
            grdExam.Properties.View.Columns["STATUS"].Visible = true;
            grdExam.Properties.View.Columns["STATUS"].VisibleIndex = 3;
            grdExam.Properties.View.Columns["STATUS"].Width = 70;

            grdExam.Properties.View.Columns["EXAM"].Caption = "Exam Name";
            grdExam.Properties.View.Columns["EXAM"].Visible = true;
            grdExam.Properties.View.Columns["EXAM"].VisibleIndex = 4;
            grdExam.Properties.View.Columns["EXAM"].Width = 200;

            grdExam.Properties.View.Columns["ORDER_DT"].Caption = "Study Date";
            grdExam.Properties.View.Columns["ORDER_DT"].Visible = true;
            grdExam.Properties.View.Columns["ORDER_DT"].VisibleIndex = 5;
            grdExam.Properties.View.Columns["ORDER_DT"].Width = 100;

            grdExam.Properties.View.Columns["UNIT_UID"].Caption = "Unit";
            grdExam.Properties.View.Columns["UNIT_UID"].Visible = true;
            grdExam.Properties.View.Columns["UNIT_UID"].VisibleIndex = 6;
            grdExam.Properties.View.Columns["UNIT_UID"].Width = 100;
        }
        public void SetNewCommentDialog(string HN, int REG_ID)
        {
            if (this._dialogMode == ShowDialogMode.New)
            {
                setStudyByPatient(HN);
                this.REG_ID = REG_ID;
                commentId = 0;
            }
        }
        public void SetNewCommentDialog(string HN, int REG_ID, int ID,string Type)
        {
            if (this._dialogMode == ShowDialogMode.New)
            {
                setStudyByPatient(HN);
                DataRow[] rows = null;
                if (Type == "S")
                    rows = dttStudy.Select("ORDER_FROM='Schedule' AND ORDER_ID=" + ID);
                else 
                    rows = dttStudy.Select("ORDER_FROM='Order' AND ORDER_ID=" + ID);
                if (rows != null && rows.Length > 0)
                    grdExam.EditValue = rows[0]["Id"].ToString();
                this.REG_ID = REG_ID;
                commentId = 0;
            }
        }

        public void SetCommentBySourceId(string HN, int REG_ID, int id, int exam_id)
        {
            if (this._dialogMode == ShowDialogMode.New)
            {
                DataTable dtDataSource = this.commentManager.GetOrderByPatient(HN).Tables[0];
                this.grdExam.Properties.DataSource = dtDataSource;
                this.grdExam.EditValue = id;
                this.REG_ID = REG_ID;
                this.contactDataRow = this.contactLookUp.GetContactDataRow(this.EMP_ID.ToString());
                commentId = 0;
            }
        }
        public void SetCommentDialog(string HN, int REG_ID, DataRow commentRow, ShowDialogMode mode)
        {
            commentId = 0;
            this.DialogMode = mode;
            this.REG_ID = REG_ID;
            if (mode == ShowDialogMode.Open || mode == ShowDialogMode.Draft || mode == ShowDialogMode.Reply)
            {
                setStudyByPatient(HN);
                if (commentRow["ORDER_ID"].Equals("0"))
                {
                    //this.grdExam.EditValue = rowHandle["SCHEDULE_ID"];
                    for (int i = 0; i < dttStudy.Rows.Count; i++)
                    {
                        if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "schedule" && dttStudy.Rows[i]["SCHEDULE_ID"].ToString() == commentRow["SCHEDULE_ID"].ToString())
                        {
                            grdExam.Properties.View.FocusedRowHandle = i;
                            break;
                        }
                    }
                }
                else
                {
                    //this.grdExam.EditValue = rowHandle["ORDER_ID"];
                    for (int i = 0; i < dttStudy.Rows.Count; i++)
                    {
                        if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "order" && dttStudy.Rows[i]["ORDER_ID"].ToString() == commentRow["ORDER_ID"].ToString())
                        {
                            grdExam.EditValue = i;
                            break;
                        }
                    }
                }
                //Initial DataRow 
                this.bteCommentTo.Text = commentRow["COMMENT_TO"].ToString();
                this.tbSubject.Text = commentRow["COMMENT_SUBJECT"].ToString();
                this.mmComment.Text = this.GetCommentText(Convert.ToInt32(commentRow["COMMENT_ID"]));
                //this.mmComment.Text = commentRow["COMMENT_BODY"].ToString();
                //this.tbBy.Text = commentRow["COMMENT_BY"].ToString();
                if (commentRow["COMMENT_PRIORITY"].Equals("High"))
                    this.cbPriorityImage.SelectedIndex = 0;
                else if (commentRow["COMMENT_PRIORITY"].Equals("Medium"))
                    this.cbPriorityImage.SelectedIndex = 1;
                else
                    this.cbPriorityImage.SelectedIndex = 2;
                //temp data
                this.SaveToBufferData(commentRow);
                List<string> contactIds = new List<string>();
                string ids = this.tempRow["COMMENT_TO_ID"].ToString().TrimEnd().TrimEnd(',');
                this.contactDataRow = this.contactLookUp.GetContactDataRow(ids);
                if (mode == ShowDialogMode.Reply)
                    this.btnReply_Click(this, EventArgs.Empty);
            }
            else if (mode == ShowDialogMode.ReadOnly)
            {
                setStudyByPatient(HN);
                if (commentRow["ORDER_ID"].Equals("0"))
                {
                    //this.grdExam.EditValue = rowHandle["SCHEDULE_ID"];
                    for (int i = 0; i < dttStudy.Rows.Count; i++)
                    {
                        if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "schedule" && dttStudy.Rows[i]["SCHEDULE_ID"].ToString() == commentRow["SCHEDULE_ID"].ToString())
                        {
                            grdExam.Properties.View.FocusedRowHandle = i;
                            break;
                        }
                    }
                }
                else
                {
                    //this.grdExam.EditValue = rowHandle["ORDER_ID"];
                    for (int i = 0; i < dttStudy.Rows.Count; i++)
                    {
                        if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "order" && dttStudy.Rows[i]["ORDER_ID"].ToString() == commentRow["ORDER_ID"].ToString())
                        {
                            grdExam.EditValue = i;
                            break;
                        }
                    }
                }
                this.bteCommentTo.Text = commentRow["COMMENT_TO"].ToString();
                this.tbSubject.Text = commentRow["COMMENT_SUBJECT"].ToString();
                this.mmComment.Text = this.GetCommentText(Convert.ToInt32(commentRow["COMMENT_ID"]));
                if (commentRow["COMMENT_PRIORITY"].Equals("High"))
                    this.cbPriorityImage.SelectedIndex = 0;
                else if (commentRow["COMMENT_PRIORITY"].Equals("Medium"))
                    this.cbPriorityImage.SelectedIndex = 1;
                else
                    this.cbPriorityImage.SelectedIndex = 2;
            }
        }
        public void SetDraftDialog(string HN, DataRow rowHandle){
            if (rowHandle == null) return;
            this.DialogMode = ShowDialogMode.Draft;
            setStudyByPatient(HN);
            if (rowHandle["ORDER_ID"].Equals("0"))
            {
                for (int i=0;i<dttStudy.Rows.Count;i++)
                {
                    if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "schedule" && dttStudy.Rows[i]["SCHEDULE_ID"].ToString() == rowHandle["SCHEDULE_ID"].ToString())
                    {
                        grdExam.Properties.View.FocusedRowHandle = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dttStudy.Rows.Count; i++)
                {
                    if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "order" && dttStudy.Rows[i]["ORDER_ID"].ToString() == rowHandle["ORDER_ID"].ToString())
                    {
                        grdExam.EditValue = i;
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(rowHandle["COMMENT_TO"].ToString()))
            {
                this.bteCommentTo.Text = rowHandle["COMMENT_TO"].ToString();

                List<string> contactIds = new List<string>();
                string ids = rowHandle["COMMENT_TO_ID"].ToString();
                string[] id_part = ids.Split(',');
                foreach (string id in id_part)
                {
                    if (id.Trim() != string.Empty)
                        contactIds.Add(id.Trim());
                }
                this.contactLookUp.SetStartSelectContact(contactIds);
                this.contactDataRow = this.contactLookUp.GetContactDataRow(ids);
            }
           

            this.tbSubject.Text = rowHandle["COMMENT_SUBJECT"].ToString();
            commentId=Convert.ToInt32(rowHandle["COMMENT_ID"]);
            this.mmComment.Text = this.GetCommentText(commentId,true);
            if (rowHandle["COMMENT_PRIORITY"].Equals("High"))
                this.cbPriorityImage.SelectedIndex = 0;
            else if (rowHandle["COMMENT_PRIORITY"].Equals("Medium"))
                this.cbPriorityImage.SelectedIndex = 1;
            else
                this.cbPriorityImage.SelectedIndex = 2;
            this.SaveToBufferData(rowHandle);
            CanShowLookUp = true;
        }
        public void SetSendDialog(string HN, DataRow rowHandle) {
            if (rowHandle == null) return;
            this.DialogMode = ShowDialogMode.Draft;
            setStudyByPatient(HN);
            if (rowHandle["ORDER_ID"].Equals("0"))
            {
                for (int i = 0; i < dttStudy.Rows.Count; i++)
                {
                    if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "schedule" && dttStudy.Rows[i]["SCHEDULE_ID"].ToString() == rowHandle["SCHEDULE_ID"].ToString())
                    {
                        grdExam.Properties.View.FocusedRowHandle = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dttStudy.Rows.Count; i++)
                {
                    if (dttStudy.Rows[i]["ORDER_FROM"].ToString().ToLower() == "order" && dttStudy.Rows[i]["ORDER_ID"].ToString() == rowHandle["ORDER_ID"].ToString())
                    {
                        grdExam.EditValue = i;
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(rowHandle["COMMENT_TO"].ToString()))
            {
                this.bteCommentTo.Text = rowHandle["COMMENT_TO"].ToString();

                List<string> contactIds = new List<string>();
                string ids = rowHandle["COMMENT_TO_ID"].ToString();
                string[] id_part = ids.Split(',');
                foreach (string id in id_part)
                {
                    if (id.Trim() != string.Empty)
                        contactIds.Add(id.Trim());
                }
                this.contactLookUp.SetStartSelectContact(contactIds);
                this.contactDataRow = this.contactLookUp.GetContactDataRow(ids);
            }


            this.tbSubject.Text = rowHandle["COMMENT_SUBJECT"].ToString();
            commentId = Convert.ToInt32(rowHandle["COMMENT_ID"]);
            this.mmComment.Text = this.GetCommentText(commentId, true);
            if (rowHandle["COMMENT_PRIORITY"].Equals("High"))
                this.cbPriorityImage.SelectedIndex = 0;
            else if (rowHandle["COMMENT_PRIORITY"].Equals("Medium"))
                this.cbPriorityImage.SelectedIndex = 1;
            else
                this.cbPriorityImage.SelectedIndex = 2;
            this.SaveToBufferData(rowHandle);
            CanShowLookUp = true;
            gSend.Visible = false;
            gDraft.Visible = false;
            gEdit.Visible = true;
        }
        #endregion

        #region Reply Button Event
        private void btnReply_Click(object sender, EventArgs e)
        {
            if (this.tempRow != null)
            {
                //this.DialogMode = ShowDialogMode.Reply;
                //this.tbSubject.Text = "Re: " + this.tbSubject.Text;
                ////this.commentTextSource =  
                ////    "\r\n\r\n\r\n\r\n"
                ////    + "\r\n--------------------------------------------------------------------------------------------------------------\r\n"
                ////    + this.tempRow["COMMENT_BODY"]
                ////    + "\r\n\r\n\r\n[ Comment By: " + this.tempRow["COMMENT_BY"] + " ]\r\n"
                ////    + "[ Comment On: " + this.tempRow["COMMENT_DT"] + " ]"
                ////    + "\r\n--------------------------------------------------------------------------------------------------------------\r\n";
                ////this.mmComment.Text = this.commentTextSource;
                //this.commentTextSource = this.GetCommentText(Convert.ToInt32(tempRow["COMMENT_ID"]));
                //this.mmComment.Text = this.commentTextSource;
                //this.bteCommentTo.Text = this.tempRow["COMMENT_BY"].ToString();
                //this.contactLookUp.ClearSelectedRows();
                //string ids = this.tempRow["COMMENT_BY_ID"].ToString();
                //this.contactDataRow = this.contactLookUp.GetContactDataRow(ids);
                ////this.tbBy.Text = "เฉลิมเกียรติ มั่นคง";

                this.DialogMode = ShowDialogMode.Reply;
                this.tbSubject.Text = "Re: " + this.tbSubject.Text;
                this.commentTextSource = "\r\n\r\n\r\n--------------------------------------------------------------------------------------------------------------\r\n" + 
                                         this.GetCommentText(Convert.ToInt32(tempRow["COMMENT_ID"])) +
                                        "\r\n--------------------------------------------------------------------------------------------------------------\r\n";
                this.mmComment.Text = this.commentTextSource;
                if (!string.IsNullOrEmpty(tempRow["COMMENT_TO"].ToString()))
                {
                    this.bteCommentTo.Text = tempRow["COMMENT_TO"].ToString();

                    List<string> contactIds = new List<string>();
                    string ids = tempRow["COMMENT_TO_ID"].ToString();
                    string[] id_part = ids.Split(',');
                    foreach (string id in id_part)
                    {
                        if (id.Trim() != string.Empty)
                            contactIds.Add(id.Trim());
                    }
                    this.contactLookUp.SetStartSelectContact(contactIds);
                    this.contactDataRow = this.contactLookUp.GetContactDataRow(ids);
                }
                bteCommentTo.BackColor = Color.White;
            }
        }
        #endregion

        #region Cancel Button Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.tbSubject.TextChanged -= new EventHandler(tbSubject_TextChanged);
            //this.cbExam.EditValueChanged -= new EventHandler(cbExam_EditValueChanged);
            //this.DialogMode = ShowDialogMode.Open;
            //this.bteCommentTo.Text = this.tempRow["COMMENT_TO"].ToString();
            //if (tempRow["ORDER_ID"].Equals("0"))
            //    this.cbExam.EditValue = tempRow["SCHEDULE_ID"];
            //else
            //    this.cbExam.EditValue = tempRow["ORDER_ID"];
            //this.tbSubject.Text = this.tempRow["COMMENT_SUBJECT"].ToString();
            //this.mmComment.Text = this.tempRow["COMMENT_BODY"].ToString();
            //this.tbBy.Text = this.tempRow["COMMENT_BY"].ToString();
        }
        #endregion

        #region Send Button Event
        private void btnSend_Click(object sender, EventArgs e)
        {
            //if (this.cbExam.EditValue.ToString() != "0" && this.cbExam.EditValue.ToString() != string.Empty)
            //{

            if (string.IsNullOrEmpty(tbSubject.Text.Trim())) {
                msg.ShowAlert("UID1307", env.CurrentLanguageID);
                tbSubject.Focus();
                return;
            }
            if (string.IsNullOrEmpty(bteCommentTo.Text.Trim())) {
                msg.ShowAlert("UID1301", env.CurrentLanguageID);
                bteCommentTo.Focus();
                return;
            }
            if (grdExam.EditValue==null ||  string.IsNullOrEmpty(grdExam.EditValue.ToString()))
            {
                msg.ShowAlert("UID1308", env.CurrentLanguageID);
                grdExam.Focus();
                return;
            }
            if (string.IsNullOrEmpty(mmComment.Text.Trim())) {
                msg.ShowAlert("UID1302", env.CurrentLanguageID);
                mmComment.Focus();
                return;
            }

            string s = msg.ShowAlert("UID1303", new GBLEnvVariable().CurrentLanguageID);
            if(s == "2")
            {
                int order_id = 0;
                int schedule_id = 0;
                int exam_id  = 0;
                //if (this.grdExam.EditValue.ToString() != "0" && this.grdExam.EditValue.ToString() != string.Empty)
                if(grdExam.EditValue!=null &&  !string.IsNullOrEmpty(this.grdExam.EditValue.ToString()))
                {
                    
                    DataRow objRow = dttStudy.Rows[Convert.ToInt32(grdExam.EditValue.ToString())];
                    exam_id = Convert.ToInt32(objRow["EXAM_ID"]);
                    if (objRow["ORDER_FROM"].Equals("Order"))
                        order_id = Convert.ToInt32(objRow["ORDER_ID"]);
                    else
                        schedule_id = Convert.ToInt32(objRow["ORDER_ID"]);
                    
                    
                }
                
                string priority = this.cbPriorityImage.EditValue.ToString();
                string commentText = string.Empty;
                if (this.commentTextSource != string.Empty)
                    commentText = this.mmComment.Text.Replace(this.commentTextSource, "");
                else
                    commentText = this.mmComment.Text;

                string subject = this.tbSubject.Text;
                if (string.IsNullOrEmpty(subject.Trim()))
                    subject = "(no subject)";

                if (this.DialogMode == ShowDialogMode.Reply)
                {
                    this.closeWith = CloseWith.Reply;
                    this.commentManager.AddComment(Convert.ToInt32(this.tempRow["COMMENT_ID"]), Convert.ToInt32(this.tempRow["REG_ID"]),
                        this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "S");
                }
                else if (this.DialogMode == ShowDialogMode.New)
                {
                    this.closeWith = CloseWith.New;
                    this.commentManager.AddComment(0, this.REG_ID,
                        this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "S");
                }
                else if (this.DialogMode == ShowDialogMode.Draft)
                {
                    this.closeWith = CloseWith.Draft;
                    int parent_id = Convert.ToInt32(this.tempRow["PARENT_ID"]);
                    int oldExam_id = 0;
                    if (this.tempRow["EXAM_ID"] != DBNull.Value)
                        oldExam_id = Convert.ToInt32(this.tempRow["EXAM_ID"]);

                    this.commentManager.UpdateDraftComment(Convert.ToInt32(this.tempRow["COMMENT_ID"])
                        , Convert.ToInt32(this.tempRow["PARENT_ID"]), oldExam_id
                        , this.REG_ID, this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "S");
                }
                this.Close();
            }
        }
            //else
            //{
            //    msg.ShowAlert("UID6013", new GBLEnvVariable().CurrentLanguageID);
            //    //MessageBox.Show("กรุณาเลือก exam ด้วย", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        //}
        #endregion

        #region Save Draft Button Event
        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSubject.Text.Trim()))
            {
                msg.ShowAlert("UID1307", env.CurrentLanguageID);
                tbSubject.Focus();
                return;
            }
            int order_id = 0;
            int schedule_id = 0;
            int exam_id = 0;
            

            if (grdExam.EditValue != null)
            {
                if (grdExam.EditValue != null && !string.IsNullOrEmpty(this.grdExam.EditValue.ToString()))
                {
                    DataRow objRow = dttStudy.Rows[Convert.ToInt32(grdExam.EditValue.ToString())];
                    exam_id = Convert.ToInt32(objRow["EXAM_ID"]);
                    if (objRow["ORDER_FROM"].Equals("Order"))
                        order_id = Convert.ToInt32(objRow["ORDER_ID"]);
                    else
                        schedule_id = Convert.ToInt32(objRow["ORDER_ID"]);
                }
            }

            string priority = this.cbPriorityImage.EditValue.ToString();
            string commentText = string.Empty;
            if (this.commentTextSource != string.Empty)
                commentText = this.mmComment.Text.Replace(this.commentTextSource, "");
            else
                commentText = this.mmComment.Text;

            string subject = this.tbSubject.Text;
            if (string.IsNullOrEmpty(subject.Trim()))
                subject = "(no subject)";

            if (this.DialogMode == ShowDialogMode.New)
            {
                this.closeWith = CloseWith.Draft;
                this.commentManager.AddComment(0, this.REG_ID,
                    this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "D");
                this.Close();
            }
            else if (this.DialogMode == ShowDialogMode.Reply)
            {
                this.closeWith = CloseWith.Draft;
                this.commentManager.AddComment(Convert.ToInt32(this.tempRow["COMMENT_ID"]), Convert.ToInt32(this.tempRow["REG_ID"]),
                   this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "D");
                this.Close();
            }
            else if (this.DialogMode == ShowDialogMode.Draft)
            {
                this.closeWith = CloseWith.Draft;
                int parent_id = Convert.ToInt32(this.tempRow["PARENT_ID"]);
                int oldExam_id;
                if (this.tempRow["EXAM_ID"] != DBNull.Value)
                    oldExam_id = Convert.ToInt32(this.tempRow["EXAM_ID"]);
                else
                    oldExam_id = 0;
                this.commentManager.UpdateDraftComment(Convert.ToInt32(this.tempRow["COMMENT_ID"])
                    , Convert.ToInt32(this.tempRow["PARENT_ID"]), oldExam_id
                    , this.REG_ID, this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow,"D");
                this.Close();
            }
        }
        #endregion

        #region Text Changed Event
        private void mmComment_TextChanged(object sender, EventArgs e)
        {
            //this.IsRecordChanged = true;
        }
        private void bteCommentTo_TextChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Contact Button LookUp
        private void bteCommentTo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.CanShowLookUp)
            {
                if (this.DialogMode == ShowDialogMode.Reply || this.DialogMode == ShowDialogMode.Draft)
                {
                    List<string> contactIds = new List<string>();
                    string ids = this.tempRow["COMMENT_TO_ID"].ToString();
                    string[] id_part = ids.Split(',');
                    foreach (string id in id_part)
                    {
                        if (id.Trim() != string.Empty)
                            contactIds.Add(id.Trim());
                    }
                    this.contactLookUp.SetStartSelectContact(contactIds);
                    
                }
                else if (this.DialogMode == ShowDialogMode.New)
                {
                    this.contactLookUp.SetStartSelectContact();
                }
                this.contactLookUp.ShowDialog();
            }
        }
        private void contactLookUp_OnContactLookUpClose(object sender, DataRow[] selectedContactDataRow)
        {
            if (selectedContactDataRow.Length > 0)
            {
                this.contactDataRow = selectedContactDataRow;
                string contacts = string.Empty;
                foreach (DataRow drContactTo in selectedContactDataRow)
                {
                    contacts += drContactTo["CONTACT_NAME"].ToString() + ", ";
                }
                this.bteCommentTo.Text = contacts;
            }
            else
            {
                this.contactDataRow = null;
                this.bteCommentTo.Text = string.Empty;
            }
        }
        #endregion

        #region On Close Event
        protected override void OnClosed(EventArgs e)
        {
            //this.tbBy.Text = string.Empty;
            this.tbSubject.Text = string.Empty;
            //this.cbExam.EditValue = 0;
            this.bteCommentTo.Text = string.Empty;
            this.mmComment.Text = string.Empty;
            this.contactLookUp.ClearSelectedRows();
           // this.cbExam.EditValueChanged -=new EventHandler(cbExam_EditValueChanged);
            this.tbSubject.TextChanged -=new EventHandler(tbSubject_TextChanged);
            base.OnClosed(e);
        }
        #endregion

        private void SaveToBufferData(DataRow commentRow)
        {
            this.tempRow = commentRow;
        }

        private void CanDoAction()
        {
            this.tbSubject.TextChanged += new EventHandler(tbSubject_TextChanged);
            //this.cbExam.EditValueChanged += new EventHandler(cbExam_EditValueChanged);
        }

        private void cbExam_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbSubject.Text.Trim())
                       && this.grdExam.EditValue.ToString() != "0" 
                       && !string.IsNullOrEmpty(this.grdExam.EditValue.ToString()))
            {
                if (DialogMode == ShowDialogMode.Open)
                {
                    this.btnCancel.Enabled = true;
                    this.btnReply.Enabled = false;
                }
                else if (DialogMode == ShowDialogMode.Reply)
                {
                    this.btnCancel.Enabled = true;
                }
                this.btnSend.Enabled = true;
                this.btnSaveDraft.Enabled = true;

            }
            else
            {
                if (DialogMode == ShowDialogMode.Open)
                    this.btnReply.Enabled = true;
                else
                    this.btnReply.Enabled = false;
                this.btnSend.Enabled = false;
                this.btnSaveDraft.Enabled = false;
                this.btnCancel.Enabled = false;
            }
        }

        private void tbSubject_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbSubject.Text.Trim())
                        && this.grdExam.EditValue.ToString() != "0"
                        && !string.IsNullOrEmpty(this.grdExam.EditValue.ToString()))
            {
                if (DialogMode == ShowDialogMode.Open)
                {
                    this.btnCancel.Enabled = true;
                    this.btnReply.Enabled = false;
                }
                else if (DialogMode == ShowDialogMode.Reply)
                {
                    this.btnCancel.Enabled = true;
                }
                this.btnSend.Enabled = true;
                this.btnSaveDraft.Enabled = true;

            }
            else
            {
                if (DialogMode == ShowDialogMode.Open)
                    this.btnReply.Enabled = true;
                else
                    this.btnReply.Enabled = false;
                this.btnSend.Enabled = false;
                this.btnSaveDraft.Enabled = false;
                this.btnCancel.Enabled = false;
            }
        }

        private void bteCommentTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.bteCommentTo.Text = string.Empty;
                this.contactDataRow = null;
            }
        }

        private string GetCommentText(int commentId)
        {
            string comment = string.Empty;
            DataSet dsCommentText = this.commentManager.GetCommentBody(commentId);
            if (dsCommentText.Tables.Count > 0)
            {
                DataRow[] commentTextRows = dsCommentText.Tables[0].Select("[IS_DELETED] = 'N'");
                foreach (DataRow drCommentTextRow in commentTextRows)
                {
                    //if (Convert.ToInt32(drCommentTextRow["COMMENT_ID"]) == commentId)
                    //{
                    //    comment += "\r\n\r\n\r\n";
                    //}
                    //comment += "\r\n--------------------------------------------------------------------------------------------------------------\r\n"
                    //       + drCommentTextRow["COMMENT_TEXT"].ToString()
                    //       + "\r\n\r\n[Comment By] " + drCommentTextRow["COMMENT_BY_NAME"]
                    //       + "\r\n[Comment On] " + drCommentTextRow["COMMENT_ON"]
                    //       + "\r\n--------------------------------------------------------------------------------------------------------------\r\n";

                    if (drCommentTextRow["COMMENT_ID"].ToString() == commentId.ToString())
                        comment += drCommentTextRow["COMMENT_TEXT"].ToString() + "\r\n[Comment By] " + drCommentTextRow["COMMENT_BY_NAME"] + "\r\n[Comment On] " + drCommentTextRow["COMMENT_ON"];

                }
            }
            return comment;
        }
        private string GetCommentText(int commentId,bool draft)
        {
            if (draft == false) return GetCommentText(commentId);
            string comment = string.Empty;
            DataSet dsCommentText = this.commentManager.GetCommentBody(commentId);
            if (dsCommentText.Tables.Count > 0)
            {
                DataRow[] commentTextRows = dsCommentText.Tables[0].Select("[IS_DELETED] = 'N'");
                foreach (DataRow drCommentTextRow in commentTextRows)
                    if(drCommentTextRow["COMMENT_ID"].ToString()==commentId.ToString())
                        comment += drCommentTextRow["COMMENT_TEXT"].ToString() + "\r\n";
            }
            return comment;
        }

        private void bteCommentTo_DoubleClick(object sender, EventArgs e)
        {
            if (this.CanShowLookUp)
            {
                if (this.DialogMode == ShowDialogMode.Reply || this.DialogMode == ShowDialogMode.Draft)
                {
                    List<string> contactIds = new List<string>();
                    string ids = this.tempRow["COMMENT_TO_ID"].ToString();
                    string[] id_part = ids.Split(',');
                    foreach (string id in id_part)
                    {
                        if (id.Trim() != string.Empty)
                            contactIds.Add(id.Trim());
                    }
                    this.contactLookUp.SetStartSelectContact(contactIds);

                }
                else if (this.DialogMode == ShowDialogMode.New)
                {
                    this.contactLookUp.SetStartSelectContact();
                }
                this.contactLookUp.ShowDialog();
            }
        }

        private void btnSaveEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSubject.Text.Trim()))
            {
                msg.ShowAlert("UID1307", env.CurrentLanguageID);
                tbSubject.Focus();
                return;
            }
            if (string.IsNullOrEmpty(bteCommentTo.Text.Trim()))
            {
                msg.ShowAlert("UID1301", env.CurrentLanguageID);
                bteCommentTo.Focus();
                return;
            }
            if (grdExam.EditValue == null || string.IsNullOrEmpty(grdExam.EditValue.ToString()))
            {
                msg.ShowAlert("UID1308", env.CurrentLanguageID);
                grdExam.Focus();
                return;
            }
            if (string.IsNullOrEmpty(mmComment.Text.Trim()))
            {
                msg.ShowAlert("UID1302", env.CurrentLanguageID);
                mmComment.Focus();
                return;
            }

            string s = msg.ShowAlert("UID1020", new GBLEnvVariable().CurrentLanguageID);
            if (s == "2")
            {
                int order_id = 0;
                int schedule_id = 0;
                int exam_id = 0;
                if (this.grdExam.EditValue.ToString() != "0" && this.grdExam.EditValue.ToString() != string.Empty)
                {
                    //DataRow objRow = ((DataRowView)this.cbExam.Properties.GetDataSourceRowByKeyValue(this.grdExam.EditValue)).Row;
                    DataRow objRow = dttStudy.Rows[Convert.ToInt32(grdExam.EditValue.ToString())];
                    exam_id = Convert.ToInt32(objRow["EXAM_ID"]);
                    if (objRow["ORDER_FROM"].Equals("Order"))
                        order_id = Convert.ToInt32(objRow["ORDER_ID"]);
                    else
                        schedule_id = Convert.ToInt32(objRow["ORDER_ID"]);


                }

                string priority = this.cbPriorityImage.EditValue.ToString();
                string commentText = string.Empty;
                if (this.commentTextSource != string.Empty)
                    commentText = this.mmComment.Text.Replace(this.commentTextSource, "");
                else
                    commentText = this.mmComment.Text;

                string subject = this.tbSubject.Text;
                if (string.IsNullOrEmpty(subject.Trim()))
                    subject = "(no subject)";

                if (this.DialogMode == ShowDialogMode.Reply)
                {
                    this.closeWith = CloseWith.Reply;
                    this.commentManager.AddComment(Convert.ToInt32(this.tempRow["COMMENT_ID"]), Convert.ToInt32(this.tempRow["REG_ID"]),
                        this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "S");
                }
                else if (this.DialogMode == ShowDialogMode.New)
                {
                    this.closeWith = CloseWith.New;
                    this.commentManager.AddComment(0, this.REG_ID,
                        this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "S");
                }
                else if (this.DialogMode == ShowDialogMode.Draft)
                {
                    this.closeWith = CloseWith.Draft;
                    int parent_id = Convert.ToInt32(this.tempRow["PARENT_ID"]);
                    int oldExam_id = 0;
                    if (this.tempRow["EXAM_ID"] != DBNull.Value)
                        oldExam_id = Convert.ToInt32(this.tempRow["EXAM_ID"]);

                    this.commentManager.UpdateDraftComment(Convert.ToInt32(this.tempRow["COMMENT_ID"])
                        , Convert.ToInt32(this.tempRow["PARENT_ID"]), oldExam_id
                        , this.REG_ID, this.EMP_ID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, "S");
                }
                this.Close();
            }
        }
    }
}