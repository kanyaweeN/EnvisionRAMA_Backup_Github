using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Controls;

namespace Envision.NET.Forms.Admin
{
    public partial class frmExamSetup : MasterForm
    {
        private DataSet ds;
        GBLEnvVariable env = new GBLEnvVariable();

        private int clickTick;
        private BaseEdit activeEditor;
        private MyMessageBox msg = new MyMessageBox();

        //Modality Mapping variables
        private DataTable dtModMap;
        private bool stopAllEvents = false;

        //DF Setting variables
        private DataSet dsExamDF;
        private DataTable dtRadTmp;
        private DataTable dtTechTmp;
        private DataTable dtNurseTmp;
        private DataTable dtBPBodyPart;
        private DataTable dtBPView;
        private List<int> deletedList;

        private DataTable dtExamBilling;

        public frmExamSetup()
        {
            InitializeComponent();

        }
        private void frmExamSetup_Load(object sender, EventArgs e)
        {
            SetEnableDisableControl(false);
            LoadData();
            LoadBodyPartData();
            LoadGridBPView();

            SetGridData();
            
            txtExamCode.Focus();

            //Modify at 2008 08 21
            RISBodyPartSelectData();
            xtraTabControl1.SelectedTabPageIndex = 0;

            base.CloseWaitDialog();
        }

        #region Navigator Control
        private void btnClose_Click(object sender, EventArgs e)
        {
            //dbu.CloseFrom(CloseControl, this);
            this.Close();
        }
        #endregion

