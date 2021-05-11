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

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Envision.NET.Forms.Comment
{
    

    public partial class frmComment : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string hn;
        private int regId;
        private int Id;
        private QueryFromMode queryFromMode;
        private CommentManagement commentManager;
        private DataTable dtInbox;
        private DataTable dtSend;
        private DataTable dtDraft;
        private DataTable dtTrash;
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private LevelType commentMode;
        private int firstRowcount = 0;

        public frmComment()
        {
            initializeValue();
            hn="xxxx";
            bindPatientLevelDataControl();
            hn = string.Empty;
            commentMode = LevelType.PatientLevel;
            rbPageStudyLevel.Visible = true;
        }
        public frmComment(string HN) {
            initializeValue();
            hn = HN;
            initializeByPatient();
            commentMode = LevelType.PatientLevel;
            rbPageStudyLevel.Visible = true;
        }
        public frmComment(string HN,int ID,QueryFromMode Mode) {
            initializeValue();
            if (Mode == QueryFromMode.None) return;
            queryFromMode = Mode;
            Id = ID;
            hn = HN;
            
            initializeByStudy();
            if (dtInbox != null && dtInbox.Rows.Count > 0) {
                DataRow rowHandle = dtInbox.Rows[0];
                tbExam.Text = rowHandle["EXAM"].ToString();
                tbExamDate.Text = rowHandle["EXAM_DT"].ToString();
                tbExam.Tag = rowHandle["EXAM_ID"].ToString();
            }
            commentMode = LevelType.StudyLevel;
            rbPagePatientLevel.Visible = true;
        }
        public frmComment(string HN, int ID,int DefaultExam,string StudyDate, QueryFromMode Mode)
        {
            initializeValue();
            if (Mode == QueryFromMode.None) return;
            queryFromMode = Mode;
            Id = ID;
            hn = HN;
            initializeByStudy();
            if (string.IsNullOrEmpty(tbExam.Text.Trim())) {
                DataRow[] rowHandle = RISBaseData.Ris_Exam().Select("EXAM_ID=" + DefaultExam);
                tbExam.Text = "[" + rowHandle[0]["EXAM_UID"].ToString() + "]" +  rowHandle[0]["EXAM_NAME"].ToString();
                tbExamDate.Text = StudyDate;
                tbExam.Tag = rowHandle[0]["EXAM_ID"].ToString();
            }
            commentMode = LevelType.StudyLevel;
            rbPagePatientLevel.Visible = true;
        }

        private void frmComment_Load(object sender, EventArgs e)
        {
            //if (commentMode == CommentMode.PatientLevel && tbHN.Properties.ReadOnly == false) {
            //    dtTrash = new DataTable();
            //    dtTrash = dtInbox.Clone();
            //    bindViewColumnTrash();
            //}
            tbHN.Focus();
            firstRowcount = viewInbox.RowCount;
        }
        
        private void rbControl_SelectedPageChanged(object sender, EventArgs e)
        {
            if (rbControl.SelectedPage == rbPageInbox)
            {
                tabCtrl.Top = tbExam.Bottom + 3;
                studyControlVisible(true);
                tabCtrl.SelectedTabPage = pageInbox;
                tabCtrl.Height = 365;
            }
            else {
                tabCtrl.Top = groupDemographic.Bottom + 3;
                studyControlVisible(false);
                tabCtrl.Height = 400;

                if (rbControl.SelectedPage == rbPageSend)
                    tabCtrl.SelectedTabPage = pageSend;
                else if (rbControl.SelectedPage == rbPageDraft)
                    tabCtrl.SelectedTabPage = pageDraft;
                else
                    tabCtrl.SelectedTabPage = pageTrash;
                    
            }
        }
        
        private void tbHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                hn = tbHN.Text.Trim();
                initializeByPatient();    
            }
        }

        private bool checkSelectRow() {
            bool flag = false;
            if (rbControl.SelectedPage == rbPageInbox)
            {
                foreach (DataRow rowHandle in dtInbox.Rows)
                    if (rowHandle["colCheck"].ToString() == "Y")
                    {
                        flag = true;
                        break;
                    }
            }
            else if (rbControl.SelectedPage == rbPageTrash) {
                foreach (DataRow rowHandle in dtTrash.Rows)
                    if (rowHandle["colCheck"].ToString() == "Y")
                    {
                        flag = true;
                        break;
                    }
            }
            else if (rbControl.SelectedPage == rbPageDraft) {
                foreach (DataRow rowHandle in dtDraft.Rows)
                    if (rowHandle["colCheck"].ToString() == "Y")
                    {
                        flag = true;
                        break;
                    }
            }
            else if (rbControl.SelectedPage == rbPageSend) {
                foreach (DataRow rowHandle in dtSend.Rows)
                    if (rowHandle["colCheck"].ToString() == "Y")
                    {
                        flag = true;
                        break;
                    }
            }
            return flag;
        }
        private void initializeValue()
        {
            InitializeComponent();
            queryFromMode = QueryFromMode.None;
            env = new GBLEnvVariable();
            commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            msg = new MyMessageBox();
            regId = 0;
        }
        private void studyControlVisible(bool flag) {
            tbExam.Visible = flag;
            tbExamDate.Visible = flag;
            btnOpen.Visible = flag;
            txtStudy.Visible = flag;
            txtDate.Visible = flag;
        }
        private void clearDataInControl()
        {
            tbHN.Text = string.Empty;
            tbName.Text = string.Empty;
            tbAge.Text = string.Empty;
            tbGender.Text = string.Empty;
            hn = string.Empty;
            Id = 0;
            queryFromMode = QueryFromMode.None;
            grdInbox.DataSource = null;
        }

        private void viewInbox_RowClick(object sender, RowClickEventArgs e)
        {
            if (viewInbox.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewInbox.GetDataRow(viewInbox.FocusedRowHandle);
            tbExam.Text = rowHandle["EXAM"].ToString();
            tbExamDate.Text = rowHandle["EXAM_DT"].ToString();
            tbExam.Tag = rowHandle["EXAM_ID"].ToString();
            if (rowHandle["SCHEDULE_ID"].ToString() == "0")
            {
                queryFromMode = QueryFromMode.Order;
                Id = Convert.ToInt32(rowHandle["ORDER_ID"].ToString());
            }
            else
            {
                queryFromMode = QueryFromMode.Schedule;
                Id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
            }
            //bindStudyLevelDataControl();
        }
        private void viewInbox_DoubleClick(object sender, EventArgs e)
        {
            if (viewInbox.FocusedRowHandle < 0) return;
            openCommentDialog();
            
            #region OLD_CODE.
            //if (string.IsNullOrEmpty(tbExam.Text.Trim()))
            //{
            //    if(msg.ShowAlert("UID1309",env.CurrentLanguageID)=="2")
            //    {
            //        DataRow rowHandle = viewInbox.GetDataRow(viewInbox.FocusedRowHandle);
            //        tbExam.Text = rowHandle["EXAM"].ToString();
            //        tbExamDate.Text = rowHandle["EXAM_DT"].ToString();
            //        tbExam.Tag = rowHandle["EXAM_ID"].ToString();
            //        if (rowHandle["SCHEDULE_ID"].ToString() == "0")
            //        {
            //            queryFromMode = QueryFromMode.Order;
            //            Id = Convert.ToInt32(rowHandle["ORDER_ID"].ToString());
            //        }
            //        else
            //        {
            //            queryFromMode = QueryFromMode.Schedule;
            //            Id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
            //        }
            //        bindStudyLevelDataControl();
            //    }
            //    else
            //    {
            //        CommentDialog frm = CommentDialog.GetCommentDialog();
            //        frm.SetCommentDialog(hn, regId, this.viewInbox.GetDataRow(viewInbox.FocusedRowHandle), CommentDialog.ShowDialogMode.Open);
            //        frm.Text = "Comment";
            //        frm.ShowDialog();

            //        DataRow drThreadRow = this.viewInbox.GetDataRow(this.viewInbox.FocusedRowHandle);
            //        if (drThreadRow["IS_UNREAD"].Equals("N"))
            //            this.commentManager.SetToReadComment(Convert.ToInt32(drThreadRow["COMMENT_ID"]), env.UserID);
            //        if (string.IsNullOrEmpty(tbExam.Text.Trim()))
            //            bindPatientLevelDataControl();
            //        else
            //            bindStudyLevelDataControl();
            //        frm.Dispose();
            //    }
            //}
            //else {
            //    CommentDialog frm = CommentDialog.GetCommentDialog();
            //    frm.SetCommentDialog(hn, regId, this.viewInbox.GetDataRow(viewInbox.FocusedRowHandle), CommentDialog.ShowDialogMode.Open);
            //    frm.Text = "Comment";
            //    frm.ShowDialog();

            //    DataRow drThreadRow = this.viewInbox.GetDataRow(this.viewInbox.FocusedRowHandle);
            //    if (drThreadRow["IS_UNREAD"].Equals("N"))
            //        this.commentManager.SetToReadComment(Convert.ToInt32(drThreadRow["COMMENT_ID"]), env.UserID);
            //    if (string.IsNullOrEmpty(tbExam.Text.Trim()))
            //        bindPatientLevelDataControl();
            //    else
            //        bindStudyLevelDataControl();
            //    frm.Dispose();
            //} 
            #endregion
        }
        private void viewInbox_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                DataRow dr = viewInbox.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr["IS_UNREAD"].Equals("N"))
                        e.Appearance.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                }
            }
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (viewInbox.FocusedRowHandle > -1)
            {
                DataRow dr = viewInbox.GetDataRow(viewInbox.FocusedRowHandle);
                if (dr["colCheck"].ToString() == "N")
                    dr["colCheck"] = "Y";
                else
                    dr["colCheck"] = "N";
            }
        }
        private void bindViewColumnInbox() {
            if (dtInbox == null) return;
            grdInbox.DataSource = null; 
            grdInbox.DataSource = dtInbox;

            viewInbox.OptionsView.ShowAutoFilterRow = true;
            for (int i = 0; i < viewInbox.Columns.Count; i++)
            {
                viewInbox.Columns[i].Visible = false;
                viewInbox.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewInbox.Columns["colCheck"].ColVIndex = 1;
            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            viewInbox.Columns["colCheck"].ColumnEdit = chk;
            viewInbox.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            viewInbox.Columns["colCheck"].Caption = " ";
            viewInbox.Columns["colCheck"].Width = 10;

            viewInbox.Columns["COMMENT_PRIORITY"].ColVIndex = 2;
            RepositoryItemImageComboBox rImcbBPView = new RepositoryItemImageComboBox();
            rImcbBPView.SmallImages = this.imgWL;
            rImcbBPView.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Low", 0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Medium", 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "High", 2)});
            rImcbBPView.Buttons.Clear();
            viewInbox.Columns["COMMENT_PRIORITY"].ColumnEdit = rImcbBPView;
            viewInbox.Columns["COMMENT_PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewInbox.Columns["COMMENT_PRIORITY"].Width = 10;
            viewInbox.Columns["COMMENT_PRIORITY"].Caption = " ";

            viewInbox.Columns["COMMENT_DT"].ColVIndex = 3;
            viewInbox.Columns["COMMENT_DT"].Caption = "Date";
            viewInbox.Columns["COMMENT_DT"].DisplayFormat.FormatString = "d";
            viewInbox.Columns["COMMENT_DT"].Width = 125;

            viewInbox.Columns["COMMENT_BY"].ColVIndex = 4;
            viewInbox.Columns["COMMENT_BY"].Caption = "From";
            viewInbox.Columns["COMMENT_BY"].Width = 150;

            viewInbox.Columns["COMMENT_SUBJECT"].ColVIndex = 5;
            viewInbox.Columns["COMMENT_SUBJECT"].Caption = "Subject";
            viewInbox.Columns["COMMENT_SUBJECT"].Width = 120;

            viewInbox.Columns["EXAM"].ColVIndex = 6;
            viewInbox.Columns["EXAM"].Caption = "Study";
            viewInbox.Columns["EXAM"].Width = 150;

            viewInbox.Columns["EXAM_DT"].ColVIndex = 7;
            viewInbox.Columns["EXAM_DT"].Caption = "Study Date";
            viewInbox.Columns["EXAM_DT"].DisplayFormat.FormatString = "d";
            viewInbox.Columns["EXAM_DT"].Width = 100;

            viewInbox.Columns["COMMENT_BODY"].ColVIndex = 8;
            viewInbox.Columns["COMMENT_BODY"].Caption = "Comment";
            viewInbox.Columns["COMMENT_BODY"].Width = 300;

           // viewInbox.FocusedRowHandle = -999997;
        }
        private void loadInboxData() {
            DataSet ds = new DataSet();
            ds = commentManager.GetCommentInBox(hn, env.UserID);
            dtInbox = new DataTable();
            dtInbox = ds.Tables[0].Copy();
            dtInbox.Columns.Add("colCheck", typeof(string));
            foreach (DataRow rowHandle in dtInbox.Rows)
            {
                rowHandle["colCheck"] = "N";
                int Id = Convert.ToInt32(rowHandle["COMMENT_ID"].ToString());
                rowHandle["COMMENT_TO"] = setContact(Id);
                rowHandle["COMMENT_TO_ID"] = setContactId(Id);
            }
            dtInbox.AcceptChanges();
        }

        private bool isCanDeleteComment()
        {
            bool flag = false;
            DataRow[] drRowSelect = dtSend.Select("[colCheck] = 'Y'");
            foreach (DataRow row in drRowSelect)
            {
                if (row["IS_UNREAD"].ToString() == "N")
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        private void viewSend_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                DataRow dr = viewSend.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr["IS_UNREAD"].Equals("Y"))
                        e.Appearance.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                }
            }
        }
        private void chkSend_CheckedChanged(object sender, EventArgs e)
        {
            if (viewSend.FocusedRowHandle > -1)
            {
                DataRow dr = viewSend.GetDataRow(viewSend.FocusedRowHandle);
                if (dr["colCheck"].ToString() == "N")
                    dr["colCheck"] = "Y";
                else
                    dr["colCheck"] = "N";
            }
        }
        private void viewSend_DoubleClick(object sender, EventArgs e)
        {
            if (viewSend.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewSend.GetDataRow(viewSend.FocusedRowHandle);
            frmCommentDialog dlg = null;
            if (rowHandle["IS_UNREAD"].ToString() == "Y") 
                dlg =new frmCommentDialog(CommentMode.EditSend, hn, rowHandle);
            else
                dlg =new frmCommentDialog(CommentMode.ReadOnly, hn, rowHandle);
            dlg.Text = "Comment";
            dlg.ShowDialog();
            dlg.Dispose();
            if (commentMode == LevelType.PatientLevel)
                bindPatientLevelDataControl();
            else
                bindStudyLevelDataControl();

        }
        private void bindViewColumnSend()
        {
            if (dtSend == null) return;
            grdSend.DataSource = null;
            grdSend.DataSource = dtSend;

            viewSend.OptionsView.ShowAutoFilterRow = true;
            for (int i = 0; i < viewSend.Columns.Count; i++)
            {
                viewSend.Columns[i].Visible = false;
                viewSend.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewSend.Columns["colCheck"].ColVIndex = 1;
            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chkSend_CheckedChanged);
            viewSend.Columns["colCheck"].ColumnEdit = chk;
            viewSend.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            viewSend.Columns["colCheck"].Caption = " ";
            viewSend.Columns["colCheck"].Width = 10;

            viewSend.Columns["COMMENT_PRIORITY"].ColVIndex = 2;
            RepositoryItemImageComboBox rImcbBPView = new RepositoryItemImageComboBox();
            rImcbBPView.SmallImages = this.imgWL;
            rImcbBPView.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Low", 0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Medium", 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "High", 2)});
            rImcbBPView.Buttons.Clear();
            viewSend.Columns["COMMENT_PRIORITY"].ColumnEdit = rImcbBPView;
            viewSend.Columns["COMMENT_PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewSend.Columns["COMMENT_PRIORITY"].Width = 10;
            viewSend.Columns["COMMENT_PRIORITY"].Caption = " ";

            viewSend.Columns["COMMENT_DT"].ColVIndex = 3;
            viewSend.Columns["COMMENT_DT"].Caption = "Date";
            viewSend.Columns["COMMENT_DT"].DisplayFormat.FormatString = "d";
            viewSend.Columns["COMMENT_DT"].Width = 125;

            viewSend.Columns["COMMENT_TO"].ColVIndex = 4;
            viewSend.Columns["COMMENT_TO"].Caption = "To";
            viewSend.Columns["COMMENT_TO"].Width = 150;

            viewSend.Columns["COMMENT_SUBJECT"].ColVIndex = 5;
            viewSend.Columns["COMMENT_SUBJECT"].Caption = "Subject";
            viewSend.Columns["COMMENT_SUBJECT"].Width = 120;

            viewSend.Columns["EXAM"].ColVIndex = 6;
            viewSend.Columns["EXAM"].Caption = "Study";
            viewSend.Columns["EXAM"].Width = 150;

            viewSend.Columns["EXAM_DT"].ColVIndex = 7;
            viewSend.Columns["EXAM_DT"].Caption = "Study Date";
            viewSend.Columns["EXAM_DT"].DisplayFormat.FormatString = "d";
            viewSend.Columns["EXAM_DT"].Width = 100;

            viewSend.Columns["COMMENT_BODY"].ColVIndex = 8;
            viewSend.Columns["COMMENT_BODY"].Caption = "Comment";
            viewSend.Columns["COMMENT_BODY"].Width = 300;
        }
        private void loadSendData() {
            DataSet ds = new DataSet();
            ds = commentManager.GetCommentInSend(hn, env.UserID);
            dtSend = new DataTable();
            dtSend = ds.Tables[0].Copy();
            dtSend.Columns.Add("colCheck", typeof(string));
            foreach (DataRow rowHandle in dtSend.Rows)
            {
                rowHandle["colCheck"] = "N";
                int Id = Convert.ToInt32(rowHandle["COMMENT_ID"].ToString());
                rowHandle["COMMENT_TO"] = setContact(Id);
                rowHandle["COMMENT_TO_ID"] = setContactId(Id);
            }
            dtSend.AcceptChanges();
        }

        private bool isEmptyRequestInSend()
        {
            bool flag = false;
            DataRow[] drRowSelect = dtDraft.Select("[colCheck] = 'Y'");
            foreach (DataRow row in drRowSelect)
            {
                if (string.IsNullOrEmpty(row["COMMENT_SUBJECT"].ToString()) || string.IsNullOrEmpty(row["COMMENT_TO_ID"].ToString()) ||
                    string.IsNullOrEmpty(row["EXAM_ID"].ToString()) || string.IsNullOrEmpty(row["COMMENT_BODY"].ToString()))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        private void viewDraft_DoubleClick(object sender, EventArgs e)
        {
            if (this.viewDraft.FocusedRowHandle > -1)
            {
                DataRow rowHandle = this.viewDraft.GetDataRow(this.viewDraft.FocusedRowHandle);
                frmCommentDialog dlg = new frmCommentDialog(CommentMode.Draft,hn,rowHandle);
                dlg.Text = "Comment";
                dlg.ShowDialog();
                dlg.Dispose();
                if (commentMode == LevelType.PatientLevel)
                    bindPatientLevelDataControl();
                else
                    bindStudyLevelDataControl();
            }
        }
        private void chkDraft_CheckedChanged(object sender, EventArgs e)
        {
            if (viewDraft.FocusedRowHandle > -1)
            {
                DataRow dr = viewDraft.GetDataRow(viewDraft.FocusedRowHandle);
                if (dr["colCheck"].ToString() == "N")
                    dr["colCheck"] = "Y";
                else
                    dr["colCheck"] = "N";
            }
        }
        private void bindViewColumnDraft() {
            if (dtDraft == null) return;
            grdDraft.DataSource = null;
            grdDraft.DataSource = dtDraft;

            viewDraft.OptionsView.ShowAutoFilterRow = true;
            for (int i = 0; i < viewDraft.Columns.Count; i++)
            {
                viewDraft.Columns[i].Visible = false;
                viewDraft.Columns[i].OptionsColumn.AllowEdit = false;
            }
            viewDraft.Columns["colCheck"].ColVIndex = 1;
            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chkDraft_CheckedChanged);
            viewDraft.Columns["colCheck"].ColumnEdit = chk;
            viewDraft.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            viewDraft.Columns["colCheck"].Caption = " ";
            viewDraft.Columns["colCheck"].Width = 10;

            viewDraft.Columns["COMMENT_PRIORITY"].ColVIndex = 2;
            RepositoryItemImageComboBox rImcbBPView = new RepositoryItemImageComboBox();
            rImcbBPView.SmallImages = this.imgWL;
            rImcbBPView.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Low", 0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Medium", 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "High", 2)});
            rImcbBPView.Buttons.Clear();
            viewDraft.Columns["COMMENT_PRIORITY"].ColumnEdit = rImcbBPView;
            viewDraft.Columns["COMMENT_PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewDraft.Columns["COMMENT_PRIORITY"].Width = 10;
            viewDraft.Columns["COMMENT_PRIORITY"].Caption = " ";

            viewDraft.Columns["COMMENT_DT"].ColVIndex = 3;
            viewDraft.Columns["COMMENT_DT"].Caption = "Date";
            viewDraft.Columns["COMMENT_DT"].DisplayFormat.FormatString = "d";
            viewDraft.Columns["COMMENT_DT"].Width = 125;

            viewDraft.Columns["COMMENT_TO"].ColVIndex = 4;
            viewDraft.Columns["COMMENT_TO"].Caption = "To";
            viewDraft.Columns["COMMENT_TO"].Width = 150;

            viewDraft.Columns["COMMENT_SUBJECT"].ColVIndex = 5;
            viewDraft.Columns["COMMENT_SUBJECT"].Caption = "Subject";
            viewDraft.Columns["COMMENT_SUBJECT"].Width = 150;

            viewDraft.Columns["EXAM"].ColVIndex = 6;
            viewDraft.Columns["EXAM"].Caption = "Study";
            viewDraft.Columns["EXAM"].Width = 150;

            viewDraft.Columns["EXAM_DT"].ColVIndex = 7;
            viewDraft.Columns["EXAM_DT"].Caption = "Study Date";
            viewDraft.Columns["EXAM_DT"].DisplayFormat.FormatString = "d";
            viewDraft.Columns["EXAM_DT"].Width = 120;

        }
        private void loadDraftData() {
            DataSet ds = new DataSet();
            ds = commentManager.GetCommentSaveDraft(hn, env.UserID);
            dtDraft = new DataTable();
            dtDraft = ds.Tables[0].Copy();
            dtDraft.Columns.Add("colCheck", typeof(string));
            foreach (DataRow rowHandle in dtDraft.Rows)
            {
                rowHandle["colCheck"] = "N";
                int Id = Convert.ToInt32(rowHandle["COMMENT_ID"].ToString());
                rowHandle["COMMENT_TO"] = setContact(Id);
                rowHandle["COMMENT_TO_ID"] = setContactId(Id);
            }
            dtDraft.AcceptChanges();
        }

        private void chkTrash_CheckedChanged(object sender, EventArgs e)
        {
            if (viewTrash.FocusedRowHandle > -1)
            {
                DataRow dr = viewTrash.GetDataRow(viewTrash.FocusedRowHandle);
                if (dr["colCheck"].ToString() == "N")
                    dr["colCheck"] = "Y";
                else
                    dr["colCheck"] = "N";
            }
        }
        private void bindViewColumnTrash()
        {
            if (dtTrash == null) return;
            grdTrash.DataSource = null;
            grdTrash.DataSource = dtTrash;

            viewTrash.OptionsView.ShowAutoFilterRow = true;
            for (int i = 0; i < viewTrash.Columns.Count; i++)
            {
                viewTrash.Columns[i].Visible = false;
                viewTrash.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewTrash.Columns["colCheck"].ColVIndex = 1;
            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged+=new EventHandler(chkTrash_CheckedChanged);
            viewTrash.Columns["colCheck"].ColumnEdit = chk;
            viewTrash.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            viewTrash.Columns["colCheck"].Caption = " ";
            viewTrash.Columns["colCheck"].Width = 10;

            viewTrash.Columns["COMMENT_PRIORITY"].ColVIndex = 2;
            RepositoryItemImageComboBox rImcbBPView = new RepositoryItemImageComboBox();
            rImcbBPView.SmallImages = this.imgWL;
            rImcbBPView.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Low", 0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Medium", 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "High", 2)});
            rImcbBPView.Buttons.Clear();
            viewTrash.Columns["COMMENT_PRIORITY"].ColumnEdit = rImcbBPView;
            viewTrash.Columns["COMMENT_PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewTrash.Columns["COMMENT_PRIORITY"].Width = 10;
            viewTrash.Columns["COMMENT_PRIORITY"].Caption = " ";

            viewTrash.Columns["COMMENT_DT"].ColVIndex = 3;
            viewTrash.Columns["COMMENT_DT"].Caption = "Date";
            viewTrash.Columns["COMMENT_DT"].DisplayFormat.FormatString = "d";
            viewTrash.Columns["COMMENT_DT"].Width = 125;

            viewTrash.Columns["COMMENT_BY"].ColVIndex = 4;
            viewTrash.Columns["COMMENT_BY"].Caption = "From";
            viewTrash.Columns["COMMENT_BY"].Width = 150;

            viewTrash.Columns["COMMENT_SUBJECT"].ColVIndex = 5;
            viewTrash.Columns["COMMENT_SUBJECT"].Caption = "Subject";
            viewTrash.Columns["COMMENT_SUBJECT"].Width = 120;

            viewTrash.Columns["EXAM"].ColVIndex = 6;
            viewTrash.Columns["EXAM"].Caption = "Study";
            viewTrash.Columns["EXAM"].Width = 150;

            viewTrash.Columns["EXAM_DT"].ColVIndex = 7;
            viewTrash.Columns["EXAM_DT"].Caption = "Study Date";
            viewTrash.Columns["EXAM_DT"].DisplayFormat.FormatString = "d";
            viewTrash.Columns["EXAM_DT"].Width = 100;

            viewTrash.Columns["COMMENT_BODY"].ColVIndex = 8;
            viewTrash.Columns["COMMENT_BODY"].Caption = "Comment";
            viewTrash.Columns["COMMENT_BODY"].Width = 300;
        }
        private void loadTrashData() {
            DataSet ds = new DataSet();
            ds = commentManager.GetCommentInTrash(hn, env.UserID);
            dtTrash = new DataTable();
            dtTrash = ds.Tables[0].Copy();
            dtTrash.Columns.Add("colCheck", typeof(string));
            foreach (DataRow rowHandle in dtTrash.Rows) rowHandle["colCheck"] = "N";
            dtTrash.AcceptChanges();
        }

        private void bindPatientLevelDataControl() {
            rbPagePatientLevel.Visible = false;
            rbPageStudyLevel.Visible = true;
            tbExam.Tag = null;
            tbExam.Text = string.Empty;
            tbExamDate.Text = string.Empty;
            Id = 0;

            loadInboxData();
            bindViewColumnInbox();

            loadSendData();
            bindViewColumnSend();

            loadTrashData();
            bindViewColumnTrash();

            loadDraftData();
            bindViewColumnDraft();

            if (dtInbox.Rows.Count > 0)
            {
                DataRow rowHandle = viewInbox.GetDataRow(0);
                tbExam.Text = rowHandle["EXAM"].ToString();
                tbExamDate.Text = rowHandle["EXAM_DT"].ToString();
                tbExam.Tag = rowHandle["EXAM_ID"].ToString();
                if (rowHandle["SCHEDULE_ID"].ToString() == "0")
                {
                    queryFromMode = QueryFromMode.Order;
                    Id = Convert.ToInt32(rowHandle["ORDER_ID"].ToString());
                }
                else
                {
                    queryFromMode = QueryFromMode.Schedule;
                    Id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
                }
                viewInbox.FocusedRowHandle = 0;
            }
            else
                viewInbox.FocusedRowHandle = -999997;
        }
        private void bindStudyLevelDataControl() {
            rbPagePatientLevel.Visible = true;
            rbPageStudyLevel.Visible = false;

            loadInboxData();
            DataTable dttClone = dtInbox.Clone();
            DataRow[] rows = null;
            if (queryFromMode == QueryFromMode.Order)
                rows = dtInbox.Select("ORDER_ID=" + Id);
            else
                rows = dtInbox.Select("SCHEDULE_ID=" + Id);
            foreach (DataRow row in rows)
                dttClone.Rows.Add(row.ItemArray);
            dttClone.AcceptChanges();
            dtInbox = dttClone;
            bindViewColumnInbox();
            tbExam.Tag = null;
            tbExam.Text = string.Empty;
            tbExamDate.Text = string.Empty;
           

            loadSendData();
            bindViewColumnSend();

            loadTrashData();
            bindViewColumnTrash();

            loadDraftData();
            bindViewColumnDraft();

            if (dtInbox.Rows.Count > 0)
            {
                DataRow rowHandle = viewInbox.GetDataRow(0);
                tbExam.Text = rowHandle["EXAM"].ToString();
                tbExamDate.Text = rowHandle["EXAM_DT"].ToString();
                tbExam.Tag = rowHandle["EXAM_ID"].ToString();
                if (rowHandle["SCHEDULE_ID"].ToString() == "0")
                {
                    queryFromMode = QueryFromMode.Order;
                    Id = Convert.ToInt32(rowHandle["ORDER_ID"].ToString());
                }
                else
                {
                    queryFromMode = QueryFromMode.Schedule;
                    Id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
                }
                viewInbox.FocusedRowHandle = 0;
            }
            else
                viewInbox.FocusedRowHandle = -999997;
        }

        private string setContact(int commentId)
        {
            DataTable dtt = commentManager.GetCommentDetails(commentId);
            string contacts = string.Empty;
            foreach (DataRow drContactTo in dtt.Rows)
                contacts += drContactTo["CONTACT_NAME"].ToString() + ", ";
            return contacts;
        }
        private string setContactId(int commentId)
        {
            DataTable dtt = commentManager.GetCommentDetails(commentId);
            string contacts = string.Empty;
            foreach (DataRow drContactTo in dtt.Rows)
                contacts += drContactTo["CONTACT_ID"].ToString() + ", ";
            return contacts;
        }

        private bool initializeDemographic() { 
            DataSet ds= commentManager.GetPatientDemographic(hn);
            if (Miracle.Util.Utilities.IsHaveData(ds))
            {
                tbHN.Text = ds.Tables[0].Rows[0]["HN"].ToString();
                tbName.Text = ds.Tables[0].Rows[0]["PATIENT_NAME"].ToString();
                tbAge.Text = ds.Tables[0].Rows[0]["AGE"].ToString();
                tbGender.Text = ds.Tables[0].Rows[0]["GENDER"].ToString();
                regId = Convert.ToInt32(ds.Tables[0].Rows[0]["REG_ID"].ToString());
                return true;
            }
            else
            {
                msg.ShowAlert("UID6011", env.CurrentLanguageID);
                string text = tbHN.Text;
                clearDataInControl();
                tbHN.Text = text;
                return false;
            }
        }
        private void initializeByPatient()
        {
            if (string.IsNullOrEmpty(hn)) return;
            tbExam.Text = string.Empty;
            tbExamDate.Text = string.Empty;
            if(initializeDemographic())bindPatientLevelDataControl();
            
        }
        private void initializeByStudy() {
            if (Id == 0) return;
            if (initializeDemographic())
                bindStudyLevelDataControl();
        }
          
        
        #region RibbonControl Buttons.
        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (dtInbox==null || dtInbox.Rows.Count == 0) return;
            if (btnSelect.Caption == "Select All")
            {
                btnSelect.Caption = "Unselect All";
                foreach (DataRow rowHandle in dtInbox.Rows) rowHandle["colCheck"] = "Y";
            }
            else
            {
                btnSelect.Caption = "Select All";
                foreach (DataRow rowHandle in dtInbox.Rows) rowHandle["colCheck"] = "N";
            }
            dtInbox.AcceptChanges();
        }
        
        private void btnNewComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn)) {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            frmCommentDialog dlg = null;
            if (string.IsNullOrEmpty(tbExam.Text.Trim()))
                dlg = new frmCommentDialog(CommentMode.New, Id, 0, hn, regId, queryFromMode);
                
            else 
                dlg = new frmCommentDialog(CommentMode.New, Id,Convert.ToInt32(tbExam.Tag.ToString()), hn,regId, queryFromMode);
            dlg.ShowDialog();
            dlg.Dispose();
            if (commentMode == LevelType.PatientLevel)
                bindPatientLevelDataControl();
            else
                bindStudyLevelDataControl();
        }

        private void btnMarkAsRead_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (dtInbox == null || dtInbox.Rows.Count == 0) return;
            if (checkSelectRow())
            {
                DataRow[] drMarkAsReads = dtInbox.Select("[colCheck] = 'Y'");
                foreach (DataRow drMarkAsRead in drMarkAsReads)
                {
                    string[] commentTo = drMarkAsRead["COMMENT_TO_ID"].ToString().Split(',');
                    if (commentTo != null && commentTo.Length > 0)
                    {
                        bool flag = true;
                        foreach (string comment in commentTo)
                        {
                            if (string.IsNullOrEmpty(comment)) continue;
                            if (comment.Trim() == env.UserID.ToString())
                            {
                                this.commentManager.SetToReadComment(Convert.ToInt32(drMarkAsRead["COMMENT_ID"]), env.UserID);
                                flag = false;
                                break;
                            }
                        }
                        if (flag) this.commentManager.SetMarkAsReadComment(drMarkAsRead, env.UserID, "C");
                    }
                }
                if (commentMode == LevelType.PatientLevel)
                    bindPatientLevelDataControl();
                else
                    bindStudyLevelDataControl();
            }
            else
                msg.ShowAlert("UID018", env.CurrentLanguageID);
        }
        private void btnMarkAsUnread_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (dtInbox == null || dtInbox.Rows.Count == 0) return;
            if (checkSelectRow())
            {
                DataRow[] drUnmarkRows = dtInbox.Select("[colCheck] = 'Y'");
                foreach (DataRow drUnmarkRow in drUnmarkRows)
                {
                    string[] commentTo = drUnmarkRow["COMMENT_TO_ID"].ToString().Split(',');
                    if (commentTo != null && commentTo.Length > 0)
                    {
                        bool flag = true;
                        foreach (string comment in commentTo)
                        {
                            if (string.IsNullOrEmpty(comment)) continue;
                            if (comment.Trim() == env.UserID.ToString())
                            {
                                this.commentManager.SetUnmarkAsReadComment(Convert.ToInt32(drUnmarkRow["COMMENT_ID"]), env.UserID);
                                flag = false;
                                break;
                            }
                        }
                        if (flag) this.commentManager.SetMarkAsReadComment(drUnmarkRow, env.UserID,"U");
                    }

                    
                }
                if (commentMode == LevelType.PatientLevel)
                    bindPatientLevelDataControl();
                else
                    bindStudyLevelDataControl();
            }
            else
                msg.ShowAlert("UID018", env.CurrentLanguageID);
        }

        private void btnTrash_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (dtInbox == null || dtInbox.Rows.Count == 0) return;
            if (checkSelectRow())
            {
                string result = msg.ShowAlert("UID1306", env.CurrentLanguageID);
                if (result == "2")
                {
                    DataRow[] drMarkAsReads = dtInbox.Select("[colCheck] = 'Y'");
                    foreach (DataRow drMarkAsRead in drMarkAsReads)
                    {
                        drMarkAsRead["colCheck"] = "N";
                        this.commentManager.SetCommentToTrash(Convert.ToInt32(drMarkAsRead["COMMENT_ID"]), env.UserID);
                        
                    }
                    if (commentMode == LevelType.PatientLevel)
                        bindPatientLevelDataControl();
                    else
                        bindStudyLevelDataControl();
                }
            }
            else
                msg.ShowAlert("UID018", env.CurrentLanguageID);
        }

        private void btnShowAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            loadInboxData();
            bindViewColumnInbox();
        }
        private void btnShowRead_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            loadInboxData();
            DataTable dttClone = dtInbox.Clone();
            DataRow[] rows = dtInbox.Select("IS_UNREAD='Y'");
            foreach (DataRow rowHandle in rows) {
                dttClone.Rows.Add(rowHandle.ItemArray);
                dttClone.AcceptChanges();
            }
            
            dtInbox = dttClone;
            bindViewColumnInbox();
        }
        private void btnShowUnread_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            loadInboxData();
            DataTable dttClone = dtInbox.Clone();
            DataRow[] rows = dtInbox.Select("IS_UNREAD='N'");
            foreach (DataRow rowHandle in rows)
            {
                dttClone.Rows.Add(rowHandle.ItemArray);
                dttClone.AcceptChanges();
            }

            dtInbox = dttClone;
            bindViewColumnInbox();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rbControl.SelectedPage == rbPageTrash) 
            {
                if (checkSelectRow())
                {
                    string result = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                    if (result == "2")
                    {
                        DataRow[] drTrashRowSelect = dtTrash.Select("[colCheck] = 'Y'");
                        foreach (DataRow drTrashRow in drTrashRowSelect)
                        {
                            this.commentManager.RemoveComment(Convert.ToInt32(drTrashRow["COMMENT_ID"]), env.UserID);

                        }
                        bindPatientLevelDataControl();
                    }
                }
                else
                    msg.ShowAlert("UID018", env.CurrentLanguageID);
            }
            else if (rbControl.SelectedPage == rbPageDraft) {
                if (checkSelectRow())
                {
                    string result = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                    if (result == "2")
                    {
                        DataRow[] drTrashRowSelect = dtDraft.Select("[colCheck] = 'Y'");
                        foreach (DataRow drTrashRow in drTrashRowSelect)
                        {
                            this.commentManager.RemoveComment(Convert.ToInt32(drTrashRow["COMMENT_ID"]), env.UserID);

                        }
                        bindPatientLevelDataControl();
                    }
                }
                else
                    msg.ShowAlert("UID018", env.CurrentLanguageID);
            }
            else if (rbControl.SelectedPage == rbPageSend) {
                if (checkSelectRow())
                {
                    if (isCanDeleteComment())
                    {
                        msg.ShowAlert("UID6014", env.CurrentLanguageID);
                        return;
                    }
                    string result = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                    if (result == "2")
                    {
                        DataRow[] drSendRowSelect = dtSend.Select("[colCheck] = 'Y'");
                        foreach (DataRow drSendRow in drSendRowSelect)
                        {
                            this.commentManager.RemoveComment(Convert.ToInt32(drSendRow["COMMENT_ID"]), env.UserID);

                        }
                        bindPatientLevelDataControl();
                    }
                }
                else
                    msg.ShowAlert("UID018", env.CurrentLanguageID);
            }
        }

        private void btnSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkSelectRow())
            {
                if (isEmptyRequestInSend())
                {
                    msg.ShowAlert("UID1403", env.CurrentLanguageID);
                    return;
                }
                string result = msg.ShowAlert("UID1303", env.CurrentLanguageID);
                if (result == "2")
                {
                    DataRow[] drRowSelect = dtDraft.Select("[colCheck] = 'Y'");
                    foreach (DataRow drRow in drRowSelect)
                    {
                        this.commentManager.SendCommentByDraft(Convert.ToInt32(drRow["COMMENT_ID"]), env.UserID);
                    }
                    if (commentMode == LevelType.PatientLevel)
                        bindPatientLevelDataControl();
                    else
                        bindStudyLevelDataControl();
                }
            }
            else
                msg.ShowAlert("UID018", env.CurrentLanguageID);
        }

        private void btnRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (dtTrash == null || dtTrash.Rows.Count == 0) return;
            if (checkSelectRow())
            {
                DataRow[] drTrashRowSelect = dtTrash.Select("colCheck = 'Y'");
                foreach (DataRow drTrashRow in drTrashRowSelect)
                    this.commentManager.RestoreCommentInTrash(Convert.ToInt32(drTrashRow["COMMENT_ID"]), env.UserID);
                if (commentMode == LevelType.PatientLevel)
                    bindPatientLevelDataControl();
                else
                    bindStudyLevelDataControl();
            }
            else
                msg.ShowAlert("UID6007", env.CurrentLanguageID);
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            commentMode = LevelType.PatientLevel;
            tbExam.Tag = null;
            tbExam.Text = string.Empty;
            tbExamDate.Text = string.Empty;
            Id = 0;
            bindPatientLevelDataControl();
        }

        private void btnStudyLevel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            commentMode = LevelType.StudyLevel;
            bindStudyLevelDataControl();
        }
        private void btnPatientLavel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(hn))
            {
                msg.ShowAlert("UID6006", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            commentMode = LevelType.PatientLevel;
            bindPatientLevelDataControl();
        }     
        
        private void openCommentDialog() 
        {
            //CommentDialog frm = CommentDialog.GetCommentDialog();
            //frm.SetCommentDialog(hn, regId, this.viewInbox.GetDataRow(viewInbox.FocusedRowHandle), CommentDialog.ShowDialogMode.Open);
            //frm.Text = "Comment";
            //frm.ShowDialog();
            //frm.Dispose();
            //DataRow drThreadRow = this.viewInbox.GetDataRow(this.viewInbox.FocusedRowHandle);
            //if (drThreadRow["IS_UNREAD"].Equals("N"))
            //{
            //    this.commentManager.SetToReadComment(Convert.ToInt32(drThreadRow["COMMENT_ID"]), env.UserID);
            //    drThreadRow["IS_UNREAD"] = "Y";
            //}

            DataRow rowHandle = this.viewInbox.GetDataRow(this.viewInbox.FocusedRowHandle);
            frmCommentDialog dlg = new frmCommentDialog(CommentMode.Open, hn, rowHandle);
            dlg.Text = "Comment";
            dlg.ShowDialog();
            dlg.Dispose();
            if (rowHandle["IS_UNREAD"].Equals("N"))
            {
                this.commentManager.SetToReadComment(Convert.ToInt32(rowHandle["COMMENT_ID"]), env.UserID);
                rowHandle["IS_UNREAD"] = "Y";
            }
            if (commentMode == LevelType.PatientLevel)
                bindPatientLevelDataControl();
            else
                bindStudyLevelDataControl();

        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (viewInbox.FocusedRowHandle > -1)
                openCommentDialog();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void frmComment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (firstRowcount == viewInbox.RowCount)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.OK;
        }
    }
}
