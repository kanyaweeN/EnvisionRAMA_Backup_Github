using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.Common;
using Envision.DataAccess.Select;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Envision.NET.Forms.EMR;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;

namespace Envision.NET.Forms.Dialog
{
    public enum PagesModes
    {
        Order, Schedule, XrayReq
    }
    public partial class frmMessageConversation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env;
        private MessageConversationManagement msgManagement;
        private int schedule_id, order_id, xrayreq_id;
        private int exam;
        private int comment;
        private string accession;
        private DataSet dsData;
        private DataTable dataGroupDetail;
        private string formParent;
        public PagesModes pageMode;
        public object objectCurrent;

        public frmMessageConversation()
        {
            InitializeComponent();
        }
        public frmMessageConversation(string Accession_no)
        {
            InitializeComponent();
            accession = Accession_no;
            pageMode = PagesModes.Order;
            objectCurrent = Accession_no;
        }
        public frmMessageConversation(int Schedule_id)
        {
            InitializeComponent();
            schedule_id = Schedule_id;
            objectCurrent = Schedule_id;
            pageMode = PagesModes.Schedule;

        }
        public frmMessageConversation(int Xrayreq_id, bool is_online)
        {
            InitializeComponent();
            xrayreq_id = Xrayreq_id;
            objectCurrent = Xrayreq_id;
            pageMode = PagesModes.XrayReq;

        }
        private void frmMessageConversation_Load(object sender, EventArgs e)
        {
            //dtData = new DataTable();
            DataTable dtPatient = new DataTable();
            dsData = new DataSet();
            env = new GBLEnvVariable();
            msgManagement = new MessageConversationManagement();

            layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.Size = new Size(495, 595);
            dataGroupDetail = new DataTable();
            dataGroupDetail.Columns.Add("COMMENT_ID");
            dataGroupDetail.Columns.Add("READER_ID");
            dataGroupDetail.AcceptChanges();

            switch (pageMode)
            {
                case PagesModes.Order:
                    dtPatient = msgManagement.getPatientDetail(accession);
                    break;
                case PagesModes.Schedule:
                    dtPatient = msgManagement.getPatientDetailByScheduleId(schedule_id);
                    break;
                case PagesModes.XrayReq:
                    dtPatient = msgManagement.getPatientDetailByXrayreq(xrayreq_id);
                    break;
            }
            foreach (DataRow row in dtPatient.Rows)
            {
                lblHN.Text = row["HN"].ToString();
                lblGender.Text = row["GENDER"].ToString();
                lblName.Text = row["PATIENT_NAME"].ToString();
                chkComboExam.Properties.Items.Add(Convert.ToInt32(row["EXAM_ID"].ToString()), row["EXAM"].ToString(), CheckState.Checked, true);
            }
            if (dtPatient.Rows.Count == 1)
            {
                chkComboExam.Properties.ReadOnly = true;
                chkComboExam.Properties.BorderStyle = BorderStyles.NoBorder;
                chkComboExam.Properties.AllowFocused = false;
            }
            else
            {
                chkComboExam.Properties.ReadOnly = false;
                chkComboExam.Properties.BorderStyle = BorderStyles.Default;
                chkComboExam.Properties.AllowFocused = true;
            }


            if (Miracle.Util.Utilities.IsHaveData(dsData))
            {
                comment = Convert.ToInt32(dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1]["COMMENT_ID"]);


                switch (pageMode)
                {
                    case PagesModes.Order:
                        msgManagement.updateReaderMessage(env.UserID, comment, accession);
                        dataGroupDetail = msgManagement.getEmpCommentedAllByOrder(accession);
                        break;
                    case PagesModes.Schedule:
                        msgManagement.updateReaderMessage(env.UserID, comment, schedule_id, false);
                        dataGroupDetail = msgManagement.getEmpCommentedAllBySchedule(schedule_id);
                        break;
                    case PagesModes.XrayReq:
                        msgManagement.updateReaderMessage(env.UserID, comment, xrayreq_id, true);
                        dataGroupDetail = msgManagement.getEmpCommentedAllByXrayreq(xrayreq_id);
                        break;
                }
            }
            else
            {
                dataGroupDetail.Rows.Add(0, env.UserID);
            }

            barStaticTxtCountUser.Caption = dataGroupDetail.Rows.Count.ToString();