        private void SetGridData()
        {
            grdData.DataSource = ds.Tables[0].DefaultView;
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                advView.Columns[i].Visible = false;

            advView.OptionsView.ShowColumnHeaders = true;

            #region Set Master
            advView.Columns["EXAM_UID"].Visible = true;
            advView.Columns["EXAM_UID"].Caption = "Exam Code";
            advView.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            advView.Columns["EXAM_UID"].Width = 70;
            advView.Columns["EXAM_UID"].OptionsColumn.FixedWidth = true;
            advView.Columns["EXAM_UID"].VisibleIndex = 1;

            advView.Columns["EXAM_NAME"].Visible = true;
            advView.Columns["EXAM_NAME"].Caption = "Exam Name";
            advView.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            //advView.Columns["EXAM_NAME"].Width = 250;
            advView.Columns["EXAM_NAME"].VisibleIndex = 2;

            //advView.Columns["SERVICE_TYPE"].Visible = true;
            advView.Columns["SERVICE_TYPE"].Caption = "Service Type";
            advView.Columns["SERVICE_TYPE"].OptionsColumn.ReadOnly = true;
            advView.Columns["SERVICE_TYPE"].BestFit();
            //advView.Columns["SERVICE_TYPE"].VisibleIndex = 3;

            //advView.Columns["EXAM_TYPE"].Visible = true;
            advView.Columns["EXAM_TYPE"].Caption = "Exam Type";
            advView.Columns["EXAM_TYPE"].OptionsColumn.ReadOnly = true;
            advView.Columns["EXAM_TYPE"].BestFit();
            //advView.Columns["EXAM_TYPE"].VisibleIndex = 4;

            //advView.Columns["RATE"].Visible = true;
            advView.Columns["RATE"].Caption = "Rate";
            advView.Columns["RATE"].OptionsColumn.ReadOnly = true;
            advView.Columns["RATE"].BestFit();
            //advView.Columns["RATE"].VisibleIndex = 5;

            //advView.Columns["SPECIAL_RATE"].Visible = true;
            advView.Columns["SPECIAL_RATE"].Caption = "Special Rate";
            advView.Columns["SPECIAL_RATE"].OptionsColumn.ReadOnly = true;
            advView.Columns["SPECIAL_RATE"].BestFit();
            //advView.Columns["SPECIAL_RATE"].VisibleIndex = 6;

            //advView.Columns["VIP_RATE"].Visible = true;
            advView.Columns["VIP_RATE"].Caption = "Premium Rate";
            advView.Columns["VIP_RATE"].OptionsColumn.ReadOnly = true;
            advView.Columns["VIP_RATE"].BestFit();
            //advView.Columns["VIP_RATE"].VisibleIndex = 7;

            //advView.Columns["IS_ACTIVE"].Visible = true;
            advView.Columns["IS_ACTIVE"].Caption = "Active";
            advView.Columns["IS_ACTIVE"].OptionsColumn.ReadOnly = true;
            advView.Columns["IS_ACTIVE"].BestFit();
            //advView.Columns["IS_ACTIVE"].VisibleIndex = 8;

            advView.BestFitColumns();
            #endregion

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SERVICE_TYPE_UID") });
            repositoryItemLookUpEdit1.DisplayMember = "SERVICE_TYPE_UID";
            repositoryItemLookUpEdit1.ValueMember = "SERVICE_TYPE_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.ShowFooter = false;
            repositoryItemLookUpEdit1.ShowHeader = false;
            repositoryItemLookUpEdit1.DataSource = ds.Tables["RIS_SERVICETYPE"];
            repositoryItemLookUpEdit1.NullText = "Service Type";
            advView.Columns["SERVICE_TYPE"].ColumnEdit = repositoryItemLookUpEdit1;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_TYPE_UID") });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_TYPE_UID";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_TYPE_ID";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.ShowFooter = false;
            repositoryItemLookUpEdit2.ShowHeader = false;
            repositoryItemLookUpEdit2.DataSource = ds.Tables["RIS_EXAMTYPE"];
            repositoryItemLookUpEdit2.NullText = "Exam Type";
            advView.Columns["EXAM_TYPE"].ColumnEdit = repositoryItemLookUpEdit2;

            RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
            chkConfirm.ValueChecked = "Y";
            //chkConfirm.ValueUnchecked = "N";
            chkConfirm.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkConfirm.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkConfirm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            advView.Columns["IS_ACTIVE"].ColumnEdit = chkConfirm;
            advView.Columns["IS_ACTIVE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            advView.OptionsView.ShowAutoFilterRow = true;
        }
        private void LoadData()
        {
            try
            {
                ProcessGetRISExam process = new ProcessGetRISExam(true);
                //process.Invoke();
                process.GetAllExam_IncludeUnActive();
                ds = new DataSet();
                ds.Tables.Add(process.Result.Tables[0].Copy());
                ds.Tables[0].TableName = "RIS_EXAM";

                ProcessGetRISServicetype processService = new ProcessGetRISServicetype(true);
                processService.Invoke();
                ds.Tables.Add(processService.Result.Tables[0].Copy());
                ds.Tables[1].TableName = "RIS_SERVICETYPE";

                ProcessGetRISExamType processExamType = new ProcessGetRISExamType();
                processExamType.Invoke();
                ds.Tables.Add(processExamType.Result.Tables[0].Copy());
                ds.Tables[2].TableName = "RIS_EXAMTYPE";

                ProcessGetHisICD processHIS = new ProcessGetHisICD();
                processHIS.Invoke();
                ds.Tables.Add(processHIS.Result.Tables[0].Copy());
                ds.Tables[3].TableName = "HIS_ICD";

                ProcessGetRISAcr processAcr = new ProcessGetRISAcr();
                processAcr.Invoke();
                ds.Tables.Add(processAcr.Result.Tables[0].Copy());
                ds.Tables[4].TableName = "RIS_ACR";

                ProcessGetRISAuthlevel processAuthen = new ProcessGetRISAuthlevel();
                processAuthen.Invoke();
                ds.Tables.Add(processAuthen.Result.Tables[0].Copy());
                ds.Tables[5].TableName = "RIS_AUTHLEVEL";

                ProcessGetHRUnit processUnit = new ProcessGetHRUnit();
                processUnit.Invoke();
                ds.Tables.Add(processUnit.Result.Tables[0].Copy());
                ds.Tables[6].TableName = "HR_UNIT";

                SetTextBoxAutoComplete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void LoadBodyPartData()
        {
            ProcessGetRISBpview getBpBodyPart = new ProcessGetRISBpview();
            dtBPBodyPart = getBpBodyPart.GetBodyPart();

            DataRow drInsert = dtBPBodyPart.NewRow();
            drInsert["BP_ID"] = 0;
            drInsert["BP_DESC"] = "None Select";
            dtBPBodyPart.Rows.InsertAt(drInsert, 0);
            lookUpBodyPart.Properties.DataSource = dtBPBodyPart;
            lookUpBodyPart.Properties.DisplayMember = "BP_DESC";
            lookUpBodyPart.Properties.ValueMember = "BP_ID";

            lookUpBodyPart.Properties.Columns.Add(new LookUpColumnInfo("BP_ID", "ID", 20));
            lookUpBodyPart.Properties.Columns.Add(new LookUpColumnInfo("BP_DESC", "Name", 80));
            lookUpBodyPart.Properties.Columns["BP_ID"].Visible = false;

            lookUpBodyPart.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

        }
        private void LoadGridBPView()
        {
            ProcessGetRISBpview getBPView = new ProcessGetRISBpview();
            getBPView.Invoke();

            DataSet dsBpview = getBPView.Result;
            dtBPView = dsBpview.Tables[0];
            dtBPView.Columns.Add("NEED_DETAIL",typeof(string));
            dtBPView.Columns.Add("SL_NO",typeof(int));
            dtBPView.Columns.Add("CHK",typeof(string));
            dtBPView.AcceptChanges();
            foreach (DataRow rows in dtBPView.Rows)
            {
                rows["NEED_DETAIL"] = "N";
                rows["SL_NO"] = 0;
                rows["CHK"] = "N";
            }

            grdBpview.DataSource = dtBPView;

            for (int i = 0; i < viewBpview.Columns.Count; i++)
                viewBpview.Columns[i].Visible = false;

            RepositoryItemCheckEdit chkSelect = new RepositoryItemCheckEdit();
            chkSelect.ValueChecked = "Y";
            chkSelect.ValueUnchecked = "N";
            chkSelect.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chkSelect.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkSelect.CheckedChanged += new EventHandler(chkSelect_CheckedChanged);
            
            viewBpview.Columns["CHK"].Caption = " ";
            viewBpview.Columns["CHK"].ColVIndex = 1;
            viewBpview.Columns["CHK"].ColumnEdit = chkSelect;
            viewBpview.Columns["CHK"].OptionsColumn.ReadOnly = false;
            viewBpview.Columns["CHK"].Width = -1;

            viewBpview.Columns["BPVIEW_NAME"].Caption = "Code";
            viewBpview.Columns["BPVIEW_NAME"].ColVIndex = 2;
            viewBpview.Columns["BPVIEW_NAME"].OptionsColumn.ReadOnly = true;

            viewBpview.Columns["BPVIEW_DESC"].Caption = "Description";
            viewBpview.Columns["BPVIEW_DESC"].ColVIndex = 3;
            viewBpview.Columns["BPVIEW_DESC"].OptionsColumn.ReadOnly = true;

            RepositoryItemCheckEdit chkNeedDetail = new RepositoryItemCheckEdit();
            chkNeedDetail.ValueChecked = "Y";
            chkNeedDetail.ValueUnchecked = "N";
            chkNeedDetail.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkNeedDetail.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chkNeedDetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            
            viewBpview.Columns["NEED_DETAIL"].Caption = "Need Detail";
            viewBpview.Columns["NEED_DETAIL"].ColVIndex = 4;
            viewBpview.Columns["NEED_DETAIL"].ColumnEdit = chkNeedDetail;
            viewBpview.Columns["NEED_DETAIL"].OptionsColumn.ReadOnly = false;

            viewBpview.Columns["SL_NO"].Caption = "Sequence";
            viewBpview.Columns["SL_NO"].ColVIndex = 5;
            viewBpview.Columns["SL_NO"].OptionsColumn.ReadOnly = false;

        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (viewBpview.FocusedRowHandle >= 0)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                DataRow row = viewBpview.GetDataRow(viewBpview.FocusedRowHandle);
                if (chk.Checked)
                    row["CHK"] = "Y";
                else
                    row["CHK"] = "N";
            }
        }
        private void SetEnableDisableControl(bool flag)
        {
            txtUnitName.Enabled = flag;
            txtICDDesc.Enabled = flag;
            txtACRDesc.Enabled = flag;
            txtServiceName.Enabled = flag;
            txtReleaseLevel.Enabled = flag;
            txtFinalizingLevel.Enabled = flag;
            txtExamTypeName.Enabled = flag;
            txtFinalizingLevel.Enabled = flag;
            txtReleaseLevel.Enabled = flag;

            txtUnitName.ReadOnly = true;
            txtICDDesc.ReadOnly = true;
            txtACRDesc.ReadOnly = true;
            txtServiceName.ReadOnly = true;
            txtReleaseLevel.ReadOnly = true;
            txtFinalizingLevel.ReadOnly = true;
            txtExamTypeName.ReadOnly = true;
            txtFinalizingLevel.ReadOnly = true;
            txtReleaseLevel.ReadOnly = true;

            txtExamCode.Enabled = flag;
            txtExamName.Enabled = flag;
            txtBillingCode.Enabled = flag;
            txtUnitCode.Enabled = flag;
            txtICDCode.Enabled = flag;
            txtACRCode.Enabled = flag;
            txtServiceType.Enabled = flag;
            txtExamType.Enabled = flag;
            txtRate.Enabled = flag;
            //chkPossibleSpecialClinic.Enabled = flag;
            chkActive.Enabled = flag;

            txtReportHeader.Enabled = flag;
            txtClaim.Enabled = flag;
            txtNonClaim.Enabled = flag;
            txtFee.Enabled = flag;
            txtAvgReq.Enabled = flag;
            txtMinReq.Enabled = flag;
            txtCostPrice.Enabled = flag;
            txtCapture.Enabled = flag;
            txtImages.Enabled = flag;
            txtRelease.Enabled = flag;
            txtFinalize.Enabled = flag;
            //chkStructureReport.Enabled = flag;
            chkCanOrderStat.Enabled = flag;
            //Code Date 25/06/2010
            chkDefer.Enabled = flag;
            chkOnlineRequest.Enabled = flag;
            //chkCanOrderUrgent.Enabled = flag;
            //chkCanbeRepeated.Enabled = flag;
            //chkNeedPrepartion.Enabled = flag;

            btnUnit.Enabled = flag;
            btnICD.Enabled = flag;
            btnACR.Enabled = flag;
            btnServiceType.Enabled = flag;
            btnExamType.Enabled = flag;
            btnRelease.Enabled = flag;
            btnFinalizing.Enabled = flag;

            lookUpBodyPart.Enabled = flag;

            txtSpRate.Enabled = flag;
            txtPreRate.Enabled = flag;

            speNonResident.Enabled = flag;
            speNonResidentSpc.Enabled = flag;
            speNonResidentVIP.Enabled = flag;

            gvModalityMapping.OptionsBehavior.Editable = flag;

            gvDFRad.OptionsBehavior.Editable = flag;
            gvDFTech.OptionsBehavior.Editable = flag;
            gvDFNurse.OptionsBehavior.Editable = flag;
            grdBpview.Enabled = flag;

            btnDFRadAdd.Enabled = flag;
            btnDFTechAdd.Enabled = flag;
            btnDFNurseAdd.Enabled = flag;

            grdExamBilling.Enabled = flag;
            btnAddExamBilling.Enabled = flag;
        }
        private void ClearText()
        {

            #region TextBox: ClearTag
            txtExamCode.Tag = null;
            txtICDCode.Tag = null;
            txtACRCode.Tag = null;
            txtServiceType.Tag = null;
            //txtCPTCode.Tag = null;
            txtRelease.Tag = null;
            txtFinalize.Tag = null;
            txtExamType.Tag = null;
            txtUnitCode.Tag = null;
            txtSpRate.Tag = null;
            txtPreRate.Tag = null;
            #endregion

            #region TextBox: ClearText
            txtExamCode.Text = string.Empty;
            txtExamName.Text = string.Empty;
            txtICDCode.Text = string.Empty;
            txtICDDesc.Text = string.Empty;
            txtACRCode.Text = string.Empty;
            txtACRDesc.Text = string.Empty;
            txtServiceType.Text = string.Empty;
            txtServiceName.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtReportHeader.Text = string.Empty;
            txtClaim.Text = string.Empty;
            txtNonClaim.Text = string.Empty;
            txtFee.Text = string.Empty;
            txtAvgReq.Text = string.Empty;
            txtMinReq.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtCapture.Text = string.Empty;
            txtImages.Text = string.Empty;
            //txtCPTCode.Text = string.Empty;
            //txtCPTDesc.Text = string.Empty;
            txtRelease.Text = string.Empty;
            txtReleaseLevel.Text = string.Empty;
            txtFinalize.Text = string.Empty;
            txtFinalizingLevel.Text = string.Empty;
            txtExamType.Text = string.Empty;
            txtExamTypeName.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtUnitName.Text = string.Empty;
            txtSpRate.Text = string.Empty;
            txtPreRate.Text = string.Empty;
            #endregion

            lookUpBodyPart.EditValue = 0;

            speNonResident.Text = string.Empty;

            chkPossibleSpecialClinic.Checked = false;
            chkActive.Checked = false;
            chkDefer.Checked = false;
            chkStructureReport.Checked = false;
            chkCanOrderStat.Checked = false;
            chkCanOrderUrgent.Checked = false;
            chkCanbeRepeated.Checked = false;
            chkNeedPrepartion.Checked = false;

        }
        private void bindingDataFocus(DataRow dr)
        {
            #region TextBox
            txtExamCode.Tag = dr["EXAM_ID"].ToString();
            txtExamCode.Text = dr["EXAM_UID"].ToString();
            txtExamName.Text = dr["EXAM_NAME"].ToString();
            txtBillingCode.Text = dr["BILLING_CODE"].ToString();
            if (ds.Tables["HIS_ICD"].Rows.Count > 0)
            {
                txtICDCode.Tag = string.IsNullOrEmpty(dr["ICD_ID"].ToString()) ? "0" : dr["ICD_ID"].ToString();
                DataRow[] rowICD = ds.Tables["HIS_ICD"].Select("ICD_ID=" + txtICDCode.Tag);
                if (rowICD.Length > 0)
                {
                    txtICDCode.Text = rowICD[0]["ICD_UID"].ToString().Trim();
                    txtICDDesc.Text = rowICD[0]["ICD_DESC"].ToString().Trim();
                }
                else
                {
                    txtICDCode.Tag = null;
                    txtICDCode.Text = string.Empty;
                    txtICDDesc.Text = string.Empty;
                }
            }
            if (ds.Tables["RIS_EXAMTYPE"].Rows.Count > 0)
            {
                txtExamType.Tag = string.IsNullOrEmpty(dr["EXAM_TYPE"].ToString().Trim()) ? "0" : dr["EXAM_TYPE"].ToString().Trim();
                DataRow[] rowExamType = ds.Tables["RIS_EXAMTYPE"].Select("EXAM_TYPE_ID=" + txtExamType.Tag);
                if (rowExamType.Length > 0)
                {
                    txtExamType.Text = rowExamType[0]["EXAM_TYPE_UID"].ToString().Trim();
                    txtExamTypeName.Text = rowExamType[0]["EXAM_TYPE_TEXT"].ToString().Trim();
                }
                else
                {
                    txtExamType.Tag = null;
                    txtExamType.Text = string.Empty;
                    txtExamTypeName.Text = string.Empty;
                }
            }
            if (ds.Tables["RIS_ACR"].Rows.Count > 0)
            {
                txtACRCode.Tag = string.IsNullOrEmpty(dr["ACR_ID"].ToString()) ? "0" : dr["ACR_ID"].ToString();
                DataRow[] rowACR = ds.Tables["RIS_ACR"].Select("ACR_ID=" + txtACRCode.Tag);
                if (rowACR.Length > 0)
                {
                    txtACRCode.Text = rowACR[0]["ACR_UID"].ToString().Trim();
                    txtACRDesc.Text = rowACR[0]["ACR_DESC"].ToString().Trim();
                }
                else
                {
                    txtACRCode.Tag = null;
                    txtACRCode.Text = string.Empty;
                    txtACRDesc.Text = string.Empty;
                }
            }
            if (ds.Tables["RIS_SERVICETYPE"].Rows.Count > 0)
            {
                txtServiceType.Tag = string.IsNullOrEmpty(dr["SERVICE_TYPE"].ToString()) ? "0" : dr["SERVICE_TYPE"].ToString();
                DataRow[] rowServiceType = ds.Tables["RIS_SERVICETYPE"].Select("SERVICE_TYPE_ID=" + txtServiceType.Tag);
                if (rowServiceType.Length > 0)
                {
                    txtServiceType.Text = rowServiceType[0]["SERVICE_TYPE_UID"].ToString().Trim();
                    txtServiceName.Text = rowServiceType[0]["SERVICE_TYPE_TEXT"].ToString().Trim();
                }
                else
                {
                    txtServiceName.Text = string.Empty;
                    txtServiceType.Text = string.Empty;
                    txtServiceType.Tag = null;
                }
            }
            if (ds.Tables["HR_UNIT"].Rows.Count > 0)
            {
                txtUnitCode.Tag = string.IsNullOrEmpty(dr["UNIT_ID"].ToString()) ? "0" : dr["UNIT_ID"].ToString();
                DataRow[] rowUnit = ds.Tables["HR_UNIT"].Select("UNIT_ID=" + txtUnitCode.Tag);
                if (rowUnit.Length > 0)
                {
                    txtUnitCode.Text = rowUnit[0]["UNIT_UID"].ToString().Trim();
                    txtUnitName.Text = rowUnit[0]["UNIT_NAME"].ToString().Trim();
                }
                else
                {
                    txtUnitCode.Tag = null;
                    txtUnitCode.Text = string.Empty;
                    txtUnitName.Text = string.Empty;

                }
            }
            if (ds.Tables["RIS_AUTHLEVEL"].Rows.Count > 0)
            {
                txtRelease.Tag = string.IsNullOrEmpty(dr["RELEASE_AUTH_LEVEL"].ToString()) ? "0" : dr["RELEASE_AUTH_LEVEL"].ToString();
                DataRow[] rowAuthLevel = ds.Tables["RIS_AUTHLEVEL"].Select("AUTH_LEVEL_ID=" + txtRelease.Tag);
                if (rowAuthLevel.Length > 0)
                {
                    txtRelease.Text = rowAuthLevel[0]["AUTH_LEVEL_UID"].ToString().Trim();
                    txtReleaseLevel.Text = rowAuthLevel[0]["AUTH_LEVEL_TEXT"].ToString().Trim();
                }
                else
                {
                    txtRelease.Tag = null;
                    txtRelease.Text = string.Empty;
                    txtReleaseLevel.Text = string.Empty;
                }
            }
            if (ds.Tables["RIS_AUTHLEVEL"].Rows.Count > 0)
            {
                txtFinalize.Tag = string.IsNullOrEmpty(dr["FINALIZE_AUTH_LEVEL"].ToString()) ? "0" : dr["FINALIZE_AUTH_LEVEL"].ToString();
                DataRow[] rowAuthFinal = ds.Tables["RIS_AUTHLEVEL"].Select("AUTH_LEVEL_ID=" + txtFinalize.Tag);
                if (rowAuthFinal.Length > 0)
                {
                    txtFinalize.Text = rowAuthFinal[0]["AUTH_LEVEL_UID"].ToString().Trim();
                    txtFinalizingLevel.Text = rowAuthFinal[0]["AUTH_LEVEL_TEXT"].ToString().Trim();
                }
                else
                {
                    txtFinalize.Tag = null;
                    txtFinalize.Text = string.Empty;
                    txtFinalizingLevel.Text = string.Empty;
                }
            }
            #endregion

            #region CheckBox
            chkActive.Checked = dr["IS_ACTIVE"].ToString().Trim() == "Y" ? true : false;
            chkDefer.Checked = dr["DEFER_HIS_RECONCILE"].ToString().Trim() == "Y" ? true : false;
            //chkPossibleSpecialClinic.Checked = dr["SPECIAL_CLINIC"].ToString().Trim() == "Y" ? true : false;
            //chkStructureReport.Checked = dr["IS_STRUCTURED_REPORT"].ToString().Trim() == "Y" ? true : false;
            //chkCanOrderStat.Checked = dr["STAT_FLAG"].ToString().Trim() == "Y" ? true : false;
            //chkCanOrderUrgent.Checked = dr["URGENT_FLAG"].ToString().Trim() == "Y" ? true : false;
            //chkCanbeRepeated.Checked = dr["REPEAT_FLAG"].ToString().Trim() == "Y" ? true : false;
            //chkNeedPrepartion.Checked = dr["PREPARATION_FLAG"].ToString().Trim() == "Y" ? true : false;


            #endregion


            lookUpBodyPart.EditValue = string.IsNullOrEmpty(dr["BP_ID"].ToString()) ? 0 : Convert.ToInt32(dr["BP_ID"]);

            txtRate.Value = string.IsNullOrEmpty(dr["RATE"].ToString()) ? 0 : Convert.ToDecimal(dr["RATE"]);
            txtSpRate.Value = string.IsNullOrEmpty(dr["SPECIAL_RATE"].ToString()) ? 0 : Convert.ToDecimal(dr["SPECIAL_RATE"]);
            txtPreRate.Value = string.IsNullOrEmpty(dr["VIP_RATE"].ToString()) ? 0 : Convert.ToDecimal(dr["VIP_RATE"]);
            speNonResident.Value = string.IsNullOrEmpty(dr["FOREIGN_RATE"].ToString()) ? 0 : Convert.ToDecimal(dr["FOREIGN_RATE"]);
            speNonResidentSpc.Value = string.IsNullOrEmpty(dr["FOREIGN_SPCIAL_RATE"].ToString()) ? 0 : Convert.ToDecimal(dr["FOREIGN_SPCIAL_RATE"]);
            speNonResidentVIP.Value = string.IsNullOrEmpty(dr["FOREIGN_VIP_RATE"].ToString()) ? 0 : Convert.ToDecimal(dr["FOREIGN_VIP_RATE"]);
            
            txtClaim.Value = string.IsNullOrEmpty(dr["CLAIMABLE_AMT"].ToString()) ? 0 : Convert.ToDecimal(dr["CLAIMABLE_AMT"]);
            txtNonClaim.Value = string.IsNullOrEmpty(dr["NONCLAIMABLE_AMT"].ToString()) ? 0 : Convert.ToDecimal(dr["NONCLAIMABLE_AMT"]);
            txtAvgReq.Value = string.IsNullOrEmpty(dr["AVG_REQ_HRS"].ToString()) ? 0 : Convert.ToDecimal(dr["AVG_REQ_HRS"]);
            txtMinReq.Value = string.IsNullOrEmpty(dr["MIN_REQ_HRS"].ToString()) ? 0 : Convert.ToDecimal(dr["MIN_REQ_HRS"]);
            txtFee.Value = string.IsNullOrEmpty(dr["FREE_AMT"].ToString()) ? 0 : Convert.ToDecimal(dr["FREE_AMT"]);
            txtCostPrice.Value = string.IsNullOrEmpty(dr["COST_PRICE"].ToString()) ? 0 : Convert.ToDecimal(dr["COST_PRICE"]);
            txtCapture.Value = string.IsNullOrEmpty(dr["DEF_CAPTURE"].ToString()) ? 0 : Convert.ToDecimal(dr["DEF_CAPTURE"]);
            txtImages.Value = string.IsNullOrEmpty(dr["DEF_IMAGES"].ToString()) ? 0 : Convert.ToDecimal(dr["DEF_IMAGES"]);

            foreach (DataRow clrrows in dtBPView.Rows)
            {
                clrrows["NEED_DETAIL"] = "N";
                clrrows["SL_NO"] = 0;
                clrrows["CHK"] = "N";
            }
            ProcessGetRISBpviewMapping bpMap = new ProcessGetRISBpviewMapping();
            bpMap.RIS_BPVIEWMAPPING.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
            bpMap.Invoke();
            DataSet dsBPMapping = bpMap.ResultSet;
            foreach (DataRow rows in dsBPMapping.Tables[0].Rows)
            {
                DataRow[] row = dtBPView.Select("BPVIEW_ID=" + rows["BPVIEW_ID"].ToString());
                if(row.Length>0)
                {
                    row[0]["CHK"] = "Y";
                    row[0]["NEED_DETAIL"] = rows["NEED_DETAIL"];
                    row[0]["SL_NO"] = rows["SL_NO"];
                }
                dtBPView.AcceptChanges();
            }
        }

        #region Lookup
        private void btnICD_Click(object sender, EventArgs e)
        {
            //            Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ICD);

            //            string qry = @"
            //                        select
            //	                        ICD_UID
            //	                        ,ICD_ID
            //	                        ,ICD_DESC
            //                        from
            //	                        HIS_ICD
            //                        where 
            //                            ICD_UID like '%%'
            //                            or  ICD_DESC like '%%'";

            //            string fields = "ICD Code,ICD ID,Description";
            //            string con = "";
            //            lv.getData(qry, fields, con, "ICD Search");
            //            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_ICD);
            lv.AddColumn("ICD_ID", "ICD ID", false, true);
            lv.AddColumn("ICD_UID", "ICD Code", true, true);
            lv.AddColumn("ICD_DESC", "Description", true, true);
            lv.Text = "ICD Search";

            ProcessGetHisICD getLookup = new ProcessGetHisICD();
            getLookup.Invoke();

            lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_ICD(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtICDCode.Tag = retValue[0];
            txtICDCode.Text = retValue[1];
            txtICDDesc.Text = retValue[2];
            btnACR.Focus();
        }

        private void btnACR_Click(object sender, EventArgs e)
        {
            //            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ACR);

            //            string qry = @"                
            //                select
            //	                ACR_UID
            //	                ,ACR_ID
            //	                ,ACR_DESC
            //                from
            //	                RIS_ACR
            //                where
            //                    ACR_UID like '%%'
            //                    or ACR_DESC like '%%'";

            //            string fields = "ACR Code,ARC ID,Description";
            //            string con = "";
            //            lv.getData(qry, fields, con, "ACR Search");
            //            lv.Show();


            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_ACR);
            lv.AddColumn("ACR_ID", "ARC ID", false, true);
            lv.AddColumn("ACR_UID", "ACR Code", true, true);
            lv.AddColumn("ACR_DESC", "Description", true, true);
            lv.Text = "ACR Search";

            ProcessGetRISAcr getLookup = new ProcessGetRISAcr();
            getLookup.Invoke();

            lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_ACR(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtACRCode.Tag = retValue[0];
            txtACRCode.Text = retValue[1];
            txtACRDesc.Text = retValue[2];
            btnServiceType.Focus();
        }

        private void btnServiceType_Click(object sender, EventArgs e)
        {
            //            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ServiceType);

            //            string qry = @"
            //                       select
            //	                        SERVICE_TYPE_UID
            //	                        ,SERVICE_TYPE_ID
            //	                        ,SERVICE_TYPE_TEXT
            //                        from
            //	                        dbo.RIS_SERVICETYPE
            //                        where
            //                            SERVICE_TYPE_UID like '%%' or SERVICE_TYPE_TEXT like '%%'";

            //            string fields = "Service Code,Service ID,Description";
            //            string con = "";
            //            lv.getData(qry, fields, con, "Service Search");
            //            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_ServiceType);
            lv.AddColumn("SERVICE_TYPE_ID", "Service ID", false, true);
            lv.AddColumn("SERVICE_TYPE_UID", "Service Code", true, true);
            lv.AddColumn("SERVICE_TYPE_TEXT", "Description", true, true);
            lv.Text = "Service Search";

            ProcessGetRISServicetype getLookup = new ProcessGetRISServicetype(true);
            getLookup.Invoke();

            lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_ServiceType(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtServiceType.Tag = retValue[0];
            txtServiceType.Text = retValue[1];
            txtServiceName.Text = retValue[2];
            btnExamType.Focus();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ICD);

            //            string qry = @"
            //                select
            //                    REG_ID
            //                    ,HN
            //                    ,FNAME
            //                    ,LNAME
            //                from
            //                    HIS_REGISTRATION
            //                where
            //                    FNAME Like '%%'";

            //            string fields = "HN,ชื่อ,นามสกุล";
            //            string con = "";
            //            lv.getData(qry, fields, con, "HN Search");
            //            lv.Show();

            //LookupData lv = new LookupData();
            //lv.ValueUpdated += new ValueUpdatedEventHandler(find_Capture);
            //lv.AddColumn("SERVICE_TYPE_ID", "Service ID", false, true);
            //lv.AddColumn("SERVICE_TYPE_UID", "Service Code", true, true);
            //lv.AddColumn("SERVICE_TYPE_TEXT", "Description", true, true);
            //lv.Text = "Service Search";

            //ProcessGetRISServicetype getLookup = new ProcessGetRISServicetype(true);
            //getLookup.Invoke();

            //lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            //lv.Size = new Size(600, 400);
            //lv.ShowBox(); 
        }
        private void find_Capture(object sender, ValueUpdatedEventArgs e)
        {
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            //            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Release);

            //            string qry = @"
            //                    select
            //                        AUTH_LEVEL_UID
            //                        ,AUTH_LEVEL_ID
            //                        ,AUTH_LEVEL_TEXT
            //
            //                    from
            //                        RIS_AUTHLEVEL
            //                    where
            //                        AUTH_LEVEL_UID like '%%'";

            //            string fields = "Release Code,Release ID,Description";
            //            string con = "";
            //            lv.getData(qry, fields, con, "Release Search");
            //            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_Release);
            lv.AddColumn("AUTH_LEVEL_ID", "Release ID", false, true);
            lv.AddColumn("AUTH_LEVEL_UID", "Release Code", true, true);
            lv.AddColumn("AUTH_LEVEL_TEXT", "Description", true, true);
            lv.Text = "Release Search";

            ProcessGetRISAuthlevel getLookup = new ProcessGetRISAuthlevel();
            getLookup.Invoke();

            lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Release(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtRelease.Tag = retValue[0];
            txtRelease.Text = retValue[1];
            txtReleaseLevel.Text = retValue[2];
        }

        private void btnFinalizing_Click(object sender, EventArgs e)
        {
            //            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Finalizing);

            //            string qry = @"
            //                    select
            //                        AUTH_LEVEL_UID
            //                        ,AUTH_LEVEL_ID
            //                        ,AUTH_LEVEL_TEXT
            //
            //                    from
            //                        RIS_AUTHLEVEL
            //                    where
            //                        AUTH_LEVEL_UID like '%%'";

            //            string fields = "Finalizing Code,Finalizing ID,Description";
            //            string con = "";
            //            lv.getData(qry, fields, con, "Finalizing Search");
            //            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_Finalizing);
            lv.AddColumn("AUTH_LEVEL_ID", "Finalizing ID", false, true);
            lv.AddColumn("AUTH_LEVEL_UID", "Finalizing Code", true, true);
            lv.AddColumn("AUTH_LEVEL_TEXT", "Description", true, true);
            lv.Text = "Finalizing Search";

            ProcessGetRISAuthlevel getLookup = new ProcessGetRISAuthlevel();
            getLookup.Invoke();

            lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Finalizing(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtFinalize.Tag = retValue[0];
            txtFinalize.Text = retValue[1];
            txtFinalizingLevel.Text = retValue[2];
        }

        private void btnExamType_Click(object sender, EventArgs e)
        {
            //            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ExamType);

            //            string qry = @"
            //                select  
            //                    EXAM_TYPE_UID
            //                    ,EXAM_TYPE_ID
            //                    ,EXAM_TYPE_TEXT
            //                from 
            //                    dbo.RIS_EXAMTYPE
            //                where
            //                    (EXAM_TYPE_UID like '%%' or EXAM_TYPE_TEXT like '%%')
            //                    AND IS_ACTIVE = 'Y'";

            //            string fields = "Exam Type,Exam ID,Description";
            //            string con = "";
            //            lv.getData(qry, fields, con, "ExamType Search");
            //            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_ExamType);
            lv.AddColumn("EXAM_TYPE_ID", "Exam ID", false, true);
            lv.AddColumn("EXAM_TYPE_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_TYPE_TEXT", "Description", true, true);
            lv.Text = "ExamType Search";

            ProcessGetRISExamType getLookup = new ProcessGetRISExamType();
            getLookup.Invoke();

            lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_ExamType(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtExamType.Tag = retValue[0];
            txtExamType.Text = retValue[1];
            txtExamTypeName.Text = retValue[2];
            txtRate.Focus();
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            //            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            //            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_UnitCode);

            //            string qry = @"
            //                	select
            //		                UNIT_UID
            //		                ,UNIT_ID
            //		                ,UNIT_NAME
            //	                from
            //		                HR_UNIT
            //                where
            //                        UNIT_UID like '%%' or UNIT_NAME like '%%'";

            //            string fields = "Unit Code,Unit ID,Unit Name";
            //            string con = "";
            //            lv.getData(qry, fields, con, "Unit Search");
            //            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(find_UnitCode);
            lv.AddColumn("UNIT_ID", "Unit ID", false, true);
            lv.AddColumn("UNIT_UID", "Unit Code", true, true);
            lv.AddColumn("UNIT_NAME", "Description", true, true);
            lv.Text = "Unit Search";

            ProcessGetHRUnit getLookup = new ProcessGetHRUnit();
            getLookup.Invoke();

            lv.Data = getLookup.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_UnitCode(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtUnitCode.Tag = retValue[0];
            txtUnitCode.Text = retValue[1];
            txtUnitName.Text = retValue[2];
        }
        #endregion

        #region Grid Double-Click
        private void advView_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.GetShowEditorMode() != DevExpress.Utils.EditorShowMode.MouseDown)
                setTickCount(view, e);
        }
        private void advView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.GetShowEditorMode() != DevExpress.Utils.EditorShowMode.MouseUp)
                setTickCount(view, e);
        }
        private void advView_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if ((System.Environment.TickCount - clickTick) < SystemInformation.DoubleClickTime)
            {
                view.ActiveEditor.MouseDown += new MouseEventHandler(Editor_MouseDown);
                activeEditor = view.ActiveEditor;
            }
        }
        private void advView_HiddenEditor(object sender, EventArgs e)
        {
            if (activeEditor != null)
            {
                activeEditor.MouseDown -= new MouseEventHandler(Editor_MouseDown);
                activeEditor = null;
            }
        }
        private int getClickedRow(GridView view, Point pt)
        {
            GridHitInfo hi = view.CalcHitInfo(pt);
            return hi.RowHandle;
        }
        private void setTickCount(GridView view, System.Windows.Forms.MouseEventArgs e)
        {
            if (view.IsDataRow(getClickedRow(view, new Point(e.X, e.Y))))
                clickTick = System.Environment.TickCount;
            else
                clickTick = 0;
        }
        private void DoDoubleClickRow(GridView view, int rowHandle)
        {
            DataRow dr = view.GetDataRow(rowHandle);
            bindingDataFocus(dr);
        }
        private void Editor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //BaseEdit editor = sender as BaseEdit;
            //if ((System.Environment.TickCount - clickTick) < SystemInformation.DoubleClickTime)
            //{
            //    if (firstClickFlag)
            //    {
            //        firstClickFlag = false;
            //        return;
            //    }
            //    GridView view = (editor.Parent as GridControl).FocusedView as GridView;
            //    int rowHandle = view.FocusedRowHandle;
            //    DoDoubleClickRow(view, rowHandle);
            //}
            //clickTick = System.Environment.TickCount;
        }
        private void advView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (advView.FocusedRowHandle >= 0)
            {
                ReloadDFSetting();
                ReloadModalityMapping();
                LoadExamBillingData();
                bindingDataFocus(advView.GetDataRow(advView.FocusedRowHandle));
            }
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtExamCode.Tag != null)
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                grdData.Enabled = false;
                SetEnableDisableControl(true);
                //if (groupBoxMaster.Expanded == false)
                //    groupBoxMaster.Expanded = true;
                txtExamCode.Focus();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;

