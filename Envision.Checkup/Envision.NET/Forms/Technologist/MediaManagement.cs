using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RIS.BusinessLogic;
using RIS.Common;
using RIS.Common.Common;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;


namespace RIS.Forms.Technologist
{
    public partial class MediaManagement : Form
    {
        private int a = 0;//for grid
        private string examUID, examname, examid, examAccession,orderid;
        private string loadID, examidEdit; //for Edit 
        private string ReleaseID, hisID;
        private int unitRe, empidRe;
        private string unit, empid, checkstatus;
        RIS.Forms.GBLMessage.MyMessageBox msg = new RIS.Forms.GBLMessage.MyMessageBox();
        RIS.Common.Common.GBLEnvVariable env = new RIS.Common.Common.GBLEnvVariable();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public MediaManagement(UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            this.CloseControl = Cls;
            BindData();
            setDefaultRelease();
            tLoadMedia.PageVisible = false;
            layoutControlGroup1.Enabled = false;
            layoutControlGroup2.Enabled = false;
            layoutControlGroup3.Enabled = false;
        }
        private void BindData()
        {
            cmbMediaTypeLoad.Properties.Items.Clear();
            cmbRequestByLoad.Properties.Items.Clear();
            cmbReasonLoad.Properties.Items.Clear();
            cmbReasonLoad.Text = "Choose..";

            dateEdit1.Text = DateTime.Now.ToString("dd/MM/yyy");

            EnableData(false);
            EnableSearchLoad(false);


            SetComboBox();
            txtHNLoad.Focus();

            ProcessGetRISLoadmedia geLo = new ProcessGetRISLoadmedia();
            geLo.RISLoadmedia.SELECTCASE = 4;
            geLo.Invoke();


            DataSet ds = geLo.Result;
            gridControl1.DataSource = ds.Tables[0];
            SetColumnGrid();

            //---set Release
            SetNullSearchRelease();
            SetEnableSearchRelease(false);

        }

        #region BarControl

