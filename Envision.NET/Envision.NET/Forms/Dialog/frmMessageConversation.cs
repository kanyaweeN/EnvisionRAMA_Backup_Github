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
using Envision.BusinessLogic.ProcessUpdate;
using Miracle.Util;
using Envision.BusinessLogic.ProcessDelete;

namespace Envision.NET.Forms.Dialog
{

    public partial class frmMessageConversation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env;
        private HIS_Patient _hisPatientWebService;
        private MessageConversationManagement msgManagement;
        private DevExpress.Utils.WaitDialogForm waitDialog;

        private int schedule_id, order_id, xrayreq_id;
        private int reg_id;
        private int exam;
        private int comment;
        private string accession;
        private string hn;
        private DateTime caseDatetime;
        private DataSet dsData;
        private DataTable dataGroupDetail;
        private string formParent;
        private Size expand = new Size(930, 600);
        private Size collapse = new Size(505, 600);
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
            LookUpSelect sel = new LookUpSelect();
            DataSet chkDs = sel.SelectOrderIdByAccession(Accession_no);
            if (Utilities.IsHaveData(chkDs))
            {
                order_id = Convert.ToInt32(chkDs.Tables[0].Rows[0]["ORDER_ID"]);
                reg_id = Convert.ToInt32(chkDs.Tables[0].Rows[0]["REG_ID"]);
                hn = chkDs.Tables[0].Rows[0]["HN"].ToString();
            }
        }
        public frmMessageConversation(int Schedule_id)
        {
            InitializeComponent();
            schedule_id = Schedule_id;
            objectCurrent = Schedule_id;
            pageMode = PagesModes.Schedule;
            LookUpSelect sel = new LookUpSelect();
            DataSet chkDs = sel.SelectRegIdByScheduleId(Schedule_id);
            if (Utilities.IsHaveData(chkDs))
            {
                reg_id = Convert.ToInt32(chkDs.Tables[0].Rows[0]["REG_ID"]);
                hn = chkDs.Tables[0].Rows[0]["HN"].ToString();
            }
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
            this._hisPatientWebService = new HIS_Patient();

            layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.Size = collapse;
            dataGroupDetail = new DataTable();
            dataGroupDetail.Columns.Add("COMMENT_ID");
            dataGroupDetail.Columns.Add("READER_ID");
            dataGroupDetail.AcceptChanges();
            showContrastDetail();
            LoadAllergyData();

            switch (pageMode)
            {
                case PagesModes.Order:
                    dtPatient = msgManagement.getPatientDetail(accession);
                    loadRISRiskDataOrder(order_id);
                    break;
                case PagesModes.Schedule:
                    dtPatient = msgManagement.getPatientDetailByScheduleId(schedule_id);
                    loadRISRiskDataSchedule(schedule_id);
                    break;
                case PagesModes.XrayReq:
                    dtPatient = msgManagement.getPatientDetailByXrayreq(xrayreq_id);
                    loadRISRiskDataRequestXray(xrayreq_id);
                    break;
            }
            foreach (DataRow row in dtPatient.Rows)
            {
                caseDatetime = Convert.ToDateTime(row["CASE_DATETIME"]);
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
            getDataTemplate();
            if (layoutTemplate.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                tabPageControl.SelectedTabPage = tabTemplate;
                layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.Size = expand;
            }
            else
            {
                if (layoutTemplate.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always && tabPageControl.SelectedTabPageIndex == 0)
                {
                    layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.Size = collapse;
                }
                else
                {
                    tabPageControl.SelectedTabPageIndex = 0;
                }
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
            if (string.IsNullOrEmpty(name))
                return;
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
                msgManagement.updateMessageStatus(Convert.ToInt32(row["COMMENT_ID"]), "Del", env.UserID);
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

            if (viewMessage.FocusedRowHandle >= 0)
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

        #region Contrast
        int _contrastDtl_id = 0;
        DataSet _dsAcr;
        DataSet _dsSymptom;
        private void btnContrastDetail_Click(object sender, EventArgs e)
        {
            showContrastDetail();
        }
        private void showContrastDetail()
        {
            _contrastDtl_id = 0;
            chkcmbAcuteReactions.Visible = false;
            speContrastMediaExtravasation.Visible = lblValueTypeContrastMediaExtra.Visible = false;
            
            setDataReaction();
            setDataSymptom();
            setDataContrastDtl();
            setDataRoute();
            setDataContrast();
            clearDataContrast();

            if (layoutTemplate.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                tabPageControl.SelectedTabPage = tabContrast;
                layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.Size = expand;
            }
            else
            {
                if (layoutTemplate.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always && tabPageControl.SelectedTabPageIndex == 1)
                {
                    layoutTemplate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.Size = collapse;
                }
                else
                    tabPageControl.SelectedTabPageIndex = 1;
            }
        }
        private void setDataContrastDtl()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            DataSet ds = new DataSet();
            switch (pageMode)
            {
                case PagesModes.Order:
                    ProcessGetRISContrastdtl _getOrd = new ProcessGetRISContrastdtl();
                    _getOrd.RIS_CONTRASTDTL.ORDER_ID = order_id;
                    ds = _getOrd.GetDataByOrderId();
                    break;
                case PagesModes.Schedule:
                    ProcessGetRISContrastdtl _getSch = new ProcessGetRISContrastdtl();
                    _getSch.RIS_CONTRASTDTL.SCHEDULE_ID = schedule_id;
                    ds = _getSch.GetDataByScheduleId();
                    break;
                case PagesModes.XrayReq:
                    break;
                default:
                    break;
            }

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    grdDataContrast.DataSource = ds.Tables[0];

                    for (int i = 0; i < viewDataContrast.Columns.Count; i++)
                    {
                        viewDataContrast.Columns[i].Visible = false;
                        viewDataContrast.Columns[i].OptionsColumn.ReadOnly = true;
                        viewDataContrast.Columns[i].OptionsColumn.AllowEdit = false;
                    }


                    viewDataContrast.Columns["CONTRAST_TEXT"].ColVIndex = 1;
                    viewDataContrast.Columns["CONTRAST_TEXT"].Caption = "Contrast Name";
                    viewDataContrast.Columns["ROUTE_TEXT"].ColVIndex = 2;
                    viewDataContrast.Columns["ROUTE_TEXT"].Caption = "Route";
                    viewDataContrast.Columns["LOT_DISPLAY"].ColVIndex = 3;
                    viewDataContrast.Columns["LOT_DISPLAY"].Caption = "Lot";
                }
                else
                    grdDataContrast.DataSource = null;
            }
            else
                grdDataContrast.DataSource = null;

            ProcessGetRISContrastdtl _getContrastHis = new ProcessGetRISContrastdtl();
            DataSet dsHis = _getContrastHis.GetDataByRegId(reg_id);
            if (!dsHis.Tables[0].Columns.Contains("MEDIA_REACTION_DISPLAY"))
                dsHis.Tables[0].Columns.Add("MEDIA_REACTION_DISPLAY");
            foreach (DataRow rowHis in dsHis.Tables[0].Rows)
            {
                string _list = "0"; 
                if(string.IsNullOrEmpty(rowHis["MEDIA_REACTION_LIST"].ToString()))
                    _list = "0";
                else if(rowHis["MEDIA_REACTION_LIST"].ToString() == "No")
                    _list = "0";
                else 
                    _list = rowHis["MEDIA_REACTION_LIST"].ToString();
                DataRow[] rowsAcr = _dsAcr.Tables[0].Select("ACR_ID in (" + _list + ")");
                foreach (DataRow rowAcr in rowsAcr)
                {
                    rowHis["MEDIA_REACTION_DISPLAY"] += "[" + rowAcr["ACR_TYPE"].ToString() + "] " + rowAcr["ACR_TEXT"].ToString() + ";";
                }
            }

            grdDataContrastHistory.DataSource = dsHis.Tables[0];

            for (int i = 0; i < viewDataContrastHistory.Columns.Count; i++)
            {
                viewDataContrastHistory.Columns[i].Visible = false;
                viewDataContrastHistory.Columns[i].OptionsColumn.ReadOnly = true;
                viewDataContrastHistory.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewDataContrastHistory.Columns["CASE_DATETIME"].ColVIndex = 1;
            viewDataContrastHistory.Columns["CASE_DATETIME"].Caption = "Datetime";
            viewDataContrastHistory.Columns["CONTRAST_TEXT"].ColVIndex = 2;
            viewDataContrastHistory.Columns["CONTRAST_TEXT"].Caption = "Contrast Name";
            viewDataContrastHistory.Columns["ROUTE_TEXT"].ColVIndex = 3;
            viewDataContrastHistory.Columns["ROUTE_TEXT"].Caption = "Route";
            viewDataContrastHistory.Columns["LOT_DISPLAY"].ColVIndex = 4;
            viewDataContrastHistory.Columns["LOT_DISPLAY"].Caption = "Lot";
            viewDataContrastHistory.Columns["ACTUAL_QTY"].ColVIndex = 5;
            viewDataContrastHistory.Columns["ACTUAL_QTY"].Caption = "Act. Qty";
            viewDataContrastHistory.Columns["MEDIA_REACTION_DISPLAY"].ColVIndex = 6;
            viewDataContrastHistory.Columns["MEDIA_REACTION_DISPLAY"].Caption = "Contrast Reaction";

            dlg.Close();
        }

        private void setDataContrast()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            LookUpSelect sel = new LookUpSelect();
            DataSet ds = sel.SelectContrastManagement(3, DateTime.Now, DateTime.Now, "");

            cmbContrastName.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbContrastName.Properties.Items;
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    colls.Add(new contrastData(Convert.ToInt32(dr["ID"]), dr["CONTRAST_NAME"].ToString(), dr["CONTRAST_UID"].ToString()));
                }
            }
            finally
            {
                colls.EndUpdate();
            }
            dlg.Close();

        }
        private void setDataRoute()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            LookUpSelect sel = new LookUpSelect();
            DataSet ds = sel.SelectContrastManagement(1, DateTime.Now, DateTime.Now, "");

            cmbRoute.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbRoute.Properties.Items;
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    colls.Add(new routeData(Convert.ToInt32(dr["ID"]), dr["RouteName"].ToString()));

                }
            }
            finally
            {
                colls.EndUpdate();
            }

            dlg.Close();
        }
        private void setDataLot(int contrastId)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            LookUpSelect sel = new LookUpSelect();
            DataSet ds = sel.SelectContrastLot(contrastId);

            cmbLot.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbLot.Properties.Items;
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    colls.Add(new lotData(Convert.ToInt32(dr["LOT_ID"]), dr["LOT_DISPLAY"].ToString()));
                }
            }
            finally
            {
                colls.EndUpdate();
            }
            dlg.Close();
        }
        private void setDataReaction()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            ProcessGetRISContrastdtl _arcReaction = new ProcessGetRISContrastdtl();
            _dsAcr = _arcReaction.GetReactionData();

            chkcmbAcuteReactions.Properties.Items.Clear();
            try
            {
                foreach (DataRow dr in _dsAcr.Tables[0].Rows)
                {
                    chkcmbAcuteReactions.Properties.Items.Add(Convert.ToInt32(dr["ACR_ID"]), dr["ACR_DISPLAY"].ToString(), System.Windows.Forms.CheckState.Unchecked, true);
                }
            }
            finally
            {
            }
            dlg.Close();

        }
        private void setDataSymptom()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            ProcessGetRISContrastdtl _getData = new ProcessGetRISContrastdtl();
            _dsSymptom = _getData.GetSymptomData();

            chkcmbSymptom.Properties.Items.Clear();
            try
            {
                foreach (DataRow dr in _dsSymptom.Tables[0].Rows)
                {
                    chkcmbSymptom.Properties.Items.Add(Convert.ToInt32(dr["CONTRAST_SYMPTOM_ID"]), dr["SYMPTOM_DISPLAY"].ToString(), System.Windows.Forms.CheckState.Unchecked, true);
                }
            }
            finally
            {
            }
            dlg.Close();

        }

        private void calculateAutoCalculate()
        {
            try
            {
                decimal _autCalculate = speDose.Value * spePatientWeight.Value;
                speAutoCalculate.Value = _autCalculate;
            }
            catch (Exception ex)
            {
                speAutoCalculate.Value = 0;
            }

        }
        private void spePatientWeight_EditValueChanged(object sender, EventArgs e)
        {
            calculateAutoCalculate();
        }
        private void speDose_EditValueChanged(object sender, EventArgs e)
        {
            calculateAutoCalculate();
        }
        private void btnSaveContrast_Click(object sender, EventArgs e)
        {
            bool flag = true;
            bool onlySym = false;
            if (cmbContrastName.SelectedItem == null || cmbContrastName.EditValue.ToString() == ""
                || cmbRoute.SelectedItem == null || cmbRoute.EditValue.ToString() == ""
                || cmbLot.SelectedItem == null || cmbLot.EditValue.ToString() == "")
                flag = false;


            if (chkAcuteReactionYes.Checked)
                if (string.IsNullOrEmpty(chkcmbAcuteReactions.EditValue.ToString()))
                    flag = false;

            if (!string.IsNullOrEmpty(chkcmbSymptom.EditValue.ToString()))
            {
                if (!flag)
                    onlySym = true;
                flag = true;
            }
            if (flag)
            {
                if (!onlySym)
                {
                    memoMessage.Text = "Study Datetime : " + caseDatetime.ToString("dd/MM/yyyy HH:mm") + "\r\n";
                    memoMessage.Text += "Patient Weight : " + spePatientWeight.Value.ToString("#,###.00") + "\r\n";
                    memoMessage.Text += "Contrast Name : " + cmbContrastName.EditValue.ToString() + "\r\n";
                    memoMessage.Text += "Route : " + cmbRoute.EditValue.ToString() + "\r\n";
                    memoMessage.Text += "Dose : " + speDose.Value.ToString("#,###.00 ml/kg.") + "\r\n";
                    memoMessage.Text += "Actual Quanlity : " + speActualQuantity.Value.ToString("#,###.00 ml.") + "\r\n";
                    memoMessage.Text += "Injection Rate : " + speSideEffect.Value.ToString("#,###.00 ml/sec") + "\r\n";
                    memoMessage.Text += "Injection Time : " + timeInjectionTime.Time.ToString("HH:mm") + "\r\n";
                    if (chkContrastMediaExtravasationYes.Checked)
                        memoMessage.Text += "Contrast Media Extravasation : " + speContrastMediaExtravasation.Value.ToString("#,###.00 ml.") + "\r\n";

                    if (chkAcuteReactionYes.Checked)
                        memoMessage.Text += "Acute adverse reaction : " + chkcmbAcuteReactions.Text + "\r\n";
                    if (!string.IsNullOrEmpty(speOnsetOfSymptom.Value.ToString()))
                        if (speOnsetOfSymptom.Value != 0)
                            memoMessage.Text += "Acute adverse On set of symptom : " + speOnsetOfSymptom.Value.ToString() + " " + cmbOnsetOfSymptom.EditValue.ToString() + "\r\n";
                }
                if (!string.IsNullOrEmpty(dtOnsetOfSymtom.Text))
                    memoMessage.Text += "Delay adverse Onset of symptom : " + dtOnsetOfSymtom.DateTime.ToString("dd/MM/yyyy HH:mm") + "\r\n";
                if (!string.IsNullOrEmpty(chkcmbSymptom.Text))
                    memoMessage.Text += "Delay adverse Symptom : " + chkcmbSymptom.Text + "\r\n";

                memoMessage.Text += "Comments : " + memComments.Text + "\r\n";

                contrastData _contrastData = cmbContrastName.SelectedItem as contrastData;
                routeData _routeData = cmbRoute.SelectedItem as routeData;
                lotData _lotData = cmbLot.SelectedItem as lotData;

                if (_contrastDtl_id == 0)
                {
                    ProcessAddRISContrastDtl _add = new ProcessAddRISContrastDtl();
                    if (!onlySym)
                    {
                        _add.RIS_CONTRASTDTL.CONTRAST_ID = _contrastData.id();
                        _add.RIS_CONTRASTDTL.PATIENT_WEIGHT = spePatientWeight.Value;
                        _add.RIS_CONTRASTDTL.ROUTE_ID = _routeData.id();
                        _add.RIS_CONTRASTDTL.LOT_ID = _lotData.id();
                        _add.RIS_CONTRASTDTL.DOSE = speDose.Value;
                        _add.RIS_CONTRASTDTL.ACTUAL_QTY = speActualQuantity.Value;
                        _add.RIS_CONTRASTDTL.INJECTION_RATE = speSideEffect.Value;
                        _add.RIS_CONTRASTDTL.INJECTION_TIME = timeInjectionTime.Time;
                        if (chkAcuteReactionYes.Checked)
                            _add.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = chkcmbAcuteReactions.EditValue.ToString();
                        else if (chkAcuteReactionNo.Checked)
                            _add.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = "No";
                        else
                            _add.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = "";
                        if (chkContrastMediaExtravasationYes.Checked)
                            _add.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = speContrastMediaExtravasation.Value;
                        else if (chkContrastMediaExtravasationNo.Checked)
                            _add.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = 0;
                        else
                            _add.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = -1;
                    }
                    _add.RIS_CONTRASTDTL.ONSET_SYMPTOM_DATETIME = new DateTime(dtOnsetOfSymtom.DateTime.Year, dtOnsetOfSymtom.DateTime.Month, dtOnsetOfSymtom.DateTime.Day, timeOnsetOfSymtom.Time.Hour, timeOnsetOfSymtom.Time.Minute, timeOnsetOfSymtom.Time.Second);
                    _add.RIS_CONTRASTDTL.ONSET_SYMPTOM_LIST = chkcmbSymptom.EditValue.ToString();
                    if (cmbOnsetOfSymptom.EditValue != null)
                    {
                        _add.RIS_CONTRASTDTL.ONSET_SYMPTOM_TYPE = cmbOnsetOfSymptom.EditValue.ToString();
                        _add.RIS_CONTRASTDTL.ONSET_SYMPTOM_VALUE = speOnsetOfSymptom.Value;
                    }

                    _add.RIS_CONTRASTDTL.ORDER_ID = order_id;
                    _add.RIS_CONTRASTDTL.SCHEDULE_ID = schedule_id;
                    _add.RIS_CONTRASTDTL.XRAYREQ_ID = xrayreq_id;
                    _add.RIS_CONTRASTDTL.COMMENTS = memComments.Text;
                    _add.RIS_CONTRASTDTL.CREATED_BY = env.UserID;
                    _add.Invoke();
                }
                else
                {
                    ProcessUpdateRISContrastDtl _update = new ProcessUpdateRISContrastDtl();
                    _update.RIS_CONTRASTDTL.CONTRASTDTL_ID = _contrastDtl_id;
                    if (!onlySym)
                    {
                        _update.RIS_CONTRASTDTL.CONTRAST_ID = _contrastData.id();
                        _update.RIS_CONTRASTDTL.PATIENT_WEIGHT = spePatientWeight.Value;
                        _update.RIS_CONTRASTDTL.ROUTE_ID = _routeData.id();
                        _update.RIS_CONTRASTDTL.LOT_ID = _lotData.id();
                        _update.RIS_CONTRASTDTL.DOSE = speDose.Value;
                        _update.RIS_CONTRASTDTL.ACTUAL_QTY = speActualQuantity.Value;
                        _update.RIS_CONTRASTDTL.INJECTION_RATE = speSideEffect.Value;
                        _update.RIS_CONTRASTDTL.INJECTION_TIME = timeInjectionTime.Time;
                        if (chkAcuteReactionYes.Checked)
                            _update.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = chkcmbAcuteReactions.EditValue.ToString();
                        else if (chkAcuteReactionNo.Checked)
                            _update.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = "No";
                        else
                            _update.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = "";
                        if (chkContrastMediaExtravasationYes.Checked)
                            _update.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = speContrastMediaExtravasation.Value;
                        else if (chkContrastMediaExtravasationNo.Checked)
                            _update.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = 0;
                        else
                            _update.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = -1;
                    }
                    _update.RIS_CONTRASTDTL.ONSET_SYMPTOM_DATETIME = new DateTime(dtOnsetOfSymtom.DateTime.Year, dtOnsetOfSymtom.DateTime.Month, dtOnsetOfSymtom.DateTime.Day, timeOnsetOfSymtom.Time.Hour, timeOnsetOfSymtom.Time.Minute, timeOnsetOfSymtom.Time.Second);
                    _update.RIS_CONTRASTDTL.ONSET_SYMPTOM_LIST = chkcmbSymptom.EditValue.ToString();
                    if (cmbOnsetOfSymptom.EditValue != null)
                    {
                        _update.RIS_CONTRASTDTL.ONSET_SYMPTOM_TYPE = cmbOnsetOfSymptom.EditValue.ToString();
                        _update.RIS_CONTRASTDTL.ONSET_SYMPTOM_VALUE = speOnsetOfSymptom.Value;
                    }
                    _update.RIS_CONTRASTDTL.ORDER_ID = order_id;
                    _update.RIS_CONTRASTDTL.SCHEDULE_ID = schedule_id;
                    _update.RIS_CONTRASTDTL.XRAYREQ_ID = xrayreq_id;
                    _update.RIS_CONTRASTDTL.COMMENTS = memComments.Text;
                    _update.RIS_CONTRASTDTL.LAST_MODIFIED_BY = env.UserID;
                    _update.Invoke();
                }

                setDataContrastDtl();
                clearDataContrast();
            }
        }
        #endregion

        private void cmbContrastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            contrastData _contrastSelected = cmbContrastName.SelectedItem as contrastData;
            if (_contrastSelected != null)
            {
                checkContrastWithHIS();
                setDataLot(_contrastSelected.id());

            }

        }
        private void chkContrastMediaExtravasationYes_CheckedChanged(object sender, EventArgs e)
        {
            speContrastMediaExtravasation.Visible = lblValueTypeContrastMediaExtra.Visible = false;
            if (chkContrastMediaExtravasationYes.Checked)
            {
                chkContrastMediaExtravasationNo.Checked = false;
                speContrastMediaExtravasation.Visible = lblValueTypeContrastMediaExtra.Visible = true;
            }
        }
        private void chkContrastMediaExtravasationNo_CheckedChanged(object sender, EventArgs e)
        {
            speContrastMediaExtravasation.Visible = lblValueTypeContrastMediaExtra.Visible = false;
            if (chkContrastMediaExtravasationNo.Checked)
            {
                chkContrastMediaExtravasationYes.Checked = false;
                speContrastMediaExtravasation.Visible = lblValueTypeContrastMediaExtra.Visible = false;
            }
        }

        private void chkAcuteReactionYes_CheckedChanged(object sender, EventArgs e)
        {
            chkcmbAcuteReactions.Visible = false;
            if (chkAcuteReactionYes.Checked)
            {
                chkAcuteReactionNo.Checked = false;
                chkcmbAcuteReactions.Visible = true;
            }
        }
        private void chkAcuteReactionNo_CheckedChanged(object sender, EventArgs e)
        {
            chkcmbAcuteReactions.Visible = false;
            if (chkAcuteReactionNo.Checked)
            {
                chkAcuteReactionYes.Checked = false;
                chkcmbAcuteReactions.Visible = false;
            }
        }
        
        private void clearDataContrast()
        {
            _contrastDtl_id = 0;
            spePatientWeight.EditValue = 0;
            cmbContrastName.EditValue = "";
            cmbRoute.EditValue = "";
            cmbLot.EditValue = "";
            speDose.EditValue = 0;
            speActualQuantity.EditValue = 0;
            speSideEffect.EditValue = 0;
            memComments.Text = "";
            chkAcuteReactionYes.Checked = false;
            chkAcuteReactionNo.Checked = false;
            for (int i = 0; i < _dsAcr.Tables[0].Rows.Count; i++)
            {
                chkcmbAcuteReactions.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            for (int i = 0; i < _dsSymptom.Tables[0].Rows.Count; i++)
            {
                chkcmbSymptom.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            dtOnsetOfSymtom.EditValue = "";
            timeOnsetOfSymtom.EditValue = "";
            timeInjectionTime.EditValue = "";

            chkContrastMediaExtravasationYes.Checked = false;
            chkContrastMediaExtravasationNo.Checked = false;
            speContrastMediaExtravasation.EditValue = 0;
            cmbOnsetOfSymptom.SelectedIndex = 0;
            speOnsetOfSymptom.EditValue = 0;
        }
        private void viewDataContrast_DoubleClick(object sender, EventArgs e)
        {
            if (viewDataContrast.FocusedRowHandle >= 0)
            {
                DataRow row = viewDataContrast.GetDataRow(viewDataContrast.FocusedRowHandle);
                _contrastDtl_id = Convert.ToInt32(row["CONTRASTDTL_ID"]);

                spePatientWeight.Value = Convert.ToDecimal(row["PATIENT_WEIGHT"]);
                cmbContrastName.EditValue = new contrastData(Convert.ToInt32(row["CONTRAST_ID"]), row["CONTRAST_TEXT"].ToString());
                cmbRoute.EditValue = new routeData(Convert.ToInt32(row["ROUTE_ID"]), row["ROUTE_TEXT"].ToString());
                cmbLot.EditValue = new lotData(Convert.ToInt32(row["LOT_ID"]), row["LOT_DISPLAY"].ToString());
                speDose.Value = Convert.ToDecimal(row["DOSE"]);
                speActualQuantity.Value = Convert.ToDecimal(row["ACTUAL_QTY"]);
                speSideEffect.Value = Convert.ToDecimal(row["INJECTION_RATE"]);

                if (!string.IsNullOrEmpty(row["INJECTION_TIME"].ToString()))
                {
                    timeInjectionTime.Time = Convert.ToDateTime(row["INJECTION_TIME"]);
                    timeInjectionTime.EditValue = Convert.ToDateTime(row["INJECTION_TIME"]).ToString("HH:mm");
                }
                if (!string.IsNullOrEmpty(row["ONSET_SYMPTOM_DATETIME"].ToString()))
                {
                    dtOnsetOfSymtom.DateTime = Convert.ToDateTime(row["ONSET_SYMPTOM_DATETIME"]);
                    timeOnsetOfSymtom.EditValue = Convert.ToDateTime(row["ONSET_SYMPTOM_DATETIME"]).ToString("HH:mm");
                }
                chkcmbSymptom.EditValue = row["ONSET_SYMPTOM_LIST"].ToString();
                chkcmbSymptom.RefreshEditValue();
                speOnsetOfSymptom.Value = Convert.ToDecimal(row["ONSET_SYMPTOM_VALUE"]);
                cmbOnsetOfSymptom.EditValue = row["ONSET_SYMPTOM_TYPE"].ToString();

                chkAcuteReactionYes.Checked = false;
                chkAcuteReactionNo.Checked = false;
                if (row["MEDIA_REACTION_LIST"].ToString() == "")
                {
                    chkAcuteReactionYes.Checked = false;
                    chkAcuteReactionNo.Checked = false;
                }
                else if (row["MEDIA_REACTION_LIST"].ToString() == "No")
                {
                    chkAcuteReactionNo.Checked = true;
                }
                else
                {
                    chkAcuteReactionYes.Checked = true;
                    chkcmbAcuteReactions.EditValue = row["MEDIA_REACTION_LIST"].ToString();
                    chkcmbAcuteReactions.RefreshEditValue();
                }

                chkContrastMediaExtravasationYes.Checked = false;
                chkContrastMediaExtravasationNo.Checked = false;
                if (row["MEDIA_EXTRAVASATION"].ToString() == "0.00")
                {
                    chkContrastMediaExtravasationNo.Checked = true;
                }
                else if (row["MEDIA_EXTRAVASATION"].ToString() == "-1.00")
                {
                    chkContrastMediaExtravasationYes.Checked = false;
                    chkContrastMediaExtravasationNo.Checked = false;
                }
                else
                {
                    chkContrastMediaExtravasationYes.Checked = true;
                    speContrastMediaExtravasation.Value = Convert.ToDecimal(row["MEDIA_EXTRAVASATION"]);
                }
                memComments.Text = row["COMMENTS"].ToString();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewDataContrast.FocusedRowHandle >= 0)
            {
                DataRow row = viewDataContrast.GetDataRow(viewDataContrast.FocusedRowHandle);
                _contrastDtl_id = Convert.ToInt32(row["CONTRASTDTL_ID"]);

                ProcessDeleteRISContrastDtl _del = new ProcessDeleteRISContrastDtl();
                _del.RIS_CONTRASTDTL.CONTRASTDTL_ID = _contrastDtl_id;
                _del.Invoke();

                setDataContrastDtl();
            }
        }
        private void ShowLoadingDialog(string message, int width, int height)
        {
            this.waitDialog = new DevExpress.Utils.WaitDialogForm(message, "Dialog", new Size(width, height));
        }

        #region Risk
        private void loadRISRiskDataOrder(int order_id)
        {
            DataTable dtIncident = new DataTable();
            ProcessGetRisRiskIncidents incident = new ProcessGetRisRiskIncidents();
            incident.RIS_RISKINCIDENTS.ORDER_ID = order_id;
            dtIncident = incident.getDataByOrderID();

            loadRiskIndicationData(dtIncident);
        }
        private void loadRISRiskDataSchedule(int schedule_id)
        {
            DataTable dtIncident = new DataTable();
            ProcessGetRisRiskIncidents incident = new ProcessGetRisRiskIncidents();
            incident.RIS_RISKINCIDENTS.SCHEDULE_ID = schedule_id;
            dtIncident = incident.getDataByScheduleID();
            loadRiskIndicationData(dtIncident);
        }
        private void loadRISRiskDataRequestXray(int xrayreq_id)
        {
            DataTable dtIncident = new DataTable();
            ProcessGetRisRiskIncidents incident = new ProcessGetRisRiskIncidents();
            incident.RIS_RISKINCIDENTS.XRAYREQ_ID = xrayreq_id;
            dtIncident = incident.getDataByXrayReqID();
            loadRiskIndicationData(dtIncident);
        }
        private void loadRiskIndicationData(DataTable dt)
        {
            DataRow[] rowUseContrast = dt.Select("RISK_CAT_ID=22");
            if (rowUseContrast.Length > 0)
            {
                switch (rowUseContrast[0]["INCIDENT_CHOOSED"].ToString())
                {
                    case "N": lblShowContrast.Visible = true; lblShowContrast.Text = "Non-Contrast"; break;
                    case "Y": lblShowContrast.Visible = true; lblShowContrast.Text = "With-Contrast"; break;
                    default: lblShowContrast.Visible = false; lblShowContrast.Text = ""; break;
                }
            }
            else
            {
                lblShowContrast.Visible = false; lblShowContrast.Text = "";
            }
        }

        private void LoadAllergyData()
        {
            this.ShowLoadingDialog("Loading...", 150, 50);
            try
            {
                DataSet ds = this._hisPatientWebService.Get_Adr(hn.Trim());
                if (ds.Tables.Count > 0)
                {
                    this.gridAllergyControl.DataSource = ds.Tables[0];
                }
                this.waitDialog.Close();
            }
            catch (Exception ex)
            {
                #if DEBUG
                //MessageBox.Show(ex.Message);
                #endif

                this.ResetAllergyData();
                this.waitDialog.Close();
            }
        }
        private void ResetAllergyData()
        {
            this.gridAllergyControl.DataSource = null;
        }
        #endregion

        private void checkContrastWithHIS()
        {
            this.ShowLoadingDialog("Loading...", 150, 50);
            try
            {
                contrastData _contrastSelected = cmbContrastName.SelectedItem as contrastData;
                DataSet ds = this._hisPatientWebService.searchAdrByMrnAndCode(hn.Trim(), _contrastSelected.code());
                if (ds.Tables.Count > 0)
                {
                    this.gridAllergyControl.DataSource = ds.Tables[0];
                }
                this.waitDialog.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                //MessageBox.Show(ex.Message);
#endif

                this.ResetAllergyData();
                this.waitDialog.Close();
            }
        }

    }
    public enum PagesModes
    {
        Order, Schedule, XrayReq
    }
    public class contrastData
    {
        private int _id;
        private string _code;
        private string _name;
        public contrastData(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public contrastData(int id, string code, string name)
        {
            _id = id;
            _code = code;
            _name = name;
        }
        public override string ToString()
        {
            return _name;
        }
        public int id()
        {
            return _id;
        }
        public string code()
        {
            return _code;
        }
    }
    public class routeData
    {
        private int _id;
        private string _name;
        public routeData(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public override string ToString()
        {
            return _name;
        }
        public int id()
        {
            return _id;
        }
    }
    public class lotData
    {
        private int _id;
        private string _name;
        public lotData(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public override string ToString()
        {
            return _name;
        }
        public int id()
        {
            return _id;
        }
    }
      
}