            grdData.Enabled = true;

            SetEnableDisableControl(false);
            //SetNavigator();

            LoadData();
            SetGridData();

            ReloadModalityMapping();
            ReloadDFSetting();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            #region Require Check
            if (txtExamCode.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1006", env.CurrentLanguageID);
                txtExamCode.Focus();
                return;
            }
            if (txtBillingCode.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1006", env.CurrentLanguageID);
                txtExamCode.Focus();
                return;
            }
            if (txtExamName.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1007", env.CurrentLanguageID);
                txtExamName.Focus();
                return;
            }
            if (txtUnitCode.Tag == null || txtUnitCode.Tag.ToString().Trim() == string.Empty)
            {
                msg.ShowAlert("UID1011", env.CurrentLanguageID);
                txtUnitCode.Focus();
                return;
            }
            if (txtServiceType.Tag == null || txtServiceType.Tag.ToString().Trim() == string.Empty)
            {
                msg.ShowAlert("UID1008", env.CurrentLanguageID);
                txtServiceType.Focus();
                return;
            }
            if (txtExamType.Tag == null || txtExamType.Tag.ToString().Trim() == string.Empty)
            {
                msg.ShowAlert("UID1009", env.CurrentLanguageID);
                txtExamType.Focus();
                return;
            }


            #endregion

            string str = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                SaveModalityMapping();
                InsertDFSetting();
                insertOrUpdateBpviewMapping();
                InsertExamBillingData();

                if (txtExamCode.Tag == null)
                    InsertData();
                else
                    UpdateData();