            viewMessage.MakeRowVisible(viewMessage.FocusedRowHandle, false);
            viewMessage.SelectRow(viewMessage.FocusedRowHandle);
            this.ActiveControl = memoMessage;
            timer1.Start();
        }
        public DialogResult ShowDialog(string parent_form)
        {
            this.ShowDialog();
            //if (!CheckOpened(this.Text))
            //{
            //    formParent = parent_form;
            //    this.Show();
            //}
            //return DialogResult.Cancel;
            return DialogResult.OK;
        }

        private DataTable getExamId()
        {
            DataTable tbExam = new DataTable();
            tbExam.Columns.Add("EXAM_ID");
            string examId = chkComboExam.EditValue.ToString();
            string[] newExamIds = examId.Split(',');
            foreach (string newExamId in newExamIds)
            {
                if (!string.IsNullOrEmpty(newExamId))
                {
                    tbExam.Rows.Add(newExamId);
                }
            }
            return tbExam;
        }
        private DataTable showData()
        {
            DataTable dtTemp = new DataTable();
            switch (pageMode)
            {
                case PagesModes.Order:
                    dtTemp = msgManagement.getMessageOrder(accession);
                    break;
                case PagesModes.Schedule:
                    if (msgManagement.checkMessageSchedule(schedule_id, chkComboExam.EditValue.ToString()))
                    {
                        dtTemp.Merge(msgManagement.getMessageSchedule(schedule_id, 0));
                    }
                    else
                    {
                        foreach (CheckedListBoxItem items in chkComboExam.Properties.GetItems())
                        {
                            if (items.CheckState == CheckState.Checked)
                            {
                                exam = Convert.ToInt32(items.Value.ToString());
                                dtTemp.Merge(msgManagement.getMessageSchedule(schedule_id, exam));
                            }
                        }
                    }
                    break;
                case PagesModes.XrayReq:
                    foreach (CheckedListBoxItem items in chkComboExam.Properties.GetItems())
                    {
                        if (items.CheckState == CheckState.Checked)
                        {
                            exam = Convert.ToInt32(items.Value.ToString());
                            dtTemp.Merge(msgManagement.getMessageXrayreq(xrayreq_id, exam));
                        }
                    }
                    break;
            }

            return dtTemp;
        }

        private void getData()
        {
            dsData = msgManagement.getResultMessage(showData(), env.UserID);
            grdMessage.DataSource = dsData.Tables[0];
            this.grdMessage.ForceInitialize();
            this.viewMessage.MoveLast();
            this.viewMessage.MoveLastVisible();
        }
        private void setGridColumns()
        {
            grdMessage.ForceInitialize();

            viewMessage.OptionsView.RowAutoHeight = true;
            viewMessage.OptionsView.ShowHorzLines = false;
            viewMessage.OptionsView.ColumnAutoWidth = false;

            for (int i = 0; i < viewMessage.Columns.Count; i++)
            {
                viewMessage.Columns[i].Visible = false;
            }

            viewMessage.Columns["CREATED_ON"].GroupIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memOther = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            memOther.ScrollBars = ScrollBars.None;
            memOther.LinesCount = 0;
            viewMessage.Columns["OTHER"].Caption = "Sender";
            viewMessage.Columns["OTHER"].Visible = true;
            viewMessage.Columns["OTHER"].OptionsColumn.ReadOnly = true;
            viewMessage.Columns["OTHER"].OptionsColumn.AllowEdit = false;
            viewMessage.Columns["OTHER"].OptionsColumn.AllowFocus = false;
            viewMessage.Columns["OTHER"].ColumnEdit = memOther;
            viewMessage.Columns["OTHER"].Width = 97;
            viewMessage.Columns["OTHER"].VisibleIndex = 1;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memTxtOther = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            memTxtOther.ScrollBars = ScrollBars.None;
            memTxtOther.LinesCount = 0;
            viewMessage.Columns["TEXT_OTHER"].Caption = "TEXT_OTHER";
            viewMessage.Columns["TEXT_OTHER"].Visible = true;
            viewMessage.Columns["TEXT_OTHER"].OptionsColumn.ReadOnly = true;
            viewMessage.Columns["TEXT_OTHER"].OptionsColumn.AllowEdit = true;
            viewMessage.Columns["TEXT_OTHER"].OptionsColumn.AllowFocus = true;
            viewMessage.Columns["TEXT_OTHER"].ColumnEdit = memTxtOther;
            viewMessage.Columns["TEXT_OTHER"].Width = 140;
            viewMessage.Columns["TEXT_OTHER"].VisibleIndex = 2;


            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit mem = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            mem.ScrollBars = ScrollBars.None;
            mem.LinesCount = 0;
            viewMessage.Columns["TEXT_ME"].Caption = "TEXT_ME";
            viewMessage.Columns["TEXT_ME"].Visible = true;
            viewMessage.Columns["TEXT_ME"].OptionsColumn.ReadOnly = true;
            viewMessage.Columns["TEXT_ME"].OptionsColumn.AllowEdit = true;
            viewMessage.Columns["TEXT_ME"].OptionsColumn.AllowFocus = true;
            viewMessage.Columns["TEXT_ME"].ColumnEdit = mem;
            viewMessage.Columns["TEXT_ME"].Width = 140;
            //viewMessage.Columns["TEXT_ME"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            viewMessage.Columns["TEXT_ME"].VisibleIndex = 3;

            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memMe = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            memMe.ScrollBars = ScrollBars.None;
            memMe.LinesCount = 0;
            viewMessage.Columns["ME"].Caption = "Me";
            viewMessage.Columns["ME"].Visible = true;
            viewMessage.Columns["ME"].OptionsColumn.ReadOnly = true;
            viewMessage.Columns["ME"].OptionsColumn.AllowEdit = false;
            viewMessage.Columns["ME"].OptionsColumn.AllowFocus = false;
            viewMessage.Columns["ME"].ColumnEdit = memMe;
            viewMessage.Columns["ME"].Width = 77;
            //viewMessage.Columns["ME"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            viewMessage.Columns["ME"].VisibleIndex = 4;

        }
        private void getDataTemplate()
        {
            grdTemplate.DataSource = msgManagement.getDataTemplate();
            setGridColumnsDataTemplate();
        }
        private void setGridColumnsDataTemplate()
        {
            grdTemplate.ForceInitialize();
            for (int i = 0; i < viewTemplate.Columns.Count; i++)
            {
                viewTemplate.Columns[i].Visible = false;
            }

            viewTemplate.Columns["GEN_TITLE"].Caption = "Title";
            viewTemplate.Columns["GEN_TITLE"].Visible = true;
            viewTemplate.Columns["GEN_TITLE"].Width = 62;
            viewTemplate.Columns["GEN_TITLE"].VisibleIndex = 1;

        }

        private void viewMessage_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "CREATED_ON")
                e.Appearance.ForeColor = Color.Gray;

            if (e.Column.FieldName == "OTHER")
                e.Appearance.ForeColor = Color.Blue;

            if (e.Column.FieldName == "TEXT_OTHER")            
                e.Appearance.ForeColor = Color.Blue;             
            
            if (e.Column.FieldName == "ME")
                e.Appearance.ForeColor = Color.Indigo;

            if (e.Column.FieldName == "TEXT_ME")            
                e.Appearance.ForeColor = Color.Indigo;               

            DataRow row = viewMessage.GetDataRow(e.RowHandle);
            if (row["MSG_STATUS"].ToString() == "Del")            
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Strikeout);
            
        }
        private void viewMessage_EndGrouping(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).ExpandAllGroups();
        }
        private void viewMessage_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            (e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds = Rectangle.Empty;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.FieldName == "CREATED_ON")
            {
                info.Appearance.ForeColor = Color.Gray;
            }
        }
        private void viewMessage_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            e.Allow = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (getExamId().Rows.Count > 0)
            {
                timer1.Stop();

                if (backgroundWorker1.IsBusy == false)
                    backgroundWorker1.RunWorkerAsync();
                else
                    timer1.Start();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable chkData = (DataTable)grdMessage.DataSource;
            DataSet getMessage = msgManagement.getResultMessage(showData(), env.UserID);

            if (chkData.Rows.Count != getMessage.Tables[0].Rows.Count)
            {
                e.Result = getMessage;
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                System.Action a = () =>
                    {
                        this.dsData = (DataSet)e.Result;
                        this.grdMessage.DataSource = this.dsData.Tables[0];
                        setGridColumns();
                    };
                this.grdMessage.Invoke(a);
                this.grdMessage.ForceInitialize();
                this.viewMessage.MakeRowVisible(viewMessage.FocusedRowHandle, false);
                this.viewMessage.SelectRow(viewMessage.FocusedRowHandle);
                this.viewMessage.MoveLast();
                this.viewMessage.MoveLastVisible();

            }
            timer1.Start();
        }

        private void getSummaryPopup()
        {
            frmPopupOrderOrScheduleSummary ordSummary = new frmPopupOrderOrScheduleSummary();

            switch (pageMode)
            {
                case PagesModes.Order:
                    ordSummary.ShowDialog(false, accession);
                    break;
                case PagesModes.Schedule:
                    ordSummary.ShowDialog(false, lblHN.Text, schedule_id, exam, frmPopupOrderOrScheduleSummary.PagesModes.Schedule, false);
                    break;
                case PagesModes.XrayReq:
                    ordSummary.ShowDialog(false, lblHN.Text, xrayreq_id, exam, frmPopupOrderOrScheduleSummary.PagesModes.Order, false);
                    break;
            }
        }
        private void btnOrderSummary_Click(object sender, EventArgs e)
        {
            getSummaryPopup();
        }
        private void barbtnOrderSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getSummaryPopup();
        }
        private void getTemplateComment()
        {
            if (layoutTemplate.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.Size = new Size(747, 595);
                getDataTemplate();
            }
            else
            {
                layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.Size = new Size(495, 595);
            }
        }
        private void btnTemplate_Click(object sender, EventArgs e)
        {
            getTemplateComment();
        }
        private void barbtnTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getTemplateComment();
        }
        private void barbtnGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GroupEmpMessageConversation frmGroup = new GroupEmpMessageConversation();
            frmGroup.dataGroupDetail = dataGroupDetail;
            frmGroup.ShowDialog();

            DataView view = new DataView(frmGroup.dataGroupDetail);
            dataGroupDetail = view.ToTable(true, "READER_ID");
            barStaticTxtCountUser.Caption = dataGroupDetail.Rows.Count.ToString();

        }
        private void grdTemplate_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(memoMessage.Text))
            {
                memoMessage.Text = memoMessage.Text + " " + viewTemplate.GetRowCellValue(viewTemplate.FocusedRowHandle, "GEN_TEXT").ToString();
            }
            else
            {
                memoMessage.Text = viewTemplate.GetRowCellValue(viewTemplate.FocusedRowHandle, "GEN_TEXT").ToString();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (string.IsNullOrEmpty(memoMessage.Text)) return;
            if (getExamId().Rows.Count > 0)
            {
                switch (pageMode)
                {
                    case PagesModes.Order:
                        comment = msgManagement.createdNewMessageForOrder(env.UserID, memoMessage.Text, accession);
                        break;
                    case PagesModes.Schedule:
                        foreach (DataRow drtbExam in getExamId().Rows)
                        {
                            if (!string.IsNullOrEmpty(drtbExam["EXAM_ID"].ToString()))
                            {
                                exam = Convert.ToInt32(drtbExam["EXAM_ID"].ToString());
                                comment = msgManagement.createdNewMessageForSchedule(env.UserID, memoMessage.Text, schedule_id, exam);
                            }
                        }
                        break;
                    case PagesModes.XrayReq:
                        foreach (DataRow drtbExam in getExamId().Rows)
                        {
                            if (!string.IsNullOrEmpty(drtbExam["EXAM_ID"].ToString()))
                            {
                                exam = Convert.ToInt32(drtbExam["EXAM_ID"].ToString());
                                comment = msgManagement.createdNewMessageForXrayreq(env.UserID, memoMessage.Text, xrayreq_id, exam);
                            }
                        }
                        break;
                }

                insertEmpInGroup();
                getData();
                setGridColumns();
                memoMessage.Text = "";
            }
            else
            {
                MyMessageBox msg = new MyMessageBox();
                msg.ShowAlert("UID1029", new GBLEnvVariable().CurrentLanguageID);
            }
            viewMessage.MakeRowVisible(viewMessage.FocusedRowHandle, false);
            viewMessage.SelectRow(viewMessage.FocusedRowHandle);
            timer1.Start();
        }

        private void insertEmpInGroup()
        {
            if (dataGroupDetail.Rows.Count > 0)
            {

                foreach (DataRow dr in dataGroupDetail.Rows)
                {
                    if (Convert.ToInt32(dr["READER_ID"].ToString()) != env.UserID)
                    {
                        ProcessAddRISCommentsystemAlert processAlert = new ProcessAddRISCommentsystemAlert();
                        processAlert.RIS_COMMENTSYSTEMALERT.COMMENT_ID = comment;
                        processAlert.RIS_COMMENTSYSTEMALERT.READER_ID = Convert.ToInt32(dr["READER_ID"].ToString());
                        processAlert.RIS_COMMENTSYSTEMALERT.CREATED_BY = env.UserID;
                        processAlert.RIS_COMMENTSYSTEMALERT.EXAM_ID = exam;

                        switch (pageMode)
                        {
                            case PagesModes.Order:
                                processAlert.RIS_COMMENTSYSTEMALERT.ACCESSION_NO = accession;
                                processAlert.createdAlertMessageByAccession();
                                break;
                            case PagesModes.Schedule:
                                processAlert.RIS_COMMENTSYSTEMALERT.SCHEDULE_ID = schedule_id;
                                processAlert.createdAlertMessageBySchedule();
                                break;
                            case PagesModes.XrayReq:
                                processAlert.RIS_COMMENTSYSTEMALERT.XRAYREQ_ID = xrayreq_id;
                                processAlert.createdAlertMessageByXrayreq();
                                break;
                            default:
                                break;
                        }

                        #region Sent Alert Message Popup
                        ProcessCheckSession chksession = new ProcessCheckSession();
                        chksession.Invoke(Convert.ToInt32(dr["READER_ID"].ToString()), 1);
                        DataTable dtcheck = chksession.ResultSet.Tables[0];
                        if (dtcheck.Rows.Count > 0)
                        {
                            string killip = dtcheck.Rows[0]["IP_ADDR_CURR"].ToString();
                            if (killip != "1.1.1.1")
                            {
                                Envision.WebService.EnvisionWebService kill = new Envision.WebService.EnvisionWebService(env.WebServiceIP);
                                kill.SentClientSession(killip, "CommentAlert");
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        private void chkComboExam_EditValueChanged(object sender, EventArgs e)
        {
            if (getExamId().Rows.Count <= 0)
            {
                grdMessage.DataSource = null;
            }
            else
            {
                getData();
                setGridColumns();
            }

            viewMessage.MakeRowVisible(viewMessage.FocusedRowHandle, false);
            viewMessage.SelectRow(viewMessage.FocusedRowHandle);

        }

        private void frmMessageConversation_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CheckClose("Summary");
            this.DialogResult = DialogResult.OK;
            formRefresh(formParent);
        }
        private void formRefresh(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    frm.Refresh();
                }
            }
        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    frm.Focus();
                    return true;
                }
            }
            return false;
        }
        private bool CheckClose(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    frm.Close();
                    return true;
                }
            }
            return false;
        }

        private void cancelMsgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewMessage.FocusedRowHandle >= 0)
            {
                timer1.Stop();

                DataRow row = viewMessage.GetDataRow(viewMessage.FocusedRowHandle);
                msgManagement = new MessageConversationManagement();
                msgManagement.updateMessageStatus(Convert.ToInt32(row["COMMENT_ID"]),"Del", env.UserID);
                string copyText = Convert.ToString(row["MSG_TEXT"]);
                
                
                getData();
                timer1.Start();
            }
        }
        private void undoMsgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewMessage.FocusedRowHandle >= 0)
            {
                timer1.Stop();

                DataRow row = viewMessage.GetDataRow(viewMessage.FocusedRowHandle);
                msgManagement = new MessageConversationManagement();
                msgManagement.updateMessageStatus(Convert.ToInt32(row["COMMENT_ID"]), "New", env.UserID);

                getData();
                timer1.Start();
            }
        }

        private void menuMessage_Opening(object sender, CancelEventArgs e)
        {
            
            if (viewMessage.FocusedRowHandle >= 0 )
            {
                DataRow row = viewMessage.GetDataRow(viewMessage.FocusedRowHandle);

                if (row["MSG_STATUS"].ToString() == "Del" && row["SENDER_ID"].ToString() == env.UserID.ToString())
                {
                    cancelMsgToolStripMenuItem.Visible = false;
                    undoMsgToolStripMenuItem.Visible = true;
                }
                else if (row["MSG_STATUS"].ToString() == "New" && row["SENDER_ID"].ToString() == env.UserID.ToString())
                {
                    cancelMsgToolStripMenuItem.Visible = true;
                    undoMsgToolStripMenuItem.Visible = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
            viewMessage.MakeRowVisible(-1, false);
            viewMessage.SelectRow(-1);
        }

    }
}