using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.DBConnection;
using DevExpress.XtraEditors.Repository;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Operational.PACS;
using RIS.Forms.GBLMessage;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace RIS.Forms.Technologist
{
    public partial class frmPatientData : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private string accession_no = string.Empty;
        private int take = 0;
        //private DataView dv = new DataView();
        private DataTable dttExam = new DataTable();


        public frmPatientData(UUL.ControlFrame.Controls.TabControl ctrl)
        {
            InitializeComponent();
            CloseControl = ctrl;
            pMain.Enabled = false;
            getExamData();
            getTechWork();
        }
        public frmPatientData(string AccessionNo) {
            InitializeComponent();
            ribbonControl1.Visible = false;
            pOrder.Enabled = true;
            pExam.Enabled = true;
            accession_no = AccessionNo;
            take = 0;
            getExamData();
            getOrderDetails();
            groupExam.Visible = true;
            groupConsump.Visible = true;
            getTechWork();
          
        }
        //public frmPatientData(string AccessionNo, int Take)
        //{
        //    InitializeComponent();
        //    //CloseControl = ctrl;

        //    pOrder.Enabled = false;
        //    pExam.Enabled = false;
        //    accession_no = AccessionNo;
        //    take = Take;
        //    getExamData();
        //    getTechWork();
        //}
        public frmPatientData(string AccessionNo, int Take, bool ShowExam)
        {
            InitializeComponent();
            ribbonControl1.Visible = false;
            pOrder.Enabled = false;
            pExam.Enabled = false;
            accession_no = AccessionNo;
            take = Take;
            getExamData();
            getOrderDetails();
            groupExam.Visible = ShowExam;
            groupConsump.Visible = ShowExam;
            if (ShowExam)
                getTechWork();
            else
            {
                grdOrder.Visible = true;
                grdOrder.Dock = DockStyle.Fill;
            }
        }

        private void getExamData()
        {
            try
            {
                ProcessGetRISExam processExam = new ProcessGetRISExam();
                processExam.Invoke();
                dttExam = processExam.Result.Tables[0].Copy();
                dttExam.TableName = "RIS_EXAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region Menu Tab 
        private void barCapture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "Capture");
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.dateFrom.Focus();
        }
        private void barQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "QA");
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.dateFrom.Focus();
        }
        private void barGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "Capture");
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.dateFrom.Focus();
        }
        private void barNewOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            ////CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barOrderData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Technologist.frmPatientData frm = new frmPatientData(this.CloseControl);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
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
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }
        #endregion

        private void getTechWork()
        {
            try
            {
                ProcessGetRISTechworks process = new ProcessGetRISTechworks();
                process.RISTechworks.ACCESSION_ON = accession_no;
                process.RISTechworks.TAKE = (byte)take;
                process.Invoke();
                if (process.Result != null)
                    if (process.Result.Tables.Count > 0)
                    {
                        if (process.Result.Tables[0].Rows.Count > 0)
                        {
                            txtTake.Text = take.ToString();
                            txtPerform.Text = process.Result.Tables[0].Rows[0]["UserName"].ToString();
                            txtKV.Text = process.Result.Tables[0].Rows[0]["KV"].ToString();
                            txtmA.Text = process.Result.Tables[0].Rows[0]["mA"].ToString();
                            txtSec.Text = process.Result.Tables[0].Rows[0]["SEC"].ToString();
                            txtExposure.Text = process.Result.Tables[0].Rows[0]["EXPOSURE_TECHNIQUE"].ToString();
                            txtNoOfImage.Text = process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString().Trim() == string.Empty ? "0" : process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString();
                            txtProtocol.Text = process.Result.Tables[0].Rows[0]["PROTOCOL"].ToString();
                            getConsumable();
                            bindTechGrid();
                            return;
                        }
                    }
                getConsumable();
                bindTechGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getConsumable()
        {
            ProcessGetRISTechconsumption process = new ProcessGetRISTechconsumption();
            DataTable dtt = new DataTable();
            process.RISTechconsumption.ACCESSION_NO = accession_no;
            int tmpTake = take > 1 ? take - 1 : take;
            process.RISTechconsumption.TAKE = (byte)tmpTake;
            process.Invoke();
            dtt = process.Result.Tables[0].Copy();
            dtt.Columns.Add("Total", typeof(decimal));
            dtt.Columns.Add("colDelete", typeof(string));
            foreach (DataRow dr in dtt.Rows)
            {
                for (int i = 0; i < dttExam.Rows.Count; i++)
                {
                    if (dr["EXAM_ID"].ToString().Trim() == dttExam.Rows[i]["EXAM_ID"].ToString().Trim())
                    {
                        dr["EXAM_NAME"] = dttExam.Rows[i]["EXAM_NAME"].ToString();
                        decimal qty = dr["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["QTY"]);
                        decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                        decimal total=qty * rate;
                        dr["Total"] = total;
                        break;
                    }
                }
            }
            grdConsumption.DataSource = dtt;
            //dv = new DataView(dtt);
        }
        private void bindTechGrid()
        {
            //DataTable dtt = dv.ToTable();
            //DataRow dr = dtt.NewRow();
            //dr["QTY"] = 1;
            //dr["IS_DELETED"] = "N";
            //dtt.Rows.Add(dr);
            //dv = new DataView(dtt);
            //grdConsumption.DataSource = dv;
            DataTable dtt = (DataTable)grdConsumption.DataSource;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.OptionsView.ShowBands = false;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            view1.OptionsView.ShowColumnHeaders = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            repositoryItemLookUpEdit1.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = dttExam;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            //repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examID_KeyUp);
            //repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examID_CloseUp);
            view1.Columns["EXAM_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            view1.Columns["EXAM_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["EXAM_ID"].Visible = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = dttExam;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            //repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            //repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            view1.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            view1.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["EXAM_NAME"].Visible = true;

            //RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            //btn.AutoHeight = false;
            //btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            //btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //btn.Buttons[0].Caption = string.Empty;
            ////btn.Click += new EventHandler(btnDeleteRow_Click);
            //view1.Columns["colDelete"].Caption = string.Empty;
            //view1.Columns["colDelete"].ColumnEdit = btn;
            //view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            //view1.Columns["colDelete"].Width = 50;
            //view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spin = new RepositoryItemSpinEdit();
            //spin.KeyUp += new KeyEventHandler(qty_KeyUp);
            //spin.ValueChanged += new EventHandler(qty_ValueChanged);
            spin.MinValue = 0.1M;
            spin.MaxValue = 999.99M;
            view1.Columns["QTY"].ColumnEdit = spin;


            view1.Columns["QTY"].Visible = true;
            view1.Columns["RATE"].Visible = true;
            view1.Columns["Total"].Visible = true;
            //view1.Columns["colDelete"].Visible = true;

            view1.Columns["EXAM_ID"].Caption = "Cons UID";
            view1.Columns["EXAM_NAME"].Caption = "Consumable Name";
            view1.Columns["QTY"].Caption = "Qty";
            view1.Columns["RATE"].Caption = "Rate";
            view1.Columns["RATE"].OptionsColumn.ReadOnly = true;
            view1.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view1.Columns["Total"].Caption = "Total";
            view1.Columns["Total"].OptionsColumn.ReadOnly = true;
            view1.Columns["Total"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view1.Columns["colDelete"].Caption = string.Empty;
            view1.BestFitColumns();
            view1.OptionsSelection.EnableAppearanceFocusedRow = true;
            view1.OptionsSelection.InvertSelection = false;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void getOrderDetails() {
            ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
            DataSet ds=process.GetPreview(accession_no);
            if(ds!=null)
                if(ds.Tables.Count>0)
                    if (ds.Tables[0].Rows.Count > 0) {
                        DataRow dr = ds.Tables[0].Rows[0];
                        txtOrderNo.Text = dr["ORDER_ID"].ToString();
                        if(dr["ORDER_DT"].ToString().Trim()!=string.Empty)
                            dateOrderDate.DateTime = Convert.ToDateTime(dr["ORDER_DT"]);
                        txtHN.Text = dr["HN"].ToString();
                        txtPatientName.Text = dr["PatientName"].ToString();
                        txtGender.Text = dr["GENDER"].ToString();
                        if (dr["DOB"].ToString().Trim() != string.Empty)
                            dateDOB.DateTime = Convert.ToDateTime(dr["DOB"]);
                        txtOrderDept.Text = dr["UNIT"].ToString();
                        txtOrderDoc.Text = dr["DOCTOR"].ToString();
                        txtMode.Text = dr["STATUS_TEXT"].ToString();
                        txtClinic.Text = dr["CLINIC_TYPE_TEXT"].ToString();
                        txtDiagnosis.Text = dr["DIAGNOSIS"].ToString();
                        txtPriority.Text = dr["PRIORITY"].ToString();
                        txtModality.Text = dr["MODALITY_NAME"].ToString();
                        txtExamCode.Text = dr["EXAM_UID"].ToString();
                        txtExamName.Text = dr["EXAM_NAME"].ToString();
                        txtAccession.Text = dr["ACCESSION_NO"].ToString();
                        txtArrival.Text = dr["ORDER_START_TIME"].ToString();
                        string strTemp = string.Empty;
                        if (dr["LMP_DT"].ToString() != null)
                            if (dr["LMP_DT"].ToString() != string.Empty)
                            {
                                DateTime dt = Convert.ToDateTime(dr["LMP_DT"]);
                                strTemp = dt.ToString("dd/MM/yyyy");
                            }
                        txtPeriod.Text = strTemp;
                        //txtEST.Text = dr["EST_START_TIME"].ToString();
                        if (dr["EST_START_TIME"].ToString().Trim() != string.Empty)
                        {
                            string hh = string.Empty;
                            string mm = string.Empty;
                            string ss = string.Empty;

                            //คิดเวลา
                            DateTime dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                            TimeSpan ts = dt.TimeOfDay;
                            txtDelay.Text = DateTime.Now.Add(ts).ToString("hh:mm:ss");
                            hh = dt.TimeOfDay.Hours.ToString().Length == 1 ? "0" + dt.TimeOfDay.Hours.ToString() : dt.TimeOfDay.Hours.ToString();
                            mm = dt.TimeOfDay.Minutes.ToString().Length == 1 ? "0" + dt.TimeOfDay.Minutes.ToString() : dt.TimeOfDay.Minutes.ToString();
                            ss = dt.TimeOfDay.Seconds.ToString().Length == 1 ? "0" + dt.TimeOfDay.Seconds.ToString() : dt.TimeOfDay.Seconds.ToString();
                            txtEST.Text = hh + ":" + mm + ":" + ss;

                            dt = Convert.ToDateTime(dr["ORDER_START_TIME"]);
                            hh = dt.TimeOfDay.Hours.ToString().Length == 1 ? "0" + dt.TimeOfDay.Hours.ToString() : dt.TimeOfDay.Hours.ToString();
                            mm = dt.TimeOfDay.Minutes.ToString().Length == 1 ? "0" + dt.TimeOfDay.Minutes.ToString() : dt.TimeOfDay.Minutes.ToString();
                            ss = dt.TimeOfDay.Seconds.ToString().Length == 1 ? "0" + dt.TimeOfDay.Seconds.ToString() : dt.TimeOfDay.Seconds.ToString();
                            txtArrival.Text = hh + ":" + mm + ":" + ss;
                        }
                        pOrder.Enabled = true;
                        SetForeColor();
                        if (ds.Tables.Count == 2)
                        {
                            grdOrder.DataSource = ds.Tables[1];
                            viewOrder.OptionsSelection.EnableAppearanceFocusedRow = true;
                            viewOrder.OptionsSelection.InvertSelection = false;
                            viewOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
                            viewOrder.Columns["ORDER_ID"].Caption = "Order No.";
                            viewOrder.Columns["ORDER_DT"].Caption = "Order Date";
                            viewOrder.Columns["EXAM_UID"].Caption = "Exam Code";
                            viewOrder.Columns["EXAM_NAME"].Caption = "Exam Name";
                            viewOrder.Columns["ACCESSION_NO"].Caption = "Accession nO.";
                            viewOrder.Columns["MODALITY_NAME"].Caption = "Modaltiy";
                            viewOrder.Columns["RATE"].Caption = "Rate";
                            viewOrder.Columns["PRIORITY"].Caption = "Priority";
                            viewOrder.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
                            viewOrder.BestFitColumns();
                            pExam.Enabled = true;
                        }
                    }
        }
        private void SetForeColor() {
            txtOrderNo.ForeColor = Color.Black;
            dateOrderDate.ForeColor = Color.Black;
            txtHN.ForeColor = Color.Black;
            txtPatientName.ForeColor = Color.Black;
            txtGender.ForeColor = Color.Black;
            dateDOB.ForeColor = Color.Black;
            txtOrderDept.ForeColor= Color.Black;
            txtOrderDoc.ForeColor = Color.Black;
            txtMode.ForeColor = Color.Black;
            txtClinic.ForeColor = Color.Black;
            txtDiagnosis.ForeColor = Color.Black;
            txtPriority.ForeColor= Color.Black;
            txtModality.ForeColor = Color.Black;
            txtExamCode.ForeColor = Color.Black;
            txtExamName.ForeColor = Color.Black;
            txtArrival.ForeColor = Color.Black;
            txtAccession.ForeColor = Color.Black;
            txtEST.ForeColor = Color.Black;
            txtDelay.ForeColor = Color.Black;

            txtTake.ForeColor = Color.Black;
            txtPerform.ForeColor = Color.Black;
            txtKV.ForeColor = Color.Black;
            txtmA.ForeColor = Color.Black;
            txtSec.ForeColor = Color.Black;
            txtNoOfImage.ForeColor = Color.Black;
            txtExposure.BackColor = txtTake.BackColor;
            txtProtocol.BackColor = txtTake.BackColor;
            txtPeriod.ForeColor = Color.Black;
        }

        private void btnOrderICD_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(txtOrderNo.Text);
            ProcessGetRISPaticd processRISPatICD = new ProcessGetRISPaticd(orderID);
            processRISPatICD.Invoke();
            Order.WaitDialog.frmICD frm = new RIS.Forms.Order.WaitDialog.frmICD(false);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ICDTable = processRISPatICD.Result.Tables[0];
            frm.ShowDialog();
        }
        private void btnViewImage_Click(object sender, EventArgs e)
        {
            ProcessGetGBLEnv process = new ProcessGetGBLEnv();
            process.Invoke();
            string strUrl = string.Empty;
            if (process.ResultSet != null)
                if (process.ResultSet.Tables.Count > 0)
                {
                    strUrl = process.ResultSet.Tables[0].Rows[0]["PACS_URL1"].ToString();
                    strUrl += txtAccession.Text;
                    System.Diagnostics.Process.Start(strUrl);
                }
        }
        private void btnOrderForm_Click(object sender, EventArgs e)
        {
            Dialog.ImageOrder frm = new RIS.Forms.Technologist.Dialog.ImageOrder(Convert.ToInt32(txtOrderNo.Text));
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            //Get_lab_data
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = null;// HIS_p.Get_lab_data(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                        lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Lab_Clicks);
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
            catch { }
        }
        private void Lab_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {

        }
        private void btnAlergy_Click(object sender, EventArgs e)
        {
            //Get_Adr
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = null;// HIS_p.Get_Adr(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                        lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Adr_Clicks);
                        lv.Text = "Alergy Detail List";
                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.ShowBox();
                    }
                }
            }
            catch { }
        }
        private void Adr_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {

        }
    }
}