                LoadData();
                SetGridData();
                ReloadModalityMapping();
                ReloadDFSetting();
                LoadExamBillingData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtExamCode.Tag != null)
            {
                //if (groupBoxMaster.Expanded == false)
                //    groupBoxMaster.Expanded = true;
                string str = msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
                if (str == "2")
                {
                    try
                    {
                        ProcessDeleteRISExam process = new ProcessDeleteRISExam();
                        process.RIS_EXAM.EXAM_ID = Convert.ToInt32(txtExamCode.Tag);
                        process.Invoke();
                        LoadData();
                        SetGridData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            grdData.Enabled = false;
            //groupBoxMaster.Enabled = true;

            ClearText();
            txtExamCode.Focus();
            SetEnableDisableControl(true);
            chkPossibleSpecialClinic.Checked = false;
            chkActive.Checked = false;
            chkDefer.Checked = true;
            chkStructureReport.Checked = false;
            chkCanOrderStat.Checked = false;
            chkCanOrderUrgent.Checked = false;
            chkCanbeRepeated.Checked = false;
            chkNeedPrepartion.Checked = false;
            //if (groupBoxMaster.Expanded == false)
            //    groupBoxMaster.Expanded = true;
            txtExamCode.Focus();
        }

        private void InsertData()
        {
            try
            {
                ProcessAddRISExam processAdd = new ProcessAddRISExam();
                processAdd.RIS_EXAM.EXAM_UID = txtExamCode.Text;
                processAdd.RIS_EXAM.EXAM_NAME = txtExamName.Text;
                processAdd.RIS_EXAM.ICD_ID = txtICDCode.Tag == null || txtICDCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtICDCode.Tag);
                processAdd.RIS_EXAM.ACR_ID = txtACRCode.Tag == null || txtACRCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtACRCode.Tag);
                processAdd.RIS_EXAM.SERVICE_TYPE = txtServiceType.Tag.ToString();
                processAdd.RIS_EXAM.EXAM_TYPE = Convert.ToInt32(txtExamType.Tag);
                processAdd.RIS_EXAM.RATE = Convert.ToDecimal(txtRate.Text);
                processAdd.RIS_EXAM.SPECIAL_CLINIC = chkPossibleSpecialClinic.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.IS_ACTIVE = chkActive.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.DEFER_HIS_RECONCILE = chkDefer.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.REPORT_HEADER = txtReportHeader.Text.Trim();
                processAdd.RIS_EXAM.CLAIMABLE_AMT = Convert.ToDecimal(txtClaim.Text);
                processAdd.RIS_EXAM.NONCLAIMABLE_AMT = Convert.ToDecimal(txtNonClaim.Text);
                processAdd.RIS_EXAM.FREE_AMT = Convert.ToDecimal(txtFee.Text);
                processAdd.RIS_EXAM.AVG_REQ_HRS = Convert.ToDecimal(txtAvgReq.Text);
                processAdd.RIS_EXAM.MIN_REQ_HRS = Convert.ToDecimal(txtMinReq.Text);
                processAdd.RIS_EXAM.COST_PRICE = Convert.ToDecimal(txtCostPrice.Text);
                processAdd.RIS_EXAM.DEF_CAPTURE = Convert.ToByte(txtCapture.Text);
                if (txtImages.Text.Trim().Length < 1) processAdd.RIS_EXAM.DEF_IMAGES = null;
                else processAdd.RIS_EXAM.DEF_IMAGES = Convert.ToByte(txtImages.Text);
                processAdd.RIS_EXAM.UNIT_ID = Convert.ToInt32(txtUnitCode.Tag);
                //processAdd.RISExam.CPT_ID = Convert.ToInt32(txtCPTCode.Tag);
                processAdd.RIS_EXAM.FINALIZE_AUTH_LEVEL = txtFinalize.Tag == null || txtFinalize.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtFinalize.Tag);
                processAdd.RIS_EXAM.RELEASE_AUTH_LEVEL = txtRelease.Tag == null || txtRelease.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtRelease.Tag);
                processAdd.RIS_EXAM.IS_STRUCTURED_REPORT = chkStructureReport.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.STAT_FLAG = chkCanOrderStat.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.URGENT_FLAG = chkCanOrderUrgent.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.REPEAT_FLAG = chkCanbeRepeated.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.PREPARATION_FLAG = chkNeedPrepartion.Checked ? 'Y' : 'N';
                processAdd.RIS_EXAM.CREATED_BY = new GBLEnvVariable().UserID.ToString();
                processAdd.RIS_EXAM.ORG_ID = new GBLEnvVariable().OrgID;
                processAdd.RIS_EXAM.BP_ID = Convert.ToInt32(lookUpBodyPart.EditValue.ToString());
                processAdd.RIS_EXAM.SPECIAL_RATE = txtSpRate.Value;
                processAdd.RIS_EXAM.VIP_RATE = txtPreRate.Value;
                processAdd.RIS_EXAM.QA_REQUIRED = 'Y';
                processAdd.RIS_EXAM.FOREIGN_RATE = speNonResident.Value;
                processAdd.RIS_EXAM.FOREIGN_SPCIAL_RATE = speNonResidentSpc.Value;
                processAdd.RIS_EXAM.FOREIGN_VIP_RATE = speNonResidentVIP.Value;
                processAdd.RIS_EXAM.BILLING_CODE = txtBillingCode.Text.Trim();
                processAdd.Invoke();
                //msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);
                SetEnableDisableControl(false);


                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                grdData.Enabled = false;
                //groupBoxMaster.Enabled = true;

