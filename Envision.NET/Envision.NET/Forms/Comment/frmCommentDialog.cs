using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic;
using Envision.Common;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Forms.Comment
{
    public partial class frmCommentDialog : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CommentMode mode;
        private QueryFromMode from;
        private int Id;
        public MyMessageBox msg;
        private static GBLEnvVariable env;
        private CommentManagement commentManager;
        private string hn;
        private DataTable dttStudy;
        private DataRow tempRow;
        private DataRow[] contactDataRow;
        private int examId;
        private int regId;
        private string commentTextSource;

        public frmCommentDialog()
        {
            InitializeComponent();
            mode = CommentMode.New;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            dttStudy = null;
            tempRow = null;
            contactDataRow = null;
            Id = 0;
            examId = 0;
            regId = 0;
            commentTextSource = string.Empty;
        }
        public frmCommentDialog(CommentMode Mode)
        {
            InitializeComponent();
            mode = Mode;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            hn = string.Empty;
            dttStudy = null;
            tempRow = null;
            contactDataRow = null;
            Id = 0;
            examId = 0;
            regId = 0;
            commentTextSource = string.Empty;
        }
        public frmCommentDialog(CommentMode Mode, string HN, DataRow RowData)
        {
            InitializeComponent();
            mode = Mode;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            hn = HN;
            dttStudy = null;
            tempRow = null;
            contactDataRow = null;
            Id = 0;
            examId = 0;
            regId = 0;
            commentTextSource = string.Empty;
            saveToBufferData(RowData);
        }
        public frmCommentDialog(CommentMode Mode, int ID, string HN, int RegID)
        {
            InitializeComponent();
            mode = Mode;
            from = QueryFromMode.Order;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            hn = HN;
            dttStudy = null;
            tempRow = null; 
            contactDataRow = null;
            Id = ID;
            examId = 0;
            commentTextSource = string.Empty;
        }
        public frmCommentDialog(CommentMode Mode, int ID, int ExamID, string HN, int RegID)
        {
            InitializeComponent();
            mode = Mode;
            Id = ID;
            examId = ExamID;
            from = QueryFromMode.Order;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            hn = HN;
            dttStudy = null;
            tempRow = null;
            contactDataRow = null;
            commentTextSource = string.Empty;
        }
        public frmCommentDialog(CommentMode Mode, int ID, string HN, int RegID, QueryFromMode From)
        {
            InitializeComponent();
            mode = Mode;
            Id = ID;
            examId = 0;
            regId = RegID;
            from = From;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            hn = HN;
            dttStudy = null;
            tempRow = null;
            contactDataRow = null;
            commentTextSource = string.Empty;
        }
        public frmCommentDialog(CommentMode Mode, int ID, int ExamID, string HN, int RegID, QueryFromMode From)
        {
            InitializeComponent();
            mode = Mode;
            Id = ID;
            examId = ExamID;
            regId = RegID;
            from = From;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            hn = HN;
            dttStudy = null;
            tempRow = null;
            contactDataRow = null;
            commentTextSource = string.Empty;
        }

        #region Ribbon bars.
        private void btnSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                string s = msg.ShowAlert("UID1303", new GBLEnvVariable().CurrentLanguageID);
                if (s == "2")
                    if (saveComments("S")) this.Close();
            }
        }
        private void btnReply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.tempRow != null)
            {
                mode = CommentMode.Reply;
                this.txtSubject.Text = "Re: " + this.txtSubject.Text;
                this.commentTextSource = "\r\n\r\n\r\n--------------------------------------------------------------------------------------------------------------\r\n" +
                                         this.getCommentText(Convert.ToInt32(tempRow["COMMENT_ID"])) +
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
                }
                enableDisableControlByMode();
                bteCommentTo.BackColor = Color.White;
            }
        }
        private void btnSaveDraft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                if (saveComments("D")) this.Close();
            }
        }
        private void btnSaveEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                string s = msg.ShowAlert("UID1020", new GBLEnvVariable().CurrentLanguageID);
                if (s == "2")
                {
                    mode = CommentMode.Draft;
                    if (saveComments("S")) this.Close();
                }
            }
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        private string getCommentText(int commentId)
        {
            string comment = string.Empty;
            DataSet dsCommentText = this.commentManager.GetCommentBody(commentId);
            if (dsCommentText.Tables.Count > 0)
            {
                DataRow[] commentTextRows = dsCommentText.Tables[0].Select("[IS_DELETED] = 'N'");
                foreach (DataRow drCommentTextRow in commentTextRows)
                {
                    if (drCommentTextRow["COMMENT_ID"].ToString() == commentId.ToString())
                        comment += drCommentTextRow["COMMENT_TEXT"].ToString() + "\r\n[Comment By] " + drCommentTextRow["COMMENT_BY_NAME"] + "\r\n[Comment On] " + drCommentTextRow["COMMENT_ON"];

                }
            }
            return comment;
        }
        private void bindContactName() {
            string contacts = string.Empty;
            foreach (DataRow drContactTo in contactDataRow)
            {
                contacts += drContactTo["CONTACT_NAME"].ToString() + ", ";
            }
            this.bteCommentTo.Text = contacts;
        }
        private void setContact(int commentId) {
            DataTable dtt = commentManager.GetCommentDetails(commentId);
            List<DataRow> lstRolw = new List<DataRow>();
            foreach (DataRow rowHandle in dtt.Rows) lstRolw.Add(rowHandle);
            contactDataRow = lstRolw.ToArray();
            bindContactName();
        }
        private void bteCommentTo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (mode == CommentMode.ReadOnly) return;
            frmContactDialog frm = null;
            if(this.contactDataRow!=null && this.contactDataRow.Length>0)
            {
                List<string> contactIds = new List<string>();
                foreach (DataRow row in contactDataRow) contactIds.Add(row["CONTACT_ID"].ToString());
                frm = new frmContactDialog(contactIds);
            }
            else 
                frm = new frmContactDialog();
            frm.ShowDialog();
            DataRow[] selectedContactDataRow = frm.GetContactDataRow();
            if (frm.DialogResult==DialogResult.OK &&  selectedContactDataRow.Length > 0)
            {
                this.contactDataRow = selectedContactDataRow;
                bindContactName();
            }
            else if (frm.DialogResult == DialogResult.Cancel)
            {
                this.contactDataRow = null;
                this.bteCommentTo.Text = string.Empty;
            }
            frm.Dispose();
        }
        
        private void loadDataToControl () {
            switch (mode) {
                case CommentMode.New:
                    loadModeNewData();
                    break;
                case CommentMode.Open:
                case CommentMode.Draft:
                case CommentMode.ReadOnly:
                case CommentMode.EditSend:
                    loadModeNewData();
                    mmComment.Text = tempRow["COMMENT_BODY"].ToString();
                    txtSubject.Text = tempRow["COMMENT_SUBJECT"].ToString();
                    examId = Convert.ToInt32(tempRow["EXAM_ID"].ToString());
                    if (tempRow["ORDER_ID"].ToString() == "0")
                        Id = Convert.ToInt32(tempRow["SCHEDULE_ID"].ToString());
                    else
                        Id = Convert.ToInt32(tempRow["ORDER_ID"].ToString());
                    int commentId = Convert.ToInt32(tempRow["COMMENT_ID"].ToString());
                    setContact(commentId);
                    break;
                case CommentMode.Reply:
                    loadModeNewData();
                    break;
            }
        }
        private void enableDisableControlByMode()
        {
            switch (mode)
            {
                case CommentMode.Draft:
                case CommentMode.New:
                    gSend.Visible = true;
                    gDraft.Visible = true;
                    gReply.Visible = true;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.txtSubject.Properties.ReadOnly = false;
                    this.btnSend.Enabled = true;
                    this.btnSaveDraft.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnReply.Enabled = false;
                    this.grdExam.Properties.ReadOnly = false;
                    this.cboPriority.Properties.ReadOnly = false;
                    this.cboPriority.SelectedIndex = 1;
                    this.mmComment.ReadOnly = false;
                    gReply.Visible = false;
                    break;
                case CommentMode.Open:
                    gSend.Visible = true;
                    gDraft.Visible = true;
                    gReply.Visible = true;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.grdExam.Properties.ReadOnly = true;
                    this.txtSubject.Properties.ReadOnly = true;
                    this.mmComment.ReadOnly = true;
                    this.btnSend.Enabled = false;
                    this.btnSaveDraft.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnReply.Enabled = true;
                    this.cboPriority.Properties.ReadOnly = true;
                    this.bteCommentTo.BackColor = Color.FromArgb(227, 239, 255);

                    gSend.Visible = false;
                    gDraft.Visible = false;
                    btnCancel.Enabled = true;
                    break;
                case CommentMode.ReadOnly:
                    gSend.Visible = false;
                    gDraft.Visible = false;
                    gReply.Visible = false;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.txtSubject.Properties.ReadOnly = true;
                    this.btnSend.Enabled = false;
                    this.btnSaveDraft.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnReply.Enabled = false;
                    this.grdExam.Properties.ReadOnly = true;
                    this.cboPriority.Properties.ReadOnly = true;
                    this.mmComment.ReadOnly = true;
                    this.bteCommentTo.BackColor = Color.FromArgb(227, 239, 255);
                    btnCancel.Enabled = true;
                    break;
                case CommentMode.Reply:
                    gSend.Visible = true;
                    gDraft.Visible = true;
                    gReply.Visible = true;
                    gCancel.Visible = true;
                    gEdit.Visible = false;
                    this.txtSubject.Properties.ReadOnly = false;
                    this.btnSaveDraft.Enabled = true;
                    this.btnSend.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnReply.Enabled = false;
                    this.grdExam.Properties.ReadOnly = true;
                    this.cboPriority.Properties.ReadOnly = false;
                    this.mmComment.ReadOnly = false;
                    this.bteCommentTo.BackColor = Color.FromArgb(227, 239, 255);
                    gReply.Visible = false;
                    break;
                case CommentMode.EditSend:
                    gSend.Visible = false;
                    gDraft.Visible = false;
                    gReply.Visible = false;
                    gCancel.Visible = true;
                    gEdit.Visible = true;
                    this.txtSubject.Properties.ReadOnly = false;
                    this.btnSend.Enabled = true;
                    this.btnSaveDraft.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnReply.Enabled = false;
                    this.grdExam.Properties.ReadOnly = false;
                    this.cboPriority.Properties.ReadOnly = false;
                    this.cboPriority.SelectedIndex = 1;
                    this.mmComment.ReadOnly = false;
                    gReply.Visible = false;
                    break;
            }
        }
        private void setDefaultExam() { 
            if (dttStudy != null && Id > 0)
            {
                for (int i = 0; i < dttStudy.Rows.Count; i++) {
                    if (dttStudy.Rows[i]["ORDER_ID"].ToString() == Id.ToString() && dttStudy.Rows[i]["EXAM_ID"].ToString() == examId.ToString()) {
                        grdExam.EditValue = i;
                        break;
                    }
                }
            }
        }
        private void frmCommentDialog_Load(object sender, EventArgs e)
        {
            loadDataToControl();
            enableDisableControlByMode();
            if(examId>0)setDefaultExam();
        }

        private void loadModeNewData() {
            dttStudy = new DataTable();
            dttStudy = this.commentManager.GetOrderByPatient(hn).Tables[0];
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

            this.commentTextSource += "\r\n\r\n\r\n";
            this.commentTextSource += "[Comment By] " + env.UserName + "\r\n[Comment On] " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            this.mmComment.Text = this.commentTextSource;
        }
        private void saveToBufferData(DataRow commentRow)
        {
            this.tempRow = commentRow;
        }

        private bool requireCheck() {
            if (string.IsNullOrEmpty(txtSubject.Text.Trim()))
            {
                msg.ShowAlert("UID1307", env.CurrentLanguageID);
                txtSubject.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(bteCommentTo.Text.Trim()))
            //{
            //    msg.ShowAlert("UID1301", env.CurrentLanguageID);
            //    bteCommentTo.Focus();
            //    return false;
            //}
            if (grdExam.EditValue == null || string.IsNullOrEmpty(grdExam.EditValue.ToString()))
            {
                msg.ShowAlert("UID1308", env.CurrentLanguageID);
                grdExam.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(mmComment.Text.Trim()))
            {
                msg.ShowAlert("UID1302", env.CurrentLanguageID);
                mmComment.Focus();
                return false;
            }
            return true;
        }
        private bool saveComments(string status) {
            

            
            int order_id = 0;
            int schedule_id = 0;
            int exam_id = 0;
            if (grdExam.EditValue != null && !string.IsNullOrEmpty(this.grdExam.EditValue.ToString()))
            {

                DataRow objRow = dttStudy.Rows[Convert.ToInt32(grdExam.EditValue.ToString())];
                exam_id = Convert.ToInt32(objRow["EXAM_ID"]);
                if (objRow["ORDER_FROM"].Equals("Order"))
                    order_id = Convert.ToInt32(objRow["ORDER_ID"]);
                else
                    schedule_id = Convert.ToInt32(objRow["ORDER_ID"]);
            }

            string priority = this.cboPriority.EditValue.ToString();
            string commentText = string.Empty;
            if (this.commentTextSource != string.Empty)
                commentText = this.mmComment.Text.Replace(this.commentTextSource, "");
            else
                commentText = this.mmComment.Text;

            string subject = this.txtSubject.Text;
            if (string.IsNullOrEmpty(subject.Trim()))
                subject = "(no subject)";

            if (mode == CommentMode.Reply)
            {
                this.commentManager.AddComment(Convert.ToInt32(this.tempRow["COMMENT_ID"]), Convert.ToInt32(this.tempRow["REG_ID"]),
                    env.UserID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, status);
            }
            else if (mode == CommentMode.New)
            {
                this.commentManager.AddComment(0, this.regId,
                    env.UserID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow, status);
            }
            else if (mode == CommentMode.Draft)
            {
                int parent_id = Convert.ToInt32(this.tempRow["PARENT_ID"]);
                int oldExam_id = 0;
                if (this.tempRow["EXAM_ID"] != DBNull.Value)
                    oldExam_id = Convert.ToInt32(this.tempRow["EXAM_ID"]);

                this.commentManager.UpdateDraftComment(Convert.ToInt32(this.tempRow["COMMENT_ID"])
                    , Convert.ToInt32(this.tempRow["PARENT_ID"]), oldExam_id
                    , this.regId, env.UserID, order_id, schedule_id, exam_id, priority, subject, commentText, this.contactDataRow,status);
            }
            return true;
           
        }
    }
}