        private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tLoadMedia)
            {
                EnableData(false);
                btnSaveLoad.Text = "Save";
                checkstatus = "New";
                chkNoHNLoad.Checked = false;
                gridControl1.DataSource = null;
                CancelLoad();
                EnableData(true);
                txtHNLoad.Focus();
            }
            else if (xtraTabControl1.SelectedTabPage == tReleaseMedia)
            {
                checkstatus = "New";
                gridControl1.DataSource = null;
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchLoad)
            {
                EnableData(false);

                #region Switch Tab

                tLoadMedia.PageVisible = true;
                tReleaseMedia.PageVisible = true;
                tSearchLoad.PageVisible = false;
                tSearchRelease.PageVisible = false;

                #endregion

                btnSaveLoad.Text = "Save";
                checkstatus = "New";
                chkNoHNLoad.Checked = false;
                gridControl1.DataSource = null;
                CancelLoad();
                EnableData(true);
                txtHNLoad.Focus();
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchRelease)
            {
                #region Switch Tab

                tLoadMedia.PageVisible = true;
                tReleaseMedia.PageVisible = true;
                tSearchLoad.PageVisible = false;
                tSearchRelease.PageVisible = false;

                #endregion

                checkstatus = "New";
                gridControl1.DataSource = null;
            }

        }
        private void barEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tLoadMedia)
            {
                EnableData(false);
                btnSaveLoad.Text = "Update";
                checkstatus = "Edit";
                chkNoHNLoad.Enabled = false;
                CancelLoad();

                txtHNLoad.Enabled = true;
                btnSeachHNLoad.Enabled = true;
                txtNameLoad.Enabled = true;
            }
            else if (xtraTabControl1.SelectedTabPage == tReleaseMedia)
            {
                checkstatus = "Edit";
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchLoad)
            {
                if (gridControl2.DataSource == null || advBandedGridView2.FocusedRowHandle < 0)
                {
                    return;
                }
                DataTable dtg = (DataTable)gridControl2.DataSource;
                EnableData(true);
                btnSaveLoad.Text = "Update";
                checkstatus = "Edit";
                chkNoHNLoad.Enabled = false;

                loadID = dtg.Rows[advBandedGridView2.FocusedRowHandle]["Request No."].ToString();
                examidEdit = dtg.Rows[advBandedGridView2.FocusedRowHandle]["Exam Code"].ToString();
                SelectDataWhenEdit();

                #region Switch Tab

                tLoadMedia.PageVisible = true;
                tReleaseMedia.PageVisible = true;
                tSearchLoad.PageVisible = false;
                tSearchRelease.PageVisible = false;

                #endregion
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchRelease)
            {
                if (grdRelease.DataSource == null || viewsRelease.FocusedRowHandle < 0)
                {
                    return;
                }
                checkstatus = "Edit";

                DataTable dtgR = (DataTable)grdRelease.DataSource;

                ReleaseID = dtgR.Rows[viewsRelease.FocusedRowHandle]["Request No."].ToString();

                //txtHNRelease.Focus();

                #region Switch Tab

                tLoadMedia.PageVisible = true;
                tReleaseMedia.PageVisible = true;
                tSearchLoad.PageVisible = false;
                tSearchRelease.PageVisible = false;

                #endregion

                xtraTabControl1.SelectedTabPage = tReleaseMedia;
            }

        }
        private void barDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tLoadMedia)
            {
                EnableData(false);
                btnSaveLoad.Text = "Delete";
                checkstatus = "Delete";
                chkNoHNLoad.Enabled = false;
                CancelLoad();

                txtHNLoad.Enabled = true;
                btnSeachHNLoad.Enabled = true;
                txtNameLoad.Enabled = true;
            }
            else if (xtraTabControl1.SelectedTabPage == tReleaseMedia)
            {
                checkstatus = "Delete";
            }
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
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
        private void barSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowColumnGrid(0);
            tLoadMedia.PageVisible = false;
            tReleaseMedia.PageVisible = false;
            tSearchLoad.PageVisible = true;
            tSearchRelease.PageVisible = true;

            deSearchFromLoad.Enabled = false;
            deSearchToLoad.Enabled = false;
            deSearchFromLoad.Text = "";
            deSearchToLoad.Text = "";


        }

        private void barMediaHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tLoadMedia.PageVisible = true;
            tReleaseMedia.PageVisible = true;
            tSearchLoad.PageVisible = false;
            tSearchRelease.PageVisible = false;

            //deSearchFromLoad.Text = "";
            //deSearchToLoad.Text = "";
        }

        #endregion

        #region LoadMedia Page

        private void EnableData(bool flag)
        {
            #region LoadMedia
            txtHNLoad.Enabled = flag;
            txtNameLoad.Enabled = flag;
            cmbMediaTypeLoad.Enabled = flag;
            cmbReasonLoad.Enabled = flag;
            cmbRequestByLoad.Enabled = flag;
            memoEdit1.Enabled = flag;
            chkNoHNLoad.Enabled = flag;
            dateEdit1.Enabled = flag;
            gridControl1.Enabled = flag;
            btnSeachHNLoad.Enabled = flag;
            btnSeachRequestByLoad.Enabled = flag;
            btnCancelLoad.Enabled = flag;
            btnSaveLoad.Enabled = flag;
            #endregion


        }
        private void SelectRequestBy()
        {
            cmbRequestByLoad.Properties.Items.Clear();

            ProcessGetRISLoadmedia geLo = new ProcessGetRISLoadmedia();
            geLo.RISLoadmedia.SELECTCASE = 3;
            geLo.Invoke();
            DataSet ds = geLo.Result;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                cmbRequestByLoad.Properties.Items.Add(ds.Tables[0].Rows[i]["Assigned Rad."].ToString());

            }
        }
        private void chkNoHNLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoHNLoad.Checked == true)
            {
                txtHNLoad.Enabled = false;
                txtNameLoad.Enabled = false;
                btnSeachHNLoad.Enabled = false;
                txtRequestNoLoad.Text = "Auto";
                SelectAll();
            }
            else
            {
                txtHNLoad.Enabled = true;
                txtNameLoad.Enabled = true;
                btnSeachHNLoad.Enabled = true;
                txtRequestNoLoad.Text = "";
                txtHNLoad.Focus();
            }
        }
        private void btnSeachHNLoad_Click(object sender, EventArgs e)
        {
            if (checkstatus == "New")
            {
                RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSeachHNLoad_Clicks);
                lv.AddColumn("HN", "HN", true, true);
                lv.AddColumn("FULLNAME", "Name", true, true);
                lv.Text = "Detail List";

                ProcessGetRISLoadmedia geL = new ProcessGetRISLoadmedia();
                geL.RISLoadmedia.SELECTCASE = 21;
                geL.Invoke();

                lv.Data = geL.Result.Tables[0];
                lv.ShowBox();
            }
            else if (checkstatus == "Edit")
            {
                RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSeachHNLoad_Clicks);
                lv.AddColumn("LOAD_ID", "ID", true, true);
                lv.AddColumn("HN", "HN", true, true);
                lv.AddColumn("FULLNAME", "Name", true, true);
                lv.AddColumn("EXAM_NAME", "EXAM", true, true);
                lv.Text = "Detail List";

                ProcessGetRISLoadmedia geL = new ProcessGetRISLoadmedia();
                geL.RISLoadmedia.SELECTCASE = 22;
                geL.Invoke();

                lv.Data = geL.Result.Tables[0];
                lv.ShowBox();
            }
            else if (checkstatus == "Delete")
            {
                RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSeachHNLoad_Clicks);
                lv.AddColumn("LOAD_ID", "ID", true, true);
                lv.AddColumn("HN", "HN", true, true);
                lv.AddColumn("FULLNAME", "Name", true, true);
                lv.AddColumn("EXAM_NAME", "EXAM", true, true);
                lv.Text = "Detail List";

                ProcessGetRISLoadmedia geL = new ProcessGetRISLoadmedia();
                geL.RISLoadmedia.SELECTCASE = 22;
                geL.Invoke();

                lv.Data = geL.Result.Tables[0];
                lv.ShowBox();
            }
        }
        private void btnSeachHNLoad_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            if (checkstatus == "Edit")
            {
                string[] retValue = e.NewValue.Split(new Char[] { '^' });
                loadID = retValue[0];
                txtNameLoad.Text = retValue[2];
                examidEdit = retValue[3];
                txtHNLoad.Text = retValue[1];
                SelectDataWhenEdit();


            }
            else if (checkstatus == "Delete")
            {
                string[] retValue = e.NewValue.Split(new Char[] { '^' });
                loadID = retValue[0];
                txtNameLoad.Text = retValue[2];
                examidEdit = retValue[3];
                txtHNLoad.Text = retValue[1];
                SelectDataWhenEdit();
            }
            else if (checkstatus == "New")
            {
                string[] retValue = e.NewValue.Split(new Char[] { '^' });
                txtNameLoad.Text = retValue[1];
                txtHNLoad.Text = retValue[0];

            }
        }

        private void btnSeachRequestByLoad_Click(object sender, EventArgs e)
        {

            if (cmbRequestByLoad.Text == "Radiologist")
            {
                RIS.Forms.Lookup.LookupData lvR = new RIS.Forms.Lookup.LookupData();
                lvR.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSeachRequestByLoad_Clicks);
                lvR.AddColumn("EMP_ID", "ID", true, true);
                lvR.AddColumn("FULLNAME", "Name", true, true);
                lvR.AddColumn("REF_UNIT", "UNIT", false, true);
                lvR.Text = "Radiologist Detail List";

                ProcessGetRISLoadmedia geLR = new ProcessGetRISLoadmedia();
                geLR.RISLoadmedia.SELECTCASE = 23;
                geLR.Invoke();

                lvR.Data = geLR.Result.Tables[0];
                lvR.ShowBox();
            }
            else if (cmbRequestByLoad.Text == "Clinician")
            {
                RIS.Forms.Lookup.LookupData lvC = new RIS.Forms.Lookup.LookupData();
                lvC.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSeachRequestByLoad_Clicks);
                lvC.AddColumn("EMP_ID", "ID", true, true);
                lvC.AddColumn("FULLNAME", "Name", true, true);
                lvC.AddColumn("REF_UNIT", "UNIT", false, true);
                lvC.Text = "Radiologist Detail List";

                ProcessGetRISLoadmedia geLC = new ProcessGetRISLoadmedia();
                geLC.RISLoadmedia.SELECTCASE = 24;
                geLC.Invoke();

                lvC.Data = geLC.Result.Tables[0];
                lvC.ShowBox();
            }
            //else
            //{
            //    string id = msg.ShowAlert("UID4004", new GBLEnvVariable().CurrentLanguageID);
            //}
        }
        private void btnSeachRequestByLoad_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            unit = retValue[2];
            empid = retValue[0];

            ProcessGetRISLoadmedia geLo = new ProcessGetRISLoadmedia();
            geLo.RISLoadmedia.SELECTCASE = 5;
            geLo.RISLoadmedia.EMP_ID = Convert.ToInt32(retValue[0]);
            geLo.Invoke();
            DataSet ds = geLo.Result;

            RIS.Forms.Lookup.LookupData lvRe = new RIS.Forms.Lookup.LookupData();
            lvRe.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSeachRequestByLoad2_Clicks);
            lvRe.AddColumn("EXAM_ID", "ID", true, true);
            lvRe.AddColumn("Exam Code", "Exam", true, true);
            lvRe.AddColumn("Exam Name", "Name", true, true);
            lvRe.AddColumn("Accession NO.", "Accession NO.", true, true);
            lvRe.Text = "Exam Detail List";

            lvRe.Data = geLo.Result.Tables[0];
            lvRe.ShowBox();

        }
        private void btnSeachRequestByLoad2_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            ProcessGetRISLoadmedia geLAC = new ProcessGetRISLoadmedia();
            geLAC.RISLoadmedia.SELECTCASE = 6;
            geLAC.RISLoadmedia.ACCESSION_NO = retValue[3];
            geLAC.Invoke();

            gridControl1.DataSource = geLAC.Result.Tables[0];
            SetColumnGrid();

        }
        private void CancelLoad()
        {
            txtRequestNoLoad.Text = "";
            txtHNLoad.Text = "";
            txtNameLoad.Text = "";
            cmbMediaTypeLoad.Text = "CD/Film/ThumbDrive";
            cmbRequestByLoad.Text = "Clinician or Radiologist";
            cmbReasonLoad.Text = "Select Reason.";
            dateEdit1.Text = DateTime.Now.ToString("dd/MM/yyy");
            memoEdit1.Text = "";
            empid = null;
            //txtREQUnit.Text = "";
            unit = null;
            loadID = "";
            gridControl1.DataSource = null;
        }
        private void btnCancelLoad_Click(object sender, EventArgs e)
        {
            CancelLoad();
        }
        private void btnSaveLoad_Click(object sender, EventArgs e)
        {
            if (checkstatus == "New")
            {
                if (cmbRequestByLoad.SelectedIndex < 0)
                {
                    msg.ShowAlert("UID4004", new GBLEnvVariable().CurrentLanguageID);
                    cmbRequestByLoad.Focus();
                    return;
                }
                if (gridControl1.DataSource == null)
                {
                    msg.ShowAlert("UID4007", new GBLEnvVariable().CurrentLanguageID);
                    btnSeachRequestByLoad_Click(sender, e);
                    //cmbRequestByLoad.Focus();
                    return;
                }

                string idN = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);

                if (idN == "2")
                {
                    InsertData();
                }
                else
                {
                    return;
                }
            }
            else if (checkstatus == "Edit")
            {
                string idE = msg.ShowAlert("UID4002", new GBLEnvVariable().CurrentLanguageID);

                if (idE == "2")
                {
                    UpdateData();
                }
                else
                {
                    return;
                }
            }
            else if (checkstatus == "Delete")
            {
                string idD = msg.ShowAlert("UID4003", new GBLEnvVariable().CurrentLanguageID);
                if (idD == "2")
                {
                    DeleteData();
                }
                else
                {
                    return;
                }
            }
            CancelLoad();
            BindData();
        }
        private void SelectDataWhenEdit()
        {
            //if (checkstatus == "Edit")
            //{
            ProcessGetRISLoadmedia SelectLoad = new ProcessGetRISLoadmedia();
            SelectLoad.RISLoadmedia.SELECTCASE = 100;
            SelectLoad.RISLoadmedia.LOAD_ID = Convert.ToInt32(loadID);
            SelectLoad.Invoke();
            DataSet ds = SelectLoad.Result;


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (gridControl2.DataSource != null)
                {
                    txtHNLoad.Text = ds.Tables[0].Rows[i]["HN"].ToString();
                    txtNameLoad.Text = ds.Tables[0].Rows[i]["FULLNAME"].ToString();
                }
                txtRequestNoLoad.Text = ds.Tables[0].Rows[i]["LOAD_ID"].ToString();
                empid = ds.Tables[0].Rows[i]["REQ_DOC"].ToString();
                unit = ds.Tables[0].Rows[i]["REQ_UNIT"].ToString();
                if (ds.Tables[0].Rows[i]["REQ_BY"].ToString() == "C")
                {
                    cmbRequestByLoad.Text = "Clinician";
                }
                else if (ds.Tables[0].Rows[i]["REQ_BY"].ToString() == "R")
                {
                    cmbRequestByLoad.Text = "Radiologist";
                }
                else
                {
                    cmbRequestByLoad.Text = "Clinician of Radiologist";
                }

                if (ds.Tables[0].Rows[i]["MEDIA_TYPE"].ToString() == "C")
                {
                    cmbMediaTypeLoad.Text = "CD";
                }
                else if (ds.Tables[0].Rows[i]["MEDIA_TYPE"].ToString() == "T")
                {
                    cmbMediaTypeLoad.Text = "ThumbDrive";
                }
                else if (ds.Tables[0].Rows[i]["MEDIA_TYPE"].ToString() == "F")
                {
                    cmbMediaTypeLoad.Text = "Film";
                }
                else
                {
                    cmbMediaTypeLoad.Text = "CD/Film/ThumbDrive";
                }

                if (ds.Tables[0].Rows[i]["REASON"].ToString() == "F")
                {
                    cmbReasonLoad.Text = "First Reason";
                }
                else if (ds.Tables[0].Rows[i]["REASON"].ToString() == "S")
                {
                    cmbReasonLoad.Text = "Second Reason";
                }
                else
                {
                    cmbReasonLoad.Text = "Select Reason";
                }
                dateEdit1.Text = ds.Tables[0].Rows[i]["LOAD_START_TIME"].ToString();
                memoEdit1.Text = ds.Tables[0].Rows[i]["COMMENT"].ToString();
            }
            ProcessGetRISLoadmediadtl loDtl = new ProcessGetRISLoadmediadtl();
            loDtl.RISLoadmediadtl.LOAD_ID = Convert.ToInt32(loadID);
            loDtl.RISLoadmediadtl.EXAM_ID = Convert.ToInt32(examidEdit);
            loDtl.RISLoadmediadtl.SELECTCASE = 0;
            loDtl.Invoke();
            DataSet dsDtl = loDtl.Result;
            gridControl1.DataSource = dsDtl.Tables[0];
            SetColumnGrid();
            //}
            EnableData(true);
            chkNoHNLoad.Enabled = false;
        }
        #endregion

        #region Search LoadMedia Page

        private void EnableSearchLoad(bool flag)
        {
            deSearchFromLoad.Enabled = flag;
            deSearchToLoad.Enabled = flag;
        }
        private void chkSearchLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchLoad.Checked == true)
            {
                deSearchFromLoad.DateTime = DateTime.Now;
                deSearchToLoad.DateTime = DateTime.Now;
                gridControl2.DataSource = null;
                EnableSearchLoad(true);
            }
            if (chkSearchLoad.Checked == false)
            {
                deSearchFromLoad.Text = "";
                deSearchToLoad.Text = "";
                gridControl2.DataSource = null;
                EnableSearchLoad(false);
            }
        }
        private void SetColumnGridSearchLoad()
        {

            advBandedGridView2.OptionsView.ShowBands = false;
            advBandedGridView2.OptionsView.ShowGroupPanel = false;
            advBandedGridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            advBandedGridView2.OptionsSelection.MultiSelect = true;
            advBandedGridView2.OptionsView.ColumnAutoWidth = true;

            advBandedGridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            for (int i = 0; i < advBandedGridView2.Columns.Count; i++)
            {
                advBandedGridView2.Columns[i].Visible = false;
            }

            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = 1;
            chk.ValueUnchecked = 0;
            chk.CheckStyle = CheckStyles.Standard;
            chk.NullStyle = StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = FormatType.Custom;
            //chk.Click += new EventHandler(chk_Click);

            //advBandedGridView2.Columns["All"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //advBandedGridView2.Columns["All"].Visible = true;
            //advBandedGridView2.Columns["All"].Caption = "All";
            //advBandedGridView2.Columns["All"].ColumnEdit = chk;
            //advBandedGridView2.Columns["All"].OptionsColumn.ReadOnly = false;
            //advBandedGridView2.Columns["All"].Width = 40;

            advBandedGridView2.Columns["Request No."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["Request No."].Visible = true;
            advBandedGridView2.Columns["Request No."].Caption = "Request No.";
            advBandedGridView2.Columns["Request No."].OptionsColumn.ReadOnly = true;

            advBandedGridView2.Columns["Exam Code"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["Exam Code"].Visible = true;
            advBandedGridView2.Columns["Exam Code"].Caption = "Exam Code";
            advBandedGridView2.Columns["Exam Code"].OptionsColumn.ReadOnly = true;

            advBandedGridView2.Columns["Exam Name"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["Exam Name"].Visible = true;
            advBandedGridView2.Columns["Exam Name"].Caption = "Exam Name";
            advBandedGridView2.Columns["Exam Name"].OptionsColumn.ReadOnly = true;

            advBandedGridView2.Columns["Load Date"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["Load Date"].Visible = true;
            advBandedGridView2.Columns["Load Date"].Caption = "Load Date";
            advBandedGridView2.Columns["Load Date"].OptionsColumn.ReadOnly = true;

            advBandedGridView2.Columns["Request By."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["Request By."].Visible = true;
            advBandedGridView2.Columns["Request By."].Caption = "Request By.";
            advBandedGridView2.Columns["Request By."].OptionsColumn.ReadOnly = true;

            RepositoryItemComboBox comboReason = new RepositoryItemComboBox();
            comboReason.Items.Add("First reason");
            comboReason.Items.Add("Second reason");

            advBandedGridView2.Columns["Reason"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["Reason"].Visible = true;
            advBandedGridView2.Columns["Reason"].Caption = "Reason";
            advBandedGridView2.Columns["Reason"].ColumnEdit = comboReason;
            advBandedGridView2.Columns["Reason"].OptionsColumn.ReadOnly = true;

            RepositoryItemMemoExEdit exmeno = new RepositoryItemMemoExEdit();
            advBandedGridView2.Columns["Comment"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["Comment"].Visible = true;
            advBandedGridView2.Columns["Comment"].Caption = "Comment";
            advBandedGridView2.Columns["Comment"].ColumnEdit = exmeno;
            advBandedGridView2.Columns["Comment"].OptionsColumn.ReadOnly = true;

            RepositoryItemButtonEdit btnDel = new RepositoryItemButtonEdit();
            btnDel.Buttons[0].Kind = ButtonPredefines.Delete;
            btnDel.ButtonsStyle = BorderStyles.Office2003;
            btnDel.TextEditStyle = TextEditStyles.HideTextEditor;
            btnDel.ButtonClick += new ButtonPressedEventHandler(btnDel_ButtonClick);

            advBandedGridView2.Columns["DEL"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView2.Columns["DEL"].Visible = true;
            advBandedGridView2.Columns["DEL"].Caption = "";
            advBandedGridView2.Columns["DEL"].ColumnEdit = btnDel;
            advBandedGridView2.Columns["DEL"].OptionsColumn.ReadOnly = true;

        }

        private void btnDel_ButtonClick(object sender, EventArgs e)
        {
            string idL = msg.ShowAlert("UID4003", new GBLEnvVariable().CurrentLanguageID);

            if (idL == "2")
            {
                DataTable dtGL = (DataTable)gridControl2.DataSource;
                dtGL.AcceptChanges();
                loadID = dtGL.Rows[advBandedGridView2.FocusedRowHandle]["Request No."].ToString();
                DeleteData();
                advBandedGridView2.DeleteSelectedRows();
                dtGL.AcceptChanges();
                advBandedGridView2.RefreshData();
            }
            return;
        }
        private void chk_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.CheckEdit chk  = (DevExpress.XtraEditors.CheckEdit)sender;
            //chk.Checked = true;
            //chk.Checked = 

        }

        private void btnGOSearchLoad_Click(object sender, EventArgs e)
        {
            if (chkSearchLoad.Checked == true)
            {
                ProcessGetRISLoadmedia load1 = new ProcessGetRISLoadmedia();
                load1.RISLoadmedia.SELECTCASE = 2;
                load1.RISLoadmedia.FROM_DATE = Convert.ToDateTime(deSearchFromLoad.DateTime.ToString("dd-MM-yy "));
                load1.RISLoadmedia.TO_DATE = Convert.ToDateTime(deSearchToLoad.DateTime.ToString("dd-MM-yy"));
                load1.Invoke();
                DataSet dss = load1.Result;
                gridControl2.DataSource = dss.Tables[0]; // ไม่ยอม setgrid
                SetColumnGridSearchLoad();
            }
            else
            {
                ProcessGetRISLoadmedia load = new ProcessGetRISLoadmedia();
                load.RISLoadmedia.SELECTCASE = 0;
                load.Invoke();
                DataSet ds = load.Result;
                gridControl2.DataSource = ds.Tables[0];
                SetColumnGridSearchLoad();
            }

        }
        private void btnSaveSearchLoad_Click(object sender, EventArgs e)
        {
            if (gridControl2.DataSource != null)
            {
                DataTable dtt = (DataTable)gridControl2.DataSource;
                DataTable dtt2 = dtt.Copy();

                dtt2.AcceptChanges();
                for (int i = 0; i < dtt2.Rows.Count; i++)
                {
                    ProcessUpdateRISLoadmedia uplo = new ProcessUpdateRISLoadmedia();
                    uplo.RISLoadmedia.LOAD_DT = Convert.ToDateTime(dtt2.Rows[i]["Load Date"]);
                    uplo.RISLoadmedia.REQ_BY = dtt2.Rows[i]["Request By."].ToString();
                    uplo.RISLoadmedia.REASON = dtt2.Rows[i]["Reason"].ToString();
                    uplo.RISLoadmedia.COMMENT = dtt2.Rows[i]["Comment"].ToString();
                    uplo.RISLoadmedia.LAST_MODIFIED_BY = env.UserID;
                    uplo.Invoke();

                }
            }
            gridControl2.DataSource = null;
        }
        private void btnDeleteSearchLoad_Click(object sender, EventArgs e)
        {
            advBandedGridView2.DeleteSelectedRows();
        }

        #endregion

        #region Search Release Page

        private void btnGOSearchRelease_Click(object sender, EventArgs e)
        {
            if (chkSearchRelease.Checked == false)
            {
                ProcessGetRISReleasemedia geRelese = new ProcessGetRISReleasemedia();
                geRelese.RISReleasemedia.SELECTCASE = 21;
                geRelese.Invoke();
                grdRelease.DataSource = geRelese.Result.Tables[0];
                SetColumnGridSearcRelease();
            }
            else if (chkSearchRelease.Checked == true)
            {
                ProcessGetRISReleasemedia geReleaseFT = new ProcessGetRISReleasemedia();
                geReleaseFT.RISReleasemedia.SELECTCASE = 23;
                geReleaseFT.RISReleasemedia.TODATE = deToSearchRelease.DateTime;
                geReleaseFT.RISReleasemedia.FROMDATE = deFromSearchRelease.DateTime;
                geReleaseFT.Invoke();
                grdRelease.DataSource = geReleaseFT.Result.Tables[0];
                SetColumnGridSearcRelease();
            }
        }
        private void SetNullSearchRelease()
        {
            ProcessGetRISReleasemedia geReleaseNull = new ProcessGetRISReleasemedia();
            geReleaseNull.RISReleasemedia.SELECTCASE = 22;
            geReleaseNull.Invoke();
            grdRelease.DataSource = geReleaseNull.Result.Tables[0];
            SetColumnGridSearcRelease();
        }
        private void SetColumnGridSearcRelease()
        {
            viewsRelease.OptionsView.ShowBands = false;
            viewsRelease.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewsRelease.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            for (int i = 0; i < viewsRelease.Columns.Count; i++)
            {
                viewsRelease.Columns[i].Visible = false;
            }

            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = 1;
            chk.ValueUnchecked = 0;
            chk.CheckStyle = CheckStyles.Standard;
            chk.NullStyle = StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = FormatType.Custom;

            viewsRelease.Columns["Request No."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Request No."].Visible = true;
            viewsRelease.Columns["Request No."].Caption = "Request No.";
            viewsRelease.Columns["Request No."].OptionsColumn.ReadOnly = true;


            viewsRelease.Columns["Exam Code"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Exam Code"].Visible = true;
            viewsRelease.Columns["Exam Code"].Caption = "Exam Code";
            viewsRelease.Columns["Exam Code"].OptionsColumn.ReadOnly = true;

            viewsRelease.Columns["Exam Name"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Exam Name"].Visible = true;
            viewsRelease.Columns["Exam Name"].Caption = "Exam Name";
            viewsRelease.Columns["Exam Name"].OptionsColumn.ReadOnly = true;

            viewsRelease.Columns["Accession No."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Accession No."].Visible = true;
            viewsRelease.Columns["Accession No."].Caption = "Accession No.";
            viewsRelease.Columns["Accession No."].OptionsColumn.ReadOnly = true;

            viewsRelease.Columns["Release Date"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Release Date"].Visible = true;
            viewsRelease.Columns["Release Date"].Caption = "Release Date";
            viewsRelease.Columns["Release Date"].OptionsColumn.ReadOnly = true;


            viewsRelease.Columns["Request By"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Request By"].Visible = true;
            viewsRelease.Columns["Request By"].Caption = "Request By";
            viewsRelease.Columns["Request By"].OptionsColumn.ReadOnly = true;
            viewsRelease.Columns["Request By"].OptionsColumn.FixedWidth = true;

            RepositoryItemComboBox comboReasonRe = new RepositoryItemComboBox();
            comboReasonRe.Items.Add("First reason");
            comboReasonRe.Items.Add("Second reason");

            viewsRelease.Columns["Reason"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Reason"].Visible = true;
            viewsRelease.Columns["Reason"].Caption = "Reason";
            viewsRelease.Columns["Reason"].ColumnEdit = comboReasonRe;
            viewsRelease.Columns["Reason"].OptionsColumn.ReadOnly = true;

            RepositoryItemMemoExEdit exmenoRe = new RepositoryItemMemoExEdit();
            viewsRelease.Columns["Comment"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["Comment"].Visible = true;
            viewsRelease.Columns["Comment"].Caption = "Comment";
            viewsRelease.Columns["Comment"].ColumnEdit = exmenoRe;
            viewsRelease.Columns["Comment"].OptionsColumn.ReadOnly = true;

            RepositoryItemButtonEdit btnDel = new RepositoryItemButtonEdit();
            btnDel.Buttons[0].Kind = ButtonPredefines.Delete;
            btnDel.ButtonsStyle = BorderStyles.Office2003;
            btnDel.TextEditStyle = TextEditStyles.HideTextEditor;
            btnDel.ButtonClick += new ButtonPressedEventHandler(btnDel_ButtonClick);
            viewsRelease.Columns["DEL"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewsRelease.Columns["DEL"].Visible = true;
            viewsRelease.Columns["DEL"].Caption = "";
            viewsRelease.Columns["DEL"].ColumnEdit = btnDel;
            viewsRelease.Columns["DEL"].OptionsColumn.ReadOnly = true;

        }

        private void btnDel_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            string idR = msg.ShowAlert("UID4003", new GBLEnvVariable().CurrentLanguageID);

            if (idR == "2")
            {
                DataTable dtGR = (DataTable)grdRelease.DataSource;
                dtGR.AcceptChanges();

                ReleaseID = dtGR.Rows[viewsRelease.FocusedRowHandle]["Request No."].ToString();
                DeleteData();
                viewsRelease.DeleteSelectedRows();
                dtGR.AcceptChanges();
                viewsRelease.RefreshData();
            }
            return;
        }
        private void SetEnableSearchRelease(bool flag)
        {
            deFromSearchRelease.Enabled = flag;
            deToSearchRelease.Enabled = flag;
        }

        private void chkSearchRelease_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchRelease.Checked == true)
            {
                SetEnableSearchRelease(true);
                grdRelease.DataSource = null;
                deToSearchRelease.DateTime = DateTime.Now;
                deFromSearchRelease.DateTime = DateTime.Now;
            }
            else
            {
                grdRelease.DataSource = null;
                SetEnableSearchRelease(false);
                deFromSearchRelease.Text = "";
                deToSearchRelease.Text = "";
            }
        }

        private void btnDeleteSearchRelease_Click(object sender, EventArgs e)
        {
            DataTable dtg = (DataTable)grdRelease.DataSource;
            dtg.AcceptChanges();

            string id = msg.ShowAlert("UID4003", new GBLEnvVariable().CurrentLanguageID);
            if (id == "2")
            {
                ProcessDeleteRISReleasemedia delRe = new ProcessDeleteRISReleasemedia();
                delRe.RISReleasemedia.RELEASE_ID = Convert.ToInt32(dtg.Rows[viewsRelease.FocusedRowHandle]["Request No."]);
                delRe.Invoke();
            }
        }

        #endregion

        private struct MyItem
        {
            public string Key;
            public string Value;
        }

        private void SelectAll()
        {
            cmbRequestByLoad.SelectionStart = 0;
            cmbRequestByLoad.SelectionLength = cmbRequestByLoad.Text.Length;
            cmbRequestByLoad.Focus();

        }
        private void SetColumnGrid()
        {
            advBandedGridView1.OptionsView.ShowGroupPanel = false;
            advBandedGridView1.OptionsView.ShowBands = false;
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            advBandedGridView1.OptionsBehavior.Editable = false;
            advBandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
            {
                advBandedGridView1.Columns[i].Visible = false;
            }

            advBandedGridView1.Columns["EXAM_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["EXAM_ID"].Visible = false;
            advBandedGridView1.Columns["EXAM_ID"].Caption = "EXAM_ID";
            advBandedGridView1.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["EXAM_ID"].Width = 10;

            advBandedGridView1.Columns["Exam Code"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Exam Code"].Visible = true;
            advBandedGridView1.Columns["Exam Code"].Caption = "Exam Code";
            advBandedGridView1.Columns["Exam Code"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Exam Code"].Width = 90;

            advBandedGridView1.Columns["Exam Name"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Exam Name"].Visible = true;
            advBandedGridView1.Columns["Exam Name"].Caption = "Exam Name";
            advBandedGridView1.Columns["Exam Name"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Exam Name"].Width = 250;

            advBandedGridView1.Columns["Accession NO."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Accession NO."].Visible = false;
            advBandedGridView1.Columns["Accession NO."].Caption = "Accession NO.";
            advBandedGridView1.Columns["Accession NO."].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Accession NO."].Width = 250;

        }
        private void ShowColumnGrid(int flag)
        {
            if (flag == 0)
            {
                ProcessGetRISLoadmedia lo = new ProcessGetRISLoadmedia();
                lo.RISLoadmedia.SELECTCASE = 1;
                lo.Invoke();
                DataSet ds = lo.Result;
                gridControl2.DataSource = ds.Tables[0];
                SetColumnGridSearchLoad();
            }
        }
        private void SetComboBox()
        {
            #region LoadMedia

            cmbRequestByLoad.Text = "Clinician or Radiologist";

            cmbMediaTypeLoad.Text = "CD/Film/ThumbDrive";
            cmbMediaTypeLoad.Properties.Items.Add("CD");
            cmbMediaTypeLoad.Properties.Items.Add("ThumbDrive");
            cmbMediaTypeLoad.Properties.Items.Add("Film");

            cmbReasonLoad.Text = "Select Reason";
            cmbReasonLoad.Properties.Items.Add("First Reason");
            cmbReasonLoad.Properties.Items.Add("Second Reason");

            cmbRequestByLoad.Text = "Clinician or Radiologist";
            cmbRequestByLoad.Properties.Items.Add("Clinician");
            cmbRequestByLoad.Properties.Items.Add("Radiologist");

            #endregion
        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tLoadMedia)
            {

            }
            else if (xtraTabControl1.SelectedTabPage == tReleaseMedia)
            {
                EnableData(false);
                CancelLoad();
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchLoad)
            {
                gridControl2.DataSource = null;
                EnableSearchLoad(false);
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchRelease)
            {
                grdRelease.DataSource = null;
                SetEnableSearchRelease(false);
            }
        }
        private void InsertData()
        {


            if (xtraTabControl1.SelectedTabPage == tLoadMedia)
            {

                #region Insert LoadMedia
                if (chkNoHNLoad.Checked == false)
                {
                    if (txtHNLoad.Text == "")
                    {
                        return;
                    }
                }


                SqlTransaction tran = null;
                SqlConnection con = null;
                int RecieceID;



                //int b = a;

                try
                {
                    DataAccess.DataAccessBase basedate = new RIS.DataAccess.DataAccessBase();
                    con = basedate.GetSQLConnection();

                    con.Open();
                    tran = con.BeginTransaction();



                    ProcessAddRISLoadmedia load = new ProcessAddRISLoadmedia(tran);

                    if (chkNoHNLoad.Checked == true)
                    {
                        load.RISLoadmedia.HN = "0";
                    }
                    else
                    {
                        load.RISLoadmedia.HN = txtHNLoad.Text;
                    }


                    if (cmbRequestByLoad.Text == "Clinician")
                    {
                        load.RISLoadmedia.REQ_BY = "C";
                    }
                    else if (cmbRequestByLoad.Text == "Radiologist")
                    {
                        load.RISLoadmedia.REQ_BY = "R";
                    }
                    else
                    {
                        load.RISLoadmedia.REQ_BY = "0";
                    }
                    if (unit != null)
                    {
                        load.RISLoadmedia.REQ_UNIT = Convert.ToInt32(unit);
                    }
                    if (empid != null)
                    {
                        load.RISLoadmedia.REQ_DOC = Convert.ToInt32(empid);
                    }

                    #region i make it

                    load.RISLoadmedia.VISIT_NO = "Visit";
                    load.RISLoadmedia.ADMISSION_NO = "Addmission";

                    #endregion

                    if (cmbMediaTypeLoad.Text == "CD")
                    {
                        load.RISLoadmedia.MEDIA_TYPE = "C";
                    }
                    else if (cmbMediaTypeLoad.Text == "ThumbDrive")
                    {
                        load.RISLoadmedia.MEDIA_TYPE = "T";
                    }
                    else if (cmbMediaTypeLoad.Text == "Film")
                    {
                        load.RISLoadmedia.MEDIA_TYPE = "F";
                    }
                    else
                    {
                        load.RISLoadmedia.MEDIA_TYPE = "0";
                    }

                    if (cmbReasonLoad.EditValue != null)
                    {
                        if (cmbReasonLoad.SelectedIndex == 0)
                        {
                            load.RISLoadmedia.REASON = "F";
                        }
                        else if (cmbReasonLoad.SelectedIndex == 1)
                        {
                            load.RISLoadmedia.REASON = "S";
                        }
                        else
                        {
                            load.RISLoadmedia.REASON = "0";
                        }//not null
                    }
                    else
                    {
                        load.RISLoadmedia.REASON = "0";
                    }
                    if (dateEdit1.DateTime != null)
                    {
                        load.RISLoadmedia.LOAD_START_TIME = dateEdit1.DateTime.Date; //not null
                    }
                    else
                    {
                        load.RISLoadmedia.LOAD_START_TIME = DateTime.Now;
                    }

                    load.RISLoadmedia.COMMENT = memoEdit1.Text;
                    load.RISLoadmedia.CREATED_BY = env.UserID;
                    load.RISLoadmedia.LAST_MODIFIED_BY = env.UserID;



                    load.Invoke();
                    RecieceID = load.RISLoadmedia.LOAD_ID;

                    //----insert MediaDtl

                    ProcessAddRISLoadmediadtl loaddtl = new ProcessAddRISLoadmediadtl(tran);
                    try
                    {
                        DataTable dtT = new DataTable();
                        dtT = (DataTable)gridControl1.DataSource;
                        dtT.AcceptChanges();
                        for (int i = 0; i < dtT.Rows.Count; i++)
                        {

                            loaddtl.RISLoadmediadtl.LOAD_ID = load.RISLoadmedia.LOAD_ID;
                            loaddtl.RISLoadmediadtl.EXAM_ID = Convert.ToInt32(dtT.Rows[i]["EXAM_ID"].ToString());
                            loaddtl.RISLoadmediadtl.ACCESSION_NO = dtT.Rows[i]["Accession NO."].ToString();
                            loaddtl.RISLoadmediadtl.CREATED_BY = env.UserID;
                            loaddtl.RISLoadmediadtl.LAST_MODIFIED_BY = env.UserID;

                            loaddtl.Invoke();
                        }

                    }
                    catch { }

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    tran.Dispose();
                }



                #endregion

            }

        }
        private void UpdateData()
        {
            if (xtraTabControl1.SelectedTabPage == tLoadMedia)
            {
                #region Update Loadmedia
                if (loadID == "")
                {
                    return;
                }

                ProcessUpdateRISLoadmedia loadUp = new ProcessUpdateRISLoadmedia();
                loadUp.RISLoadmedia.LOAD_ID = Convert.ToInt32(loadID);
                loadUp.RISLoadmedia.HN = txtHNLoad.Text;

                #region i make it

                loadUp.RISLoadmedia.VISIT_NO = "Visit";
                loadUp.RISLoadmedia.ADMISSION_NO = "Addmission";

                #endregion


                if (dateEdit1.DateTime != null)
                {
                    loadUp.RISLoadmedia.LOAD_START_TIME = dateEdit1.DateTime.Date; //not null
                }
                else
                {
                    loadUp.RISLoadmedia.LOAD_START_TIME = DateTime.Now;
                }

                if (cmbRequestByLoad.Text == "Clinician")
                {
                    loadUp.RISLoadmedia.REQ_BY = "C";
                }
                else if (cmbRequestByLoad.Text == "Radiologist")
                {
                    loadUp.RISLoadmedia.REQ_BY = "R";
                }
                else
                {
                    loadUp.RISLoadmedia.REQ_BY = "0";
                }
                if (unit != null)
                {
                    loadUp.RISLoadmedia.REQ_UNIT = Convert.ToInt32(unit);
                }
                //else
                //{
                //    loadUp.RISLoadmedia.REQ_UNIT = 0;
                //}

                loadUp.RISLoadmedia.REQ_DOC = Convert.ToInt32(empid);


                if (cmbMediaTypeLoad.Text == "CD")
                {
                    loadUp.RISLoadmedia.MEDIA_TYPE = "C";
                }
                else if (cmbMediaTypeLoad.Text == "ThumbDrive")
                {
                    loadUp.RISLoadmedia.MEDIA_TYPE = "T";
                }
                else if (cmbMediaTypeLoad.Text == "Film")
                {
                    loadUp.RISLoadmedia.MEDIA_TYPE = "F";
                }
                else
                {
                    loadUp.RISLoadmedia.MEDIA_TYPE = "0";
                }

                if (cmbReasonLoad.EditValue != null)
                {
                    if (cmbReasonLoad.SelectedIndex == 0)
                    {
                        loadUp.RISLoadmedia.REASON = "F";
                    }
                    else if (cmbReasonLoad.SelectedIndex == 1)
                    {
                        loadUp.RISLoadmedia.REASON = "S";
                    }
                    else
                    {
                        loadUp.RISLoadmedia.REASON = "0";
                    }//not null
                }
                else
                {
                    loadUp.RISLoadmedia.REASON = "0";
                }


                loadUp.RISLoadmedia.COMMENT = memoEdit1.Text;
                loadUp.RISLoadmedia.LAST_MODIFIED_BY = env.UserID;

                loadUp.Invoke();

                DataTable dtG = (DataTable)gridControl1.DataSource;
                for (int G = 0; G < dtG.Rows.Count; G++)
                {
                    ProcessUpdateRISLoadmediadtl upLoDtl = new ProcessUpdateRISLoadmediadtl();
                    upLoDtl.RISLoadmediadtl.LOAD_ID = Convert.ToInt32(loadID);
                    upLoDtl.RISLoadmediadtl.EXAM_ID = Convert.ToInt32(examidEdit);
                    upLoDtl.RISLoadmediadtl.ACCESSION_NO = dtG.Rows[G]["Accession NO."].ToString();
                    upLoDtl.RISLoadmediadtl.LAST_MODIFIED_BY = env.UserID;
                    upLoDtl.Invoke();
                }

                #endregion
            }
        }
        private void DeleteData()
        {
            if (xtraTabControl1.SelectedTabPage == tLoadMedia)
            {
                #region Delete Loadmedia
                if (loadID == "")
                {
                    return;

                }

                ProcessDeleteRISLoadmediadtl deLodtl = new ProcessDeleteRISLoadmediadtl();
                deLodtl.RISLoadmediadtl.LOAD_ID = Convert.ToInt32(loadID);
                deLodtl.Invoke();

                ProcessDeleteRISLoadmedia deLo = new ProcessDeleteRISLoadmedia();
                deLo.RISLoadmedia.LOAD_ID = Convert.ToInt32(loadID);
                deLo.Invoke();

                #endregion
            }
            else if (xtraTabControl1.SelectedTabPage == tReleaseMedia)
            {
                #region Delete Releasemedia
                if (ReleaseID == "")
                {
                    return;
                }

                ProcessDeleteRISReleasemedia deRe = new ProcessDeleteRISReleasemedia();
                deRe.RISReleasemedia.RELEASE_ID = Convert.ToInt32(ReleaseID);
                deRe.Invoke();

                #endregion
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchLoad)
            {
                #region Delete Loadmedia
                if (loadID == "")
                {
                    return;
                }

                ProcessDeleteRISLoadmediadtl deLodtl = new ProcessDeleteRISLoadmediadtl();
                deLodtl.RISLoadmediadtl.LOAD_ID = Convert.ToInt32(loadID);
                deLodtl.Invoke();

                ProcessDeleteRISLoadmedia deLo = new ProcessDeleteRISLoadmedia();
                deLo.RISLoadmedia.LOAD_ID = Convert.ToInt32(loadID);
                deLo.Invoke();

                #endregion
            }
            else if (xtraTabControl1.SelectedTabPage == tSearchRelease)
            {
                #region Delete Releasemedia
                if (ReleaseID == "")
                {
                    return;
                }

                ProcessDeleteRISReleasemedia deRe = new ProcessDeleteRISReleasemedia();
                deRe.RISReleasemedia.RELEASE_ID = Convert.ToInt32(ReleaseID);
                deRe.Invoke();

                #endregion
            }
        }

        private void advBandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                a = e.FocusedRowHandle;
            }
        }




        private void barRelease_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setDefaultRelease();
            txtHN.Focus();
        }

        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtHN.Text))
                {
                    ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
                    get.RISReleasemedia.SELECTCASE = 0;
                    get.RISReleasemedia.HN = txtHN.Text.Trim();
                    get.Invoke();
                    DataTable dt = get.Result.Tables[0];
                    DataTable dt1 = get.Result.Tables[1];
                    grcData.DataSource = dt1;
                    setGridData();

                    if (dt.Rows.Count > 0)
                    {
                        txtPatientName.Text = dt.Rows[0]["PATIENTNAME"].ToString();
                        txtAge.Text = dt.Rows[0]["AGE"].ToString();
                    }
                    else
                    {
                        txtPatientName.Text = "";
                        txtAge.Text = "";
                    }
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtAccession.Focus();
            }
        }
        private void setDefaultRelease()
        {
            txtHN.Text = "";
            txtAccession.Text = "";
            txtPatientName.Text = "";
            txtAge.Text = "";

            layoutControlGroup1.Enabled = true;
            layoutControlGroup2.Enabled = true;
            layoutControlGroup3.Enabled = true;

            txtPatientName.Enabled = false;
            txtPatientName.Properties.ReadOnly = true;
            txtAge.Enabled = false;
            txtAge.Properties.ReadOnly = true;

            ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
            get.RISReleasemedia.SELECTCASE = 0;
            get.RISReleasemedia.HN = "";
            get.Invoke();
            DataTable dtData = get.Result.Tables[1];
            grcData.DataSource = dtData;
            setGridData();

            get.RISReleasemedia.SELECTCASE = 2;
            get.RISReleasemedia.ACCESSION_NO = "";
            get.Invoke();
            DataTable dtRelease = get.Result.Tables[0];
            grcRelease.DataSource = dtRelease;
            setGridRelease();
        }
        private void setGridData()
        {

            viewData.Columns["ACCESSION_NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ACCESSION_NO"].Visible = true;
            viewData.Columns["ACCESSION_NO"].Caption = "Accession No.";
            viewData.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
            viewData.Columns["ACCESSION_NO"].Width = 90;

            viewData.Columns["EXAM_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_ID"].Visible = false;
            viewData.Columns["EXAM_ID"].Caption = "Exam ID";
            viewData.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["EXAM_CODE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_CODE"].Visible = true;
            viewData.Columns["EXAM_CODE"].Caption = "Exam Code";
            viewData.Columns["EXAM_CODE"].OptionsColumn.ReadOnly = true;
            viewData.Columns["EXAM_CODE"].Width = 30;

            viewData.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_NAME"].Visible = true;
            viewData.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewData.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            viewData.Columns["EXAM_NAME"].Width = 70;

            RepositoryItemTextEdit txt = new RepositoryItemTextEdit();
            viewData.Columns["STUDY_DATETIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["STUDY_DATETIME"].Visible = true;
            viewData.Columns["STUDY_DATETIME"].ColumnEdit = txt;
            viewData.Columns["STUDY_DATETIME"].Caption = "Study data-time";
            viewData.Columns["STUDY_DATETIME"].OptionsColumn.ReadOnly = true;
            viewData.Columns["STUDY_DATETIME"].Width = 100;

            viewData.Columns["PATIENTNAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["PATIENTNAME"].Visible = false;
            viewData.Columns["PATIENTNAME"].Caption = "Patient";
            viewData.Columns["PATIENTNAME"].OptionsColumn.ReadOnly = true;

            viewData.Columns["AGE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["AGE"].Visible = false;
            viewData.Columns["AGE"].Caption = "Age";
            viewData.Columns["AGE"].OptionsColumn.ReadOnly = true;

            viewData.Columns["REG_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["REG_ID"].Visible = false;
            viewData.Columns["REG_ID"].Caption = "REG_ID";
            viewData.Columns["REG_ID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["HN"].Visible = false;
            viewData.Columns["HN"].Caption = "Hn";
            viewData.Columns["HN"].OptionsColumn.ReadOnly = true;

            viewData.Columns["ORDER_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ORDER_ID"].Visible = false;
            viewData.Columns["ORDER_ID"].Caption = "ORDER_ID";
            viewData.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["REF_UNIT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["REF_UNIT"].Visible = false;
            viewData.Columns["REF_UNIT"].Caption = "REF_UNIT";
            viewData.Columns["REF_UNIT"].OptionsColumn.ReadOnly = true;
        }
        private void setGridRelease()
        {
            viewRelease.Columns["RequestDept"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["RequestDept"].Visible = true;
            viewRelease.Columns["RequestDept"].Caption = "Request Dept.";
            viewRelease.Columns["RequestDept"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["RequestDept"].BestFit();

            viewRelease.Columns["RequestBy"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["RequestBy"].Visible = true;
            viewRelease.Columns["RequestBy"].Caption = "Requested By";
            viewRelease.Columns["RequestBy"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["RequestBy"].BestFit();

            viewRelease.Columns["MEDIA_TYPE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["MEDIA_TYPE"].Visible = true;
            viewRelease.Columns["MEDIA_TYPE"].Caption = "Media Type";
            viewRelease.Columns["MEDIA_TYPE"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["MEDIA_TYPE"].BestFit();

            viewRelease.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["QTY"].Visible = true;
            viewRelease.Columns["QTY"].Caption = "Qty";
            viewRelease.Columns["QTY"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["QTY"].BestFit();

            viewRelease.Columns["PRINTBY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["PRINTBY"].Visible = true;
            viewRelease.Columns["PRINTBY"].Caption = "Printed By";
            viewRelease.Columns["PRINTBY"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["PRINTBY"].BestFit();

            RepositoryItemTextEdit txt = new RepositoryItemTextEdit();
            viewRelease.Columns["CREATED_ON"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["CREATED_ON"].Visible = true;
            viewRelease.Columns["CREATED_ON"].ColumnEdit = txt;
            viewRelease.Columns["CREATED_ON"].Caption = "Printed Timestamp";
            viewRelease.Columns["CREATED_ON"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["CREATED_ON"].BestFit();

            RepositoryItemMemoEdit mem = new RepositoryItemMemoEdit();
            viewRelease.Columns["COMMENT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["COMMENT"].Visible = true;
            viewRelease.Columns["COMMENT"].ColumnEdit = mem;
            viewRelease.Columns["COMMENT"].Caption = "COMMENT";
            viewRelease.Columns["COMMENT"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["COMMENT"].BestFit();
        }

        private void txtAccession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtAccession.Text))
                {
                    ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
                    get.RISReleasemedia.SELECTCASE = 1;
                    get.RISReleasemedia.ACCESSION_NO = txtAccession.Text.Trim();
                    get.Invoke();
                    DataTable dt = get.Result.Tables[0];
                    grcData.DataSource = dt;
                    setGridData();

                    if (dt.Rows.Count > 0)
                    {
                        txtPatientName.Text = dt.Rows[0]["PATIENTNAME"].ToString();
                        txtAge.Text = dt.Rows[0]["AGE"].ToString();
                        txtHN.Text = dt.Rows[0]["HN"].ToString();
                    }
                    else
                    {
                        txtPatientName.Text = "";
                        txtAge.Text = "";
                        txtHN.Text = "";
                    }
                }
            }
        }

        private void viewData_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            DataTable dtData = (DataTable)grcData.DataSource;
            if (dtData.Rows.Count > 0)
            {
                DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);
                ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
                get.RISReleasemedia.SELECTCASE = 2;
                get.RISReleasemedia.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                get.Invoke();
                DataTable dtRelease = get.Result.Tables[0];
                grcRelease.DataSource = dtRelease;
                setGridRelease();
            }
        }

        private void viewData_DoubleClick(object sender, EventArgs e)
        {
            DataTable dtData = (DataTable)grcData.DataSource;
            if (dtData.Rows.Count > 0)
            {
                DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);
                frmPopupReleaseMedia frm = new frmPopupReleaseMedia(dr);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
                    get.RISReleasemedia.SELECTCASE = 2;
                    get.RISReleasemedia.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                    get.Invoke();
                    DataTable dtRelease = get.Result.Tables[0];
                    grcRelease.DataSource = dtRelease;
                }
            }
        }
    }
}