                ClearText();
                txtExamCode.Focus();
                SetEnableDisableControl(true);
                chkPossibleSpecialClinic.Checked = false;
                chkActive.Checked = false;
                chkDefer.Checked = true;
                chkStructureReport.Checked = false;
                chkCanOrderStat.Checked = false;
                chkCanOrderUrgent.Checked = false;
                chkCanbeRepeated.Checked = false;
                chkNeedPrepartion.Checked = false;
                txtExamCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void UpdateData()
        {
            try
            {
                ProcessUpdateRISExam process = new ProcessUpdateRISExam();
                process.RIS_EXAM.EXAM_ID = Convert.ToInt32(txtExamCode.Tag);
                process.RIS_EXAM.EXAM_UID = txtExamCode.Text;
                process.RIS_EXAM.EXAM_NAME = txtExamName.Text;
                process.RIS_EXAM.ICD_ID = txtICDCode.Tag == null || txtICDCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtICDCode.Tag);
                process.RIS_EXAM.ACR_ID = txtACRCode.Tag == null || txtACRCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtACRCode.Tag);
                process.RIS_EXAM.SERVICE_TYPE = txtServiceType.Tag.ToString();
                process.RIS_EXAM.EXAM_TYPE = Convert.ToInt32(txtExamType.Tag);
                process.RIS_EXAM.RATE = Convert.ToDecimal(txtRate.Text);
                process.RIS_EXAM.SPECIAL_CLINIC = chkPossibleSpecialClinic.Checked ? 'Y' : 'N';
                process.RIS_EXAM.IS_ACTIVE = chkActive.Checked ? 'Y' : 'N';
                process.RIS_EXAM.DEFER_HIS_RECONCILE = chkDefer.Checked ? 'Y' : 'N';
                process.RIS_EXAM.REPORT_HEADER = txtReportHeader.Text.Trim();
                process.RIS_EXAM.CLAIMABLE_AMT = Convert.ToDecimal(txtClaim.Text);
                process.RIS_EXAM.NONCLAIMABLE_AMT = Convert.ToDecimal(txtNonClaim.Text);
                process.RIS_EXAM.FREE_AMT = Convert.ToDecimal(txtFee.Text);
                process.RIS_EXAM.AVG_REQ_HRS = Convert.ToDecimal(txtAvgReq.Text);
                process.RIS_EXAM.MIN_REQ_HRS = Convert.ToDecimal(txtMinReq.Text);
                process.RIS_EXAM.COST_PRICE = Convert.ToDecimal(txtCostPrice.Text);
                process.RIS_EXAM.DEF_CAPTURE = Convert.ToByte(txtCapture.Text);
                if (txtImages.Text.Trim().Length < 1) process.RIS_EXAM.DEF_IMAGES = null;
                else process.RIS_EXAM.DEF_IMAGES = Convert.ToByte(txtImages.Text);
                //process.RISExam.CPT_ID = Convert.ToInt32(txtCPTCode.Tag);
                process.RIS_EXAM.UNIT_ID = Convert.ToInt32(txtUnitCode.Tag);
                process.RIS_EXAM.FINALIZE_AUTH_LEVEL = txtFinalize.Tag == null || txtFinalize.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtFinalize.Tag);
                process.RIS_EXAM.RELEASE_AUTH_LEVEL = txtRelease.Tag == null || txtRelease.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtRelease.Tag);
                process.RIS_EXAM.IS_STRUCTURED_REPORT = chkStructureReport.Checked ? 'Y' : 'N';
                process.RIS_EXAM.STAT_FLAG = chkCanOrderStat.Checked ? 'Y' : 'N';
                process.RIS_EXAM.URGENT_FLAG = chkCanOrderUrgent.Checked ? 'Y' : 'N';
                process.RIS_EXAM.REPEAT_FLAG = chkCanbeRepeated.Checked ? 'Y' : 'N';
                process.RIS_EXAM.PREPARATION_FLAG = chkNeedPrepartion.Checked ? 'Y' : 'N';
                process.RIS_EXAM.CREATED_BY = new GBLEnvVariable().UserID.ToString();
                process.RIS_EXAM.ORG_ID = new GBLEnvVariable().OrgID;
                process.RIS_EXAM.BP_ID = Convert.ToInt32(lookUpBodyPart.EditValue.ToString());
                process.RIS_EXAM.SPECIAL_RATE = txtSpRate.Value;
                process.RIS_EXAM.VIP_RATE = txtPreRate.Value;
                process.RIS_EXAM.FOREIGN_RATE = speNonResident.Value;
                process.RIS_EXAM.FOREIGN_SPCIAL_RATE = speNonResidentSpc.Value;
                process.RIS_EXAM.FOREIGN_VIP_RATE = speNonResidentVIP.Value;
                process.RIS_EXAM.QA_REQUIRED = 'Y';
                process.RIS_EXAM.BILLING_CODE = txtBillingCode.Text.Trim();
                process.Invoke();

                //msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);
                SetEnableDisableControl(false);

                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;

                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;

                grdData.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void insertOrUpdateBpviewMapping()
        {
            ProcessDeleteRISBPViewMapping delBpviewMap = new ProcessDeleteRISBPViewMapping();
            delBpviewMap.RIS_BPVIEWMAPPING.EXAM_ID = Convert.ToInt32(txtExamCode.Tag);
            delBpviewMap.Invoke();

            foreach (DataRow row in dtBPView.Rows)
            {
                if (row["CHK"].ToString() == "Y")
                {
                    ProcessAddRISBpviewMapping addBpviewMap = new ProcessAddRISBpviewMapping();
                    addBpviewMap.RIS_BPVIEWMAPPING.EXAM_ID = Convert.ToInt32(txtExamCode.Tag);
                    addBpviewMap.RIS_BPVIEWMAPPING.BPVIEW_ID = Convert.ToInt32(row["BPVIEW_ID"]);
                    addBpviewMap.RIS_BPVIEWMAPPING.NEED_DETAIL = row["NEED_DETAIL"].ToString();
                    addBpviewMap.RIS_BPVIEWMAPPING.SL_NO = Convert.ToByte(row["SL_NO"]);
                    addBpviewMap.RIS_BPVIEWMAPPING.CREATED_BY = env.UserID;
                    addBpviewMap.Invoke();
                }
            }

        }
        private void SetTextBoxAutoComplete()
        {
            AutoCompleteStringCollection icdCode = new AutoCompleteStringCollection();
            AutoCompleteStringCollection acrCode = new AutoCompleteStringCollection();
            AutoCompleteStringCollection serviceType = new AutoCompleteStringCollection();
            AutoCompleteStringCollection examType = new AutoCompleteStringCollection();
            AutoCompleteStringCollection unitCode = new AutoCompleteStringCollection();
            AutoCompleteStringCollection authorize = new AutoCompleteStringCollection();

            foreach (DataRow dr in ds.Tables["HIS_ICD"].Rows)
                icdCode.Add(dr["ICD_UID"].ToString());
            foreach (DataRow dr in ds.Tables["RIS_ACR"].Rows)
                acrCode.Add(dr["ACR_UID"].ToString());
            foreach (DataRow dr in ds.Tables["RIS_SERVICETYPE"].Rows)
                serviceType.Add(dr["SERVICE_TYPE_UID"].ToString());
            foreach (DataRow dr in ds.Tables["RIS_EXAMTYPE"].Rows)
                examType.Add(dr["EXAM_TYPE_UID"].ToString());
            foreach (DataRow dr in ds.Tables["RIS_AUTHLEVEL"].Rows)
                authorize.Add(dr["AUTH_LEVEL_UID"].ToString());
            foreach (DataRow dr in ds.Tables["HR_UNIT"].Rows)
                unitCode.Add(dr["UNIT_UID"].ToString());

            txtICDCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtICDCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtICDCode.AutoCompleteCustomSource = icdCode;

            txtACRCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtACRCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtACRCode.AutoCompleteCustomSource = acrCode;

            txtServiceType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtServiceType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtServiceType.AutoCompleteCustomSource = serviceType;

            txtExamType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtExamType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtExamType.AutoCompleteCustomSource = examType;

            txtUnitCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUnitCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUnitCode.AutoCompleteCustomSource = unitCode;

            txtFinalize.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtFinalize.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtFinalize.AutoCompleteCustomSource = authorize;

            txtRelease.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtRelease.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRelease.AutoCompleteCustomSource = authorize;


        }

        #region Keypress and Validating
        private void txtICDCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtICDCode.Text.Trim().Length > 0)
            {
                bool flag = true;
                foreach (DataRow dr in ds.Tables["HIS_ICD"].Rows)
                {
                    if (txtICDCode.Text.Trim().ToUpper() == dr["ICD_UID"].ToString().Trim().ToUpper())
                    {
                        txtICDCode.Tag = dr["ICD_ID"].ToString();
                        txtICDCode.Text = dr["ICD_UID"].ToString();
                        txtICDDesc.Text = dr["ICD_DESC"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1000", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    txtACRCode.Focus();
                }
            }
            else
            {
                txtICDCode.Text = string.Empty;
                txtICDCode.Tag = null;
                txtICDDesc.Text = string.Empty;
                e.Cancel = false;
                btnICD.Focus();
            }
        }
        private void txtICDCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtACRCode.Focus();
        }

        private void txtACRCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtACRCode.Text.Trim().Length > 0)
            {
                bool flag = true;
                foreach (DataRow dr in ds.Tables["RIS_ACR"].Rows)
                {
                    if (txtACRCode.Text.Trim().ToUpper() == dr["ACR_UID"].ToString().Trim().ToUpper())
                    {
                        txtACRCode.Tag = dr["ACR_ID"].ToString();
                        txtACRCode.Text = dr["ACR_UID"].ToString();
                        txtACRDesc.Text = dr["ACR_DESC"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1001", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    txtServiceType.Focus();
                }
            }
            else
            {
                txtACRCode.Text = string.Empty;
                txtACRCode.Tag = null;
                txtACRDesc.Text = string.Empty;
                e.Cancel = false;
                btnACR.Focus();
            }
        }
        private void txtACRCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtServiceType.Focus();
        }

        private void txtServiceType_Validating(object sender, CancelEventArgs e)
        {
            if (txtServiceType.Text.Trim().Length > 0)
            {
                bool flag = true;
                foreach (DataRow dr in ds.Tables["RIS_SERVICETYPE"].Rows)
                {
                    if (txtServiceType.Text.Trim().ToUpper() == dr["SERVICE_TYPE_UID"].ToString().Trim().ToUpper())
                    {
                        txtServiceType.Tag = dr["SERVICE_TYPE_ID"].ToString();
                        txtServiceType.Text = dr["SERVICE_TYPE_UID"].ToString();
                        txtServiceName.Text = dr["SERVICE_TYPE_TEXT"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1002", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    txtExamType.Focus();
                }
            }
            else
            {
                txtServiceType.Text = string.Empty;
                txtServiceType.Tag = null;
                txtServiceName.Text = string.Empty;
                e.Cancel = false;
                btnServiceType.Focus();
            }
        }
        private void txtServiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExamType.Focus();
        }

        private void txtExamType_Validating(object sender, CancelEventArgs e)
        {
            if (txtExamType.Text.Trim().Length > 0)
            {
                bool flag = true;
                foreach (DataRow dr in ds.Tables["RIS_EXAMTYPE"].Rows)
                {
                    if (txtExamType.Text.Trim().ToUpper() == dr["EXAM_TYPE_UID"].ToString().Trim().ToUpper())
                    {
                        txtExamType.Tag = dr["EXAM_TYPE_ID"].ToString();
                        txtExamType.Text = dr["EXAM_TYPE_UID"].ToString();
                        txtExamTypeName.Text = dr["EXAM_TYPE_TEXT"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1003", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    txtRate.Focus();
                }
            }
            else
            {
                txtExamType.Text = string.Empty;
                txtExamType.Tag = null;
                txtExamTypeName.Text = string.Empty;
                e.Cancel = false;
                btnExamType.Focus();
            }
        }
        private void txtExamType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRate.Focus();
        }

        private void txtRate_Validating(object sender, CancelEventArgs e)
        {
            decimal decResult;
            if (Decimal.TryParse(txtRate.Text, out decResult))
            {
                if (decResult < 0)
                    txtRate.Text = "0";
                if (txtRate.Tag == null)
                    txtRate.Tag = txtRate.Text;
                else if (txtRate.Tag.ToString().Trim() != txtRate.Text.Trim())
                {
                    //txtClaim.Text = "0";
                    txtNonClaim.Text = "0";
                    txtFee.Text = "0";
                    txtRate.Tag = txtRate.Text;
                }
            }
        }
        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                //chkPossibleSpecialClinic.Focus();
                chkActive.Focus();
        }

        private void txtRelease_Validating(object sender, CancelEventArgs e)
        {
            if (txtRelease.Text.Trim().Length > 0)
            {
                bool flag = true;
                foreach (DataRow dr in ds.Tables["RIS_AUTHLEVEL"].Rows)
                {
                    if (txtRelease.Text.Trim().ToUpper() == dr["AUTH_LEVEL_UID"].ToString().Trim().ToUpper())
                    {
                        txtRelease.Tag = dr["AUTH_LEVEL_ID"].ToString();
                        txtRelease.Text = dr["AUTH_LEVEL_UID"].ToString();
                        txtReleaseLevel.Text = dr["AUTH_LEVEL_TEXT"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1004", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    txtFinalize.Focus();
                }
            }
            else
            {
                txtRelease.Text = string.Empty;
                txtRelease.Tag = null;
                txtReleaseLevel.Text = string.Empty;
                e.Cancel = false;
                btnRelease.Focus();
            }
        }
        private void txtRelease_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtFinalize_Validating(object sender, CancelEventArgs e)
        {
            if (txtFinalize.Text.Trim().Length > 0)
            {
                bool flag = true;
                foreach (DataRow dr in ds.Tables["RIS_AUTHLEVEL"].Rows)
                {
                    if (txtFinalize.Text.Trim().ToUpper() == dr["AUTH_LEVEL_UID"].ToString().Trim().ToUpper())
                    {
                        txtFinalize.Tag = dr["AUTH_LEVEL_ID"].ToString();
                        txtFinalize.Text = dr["AUTH_LEVEL_UID"].ToString();
                        txtFinalizingLevel.Text = dr["AUTH_LEVEL_TEXT"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1005", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    btnSave.Select();
                }
            }
            else
            {
                txtFinalize.Text = string.Empty;
                txtFinalize.Tag = null;
                txtFinalizingLevel.Text = string.Empty;
                e.Cancel = false;
                btnFinalizing.Focus();
            }
        }
        private void txtFinalize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                chkStructureReport.Focus();
        }

        private void txtCapture_Validating(object sender, CancelEventArgs e)
        {
            int decResult;
            if (int.TryParse(txtCapture.Text, out decResult))
            {
                if (decResult < 0 && decResult > 255)
                    txtRate.Text = "0";
            }
        }
        private void txtImages_Validating(object sender, CancelEventArgs e)
        {
            int decResult;
            if (int.TryParse(txtImages.Text, out decResult))
            {
                if (decResult < 0 && decResult > 255)
                    txtRate.Text = "0";
            }
        }

        private void txtClaim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNonClaim.Focus();
        }
        private void txtClaim_Validating(object sender, CancelEventArgs e)
        {
            //decimal decResult;
            //if (Decimal.TryParse(txtClaim.Text, out decResult))
            //{
            //    if (decResult < 0)
            //        txtClaim.Text = "0";
            //    CalRate();           
            //    txtNonClaim.Focus();
            //}

            //string str = txtClaim.Text.Remove(txtClaim.Text.LastIndexOf('%'));
            //decimal decResult = Convert.ToDecimal(str);
            //if (decResult > 100)
            //{
            //    decResult=100;
            //    txtClaim.Text = "0.00";
            //}

            //string str = txtClaim.Text.Remove(txtClaim.Text.IndexOf("%"),1);
            //try { str = str.Remove(str.IndexOf(","), 1); }catch (Exception) { }
            //str = str.Remove(str.IndexOf("."),3);
            //string str = txtClaim.Text;
            //int int1 = Convert.ToInt32(float.Parse(str));

            //if (int1 > 100)
            //{
            //    txtClaim.Value = 100;
            //}
        }

        private void txtNonClaim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFee.Focus();
        }
        private void txtNonClaim_Validating(object sender, CancelEventArgs e)
        {
            //decimal decResult;
            //if (Decimal.TryParse(txtNonClaim.Text, out decResult))
            //{
            //    if (decResult < 0)
            //        txtNonClaim.Text = "0";
            //    CalRate();
            //    txtFee.Focus();
            //}

            //string str = txtNonClaim.Text.Remove(txtNonClaim.Text.LastIndexOf('%'));
            //decimal decResult = Convert.ToDecimal(str);
            //if (decResult > 100)
            //{
            //    decResult = 100;
            //    txtNonClaim.Text = "0.0";
            //}
        }

        private void txtFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAvgReq.Focus();
        }
        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            //decimal decResult;
            //if (Decimal.TryParse(txtFee.Text, out decResult))
            //{
            //    if (decResult < 0)
            //        txtFee.Text = "0";
            //    CalRate();
            //    txtAvgReq.Focus();
            //}
            //string str = txtFee.Text.Remove(txtFee.Text.LastIndexOf('%'));
            //decimal decResult = Convert.ToDecimal(str);
            //if (decResult > 100)
            //{
            //    decResult = 100;
            //    txtFee.Text = "0.0";
            //}
        }

        private void txtCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCapture.Focus();

        }
        private void txtCostPrice_Validating(object sender, CancelEventArgs e)
        {
            decimal decResult;
            if (Decimal.TryParse(txtCostPrice.Text, out decResult))
            {
                if (decResult < 0)
                    txtCostPrice.Text = "0";
                decimal rate = decimal.Parse(txtRate.Text);
                if (decResult > rate)
                {
                    MessageBox.Show("COSTPRICE MUST BE BELOW RATE");
                    e.Cancel = true;
                }
            }
        }

        private void txtUnitCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtICDCode.Focus();
        }
        private void txtUnitCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtUnitCode.Text.Trim().Length > 0)
            {
                bool flag = true;
                foreach (DataRow dr in ds.Tables["HR_UNIT"].Rows)
                {
                    if (txtUnitCode.Text.Trim().ToUpper() == dr["UNIT_UID"].ToString().Trim().ToUpper())
                    {
                        txtUnitCode.Tag = dr["UNIT_ID"].ToString();
                        txtUnitCode.Text = dr["UNIT_UID"].ToString();
                        txtUnitName.Text = dr["UNIT_NAME"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1010", env.CurrentLanguageID);
                    txtExamCode.Tag = null;
                    txtExamName.Text = string.Empty;
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    txtICDCode.Focus();
                }
            }
            else
            {
                txtUnitCode.Tag = string.Empty;
                txtUnitCode.Text = string.Empty;
                txtUnitName.Text = string.Empty;
                e.Cancel = false;
                btnUnit.Focus();
            }
        }

        private void txtExamCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExamName.Focus();
        }
        private void txtExamName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUnitCode.Focus();
        }
        private void txtReportHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtClaim.Focus();
        }
        private void txtAvgReq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMinReq.Focus();
        }
        private void txtMinReq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCostPrice.Focus();

        }
        private void txtCapture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtImages.Focus();
        }
        private void txtImages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRelease.Focus();
        }

        private void txtAvgReq_Validating(object sender, CancelEventArgs e)
        {
            decimal decResult;
            if (Decimal.TryParse(txtAvgReq.Text, out decResult))
            {
                if (decResult < 0)
                    txtAvgReq.Text = "0";
                CalRate();
                txtMinReq.Focus();
            }
        }
        private void txtMinReq_Validating(object sender, CancelEventArgs e)
        {
            decimal decResult;
            if (Decimal.TryParse(txtMinReq.Text, out decResult))
            {
                if (decResult < 0)
                    txtMinReq.Text = "0";
                //txtCapture.Focus();
                txtCostPrice.Focus();
            }
        }
        #endregion

        private void groupBoxMaster_ExpandedStateChanged(object sender, EventArgs e)
        {
            //Infragistics.Win.Misc.UltraExpandableGroupBox expand = sender as Infragistics.Win.Misc.UltraExpandableGroupBox;
            //int h = expand.Expanded ? -300 : 300;
            //System.Drawing.Size s = new Size(grdData.Size.Width, grdData.Size.Height + h);
            //grdData.Size = s;
        }
        private void CalRate()
        {
            //decimal claim = 0;
            //decimal nonClaim = 0;
            //decimal free = 0;
            //decimal rate = 0;

            //decimal.TryParse(txtClaim.Text.Remove(txtClaim.Text.IndexOf("%")), out claim);
            //decimal.TryParse(txtNonClaim.Text.Remove(txtNonClaim.Text.IndexOf("%")), out nonClaim);
            //decimal.TryParse(txtFee.Text.Remove(txtFee.Text.IndexOf("%")), out free);
            //rate = claim + nonClaim + free;
            //txtRate.Text = rate.ToString();
            //txtRate.Tag = rate;

        }

        private void txtUnitCode_Validated(object sender, EventArgs e)
        {
            //if (txtUnitCode.Tag != null)
            //{
            //    if (txtUnitCode.Text == string.Empty)
            //    {
            //        foreach (DataRow dr in ds.Tables["HR_UNIT"].Rows)
            //        {
            //            if (txtUnitCode.Tag.ToString().Trim().ToUpper() == dr["UNIT_ID"].ToString().Trim().ToUpper())
            //            {

            //                txtUnitCode.Text = dr["UNIT_UID"].ToString();
            //                break;
            //            }
            //        }
            //    }
            //}
        }
        private void RIS_SF11_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;
        }
        private void txtExamName_VisibleChanged(object sender, EventArgs e)
        {
            txtUnitCode.Focus();
        }
        private void txtExamCode_Validating(object sender, CancelEventArgs e)
        {
            txtExamName.Focus();
        }
        private void chkActive_Validating(object sender, CancelEventArgs e)
        {
            chkCanOrderStat.Focus();
        }
        private void chkCanOrderStat_Validating(object sender, CancelEventArgs e)
        {
            txtReportHeader.Focus();
        }
        private void chkActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                chkCanOrderStat.Focus();
        }
        private void chkCanOrderStat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReportHeader.Focus();
        }
        List<int> BP_ID = new List<int>();
        public void RISBodyPartSelectData()
        {

        }

        private void LoadModalityMappingData()
        {
            DataRow row = advView.GetDataRow(advView.FocusedRowHandle);
            int exam_id = Convert.ToInt32(row["EXAM_ID"]);

            ProcessGetRISModality getMod = new ProcessGetRISModality();
            DataSet ds = getMod.GetModalityForExamSetup(exam_id);
            dtModMap = ds.Tables[0].Copy();
        }
        private void LoadModalityMappingFilter()
        {

        }
        private void LoadModalityMappingGrid()
        {
            gcModalityMapping.DataSource = dtModMap;

            gvModalityMapping.OptionsView.ColumnAutoWidth = true;

            foreach (BandedGridColumn col in gvModalityMapping.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
                col.Visible = false;
            }

            gvModalityMapping.Columns["MODALITY_NAME"].Caption = "Modality Name";
            gvModalityMapping.Columns["MODALITY_NAME"].ColVIndex = 1;

            gvModalityMapping.Columns["MODALITY_CODE"].Caption = "Modality Code";
            gvModalityMapping.Columns["MODALITY_CODE"].ColVIndex = 2;

            gvModalityMapping.Columns["IS_ACTIVE"].Caption = "Active";
            gvModalityMapping.Columns["IS_ACTIVE"].ColVIndex = 3;
            gvModalityMapping.Columns["IS_ACTIVE"].OptionsColumn.AllowEdit = true;
            //gvModalityMapping.Columns["IS_ACTIVE"].OptionsColumn.FixedWidth = true;
            //gvModalityMapping.Columns["IS_ACTIVE"].Width = 60;

            gvModalityMapping.Columns["IS_DEFAULT_MODALITY"].Caption = "Default";
            gvModalityMapping.Columns["IS_DEFAULT_MODALITY"].ColVIndex = 4;
            gvModalityMapping.Columns["IS_DEFAULT_MODALITY"].OptionsColumn.AllowEdit = true;
            //gvModalityMapping.Columns["IS_DEFAULT_MODALITY"].OptionsColumn.FixedWidth = true;
            //gvModalityMapping.Columns["IS_DEFAULT_MODALITY"].Width = 60;

            //gvModalityMapping.Columns["colDel"].Caption = "";
            //gvModalityMapping.Columns["colDel"].ColVIndex = 4;

            RepositoryItemCheckEdit chk1 = new RepositoryItemCheckEdit();
            chk1.ValueChecked = "Y";
            chk1.ValueGrayed = "N";
            chk1.ValueUnchecked = "N";
            chk1.CheckStateChanged += new EventHandler(IsActive_CheckStateChanged);
            gvModalityMapping.Columns["IS_ACTIVE"].ColumnEdit = chk1;

            RepositoryItemCheckEdit chk2 = new RepositoryItemCheckEdit();
            chk2.ValueChecked = "Y";
            chk2.ValueGrayed = "N";
            chk2.ValueUnchecked = "N";
            chk2.CheckStateChanged += new EventHandler(IsDefault_CheckStateChanged);
            gvModalityMapping.Columns["IS_DEFAULT_MODALITY"].ColumnEdit = chk2;

            //RepositoryItemButtonEdit btn1 = new RepositoryItemButtonEdit();
            //btn1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //btn1.Buttons.Clear();
            //EditorButton eb = new EditorButton();
            //eb.Kind = ButtonPredefines.Delete;
            //eb.Width = 50;
            //btn1.Buttons.Add(eb);
            //btn1.ButtonPressed += new ButtonPressedEventHandler(Delete_ButtonPressed);
            //gvModalityMapping.Columns["colDel"].ColumnEdit = btn1;

            if (gvModalityMapping.RowCount < 100)
                gvModalityMapping.BestFitColumns();
        }
        private void ReloadModalityMapping()
        {
            if (advView.FocusedRowHandle < 0) return;

            stopAllEvents = true;
            LoadModalityMappingData();
            LoadModalityMappingFilter();
            LoadModalityMappingGrid();
            stopAllEvents = false;
        }

        #region Modality Mapping
        private void IsActive_CheckStateChanged(object sender, EventArgs e)
        {
            if (stopAllEvents) return;
            if (gvModalityMapping.FocusedRowHandle > -1)
            {
                DataRow row = gvModalityMapping.GetDataRow(gvModalityMapping.FocusedRowHandle);
                int tbIndex = dtModMap.Rows.IndexOf(row);
                if (dtModMap.Rows[tbIndex]["IS_ACTIVE"].ToString() == "Y")
                    dtModMap.Rows[tbIndex]["IS_ACTIVE"] = "N";
                else if ((dtModMap.Rows[tbIndex]["IS_ACTIVE"].ToString() == "N"))
                    dtModMap.Rows[tbIndex]["IS_ACTIVE"] = "Y";
                dtModMap.AcceptChanges();
            }
        }
        private void IsDefault_CheckStateChanged(object sender, EventArgs e)
        {
            //if (stopAllEvents) return;
            //if (checkStateChange) { checkStateChange = false; return; }
            //if (gvModalityMapping.FocusedRowHandle > -1)
            //{
            //    DataRow row = gvModalityMapping.GetDataRow(gvModalityMapping.FocusedRowHandle);
            //    int tbIndex = dtModMap_New.Rows.IndexOf(row);

            //    #region Check Default Condition
            //    if (dtModMap_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "N")
            //    {
            //        int exam_id = Convert.ToInt32(row["EXAM_ID"]);
            //        int modality_id = Convert.ToInt32(row["MODALITY_ID"]);
            //        ProcessGetRISModality getDupl = new ProcessGetRISModality();
            //        DataSet dsCheck = getDupl.GetCheckDuplicateIsDefault(exam_id, modality_id);
            //        if (Miracle.Util.Utilities.IsHaveData(dsCheck))
            //        {
            //            DataRow[] drs = dsCheck.Tables[0].Select("ISNULL(IS_DEFAULT_MODALITY,'N') = 'Y'");
            //            if (drs.Length > 0)
            //            {
            //                MyMessageBox msg = new MyMessageBox();
            //                string msgAck = msg.ShowAlert("UID2123", new GBLEnvVariable().CurrentLanguageID);
            //                if (msgAck == "1")
            //                {
            //                    checkStateChange = true;
            //                    DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            //                    chk.CheckState = CheckState.Unchecked;
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //    #endregion

            //    if (dtModMap_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "Y")
            //        dtModMap_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "N";
            //    else if ((dtModMap_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "N"))
            //        dtModMap_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "Y";
            //    dtModMap_New.AcceptChanges();
            //}

            if (stopAllEvents) return;
            DataRow row = gvModalityMapping.GetDataRow(gvModalityMapping.FocusedRowHandle);
            int tbIndex = dtModMap.Rows.IndexOf(row);

            //foreach (DataRow rowTemp in dtModMap_New.Rows)
            //{
            //    rowTemp["IS_DEFAULT_MODALITY"] = "N";
            //}
            //dtModMap_New.AcceptChanges();

            if (dtModMap.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "N")
            {
                foreach (DataRow dr in dtModMap.Rows)
                    dr["IS_DEFAULT_MODALITY"] = "N";
            }
            dtModMap.AcceptChanges();

            if (dtModMap.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "Y")
                dtModMap.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "N";
            else if ((dtModMap.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "N"))
                dtModMap.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "Y";
            dtModMap.AcceptChanges();
        }
        private void Delete_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (gvModalityMapping.FocusedRowHandle > -1)
            {
                DataRow row = gvModalityMapping.GetDataRow(gvModalityMapping.FocusedRowHandle);
                dtModMap.Rows.Remove(row);
                dtModMap.AcceptChanges();
            }

        }
        private void SaveModalityMapping()
        {
            DataTable tbUpdate = dtModMap.Clone();
            #region row was updated
            foreach (DataRow mr in dtModMap.Rows)
            {
                //string examid = mr["EXAM_ID"].ToString();
                //string isactive = mr["IS_ACTIVE"].ToString().Trim().ToUpper();
                //string isdefault = mr["IS_DEFAULT_MODALITY"].ToString().Trim().ToUpper();
                //DataRow[] rows = dtModMap_New.Select("EXAM_ID=" + examid + " AND (IS_ACTIVE<>'" + isactive + "' OR IS_DEFAULT_MODALITY<>'" + isdefault + "')");
                //if (rows.Length > 0)
                //{
                //    mr["IS_ACTIVE"] = rows[0]["IS_ACTIVE"];
                //    mr["IS_DEFAULT_MODALITY"] = rows[0]["IS_DEFAULT_MODALITY"];
                //    tbUpdate.Rows.Add(mr.ItemArray);
                //}

                tbUpdate.Rows.Add(mr.ItemArray);
            }
            #endregion

            #region clear update row
            foreach (DataRow dr in tbUpdate.Rows)
            {
                ProcessUpdateRISModalityexam processUpdateDetails = new ProcessUpdateRISModalityexam();
                processUpdateDetails.RIS_MODALITYEXAM.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                processUpdateDetails.RIS_MODALITYEXAM.EXAM_ID = (int)dr["EXAM_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_ACTIVE"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_DEFAULT_MODALITY"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_DELETED = dr["IS_DELETED"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_DELETED"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_UPDATED"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.MODALITY_EXAM_ID = (int)dr["MODALITY_EXAM_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.MODALITY_ID = (int)dr["MODALITY_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.ORG_ID = new GBLEnvVariable().OrgID;
                processUpdateDetails.RIS_MODALITYEXAM.QA_BYPASS = dr["QA_BYPASS"].ToString().Trim().Length == 0 ? null : (char?)dr["QA_BYPASS"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.TECH_BYPASS = dr["TECH_BYPASS"].ToString().Trim().Length == 0 ? null : (char?)dr["TECH_BYPASS"].ToString().Trim()[0];
                //processUpdateDetails.RISModalityexam.CREATED_BY =(int) dr["CREATED_BY"];
                processUpdateDetails.Invoke();
            }
            #endregion
        }
        #endregion

        private void LoadDFSettingData()
        {
            DataRow row = advView.GetFocusedDataRow();
            int examID = Convert.ToInt32(row["EXAM_ID"]);

            ProcessGetRISExamDF getExamDF = new ProcessGetRISExamDF();
            getExamDF.RIS_EXAMDF.EXAM_ID = examID;
            dsExamDF = getExamDF.GetData();

            #region Rad Data Setup
            dtRadTmp = new DataTable();
            dtRadTmp.Columns.Add("SL_NO");
            dtRadTmp.Columns.Add("DF_RGL");
            dtRadTmp.Columns.Add("DF_SPC");
            dtRadTmp.Columns.Add("DF_PRM");
            dtRadTmp.Columns.Add("EXAM_DF_ID_RGL");
            dtRadTmp.Columns.Add("EXAM_DF_ID_SPC");
            dtRadTmp.Columns.Add("EXAM_DF_ID_PRM");
            dtRadTmp.Columns.Add("colDelete");
            DataTable dtRad = dsExamDF.Tables[0].Copy();
            foreach (DataRow dr in dtRad.Rows)
            {
                DataRow[] tmpRow = dtRadTmp.Select("SL_NO=" + dr["SL_NO"].ToString());
                if (tmpRow.Length == 0)
                {
                    DataRow nRow = dtRadTmp.NewRow();
                    nRow["SL_NO"] = Convert.ToInt32(dr["SL_NO"]);
                    nRow["DF_RGL"] = 0;
                    nRow["DF_SPC"] = 0;
                    nRow["DF_PRM"] = 0;
                    dtRadTmp.Rows.Add(nRow);
                    dtRadTmp.AcceptChanges();
                }

                tmpRow = dtRadTmp.Select("SL_NO=" + dr["SL_NO"].ToString());
                if (dr["CLINIC_TYPE"].ToString() == "R")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_RGL"] = Convert.ToInt32(tmpFRow["DF_RGL"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_RGL"] = dr["EXAM_DF_ID"];
                }
                else if (dr["CLINIC_TYPE"].ToString() == "S")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_SPC"] = Convert.ToInt32(tmpFRow["DF_SPC"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_SPC"] = dr["EXAM_DF_ID"];
                }
                else if (dr["CLINIC_TYPE"].ToString() == "P")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_PRM"] = Convert.ToInt32(tmpFRow["DF_PRM"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_PRM"] = dr["EXAM_DF_ID"];
                }

                dtRadTmp.AcceptChanges();
            }
            #endregion

            #region Tech Data Setup
            dtTechTmp = new DataTable();
            dtTechTmp.Columns.Add("SL_NO");
            dtTechTmp.Columns.Add("DF_RGL");
            dtTechTmp.Columns.Add("DF_SPC");
            dtTechTmp.Columns.Add("DF_PRM");
            dtTechTmp.Columns.Add("EXAM_DF_ID_RGL");
            dtTechTmp.Columns.Add("EXAM_DF_ID_SPC");
            dtTechTmp.Columns.Add("EXAM_DF_ID_PRM");
            dtTechTmp.Columns.Add("colDelete");
            DataTable dtTech = dsExamDF.Tables[1].Copy();
            foreach (DataRow dr in dtTech.Rows)
            {
                DataRow[] tmpRow = dtTechTmp.Select("SL_NO=" + dr["SL_NO"].ToString());
                if (tmpRow.Length == 0)
                {
                    DataRow nRow = dtTechTmp.NewRow();
                    nRow["SL_NO"] = Convert.ToInt32(dr["SL_NO"]);
                    nRow["DF_RGL"] = 0;
                    nRow["DF_SPC"] = 0;
                    nRow["DF_PRM"] = 0;
                    dtTechTmp.Rows.Add(nRow);
                    dtTechTmp.AcceptChanges();
                }

                tmpRow = dtTechTmp.Select("SL_NO=" + dr["SL_NO"].ToString());
                if (dr["CLINIC_TYPE"].ToString() == "R")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_RGL"] = Convert.ToInt32(tmpFRow["DF_RGL"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_RGL"] = dr["EXAM_DF_ID"];
                }
                else if (dr["CLINIC_TYPE"].ToString() == "S")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_SPC"] = Convert.ToInt32(tmpFRow["DF_SPC"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_SPC"] = dr["EXAM_DF_ID"];
                }
                else if (dr["CLINIC_TYPE"].ToString() == "P")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_PRM"] = Convert.ToInt32(tmpFRow["DF_PRM"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_PRM"] = dr["EXAM_DF_ID"];
                }

                dtTechTmp.AcceptChanges();
            }
            #endregion

            #region Nurse Data Setup
            dtNurseTmp = new DataTable();
            dtNurseTmp.Columns.Add("SL_NO");
            dtNurseTmp.Columns.Add("DF_RGL");
            dtNurseTmp.Columns.Add("DF_SPC");
            dtNurseTmp.Columns.Add("DF_PRM");
            dtNurseTmp.Columns.Add("EXAM_DF_ID_RGL");
            dtNurseTmp.Columns.Add("EXAM_DF_ID_SPC");
            dtNurseTmp.Columns.Add("EXAM_DF_ID_PRM");
            dtNurseTmp.Columns.Add("colDelete");
            DataTable dtNurse = dsExamDF.Tables[2].Copy();
            foreach (DataRow dr in dtNurse.Rows)
            {
                DataRow[] tmpRow = dtNurseTmp.Select("SL_NO=" + dr["SL_NO"].ToString());
                if (tmpRow.Length == 0)
                {
                    DataRow nRow = dtNurseTmp.NewRow();
                    nRow["SL_NO"] = Convert.ToInt32(dr["SL_NO"]);
                    nRow["DF_RGL"] = 0;
                    nRow["DF_SPC"] = 0;
                    nRow["DF_PRM"] = 0;
                    dtNurseTmp.Rows.Add(nRow);
                    dtNurseTmp.AcceptChanges();
                }

                tmpRow = dtNurseTmp.Select("SL_NO=" + dr["SL_NO"].ToString());
                if (dr["CLINIC_TYPE"].ToString() == "R")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_RGL"] = Convert.ToInt32(tmpFRow["DF_RGL"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_RGL"] = dr["EXAM_DF_ID"];
                }
                else if (dr["CLINIC_TYPE"].ToString() == "S")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_SPC"] = Convert.ToInt32(tmpFRow["DF_SPC"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_SPC"] = dr["EXAM_DF_ID"];
                }
                else if (dr["CLINIC_TYPE"].ToString() == "P")
                {
                    DataRow tmpFRow = tmpRow[0];
                    tmpFRow["DF_PRM"] = Convert.ToInt32(tmpFRow["DF_PRM"]) + Convert.ToInt32(dr["DF"]);
                    tmpFRow["EXAM_DF_ID_PRM"] = dr["EXAM_DF_ID"];
                }

                dtNurseTmp.AcceptChanges();
            }
            #endregion
        }
        private void LoadDFSettingFilter()
        {

        }
        private void LoadDFSettingGrid()
        {
            gcDFRad.DataSource = dtRadTmp;
            gcDFTech.DataSource = dtTechTmp;
            gcDFNurse.DataSource = dtNurseTmp;

            #region Rad Column setup
            gvDFRad.Columns["SL_NO"].Caption = "Level";
            gvDFRad.Columns["SL_NO"].OptionsColumn.AllowEdit = false;

            gvDFRad.Columns["DF_RGL"].Caption = "Regular";
            gvDFRad.Columns["DF_SPC"].Caption = "Special";
            gvDFRad.Columns["DF_PRM"].Caption = "Premium";

            gvDFRad.Columns["EXAM_DF_ID_RGL"].Visible = false;
            gvDFRad.Columns["EXAM_DF_ID_SPC"].Visible = false;
            gvDFRad.Columns["EXAM_DF_ID_PRM"].Visible = false;

            RepositoryItemButtonEdit btnDeleteRad = new RepositoryItemButtonEdit();
            btnDeleteRad.AutoHeight = false;
            btnDeleteRad.BestFitWidth = 15;
            btnDeleteRad.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btnDeleteRad.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDeleteRad.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDeleteRad.Buttons[0].Caption = string.Empty;
            btnDeleteRad.Click += new EventHandler(btnDeleteRad_Click);
            gvDFRad.Columns["colDelete"].Caption = string.Empty;
            gvDFRad.Columns["colDelete"].ColumnEdit = btnDeleteRad;
            gvDFRad.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gvDFRad.Columns["colDelete"].Width = 15;
            gvDFRad.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spinDFRadRGL = new RepositoryItemSpinEdit();
            //spinDFRadRGL.EditValueChanged += new EventHandler(spinDFRadRGL_EditValueChanged);
            gvDFRad.Columns["DF_RGL"].ColumnEdit = spinDFRadRGL;

            RepositoryItemSpinEdit spinDFRadSPC = new RepositoryItemSpinEdit();
            //spinDFRadSPC.EditValueChanged += new EventHandler(spinDFRadSPC_EditValueChanged);
            gvDFRad.Columns["DF_SPC"].ColumnEdit = spinDFRadSPC;

            RepositoryItemSpinEdit spinDFRadPRM = new RepositoryItemSpinEdit();
            //spinDFRadPRM.EditValueChanged += new EventHandler(spinDFRadPRM_EditValueChanged);
            gvDFRad.Columns["DF_PRM"].ColumnEdit = spinDFRadPRM;
            #endregion

            #region Tech Column setup
            gvDFTech.Columns["SL_NO"].Caption = "Level";
            gvDFTech.Columns["SL_NO"].OptionsColumn.AllowEdit = false;

            gvDFTech.Columns["DF_RGL"].Caption = "Regular";
            gvDFTech.Columns["DF_SPC"].Caption = "Special";
            gvDFTech.Columns["DF_PRM"].Caption = "Premium";

            gvDFTech.Columns["EXAM_DF_ID_RGL"].Visible = false;
            gvDFTech.Columns["EXAM_DF_ID_SPC"].Visible = false;
            gvDFTech.Columns["EXAM_DF_ID_PRM"].Visible = false;

            RepositoryItemButtonEdit btnDeleteTech = new RepositoryItemButtonEdit();
            btnDeleteTech.AutoHeight = false;
            btnDeleteTech.BestFitWidth = 15;
            btnDeleteTech.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btnDeleteTech.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDeleteTech.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDeleteTech.Buttons[0].Caption = string.Empty;
            btnDeleteTech.Click += new EventHandler(btnDeleteTech_Click);
            gvDFTech.Columns["colDelete"].Caption = string.Empty;
            gvDFTech.Columns["colDelete"].ColumnEdit = btnDeleteTech;
            gvDFTech.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gvDFTech.Columns["colDelete"].Width = 15;
            gvDFTech.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spinDFRegularTech = new RepositoryItemSpinEdit();
            //spinDFRegularTech.EditValueChanged += new EventHandler(spinDFTechRGL_EditValueChanged);
            gvDFTech.Columns["DF_RGL"].ColumnEdit = spinDFRegularTech;

            RepositoryItemSpinEdit spinDFSpecialTech = new RepositoryItemSpinEdit();
            //spinDFSpecialTech.EditValueChanged += new EventHandler(spinDFTechSPC_EditValueChanged);
            gvDFTech.Columns["DF_SPC"].ColumnEdit = spinDFSpecialTech;

            RepositoryItemSpinEdit spinDFPremiumTech = new RepositoryItemSpinEdit();
            //spinDFPremiumTech.EditValueChanged += new EventHandler(spinDFTechPRM_EditValueChanged);
            gvDFTech.Columns["DF_PRM"].ColumnEdit = spinDFPremiumTech;
            #endregion

            #region Nurse Column setup
            gvDFNurse.Columns["SL_NO"].Caption = "Level";
            gvDFNurse.Columns["SL_NO"].OptionsColumn.AllowEdit = false;

            gvDFNurse.Columns["DF_RGL"].Caption = "Regular";
            gvDFNurse.Columns["DF_SPC"].Caption = "Special";
            gvDFNurse.Columns["DF_PRM"].Caption = "Premium";

            gvDFNurse.Columns["EXAM_DF_ID_RGL"].Visible = false;
            gvDFNurse.Columns["EXAM_DF_ID_SPC"].Visible = false;
            gvDFNurse.Columns["EXAM_DF_ID_PRM"].Visible = false;

            RepositoryItemButtonEdit btnDeleteNurse = new RepositoryItemButtonEdit();
            btnDeleteNurse.AutoHeight = false;
            btnDeleteNurse.BestFitWidth = 15;
            btnDeleteNurse.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btnDeleteNurse.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDeleteNurse.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDeleteNurse.Buttons[0].Caption = string.Empty;
            btnDeleteNurse.Click += new EventHandler(btnDeleteNurse_Click);
            gvDFNurse.Columns["colDelete"].Caption = string.Empty;
            gvDFNurse.Columns["colDelete"].ColumnEdit = btnDeleteNurse;
            gvDFNurse.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gvDFNurse.Columns["colDelete"].Width = 15;
            gvDFNurse.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spinDFRegularNurse = new RepositoryItemSpinEdit();
            //spinDFRegularNurse.EditValueChanged += new EventHandler(spinDFNurseRGL_EditValueChanged);
            gvDFNurse.Columns["DF_RGL"].ColumnEdit = spinDFRegularNurse;

            RepositoryItemSpinEdit spinDFSpecialNurse = new RepositoryItemSpinEdit();
            //spinDFSpecialNurse.EditValueChanged += new EventHandler(spinDFNurseSPC_EditValueChanged);
            gvDFNurse.Columns["DF_SPC"].ColumnEdit = spinDFSpecialNurse;

            RepositoryItemSpinEdit spinDFPremiumNurse = new RepositoryItemSpinEdit();
            //spinDFPremiumNurse.EditValueChanged += new EventHandler(spinDFNursePRM_EditValueChanged);
            gvDFNurse.Columns["DF_PRM"].ColumnEdit = spinDFPremiumNurse;
            #endregion
        }
        private void ReloadDFSetting()
        {
            if (advView.FocusedRowHandle < 0)
            {
                DataTable tmpRad = (DataTable)gcDFRad.DataSource;
                gcDFRad.DataSource = tmpRad.Clone().Copy();

                DataTable tmpTech = (DataTable)gcDFTech.DataSource;
                gcDFTech.DataSource = tmpRad.Clone().Copy();

                DataTable tmpNurse = (DataTable)gcDFNurse.DataSource;
                gcDFNurse.DataSource = tmpRad.Clone().Copy();

                return;
            }

            deletedList = new List<int>();

            LoadDFSettingData();
            LoadDFSettingFilter();
            LoadDFSettingGrid();
        }

        #region Exam DF
        private void InsertDFSetting()
        {
            if (advView.FocusedRowHandle < 0) return;

            int EXAM_ID = Convert.ToInt32(advView.GetFocusedDataRow()["EXAM_ID"]);
            dtRadTmp.AcceptChanges();
            dtTechTmp.AcceptChanges();
            dtNurseTmp.AcceptChanges();
            gvDFRad.SelectRow(0);

            // delete data list
            foreach (int EXAM_DF_ID in deletedList)
            {
                ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                updateDF.RIS_EXAMDF.EXAM_DF_ID = EXAM_DF_ID;
                updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                updateDF.UpdateDataIsDeleted();
            }

            // Rad update data
            foreach (DataRow dr in dtRadTmp.Rows)
            {
                #region DF Regular
                if (dr["EXAM_DF_ID_RGL"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_RGL"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'R';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'R';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_RGL"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'R';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'R';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_RGL"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion

                #region DF Special
                if (dr["EXAM_DF_ID_SPC"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_SPC"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'R';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'S';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_SPC"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'R';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'S';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_SPC"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion

                #region DF Premium
                if (dr["EXAM_DF_ID_PRM"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_PRM"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'R';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'P';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_PRM"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'R';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'P';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_PRM"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion
            }

            //Tech update data
            foreach (DataRow dr in dtTechTmp.Rows)
            {
                #region DF Regular
                if (dr["EXAM_DF_ID_RGL"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_RGL"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'T';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'R';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_RGL"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'T';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'R';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_RGL"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion

                #region DF Special
                if (dr["EXAM_DF_ID_SPC"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_SPC"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'T';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'S';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_SPC"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'T';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'S';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_SPC"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion

                #region DF Premium
                if (dr["EXAM_DF_ID_PRM"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_PRM"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'T';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'P';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_PRM"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'T';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'P';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_PRM"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion
            }

            //Nurse update data
            foreach (DataRow dr in dtNurseTmp.Rows)
            {
                #region DF Regular
                if (dr["EXAM_DF_ID_RGL"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_RGL"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'N';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'R';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_RGL"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'N';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'R';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_RGL"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion

                #region DF Special
                if (dr["EXAM_DF_ID_SPC"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_SPC"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'N';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'S';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_SPC"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'N';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'S';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_SPC"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion

                #region DF Premium
                if (dr["EXAM_DF_ID_PRM"].ToString().Length > 0)
                {
                    ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                    updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_PRM"]);
                    updateDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    updateDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    updateDF.RIS_EXAMDF.JOB_TYPE = 'N';
                    updateDF.RIS_EXAMDF.CLINIC_TYPE = 'P';
                    updateDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_PRM"]);
                    updateDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    updateDF.RIS_EXAMDF.LAST_UPDATED_BY = new GBLEnvVariable().UserID;
                    updateDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    updateDF.RIS_EXAMDF.IS_DELETED = 'N';
                    updateDF.UpdateData();
                }
                else
                {
                    ProcessAddRISExamDF addDF = new ProcessAddRISExamDF();
                    addDF.RIS_EXAMDF.EXAM_ID = EXAM_ID;
                    addDF.RIS_EXAMDF.SL_NO = Convert.ToInt32(dr["SL_NO"]);
                    addDF.RIS_EXAMDF.JOB_TYPE = 'N';
                    addDF.RIS_EXAMDF.CLINIC_TYPE = 'P';
                    addDF.RIS_EXAMDF.DF = Convert.ToDecimal(dr["DF_PRM"]);
                    addDF.RIS_EXAMDF.ORG_ID = new GBLEnvVariable().OrgID;
                    addDF.RIS_EXAMDF.CREATED_BY = new GBLEnvVariable().UserID;
                    addDF.RIS_EXAMDF.IS_ACTIVE = 'Y';
                    addDF.RIS_EXAMDF.IS_DELETED = 'N';
                    addDF.AddData();
                }
                #endregion
            }
        }

        private void btnDeleteRad_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string strMsg = msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (strMsg == "1") return;

            if (advView.FocusedRowHandle < 0) return;
            if (gvDFRad.FocusedRowHandle < 0) return;
            DataRow dr = gvDFRad.GetFocusedDataRow();

            if (dr["EXAM_DF_ID_RGL"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_RGL"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_RGL"]));
            }

            if (dr["EXAM_DF_ID_SPC"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_SPC"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_SPC"]));
            }

            if (dr["EXAM_DF_ID_PRM"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_PRM"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_PRM"]));
            }

            //ReloadDFSetting();
            dtRadTmp.Rows.Remove(dr);
            dtRadTmp.AcceptChanges();
            gvDFRad.RefreshData();
        }
        private void btnDeleteTech_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string strMsg = msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (strMsg == "1") return;

            if (advView.FocusedRowHandle < 0) return;
            if (gvDFTech.FocusedRowHandle < 0) return;
            DataRow dr = gvDFTech.GetFocusedDataRow();

            if (dr["EXAM_DF_ID_RGL"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_RGL"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_RGL"]));
            }

            if (dr["EXAM_DF_ID_SPC"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_SPC"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_SPC"]));
            }

            if (dr["EXAM_DF_ID_PRM"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_PRM"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_PRM"]));
            }

            //ReloadDFSetting();
            dtTechTmp.Rows.Remove(dr);
            dtTechTmp.AcceptChanges();
            gvDFTech.RefreshData();
        }
        private void btnDeleteNurse_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string strMsg = msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (strMsg == "1") return;

            if (advView.FocusedRowHandle < 0) return;
            if (gvDFNurse.FocusedRowHandle < 0) return;
            DataRow dr = gvDFNurse.GetFocusedDataRow();

            if (dr["EXAM_DF_ID_RGL"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_RGL"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_RGL"]));
            }

            if (dr["EXAM_DF_ID_SPC"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_SPC"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_SPC"]));
            }

            if (dr["EXAM_DF_ID_PRM"].ToString().Length > 0)
            {
                //ProcessUpdateRISExamDF updateDF = new ProcessUpdateRISExamDF();
                //updateDF.RIS_EXAMDF.EXAM_DF_ID = Convert.ToInt32(dr["EXAM_DF_ID_PRM"]);
                //updateDF.RIS_EXAMDF.IS_DELETED = 'Y';
                //updateDF.UpdateDataIsDeleted();
                deletedList.Add(Convert.ToInt32(dr["EXAM_DF_ID_PRM"]));
            }

            //ReloadDFSetting();
            dtNurseTmp.Rows.Remove(dr);
            dtNurseTmp.AcceptChanges();
            gvDFNurse.RefreshData();
        }

        private void spinDFRadRGL_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFRad.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFRad.GetFocusedDataRow();
            int rowIdx = dtRadTmp.Rows.IndexOf(row);
            dtRadTmp.Rows[rowIdx]["DF_RGL"] = spnEdit.EditValue;
            dtRadTmp.AcceptChanges();
        }
        private void spinDFRadSPC_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFRad.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFRad.GetFocusedDataRow();
            int rowIdx = dtRadTmp.Rows.IndexOf(row);
            dtRadTmp.Rows[rowIdx]["DF_SPC"] = spnEdit.EditValue;
            dtRadTmp.AcceptChanges();
        }
        private void spinDFRadPRM_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFRad.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFRad.GetFocusedDataRow();
            int rowIdx = dtRadTmp.Rows.IndexOf(row);
            dtRadTmp.Rows[rowIdx]["DF_PRM"] = spnEdit.EditValue;
            dtRadTmp.AcceptChanges();
        }

        private void spinDFTechRGL_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFTech.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFTech.GetFocusedDataRow();
            int rowIdx = dtTechTmp.Rows.IndexOf(row);
            dtTechTmp.Rows[rowIdx]["DF_RGL"] = spnEdit.EditValue;
            dtTechTmp.AcceptChanges();
        }
        private void spinDFTechSPC_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFTech.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFTech.GetFocusedDataRow();
            int rowIdx = dtTechTmp.Rows.IndexOf(row);
            dtTechTmp.Rows[rowIdx]["DF_SPC"] = spnEdit.EditValue;
            dtTechTmp.AcceptChanges();
        }
        private void spinDFTechPRM_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFTech.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFTech.GetFocusedDataRow();
            int rowIdx = dtTechTmp.Rows.IndexOf(row);
            dtTechTmp.Rows[rowIdx]["DF_PRM"] = spnEdit.EditValue;
            dtTechTmp.AcceptChanges();
        }

        private void spinDFNurseRGL_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFNurse.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFNurse.GetFocusedDataRow();
            int rowIdx = dtNurseTmp.Rows.IndexOf(row);
            dtNurseTmp.Rows[rowIdx]["DF_RGL"] = spnEdit.EditValue;
            dtNurseTmp.AcceptChanges();
        }
        private void spinDFNurseSPC_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFNurse.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFNurse.GetFocusedDataRow();
            int rowIdx = dtNurseTmp.Rows.IndexOf(row);
            dtNurseTmp.Rows[rowIdx]["DF_SPC"] = spnEdit.EditValue;
            dtNurseTmp.AcceptChanges();
        }
        private void spinDFNursePRM_EditValueChanged(object sender, EventArgs e)
        {
            if (gvDFNurse.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.SpinEdit spnEdit = (DevExpress.XtraEditors.SpinEdit)sender;
            DataRow row = gvDFNurse.GetFocusedDataRow();
            int rowIdx = dtNurseTmp.Rows.IndexOf(row);
            dtNurseTmp.Rows[rowIdx]["DF_PRM"] = spnEdit.EditValue;
            dtNurseTmp.AcceptChanges();
        }

        private void btnDFRadAdd_Click(object sender, EventArgs e)
        {
            if (advView.FocusedRowHandle < 0) return;
            //if (gvDFRad.FocusedRowHandle < 0) return;

            DataRow nRow = dtRadTmp.NewRow();
            nRow["SL_NO"] = dtRadTmp.Rows.Count + 1;
            nRow["DF_RGL"] = 0;
            nRow["DF_SPC"] = 0;
            nRow["DF_PRM"] = 0;
            dtRadTmp.Rows.Add(nRow);
            dtRadTmp.AcceptChanges();

            gvDFRad.RefreshData();
        }
        private void btnDFTechAdd_Click(object sender, EventArgs e)
        {
            if (advView.FocusedRowHandle < 0) return;
            //if (gvDFTech.FocusedRowHandle < 0) return;

            DataRow nRow = dtTechTmp.NewRow();
            nRow["SL_NO"] = dtTechTmp.Rows.Count + 1;
            nRow["DF_RGL"] = 0;
            nRow["DF_SPC"] = 0;
            nRow["DF_PRM"] = 0;
            dtTechTmp.Rows.Add(nRow);
            dtTechTmp.AcceptChanges();

            gvDFTech.RefreshData();
        }
        private void btnDFNurseAdd_Click(object sender, EventArgs e)
        {
            if (advView.FocusedRowHandle < 0) return;
            //if (gvDFNurse.FocusedRowHandle < 0) return;

            DataRow nRow = dtNurseTmp.NewRow();
            nRow["SL_NO"] = dtNurseTmp.Rows.Count + 1;
            nRow["DF_RGL"] = 0;
            nRow["DF_SPC"] = 0;
            nRow["DF_PRM"] = 0;
            dtNurseTmp.Rows.Add(nRow);
            dtNurseTmp.AcceptChanges();

            gvDFNurse.RefreshData();
        }
        #endregion

        private void autoFillForeignRate(bool force_value)
        {
            decimal maximium_rate = 0;
            decimal df_reg_rate = 0;
            decimal df_spc_rate = 0;
            decimal df_pre_rate = 0;

            if (txtRate.Value > maximium_rate)
                maximium_rate = txtRate.Value;
            if (txtSpRate.Value > maximium_rate)
                maximium_rate = txtSpRate.Value;
            if (txtPreRate.Value > maximium_rate)
                maximium_rate = txtPreRate.Value;

            if (dtRadTmp.Rows.Count > 0)
            {
                df_reg_rate = Convert.ToDecimal(dtRadTmp.Rows[0]["DF_RGL"]);
                df_spc_rate = Convert.ToDecimal(dtRadTmp.Rows[0]["DF_SPC"]);
                df_pre_rate = Convert.ToDecimal(dtRadTmp.Rows[0]["DF_PRM"]);
            }
            if (force_value)
            {
                speNonResident.Value = calulateForeignRate(maximium_rate, df_reg_rate);
                speNonResidentSpc.Value = calulateForeignRate(maximium_rate, df_spc_rate);
                speNonResidentVIP.Value = calulateForeignRate(maximium_rate, df_pre_rate);
            }
            else
            {
                speNonResident.Value = speNonResident.Value == 0 ? calulateForeignRate(maximium_rate, df_reg_rate) : speNonResident.Value;
                speNonResidentSpc.Value = speNonResidentSpc.Value == 0 ? calulateForeignRate(maximium_rate, df_spc_rate) : speNonResidentSpc.Value;
                speNonResidentVIP.Value = speNonResidentVIP.Value == 0 ? calulateForeignRate(maximium_rate, df_pre_rate) : speNonResidentVIP.Value;
            }
        }
        private decimal calulateForeignRate(decimal maximium_rate, decimal df_rate)
        {
            double method_1 = (Convert.ToDouble(maximium_rate) - Convert.ToDouble(df_rate)) * 1.2;
            double method_2 = Convert.ToDouble(df_rate) * 2;
            double method_3 = method_1 + method_2;
            return Convert.ToDecimal(method_3);
        }
        private void txtRate_EditValueChanged(object sender, EventArgs e)
        {
            autoFillForeignRate(false);
        }
        private void txtSpRate_EditValueChanged(object sender, EventArgs e)
        {
            autoFillForeignRate(false);
        }
        private void txtPreRate_EditValueChanged(object sender, EventArgs e)
        {
            autoFillForeignRate(false);
        }

        private void simpleLabelItem2_DoubleClick(object sender, EventArgs e)
        {
            if (speNonResident.Enabled)
            {
                string _confirm = msg.ShowAlert("UID4048", env.CurrentLanguageID);
                if (_confirm == "2")
                    autoFillForeignRate(true);
            }
        }

        private void LoadExamBillingData()
        {
            DataRow row = advView.GetFocusedDataRow();
            int examID = Convert.ToInt32(row["EXAM_ID"]);

            ProcessGetRISExamMapBilling getExamBilling = new ProcessGetRISExamMapBilling();
            getExamBilling.RIS_EXAMMAPBILLING.EXAM_ID = examID;
            getExamBilling.Invoke();

            dtExamBilling = getExamBilling.DataResult.Tables[0].Copy();
            if (!dtExamBilling.Columns.Contains("DEL"))
                dtExamBilling.Columns.Add("DEL");

            grdExamBilling.DataSource = dtExamBilling;

            for (int i = 0; i < viewExamBilling.Columns.Count; i++)
            {
                viewExamBilling.Columns[i].Visible = false;
                viewExamBilling.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewExamBilling.Columns["EXAM_UID"].Caption = "Code";
            viewExamBilling.Columns["EXAM_UID"].ColVIndex = 1;

            viewExamBilling.Columns["EXAM_NAME"].Caption = "Name";
            viewExamBilling.Columns["EXAM_NAME"].Width = 250;
            viewExamBilling.Columns["EXAM_NAME"].ColVIndex = 2;

            RepositoryItemSpinEdit speQty = new RepositoryItemSpinEdit();
            viewExamBilling.Columns["EXAM_SUB_QTY"].Caption = "Qty";
            viewExamBilling.Columns["EXAM_SUB_QTY"].Width = 100;
            viewExamBilling.Columns["EXAM_SUB_QTY"].ColVIndex = 3;
            viewExamBilling.Columns["EXAM_SUB_QTY"].OptionsColumn.AllowEdit = true;
            viewExamBilling.Columns["EXAM_SUB_QTY"].ColumnEdit = speQty;

            viewExamBilling.Columns["DEL"].Visible = true;

            RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
            btnDelete.AutoHeight = false;
            btnDelete.BestFitWidth = 15;
            btnDelete.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Caption = string.Empty;
            btnDelete.Click += new EventHandler(btnDeleteExamBilling_Click);
            viewExamBilling.Columns["DEL"].Caption = string.Empty;
            viewExamBilling.Columns["DEL"].OptionsColumn.AllowEdit = true;
            viewExamBilling.Columns["DEL"].ColumnEdit = btnDelete;
            viewExamBilling.Columns["DEL"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            viewExamBilling.Columns["DEL"].Width = 15;
            viewExamBilling.Columns["DEL"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

        }
        private void btnDeleteExamBilling_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string strMsg = msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (strMsg == "1") return;
            
            if (advView.FocusedRowHandle < 0) return;
            if (viewExamBilling.FocusedRowHandle < 0) return;
            DataRow dr = viewExamBilling.GetFocusedDataRow();
            
            //ReloadDFSetting();
            dtExamBilling.Rows.Remove(dr);
            dtExamBilling.AcceptChanges();
            viewExamBilling.RefreshData();
        }
        private void InsertExamBillingData()
        {
            if (advView.FocusedRowHandle < 0) return;
 
            int _EXAM_ID = Convert.ToInt32(advView.GetFocusedDataRow()["EXAM_ID"]);
            ProcessDeleteRISExamMapBilling _del = new ProcessDeleteRISExamMapBilling();
            _del.RIS_EXAMMAPBILLING.EXAM_ID = _EXAM_ID;
            _del.Invoke();
            foreach (DataRow row in dtExamBilling.Rows)
            {
                ProcessAddRISExamMapBilling _prc = new ProcessAddRISExamMapBilling();
                _prc.RIS_EXAMMAPBILLING.EXAM_ID = _EXAM_ID;
                _prc.RIS_EXAMMAPBILLING.EXAM_SUB_ID = Convert.ToInt32(row["EXAM_SUB_ID"]);
                _prc.RIS_EXAMMAPBILLING.EXAM_SUB_QTY = Convert.ToInt32(row["EXAM_SUB_QTY"]);
                _prc.RIS_EXAMMAPBILLING.ORG_ID = env.OrgID;
                _prc.RIS_EXAMMAPBILLING.CREATED_BY = env.UserID;
                _prc.Invoke();
            }
        }
        private void btnAddExamBilling_Click(object sender, EventArgs e)
        {
            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(examBilling_Click);
            lv.AddColumn("EXAM_ID", "Exam ID", false, true);
            lv.AddColumn("EXAM_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_NAME", "Exam Name", true, true);
            lv.Text = "Exam Search";

            lv.Data = ds.Tables[0].Copy();
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void examBilling_Click(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            DataRow addRow = dtExamBilling.NewRow();
            addRow["EXAM_SUB_ID"] = retValue[0];
            addRow["EXAM_UID"] = retValue[1];
            addRow["EXAM_NAME"] = retValue[3];
            addRow["EXAM_SUB_QTY"] = 1;
            dtExamBilling.Rows.Add(addRow);
            dtExamBilling.AcceptChanges();

            viewExamBilling.RefreshData();
        }

    }
}
