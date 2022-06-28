using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.Operational.PACS;
using Envision.Plugin.ReportManager;
using Miracle.HL7.ORM;
using Miracle.Scanner;

using Envision.Plugin.XtraFile.xtraReports;
using Envision.Operational.Translator;
using Envision.Common.Common;
using Miracle.Util;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;

namespace Envision.NET.Forms.Orders
{
    public partial class frmOrders : Envision.NET.Forms.Main.MasterForm
    {
        private MyMessageBox msg = new MyMessageBox();
        private int[] langid;
        private string defaultlangs;
        //ตัวแปร 3 ตัวนี้ใช้ในการคลิกตรง Grid Order
        private int clickTick;
        private BaseEdit activeEditor;
        private bool firstClickFlag;
        //
        private GBLEnvVariable env = new GBLEnvVariable();
        private DateTime orderDT;
        private OrderManager orderManger;
        private Order thisOrder;
        private Color defaultForeColor;
        private Color defaultBackColor;
        private string mode = "";
        private int scheduleID;
        private string chk;
        private DataTable dttExamPanel;
        private DataTable dttUpdate;
        private int SL_NO = -1;
        private DataTable dtOrderdtlEdit;
        private DataTable dtExam = RISBaseData.Ris_Exam();
        private DataTable dtBP_View = RISBaseData.BP_View();
        private DataTable dtClinic = RISBaseData.RIS_ClinicType();
        private DataTable dtRefUnit = RISBaseData.His_Department();
        private DataTable dtRefDoc = RISBaseData.His_Doctor();
        private string Enc_ID;
        private string Enc_Type;

        private DataTable dttExamFlag, dtExamFlagDTL;
        private FinancialBilling fnBill = new FinancialBilling();

        //Multiple Assignment Variables
        private List<DataTable> tbMultiAssList = new List<DataTable>();

        Miracle.UserControls.HISPatientPhotoForm ptPhoto
            = new Miracle.UserControls.HISPatientPhotoForm();

        public frmOrders()
        {
            InitializeComponent();
            env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
        }
        public frmOrders(string Mode)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loadFormLanguage();
            thisOrder = new Order();
            clearContexInControl();
            setEnableDisableControl(false);
            defaultBackColor = txtLastVisit.BackColor;
            defaultForeColor = btnPhysician.ForeColor;
            setBackColor(defaultBackColor);
            setForeColor(defaultForeColor);
            setInitalVariable();
            mode = Mode;
            setGridData();
            setGridOrder();
            if (Mode == "Edit")
            {
                btnSave.Text = "[F2] &Modify Order";
                btnSaveSame.Text = "[F3] &Cancel Order";
                txtOrderNo.Enabled = true;
                txtOrderNo.BackColor = Color.White;
                btnLookUpNo.Enabled = true;
            }
            else if (Mode == "New" || Mode == "Last")
            {
                lblOrderNo.Visible = false;
                txtOrderNo.Visible = false;
                btnLookUpNo.Visible = false;
                txtHN.Enabled = true;
                txtHN.BackColor = Color.White;
                btnLookup.Enabled = true;
                btnSave.Text = "[F2] Save & Ready for New Patient";
                btnSaveSame.Text = "[F3] Save & Add New Order For Same Patient";
                if (Mode == "Last")
                {

                    thisOrder.LastOrder(env.UserID);
                    setGridData();
                }
            }
            else if (Mode == "Manual")
            {
                //txtInsurace.Enabled = true;
                //txtInsurace.BackColor = Color.White;
                //btnInsurance.Enabled = true;

                txtDOB.DateTime = DateTime.Now;
                cboGender.SelectedIndex = 1;

                btnSave.Text = "[F2] Save & Ready for New Patient";
                btnSaveSame.Text = "[F3] Save & Add New Order For Same Patient";
                btnSave.Enabled = true;
                btnSaveSame.Enabled = true;

                setEnableForManual();
            }
            else if (Mode == "JohnDoe")
            {
                //txtInsurace.Enabled = true;
                //txtInsurace.BackColor = Color.White;
                //btnInsurance.Enabled = true;

                txtDOB.DateTime = DateTime.Now;
                cboGender.SelectedIndex = 1;

                txtThaiName.Text = "John Doe";
                txtEngName.Text = "John Doe";
                txtLastThaiName.Text = "John Doe";
                txtLastEngName.Text = "John Doe";

                cboGender.SelectedIndex = 1;

                btnSave.Text = "[F2] Save & Ready for New Patient";
                btnSaveSame.Text = "[F3] Save & Add New Order For Same Patient";
                btnSave.Enabled = true;
                btnSaveSame.Enabled = true;
                setEnableForManual();
            }
            orderDT = DateTime.Now;
            //switch (mode)
            //{
            //    case "New":
            //        this.Text = "New Order";
            //        break;
            //    case "Edit":
            //        this.Text = "Edit Order";
            //        break;
            //    case "Last":
            //        this.Text = "Last Order";
            //        break;
            //    case "Manual":
            //        this.Text = "Manual Order";
            //        break;
            //    case "JohnDoe":
            //        this.Text = "John Doe";
            //        break;
            //}
        }
        public frmOrders(string HN, string mode)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loadFormLanguage();
            thisOrder = new Order(HN, true);
            clearContexInControl();
            setEnableDisableControl(false);
            defaultBackColor = txtLastVisit.BackColor;
            defaultForeColor = btnPhysician.ForeColor;
            setBackColor(defaultBackColor);
            setForeColor(defaultForeColor);
            setInitalVariable();
            this.mode = mode;
            setGridData();
            fillDemographicmodeNew();
            lblOrderNo.Visible = false;
            txtOrderNo.Visible = false;
            btnLookUpNo.Visible = false;
            txtHN.Enabled = true;
            txtHN.BackColor = Color.White;
            btnLookup.Enabled = true;
            orderDT = DateTime.Now;

