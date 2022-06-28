using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors.Repository;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Operational.HL7.OrderManagement;
using RIS.Operational.PACS;
using RIS.Operational.ReportManager;


using RIS.Forms.GBLMessage;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace RIS.Forms.Technologist
{
    public partial class TF05 : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataTable dttCon;
        private DataSet ds;
        private string mode;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        //
        private int clickTick;
        private BaseEdit activeEditor;
        private bool firstClickFlag;
        private DateTime dtStart;
        private DateTime dtEnd;
        private int status;
        private int group_id;
        //

        public TF05(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            this.CloseControl = clsCtl;
            this.StartPosition = FormStartPosition.CenterScreen;
            //mode = string.Empty;
            //bindShow();
            mode = "Capture";
            loadCapture();
            status = 1;
            group_id = 0;
        }
        public TF05(UUL.ControlFrame.Controls.TabControl clsCtl,string Mode)
        {
            InitializeComponent();
            this.CloseControl = clsCtl;
            this.StartPosition = FormStartPosition.CenterScreen;
            mode = Mode;
            if (mode == "QA")
                loadQA();
            else if (mode == "Capture")
                loadCapture();
            else if (mode == "Group")
                loadCapture();
            status = 1;
            group_id = 0;
        }

        private void bindShow() {
            pMain.Enabled = false;
            dateFrom.DateTime = DateTime.Today.AddDays(-1);
            dateTo.DateTime = DateTime.Today;

            DataTable dtt = new DataTable();
            dtt.Columns.Add("Priority");
            dtt.Columns.Add("HN");
            dtt.Columns.Add("Patient Name");
            dtt.Columns.Add("Gender");
            dtt.Columns.Add("Age");
            dtt.Columns.Add("Mode");
            dtt.Columns.Add("Accession No");
            dtt.Columns.Add("Exam Code");
            dtt.Columns.Add("Exam Name");
            dtt.Columns.Add("Modality");
            dtt.Columns.Add("Arr. Time");
            dtt.Columns.Add("EST");
            dtt.Columns.Add("Delay");
            dtt.Columns.Add("Tak");
            dtt.Columns.Add("Status");
            DataRow dr = dtt.NewRow();
            dtt.Rows.Add(dr);

            grdTech.DataSource = dtt;
            view1.BestFitColumns();
        }
        private void SetConForCapture() {
            if (dttCon == null) {
                dttCon = new DataTable();
                dttCon.Columns.Add("ID", typeof(int));
                dttCon.Columns.Add("Name", typeof(string));

                DataRow dr = dttCon.NewRow();
                dr[0] = 0;
                dr[1] = "Waiting";
                dttCon.Rows.Add(dr);

                dr = dttCon.NewRow();
                dr[0] = 1;
                dr[1] = "Started";
                dttCon.Rows.Add(dr);

                dr = dttCon.NewRow();
                dr[0] = 2;
                dr[1] = "Complete";
                dttCon.Rows.Add(dr);

                dr = dttCon.NewRow();
                dr[0] = 3;
                dr[1] = "Discontinued";
                dttCon.Rows.Add(dr);

                dr = dttCon.NewRow();
                dr[0] = 4;
                dr[1] = "Canceled";
                dttCon.Rows.Add(dr);
            }
        
        }

        private void condition_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            if (e.AcceptValue)
            {
                if (e.Value.ToString() != string.Empty)
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    if (dr != null) {
                        dtStart = DateTime.Now;
                        string s = string.Empty;
                        int id = Convert.ToInt32(e.Value);
                        dr["colStatus"] = id;
                        view1.RefreshData();
                        if (id == 1 ) {
                            s = msg.ShowAlert("UID1039", env.CurrentLanguageID);
                            dtEnd = DateTime.Now;
                            if (s == "2")
                                onlyStart();
                            if (s == "3")
                                yesEntry();
                            else
                            {
                                dr["colStatus"] = 0;
                                view1.RefreshData();
                            }
                        }
                        else if (id == 2) {
                            s = msg.ShowAlert("UID1042", env.CurrentLanguageID);
                            dtEnd = DateTime.Now;
                            status = 2;
                            if (s == "2")
                                onlyComplete();
                            if (s == "3")
                                yesEntry();
                            else
                            {
                                dr["colStatus"] = 0;
                                view1.RefreshData();
                            }
                        }
                        else if (id == 3)
                        {
                            //discontinue
                            dtEnd = DateTime.Now;
                            s = msg.ShowAlert("UID1040", env.CurrentLanguageID);
                            if (s == "2")
                                // MessageBox.Show("X");
                                SetStatusCancelDiscontinue(dr);
                            else
                            {
                                dr["colStatus"] = 0;
                                view1.RefreshData();
                            }
                        }
                        else if (id == 4)
                        {
                            //cancel
                            dtEnd = DateTime.Now;
                            s = msg.ShowAlert("UID1041", env.CurrentLanguageID);
                            if (s == "2")
                                // MessageBox.Show("X");
                                SetStatusCancelDiscontinue(dr);
                            else
                            {
                                dr["colStatus"] = 0;
                                view1.RefreshData();
                            }
                        }
                        else
                        {
                            dr["colStatus"] = 0;
                            view1.RefreshData();
                        }
                    }
                }
            }
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                if (dr != null)
                {
                    string accession = dr["ACCESSION_NO"].ToString();
                    int take = Convert.ToInt32(dr["TAKE"]);

                    frmPatientData frm = new frmPatientData(accession, take, mode == "QA");
                    frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    //if (mode == "Capture")
                    //    frm.Height -= 420;
                    //else
                          frm.Height -= 125;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex) {
            
            }
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mode == "QA")
                searchByQA();
            else if (mode == "Capture")
                searchByCapture();
            else if (mode == "Group")
                searchByCapture();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (mode == "QA")
                searchByQA();
            else if (mode == "Capture")
                searchByCapture();
            else if (mode == "Group")
                searchByCapture();
        }
        private void dateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dateTo.Focus();
        }
        private void dateTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGo.Focus();
        }
        
        private void SetStatusCancelDiscontinue(DataRow  dr) {
            Dialog.Reason frm = new RIS.Forms.Technologist.Dialog.Reason();
            if (DialogResult.OK == frm.ShowDialog())
            {
                ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                process.RISTechworks.ACCESSION_ON = dr["ACCESSION_NO"].ToString();
                process.RISTechworks.TAKE = Convert.ToByte(dr["TAKE"]);
                process.RISTechworks.START_TIME = dtStart;
                process.RISTechworks.END_TIME = dtEnd;
                //process.RISTechworks.EXPOSURE_TECHNIQUE = txtExposure.Text.Trim();
                //process.RISTechworks.PROTOCOL = txtProtocol.Text.Trim();
                //process.RISTechworks.KV = txtKV.Text.Trim();
                //process.RISTechworks.mA = txtmA.Text.Trim();
                //process.RISTechworks.SEC = txtSec.Text.Trim();
                process.RISTechworks.STATUS = "X";
                //process.RISTechworks.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage.Text);
                process.RISTechworks.ORG_ID = env.OrgID;
                process.RISTechworks.CREATED_BY = env.UserID;
                process.RISTechworks.PERFORMANCED_BY = env.UserID;
                process.RISTechworks.COMMENTS = frm.Comment;
                process.Invoke();


                ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                processUpdate.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                processUpdate.RISOrderdtl.STATUS = "X";
                processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                processUpdate.UpdateStatus();
                searchByCapture();
            }
        }

        #region Menu Tab 
        private void barCapture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "Capture");
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.dateFrom.Focus();
        }
        private void barQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "QA");
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.dateFrom.Focus();
        }
        private void barGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //if (pMain.Enabled == false || mode=="QA")
            //{
                //RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "Group");
                //frm.BackColor = Color.White;
                //frm.MaximizeBox = false;
                //frm.MinimizeBox = false;
                //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                //page.Selected = true;
                //int index = CloseControl.SelectedIndex;
                //CloseControl.TabPages.Add(page);
                //CloseControl.TabPages.RemoveAt(index);
                //frm.dateFrom.Focus();
            //}
            //else {
                Forms.Admin.RIS_SF12 frm = new RIS.Forms.Admin.RIS_SF12();
                frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                //group_id = frm.Group_ID;
            //}
        }
        private void barNewOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null)
            {

                RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders(dr["HN"].ToString(), "New", this.CloseControl);
                frm.BackColor = Color.White;
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.Text = frm.Text;
                UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                page.Selected = true;
                int index = CloseControl.SelectedIndex;
                CloseControl.TabPages.Add(page);
                //frm.txtHN.Focus();
                frm.txtOrderDepartment.Focus();
            }
            else
                msg.ShowAlert("UID1045",env.CurrentLanguageID);
        }
        private void barOrderData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null)
            {
                string accession = dr["ACCESSION_NO"].ToString();
                int take = Convert.ToInt32(dr["TAKE"]);
                frmPatientData frm = new frmPatientData(accession, take, mode == "QA");
                frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Height -= 112;
                frm.ShowDialog();
            }
            else
            {
                
                msg.ShowAlert("UID1045",env.CurrentLanguageID);
                return;
                //RIS.Forms.Technologist.frmPatientData frm = new frmPatientData(this.CloseControl);
                //frm.BackColor = Color.White;
                //frm.MaximizeBox = false;
                //frm.MinimizeBox = false;
                //frm.Text = frm.Text;
                //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
                //page.Selected = true;
                //int index = CloseControl.SelectedIndex;
                //CloseControl.TabPages.Add(page);
                //CloseControl.TabPages.RemoveAt(index);
            }
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

        private void searchByQA() {
            pMain.Enabled = true;
            ds = new DataSet();
            DateTime dtFrom = new DateTime(dateFrom.DateTime.Year, dateFrom.DateTime.Month, dateFrom.DateTime.Day, 0, 0, 0, 0);
            DateTime dtTo = new DateTime(dateTo.DateTime.Year, dateTo.DateTime.Month, dateTo.DateTime.Day, 23, 59, 59);

            ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
            ds = process.GetDataQA(dtFrom, dtTo);
            //ds.Tables[0].Columns.Add("Delay", typeof(DateTime));
            ds.Tables[0].Columns.Add("Delay", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                // DateTime dt=DateTime.Now;
                //if(dr["EST_START_TIME"].ToString()!=string.Empty)
                //    dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                //TimeSpan ts = dt.TimeOfDay;
                //dr["Delay"] = DateTime.Now.Add(ts);

                DateTime dt = DateTime.Now;
                if (dr["EST_START_TIME"].ToString() != string.Empty)
                    dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                TimeSpan ts = DateTime.Now.Subtract(dt);
                string day = ts.Days == 0 ? "00" : ts.Days.ToString();
                day = day.Length == 1 ? "0" + day + ":" : day + ":";
                string hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                string minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                minute = minute.Length == 1 ? "0" + minute : minute;
                dr["Delay"] = day + hour + minute;
            }
            bindDataByQA();
        }
        private void bindDataByQA() {
            try
            {
                view1.OptionsSelection.EnableAppearanceFocusedRow = true;
                view1.OptionsSelection.InvertSelection = false;
                view1.OptionsSelection.EnableAppearanceFocusedCell = false;
                view1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                view1.OptionsBehavior.Editable = false;
                view1.OptionsView.ShowAutoFilterRow = true;
                grdTech.DataSource = ds.Tables[0];
                view1.Columns["ORDER_ID"].Visible = false;
                view1.Columns["MODALITY_ID"].Visible = false;
                view1.Columns["EXAM_ID"].Visible = false;
                view1.Columns["PAT_STATUS"].Visible = false;
                view1.Columns["EXAM_ID"].Visible = false;
                view1.Columns["MODALITY_ID"].Visible = false;
                view1.Columns["STATUS"].Visible = false;

                view1.Columns["PRIORITY"].Caption = "Priority";
                view1.Columns["HN"].Caption = "HN";
                view1.Columns["PatientName"].Caption = "Patient Name";
                view1.Columns["GENDER"].Caption = "Gender";
                //view1.Columns["AGE"].Caption = "Age";
                view1.Columns["AGE"].Visible = false;
                view1.Columns["AGEText"].ColVIndex = 5;
                view1.Columns["AGEText"].Caption = "Age";
                view1.Columns["STATUS_TEXT"].Caption = "Mode";
                view1.Columns["ACCESSION_NO"].Caption = "Accession No.";
                view1.Columns["EXAM_UID"].Caption = "Exam Code";
                view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                view1.Columns["MODALITY_NAME"].Caption = "Modality";
                view1.Columns["ORDER_START_TIME"].Caption = "Arr. Time";

                DevExpress.XtraGrid.Columns.GridColumn gc = view1.Columns["ORDER_START_TIME"];
                gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gc.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

                view1.Columns["EST_START_TIME"].Caption = "EST";
                DevExpress.XtraGrid.Columns.GridColumn gcEST = view1.Columns["EST_START_TIME"];
                gcEST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gcEST.DisplayFormat.FormatString = "hh:mm:ss";

                view1.Columns["STATUS"].Caption = "Status";
                view1.Columns["TAKE"].Caption = "Take";

                //view1.Columns["Delay"].Caption = "Delay";
                //DevExpress.XtraGrid.Columns.GridColumn gcDelay = view1.Columns["Delay"];
                //gcDelay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gcDelay.DisplayFormat.FormatString = "hh:mm:ss";

                view1.BestFitColumns();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void loadQA() {
            //dateFrom.DateTime = DateTime.Today.AddDays(-1);
            dateFrom.DateTime = DateTime.Today;
            dateTo.DateTime = DateTime.Today;
            pMain.Enabled = true;
            ds = new DataSet();
            DateTime dtFrom = new DateTime(dateFrom.DateTime.Year, dateFrom.DateTime.Month, dateFrom.DateTime.Day, 0, 0, 0, 0);
            DateTime dtTo = new DateTime(dateTo.DateTime.Year, dateTo.DateTime.Month, dateTo.DateTime.Day, 23, 59, 59);

            ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
            ds = process.GetDataQA(dtFrom, dtTo);
            //ds.Tables[0].Columns.Add("Delay", typeof(DateTime));
            ds.Tables[0].Columns.Add("Delay", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //DateTime dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                //TimeSpan ts = dt.TimeOfDay;
                //dr["Delay"] = DateTime.Now.Add(ts);

                DateTime dt = DateTime.Now;
                if (dr["EST_START_TIME"].ToString() != string.Empty)
                    dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                TimeSpan ts = DateTime.Now.Subtract(dt);
                string day = ts.Days == 0 ? "00" : ts.Days.ToString();
                day = day.Length == 1 ? "0" + day + ":" : day + ":";
                string hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                string minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                minute = minute.Length == 1 ? "0" + minute : minute;
                dr["Delay"] = day + hour + minute;
            }
            bindDataByQA();
        }

        private void searchByCapture() {
            pMain.Enabled = true;
            ds = new DataSet();
            DateTime dtFrom = new DateTime(dateFrom.DateTime.Year, dateFrom.DateTime.Month, dateFrom.DateTime.Day, 0, 0, 0, 0);
            DateTime dtTo = new DateTime(dateTo.DateTime.Year, dateTo.DateTime.Month, dateTo.DateTime.Day, 23, 59, 59);
            ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
            ds = process.GetDataCapture(dtFrom, dtTo);
            //ds.Tables[0].Columns.Add("Delay", typeof(DateTime));
            ds.Tables[0].Columns.Add("Delay", typeof(string));
            ds.Tables[0].Columns.Add("colStatus", typeof(int));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //DateTime dt=DateTime.Now;
                //if(dr["EST_START_TIME"].ToString().Trim()!=string.Empty)
                //     dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                //TimeSpan ts = dt.TimeOfDay;
                //dr["Delay"] = DateTime.Now.Add(ts);
                if (dr["STATUS"].ToString().Trim() == "S")
                    dr["colStatus"] = 1;
                else
                    dr["colStatus"] = 0;

                DateTime dt = DateTime.Now;
                if (dr["EST_START_TIME"].ToString() != string.Empty)
                    dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                TimeSpan ts = DateTime.Now.Subtract(dt);
                string day = ts.Days == 0 ? "00" : ts.Days.ToString();
                day = day.Length == 1 ? "0" + day + ":" : day + ":";
                string hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                string minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                minute = minute.Length == 1 ? "0" + minute : minute;
                dr["Delay"] = day + hour + minute;
            }
            bindDataByCapture();
        }
        private void bindDataByCapture()
        {
            try
            {
                SetConForCapture();

                view1.OptionsSelection.EnableAppearanceFocusedRow = true;
                view1.OptionsSelection.InvertSelection = false;
                view1.OptionsSelection.EnableAppearanceFocusedCell = false;
                view1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                view1.OptionsView.ShowAutoFilterRow = true;
                grdTech.DataSource = ds.Tables[0];
                view1.Columns["ORDER_ID"].Visible = false;
                view1.Columns["MODALITY_ID"].Visible = false;
                view1.Columns["EXAM_ID"].Visible = false;
                view1.Columns["PAT_STATUS"].Visible = false;
                view1.Columns["EXAM_ID"].Visible = false;
                view1.Columns["MODALITY_ID"].Visible = false;
                view1.Columns["STATUS"].Visible = false;
                view1.Columns["PRIORITY"].Caption = "Priority";
                view1.Columns["HN"].Caption = "HN";
                view1.Columns["PatientName"].Caption = "Patient Name";
                view1.Columns["GENDER"].Caption = "Gender";
                view1.Columns["AGE"].Visible = false;
                //view1.Columns["AGE"].Caption = "Age";
                view1.Columns["AGEText"].ColVIndex = 5;
                view1.Columns["AGEText"].Caption = "Age";
                view1.Columns["STATUS_TEXT"].Caption = "Mode";
                view1.Columns["ACCESSION_NO"].Caption = "Accession No.";
                view1.Columns["EXAM_UID"].Caption = "Exam Code";
                view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                view1.Columns["MODALITY_NAME"].Caption = "Modality";
                view1.Columns["ORDER_START_TIME"].Caption = "Arr. Time";
                view1.Columns["EST_START_TIME"].Caption = "EST";
                view1.Columns["STATUS"].Caption = "Status";
                view1.Columns["TAKE"].Caption = "Take";
                view1.Columns["colStatus"].Caption = string.Empty;

                view1.Columns["AGE"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                view1.Columns["ORDER_START_TIME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                view1.Columns["EST_START_TIME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                view1.Columns["Delay"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; 

                for (int i = 0; i < view1.Columns.Count; i++)
                    view1.Columns[i].OptionsColumn.ReadOnly = true;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit1.ImmediatePopup = true;
                repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit1.AutoHeight = false;
                repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Condition", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit1.DisplayMember = "Name";
                repositoryItemLookUpEdit1.ValueMember = "ID";
                repositoryItemLookUpEdit1.DropDownRows = 5;
                repositoryItemLookUpEdit1.DataSource = dttCon;
                repositoryItemLookUpEdit1.NullText = string.Empty;
                repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(condition_CloseUp);
                view1.Columns["colStatus"].ColumnEdit = repositoryItemLookUpEdit1;
                view1.Columns["colStatus"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                view1.Columns["colStatus"].OptionsColumn.ReadOnly = false;
                view1.Columns["colStatus"].Caption = "Status";
                
                DevExpress.XtraGrid.StyleFormatCondition cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["colStatus"], null, "B");
                cn.Appearance.BackColor = Color.LightGreen;
                view1.FormatConditions.Add(cn);

                DevExpress.XtraGrid.Columns.GridColumn gc = view1.Columns["ORDER_START_TIME"];
                gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gc.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

                DevExpress.XtraGrid.Columns.GridColumn gcEST = view1.Columns["EST_START_TIME"];
                gcEST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gcEST.DisplayFormat.FormatString = "hh:mm:ss";

                DevExpress.XtraGrid.Columns.GridColumn gcDelay = view1.Columns["Delay"];
                //gcDelay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gcDelay.DisplayFormat.FormatString = "hh:mm:ss";
                //gcDelay.DisplayFormat.FormatString = "dd:hh:mm";

                view1.BestFitColumns();
                view1.Columns["colStatus"].Width = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void loadCapture() {
            //dateFrom.DateTime = DateTime.Today.AddDays(-1);
            dateFrom.DateTime = DateTime.Today;
            dateTo.DateTime = DateTime.Today;
            pMain.Enabled = true;
            ds = new DataSet();
            DateTime dtFrom = new DateTime(dateFrom.DateTime.Year, dateFrom.DateTime.Month, dateFrom.DateTime.Day, 0, 0, 0, 0);
            DateTime dtTo = new DateTime(dateTo.DateTime.Year, dateTo.DateTime.Month, dateTo.DateTime.Day, 23, 59, 59);
            ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
            ds = process.GetDataCapture(dtFrom,dtTo);
            //ds.Tables[0].Columns.Add("Delay", typeof(DateTime));
            ds.Tables[0].Columns.Add("Delay", typeof(string));
            ds.Tables[0].Columns.Add("colStatus", typeof(int));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //DateTime dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                //TimeSpan ts = dt.TimeOfDay;
                //dr["Delay"] = DateTime.Now.Add(ts);

                if(dr["STATUS"].ToString().Trim()=="S")
                    dr["colStatus"] = 1;
                else
                    dr["colStatus"] = 0;

                DateTime dt = DateTime.Now;
                if (dr["EST_START_TIME"].ToString() != string.Empty)
                    dt = Convert.ToDateTime(dr["EST_START_TIME"]);
                TimeSpan ts = DateTime.Now.Subtract(dt);
                string day = ts.Days == 0 ? "00" : ts.Days.ToString();
                day = day.Length == 1 ? "0" + day + ":" : day + ":";
                string hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                string minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                minute = minute.Length == 1 ? "0" + minute : minute;
                dr["Delay"] = day + hour + minute;
            }
            bindDataByCapture();
        }

        private void view1_DoubleClick(object sender, EventArgs e)
        {
            dtStart = DateTime.Now;
            DateTime startDT = DateTime.Now;
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null)
            {
                if (mode == "QA")
                {
                    #region by QA 
                    string accession_no = dr["ACCESSION_NO"].ToString();
                    int take = Convert.ToInt32(dr["TAKE"]);
                    string hn = dr["HN"].ToString();
                    Dialog.QAConfirm frm = new RIS.Forms.Technologist.Dialog.QAConfirm(hn,accession_no, take);
                    frm.Text = "Confirm : " + dr["HN"].ToString() + " (" +dr["PatientName"].ToString() + ") ";
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        DateTime endDT = DateTime.Now;
                        RISQaworks qaCommon = new RISQaworks();
                        qaCommon.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                        qaCommon.COMMENTS = frm.Comment;
                        qaCommon.CREATED_BY = env.UserID;
                        qaCommon.END_TIME = endDT;
                        qaCommon.ORG_ID = env.OrgID;
                        qaCommon.START_TIME = startDT;
                        qaCommon.NO_OF_IMAGES_PRINT = frm.ImageCount;

                        ProcessAddRISQaworks process = new ProcessAddRISQaworks();
                        process.RISQaworks = qaCommon;
                        process.Invoke();

                        ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                        processUpdate.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                        processUpdate.RISOrderdtl.STATUS = frm.Pass ? "G" : "B";
                        processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                        processUpdate.UpdateStatus();

                        //update data table
                        //delete consumption
                        ProcessDeleteRISTechconsumption processDel = new ProcessDeleteRISTechconsumption();
                        processDel.RISTechconsumption.ACCESSION_NO = accession_no;
                        processDel.RISTechconsumption.TAKE = (byte)take;
                        processDel.Invoke();

                        //add consumption
                        ProcessAddRISTechconsumption processCon = new ProcessAddRISTechconsumption();
                        processCon.RISTechconsumption.ACCESSION_NO = accession_no ;
                        processCon.RISTechconsumption.TAKE = (byte)take;
                        processCon.RISTechconsumption.CREATED_BY = env.UserID;
                        DataTable dtt = frm.Consumption;
                        foreach (DataRow drAdd in dtt.Rows)
                        {
                            if (drAdd["EXAM_ID"].ToString().Trim() != string.Empty)
                            {
                                processCon.RISTechconsumption.EXAM_ID = Convert.ToInt32(drAdd["EXAM_ID"]);
                                processCon.RISTechconsumption.IS_DELETED = "N";
                                processCon.RISTechconsumption.QTY = Convert.ToDecimal(drAdd["QTY"]);
                                processCon.RISTechconsumption.RATE = Convert.ToDecimal(drAdd["RATE"]);
                                processCon.RISTechconsumption.ORG_ID = env.OrgID;
                                processCon.Invoke();
                            }
                        }



                        searchByQA();
                    } 
                    #endregion
                }
                else if (mode == "Capture" || mode == "Group") {
                    #region by Capture 
                    string s = msg.ShowAlert("UID1039", env.CurrentLanguageID);
                    //onlystart =2,yes =3
                    dtEnd = DateTime.Now;
                    if (s == "2")
                        onlyStart();
                    if (s == "3")
                        yesEntry();
                    #endregion
                }
            }
        }

        private void onlyStart() {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null) {
                RISTechworks tech = new RISTechworks();
                tech.ACCESSION_ON = dr["ACCESSION_NO"].ToString();
                tech.START_TIME = dtStart;
                tech.END_TIME = dtEnd;
                tech.ORG_ID = env.OrgID;
                tech.CREATED_BY = env.UserID;
                ProcessAddRISTechworks process = new ProcessAddRISTechworks(tech);
                process.Invoke();

                //update status
                ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                processUpdate.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                processUpdate.RISOrderdtl.STATUS = "S";
                processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                processUpdate.UpdateStatus();
                searchByCapture();
            }
        }
        private void onlyComplete()
        {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null)
            {
                RISTechworks tech = new RISTechworks();
                tech.ACCESSION_ON = dr["ACCESSION_NO"].ToString();
                tech.START_TIME = dtStart;
                tech.END_TIME = dtEnd;
                tech.ORG_ID = env.OrgID;
                tech.CREATED_BY = env.UserID;
                ProcessAddRISTechworks process = new ProcessAddRISTechworks(tech);
                process.Invoke();

                //update status
                ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                processUpdate.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                processUpdate.RISOrderdtl.STATUS = "C";
                processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                processUpdate.UpdateStatus();
                searchByCapture();
            }
        }
        private void yesEntry() {
            string s = msg.ShowAlert("UID1043", env.CurrentLanguageID);
            int performby = env.UserID;
            if (s == "2")
            {
                Dialog.PerformUsr per = new RIS.Forms.Technologist.Dialog.PerformUsr();
                per.StartPosition = FormStartPosition.CenterParent;
                if (DialogResult.OK == per.ShowDialog())
                {
                    performby = per.PerformBy;
                    group_id = 0;
                }
                else
                    return;
            }
            //goto techwork
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            int take =Convert.ToInt32( dr["TAKE"]);
            string accNo = dr["ACCESSION_NO"].ToString();
            frmTechWork frm = new frmTechWork(this.CloseControl, dtStart, performby, take,status, accNo);
            if (group_id > 0)
                frm = new frmTechWork(this.CloseControl, dtStart, group_id, take, status, accNo, true);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtNoOfImage.Focus();
        }

        #region Grid Event 
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
            dtStart = DateTime.Now;
            string s = msg.ShowAlert("UID1039", env.CurrentLanguageID);
            //onlystart =2,yes =3
            dtEnd = DateTime.Now;
            if (s == "2")
                onlyStart();
            if (s == "3")
                yesEntry();
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
        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (activeEditor != null)
            {
                activeEditor.MouseDown -= new MouseEventHandler(Editor_MouseDown);
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
                view.ActiveEditor.MouseDown += new MouseEventHandler(Editor_MouseDown);
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


    }
}