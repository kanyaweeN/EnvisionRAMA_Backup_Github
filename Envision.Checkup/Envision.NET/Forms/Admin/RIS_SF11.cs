using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Common.UtilityClass;
using RIS.Forms.GBLMessage;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using RIS.Common.DBConnection;

//Exam Setup
namespace RIS.Forms.Admin
{
    public partial class RIS_SF11 : Form
    {
        private DBUtility dbu;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataSet ds;
        private BindingSource bs;
        GBLEnvVariable env = new GBLEnvVariable();

        private int clickTick;
        private BaseEdit activeEditor;
        private bool firstClickFlag;
        private MyMessageBox msg = new MyMessageBox();

        public RIS_SF11(UUL.ControlFrame.Controls.TabControl Tab)
        {
            InitializeComponent();
            CloseControl = Tab;

            SetEnableDisableControl(false);
            LoadData();
            SetNavigator();
            SetGridData();
            if (bs.Count > 0)
            {
                bs.MoveLast();
                bs.MoveFirst();
            }
            txtExamCode.Focus();

            //Modify at 2008 08 21
            RISBodyPartSelectData();
        }

        #region Navigator Control 
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }
        #endregion

        private void SetGridData() 
        {
            grdData.DataSource = ds.Tables[0].DefaultView;
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                advView.Columns[i].Visible = false;

            #region Set Master 
            advView.Columns["EXAM_UID"].Visible = true;
            advView.Columns["EXAM_UID"].Caption = "Exam Code";
            advView.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            advView.Columns["EXAM_UID"].BestFit();
            advView.Columns["EXAM_UID"].VisibleIndex = 1;

            advView.Columns["EXAM_NAME"].Visible = true;
            advView.Columns["EXAM_NAME"].Caption = "Exam Name";
            advView.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            advView.Columns["EXAM_NAME"].Width = 250;
            advView.Columns["EXAM_NAME"].VisibleIndex = 2;

            advView.Columns["SERVICE_TYPE"].Visible = true;
            advView.Columns["SERVICE_TYPE"].Caption = "Service Type";
            advView.Columns["SERVICE_TYPE"].OptionsColumn.ReadOnly = true;
            advView.Columns["SERVICE_TYPE"].BestFit();
            advView.Columns["SERVICE_TYPE"].VisibleIndex = 3;

            advView.Columns["EXAM_TYPE"].Visible = true;
            advView.Columns["EXAM_TYPE"].Caption = "Exam Type";
            advView.Columns["EXAM_TYPE"].OptionsColumn.ReadOnly = true;
            advView.Columns["EXAM_TYPE"].BestFit();
            advView.Columns["EXAM_TYPE"].VisibleIndex = 4;

            advView.Columns["RATE"].Visible = true;
            advView.Columns["RATE"].Caption = "Rate";
            advView.Columns["RATE"].OptionsColumn.ReadOnly = true;
            advView.Columns["RATE"].BestFit();
            advView.Columns["RATE"].VisibleIndex = 5;

            advView.Columns["IS_ACTIVE"].Visible = true;
            advView.Columns["IS_ACTIVE"].Caption = "Active";
            advView.Columns["IS_ACTIVE"].OptionsColumn.ReadOnly = true;
            advView.Columns["IS_ACTIVE"].BestFit();
            advView.Columns["IS_ACTIVE"].VisibleIndex = 6;
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
                process.Invoke();
                ds = new DataSet();
                bs = new BindingSource();
                ds.Tables.Add(process.Result.Tables[0].Copy());
                ds.Tables[0].TableName = "RIS_EXAM";
                bs.DataSource = ds.Tables[0];

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
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            cbbBodyPart.Enabled = flag;
        }
        private void ClearText()
        { 
            dbu = new DBUtility();

            #region TextBox: ClearDataBinding 
            txtExamCode.DataBindings.Clear();
            txtExamName.DataBindings.Clear();
            txtExamType.DataBindings.Clear();
            txtExamTypeName.DataBindings.Clear();
            txtICDCode.DataBindings.Clear();
            txtICDDesc.DataBindings.Clear();
            txtACRCode.DataBindings.Clear();
            txtACRDesc.DataBindings.Clear();
            txtServiceType.DataBindings.Clear();
            txtServiceName.DataBindings.Clear();
            txtRate.DataBindings.Clear();
            txtReportHeader.DataBindings.Clear();
            txtClaim.DataBindings.Clear();
            txtNonClaim.DataBindings.Clear();
            txtFee.DataBindings.Clear();
            txtAvgReq.DataBindings.Clear();
            txtMinReq.DataBindings.Clear();
            txtCostPrice.DataBindings.Clear();
            txtCapture.DataBindings.Clear();
            txtImages.DataBindings.Clear();
            //txtCPTCode.DataBindings.Clear();
            //txtCPTDesc.DataBindings.Clear();
            txtRelease.DataBindings.Clear();
            txtReleaseLevel.DataBindings.Clear();
            txtFinalize.DataBindings.Clear();
            txtFinalizingLevel.DataBindings.Clear();
            txtUnitCode.DataBindings.Clear();
            txtUnitName.DataBindings.Clear();
            cbbBodyPart.DataBindings.Clear();
            #endregion

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
            cbbBodyPart.Tag = null;
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
            cbbBodyPart.Text = string.Empty;
            #endregion

            chkPossibleSpecialClinic.Checked = false;
            chkActive.Checked = false;
            chkStructureReport.Checked = false;
            chkCanOrderStat.Checked = false;
            chkCanOrderUrgent.Checked = false;
            chkCanbeRepeated.Checked = false;
            chkNeedPrepartion.Checked = false;

        }
        private void SetNavigator()
        {
            ClearText();
            txtExamCode.DataBindings.Add("Tag", bs, "EXAM_ID");
            txtExamCode.DataBindings.Add("Text", bs, "EXAM_UID");
            txtExamName.DataBindings.Add("Text", bs, "EXAM_NAME");

            txtExamType.DataBindings.Add("Tag", bs, "EXAM_TYPE");

            txtRate.DataBindings.Add("Text", bs, "RATE");
            txtReportHeader.DataBindings.Add("Text", bs, "REPORT_HEADER");

            txtClaim.DataBindings.Add("Text", bs, "CLAIMABLE_AMT");
            txtNonClaim.DataBindings.Add("Text", bs, "NONCLAIMABLE_AMT");
            txtFee.DataBindings.Add("Text", bs, "FREE_AMT");

            txtAvgReq.DataBindings.Add("Text", bs, "AVG_REQ_HRS");
            txtMinReq.DataBindings.Add("Text", bs, "MIN_REQ_HRS");
            txtCostPrice.DataBindings.Add("Text", bs, "COST_PRICE");

            txtCapture.DataBindings.Add("Text", bs, "DEF_CAPTURE");
            txtImages.DataBindings.Add("Text", bs, "DEF_IMAGES");

            txtUnitCode.DataBindings.Add("Text", bs, "UNIT_ID");

            //cbbBodyPart.DataBindings.Add("Text", bs, "BP_UID");
            //cbbBodyPart.DataBindings.Add("Tag", bs, "BP_ID");

            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            bindingNavigator1.BindingSource = bs;
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            DataTable dtt = ((DataTable)bs.DataSource).Copy();
            DataRow dr = dtt.Rows[bs.Position];
            #region TextBox
            string strTemp = string.Empty;
            int j = 0;
            if (ds.Tables["HIS_ICD"].Rows.Count > 0)
            {
                txtICDCode.Tag = dr["ICD_ID"].ToString();
                for (; j < ds.Tables["HIS_ICD"].Rows.Count; j++)
                {
                    if (ds.Tables["HIS_ICD"].Rows[j]["ICD_ID"].ToString().Trim() == dr["ICD_ID"].ToString().Trim())
                        break;
                }
                if (j < ds.Tables["HIS_ICD"].Rows.Count)
                {
                    txtICDCode.Text = ds.Tables["HIS_ICD"].Rows[j]["ICD_UID"].ToString().Trim();
                    txtICDDesc.Text = ds.Tables["HIS_ICD"].Rows[j]["ICD_DESC"].ToString().Trim();
                }
                else 
                {
                    txtICDCode.Tag = null;
                    txtICDCode.Text = string.Empty;
                    txtICDDesc.Text = string.Empty;
                }

            }
            j = 0;
            if (ds.Tables["RIS_EXAMTYPE"].Rows.Count > 0)
            {
                for (; j < ds.Tables["RIS_EXAMTYPE"].Rows.Count; j++)
                {
                    if (ds.Tables["RIS_EXAMTYPE"].Rows[j]["EXAM_TYPE_ID"].ToString().Trim() == dr["EXAM_TYPE"].ToString().Trim())
                        break;
                }
                if (j < ds.Tables["RIS_EXAMTYPE"].Rows.Count)
                {
                    txtExamType.Text = ds.Tables["RIS_EXAMTYPE"].Rows[j]["EXAM_TYPE_UID"].ToString().Trim();
                    txtExamTypeName.Text = ds.Tables["RIS_EXAMTYPE"].Rows[j]["EXAM_TYPE_TEXT"].ToString().Trim();
                }
                else 
                {
                    txtExamType.Tag = null;
                    txtExamType.Text = string.Empty;
                    txtExamTypeName.Text = string.Empty;
                }
            }

            j = 0;
            if (ds.Tables["RIS_ACR"].Rows.Count > 0)
            {
                txtACRCode.Tag = dr["ACR_ID"].ToString();
                for (; j < ds.Tables["RIS_ACR"].Rows.Count; j++)
                {
                    if (ds.Tables["RIS_ACR"].Rows[j]["ACR_ID"].ToString().Trim() == dr["ACR_ID"].ToString().Trim())
                        break;
                }
                if (j < ds.Tables["RIS_ACR"].Rows.Count)
                {
                    txtACRCode.Text = ds.Tables["RIS_ACR"].Rows[j]["ACR_UID"].ToString().Trim();
                    txtACRDesc.Text = ds.Tables["RIS_ACR"].Rows[j]["ACR_DESC"].ToString().Trim();
                }
                else {
                    txtACRCode.Tag = null;
                    txtACRCode.Text = string.Empty;
                    txtACRDesc.Text = string.Empty;
                }
            }
            j = 0;
            if (ds.Tables["RIS_SERVICETYPE"].Rows.Count > 0)
            {
                txtServiceType.Tag = dr["SERVICE_TYPE"].ToString();
                for (; j < ds.Tables["RIS_SERVICETYPE"].Rows.Count; j++)
                {
                    if (ds.Tables["RIS_SERVICETYPE"].Rows[j]["SERVICE_TYPE_ID"].ToString().Trim() == dr["SERVICE_TYPE"].ToString().Trim())
                        break;
                }
                if (j < ds.Tables["RIS_SERVICETYPE"].Rows.Count)
                {
                    txtServiceType.Text = ds.Tables["RIS_SERVICETYPE"].Rows[j]["SERVICE_TYPE_UID"].ToString().Trim();
                    txtServiceName.Text = ds.Tables["RIS_SERVICETYPE"].Rows[j]["SERVICE_TYPE_UID"].ToString().Trim();
                }
                else {
                    txtServiceName.Text = string.Empty;
                    txtServiceType.Text = string.Empty;
                    txtServiceType.Tag = null;
                }
            }
            j = 0;
            if (ds.Tables["HR_UNIT"].Rows.Count > 0)
            {
                txtUnitCode.Tag = dr["UNIT_ID"].ToString();
                for (; j < ds.Tables["HR_UNIT"].Rows.Count; j++)
                {
                    if (ds.Tables["HR_UNIT"].Rows[j]["UNIT_ID"].ToString().Trim() == dr["UNIT_ID"].ToString().Trim())
                        break;
                }
                if (j < ds.Tables["HR_UNIT"].Rows.Count)
                {
                    txtUnitCode.Text = ds.Tables["HR_UNIT"].Rows[j]["UNIT_UID"].ToString().Trim();
                    txtUnitName.Text = ds.Tables["HR_UNIT"].Rows[j]["UNIT_NAME"].ToString().Trim();
                }
                else
                {
                    txtUnitCode.Tag = null;
                    txtUnitCode.Text = string.Empty;
                    txtUnitName.Text = string.Empty;

                }
            }
            j = 0;
            if (ds.Tables["RIS_AUTHLEVEL"].Rows.Count > 0)
            {
                txtRelease.Tag = dr["RELEASE_AUTH_LEVEL"].ToString();
                for (; j < ds.Tables["RIS_AUTHLEVEL"].Rows.Count; j++)
                {
                    if (ds.Tables["RIS_AUTHLEVEL"].Rows[j]["AUTH_LEVEL_ID"].ToString().Trim() == dr["RElEASE_AUTH_LEVEL"].ToString().Trim())
                        break;
                }
                if (j < ds.Tables["RIS_AUTHLEVEL"].Rows.Count)
                {
                    txtRelease.Text = ds.Tables["RIS_AUTHLEVEL"].Rows[j]["AUTH_LEVEL_UID"].ToString().Trim();
                    txtReleaseLevel.Text = ds.Tables["RIS_AUTHLEVEL"].Rows[j]["AUTH_LEVEL_TEXT"].ToString().Trim();
                }
                else {
                    txtRelease.Tag = null;
                    txtRelease.Text = string.Empty;
                    txtReleaseLevel.Text = string.Empty;
                }
            }
            j = 0;
            if (ds.Tables["RIS_AUTHLEVEL"].Rows.Count > 0)
            {
                txtFinalize.Tag = dr["FINALIZE_AUTH_LEVEL"].ToString();
                for (; j < ds.Tables["RIS_AUTHLEVEL"].Rows.Count; j++)
                {
                    if (ds.Tables["RIS_AUTHLEVEL"].Rows[j]["AUTH_LEVEL_ID"].ToString().Trim() == dr["FINALIZE_AUTH_LEVEL"].ToString().Trim())
                        break;
                }
                if (j < ds.Tables["RIS_AUTHLEVEL"].Rows.Count)
                {
                    txtFinalize.Text = ds.Tables["RIS_AUTHLEVEL"].Rows[j]["AUTH_LEVEL_UID"].ToString().Trim();
                    txtFinalizingLevel.Text = ds.Tables["RIS_AUTHLEVEL"].Rows[j]["AUTH_LEVEL_TEXT"].ToString().Trim();
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
            //chkPossibleSpecialClinic.Checked = dr["SPECIAL_CLINIC"].ToString().Trim() == "Y" ? true : false;
            //chkStructureReport.Checked = dr["IS_STRUCTURED_REPORT"].ToString().Trim() == "Y" ? true : false;
            chkCanOrderStat.Checked = dr["STAT_FLAG"].ToString().Trim() == "Y" ? true : false;
            //chkCanOrderUrgent.Checked = dr["URGENT_FLAG"].ToString().Trim() == "Y" ? true : false;
            //chkCanbeRepeated.Checked = dr["REPEAT_FLAG"].ToString().Trim() == "Y" ? true : false;
            //chkNeedPrepartion.Checked = dr["PREPARATION_FLAG"].ToString().Trim() == "Y" ? true : false;


            #endregion
        }

        #region Lookup 
        private void btnICD_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ICD);

            string qry = @"
                        select
	                        ICD_UID
	                        ,ICD_ID
	                        ,ICD_DESC
                        from
	                        HIS_ICD
                        where 
                            ICD_UID like '%%'
                            or  ICD_DESC like '%%'";

            string fields = "ICD Code,ICD ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "ICD Search");
            lv.Show();
        }
        private void find_ICD(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtICDCode.Tag = retValue[1];
            txtICDCode.Text = retValue[0];
            txtICDDesc.Text = retValue[2];
            btnACR.Focus();
        }

