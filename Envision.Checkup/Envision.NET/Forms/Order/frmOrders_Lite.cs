using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using RIS.Operational.Translator;
using RIS.Forms.GBLMessage;
using DevExpress.XtraEditors.Repository;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Operational.PACS;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Text.RegularExpressions;
using Npgsql;
using Miracle.Scanner;
using Miracle.ScannerNew;
using RIS.Plugin.ReportManager;
using RIS.Plugin.DirectPrint;

namespace RIS.Forms.Order
{  
    public partial class frmOrders_Lite :  Form         
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private MyMessageBox msg = new MyMessageBox();
        private int[] langid;
        private string defaultlangs;
        // ����� 3 ��ǹ����㹡�ä�ԡ�ç Grid Order  
        private int clickTick;
        private BaseEdit activeEditor;
        private bool firstClickFlag;
        //
        private GBLEnvVariable env = new GBLEnvVariable();
        private DateTime orderDT;
        private OrderManager orderManger;
        private order thisOrder;
        private Color defaultForeColor;
        private Color defaultBackColor;
        private string mode;
        private int scheduleID;

        private DataTable dttUpdate;

        public frmOrders_Lite(UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            defaultBackColor = txtLastVisit.BackColor;
            defaultForeColor = btnPhysician.ForeColor;
            this.StartPosition = FormStartPosition.CenterScreen;
            CloseControl = Cls;
            loadFormLanguage();
            thisOrder = new order();
            clearContexInControl();
            setEnableDisableControl(false);
            setBackColor(defaultBackColor);
            setForeColor(defaultForeColor);
            setGridData();
            setGridOrder();
            //ultraExpandableGroupBox1.Focus();
            CloseControl.ClosePressed += new EventHandler(CloseControl_ClosePressed);
        }
        void CloseControl_ClosePressed(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public frmOrders_Lite(string Mode, UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.CenterScreen;
            CloseControl = Cls;
            loadFormLanguage();
            thisOrder = new order();
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
            else if(Mode=="New" || Mode=="Last") {
                lblOrderNo.Visible = false;
                txtOrderNo.Visible = false;
                btnLookUpNo.Visible = false;
                txtHN.Enabled = true;
                txtHN.BackColor = Color.White;
                btnLookup.Enabled = true;
                btnSave.Text = "[F2] Save && Ready for New Patient";
                btnSaveSame.Text = "[F3] Save && Add New Order For Same Patient";
                if (Mode == "Last")
                {
                    thisOrder.LastOrder(env.UserID);
                    setGridData();
                }
            }
            else if (Mode == "Manual") {
                txtInsurace.Enabled = true;
                txtInsurace.BackColor = Color.White;
                btnInsurance.Enabled = true;
                setEnableForManual();
            }
            orderDT = DateTime.Now;
            CloseControl.ClosePressed += new EventHandler(CloseControl_ClosePressed);
        }
        public void frmOrdersSelectMode(string Mode)
        {
            //InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            //CloseControl = Cls;
            loadFormLanguage();
            thisOrder = new order();
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
                gridControl1.Enabled = true;
            }
            else if (Mode == "New" || Mode == "Last")
            {
                lblOrderNo.Visible = false;
                txtOrderNo.Visible = false;
                btnLookUpNo.Visible = false;
                txtHN.Enabled = true;
                txtHN.BackColor = Color.White;
                btnLookup.Enabled = true;
                btnSave.Text = "[F2] Save && Ready for New Patient";
                btnSaveSame.Text = "[F3] Save && Add New Order For Same Patient";
                if (Mode == "Last")
                {
                    thisOrder.LastOrder(env.UserID);
                    setGridData();
                }
                gridControl1.Enabled = true;
            }
            else if (Mode == "Manual")
            {
                txtInsurace.Enabled = true;
                txtInsurace.BackColor = Color.White;
                btnInsurance.Enabled = true;
                setEnableForManual();
                gridControl1.Enabled = true;
            }
            orderDT = DateTime.Now;
        }
        public frmOrders_Lite(string HN, string mode, UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CloseControl = Cls;
            loadFormLanguage();
            thisOrder = new order(HN, true);
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
        }

        private void frmOrders_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;

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