            //switch (mode)
            //{
            //    case "New":
            //        this.Text = "New Order";
            //        break;
            //    case "Edit":
            //        this.Text = "Edit Order";
            //        break;
            //    case "Last":
            //        this.Text = "Last Order";
            //        break;
            //    case "Manual":
            //        this.Text = "Manual Order";
            //        break;
            //    case "JohnDoe":
            //        this.Text = "John Doe";
            //        break;
            //}
        }
        public frmOrders(int ReqNo, string mode)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //CloseControl = Cls;
            loadFormLanguage();
            thisOrder = new Order(ReqNo, true);
            clearContexInControl();
            setEnableDisableControl(false);
            defaultBackColor = txtLastVisit.BackColor;
            defaultForeColor = btnPhysician.ForeColor;
            setBackColor(defaultBackColor);
            setForeColor(defaultForeColor);
            setInitalVariable();
            this.mode = "New";
            chk = "C";
            setGridData();
            fillDemographicmodeNew();
            lblOrderNo.Visible = false;
            txtOrderNo.Visible = false;
            btnLookUpNo.Visible = false;
            txtHN.Enabled = true;
            txtHN.BackColor = Color.White;
            btnLookup.Enabled = true;
            orderDT = DateTime.Now;

            ribbonPageGroup1.Visible = false;
            ribbonPageGroup2.Visible = false;
            ribbonPageGroup9.Visible = false;
            ribbonPageGroup11.Visible = false;
            ribbonPageGroup5.Visible = false;
            ribbonPageGroup3.Visible = false;
            ribbonPageGroup6.Visible = false;
            //ribbonPageGroup7.Visible = false;
            ribbonPageGroup8.Visible = false;
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            if (mode == "")
            {
                thisOrder = new Order();
                setStartOrder();
            }
            setTrauma();
            env.ErrorForm = base.Menu_Name_Class;
            base.CloseWaitDialog();
        }
        private void frmOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (btnSave.Enabled)
                    btnSave_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (btnSaveSame.Enabled)
                    btnSaveSame_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (btnPrintPreview.Enabled)
                    btnPrintPreview_Click(null, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (btnSendToPrint.Enabled)
                    btnSendToPrint_Click(null, null);
            }
        }

        public void frmOrdersSelectMode(string Mode)
        {
            //InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // 
            lblDOB.ContainerText = "AGE";
            loadFormLanguage();
            setTemplateBillingLog();
            thisOrder = new Order();
            clearContexInControl();
            setEnableDisableControl(false);
            defaultBackColor = txtLastVisit.BackColor;
            defaultForeColor = btnPhysician.ForeColor;
            setBackColor(defaultBackColor);
            setForeColor(defaultForeColor);
            setInitalVariable();
            mode = Mode;
            setGridData();
            setGridOrder();
            if (Mode == "Edit")
            {
                btnSave.Text = "[F2] &Modify Order";
                btnSaveSame.Text = "[F3] &Cancel Order";
                lblOrderNo.Visible = true;
                txtOrderNo.Visible = true;
                btnLookUpNo.Visible = true;

                txtOrderNo.Enabled = true;
                txtOrderNo.BackColor = Color.White;
                btnLookUpNo.Enabled = true;

                btnSave.Enabled = true;
                btnSaveSame.Enabled = true;

            }
            else if (Mode == "New" || Mode == "Last")
            {
                lblOrderNo.Visible = false;
                txtOrderNo.Visible = false;
                btnLookUpNo.Visible = false;
                txtHN.Enabled = true;
                txtHN.BackColor = Color.White;
                btnLookup.Enabled = true;
                btnSave.Text = "[F2] Save & Ready for New Patient";
                btnSaveSame.Text = "[F3] Save & Add New Order For Same Patient";
                btnSave.Enabled = true;
                btnSaveSame.Enabled = true;

                if (Mode == "Last")
                {
                    thisOrder.LastOrder(env.UserID);
                    setGridData();
                }


            }
            else if (Mode == "Manual")
            {
                //txtInsurace.Enabled = true;
                //txtInsurace.BackColor = Color.White;
                //btnInsurance.Enabled = true;

                txtDOB.DateTime = DateTime.Now;
                cboGender.SelectedIndex = 1;

                btnSave.Text = "[F2] Save & Ready for New Patient";
                btnSaveSame.Text = "[F3] Save & Add New Order For Same Patient";
                btnSave.Enabled = true;
                btnSaveSame.Enabled = true;
                setEnableForManual();
            }
            else if (Mode == "JohnDoe")
            {
                //txtInsurace.Enabled = true;
                //txtInsurace.BackColor = Color.White;
                //btnInsurance.Enabled = true;

                txtDOB.DateTime = DateTime.Now;
                cboGender.SelectedIndex = 1;

                txtThaiName.Text = "John Doe";
                txtEngName.Text = "John Doe";
                txtLastThaiName.Text = "John Doe";
                txtLastEngName.Text = "John Doe";

                cboGender.SelectedIndex = 1;

                btnSave.Text = "[F2] Save & Ready for New Patient";
                btnSaveSame.Text = "[F3] Save & Add New Order For Same Patient";
                btnSave.Enabled = true;
                btnSaveSame.Enabled = true;
                setEnableForManual();

            }
            orderDT = DateTime.Now;

            //env.CountImg = string.Empty;
            //env.PixPic = IntPtr.Zero;
            //env.PixPic2 = IntPtr.Zero;
            //env.PixPic3 = IntPtr.Zero;
            //env.BmpPic = IntPtr.Zero;
            //env.BmpPic2 = IntPtr.Zero;
            //env.BmpPic3 = IntPtr.Zero;
            env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);

            //switch (mode)
            //{
            //    case "New":
            //        this.Text = "New Order";
            //        break;
            //    case "Edit":
            //        this.Text = "Edit Order";
            //        break;
            //    case "Last":
            //        this.Text = "Last Order";
            //        break;
            //    case "Manual":
            //        this.Text = "Manual Order";
            //        break;
            //    case "JohnDoe":
            //        this.Text = "John Doe";
            //        break;
            //}
        }
        private DataTable dtTemplateBillingLog;
        private void setTemplateBillingLog()
        {
            ProcessGetRISBillinglogWithHIS getBilling = new ProcessGetRISBillinglogWithHIS();
            getBilling.RIS_BILLINGLOG_WITH_HIS.ORDER_ID = 0;
            getBilling.Invoke();
            dtTemplateBillingLog = new DataTable();
            dtTemplateBillingLog = getBilling.Result.Tables[0].Copy();
        }
        private void setStartOrder()
        {
            StartPosition = FormStartPosition.CenterScreen;

            loadFormLanguage();
            clearContexInControl();
            setEnableDisableControl(false);
            defaultBackColor = txtLastVisit.BackColor;
            defaultForeColor = btnPhysician.ForeColor;
            setBackColor(defaultBackColor);
            setForeColor(defaultForeColor);
            setGridData(); setGridOrder();
        }
        private void setEnabledHN()
        {
            lblOrderNo.Visible = false;
            txtOrderNo.Visible = false;
            btnLookUpNo.Visible = false;
            txtHN.Enabled = true;
            txtHN.BackColor = Color.White;
            btnLookup.Enabled = true;
        }
        private void setDefault_PATSTATUS()
        {
            DataTable dt = RISBaseData.RIS_PatStatus().Copy();

            if (Miracle.Util.Utilities.IsHaveData(dt))
            {
                DataRow[] dr = dt.Select("IS_DEFAULT = 'Y'");
                if (dr.Length > 0)
                {
                    txtPatientType.Text = dr[0]["STATUS_TEXT"].ToString();
                    txtPatientType.Tag = dr[0]["STATUS_ID"].ToString();
                }
            }
        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID == 0 ? -1 : thisOrder.Item.ORDER_ID;
            prc.Invoke();
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();

            contextcmb.Items.Clear();
            System.Windows.Forms.ComboBox.ObjectCollection colls = contextcmb.Items;
            try
            {
                foreach (DataRow row in dtExamFlagDTL.Rows)
                    colls.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
            }
            finally
            {
            }
            contextcmb.SelectedIndex = 0;
        }
        private void getTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID == 0 ? -1 : thisOrder.Item.ORDER_ID;
            prc.Invoke();
            dttExamFlag = prc.Result.Tables[0];
        }
        private void updateIsLock()
        {
            if (SL_NO > 0)
            {
                foreach (DataRow drUnlock in dtOrderdtlEdit.Rows)
                {
                    if (drUnlock["ACCESSION_NO"].ToString() != string.Empty)
                    {
                        ProcessUpdateRISExamresultlocks prc = new ProcessUpdateRISExamresultlocks();
                        prc.RIS_EXAMRESULTLOCK.ACCESSION_NO = drUnlock["ACCESSION_NO"].ToString();
                        prc.RIS_EXAMRESULTLOCK.SL_NO = Convert.ToByte(drUnlock["SL_NO"].ToString());
                        prc.RIS_EXAMRESULTLOCK.IS_LOCKED = 'N';
                        prc.RIS_EXAMRESULTLOCK.UNLOCKED_BY = env.UserID;
                        prc.RIS_EXAMRESULTLOCK.ORG_ID = 1;
                        prc.RIS_EXAMRESULTLOCK.LAST_MODIFIED_BY = env.UserID;

                        prc.Invoke();
                    }
                }
            }
            else if (SL_NO == -2)
            {
                foreach (DataRow drUnlock in dtOrderdtlEdit.Rows)
                {
                    if (drUnlock["ACCESSION_NO"].ToString() != string.Empty)
                    {
                        if (drUnlock["SL_NO"].ToString() != string.Empty)
                        {
                            ProcessUpdateRISExamresultlocks prc = new ProcessUpdateRISExamresultlocks();
                            prc.RIS_EXAMRESULTLOCK.ACCESSION_NO = drUnlock["ACCESSION_NO"].ToString();
                            prc.RIS_EXAMRESULTLOCK.SL_NO = Convert.ToByte(drUnlock["SL_NO"].ToString());
                            prc.RIS_EXAMRESULTLOCK.IS_LOCKED = 'N';
                            prc.RIS_EXAMRESULTLOCK.UNLOCKED_BY = env.UserID;
                            prc.RIS_EXAMRESULTLOCK.ORG_ID = 1;
                            prc.RIS_EXAMRESULTLOCK.LAST_MODIFIED_BY = env.UserID;

                            prc.Invoke();
                        }
                    }
                }
            }
        }
        private int checkIsLock(string AccessionNO)
        {
            LookUpSelect ls = new LookUpSelect();
            DataSet dsLock = ls.SelectExamResultLock(AccessionNO, env.UserID);
            SL_NO = 0;
            if (dsLock.Tables[1].Rows.Count > 0)
            {
                if (dsLock.Tables[1].Rows[0]["WORKING_RAD"].ToString() == env.UserID.ToString())
                {
                    SL_NO = Convert.ToInt32(dsLock.Tables[1].Rows[0]["SL_NO"].ToString());
                    return env.UserID; //true 
                }
            }
            else
            {
                return env.UserID; //true
            }
            return -1; // false, This case can't select
        }

        private void btnICD_Click(object sender, EventArgs e)
        {
            Envision.NET.Forms.Dialog.frmICD frm = new Envision.NET.Forms.Dialog.frmICD();
            if (thisOrder.Ris_PatICD != null)
            {
                if (thisOrder.Ris_PatICD.Rows.Count > 0)
                    frm.ICDTable = thisOrder.Ris_PatICD.Copy();
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (DialogResult.OK == frm.ShowDialog())
                thisOrder.Ris_PatICD = frm.ICDTable.Copy();
        }
        private void btnDocInstruction_Click(object sender, EventArgs e)
        {
            Envision.NET.Forms.Dialog.frmDocInstruction frm = new Envision.NET.Forms.Dialog.frmDocInstruction();
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.REF_DOC = thisOrder.Item.REF_DOC_INSTRUCTION;
            frm.CLINIC = thisOrder.Item.CLINICAL_INSTRUCTION;
            if (DialogResult.OK == frm.ShowDialog())
            {
                thisOrder.Item.REF_DOC_INSTRUCTION = frm.REF_DOC;
                thisOrder.Item.CLINICAL_INSTRUCTION = frm.CLINIC;
            }
        }
        private void btnScanOrder_Click(object sender, EventArgs e)
        {
            ScanClick();
        }
        private void ScanClick()
        {
            if (!Utilities.IsHaveData(thisOrder.Ris_OrderImage))
                thisOrder.Ris_OrderImage = new ScanImages().GetData(0, thisOrder.Item.ORDER_ID);

            using (diagUploadFile diag = new diagUploadFile(thisOrder.Ris_OrderImage, false))
            {
                if (Height > diag.Height)
                    diag.Height = Height;
                if (Width > diag.Width)
                    diag.Width = Width;

                if (diag.ShowDialog() == DialogResult.OK)
                    thisOrder.Ris_OrderImage = diag.OrderImages;
                else if (diag.ShowDialog() == DialogResult.Abort)
                {
                    PointerStruct.ImageUrl = env.PacsUrl2;
                    if (mode == "Edit")
                    {
                        if (thisOrder.Ris_OrderImage.ToTable().Rows.Count > 0)
                        {

                            Miracle.Scanner.EditImageOrder editFrm = new Miracle.Scanner.EditImageOrder(thisOrder.Ris_OrderImage.ToTable(), env.PixPicture);
                            editFrm.StartPosition = FormStartPosition.CenterParent;
                            editFrm.ShowDialog();
                            if (editFrm.DialogResult == DialogResult.Yes)
                            {
                                thisOrder.Ris_OrderImage = editFrm.Data.Copy().DefaultView;
                                env.PixPicture = editFrm.PictureStruct;
                            }

                        }
                        else
                        {
                            Miracle.Scanner.NewScan frm = new Miracle.Scanner.NewScan(env.PixPicture);
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                btnSendToPrint.Focus();
                                env.PixPicture = frm.PictureStruct;
                            }
                        }
                    }
                    else
                    {
                        Miracle.Scanner.NewScan frm = new Miracle.Scanner.NewScan(env.PixPicture);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            btnSendToPrint.Focus();
                            env.PixPicture = frm.PictureStruct;
                        }
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string s = string.Empty;

            if (mode == "Edit")
            {
                #region Update Order
                if (checkRequireModeEdit())
                {
                    s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (SL_NO > 0)
                        {
                            updateIsLock();
                        }

                        fillDataToEditOrder(thisOrder);
                        updateData();
                    }
                }
                #endregion
            }
            else
            {
                #region Create Order
                bool addDetials = true; //เช็คกรณี save same

                if (checkRequireModeCreate(ref addDetials))
                {
                    s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (addDetials)
                        {
                            if (mode.ToUpper() == "LAST")
                                thisOrder.Item.ORDER_ID = 0;
                            fillDataToCreateOrder(thisOrder);
                        }

                        insertData();

                        if (!string.IsNullOrEmpty(thisOrder.Item.REQUESTNO))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }

                    }
                }
                #endregion
            }
        }
        private void btnSaveSame_Click(object sender, EventArgs e)
        {
            if (mode == "Edit")
            {
                #region Cancel Order
                string s = msg.ShowAlert("UID1022", env.CurrentLanguageID);
                if (s == "2")
                {
                    #region Check Status exam is not New,Complete

                    DataView dvE = (DataView)grdData.DataSource;
                    DataTable dtE = dvE.Table.Clone();
                    foreach (DataRow drr in dvE.Table.Rows)
                    {
                        if (drr["ORDER_ID"].ToString() != string.Empty)
                        {
                            if (drr["STATUS"].ToString() == "P" || drr["STATUS"].ToString() == "F" || drr["STATUS"].ToString() == "D")
                            {
                                msg.ShowAlert("UID4026", new GBLEnvVariable().CurrentLanguageID);
                                updateIsLock();
                                panelMain.Enabled = false;
                                string hnTmp = txtHN.Text;
                                thisOrder = new Order();
                                clearContexInControl();
                                setEnableDisableControl(false);
                                setBackColor(defaultBackColor);
                                setForeColor(defaultForeColor);
                                setInitalVariable();

                                setGridData();
                                setGridOrder();
                                txtOrderNo.Enabled = true;
                                txtOrderNo.BackColor = Color.White;
                                btnLookUpNo.Enabled = true;
                                txtOrderNo.Focus();
                                return;
                            }
                        }
                    }

                    #endregion
                    #region Call Cancel Reason
                    frmOrdersCancelForm frmCancel
                        = new frmOrdersCancelForm();
                    if (frmCancel.ShowDialog() != DialogResult.OK) return;

                    DataRow rowCancel = frmCancel.SELECTED;
                    string strCancel = rowCancel["CAN_NAME"].ToString();
                    #endregion


                    RIS_ORDER ord = new RIS_ORDER();
                    ord.ORDER_ID = thisOrder.Item.ORDER_ID; ;
                    ord.IS_CANCELED = 'Y';
                    ord.LAST_MODIFIED_BY = env.UserID;
                    ord.REASON = strCancel; //เพิ่มบรรทัด นี้เข้าไป
                    ProcessUpdateRISOrder processUpdate = new ProcessUpdateRISOrder(ord, true);
                    processUpdate.Invoke();

                    //DataView dv = (DataView)grdData.DataSource;
                    DataView dv = new DataView(dtOrderdtlEdit);
                    DataTable dtt = dv.Table.Clone();
                    if (dv.Table.Rows.Count > 1)
                    {

                        dtt.Columns.Add("ordflag", typeof(string));

                        foreach (DataRow dr in dv.Table.Rows)
                        {
                            if (dr["ORDER_ID"].ToString().Trim() != string.Empty)
                            {
                                DataRow drDtt = dtt.NewRow();
                                for (int i = 0; i < dv.Table.Columns.Count; i++)
                                    drDtt[i] = dr[i];
                                drDtt["ordflag"] = "CA";
                                drDtt["ORDER_ID"] = dr["ORDER_ID"];
                                drDtt["ACCESSION_NO"] = dr["ACCESSION_NO"];
                                dtt.Rows.Add(drDtt);

                                dtt.AcceptChanges();

                                #region cancel billing
                                try
                                {
                                    string his_ack = fnBill.Cancel_Billing(txtHN.Text, dr["EXAM_UID"].ToString().Trim() + dr["ACCESSION_NO"].ToString(), " ", " ");
                                    fnBill.UpdateHisSync(dr["ACCESSION_NO"].ToString(), his_ack);
                                    if (his_ack.Trim() != "Success in Cancel_Billing")
                                    {
                                        MessageBox.Show("ไม่สามารถทำการยกเลิกบิลลิ่งได้ กรุณาติดต่อเจ้าหน้าที่", "Billing Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("ไม่สามารถทำการยกเลิกบิลลิ่งได้ กรุณาติดต่อเจ้าหน้าที่", "Billing Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    MessageBox.Show(ex.Message);
                                }
                                #endregion
                            }
                        }

                        dtt.AcceptChanges();
                        ProcessUpdateRISOrderdtl processUpdateDTL = new ProcessUpdateRISOrderdtl();
                        processUpdateDTL.UpdateFlag(dtt, "Y");
                   
                        GenerateORM genHl7 = new GenerateORM();
                        Patient p = (Patient)thisOrder.Demographic;
                        DataTable dttSendToPacs = genHl7.ORMMessage(p.ConvertToPatientHL7(), dtt);
                        ProcessUpdateRISOrderdtl processUpdateDtl = new ProcessUpdateRISOrderdtl();
                        processUpdateDtl.UpdateHL7(dttSendToPacs);

                        #region Clear Consumable Case before Send to PACS
                        try
                        {
                            DataTable dtTempIsInvestigation = dttSendToPacs.Clone();

                            foreach (DataRow drIsInvestigation in dttSendToPacs.Rows)
                            {
                                ProcessGetRISOrder getIsInvestigation = new ProcessGetRISOrder();
                                DataSet dsIsInvestigation =
                                    getIsInvestigation.GetIsInvestigation(drIsInvestigation["ACCESSION_NO"].ToString());
                                string IS_INVESTIGATION =
                                    dsIsInvestigation.Tables[0].Rows[0]["IS_INVESTIGATION"].ToString();

                                if (IS_INVESTIGATION == "Y")
                                {
                                    DataRow drTemp = dtTempIsInvestigation.NewRow();
                                    drTemp = drIsInvestigation;
                                    dtTempIsInvestigation.Rows.Add(drTemp.ItemArray);
                                }
                            }

                            dttSendToPacs = dtTempIsInvestigation;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ไม่สามารถทำการยกเลิกข้อมูลที่ PACS ได้ กรุณาติดต่อเจ้าหน้าที่", "PACS Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            MessageBox.Show(ex.Message, ex.Source);
                        }
                        #endregion

                        foreach (DataRow drSentToPacs in dtt.Rows)
                        {
                            new SendToPacs().Set_ORMByOrderIdQueue(Convert.ToInt32(drSentToPacs["ORDER_ID"]));
                        }

                        cboGender.SelectedIndex = 0;
                        thisOrder = new Order();
                        orderManger = new OrderManager();
                        loadFormLanguage();
                        clearContexInControl();
                        setEnableDisableControl(false);
                        setBackColor(defaultBackColor);
                        setForeColor(defaultForeColor);
                        setGridData();
                        setGridOrder();
                    }
                    frmOrdersSelectMode("Edit");
                }
                #endregion
            }
            else
            {
                #region Save Same Patient
                bool flag = checkRequireModeCreateSamePatient();
                if (flag)
                {
                    Order ord = new Order();
                    fillDataToCreateOrder(ord);

                    //เคลียร์ Value;
                    //env.CountImg = "";
                    scheduleID = 0;
                    DataTable dtt = thisOrder.Ris_OrderImage.ToTable().Clone();
                    thisOrder.Ris_OrderImage = null;
                    thisOrder.Ris_OrderImage = dtt.DefaultView;
                    dtt = thisOrder.ItemDetail.Clone();
                    thisOrder.ItemDetail = null;
                    DataRow dr = dtt.NewRow();
                    dr["SPECIAL_CLINIC"] = "N";
                    dr["IS_DELETED"] = "N";
                    dr["PRIORITY"] = "R";
                    dr["EXAM_DT"] = DateTime.Today;
                    dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                    dtt.Rows.Add(dr);
                    thisOrder.ItemDetail = dtt;
                    dtt = thisOrder.Ris_PatICD.Clone();
                    thisOrder.Ris_PatICD = null;
                    thisOrder.Ris_PatICD = dtt;
                    thisOrder.Item.CLINICAL_INSTRUCTION = string.Empty;
                    thisOrder.Item.REF_DOC_INSTRUCTION = string.Empty;
                    DataSet dsOrder = thisOrder.TreeData.Copy();
                    setTreeOrder(ord, dsOrder);
                    thisOrder.TreeData = dsOrder;


                    //bind ข้อมูลใหม่ใน DataGrid
                    setGridData();
                    setGridOrder();
                    calTotal();
                    gridControl3.Enabled = true;
                }
                #endregion
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            string s = string.Empty;

            if (mode == "Edit")
            {
                #region Update Order
                if (checkRequireModeEdit())
                {
                    s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (SL_NO > 0)
                        {
                            updateIsLock();
                        }

                        fillDataToEditOrder(thisOrder);
                        updateDataByPrintPreview();
                    }
                }
                #endregion
            }
            else
            {
                #region Create Order
                bool addDetials = true;

                if (checkRequireModeCreate(ref addDetials))
                {
                    s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (addDetials)
                            fillDataToCreateOrder(thisOrder);

                        insertDataByPrintPreview();

                        if (!string.IsNullOrEmpty(thisOrder.Item.REQUESTNO))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                #endregion
            }
        }
        private void btnSendToPrint_Click(object sender, EventArgs e)
        {
            string s = string.Empty;

            if (mode == "Edit")
            {
                #region Update Order
                if (checkRequireModeEdit())
                {
                    s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (SL_NO > 0)
                        {
                            updateIsLock();
                        }

                        fillDataToEditOrder(thisOrder);
                        updateDataBySendToPrint();
                        frmOrdersSelectMode("New");
                        this.txtHN.Focus();
                    }
                }
                #endregion
            }
            else
            {
                #region Create Order
                bool addDetials = true;

                if (checkRequireModeCreate(ref addDetials))
                {
                    s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (addDetials)
                            fillDataToCreateOrder(thisOrder);

                        insertDataBySendToPrint();

                        if (!string.IsNullOrEmpty(thisOrder.Item.REQUESTNO))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            frmOrdersSelectMode("New");
                            this.txtHN.Focus();
                        }
                    }
                }
                #endregion
            }
        }

        private void datePeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDOB.Enabled) txtDOB.Focus();
                else txtTelephone.Focus();
            }
        }
        private void datePeriod_Validating(object sender, CancelEventArgs e)
        {
            if (txtDOB.Enabled) txtDOB.Focus();
            else if (txtTelephone.Enabled) txtTelephone.Focus();
            else if (txtPatientType.Enabled) txtPatientType.Focus();
            else if (txtOrderDepartment.Enabled) txtOrderDepartment.Focus();
            else if (txtOrderPhysician.Enabled) txtOrderPhysician.Focus();
        }

        #region Manu Tab
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkList' and MENU_ID=" + this.Menu_ID);

            if (rows.Length > 0)
            {
                Envision.NET.Forms.Orders.frmArrivalWorkListNew frm = new Envision.NET.Forms.Orders.frmArrivalWorkListNew();
                frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                frm.Text = frm.Menu_Name_User;
                frm.ShowWaitDialog();
                frm.MdiParent = this.MdiParent;
                frm.Show();
                this.Close();
            }
        }
        private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }

            EnableForJohndoe(true);
            frmOrdersSelectMode("New");
            this.txtHN.Focus();
        }
        private void barModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }

            EnableForJohndoe(true);
            frmOrdersSelectMode("Edit");
            this.txtOrderNo.Focus();
        }
        private void barSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // OLD CODE
            //Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            //DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            //DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmScheduleWorkList'");

            //if (rows.Length > 0)
            //{
            //    int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
            //    if (!main.FormIsAlive(id))
            //    {
            //        Envision.NET.Forms.Schedule.frmScheduleWorkList frm = new Envision.NET.Forms.Schedule.frmScheduleWorkList();
            //        frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
            //        frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
            //        frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
            //        frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
            //        frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
            //        frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
            //        frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
            //        frm.Text = frm.Menu_Name_User;
            //        frm.ShowWaitDialog();
            //        frm.MdiParent = this.MdiParent;
            //        frm.Show();
            //        this.Close();
            //    }
            //}

            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            //DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkListExtend'");
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmArrivalWorkListNew'");

            if (rows.Length > 0)
            {
                int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                if (!main.FormIsAlive(id))
                {
                    Envision.NET.Forms.Orders.frmArrivalWorkListNew frm = new Envision.NET.Forms.Orders.frmArrivalWorkListNew();
                    frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                    frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                    frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                    frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                    frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                    frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                    frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                    frm.Text = frm.Menu_Name_User;
                    frm.ShowWaitDialog();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    this.Close();
                }
            }
        }
        private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }

            frmOrdersSelectMode("Last");
            this.txtHN.Focus();
        }
        private void barPrintLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }
            Envision.NET.Forms.Main.frmMain main = (Envision.NET.Forms.Main.frmMain)this.MdiParent;
            DataSet menu = Envision.NET.Forms.Main.MasterForm.MenuInfo;
            DataRow[] rows = menu.Tables[1].Select("SUBMENU_CLASS_NAME='frmReprint' and MENU_ID=" + this.Menu_ID);

            if (rows.Length > 0)
            {
                int id = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                if (!main.FormIsAlive(id))
                {
                    Envision.NET.Forms.Orders.frmReprint frm = new Envision.NET.Forms.Orders.frmReprint();
                    frm.Menu_ID = Convert.ToInt32(rows[0]["MENU_ID"].ToString());
                    frm.Submenu_ID = Convert.ToInt32(rows[0]["SUBMENU_ID"].ToString());
                    frm.Role_ID = Convert.ToInt32(rows[0]["ROLE_ID"].ToString());
                    frm.Menu_Name_Class = rows[0]["SUBMENU_CLASS_NAME"].ToString();
                    frm.Menu_Name_User = rows[0]["SUBMENU_NAME_USER"].ToString();
                    frm.Menu_Namespace = rows[0]["MENU_NAMESPACE"].ToString();
                    frm.Menu_FullNamespace = frm.Menu_Namespace + "." + frm.Menu_Name_Class;
                    frm.Text = frm.Menu_Name_User;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    this.Close();
                }
            }
        }
        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }
        }
        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }

            ((Envision.NET.Forms.Main.frmMain)this.MdiParent).DisplayHome();
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }

            this.Close();
        }
        private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }

            EnableForJohndoe(true);
            setDefault_PATSTATUS();
            frmOrdersSelectMode("Manual");
            lblDOB.ContainerText = "DOB";
            this.txtThaiName.Focus();
        }
        private void barJohnDoe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SL_NO > 0)
            {
                updateIsLock();
            }

            EnableForJohndoe(true);
            setDefault_PATSTATUS();
            frmOrdersSelectMode("JohnDoe");
            lblDOB.ContainerText = "DOB";
            this.txtThaiName.Focus();
        }
        private void barScanImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmScanImage frm = new frmScanImage();
            frm.ShowDialog();
            frm.Dispose();
        }
        #endregion

        #region Grid Show last 3 Order like Tree.
        private void setGridOrder()
        {
            DataTable dtRoot = thisOrder.TreeData.Tables["Root"];
            if (dtRoot.Rows.Count == 0)
            {
                DataRow dr = dtRoot.NewRow();
                dr["Caption"] = "No Order";
                dr["Level"] = 100;
                dtRoot.Rows.Add(dr);
            }
            gridControl3.DataSource = dtRoot;
            for (int i = 0; i < advBandedGridView2.Columns.Count; i++)
                advBandedGridView2.Columns[i].Visible = false;
            advBandedGridView2.OptionsBehavior.Editable = false;
            advBandedGridView2.OptionsView.ShowBands = false;
            advBandedGridView2.OptionsDetail.ShowDetailTabs = false;
            advBandedGridView2.OptionsView.ShowGroupPanel = false;
            advBandedGridView2.BestFitColumns();

            advBandedGridView2.Columns["Caption"].Visible = true;
            advBandedGridView2.Columns["Caption"].Width = 100;
            advBandedGridView2.OptionsView.ShowColumnHeaders = false;

            DevExpress.XtraGrid.Columns.GridColumn colID = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colID.Caption = "Order";
            colID.FieldName = "Caption";
            colID.Visible = true;
            colID.VisibleIndex = 0;
            colID.OptionsColumn.ReadOnly = true;
            colDateTime.Caption = "Date";
            colDateTime.FieldName = "DateTime";
            colDateTime.Visible = true;
            colDateTime.VisibleIndex = 1;
            colDateTime.OptionsColumn.ReadOnly = true;
            colDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colDateTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";



            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colID, colDateTime });
            gridView1.GridControl = gridControl3;
            gridView1.ViewCaption = "Master";
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowColumnHeaders = false;
            //gridView1.OptionsSelection.InvertSelection = true;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowHorzLines = false;
            gridView1.OptionsView.ShowVertLines = false;


            gridView1.KeyPress += new KeyPressEventHandler(gridView1_KeyPress);

            gridView1.ShownEditor += new EventHandler(gridView1_ShownEditor);
            gridView1.HiddenEditor += new EventHandler(gridView1_HiddenEditor);
            gridView1.MouseDown += new MouseEventHandler(gridView1_MouseDown);
            gridView1.MouseUp += new MouseEventHandler(gridView1_MouseUp);
            gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            gridLevelNode1.LevelTemplate = gridView1;
            gridLevelNode1.RelationName = "Root_Master";

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME") });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.ShowFooter = false;
            repositoryItemLookUpEdit2.ShowHeader = false;
            repositoryItemLookUpEdit2.NullText = "Exam Name";
            repositoryItemLookUpEdit2.DataSource = dtExam;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit4 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODALITY_NAME") });
            repositoryItemLookUpEdit4.DisplayMember = "MODALITY_NAME";
            repositoryItemLookUpEdit4.ValueMember = "MODALITY_ID";
            repositoryItemLookUpEdit4.DropDownRows = 5;
            repositoryItemLookUpEdit4.ShowFooter = false;
            repositoryItemLookUpEdit4.ShowHeader = false;
            repositoryItemLookUpEdit4.NullText = "Modularity";
            repositoryItemLookUpEdit4.DataSource = RISBaseData.Ris_Modality();

            DevExpress.XtraGrid.Columns.GridColumn colEXAM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colEXAM_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colMODALITY_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            colEXAM_ID.Caption = "Exam ID";
            colEXAM_ID.FieldName = "EXAM_ID";
            colEXAM_ID.Visible = true;
            colEXAM_ID.VisibleIndex = 0;
            colEXAM_Name.Caption = "Exam Name";
            colEXAM_Name.FieldName = "EXAM_ID";
            colEXAM_Name.ColumnEdit = repositoryItemLookUpEdit2;
            colEXAM_Name.Visible = true;
            colEXAM_Name.VisibleIndex = 1;
            colEXAM_Name.OptionsColumn.ReadOnly = true;
            colEXAM_ID.OptionsColumn.ReadOnly = true;
            colMODALITY_ID.ColumnEdit = repositoryItemLookUpEdit4;
            colMODALITY_ID.Caption = "Modality";
            colMODALITY_ID.FieldName = "MODALITY_ID";
            colMODALITY_ID.Visible = true;
            colMODALITY_ID.VisibleIndex = 2;
            colMODALITY_ID.OptionsColumn.ReadOnly = true;
            DevExpress.XtraGrid.Views.Grid.GridView gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colEXAM_ID, colEXAM_Name, colMODALITY_ID });
            gridView2.GridControl = gridControl3;
            gridView2.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowColumnHeaders = true;
            gridView2.OptionsSelection.InvertSelection = true;
            gridView2.OptionsView.ShowIndicator = false;

            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();

            gridLevelNode2.LevelTemplate = gridView2;
            gridLevelNode2.RelationName = "Master_Details";

            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode2 });
            gridControl3.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1, gridLevelNode2 });
            gridControl3.ShowOnlyPredefinedDetails = true;
            gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });

            advBandedGridView2.Columns["Level"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
        private void doDoubleClickRow(GridView view, int rowHandle)
        {
            #region Old Code
            //try
            //{

            //    DataRow dr = view.GetDataRow(rowHandle);
            //    if ((int)dr[3] == 1)
            //    {
            //        if (myGlobalBaseData.Count == 0)
            //            myGlobalBaseData.Schedule_ID = (int)dr[0];
            //        else
            //        {
            //            string s = msg.ShowAlert("UID100", new GBLEnvVariable().CurrentLanguageID);
            //            if (s == "2")
            //            {
            //                //chkSpecialClinic.Checked = dr[4].ToString().Trim() == string.Empty || dr[4].ToString() == "N" ? false : true;
            //                myGlobalBaseData.Schedule_ID = (int)dr[0];
            //            }
            //            else
            //                return;
            //        }
            //        hasSchedule = myGlobalBaseData.HasSchedule;
            //        scheduleID = myGlobalBaseData.Schedule_ID;
            //        if (dsPreviosOrder == null)
            //            dsPreviosOrder = myGlobalBaseData.PreviousGlobalBaseData.Copy();
            //        DataSet dsOrder = dsPreviosGlobalBaseData.Copy();
            //        for (int i = 0; i < dsOrder.Tables["Masters"].Rows.Count; i++)
            //        {
            //            if ((int)dsOrder.Tables["Masters"].Rows[i]["Level"] == 1 && (int)dsOrder.Tables["Masters"].Rows[i]["ID"] == scheduleID)
            //            {
            //                dsOrder.Tables["Masters"].Rows[i].Delete();
            //                break;
            //            }
            //        }
            //        dsOrder.AcceptChanges();
            //        bool flag = true;
            //        for (int i = 0; i < dsOrder.Tables["Masters"].Rows.Count; i++)
            //            if ((int)dsOrder.Tables["Masters"].Rows[i]["Level"] == 1)
            //            {
            //                flag = false;
            //                break;
            //            }
            //        if (flag)
            //        {
            //            for (int i = 0; i < dsOrder.Tables["Root"].Rows.Count; i++)
            //            {
            //                if ((int)dsOrder.Tables["Root"].Rows[i]["Level"] == 1)
            //                {
            //                    dsOrder.Tables["Root"].Rows[i].Delete();
            //                    break;
            //                }
            //            }
            //        }
            //        dsOrder.AcceptChanges();
            //        myGlobalBaseData.PreviousOrder = dsOrder;
            //        SetGridData();
            //        SetGridOrder();
            //        txtInsurace.Focus();
            //    }
            //}
            //catch { }
            //finally { }
            #endregion

            try
            {
                DataRow dr = view.GetDataRow(rowHandle);
                if ((int)dr[3] == 1)
                {
                    string s = msg.ShowAlert("UID100", new GBLEnvVariable().CurrentLanguageID);
                    if (s == "2")
                    {
                        scheduleID = thisOrder.ScheduleID = (int)dr[0];
                        DataSet dsOrder = thisOrder.TreeData.Copy();
                        if (orderManger.Count > 0)
                        {
                            for (int i = 0; i < orderManger.Count; i++)
                                setTreeOrder(orderManger[i], dsOrder);
                            for (int j = 0; j < orderManger.Count; j++)
                            {
                                if (orderManger[j].ScheduleID == 0) continue;
                                for (int i = 0; i < dsOrder.Tables["Masters"].Rows.Count; i++)
                                {
                                    if ((int)dsOrder.Tables["Masters"].Rows[i]["Level"] == 1 && (int)dsOrder.Tables["Masters"].Rows[i]["ID"] == orderManger[j].ScheduleID)
                                    {
                                        dsOrder.Tables["Masters"].Rows[i].Delete();
                                        break;
                                    }
                                }
                                dsOrder.AcceptChanges();
                            }

                        }
                        for (int i = 0; i < dsOrder.Tables["Masters"].Rows.Count; i++)
                        {
                            if ((int)dsOrder.Tables["Masters"].Rows[i]["ID"] == scheduleID && (int)dsOrder.Tables["Masters"].Rows[i]["Level"] == 1)
                            {
                                dsOrder.Tables["Masters"].Rows[i].Delete();
                                break;
                            }
                        }
                        dsOrder.AcceptChanges();
                        bool flag = true;
                        foreach (DataRow drMaster in dsOrder.Tables["Masters"].Rows)
                        {
                            if (drMaster["Level"].ToString() == "1")
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            int i = 0;
                            while (i < dsOrder.Tables["Root"].Rows.Count)
                            {
                                if (dsOrder.Tables["Root"].Rows[i]["Level"].ToString() == "1")
                                {
                                    dsOrder.Tables["Root"].Rows[i].Delete();
                                    break;
                                }
                                else
                                    i++;
                            }
                        }

                        thisOrder.TreeData = dsOrder;

                        setGridData();
                        setGridOrder();

                        DataTable dttHis = dtRefDoc.Copy();// myGlobalBaseData.HIS_Doctor();
                        foreach (DataRow dr_doc in dttHis.Rows)
                        {
                            if (thisOrder.Item.REF_DOC.ToString().Trim().ToUpper() == dr_doc["EMP_ID"].ToString().Trim().ToUpper())
                            {
                                txtOrderPhysician.Tag = dr_doc["EMP_ID"].ToString();
                                txtOrderPhysician.Text = dr_doc["EMP_UID"].ToString() + ":" + dr_doc["RadioName"].ToString();
                                break;
                            }
                        }

                        DataTable dttDep = dtRefUnit.Copy();// myGlobalBaseData.HIS_Department();
                        foreach (DataRow drDep in dttDep.Rows)//UNIT_NAME
                        {
                            if (thisOrder.Item.REF_UNIT.ToString().Trim().ToUpper() == drDep["UNIT_ID"].ToString().Trim().ToUpper())
                            {
                                txtOrderDepartment.Tag = drDep["UNIT_ID"].ToString();
                                txtOrderDepartment.Text = drDep["UNIT_UID"].ToString() + ":" + drDep["UNIT_NAME"].ToString() + "(" + drDep["PHONE_NO"].ToString() + ")";
                                txtOrderDept.Text = drDep["PHONE_NO"].ToString();
                                break;
                            }
                        }
                        LookUpSelect lvS = new LookUpSelect();
                        DataTable dtS = lvS.ScheduleNotParameter("Prepation").Tables[0];
                        foreach (DataRow drPre in dtS.Rows)
                        {

                            if (thisOrder.ItemDetail.Rows[0]["PREPARATION_ID"].ToString() == drPre["PREPARATION_ID"].ToString())
                            {
                                txtPreparation.Tag = Convert.ToInt32(drPre["PREPARATION_ID"].ToString());
                                txtPreparation.Text = drPre["PREPARATION_DESC"].ToString();
                                break;
                            }
                        }
                    }
                    else
                        return;
                }
            }
            catch { }
        }
        private void setTreeOrder(Order ord, DataSet dsOrder)
        {
            DataRow dr;
            DataRow[] drs;
            DataView dv;
            int newOrder = -1;
            #region Create New Order
            drs = dsOrder.Tables["Root"].Select("Level = 0");
            if (drs.Length == 0)
            {
                dr = dsOrder.Tables["Root"].NewRow();
                dr[0] = "New Order";
                dr[1] = 0;
                dsOrder.Tables["Root"].Rows.Add(dr);
                dsOrder.Tables["Root"].AcceptChanges();
            }
            else
            {
                //set id order
                dv = dsOrder.Tables["Masters"].DefaultView;
                dv.RowFilter = "Caption = 'New Order'";
                dv.Sort = "ID DESC";

                if (dv.Count > 0)
                {
                    int i = Convert.ToInt32(dv[0]["ID"]);

                    if (newOrder < i)
                    {
                        newOrder = i;
                    }
                }
            }


            foreach (DataRow drID in dsOrder.Tables["Details"].Rows)
            {
                int id = Convert.ToInt32(drID["ID"].ToString());
                if (id > newOrder)
                {
                    newOrder = id;
                    break;
                }
            }
            newOrder++;
            dsOrder.AcceptChanges();

            DataRow drMas = dsOrder.Tables["Masters"].NewRow();
            drMas["ID"] = newOrder;
            drMas["Caption"] = "New Order";
            drMas["DateTime"] = DateTime.Today;
            drMas["Level"] = 0;
            dsOrder.Tables["Masters"].Rows.Add(drMas);
            dsOrder.Tables["Masters"].AcceptChanges();

            DataTable dttDetails = dsOrder.Tables["Details"];

            foreach (DataRow _dr in ord.ItemDetail.Rows)
            {
                DataRow drDetail = dttDetails.NewRow();
                drDetail["ID"] = newOrder;
                drDetail["EXAM_ID"] = _dr["EXAM_ID"];
                drDetail["MODALITY_ID"] = _dr["MODALITY_ID"];
                drDetail["Level"] = 0;
                //dsOrder.Tables["Details"].Rows.Add(dr);
                dttDetails.Rows.Add(drDetail);
                dttDetails.AcceptChanges();
            }
            #endregion

            #region Remove No Order
            drs = dsOrder.Tables["Root"].Select("Level = 100");
            foreach (DataRow _dr in drs)
            {
                dsOrder.Tables["Root"].Rows.Remove(_dr);
            }
            #endregion
            dsOrder.AcceptChanges();

            //DataTable dt1 = dsOrder.Tables[0];
            //DataTable dt2 = dsOrder.Tables[1];
            //DataTable dt3 = dsOrder.Tables[2];
        }

        private void editor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
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
                doDoubleClickRow(view, rowHandle);
            }
            clickTick = System.Environment.TickCount;
        }
        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (activeEditor != null)
            {
                activeEditor.MouseDown -= new MouseEventHandler(editor_MouseDown);
                activeEditor = null;
            }
        }
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if ((System.Environment.TickCount - clickTick) < SystemInformation.DoubleClickTime)
            {
                if (view.GetShowEditorMode() == DevExpress.Utils.EditorShowMode.MouseDown)
                    firstClickFlag = true;
                view.ActiveEditor.MouseDown += new MouseEventHandler(editor_MouseDown);
                activeEditor = view.ActiveEditor;
            }
        }
        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.GetShowEditorMode() != DevExpress.Utils.EditorShowMode.MouseDown)
                setTickCount(view, e);
        }
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.GetShowEditorMode() != DevExpress.Utils.EditorShowMode.MouseUp)
                setTickCount(view, e);
        }
        #endregion

        #region Grid Data for input Exam.
        private bool canAddRow()
        {
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            bool flag = true;
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        private bool canAddRow(DataTable dtt)
        {
            bool flag = true;
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private void setTreeRadioLogist(int RadioID, string RadioName)
        {
            try
            {
                ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
                DataView ddd = new DataView();
                ddd = (DataView)grdData.DataSource;
                DataTable dtt = process.GetRadioLogistWork(RadioID, dateDemo.DateTime);
                treeRadio.Nodes.Clear();
                treeRadio.Nodes.Add(RadioName);
                foreach (DataRow dr in dtt.Rows)
                {
                    TreeNode newNodes = new TreeNode(dr["EXAM_TYPE_TEXT"].ToString() + "(" + dr["Amt"].ToString() + ")");
                    treeRadio.Nodes[0].Nodes.Add(newNodes);
                }
                treeRadio.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void gridBestFitColumn()
        {
            view1.Columns["EXAM_NAME"].BestFit();
            view1.Columns["RATE"].BestFit();
            view1.Columns["EXAM_UID"].BestFit();
            view1.Columns["EXAM_NAME"].BestFit();
            view1.Columns["PRIORITY"].BestFit();
            view1.Columns["FLAG_ICON"].BestFit();
            view1.Columns["SPECIAL_RATE"].BestFit();
            view1.Columns["MODALITY_ID"].BestFit();
            view1.Columns["ASSIGNED_TO"].BestFit();
            view1.Columns["CLINIC_TYPE"].BestFit();
            view1.Columns["BPVIEW_ID"].BestFit();
            view1.Columns["QTY"].BestFit();
            int w = view1.Columns["EXAM_NAME"].Width;
            view1.Columns["EXAM_NAME"].Width = w + 10;
            //w = view1.Columns["PRIORITY"].Width;
            view1.Columns["PRIORITY"].Width = 20;
            view1.Columns["FLAG_ICON"].Width = 20;
            w = view1.Columns["ASSIGNED_TO"].Width;
            view1.Columns["ASSIGNED_TO"].Width = w + 10;
            w = view1.Columns["CLINIC_TYPE"].Width;
            view1.Columns["CLINIC_TYPE"].Width = w + 5;
            w = view1.Columns["EXAM_UID"].Width;
            view1.Columns["EXAM_UID"].Width = w + 5;

            view1.Columns["colDelete"].Width = 10;
        }
        private void setGridData()
        {
            try
            {
                initiateExamPanel();

                DataTable dtt = thisOrder.ItemDetail;
                #region Check IS_Lock
                dtOrderdtlEdit = dtt.Copy();
                dtOrderdtlEdit.Columns.Add("SL_NO");
                foreach (DataRow drchk in dtOrderdtlEdit.Rows)
                {
                    if (drchk["ACCESSION_NO"].ToString() != string.Empty)
                    {
                        if (checkIsLock(drchk["ACCESSION_NO"].ToString()) < 0)
                        {
                            SL_NO = -2;
                            updateIsLock();
                            msg.ShowAlert("UID4026", env.CurrentLanguageID);
                            frmOrdersSelectMode("Edit");
                            return;
                        }
                        else
                        {
                            drchk["SL_NO"] = SL_NO;
                            dtOrderdtlEdit.AcceptChanges();
                        }
                    }
                }
                #endregion
                DataView dv = new DataView(dtt);
                if (dv.Table.Rows.Count > 0)
                    dv.RowFilter = " IS_DELETED <>'Y' ";
                grdData.DataSource = dv;
                view1.OptionsView.ShowBands = false;
                view1.OptionsSelection.EnableAppearanceFocusedCell = false;
                view1.OptionsSelection.EnableAppearanceFocusedRow = false;
                view1.OptionsView.ShowColumnHeaders = true;
                view1.OptionsCustomization.AllowSort = false;

                for (int i = 0; i < view1.Columns.Count; i++)
                    view1.Columns[i].Visible = false;

                view1.Columns["PRIORITY"].OptionsFilter.AllowFilter = false;
                view1.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;

                view1.Columns["EXAM_UID"].Caption = "Exam Code";
                view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                view1.Columns["PRIORITY"].Caption = " ";//"Priority";
                view1.Columns["FLAG_ICON"].Caption = " ";//"FLAG_ID";
                view1.Columns["RATE"].Caption = "Rate";
                view1.Columns["RATE"].OptionsColumn.ReadOnly = true;
                view1.Columns["CLINIC_TYPE"].Caption = "Clinic";
                view1.Columns["MODALITY_ID"].Caption = "Room";
                view1.Columns["ASSIGNED_TO"].Caption = "Radiologist";
                view1.Columns["BPVIEW_ID"].Caption = "Sides";
                view1.Columns["QTY"].Caption = "QTY";

                view1.Columns["PRIORITY"].ColVIndex = 1;
                view1.Columns["FLAG_ICON"].ColVIndex = 2;
                view1.Columns["EXAM_UID"].ColVIndex = 3;
                view1.Columns["EXAM_NAME"].ColVIndex = 4;
                view1.Columns["BPVIEW_ID"].ColVIndex = 5;
                view1.Columns["MODALITY_ID"].ColVIndex = 6;
                view1.Columns["QTY"].ColVIndex = 7;
                view1.Columns["RATE"].ColVIndex = 8;
                view1.Columns["CLINIC_TYPE"].ColVIndex = 9;
                view1.Columns["ASSIGNED_TO"].ColVIndex = 10;
                view1.Columns["colDelete"].ColVIndex = 11;

                view1.Columns["colDelete"].Visible = true;
                view1.Columns["EXAM_UID"].Visible = true;
                view1.Columns["EXAM_NAME"].Visible = true;
                view1.Columns["PRIORITY"].Visible = true;
                view1.Columns["FLAG_ICON"].Visible = true;
                view1.Columns["MODALITY_ID"].Visible = true;
                view1.Columns["ASSIGNED_TO"].Visible = true;
                view1.Columns["BPVIEW_ID"].Visible = true;
                view1.Columns["QTY"].Visible = true;

                //view1.Columns["EXAM_UID"].BestFit();
                //view1.Columns["EXAM_NAME"].BestFit();
                // view1.Columns["PRIORITY"].BestFit();
                view1.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
                view1.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view1.Columns["RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                //view1.Columns["CLINIC_TYPE"].BestFit();
                //view1.Columns["MODALITY_ID"].BestFit();
                //view1.Columns["ASSIGNED_TO"].BestFit();

                RepositoryItemSpinEdit spe = new RepositoryItemSpinEdit();
                spe.ValueChanged += new EventHandler(spe_ValueChanged);
                view1.Columns["QTY"].ColumnEdit = spe;

                RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
                btn.AutoHeight = false;
                btn.BestFitWidth = 9;
                btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
                btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btn.Buttons[0].Caption = string.Empty;
                btn.Click += new EventHandler(btnDeleteRow_Click);
                view1.Columns["colDelete"].Caption = string.Empty;
                view1.Columns["colDelete"].ColumnEdit = btn;
                view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                view1.Columns["colDelete"].Width = 10;
                view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                DataTable table_original = dtExam.Copy();
                DataRow[] exam_rows = table_original.Select("", "EXAM_UID ASC");
                DataTable exam_tb = table_original.Clone();
                foreach (DataRow dr in exam_rows)
                    exam_tb.Rows.Add(dr.ItemArray);
                exam_tb.AcceptChanges();

                RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit1.ImmediatePopup = true;
                repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit1.AutoHeight = false;
                repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
                repositoryItemLookUpEdit1.ValueMember = "EXAM_UID";
                repositoryItemLookUpEdit1.DropDownRows = 5;
                repositoryItemLookUpEdit1.DataSource = exam_tb;
                repositoryItemLookUpEdit1.NullText = string.Empty;
                repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examCode_KeyUp);
                repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode_CloseUp);
                repositoryItemLookUpEdit1.BestFit();
                repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                view1.Columns["EXAM_UID"].ColumnEdit = repositoryItemLookUpEdit1;
                view1.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit2.ImmediatePopup = true;
                repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit2.AutoHeight = false;
                repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
                repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
                repositoryItemLookUpEdit2.DropDownRows = 5;
                repositoryItemLookUpEdit2.DataSource = dtExam;
                repositoryItemLookUpEdit2.NullText = string.Empty;
                repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
                repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
                repositoryItemLookUpEdit2.BestFit();
                repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                view1.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
                view1.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                RepositoryItemImageComboBox rImcbBPView = new RepositoryItemImageComboBox();
                rImcbBPView.SmallImages = this.imgWL;
                rImcbBPView.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

                rImcbBPView.Buttons.Clear();
                //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});

                RepositoryItemLookUpEdit repositoryItemLookUpEdit3 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit3.ImmediatePopup = true;
                repositoryItemLookUpEdit3.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit3.AutoHeight = false;
                repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRIORITY", "Priority", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit3.DisplayMember = "PRIORITY";
                repositoryItemLookUpEdit3.ValueMember = "PRI_ID";
                repositoryItemLookUpEdit3.DropDownRows = 5;
                repositoryItemLookUpEdit3.NullText = string.Empty;
                repositoryItemLookUpEdit3.DataSource = RISBaseData.Ris_Priority();
                repositoryItemLookUpEdit3.KeyUp += new KeyEventHandler(priority_KeyUp);
                repositoryItemLookUpEdit3.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(priority_CloseUp);
                view1.Columns["PRIORITY"].ColumnEdit = rImcbBPView;
                view1.Columns["PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                view1.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;

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

                view1.Columns["FLAG_ICON"].ColumnEdit = repFlag;
                view1.Columns["FLAG_ICON"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                view1.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit4 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit4.ImmediatePopup = true;
                repositoryItemLookUpEdit4.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit4.AutoHeight = false;
                repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODALITY_NAME", "Modality", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit4.DisplayMember = "MODALITY_NAME";
                repositoryItemLookUpEdit4.ValueMember = "MODALITY_ID";
                repositoryItemLookUpEdit4.DropDownRows = 5;
                repositoryItemLookUpEdit4.NullText = string.Empty;
                repositoryItemLookUpEdit4.KeyUp += new KeyEventHandler(modality_KeyUp);
                repositoryItemLookUpEdit4.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(modality_CloseUp);
                repositoryItemLookUpEdit4.DataSource = RISBaseData.Ris_Modality();
                repositoryItemLookUpEdit4.BestFit();
                repositoryItemLookUpEdit4.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                view1.Columns["MODALITY_ID"].ColumnEdit = repositoryItemLookUpEdit4;
                view1.Columns["MODALITY_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit5 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit5.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit5.ImmediatePopup = true;
                repositoryItemLookUpEdit5.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit5.AutoHeight = false;
                repositoryItemLookUpEdit5.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UIDAndRadioName", "Radiologist", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit5.DisplayMember = "UIDAndRadioName";
                repositoryItemLookUpEdit5.ValueMember = "EMP_ID";
                repositoryItemLookUpEdit5.DropDownRows = 5;
                repositoryItemLookUpEdit5.NullText = string.Empty;
                repositoryItemLookUpEdit5.KeyUp += new KeyEventHandler(radio_KeyUp);
                repositoryItemLookUpEdit5.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(radio_CloseUp);
                repositoryItemLookUpEdit5.DataSource = RISBaseData.Ris_Radiologist();
                repositoryItemLookUpEdit5.BestFit();
                repositoryItemLookUpEdit5.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                view1.Columns["ASSIGNED_TO"].ColumnEdit = repositoryItemLookUpEdit5;
                view1.Columns["ASSIGNED_TO"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit6 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit6.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit6.ImmediatePopup = true;
                repositoryItemLookUpEdit6.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit6.AutoHeight = false;
                repositoryItemLookUpEdit6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLINIC_TYPE_TEXT", "Clinic Type", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit6.DisplayMember = "CLINIC_TYPE_TEXT";
                repositoryItemLookUpEdit6.ValueMember = "CLINIC_TYPE_ID";
                repositoryItemLookUpEdit6.DropDownRows = 5;
                repositoryItemLookUpEdit6.NullText = string.Empty;
                repositoryItemLookUpEdit6.KeyUp += new KeyEventHandler(clinic_KeyUp);
                repositoryItemLookUpEdit6.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(clinic_CloseUp);
                repositoryItemLookUpEdit6.DataSource = RISBaseData.RIS_ClinicType();
                repositoryItemLookUpEdit6.BestFit();
                repositoryItemLookUpEdit6.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                view1.Columns["CLINIC_TYPE"].ColumnEdit = repositoryItemLookUpEdit6;
                view1.Columns["CLINIC_TYPE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                RepositoryItemLookUpEdit rleBPView = new RepositoryItemLookUpEdit();
                rleBPView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                rleBPView.ImmediatePopup = true;
                rleBPView.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                rleBPView.AutoHeight = false;
                rleBPView.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BPVIEW_NAME", "Sides", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                rleBPView.DisplayMember = "BPVIEW_NAME";
                rleBPView.ValueMember = "BPVIEW_ID";
                rleBPView.DropDownRows = 5;
                rleBPView.DataSource = dtBP_View;
                rleBPView.NullText = string.Empty;
                rleBPView.KeyUp += new KeyEventHandler(BPView_KeyUp);
                rleBPView.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(BPView_CloseUp);
                //rleBPView.MouseDown += new MouseEventHandler(rleBPView_MouseDown);
                rleBPView.BestFit();
                rleBPView.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                view1.Columns["BPVIEW_ID"].ColumnEdit = rleBPView;
                view1.Columns["BPVIEW_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gridBestFitColumn();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getCovid19Icon(string Hn)
        {
            try
            {
                string _url = System.Configuration.ConfigurationSettings.AppSettings["RamaCare"] + Hn;
                Uri ur = new Uri(_url);
                webBrowser1.Url = ur;
            }
            catch (Exception ex)
            {

            }
        }

        private void rleBPView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
            if (view1.FocusedRowHandle >= 0)
            {
                try
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    ProcessGetRISBpviewMapping bpMap = new ProcessGetRISBpviewMapping();
                    bpMap.RIS_BPVIEWMAPPING.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                    bpMap.Invoke();
                    DataSet dsBPMapping = bpMap.ResultSet;

                    DevExpress.XtraEditors.LookUpEdit rleBPView = (DevExpress.XtraEditors.LookUpEdit)sender;
                    rleBPView.Properties.DisplayMember = "BPVIEW_NAME";
                    rleBPView.Properties.ValueMember = "BPVIEW_ID";
                    rleBPView.Properties.DropDownRows = 5;
                    rleBPView.Properties.DataSource = dsBPMapping.Tables[0].Rows.Count > 0 ? dsBPMapping.Tables[0] : dtBP_View;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void spe_ValueChanged(object sender, EventArgs e)
        {
            SpinEdit spe = new SpinEdit();
            spe = (SpinEdit)sender;
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            int sp = Convert.ToInt32(spe.Value.ToString());
            if (sp > 0)
            {
                dr["QTY"] = sp;
                dr.AcceptChanges();
                calTotal();
            }
            else
            {
                dr["QTY"] = 0;
                dr.AcceptChanges();
                calTotal();
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            if (dtt.Rows.Count > 0)
            {
                if (dv.Count == 1)
                {
                    if (dv[0][24].ToString() == "N")
                    {
                        if (dv[0][6].ToString() == string.Empty)
                        {
                            treeRadio.Nodes.Clear();
                            treeRadio.Nodes.Add("No Radiologist");
                        }
                    }
                }
                else
                {
                    DataRow dr = null;
                    dr = dtt.Rows[view1.FocusedRowHandle];
                    if (dr["EXAM_ID"].ToString().Trim() == string.Empty && dr["MODALITY_ID"].ToString().Trim() == string.Empty)
                        return;
                    string s = msg.ShowAlert("UID1025", env.CurrentLanguageID);

                    if (s == "2")
                    {
                        if (mode == "Edit")
                        {
                            if (dr["STATUS"].ToString() == "P" || dr["STATUS"].ToString() == "F" || dr["STATUS"].ToString() == "D")
                            {
                                msg.ShowAlert("UID4026", new GBLEnvVariable().CurrentLanguageID);
                                return;
                            }
                            DataRow drAdd = dttUpdate.NewRow();
                            for (int i = 0; i < dttUpdate.Columns.Count; i++)
                                drAdd[i] = dr[i];
                            drAdd["IS_DELETED"] = "Y";

                            dttUpdate.Rows.Add(drAdd);
                            dttUpdate.AcceptChanges();
                        }
                        dtt.Rows[view1.FocusedRowHandle].Delete();
                        dtt.AcceptChanges();
                        dv = new DataView(dtt);
                        grdData.DataSource = dv;
                        if (dtt.Rows.Count == 1)
                        {
                            if (dtt.Rows[0]["MODALITY_ID"].ToString().Trim() == string.Empty)
                            {
                                treeRadio.Nodes.Clear();
                                treeRadio.Nodes.Add("No Radiologist");
                            }
                        }
                    }
                }
                calTotal();
                gridBestFitColumn();
            }
        }
        private void view1_ShownEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view != null)
            {
                if (view.FocusedColumn.FieldName == "MODALITY_ID" && view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    if (dr["EXAM_ID"].ToString().Trim() != string.Empty)
                    {
                        string s = modalityFilter(dr["EXAM_ID"].ToString());
                        if (s != string.Empty)
                        {
                            DevExpress.XtraEditors.LookUpEdit edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;
                            DataTable table = RISBaseData.Ris_Modality();
                            DataView clone = new DataView(table);
                            clone.RowFilter = "[MODALITY_ID] in (" + s + ")";
                            edit.Properties.DataSource = new BindingSource(clone, "");
                        }
                    }
                }
            }
        }

        private void clinic_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        private void radio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                view1.FocusedColumn = view1.VisibleColumns[1];
                view1.MoveNext();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                dr["ASSIGNED_TO"] = DBNull.Value;
                view1.FocusedColumn = view1.VisibleColumns[1];
                view1.MoveNext();
            }
        }
        private void modality_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        private void priority_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 2];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        private void examName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        private void examCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        private void BPView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 3];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }

        private void clinic_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                try
                {
                    if (dr["IS_LOCK"].ToString() == "Y")
                    {
                        msg.ShowAlert("UID1202", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
                catch { }

                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateClinic(e.Value.ToString());

                    if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    {
                        view1.FocusedRowHandle = row;
                        view1.FocusedColumn = view1.VisibleColumns[7];
                    }
                    else
                    {
                        view1.FocusedColumn = view1.VisibleColumns[0];
                        view1.MoveNext();
                    }
                }
            }
        }
        private void radio_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                try
                {
                    if (dr["IS_LOCK"].ToString() == "Y")
                    {
                        msg.ShowAlert("UID1202", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
                catch { }
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateRadio(e.Value.ToString());

                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();

                }
            }
        }
        private void modality_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                try
                {
                    if (dr["IS_LOCK"].ToString() == "Y")
                    {
                        msg.ShowAlert("UID1202", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
                catch { }
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateModality(e.Value.ToString());

                    if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    {
                        view1.FocusedRowHandle = row;
                        view1.FocusedColumn = view1.VisibleColumns[8];
                    }
                    else
                    {
                        view1.FocusedColumn = view1.VisibleColumns[0];
                        view1.MoveNext();
                    }
                }
            }
        }
        private void priority_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                try
                {
                    if (dr["IS_LOCK"].ToString() == "Y")
                    {
                        msg.ShowAlert("UID1202", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
                catch { }
                if (!checkModifiedGridDetail(dr))
                {
                    e.AcceptValue = false;
                    return;
                }
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updatePriority(e.Value.ToString());
                    if (flag)
                    {
                        if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                        {
                            view1.FocusedRowHandle = row;
                            view1.FocusedColumn = view1.VisibleColumns[4];
                        }
                        else
                        {
                            view1.FocusedColumn = view1.VisibleColumns[0];
                            view1.MoveNext();
                        }
                    }
                }
            }
        }
        private void examName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                try
                {
                    if (dr["IS_LOCK"].ToString() == "Y")
                    {
                        msg.ShowAlert("UID1202", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
                catch { }
                if (!checkModifiedGridDetail(dr))
                {
                    e.AcceptValue = false;
                    return;
                }
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updateExamName(e.Value.ToString());
                    if (flag)
                    {
                        if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                        {
                            view1.FocusedRowHandle = row;
                            view1.FocusedColumn = view1.VisibleColumns[2];
                        }
                        else
                        {
                            view1.FocusedColumn = view1.VisibleColumns[0];
                            view1.MoveNext();
                        }
                    }
                    else
                    {
                        msg.ShowAlert("UID1014", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
            }
        }
        private void examCode_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                try
                {
                    if (dr["IS_LOCK"].ToString() == "Y")
                    {
                        msg.ShowAlert("UID1202", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
                catch { }
                if (!checkModifiedGridDetail(dr))
                {
                    e.AcceptValue = false;
                    return;
                }
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updateExamUID(e.Value.ToString());
                    if (flag)
                    {
                        if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                        {
                            view1.FocusedRowHandle = row;
                            view1.FocusedColumn = view1.VisibleColumns[2];
                        }
                        else
                        {
                            view1.FocusedColumn = view1.VisibleColumns[0];
                            view1.MoveNext();
                        }
                    }
                    else
                    {
                        msg.ShowAlert("UID1014", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
            }
        }
        private void BPView_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                try
                {
                    if (dr["IS_LOCK"].ToString() == "Y")
                    {
                        msg.ShowAlert("UID1202", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
                catch { }
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateBPView(e.Value.ToString());

                    if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    {
                        view1.FocusedRowHandle = row;
                        view1.FocusedColumn = view1.VisibleColumns[6];
                    }
                    else
                    {
                        view1.FocusedColumn = view1.VisibleColumns[0];
                        view1.MoveNext();
                    }
                }

            }
        }

        private string modalityFilter(string ID)
        {
            string strReturn = string.Empty;
            DataView dv = new DataView(RISBaseData.Ris_ModalityExam());
            dv.RowFilter = "EXAM_ID= " + ID;
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                    strReturn += dv[i][1].ToString() + ",";
                strReturn = strReturn.Remove(strReturn.LastIndexOf(','));
            }
            return strReturn;
        }
        private int modalityDefault(string ID)
        {
            int intReturn = 0;
            DataView dv = new DataView(RISBaseData.Ris_ModalityExam());
            dv.RowFilter = " IS_DEFAULT_MODALITY ='Y' and EXAM_ID=" + ID;
            if (dv.Count > 0)
                intReturn = (int)dv[0][1];
            return intReturn;
        }
        private void updateClinic(string strSearch)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dtClinic.Rows.Count; i++)
                if (dtClinic.Rows[i]["CLINIC_TYPE_ID"].ToString() == strSearch)
                    break;
            if (i < dtClinic.Rows.Count)
            {
                DataRow dr = dtClinic.Rows[i];
                dtt.Rows[row]["CLINIC_TYPE"] = dr["CLINIC_TYPE_ID"];
                thisOrder.IsRowDefalutClinic = Convert.ToInt32(strSearch);

                if (dtt.Rows[row]["COMMENTS"].ToString().IndexOf("</F>") <= 0)
                {
                    try
                    {
                        DataRow[] drExam = dtExam.Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
                        switch (dr["CLINIC_TYPE_UID"].ToString())
                        {
                            case "Normal":
                                dtt.Rows[row]["RATE"] = drExam[0]["RATE"];
                                break;
                            case "Special":
                                dtt.Rows[row]["RATE"] = drExam[0]["SPECIAL_RATE"];
                                break;
                            case "VIP":
                                dtt.Rows[row]["RATE"] = drExam[0]["VIP_RATE"];
                                break;
                            default:
                                break;
                        }
                        if (chkNonResident.Checked)
                        {
                            switch (dr["CLINIC_TYPE_UID"].ToString())
                            {
                                case "Normal":
                                    dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_RATE"];
                                    break;
                                case "Special":
                                    dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_SPCIAL_RATE"];
                                    break;
                                case "VIP":
                                    dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_VIP_RATE"];
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch { }

                }

                if (dtt.Rows[dtt.Rows.Count - 1]["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    dtt.Rows[dtt.Rows.Count - 1]["CLINIC_TYPE"] = dr["CLINIC_TYPE_ID"];
                }
                calTotal();
                view1.RefreshData();
                gridBestFitColumn();
            }
        }
        private void updateModality(string strSearch)
        {
            DataTable dtModality = RISBaseData.Ris_Modality();
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dtModality.Rows.Count; i++)
                if (dtModality.Rows[i]["MODALITY_ID"].ToString() == strSearch)
                    break;
            if (i < dtModality.Rows.Count)
            {
                DataRow dr = dtModality.Rows[i];
                dtt.Rows[row]["MODALITY_ID"] = dr["MODALITY_ID"];
                view1.RefreshData();
                gridBestFitColumn();
            }
        }
        private void updateRadio(string strSearch)
        {
            DataTable dtRadio = RISBaseData.Ris_Radiologist();
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dtRadio.Rows.Count; i++)
                if (dtRadio.Rows[i]["EMP_ID"].ToString() == strSearch)
                    break;
            if (i < dtRadio.Rows.Count)
            {
                DataRow dr = dtRadio.Rows[i];
                dtt.Rows[row]["ASSIGNED_TO"] = dr["EMP_ID"];
                view1.RefreshData();
                gridBestFitColumn();
                setTreeRadioLogist((int)dr["EMP_ID"], dr["RadioName"].ToString());
            }
        }
        private bool updatePriority(string strSearch)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataRow dr = dv.Table.Rows[view1.FocusedRowHandle];
            if (strSearch == "S")
            {
                DataTable dttExam = dtExam.Copy();
                foreach (DataRow drExam in dttExam.Rows)
                {
                    if (drExam["EXAM_ID"].ToString().Trim() == dr["EXAM_ID"].ToString().Trim())
                    {
                        if (drExam["STAT_FLAG"].ToString().Trim() == "Y")
                        {
                            dr["PRIORITY"] = "S";
                            break;
                        }
                        else
                        {
                            msg.ShowAlert("UID1030", env.CurrentLanguageID);
                            dr["PRIORITY"] = "R";
                            view1.RefreshData();
                            gridBestFitColumn();
                            return false;
                        }
                    }
                }
            }
            else
                dr["PRIORITY"] = "R";
            view1.RefreshData();
            gridBestFitColumn();
            return true;
        }
        private bool updateExamName(string strSearch)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dtExam.Rows.Count; i++)
                if (dtExam.Rows[i]["EXAM_NAME"].ToString() == strSearch)
                    break;
            if (i < dtExam.Rows.Count)
            {
                DataRow dr = dtExam.Rows[i];
                if (thisOrder.CheckConfliction(dateDemo.DateTime, (int)dr["EXAM_ID"], dtt))
                    return false;
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_UID"] = dr["EXAM_UID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                dtt.Rows[row]["BPVIEW_ID"] = dtBP_View.Rows[0]["BPVIEW_ID"];
                dtt.Rows[row]["QTY"] = dtBP_View.Rows[0]["NO_OF_EXAM"];
                dtt.Rows[row]["MODALITY_ID"] = modalityDefault(dr["EXAM_ID"].ToString());
                if (dtt.Rows[row]["COMMENTS"].ToString().IndexOf("</F>") <= 0)
                {
                    DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + dtt.Rows[row]["CLINIC_TYPE"].ToString());
                    DataRow[] drExam = dtExam.Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
                    switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Normal":
                            dtt.Rows[row]["RATE"] = drExam[0]["RATE"];
                            break;
                        case "Special":
                            dtt.Rows[row]["RATE"] = drExam[0]["SPECIAL_RATE"];
                            break;
                        case "VIP":
                            dtt.Rows[row]["RATE"] = drExam[0]["VIP_RATE"];
                            break;
                        default:
                            break;
                    }
                    if (chkNonResident.Checked)
                    {
                        switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                        {
                            case "Normal":
                                dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_RATE"];
                                break;
                            case "Special":
                                dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_SPCIAL_RATE"];
                                break;
                            case "VIP":
                                dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_VIP_RATE"];
                                break;
                            default:
                                break;
                        }
                    }
                }

                calExamPanel(dtt, dr["EXAM_ID"].ToString(), dtt.Rows[row]["CLINIC_TYPE"].ToString(), dtExam, dtBP_View, dtClinic);
                view1.RefreshData();
                gridBestFitColumn();
                if (canAddRow())
                {
                    dr = dtt.NewRow();
                    dr["PRIORITY"] = "R";
                    dr["IS_DELETED"] = "N";
                    dr["EXAM_DT"] = DateTime.Today;
                    dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                    dtt.Rows.Add(dr);
                }
                calTotal();
                return true;
            }
            else
                return false;
        }
        private bool updateExamUID(string strSearch)
        {

            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dtExam.Rows.Count; i++)
                if (dtExam.Rows[i]["EXAM_UID"].ToString() == strSearch)
                    break;
            if (i < dtExam.Rows.Count)
            {
                DataRow dr = dtExam.Rows[i];
                if (dr["EXAM_ID"].ToString().Trim() != dtt.Rows[row]["EXAM_ID"].ToString())
                    if (thisOrder.CheckConfliction(dateDemo.DateTime, (int)dr["EXAM_ID"], dtt))
                        return false;
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_UID"] = dr["EXAM_UID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                dtt.Rows[row]["BPVIEW_ID"] = dtBP_View.Rows[0]["BPVIEW_ID"];
                dtt.Rows[row]["QTY"] = dtBP_View.Rows[0]["NO_OF_EXAM"];
                dtt.Rows[row]["MODALITY_ID"] = modalityDefault(dr["EXAM_ID"].ToString());
                if (dtt.Rows[row]["COMMENTS"].ToString().IndexOf("</F>") <= 0)
                {
                    DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + dtt.Rows[row]["CLINIC_TYPE"].ToString());
                    DataRow[] drExam = dtExam.Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
                    switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Normal":
                            dtt.Rows[row]["RATE"] = drExam[0]["RATE"];
                            break;
                        case "Special":
                            dtt.Rows[row]["RATE"] = drExam[0]["SPECIAL_RATE"];
                            break;
                        case "VIP":
                            dtt.Rows[row]["RATE"] = drExam[0]["VIP_RATE"];
                            break;
                        default:
                            break;
                    }
                    if (chkNonResident.Checked)
                    {
                        switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                        {
                            case "Normal":
                                dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_RATE"];
                                break;
                            case "Special":
                                dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_SPCIAL_RATE"];
                                break;
                            case "VIP":
                                dtt.Rows[row]["RATE"] = drExam[0]["FOREIGN_VIP_RATE"];
                                break;
                            default:
                                break;
                        }
                    }
                }
                calExamPanel(dtt, dr["EXAM_ID"].ToString(), dtt.Rows[row]["CLINIC_TYPE"].ToString(), dtExam, dtBP_View, dtClinic);
                view1.RefreshData();
                gridBestFitColumn();
                if (canAddRow())
                {
                    dr = dtt.NewRow();
                    dr["PRIORITY"] = "R";
                    dr["IS_DELETED"] = "N";
                    dr["EXAM_DT"] = DateTime.Today;
                    dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                    dtt.Rows.Add(dr);
                }
                calTotal();
                return true;
            }
            else
                return false;
        }
        private void updateBPView(string strSearch)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dtBP_View.Rows.Count; i++)
                if (dtBP_View.Rows[i]["BPVIEW_ID"].ToString() == strSearch)
                    break;
            if (i < dtBP_View.Rows.Count)
            {
                DataRow dr = dtBP_View.Rows[i];
                dtt.Rows[row]["BPVIEW_ID"] = dr["BPVIEW_ID"];
                dtt.Rows[row]["QTY"] = dr["NO_OF_EXAM"];
                //view1.Columns["QTY"].OptionsColumn.
                calTotal();
                view1.RefreshData();
                gridBestFitColumn();
                //setTreeRadioLogist((int)dr["EMP_ID"], dr["RadioName"].ToString());
                //dtt.AcceptChanges();
            }
        }

        private void updateRateByHISServiceBackup(DataRow datarowExam)
        {
            DataRow[] getBillingExamUID = dtExam.Select("EXAM_UID = '"+datarowExam["EXAM_UID"].ToString()+"'");
            string exam_uid = getBillingExamUID[0]["BILLING_CODE"].ToString();
            HIS_Patient proxy = new HIS_Patient();
            string _nonResident = chkNonResident.Checked ? "nonresident(v)" : "";
            DataSet dsCheckRate = proxy.GetEncounterDetailClinicTypePriceType(txtHN.Text.Trim(), exam_uid, DateTime.Now.ToString("dd/MM/yyyy"), _nonResident);
            insertLogsByHIS(dsCheckRate);
            int _ref_unit = txtOrderDepartment.Tag == null || txtOrderDepartment.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderDepartment.Tag);
            DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + datarowExam["CLINIC_TYPE"].ToString());
            DataRow[] drUnit = dttAutoUnit.Select("UNIT_ID=" + _ref_unit.ToString());

            DataView dv = dsCheckRate.Tables[0].DefaultView;
            dv.RowFilter = "sdloc_id='" + drUnit[0]["UNIT_UID"].ToString() + "'";
            if (dv.Count > 0)
            {

                dv.RowFilter = "clinictype='" + drClinic[0]["CLINIC_TYPE_ALIAS"].ToString() + "'";
                if (dv.Count == 0)
                {
                    //MessageBox.Show(datarowExam["EXAM_UID"].ToString() + " ไม่มีประกาศราคาใน clinic type นี้"); //_strAlert += " " +  + " clinictype= null;";
                }
                else
                {
                    datarowExam["RATE"] = dv[0]["amtprice"];

                    #region Add TemplateTable Billing
                    DataRow[] rowChkExam = dtTemplateBillingLog.Select("EXAM_ID=" + datarowExam["EXAM_ID"].ToString());
                    if (rowChkExam.Length > 0)
                        dtTemplateBillingLog.Rows.Remove(rowChkExam[0]);

                    DataRow rowAddTemp = dtTemplateBillingLog.NewRow();
                    rowAddTemp["EXAM_ID"] = datarowExam["EXAM_ID"];
                    rowAddTemp["object_id"] = dv[0]["object_id"];
                    rowAddTemp["enc_id"] = dv[0]["enc_id"];
                    rowAddTemp["enc_type"] = dv[0]["enc_type"];
                    rowAddTemp["mrn"] = dv[0]["mrn"];
                    rowAddTemp["mrn_type"] = dv[0]["mrn_type"];
                    rowAddTemp["sdloc_id"] = dv[0]["sdloc_id"];
                    rowAddTemp["period"] = dv[0]["period"];
                    rowAddTemp["attender"] = dv[0]["attender"];
                    rowAddTemp["enterer"] = dv[0]["enterer"];
                    rowAddTemp["insurance"] = dv[0]["insurance"];
                    rowAddTemp["pt_acc_id"] = dv[0]["pt_acc_id"];
                    rowAddTemp["effectivestartdate"] = convertHISDate(dv[0]["effectivestartdate"].ToString());
                    rowAddTemp["effectiveenddate"] = convertHISDate(dv[0]["effectiveenddate"].ToString()) ;
                    rowAddTemp["statuscode"] = dv[0]["statuscode"];
                    rowAddTemp["productcode"] = dv[0]["productcode"];
                    rowAddTemp["clinictype"] = dv[0]["clinictype"];
                    rowAddTemp["pricetype"] = dv[0]["pricetype"];
                    rowAddTemp["amtprice"] = dv[0]["amtprice"];
                    dtTemplateBillingLog.Rows.Add(rowAddTemp);
                    dtTemplateBillingLog.AcceptChanges();
                    #endregion

                }
            }
            else
            {
                //MessageBox.Show(drUnit[0]["UNIT_UID"].ToString() + " ไม่มีการลงทะเบียนที่แผนกนี้");//_strAlert += "sdloc_id=0";
            }
        }
        private void insertLogsByHIS(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ProcessAddRISBillinglogWithHIS logs = new ProcessAddRISBillinglogWithHIS();
                logs.RIS_BILLINGLOG_WITH_HIS.object_id = row["object_id"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.enc_id = row["enc_id"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.enc_type = row["enc_type"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.mrn = row["mrn"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.mrn_type = row["mrn_type"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.sdloc_id = row["sdloc_id"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.period = row["period"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.attender = row["attender"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.enterer = row["enterer"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.insurance = row["insurance"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.pt_acc_id = row["pt_acc_id"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.effectivestartdate = convertHISDate(row["effectivestartdate"].ToString());
                logs.RIS_BILLINGLOG_WITH_HIS.effectiveenddate = convertHISDate(row["effectiveenddate"].ToString());
                logs.RIS_BILLINGLOG_WITH_HIS.statuscode = row["statuscode"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.productcode = row["productcode"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.clinictype = row["clinictype"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.pricetype = row["pricetype"].ToString();
                logs.RIS_BILLINGLOG_WITH_HIS.amtprice = Convert.ToDouble(row["amtprice"].ToString());
                logs.RIS_BILLINGLOG_WITH_HIS.CREATED_BY = env.UserID;
                logs.insertLogByHIS();
            }

        }
        private void insertBillingLog()
        {
            #region Insert BillingLogs
            foreach (DataRow rowBillingLog in dtTemplateBillingLog.Rows)
            {
                ProcessAddRISBillinglogWithHIS addBillinglog = new ProcessAddRISBillinglogWithHIS();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.amtprice = Convert.ToDouble(rowBillingLog["amtprice"].ToString());
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.attender = rowBillingLog["attender"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.clinictype = rowBillingLog["clinictype"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.CREATED_BY = env.UserID;
                if (!string.IsNullOrEmpty(rowBillingLog["effectiveenddate"].ToString()))
                    addBillinglog.RIS_BILLINGLOG_WITH_HIS.effectiveenddate = Convert.ToDateTime(rowBillingLog["effectiveenddate"].ToString());
                if (!string.IsNullOrEmpty(rowBillingLog["effectivestartdate"].ToString()))
                    addBillinglog.RIS_BILLINGLOG_WITH_HIS.effectivestartdate = Convert.ToDateTime(rowBillingLog["effectivestartdate"].ToString());
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.enc_id = rowBillingLog["enc_id"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.enc_type = rowBillingLog["enc_type"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.enterer = rowBillingLog["enterer"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.EXAM_ID = Convert.ToInt32(rowBillingLog["EXAM_ID"].ToString());
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.insurance = rowBillingLog["insurance"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.mrn = rowBillingLog["mrn"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.mrn_type = rowBillingLog["mrn_type"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.object_id = rowBillingLog["object_id"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.ORDER_ID = thisOrder.Item.ORDER_ID;
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.period = rowBillingLog["period"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.pricetype = rowBillingLog["pricetype"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.productcode = rowBillingLog["productcode"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.pt_acc_id = rowBillingLog["pt_acc_id"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.sdloc_id = rowBillingLog["sdloc_id"].ToString();
                addBillinglog.RIS_BILLINGLOG_WITH_HIS.statuscode = rowBillingLog["statuscode"].ToString();
                addBillinglog.Invoke();
            }
            #endregion

        }
        private DateTime convertHISDate(string dateHIS)
        {
            if (string.IsNullOrEmpty(dateHIS))
                return DateTime.MinValue;
            string[] arr1 = dateHIS.Split('/');
            string[] arr2 = arr1[2].Split(' ');
            string[] arr3 = arr2[1].Split(':');
            DateTime dateTime = new DateTime(Convert.ToInt32(arr2[0]), Convert.ToInt32(arr1[1]), Convert.ToInt32(arr1[0]), Convert.ToInt32(arr3[0]), Convert.ToInt32(arr3[1]), Convert.ToInt32(arr3[2]));

            return dateTime;
        }
        private bool checkClinicRateWithHISServiceBackup(DataRow datarowExam,string clinic_type_id)
        {
            bool chk = true;
            DataRow[] getBillingExamUID = dtExam.Select("EXAM_UID = '" + datarowExam["EXAM_UID"].ToString() + "'");
            string exam_uid = getBillingExamUID[0]["BILLING_CODE"].ToString();
            HIS_Patient proxy = new HIS_Patient();
            string _nonResident = chkNonResident.Checked ? "non-resident(v)" : "";
            DataSet dsCheckRate = proxy.GetEncounterDetailClinicTypePriceType(txtHN.Text.Trim(), exam_uid, DateTime.Now.ToString("dd/MM/yyyy"), _nonResident);

            int _ref_unit = txtOrderDepartment.Tag == null || txtOrderDepartment.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderDepartment.Tag);
            DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + clinic_type_id);
            DataRow[] drUnit = dttAutoUnit.Select("UNIT_ID=" + _ref_unit.ToString());

            DataView dv = dsCheckRate.Tables[0].DefaultView;
            dv.RowFilter = "sdloc_id='" + drUnit[0]["UNIT_UID"].ToString() + "'";
            if (dv.Count > 0)
            {
                dv.RowFilter = "clinictype='" + drClinic[0]["CLINIC_TYPE_ALIAS"].ToString() + "'";
                if (dv.Count == 0)
                {
                    MessageBox.Show(datarowExam["EXAM_UID"].ToString() + " ไม่มีประกาศราคาใน \""+drClinic[0]["CLINIC_TYPE_TEXT"].ToString()+"\" นี้"); //_strAlert += " " +  + " clinictype= null;";
                    chk = false;
                }
            }
            return chk;
        }
        private bool checkModifiedGridDetail(DataRow dr)
        {
            bool flag = true;
            if (mode != "Last")
            {
                if (env.SUPPORT_USER == "N")
                {
                    if (dr["STATUS"].ToString() == "P" || dr["STATUS"].ToString() == "F" || dr["STATUS"].ToString() == "D")
                    {
                        msg.ShowAlert("UID4026", new GBLEnvVariable().CurrentLanguageID);
                        flag = false;
                        return flag;
                    }
                    if (!string.IsNullOrEmpty(dr["ACCESSION_NO"].ToString()))
                    {
                        //msg.ShowAlert("UID4044", new GBLEnvVariable().CurrentLanguageID);
                        //flag = false;
                        //return flag;

                        //Check before sent billing

                    }
                }
            }
            return flag;
        }
        #endregion

        #region ปุ่ม Lookup
        private void btnInsurance_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_Insurance);
            lv.AddColumn("INSURANCE_TYPE_ID", "Insurance ID", false, true);
            lv.AddColumn("INSURANCE_TYPE_UID", "Insurance Code", true, true);
            lv.AddColumn("INSURANCE_TYPE_DESC", "Description", true, true);
            lv.Text = "Insurance Search";

            lv.Data = lvS.SelectOrderFrom("INSURANCE").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Insurance(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            if (txtOrderDepartment.Tag != null && txtOrderDepartment.Tag.ToString() != string.Empty)
            {
                //setTextBoxAutoComplete((Convert.ToInt32(txtOrderDepartment.Tag)));
                setTextBoxAutoComplete();
            }
            else
            {
                setTextBoxAutoComplete();
            }
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInsurace.Tag = retValue[0];
            txtInsurace.Text = retValue[2];
            txtTempInsurance.Text = txtInsurace.Text;
            //myGlobalBaseData.Demographic.InsuranceID = Convert.ToInt32(txtInsurace.Tag);
            //myGlobalBaseData.Demographic.Insurance_Type = txtInsurace.Text;
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_UnitCode);
            lv.AddColumn("UNIT_ID", "Department ID", false, true);
            lv.AddColumn("UNIT_UID", "Department Code", true, true);
            lv.AddColumn("UNIT_NAME", "Department Name", true, true);
            lv.AddColumn("PHONE_NO", "Telephone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.SelectOrderFrom("UNIT").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }
        private void find_UnitCode(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string s = txtOrderDepartment.Tag == null ? string.Empty : txtOrderDepartment.Tag.ToString();
            if (retValue[0] != s)
            {

                txtOrderDepartment.Tag = retValue[0];
                //txtOrderDepartment.Text = retValue[0];
                txtOrderDepartment.Text = retValue[1] + ":" + retValue[2] + "(" + retValue[3] + ")";
                txtOrderDept.Text = retValue[3];
                //txtOrderPhysician.Text = string.Empty;
                //txtOrderPhysician.Tag = null;
                //setTextBoxAutoComplete((Convert.ToInt32(txtOrderDepartment.Tag)));
                setTextBoxAutoComplete();

            }
            LoadInsuranceDetail();
        }

        private void btnPhysician_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_Physician);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.SelectOrderFrom("Physician").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Physician(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            //setTextBoxAutoComplete((Convert.ToInt32(txtOrderDepartment.Tag)));
            setTextBoxAutoComplete();
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtOrderPhysician.Tag = retValue[0];
            //txtOrderDepartment.Text = retValue[0];
            txtOrderPhysician.Text = retValue[1] + ":" + retValue[2];
            view1.Focus();
            if (view1.RowCount > 0)
            {
                view1.FocusedRowHandle = view1.RowCount - 1;
                DevExpress.XtraGrid.Columns.GridColumn focusColumn = view1.Columns["EXAM_UID"];
                view1.FocusedColumn = focusColumn;
            }

        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (mode == "Edit")
            {
                if (dateDemo.Text.Trim().Length == 0)
                {
                    dateDemo.Focus();
                    return;
                }
            }

            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupHN lv = new Envision.NET.Forms.Dialog.LookupHN();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(lv_ValueUpdated);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("REG_ID", "ID", false, true);
            lv.AddColumn("FNAME", "First name", true, true);
            lv.AddColumn("LNAME", "Last Name", true, true);
            lv.Text = "HN Search";

            lv.Data = lvS.SelectOrderFrom("HN").Tables[0];
            //lv.Size = new Size(600, 400);
            lv.ShowBox();
            txtOrderDepartment.Focus();
        }
        private void lv_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string hn = retValue[0].ToString();

            thisOrder = new Order(hn, true);
            if (thisOrder.Demographic.HasHN)
            {
                fillDemographicmodeNew();
                txtHN.Enabled = false; txtHN.BackColor = txtNextAppointment.BackColor;
            }
            else
            {
                panelMain.Enabled = false;
                string hnTmp = txtHN.Text;
                thisOrder = new Order();
                clearContexInControl();
                setEnableDisableControl(false);
                setBackColor(defaultBackColor);
                //setForeColor(defaultForeColor);
                setInitalVariable();
                setGridData();
                setGridOrder();
                txtHN.Enabled = true;
                txtHN.BackColor = Color.White;
                btnLookup.Enabled = true;
                msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
            }

            LoadInsuranceDetail();
        }

        private void btnLookUpNo_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupEditOrder lv = new Envision.NET.Forms.Dialog.LookupEditOrder();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(lvNo_ValueUpdated);
            lv.AddColumn("ORDER_ID", "Order No", true, true);
            lv.AddColumn("XRAY_NO", "Xray No", true, true);
            lv.AddColumn("REG_ID", "ID", false, true);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("ACCESSION_NO", "Accession No", true, true);
            lv.AddColumn("Exam", "Exam", true, true);
            lv.AddColumn("ORDER_DT", "Date", true, true);
            lv.Text = "Xray Search";

            lv.Data = lvS.SelectOrderFrom("ORDER").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
            txtOrderPhysician.Focus();
        }
        private void lvNo_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            #region Check IS_Lock
            if (SL_NO > 0)
            {
                updateIsLock();
            }
            #endregion

            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            int orderID = Convert.ToInt32(retValue[0]);
            thisOrder = new Order(orderID);

            #region Check Status : Draft, Prelim, Finalize
            bool is_found = false;
            if (is_found)
            {
                //msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                msg.ShowAlert("UID4026", new GBLEnvVariable().CurrentLanguageID);
                panelMain.Enabled = false;
                string hnTmp = txtHN.Text;
                thisOrder = new Order();
                clearContexInControl();
                setEnableDisableControl(false);
                setBackColor(defaultBackColor);
                setForeColor(defaultForeColor);
                setInitalVariable();

                setGridData();
                setGridOrder();
                txtOrderNo.Enabled = true;
                txtOrderNo.BackColor = Color.White;
                btnLookUpNo.Enabled = true;
                txtOrderNo.Focus();
                return;
            }
            #endregion

            if (thisOrder.Demographic.HasHN)
            {
                getTrauma();
                fillDemographicmodeEdit();
                txtOrderNo.Tag = orderID;
                txtOrderNo.Text = orderID.ToString();
                btnPatientAllergy.Enabled = true;
            }
            else
            {
                msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                panelMain.Enabled = false;
                string hnTmp = txtHN.Text;
                thisOrder = new Order();
                clearContexInControl();
                setEnableDisableControl(false);
                setBackColor(defaultBackColor);
                setForeColor(defaultForeColor);
                setInitalVariable();

                setGridData();
                setGridOrder();
                txtOrderNo.Enabled = true;
                txtOrderNo.BackColor = Color.White;
                btnLookUpNo.Enabled = true;
                txtOrderNo.Focus();
                return;
            }
        }

        private void btnPatienType_Click(object sender, EventArgs e)
        {

            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(patientType_ValueUpdated);
            lv.AddColumn("STATUS_UID", "Status Name", true, true);
            lv.AddColumn("STATUS_ID", "Status ID", false, true);
            lv.AddColumn("STATUS_TEXT", "Description", true, true);
            lv.Text = "Search Status Name";

            lv.Data = lvS.SelectOrderFrom("Patient").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void patientType_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtPatientType.Tag = retValue[1];
            //txtPatientType.Text = retValue[0];
            txtPatientType.Text = retValue[2];
        }

        private void btnPrepation_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(btnPrepation_Clicks);
            lv.AddColumn("PREPARATION_ID", "ID", true, true);
            lv.AddColumn("PREPARATION_UID", "ID", false, true);
            lv.AddColumn("PREPARATION_DESC", "Prepation", true, true);
            lv.Text = "Prepation Search";

            lv.Data = lvS.ScheduleNotParameter("Prepation").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnPrepation_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtPreparation.Tag = Convert.ToInt32(retValue[0]);
            txtPreparation.Text = retValue[2];
        }

        private void btnLabData_Click(object sender, EventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();

                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_lab_data(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                        lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Lab_Clicks);
                        lv.Text = "Lab Detail List";

                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.PreviewFieldName = "report";
                        lv.SortFieldName = "lab_date";
                        lv.ShowDescription = true;
                        lv.ShowBox();
                    }
                }
            }
            catch (Exception ex)
            {
                msg.ShowAlert("UID4022", new GBLEnvVariable().CurrentLanguageID);
            }
        }
        private void Lab_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
        }

        private void btnPatientAllergy_Click(object sender, EventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_Adr(txtHN.Text);

                    Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                    lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Adr_Clicks);
                    lv.Text = "Alergy Detail List";
                    lv.Data = dsHIS.Tables[0];

                    Size ss = new Size(800, 600);
                    lv.Size = ss;
                    lv.ShowBox();
                }
            }
            catch { }
        }
        private void Adr_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {

        }
        private void btnNextAppointment_Click(object sender, EventArgs e)
        {
            if (txtHN.Text.Trim().Length == 0) return;

            frmNextAppointment frmNextAppt = new frmNextAppointment(txtHN.Text);
            if (frmNextAppt.ShowDialog() == DialogResult.OK)
            {
                DataRow rowNewAppoint = frmNextAppt.returnNextAppointRow;
                DataRow[] rowRefUnit = dtRefUnit.Select("UNIT_UID='"+rowNewAppoint["appt_doc_dept_code"].ToString()+"'");
                if (rowRefUnit.Length > 0)
                {
                    string s = txtOrderDepartment.Tag == null ? string.Empty : txtOrderDepartment.Tag.ToString();
                    if (rowRefUnit[0]["UNIT_ID"].ToString() != s)
                    {
                        txtOrderDepartment.Tag = rowRefUnit[0]["UNIT_ID"].ToString();
                        txtOrderDepartment.Text = rowRefUnit[0]["UNIT_UID"].ToString() + ":" + rowRefUnit[0]["UNIT_NAME"].ToString() + "(" + rowRefUnit[0]["PHONE_NO"].ToString() + ")";
                        txtOrderDept.Text = rowRefUnit[0]["PHONE_NO"].ToString();

                        
                    }
                }
               
                DataRow[] rowRefDoc = dtRefDoc.Select("EMP_UID='" + rowNewAppoint["appt_doc_code"].ToString() + "'");
                if (rowRefDoc.Length > 0)
                {
                    txtOrderPhysician.Tag = rowRefDoc[0]["EMP_ID"].ToString();
                    txtOrderPhysician.Text = rowRefDoc[0]["EMP_UID"].ToString() + ":" + rowRefDoc[0]["RadioName"].ToString();
                }

                string strAppDate = rowNewAppoint["appt_date"].ToString();
                if (string.IsNullOrEmpty(strAppDate))
                {
                    DateTime date = Convert.ToDateTime(strAppDate);
                    txtNextAppointment.Text = date.ToString("dd/MM/yyyy");
                }
            }
        }
        #endregion

        #region TextBox Button ComboBox Behavior
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 47) e.Handled = true;
            if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 13)
            {
                if (txtHN.Text.Trim().Length > 0)
                {
                    if (txtHN.Text.Trim().Length == 0) return;
                    EnableForJohndoe(true);
                    thisOrder = new Order(txtHN.Text.Trim());
                    if (!thisOrder.Demographic.LinkDown)
                    {
                        #region สามารถเชื่อมต่อเข้ากับระบบ HIS ได้
                        if (thisOrder.Demographic.DataFromHIS)
                        {
                            updateRegistrationAllergies();
                            thisOrder.Demographic.Reg_UID = txtHN.Text;
                            fillDemographicmodeNew();
                        }
                        else
                        {
                            msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                            panelMain.Enabled = false;
                            string hnTmp = txtHN.Text;
                            thisOrder = new Order();
                            clearContexInControl();
                            setEnableDisableControl(false);
                            setBackColor(defaultBackColor);
                            setForeColor(defaultForeColor);
                            setInitalVariable();
                            setGridData();
                            setGridOrder();
                            txtHN.Enabled = true;
                            txtHN.BackColor = Color.White;
                            btnLookup.Enabled = true;
                            txtHN.Focus();
                        }
                        return;
                        #endregion
                    }
                    //กรณี LinkDown ตรวจสอบข้อมูลในตาราง HIS_REGISTRATION ว่ามีหรือไม่
                    thisOrder = new Order(txtHN.Text, true);
                    if (thisOrder.Demographic.HasHN)
                    {
                        #region ดึงข้อมูลจาก Local ในตาราง HIS_REGISTRATION
                        string s = msg.ShowAlert("UID1016", env.CurrentLanguageID);
                        if (s == "1")
                        {
                            //กรณี wait
                            Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders();
                            frm.Text = frm.Text;
                            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                            //page.Selected = true;
                        }
                        else if (s == "2")
                        {
                            //update ข้อมูลใน his
                            fillDemographicmodeNew();

                            txtHN.Enabled = false;
                            txtHN.BackColor = defaultBackColor;
                            btnLookup.Enabled = false;

                            txtThaiName.Enabled = true;
                            txtThaiName.BackColor = Color.White;
                            txtLastThaiName.Enabled = true;
                            txtLastThaiName.BackColor = Color.White;
                            txtDOB.Enabled = true;
                            txtDOB.BackColor = Color.White;
                            cboGender.Enabled = true;
                            cboGender.BackColor = Color.White;
                        }
                        else if (s == "3")
                        {
                            //ใช้ข้อมูล
                            fillDemographicmodeNew();
                        }
                        #endregion
                    }
                    else
                    {
                        #region ทำ Order แบบ Manual
                        string s = msg.ShowAlert("UID1015", env.CurrentLanguageID);
                        if (s == "1")
                        {
                            Envision.NET.Forms.Orders.frmOrders frm = new Envision.NET.Forms.Orders.frmOrders();
                            frm.Text = frm.Text;
                            // UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                            //page.Selected = true;
                        }
                        else
                        {
                            panelMain.Enabled = true;
                            gridControl3.Enabled = false;
                            grdData.Enabled = true;

                            thisOrder.Demographic.Reg_UID = txtHN.Text;
                            thisOrder.Demographic.DataFromHIS = false;
                            thisOrder.Demographic.DataFromLocal = false;
                            thisOrder.Demographic.DataFromManual = true;

                            txtPatientType.Enabled = true;
                            txtPatientType.BackColor = Color.White;
                            btnPatienType.Enabled = true;

                            txtHN.Enabled = false;
                            txtHN.BackColor = defaultBackColor;
                            btnLookup.Enabled = false;

                            //txtInsurace.Enabled = true;
                            //txtInsurace.BackColor = Color.White;
                            //btnInsurance.Enabled = true;

                            txtOrderDepartment.Enabled = true;
                            txtOrderDepartment.BackColor = Color.White;
                            btnDepartment.Enabled = true;

                            txtThaiName.Enabled = true;
                            txtThaiName.BackColor = Color.White;

                            txtLastThaiName.Enabled = true;
                            txtLastThaiName.BackColor = Color.White;

                            txtOrderPhysician.Enabled = true;
                            txtOrderPhysician.BackColor = Color.White;
                            btnPhysician.Enabled = true;

                            txtEngName.Enabled = true;
                            txtEngName.BackColor = Color.White;

                            txtLastEngName.Enabled = true;
                            txtLastEngName.BackColor = Color.White;

                            txtDOB.Enabled = true;
                            txtDOB.BackColor = Color.White;

                            cboGender.Enabled = true;
                            cboGender.BackColor = Color.White;

                            txtTelephone.Enabled = true;
                            txtTelephone.BackColor = Color.White;

                            btnNextAppointment.Enabled = true;

                            EnableForJohndoe(false);

                            setTextBoxAutoComplete();
                            txtInsurace.Focus();
                        }
                        #endregion
                    }

                    if (txtEngName.Text.Trim() == "")
                        txtEngName.Text = TransToEnglish.Trans(txtThaiName.Text);
                    if (txtLastEngName.Text.Trim() == "")
                        txtLastEngName.Text = TransToEnglish.Trans(txtLastThaiName.Text);
                }
            }//end else
        }
        private void EnableForJohndoe(bool flag)
        {
            txtDOB.Visible = !flag;
            txtAGE.Enabled = flag;
            txtAGE.Visible = flag;
        }
        private void txtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int result;
            if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar != 13 && !int.TryParse(e.KeyChar.ToString(), out result))
                e.Handled = true;
            else if ((int)e.KeyChar == 13)
            {
                if (SL_NO > 0)
                {
                    updateIsLock();
                }

                if (txtOrderNo.Text.Trim().Length > 0)
                {
                    int id;
                    if (int.TryParse(txtOrderNo.Text.Trim(), out id))
                    {

                        ProcessGetRISOrder processGet = new ProcessGetRISOrder(id, 0);
                        DataTable dtt = new DataTable();
                        processGet.RIS_ORDER.REG_ID = 0;
                        processGet.RIS_ORDER.ORDER_ID = id;
                        //processGet.RIS_ORDER.XRAY_NO = txtOrderNo.Text.Trim();
                        //dtt = processGet.GetXrayNumber();
                        processGet.Invoke();

                        dtt = processGet.Result.Tables[0].Copy();
                        if (dtt != null)
                            if (dtt.Rows.Count > 0)
                            {

                                int orderID = Convert.ToInt32(dtt.Rows[0]["ORDER_ID"].ToString());
                                txtOrderNo.Tag = orderID;
                                if (Order.HasOrder(orderID))
                                {
                                    thisOrder = new Order(orderID);
                                    fillDemographicmodeEdit();
                                    txtOrderNo.Text = orderID.ToString();
                                    txtOrderNo.Tag = orderID;
                                    return;
                                }
                            }
                    }
                    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                    panelMain.Enabled = false;
                    string hnTmp = txtHN.Text;
                    thisOrder = new Order();
                    clearContexInControl();
                    setEnableDisableControl(false);
                    setBackColor(defaultBackColor);
                    setForeColor(defaultForeColor);
                    setInitalVariable();

                    setGridData();
                    setGridOrder();
                    txtOrderNo.Enabled = true;
                    txtOrderNo.BackColor = Color.White;
                    btnLookUpNo.Enabled = true;
                    txtOrderNo.Focus();
                }

            }
        }
        private void btnLookUpNo_Validating(object sender, CancelEventArgs e)
        {
            //txtOrderDepartment.Focus();
            //return;
        }

        private void txtInsurace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                //if (txtInsurace.Text.Trim().Length > 0)
                //    txtEngName.Focus();
                //else
                SendKeys.Send("{Tab}");


            }

        }
        private void txtInsurace_Validating(object sender, CancelEventArgs e)
        {
            if (txtInsurace.Text.Trim() == string.Empty)
                txtInsurace.Tag = null;
            else
            {
                bool flag = true;
                DataTable dtt = RISBaseData.Ris_InsuranceType();
                DataRow d = null;
                foreach (DataRow dr in dtt.Rows)
                {
                    if (txtInsurace.Text.Trim().ToUpper() == dr["INSURANCE_TYPE_DESC"].ToString().Trim().ToUpper())
                    {
                        txtInsurace.Tag = dr["INSURANCE_TYPE_ID"].ToString();
                        txtInsurace.Text = dr["INSURANCE_TYPE_DESC"].ToString();
                        txtTempInsurance.Text = txtInsurace.Text;
                        flag = false;
                        d = dr;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1013", env.CurrentLanguageID);
                    txtInsurace.SelectAll();
                    txtInsurace.Focus();
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                }

            }
        }

        private void txtOrderDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    SendKeys.Send("{Tab}");
            if (e.KeyCode == Keys.Enter)
            {

                if (txtOrderDepartment.Text.Trim().Length > 0)
                    txtOrderPhysician.Focus();
                else
                    SendKeys.Send("{Tab}");
                LoadInsuranceDetail();
            }
        }
        private void txtOrderDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (txtOrderDepartment.Text.Trim() == string.Empty)
            {
                txtOrderDepartment.Tag = null;
                txtOrderDept.Text = string.Empty;
            }
            else
            {
                bool flag = true;
                DataTable dtt = dtRefUnit.Copy();// myGlobalBaseData.HIS_Department();
                DataRow d = null;

                foreach (DataRow dr in dtt.Rows)//UNIT_NAME
                {
                    if (txtOrderDepartment.Text.Trim().ToUpper() == dr["UNIT_UID"].ToString().Trim().ToUpper() + ":" + dr["UNIT_NAME"].ToString().Trim().ToUpper() + "(" + dr["PHONE_NO"].ToString() + ")")
                    {
                        txtOrderDepartment.Tag = dr["UNIT_ID"].ToString();
                        txtOrderDepartment.Text = dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString() + "(" + dr["PHONE_NO"].ToString() + ")";
                        txtOrderDept.Text = dr["PHONE_NO"].ToString();
                        flag = false;
                        d = dr;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1012", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    setTextBoxAutoComplete();
                    txtOrderPhysician.Focus();
                }
            }

            LoadInsuranceDetail();
        }
        private void txtOrderDepartment_Validated(object sender, EventArgs e)
        {
            LoadInsuranceDetail();
        }

        private void txtOrderPhysician_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                view1.Focus();
                if (view1.RowCount > 0)
                {
                    view1.FocusedRowHandle = view1.RowCount - 1;
                    DevExpress.XtraGrid.Columns.GridColumn focusColumn = view1.Columns["EXAM_UID"];
                    view1.FocusedColumn = focusColumn;
                }
            }
        }
        private void txtOrderPhysician_Validating(object sender, CancelEventArgs e)
        {
            if (txtOrderPhysician.Text.Trim() != string.Empty)
            {
                bool flag = true;
                DataTable dtt = dtRefDoc.Copy();// myGlobalBaseData.HIS_Doctor();
                DataRow d = null;
                foreach (DataRow dr in dtt.Rows)
                {
                    if (txtOrderPhysician.Text.Trim().ToUpper() == dr["EMP_UID"].ToString() + ":" + dr["RadioName"].ToString().Trim().ToUpper())
                    {
                        txtOrderPhysician.Tag = dr["EMP_ID"].ToString();
                        txtOrderPhysician.Text = dr["EMP_UID"].ToString() + ":" + dr["RadioName"].ToString();
                        flag = false;
                        d = dr;
                        break;
                    }
                }
                if (flag)
                {
                    txtOrderPhysician.Text = string.Empty;
                    txtOrderPhysician.Tag = null;
                    msg.ShowAlert("UID5000", env.CurrentLanguageID);
                    txtOrderPhysician.Focus();
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;

                }
            }
            else
            {
                txtOrderPhysician.Text = string.Empty;
                txtOrderPhysician.Tag = null;
            }
        }
        private void btnPhysician_Validating(object sender, CancelEventArgs e)
        {
            view1.Focus();
            if (view1.RowCount > 0)
            {
                view1.FocusedRowHandle = view1.RowCount - 1;
                DevExpress.XtraGrid.Columns.GridColumn focusColumn = view1.Columns["EXAM_UID"];
                view1.FocusedColumn = focusColumn;
            }
        }

        private void txtPatientType_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    SendKeys.Send("{Tab}");
            if (e.KeyCode == Keys.Enter)
            {

                if (txtPatientType.Text.Trim().Length > 0)
                    txtOrderDepartment.Focus();
                else
                    SendKeys.Send("{Tab}");
            }
        }
        private void txtPatientType_Validating(object sender, CancelEventArgs e)
        {
            if (txtPatientType.Text.Trim() == string.Empty)
                txtPatientType.Tag = null;
            else
            {
                bool flag = true;
                DataTable dtt = RISBaseData.RIS_PatStatus();// myGlobalBaseData.RIS_PATSTATUS();
                DataRow d = null;
                foreach (DataRow dr in dtt.Rows)
                {
                    if (txtPatientType.Text.Trim().ToUpper() == dr["STATUS_TEXT"].ToString().Trim().ToUpper())
                    {
                        txtPatientType.Tag = dr["STATUS_ID"].ToString();
                        txtPatientType.Text = dr["STATUS_TEXT"].ToString();
                        flag = false;
                        d = dr;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1017", env.CurrentLanguageID);
                    txtPatientType.SelectAll();
                    txtPatientType.Focus();
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                }

            }
        }

        private void txtThaiName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            if (e.KeyCode == Keys.Tab)
            {
                miraContainer15.Focus();
                txtLastThaiName.Focus();
            }
        }
        private void txtThaiName_Validating(object sender, CancelEventArgs e)
        {
            if (txtThaiName.Text.Trim() != string.Empty)
            {
                txtEngName.Text = TransToEnglish.Trans(txtThaiName.Text.Trim());
                string fname_eng = txtEngName.Text.Trim();
                fname_eng = fname_eng.Trim();
                string s = string.Empty;
                if (fname_eng.Length > 0)
                {
                    s = fname_eng[0].ToString();
                    fname_eng = fname_eng.Substring(1);
                    fname_eng = s.ToUpper() + fname_eng;
                }
                txtEngName.Text = fname_eng;
            }
            //if (txtLastThaiName.Enabled)
            //    txtLastThaiName.Focus();
            //else if (txtEngName.Enabled)
            //    txtEngName.Focus();
            //else if (datePeriod.Enabled)
            //    datePeriod.Focus();
            //else if (cboGender.Enabled)
            //    cboGender.Focus();
            //else if (txtDOB.Enabled)
            //    txtDOB.Focus();
            //else if (txtTelephone.Enabled)
            //    txtTelephone.Focus();
            //else if (txtPatientType.Enabled)
            //    txtPatientType.Focus();
            //else if (txtOrderDepartment.Enabled)
            //    txtOrderDepartment.Focus();
            //else if (txtOrderPhysician.Enabled)
            //    txtOrderPhysician.Focus();
        }

        private void txtLastThaiName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void txtLastThaiName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLastThaiName.Text.Trim() != string.Empty)
            {
                txtLastEngName.Text = TransToEnglish.Trans(txtLastThaiName.Text.Trim());
                string fname_eng = txtLastEngName.Text.Trim();
                fname_eng = fname_eng.Trim();
                string s = string.Empty;
                if (fname_eng.Length > 0)
                {
                    s = fname_eng[0].ToString();
                    fname_eng = fname_eng.Substring(1);
                    fname_eng = s.ToUpper() + fname_eng;
                }
                txtLastEngName.Text = fname_eng;
            }
            //if (txtEngName.Enabled)
            //    txtEngName.Focus();
            //else if (cboGender.Enabled)
            //    cboGender.Focus();
            //else if (datePeriod.Enabled)
            //    datePeriod.Focus();
            //else if (txtDOB.Enabled)
            //    txtDOB.Focus();
            //else if (txtTelephone.Enabled)
            //    txtTelephone.Focus();
            //else if (txtPatientType.Enabled)
            //    txtPatientType.Focus();
            //else if (txtOrderDepartment.Enabled)
            //    txtOrderDepartment.Focus();
            //else if (txtOrderPhysician.Enabled)
            //    txtOrderPhysician.Focus();
        }

        private void txtEngName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                //txtLastEngName.Focus();
                SendKeys.Send("{Tab}");

        }

        private void txtLastEngName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                //if (cboGender.Enabled)
                //    cboGender.Focus();
                //else
                //    txtTelephone.Focus();
                SendKeys.Send("{Tab}");

            }
        }

        private void txtDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                //txtTelephone.Focus();
                SendKeys.Send("{Tab}");

        }

        private void txtTelephone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                //txtPatientType.Focus();
                SendKeys.Send("{Tab}");

        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");

        }
        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode != "Edit")
            {
                if (cboGender.SelectedIndex == 2)
                {
                    datePeriod.DateTime = DateTime.Today;
                    datePeriod.Enabled = true;
                    datePeriod.BackColor = Color.White;
                }
                else
                {
                    datePeriod.ResetText();
                    datePeriod.Enabled = false;
                    datePeriod.BackColor = defaultBackColor;
                }
            }
        }

        private void txtPreparation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtPreparation.Text.Trim().Length > 0)
                    SendKeys.Send("{Tab}");
                else
                    SendKeys.Send("{Tab}");
            }
        }
        private void txtPreparation_Validating(object sender, CancelEventArgs e)
        {
            if (txtPreparation.Text.Trim() == string.Empty)
                txtPreparation.Tag = null;
            else
            {
                bool flag = true;
                LookUpSelect lvS = new LookUpSelect();
                DataTable dtt = lvS.ScheduleNotParameter("Prepation").Tables[0];
                DataRow d = null;
                foreach (DataRow dr in dtt.Rows)
                {
                    if (txtPreparation.Text.Trim().ToUpper() == dr["PREPARATION_DESC"].ToString().Trim().ToUpper())
                    {
                        txtPreparation.Tag = dr["PREPARATION_ID"].ToString();
                        txtPreparation.Text = dr["PREPARATION_DESC"].ToString();
                        flag = false;
                        d = dr;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID4022", env.CurrentLanguageID);
                    txtPreparation.SelectAll();
                    txtPreparation.Focus();
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                }

            }
        }
        private void txtCopies_TextChanged(object sender, EventArgs e)
        {
            int cp;
            if (!int.TryParse(txtCopies.Text, out cp))
                txtCopies.Text = "1";
            else if (cp < 1)
                txtCopies.Text = "1";
        }
        #endregion

        private void loadFormLanguage()
        {
            FormLanguage fl = new FormLanguage();
            fl.FormID = 1;
            fl.LanguageID = 1;
            fl.ProcedureType = 2;
            ProcessGetLanguage langs = new ProcessGetLanguage();
            langs.FormLanguage = fl;
            try
            {
                langs.Invoke();
            }
            catch { }
            try
            {

                DataTable dt = langs.ResultSet.Tables[0];
                langid = new int[dt.Rows.Count];
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    string lid = dt.Rows[k]["LANG_ID"].ToString();
                    langid[k] = Convert.ToInt32(lid);
                    if ((dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim()) == ("Y"))
                    {
                        defaultlangs = dt.Rows[k]["IS_DEFAULT"].ToString().ToUpper().Trim();
                        new GBLEnvVariable().CurrentLanguageID = Convert.ToInt32(dt.Rows[k]["LANG_ID"].ToString().Trim());
                    }
                    k++;
                }
            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }
        }
        private void setForeColor(Color clr)
        {
            dateDemo.ForeColor = clr;
            txtOrderNo.ForeColor = clr;
            btnLookUpNo.ForeColor = clr;
            txtPatientType.ForeColor = clr;
            btnPatienType.ForeColor = clr;
            txtHN.ForeColor = clr;
            btnLookup.ForeColor = clr;
            txtInsurace.ForeColor = clr;
            btnInsurance.ForeColor = clr;
            txtOrderDepartment.ForeColor = clr;
            btnDepartment.ForeColor = clr;
            txtThaiName.ForeColor = clr;
            txtLastThaiName.ForeColor = clr;
            txtOrderPhysician.ForeColor = clr;
            btnPhysician.ForeColor = clr;
            txtEngName.ForeColor = clr;
            txtLastEngName.ForeColor = clr;
            txtOrderDept.ForeColor = clr;
            cboGender.ForeColor = clr;
            datePeriod.ForeColor = clr;
            txtLastVisit.ForeColor = clr;
            txtDOB.ForeColor = clr;
            txtTelephone.ForeColor = clr;
            txtNextAppointment.ForeColor = clr;
            txtCopies.ForeColor = clr;
            txtTotal.ForeColor = clr;
            txtAGE.ForeColor = clr;
            txtTempInsurance.ForeColor = clr;
            txtPreparation.ForeColor = clr;
            btnNextAppointment.ForeColor = clr;
        }
        private void setBackColor(Color clr)
        {
            dateDemo.BackColor = clr;
            txtOrderNo.BackColor = clr;
            btnLookUpNo.BackColor = clr;
            txtPatientType.BackColor = clr;
            btnPatienType.BackColor = clr;
            txtHN.BackColor = clr;
            btnLookup.BackColor = clr;
            txtInsurace.BackColor = clr;
            btnInsurance.BackColor = clr;
            txtOrderDepartment.BackColor = clr;
            btnDepartment.BackColor = clr;
            txtThaiName.BackColor = clr;
            txtLastThaiName.BackColor = clr;
            txtOrderPhysician.BackColor = clr;
            btnPhysician.BackColor = clr;
            txtEngName.BackColor = clr;
            txtLastEngName.BackColor = clr;
            txtOrderDept.BackColor = clr;
            cboGender.BackColor = clr;
            datePeriod.BackColor = clr;
            txtLastVisit.BackColor = clr;
            txtDOB.BackColor = clr;
            txtTelephone.BackColor = clr;
            txtNextAppointment.BackColor = clr;
            txtCopies.BackColor = clr;
            txtTotal.BackColor = clr;
            txtAGE.BackColor = clr;
            txtTempInsurance.BackColor = clr;
            txtPreparation.BackColor = clr;
            btnNextAppointment.BackColor = clr;
        }
        private void setInitalVariable()
        {
            dttUpdate = null;
            //env.CountImg = "";
            scheduleID = 0;
            orderManger = new OrderManager();
            cboGender.Items.Clear();
            cboGender.Items.Add(string.Empty);
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");
            cboGender.SelectedIndex = 0;
            grdData.DataSource = null;
            gridControl3.DataSource = null;
            if (mode == "Last")
            {
                thisOrder.LastOrder(env.UserID);
            }
        }
        private void setEnableDisableControl(bool flag)
        {

            #region Demographic Tab
            //ultraExpandableGroupBox1.Enabled = true;
            //ultraExpandableGroupBox1.Expanded = true;
            dateDemo.Enabled = flag;
            txtOrderNo.Enabled = flag;
            btnLookUpNo.Enabled = flag;
            txtPatientType.Enabled = flag;
            btnPatienType.Enabled = flag;
            txtHN.Enabled = flag;
            btnLookup.Enabled = flag;
            txtInsurace.Enabled = flag;
            btnInsurance.Enabled = flag;
            txtOrderDepartment.Enabled = flag;
            btnDepartment.Enabled = flag;
            txtThaiName.Enabled = flag;
            txtLastThaiName.Enabled = flag;
            txtOrderPhysician.Enabled = flag;
            btnPhysician.Enabled = flag;
            txtEngName.Enabled = flag;
            txtLastEngName.Enabled = flag;
            txtOrderDept.Enabled = flag;
            cboGender.Enabled = flag;
            datePeriod.Enabled = flag;
            txtLastVisit.Enabled = flag;
            txtDOB.Enabled = flag;
            txtTelephone.Enabled = flag;
            txtNextAppointment.Enabled = flag;
            txtPreparation.Enabled = flag;
            btnPrepation.Enabled = flag;
            txtAGE.Enabled = flag;
            btnPatientAllergy.Enabled = flag;
            btnNextAppointment.Enabled = flag;
            chkNonResident.Enabled = flag;
            chkRequestResult.Enabled = flag;
            if (!flag)
                chkRequestResult.Checked = false;
            #endregion

            #region Order Details Tabs
            //ultraExpandableGroupBox5.Enabled = true;
            //ultraExpandableGroupBox5.Expanded = true;
            //grdData.Enabled = flag;
            //gridControl3.Enabled = flag;
            //btnPatientAllergy.Enabled = flag;
            //btnICD.Enabled = flag;
            //btnDocInstruction.Enabled = flag;
            //btnScanOrder.Enabled = flag;
            //txtTotal.Enabled = flag;
            //labelControl1.Enabled = flag;
            //btnSave.Enabled = flag;
            //btnSaveSame.Enabled = flag;
            //btnPrintPreview.Enabled = flag;
            //btnSendToPrint.Enabled = flag;
            //txtCopies.Enabled = flag;
            //treeRadio.Enabled = flag;
            panelMain.Enabled = flag;
            #endregion

        }
        private void setEnableForManual()
        {
            txtHN.Text = "AUTO";

            #region Set Enable
            panelMain.Enabled = true;

            lblOrderNo.Visible = false;
            txtOrderNo.Visible = false;
            btnLookUpNo.Visible = false;

            txtInsurace.Enabled = true;
            btnInsurance.Enabled = true;

            txtThaiName.Enabled = true;
            txtThaiName.BackColor = Color.White;

            txtLastThaiName.Enabled = true;
            txtLastThaiName.BackColor = Color.White;

            txtEngName.Enabled = true;
            txtEngName.BackColor = Color.White;

            txtLastEngName.Enabled = true;
            txtLastEngName.BackColor = Color.White;

            cboGender.Enabled = true;
            cboGender.BackColor = Color.White;

            txtTelephone.Enabled = true;
            txtTelephone.BackColor = Color.White;

            txtDOB.Enabled = true;
            txtDOB.BackColor = Color.White;

            txtPatientType.Enabled = true;
            txtPatientType.BackColor = Color.White;

            btnPatienType.Enabled = true;

            txtOrderDepartment.Enabled = true;
            txtOrderDepartment.BackColor = Color.White;

            btnDepartment.Enabled = true;
            btnPhysician.Enabled = true;

            txtOrderPhysician.Enabled = true;
            txtOrderPhysician.BackColor = Color.White;

            txtPreparation.Enabled = true;
            txtPreparation.BackColor = Color.White;

            btnPrepation.Enabled = true;

            //gridControl3.Enabled = false;
            btnLookup.Enabled = false;

            txtAGE.Visible = false;
            txtDOB.Visible = true;
            btnPatientAllergy.Enabled = true;

            btnNextAppointment.Enabled = true;
            #endregion

            thisOrder.Demographic.DataFromHIS = false;
            thisOrder.Demographic.DataFromLocal = false;
            thisOrder.Demographic.DataFromManual = true;
            setTextBoxAutoComplete();
        }
        private void clearContexInControl()
        {

            #region DemoGraphics
            dateDemo.DateTime = DateTime.Today;
            txtHN.Tag = null;
            txtOrderNo.Tag = null;
            txtHN.Text = txtOrderNo.Text = string.Empty;
            txtPatientDetail.Text = string.Empty;
            txtThaiName.Text = txtLastThaiName.Text = string.Empty;
            txtEngName.Text = txtLastEngName.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtOrderPhysician.Text = txtOrderDepartment.Text = string.Empty;
            txtOrderDept.Text = string.Empty;
            txtPatientType.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtInsurace.Text = string.Empty;
            txtTempInsurance.Text = txtInsurace.Text;
            txtLastVisit.Text = txtNextAppointment.Text = string.Empty;
            txtAGE.Text = string.Empty;
            txtPreparation.Tag = null;
            txtPreparation.Text = string.Empty;
            chkNonResident.Checked = false;
            #endregion

            #region Total
            txtTotal.Text = "0.00";
            txtCopies.Text = "1";
            #endregion

            datePeriod.ResetText();
            treeRadio.Nodes.Clear();
            treeRadio.Nodes.Add("No Radiologist");
            treeRadio.CollapseAll();
        }

        private DataTable dttAutoUnit;
        private DataTable dttAutoRadio;
        private DataTable dttAutoIns;
        private void bindUnitAutoComplete()
        {
            AutoCompleteStringCollection Dep = new AutoCompleteStringCollection();
            dttAutoUnit = new DataTable();
            dttAutoUnit = dtRefUnit.Copy();
            for (int i = 0; i < dttAutoUnit.Rows.Count; i++)
                Dep.Add(dttAutoUnit.Rows[i]["UNIT_UID"].ToString() + ":" + dttAutoUnit.Rows[i]["UNIT_NAME"].ToString() + "(" + dttAutoUnit.Rows[i]["PHONE_NO"].ToString() + ")");
            txtOrderDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtOrderDepartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrderDepartment.AutoCompleteCustomSource = Dep;

        }
        private void bindRadioAutoComplete()
        {
            AutoCompleteStringCollection Doc = new AutoCompleteStringCollection();
            dttAutoRadio = new DataTable();
            dttAutoRadio = new DataTable();
            dttAutoRadio = dtRefDoc.Copy();
            for (int i = 0; i < dttAutoRadio.Rows.Count; i++)
                Doc.Add(dttAutoRadio.Rows[i]["EMP_UID"].ToString() + ":" + dttAutoRadio.Rows[i]["RadioName"].ToString());
            txtOrderPhysician.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtOrderPhysician.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrderPhysician.AutoCompleteCustomSource = Doc;
        }
        private void bindInsuranceAutoComplete()
        {
            AutoCompleteStringCollection Insure = new AutoCompleteStringCollection();
            dttAutoIns = new DataTable();
            dttAutoIns = RISBaseData.Ris_InsuranceType();
            for (int i = 0; i < dttAutoIns.Rows.Count; i++)
                Insure.Add(dttAutoIns.Rows[i]["INSURANCE_TYPE_DESC"].ToString());
            txtInsurace.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtInsurace.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtInsurace.AutoCompleteCustomSource = Insure;
        }
        private void setTextBoxAutoComplete()
        {
            try
            {
                bindUnitAutoComplete();
                bindRadioAutoComplete();
                bindInsuranceAutoComplete();

                AutoCompleteStringCollection Tel = new AutoCompleteStringCollection();
                AutoCompleteStringCollection Pat = new AutoCompleteStringCollection();
                AutoCompleteStringCollection Pre = new AutoCompleteStringCollection();

                DataTable dtt = new DataTable();
                dtt = RISBaseData.RIS_PatStatus();
                for (int i = 0; i < dtt.Rows.Count; i++)
                    Pat.Add(dtt.Rows[i]["STATUS_TEXT"].ToString());
                txtPatientType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPatientType.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPatientType.AutoCompleteCustomSource = Pat;

                LookUpSelect lvS = new LookUpSelect();
                DataSet dsS = lvS.ScheduleNotParameter("Prepation");
                for (int i = 0; i < dsS.Tables[0].Rows.Count; i++)
                {
                    Pre.Add(dsS.Tables[0].Rows[i]["PREPARATION_DESC"].ToString());
                }
                txtPreparation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPreparation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPreparation.AutoCompleteCustomSource = Pre;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void setTextBoxAutoComplete(int unitID)
        {
            try
            {
                AutoCompleteStringCollection Doc = new AutoCompleteStringCollection();
                DataTable dtt = new DataTable();
                dtt = dtRefDoc.Copy();
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    if (dtt.Rows[i]["UNIT_ID"].ToString().Trim() != string.Empty)
                    {
                        if ((int)dtt.Rows[i]["UNIT_ID"] == unitID)
                            Doc.Add(dtt.Rows[i]["FNAME"].ToString() + " " + dtt.Rows[i]["MNAME"].ToString() + " " + dtt.Rows[i]["LNAME"].ToString());
                    }
                }
                txtOrderPhysician.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtOrderPhysician.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtOrderPhysician.AutoCompleteCustomSource = Doc;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void calTotal()
        {
            decimal total = 0.0M;
            DataView dv = (DataView)grdData.DataSource;
            foreach (DataRow dr in dv.Table.Rows)
            {
                decimal taxTemp = dr["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["RATE"]);
                int qty = dr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["QTY"]);

                total = total + (taxTemp * qty);
            }
            txtTotal.Text = total.ToString("#,##0.00");
        }
        private string genHhManual()
        {
            //return RIS.BusinessLogic.GlobalBaseData.GenHN();
            return Order.GenHN();
        }
        private void fillDemographicmodeNew()
        {
            setGridData();
            setGridOrder();
            gridControl3.Enabled = true;
            setTextBoxAutoComplete();
            getCovid19Icon(thisOrder.Demographic.Reg_UID);

            txtPatientDetail.Text = string.IsNullOrEmpty(thisOrder.Demographic.PATIENT_ID_LABEL) ? "-" : "[" + thisOrder.Demographic.PATIENT_ID_LABEL + "] " + thisOrder.Demographic.PATIENT_ID_DETAIL;
            txtHN.Text = thisOrder.Demographic.Reg_UID;
            txtThaiName.Text = thisOrder.Demographic.FirstName;
            txtLastThaiName.Text = thisOrder.Demographic.LastName;
            txtEngName.Text = thisOrder.Demographic.FirstName_ENG;
            txtLastEngName.Text = thisOrder.Demographic.LastName_ENG;
            if (thisOrder.Demographic.DateOfBirth == DateTime.MinValue)
            {
                txtDOB.ResetText();
                txtDOB.Enabled = true;
                txtDOB.BackColor = Color.White;
                txtAGE.Text = "";
            }
            else
            {
                txtDOB.DateTime = thisOrder.Demographic.DateOfBirth;
                //txtDOB.Text = thisOrder.Demographic.DateOfBirth.ToString("dd/MM/yyyy");
                LookUpSelect lus = new LookUpSelect();
                txtAGE.Text = lus.SelectAGE(thisOrder.Demographic.DateOfBirth).Tables[0].Rows[0][0].ToString();
                //txtAGE.ToolTipController.Appearance.BackColor = Color.White;//Color.FromArgb(227, 239, 255);
                txtAGE.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                txtAGE.ToolTip = "DOB : " + txtDOB.Text;

            }
            txtTelephone.Text = thisOrder.Demographic.Phone1;
            if (thisOrder.Demographic.Gender == "M")
                cboGender.SelectedIndex = 1;
            else if (thisOrder.Demographic.Gender == "F")
            {
                cboGender.SelectedIndex = 2;
                datePeriod.Enabled = true;
                datePeriod.ResetText();
                datePeriod.BackColor = Color.White;
            }
            else
                cboGender.SelectedIndex = 0;
            txtNextAppointment.Text = "";
            txtOrderDept.Text = "";
            txtLastVisit.Text = thisOrder.Demographic.Last_Modified_ON == DateTime.MinValue ? string.Empty : thisOrder.Demographic.Last_Modified_ON.ToString("dd/MM/yyyy");
            //txtNextAppointment.Text = string.Empty;

            GetNextAppointment();

            //txtNextAppointment.Text = string.Empty;
            txtOrderDepartment.Tag = thisOrder.Item.REF_UNIT;
            txtOrderPhysician.Tag = thisOrder.Item.REF_DOC;
            txtPatientType.Tag = thisOrder.Item.PAT_STATUS;
            DataTable dtt = null;
            if (txtOrderDepartment.Tag != null)
            {
                DataRow[] rows = dttAutoUnit.Select("UNIT_ID=" + txtOrderDepartment.Tag.ToString());
                if (rows.Length == 0)
                {
                    bindUnitAutoComplete();
                    rows = dttAutoUnit.Select("UNIT_ID=" + txtOrderDepartment.Tag.ToString());
                }
                if (rows.Length > 0)
                {
                    txtOrderDepartment.Text = rows[0]["UNIT_UID"].ToString() + ":" + rows[0]["UNIT_NAME"].ToString() + "(" + rows[0]["PHONE_NO"].ToString() + ")";
                    txtOrderDept.Text = rows[0]["PHONE_NO"].ToString();
                }

            }
            if (txtOrderPhysician.Tag != null)
            {
                DataRow[] rows = dttAutoRadio.Select("EMP_ID=" + txtOrderPhysician.Tag.ToString());
                if (rows.Length == 0)
                {
                    bindRadioAutoComplete();
                    rows = dttAutoRadio.Select("EMP_ID=" + txtOrderPhysician.Tag.ToString());
                }
                if (rows.Length > 0)
                {
                    txtOrderPhysician.Text = rows[0]["EMP_UID"].ToString() + ":" + rows[0]["RadioName"].ToString();
                    txtOrderPhysician.Tag = rows[0]["EMP_ID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(thisOrder.Demographic.Insurance_Type))
            {
                txtInsurace.Tag = thisOrder.Demographic.InsuranceID;
                txtInsurace.Text = thisOrder.Demographic.Insurance_Name;
                txtTempInsurance.Text = txtInsurace.Text;
                //DataRow[] rows = dttAutoIns.Select("INSURANCE_TYPE_UID='" + thisOrder.Demographic.Insurance_Type + "'");
                //if (rows.Length == 0)
                //{
                //    bindInsuranceAutoComplete();
                //    rows = dttAutoIns.Select("INSURANCE_TYPE_ID=" + thisOrder.Demographic.Insurance_Type);
                //}
                //if (rows.Length == 0)
                //{
                //    thisOrder.Demographic.Insurance_Type = string.Empty;
                //    thisOrder.Demographic.InsuranceID = 0;
                //}
                //else
                //{
                //    txtInsurace.Tag = rows[0]["INSURANCE_TYPE_ID"].ToString();
                //    txtInsurace.Text = rows[0]["INSURANCE_TYPE_DESC"].ToString();
                //    txtTempInsurance.Text = txtInsurace.Text;
                //}

            }
            if (txtPatientType.Tag != null)
            {
                dtt = RISBaseData.RIS_PatStatus();
                foreach (DataRow drPat in dtt.Rows)
                {
                    if (drPat["STATUS_ID"].ToString() == txtPatientType.Tag.ToString())
                        txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
                }
            }
            else
            {
                dtt = RISBaseData.RIS_PatStatus();
                foreach (DataRow drPat in dtt.Rows)
                {
                    if (drPat["IS_DEFAULT"].ToString() == "Y")
                    {
                        txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
                        txtPatientType.Tag = drPat["STATUS_ID"].ToString();
                        break;
                    }
                }

            }
            chkNonResident.Checked = thisOrder.Demographic.NON_RESIDENCE == "Y" ? true : false;
            chkNonResident.ForeColor = chkNonResident.Checked ? Color.Red : Color.Black;
            //if (thisOrder.Demographic.HL7_Format.Trim().Length > 0)
            if (!string.IsNullOrEmpty(thisOrder.Demographic.HL7_Format) && thisOrder.Demographic.HL7_Format.Trim().Length > 0)
                layoutDemographic.Text = "Demographic : " + thisOrder.Demographic.HL7_Format.Trim();
            else
                layoutDemographic.Text = "Demographic :";

            panelMain.Enabled = true;
            calTotal();

            txtOrderDepartment.Enabled = true;
            txtOrderPhysician.Enabled = true;
            txtInsurace.Enabled = true;
            txtPatientType.Enabled = true;
            txtTelephone.Enabled = true;
            txtPreparation.Enabled = true;
            btnPhysician.Enabled = true;
            btnInsurance.Enabled = true;
            btnDepartment.Enabled = true;
            btnPatienType.Enabled = true;
            btnPrepation.Enabled = true;
            btnPatientAllergy.Enabled = true;
            btnNextAppointment.Enabled = true;
            chkNonResident.Enabled = true;
            chkRequestResult.Enabled = true;
            txtOrderDepartment.BackColor = Color.White;
            txtOrderPhysician.BackColor = Color.White;
            //txtInsurace.BackColor = Color.White;
            txtPatientType.BackColor = Color.White;
            txtTelephone.BackColor = Color.White;
            txtCopies.BackColor = Color.White;
            txtPreparation.BackColor = Color.White;
            setForeColor(Color.Black);
            if (mode == "Last")
            {
                thisOrder.LastOrder(env.UserID);
                setGridData();
            }
            txtOrderDepartment.Focus();

            if (txtOrderDepartment.Text.Trim().Length > 0)
                txtOrderDepartment.Select(0, 1);

            //LoadInsuranceDetail();

            if (thisOrder.Demographic.HasEngName == false)
            {
                txtEngName.Enabled = true;
                txtEngName.BackColor = Color.White;

                txtLastEngName.Enabled = true;
                txtLastEngName.BackColor = Color.White;
            }
            else
            {
                txtEngName.Enabled = false;
                txtEngName.BackColor = defaultBackColor;

                txtLastEngName.Enabled = false;
                txtLastEngName.BackColor = defaultBackColor;
            }
            if (string.IsNullOrEmpty(thisOrder.Demographic.FirstName) || string.IsNullOrEmpty(thisOrder.Demographic.LastName))
            {
               
                txtThaiName.Enabled = true;
                txtThaiName.BackColor = Color.White;

                txtLastThaiName.Enabled = true;
                txtLastThaiName.BackColor = Color.White;
            }
            //if (txtHN.Text.Trim() == "4009812")
            //    ShowPatientPhoto();
            //else
            //    HidePatientPhoto();

            checkAllergies();
        }
        private void fillDemographicmodeEdit()
        {
            dttUpdate = thisOrder.ItemDetail.Clone();
            txtOrderNo.Text = thisOrder.Item.ORDER_ID.ToString();
            DataSet ds = thisOrder.TreeData;
            for (int i = 0; i < ds.Tables["Root"].Rows.Count; i++)
            {
                if (ds.Tables["Root"].Rows[i]["Level"].ToString() == "1")
                {
                    ds.Tables["Root"].Rows[i].Delete();
                    ds.AcceptChanges();
                    break;
                }
            }
            thisOrder.TreeData = ds;
            setGridOrder();
            setGridData();
            setTextBoxAutoComplete();
            txtHN.Text = thisOrder.Demographic.Reg_UID;
            txtPatientDetail.Text = string.IsNullOrEmpty(thisOrder.Demographic.PATIENT_ID_LABEL) ? "-" : "[" + thisOrder.Demographic.PATIENT_ID_LABEL + "] " + thisOrder.Demographic.PATIENT_ID_DETAIL;
            txtThaiName.Text = thisOrder.Demographic.FirstName;
            txtLastThaiName.Text = thisOrder.Demographic.LastName;
            txtEngName.Text = thisOrder.Demographic.FirstName_ENG;
            txtLastEngName.Text = thisOrder.Demographic.LastName_ENG;
            DataTable dtt = RISBaseData.Ris_InsuranceType();
            foreach (DataRow drIns in dtt.Rows)
            {
                if (drIns["INSURANCE_TYPE_ID"].ToString() == thisOrder.Demographic.InsuranceID.ToString())
                {
                    txtInsurace.Tag = drIns["INSURANCE_TYPE_ID"].ToString();
                    txtInsurace.Text = drIns["INSURANCE_TYPE_DESC"].ToString();
                    txtTempInsurance.Text = txtInsurace.Text;
                    break;
                }
            }
            if (thisOrder.Demographic.DateOfBirth == DateTime.MinValue)
            {
                txtDOB.ResetText();
                txtDOB.Enabled = true;
                txtDOB.BackColor = Color.White;
            }
            else
            {
                txtDOB.Text = thisOrder.Demographic.DateOfBirth.ToString("dd/MM/yyyy");
                LookUpSelect lus = new LookUpSelect();
                txtAGE.Text = lus.SelectAGE(thisOrder.Demographic.DateOfBirth).Tables[0].Rows[0][0].ToString();
                txtAGE.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                txtAGE.ToolTip = "DOB : " + txtDOB.Text;
            }
            txtTelephone.Text = thisOrder.Demographic.Phone1;
            if (thisOrder.Demographic.Gender == "M")
            {
                cboGender.SelectedIndex = 1;
                this.datePeriod.Text = string.Empty;
                this.datePeriod.Enabled = false;
            }
            else if (thisOrder.Demographic.Gender == "F")
            {
                cboGender.SelectedIndex = 2;
                datePeriod.Enabled = true;
                datePeriod.ResetText();
                datePeriod.BackColor = Color.White;
                datePeriod.Text = string.Empty;
                //datePeriod.DateTime = DateTime.Today;
                if (thisOrder.Item.LMP_DT != null)
                    if (thisOrder.Item.LMP_DT != DateTime.MinValue)
                        datePeriod.DateTime = thisOrder.Item.LMP_DT.GetValueOrDefault();
            }
            else
                cboGender.SelectedIndex = 0;
            txtNextAppointment.Text = "";
            txtOrderDept.Text = "";
            txtLastVisit.Text = thisOrder.Demographic.Last_Modified_ON == DateTime.MinValue ? string.Empty : thisOrder.Demographic.Last_Modified_ON.ToString("dd/MM/yyyy");
            //txtNextAppointment.Text = string.Empty;

            GetNextAppointment();

            txtOrderDepartment.Tag = thisOrder.Item.REF_UNIT;
            txtOrderPhysician.Tag = thisOrder.Item.REF_DOC;
            txtPatientType.Tag = thisOrder.Item.PAT_STATUS;
            if (txtOrderDepartment.Tag != null)
            {
                dtt = dtRefUnit.Copy();
                foreach (DataRow drUnit in dtt.Rows)
                {
                    if (drUnit["UNIT_ID"].ToString() == txtOrderDepartment.Tag.ToString())
                    {
                        txtOrderDepartment.Text = drUnit["UNIT_UID"].ToString() + ":" + drUnit["UNIT_NAME"].ToString() + "(" + drUnit["PHONE_NO"].ToString() + ")";
                        txtOrderDept.Text = drUnit["PHONE_NO"].ToString();
                    }
                }
            }
            if (txtOrderDepartment.Tag != null)
            {
                dtt = dtRefDoc.Copy();
                foreach (DataRow drDoc in dtt.Rows)
                {
                    if (drDoc["EMP_ID"].ToString() == txtOrderPhysician.Tag.ToString())
                        txtOrderPhysician.Text = drDoc["EMP_UID"].ToString() + ":" + drDoc["RadioName"].ToString();
                }
            }
            if (txtPatientType.Tag != null)
            {
                dtt = RISBaseData.RIS_PatStatus();
                foreach (DataRow drPat in dtt.Rows)
                {
                    if (drPat["STATUS_ID"].ToString() == txtPatientType.Tag.ToString())
                        txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
                }
            }
            else
            {
                dtt = RISBaseData.RIS_PatStatus();
                foreach (DataRow drPat in dtt.Rows)
                {
                    if (drPat["IS_DEFAULT"].ToString() == "Y")
                    {
                        txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
                        txtPatientType.Tag = drPat["STATUS_ID"].ToString();
                    }
                }
            }
            if (string.IsNullOrEmpty(thisOrder.ItemDetail.Rows[0]["PREPARATION_ID"].ToString()))
            {
                txtPreparation.Tag = null;
                txtPreparation.Text = "";
            }
            else
            {
                LookUpSelect lvS = new LookUpSelect();
                DataRow[] drPre = lvS.ScheduleNotParameter("Prepation").Tables[0].Select("PREPARATION_ID=" + thisOrder.ItemDetail.Rows[0]["PREPARATION_ID"].ToString());
                txtPreparation.Tag = Convert.ToInt32(drPre[0]["PREPARATION_ID"]);
                txtPreparation.Text = drPre[0]["PREPARATION_DESC"].ToString();
            }
            chkNonResident.Checked = thisOrder.Demographic.NON_RESIDENCE == "Y" ? true : false;
            chkNonResident.ForeColor = chkNonResident.Checked ? Color.Red : Color.Black;
            panelMain.Enabled = true;
            calTotal();

            #region Request Result Datetime
            if (thisOrder.Item.HAS_REQUEST_RESULT)
            {
                chkRequestResult.Checked = true;
                dtRequestResult.DateTime = thisOrder.Item.REQUEST_RESULT_DATETIME;
                timeReqeustResult.Time = thisOrder.Item.REQUEST_RESULT_DATETIME;
            }
            #endregion

            txtOrderDepartment.Enabled = true;
            txtOrderPhysician.Enabled = true;
            txtInsurace.Enabled = true;
            txtPatientType.Enabled = true;
            txtTelephone.Enabled = true;
            txtEngName.Enabled = true;
            txtLastEngName.Enabled = true;
            txtPreparation.Enabled = true;
            btnPhysician.Enabled = true;
            btnInsurance.Enabled = true;
            btnDepartment.Enabled = true;
            btnPatienType.Enabled = true;
            btnPrepation.Enabled = true;
            btnNextAppointment.Enabled = true;
            chkNonResident.Enabled = true;
            chkRequestResult.Enabled = true;
            txtOrderDepartment.BackColor = Color.White;
            txtOrderPhysician.BackColor = Color.White;
            //txtInsurace.BackColor = Color.White;
            txtPatientType.BackColor = Color.White;
            txtTelephone.BackColor = Color.White;
            txtEngName.BackColor = Color.White;
            txtLastEngName.BackColor = Color.White;
            txtCopies.BackColor = Color.White;
            txtPreparation.BackColor = Color.White;
            setForeColor(Color.Black);
            btnPatientAllergy.Enabled = true;
            //DataRow[] drChk = thisOrder.ItemDetail.Select("STATUS = 'F' OR STATUS = 'P'");
            //if (drChk.Length > 0)
            //{
            //    btnSave.Enabled = false;
            //    btnSaveSame.Enabled = false;
            //}
            //else
            //{
            btnSave.Enabled = true;
            btnSaveSame.Enabled = true;
            //}

            txtOrderDepartment.Focus();
            //check case log.

            checkAllergies();
        }
        private void fillDemographicmodeManual()
        {
            txtHN.Text = "AUTO";
            #region Set Enable
            panelMain.Enabled = true;
            txtInsurace.Enabled = true;
            btnInsurance.Enabled = true;

            txtThaiName.Enabled = true;
            txtThaiName.BackColor = Color.White;

            txtLastThaiName.Enabled = true;
            txtLastThaiName.BackColor = Color.White;

            txtEngName.Enabled = true;
            txtLastEngName.Enabled = true;
            cboGender.Enabled = true;

            txtTelephone.Enabled = true;
            txtDOB.Enabled = true;

            txtPatientType.Enabled = true;
            btnPatienType.Enabled = true;

            txtOrderDepartment.Enabled = true;
            btnDepartment.Enabled = true;

            txtOrderPhysician.Enabled = true;
            btnPhysician.Enabled = true;

            txtPreparation.Enabled = true;
            btnPrepation.Enabled = true;

            btnNextAppointment.Enabled = true;

            cboGender.BackColor = Color.White;
            btnPatientAllergy.Enabled = false;
            gridControl3.Enabled = false;
            btnLookup.Enabled = false;
            #endregion
            grdData.Enabled = true;
        }

        private bool checkRequire()
        {
            bool flag = true;

            //else
            //{
            //    #region Require check 
            //    DataView dv = (DataView)grdData.DataSource;
            //    flag = true;
            //    foreach (DataRow drModify in dv.Table.Rows)
            //    {
            //        if (drModify["IS_DELETED"].ToString().Trim() != "Y")
            //        {
            //            if (drModify["EXAM_UID"].ToString().Trim() != string.Empty)
            //            {
            //                if (drModify["MODALITY_ID"].ToString().Trim() != "0" && drModify["MODALITY_ID"].ToString() != string.Empty)
            //                    flag = false;
            //                else
            //                    flag = true;
            //            }
            //        }
            //    }
            //    if (flag)
            //    {
            //        msg.ShowAlert("UID1018", env.CurrentLanguageID);
            //        return false;
            //    }
            //    flag = true;
            //    #endregion
            //}
            return flag;
        }
        private bool checkRequireModeCreate(ref bool AddDetails)
        {
            bool flag = true;
            AddDetails = false;

            #region เช็ค Demographic
            if (txtThaiName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1026", env.CurrentLanguageID);
                txtThaiName.Focus();
                return false;
            }
            if (txtLastThaiName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1026", env.CurrentLanguageID);
                txtLastThaiName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtThaiName.Text.Trim()) && string.IsNullOrEmpty(txtLastThaiName.Text.Trim()))
            {
                msg.ShowAlert("UID1026", env.CurrentLanguageID);
                txtThaiName.Focus();
                return false;
            }
            if (txtEngName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1027", env.CurrentLanguageID);
                txtEngName.Focus();
                return false;
            }
            if (txtLastEngName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1027", env.CurrentLanguageID);
                txtLastEngName.Focus();
                return false;
            }
            if (txtOrderDepartment.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1012", env.CurrentLanguageID);
                txtOrderDepartment.Focus();
                return false;
            }
            if (txtOrderPhysician.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID5000", env.CurrentLanguageID);
                txtOrderPhysician.Focus();
                return false;
            }
            #endregion

            if (orderManger.Count > 0)
            {
                #region กรณีมีการทำ Order แบบ Same Patient
                flag = false;
                DataView dv = (DataView)grdData.DataSource;
                if (dv.Table.Rows.Count == 1)
                {
                    if (dv.Table.Rows[0]["EXAM_ID"].ToString().Trim() == string.Empty)
                    {
                        if (orderManger.Count == 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = true;
                            AddDetails = false;
                            return flag;
                        }
                    }
                }
                else
                {
                    foreach (DataRow drSearch in dv.Table.Rows)
                    {
                        if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty && drSearch["MODALITY_ID"].ToString().Trim() == string.Empty)
                            continue;
                        if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty)
                        {
                            flag = true;
                            break;
                        }
                        if (drSearch["MODALITY_ID"].ToString().Trim() == string.Empty || drSearch["MODALITY_ID"].ToString().Trim() == "0")
                        {
                            flag = true;
                            break;
                        }
                    }

                }


                if (flag)
                {

                    msg.ShowAlert("UID1018", new GBLEnvVariable().CurrentLanguageID);
                    return false;

                }
                AddDetails = true;
                flag = true;
                #endregion
            }
            else
            {
                #region เช็คในกรณีที่ไม่มีการ Add Same Patient
                flag = false;
                DataView dv = (DataView)grdData.DataSource;
                if (dv.Table.Rows.Count == 1)
                {
                    if (dv.Table.Rows[0]["EXAM_ID"].ToString().Trim() == string.Empty)
                    {
                        if (orderManger.Count == 0)
                            flag = true;
                        else
                            flag = false;
                    }
                }
                else
                {
                    foreach (DataRow drSearch in dv.Table.Rows)
                    {
                        if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty && drSearch["MODALITY_ID"].ToString().Trim() == string.Empty)
                            continue;
                        if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty)
                        {
                            flag = true;
                            break;
                        }
                        if (drSearch["MODALITY_ID"].ToString().Trim() == string.Empty || drSearch["MODALITY_ID"].ToString().Trim() == "0")
                        {
                            //DataRow[] drEx = dtExam.Select("EXAM_ID = " + drSearch["EXAM_ID"].ToString() + "AND SERVICE_TYPE = 1");
                            //if (drEx.Length > 0)
                            //{
                            flag = true;
                            break;
                            //}

                        }
                    }
                }
                if (flag)
                {

                    msg.ShowAlert("UID1018", new GBLEnvVariable().CurrentLanguageID);
                    return false;

                }
                AddDetails = true;
                flag = true;
                #endregion
            }

            return flag;
        }
        private bool checkRequireModeCreateSamePatient()
        {
            bool flag = true;

            #region เช็ค Demographic
            if (txtThaiName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1026", env.CurrentLanguageID);
                txtThaiName.Focus();
                return false;
            }
            if (txtLastThaiName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1026", env.CurrentLanguageID);
                txtLastThaiName.Focus();
                return false;
            }
            if (txtEngName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1027", env.CurrentLanguageID);
                txtEngName.Focus();
                return false;
            }
            if (txtLastEngName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1027", env.CurrentLanguageID);
                txtLastEngName.Focus();
                return false;
            }
            if (txtOrderDepartment.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1012", env.CurrentLanguageID);
                txtOrderDepartment.Focus();
                return false;
            }
            if (txtOrderPhysician.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID5000", env.CurrentLanguageID);
                txtOrderPhysician.Focus();
                return false;
            }
            #endregion

            #region ตรวจสอบการใส่ข้อมูลในกริด
            flag = false;
            DataView dv = (DataView)grdData.DataSource;
            if (dv.Table.Rows.Count == 1)
            {
                if (dv.Table.Rows[0]["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    flag = true;
                }
            }
            else
            {
                foreach (DataRow drSearch in dv.Table.Rows)
                {
                    if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty && drSearch["MODALITY_ID"].ToString().Trim() == string.Empty)
                        continue;
                    if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty)
                    {
                        flag = true;
                        break;
                    }
                    if (drSearch["MODALITY_ID"].ToString().Trim() == string.Empty || drSearch["MODALITY_ID"].ToString().Trim() == "0")
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {

                msg.ShowAlert("UID1018", new GBLEnvVariable().CurrentLanguageID);
                return false;

            }
            flag = true;
            #endregion

            return flag;
        }
        private bool checkRequireModeEdit()
        {
            bool flag = false;

            #region เช็ค Demographic
            if (txtThaiName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1026", env.CurrentLanguageID);
                txtThaiName.Focus();
                return false;
            }
            if (txtLastThaiName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1026", env.CurrentLanguageID);
                txtLastThaiName.Focus();
                return false;
            }
            if (txtEngName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1027", env.CurrentLanguageID);
                txtEngName.Focus();
                return false;
            }
            if (txtLastEngName.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1027", env.CurrentLanguageID);
                txtLastEngName.Focus();
                return false;
            }
            if (txtOrderDepartment.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID1012", env.CurrentLanguageID);
                txtOrderDepartment.Focus();
                return false;
            }
            if (txtOrderPhysician.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID5000", env.CurrentLanguageID);
                txtOrderPhysician.Focus();
                return false;
            }
            #endregion
            DataView dv = (DataView)grdData.DataSource;
            if (dv.Table.Rows.Count == 1)
            {
                if (dv.Table.Rows[0]["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    if (orderManger.Count == 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            else
            {

                foreach (DataRow drSearch in dv.Table.Rows)
                {
                    if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty && drSearch["MODALITY_ID"].ToString().Trim() == string.Empty)
                        continue;
                    if (drSearch["EXAM_ID"].ToString().Trim() == string.Empty)
                    {
                        flag = true;
                        break;
                    }
                    if (drSearch["MODALITY_ID"].ToString().Trim() == string.Empty || drSearch["MODALITY_ID"].ToString().Trim() == "0")
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {

                msg.ShowAlert("UID1018", new GBLEnvVariable().CurrentLanguageID);
                return false;

            }
            return true;
        }
        private void checkAllergies()
        {
            if (!string.IsNullOrEmpty(thisOrder.Demographic.Allergies))
            {
                frmAllergy2 Allergy = new frmAllergy2(thisOrder.Demographic.Reg_UID);
                Allergy.TopLevel = true;
                Allergy.StartPosition = FormStartPosition.CenterScreen;
                Allergy.ShowDialog();
            }
        }

        private bool insertData()
        {
            bool flag = true;
            try
            {
                int count = 0;
                while (count < orderManger.Count)
                {
                    //orderManger[count].Enc_ID = Enc_ID;
                    //orderManger[count].Enc_Type = Enc_Type;
                    flag = orderManger[count].Invoke();
                    if (!flag)
                        break;

                    _InputLogMultiOrder.AddLog(orderManger[count].Item.ORDER_ID, Utilities.IPAddress(), "frmOrders_save");
                    count = 0;
                    orderManger.RemoveAt(0);

                }
                if (flag)
                {
                    #region Check Insert Exam Flag
                    if (Utilities.IsHaveData(dttExamFlag))
                    {
                        foreach (DataRow rowFlag in dttExamFlag.Rows)
                        {
                            ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                            addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = 0;
                            addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = 0;
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowFlag["EXAM_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowFlag["EXAMFLAG_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowFlag["REASON"].ToString();
                            addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            addExamFlag.Invoke();
                        }
                    }
                    #endregion
                    #region Update Request Result Datetime
                    if (chkRequestResult.Checked)
                    {
                        DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                        ProcessUpdateRISOrder updateRequestResult = new ProcessUpdateRISOrder();
                        updateRequestResult.RIS_ORDER.ORDER_ID = thisOrder.Item.ORDER_ID;
                        updateRequestResult.RIS_ORDER.REQUEST_RESULT_DATETIME = requestResult;
                        updateRequestResult.UpdateRequestResult();
                    }
                    #endregion
                    lblOrderNo.Visible = true;
                    txtOrderNo.Visible = true;
                    btnLookUpNo.Visible = true;
                    cboGender.SelectedIndex = 0;
                    thisOrder = new Order();
                    loadFormLanguage();
                    clearContexInControl();
                    setEnableDisableControl(false);
                    setBackColor(defaultBackColor);
                    setForeColor(defaultForeColor);
                    setGridData();
                    setGridOrder();
                }
                else
                {
                    flag = false;
                    msg.ShowAlert("UID1024", env.CurrentLanguageID);
                    //env.CountImg = "";
                    scheduleID = 0;
                    cboGender.Items.Clear();
                    cboGender.Items.Add(string.Empty);
                    cboGender.Items.Add("Male");
                    cboGender.Items.Add("Female");
                    cboGender.SelectedIndex = 1;
                    grdData.DataSource = null;
                    gridControl3.DataSource = null;
                    if (orderManger.Count == 1)
                    {

                        DataRow dr = thisOrder.ItemDetail.NewRow();
                        dr["SPECIAL_CLINIC"] = "N";
                        dr["IS_DELETED"] = "N";
                        dr["PRIORITY"] = "R";
                        dr["EXAM_DT"] = DateTime.Today;
                        dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                        dr["colDelete"] = "Delete";
                        thisOrder.ItemDetail.Rows.Add(dr);
                        setGridData();
                        orderManger = new OrderManager();
                        txtOrderDepartment.Focus();
                    }
                    else
                    {
                        thisOrder = orderManger[orderManger.Count - 1];
                        orderManger.RemoveAt(orderManger.Count - 1);
                        DataRow dr = thisOrder.ItemDetail.NewRow();
                        dr["SPECIAL_CLINIC"] = "N";
                        dr["IS_DELETED"] = "N";
                        dr["PRIORITY"] = "R";
                        dr["EXAM_DT"] = DateTime.Today;
                        dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                        dr["colDelete"] = "Delete";
                        thisOrder.ItemDetail.Rows.Add(dr);
                        setGridData();
                        txtOrderDepartment.Focus();
                    }

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            }
            return flag;
        }
        private bool insertDataByPrintPreview()
        {
            bool flag = true;
            try
            {
                int count = 0;
                while (count < orderManger.Count)
                {
                    flag = orderManger[count].Invoke();
                    if (!flag)
                        break;

                    ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                    geExam.Invoke();
                    DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_ID=" + orderManger[0].ItemDetail.Rows[0]["EXAM_ID"].ToString());
                    if (string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                    {
                        //ReportMangager rptManager = new ReportMangager();
                        //Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReport(orderManger[0].Item.ORDER_ID, env.UserID));
                        //rptViewer.Text = "Xray No=" + orderManger[0].Item.XRAY_NO + " (Print Preview.)";
                        //rptViewer.ShowDialog();

                        xrptOrderReport orderReport = new xrptOrderReport(orderManger[0].Item.ORDER_ID);
                        orderReport.ShowPreviewDialog();
                    }
                    else if (drExam[0]["UNIT_ID"].ToString() == "2")
                    {
                        ReportMangager rptManager = new ReportMangager();
                        Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReportAIMC(orderManger[0].Item.ORDER_ID, env.UserID));
                        rptViewer.Text = "Xray No=" + orderManger[0].Item.XRAY_NO + " (Print Preview.)";
                        rptViewer.ShowDialog();
                    }
                    else
                    {
                        //ReportMangager rptManager = new ReportMangager();
                        //Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReport(orderManger[0].Item.ORDER_ID, env.UserID));
                        //rptViewer.Text = "Xray No=" + orderManger[0].Item.XRAY_NO + " (Print Preview.)";
                        //rptViewer.ShowDialog();

                        xrptOrderReport orderReport = new xrptOrderReport(orderManger[0].Item.ORDER_ID);
                        orderReport.ShowPreviewDialog();
                    }

                    count = 0;
                    orderManger.RemoveAt(0);
                }
                if (flag)
                {
                    #region Check Insert Exam Flag
                    if (Utilities.IsHaveData(dttExamFlag))
                    {
                        foreach (DataRow rowFlag in dttExamFlag.Rows)
                        {
                            ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                            addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = 0;
                            addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = 0;
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowFlag["EXAM_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowFlag["EXAMFLAG_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowFlag["REASON"].ToString();
                            addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            addExamFlag.Invoke();
                        }
                    }
                    #endregion
                    #region Update Request Result Datetime
                    if (chkRequestResult.Checked)
                    {
                        DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                        ProcessUpdateRISOrder updateRequestResult = new ProcessUpdateRISOrder();
                        updateRequestResult.RIS_ORDER.ORDER_ID = thisOrder.Item.ORDER_ID;
                        updateRequestResult.RIS_ORDER.REQUEST_RESULT_DATETIME = requestResult;
                        updateRequestResult.UpdateRequestResult();
                    }
                    #endregion
                    lblOrderNo.Visible = true;
                    txtOrderNo.Visible = true;
                    btnLookUpNo.Visible = true;
                    cboGender.SelectedIndex = 0;
                    thisOrder = new Order();
                    loadFormLanguage();
                    clearContexInControl();
                    setEnableDisableControl(false);
                    setBackColor(defaultBackColor);
                    setForeColor(defaultForeColor);
                    setGridData();
                    setGridOrder();
                }
                else
                {
                    flag = false;
                    msg.ShowAlert("UID1024", env.CurrentLanguageID);
                    if (orderManger.Count == 1)
                    {
                        //return ค่า order ใส่กริดแล้วเคลียร์ order manager
                        //add 1 row เพิ่ม
                        orderManger = new OrderManager();
                        DataRow dr = thisOrder.ItemDetail.NewRow();
                        dr["SPECIAL_CLINIC"] = "N";
                        dr["IS_DELETED"] = "N";
                        dr["PRIORITY"] = "R";
                        dr["EXAM_DT"] = DateTime.Today;
                        dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                        dr["colDelete"] = "Delete";
                        thisOrder.ItemDetail.Rows.Add(dr);
                        setGridData();
                    }
                    else
                    {
                        //return ค่า order ใส่กริดตัว Top สุด แล้วเคลียร์ตัว Top ออก
                        //add 1 row เพิ่ม
                        thisOrder = orderManger[orderManger.Count - 1];
                        orderManger.RemoveAt(orderManger.Count - 1);
                        DataRow dr = thisOrder.ItemDetail.NewRow();
                        dr["SPECIAL_CLINIC"] = "N";
                        dr["IS_DELETED"] = "N";
                        dr["PRIORITY"] = "R";
                        dr["EXAM_DT"] = DateTime.Today;
                        dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                        dr["colDelete"] = "Delete";
                        thisOrder.ItemDetail.Rows.Add(dr);
                        setGridData();
                    }

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            }
            return flag;
        }
        private bool insertDataBySendToPrint()
        {
            bool flag = true;
            try
            {
                int count = 0;
                while (count < orderManger.Count)
                {
                    flag = orderManger[count].Invoke();
                    if (!flag)
                        break;
                    ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                    geExam.Invoke();
                    DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_ID=" + orderManger[0].ItemDetail.Rows[0]["EXAM_ID"].ToString());
                    if (string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                    {
                        int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                        numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                        print.OrderEntryDirectPrint(orderManger[count].Item.ORDER_ID, env.UserID, numberOfCopy);
                    }
                    else if (drExam[0]["UNIT_ID"].ToString() == "2")
                    {
                        int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                        numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                        print.OrderEntryDirectPrintAIMC(orderManger[count].Item.ORDER_ID, env.UserID, numberOfCopy);
                    }
                    else
                    {
                        int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                        numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                        print.OrderEntryDirectPrint(orderManger[count].Item.ORDER_ID, env.UserID, numberOfCopy);
                    }

                    _InputLogMultiOrder.AddLog(orderManger[count].Item.ORDER_ID, Utilities.IPAddress(), "frmOrders_savePrint");

                    count = 0;
                    orderManger.RemoveAt(0);
                }
                if (flag)
                {
                    //defaultBackColor = txtLastVisit.BackColor;
                    //defaultForeColor = btnPhysician.ForeColor;
                    #region Check Insert Exam Flag
                    if (Utilities.IsHaveData(dttExamFlag))
                    {
                        foreach (DataRow rowFlag in dttExamFlag.Rows)
                        {
                            ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                            addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = 0;
                            addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = 0;
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowFlag["EXAM_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowFlag["EXAMFLAG_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowFlag["REASON"].ToString();
                            addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            addExamFlag.Invoke();
                        }
                    }
                    #endregion
                    #region Update Request Result Datetime
                    if (chkRequestResult.Checked)
                    {
                        DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                        ProcessUpdateRISOrder updateRequestResult = new ProcessUpdateRISOrder();
                        updateRequestResult.RIS_ORDER.ORDER_ID = thisOrder.Item.ORDER_ID;
                        updateRequestResult.RIS_ORDER.REQUEST_RESULT_DATETIME = requestResult;
                        updateRequestResult.UpdateRequestResult();
                    }
                    #endregion
                    #region Insert BillingLogs
                    foreach (DataRow rowBillingLog in dtTemplateBillingLog.Rows)
                    {
                        ProcessAddRISBillinglogWithHIS addBillinglog = new ProcessAddRISBillinglogWithHIS();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.amtprice = Convert.ToDouble(rowBillingLog["amtprice"].ToString());
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.attender = rowBillingLog["attender"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.clinictype = rowBillingLog["clinictype"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.CREATED_BY = env.UserID;
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.effectiveenddate = Convert.ToDateTime(rowBillingLog["effectiveenddate"].ToString());
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.effectivestartdate = Convert.ToDateTime(rowBillingLog["effectivestartdate"].ToString());
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.enc_id = rowBillingLog["enc_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.enc_type = rowBillingLog["enc_type"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.enterer = rowBillingLog["enterer"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.EXAM_ID = Convert.ToInt32(rowBillingLog["EXAM_ID"].ToString());
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.insurance = rowBillingLog["insurance"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.mrn = rowBillingLog["mrn"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.mrn_type = rowBillingLog["mrn_type"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.object_id = rowBillingLog["object_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.ORDER_ID = thisOrder.Item.ORDER_ID;
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.period = rowBillingLog["period"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.pricetype = rowBillingLog["pricetype"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.productcode = rowBillingLog["productcode"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.pt_acc_id = rowBillingLog["pt_acc_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.sdloc_id = rowBillingLog["sdloc_id"].ToString();
                        addBillinglog.RIS_BILLINGLOG_WITH_HIS.statuscode = rowBillingLog["statuscode"].ToString();
                        addBillinglog.Invoke();
                    }
                    #endregion
                    lblOrderNo.Visible = true;
                    txtOrderNo.Visible = true;
                    btnLookUpNo.Visible = true;
                    cboGender.SelectedIndex = 0;
                    thisOrder = new Order();
                    loadFormLanguage();
                    clearContexInControl();
                    setEnableDisableControl(false);
                    setBackColor(defaultBackColor);
                    setForeColor(defaultForeColor);
                    setGridData();
                    setGridOrder();
                }
                else
                {
                    flag = false;
                    msg.ShowAlert("UID1024", env.CurrentLanguageID);
                    if (orderManger.Count == 1)
                    {
                        //return ค่า order ใส่กริดแล้วเคลียร์ order manager
                        //add 1 row เพิ่ม
                        orderManger = new OrderManager();
                        DataRow dr = thisOrder.ItemDetail.NewRow();
                        dr["SPECIAL_CLINIC"] = "N";
                        dr["IS_DELETED"] = "N";
                        dr["PRIORITY"] = "R";
                        dr["EXAM_DT"] = DateTime.Today;
                        dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                        dr["colDelete"] = "Delete";
                        thisOrder.ItemDetail.Rows.Add(dr);
                        setGridData();
                    }
                    else
                    {
                        //return ค่า order ใส่กริดตัว Top สุด แล้วเคลียร์ตัว Top ออก
                        //add 1 row เพิ่ม
                        thisOrder = orderManger[orderManger.Count - 1];
                        orderManger.RemoveAt(orderManger.Count - 1);
                        DataRow dr = thisOrder.ItemDetail.NewRow();
                        dr["SPECIAL_CLINIC"] = "N";
                        dr["IS_DELETED"] = "N";
                        dr["PRIORITY"] = "R";
                        dr["EXAM_DT"] = DateTime.Today;
                        dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                        dr["colDelete"] = "Delete";
                        thisOrder.ItemDetail.Rows.Add(dr);
                        setGridData();
                    }

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            }
            return flag;
        }

        private bool updateData()
        {
            bool flag = orderManger[0].Invoke();
            if (flag)
            {

                #region Update Exam Flag
                if (Utilities.IsHaveData(dttExamFlag))
                {
                    foreach (DataRow rowExamFlag in dttExamFlag.Rows)
                    {
                        if (Convert.ToInt32(rowExamFlag["FLAG_ID"].ToString()) == 0)
                        {
                            ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                            addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            addExamFlag.Invoke();
                        }
                        else
                        {
                            ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                            updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowExamFlag["FLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            updateExamFlag.Invoke();
                        }
                    }
                }
                #endregion
                #region Update Request Result Datetime
                if (chkRequestResult.Checked)
                {
                    DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                    ProcessUpdateRISOrder updateRequestResult = new ProcessUpdateRISOrder();
                    updateRequestResult.RIS_ORDER.ORDER_ID = thisOrder.Item.ORDER_ID;
                    updateRequestResult.RIS_ORDER.REQUEST_RESULT_DATETIME = requestResult;
                    updateRequestResult.UpdateRequestResult();
                }
                #endregion
                cboGender.SelectedIndex = 0;
                thisOrder = new Order();
                orderManger = new OrderManager();
                loadFormLanguage();
                clearContexInControl();
                setEnableDisableControl(false);
                setBackColor(defaultBackColor);
                setForeColor(defaultForeColor);
                setGridData();
                setGridOrder();
            }
            else
            {
                msg.ShowAlert("UID1024", env.CurrentLanguageID);
                DataRow dr = thisOrder.ItemDetail.NewRow();
                dr["SPECIAL_CLINIC"] = "N";
                dr["IS_DELETED"] = "N";
                dr["PRIORITY"] = "R";
                dr["EXAM_DT"] = DateTime.Today;
                dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                dr["colDelete"] = "Delete";
                thisOrder.ItemDetail.Rows.Add(dr);
                setGridData();
                orderManger = new OrderManager();
                txtOrderDepartment.Focus();
            }
            return flag;
        }
        private bool updateDataByPrintPreview()
        {

            bool flag = orderManger[0].Invoke();
            if (flag)
            {
                #region Update Exam Flag
                if (Utilities.IsHaveData(dttExamFlag))
                {
                    foreach (DataRow rowExamFlag in dttExamFlag.Rows)
                    {
                        if (Convert.ToInt32(rowExamFlag["FLAG_ID"].ToString()) == 0)
                        {
                            ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                            addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            addExamFlag.Invoke();
                        }
                        else
                        {
                            ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                            updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowExamFlag["FLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            updateExamFlag.Invoke();
                        }
                    }
                }
                #endregion
                #region Update Request Result Datetime
                if (chkRequestResult.Checked)
                {
                    DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                    ProcessUpdateRISOrder updateRequestResult = new ProcessUpdateRISOrder();
                    updateRequestResult.RIS_ORDER.ORDER_ID = thisOrder.Item.ORDER_ID;
                    updateRequestResult.RIS_ORDER.REQUEST_RESULT_DATETIME = requestResult;
                    updateRequestResult.UpdateRequestResult();
                }
                #endregion

                #region Print Preview
                ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                geExam.Invoke();
                DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_ID=" + orderManger[0].ItemDetail.Rows[0]["EXAM_ID"].ToString());
                if (string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                {
                    //ReportMangager rptManager = new ReportMangager();
                    //Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReport(orderManger[0].Item.ORDER_ID, env.UserID));
                    //rptViewer.Text = "Xray No=" + orderManger[0].Item.XRAY_NO + " (Print Preview.)";
                    //rptViewer.ShowDialog();

                    xrptOrderReport orderReport = new xrptOrderReport(orderManger[0].Item.ORDER_ID);
                    orderReport.ShowPreviewDialog();
                }
                else if (drExam[0]["UNIT_ID"].ToString() == "2")
                {
                    ReportMangager rptManager = new ReportMangager();
                    Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReportAIMC(orderManger[0].Item.ORDER_ID, env.UserID));
                    rptViewer.Text = "Xray No=" + orderManger[0].Item.XRAY_NO + " (Print Preview.)";
                    rptViewer.ShowDialog();
                }
                else
                {
                    //ReportMangager rptManager = new ReportMangager();
                    //Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReport(orderManger[0].Item.ORDER_ID, env.UserID));
                    //rptViewer.Text = "Xray No=" + orderManger[0].Item.XRAY_NO + " (Print Preview.)";
                    //rptViewer.ShowDialog();

                    xrptOrderReport orderReport = new xrptOrderReport(orderManger[0].Item.ORDER_ID);
                    orderReport.ShowPreviewDialog();
                }


                #endregion

                #region Clear Control
                cboGender.SelectedIndex = 0;
                thisOrder = new Order();
                orderManger = new OrderManager();
                loadFormLanguage();
                clearContexInControl();
                setEnableDisableControl(false);
                setBackColor(defaultBackColor);
                setForeColor(defaultForeColor);
                setGridData();
                setGridOrder();
                #endregion
            }
            else
            {
                msg.ShowAlert("UID1024", env.CurrentLanguageID);
                DataRow dr = thisOrder.ItemDetail.NewRow();
                dr["SPECIAL_CLINIC"] = "N";
                dr["IS_DELETED"] = "N";
                dr["PRIORITY"] = "R";
                dr["EXAM_DT"] = DateTime.Today;
                dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                dr["colDelete"] = "Delete";
                thisOrder.ItemDetail.Rows.Add(dr);
                setGridData();
                setGridData();
                orderManger = new OrderManager();
                txtOrderDepartment.Focus();
            }
            return flag;
        }
        private bool updateDataBySendToPrint()
        {

            bool flag = orderManger[0].Invoke();
            if (flag)
            {
                #region Update Exam Flag
                if (Utilities.IsHaveData(dttExamFlag))
                {
                    foreach (DataRow rowExamFlag in dttExamFlag.Rows)
                    {
                        if (Convert.ToInt32(rowExamFlag["FLAG_ID"].ToString()) == 0)
                        {
                            ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                            addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            addExamFlag.Invoke();
                        }
                        else
                        {
                            ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                            updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowExamFlag["FLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = thisOrder.Item.ORDER_ID;
                            updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                            updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                            updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                            updateExamFlag.Invoke();
                        }
                    }
                }
                #endregion
                #region Update Request Result Datetime
                if (chkRequestResult.Checked)
                {
                    DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                    ProcessUpdateRISOrder updateRequestResult = new ProcessUpdateRISOrder();
                    updateRequestResult.RIS_ORDER.ORDER_ID = thisOrder.Item.ORDER_ID;
                    updateRequestResult.RIS_ORDER.REQUEST_RESULT_DATETIME = requestResult;
                    updateRequestResult.UpdateRequestResult();
                }
                #endregion
                #region Send To Print
                ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                geExam.Invoke();
                DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_ID=" + orderManger[0].ItemDetail.Rows[0]["EXAM_ID"].ToString());
                if (string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                {
                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrint(orderManger[0].Item.ORDER_ID, env.UserID, numberOfCopy);
                }
                else if (drExam[0]["UNIT_ID"].ToString() == "2")
                {
                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrintAIMC(orderManger[0].Item.ORDER_ID, env.UserID, numberOfCopy);
                }
                else
                {
                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.OrderEntryDirectPrint(orderManger[0].Item.ORDER_ID, env.UserID, numberOfCopy);
                }

                #endregion

                #region Clear Control
                cboGender.SelectedIndex = 0;
                thisOrder = new Order();
                orderManger = new OrderManager();
                loadFormLanguage();
                clearContexInControl();
                setEnableDisableControl(false);
                setBackColor(defaultBackColor);
                setForeColor(defaultForeColor);
                setGridData();
                setGridOrder();
                #endregion
            }
            else
            {
                msg.ShowAlert("UID1024", env.CurrentLanguageID);
                DataRow dr = thisOrder.ItemDetail.NewRow();
                dr["SPECIAL_CLINIC"] = "N";
                dr["IS_DELETED"] = "N";
                dr["PRIORITY"] = "R";
                dr["EXAM_DT"] = DateTime.Today;
                dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                dr["colDelete"] = "Delete";
                thisOrder.ItemDetail.Rows.Add(dr);
                setGridData();
                setGridData();
                orderManger = new OrderManager();
                txtOrderDepartment.Focus();
            }
            return flag;
        }
        private void updateRegistrationAllergies()
        {
            try
            {
                GBLEnvVariable env = new GBLEnvVariable();
                ProcessUpdateHISRegistration proUpdateAllergies = new ProcessUpdateHISRegistration();
                proUpdateAllergies.HIS_REGISTRATION.HN = thisOrder.Demographic.Reg_UID;
                proUpdateAllergies.HIS_REGISTRATION.LAST_MODIFIED_BY = env.UserID;
                proUpdateAllergies.HIS_REGISTRATION.ALLERGIES = string.IsNullOrEmpty(thisOrder.Demographic.Allergies.ToString().Trim()) ? "" : "Y";
                proUpdateAllergies.UpdateAllergies();
            }
            catch { }
        }

        private void fillDataToCreateOrder(Order Ord)
        {
            Ord.Item.REF_UNIT = txtOrderDepartment.Tag == null || txtOrderDepartment.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderDepartment.Tag);
            Ord.Item.REF_DOC = txtOrderPhysician.Tag == null || txtOrderPhysician.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderPhysician.Tag);
            Ord.Item.INSURANCE_TYPE_ID = txtInsurace.Tag == null || txtInsurace.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtInsurace.Tag);
            Ord.Item.PAT_STATUS = txtPatientType.Tag == null || txtPatientType.Tag.ToString() == string.Empty ? string.Empty : txtPatientType.Tag.ToString();
            Ord.Item.LMP_DT = datePeriod.DateTime;
            Ord.Item.REF_DOC_INSTRUCTION = this.thisOrder.Item.REF_DOC_INSTRUCTION;
            Ord.Item.CLINICAL_INSTRUCTION = this.thisOrder.Item.CLINICAL_INSTRUCTION;
            Ord.Item.ORG_ID = env.OrgID;
            Ord.Item.ORDER_DT = DateTime.Now;
            Ord.Item.ORDER_START_TIME = orderDT;
            if (txtOrderDepartment.Tag != null)
                if (txtOrderDepartment.Text.Trim() != string.Empty)
                    Ord.Item.REF_UNIT = Convert.ToInt32(txtOrderDepartment.Tag);
            if (txtOrderPhysician.Tag != null)
                if (txtOrderPhysician.Text.Trim() != string.Empty)

                    Ord.Item.REF_DOC = Convert.ToInt32(txtOrderPhysician.Tag);
            Ord.Item.CREATED_BY = env.UserID;
            Ord.Item.LAST_MODIFIED_BY = env.UserID;


            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table.Copy();

            int i = 0;
            //ลบ Row ว่าง
            while (i < dtt.Rows.Count)
            {
                if (dtt.Rows[i]["EXAM_ID"].ToString() == string.Empty)
                {
                    dtt.Rows[i].Delete();
                    dtt.AcceptChanges();
                    i = 0;
                }
                else
                {
                    dtt.Rows[i]["PREPARATION_ID"] = Convert.ToInt32(txtPreparation.Tag);
                    i++;
                }
            }


            Ord.ItemDetail = dtt.Copy();
            Ord.Ris_OrderImage = this.thisOrder.Ris_OrderImage;
            Ord.Ris_PatICD = this.thisOrder.Ris_PatICD.Copy();

            Ord.Demographic = this.thisOrder.Demographic;
            Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            Ord.Demographic.InsuranceID = Ord.Item.INSURANCE_TYPE_ID.GetValueOrDefault();
            Ord.Demographic.NON_RESIDENCE = chkNonResident.Checked ? "Y" : "N";
            if (txtInsurace.Tag != null)
            {
                if (txtInsurace.Text.Trim() != string.Empty)
                    Ord.Demographic.Insurance_Type = txtInsurace.Text;
            }
            if (Ord.Demographic.LinkDown == false && Ord.Demographic.DataFromHIS)
            {
                Ord.Demographic.Reg_UID = txtHN.Text.Trim();
                Ord.Demographic.FirstName_ENG = txtEngName.Text;
                Ord.Demographic.LastName_ENG = txtLastEngName.Text;
                Ord.Demographic.Phone1 = txtTelephone.Text;
            }
            else if (Ord.Demographic.DataFromLocal)
            {
                Ord.Demographic.DateOfBirth = txtDOB.DateTime;
                Ord.Demographic.FirstName_ENG = txtEngName.Text;
                Ord.Demographic.LastName_ENG = txtLastEngName.Text;
                Ord.Demographic.Phone1 = txtTelephone.Text;

            }
            else if (Ord.Demographic.DataFromManual)
            {
                #region Manual
                HIS_REGISTRATION his = new HIS_REGISTRATION();
                if (txtHN.Tag == null)
                    if (txtHN.Text != string.Empty)
                        txtHN.Tag = Envision.Operational.Translator.ConvertHNtoKKU.HN_KKU(txtHN.Text);

                if (Ord.Demographic.Reg_ID == 0)
                {
                    int reg_id;
                    if (int.TryParse(txtHN.Tag.ToString(), out reg_id))
                        his.REG_ID = reg_id;
                    else
                        his.REG_ID = 0;
                }
                his.TITLE_ENG = Ord.Demographic.Title_ENG;
                if (orderManger.Count > 0)
                    his.HN = orderManger[0].His_Registratiion.HN;
                else
                {
                    if (txtHN.Text.Trim().ToLower() == "auto")
                        his.HN = genHhManual();
                    else
                        his.HN = txtHN.Text;
                }
                his.FNAME = txtThaiName.Text.Trim();
                his.LNAME = txtLastThaiName.Text.Trim();
                his.FNAME_ENG = txtEngName.Text.Trim();
                his.LNAME_ENG = txtLastEngName.Text.Trim();
                switch (cboGender.SelectedIndex)
                {
                    case 0:
                        his.GENDER = null;
                        break;
                    case 1:
                        his.GENDER = 'M';
                        his.TITLE = "นาย";
                        his.TITLE_ENG = "Mr.";
                        break;
                    case 2:
                        his.GENDER = 'F';
                        his.TITLE = "นางสาว";
                        his.TITLE_ENG = "Mrs.";
                        break;
                }
                his.DOB = txtDOB.DateTime;
                his.PHONE1 = txtTelephone.Text.Trim();
                his.REG_DT = DateTime.Today;
                his.LAST_MODIFIED_BY = env.UserID;
                Ord.His_Registratiion = his;

                Ord.Demographic.DateOfBirth = txtDOB.DateTime;
                Ord.Demographic.FirstName = txtThaiName.Text;
                Ord.Demographic.LastName = txtLastThaiName.Text;
                Ord.Demographic.FirstName_ENG = txtEngName.Text;
                Ord.Demographic.LastName_ENG = txtLastEngName.Text;
                Ord.Demographic.Phone1 = txtTelephone.Text;

                #endregion
            }

            if (scheduleID > 0)
            {
                Ord.SetScheduleID(scheduleID);
                scheduleID = 0;
            }
            orderManger.Add(Ord);
        }
        private void fillDataToEditOrder(Order Ord)
        {

            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table.Copy();
            int i = 0;
            while (i < dtt.Rows.Count)
            {
                if (dtt.Rows[i]["EXAM_ID"].ToString() == string.Empty)
                {
                    dtt.Rows[i].Delete();
                    dtt.AcceptChanges();
                    i = 0;
                }
                else
                {
                    dtt.Rows[i]["PREPARATION_ID"] = Convert.ToInt32(txtPreparation.Tag);
                    i++;
                }
            }
            dtt.AcceptChanges();
            if (dttUpdate.Rows.Count > 0)
            {
                foreach (DataRow dr in dttUpdate.Rows)
                {
                    DataRow drAdd = dtt.NewRow();
                    for (i = 0; i < dttUpdate.Columns.Count; i++)
                        drAdd[i] = dr[i];
                    dtt.Rows.Add(drAdd);
                }
            }
            i = 0;
            Ord.ItemDetail = dtt.Copy();
            Ord.Ris_OrderImage = this.thisOrder.Ris_OrderImage;
            Ord.Ris_PatICD = this.thisOrder.Ris_PatICD.Copy();

            Ord.Item.REF_UNIT = txtOrderDepartment.Tag == null || txtOrderDepartment.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderDepartment.Tag);
            Ord.Item.REF_DOC = txtOrderPhysician.Tag == null || txtOrderPhysician.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderPhysician.Tag);
            Ord.Item.INSURANCE_TYPE_ID = txtInsurace.Tag == null || txtInsurace.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtInsurace.Tag);
            Ord.Item.PAT_STATUS = txtPatientType.Tag == null || txtPatientType.Tag.ToString() == string.Empty ? string.Empty : txtPatientType.Tag.ToString();
            Ord.Item.LMP_DT = datePeriod.DateTime;
            Ord.Item.REF_DOC_INSTRUCTION = this.thisOrder.Item.REF_DOC_INSTRUCTION;
            Ord.Item.CLINICAL_INSTRUCTION = this.thisOrder.Item.CLINICAL_INSTRUCTION;
            Ord.Item.LAST_MODIFIED_BY = env.UserID;
            Ord.Item.ORG_ID = env.OrgID;
            if (txtOrderDepartment.Tag != null)
                if (txtOrderDepartment.Text.Trim() != string.Empty)
                    Ord.Item.REF_UNIT = Convert.ToInt32(txtOrderDepartment.Tag);
            if (txtOrderPhysician.Tag != null)
                if (txtOrderPhysician.Text.Trim() != string.Empty)
                    Ord.Item.REF_DOC = Convert.ToInt32(txtOrderPhysician.Tag);

            Ord.Demographic = this.thisOrder.Demographic;
            Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            Ord.Demographic.InsuranceID = Ord.Item.INSURANCE_TYPE_ID.GetValueOrDefault();
            Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            Ord.Demographic.NON_RESIDENCE = chkNonResident.Checked ? "Y" : "N";
            if (txtInsurace.Tag != null)
            {
                if (txtInsurace.Text.Trim() != string.Empty)
                    Ord.Demographic.Insurance_Type = txtInsurace.Text;
            }
            if (Ord.Demographic.LinkDown == false && Ord.Demographic.DataFromHIS)
                Ord.Demographic.Reg_UID = txtHN.Text.Trim();
            else if (Ord.Demographic.DataFromLocal)
            {
                Ord.Demographic.DateOfBirth = txtDOB.DateTime;
                Ord.Demographic.FirstName_ENG = txtEngName.Text;
                Ord.Demographic.LastName_ENG = txtLastEngName.Text;
                Ord.Demographic.Phone1 = txtTelephone.Text;
            }
            Ord.Item.XRAY_NO = txtOrderNo.Text;
            orderManger.Add(Ord);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                e.Cancel = false;
                //routineToolStripMenuItem.Image = RIS.Properties.Resources.QA;
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                DataView dv = (DataView)grdData.DataSource;
                DataTable dtt = dv.Table;
                int row = view1.FocusedRowHandle;



                if (dtt.Rows[row]["EXAM_ID"].ToString() != "")
                {
                    DataRow[] drexam = dtExam.Select("EXAM_ID = " + dr["EXAM_ID"].ToString());
                    if (drexam[0]["URGENT_POSSIBLE"].ToString() == "1")
                    {
                        ugentToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        ugentToolStripMenuItem.Visible = true;
                    }
                    if (drexam[0]["STAT_POSSIBLE"].ToString() == "1")
                    {
                        statToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        statToolStripMenuItem.Visible = true;
                    }

                    string Priority = dtt.Rows[row]["PRIORITY"].ToString();
                    switch (Priority)
                    {
                        case "R":
                            statToolStripMenuItem.Image = null;
                            ugentToolStripMenuItem.Image = null;
                            rountineToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                            break;
                        case "U":
                            statToolStripMenuItem.Image = null;
                            ugentToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                            rountineToolStripMenuItem.Image = null;
                            break;
                        case "S":
                            statToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                            ugentToolStripMenuItem.Image = null;
                            rountineToolStripMenuItem.Image = null;
                            break;
                        default:
                            break;
                    }

                    string SetRate = dtt.Rows[row]["COMMENTS"].ToString();
                    if (SetRate.Length > 3)
                    {
                        SetRate = SetRate.Substring(0, 3).ToUpper();
                    }
                    switch (SetRate)
                    {
                        case "<F>":
                            NormalRateToolStripMenuItem.Image = null;
                            FreeRateToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                            break;
                        default:
                            NormalRateToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                            FreeRateToolStripMenuItem.Image = null;
                            break;
                    }

                    DataRow[] rowExamFlag = dttExamFlag.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                    if (rowExamFlag.Length > 0)
                    {
                        DataRow[] rowSelected = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowExamFlag[0]["EXAMFLAG_ID"].ToString());
                        contextcmb.SelectedIndex = dtExamFlagDTL.Rows.IndexOf(rowSelected[0]);
                    }
                    else
                        contextcmb.SelectedIndex = 0;

                    setFreeToolStripMenuItem.Enabled = true;
                    priorityToolStripMenuItem.Enabled = true;
                    multipleAssignmentToolStripMenuItem.Enabled = true;
                    examflagToolStripMenuItem.Enabled = true;
                }
                else
                {
                    setFreeToolStripMenuItem.Enabled = false;
                    priorityToolStripMenuItem.Enabled = false;
                    multipleAssignmentToolStripMenuItem.Enabled = false;
                    examflagToolStripMenuItem.Enabled = false;
                }



            }
            else
                e.Cancel = true;
        }
        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string strqty = view1.FocusedColumn.FieldName;
                if (view1.FocusedRowHandle > -1)
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    if (dr["EXAM_UID"].ToString() != string.Empty)
                    {
                        if (strqty == "QTY")
                        {
                            DataRow[] drbp = RISBaseData.BP_View().Select("BPVIEW_ID =" + dr["BPVIEW_ID"].ToString());
                            if (drbp[0]["BPVIEW_NAME"].ToString() == "Other")
                            {
                                view1.Columns["QTY"].OptionsColumn.ReadOnly = false;
                            }
                            else
                            {
                                view1.Columns["QTY"].OptionsColumn.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void rountineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rountineToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            dr["PRIORITY"] = "R";
            view1.RefreshData();
        }

        private void ugentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ugentToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            dr["PRIORITY"] = "U";
            view1.RefreshData();
        }

        private void statToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // thisOrder.ItemDetail.AcceptChanges();
            //int row = view1.FocusedRowHandle;
            statToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            dr["PRIORITY"] = "S";
            view1.RefreshData();
            //thisOrder.ItemDetail.Rows[row]["PRIORITY"] = "S";
            //thisOrder.ItemDetail.AcceptChanges();

            //DataTable dtt = thisOrder.ItemDetail;
            //DataView dv = new DataView(dtt);
            //if (dv.Table.Rows.Count > 0)
            //    dv.RowFilter = " IS_DELETED <>'Y' ";
            //grdData.DataSource = dv;
            //grdData.DataSource =
        }

        private void NormalRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComments frm = new frmComments();
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            string Comment = dr["COMMENTS"].ToString();
            if (Comment.IndexOf("</F>") > 0)
            {
                DataRow[] drAr = dtExam.Select("EXAM_ID = " + dr["EXAM_ID"].ToString());
                dr["COMMENTS"] = Comment.Replace("<F>" + getTagXML("F", Comment) + "</F>", "");
                dr["RATE"] = drAr[0]["RATE"];

                DataRow[] drClinic = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dr["CLINIC_TYPE"].ToString());

                switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                {
                    case "Normal":
                        dr["RATE"] = drAr[0]["RATE"];
                        break;
                    case "Special":
                        dr["RATE"] = drAr[0]["SPECIAL_RATE"];
                        break;
                    case "VIP":
                        dr["RATE"] = drAr[0]["VIP_RATE"];
                        break;
                    default:
                        break;
                }

                calTotal();
            }
        }

        private void FreeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComments frm = new frmComments();
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            string Comment = dr["COMMENTS"].ToString();
            string tag;
            if (Comment.IndexOf("</F>") > 0)
            {
                frm.Comments = getTagXML("F", Comment);
                tag = frm.Comments;
            }
            else
            {
                frm.Comments = "";
                tag = " ";
                Comment = Comment + "<F> </F>";
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dr["COMMENTS"] = Comment.Replace("<F>" + tag + "</F>", "<F>" + frm.Comments + "</F>");
                dr["RATE"] = 0;
                calTotal();
            }
        }
        public string getTagXML(string tag, string TextXML)
        {
            string TagData, Ftag, Ltag;
            Ftag = "<" + tag + ">";
            Ltag = "</" + tag + ">";
            try
            {
                TagData = TextXML.Substring(TextXML.IndexOf(Ftag) + 3, TextXML.IndexOf(Ltag) - (TextXML.IndexOf(Ftag) + 3));
            }
            catch { return ""; }
            return TagData;
        }

        private void multipleAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            DataTable tbTemp = new DataTable(dr["EXAM_UID"].ToString());
            tbMultiAssList.Add(tbTemp);

            frmOrdersMultipleAssignment frmMultiAssign = new frmOrdersMultipleAssignment();
            frmMultiAssign.ShowDialog();
        }

        private void view1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                string strqty = e.FocusedColumn.FieldName;
                if (view1.FocusedRowHandle > -1)
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    if (dr["EXAM_UID"].ToString() != string.Empty)
                    {
                        if (strqty == "QTY")
                        {
                            DataRow[] drbp = RISBaseData.BP_View().Select("BPVIEW_ID =" + dr["BPVIEW_ID"].ToString());
                            if (drbp[0]["BPVIEW_NAME"].ToString() == "Other")
                            {
                                view1.Columns["QTY"].OptionsColumn.ReadOnly = false;
                            }
                            else
                            {
                                view1.Columns["QTY"].OptionsColumn.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void layoutControl1_ShowContextMenu(object sender, DevExpress.XtraLayout.LayoutMenuEventArgs e)
        {
            e.Allow = false;
        }

        #region ExamPanel.
        private void initiateExamPanel()
        {
            ProcessGetRISExam proc = new ProcessGetRISExam();
            dttExamPanel = new DataTable();
            dttExamPanel = proc.GetExamPanel();
        }
        private bool haveExamData(DataTable dtt, string ExamID)
        {
            DataRow[] rows = dtt.Select("EXAM_ID=" + ExamID);
            return rows.Length == 0 ? false : true;
        }
        private void calExamPanel(DataTable dttExam, string ExamID, string ClinicType, DataTable dataExam, DataTable dtBP_View, DataTable dtClinic)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataRow[] rows = dttExamPanel.Select("EXAM_ID=" + ExamID);
            if (rows.Length > 0)
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow[] rowsExam = dataExam.Select("EXAM_ID=" + rows[i]["AUTO_EXAM_ID"].ToString());
                    if (!haveExamData(dttExam, rowsExam[0]["EXAM_ID"].ToString()))
                    {
                        DataRow dr = dttExam.NewRow();
                        dr["EXAM_ID"] = rowsExam[0]["EXAM_ID"];
                        dr["EXAM_UID"] = rowsExam[0]["EXAM_UID"];
                        dr["EXAM_NAME"] = rowsExam[0]["EXAM_NAME"];
                        dr["RATE"] = dr["RATE"];
                        dr["BPVIEW_ID"] = dtBP_View.Rows[0]["BPVIEW_ID"];
                        dr["QTY"] = dtBP_View.Rows[0]["NO_OF_EXAM"];
                        dr["MODALITY_ID"] = modalityDefault(dr["EXAM_ID"].ToString());
                        dr["SPECIAL_CLINIC"] = "N";
                        if (dr["COMMENTS"].ToString().IndexOf("</F>") <= 0)
                        {
                            DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + ClinicType);
                            DataRow[] drExam = dataExam.Select("EXAM_ID = " + rows[i]["AUTO_EXAM_ID"].ToString());
                            switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                            {
                                case "Normal":
                                    dr["RATE"] = drExam[0]["RATE"];
                                    break;
                                case "Special":
                                    dr["RATE"] = drExam[0]["SPECIAL_RATE"];
                                    dr["SPECIAL_CLINIC"] = "Y";
                                    break;
                                case "VIP":
                                    dr["RATE"] = drExam[0]["VIP_RATE"];
                                    break;
                                default:
                                    break;
                            }
                        }
                        dr["colDelete"] = "Delete";
                        dr["PRIORITY"] = "R";
                        dr["IS_DELETED"] = "N";
                        dr["CLINIC_TYPE"] = ClinicType;
                        dttExam.Rows.Add(dr);
                    }
                }
                dttExam.AcceptChanges();
            }
        }
        #endregion

        #region Insurance Webservice Process
        private void LoadInsuranceDetail()
        {
            //string strUNIT_UID = " ";
            //string[] strSplit = txtOrderDepartment.Text.Split(new string[] { ":" }, StringSplitOptions.None);
            //if (strSplit.Length > 1 && strSplit[0] != "")
            //{
            //    strUNIT_UID = strSplit[0];
            //}

            //String strEnc_id = "";
            //String strEnc_type = "";
            //string perfDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            //fnBill.LoadEncounter(txtHN.Text, strUNIT_UID, ref strEnc_id, ref strEnc_type);

            //if (strEnc_id == "") strEnc_id = " ";
            //if (strEnc_type == "") strEnc_type = " ";

            //Enc_ID = strEnc_id;
            //Enc_Type = strEnc_type;

            //string insu_uid = fnBill.LoadGetEligibilityInsuranceDetail(txtHN.Text, strEnc_id, strEnc_type, strUNIT_UID, perfDate, "RGL");

            //int insu_id = 0;
            //string insu_name = "";
            //fnBill.LoadInsuranceType(insu_uid, ref insu_id, ref insu_name);

            //txtInsurace.Text = insu_name;
            //txtInsurace.Tag = insu_id;
        }
        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (SL_NO > 0)
                updateIsLock();
        }

        private void barComments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Comment.frmComment frm = null;
            if (string.IsNullOrEmpty(txtHN.Text.Trim()))
            {
                frm = new Envision.NET.Forms.Comment.frmComment();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                if (mode.ToLower() == "edit")
                    frm = new Envision.NET.Forms.Comment.frmComment(txtHN.Text, thisOrder.Item.ORDER_ID, Envision.NET.Forms.Comment.QueryFromMode.Order);
                else
                    frm = new Envision.NET.Forms.Comment.frmComment(txtHN.Text);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            frm.Dispose();
        }
        private void btnOrderSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void GetNextAppointment()
        {
            if (txtHN.Text.Trim().Length == 0) return;

            try
            {
                //Envision.WebService.HISWebService.Service sv = new Envision.WebService.HISWebService.Service();
                //DataTable tb = sv.Get_appointment_detail(txtHN.Text).Tables[0];

                HIS_Patient nextAppt = new HIS_Patient();
                DataTable tb = nextAppt.Get_appointment_detail(txtHN.Text.Trim()).Tables[0];

                if (tb == null || tb.Rows.Count == 0) return;
                if (tb.Rows[0]["appt_date"].ToString().Trim().Length == 0) return;

                DateTime date = Convert.ToDateTime(tb.Rows[0]["appt_date"].ToString());
                //txtNextAppointment.Text = date.Day + "/" + date.Month + "/" + date.Year;
                txtNextAppointment.Text = date.ToString("dd/MM/yyyy");
            }
            catch
            {
                txtNextAppointment.Text = "";
            }
        }

        private void ShowPatientPhoto()
        {
            //ptPhoto = new Miracle.UserControls.HISPatientPhotoForm();
            //ptPhoto.Location = new Point(this.Location.X, this.Location.Y);

            try
            {
                ptPhoto.Show();
            }
            catch
            {
                ptPhoto = new Miracle.UserControls.HISPatientPhotoForm();
                ptPhoto.Show();
            }
        }
        private void HidePatientPhoto()
        {
            ptPhoto.Hide();
        }

        private void txtNextAppointment_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void chkNonResident_EditValueChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataTable dt = dv.ToTable();
            if (chkNonResident.Checked)
            {
                chkNonResident.ForeColor = Color.Red;
                foreach (DataRow drExam in dt.Rows)
                {
                    if (string.IsNullOrEmpty(drExam["EXAM_ID"].ToString())) break;
                    DataRow[] rows = dtExam.Select("EXAM_ID=" + drExam["EXAM_ID"].ToString());
                    if (rows.Length > 0)
                        drExam["RATE"] = rows[0]["FOREIGN_RATE"].ToString();
                }
            }
            else
            {
                chkNonResident.ForeColor = Color.Black;

                foreach (DataRow drExam in dt.Rows)
                {
                    if (string.IsNullOrEmpty(drExam["EXAM_ID"].ToString())) break;
                    DataRow[] rows = dtExam.Select("EXAM_ID=" + drExam["EXAM_ID"].ToString());
                    if (rows.Length > 0)
                    {
                        DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + drExam["CLINIC_TYPE"].ToString());
                        string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                        switch (clinictypeName.ToUpper())
                        {
                            case "SPECIAL":
                                drExam["RATE"] = rows[0]["SPECIAL_RATE"].ToString();
                                break;
                            case "VIP":
                                drExam["RATE"] = rows[0]["VIP_RATE"].ToString();
                                break;
                            default:
                                drExam["RATE"] = rows[0]["RATE"].ToString();
                                break;
                        }
                    }
                }
            }
            dt.AcceptChanges();
            grdData.DataSource = dt.DefaultView;
            calTotal();
            view1.RefreshData();
        }

        private void contextcmb_DropDownClosed(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow rowDtl = view1.GetDataRow(view1.FocusedRowHandle);
                DataRow[] rowCheck = dttExamFlag.Select("EXAM_ID=" + rowDtl["EXAM_ID"].ToString());
                int flag_id = 0;
                if (rowCheck.Length > 0)
                {
                    flag_id = string.IsNullOrEmpty(rowCheck[0]["FLAG_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["FLAG_ID"]);
                    dttExamFlag.Rows.Remove(rowCheck[0]);
                }
                dttExamFlag.AcceptChanges();

                TraumaItems trauma = contextcmb.SelectedItem as TraumaItems;
                DataRow rowAdd = dttExamFlag.NewRow();
                rowAdd["FLAG_ID"] = flag_id;
                rowAdd["EXAM_ID"] = rowDtl["EXAM_ID"].ToString();
                rowAdd["EXAMFLAG_ID"] = trauma.Trauma_id();
                rowAdd["REASON"] = "";
                dttExamFlag.Rows.Add(rowAdd);
                dttExamFlag.AcceptChanges();

                DataRow rowData = view1.GetDataRow(view1.FocusedRowHandle);
                rowData["FLAG_ICON"] = trauma.Trauma_id() == 72 ? 0 : trauma.Trauma_Seq();
                rowData["EXAMFLAG_ID"] = trauma.Trauma_id();
                view1.RefreshData();
                gridBestFitColumn();
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == grdData)
                {
                    GridView view = grdData.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "FLAG_ICON":
                                    if (!string.IsNullOrEmpty(rowDetail["FLAG_ICON"].ToString()))
                                        if (rowDetail["FLAG_ICON"].ToString() != "0")
                                        {
                                            DataRow[] rowFlag = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowDetail["EXAMFLAG_ID"].ToString());
                                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowFlag[0]["GEN_TEXT"].ToString());
                                            return;
                                        }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.GroupPanel)
                    {
                        info = new ToolTipControlInfo(hi.HitTest, "Group panel");
                        return;
                    }

                    if (hi.HitTest == GridHitTest.RowIndicator)
                    {
                        info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                        return;
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                            case "PRIORITY": info = new ToolTipControlInfo(hi.HitTest, "Priority"); break;
                        }
                    }
                }
            }
            finally
            {
                e.Info = info;
            }
        }

        private void chkRequestResult_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRequestResult.Checked)
            {
                dtRequestResult.Enabled = true;
                timeReqeustResult.Enabled = true;
            }
            else
            {
                dtRequestResult.Enabled = false;
                timeReqeustResult.Enabled = false;
            }
        }
    }
}