        private void btnACR_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ACR);

            string qry = @"                
                select
	                ACR_UID
	                ,ACR_ID
	                ,ACR_DESC
                from
	                RIS_ACR
                where
                    ACR_UID like '%%'
                    or ACR_DESC like '%%'";


            string fields = "ACR Code,ARC ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "ACR Search");
            lv.Show();
        }
        private void find_ACR(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtACRCode.Tag = retValue[1];
            txtACRCode.Text = retValue[0];
            txtACRDesc.Text = retValue[2];
            btnServiceType.Focus();
        }

        private void btnServiceType_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ServiceType);

            string qry = @"
                       select
	                        SERVICE_TYPE_UID
	                        ,SERVICE_TYPE_ID
	                        ,SERVICE_TYPE_TEXT
                        from
	                        dbo.RIS_SERVICETYPE
                        where
                            SERVICE_TYPE_UID like '%%' or SERVICE_TYPE_TEXT like '%%'";

            string fields = "Service Code,Service ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "Service Search");
            lv.Show();
        }
        private void find_ServiceType(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtServiceType.Tag = retValue[1];
            txtServiceType.Text = retValue[0];
            txtServiceName.Text = retValue[2];
            btnExamType.Focus();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ICD);

            string qry = @"
                select
                    REG_ID
                    ,HN
                    ,FNAME
                    ,LNAME
                from
                    HIS_REGISTRATION
                where
                    FNAME Like '%%'";

            string fields = "HN,ชื่อ,นามสกุล";
            string con = "";
            lv.getData(qry, fields, con, "HN Search");
            lv.Show();
        }
        private void find_Capture(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Release);

            string qry = @"
                    select
                        AUTH_LEVEL_UID
                        ,AUTH_LEVEL_ID
                        ,AUTH_LEVEL_TEXT

                    from
                        RIS_AUTHLEVEL
                    where
                        AUTH_LEVEL_UID like '%%'";

            string fields = "Release Code,Release ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "Release Search");
            lv.Show();
        }
        private void find_Release(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtRelease.Tag = retValue[1];
            txtRelease.Text = retValue[0];
            txtReleaseLevel.Text = retValue[2];
        }

        private void btnFinalizing_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Finalizing);

            string qry = @"
                    select
                        AUTH_LEVEL_UID
                        ,AUTH_LEVEL_ID
                        ,AUTH_LEVEL_TEXT

                    from
                        RIS_AUTHLEVEL
                    where
                        AUTH_LEVEL_UID like '%%'";

            string fields = "Finalizing Code,Finalizing ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "Finalizing Search");
            lv.Show();
        }
        private void find_Finalizing(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtFinalize.Tag = retValue[1];
            txtFinalize.Text = retValue[0];
            txtFinalizingLevel.Text = retValue[2];
        }

        private void btnExamType_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_ExamType);

            string qry = @"
                select  
                    EXAM_TYPE_UID
                    ,EXAM_TYPE_ID
                    ,EXAM_TYPE_TEXT
                from 
                    dbo.RIS_EXAMTYPE
                where
                    (EXAM_TYPE_UID like '%%' or EXAM_TYPE_TEXT like '%%')
                    AND IS_ACTIVE = 'Y'";

            string fields = "Exam Type,Exam ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "ExamType Search");
            lv.Show();
        }
        private void find_ExamType(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtExamType.Tag = retValue[1];
            txtExamType.Text = retValue[0];
            txtExamTypeName.Text = retValue[2];
            txtRate.Focus();
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_UnitCode);

            string qry = @"
                	select
		                UNIT_UID
		                ,UNIT_ID
		                ,UNIT_NAME
	                from
		                HR_UNIT
                where
                        UNIT_UID like '%%' or UNIT_NAME like '%%'";

            string fields = "Unit Code,Unit ID,Unit Name";
            string con = "";
            lv.getData(qry, fields, con, "Unit Search");
            lv.Show();
        }
        private void find_UnitCode(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtUnitCode.Tag = retValue[1];
            txtUnitCode.Text = retValue[0];
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
                if (view.GetShowEditorMode() == DevExpress.Utils.EditorShowMode.MouseDown)
                    firstClickFlag = true;
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
            DataTable dtt = (DataTable)bs.DataSource;
            int id = (int)dr["EXAM_ID"];
            int i = 0;
            for (; i < dtt.Rows.Count; i++)
                if ((int)dtt.Rows[i]["EXAM_ID"] == id)
                    break;
            bs.Position = i;
            if(groupBoxMaster.Expanded==false)
                groupBoxMaster.Expanded = true;
        }
        private void Editor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            BaseEdit editor = sender as BaseEdit;
            if ((System.Environment.TickCount - clickTick) < SystemInformation.DoubleClickTime)
            {
                if (firstClickFlag)
                {
                    firstClickFlag = false;
                    return;
                }
                GridView view = (editor.Parent as GridControl).FocusedView as GridView;
                int rowHandle = view.FocusedRowHandle;
                DoDoubleClickRow(view, rowHandle);
            }
            clickTick = System.Environment.TickCount;
        } 
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtRate.DataBindings.Clear();
            txtClaim.DataBindings.Clear();
            cbbBodyPart.DataBindings.Clear();

            if (txtExamCode.Tag != null)
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnMoveFirst.Enabled = false;
                btnMovePrevious.Enabled = false;
                btnMoveNext.Enabled = false;
                btnMoveLast.Enabled = false;
                grdData.Enabled = false;
                SetEnableDisableControl(true);
                if (groupBoxMaster.Expanded == false)
                    groupBoxMaster.Expanded = true;
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

            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
            grdData.Enabled = true;

            SetEnableDisableControl(false);
            SetNavigator();
            int position = bs.Position;
            if (bs.Count > 0) 
            {
                bs.MoveLast();
                bs.MoveFirst();
                bs.Position = position;
            }   
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            #region Require Check 
            if (txtExamCode.Text.Trim().Length == 0) {
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
            if (txtExamType.Tag == null || txtExamType.Tag.ToString().Trim()==string.Empty)
            {
                msg.ShowAlert("UID1009", env.CurrentLanguageID);
                txtExamType.Focus();
                return;
            }
           
            
            #endregion

            string str = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                if (txtExamCode.Tag == null)
                    InsertData();
                else
                    UpdateData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtExamCode.Tag != null) {
                if (groupBoxMaster.Expanded == false)
                    groupBoxMaster.Expanded = true;
                string str=msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
                if (str == "2")
                {
                    try
                    {
                        ProcessDeleteRISExam process = new ProcessDeleteRISExam();
                        process.RISExam.EXAM_ID = Convert.ToInt32(txtExamCode.Tag);
                        process.Invoke();
                        LoadData();
                        SetNavigator();
                        SetGridData();
                        if (bs.Count > 0)
                            bs.MoveLast();
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
            txtRate.DataBindings.Clear();
            txtClaim.DataBindings.Clear();
            cbbBodyPart.DataBindings.Clear();

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            grdData.Enabled = false;
            groupBoxMaster.Enabled = true;

            ClearText();
            txtExamCode.Focus();
            SetEnableDisableControl(true);
            chkPossibleSpecialClinic.Checked = false;
            chkActive.Checked = false;
            chkStructureReport.Checked = false;
            chkCanOrderStat.Checked = false;
            chkCanOrderUrgent.Checked = false;
            chkCanbeRepeated.Checked = false;
            chkNeedPrepartion.Checked = false;
            if (groupBoxMaster.Expanded == false)
                groupBoxMaster.Expanded = true;
            txtExamCode.Focus();
        }

        private void InsertData() {
            try
            {
                ProcessAddRISExam processAdd = new ProcessAddRISExam();
                processAdd.RISExam.EXAM_UID = txtExamCode.Text;
                processAdd.RISExam.EXAM_NAME = txtExamName.Text;
                processAdd.RISExam.UNIT_ID = Convert.ToInt32(txtUnitCode.Tag);
                processAdd.RISExam.ICD_ID = txtICDCode.Tag == null || txtICDCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtICDCode.Tag);
                processAdd.RISExam.ACR_ID = txtACRCode.Tag == null || txtACRCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtACRCode.Tag);
                processAdd.RISExam.SERVICE_TYPE = txtServiceType.Tag.ToString();
                processAdd.RISExam.EXAM_TYPE = Convert.ToInt32(txtExamType.Tag);
                processAdd.RISExam.RATE = Convert.ToDecimal(txtRate.Text);
                processAdd.RISExam.SPECIAL_CLINIC = chkPossibleSpecialClinic.Checked ? "Y" : null;
                processAdd.RISExam.IS_ACTIVE = chkActive.Checked ? "Y" : null;
                processAdd.RISExam.REPORT_HEADER = txtReportHeader.Text.Trim();
                processAdd.RISExam.CLAIMABLE_AMT = Convert.ToDecimal(txtClaim.Text);
                processAdd.RISExam.NONCLAIMABLE_AMT = Convert.ToDecimal(txtNonClaim.Text);
                processAdd.RISExam.FREE_AMT = Convert.ToDecimal(txtFee.Text);
                processAdd.RISExam.AVG_REQ_HRS = Convert.ToDecimal(txtAvgReq.Text);
                processAdd.RISExam.MIN_REQ_HRS = Convert.ToDecimal(txtMinReq.Text);
                processAdd.RISExam.COST_PRICE = Convert.ToDecimal(txtCostPrice.Text);
                processAdd.RISExam.DEF_CAPTURE = Convert.ToByte(txtCapture.Text);
                if (txtImages.Text.Trim().Length < 1) processAdd.RISExam.DEF_IMAGES = null;
                else processAdd.RISExam.DEF_IMAGES = Convert.ToByte(txtImages.Text);
                //processAdd.RISExam.CPT_ID = Convert.ToInt32(txtCPTCode.Tag);
                processAdd.RISExam.FINALIZE_AUTH_LEVEL = txtFinalize.Tag == null || txtFinalize.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtFinalize.Tag);
                processAdd.RISExam.RELEASE_AUTH_LEVEL = txtRelease.Tag == null || txtRelease.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtRelease.Tag);
                processAdd.RISExam.IS_STRUCTURED_REPORT = chkStructureReport.Checked ? "Y" : null;
                processAdd.RISExam.STAT_FLAG = chkCanOrderStat.Checked ? "Y" : null;
                processAdd.RISExam.URGENT_FLAG = chkCanOrderUrgent.Checked ? "Y" : null;
                processAdd.RISExam.REPEAT_FLAG = chkCanbeRepeated.Checked ? "Y" : null;
                processAdd.RISExam.PREPARATION_FLAG = chkNeedPrepartion.Checked ? "Y" : null;
                processAdd.RISExam.CREATED_BY = new GBLEnvVariable().UserID.ToString();
                processAdd.RISExam.ORG_ID = new GBLEnvVariable().OrgID;
                if (cbbBodyPart.SelectedIndex == -1)
                { processAdd.RISExam.BP_ID = null; }
                else { processAdd.RISExam.BP_ID = BP_ID[cbbBodyPart.SelectedIndex]; }
                processAdd.RISExam.QA_REQUIRED = "Y";
                processAdd.Invoke();
                //msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);
                SetEnableDisableControl(false);
                LoadData();
                ClearText();
                //SetNavigator();
                SetGridData();
                #region old 
                //if (bs.Count > 0)
                //    bs.MoveLast();

                //btnSave.Enabled = false;
                //btnCancel.Enabled = false;
                //btnSave.Visible = false;
                //btnCancel.Visible = false;

                //btnAdd.Visible = true;
                //btnEdit.Visible = true;
                //btnDelete.Visible = true;

                //btnMoveFirst.Enabled = true;
                //btnMovePrevious.Enabled = true;
                //btnMoveNext.Enabled = true;
                //btnMoveLast.Enabled = true;
                //grdData.Enabled = true; 
                #endregion
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnMoveFirst.Enabled = false;
                btnMovePrevious.Enabled = false;
                btnMoveNext.Enabled = false;
                btnMoveLast.Enabled = false;
                grdData.Enabled = false;
                groupBoxMaster.Enabled = true;

                ClearText();
                txtExamCode.Focus();
                SetEnableDisableControl(true);
                chkPossibleSpecialClinic.Checked = false;
                chkActive.Checked = false;
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
        private void UpdateData() {
            try
            {
                int index = bs.Position;
                ProcessUpdateRISExam process = new ProcessUpdateRISExam();
                process.RISExam.EXAM_ID = Convert.ToInt32(txtExamCode.Tag);
                process.RISExam.EXAM_UID = txtExamCode.Text;
                process.RISExam.EXAM_NAME = txtExamName.Text;
                process.RISExam.UNIT_ID = Convert.ToInt32(txtUnitCode.Tag);
                process.RISExam.ICD_ID = txtICDCode.Tag == null || txtICDCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtICDCode.Tag);
                process.RISExam.ACR_ID = txtACRCode.Tag == null || txtACRCode.Tag.ToString().Trim() == string.Empty ? 0 : Convert.ToInt32(txtACRCode.Tag);
                process.RISExam.SERVICE_TYPE = txtServiceType.Tag.ToString();
                process.RISExam.EXAM_TYPE = Convert.ToInt32(txtExamType.Tag);
                process.RISExam.RATE = Convert.ToDecimal(txtRate.Text);
                process.RISExam.SPECIAL_CLINIC = chkPossibleSpecialClinic.Checked ? "Y" : null;
                process.RISExam.IS_ACTIVE = chkActive.Checked ? "Y" : null;
                process.RISExam.REPORT_HEADER = txtReportHeader.Text.Trim();
                process.RISExam.CLAIMABLE_AMT = Convert.ToDecimal(txtClaim.Text);
                process.RISExam.NONCLAIMABLE_AMT = Convert.ToDecimal(txtNonClaim.Text);
                process.RISExam.FREE_AMT = Convert.ToDecimal(txtFee.Text);
                process.RISExam.AVG_REQ_HRS = Convert.ToDecimal(txtAvgReq.Text);
                process.RISExam.MIN_REQ_HRS = Convert.ToDecimal(txtMinReq.Text);
                process.RISExam.COST_PRICE = Convert.ToDecimal(txtCostPrice.Text);
                process.RISExam.DEF_CAPTURE = Convert.ToByte(txtCapture.Text);
                if (txtImages.Text.Trim().Length < 1) process.RISExam.DEF_IMAGES = null;
                else process.RISExam.DEF_IMAGES = Convert.ToByte(txtImages.Text);
                //process.RISExam.CPT_ID = Convert.ToInt32(txtCPTCode.Tag);
                process.RISExam.FINALIZE_AUTH_LEVEL = txtFinalize.Tag == null || txtFinalize.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtFinalize.Tag);
                process.RISExam.RELEASE_AUTH_LEVEL = txtRelease.Tag == null || txtRelease.Tag.ToString().Trim() == string.Empty ? (byte)0 : Convert.ToByte(txtRelease.Tag);
                process.RISExam.IS_STRUCTURED_REPORT = chkStructureReport.Checked ? "Y" : null;
                process.RISExam.STAT_FLAG = chkCanOrderStat.Checked ? "Y" : null;
                process.RISExam.URGENT_FLAG = chkCanOrderUrgent.Checked ? "Y" : null;
                process.RISExam.REPEAT_FLAG = chkCanbeRepeated.Checked ? "Y" : null;
                process.RISExam.PREPARATION_FLAG = chkNeedPrepartion.Checked ? "Y" : null;
                process.RISExam.CREATED_BY = new GBLEnvVariable().UserID.ToString();
                process.RISExam.ORG_ID = new GBLEnvVariable().OrgID;
                if(cbbBodyPart.SelectedIndex==-1)
                { process.RISExam.BP_ID = null; }
                else{ process.RISExam.BP_ID = BP_ID[cbbBodyPart.SelectedIndex]; }
                process.RISExam.QA_REQUIRED = "Y";
                process.Invoke();

                //msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);
                SetEnableDisableControl(false);
                LoadData();
                SetNavigator();
                SetGridData();
                if (bs.Count > 0)
                    bs.MoveLast();

                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;

                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;

                btnMoveFirst.Enabled = true;
                btnMovePrevious.Enabled = true;
                btnMoveNext.Enabled = true;
                btnMoveLast.Enabled = true;
                grdData.Enabled = true;
                groupBoxMaster.Enabled = true;
                bs.Position = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (e.KeyCode == Keys.Enter)
                txtFinalize.Focus();
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
                if (decResult > rate) {
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
                        txtUnitCode.DataBindings.Clear();
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
            Infragistics.Win.Misc.UltraExpandableGroupBox expand = sender as Infragistics.Win.Misc.UltraExpandableGroupBox;
            int h = expand.Expanded ? -300 : 300;
            System.Drawing.Size s = new Size(grdData.Size.Width, grdData.Size.Height + h);
            grdData.Size = s;
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
            if(e.KeyCode==Keys.Enter)
                chkCanOrderStat.Focus();
        }

        private void chkCanOrderStat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReportHeader.Focus();
        }

        //Modify add 2008 08 21
        List<int> BP_ID;
        public void RISBodyPartSelectData()
        {
            dbConnection db = new dbConnection();
            string sql = @" select BP_ID, ISNULL(BP_UID,' ')+'('+ ISNULL(SHORT_NAME,' ')+') - '+BP_DESC AS BP_NAME
                            from dbo.RIS_BODYPART";
            DataTable ds = db.SelectDs(sql);
            cbbBodyPart.Properties.Items.Clear();
            BP_ID = new List<int>();
            BP_ID.Clear();
            foreach(DataRow row in ds.Rows)
            {
                cbbBodyPart.Properties.Items.Add(row["BP_NAME"]);
                BP_ID.Add((int)row["BP_ID"]);
            }
        }

        //private void cbbBodyPart_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DevExpress.XtraEditors.ComboBoxEdit sd = (DevExpress.XtraEditors.ComboBoxEdit)sender;
        //    if (sd.SelectedIndex == -1)return;
        //    sd.Tag = BP_ID[sd.SelectedIndex];
        //}

        //Modify add 2008 08 21
    }
}
            