        private void btnPatientAllergy_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("��ʹ�� ", "�ѧ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnICD_Click(object sender, EventArgs e)
        {
            RIS.Forms.Order.WaitDialog.frmICD frm = new RIS.Forms.Order.WaitDialog.frmICD();
            if (thisOrder.Ris_PatICD != null) {
                if (thisOrder.Ris_PatICD.Rows.Count > 0)
                    frm.ICDTable = thisOrder.Ris_PatICD.Copy();
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (DialogResult.OK == frm.ShowDialog())
                thisOrder.Ris_PatICD = frm.ICDTable.Copy();
        }
        private void btnDocInstruction_Click(object sender, EventArgs e)
        {
            RIS.Forms.Order.WaitDialog.frmDocInstruction frm = new RIS.Forms.Order.WaitDialog.frmDocInstruction();
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.REF_DOC =thisOrder.Item.REF_DOC_INSTRUCTION;
            frm.CLINIC =thisOrder.Item.CLINICAL_INSTRUCTION;
            if (DialogResult.OK == frm.ShowDialog())
            {
                thisOrder.Item.REF_DOC_INSTRUCTION = frm.REF_DOC;
                thisOrder.Item.CLINICAL_INSTRUCTION = frm.CLINIC;
            }
        }
        private void btnScanOrder_Click(object sender, EventArgs e)
        {
            PointerStruct.ImageUrl = env.PacsUrl2;

            if (mode == "Edit")
            {
                if (thisOrder.Ris_OrderImage.Rows.Count > 0)
                {

                    Miracle.Scanner.EditImageOrder editFrm = new Miracle.Scanner.EditImageOrder(thisOrder.Ris_OrderImage.Copy(), env.PixPicture);
                    editFrm.StartPosition = FormStartPosition.CenterParent;
                    editFrm.ShowDialog();
                    if (editFrm.DialogResult == DialogResult.Yes)
                    {
                        thisOrder.Ris_OrderImage = editFrm.Data.Copy();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string s = string.Empty;
            if (mode == "Edit")
            {
                #region Update Order 
                flag = checkRequireModeEdit();
                if (flag)
                {
                    s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        fillDataToEditOrder(thisOrder);
                        updateData();
                        //updateDataBySendToPrint();
                    }
                }
                #endregion
            }
            else
            {
                #region Create Order 
                bool addDetials = true; //�礡ó� save same

                flag = checkRequireModeCreate(ref addDetials);
                if (flag)
                {
                    s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (addDetials)
                            fillDataToCreateOrder(thisOrder);

                        
                        insertData();
                        //insertDataBySendToPrint();
                        frmOrdersSelectMode("New");
                        this.txtHN.Focus();
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
                //string s = msg.ShowAlert("UID1022", env.CurrentLanguageID);
                //if (s == "2")
                //{
                //    RISOrder ord = new RISOrder();
                //    ord.ORDER_ID = thisOrder.Item.ORDER_ID; ;
                //    ord.IS_CANCELED = "Y";
                //    ord.LAST_MODIFIED_BY = env.UserID;
                //    ProcessUpdateRISOrder processUpdate = new ProcessUpdateRISOrder(ord, true);
                //    processUpdate.Invoke();

                //    DataView dv = (DataView)grdData.DataSource;
                //    DataTable dtt = dv.Table.Clone();
                //    if (dv.Table.Rows.Count > 1)
                //    {
                //        DataTable dttCancel = new DataTable();
                //        dttCancel.Columns.Add("ACCESSION_NO", typeof(string));
                //        dttCancel.AcceptChanges();

                //        dtt.Columns.Add("ordflag", typeof(string));

                //        foreach (DataRow dr in dv.Table.Rows)
                //        {
                //            if (dr["ORDER_ID"].ToString().Trim() != string.Empty)
                //            {
                //                DataRow drDtt = dtt.NewRow();
                //                for (int i = 0; i < dv.Table.Columns.Count; i++)
                //                    drDtt[i] = dr[i];
                //                drDtt["ordflag"] = "CA";
                //                drDtt["ORDER_ID"] = dr["ORDER_ID"];
                //                drDtt["ACCESSION_NO"] = dr["ACCESSION_NO"];
                //                dtt.Rows.Add(drDtt);
                //                dtt.AcceptChanges();

                //                DataRow drCancel = dttCancel.NewRow();
                //                drCancel[0] = dr["ACCESSION_NO"];
                //                dttCancel.Rows.Add(drCancel);
                //                dttCancel.AcceptChanges();
                //            }
                //        }
                //        dtt.AcceptChanges();
                //        ProcessUpdateRISOrderdtl processUpdateDTL = new ProcessUpdateRISOrderdtl();
                //        processUpdateDTL.UpdateFlag(dtt, "Y");

                //        thisOrder.CancelBilling(dttCancel, ord.ORDER_ID);



                //        GenerateOrderMessage genHl7 = new GenerateOrderMessage();
                //        Patient p = (Patient)thisOrder.Demographic;
                //        DataTable dttSendToPacs = genHl7.createMessage(p, dtt);
                //        ProcessUpdateRISOrderdtl processUpdateDtl = new ProcessUpdateRISOrderdtl();
                //        processUpdateDtl.UpdateHL7(dttSendToPacs);
                //        SendToPacs send = new SendToPacs();
                //        bool flag = send.SendMSGToPacs(dttSendToPacs, "ORM");

                //        cboGender.SelectedIndex = 0;
                //        thisOrder = new order();
                //        orderManger = new OrderManager();
                //        loadFormLanguage();
                //        clearContexInControl();
                //        setEnableDisableControl(false);
                //        setBackColor(defaultBackColor);
                //        setForeColor(defaultForeColor);
                //        setGridData();
                //        setGridOrder();
                //    }
                //    frmOrdersSelectMode("Edit");
                //}
                #endregion

                #region Cancel Order
                string s = msg.ShowAlert("UID1022", env.CurrentLanguageID);
                if (s == "2")
                {
                    RISOrder ord = new RISOrder();
                    ord.ORDER_ID = thisOrder.Item.ORDER_ID; ;
                    ord.IS_CANCELED = "Y";
                    ord.LAST_MODIFIED_BY = env.UserID;
                    ProcessUpdateRISOrder processUpdate = new ProcessUpdateRISOrder(ord, true);
                    processUpdate.Invoke();

                    SendToPacs send = new SendToPacs();
                    send.Set_ORMByOrderIdQueue(thisOrder.Item.ORDER_ID);

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
                    order ord = new order();
                    fillDataToCreateOrder(ord);

                    //������ Value;
                    env.CountImg = "";
                    scheduleID = 0;
                    DataTable dtt = thisOrder.Ris_OrderImage.Clone();
                    thisOrder.Ris_OrderImage = null;
                    thisOrder.Ris_OrderImage = dtt.Copy();
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
                    //bind ����������� DataGrid
                    setGridData();
                    setGridOrder();
                    calTotal();
                } 
                #endregion
            }
        }
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string s = string.Empty;

            if (mode == "Edit")
            {
                #region Update Order 
                flag = checkRequireModeEdit();
                if (flag) {
                    s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                    if (s == "2")
                    {
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
                flag = checkRequireModeCreate(ref addDetials);
                if (flag)
                {
                    s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (addDetials)
                            fillDataToCreateOrder(thisOrder);
                        insertDataByPrintPreview();
                    }
                }
                #endregion
            }
        }
        private void btnSendToPrint_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string s = string.Empty;
            if (mode == "Edit"){

                #region Update Order 
                flag = checkRequireModeEdit();
                if (flag)
                {
                    s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        fillDataToEditOrder(thisOrder);
                        updateDataBySendToPrint();               
                    }
                }
                #endregion

            }else {

                #region Create Order 
                bool addDetials = true;
                flag = checkRequireModeCreate(ref addDetials);
                if (flag)
                {
                    s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        if (addDetials)
                            fillDataToCreateOrder(thisOrder);
                        insertDataBySendToPrint();
                    }
                }
                #endregion

            }
        }

        private void datePeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDOB.Enabled)
                    txtDOB.Focus();
                else
                    txtTelephone.Focus();
            }
        }
        private void datePeriod_Validating(object sender, CancelEventArgs e)
        {
            if (txtDOB.Enabled)
                txtDOB.Focus();
            else if (txtTelephone.Enabled)
                txtTelephone.Focus();
            else if (txtPatientType.Enabled)
                txtPatientType.Focus();
            else if (txtOrderDepartment.Enabled)
                txtOrderDepartment.Focus();
            else if (txtOrderPhysician.Enabled)
                txtOrderPhysician.Focus();
        }

        #region Manu Tab 
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmArrivalWorkList frm = new RIS.Forms.Order.frmArrivalWorkList(this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrdersSelectMode("New");
            this.txtHN.Focus();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrdersSelectMode("Edit");
            this.txtOrderNo.Focus();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Edit", this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtOrderNo.Focus();
        }
        private void barSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Schedule.frmScheduleWorkList frm = new RIS.Forms.Schedule.frmScheduleWorkList(this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrdersSelectMode("Last");
            this.txtHN.Focus();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Last", this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barPrintLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmReprint frm = new RIS.Forms.Order.frmReprint(this.CloseControl);
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmViewPerformance frm = new frmViewPerformance(this.CloseControl);
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < CloseControl.TabPages.Count; i++)
            {
                if (CloseControl.TabPages[i].Title == "Home")
                {
                    CloseControl.TabPages[i].Selected = true;
                    return;
                }
            }
            RIS.Forms.Main.frmMainTab frm = new RIS.Forms.Main.frmMainTab(this.CloseControl);
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
            this.Close();
        }
        private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrdersSelectMode("Manual");
            this.txtInsurace.Focus();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Manual", this.CloseControl);
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtInsurace.Focus();
        }
        #endregion

        #region Grid �ʴ������š�ùѴ�����¡�� Order ����ش 
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
            for (int i = 0; i < gridView3.Columns.Count; i++)
                gridView3.Columns[i].Visible = false;
            gridView3.OptionsBehavior.Editable = false;
            gridView3.OptionsView.ShowBands = false;
            gridView3.OptionsDetail.ShowDetailTabs = false;
            gridView3.OptionsView.ShowGroupPanel = false;
            gridView3.BestFitColumns();

            gridView3.Columns["Caption"].Visible = true;
            gridView3.Columns["Caption"].Width = 100;
            gridView3.OptionsView.ShowColumnHeaders = false;

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
            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colID, colDateTime });
            gridView1.GridControl = gridControl3;
            gridView1.OptionsView.ShowGroupPanel = true;
            gridView1.ViewCaption = "Master";
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowColumnHeaders = false;
            gridView1.OptionsSelection.InvertSelection = true;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowHorzLines = false;
            gridView1.OptionsView.ShowVertLines = false;
            
            //gridView1.OptionsBehavior.Editable = false;

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
            repositoryItemLookUpEdit2.DataSource = order.Ris_Exam();

            RepositoryItemLookUpEdit repositoryItemLookUpEdit4 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODALITY_NAME") });
            repositoryItemLookUpEdit4.DisplayMember = "MODALITY_NAME";
            repositoryItemLookUpEdit4.ValueMember = "MODALITY_ID";
            repositoryItemLookUpEdit4.DropDownRows = 5;
            repositoryItemLookUpEdit4.ShowFooter = false;
            repositoryItemLookUpEdit4.ShowHeader = false;
            repositoryItemLookUpEdit4.NullText = "Modularity";
            repositoryItemLookUpEdit4.DataSource = order.Ris_Modality();


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

            gridView3.Columns["Level"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
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
            //        if (myOrder.Count == 0)
            //            myOrder.Schedule_ID = (int)dr[0];
            //        else
            //        {
            //            string s = msg.ShowAlert("UID100", new GBLEnvVariable().CurrentLanguageID);
            //            if (s == "2")
            //            {
            //                //chkSpecialClinic.Checked = dr[4].ToString().Trim() == string.Empty || dr[4].ToString() == "N" ? false : true;
            //                myOrder.Schedule_ID = (int)dr[0];
            //            }
            //            else
            //                return;
            //        }
            //        hasSchedule = myOrder.HasSchedule;
            //        scheduleID = myOrder.Schedule_ID;
            //        if (dsPreviosOrder == null)
            //            dsPreviosOrder = myOrder.PreviousOrder.Copy();
            //        DataSet dsOrder = dsPreviosOrder.Copy();
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
            //        myOrder.PreviousOrder = dsOrder;
            //        SetGridData();
            //        SetGridOrder();
            //        txtInsurace.Focus();
            //    }
            //}
            //catch { }
            //finally { }
            #endregion

            try {
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
                        foreach (DataRow drMaster in dsOrder.Tables["Masters"].Rows) {
                            if (drMaster["Level"].ToString() == "1")
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag) {
                            int i = 0;
                            while (i < dsOrder.Tables["Root"].Rows.Count) {
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
                        //**********
                         
                        setGridData();
                        setGridOrder();

                        DataTable dttHis = order.His_Doctor();// myOrder.HIS_Doctor();
                        foreach (DataRow dr_doc in dttHis.Rows)
                        {
                            if (thisOrder.Item.REF_DOC.ToString().Trim().ToUpper() == dr_doc["EMP_ID"].ToString().Trim().ToUpper())
                            {
                                txtOrderPhysician.Tag = dr_doc["EMP_ID"].ToString();
                                txtOrderPhysician.Text = dr_doc["RadioName"].ToString();
                                break;
                            }
                        }

                        DataTable dttDep = order.His_Department();// myOrder.HIS_Department();
                        foreach (DataRow drDep in dttDep.Rows)//UNIT_NAME
                        {
                            if (thisOrder.Item.REF_UNIT.ToString().Trim().ToUpper() == drDep["UNIT_ID"].ToString().Trim().ToUpper())
                            {
                                txtOrderDepartment.Tag = drDep["UNIT_ID"].ToString();
                                txtOrderDepartment.Text = drDep["UNIT_UID"].ToString() + ":" + drDep["UNIT_NAME"].ToString();
                                txtOrderDept.Text = drDep["PHONE_NO"].ToString();
                                break;
                            }
                        }
             
                        //txtOrderDepartment.Focus();
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            { }
        }
        private void setTreeOrder(order ord,DataSet dsOrder)
        {
            #region �� New Order 
            int newOrder = -1;
            bool flag = true;
            for (int i = 0; i < dsOrder.Tables["Root"].Rows.Count; i++)
            {
                if ((int)dsOrder.Tables["Root"].Rows[i]["Level"] == 0)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                DataRow drRoot = dsOrder.Tables["Root"].NewRow();
                drRoot[0] = "New Order";
                drRoot[1] = 0;
                dsOrder.Tables["Root"].Rows.Add(drRoot);
            }
            else
            {
                //�緤�� id order
                for (int i = 0; i < dsOrder.Tables["Masters"].Rows.Count; i++)
                {
                    if (dsOrder.Tables["Masters"].Rows[i]["Caption"].ToString() == "New Order")
                    {
                        int idTmp = Convert.ToInt32(dsOrder.Tables["Masters"].Rows[i]["ID"]);
                        if (newOrder < idTmp)
                            newOrder = idTmp;
                    }
                }
            }
           
            newOrder++;
            DataRow drNew = dsOrder.Tables["Masters"].NewRow();
            drNew["ID"] = newOrder;
            drNew["Caption"] = "New Order";
            drNew["DateTime"] = DateTime.Today;
            drNew["Level"] = 0;
            dsOrder.Tables["Masters"].Rows.Add(drNew);
            foreach (DataRow drData in ord.ItemDetail.Rows)
            {
                DataRow drNewDetail = dsOrder.Tables["Details"].NewRow();
                drNewDetail["ID"] = newOrder;
                drNewDetail["EXAM_ID"] = drData["EXAM_ID"];
                drNewDetail["MODALITY_ID"] = drData["MODALITY_ID"];
                drNewDetail["Level"] = 0;
                dsOrder.Tables["Details"].Rows.Add(drNewDetail);
            }
            
            #endregion
       
            #region ź No Order 
		    int iCount = 0;
            while (iCount < dsOrder.Tables["Root"].Rows.Count)
            {
                if (dsOrder.Tables["Root"].Rows[iCount]["Level"].ToString() == "100")
                {
                    dsOrder.Tables["Root"].Rows[iCount].Delete();
                    dsOrder.Tables["Root"].AcceptChanges();
                    iCount = 0;
                }
                else
                    iCount++;
            }
	        #endregion
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

        #region Grid �ͧ Order 
        private bool canAddRow()
        {
            //DataView dv = (DataView)grdData.DataSource;
            //dv.RowFilter = " IS_DELETED<>'Y'";
            //DataTable dtt = dv.ToTable();
            //DataRow dr = dtt.Rows[view1.FocusedRowHandle];

            //if (dr != null)
            //{
            //    if (dr["EXAM_ID"].ToString().Trim() == string.Empty &&  dr["MODALITY_ID"].ToString().Trim() == string.Empty)
            //        return false;
            //    else
            //        return true;
            //}
            //else
            //    return true;

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
            #region oldcode

            //try
            //{
            //    DataTable dtt = thisOrder.ItemDetail;
            //    DataView dv = new DataView(dtt);
            //    if (dv.Table.Rows.Count > 0)
            //        dv.RowFilter = " IS_DELETED <>'Y' ";
            //    grdData.DataSource = dv;
            //    view1.OptionsView.ShowBands = false;
            //    view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            //    view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            //    view1.OptionsView.ShowColumnHeaders = true;
            //    view1.OptionsCustomization.AllowSort = false;

            //    for (int i = 0; i < view1.Columns.Count; i++)
            //        view1.Columns[i].Visible = false;

            //    view1.Columns["EXAM_UID"].Caption = "Exam Code";
            //    view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            //    view1.Columns["PRIORITY"].Caption = "";//"Priority";
            //    view1.Columns["RATE"].Caption = "Rate";
            //    view1.Columns["RATE"].OptionsColumn.ReadOnly = true;
            //    view1.Columns["CLINIC_TYPE"].Caption = "Clinic";
            //    view1.Columns["MODALITY_ID"].Caption = "Modality";
            //    view1.Columns["ASSIGNED_TO"].Caption = "Radiologist";
            //    view1.Columns["BPVIEW_ID"].Caption = "Sides";
            //    view1.Columns["QTY"].Caption = "QTY";

            //    view1.Columns["PRIORITY"].ColVIndex = 0;
            //    view1.Columns["EXAM_UID"].ColVIndex = 1;
            //    view1.Columns["EXAM_NAME"].ColVIndex = 2;
            //    view1.Columns["BPVIEW_ID"].ColVIndex = 3;
            //    view1.Columns["QTY"].ColVIndex = 4;
            //    view1.Columns["RATE"].ColVIndex = 5;
            //    view1.Columns["CLINIC_TYPE"].ColVIndex = 6;
            //    view1.Columns["MODALITY_ID"].ColVIndex = 7;
            //    view1.Columns["ASSIGNED_TO"].ColVIndex = 8;
            //    view1.Columns["colDelete"].ColVIndex = 9;

            //    view1.Columns["colDelete"].Visible = true;
            //    view1.Columns["EXAM_UID"].Visible = true;
            //    view1.Columns["EXAM_NAME"].Visible = true;
            //    view1.Columns["PRIORITY"].Visible = true;
            //    view1.Columns["MODALITY_ID"].Visible = true;
            //    view1.Columns["ASSIGNED_TO"].Visible = true;
            //    view1.Columns["BPVIEW_ID"].Visible = false;
            //    view1.Columns["QTY"].Visible = true;

            //    //view1.Columns["EXAM_UID"].BestFit();
            //    //view1.Columns["EXAM_NAME"].BestFit();
            //    // view1.Columns["PRIORITY"].BestFit();
            //    view1.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
            //    view1.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //    view1.Columns["RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //    //view1.Columns["CLINIC_TYPE"].BestFit();
            //    //view1.Columns["MODALITY_ID"].BestFit();
            //    //view1.Columns["ASSIGNED_TO"].BestFit();

            //    RepositoryItemSpinEdit spe = new RepositoryItemSpinEdit();
            //    spe.ValueChanged += new EventHandler(spe_ValueChanged);
            //    view1.Columns["QTY"].ColumnEdit = spe;

            //    RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            //    btn.AutoHeight = false;
            //    btn.BestFitWidth = 9;
            //    btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //    btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            //    btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //    btn.Buttons[0].Caption = string.Empty;
            //    btn.Click += new EventHandler(btnDeleteRow_Click);
            //    view1.Columns["colDelete"].Caption = string.Empty;
            //    view1.Columns["colDelete"].ColumnEdit = btn;
            //    view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            //    view1.Columns["colDelete"].Width = 10;
            //    view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            //    RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            //    repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //    repositoryItemLookUpEdit1.ImmediatePopup = true;
            //    repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //    repositoryItemLookUpEdit1.AutoHeight = false;
            //    repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //    repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            //    repositoryItemLookUpEdit1.ValueMember = "EXAM_UID";
            //    repositoryItemLookUpEdit1.DropDownRows = 5;
            //    repositoryItemLookUpEdit1.DataSource = order.Ris_ExamCheckup();
            //    repositoryItemLookUpEdit1.NullText = string.Empty;
            //    repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examCode_KeyUp);
            //    repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode_CloseUp);
            //    view1.Columns["EXAM_UID"].ColumnEdit = repositoryItemLookUpEdit1;
            //    view1.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            //    RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            //    repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //    repositoryItemLookUpEdit2.ImmediatePopup = true;
            //    repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //    repositoryItemLookUpEdit2.AutoHeight = false;
            //    repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //    repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            //    repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
            //    repositoryItemLookUpEdit2.DropDownRows = 5;
            //    repositoryItemLookUpEdit2.DataSource = order.Ris_ExamCheckup();
            //    repositoryItemLookUpEdit2.NullText = string.Empty;
            //    repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            //    repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            //    view1.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            //    view1.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            //    RepositoryItemImageComboBox rImcbBPView = new RepositoryItemImageComboBox();
            //    rImcbBPView.SmallImages = this.imgWL;
            //    rImcbBPView.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            //    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
            //    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
            //    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

            //    rImcbBPView.Buttons.Clear();
            //    //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});

            //    RepositoryItemLookUpEdit repositoryItemLookUpEdit3 = new RepositoryItemLookUpEdit();
            //    repositoryItemLookUpEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //    repositoryItemLookUpEdit3.ImmediatePopup = true;
            //    repositoryItemLookUpEdit3.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //    repositoryItemLookUpEdit3.AutoHeight = false;
            //    repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRIORITY", "Priority", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //    repositoryItemLookUpEdit3.DisplayMember = "PRIORITY";
            //    repositoryItemLookUpEdit3.ValueMember = "PRI_ID";
            //    repositoryItemLookUpEdit3.DropDownRows = 5;
            //    repositoryItemLookUpEdit3.NullText = string.Empty;
            //    repositoryItemLookUpEdit3.DataSource = order.Ris_Priority();
            //    repositoryItemLookUpEdit3.KeyUp += new KeyEventHandler(priority_KeyUp);
            //    repositoryItemLookUpEdit3.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(priority_CloseUp);
            //    view1.Columns["PRIORITY"].ColumnEdit = rImcbBPView;
            //    view1.Columns["PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //    view1.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;

            //    RepositoryItemLookUpEdit repositoryItemLookUpEdit4 = new RepositoryItemLookUpEdit();
            //    repositoryItemLookUpEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //    repositoryItemLookUpEdit4.ImmediatePopup = true;
            //    repositoryItemLookUpEdit4.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //    repositoryItemLookUpEdit4.AutoHeight = false;
            //    repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODALITY_NAME", "Modality", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //    repositoryItemLookUpEdit4.DisplayMember = "MODALITY_NAME";
            //    repositoryItemLookUpEdit4.ValueMember = "MODALITY_ID";
            //    repositoryItemLookUpEdit4.DropDownRows = 5;
            //    repositoryItemLookUpEdit4.NullText = string.Empty;
            //    repositoryItemLookUpEdit4.KeyUp += new KeyEventHandler(modality_KeyUp);
            //    repositoryItemLookUpEdit4.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(modality_CloseUp);
            //    repositoryItemLookUpEdit4.DataSource = order.Ris_Modality();
            //    view1.Columns["MODALITY_ID"].ColumnEdit = repositoryItemLookUpEdit4;
            //    view1.Columns["MODALITY_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            //    RepositoryItemLookUpEdit repositoryItemLookUpEdit5 = new RepositoryItemLookUpEdit();
            //    repositoryItemLookUpEdit5.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //    repositoryItemLookUpEdit5.ImmediatePopup = true;
            //    repositoryItemLookUpEdit5.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //    repositoryItemLookUpEdit5.AutoHeight = false;
            //    repositoryItemLookUpEdit5.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RadioName", "Radiologist", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //    repositoryItemLookUpEdit5.DisplayMember = "RadioName";
            //    repositoryItemLookUpEdit5.ValueMember = "EMP_ID";
            //    repositoryItemLookUpEdit5.DropDownRows = 5;
            //    repositoryItemLookUpEdit5.NullText = string.Empty;
            //    repositoryItemLookUpEdit5.KeyUp += new KeyEventHandler(radio_KeyUp);
            //    repositoryItemLookUpEdit5.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(radio_CloseUp);
            //    repositoryItemLookUpEdit5.DataSource = order.Ris_Radiologist();
            //    view1.Columns["ASSIGNED_TO"].ColumnEdit = repositoryItemLookUpEdit5;
            //    view1.Columns["ASSIGNED_TO"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            //    RepositoryItemLookUpEdit repositoryItemLookUpEdit6 = new RepositoryItemLookUpEdit();
            //    repositoryItemLookUpEdit6.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //    repositoryItemLookUpEdit6.ImmediatePopup = true;
            //    repositoryItemLookUpEdit6.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //    repositoryItemLookUpEdit6.AutoHeight = false;
            //    repositoryItemLookUpEdit6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLINIC_TYPE_TEXT", "Clinic Type", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //    repositoryItemLookUpEdit6.DisplayMember = "CLINIC_TYPE_TEXT";
            //    repositoryItemLookUpEdit6.ValueMember = "CLINIC_TYPE_ID";
            //    repositoryItemLookUpEdit6.DropDownRows = 5;
            //    repositoryItemLookUpEdit6.NullText = string.Empty;
            //    repositoryItemLookUpEdit6.KeyUp += new KeyEventHandler(clinic_KeyUp);
            //    repositoryItemLookUpEdit6.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(clinic_CloseUp);
            //    repositoryItemLookUpEdit6.DataSource = order.RIS_ClinicType();
            //    view1.Columns["CLINIC_TYPE"].ColumnEdit = repositoryItemLookUpEdit6;
            //    view1.Columns["CLINIC_TYPE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          
            //    RepositoryItemLookUpEdit rleBPView = new RepositoryItemLookUpEdit();
            //    rleBPView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //    rleBPView.ImmediatePopup = true;
            //    rleBPView.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //    rleBPView.AutoHeight = false;
            //    rleBPView.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BPVIEW_NAME", "Sides", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //    rleBPView.DisplayMember = "BPVIEW_NAME";
            //    rleBPView.ValueMember = "BPVIEW_ID";
            //    rleBPView.DropDownRows = 5;
            //    rleBPView.DataSource = order.BP_View();
            //    rleBPView.NullText = string.Empty;
            //    rleBPView.KeyUp += new KeyEventHandler(BPView_KeyUp);
            //    rleBPView.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(BPView_CloseUp);
            //    view1.Columns["BPVIEW_ID"].ColumnEdit = rleBPView;
            //    view1.Columns["BPVIEW_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //    gridBestFitColumn();
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            #endregion

            try
            {
                DataTable dtt = thisOrder.ItemDetail;
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

                view1.Columns["EXAM_UID"].Caption = "Exam Code";
                view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                view1.Columns["PRIORITY"].Caption = "";//"Priority";
                view1.Columns["RATE"].Caption = "Rate";
                view1.Columns["RATE"].OptionsColumn.ReadOnly = true;
                view1.Columns["CLINIC_TYPE"].Caption = "Clinic";
                view1.Columns["MODALITY_ID"].Caption = "Modality";
                view1.Columns["ASSIGNED_TO"].Caption = "Radiologist";
                view1.Columns["BPVIEW_ID"].Caption = "Sides";
                view1.Columns["QTY"].Caption = "QTY";

                view1.Columns["PRIORITY"].ColVIndex = 0;
                view1.Columns["EXAM_UID"].ColVIndex = 1;
                view1.Columns["EXAM_NAME"].ColVIndex = 2;
                view1.Columns["BPVIEW_ID"].ColVIndex = 3;
                view1.Columns["QTY"].ColVIndex = 4;
                view1.Columns["RATE"].ColVIndex = 5;
                view1.Columns["CLINIC_TYPE"].ColVIndex = 6;
                view1.Columns["MODALITY_ID"].ColVIndex = 7;
                view1.Columns["ASSIGNED_TO"].ColVIndex = 8;
                view1.Columns["colDelete"].ColVIndex = 9;

                view1.Columns["colDelete"].Visible = true;
                view1.Columns["EXAM_UID"].Visible = true;
                view1.Columns["EXAM_NAME"].Visible = true;
                view1.Columns["PRIORITY"].Visible = true;
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

                RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit1.ImmediatePopup = true;
                repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit1.AutoHeight = false;
                repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
                repositoryItemLookUpEdit1.ValueMember = "EXAM_UID";
                repositoryItemLookUpEdit1.DropDownRows = 5;
                //repositoryItemLookUpEdit1.DataSource = order.Ris_Exam();
                repositoryItemLookUpEdit1.DataSource = getExamCheckup();
                repositoryItemLookUpEdit1.NullText = string.Empty;
                repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examCode_KeyUp);
                repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode_CloseUp);
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
                //repositoryItemLookUpEdit2.DataSource = order.Ris_Exam();
                repositoryItemLookUpEdit2.DataSource = getExamCheckup();
                repositoryItemLookUpEdit2.NullText = string.Empty;
                repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
                repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
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
                repositoryItemLookUpEdit3.DataSource = order.Ris_Priority();
                repositoryItemLookUpEdit3.KeyUp += new KeyEventHandler(priority_KeyUp);
                repositoryItemLookUpEdit3.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(priority_CloseUp);
                view1.Columns["PRIORITY"].ColumnEdit = rImcbBPView;
                view1.Columns["PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                view1.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;

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
                repositoryItemLookUpEdit4.DataSource = order.Ris_Modality();
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
                repositoryItemLookUpEdit5.DataSource = order.Ris_Radiologist();
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
                repositoryItemLookUpEdit6.DataSource = order.RIS_ClinicType();
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
                rleBPView.DataSource = order.BP_View();
                rleBPView.NullText = string.Empty;
                rleBPView.KeyUp += new KeyEventHandler(BPView_KeyUp);
                rleBPView.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(BPView_CloseUp);
                view1.Columns["BPVIEW_ID"].ColumnEdit = rleBPView;
                view1.Columns["BPVIEW_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gridBestFitColumn();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void spe_ValueChanged(object sender, EventArgs e)
        {
            string str = "";
            SpinEdit spe = new SpinEdit();
            spe = (SpinEdit)sender;
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            dr["QTY"] = Convert.ToInt32(spe.Value.ToString());
            dr.AcceptChanges();
            calTotal();
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
                    #region Old Code 
                    //if (mode == "Edit")
                    //{
                    //    if (s == "2")
                    //    {
                    //        //int i = 0;
                    //        //dr = view1.GetDataRow(view1.FocusedRowHandle);
                    //        //DataRow drAdd = dttUpdate.NewRow();
                    //        //for (int j = 0; j < dttUpdate.Columns.Count; j++)
                    //        //    drAdd[j] = dr[j];
                    //        //drAdd["IS_DELETED"] = "Y";
                    //        //dttUpdate.Rows.Add(drAdd);
                    //        //dtt.Rows[view1.FocusedRowHandle].Delete();
                    //        //dtt.AcceptChanges();
                    //        //GridBestFitColumn();

                    //        dv = (DataView)grdData.DataSource;
                    //        DataTable dttUpdate = dv.Table;
                    //        dr = view1.GetDataRow(view1.FocusedRowHandle);
                    //        foreach (DataRow drFind in dttUpdate.Rows) {
                    //            if (drFind.Equals(dr)) { 
                    //                drFind["IS_DELETED"] = "Y";
                    //                break;
                    //            }
                    //        }
                    //        dttUpdate.AcceptChanges();
                    //        thisOrder.ItemDetail = dttUpdate;
                    //        setGridData();
                    //        gridBestFitColumn();
                    //    }
                    //    return;
                    //} 
                    #endregion
                    if (s == "2")
                    {
                        if (mode == "Edit") {
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
                            DataTable table = order.Ris_Modality();
                            DataView clone = new DataView(table);
                            clone.RowFilter = "[MODALITY_ID] in (" + s + ")";
                            edit.Properties.DataSource = new BindingSource(clone, "");
                        }
                    }
                }
            }
        }

        void clinic_KeyUp(object sender, KeyEventArgs e)
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
        void radio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                view1.FocusedColumn = view1.VisibleColumns[0];
                view1.MoveNext();
            }
        }
        void modality_KeyUp(object sender, KeyEventArgs e)
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
        void priority_KeyUp(object sender, KeyEventArgs e)
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
        void examName_KeyUp(object sender, KeyEventArgs e)
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
        void examCode_KeyUp(object sender, KeyEventArgs e)
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
        void BPView_KeyUp(object sender, KeyEventArgs e)
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

        void clinic_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateClinic(e.Value.ToString());

                    if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    {
                        view1.FocusedRowHandle = row;
                        view1.FocusedColumn = view1.VisibleColumns[5];
                    }
                    else
                    {
                        view1.FocusedColumn = view1.VisibleColumns[0];
                        view1.MoveNext();
                    }
                }
            }
        }
        void radio_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateRadio(e.Value.ToString());

                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();

                }
            }
        }
        void modality_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateModality(e.Value.ToString());

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
        void priority_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
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
        void examName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
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
        void examCode_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
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
        void BPView_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    updateBPView(e.Value.ToString());

                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();

                }
            }
        }

        private string  modalityFilter(string ID)
        {
            string strReturn = string.Empty;
            DataView dv = new DataView(order.Ris_ModalityExam());
            dv.RowFilter = "EXAM_ID= " + ID;
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                    strReturn += dv[i][1].ToString() + ",";
                strReturn = strReturn.Remove(strReturn.LastIndexOf(','));
            }
            return strReturn;
        }
        private int     modalityDefault(string ID)
        {
            int intReturn = 0;
            DataView dv = new DataView(order.Ris_ModalityExam());
            dv.RowFilter = " IS_DEFAULT_MODALITY ='Y' and EXAM_ID=" + ID;
            if (dv.Count > 0)
                intReturn = (int)dv[0][1];
            return intReturn;
        }
        private void    updateClinic(string strSearch)
        {
            DataTable dtClinic = order.RIS_ClinicType();
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
                    DataRow[] drExam = order.Ris_Exam().Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
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
        private void    updateModality(string strSearch)
        {
            DataTable dtModality = order.Ris_Modality();
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
        private void    updateRadio(string strSearch)
        {
            DataTable dtRadio = order.Ris_Radiologist();
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
        private bool    updatePriority(string strSearch)
        {
            DataView dv = (DataView)grdData.DataSource;
            DataRow dr = dv.Table.Rows[view1.FocusedRowHandle];
            if (strSearch == "S")
            {
                DataTable dttExam = order.Ris_Exam();
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
        private bool    updateExamName(string strSearch)
        {
            DataTable dtExam = order.Ris_Exam();
            DataTable dtBP_View = order.BP_View();
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
                    DataRow[] drClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dtt.Rows[row]["CLINIC_TYPE"].ToString());
                    DataRow[] drExam = order.Ris_Exam().Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
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
                }


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
            DataTable dtExam = order.Ris_Exam();
            DataTable dtBP_View = order.BP_View();
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            //if (mode == "Edit")
            //{

            //    if (dtt.Rows[row]["IS_DELETED"].ToString().Trim() == "Y")
            //    {
            //        for (int j = 0; j < dtt.Rows.Count; j++)
            //            if (dtt.Rows[j]["IS_DELETED"].ToString().Trim() == "N")
            //            {
            //                row = j;
            //                break;
            //            }
            //    }
            //}
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
                    DataRow[] drClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dtt.Rows[row]["CLINIC_TYPE"].ToString());
                    DataRow[] drExam = order.Ris_Exam().Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
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
                }
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
            DataTable dtBP_View = order.BP_View();
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

                calTotal();
                view1.RefreshData();
                gridBestFitColumn();
                //setTreeRadioLogist((int)dr["EMP_ID"], dr["RadioName"].ToString());
            }
        }
        #endregion

        #region ���� Lookup 
        private void btnInsurance_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Insurance);

            string qry = @"
                        select
                            INSURANCE_TYPE_ID
	                        ,INSURANCE_TYPE_UID
	                        ,INSURANCE_TYPE_DESC
                        from
	                        RIS_INSURANCETYPE
                        where INSURANCE_TYPE_DESC Like '%%'";

            string fields = "Insurance Code,Insurance ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "Insurance Search");
            lv.Show();
        }
        private void find_Insurance(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
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
            //myOrder.Demographic.InsuranceID = Convert.ToInt32(txtInsurace.Tag);
            //myOrder.Demographic.Insurance_Type = txtInsurace.Text;
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_UnitCode);
            lv.AddColumn("UNIT_ID", "Department ID", false, true);
            lv.AddColumn("UNIT_UID", "Department Code", true, true);
            lv.AddColumn("UNIT_NAME", "Department Name", true, true);
            lv.AddColumn("PHONE_NO", "Telephone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.SelectOrderFrom("UNIT").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_UnitCode(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string s = txtOrderDepartment.Tag == null ? string.Empty : txtOrderDepartment.Tag.ToString();
            if (retValue[0] != s)
            {

                txtOrderDepartment.Tag = retValue[0];
                //txtOrderDepartment.Text = retValue[0];
                txtOrderDepartment.Text = retValue[1] + ":" + retValue[2];
                txtOrderDept.Text = retValue[3];
                //txtOrderPhysician.Text = string.Empty;
                //txtOrderPhysician.Tag = null;
                //setTextBoxAutoComplete((Convert.ToInt32(txtOrderDepartment.Tag)));
                setTextBoxAutoComplete();
            }
        }

        private void btnPhysician_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(find_Physician);

            string qry = @"
                	select
                        EMP_ID,EMP_UID
		                ,ISNULL(FNAME,'') + ' ' +ISNULL(MNAME,'') + ' '+ ISNULL(LNAME,'')as RadioName
                        
	                from
		                HR_EMP

                    where
                        (EMP_ID LIKE '%%' OR EMP_UID LIKE '%%' OR FNAME LIKE '%%' OR LNAME LIKE '%%') and JOB_TYPE='D'
                    ";
                    //where
                    //    JOB_TYPE='D'";

            string fields = "Doctor ID,Doctor Code,Doctor Name";
            string con = "";
            //if (txtOrderDepartment.Tag != null && txtOrderDepartment.Tag.ToString() != string.Empty)
            //    qry += " AND UNIT_ID=" + txtOrderDepartment.Tag.ToString();
            //qry += " AND  EMP_ID Like '%%'";
            lv.getData(qry, fields, con, "Doctor Search");
            lv.Show();
        }
        private void find_Physician(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            //setTextBoxAutoComplete((Convert.ToInt32(txtOrderDepartment.Tag)));
            setTextBoxAutoComplete();
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtOrderPhysician.Tag = retValue[0];
            //txtOrderDepartment.Text = retValue[0];
            txtOrderPhysician.Text = retValue[2];
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

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_ValueUpdated);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("REG_ID", "ID", false, true);
            lv.AddColumn("FNAME", "First name", true, true);
            lv.AddColumn("LNAME", "Last Name", true, true);
            lv.Text = "HN Search";

            lv.Data = lvS.SelectOrderFrom("HN").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void lv_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string hn = retValue[0].ToString();
            // thisOrder = new order(hn, true);

            thisOrder = new order(hn);
            if (thisOrder.Demographic.HasHN == false)
            {
                thisOrder = new order(hn, true);
            }

            if (thisOrder.Demographic.HasHN)
                fillDemographicmodeNew();
            else
            {
                layoutGroupDetail.Enabled = false;
                string hnTmp = txtHN.Text;
                thisOrder = new order();
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

        }

        private void btnLookUpNo_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lvNo_ValueUpdated);
            lv.AddColumn("ORDER_ID", "Order No", true, true);
            lv.AddColumn("REG_ID", "ID", false, true);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("ACCESSION_NO", "Accession No", true, true);
            lv.AddColumn("Exam", "Exam", true, true);
            lv.AddColumn("ORDER_DT", "Date", true, true);
            lv.Text = "HN Search";

            lv.Data = lvS.SelectOrderFrom("ORDER").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void lvNo_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            //string[] retValue = e.NewValue.Split(new Char[] { '^' });
            //int orderID = Convert.ToInt32(retValue[0]);
            //thisOrder = new order(orderID);
            //if (thisOrder.Demographic.HasHN)
            //{
            //    fillDemographicmodeEdit();

            //}
            //else
            //{
            //    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
            //    panelMain.Enabled = false;
            //    string hnTmp = txtHN.Text;
            //    thisOrder = new order();
            //    clearContexInControl();
            //    setEnableDisableControl(false);
            //    setBackColor(defaultBackColor);
            //    setForeColor(defaultForeColor);
            //    setInitalVariable();

            //    setGridData();
            //    setGridOrder();
            //    txtOrderNo.Enabled = true;
            //    txtOrderNo.BackColor = Color.White;
            //    btnLookUpNo.Enabled = true;
            //    txtOrderNo.Focus();
            //    return;

            //}
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            int orderID = Convert.ToInt32(retValue[0]);
            thisOrder = new order(orderID);

            #region Check IS_Lock
            //if (!string.IsNullOrEmpty(thisOrder.ItemDetail.Rows[0]["ACCESSION_NO"].ToString()))
            //{
            //    UpdateIsLock(thisOrder.ItemDetail.Rows[0]["ACCESSION_NO"].ToString());
            //}

            //if (CheckIsLock(retValue[3].ToString()) < 0)
            //{
            //    msg.ShowAlert("UID4026", env.CurrentLanguageID);
            //    return;
            //}
            #endregion

            if (thisOrder.Demographic.HasHN)
            {
                fillDemographicmodeEdit();
            }
            else
            {
                msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                layoutGroupDetail.Enabled = false;
                string hnTmp = txtHN.Text;
                thisOrder = new order();
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
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(patientType_ValueUpdated);
            string qry = @"
                       select
	                        STATUS_UID
	                        ,STATUS_ID
	                        ,STATUS_TEXT
                        from
	                        RIS_PATSTATUS
                        where 
                            STATUS_UID like '%%'
                        ";
            string fields = "Status Code,Status ID,Description";
            string con = "";
            lv.getData(qry, fields, con, "Status Search");
            lv.Show();
        }
        private void patientType_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtPatientType.Tag = retValue[1];
            //txtPatientType.Text = retValue[0];
            txtPatientType.Text = retValue[2];
        }
        #endregion

        #region TextBox Button ComboBox Behavior 
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 13)
            {
                txtHN.Text = txtHN.Text.Trim();
                if (txtHN.Text.Trim().Length > 0)
                {
                    #region oldCode
                    ////string realHN = txtHN.Text;
                    ////thisOrder = new order(realHN);
                    ////if (!thisOrder.Demographic.LinkDown)
                    ////{
                    //#region ����ö����������ҡѺ�к� HIS ��
                    ////if (thisOrder.Demographic.DataFromHIS)
                    ////{
                    ////    thisOrder.Demographic.Reg_UID = txtHN.Text;
                    ////    fillDemographicmodeNew();
                    ////}
                    ////else
                    ////{
                    ////    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                    ////    panelMain.Enabled = false;
                    ////    string hnTmp = txtHN.Text;
                    ////    thisOrder = new order();
                    ////    clearContexInControl();
                    ////    setEnableDisableControl(false);
                    ////    setBackColor(defaultBackColor);
                    ////    setForeColor(defaultForeColor);
                    ////    setInitalVariable();
                    ////    setGridData();
                    ////    setGridOrder();
                    ////    txtHN.Enabled = true;
                    ////    txtHN.BackColor = Color.White;
                    ////    btnLookup.Enabled = true;
                    ////    txtHN.Focus();
                    ////}
                    ////return;
                    //#endregion

                    ////}

                    ////string HN = Regex.Replace(txtHN.Text, "[a-zA-Z]", "");
                    ////HN = HN.Remove(HN.Length - 3);

                    ////bool canAccess = false;
                    ////string cns = "Dsn=MiraFoxFox";
                    ////DataTable dt = new DataTable();
                    ////using (OdbcConnection cn = new OdbcConnection(cns))
                    ////{
                    ////    //cn.Open();
                    ////    OdbcDataAdapter ad = new OdbcDataAdapter();
                    ////    ad.SelectCommand = new OdbcCommand();
                    ////    ad.SelectCommand.Connection = cn;
                    ////    //ad.SelectCommand.CommandText = @"select * from labour";// where REF_NO=" + HN;
                    ////    ad.SelectCommand.CommandText = @"select * from labour where ref_no=" + HN;
                    ////    //ad.SelectCommand.CommandText = @"select * from \\.\$c:\labour.dbf";
                    ////    //ad.SelectCommand.CommandText = @"select * from \\192.168.1.14\mr\Lacc\LACC_52\DATA\labour";
                    ////    ad.SelectCommand.CommandType = CommandType.Text;
                    ////    ad.Fill(dt);

                    ////    if (dt.Rows.Count > 0)
                    ////        canAccess = true;
                    ////}

                    ////if (canAccess)
                    ////{
                    ////    //#region ����ö�������͡Ѻ[LabourAcc.dbf]:192.168.1.14\mr\Lacc\LACC_52\Data\LabourAcc.dbf
                    ////    //thisOrder = new order();
                    ////    //thisOrder.Demographic
                    ////    //#endregion
                    ////    MessageBox.Show(dt.Rows.Count.ToString());
                    ////}
                    ////else
                    ////{
                    ////    MessageBox.Show("Can not Query");

                    ////�ó� LinkDown ��Ǩ�ͺ������㹵��ҧ HIS_REGISTRATION ������������
                    //thisOrder = new order(txtHN.Text, true);
                    //if (thisOrder.Demographic.HasHN)
                    //{
                    //    #region �֧�����Ũҡ Local 㹵��ҧ HIS_REGISTRATION
                    //    //string s = msg.ShowAlert("UID1016", env.CurrentLanguageID);
                    //    //if (s == "1")
                    //    //{
                    //    //    //�ó� wait
                    //    //    RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders(this.CloseControl);
                    //    //    frm.Text = frm.Text;
                    //    //    UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                    //    //    page.Selected = true;
                    //    //    int index = CloseControl.SelectedIndex;
                    //    //    CloseControl.TabPages.Add(page);
                    //    //    CloseControl.TabPages.RemoveAt(index);
                    //    //}
                    //    //else if (s == "2")
                    //    //{
                    //    //    //update ������� his
                    //    //    fillDemographicmodeNew();

                    //    //    txtHN.Enabled = false;
                    //    //    txtHN.BackColor = defaultBackColor;
                    //    //    btnLookup.Enabled = false;

                    //    //    txtThaiName.Enabled = true;
                    //    //    txtThaiName.BackColor = Color.White;
                    //    //    txtLastThaiName.Enabled = true;
                    //    //    txtLastThaiName.BackColor = Color.White;
                    //    //    txtDOB.Enabled = true;
                    //    //    txtAGE2.Enabled = true;
                    //    //    txtDOB.BackColor = Color.White;
                    //    //    cboGender.Enabled = true;
                    //    //    cboGender.BackColor = Color.White;
                    //    //}
                    //    //else if (s == "3")
                    //    //{
                    //    //�������
                    //    fillDemographicmodeNew();
                    //    gridView1.Focus();
                    //    //}
                    //    #endregion
                    //}
                    //else
                    //{
                    //    DataSet ds = new DataSet();
                    //    if (txtHN.Text.StartsWith("L", StringComparison.CurrentCultureIgnoreCase))
                    //        ds = GetDemographicLabor(txtHN.Text);

                    //    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        DataRow dr = ds.Tables[0].Rows[0];

                    //        #region loadControl
                    //        panelMain.Enabled = true;
                    //        gridControl3.Enabled = false;
                    //        grdData.Enabled = true;

                    //        thisOrder.Demographic.Reg_UID = txtHN.Text;
                    //        thisOrder.Demographic.DataFromHIS = false;
                    //        thisOrder.Demographic.DataFromLocal = false;
                    //        thisOrder.Demographic.DataFromManual = true;

                    //        txtPatientType.Enabled = true;
                    //        txtPatientType.BackColor = Color.White;
                    //        btnPatienType.Enabled = true;

                    //        txtHN.Enabled = false;
                    //        txtHN.BackColor = defaultBackColor;
                    //        btnLookup.Enabled = false;

                    //        txtInsurace.Enabled = true;
                    //        txtInsurace.BackColor = Color.White;
                    //        btnInsurance.Enabled = true;

                    //        txtOrderDepartment.Enabled = true;
                    //        txtOrderDepartment.BackColor = Color.White;
                    //        btnDepartment.Enabled = true;

                    //        txtThaiName.Enabled = true;
                    //        txtThaiName.BackColor = Color.White;

                    //        txtLastThaiName.Enabled = true;
                    //        txtLastThaiName.BackColor = Color.White;

                    //        txtOrderPhysician.Enabled = true;
                    //        txtOrderPhysician.BackColor = Color.White;
                    //        btnPhysician.Enabled = true;

                    //        txtEngName.Enabled = true;
                    //        txtEngName.BackColor = Color.White;

                    //        txtLastEngName.Enabled = true;
                    //        txtLastEngName.BackColor = Color.White;


                    //        txtDOB.Enabled = true;
                    //        txtAGE2.Enabled = true;
                    //        txtDOB.BackColor = Color.White;

                    //        cboGender.Enabled = true;
                    //        cboGender.BackColor = Color.White;

                    //        txtTelephone.Enabled = true;
                    //        txtTelephone.BackColor = Color.White;
                    //        #endregion

                    //        #region loadData
                    //        txtHN.Text = dr["hn"].ToString().Trim().ToUpper();

                    //        txtThaiName.Text = dr["tname"].ToString().Trim() + " " + dr["fname"].ToString().Trim();
                    //        txtLastThaiName.Text = dr["lname"].ToString().Trim();

                    //        txtEngName.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtThaiName.Text);
                    //        txtLastEngName.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtLastThaiName.Text);

                    //        try
                    //        {
                    //            txtAGE2.Text = dr["age"].ToString().Trim();
                    //        }
                    //        catch { txtAGE2.Text = "0"; }
                    //        try
                    //        {
                    //            txtDOB.DateTime = Convert.ToDateTime(dr["birth"].ToString().Trim());
                    //        }
                    //        catch { }

                    //        if (dr["sex"].ToString().Trim() == "1")
                    //            cboGender.SelectedIndex = 1;
                    //        else if (dr["sex"].ToString().Trim() == "2")
                    //            cboGender.SelectedIndex = 2;
                    //        else
                    //            cboGender.SelectedIndex = 0;
                    //        txtTelephone.Text = dr["tel"].ToString().Trim();
                    //        #endregion

                    //        setTextBoxAutoComplete();
                    //        //txtInsurace.Focus();
                    //        txtThaiName.Focus();
                    //    }
                    //    else
                    //    {
                    //        #region �� Order Ẻ Manual
                    //        string s = msg.ShowAlert("UID1015", env.CurrentLanguageID);
                    //        if (s == "1")
                    //        {
                    //            RIS.Forms.Order.frmOrders_Lite frm = new RIS.Forms.Order.frmOrders_Lite(this.CloseControl);
                    //            frm.Text = frm.Text;
                    //            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                    //            page.Selected = true;
                    //            int index = CloseControl.SelectedIndex;
                    //            CloseControl.TabPages.Add(page);
                    //            CloseControl.TabPages.RemoveAt(index);
                    //        }
                    //        else
                    //        {
                    //            panelMain.Enabled = true;
                    //            gridControl3.Enabled = false;
                    //            grdData.Enabled = true;

                    //            thisOrder.Demographic.Reg_UID = txtHN.Text;
                    //            thisOrder.Demographic.DataFromHIS = false;
                    //            thisOrder.Demographic.DataFromLocal = false;
                    //            thisOrder.Demographic.DataFromManual = true;

                    //            txtPatientType.Enabled = true;
                    //            txtPatientType.BackColor = Color.White;
                    //            btnPatienType.Enabled = true;

                    //            txtHN.Enabled = false;
                    //            txtHN.BackColor = defaultBackColor;
                    //            btnLookup.Enabled = false;

                    //            txtInsurace.Enabled = true;
                    //            txtInsurace.BackColor = Color.White;
                    //            btnInsurance.Enabled = true;

                    //            txtOrderDepartment.Enabled = true;
                    //            txtOrderDepartment.BackColor = Color.White;
                    //            btnDepartment.Enabled = true;

                    //            txtThaiName.Enabled = true;
                    //            txtThaiName.BackColor = Color.White;

                    //            txtLastThaiName.Enabled = true;
                    //            txtLastThaiName.BackColor = Color.White;

                    //            txtOrderPhysician.Enabled = true;
                    //            txtOrderPhysician.BackColor = Color.White;
                    //            btnPhysician.Enabled = true;

                    //            txtEngName.Enabled = true;
                    //            txtEngName.BackColor = Color.White;

                    //            txtLastEngName.Enabled = true;
                    //            txtLastEngName.BackColor = Color.White;


                    //            txtDOB.Enabled = true;
                    //            txtAGE2.Enabled = true;
                    //            txtDOB.BackColor = Color.White;

                    //            cboGender.Enabled = true;
                    //            cboGender.BackColor = Color.White;

                    //            txtTelephone.Enabled = true;
                    //            txtTelephone.BackColor = Color.White;

                    //            setTextBoxAutoComplete();
                    //            //txtInsurace.Focus();
                    //            txtThaiName.Focus();
                    //        }
                    //        #endregion
                    //    }
                    //} 
                    #endregion
                    LoadHN();
                }
            }
        }

        private void LoadHN()
        {
            #region old code
            //if (txtHN.Text.StartsWith("M", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    thisOrder = new order(txtHN.Text);
            //    if (thisOrder.Demographic.HasHN)
            //    {
            //        #region �֧�����Ũҡ Local 㹵��ҧ HIS_REGISTRATION
            //        fillDemographicmodeNew();
            //        gridView1.Focus();

            //        if (txtLastThaiName.Text != null && txtLastThaiName.Text.Trim() == "")
            //            txtLastThaiName.Text = ".";
            //        if (txtLastThaiName.Text != null && txtLastEngName.Text.Trim() == "")
            //            txtLastEngName.Text = ".";
            //        #endregion
            //    }
            //    else
            //    {
            //        LoadManual();
            //    }
            //}
            //else if (txtHN.Text.StartsWith("L", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    thisOrder = new order(txtHN.Text);
            //    if (thisOrder.Demographic.HasHN)
            //    {
            //        #region �֧�����Ũҡ Local 㹵��ҧ HIS_REGISTRATION
            //        fillDemographicmodeNew();
            //        gridView1.Focus();
            //        #endregion
            //    }
            //    else
            //    {
            //        DataSet ds = GetDemographicLabor_II(txtHN.Text);
            //        if (ds != null && ds.Tables[0].Rows.Count > 0)
            //        {
            //            DataRow dr = ds.Tables[0].Rows[0];

            //            #region loadControl
            //            panelMain.Enabled = true;
            //            gridControl3.Enabled = false;
            //            grdData.Enabled = true;

            //            thisOrder.Demographic.Reg_UID = txtHN.Text;
            //            thisOrder.Demographic.DataFromHIS = false;
            //            thisOrder.Demographic.DataFromLocal = false;
            //            thisOrder.Demographic.DataFromManual = true;

            //            txtPatientType.Enabled = true;
            //            txtPatientType.BackColor = Color.White;
            //            btnPatienType.Enabled = true;

            //            txtHN.Enabled = false;
            //            txtHN.BackColor = defaultBackColor;
            //            btnLookup.Enabled = false;

            //            txtInsurace.Enabled = true;
            //            txtInsurace.BackColor = Color.White;
            //            btnInsurance.Enabled = true;

            //            txtOrderDepartment.Enabled = true;
            //            txtOrderDepartment.BackColor = Color.White;
            //            btnDepartment.Enabled = true;

            //            //txtThaiName.Enabled = true;
            //            //txtThaiName.BackColor = Color.White;
            //            txtThaiName.Enabled = false;
            //            txtThaiName.BackColor = Color.Gray;

            //            txtLastThaiName.Enabled = true;
            //            txtLastThaiName.BackColor = Color.White;

            //            txtOrderPhysician.Enabled = true;
            //            txtOrderPhysician.BackColor = Color.White;
            //            btnPhysician.Enabled = true;

            //            txtEngName.Enabled = true;
            //            txtEngName.BackColor = Color.White;

            //            txtLastEngName.Enabled = true;
            //            txtLastEngName.BackColor = Color.White;


            //            //txtDOB.Enabled = true;
            //            //txtAGE2.Enabled = true;
            //            //txtDOB.BackColor = Color.White;
            //            txtDOB.Enabled = false;
            //            txtDOB.BackColor = Color.Gray;
            //            txtAGE2.Enabled = false;
            //            txtAGE2.BackColor = Color.Gray;

            //            //cboGender.Enabled = true;
            //            //cboGender.BackColor = Color.White;
            //            cboGender.Enabled = false;
            //            cboGender.BackColor = Color.Gray;

            //            txtTelephone.Enabled = true;
            //            txtTelephone.BackColor = Color.White;

            //            #endregion

            //            #region loadData
            //            //txtHN.Text = dr["hn"].ToString().Trim().ToUpper();

            //            txtThaiName.Text = dr["name"].ToString().Trim();
            //            txtLastThaiName.Text = dr["fname"].ToString().Trim();

            //            txtEngName.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtThaiName.Text);
            //            txtLastEngName.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtLastThaiName.Text);

            //            try
            //            {
            //                txtAGE2.Text = dr["age"].ToString().Trim();
            //            }
            //            catch { txtAGE2.Text = "0"; }
            //            try
            //            {
            //                for (int i = 0; i < 2; i++)
            //                    txtDOB.DateTime = Convert.ToDateTime(dr["birth"].ToString().Trim());
            //                if (txtDOB.DateTime.Year != DateTime.Now.Year)
            //                {
            //                    txtAGE2.Text = (DateTime.Now.Year - txtDOB.DateTime.Year).ToString();
            //                }
            //            }
            //            catch { }

            //            if (dr["sex"].ToString().Trim() == "1")
            //                cboGender.SelectedIndex = 1;
            //            else if (dr["sex"].ToString().Trim() == "2")
            //                cboGender.SelectedIndex = 2;
            //            else
            //                cboGender.SelectedIndex = 0;
            //            txtTelephone.Text = dr["tel"].ToString().Trim();
            //            #endregion

            //            setTextBoxAutoComplete();
            //            //txtInsurace.Focus();
            //            txtThaiName.Focus();
            //        }
            //        else
            //        {
            //            LoadManual();
            //        }
            //    }
            //}
            //else
            //{
            #endregion
            string realHN = txtHN.Text;
                thisOrder = new order(realHN);
                if (!thisOrder.Demographic.LinkDown)
                {
                    #region ����ö����������ҡѺ�к� HIS ��
                    if (thisOrder.Demographic.DataFromHIS)
                    {
                        thisOrder.Demographic.Reg_UID = txtHN.Text;
                        fillDemographicmodeNew();
                    }
                    else
                    {
                        thisOrder = new order(txtHN.Text);
                        if (thisOrder.Demographic.HasHN)
                        {
                            #region �֧�����Ũҡ Local 㹵��ҧ HIS_REGISTRATION
                            fillDemographicmodeNew();
                            gridView1.Focus();
                            #endregion
                        }
                        else
                        {
                            LoadManual();
                        }

                        //msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                        //panelMain.Enabled = false;
                        //string hnTmp = txtHN.Text;
                        //thisOrder = new order();
                        //clearContexInControl();
                        //setEnableDisableControl(false);
                        //setBackColor(defaultBackColor);
                        //setForeColor(defaultForeColor);
                        //setInitalVariable();
                        //setGridData();
                        //setGridOrder();
                        //txtHN.Enabled = true;
                        //txtHN.BackColor = Color.White;
                        //btnLookup.Enabled = true;
                        //txtHN.Focus();
                    }
                    return;
                    #endregion
                }

                thisOrder = new order(txtHN.Text);
                if (thisOrder.Demographic.HasHN)
                {
                    #region �֧�����Ũҡ Local 㹵��ҧ HIS_REGISTRATION
                    fillDemographicmodeNew();
                    gridView1.Focus();
                    #endregion
                }
                else
                {
                    LoadManual();
                }
            //}
        }
        private void LoadManual()
        {
            #region �� Order Ẻ Manual
            string s = msg.ShowAlert("UID1015", env.CurrentLanguageID);
            if (s == "1")
            {
                //RIS.Forms.Order.frmOrders_Lite frm = new RIS.Forms.Order.frmOrders_Lite("New",this.CloseControl);
                //frm.Text = frm.Text;
                //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                //page.Selected = true;
                //int index = CloseControl.SelectedIndex;
                //CloseControl.TabPages.Add(page);
                //CloseControl.TabPages.RemoveAt(index);
                frmOrdersSelectMode("New");
                txtHN.Focus();
            }
            else
            {
                layoutGroupDetail.Enabled = true;
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

                txtInsurace.Enabled = true;
                txtInsurace.BackColor = Color.White;
                btnInsurance.Enabled = true;

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
                txtAGE2.Enabled = true;
                txtAGE2.BackColor = Color.White;
                txtDOB.BackColor = Color.White;

                cboGender.Enabled = true;
                cboGender.BackColor = Color.White;

                txtTelephone.Enabled = true;
                txtTelephone.BackColor = Color.White;

                setTextBoxAutoComplete();
                //txtInsurace.Focus();
                txtThaiName.Focus();
            }
            #endregion
        }
        //public DataSet GetDemographicLabor(string LHN)
        //{
        //    string connectionString = "server=192.168.1.11;database=raja;user id=xray;password=xray";

        //    #region oldcode
        //    //            string query = @"
        //    //                          select
        //    //                                l_date 		as birth,
        //    //                                l_ini		as ini_name,
        //    //                                l_tname		as name,
        //    //                                l_tsur		as fname,
        //    //                                l_cid		as cid,
        //    //                                l_age		as age,
        //    //                                ' '		    as addr,
        //    //                                ' '		    as addrmu,
        //    //                                ' '		    as soi,
        //    //                                ' '		    as street,
        //    //                                ' '		    as town,
        //    //                                ' '		    as district_text,
        //    //                                ' '		    as province_text,
        //    //                                ' '		    as zip,
        //    //                                l_phone		as tel,
        //    //                                ' '		    as contact,
        //    //                                l_sex		as sex,
        //    //                                l_nation	as nation,
        //    //                                l_com		as cont_pers,
        //    //                                ' '		    as type_pat,
        //    //                                ' '		    as bloodgroup,
        //    //                                ' '		    as religion,
        //    //                                ' '		    as cont_code,
        //    //                                ' '		    as last_come,
        //    //                                ' '		    as an,
        //    //                                ' '         as oldhn,
        //    //                                ' '         as visit_no,
        //    //                                ' '         as ref_doc,
        //    //                                ' '         as ref_unit 
        //    //                            from
        //    //                                LABHIT
        //    //                            where  L_HN ='" + LHN + "'";
        //    #endregion

        //    string query = "select "
        //                        + "l_hn as hn, "
        //                        + "l_date as birth, "
        //                        + "l_ini as tname, "
        //                        + "l_tname as fname, "
        //                        + "l_tsur as lname, "
        //                        + "l_age as age, "
        //                        + "l_phone as tel, "
        //                        + "l_sex as sex "
        //                    + "from LABHIT "
        //                    + "where  L_HN ='" + LHN + "' "
        //                    + "order by  L_HN desc ";
        //    DataSet ds = null;
        //    try
        //    {
        //        NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connectionString);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = null;
        //    }
        //    return ds;
        //}
        //public DataSet GetDemographicLabor_II(string HN)
        //{
        //    //RIS.BusinessLogic.Common.HISService.Service proxy;
        //    //proxy = new RIS.BusinessLogic.Common.HISService.Service();
        //    RIS.BusinessLogic.Common.RamaService.Service proxy;
        //    proxy = new RIS.BusinessLogic.Common.RamaService.Service();

        //    DataSet ds = null;
        //    if (HN.Length == 0) return ds;
        //    //if (HN[0] == 'L')
        //    //{
        //    //    //��Ѻ���Ϳ�Ŵ��������͹�Ѻ Demographic.
        //        ds = proxy.GetDemographicLabor(HN);
        //    //}
        //    //else
        //    //    ds = proxy.GetDemographic(HN);

        //    return ds;
        //}
        //public DataSet GetFoxpro(string HN)
        //{
        //    return new DataSet();
        //}

        private void txtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int result;
            if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar != 13 && !int.TryParse(e.KeyChar.ToString(), out result))
                e.Handled = true;
            else if ((int)e.KeyChar == 13)
            {
                if (txtOrderNo.Text.Trim().Length > 0)
                {
                    int orderID = Convert.ToInt32(txtOrderNo.Text);
                    if (order.HasOrder(orderID))
                    {
                        thisOrder = new order(orderID);
                        fillDemographicmodeEdit();
                    }
                    else {
                        msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                        layoutGroupDetail.Enabled = false;
                        string hnTmp = txtHN.Text;
                        thisOrder = new order();
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
                
                if (txtInsurace.Text.Trim().Length > 0)
                    txtEngName.Focus();
                else
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
                DataTable dtt = order.Ris_InsuranceType();
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
                    e.Cancel = true;//����������
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
                DataTable dtt = order.His_Department();// myOrder.HIS_Department();
                DataRow d = null;
                foreach (DataRow dr in dtt.Rows)//UNIT_NAME
                {
                    if (txtOrderDepartment.Text.Trim().ToUpper() == dr["UNIT_UID"].ToString().Trim().ToUpper() + ":" + dr["UNIT_NAME"].ToString().Trim().ToUpper())
                    {
                        txtOrderDepartment.Tag = dr["UNIT_ID"].ToString();
                        txtOrderDepartment.Text = dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString();
                        txtOrderDept.Text = dr["PHONE_NO"].ToString();
                        flag = false;
                        d = dr;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1012", env.CurrentLanguageID);
                    e.Cancel = true;//����������
                }
                else
                {
                    e.Cancel = false;
                    setTextBoxAutoComplete();
                    txtOrderPhysician.Focus();
                }
            }
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
                DataTable dtt = order.His_Doctor();// myOrder.HIS_Doctor();
                DataRow d = null;
                foreach (DataRow dr in dtt.Rows)
                {
                    if (txtOrderPhysician.Text.Trim().ToUpper() == dr["RadioName"].ToString().Trim().ToUpper())
                    {
                        txtOrderPhysician.Tag = dr["EMP_ID"].ToString();
                        txtOrderPhysician.Text = dr["RadioName"].ToString();
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
                    e.Cancel = true;//����������
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
                DataTable dtt = order.RIS_PatStatus();// myOrder.RIS_PATSTATUS();
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
                    e.Cancel = true;//����������
                }
                else
                {
                    e.Cancel = false;
                }

            }
        }

        private void txtThaiName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                //SendKeys.Send("{Tab}");
                txtLastThaiName.Focus();
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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                //SendKeys.Send("{Tab}");
                txtEngName.Focus();
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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtLastEngName.Focus();
                //SendKeys.Send("{Tab}");

        }

        private void txtLastEngName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
              
                //if (cboGender.Enabled)
                //    cboGender.Focus();
                //else
                //    txtTelephone.Focus();
                    //SendKeys.Send("{Tab}");
                txtAGE2.Focus();
            }
        }

        private void txtDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtTelephone.Focus();
                //SendKeys.Send("{Tab}");

        }

        private void txtTelephone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                //txtPatientType.Focus();
                //SendKeys.Send("{Tab}");
                //view1.Focus();
                gridView1.Focus();

        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                //SendKeys.Send("{Tab}");
                txtDOB.Focus();

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
            txtAGE2.ForeColor = clr;
        }
        private void setBackColor(Color clr) {
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
            txtAGE2.BackColor = clr;
        }
        private void setInitalVariable() {
            dttUpdate = null;
            env.CountImg = "";
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
        private void setEnableDisableControl(bool flag) {

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
            txtAGE2.Enabled = flag;
            txtTelephone.Enabled = flag;
            txtNextAppointment.Enabled = flag; 
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
            layoutGroupDetail.Enabled = flag;
            #endregion

            #region Frequently Used Exam
            gridControl1.Enabled = flag;
            #endregion
        }
        private void setEnableForManual()
        {
            txtHN.Text = "AUTO";

            #region Set Enable
            layoutGroupDetail.Enabled = true;

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
            txtAGE2.Enabled = true;
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

            //gridControl3.Enabled = false;
            btnLookup.Enabled = false;
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
            txtThaiName.Text = txtLastThaiName.Text = string.Empty;
            txtEngName.Text = txtLastEngName.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtAGE2.Text = "";
            txtOrderPhysician.Text = txtOrderDepartment.Text = string.Empty;
            txtOrderDept.Text = string.Empty;
            txtPatientType.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtInsurace.Text = string.Empty;
            txtTempInsurance.Text = txtInsurace.Text;
            txtLastVisit.Text = txtNextAppointment.Text = string.Empty;
            txtAGE.Text = string.Empty;
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
       
        private void setTextBoxAutoComplete()
        {
            try
            {
                AutoCompleteStringCollection Dep = new AutoCompleteStringCollection();
                AutoCompleteStringCollection Doc = new AutoCompleteStringCollection();
                AutoCompleteStringCollection Tel = new AutoCompleteStringCollection();
                AutoCompleteStringCollection Insure = new AutoCompleteStringCollection();
                AutoCompleteStringCollection Pat = new AutoCompleteStringCollection();

                DataTable dtt = new DataTable();
                dtt = order.His_Department();
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    Dep.Add(dtt.Rows[i]["UNIT_UID"].ToString() + ":" + dtt.Rows[i]["UNIT_NAME"].ToString());
                }

                dtt = new DataTable();
                dtt = order.His_Doctor();
                for (int i = 0; i < dtt.Rows.Count; i++)
                    Doc.Add(dtt.Rows[i]["RadioName"].ToString());

                txtOrderDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtOrderDepartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtOrderDepartment.AutoCompleteCustomSource = Dep;

                txtOrderPhysician.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtOrderPhysician.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtOrderPhysician.AutoCompleteCustomSource = Doc;

                dtt = new DataTable();
                dtt = order.Ris_InsuranceType();
                for (int i = 0; i < dtt.Rows.Count; i++)
                    Insure.Add(dtt.Rows[i]["INSURANCE_TYPE_DESC"].ToString());
                txtInsurace.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtInsurace.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtInsurace.AutoCompleteCustomSource = Insure;


                dtt = new DataTable();
                dtt = order.RIS_PatStatus(); 
                for (int i = 0; i < dtt.Rows.Count; i++)
                    Pat.Add(dtt.Rows[i]["STATUS_TEXT"].ToString());
                txtPatientType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPatientType.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPatientType.AutoCompleteCustomSource = Pat;

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
                dtt = order.His_Doctor();
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
            //return RIS.BusinessLogic.Order.GenHN();
            return order.GenHN();
        }

        #region Fill Demographic by new order
        /// <summary>
        /// This method use to fill demographic by new order mode
        /// </summary>
        private void fillDemographicmodeNew()
        {
            setGridOrder();
            setTextBoxAutoComplete();

            //string reg_uid = thisOrder.Demographic.Reg_UID.Replace("M", "");
            //reg_uid = reg_uid.Replace("-52","");

            txtHN.Text = thisOrder.Demographic.Reg_UID;
            //txtHN.Text = reg_uid;
            thisOrder.Demographic.Reg_UID = txtHN.Text;
            txtThaiName.Text = thisOrder.Demographic.FirstName;
            txtLastThaiName.Text = thisOrder.Demographic.LastName;
            txtEngName.Text = thisOrder.Demographic.FirstName_ENG;
            txtLastEngName.Text = thisOrder.Demographic.LastName_ENG;
            if (thisOrder.Demographic.DateOfBirth == DateTime.MinValue
                || thisOrder.Demographic.DateOfBirth.Year < 1800)
            {
                if (thisOrder.Demographic.Age != null && thisOrder.Demographic.Age != 0)
                {
                    txtDOB.ResetText();
                    txtDOB.Enabled = true;
                    txtDOB.BackColor = Color.White;
                    txtAGE2.Text = thisOrder.Demographic.Age.ToString().Trim();
                    txtDOB.DateTime = new DateTime(DateTime.Now.Year - Convert.ToInt32(txtAGE2.Text), 1, 1);
                }
                else
                {
                    txtDOB.ResetText();
                    txtDOB.Enabled = true;
                    txtDOB.BackColor = Color.White;
                    txtAGE.Text = "";
                    txtAGE2.Text = "0";
                    txtDOB.DateTime = new DateTime(DateTime.Now.Year, 1, 1).ToLocalTime();
                }
            }
            else
            {
                DateTime _dob = new DateTime(
                    thisOrder.Demographic.DateOfBirth.Year
                    , thisOrder.Demographic.DateOfBirth.Month
                    , thisOrder.Demographic.DateOfBirth.Day);
                //txtDOB.Text = _dob.Day + "/" + _dob.Month + "/" + _dob.Year;
                txtDOB.DateTime = new DateTime(_dob.Year, _dob.Month, _dob.Day);
                txtDOB.DateTime = txtDOB.DateTime.AddDays(_dob.Day - 1);
                txtDOB.DateTime = txtDOB.DateTime.AddMonths(_dob.Month - 1);
                LookUpSelect lus = new LookUpSelect();
                if (thisOrder.Demographic.Age != null && thisOrder.Demographic.Age != 0)
                    txtAGE2.Text = thisOrder.Demographic.Age.ToString().Trim();
                else
                    txtAGE2.Text = (DateTime.Now.Year - thisOrder.Demographic.DateOfBirth.Year).ToString();
                //txtAGE.Text = lus.SelectAGE(thisOrder.Demographic.DateOfBirth).Tables[0].Rows[0][0].ToString();
                //txtAGE2.Text = lus.SelectAGE(thisOrder.Demographic.DateOfBirth).Tables[0].Rows[0][0].ToString();
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
            txtNextAppointment.Text = string.Empty;
            txtOrderDepartment.Tag = thisOrder.Item.REF_UNIT;
            txtOrderPhysician.Tag = thisOrder.Item.REF_DOC;
            txtPatientType.Tag = thisOrder.Item.PAT_STATUS;
            DataTable dtt = null;
            if (txtOrderDepartment.Tag != null)
            {
                dtt = order.His_Department();
                foreach (DataRow drUnit in dtt.Rows)
                {
                    if (drUnit["UNIT_ID"].ToString() == txtOrderDepartment.Tag.ToString())
                    {
                        txtOrderDepartment.Text = drUnit["UNIT_UID"].ToString() + ":" + drUnit["UNIT_NAME"].ToString();
                        txtOrderDept.Text = drUnit["PHONE_NO"].ToString();
                    }
                }
            }
            if (txtOrderDepartment.Tag != null)
            {
                dtt = order.His_Doctor();
                foreach (DataRow drDoc in dtt.Rows)
                {
                    if (drDoc["EMP_ID"].ToString() == txtOrderPhysician.Tag.ToString())
                        txtOrderPhysician.Text = drDoc["RadioName"].ToString();
                }
            }
            string str = thisOrder.Demographic.Insurance_Type == null ? string.Empty : thisOrder.Demographic.Insurance_Type.Trim();
            if(str!=string.Empty)
            {
                dtt = order.Ris_InsuranceType();
                bool flag = true;
                if (thisOrder.Demographic.DataFromHIS)
                {
                    foreach (DataRow drIns in dtt.Rows)
                    {
                        if (drIns["INSURANCE_TYPE_UID"].ToString() == thisOrder.Demographic.Insurance_Type)
                        {
                            txtInsurace.Tag = drIns["INSURANCE_TYPE_ID"].ToString();
                            txtInsurace.Text = drIns["INSURANCE_TYPE_DESC"].ToString();
                            txtTempInsurance.Text = txtInsurace.Text;
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (DataRow drIns in dtt.Rows)
                    {
                        if (drIns["INSURANCE_TYPE_ID"].ToString() == thisOrder.Demographic.Insurance_Type)
                        {
                            txtInsurace.Tag = drIns["INSURANCE_TYPE_ID"].ToString();
                            txtInsurace.Text = drIns["INSURANCE_TYPE_DESC"].ToString();
                            txtTempInsurance.Text = txtInsurace.Text;
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    //string s = msg.ShowAlert("UID1032", env.CurrentLanguageID);
                    thisOrder.Demographic.Insurance_Type = string.Empty;
                    thisOrder.Demographic.InsuranceID = 0;
                }
            }
            if (txtPatientType.Tag != null)
            {
                dtt = order.RIS_PatStatus();
                foreach (DataRow drPat in dtt.Rows)
                {
                    if (drPat["STATUS_ID"].ToString() == txtPatientType.Tag.ToString())
                        txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
                }
            }
            else
            {
                dtt = order.RIS_PatStatus();
                foreach (DataRow drPat in dtt.Rows)
                {
                    if (drPat["IS_DEFAULT"].ToString() == "Y")
                    {
                        txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
                        txtPatientType.Tag = drPat["STATUS_ID"].ToString();
                    }
                }
            }
            layoutGroupDetail.Enabled = true;
            calTotal();

            txtOrderDepartment.Enabled = true;
            txtOrderPhysician.Enabled = true;
            txtInsurace.Enabled = true;
            txtPatientType.Enabled = true;
            txtTelephone.Enabled = true;
            txtEngName.Enabled = true;
            txtLastEngName.Enabled = true;
            btnPhysician.Enabled = true;
            btnInsurance.Enabled = true;
            btnDepartment.Enabled = true;
            btnPatienType.Enabled = true;

            txtOrderDepartment.BackColor = Color.White;
            txtOrderPhysician.BackColor= Color.White;
            txtInsurace.BackColor = Color.White;
            txtPatientType.BackColor = Color.White;
            txtTelephone.BackColor = Color.White;
            txtEngName.BackColor = Color.White;
            txtLastEngName.BackColor = Color.White;
            txtCopies.BackColor = Color.White;
            setForeColor(Color.Black);
            if (mode == "Last")
            {
                thisOrder.LastOrder(env.UserID);
                setGridData();
            }
            //txtOrderDepartment.Focus();

            txtThaiName.Enabled = true;
            txtLastThaiName.Enabled = true;

            txtAGE2.Enabled = true;
            cboGender.Enabled = true;

            txtThaiName.ForeColor = Color.Black;
            txtLastThaiName.ForeColor = Color.Black;
            txtAGE2.ForeColor = Color.Black;
            cboGender.ForeColor = Color.Black;

            txtThaiName.BackColor = Color.White;
            txtLastThaiName.BackColor = Color.White;
            txtAGE2.BackColor = Color.White;
            cboGender.BackColor = Color.White;

            txtThaiName.Text = txtThaiName.Text.Trim();
            txtLastThaiName.Text = txtLastThaiName.Text.Trim();
            txtEngName.Text = txtEngName.Text.Trim();
            txtLastEngName.Text = txtLastEngName.Text.Trim();

            txtTelephone.Text = txtTelephone.Text.Trim();

            txtDOB.Enabled = true;
            txtDOB.BackColor = Color.White;

            txtHN.Enabled = false;
            txtHN.ForeColor = Color.Black;
            txtHN.BackColor = defaultBackColor;

            txtAGE.Enabled = false;
            txtAGE.BackColor = defaultBackColor;
            txtAGE2.Enabled = false;
            txtAGE2.BackColor = defaultBackColor;

            cboGender.Enabled = true;
            cboGender.BackColor = Color.White;
            txtThaiName.Enabled = false;
            txtThaiName.BackColor = defaultBackColor;
            txtLastThaiName.Enabled = false;
            txtLastThaiName.BackColor = defaultBackColor;

            txtOrderDepartment.Text = thisOrder.Demographic.Department_Name;
        }
        #endregion

        //private void fillDemographicmodeEdit()
        //{
            
        //    dttUpdate = thisOrder.ItemDetail.Clone();
        //    txtOrderNo.Text = thisOrder.Item.ORDER_ID.ToString();
        //    DataSet ds = thisOrder.TreeData;
        //    for (int i = 0; i < ds.Tables["Root"].Rows.Count; i++) {
        //        if (ds.Tables["Root"].Rows[i]["Level"].ToString() == "1")
        //        {
        //            ds.Tables["Root"].Rows[i].Delete();
        //            ds.AcceptChanges();
        //            break;
        //        }
        //    }
        //    thisOrder.TreeData = ds;
        //    setGridOrder();
        //    setGridData();
        //    setTextBoxAutoComplete();
        //    string hn = thisOrder.Demographic.Reg_UID.Replace("M", "").Replace("-52", "");
        //    txtHN.Text = hn;
        //    thisOrder.Demographic.Reg_UID = hn;
        //    txtThaiName.Text = thisOrder.Demographic.FirstName.Trim();
        //    txtLastThaiName.Text = thisOrder.Demographic.LastName.Trim() == "" ? "." : thisOrder.Demographic.LastName.Trim();
        //    txtEngName.Text = thisOrder.Demographic.FirstName_ENG;
        //    txtLastEngName.Text = thisOrder.Demographic.LastName_ENG;
        //    DataTable dtt = order.Ris_InsuranceType(); 
        //    foreach (DataRow drIns in dtt.Rows)
        //    {
        //        if (drIns["INSURANCE_TYPE_ID"].ToString() ==thisOrder.Demographic.InsuranceID.ToString())
        //        {
        //            txtInsurace.Tag = drIns["INSURANCE_TYPE_ID"].ToString();
        //            txtInsurace.Text = drIns["INSURANCE_TYPE_DESC"].ToString();
        //            txtTempInsurance.Text = txtInsurace.Text;
        //            break;
        //        }
        //    }
        //    //try
        //    //{
        //    //    txtAGE2.Text = dr["age"].ToString().Trim();
        //    //}
        //    //catch { txtAGE2.Text = "0"; }
        //    //try
        //    //{
        //    //    for (int i = 0; i < 2; i++)
        //    //        txtDOB.DateTime = Convert.ToDateTime(dr["birth"].ToString().Trim());
        //    //    if (txtDOB.DateTime.Year != DateTime.Now.Year)
        //    //    {
        //    //        txtAGE2.Text = (DateTime.Now.Year - txtDOB.DateTime.Year).ToString();
        //    //    }
        //    //}
        //    //catch { }
        //    if (thisOrder.Demographic.DateOfBirth == DateTime.MinValue)
        //    {
        //        txtDOB.ResetText();
        //        txtDOB.Enabled = true;
        //        txtDOB.BackColor = Color.White;
        //        txtAGE2.Text = "";
        //    }
        //    else
        //    {
        //        txtDOB.Text = thisOrder.Demographic.DateOfBirth.ToString("dd/MM/yyyy");
        //        LookUpSelect lus = new LookUpSelect();
        //        txtAGE.Text = lus.SelectAGE(thisOrder.Demographic.DateOfBirth).Tables[0].Rows[0][0].ToString();
        //        txtAGE2.Text = thisOrder.Demographic.Age.ToString();
        //    }
        //    txtTelephone.Text = thisOrder.Demographic.Phone1;
        //    if (thisOrder.Demographic.Gender == "M")
        //        cboGender.SelectedIndex = 1;
        //    else if (thisOrder.Demographic.Gender == "F")
        //    {
        //        cboGender.SelectedIndex = 2;
        //        datePeriod.Enabled = true;
        //        datePeriod.ResetText();
        //        datePeriod.BackColor = Color.White;
        //        datePeriod.DateTime = thisOrder.Item.Lmp_DT;
        //    }
        //    else
        //        cboGender.SelectedIndex = 0;
        //    txtNextAppointment.Text = "";
        //    txtOrderDept.Text = "";
        //    txtLastVisit.Text = thisOrder.Demographic.Last_Modified_ON == DateTime.MinValue ? string.Empty : thisOrder.Demographic.Last_Modified_ON.ToString("dd/MM/yyyy");
        //    txtNextAppointment.Text = string.Empty;
        //    txtOrderDepartment.Tag = thisOrder.Item.REF_UNIT;
        //    txtOrderPhysician.Tag = thisOrder.Item.REF_DOC;
        //    txtPatientType.Tag = thisOrder.Item.PAT_STATUS;
        //    if (txtOrderDepartment.Tag != null)
        //    {
        //        dtt = order.His_Department();
        //        foreach (DataRow drUnit in dtt.Rows)
        //        {
        //            if (drUnit["UNIT_ID"].ToString() == txtOrderDepartment.Tag.ToString())
        //            {
        //                txtOrderDepartment.Text = drUnit["UNIT_UID"].ToString() + ":" + drUnit["UNIT_NAME"].ToString();
        //                txtOrderDept.Text = drUnit["PHONE_NO"].ToString();
        //            }
        //        }
        //    }
        //    if (txtOrderDepartment.Tag != null)
        //    {
        //        dtt = order.His_Doctor();
        //        foreach (DataRow drDoc in dtt.Rows)
        //        {
        //            if (drDoc["EMP_ID"].ToString() == txtOrderPhysician.Tag.ToString())
        //                txtOrderPhysician.Text = drDoc["RadioName"].ToString();
        //        }
        //    }
        //    //string strIns = thisOrder.Demographic.Insurance_Type == null ? string.Empty : thisOrder.Demographic.ToString();
        //    //if (strIns != string.Empty)
        //    //{
        //    //    dtt = order.Ris_InsuranceType();
        //    //    bool flag = true;
        //    //    foreach (DataRow drIns in dtt.Rows)
        //    //    {
        //    //        if (drIns["INSURANCE_TYPE_UID"].ToString() == thisOrder.Demographic.Insurance_Type)
        //    //        {
        //    //            txtInsurace.Tag = drIns["INSURANCE_TYPE_ID"].ToString();
        //    //            thisOrder.Demographic.InsuranceID = Convert.ToInt32(drIns["INSURANCE_TYPE_ID"]);
        //    //            txtInsurace.Text = drIns["INSURANCE_TYPE_DESC"].ToString();
        //    //            flag = false;
        //    //            break;
        //    //        }
        //    //    }
        //    //    if (flag)
        //    //    {
        //    //        string s = msg.ShowAlert("UID1032", env.CurrentLanguageID);
        //    //        thisOrder.Demographic.Insurance_Type = string.Empty;
        //    //        thisOrder.Demographic.InsuranceID = 0;
        //    //    }
        //    //}
        //    if (txtPatientType.Tag != null)
        //    {
        //        dtt = order.RIS_PatStatus();
        //        foreach (DataRow drPat in dtt.Rows)
        //        {
        //            if (drPat["STATUS_ID"].ToString() == txtPatientType.Tag.ToString())
        //                txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        dtt = order.RIS_PatStatus();
        //        foreach (DataRow drPat in dtt.Rows)
        //        {
        //            if (drPat["IS_DEFAULT"].ToString() == "Y")
        //            {
        //                txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
        //                txtPatientType.Tag = drPat["STATUS_ID"].ToString();
        //            }
        //        }
        //    }
        //    panelMain.Enabled = true;
        //    calTotal();

        //    txtOrderDepartment.Enabled = true;
        //    txtOrderPhysician.Enabled = true;
        //    txtInsurace.Enabled = true;
        //    txtPatientType.Enabled = true;
        //    txtTelephone.Enabled = true;
        //    txtEngName.Enabled = true;
        //    txtLastEngName.Enabled = true;
        //    btnPhysician.Enabled = true;
        //    btnInsurance.Enabled = true;
        //    btnDepartment.Enabled = true;
        //    btnPatienType.Enabled = true;

        //    //txtThaiName.Enabled = true;
        //    //txtLastThaiName.Enabled = true;
            

        //    txtOrderDepartment.BackColor = Color.White;
        //    txtOrderPhysician.BackColor = Color.White;
        //    txtInsurace.BackColor = Color.White;
        //    txtPatientType.BackColor = Color.White;
        //    txtTelephone.BackColor = Color.White;
        //    txtEngName.BackColor = Color.White;
        //    txtLastEngName.BackColor = Color.White;
        //    txtCopies.BackColor = Color.White;
        //    setForeColor(Color.Black);
        //    txtOrderDepartment.Focus();
        //}
        #region Fill Demograhic by Edit order
        /// <summary>
        /// This method use to fill demographic by edit order mode
        /// </summary>
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
            txtThaiName.Text = thisOrder.Demographic.FirstName;
            txtLastThaiName.Text = thisOrder.Demographic.LastName;
            txtEngName.Text = thisOrder.Demographic.FirstName_ENG;
            txtLastEngName.Text = thisOrder.Demographic.LastName_ENG;
            DataTable dtt = order.Ris_InsuranceType();
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
                DateTime _dob = new DateTime(
                    thisOrder.Demographic.DateOfBirth.Year
                    , thisOrder.Demographic.DateOfBirth.Month
                    , thisOrder.Demographic.DateOfBirth.Day);
                //txtDOB.Text = _dob.Day + "/" + _dob.Month + "/" + _dob.Year;
                txtDOB.DateTime = new DateTime(_dob.Year, _dob.Month, _dob.Day);
                txtDOB.DateTime = txtDOB.DateTime.AddDays(_dob.Day - 1);
                txtDOB.DateTime = txtDOB.DateTime.AddMonths(_dob.Month - 1);
                LookUpSelect lus = new LookUpSelect();
                txtAGE.Text = lus.SelectAGE(thisOrder.Demographic.DateOfBirth).Tables[0].Rows[0][0].ToString();
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
                datePeriod.DateTime = thisOrder.Item.Lmp_DT;
            }
            else
                cboGender.SelectedIndex = 0;
            txtNextAppointment.Text = "";
            txtOrderDept.Text = "";
            txtLastVisit.Text = thisOrder.Demographic.Last_Modified_ON == DateTime.MinValue ? string.Empty : thisOrder.Demographic.Last_Modified_ON.ToString("dd/MM/yyyy");
            txtNextAppointment.Text = string.Empty;
            txtOrderDepartment.Tag = thisOrder.Item.REF_UNIT;
            txtOrderPhysician.Tag = thisOrder.Item.REF_DOC;
            txtPatientType.Tag = thisOrder.Item.PAT_STATUS;
            if (txtOrderDepartment.Tag != null)
            {
                dtt = order.His_Department();
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
                dtt = order.His_Doctor();
                foreach (DataRow drDoc in dtt.Rows)
                {
                    if (drDoc["EMP_ID"].ToString() == txtOrderPhysician.Tag.ToString())
                        txtOrderPhysician.Text = drDoc["EMP_UID"].ToString() + ":" + drDoc["RadioName"].ToString();
                }
            }
            //string strIns = thisOrder.Demographic.Insurance_Type == null ? string.Empty : thisOrder.Demographic.ToString();
            //if (strIns != string.Empty)
            //{
            //    dtt = order.Ris_InsuranceType();
            //    bool flag = true;
            //    foreach (DataRow drIns in dtt.Rows)
            //    {
            //        if (drIns["INSURANCE_TYPE_UID"].ToString() == thisOrder.Demographic.Insurance_Type)
            //        {
            //            txtInsurace.Tag = drIns["INSURANCE_TYPE_ID"].ToString();
            //            thisOrder.Demographic.InsuranceID = Convert.ToInt32(drIns["INSURANCE_TYPE_ID"]);
            //            txtInsurace.Text = drIns["INSURANCE_TYPE_DESC"].ToString();
            //            flag = false;
            //            break;
            //        }
            //    }
            //    if (flag)
            //    {
            //        string s = msg.ShowAlert("UID1032", env.CurrentLanguageID);
            //        thisOrder.Demographic.Insurance_Type = string.Empty;
            //        thisOrder.Demographic.InsuranceID = 0;
            //    }
            //}
            if (txtPatientType.Tag != null)
            {
                dtt = order.RIS_PatStatus();
                foreach (DataRow drPat in dtt.Rows)
                {
                    if (drPat["STATUS_ID"].ToString() == txtPatientType.Tag.ToString())
                        txtPatientType.Text = drPat["STATUS_TEXT"].ToString();
                }
            }
            else
            {
                dtt = order.RIS_PatStatus();
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
                //txtPreparation.Tag = null;
                //txtPreparation.Text = "";
            }
            else
            {
                LookUpSelect lvS = new LookUpSelect();
                DataRow[] drPre = lvS.ScheduleNotParameter("Prepation").Tables[0].Select("PREPARATION_ID=" + thisOrder.ItemDetail.Rows[0]["PREPARATION_ID"].ToString());
                //txtPreparation.Tag = Convert.ToInt32(drPre[0]["PREPARATION_ID"]);
                //txtPreparation.Text = drPre[0]["PREPARATION_DESC"].ToString();
            }

            layoutGroupDetail.Enabled = true;
            calTotal();

            txtOrderDepartment.Enabled = true;
            txtOrderPhysician.Enabled = true;
            txtInsurace.Enabled = true;
            txtPatientType.Enabled = true;
            txtTelephone.Enabled = true;
            txtEngName.Enabled = true;
            txtLastEngName.Enabled = true;
            //txtPreparation.Enabled = true;
            btnPhysician.Enabled = true;
            btnInsurance.Enabled = true;
            btnDepartment.Enabled = true;
            btnPatienType.Enabled = true;
            //btnPrepation.Enabled = true;

            txtOrderDepartment.BackColor = Color.White;
            txtOrderPhysician.BackColor = Color.White;
            txtInsurace.BackColor = Color.White;
            txtPatientType.BackColor = Color.White;
            txtTelephone.BackColor = Color.White;
            txtEngName.BackColor = Color.White;
            txtLastEngName.BackColor = Color.White;
            txtCopies.BackColor = Color.White;
            //txtPreparation.BackColor = Color.White;
            setForeColor(Color.Black);
            txtOrderDepartment.Focus();

            DataRow[] drChk = thisOrder.ItemDetail.Select("STATUS = 'F' OR STATUS = 'P'");
            if (drChk.Length > 0)
            {
                btnSave.Enabled = false;
                btnSaveSame.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnSaveSame.Enabled = true;
            }
            cboGender.Enabled = true;
            cboGender.BackColor = Color.White;

            txtDOB.Enabled = true;
            txtDOB.BackColor = Color.White;

            txtAGE.Enabled = true;
            txtAGE.BackColor = Color.White;
           
        }
        #endregion
        private void fillDemographicmodeManual()
        {
            txtHN.Text = "AUTO";
            #region Set Enable 
            layoutGroupDetail.Enabled = true;
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

            cboGender.BackColor = Color.White;

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

            #region �� Demographic 
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
                //msg.ShowAlert("UID1012", env.CurrentLanguageID);
                //txtOrderDepartment.Focus();
                //return false;
            }
            if (false)//txtOrderPhysician.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID5000", env.CurrentLanguageID);
                txtOrderPhysician.Focus();
                return false;
            }

            if (txtAGE2.Text == "" || txtAGE2.Text == "0")//(txtAGE2.SelectedIndex == -1 || txtAGE2.SelectedIndex == 0 || txtAGE2.SelectedIndex == 1)
            {
                msg.ShowAlert("UID2125", env.CurrentLanguageID);
                txtAGE2.Focus();
                return false;
            }
            if (cboGender.Text.Trim() == "")//(cboGender.SelectedIndex == -1 ||cboGender.SelectedIndex == 0)
            {
                msg.ShowAlert("UID2126", env.CurrentLanguageID);
                cboGender.Focus();
                return false;
            }

            #endregion

            if (orderManger.Count > 0)
            {
                #region �ó��ա�÷� Order Ẻ Same Patient 
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
                #region ��㹡óշ������ա�� Add Same Patient 
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
          
            return flag;
        }
        private bool checkRequireModeCreateSamePatient() {
            bool flag = true;

            #region �� Demographic 
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
                //msg.ShowAlert("UID1012", env.CurrentLanguageID);
                //txtOrderDepartment.Focus();
                //return false;
            }
            if (false)//txtOrderPhysician.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID5000", env.CurrentLanguageID);
                txtOrderPhysician.Focus();
                return false;
            }

            if (txtAGE2.Text == "" || txtAGE2.Text == "0")
            {
                msg.ShowAlert("UID2025", env.CurrentLanguageID);
                txtAGE2.Focus();
                return false;
            }
            if (cboGender.Text.Trim() == "")
            {
                msg.ShowAlert("UID2026", env.CurrentLanguageID);
                cboGender.Focus();
                return false;
            }

            #endregion

            #region ��Ǩ�ͺ�����������㹡�Դ 
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
        private bool checkRequireModeEdit() {
            bool flag = false;

            #region �� Demographic 
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
                //msg.ShowAlert("UID1012", env.CurrentLanguageID);
                //txtOrderDepartment.Focus();
                //return false;
            }
            if (false)//txtOrderPhysician.Text.Trim() == string.Empty)
            {
                msg.ShowAlert("UID5000", env.CurrentLanguageID);
                txtOrderPhysician.Focus();
                return false;
            }

            if (txtAGE2.Text == "" || txtAGE2.Text == "0")//(txtAGE2.SelectedIndex == -1 || txtAGE2.SelectedIndex == 0 || txtAGE2.SelectedIndex == 1)
            {
                msg.ShowAlert("UID2125", env.CurrentLanguageID);
                txtAGE2.Focus();
                return false;
            }
            if (cboGender.Text.Trim() == "")//(cboGender.SelectedIndex == -1 ||cboGender.SelectedIndex == 0)
            {
                msg.ShowAlert("UID2126", env.CurrentLanguageID);
                cboGender.Focus();
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
                return  false;               

            }
            return true;
        }

        private bool insertData()
        {
            bool flag = true;
            try
            {
                int count = 0;
                while (count < orderManger.Count) 
                {
                    //orderManger[count].his.AGE = Convert.ToInt32(txtAGE2.Text);
                    //orderManger[count].his.GENDER = cboGender.Text.Trim().Substring(0, 1);
                    //orderManger[count].his.DOB = txtDOB.DateTime;
                    orderManger[count].His_Registratiion.AGE = Convert.ToInt32(txtAGE2.Text);
                    orderManger[count].His_Registratiion.GENDER = cboGender.Text.Trim().Substring(0, 1);
                    orderManger[count].His_Registratiion.DOB = txtDOB.DateTime;

                    orderManger[count].Demographic.Age = Convert.ToInt32(txtAGE2.Text);
                    orderManger[count].Demographic.Gender = cboGender.Text.Trim().Substring(0, 1);
                    orderManger[count].Demographic.DateOfBirth = txtDOB.DateTime;

                    //orderManger[count].Demographic.Department_Name = "�ٹ���Ǩ���ҹ仵�ҧ�����";

                    flag = orderManger[count].Invoke();
                    if (!flag)
                        break;
                    count=0;
                    orderManger.RemoveAt(0);
                }
                if (flag)
                {
                    //defaultBackColor = txtLastVisit.BackColor;
                    //defaultForeColor = btnPhysician.ForeColor;
                    lblOrderNo.Visible = true;
                    txtOrderNo.Visible = true;
                    btnLookUpNo.Visible = true;
                    cboGender.SelectedIndex = 0;
                    thisOrder = new order();
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
                    env.CountImg = "";
                    scheduleID = 0;
                    cboGender.Items.Clear();
                    cboGender.Items.Add(string.Empty);
                    cboGender.Items.Add("Male");
                    cboGender.Items.Add("Female");
                    cboGender.SelectedIndex = 0;
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
                    else {
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
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            }
            return flag;
        }
        private bool insertDataByPrintPreview() {
            bool flag = true;
            try
            {
                int count = 0;
                while (count < orderManger.Count)
                {
                    //orderManger[count].his.AGE = Convert.ToInt32(txtAGE2.Text);
                    //orderManger[count].his.GENDER = cboGender.Text.Trim().Substring(0, 1);
                    //orderManger[count].his.DOB = txtDOB.DateTime;
                    orderManger[count].His_Registratiion.AGE = Convert.ToInt32(txtAGE2.Text);
                    orderManger[count].His_Registratiion.GENDER = cboGender.Text.Trim().Substring(0, 1);
                    orderManger[count].His_Registratiion.DOB = txtDOB.DateTime;

                    orderManger[count].Demographic.Age = Convert.ToInt32(txtAGE2.Text);
                    orderManger[count].Demographic.Gender = cboGender.Text.Trim().Substring(0, 1);
                    orderManger[count].Demographic.DateOfBirth = txtDOB.DateTime;

                    flag = orderManger[count].Invoke();
                    if (!flag)
                        break;
                    ReportMangager rptManager = new ReportMangager();
                    RIS.Reports.ReportViewer.frmReportViewer rptViewer = new RIS.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReport(orderManger[count].Item.ORDER_ID, env.UserID), CloseControl);
                    rptViewer.Text = "Order No=" + orderManger[count].Item.ORDER_ID.ToString() + " (Print Preview.)";
                    rptViewer.StartPosition = FormStartPosition.CenterScreen;

                    UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(rptViewer.Text, rptViewer);
                    CloseControl.TabPages.Add(page);

                    count = 0;
                    orderManger.RemoveAt(0);
                }
                if (flag)
                {
                    //defaultBackColor = txtLastVisit.BackColor;
                    //defaultForeColor = btnPhysician.ForeColor;
                    lblOrderNo.Visible = true;
                    txtOrderNo.Visible = true;
                    btnLookUpNo.Visible = true;
                    cboGender.SelectedIndex = 0;
                    thisOrder = new order();
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
                        //return ��� order ����Դ���������� order manager
                        //add 1 row ����
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
                        //return ��� order ����Դ��� Top �ش ������������ Top �͡
                        //add 1 row ����
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
        private bool insertDataBySendToPrint() {
            bool flag = true;
            try
            {
                int count = 0;
                while (count < orderManger.Count)
                {
                    //orderManger[count].his.AGE = Convert.ToInt32(txtAGE2.Text);
                    //orderManger[count].his.GENDER = cboGender.Text.Trim().Substring(0, 1);
                    //orderManger[count].his.DOB = txtDOB.DateTime;
                    orderManger[count].His_Registratiion.AGE = Convert.ToInt32(txtAGE2.Text);
                    orderManger[count].His_Registratiion.GENDER = cboGender.Text.Trim().Substring(0, 1);
                    orderManger[count].His_Registratiion.DOB = txtDOB.DateTime;

                    orderManger[count].Demographic.Age = Convert.ToInt32(txtAGE2.Text);
                    orderManger[count].Demographic.Gender = cboGender.Text.Trim().Substring(0, 1);
                    orderManger[count].Demographic.DateOfBirth = txtDOB.DateTime;

                    flag = orderManger[count].Invoke();
                    if (!flag)
                        break;

                    int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                    numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                     DirectPrint print = new  DirectPrint();
                    print.OrderEntryDirectPrint(orderManger[count].Item.ORDER_ID, env.UserID, numberOfCopy);

                    count = 0;
                    orderManger.RemoveAt(0);
                }
                if (flag)
                {
                    //defaultBackColor = txtLastVisit.BackColor;
                    //defaultForeColor = btnPhysician.ForeColor;
                    lblOrderNo.Visible = true;
                    txtOrderNo.Visible = true;
                    btnLookUpNo.Visible = true;
                    cboGender.SelectedIndex = 0;
                    thisOrder = new order();
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
                        //return ��� order ����Դ���������� order manager
                        //add 1 row ����
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
                        //return ��� order ����Դ��� Top �ش ������������ Top �͡
                        //add 1 row ����
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
            //orderManger[0].his.AGE = Convert.ToInt32(txtAGE2.Text);
            //orderManger[0].his.GENDER = cboGender.Text.Trim().Substring(0, 1);
            //orderManger[0].his.DOB = txtDOB.DateTime;
            orderManger[0].His_Registratiion.AGE = Convert.ToInt32(txtAGE2.Text);
            orderManger[0].His_Registratiion.GENDER = cboGender.Text.Trim().Substring(0, 1);
            orderManger[0].His_Registratiion.DOB = txtDOB.DateTime;

            orderManger[0].Demographic.Age = Convert.ToInt32(txtAGE2.Text);
            orderManger[0].Demographic.Gender = cboGender.Text.Trim().Substring(0, 1);
            orderManger[0].Demographic.DateOfBirth = txtDOB.DateTime;

            bool flag = orderManger[0].Invoke();
            if (flag)
            {
                cboGender.SelectedIndex = 0;
                thisOrder = new order();
                orderManger = new OrderManager();
                loadFormLanguage();
                clearContexInControl();
                setEnableDisableControl(false);
                setBackColor(defaultBackColor);
                setForeColor(defaultForeColor);
                setGridData();
                setGridOrder();
            }
            else {
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
        private bool updateDataByPrintPreview() {

            //orderManger[0].his.AGE = Convert.ToInt32(txtAGE2.Text);
            //orderManger[0].his.GENDER = cboGender.Text.Trim().Substring(0, 1);
            //orderManger[0].his.DOB = txtDOB.DateTime;
            orderManger[0].His_Registratiion.AGE = Convert.ToInt32(txtAGE2.Text);
            orderManger[0].His_Registratiion.GENDER = cboGender.Text.Trim().Substring(0, 1);
            orderManger[0].His_Registratiion.DOB = txtDOB.DateTime;

            orderManger[0].Demographic.Age = Convert.ToInt32(txtAGE2.Text);
            orderManger[0].Demographic.Gender = cboGender.Text.Trim().Substring(0, 1);
            orderManger[0].Demographic.DateOfBirth = txtDOB.DateTime;

            bool flag = orderManger[0].Invoke();
            if (flag)
            {
                #region Print Preview 
                ReportMangager rptManager = new ReportMangager();
                RIS.Reports.ReportViewer.frmReportViewer rptViewer = new RIS.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReport(orderManger[0].Item.ORDER_ID, env.UserID), CloseControl);
                rptViewer.Text = "Order No=" + orderManger[0].Item.ORDER_ID.ToString() + " (Print Preview.)";
                rptViewer.StartPosition = FormStartPosition.CenterScreen;
                UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(rptViewer.Text, rptViewer);
                CloseControl.TabPages.Add(page);
                
                #endregion

                #region Clear Control 
                cboGender.SelectedIndex = 0;
                thisOrder = new order();
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
        private bool updateDataBySendToPrint() {

            //orderManger[0].his.AGE = Convert.ToInt32(txtAGE2.Text);
            //orderManger[0].his.GENDER = cboGender.Text.Trim().Substring(0, 1);
            //orderManger[0].his.DOB = txtDOB.DateTime;
            orderManger[0].His_Registratiion.AGE = Convert.ToInt32(txtAGE2.Text);
            orderManger[0].His_Registratiion.GENDER = cboGender.Text.Trim().Substring(0, 1);
            orderManger[0].His_Registratiion.DOB = txtDOB.DateTime;

            orderManger[0].Demographic.Age = Convert.ToInt32(txtAGE2.Text);
            orderManger[0].Demographic.Gender = cboGender.Text.Trim().Substring(0, 1);
            orderManger[0].Demographic.DateOfBirth = txtDOB.DateTime;
            
            bool flag = orderManger[0].Invoke();
            if (flag)
            {
                #region Send To Print 
                int numberOfCopy = Convert.ToInt32(txtCopies.Text);
                numberOfCopy = numberOfCopy < 1 ? 1 : numberOfCopy;
                 DirectPrint print = new  DirectPrint();
                print.OrderEntryDirectPrint(orderManger[0].Item.ORDER_ID, env.UserID, numberOfCopy); 
                #endregion

                #region Clear Control 
                cboGender.SelectedIndex = 0;
                thisOrder = new order();
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

        private void fillDataToCreateOrder(order Ord) 
        {
            txtOrderDepartment.Tag = 11226;
            txtOrderDepartment.Text = "�ٹ���Ǩ���ҹ��ҧ�����";

            Ord.Item.REF_UNIT = txtOrderDepartment.Tag == null || txtOrderDepartment.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderDepartment.Tag);
            Ord.Item.REF_DOC = txtOrderPhysician.Tag == null || txtOrderPhysician.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderPhysician.Tag);
            Ord.Item.INSURANCE_TYPE_ID = txtInsurace.Tag == null || txtInsurace.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtInsurace.Tag);
            Ord.Item.PAT_STATUS = txtPatientType.Tag == null || txtPatientType.Tag.ToString() == string.Empty ? string.Empty : txtPatientType.Tag.ToString();
            Ord.Item.Lmp_DT = datePeriod.DateTime;
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
            //ź Row ��ҧ
            while (i < dtt.Rows.Count) {
                if (dtt.Rows[i]["EXAM_ID"].ToString()==string.Empty) {
                    dtt.Rows[i].Delete();
                    dtt.AcceptChanges();
                    i = 0;
                }
                else
                    i++;
            }
            Ord.ItemDetail = dtt.Copy();
            Ord.Ris_OrderImage = this.thisOrder.Ris_OrderImage.Copy();
            Ord.Ris_PatICD = this.thisOrder.Ris_PatICD.Copy();

            Ord.Demographic = this.thisOrder.Demographic;
            Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            Ord.Demographic.InsuranceID = Ord.Item.INSURANCE_TYPE_ID;
            if (txtInsurace.Tag != null) {
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
            else if (Ord.Demographic.DataFromManual)
            {
                #region Manual 
                HISRegistration his = new HISRegistration();
                if (txtHN.Tag == null)
                    if (txtHN.Text != string.Empty)
                        txtHN.Tag = RIS.Operational.Translator.ConvertHNtoKKU.HN_KKU(txtHN.Text);

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
                        his.GENDER = string.Empty;
                        break;
                    case 1:
                        his.GENDER = "M";
                        his.TITLE = "���";
                        his.TITLE_ENG = "Mr.";
                        break;
                    case 2:
                        his.GENDER = "F";
                        his.TITLE = "�ҧ���";
                        his.TITLE_ENG = "Mrs.";
                        break;
                }
                his.DOB = txtDOB.DateTime;
                his.PHONE1 = txtTelephone.Text.Trim();
                his.REG_DT = DateTime.Today;
                his.LAST_MODIFIED_BY = env.UserID;
                Ord.His_Registratiion = his; 
                #endregion
            }

            if (scheduleID > 0)
            {
                Ord.SetScheduleID(scheduleID);
                scheduleID = 0;
            }
            orderManger.Add(Ord);
        }
        private void fillDataToEditOrder(order Ord)
        {
            txtOrderDepartment.Tag = 11226;
            txtOrderDepartment.Text = "�ٹ���Ǩ���ҹ��ҧ�����";

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
                    i++;
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
            Ord.Ris_OrderImage = this.thisOrder.Ris_OrderImage.Copy();
            Ord.Ris_PatICD = this.thisOrder.Ris_PatICD.Copy();

            Ord.Item.REF_UNIT = txtOrderDepartment.Tag == null || txtOrderDepartment.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderDepartment.Tag);
            Ord.Item.REF_DOC = txtOrderPhysician.Tag == null || txtOrderPhysician.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderPhysician.Tag);
            Ord.Item.INSURANCE_TYPE_ID = txtInsurace.Tag == null || txtInsurace.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtInsurace.Tag);
            Ord.Item.PAT_STATUS = txtPatientType.Tag == null || txtPatientType.Tag.ToString() == string.Empty ? string.Empty : txtPatientType.Tag.ToString();
            Ord.Item.Lmp_DT = datePeriod.DateTime;
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
            Ord.Demographic.InsuranceID = Ord.Item.INSURANCE_TYPE_ID;
            Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
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
            orderManger.Add(Ord);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                e.Cancel = false;
                //routineToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                DataTable dtExam = order.Ris_Exam();
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
                    setFreeToolStripMenuItem.Enabled = true;
                    priorityToolStripMenuItem.Enabled = true;
                }
                else
                {
                    setFreeToolStripMenuItem.Enabled = false;
                    priorityToolStripMenuItem.Enabled = false;
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
                            DataRow[] drbp = order.BP_View().Select("BPVIEW_ID =" + dr["BPVIEW_ID"].ToString());
                            if (drbp[0]["BPVIEW_UID"].ToString() == "O")
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
//            grdData.DataSource =
        }

        private void NormalRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComments frm = new frmComments();
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            string Comment = dr["COMMENTS"].ToString();
            if (Comment.IndexOf("</F>") > 0)
            {
                DataRow[] drAr = order.Ris_Exam().Select("EXAM_ID = " + dr["EXAM_ID"].ToString());
                dr["COMMENTS"] = Comment.Replace("<F>" + getTagXML("F", Comment) + "</F>", "");
                dr["RATE"] = drAr[0]["RATE"];

                DataRow[] drClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dr["CLINIC_TYPE_ID"].ToString());

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
        public string getTagXML(string tag,string TextXML)
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
                            DataRow[] drbp = order.BP_View().Select("BPVIEW_ID =" + dr["BPVIEW_ID"].ToString());
                            if (drbp[0]["BPVIEW_UID"].ToString() == "O")
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

        private void frmOrders_Lite_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = Ris_FrequenlyUsedExam();

            #region ColumnEdit
            try
            {
                gridView1.Columns["EXAM_ID"].Visible = false;

                gridView1.Columns["EXAM_UID"].Visible = true;
                gridView1.Columns["EXAM_UID"].Caption = "Exam Code";
                gridView1.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["EXAM_UID"].Width = 75;
                gridView1.Columns["EXAM_UID"].OptionsColumn.FixedWidth = true;

                gridView1.Columns["EXAM_NAME"].Visible = true;
                gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
                gridView1.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["EXAM_NAME"].Width = 150;
                gridView1.Columns["EXAM_NAME"].OptionsColumn.FixedWidth = true;

                gridView1.Columns["EXAM_COUNT"].Visible = false;
            }
            catch
            {
                throw new Exception();
            }
            #endregion

            txtAGE2.Properties.Items.Add("");
            for (int i = 0; i < 150; i++)
            {
                txtAGE2.Properties.Items.Add(i);
            }
        }
        public static DataTable Ris_FrequenlyUsedExam()
        {
            DataTable tb = new DataTable();
            ProcessGetRisvFreqUsedExam processFreqUsedExam = new ProcessGetRisvFreqUsedExam();
            processFreqUsedExam.Invoke();
            tb = processFreqUsedExam.ResultSet.Tables[0].Copy();
            tb.TableName = "Risv_FrequenlyUsedExam";
            return tb;
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            //if (gridView1.FocusedRowHandle > -1)
            //{
            //    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //    string exam_uid = dr["exam_uid"].ToString();
            //    int row = view1.FocusedRowHandle;
            //    if (exam_uid != string.Empty)
            //    {
            //        bool flag = updateExam(exam_uid);
            //        if (flag)
            //        {
            //            if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
            //            {
            //                view1.FocusedRowHandle = row;
            //                view1.FocusedColumn = view1.VisibleColumns[2];
            //            }
            //            else
            //            {
            //                view1.FocusedColumn = view1.VisibleColumns[0];
            //                view1.MoveNext();
            //            }
            //        }
            //        else
            //        {
            //            //msg.ShowAlert("UID1014", env.CurrentLanguageID);
            //        }
            //    }
            //}
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string exam_uid = dr["exam_uid"].ToString();
                int row = view1.FocusedRowHandle; 
                bool flag = false;
                if (exam_uid != string.Empty)
                {
                    flag = updateExam(exam_uid);
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
                        //msg.ShowAlert("UID1014", env.CurrentLanguageID);
                    }
                }

                #region select last "assigned to"

//                string cns = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
//                DataTable dt = new DataTable("LastRadiologist");

//                using (SqlConnection cn = new SqlConnection(cns))
//                {
//                    SqlDataAdapter ad = new SqlDataAdapter();
//                    ad.SelectCommand = new SqlCommand();
//                    ad.SelectCommand.Connection = cn;
//                    ad.SelectCommand.CommandText =
//                    @"  
//                        select top 1 ASSIGNED_TO
//                        from RIS_ORDERDTL
//                        where ASSIGNED_TO is not null
//                        order by CREATED_ON desc
//                    ";
//                    ad.SelectCommand.CommandType = CommandType.Text;
//                    ad.Fill(dt);
//                }

//                if (dt.Rows.Count > 0)
//                {
//                    DataView dv = (DataView)grdData.DataSource;
//                    DataTable dtt = dv.Table;
//                    int k = 0;
//                    foreach (DataRow drr in dtt.Rows)
//                    {
//                        if (k != dtt.Rows.Count - 1)
//                            drr["ASSIGNED_TO"] = dt.Rows[0]["ASSIGNED_TO"];
//                        k++;
//                    }
//                }

                #endregion

                #region oldCode
                //flag = false;
                //string s = string.Empty;
                //if (mode == "Edit")
                //{
                //    #region Update Order
                //    flag = checkRequireModeEdit();
                //    if (flag)
                //    {
                //        s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                //        if (s == "2")
                //        {
                //            fillDataToEditOrder(thisOrder);
                //            updateDataBySendToPrint();
                //        }
                //    }
                //    #endregion
                //}
                //else
                //{
                //    #region Create Order
                //    bool addDetials = true;
                //    flag = checkRequireModeCreate(ref addDetials);
                //    if (flag)
                //    {
                //        s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                //        if (s == "2")
                //        {
                //            if (addDetials)
                //                fillDataToCreateOrder(thisOrder);
                //            insertDataBySendToPrint();
                //        }
                //    }
                //    #endregion
                //}
                #endregion

                flag = false;
                string s = string.Empty;
                if (mode == "Edit")
                {
                    #region Update Order
                    flag = checkRequireModeEdit();
                    if (flag)
                    {
                        s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                        if (s == "2")
                        {
                            fillDataToEditOrder(thisOrder);
                            //updateData();
                            updateDataBySendToPrint();
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Create Order
                    bool addDetials = true; //�礡ó� save same
                    flag = checkRequireModeCreate(ref addDetials);
                    if (flag)
                    {
                        s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                        if (s == "2")
                        {

                            if (addDetials)
                                fillDataToCreateOrder(thisOrder);
                            //insertData();
                            insertDataBySendToPrint();
                            frmOrdersSelectMode("New");
                            this.txtHN.Focus();
                        }
                    }
                    #endregion
                }
            }
        }
        private bool updateExam(string strSearch)
        {
            DataTable dtExam = order.Ris_Exam();
            DataTable dtBP_View = order.BP_View();
            DataView dv = (DataView)grdData.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.RowCount - 1;
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
                    DataRow[] drClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dtt.Rows[row]["CLINIC_TYPE"].ToString());
                    DataRow[] drExam = order.Ris_Exam().Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
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
                }
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
        private void GetOrderingDepartment(string hn)
        {
            return;

            string orderDepartment = "";
            DataSet ds;
            try
            {
                HIS_Patient webService = new HIS_Patient();
                //ds = webService.Get_appointment_detail(hn);
                ds = new DataSet();

                ProcessGetHRUnit getUnit = new ProcessGetHRUnit();
                getUnit.Invoke();
                if (getUnit.Result.Tables[0].Rows.Count > 0) {
                    bool flag = false;
                    int k = 0;
                    foreach (DataRow dr in getUnit.Result.Tables[0].Rows) {
                        if (dr["UNIT_UID"].ToString() == ds.Tables[0].Rows[0]["appt_doc_dept_code"].ToString()) {
                            flag = true;
                            break;
                        }
                        k++;
                    }
                    if (flag) {
                        DataRow row = getUnit.Result.Tables[0].Rows[k];
                        string s = txtOrderDepartment.Tag == null ? string.Empty : txtOrderDepartment.Tag.ToString();
                        if (row["UNIT_ID"].ToString() != s) {
                            txtOrderDepartment.Tag = row["UNIT_ID"].ToString();
                            txtOrderDepartment.Text = row["UNIT_UID"].ToString() + ":" + row["UNIT_NAME"].ToString();
                            txtOrderDept.Text = row["DESCR"].ToString();
                            setTextBoxAutoComplete();
                        }
                    }
                }
            }
            catch
            {
                
            }

            txtOrderDepartment.Text = orderDepartment;
        }

        private void txtAGE2_TextChanged(object sender, EventArgs e)
        {
            if (txtAGE2.Text != "")
            {
                txtDOB.DateTime = new DateTime(DateTime.Now.Year - Convert.ToInt32(txtAGE2.Text), 1, 1);
            }
        }

        private void txtDOB_TextChanged(object sender, EventArgs e)
        {
            if(txtDOB.Text != "")
            {
                int age = DateTime.Now.Year - txtDOB.DateTime.Year;
                if (age <= Convert.ToInt32(txtAGE2.Properties.Items[txtAGE2.Properties.Items.Count - 1]))
                {
                    txtAGE2.Text = age.ToString();
                }
            }
        }

        private void txtAGE2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                cboGender.Focus();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                    gridView1_DoubleClick(new object(), new EventArgs());
                }
            }
        }

        private void fillEmptyData()
        {
            //thisOrder. patient.DateOfBirth = his.DOB = ;
            //patient.Age = his.AGE;

            //patient.FirstName = his.FNAME;
            //patient.MiddleName = his.MNAME;
            //patient.LastName = his.LNAME;

            //patient.FirstName_ENG = his.FNAME_ENG;
            //patient.MiddleName_ENG = his.MNAME_ENG;
            //patient.LastName_ENG = his.LNAME_ENG;

            //patient.Gender = his.GENDER;
        }

        private DataTable getExamCheckup()
        {
            DataTable tb = order.Ris_Exam().Copy();
            DataTable tbchk = tb.Clone();

            DataRow[] rows = tb.Select("IS_CHECKUP='Y'");
            foreach (DataRow dr in rows)
                tbchk.Rows.Add(dr.ItemArray);

            return tbchk;
        }

        #region Title Thai Name
        public string[] TitleThaiName = new string[]
        { 
            "���",
            "�ҧ���",
            "�ҧ",

            "�ҷ��ǧ",
            "����",
            "���",
            "������Ҫǧ��",
            "�������ǧ",
            "�ͧ��ʵ�Ҩ����",
            "��������ʵ�Ҩ����",

            "��.�.�.",
            "��.�.�.",
            "��.�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "���",

            "��.�.",
            "��.�.",
            "��.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "���",

            "��.�.�.",
            "��.�.�.",
            "��.�.�.",
            "�.�...�.�.",
            "�.�...�.�.",
            "�.�...�.�.",
            "�.�...�.�.",
            "�.�...�.�.",
            "�.�...�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.",
            "�.�.",
            "�.�.",
            "���",

            "��.�.�.",
            "��.�.�.",
            "��.�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.�",
            "�.�.�",
            "�.�.�",
            "�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.�.",
            "�.�.�.",
            "�ŵ��Ǩ",
        };
        #endregion Title Thai Name

        #region Title Eng Name
        public string[] TitleEngName = new string[]
        { 
            "Mr.",
            "Ms.",
            "Mrs.",

            "Fr.",
            "Sis.",
            "Monk",
            "M R",
            "M L", 
            "Assoc P.",
            "Assist Pro.",

            "ACM",
            "AM", 
            "AVM", 
            "GP CAPT",
            "WG CDR",
            "SON LDR",
            "FLT LT",
            "FLG OFF",
            "PLT OFF",
            "FS 1",
            "FS 2",
            "FS 3",
            "SGT",
            "CPL", 
            "LAC",
            "AMN",

            "GEN", 
            "LT GEN", 
            "MAJ GEN",
            "COL", 
            "LT COL", 
            "MAJ",
            "CAPT",
            "LT",
            "SUB KT",
            "SM 1",
            "SM 2",
            "SM 3",
            "PFC",
            "CPL",
            "PFC",
            "PVT",

            "ADM", 
            "V ADM",
            "R AVM",
            "CAPT",
            "CDR",
            "L CDR",
            "LT",
            "LT JG", 
            "SUB LT",
            "CPO 1",
            "CPO 2",
            "CPO 3",
            "PO 1",
            "PO 2",
            "PO 3",
            "SEA-MAN",

            "POL GEN",
            "POL LT GEN", 
            "POL MAL GEN",
            "POL COL",
            "POL LT COL", 
            "POL MAL",
            "POL CAPT",
            "POL LT",
            "POL SUB LT",
            "POL SEN SGT MAJ", 
            "POL SM",
            "POL SGT",
            "POL CPL",
            "POL PFC",
            "POL PVT",         
        };
        #endregion Title Eng Name
    }
}
