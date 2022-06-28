using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.Common.Common;
using Miracle.Util;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Controls;
using Envision.NET.Forms.Dialog;
using Miracle.Scanner;
using DevExpress.XtraEditors;
using Envision.NET.Forms.EMR;
using Envision.NET.Forms.Technologist;
using Envision.NET.Forms.ResultEntry.ConsultCase;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Operational.PACS;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmResultWorklist : Envision.NET.Forms.Main.MasterForm// Form
    {
        private Envision.BusinessLogic.ResultEntry result;
        private frmPopupOrderOrScheduleSummary _orderSummary;

        private GBL_RADEXPERIENCE rad;
        private GBLEnvVariable env;
        private MyMessageBox msg;

        //work list
        private DataTable dttWL;
        private DataTable dttWLSchedule;

        private DataTable dttExamFlag, dtExamFlagDTL;

        bool chkFirstSetGridWL = true;
        private bool FirstDatabind = true;

        public frmResultWorklist()
        {
            InitializeComponent();
        }

        private void frmResultWorklist_Load(object sender, EventArgs e)
        {
            result = new Envision.BusinessLogic.ResultEntry();
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
            rad = result.GetRadiologistConfig(env.UserID);

            setTrauma();
            initFirst();

            initExamType();
            initOrderingDepartment();
            initLocFilter();

            FirstDatabind = false;
            this._orderSummary = new frmPopupOrderOrScheduleSummary();

            base.CloseWaitDialog();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!FirstDatabind)
                LoadData("None");
        }
        private void txtDashHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtDashHN.Text.Trim().Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDashHN.Text.Trim().Length == 0)
                    {
                        txtDashHN.Focus();
                        return;
                    }
                    LoadData("None");
                }
            }
        }
        private void rdoDashDate_Click(object sender, EventArgs e)
        {
            if (rdoDashDate.Checked)
            {
                panelDate.Visible = true;
                panelHN.Visible = false;
                rdoDashHN.Checked = false;
            }
            else
            {
                panelDate.Visible = false;
                panelHN.Visible = true;
                rdoDashHN.Checked = true;
            }
        }
        private void rdoDashHN_Click(object sender, EventArgs e)
        {
            if (rdoDashHN.Checked)
            {
                panelDate.Visible = false;
                panelHN.Visible = true;
                rdoDashDate.Checked = false;
            }
            else
            {
                panelDate.Visible = false;
                panelHN.Visible = true;
                rdoDashDate.Checked = true;
            }
        }
        private void rdoDashHN_Validating(object sender, CancelEventArgs e)
        {
            if (txtDashHN.Text.Trim().Length == 0)
                txtDashHN.Focus();
            //else
            //    btnSearchHN.Focus();
        }
        private void chkFinalize_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit chk = sender as CheckEdit;
            chkFinalizeFilter.Checked = chkFinalizeSearch.Checked = chk.Checked;


            if (!FirstDatabind)
                LoadData("None");
        }
        private void rdoAssignedCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstDatabind)
            {
                if (rdoAssignedCase.SelectedIndex == 1)
                    rad.LOAD_ALL_EXAM = false;
                else
                    rad.LOAD_ALL_EXAM = true;
                LoadData("ASSIGNEDCASE");
            }
        }
        private void ccbExamType_EditValueChanged(object sender, EventArgs e)
        {
            if (!FirstDatabind)
                setFilterGrid("EXAM_TYPE");
        }
        private void ccbOrderingDept_EditValueChanged(object sender, EventArgs e)
        {
            if (!FirstDatabind)
                setFilterGrid("REF_UNIT");
        }
        private void cmbLocFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilterGrid("FILTER");
        }
        private void xtabGridWorklist_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (!FirstDatabind)
            {
                switch (e.Page.Name)
                {
                    case "tabResultworklist":
                        txtToDT.DateTime = DateTime.Now;
                        break;
                    case "tabScheduleworklist":
                        break;
                }
                LoadData("None");
            }
        }

        #region context Schedule Worklist Popup
        private void menuWLSchedule_Opening(object sender, CancelEventArgs e)
        {
            if (viewSchedule.FocusedRowHandle >= 0)
            {
                DataRow row = viewSchedule.GetDataRow(viewSchedule.FocusedRowHandle);
                bool is_schedule = row["STATUS_TEXT"].ToString() == "Request" ? false : true;
                getTrauma(Convert.ToInt32(row["SCHEDULE_ID"]), is_schedule);

                DataRow[] rowExamFlag = dttExamFlag.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                if (rowExamFlag.Length > 0)
                {
                    DataRow[] rowSelected = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowExamFlag[0]["EXAMFLAG_ID"].ToString());
                    contextcmbSchedule.SelectedIndex = dtExamFlagDTL.Rows.IndexOf(rowSelected[0]);
                }
                else
                    contextcmbSchedule.SelectedIndex = 0;
            }
        }
        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderImage();
        }
        private void toolStripCommentsSchdule_Click(object sender, EventArgs e)
        {
            if (viewSchedule.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewSchedule.GetDataRow(viewSchedule.FocusedRowHandle);
            if (Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString()) == 0)
                showMessageConversation(Convert.ToInt32(rowHandle["XRAYREQ_ID"].ToString()), true);
            else
                showMessageConversation(Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString()));
        }
        private void contextcmbSchedule_DropDownClosed(object sender, EventArgs e)
        {
            if (viewSchedule.FocusedRowHandle >= 0)
            {
                TraumaItems trauma = contextcmbSchedule.SelectedItem as TraumaItems;
                DataRow rowDtl = viewSchedule.GetDataRow(viewSchedule.FocusedRowHandle);
                DataRow[] rowCheck = dttExamFlag.Select("EXAM_ID=" + rowDtl["EXAM_ID"].ToString());
                if (rowCheck.Length > 0)
                {
                    ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                    updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowCheck[0]["FLAG_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = Convert.ToInt32(rowCheck[0]["ORDER_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = Convert.ToInt32(rowCheck[0]["XRAYREQ_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowCheck[0]["ORDER_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["SCHEDULE_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowDtl["EXAM_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = trauma.Trauma_id();
                    updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowCheck[0]["REASON"].ToString();
                    updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                    updateExamFlag.Invoke();
                }
                else
                {
                    ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                    addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = Convert.ToInt32(rowDtl["ORDER_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = Convert.ToInt32(rowDtl["XRAYREQ_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowDtl["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowDtl["SCHEDULE_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowDtl["EXAM_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = trauma.Trauma_id();
                    addExamFlag.RIS_ORDEREXAMFLAG.REASON = "";
                    addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                    addExamFlag.Invoke();
                }
                rowDtl["FLAG_ICON"] = trauma.Trauma_id() == 72 ? 0 : trauma.Trauma_Seq();
                viewSchedule.RefreshData();
            }
        }
        #endregion
        #region content Worklist Popup
        private void menuWL_Opening(object sender, CancelEventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
                getTrauma(Convert.ToInt32(row["ORDER_ID"]));

                DataRow[] rowExamFlag = dttExamFlag.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                if (rowExamFlag.Length > 0)
                {
                    DataRow[] rowSelected = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowExamFlag[0]["EXAMFLAG_ID"].ToString());
                    contextcmb.SelectedIndex = dtExamFlagDTL.Rows.IndexOf(rowSelected[0]);
                }
                else
                    contextcmb.SelectedIndex = 0;
            }
        }
        private void toolsOrderImg_Click(object sender, EventArgs e)
        {
            orderImage();
        }
        private void toolsLabData_Click(object sender, EventArgs e)
        {
            OrderLabData();
        }
        private void toolsERClinicalData_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;

            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
            string hn = row["HN"].ToString();
            if (hn.Length == 0) return;

            frmPatientData_ClinicalData form = new frmPatientData_ClinicalData(hn);
            form.HN = hn;
            form.ShowDialog();
        }
        private void toolsHistory_Click(object sender, EventArgs e)
        {
            History_Action();
        }
        private void toolsBrowse_Click(object sender, EventArgs e)
        {
            BrowseArchive_Action();
        }
        private void toolBookmark_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
            frmStudyLibraryPopupAddEdit frm
                    = new frmStudyLibraryPopupAddEdit(row["ACCESSION_NO"].ToString(), "ALL");
            frm.ShowDialog();
        }
        private void toolsConsultCase_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;

            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
            string report_status = row["S"].ToString();
            if (report_status == "F")
            {
                string accession_no = row["ACCESSION_NO"].ToString();
                frmConsultCaseManagement frmConsult = new frmConsultCaseManagement(accession_no);
                frmConsult.StartPosition = FormStartPosition.CenterScreen;
                frmConsult.ShowDialog();
            }
            else
            {
                MyMessageBox msg = new MyMessageBox();
                msg.ShowAlert("UID2044", new GBLEnvVariable().CurrentLanguageID);
            }
        }
        private void toolStripComments_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow fcRow = view1.GetDataRow(view1.FocusedRowHandle);
            showMessageConversation(fcRow["ACCESSION_NO"].ToString());
        }
        private void contextcmb_DropDownClosed(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                TraumaItems trauma = contextcmb.SelectedItem as TraumaItems;
                DataRow rowDtl = view1.GetDataRow(view1.FocusedRowHandle);
                DataRow[] rowCheck = dttExamFlag.Select("EXAM_ID=" + rowDtl["EXAM_ID"].ToString());
                if (rowCheck.Length > 0)
                {
                    ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                    updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowCheck[0]["FLAG_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = Convert.ToInt32(rowCheck[0]["ORDER_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = Convert.ToInt32(rowCheck[0]["XRAYREQ_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowCheck[0]["ORDER_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["SCHEDULE_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowDtl["EXAM_ID"]);
                    updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = trauma.Trauma_id();
                    updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowCheck[0]["REASON"].ToString();
                    updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                    updateExamFlag.Invoke();
                }
                else
                {
                    ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                    addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = Convert.ToInt32(rowDtl["ORDER_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = Convert.ToInt32(rowDtl["XRAYREQ_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowDtl["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowDtl["SCHEDULE_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowDtl["EXAM_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = trauma.Trauma_id();
                    addExamFlag.RIS_ORDEREXAMFLAG.REASON = "";
                    addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                    addExamFlag.Invoke();
                }
                rowDtl["FLAG_ICON"] = trauma.Trauma_id() == 72 ? 0 : trauma.Trauma_Seq();
                view1.RefreshData();
            }
        }
        private void pACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            openPACS(dr["ACCESSION_NO"].ToString(), false);
        }
        #endregion

        private string openPACS(string AccessionNumber, bool is_blank)
        {
            string str = "http://miracleonline/SynapseManageLink/AccessionNOpacsurl.html?AccessionNo=" + AccessionNumber;
            if (env.LoginType == "W")
            {
                str = env.PacsUrl;
                str = str.Replace("http://", string.Empty);
                str = "http://radiology%5C" + env.UserName + ":" + env.PasswordAD + "@" + str + AccessionNumber;
            }

            if (is_blank)
            {
                Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
                if (!ieCom.OpenLink("http://miracleonline", str))
                    msg.ShowAlert("UID4053", env.CurrentLanguageID);
            }
            else
            {
                Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
                if (!ieCom.OpenLink("http://miracleonline", str))
                    msg.ShowAlert("UID4053", env.CurrentLanguageID);
            }

            return str;

            //// UpdatePacs
            //return new OpenPACS(env.PacsUrl).OpenIE(AccessionNumber, env.UserName, env.PasswordAD, "", env.LoginType);

        }
        private void initFirst()
        {
            initPreparingGridWL();
            initPreparingGridWLSchedule();

            if (FirstDatabind)
            {
                txtFromDT.DateTime = DateTime.Today;
                txtToDT.DateTime = DateTime.Today;
                xtraTabSearch.SelectedTabPage = wlpageFilter;
                chkFinalizeFilter.Checked = chkFinalizeSearch.Checked = rad.LOAD_FINALIZED_EXAMS.Value;

                if (rad.DEF_DATE_RANGE.Trim().Length > 0)
                {
                    int DefDateRange = Convert.ToInt32(rad.DEF_DATE_RANGE);
                    txtFromDT.DateTime = DateTime.Now.AddDays((-1) * DefDateRange);
                }
                else
                    txtFromDT.DateTime = DateTime.Now.AddDays(-7);

                switch (rad.DASHBOARD_DEF_SEARCH.ToString())
                {
                    case "D":
                        rdoDashDate.Checked = true;
                        rdoDashHN.Checked = false;
                        panelDate.Visible = true;
                        panelHN.Visible = false;
                        break;
                    case "H":
                        txtDashHN.Text = "";
                        txtDashHN.Focus();
                        rdoDashDate.Checked = false;
                        rdoDashHN.Checked = true;
                        panelDate.Visible = false;
                        panelHN.Visible = true;
                        xtraTabSearch.SelectedTabPage = wlpageSearch;
                        break;
                    default:
                        rdoDashDate.Checked = true;
                        rdoDashHN.Checked = false;
                        panelDate.Visible = true;
                        panelHN.Visible = false;
                        break;
                }

            }
            if (rad.DASHBOARD_DEF_SEARCH.ToString() == "H")
            {
                txtDashHN.Text = "";
                txtDashHN.Focus();
            }
            CheckDataBind();

        }
        private void CheckDataBind()
        {
            LoadData("None");
        }
        private void initLocFilter()
        {
            ProcessGetRISExamresultFilterworklist filterData = new ProcessGetRISExamresultFilterworklist();
            filterData.RIS_EXAMRESULT_FILTERWORKLIST.EMP_ID = env.UserID;
            filterData.getDataByRadid();
            cmbLocFilter.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbLocFilter.Properties.Items;
            colls.BeginUpdate();
            try
            {
                foreach (DataRow dr in filterData.Result.Tables[0].Rows)
                    colls.Add(new Filter_WLLOC_Mode(Convert.ToInt32(dr["FILTER_ID"]), dr["FILTER_NAME"].ToString(), dr["FILTER_DETAIL"].ToString()));
            }
            finally
            {
                colls.EndUpdate();
            }
            cmbLocFilter.SelectedIndex = 0;
        }
        private void initOrderingDepartment()
        {
            ccbOrderingDept.Properties.Items.Clear();
            ProcessGetHRUnit get = new ProcessGetHRUnit();
            get.Invoke_forRadiologistWorklist();
            DataTable dt = get.Result.Tables[0];

            ccbOrderingDept.Properties.DataSource = dt;
            ccbOrderingDept.Properties.DisplayMember = "UNIT_UID";
            ccbOrderingDept.Properties.ValueMember = "UNIT_ID";
        }
        private void initExamType()
        {
            ccbExamType.Properties.Items.Clear();
            ProcessGetRISExamType get = new ProcessGetRISExamType();
            get.Invoke();
            DataTable dt = get.Result.Tables[0];

            ccbExamType.Properties.DataSource = dt;
            ccbExamType.Properties.DisplayMember = "EXAM_TYPE_TEXT";
            ccbExamType.Properties.ValueMember = "EXAM_TYPE_ID";
        }
        private void initPreparingGridWL()
        {
            dttWL = new DataTable();
            result.RISExamresult.MODE = 100;
            dttWL = result.GetWorkList();
            grdWL.DataSource = dttWL;
            setGridColumnWL();
        }
        private void initPreparingGridWLSchedule()
        {
            dttWLSchedule = new DataTable();
            result.RISExamresult.MODE = 100;
            dttWLSchedule = result.GetWorkListSchedule();
            grdSchedule.DataSource = dttWLSchedule;
            setGridColumnWLSchedule();
        }
        private void setGridColumnWL()
        {
            #region column edit
            if (chkFirstSetGridWL == true)
            {
                for (int i = 0; i < dttWL.Columns.Count; i++)
                    view1.Columns[i].Visible = false;

                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
                    repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repositoryItemImageComboBox2.AutoHeight = false;
                repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)
                });
                repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
                repositoryItemImageComboBox2.SmallImages = imgWL;
                repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                    chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                chkTemplate.ValueChecked = "Y";
                chkTemplate.ValueUnchecked = "N";
                chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
                chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
                chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                chkTemplate.Click += new EventHandler(chk_Click);

                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                    chkDF = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                chkDF.ValueChecked = "Y";
                chkDF.ValueUnchecked = "N";
                chkDF.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
                chkDF.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
                chkDF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox linkScanImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                linkScanImage.AutoHeight = false;
                linkScanImage.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,22),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",0,23)
            });
                linkScanImage.Name = "linkScanImage";
                linkScanImage.SmallImages = imgSmall;
                linkScanImage.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                linkScanImage.Buttons[0].Visible = false;
                linkScanImage.ShowDropDown = ShowDropDown.Never;
                linkScanImage.ShowPopupShadow = false;
                linkScanImage.DropDownRows = 0;
                linkScanImage.Click += new EventHandler(linkScanImage_Click);


                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repComment = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repComment.AutoHeight = false;
                repComment.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","New",1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Read",9)
            });
                repComment.Name = "repComment";
                repComment.SmallImages = imgWL;
                repComment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repComment.Buttons[0].Visible = false;
                repComment.Click += new EventHandler(repComment_Click);

                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repFlag.AutoHeight = false;
                repFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",2,1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",3,2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",4,3),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",5,4)
            });
                repFlag.Name = "repFlag";
                repFlag.SmallImages = img16;
                repFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repFlag.Buttons[0].Visible = false;

            #endregion column edit

                //for (int i = 0; i < view1.Columns.Count; i++)
                //    view1.Columns[i].Visible = false;

                view1.OptionsSelection.EnableAppearanceFocusedCell = false;

                view1.Columns["CHK"].ColVIndex = 1;
                view1.Columns["CHK"].Caption = " ";
                //view1.Columns["CHK"].Visible = true;
                view1.Columns["CHK"].ColumnEdit = chkTemplate;
                view1.Columns["CHK"].Width = -1;

                view1.Columns["HAS_COMMENT"].Caption = " ";
                view1.Columns["HAS_COMMENT"].ColumnEdit = repComment;
                view1.Columns["HAS_COMMENT"].Width = -1;
                view1.Columns["HAS_COMMENT"].OptionsColumn.ReadOnly = true;
                view1.Columns["HAS_COMMENT"].OptionsColumn.AllowEdit = true;
                view1.Columns["HAS_COMMENT"].OptionsFilter.AllowFilter = false;
                view1.Columns["HAS_COMMENT"].Visible = false;

                view1.Columns["READER"].Caption = " ";
                view1.Columns["READER"].ColVIndex = 2;
                view1.Columns["READER"].OptionsColumn.ReadOnly = true;
                view1.Columns["READER"].OptionsColumn.AllowEdit = true;
                view1.Columns["READER"].OptionsFilter.AllowFilter = false;
                view1.Columns["READER"].ColumnEdit = repComment;
                view1.Columns["READER"].Width = -1;

                view1.Columns["SCANIMAGES"].ColVIndex = 3;
                view1.Columns["SCANIMAGES"].ColumnEdit = linkScanImage;
                view1.Columns["SCANIMAGES"].Caption = " ";
                view1.Columns["SCANIMAGES"].Width = -1;
                view1.Columns["SCANIMAGES"].OptionsColumn.ReadOnly = false;
                view1.Columns["SCANIMAGES"].OptionsColumn.AllowEdit = true;
                view1.Columns["SCANIMAGES"].OptionsFilter.AllowFilter = false;

                view1.Columns["PATIENT_ID_LABEL"].ColVIndex = 4;
                view1.Columns["PATIENT_ID_LABEL"].Caption = " ";
                view1.Columns["PATIENT_ID_LABEL"].OptionsColumn.ReadOnly = true;
                view1.Columns["PATIENT_ID_LABEL"].OptionsColumn.AllowEdit = false;

                view1.Columns["PRIORITY_ID"].ColVIndex = 5;
                view1.Columns["PRIORITY_ID"].ColumnEdit = repositoryItemImageComboBox2;
                view1.Columns["PRIORITY_ID"].Caption = "Priority";
                view1.Columns["PRIORITY_ID"].OptionsColumn.ReadOnly = true;
                view1.Columns["PRIORITY_ID"].OptionsColumn.AllowEdit = false;

                view1.Columns["STATUS"].ColVIndex = 6;
                view1.Columns["STATUS"].Caption = "Status";
                view1.Columns["STATUS"].OptionsColumn.ReadOnly = true;
                view1.Columns["STATUS"].OptionsColumn.AllowEdit = false;

                view1.Columns["TIMEDIFF"].ColVIndex = 7;
                view1.Columns["TIMEDIFF"].Caption = "Waiting Time";
                view1.Columns["TIMEDIFF"].OptionsColumn.ReadOnly = true;
                view1.Columns["TIMEDIFF"].OptionsColumn.AllowEdit = false;

                view1.Columns["ORDER_DT"].ColVIndex = 8;
                view1.Columns["ORDER_DT"].Caption = "Order Time";
                view1.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
                view1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view1.Columns["ORDER_DT"].Width = 73;
                view1.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
                view1.Columns["ORDER_DT"].OptionsColumn.AllowEdit = false;

                view1.Columns["HN"].ColVIndex = 9;
                view1.Columns["HN"].Caption = "HN";
                view1.Columns["HN"].OptionsColumn.ReadOnly = true;
                view1.Columns["HN"].OptionsColumn.AllowEdit = false;
                //view1.Columns["HN"].ToolTip = "HN";

                view1.Columns["PatientName"].ColVIndex = 10;
                view1.Columns["PatientName"].Caption = "Patient Name";
                //view1.Columns["PatientName"].Visible = true;
                view1.Columns["PatientName"].OptionsColumn.ReadOnly = true;
                view1.Columns["PatientName"].OptionsColumn.AllowEdit = false;

                view1.Columns["AGE"].ColVIndex = 11;
                view1.Columns["AGE"].Caption = "Age";
                //view1.Columns["AGE"].Visible = true;
                view1.Columns["AGE"].OptionsColumn.ReadOnly = true;
                view1.Columns["AGE"].OptionsColumn.AllowEdit = false;

                view1.Columns["ACCESSION_NO"].ColVIndex = 12;
                view1.Columns["ACCESSION_NO"].Caption = "Accession No";
                //view1.Columns["ACCESSION_NO"].Visible = true;
                view1.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
                view1.Columns["ACCESSION_NO"].OptionsColumn.AllowEdit = false;

                view1.Columns["EXAM_NAME"].ColVIndex = 13;
                view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                //view1.Columns["EXAM_NAME"].Visible = true;
                view1.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
                view1.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;

                view1.Columns["BPVIEW_NAME"].ColVIndex = 14;
                view1.Columns["BPVIEW_NAME"].Caption = "Side";
                view1.Columns["BPVIEW_NAME"].Visible = true;
                view1.Columns["BPVIEW_NAME"].OptionsColumn.ReadOnly = true;
                view1.Columns["BPVIEW_NAME"].OptionsColumn.AllowEdit = false;

                view1.Columns["Radiologist"].ColVIndex = 15;
                view1.Columns["Radiologist"].Caption = "Radiologist";
                //view1.Columns["Radiologist"].Visible = true;
                view1.Columns["Radiologist"].OptionsColumn.ReadOnly = true;
                view1.Columns["Radiologist"].OptionsColumn.AllowEdit = false;

                view1.Columns["REF_DOC"].ColVIndex = 16;
                view1.Columns["REF_DOC"].Caption = "Ordering Doc.";
                view1.Columns["REF_DOC"].OptionsColumn.ReadOnly = true;
                view1.Columns["REF_DOC"].OptionsColumn.AllowEdit = false;

                view1.Columns["RESULT_MODIFIED_BY"].ColVIndex = 17;
                view1.Columns["RESULT_MODIFIED_BY"].Caption = "Last Modified by.";
                //view1.Columns["RESULT_MODIFIED_BY"].Visible = true;
                view1.Columns["RESULT_MODIFIED_BY"].OptionsColumn.ReadOnly = true;
                view1.Columns["RESULT_MODIFIED_BY"].OptionsColumn.AllowEdit = false;

                view1.Columns["Unit"].ColVIndex = 18;
                view1.Columns["Unit"].Caption = "Ordering Dept.";
                //view1.Columns["Unit"].Visible = true;
                view1.Columns["Unit"].OptionsColumn.ReadOnly = true;
                view1.Columns["Unit"].OptionsColumn.AllowEdit = false;

                view1.Columns["CLINIC_TYPE_TEXT"].ColVIndex = 19;
                view1.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
                //view1.Columns["CLINIC_TYPE_TEXT"].Visible = true;
                view1.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.ReadOnly = true;
                view1.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.AllowEdit = false;

                view1.Columns["EXAM_UID"].ColVIndex = 20;
                view1.Columns["EXAM_UID"].Caption = "Exam Code";
                //view1.Columns["EXAM_UID"].Visible = true;
                view1.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
                view1.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;

                view1.Columns["IS_DF"].ColVIndex = 21;
                view1.Columns["IS_DF"].Caption = "DF";
                view1.Columns["IS_DF"].ColumnEdit = chkDF;
                view1.Columns["IS_DF"].OptionsColumn.ReadOnly = true;
                view1.Columns["IS_DF"].OptionsColumn.AllowEdit = false;

                view1.Columns["FLAG_ICON"].ColVIndex = 22;
                view1.Columns["FLAG_ICON"].Caption = " ";
                view1.Columns["FLAG_ICON"].Width = -1;
                view1.Columns["FLAG_ICON"].ColumnEdit = repFlag;
                view1.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
                view1.Columns["FLAG_ICON"].OptionsColumn.AllowEdit = false;
                view1.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;

                view1.Columns["REQUEST_RESULT_DATETIME"].ColVIndex = 23;
                view1.Columns["REQUEST_RESULT_DATETIME"].Caption = "Request Result Datetime";
                view1.Columns["REQUEST_RESULT_DATETIME"].DisplayFormat.FormatString = "G";
                view1.Columns["REQUEST_RESULT_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view1.Columns["REQUEST_RESULT_DATETIME"].Width = 73;
                view1.Columns["REQUEST_RESULT_DATETIME"].OptionsColumn.ReadOnly = true;
                view1.Columns["REQUEST_RESULT_DATETIME"].OptionsColumn.AllowEdit = false;

                view1.Columns["ORDER_ID"].Caption = "Order No";
                view1.Columns["ORDER_ID"].Visible = false;
                view1.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
                view1.Columns["ORDER_ID"].OptionsColumn.AllowEdit = false;

                view1.Columns["XRAY_NO"].Caption = "Xray No.";
                view1.Columns["XRAY_NO"].Visible = false;
                view1.Columns["XRAY_NO"].OptionsColumn.ReadOnly = true;
                view1.Columns["XRAY_NO"].OptionsColumn.AllowEdit = false;

                //view1.Columns["PRIORITY"].Caption = " ";
                //view1.Columns["PRIORITY"].Visible = false;
                //view1.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;
                //view1.Columns["PRIORITY"].OptionsColumn.AllowEdit = false;

                view1.Columns["S"].Caption = "S";
                view1.Columns["S"].Visible = false;
                view1.Columns["S"].OptionsColumn.ReadOnly = true;
                view1.Columns["S"].OptionsColumn.AllowEdit = false;

                view1.Columns["EXAM_ID"].Caption = "EXAM_ID";
                view1.Columns["EXAM_ID"].Visible = false;
                view1.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;
                view1.Columns["EXAM_ID"].OptionsColumn.AllowEdit = false;

                view1.Columns["ASSIGNED_TO"].Caption = "ASSIGNED_TO";
                view1.Columns["ASSIGNED_TO"].Visible = false;
                view1.Columns["ASSIGNED_TO"].OptionsColumn.ReadOnly = true;
                view1.Columns["ASSIGNED_TO"].OptionsColumn.AllowEdit = false;

                view1.Columns["MERGE"].Caption = "MERGE";
                view1.Columns["MERGE"].Visible = false;
                view1.Columns["MERGE"].OptionsColumn.ReadOnly = true;
                view1.Columns["MERGE"].OptionsColumn.AllowEdit = false;

                view1.Columns["MERGE_WITH"].Caption = "MERGE_WITH";
                view1.Columns["MERGE_WITH"].Visible = false;
                view1.Columns["MERGE_WITH"].OptionsColumn.ReadOnly = true;
                view1.Columns["MERGE_WITH"].OptionsColumn.AllowEdit = false;

                view1.Columns["Favorite"].Caption = "Favorite";
                view1.Columns["Favorite"].Visible = false;
                view1.Columns["Favorite"].OptionsColumn.ReadOnly = true;
                view1.Columns["Favorite"].OptionsColumn.AllowEdit = false;

                view1.Columns["Teaching"].Caption = "Teaching";
                view1.Columns["Teaching"].Visible = false;
                view1.Columns["Teaching"].OptionsColumn.ReadOnly = true;
                view1.Columns["Teaching"].OptionsColumn.AllowEdit = false;

                view1.Columns["Other"].Caption = "Other";
                view1.Columns["Other"].Visible = false;
                view1.Columns["Other"].OptionsColumn.ReadOnly = true;
                view1.Columns["Other"].OptionsColumn.AllowEdit = false;

                view1.Columns["NO_OF_IMAGES"].ColVIndex = 19;
                view1.Columns["NO_OF_IMAGES"].Caption = "Number of Images";
                //view1.Columns["EXAM_UID"].Visible = true;
                view1.Columns["NO_OF_IMAGES"].OptionsColumn.ReadOnly = true;
                view1.Columns["NO_OF_IMAGES"].OptionsColumn.AllowEdit = false;

                #region Set font style.
                //Alive
                DevExpress.XtraGrid.StyleFormatCondition stylCon1
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "New");
                stylCon1.Appearance.ForeColor = Color.Red;

                //Complete
                DevExpress.XtraGrid.StyleFormatCondition stylCon2
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Complete");
                stylCon2.Appearance.ForeColor = Color.Red;

                //Prelim
                DevExpress.XtraGrid.StyleFormatCondition stylCon3
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim");
                stylCon3.Appearance.ForeColor = Color.Goldenrod;

                //Draft
                DevExpress.XtraGrid.StyleFormatCondition stylCon4
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft");
                stylCon4.Appearance.ForeColor = Color.Goldenrod;

                //Finalize
                DevExpress.XtraGrid.StyleFormatCondition stylCon5
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized");
                stylCon5.Appearance.ForeColor = Color.Green;

                //Prelim(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon6
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim(T)");
                stylCon6.Appearance.ForeColor = Color.Goldenrod;

                //Draft(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon7
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft(T)");
                stylCon7.Appearance.ForeColor = Color.Goldenrod;

                //Finalize(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon8
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized(T)");
                stylCon8.Appearance.ForeColor = Color.Green;

                //Locked
                DevExpress.XtraGrid.StyleFormatCondition stylCon9
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Locked");
                stylCon9.Appearance.ForeColor = Color.Blue;

                //Rejected
                DevExpress.XtraGrid.StyleFormatCondition stylCon10
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Rejected");
                stylCon10.Appearance.ForeColor = Color.DarkViolet;

                //Repeated
                DevExpress.XtraGrid.StyleFormatCondition stylCon11
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Repeated");
                stylCon11.Appearance.ForeColor = Color.Violet;

                //Rejected(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon12
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Rejected(T)");
                stylCon12.Appearance.ForeColor = Color.DarkViolet;

                //Repeated(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon13
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Repeated(T)");
                stylCon13.Appearance.ForeColor = Color.Violet;

                //Complete
                DevExpress.XtraGrid.StyleFormatCondition stylCon14
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Complete(T)");
                stylCon2.Appearance.ForeColor = Color.Red;

                //Locked
                DevExpress.XtraGrid.StyleFormatCondition stylCon15
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Short Prelim");
                stylCon15.Appearance.ForeColor = Color.Blue;

                //Locked
                DevExpress.XtraGrid.StyleFormatCondition stylCon16
                    = new DevExpress.XtraGrid.StyleFormatCondition
                        (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Short Prelim(T)");
                stylCon16.Appearance.ForeColor = Color.Blue;

                view1.FormatConditions.Clear();
                view1.FormatConditions.AddRange
                    (new DevExpress.XtraGrid.StyleFormatCondition[] 
                    { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5
                        , stylCon6, stylCon7, stylCon8, stylCon9, stylCon10
                        , stylCon11, stylCon12, stylCon13, stylCon14 
                        , stylCon15, stylCon16});
                #endregion

                if (rad.WORKLIST_GRID_ORDER.Length > 0)
                {
                    //for (int i = 0; i < view1.Columns.Count; i++)
                    //    view1.Columns[i].Visible = false;

                    DataSet getXML = new DataSet();
                    System.IO.MemoryStream mem = null;
                    try
                    {
                        char[] chr = rad.WORKLIST_GRID_ORDER.ToCharArray();
                        byte[] data = new byte[chr.Length];
                        for (int i = 0; i < chr.Length; i++)
                            data[i] = (byte)chr[i];
                        mem = new System.IO.MemoryStream(data);

                        getXML.ReadXml(mem);
                        for (int j = 0; j < getXML.Tables[0].Rows.Count; j++)
                        {
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Width = Convert.ToInt32(getXML.Tables[0].Rows[j][1]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Visible = Convert.ToBoolean(getXML.Tables[0].Rows[j][2]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].ColVIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][3]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].GroupIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][4]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].AbsoluteIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][5]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].VisibleIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][6]);
                        }
                        mem.Dispose();
                    }
                    catch
                    { }
                }
                chkFirstSetGridWL = false;
            }
        }
        private void chk_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (view1.FocusedRowHandle > -1)
                {
                    view1.OptionsBehavior.Editable = false;

                    DataRow drChk = view1.GetDataRow(view1.FocusedRowHandle);
                    if (chk.Checked == false)
                        drChk["CHK"] = "Y";
                    else
                        drChk["CHK"] = "N";

                    drChk.AcceptChanges();

                    if (drChk["CHK"].ToString() == "Y")
                    {
                        string ACCESSION_NO = drChk["ACCESSION_NO"].ToString();
                        string MERGE = drChk["MERGE"].ToString();
                        string MERGE_WITH = drChk["MERGE_WITH"].ToString();

                        for (int i = 0; i < view1.RowCount; i++)
                        {
                            if (i == view1.FocusedRowHandle) continue;

                            DataRow row = view1.GetDataRow(i);
                            if (row == null) break;
                            if (
                                (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == MERGE_WITH
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == ACCESSION_NO
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == MERGE_WITH
                                || (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == ACCESSION_NO
                                )
                            {
                                row["CHK"] = "Y";
                            }
                        }
                    }
                    else
                    {
                        string ACCESSION_NO = drChk["ACCESSION_NO"].ToString();
                        string MERGE = drChk["MERGE"].ToString();
                        string MERGE_WITH = drChk["MERGE_WITH"].ToString();

                        for (int i = 0; i < view1.RowCount; i++)
                        {
                            if (i == view1.FocusedRowHandle) continue;

                            DataRow row = view1.GetDataRow(i);
                            if (
                                (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == MERGE_WITH
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == ACCESSION_NO
                                || (row["MERGE_WITH"].ToString().Length == 0 ? "EMPTY" : row["MERGE_WITH"].ToString())
                                == MERGE_WITH
                                || (row["ACCESSION_NO"].ToString().Length == 0 ? "EMPTY" : row["ACCESSION_NO"].ToString())
                                == ACCESSION_NO
                                )
                            {
                                row["CHK"] = "N";
                            }
                        }
                    }

                    view1.OptionsBehavior.Editable = true;
                }
            }
        }
        private void repComment_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            showMessageConversation(rowHandle["ACCESSION_NO"].ToString());
        }
        private void repCommentSch_Click(object sender, EventArgs e)
        {
            if (viewSchedule.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewSchedule.GetDataRow(viewSchedule.FocusedRowHandle);
            showMessageConversation(Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString()));
        }

        private void linkScanImage_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
                scanOrder();
        }
        private void linkScanImageSch_Click(object sender, EventArgs e)
        {
            if (viewSchedule.FocusedRowHandle >= 0)
            {
                DataRow dr = viewSchedule.GetDataRow(viewSchedule.FocusedRowHandle);

                ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
                process.RIS_ORDERIMAGE.ORDER_ID = 0;
                process.RIS_ORDERIMAGE.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]); ;
                DataTable dtOrderImage = process.GetDataByID();
                PointerStruct.ImageUrl = env.PacsUrl2;

                if (dtOrderImage.Rows.Count > 0)
                {
                    if (dtOrderImage.Rows.Count > 1)
                    {
                        Envision.NET.Forms.Dialog.ImageOrder img = new ImageOrder(Convert.ToInt32(dr["SCHEDULE_ID"]), "Schedule");
                        img.StartPosition = FormStartPosition.CenterParent;
                        img.ShowDialog();
                    }
                    else
                    {
                        string url = PointerStruct.ImageUrl + "/" + dtOrderImage.Rows[0]["IMAGE_NAME"].ToString();

                        Envision.NET.Reports.ReportViewer.frmXtraReportViewer Browser = new Envision.NET.Reports.ReportViewer.frmXtraReportViewer(url);
                        Browser.Text = dtOrderImage.Rows[0]["IMAGE_NAME"].ToString();
                        Browser.StartPosition = FormStartPosition.CenterScreen;
                        Browser.ShowDialog();
                    }
                }
                else
                {
                    msg.ShowAlert("UID4029", env.CurrentLanguageID);
                }
            }
        }
        private void setGridColumnWLSchedule()
        {
            #region column edit

            for (int i = 0; i < dttWLSchedule.Columns.Count; i++)
                viewSchedule.Columns[i].Visible = false;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
                repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
              new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)
            });
            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgWL;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox linkScanImageSch = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            linkScanImageSch.AutoHeight = false;
            linkScanImageSch.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,22),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",0,23)
            });
            linkScanImageSch.Name = "linkScanImage";
            linkScanImageSch.SmallImages = imgSmall;
            linkScanImageSch.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            linkScanImageSch.Buttons[0].Visible = false;
            linkScanImageSch.ShowDropDown = ShowDropDown.Never;
            linkScanImageSch.ShowPopupShadow = false;
            linkScanImageSch.DropDownRows = 0;
            linkScanImageSch.Click += new EventHandler(linkScanImageSch_Click);


            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repCommentSch = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repCommentSch.AutoHeight = false;
            repCommentSch.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","New",1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("","Read",9)
            });
            repCommentSch.Name = "repComment";
            repCommentSch.SmallImages = imgWL;
            repCommentSch.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repCommentSch.Buttons[0].Visible = false;
            repCommentSch.Click += new EventHandler(repCommentSch_Click);

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repFlag.AutoHeight = false;
            repFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",2,1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",3,2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",4,3),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",5,4)
            });
            repFlag.Name = "repFlag";
            repFlag.SmallImages = img16;
            repFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repFlag.Buttons[0].Visible = false;

            #endregion column edit

            //for (int i = 0; i < view1.Columns.Count; i++)
            //    view1.Columns[i].Visible = false;

            viewSchedule.OptionsSelection.EnableAppearanceFocusedCell = false;

            viewSchedule.Columns["READER"].Caption = " ";
            viewSchedule.Columns["READER"].ColVIndex = 1;
            viewSchedule.Columns["READER"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["READER"].OptionsColumn.AllowEdit = true;
            viewSchedule.Columns["READER"].OptionsFilter.AllowFilter = false;
            viewSchedule.Columns["READER"].ColumnEdit = repCommentSch;
            viewSchedule.Columns["READER"].Width = -1;

            viewSchedule.Columns["SCANIMAGES"].ColVIndex = 2;
            viewSchedule.Columns["SCANIMAGES"].ColumnEdit = linkScanImageSch;
            viewSchedule.Columns["SCANIMAGES"].Caption = " ";
            viewSchedule.Columns["SCANIMAGES"].Width = -1;
            viewSchedule.Columns["SCANIMAGES"].OptionsColumn.ReadOnly = false;
            viewSchedule.Columns["SCANIMAGES"].OptionsColumn.AllowEdit = true;
            viewSchedule.Columns["SCANIMAGES"].OptionsFilter.AllowFilter = false;

            viewSchedule.Columns["FLAG_ICON"].ColVIndex = 3;
            viewSchedule.Columns["FLAG_ICON"].Caption = " ";
            viewSchedule.Columns["FLAG_ICON"].Width = -1;
            viewSchedule.Columns["FLAG_ICON"].ColumnEdit = repFlag;
            viewSchedule.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["FLAG_ICON"].OptionsColumn.AllowEdit = false;
            viewSchedule.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;


            viewSchedule.Columns["PATIENT_ID_LABEL"].ColVIndex = 4;
            viewSchedule.Columns["PATIENT_ID_LABEL"].Caption = " ";
            viewSchedule.Columns["PATIENT_ID_LABEL"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["PATIENT_ID_LABEL"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["STATUS_TEXT"].ColVIndex = 5;
            viewSchedule.Columns["STATUS_TEXT"].Caption = "Status";
            viewSchedule.Columns["STATUS_TEXT"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["STATUS_TEXT"].OptionsColumn.AllowEdit = false;


            viewSchedule.Columns["PRIORITY_ID"].ColVIndex = 6;
            viewSchedule.Columns["PRIORITY_ID"].ColumnEdit = repositoryItemImageComboBox2;
            viewSchedule.Columns["PRIORITY_ID"].Caption = "Priority";
            viewSchedule.Columns["PRIORITY_ID"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["PRIORITY_ID"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["SCHEDULE_DT"].ColVIndex = 7;
            viewSchedule.Columns["SCHEDULE_DT"].Caption = "Schedule Time";
            viewSchedule.Columns["SCHEDULE_DT"].DisplayFormat.FormatString = "G";
            viewSchedule.Columns["SCHEDULE_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewSchedule.Columns["SCHEDULE_DT"].Width = 73;
            viewSchedule.Columns["SCHEDULE_DT"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["SCHEDULE_DT"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["HN"].ColVIndex = 8;
            viewSchedule.Columns["HN"].Caption = "HN";
            viewSchedule.Columns["HN"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["HN"].OptionsColumn.AllowEdit = false;
            //view1.Columns["HN"].ToolTip = "HN";

            viewSchedule.Columns["PatientName"].ColVIndex = 9;
            viewSchedule.Columns["PatientName"].Caption = "Patient Name";
            //view1.Columns["PatientName"].Visible = true;
            viewSchedule.Columns["PatientName"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["PatientName"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["AGE"].ColVIndex = 10;
            viewSchedule.Columns["AGE"].Caption = "Age";
            //view1.Columns["AGE"].Visible = true;
            viewSchedule.Columns["AGE"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["AGE"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["EXAM_NAME"].ColVIndex = 11;
            viewSchedule.Columns["EXAM_NAME"].Caption = "Exam Name";
            //view1.Columns["EXAM_NAME"].Visible = true;
            viewSchedule.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["BPVIEW_NAME"].ColVIndex = 12;
            viewSchedule.Columns["BPVIEW_NAME"].Caption = "Side";
            viewSchedule.Columns["BPVIEW_NAME"].Visible = true;
            viewSchedule.Columns["BPVIEW_NAME"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["BPVIEW_NAME"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["Radiologist"].ColVIndex = 13;
            viewSchedule.Columns["Radiologist"].Caption = "Radiologist";
            //view1.Columns["Radiologist"].Visible = true;
            viewSchedule.Columns["Radiologist"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["Radiologist"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["REF_DOC"].ColVIndex = 14;
            viewSchedule.Columns["REF_DOC"].Caption = "Ordering Doc.";
            viewSchedule.Columns["REF_DOC"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["REF_DOC"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["Unit"].ColVIndex = 15;
            viewSchedule.Columns["Unit"].Caption = "Ordering Dept.";
            //view1.Columns["Unit"].Visible = true;
            viewSchedule.Columns["Unit"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["Unit"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["CLINIC_TYPE_TEXT"].ColVIndex = 16;
            viewSchedule.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
            //view1.Columns["CLINIC_TYPE_TEXT"].Visible = true;
            viewSchedule.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["EXAM_UID"].ColVIndex = 17;
            viewSchedule.Columns["EXAM_UID"].Caption = "Exam Code";
            //view1.Columns["EXAM_UID"].Visible = true;
            viewSchedule.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;


            viewSchedule.Columns["SCHEDULE_ID"].Caption = "Schedule No";
            viewSchedule.Columns["SCHEDULE_ID"].Visible = false;
            viewSchedule.Columns["SCHEDULE_ID"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["SCHEDULE_ID"].OptionsColumn.AllowEdit = false;

            //viewSchedule.Columns["PRIORITY"].Caption = " ";
            //viewSchedule.Columns["PRIORITY"].Visible = false;
            //viewSchedule.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;
            //viewSchedule.Columns["PRIORITY"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["S"].Caption = "S";
            viewSchedule.Columns["S"].Visible = false;
            viewSchedule.Columns["S"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["S"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["EXAM_ID"].Caption = "EXAM_ID";
            viewSchedule.Columns["EXAM_ID"].Visible = false;
            viewSchedule.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["EXAM_ID"].OptionsColumn.AllowEdit = false;

            viewSchedule.Columns["ASSIGNED_TO"].Caption = "ASSIGNED_TO";
            viewSchedule.Columns["ASSIGNED_TO"].Visible = false;
            viewSchedule.Columns["ASSIGNED_TO"].OptionsColumn.ReadOnly = true;
            viewSchedule.Columns["ASSIGNED_TO"].OptionsColumn.AllowEdit = false;


            #region Set font style.
            //Waiting
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, viewSchedule.Columns["Status"], null, "Waiting");
            stylCon1.Appearance.ForeColor = Color.Blue;

            //Pending
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, viewSchedule.Columns["Status"], null, "Pending");
            stylCon2.Appearance.ForeColor = Color.Brown;

            //Schedule
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, viewSchedule.Columns["Status"], null, "Schedule");
            stylCon3.Appearance.ForeColor = Color.Black;

            //Order
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition
                    (DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Order");
            stylCon4.Appearance.ForeColor = Color.Pink;

            viewSchedule.FormatConditions.Clear();
            viewSchedule.FormatConditions.AddRange
                (new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4 });
            #endregion
        }

        private void orderImage()
        {
            switch (xtabGridWorklist.SelectedTabPage.Name)
            {
                case "tabResultworklist":
                    if (view1.FocusedRowHandle > -1)
                    {
                        DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                        this._orderSummary.ShowDialog(true, dr["ACCESSION_NO"].ToString());
                    }
                    else
                        msg.ShowAlert("UID006", env.CurrentLanguageID);
                    break;
                case "tabScheduleworklist":
                    if (viewSchedule.FocusedRowHandle > -1)
                    {
                        DataRow dr = viewSchedule.GetDataRow(viewSchedule.FocusedRowHandle);
                        int _id = Convert.ToInt32(dr["SCHEDULE_ID"]);
                        if (_id > 0)
                            this._orderSummary.ShowDialog(true, dr["HN"].ToString(), _id, 0, frmPopupOrderOrScheduleSummary.PagesModes.Schedule, false);
                        else
                            this._orderSummary.ShowDialog(true, dr["HN"].ToString(), Convert.ToInt32(dr["XRAYREQ_ID"]), Convert.ToInt32(dr["EXAM_ID"]), frmPopupOrderOrScheduleSummary.PagesModes.Order, false);
                    }
                    else
                        msg.ShowAlert("UID006", env.CurrentLanguageID);
                    break;
            }

        }
        private void OrderLabData()
        {
            if (view1.FocusedRowHandle > -1)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                this._orderSummary.ShowDialogWithLabData(true, dr["ACCESSION_NO"].ToString());
            }
            else
                msg.ShowAlert("UID006", env.CurrentLanguageID);
        }
        private void History_Action()
        {
            if (view1.FocusedRowHandle > -1)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                string hn = dr["HN"].ToString();
                BrowseArchive frm = new BrowseArchive(hn);
                frm.ShowDialog();
            }
            else
            {
                BrowseArchive frm = new BrowseArchive("");
                frm.ShowDialog();
            }
        }
        private void BrowseArchive_Action()
        {
            BrowseArchive frm = new BrowseArchive();
            frm.ShowDialog();
        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.ORDER_ID = -1;
            prc.Invoke();
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();

            contextcmb.Items.Clear();
            contextcmbSchedule.Items.Clear();
            System.Windows.Forms.ComboBox.ObjectCollection colls = contextcmb.Items;
            System.Windows.Forms.ComboBox.ObjectCollection collSch = contextcmbSchedule.Items;
            try
            {
                foreach (DataRow row in dtExamFlagDTL.Rows)
                {
                    colls.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
                    collSch.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
                }
            }
            finally
            {
            }
            contextcmb.SelectedIndex = 0;
            contextcmbSchedule.SelectedIndex = 0;
        }
        private void getTrauma(int order_id)
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.ORDER_ID = order_id == 0 ? -1 : order_id;
            prc.Invoke();

            dttExamFlag = prc.Result.Tables[0];
        }
        private void getTrauma(int id, bool is_schedule)
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            if (is_schedule)
            {
                prc.RIS_ORDEREXAMFLAG.SCHEDULE_ID = id;
                prc.InvokeSchedule();
            }
            else
            {
                prc.RIS_ORDEREXAMFLAG.XRAYREQ_ID = id;
                prc.InvokeXrayreq();
            }

            dttExamFlag = prc.Result.Tables[0];
        }
        private void setFilterGrid(string filterFrom)
        {
            Filter_WLLOC_Mode filterMode = cmbLocFilter.SelectedItem as Filter_WLLOC_Mode;
            if (filterMode != null)
            {
                DataSet getXML = new DataSet();
                System.IO.MemoryStream mem = null;
                char[] chr = filterMode.Loc_Filter().ToCharArray();
                byte[] data = new byte[chr.Length];
                for (int i = 0; i < chr.Length; i++)
                    data[i] = (byte)chr[i];
                mem = new System.IO.MemoryStream(data);

                getXML.ReadXml(mem);

                if (Utilities.IsHaveData(getXML))
                {
                    string valueExamtype = "";
                    string valueOrderingDept = "";
                    string valueFilter = "";

                    if (filterFrom == "FILTER")
                    {
                        valueFilter = getXML.Tables[0].Rows[0]["FILTER_COLUMNS"].ToString();
                        valueExamtype = getXML.Tables[0].Rows[0]["EXAM_TYPE"].ToString();
                        valueOrderingDept = getXML.Tables[0].Rows[0]["REF_UNIT"].ToString();
                    }
                    else
                    {
                        valueFilter = getXML.Tables[0].Rows[0]["FILTER_COLUMNS"].ToString();
                        valueExamtype = ccbExamType.EditValue.ToString();
                        valueOrderingDept = ccbOrderingDept.EditValue.ToString();
                    }
                    ccbExamType.EditValue = valueExamtype;
                    ccbExamType.RefreshEditValue();
                    ccbOrderingDept.EditValue = valueOrderingDept;
                    ccbOrderingDept.RefreshEditValue();

                    string strFilter = "";


                    if (!string.IsNullOrEmpty(valueExamtype))
                        strFilter += "EXAM_TYPE IN (" + valueExamtype + ")";
                    if (!string.IsNullOrEmpty(valueOrderingDept))
                        strFilter += string.IsNullOrEmpty(strFilter) ? "" : " AND" + " REF_UNIT IN (" + valueOrderingDept + ")";
                    if (!string.IsNullOrEmpty(valueFilter))
                        strFilter += string.IsNullOrEmpty(strFilter) ? "" : " AND " + valueFilter;
                    if (FirstDatabind)
                        rdoAssignedCase.SelectedIndex = rad.LOAD_ALL_EXAM.Value ? 2 : 1;

                    switch (rdoAssignedCase.SelectedIndex)
                    {
                        case 0: strFilter += string.IsNullOrEmpty(strFilter) ? "" : " AND " + "( ASSIGNED_TO = " + env.UserID + " OR ASSIGNED_TO is null )"; break;
                        case 1: strFilter += string.IsNullOrEmpty(strFilter) ? "" : " AND " + "( ASSIGNED_TO = " + env.UserID + " )"; break;
                        case 2: break;
                    }

                    switch (xtabGridWorklist.SelectedTabPage.Name)
                    {
                        case "tabResultworklist":
                            view1.ActiveFilterString = strFilter;
                            view1.ActiveFilterEnabled = true;
                            break;
                        case "tabScheduleworklist":
                            viewSchedule.ActiveFilterString = strFilter;
                            viewSchedule.ActiveFilterEnabled = true;
                            break;
                    }

                }
            }

        }
        private void LoadData(string filterFrom)
        {
            rdoDashHN.Enabled = false;
            rdoDashDate.Enabled = false;
            panelHN.Enabled = false;
            panelDate.Enabled = false;
            chkFinalizeFilter.Enabled = chkFinalizeSearch.Enabled = false;

            result.RISExamresult.EMP_ID = env.UserID;
            result.RISExamresult.FROM_DATE = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
            result.RISExamresult.TO_DATE = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);

            if (rdoDashDate.Checked)
            {
                // Mode 1,2 เหมือนกันอยู่ ไม่มีการ where emp_id มาใช้ filter grid แยกแทน
                if (rad.LOAD_ALL_EXAM.Value)
                    result.RISExamresult.MODE = 2;
                else
                    result.RISExamresult.MODE = 1;
            }
            else if (rdoDashHN.Checked)
            {
                result.RISExamresult.MODE = 3;
                result.RISExamresult.HN = txtDashHN.Text;
            }

            getDataTable();
            //setGridColumnWL();
            if (filterFrom != "None")
                setFilterGrid(filterFrom);

            rdoDashHN.Enabled = true;
            rdoDashDate.Enabled = true;
            panelHN.Enabled = true;
            panelDate.Enabled = true;
            chkFinalizeFilter.Enabled = chkFinalizeSearch.Enabled = true;
        }
        private void getDataTable()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Loading Worklist Data", s);

            switch (xtabGridWorklist.SelectedTabPage.Name)
            {
                case "tabResultworklist":
                    dttWL = new DataTable();
                    if (chkFinalizeFilter.Checked)
                        result.RISExamresult.STATUS = "F";
                    else
                        result.RISExamresult.STATUS = "N";
                    dttWL = result.GetWorkList();
                    grdWL.DataSource = dttWL;
                    break;
                case "tabScheduleworklist":
                    dttWLSchedule = result.GetWorkListSchedule();
                    grdSchedule.DataSource = dttWLSchedule;
                    break;
            }
            dlg.Close();
        }
        private void scanOrder()
        {
            #region Scan Image
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);

            ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
            process.RIS_ORDERIMAGE.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]);
            process.Invoke();
            DataTable dtSImg = process.Result.Tables[0].Copy();
            PointerStruct.ImageUrl = env.PacsUrl2;

            if (dtSImg.Rows.Count > 0)
            {
                if (dtSImg.Rows.Count > 1)
                {
                    Envision.NET.Forms.Dialog.ImageOrder img = new ImageOrder(Convert.ToInt32(dr["ORDER_ID"]));
                    img.StartPosition = FormStartPosition.CenterParent;
                    img.ShowDialog();
                }
                else
                {
                    string url = PointerStruct.ImageUrl + "/" + dtSImg.Rows[0]["IMAGE_NAME"].ToString();

                    Envision.NET.Reports.ReportViewer.frmXtraReportViewer Browser = new Envision.NET.Reports.ReportViewer.frmXtraReportViewer(url);
                    Browser.Text = dtSImg.Rows[0]["IMAGE_NAME"].ToString();
                    Browser.StartPosition = FormStartPosition.CenterScreen;
                    Browser.ShowDialog();
                }
            }
            else
            {
                msg.ShowAlert("UID4029", env.CurrentLanguageID);
            }
            #endregion
        }
        private void showMessageConversation(string accession_no)
        {
            frmMessageConversation frm = new frmMessageConversation(accession_no);
            frm.ShowDialog();
            if (bgwRefreshGrid.IsBusy == false)
                bgwRefreshGrid.RunWorkerAsync();
        }
        private void showMessageConversation(int schedule_id)
        {
            frmMessageConversation frm = new frmMessageConversation(schedule_id);
            frm.ShowDialog();
            if (bgwRefreshGrid.IsBusy == false)
                bgwRefreshGrid.RunWorkerAsync();
        }
        private void showMessageConversation(int xrayrequest_id, bool is_Online)
        {
            frmMessageConversation frm = new frmMessageConversation(xrayrequest_id, is_Online);
            frm.ShowDialog();
            if (bgwRefreshGrid.IsBusy == false)
                bgwRefreshGrid.RunWorkerAsync();
        }
        private void bgwRefreshGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtClone = new DataTable();
            if (chkFinalizeFilter.Checked)
                result.RISExamresult.STATUS = "F";
            else
                result.RISExamresult.STATUS = "N";
            dtClone = result.GetWorkList();
            e.Result = dtClone;
        }
        private void bgwRefreshGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Action a = () =>
            {
                this.dttWL = (DataTable)e.Result;
                this.grdWL.DataSource = dttWL;
            };
            this.grdWL.Invoke(a);
        }



    }
}
