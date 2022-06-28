using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using Envision.Common;
using Miracle.Util;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;

namespace Envision.NET.Forms.Admin
{
    public partial class frmUserAccountSettings : MasterForm
    {
        #region gridlayout1 variable
        DataTable dtWL = new DataTable();
        List<string> lstUnit = new List<string>();
        List<string> lstAuth = new List<string>();
        List<string> lstJobTitle = new List<string>();
        bool preLoad = false;
        Size currentSize;
        bool createNewAccount = false;
        #endregion

        #region gridlayout2 variable
        List<string> lstUnitLayout2 = new List<string>();
        List<string> lstAuthLvLayout2 = new List<string>();
        List<string> lstDefaultLangLayout2 = new List<string>();
        DataRow drLayout2;
        string saveStatus = "";
        #endregion

        DataTable dtJobTitle;
        DataView dvJobTitle;

        public frmUserAccountSettings()
        {
            InitializeComponent();
        }
        private void frmUserAccountSettings_Load(object sender, EventArgs e)
        {
            preLoad = true;
            gvAccPreview.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.SingleRecord;
            LoadUnit();
            LoadAulthLV();
            LoadJobtitle();
            tabUserAccount.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            tabUserAccount.SelectedTabPageIndex = 0;
            layoutControlGroup3.Expanded = true;
            txtSearchUnit.SelectedIndex = 0;
            txtSearchAuthLV.SelectedIndex = 0;
            txtSearchJobTitle.SelectedIndex = 0;
            Reload();
            gvAccPreview.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;
            preLoad = false;

            txtSearch.Focus();

            base.CloseWaitDialog();
        }
        private void frmUserAccountSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabUserAccount.SelectedTabPage == pageAccDetail)
            {
                if (btnribbonAdd.Visible == true)
                {
                    if (e.KeyCode == Keys.F1)
                    {
                        LoadbtnAdd();
                    }
                    else if (e.KeyCode == Keys.F2)
                    {
                        LoadbtnUpdate();
                    }
                    else if (e.KeyCode == Keys.F3)
                    {
                        LoadbtnDelete();
                    }
                    else if (e.KeyCode == Keys.F4)
                    {
                        LoadbtnBack();
                    }
                }
                else if (btnribbonSave.Visible == true)
                {
                    if (e.KeyCode == Keys.F2)
                    {
                        LoadbtnSave();
                    }
                    else if (e.KeyCode == Keys.F3)
                    {
                        LoadbtnCancel();
                    }
                }
            }
        }

        private void LoadUnit()
        {
            ProcessGetHRUnit bg = new ProcessGetHRUnit();
            bg.Invoke();
            DataRow[] drs = bg.Result.Tables[0].Select("UNIT_TYPE='S'");
            DataTable dt = bg.Result.Tables[0].Clone();

            lstUnit.Clear();
            txtSearchUnit.Properties.Items.Clear();
            lstUnit.Add("ALL");
            txtSearchUnit.Properties.Items.Add("All Departments");
            foreach (DataRow dr in drs)
            {
                lstUnit.Add(dr["UNIT_ID"].ToString());
                txtSearchUnit.Properties.Items.Add(dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString());
            }
            lstUnit.Add("Other");
            txtSearchUnit.Properties.Items.Add("Other Departments");
        }
        private void LoadAulthLV()
        {
            ProcessGetRISAuthlevel bg = new ProcessGetRISAuthlevel();
            bg.Invoke();
            DataTable dt = bg.Result.Tables[0];

            lstAuth.Clear();
            txtSearchAuthLV.Properties.Items.Clear();
            lstAuth.Add("ALL");
            txtSearchAuthLV.Properties.Items.Add("All Authority Level");
            foreach (DataRow dr in dt.Rows)
            {
                lstAuth.Add(dr["AUTH_LEVEL_ID"].ToString());
                txtSearchAuthLV.Properties.Items.Add(dr["AUTH_LEVEL_ID"].ToString() + ":" + dr["AUTH_LEVEL_DESC"].ToString());
            }
        }
        private void LoadJobtitle()
        {
            DataSet ds = new DataSet();
            LookUpSelect lk = new LookUpSelect();
            DataTable dtData = lk.SelectHrJobtitle().Tables[0];

            lstJobTitle.Clear();
            txtSearchJobTitle.Properties.Items.Clear();
            lstJobTitle.Add("ALL");
            txtSearchJobTitle.Properties.Items.Add("All Job Title");
            foreach (DataRow dr in dtData.Rows)
            {
                lstJobTitle.Add(dr["JOB_TITLE_ID"].ToString());
                txtSearchJobTitle.Properties.Items.Add(dr["JOB_TITLE_UID"].ToString() + ":" + dr["JOB_TITLE_DESC"].ToString());
            }
        }

        private void LoadTableLayout()
        {
            ProcessGetHREmp bg = new ProcessGetHREmp();

            if (txtSearchUnit.SelectedIndex == 0 && txtSearchAuthLV.SelectedIndex == 0)
            {
                bg.HR_EMP.MODE = "All";
                bg.HR_EMP.EMP_ID = 0;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
            }
            else if (txtSearchUnit.SelectedIndex == txtSearchUnit.Properties.Items.Count - 1 && txtSearchAuthLV.SelectedIndex == 0)
            {
                bg.HR_EMP.MODE = "OtherUnit+AuthAll";
                bg.HR_EMP.EMP_ID = 0;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
            }
            else if (txtSearchUnit.SelectedIndex == txtSearchUnit.Properties.Items.Count - 1 && txtSearchAuthLV.SelectedIndex != 0)
            {
                bg.HR_EMP.MODE = "OtherUnit+!AuthAll";
                bg.HR_EMP.EMP_ID = 0;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = Convert.ToInt32(lstAuth[txtSearchAuthLV.SelectedIndex]);
            }
            else if (txtSearchUnit.SelectedIndex == 0)
            {
                bg.HR_EMP.MODE = "AuthLv";
                bg.HR_EMP.EMP_ID = 0;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = 0;
                bg.HR_EMP.AUTH_LEVEL_ID = Convert.ToInt32(lstAuth[txtSearchAuthLV.SelectedIndex]);
            }
            else if (txtSearchAuthLV.SelectedIndex == 0)
            {
                bg.HR_EMP.MODE = "UnitId";
                bg.HR_EMP.EMP_ID = 0;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = Convert.ToInt32(lstUnit[txtSearchUnit.SelectedIndex]);
                bg.HR_EMP.AUTH_LEVEL_ID = 0;
            }
            else
            {
                bg.HR_EMP.MODE = "UnitId+AuthLv";
                bg.HR_EMP.EMP_ID = 0;
                bg.HR_EMP.USER_NAME = "";
                bg.HR_EMP.UNIT_ID = Convert.ToInt32(lstUnit[txtSearchUnit.SelectedIndex]);
                bg.HR_EMP.AUTH_LEVEL_ID = Convert.ToInt32(lstAuth[txtSearchAuthLV.SelectedIndex]);
            }

            bg.Invoke();
            dtWL = bg.Result.Tables[0];
        }
        private void LoadFilterLayout()
        {
            // Show Inactive User       
            {
                DataTable dt = dtWL.Clone();
                string ts = txtSearch.Text;
                string query = "(EMP_UID like '%" + ts + "%' OR USER_NAME like '%" + ts + "%' OR FullName like '%" + ts + "%')";
                if (chkShowActiveUser.Checked == true)
                    query += " AND IS_ACTIVE='Y' ";
                else
                    query += " AND (IS_ACTIVE='N' OR IS_ACTIVE is null) ";
                DataRow[] drs = dtWL.Select(query);
                foreach (DataRow dr in drs)
                    dt.Rows.Add(dr.ItemArray);
                dtWL = dt;
            }


            // Show only Support User
            if (chkShowSupport.Checked == true)
            {
                DataTable dt = dtWL.Clone();
                string query = " SUPPORT_USER='Y' ";
                DataRow[] drs = dtWL.Select(query);
                foreach (DataRow dr in drs)
                    dt.Rows.Add(dr.ItemArray);
                dtWL = dt;
            }

            // Show Selected Job Title
            if (lstJobTitle[txtSearchJobTitle.SelectedIndex].ToString() != "ALL")
            {
                DataTable dt = dtWL.Clone();
                string query = " JOBTITLE_ID=" + lstJobTitle[txtSearchJobTitle.SelectedIndex].ToString();
                DataRow[] drs = dtWL.Select(query);
                foreach (DataRow dr in drs)
                    dt.Rows.Add(dr.ItemArray);
                dtWL = dt;
            }
        }
        private void LoadGridLayout()
        {
            gcAccPreview.DataSource = dtWL.Copy();
            gvAccPreview.ClearSorting();

        }
        private void Reload()
        {
            gvAccPreview.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.SingleRecord;
            LoadTableLayout();
            LoadFilterLayout();
            LoadGridLayout();
            LoadGridList();
            gvAccPreview.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;
        }

        private void txtUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!preLoad)
            {
                int SelIndexTemp = gvAccountList.FocusedRowHandle;
                Reload();
                gvAccountList.FocusedRowHandle = -1;
                gvAccountList.FocusedRowHandle = SelIndexTemp;
            }
        }
        private void txtAuthLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!preLoad)
            {
                int SelIndexTemp = gvAccountList.FocusedRowHandle;
                Reload();
                gvAccountList.FocusedRowHandle = -1;
                gvAccountList.FocusedRowHandle = SelIndexTemp;
            }
        }
        private void txtSearchJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!preLoad)
            {
                int SelIndexTemp = gvAccountList.FocusedRowHandle;
                Reload();
                gvAccountList.FocusedRowHandle = -1;
                gvAccountList.FocusedRowHandle = SelIndexTemp;
            }
        }

        private void txtJobTitle_LoadData()
        {
            dtJobTitle = new DataTable();

            DataSet ds = new DataSet();
            LookUpSelect lk = new LookUpSelect();
            ds = lk.SelectHrJobtitle();
            dtJobTitle = ds.Tables[0];
            dvJobTitle = new DataView(ds.Tables[0]);
        }
        private void txtJobTitle_LoadFilter()
        {
            dvJobTitle.RowFilter = "IS_ACTIVE='Y'";
        }
        private void txtJobTitle_LoadGrid()
        {
            txtJobTitle.Properties.DataSource = dvJobTitle;
            txtJobTitle.Properties.DisplayMember = "JOB_TITLE_UID";
            txtJobTitle.Properties.ValueMember = "JOB_TITLE_ID";

            int k = 0;
            while (k < txtJobTitle.Properties.View.Columns.Count)
            {
                txtJobTitle.Properties.View.Columns[k].Visible = false;
                txtJobTitle.Properties.View.Columns[k].OptionsColumn.AllowEdit = false;
                k++;
            }

            txtJobTitle.Properties.View.Columns["JOB_TITLE_UID"].VisibleIndex = 0;
            txtJobTitle.Properties.View.Columns["JOB_TITLE_UID"].Caption = "Job Code";

            txtJobTitle.Properties.View.Columns["JOB_TITLE_DESC"].VisibleIndex = 1;
            txtJobTitle.Properties.View.Columns["JOB_TITLE_DESC"].Caption = "Job Name";

            txtJobTitle.Properties.View.BestFitColumns();
        }
        private void txtJobTitle_Reload()
        {
            txtJobTitle_LoadData();
            txtJobTitle_LoadFilter();
            txtJobTitle_LoadGrid();
        }

        #region Account List
        private void LoadGridList()
        {
            gcAccountList.DataSource = dtWL.Copy();
        }
        private void gridView2_Click(object sender, EventArgs e)
        {
            //if (gvAccountList.FocusedRowHandle > -1 && !preLoad)
            //{
            //    if (Math.Abs((decimal)(gvAccountList.FocusedRowHandle - gvAccPreview.FocusedRowHandle)) > 99)
            //    {
            //        DevExpress.XtraGrid.Views.Layout.LayoutViewMode mode;
            //        mode = gvAccPreview.OptionsView.ViewMode;
            //        gvAccPreview.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            //        gvAccPreview.FocusedRowHandle = gvAccountList.FocusedRowHandle;
            //        gvAccPreview.OptionsView.ViewMode = mode;
            //    }
            //    else
            //    {
            //        gvAccPreview.OptionsCarouselMode.FrameDelay = 10000;
            //        gvAccPreview.FocusedRowHandle = gvAccountList.FocusedRowHandle;
            //        gvAccPreview.OptionsCarouselMode.FrameDelay = 40000;
            //    }
            //}
        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvAccountList.FocusedRowHandle > -1 && !preLoad)
            {
                if (Math.Abs((decimal)(gvAccountList.FocusedRowHandle - gvAccPreview.FocusedRowHandle)) > 99)
                {
                    DevExpress.XtraGrid.Views.Layout.LayoutViewMode mode;
                    mode = gvAccPreview.OptionsView.ViewMode;
                    gvAccPreview.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
                    gvAccPreview.FocusedRowHandle = gvAccountList.FocusedRowHandle;
                    gvAccPreview.OptionsView.ViewMode = mode;
                }
                else
                {
                    gvAccPreview.OptionsCarouselMode.FrameDelay = 10000;
                    gvAccPreview.FocusedRowHandle = gvAccountList.FocusedRowHandle;
                    gvAccPreview.OptionsCarouselMode.FrameDelay = 40000;
                }
            }

            if (tabUserAccount.SelectedTabPage == pageAccDetail)
            {
                if (gvAccountList.FocusedRowHandle > -1)
                {
                    tabUserAccount.SelectedTabPage = pageAccDetail;
                    drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);
                    LoadGridLayout2();
                }
            }
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (gvAccountList.FocusedRowHandle > -1)
            {
                tabUserAccount.SelectedTabPage = pageAccDetail;
                drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);
                LoadGridLayout2();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
            if (gvAccountList.RowCount == 0)
                createNewAccount_inittal();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Reload();
                if (gvAccountList.RowCount == 0)
                    createNewAccount_inittal();
                else
                    gvAccountList.Focus();
            }
        }
        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            if (gvAccountList.RowCount == 0)
                createNewAccount_inittal();
        }
        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (gvAccountList.FocusedRowHandle > -1)
                {
                    tabUserAccount.SelectedTabPage = pageAccDetail;
                    drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);
                    LoadGridLayout2();
                }
            }
        }
        private void chkShowUser_CheckedChanged(object sender, EventArgs e)
        {
            int SelIndexTemp = gvAccountList.FocusedRowHandle;
            Reload();
            gvAccountList.FocusedRowHandle = -1;
            gvAccountList.FocusedRowHandle = SelIndexTemp;
        }
        private void chkShowSupport_CheckedChanged(object sender, EventArgs e)
        {
            int SelIndexTemp = gvAccountList.FocusedRowHandle;
            Reload();
            gvAccountList.FocusedRowHandle = -1;
            gvAccountList.FocusedRowHandle = SelIndexTemp;
        }
        #endregion

        #region Account Preview
        private void layoutView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvAccPreview.FocusedRowHandle > -1)
            {
                preLoad = true;
                gvAccountList.FocusedRowHandle = gvAccPreview.FocusedRowHandle;
                preLoad = false;
            }
        }
        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {
            if (gvAccPreview.FocusedRowHandle > -1)
            {
                tabUserAccount.SelectedTabPage = pageAccDetail;
                drLayout2 = gvAccPreview.GetDataRow(gvAccPreview.FocusedRowHandle);
                LoadGridLayout2();
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gvAccountList.RowCount == 0)
                createNewAccount_inittal();
        }
        #endregion

        #region Account Control Information
        private void LoadGridLayout2()
        {
            if (drLayout2["EMP_ID"].ToString() == "" || drLayout2["EMP_ID"] == null)
                return;

            #region LoadButton
            ProcessGetHREmp bg = new ProcessGetHREmp();
            bg.HR_EMP.MODE = "EmpId";
            bg.HR_EMP.EMP_ID = new GBLEnvVariable().UserID;
            bg.HR_EMP.USER_NAME = "";
            bg.HR_EMP.UNIT_ID = 0;
            bg.HR_EMP.AUTH_LEVEL_ID = 0;
            bg.Invoke();
            if (bg.Result.Tables[0].Rows[0]["SUPPORT_USER"].ToString() == "Y")
                btnribbonShowPassword.Visible = true;
            else
                btnribbonShowPassword.Visible = false;

            btnribbonSave.Visible = false;
            btnribbonCancel.Visible = false;
            btnribbonGrantRole.Visible = false;
            btnribbonGrantUnit.Visible = false;
            #endregion

            EnableTextControl(false);

            try
            {
                #region loadTitle
                txtTitle.Properties.Items.Clear();
                txtTitle.Properties.Items.AddRange(TitleThaiName);
                #endregion

                #region loadTitleEng
                txtTitleEng.Properties.Items.Clear();
                txtTitleEng.Properties.Items.AddRange(TitleEngName);
                #endregion

                #region loadGender
                txtGender.Properties.Items.Clear();
                txtGender.Properties.Items.AddRange
                    (
                        new string[] { "Male", "Female" }
                    );
                #endregion

                #region loadUnit
                ProcessGetHRUnit bgUnit = new ProcessGetHRUnit();
                bgUnit.Invoke();
                DataRow[] drsUnit = bgUnit.Result.Tables[0].Select("UNIT_TYPE='S'");
                lstUnitLayout2.Clear();
                txtUnitName.Properties.Items.Clear();
                foreach (DataRow dr in drsUnit)
                {
                    lstUnitLayout2.Add(dr["UNIT_ID"].ToString());
                    txtUnitName.Properties.Items.Add(dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString());
                }
                #endregion

                #region loadAuthLv
                ProcessGetRISAuthlevel bgAuth = new ProcessGetRISAuthlevel();
                bgAuth.Invoke();
                lstAuthLvLayout2.Clear();
                txtAuthorityLevel.Properties.Items.Clear();
                foreach (DataRow dr in bgAuth.Result.Tables[0].Rows)
                {
                    lstAuthLvLayout2.Add(dr["AUTH_LEVEL_ID"].ToString());
                    txtAuthorityLevel.Properties.Items.Add(dr["AUTH_LEVEL_ID"].ToString() + ":" + dr["AUTH_LEVEL_DESC"].ToString());
                }
                #endregion

                #region loadDefaultLanguage
                ProcessSelectGBLLanguage bgLang = new ProcessSelectGBLLanguage();
                bgLang.Invoke2();
                lstDefaultLangLayout2.Clear();
                txtDefaultLanguage.Properties.Items.Clear();
                DataRow[] drsLang = bgLang.ResultSet.Tables[0].Select("IS_ACTIVE='Y'");
                foreach (DataRow dr in drsLang)
                {
                    lstDefaultLangLayout2.Add(dr["LANG_ID"].ToString());
                    txtDefaultLanguage.Properties.Items.Add(dr["LANG_UID"].ToString() + ":" + dr["LANG_NAME"].ToString());
                }
                DataRow[] drsLangFilter = bgLang.ResultSet.Tables[0].Select("IS_DEFAULT='Y'");
                bool flag = false;
                int SelectIndex = 0;
                foreach (DataRow dr in drsLangFilter)
                {
                    if (dr["IS_DEFAULT"].ToString() == "Y")
                    {
                        flag = true;
                        break;
                    }
                    SelectIndex++;
                }
                if (flag)
                    txtDefaultLanguage.SelectedIndex = SelectIndex;
                #endregion

                txtJobTitle_Reload();

                #region fillTextBox
                DataRow row = drLayout2;

                txtEmpUid.Tag = Convert.ToInt32(row["EMP_ID"]);
                txtEmpUid.Text = row["EMP_UID"].ToString();

                txtUserName.Text = row["USER_NAME"].ToString();
                try {
                    txtPassword.Text = Utilities.Decrypt(row["PWD"].ToString());
                } catch {
                    txtPassword.Text = "envision";
                }
                txtTitle.Text = row["SALUTATION"].ToString();
                txtFname.Text = row["FNAME"].ToString();
                txtMname.Text = row["MNAME"].ToString();
                txtLname.Text = row["LNAME"].ToString();

                txtTitleEng.Text = row["TITLE_ENG"].ToString();
                txtFnameEng.Text = row["FNAME_ENG"].ToString();
                txtMnameEng.Text = row["MNAME_ENG"].ToString();
                txtLnameEng.Text = row["LNAME_ENG"].ToString();

                txtSecurityQuestion.Text = row["SECURITY_QUESTION"].ToString();
                txtSecurityAnswer.Text = row["SECURITY_ANSWER"].ToString();

                if (row["GENDER"].ToString() == "M")
                    txtGender.SelectedIndex = 0;
                else if (row["GENDER"].ToString() == "F")
                    txtGender.SelectedIndex = 1;
                else txtGender.SelectedIndex = -1;

                txtJobType.Text = row["JOB_TYPE"].ToString();

                #region DefaultLangtextBox
                int k = 0;
                flag = false;
                foreach (string slng in lstDefaultLangLayout2)
                {
                    if (slng == row["DEFAULT_LANG"].ToString())
                    {
                        flag = true;
                        break;
                    }
                    k++;
                }
                if (flag)
                {
                    txtDefaultLanguage.SelectedIndex = k;
                }
                else
                {
                    txtDefaultLanguage.SelectedIndex = -1;
                }
                #endregion

                #region UnitIdtextBox
                k = 0;
                flag = false;
                foreach (string sUnit in lstUnitLayout2)
                {
                    if (sUnit == row["UNIT_ID"].ToString())
                    {
                        flag = true;
                        break;
                    }
                    k++;
                }
                if (flag)
                {
                    txtUnitName.SelectedIndex = k;
                }
                else
                {
                    txtUnitName.SelectedIndex = -1;
                }
                #endregion

                #region AuthLVtextBox
                k = 0;
                flag = false;
                foreach (string sAuth in lstAuthLvLayout2)
                {
                    if (sAuth == row["AUTH_LEVEL_ID"].ToString())
                    {
                        flag = true;
                        break;
                    }
                    k++;
                }
                if (flag)
                {
                    txtAuthorityLevel.SelectedIndex = k;
                }
                else
                {
                    txtAuthorityLevel.SelectedIndex = -1;
                }
                #endregion

                if (row["IS_ACTIVE"].ToString() == "Y")
                    chkIsActive.Checked = true;
                else chkIsActive.Checked = false;

                if (row["IS_RADIOLOGIST"].ToString() == "Y")
                    chkRadiologist.Checked = true;
                else chkRadiologist.Checked = false;

                if (row["ALLOW_OTHERS_TO_FINALIZE"].ToString() == "Y")
                    chkAllowOtherstoFinalize.Checked = true;
                else chkAllowOtherstoFinalize.Checked = false;

                if (row["SUPPORT_USER"].ToString() == "Y")
                    chkSupportUser.Checked = true;
                else chkSupportUser.Checked = false;
                
                if (row["CAN_EXCEED_SCHEDULE"].ToString() == "Y")
                    chkScheduleExceed.Checked = true;
                else chkScheduleExceed.Checked = false;

                if (row["CAN_KILL_SESSION"].ToString() == "Y")
                    chkCanKillSession.Checked = true;
                else chkCanKillSession.Checked = false;

                if (row["IS_RESIDENT"].ToString() == "Y")
                    chkResident.Checked = true;
                else chkResident.Checked = false;

                txtCreatedOn.Text = row["CREATED_BY_NAME"].ToString() + "  ";
                txtLastModifiedOn.Text = row["LAST_MODIFIED_BY_NAME"].ToString() + "  ";

                txtCreatedOn.Text += row["CREATED_ON"].ToString() == "" ? "" : Convert.ToDateTime(row["CREATED_ON"]).ToString("dd/MM/yyyy HH:mm");
                txtLastModifiedOn.Text += row["LAST_MODIFIED_ON"].ToString() == "" ? "" : Convert.ToDateTime(row["LAST_MODIFIED_ON"]).ToString("dd/MM/yyyy HH:mm");

                txtJobTitle.EditValue = row["JOBTITLE_ID"];

                if (row["IS_FELLOW"].ToString() == "Y")
                    chkFellow.Checked = true;
                else chkFellow.Checked = false;

                #region Select JobTitle
                string jobTitleUid = row["JOB_TITLE_NAME"].ToString();

                if (jobTitleUid.StartsWith("RAD"))
                {
                    chkRadiologist.Checked = true;
                    chkFellow.Checked = false;
                    chkResident.Checked = false;
                }
                else if (jobTitleUid.StartsWith("FEL"))
                {
                    chkRadiologist.Checked = true;
                    chkFellow.Checked = true;
                    chkResident.Checked = false;
                }
                else if (jobTitleUid.StartsWith("DEN"))
                {
                    chkRadiologist.Checked = true;
                    chkFellow.Checked = false;
                    chkResident.Checked = true;
                }
                else
                {
                    chkRadiologist.Checked = false;
                    chkFellow.Checked = false;
                    chkResident.Checked = false;
                }
                #endregion

                #region Phone Number & Email Address
                //Phone Number
                txtPhoneNo.Tag = row["PHONE_HOME"].ToString().Trim() + "#" + row["PHONE_MOBILE"].ToString().Trim() + "#" + row["PHONE_OFFICE"].ToString().Trim();
                txtPhoneNo.Text = "";
                if (row["PHONE_HOME"].ToString().Trim().Length > 0)
                    txtPhoneNo.Text += row["PHONE_HOME"].ToString().Trim() + ", ";
                if (row["PHONE_MOBILE"].ToString().Trim().Length > 0)
                    txtPhoneNo.Text += row["PHONE_MOBILE"].ToString().Trim() + ", ";                
                if (row["PHONE_OFFICE"].ToString().Trim().Length > 0)
                    txtPhoneNo.Text += row["PHONE_OFFICE"].ToString().Trim() + ", ";
                int lastIdxPhone = txtPhoneNo.Text.LastIndexOf(",");
                if (lastIdxPhone > 0)
                    txtPhoneNo.Text = txtPhoneNo.Text.Substring(0, lastIdxPhone);

                //Email Address
                txtEmailAddress.Tag = row["EMAIL_PERSONAL"].ToString().Trim() + "#" + row["EMAIL_OFFICIAL"].ToString().Trim();
                txtEmailAddress.Text = "";
                if (row["EMAIL_PERSONAL"].ToString().Trim().Length > 0)
                    txtEmailAddress.Text += row["EMAIL_PERSONAL"].ToString().Trim() + ", ";
                if (row["EMAIL_OFFICIAL"].ToString().Trim().Length > 0)
                    txtEmailAddress.Text += row["EMAIL_OFFICIAL"].ToString().Trim() + ", ";
                int lastIdxEmail = txtEmailAddress.Text.LastIndexOf(",");
                if (lastIdxEmail > 0)
                    txtEmailAddress.Text = txtEmailAddress.Text.Substring(0, lastIdxEmail);
                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Load Account Detail Error : "+ex.Message);
            }

            if (gvAccountList.RowCount > -1)
                gvAccountList.Focus();
            else txtSearch.Focus();

            //#region clearDatarow
            //drLayout2["EMP_ID"] = DBNull.Value;
            //#endregion
        }
        private void EnableTextControl(bool enable)
        {
            txtEmpUid.Enabled = enable;
            txtUserName.Enabled = enable;
            txtPassword.Enabled = enable;

            txtSecurityQuestion.Enabled = enable;
            txtSecurityAnswer.Enabled = enable;

            //txtPhoto.Enabled = enable;
            //btnBrowse.Enabled = enable;

            txtTitle.Enabled = enable;
            txtFname.Enabled = enable;
            txtMname.Enabled = enable;
            txtLname.Enabled = enable;

            txtTitleEng.Enabled = enable;
            txtFnameEng.Enabled = enable;
            txtMnameEng.Enabled = enable;
            txtLnameEng.Enabled = enable;

            txtGender.Enabled = enable;
            txtUnitName.Enabled = enable;
            txtJobType.Enabled = enable;
            txtAuthorityLevel.Enabled = enable;
            txtDefaultLanguage.Enabled = enable;

            chkIsActive.Enabled = enable;
            chkRadiologist.Enabled = enable;
            chkSupportUser.Enabled = enable;
            chkScheduleExceed.Enabled = enable;
            chkAllowOtherstoFinalize.Enabled = enable;
            chkCanKillSession.Enabled = enable;

            txtSearchAuthLV.Enabled = !enable;
            txtSearchUnit.Enabled = !enable;
            txtSearchJobTitle.Enabled = !enable;
            gpSearchFilter.Enabled = !enable;

            txtSearch.Enabled = !enable;
            btnSearch.Enabled = !enable;

            chkResident.Enabled = enable;
            chkFellow.Enabled = enable;

            txtJobTitle.Enabled = enable;

            if (chkAllowOtherstoFinalize.Enabled == true)
            {
                CheckState chk = chkRadiologist.CheckState;
                if (chk == CheckState.Checked)
                    txtAuthorityLevel.Enabled = true;
                else
                    txtAuthorityLevel.Enabled = false;
            }
            else
                txtAuthorityLevel.Enabled = false;

            txtPhoneNo.Enabled = enable;
            txtEmailAddress.Enabled = enable;
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            string strTitle = txtTitle.Text;

            int k = 0;
            bool wasFound = false;
            foreach (string titlename in TitleThaiName)
            {
                if (titlename == strTitle)
                {
                    wasFound = true;
                    break;
                }
                k++;
            }

            if (wasFound)
            {
                txtTitleEng.Text = TitleEngName[k];
            }
            else
            {
                txtTitleEng.Text = "";
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG (*.jpg)|*.jpg|Png (*.png)|*.png|Gif (*.gif)|*.gif";
            ofd.InitialDirectory = "root";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName != "")
                {
                    try
                    {
                        txtPhoto.Image = Image.FromFile(ofd.FileName);
                    }
                    catch
                    {
                        txtPhoto.Image = (Image)imageCollection1.Images[6].Clone();
                    }
                    txtPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                }
            }

        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            //if (txtFname.Text.Trim() != "")
            //{
            //    txtFnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtFname.Text).Trim();
            //    if (txtFnameEng.Text.Length > 0)
            //    {
            //        string firstLetter = txtFnameEng.Text.Substring(0, 1);
            //        string firstUpper = firstLetter.ToUpper();
            //        string firstDelete = txtFnameEng.Text.Remove(0, 1);
            //        txtFnameEng.Text = firstUpper + firstDelete;
            //    }
            //}
        }
        private void txtMname_TextChanged(object sender, EventArgs e)
        {
            //if (txtMname.Text.Trim() != "")
            //{
            //    txtMnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtMname.Text).Trim();
            //    if (txtMnameEng.Text.Length > 0)
            //    {
            //        string firstLetter = txtMnameEng.Text.Substring(0, 1);
            //        string firstUpper = firstLetter.ToUpper();
            //        string firstDelete = txtMnameEng.Text.Remove(0, 1);
            //        txtMnameEng.Text = firstUpper + firstDelete;
            //    }
            //}
        }
        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            //if (txtLname.Text.Trim() != "")
            //{
            //    txtLnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtLname.Text).Trim();
            //    if (txtLnameEng.Text.Length > 0)
            //    {
            //        string firstLetter = txtLnameEng.Text.Substring(0, 1);
            //        string firstUpper = firstLetter.ToUpper();
            //        string firstDelete = txtLnameEng.Text.Remove(0, 1);
            //        txtLnameEng.Text = firstUpper + firstDelete;
            //    }
            //}
        }

        private void chkRadiologist_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkAllowOtherstoFinalize.Enabled == true)
            {
                CheckState chk = chkRadiologist.CheckState;
                if (chk == CheckState.Checked)
                    txtAuthorityLevel.Enabled = true;
                else
                    txtAuthorityLevel.Enabled = false;
            }
            else
                txtAuthorityLevel.Enabled = false;

            if (chkRadiologist.CheckState == CheckState.Checked)
                txtJobType.Text = "D";
            else
                txtJobType.Text = "";
        }
        private void txtJobTitle_EditValueChanged(object sender, EventArgs e)
        {
            if (txtJobTitle.Properties.View.FocusedRowHandle < 0) return;

            DataRow row = txtJobTitle.Properties.View.GetDataRow(txtJobTitle.Properties.View.FocusedRowHandle);
            string jobTitleUid = row["JOB_TITLE_UID"].ToString();

            if (jobTitleUid.StartsWith("RAD"))
            {
                chkRadiologist.Checked = true;
                chkFellow.Checked = false;
                chkResident.Checked = false;
            }
            else if (jobTitleUid.StartsWith("FEL"))
            {
                chkRadiologist.Checked = true;
                chkFellow.Checked = true;
                chkResident.Checked = false;
            }
            else if (jobTitleUid.StartsWith("DEN"))
            {
                chkRadiologist.Checked = true;
                chkFellow.Checked = false;
                chkResident.Checked = true;
            }
            else
            {
                chkRadiologist.Checked = false;
                chkFellow.Checked = false;
                chkResident.Checked = false;
            }
        }
        
        private void txtPhoneNo_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (saveStatus == "Add")
            {
                frmUserAccountSettingsPhoneNum phoneForm = new frmUserAccountSettingsPhoneNum();
                phoneForm.ValueUpdated += new ValueUpdatedEventHandler(phoneForm_ValueUpdated);
                phoneForm.ShowDialog();
            }
            else
            {
                frmUserAccountSettingsPhoneNum phoneForm = new frmUserAccountSettingsPhoneNum(txtPhoneNo.Tag.ToString());
                phoneForm.ValueUpdated += new ValueUpdatedEventHandler(phoneForm_ValueUpdated);
                phoneForm.ShowDialog();
            }
        }
        private void phoneForm_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValues = e.NewValue.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
            txtPhoneNo.Tag = e.NewValue;

            txtPhoneNo.Text = "";
            if (retValues.Length > 0)
            {
                foreach (string str in retValues)
                    txtPhoneNo.Text += str + ", ";

                int lastIdx = txtPhoneNo.Text.LastIndexOf(",");
                if (lastIdx > 0)
                    txtPhoneNo.Text = txtPhoneNo.Text.Substring(0, lastIdx);
            }
        }
        private void txtEmailAddress_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (saveStatus == "Add")
            {
                frmUserAccountSettingsEmailAdd emailForm = new frmUserAccountSettingsEmailAdd();
                emailForm.ValueUpdated += new ValueUpdatedEventHandler(emailForm_ValueUpdated);
                emailForm.ShowDialog();
            }
            else
            {
                frmUserAccountSettingsEmailAdd emailForm = new frmUserAccountSettingsEmailAdd(txtEmailAddress.Tag.ToString());
                emailForm.ValueUpdated += new ValueUpdatedEventHandler(emailForm_ValueUpdated);
                emailForm.ShowDialog();
            }
        }
        private void emailForm_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValues = e.NewValue.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
            txtEmailAddress.Tag = e.NewValue;

            txtEmailAddress.Text = "";
            if (retValues.Length > 0)
            {
                foreach (string str in retValues)
                    txtEmailAddress.Text += str + ", ";

                int lastIdx = txtEmailAddress.Text.LastIndexOf(",");
                if (lastIdx > 0)
                    txtEmailAddress.Text = txtEmailAddress.Text.Substring(0, lastIdx);
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpUid.Text.Trim().Length == 0 || txtUserName.Text.Trim().StartsWith(txtEmpUid.Text.Trim()))
                txtEmpUid.Text = txtUserName.Text;
        }
        #endregion

        #region Menu Ribbon Control
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadbtnAdd();
        }
        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadbtnUpdate();
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadbtnDelete();
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadbtnSave();
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadbtnCancel();
        }
        private void btnBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadbtnBack();
        }
        private void btnShowPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtPassword.Text != "")
                MessageBox.Show(txtPassword.Text, "Show The Password", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("No Password, It's empty", "Show The Password", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        private void btnRefreshPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region checkUpdate

            MyMessageBox mm = new MyMessageBox();

            if (txtEmpUid.Tag == null)
            {
                mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (txtUserName.Text == "")
            {
                mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                return;
            }

            #endregion

            string str = mm.ShowAlert("UID2112", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                ProcessUpdateHREmp bu = new ProcessUpdateHREmp();
                try
                {
                    bu.HR_EMP.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                    bu.HR_EMP.EMP_UID = txtEmpUid.Text;

                    bu.HR_EMP.USER_NAME = txtUserName.Text;
                    //bu.HREmp.PWD = txtPassword.Text == "" ? Secure.Encrypt("envision") : Secure.Encrypt(txtPassword.Text);
                    bu.HR_EMP.PWD = Utilities.Encrypt("envision");

                    bu.HR_EMP.SECURITY_QUESTION = txtSecurityQuestion.Text;
                    bu.HR_EMP.SECURITY_ANSWER = txtSecurityAnswer.Text;

                    bu.HR_EMP.SALUTATION = txtTitle.Text;
                    bu.HR_EMP.FNAME = txtFname.Text;
                    bu.HR_EMP.MNAME = txtMname.Text;
                    bu.HR_EMP.LNAME = txtLname.Text;

                    bu.HR_EMP.TITLE_ENG = txtTitleEng.Text;
                    bu.HR_EMP.FNAME_ENG = txtFnameEng.Text;
                    bu.HR_EMP.MNAME_ENG = txtMnameEng.Text;
                    bu.HR_EMP.LNAME_ENG = txtLnameEng.Text;

                    bu.HR_EMP.GENDER = txtGender.Text.Trim().Length == 0 ? ' ' : txtGender.Text.Trim()[0];
                    bu.HR_EMP.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                    bu.HR_EMP.JOB_TYPE = txtJobType.Text.Trim().Length == 0 ? ' ' : txtJobType.Text.Trim()[0];
                    bu.HR_EMP.AUTH_LEVEL_ID = txtAuthorityLevel.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstAuthLvLayout2[txtAuthorityLevel.SelectedIndex]);
                    bu.HR_EMP.DEFAULT_LANG = txtDefaultLanguage.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstDefaultLangLayout2[txtDefaultLanguage.SelectedIndex]);

                    bu.HR_EMP.IS_ACTIVE = chkIsActive.Checked ? 'Y' : 'N';
                    bu.HR_EMP.IS_RADIOLOGIST = chkRadiologist.Checked ? 'Y' : 'N';
                    bu.HR_EMP.SUPPORT_USER = chkSupportUser.Checked ? 'Y' : 'N';
                    bu.HR_EMP.CAN_EXCEED_SCHEDULE = chkScheduleExceed.Checked ? 'Y' : 'N';
                    bu.HR_EMP.ALLOW_OTHERS_TO_FINALIZE = chkAllowOtherstoFinalize.Checked ? 'Y' : 'N';
                    bu.HR_EMP.CAN_KILL_SESSION = chkCanKillSession.Checked ? 'Y' : 'N';

                    bu.HR_EMP.EMP_REPORT_FOOTER1 = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
                    bu.HR_EMP.EMP_REPORT_FOOTER2 = txtFnameEng.Text + " " + txtMnameEng.Text + " " + txtLnameEng.Text;

                    bu.HR_EMP.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;

                    bu.HR_EMP.ORG_ID = new GBLEnvVariable().OrgID;

                    bu.HR_EMP.IS_RESIDENT = chkResident.Checked ? 'Y' : 'N';

                    bu.HR_EMP.JOBTITLE_ID = Convert.ToInt32(txtJobTitle.EditValue.ToString() == "" ? 0 : txtJobTitle.EditValue);

                    bu.HR_EMP.IS_FELLOW = chkFellow.Checked ? 'Y' : 'N';

                    bu.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    return;
                }

                mm.ShowAlert("UID2113", new GBLEnvVariable().CurrentLanguageID);

                int focusAt = gvAccountList.FocusedRowHandle;
                Reload();
                gvAccountList.FocusedRowHandle = focusAt;
                drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);
                LoadGridLayout2();
            }
        }
        private void btnribbonGrantUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtEmpUid.Tag == null) return;
            if (txtUnitName.Text.Trim().Equals(""))
            {
                GrantUnit gblsf13 = new GrantUnit(Convert.ToInt32(txtEmpUid.Tag), txtEmpUid.Text,
                                                txtFname.Text + " " + txtMname.Text + " " + txtLname.Text);
                gblsf13.ShowDialog();
            }
            else
            {
                GrantUnit gblsf13 = new GrantUnit(Convert.ToInt32(txtEmpUid.Tag), txtEmpUid.Text,
                                                txtFname.Text + " " + txtMname.Text + " " + txtLname.Text, Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]));
                gblsf13.ShowDialog();
            }
        }
        private void btnribbonGrantRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtEmpUid.Tag == null) return;
            GBL_SF13 gblsf13 = new GBL_SF13(Convert.ToInt32(txtEmpUid.Tag), txtEmpUid.Text,
                                            txtFname.Text + " " + txtMname.Text + " " + txtLname.Text);
            gblsf13.ShowDialog();
        }
        #endregion

        private void LoadbtnAdd()
        {
            btnribbonAdd.Visible = false;
            btnribbonUpdate.Visible = false;
            //btnribbonDelete.Visible = false;

            btnribbonSave.Visible = true;
            btnribbonCancel.Visible = true;

            btnribbonBack.Visible = false;

            btnribbonShowPassword.Visible = false;
            btnribbonRefreshPassword.Visible = false;

            btnribbonGrantRole.Visible = false;
            btnribbonGrantUnit.Visible = false;

            gcAccountList.Enabled = false;

            EnableTextControl(true);

            #region clearTextBox

            txtEmpUid.Tag = null;
            txtEmpUid.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";

            txtSecurityQuestion.Text = "";
            txtSecurityAnswer.Text = "";

            txtTitle.Text = "";
            txtFname.Text = "";
            txtMname.Text = "";
            txtLname.Text = "";

            txtTitleEng.Text = "";
            txtFnameEng.Text = "";
            txtMnameEng.Text = "";
            txtLnameEng.Text = "";

            txtGender.SelectedIndex = 0;
            txtUnitName.SelectedIndex = txtSearchUnit.SelectedIndex == 0 ? 0 : txtSearchUnit.SelectedIndex - 1;
            txtJobType.SelectedIndex = 0;
            txtAuthorityLevel.SelectedIndex = txtSearchAuthLV.SelectedIndex == 0 ? 0 : txtSearchAuthLV.SelectedIndex - 1;
            txtDefaultLanguage.SelectedIndex = 1;

            chkIsActive.Checked = false;
            chkRadiologist.Checked = false;
            chkSupportUser.Checked = false;
            chkScheduleExceed.Checked = false;
            chkAllowOtherstoFinalize.Checked = false;
            chkCanKillSession.Checked = false;

            txtCreatedOn.Text = "";
            txtLastModifiedOn.Text = "";

            chkResident.Checked = false;
            txtJobTitle.EditValue = null;

            txtAuthorityLevel.Enabled = false;
            chkFellow.Checked = false;

            txtPhoneNo.Tag = "###";
            txtPhoneNo.Text = "";

            txtEmailAddress.Tag = "###";
            txtEmailAddress.Text = "";

            chkRadiologist.Checked = false;

            #endregion

            txtUserName.Focus();

            saveStatus = "Add";
        }
        private void LoadbtnUpdate()
        {
            btnribbonAdd.Visible = false;
            btnribbonUpdate.Visible = false;
            //btnribbonDelete.Visible = false;

            btnribbonSave.Visible = true;
            btnribbonCancel.Visible = true;

            btnribbonBack.Visible = false;

            btnribbonShowPassword.Visible = false;
            btnribbonRefreshPassword.Visible = false;

            btnribbonGrantRole.Visible = true;
            btnribbonGrantUnit.Visible = true;

            gcAccountList.Enabled = false;

            #region checkEmptySelected
            txtGender.SelectedIndex = txtGender.SelectedIndex == -1 ? 0 : txtGender.SelectedIndex;
            txtUnitName.SelectedIndex = txtUnitName.SelectedIndex == -1 ? 0 : txtUnitName.SelectedIndex;
            txtAuthorityLevel.SelectedIndex = txtAuthorityLevel.SelectedIndex == -1 ? 0 : txtAuthorityLevel.SelectedIndex;
            txtDefaultLanguage.SelectedIndex = txtDefaultLanguage.SelectedIndex == -1 ? 1 : txtDefaultLanguage.SelectedIndex;
            #endregion

            EnableTextControl(true);

            txtUserName.Focus();

            saveStatus = "Update";
        }
        private void LoadbtnDelete()
        {
            MyMessageBox mm = new MyMessageBox();

            if (txtEmpUid.Tag == null)
            {
                mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (mm.ShowAlert("UID4003", new GBLEnvVariable().CurrentLanguageID) == "2")
            {
                try
                {
                    ProcessDeleteHREmp bd = new ProcessDeleteHREmp();
                    bd.HR_EMP.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                    bd.Invoke();

                    int focusAt = gvAccountList.FocusedRowHandle;
                    Reload();
                    gvAccountList.FocusedRowHandle = focusAt;
                    if (gvAccountList.FocusedRowHandle > -1)
                    {
                        drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);
                        LoadGridLayout2();
                    }
                    else
                    {
                        tabUserAccount.SelectedTabPage = pageAccPreview;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        private void LoadbtnSave()
        {
            MyMessageBox mm = new MyMessageBox();
            string str = mm.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);

            if (str == "2")
            {
                if (saveStatus == "Add")
                {
                    #region checkAdd

                    if (txtUserName.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtUserName.Focus();
                        return;
                    }
                    if (txtFname.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtFname.Focus();
                        return;
                    }
                    if (txtLname.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtLname.Focus();
                        return;
                    }
                    if (txtJobTitle.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtJobTitle.Focus();
                        return;
                    }

                    ProcessGetHREmp bgUN = new ProcessGetHREmp();
                    bgUN.HR_EMP.MODE = "UserName";
                    bgUN.HR_EMP.USER_NAME = txtUserName.Text;
                    bgUN.Invoke();
                    if (bgUN.Result.Tables[0].Rows.Count > 0)
                    {
                        mm.ShowAlert("UID2120", new GBLEnvVariable().CurrentLanguageID);
                        mm.ShowAlert("UID2121", new GBLEnvVariable().CurrentLanguageID);
                        txtUserName.Focus();
                        return;
                    }

                    #endregion

                    #region Add
                    ProcessAddHREmp ba = new ProcessAddHREmp();
                    try
                    {
                        //ba.HREmp.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                        ba.HR_EMP.EMP_UID = txtEmpUid.Text;

                        ba.HR_EMP.USER_NAME = txtUserName.Text;
                        ba.HR_EMP.PWD = txtPassword.Text == "" ? Utilities.Encrypt("envision") : Utilities.Encrypt(txtPassword.Text);

                        ba.HR_EMP.SECURITY_QUESTION = txtSecurityQuestion.Text;
                        ba.HR_EMP.SECURITY_ANSWER = txtSecurityAnswer.Text;

                        ba.HR_EMP.SALUTATION = txtTitle.Text;
                        ba.HR_EMP.FNAME = txtFname.Text;
                        ba.HR_EMP.MNAME = txtMname.Text;
                        ba.HR_EMP.LNAME = txtLname.Text;

                        ba.HR_EMP.TITLE_ENG = txtTitleEng.Text;
                        ba.HR_EMP.FNAME_ENG = txtFnameEng.Text;
                        ba.HR_EMP.MNAME_ENG = txtMnameEng.Text;
                        ba.HR_EMP.LNAME_ENG = txtLnameEng.Text;

                        ba.HR_EMP.GENDER = txtGender.Text.Trim().Length == 0 ? ' ' : txtGender.Text.Trim()[0];
                        ba.HR_EMP.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                        ba.HR_EMP.JOB_TYPE = txtJobType.Text.Trim().Length == 0 ? ' ' : txtJobType.Text.Trim()[0];
                        ba.HR_EMP.AUTH_LEVEL_ID = txtAuthorityLevel.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstAuthLvLayout2[txtAuthorityLevel.SelectedIndex]);
                        ba.HR_EMP.DEFAULT_LANG = txtDefaultLanguage.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstDefaultLangLayout2[txtDefaultLanguage.SelectedIndex]);

                        ba.HR_EMP.IS_ACTIVE = chkIsActive.Checked ? 'Y' : 'N';
                        ba.HR_EMP.IS_RADIOLOGIST = chkRadiologist.Checked ? 'Y' : 'N';
                        ba.HR_EMP.SUPPORT_USER = chkSupportUser.Checked ? 'Y' : 'N';
                        ba.HR_EMP.CAN_EXCEED_SCHEDULE = chkScheduleExceed.Checked ? 'Y' : 'N';
                        ba.HR_EMP.ALLOW_OTHERS_TO_FINALIZE = chkAllowOtherstoFinalize.Checked ? 'Y' : 'N';
                        ba.HR_EMP.CAN_KILL_SESSION = chkCanKillSession.Checked ? 'Y' : 'N';

                        ba.HR_EMP.EMP_REPORT_FOOTER1 = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
                        ba.HR_EMP.EMP_REPORT_FOOTER2 = txtFnameEng.Text + " " + txtMnameEng.Text + " " + txtLnameEng.Text;
                        ba.HR_EMP.CREATED_BY = new GBLEnvVariable().UserID;
                        ba.HR_EMP.ORG_ID = new GBLEnvVariable().OrgID;
                        ba.HR_EMP.IS_RESIDENT = chkResident.Checked ? 'Y' : 'N';

                        ba.HR_EMP.JOBTITLE_ID = Convert.ToInt32(txtJobTitle.EditValue);
                        ba.HR_EMP.IS_FELLOW = chkFellow.Checked ? 'Y' : 'N';

                        string[] splitPhone = txtPhoneNo.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.None);
                        ba.HR_EMP.PHONE_HOME = splitPhone[0];
                        ba.HR_EMP.PHONE_MOBILE = splitPhone[1];
                        ba.HR_EMP.PHONE_OFFICE = splitPhone[2];

                        string[] splitEmail = txtEmailAddress.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.None);
                        ba.HR_EMP.EMAIL_PERSONAL = splitEmail[0];
                        ba.HR_EMP.EMAIL_OFFICIAL = splitEmail[1];

                        ba.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        return;
                    }

                    try
                    {
                        ProcessGetRISUserorgmap bg = new ProcessGetRISUserorgmap();
                        bg.RIS_USERORGMAP.MODE = 2;
                        bg.Invoke();
                        string query = "EMP_ID=" + Convert.ToInt32(txtEmpUid.Tag).ToString() + " and UNIT_ID=" + (txtUnitName.SelectedIndex == -1 ? "0" : lstUnitLayout2[txtUnitName.SelectedIndex]);
                        DataRow[] drs = bg.Result.Tables[0].Select(query);
                        if (drs.Length == 0)
                        {
                            ProcessGetHREmp bgg = new ProcessGetHREmp();
                            bgg.HR_EMP.MODE = "UserName";
                            bgg.HR_EMP.USER_NAME = txtUserName.Text;
                            bgg.Invoke();

                            ProcessAddRISUserorgmap baa = new ProcessAddRISUserorgmap();
                            baa.RIS_USERORGMAP.EMP_ID = Convert.ToInt32(bgg.Result.Tables[0].Rows[0]["EMP_ID"]);
                            baa.RIS_USERORGMAP.ACCESS_ORG_ID = new GBLEnvVariable().OrgID;
                            baa.RIS_USERORGMAP.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                            baa.RIS_USERORGMAP.CREATED_BY = new GBLEnvVariable().UserID;
                            baa.RIS_USERORGMAP.ORG_ID = new GBLEnvVariable().OrgID;
                            baa.Invoke();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        return;
                    }
                    #endregion

                    #region initControl
                    if (!createNewAccount)
                    {
                        EnableTextControl(false);

                        mm.ShowAlert("UID2002", new GBLEnvVariable().CurrentLanguageID);

                        btnribbonAdd.Visible = true;
                        btnribbonUpdate.Visible = true;
                        //btnribbonDelete.Visible = true;
                        btnribbonBack.Visible = true;

                        btnribbonSave.Visible = false;
                        btnribbonCancel.Visible = false;

                        btnribbonShowPassword.Visible = true;
                        btnribbonRefreshPassword.Visible = true;

                        btnribbonGrantRole.Visible = true;
                        btnribbonGrantUnit.Visible = true;

                        gcAccountList.Enabled = true;

                        chkShowActiveUser.Checked = chkIsActive.Checked;

                        int focusAt = gvAccountList.FocusedRowHandle;
                        txtSearch.Text = txtUserName.Text.Trim();
                        Reload();
                        gvAccountList.FocusedRowHandle = focusAt;
                        drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);
                        if (drLayout2 != null)
                            LoadGridLayout2();
                        else
                        {
                            tabUserAccount.SelectedTabPage = pageAccPreview;
                            if (gvAccountList.RowCount > 0)
                                gvAccountList.Focus();
                            else
                                txtSearch.Focus();
                        }

                        saveStatus = "";
                    }
                    else
                        createNewAccount_afterAdd();
                    #endregion
                }
                else if (saveStatus == "Update")
                {
                    #region checkUpdate

                    if (txtEmpUid.Tag == null)
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        return;
                    }
                    if (txtUserName.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtUserName.Focus();
                        return;
                    }
                    if (txtFname.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtFname.Focus();
                        return;
                    }
                    if (txtLname.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtLname.Focus();
                        return;
                    }
                    if (txtJobTitle.Text == "")
                    {
                        mm.ShowAlert("UID2001", new GBLEnvVariable().CurrentLanguageID);
                        txtJobTitle.Focus();
                        return;
                    }

                    ProcessGetHREmp bgUN = new ProcessGetHREmp();
                    bgUN.HR_EMP.MODE = "Username+!EmpId";
                    bgUN.HR_EMP.USER_NAME = txtUserName.Text;
                    bgUN.HR_EMP.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                    bgUN.Invoke();
                    if (bgUN.Result.Tables[0].Rows.Count > 0)
                    {
                        mm.ShowAlert("UID2120", new GBLEnvVariable().CurrentLanguageID);
                        mm.ShowAlert("UID2121", new GBLEnvVariable().CurrentLanguageID);
                        txtUserName.Focus();
                        return;
                    }

                    #endregion

                    #region update
                    ProcessUpdateHREmp bu = new ProcessUpdateHREmp();

                    try
                    {
                        bu.HR_EMP.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                        bu.HR_EMP.EMP_UID = txtEmpUid.Text;

                        bu.HR_EMP.USER_NAME = txtUserName.Text;
                        bu.HR_EMP.PWD = txtPassword.Text == "" ? Utilities.Encrypt("envision") : Utilities.Encrypt(txtPassword.Text);

                        bu.HR_EMP.SECURITY_QUESTION = txtSecurityQuestion.Text;
                        bu.HR_EMP.SECURITY_ANSWER = txtSecurityAnswer.Text;

                        bu.HR_EMP.SALUTATION = txtTitle.Text;
                        bu.HR_EMP.FNAME = txtFname.Text;
                        bu.HR_EMP.MNAME = txtMname.Text;
                        bu.HR_EMP.LNAME = txtLname.Text;

                        bu.HR_EMP.TITLE_ENG = txtTitleEng.Text;
                        bu.HR_EMP.FNAME_ENG = txtFnameEng.Text;
                        bu.HR_EMP.MNAME_ENG = txtMnameEng.Text;
                        bu.HR_EMP.LNAME_ENG = txtLnameEng.Text;

                        //bu.HR_EMP.GENDER = txtGender.Text.Trim() == "" ? ' ' : Convert.ToChar(txtGender.Text.Trim());
                        bu.HR_EMP.GENDER = txtGender.Text.Trim().Length == 0 ? ' ' : txtGender.Text.Trim()[0];
                        bu.HR_EMP.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                        //bu.HR_EMP.JOB_TYPE = txtJobType.Text.Trim() == "" ? ' ' : Convert.ToChar(txtJobType.Text.Trim());
                        bu.HR_EMP.JOB_TYPE = txtJobType.Text.Trim().Length == 0 ? ' ' : txtJobType.Text.Trim()[0];
                        bu.HR_EMP.AUTH_LEVEL_ID = txtAuthorityLevel.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstAuthLvLayout2[txtAuthorityLevel.SelectedIndex]);
                        bu.HR_EMP.DEFAULT_LANG = txtDefaultLanguage.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstDefaultLangLayout2[txtDefaultLanguage.SelectedIndex]);

                        bu.HR_EMP.IS_ACTIVE = chkIsActive.Checked ? 'Y' : 'N';
                        bu.HR_EMP.IS_RADIOLOGIST = chkRadiologist.Checked ? 'Y' : 'N';
                        bu.HR_EMP.SUPPORT_USER = chkSupportUser.Checked ? 'Y' : 'N';
                        bu.HR_EMP.CAN_EXCEED_SCHEDULE = chkScheduleExceed.Checked ? 'Y' : 'N';
                        bu.HR_EMP.ALLOW_OTHERS_TO_FINALIZE = chkAllowOtherstoFinalize.Checked ? 'Y' : 'N';
                        bu.HR_EMP.CAN_KILL_SESSION = chkCanKillSession.Checked ? 'Y' : 'N';

                        bu.HR_EMP.EMP_REPORT_FOOTER1 = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
                        bu.HR_EMP.EMP_REPORT_FOOTER2 = txtFnameEng.Text + " " + txtMnameEng.Text + " " + txtLnameEng.Text;
                        bu.HR_EMP.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        bu.HR_EMP.ORG_ID = new GBLEnvVariable().OrgID;
                        bu.HR_EMP.IS_RESIDENT = chkResident.Checked ? 'Y' : 'N';

                        bu.HR_EMP.JOBTITLE_ID = Convert.ToInt32(txtJobTitle.EditValue.ToString() == "" ? 0 : txtJobTitle.EditValue);
                        bu.HR_EMP.IS_FELLOW = chkFellow.Checked ? 'Y' : 'N';

                        string[] splitPhone = txtPhoneNo.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.None);
                        bu.HR_EMP.PHONE_HOME = splitPhone[0];
                        bu.HR_EMP.PHONE_MOBILE = splitPhone[1];
                        bu.HR_EMP.PHONE_OFFICE = splitPhone[2];

                        string[] splitEmail = txtEmailAddress.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.None);
                        bu.HR_EMP.EMAIL_PERSONAL = splitEmail[0];
                        bu.HR_EMP.EMAIL_OFFICIAL = splitEmail[1];

                        bu.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        return;
                    }

                    try
                    {
                        ProcessGetRISUserorgmap bg = new ProcessGetRISUserorgmap();
                        bg.RIS_USERORGMAP.MODE = 2;
                        bg.Invoke();
                        string query = "EMP_ID=" + txtEmpUid.Tag.ToString() + " and UNIT_ID=" + (txtUnitName.SelectedIndex == -1 ? "0" : lstUnitLayout2[txtUnitName.SelectedIndex]);
                        DataRow[] drs = bg.Result.Tables[0].Select(query);
                        if (drs.Length == 0)
                        {
                            ProcessAddRISUserorgmap ba = new ProcessAddRISUserorgmap();
                            ba.RIS_USERORGMAP.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                            ba.RIS_USERORGMAP.ACCESS_ORG_ID = new GBLEnvVariable().OrgID;
                            ba.RIS_USERORGMAP.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                            ba.RIS_USERORGMAP.CREATED_BY = new GBLEnvVariable().UserID;
                            ba.RIS_USERORGMAP.ORG_ID = new GBLEnvVariable().OrgID;
                            ba.Invoke();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        return;
                    }
                    #endregion

                    #region initControl
                    EnableTextControl(false);

                    mm.ShowAlert("UID2002", new GBLEnvVariable().CurrentLanguageID);

                    btnribbonAdd.Visible = true;
                    btnribbonUpdate.Visible = true;
                    //btnribbonDelete.Visible = true;
                    btnribbonBack.Visible = true;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;

                    btnribbonShowPassword.Visible = true;
                    btnribbonRefreshPassword.Visible = true;

                    btnribbonGrantRole.Visible = true;
                    btnribbonGrantUnit.Visible = true;

                    gcAccountList.Enabled = true;
                    
                    chkShowActiveUser.Checked = chkIsActive.Checked;

                    int focusAt = gvAccountList.FocusedRowHandle;
                    //txtSearch.Text = txtUserName.Text.Trim();
                    Reload();
                    gvAccountList.FocusedRowHandle = focusAt;
                    drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);
                    if (drLayout2 != null)
                        LoadGridLayout2();
                    else
                    {
                        tabUserAccount.SelectedTabPage = pageAccPreview;
                        if (gvAccountList.RowCount > 0)
                            gvAccountList.Focus();
                        else
                            txtSearch.Focus();
                    }

                    saveStatus = "";
                    #endregion
                }
            }
        }
        private void LoadbtnCancel()
        {
            if (!createNewAccount)
            {
                EnableTextControl(false);

                btnribbonAdd.Visible = true;
                btnribbonUpdate.Visible = true;
                //btnribbonDelete.Visible = true;
                btnribbonBack.Visible = true;

                btnribbonSave.Visible = false;
                btnribbonCancel.Visible = false;

                btnribbonShowPassword.Visible = true;
                btnribbonRefreshPassword.Visible = true;

                btnribbonGrantRole.Visible = false;
                btnribbonGrantUnit.Visible = false;

                gcAccountList.Enabled = true;

                LoadGridLayout2();

                if (gvAccountList.RowCount > 0)
                    gvAccountList.Focus();
                else
                    txtSearch.Focus();

                saveStatus = "";
            }
            else
                createNewAccount_afterCancel();
        }
        private void LoadbtnBack()
        {
            tabUserAccount.SelectedTabPage = pageAccPreview;

            btnribbonAdd.Visible = true;
            btnribbonUpdate.Visible = true;
            //btnribbonDelete.Visible = true;

            btnribbonSave.Visible = false;
            btnribbonCancel.Visible = false;

            btnribbonGrantUnit.Visible = false;
            btnribbonGrantRole.Visible = false;

            gcAccountList.Enabled = true;

            if (gvAccountList.RowCount > 0)
                gvAccountList.Focus();
            else
                txtSearch.Focus();

            saveStatus = "";
        }

        #region Create New Account From Hot-Keys
        private void createNewAccount_inittal()
        {
            MyMessageBox mm = new MyMessageBox();
            if (mm.ShowAlert("UID2119", new GBLEnvVariable().CurrentLanguageID) == "2")
            {
                createNewAccount = true;

                tabUserAccount.SelectedTabPage = pageAccDetail;

                #region loadTitle
                txtTitle.Properties.Items.Clear();
                txtTitle.Properties.Items.AddRange(TitleThaiName);
                #endregion

                #region loadTitleEng
                txtTitleEng.Properties.Items.Clear();
                txtTitleEng.Properties.Items.AddRange(TitleEngName);
                #endregion

                #region loadGender
                txtGender.Properties.Items.Clear();
                txtGender.Properties.Items.AddRange
                    (
                        new string[] { "Male", "Female" }
                    );
                #endregion

                #region loadUnit
                ProcessGetHRUnit bgUnit = new ProcessGetHRUnit();
                bgUnit.Invoke();
                DataRow[] drsUnit = bgUnit.Result.Tables[0].Select("UNIT_TYPE='S'");
                lstUnitLayout2.Clear();
                txtUnitName.Properties.Items.Clear();
                foreach (DataRow dr in drsUnit)
                {
                    lstUnitLayout2.Add(dr["UNIT_ID"].ToString());
                    txtUnitName.Properties.Items.Add(dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString());
                }
                #endregion

                #region loadAuthLv
                ProcessGetRISAuthlevel bgAuth = new ProcessGetRISAuthlevel();
                bgAuth.Invoke();
                lstAuthLvLayout2.Clear();
                txtAuthorityLevel.Properties.Items.Clear();
                foreach (DataRow dr in bgAuth.Result.Tables[0].Rows)
                {
                    lstAuthLvLayout2.Add(dr["AUTH_LEVEL_ID"].ToString());
                    txtAuthorityLevel.Properties.Items.Add(dr["AUTH_LEVEL_ID"].ToString() + ":" + dr["AUTH_LEVEL_DESC"].ToString());
                }
                #endregion

                #region loadDefaultLanguage
                ProcessSelectGBLLanguage bgLang = new ProcessSelectGBLLanguage();
                bgLang.Invoke2();
                lstDefaultLangLayout2.Clear();
                txtDefaultLanguage.Properties.Items.Clear();
                DataRow[] drsLang = bgLang.ResultSet.Tables[0].Select("IS_ACTIVE='Y'");
                foreach (DataRow dr in drsLang)
                {
                    lstDefaultLangLayout2.Add(dr["LANG_ID"].ToString());
                    txtDefaultLanguage.Properties.Items.Add(dr["LANG_UID"].ToString() + ":" + dr["LANG_NAME"].ToString());
                }
                DataRow[] drsLangFilter = bgLang.ResultSet.Tables[0].Select("IS_DEFAULT='Y'");
                bool flag = false;
                int SelectIndex = 0;
                foreach (DataRow dr in drsLangFilter)
                {
                    if (dr["IS_DEFAULT"].ToString() == "Y")
                    {
                        flag = true;
                        break;
                    }
                    SelectIndex++;
                }
                if (flag)
                    txtDefaultLanguage.SelectedIndex = SelectIndex;
                #endregion

                #region button setting

                btnribbonAdd.Visible = false;
                btnribbonUpdate.Visible = false;
                //btnribbonDelete.Visible = false;

                btnribbonSave.Visible = true;
                btnribbonCancel.Visible = true;

                btnribbonBack.Visible = false;

                btnribbonShowPassword.Visible = false;
                btnribbonRefreshPassword.Visible = false;

                btnribbonGrantRole.Visible = false;
                btnribbonGrantUnit.Visible = false;

                EnableTextControl(true);

                saveStatus = "Add";

                #endregion

                #region clearTextBox

                txtEmpUid.Tag = null;
                txtEmpUid.Text = "";
                txtUserName.Text = txtSearch.Text;
                txtPassword.Text = "";

                txtSecurityQuestion.Text = "";
                txtSecurityAnswer.Text = "";

                txtTitle.Text = "";
                txtFname.Text = "";
                txtMname.Text = "";
                txtLname.Text = "";

                txtTitleEng.Text = "";
                txtFnameEng.Text = "";
                txtMnameEng.Text = "";
                txtLnameEng.Text = "";

                txtGender.SelectedIndex = 0;
                txtUnitName.SelectedIndex = txtSearchUnit.SelectedIndex == 0 ? 0 : txtSearchUnit.SelectedIndex - 1;
                txtJobType.SelectedIndex = 0;
                txtAuthorityLevel.SelectedIndex = txtSearchAuthLV.SelectedIndex == 0 ? 0 : txtSearchAuthLV.SelectedIndex - 1;
                txtDefaultLanguage.SelectedIndex = 1;

                chkIsActive.Checked = false;
                chkRadiologist.Checked = false;
                chkSupportUser.Checked = false;
                chkScheduleExceed.Checked = false;
                chkAllowOtherstoFinalize.Checked = false;
                chkCanKillSession.Checked = false;

                txtCreatedOn.Text = "";
                txtLastModifiedOn.Text = "";

                chkResident.Checked = false;
                txtJobTitle.EditValue = null;

                txtAuthorityLevel.Enabled = false;
                chkFellow.Checked = false;

                txtPhoneNo.Tag = "###";
                txtPhoneNo.Text = "";

                txtEmailAddress.Tag = "###";
                txtEmailAddress.Text = "";

                chkRadiologist.Checked = false;

                #endregion

                txtJobTitle_Reload();

                txtUserName.Focus();

            }
        }
        private void createNewAccount_afterAdd()
        {
            MyMessageBox mm = new MyMessageBox();

            txtSearch.Text = txtUserName.Text;

            EnableTextControl(false);

            mm.ShowAlert("UID2002", new GBLEnvVariable().CurrentLanguageID);

            btnribbonAdd.Visible = true;
            btnribbonUpdate.Visible = true;
            //btnribbonDelete.Visible = true;
            btnribbonBack.Visible = true;

            btnribbonSave.Visible = false;
            btnribbonCancel.Visible = false;

            btnribbonShowPassword.Visible = true;
            btnribbonRefreshPassword.Visible = true;

            btnribbonGrantRole.Visible = true;
            btnribbonGrantUnit.Visible = true;

            int focusAt = gvAccountList.FocusedRowHandle;
            Reload();
            gvAccountList.FocusedRowHandle = focusAt;
            drLayout2 = gvAccountList.GetDataRow(gvAccountList.FocusedRowHandle);

            tabUserAccount.SelectedTabPage = pageAccPreview;

            createNewAccount = false;

            saveStatus = "";
        }
        private void createNewAccount_afterCancel()
        {
            tabUserAccount.SelectedTabPage = pageAccPreview;

            EnableTextControl(false);

            btnribbonAdd.Visible = true;
            btnribbonUpdate.Visible = true;
            //btnribbonDelete.Visible = true;
            btnribbonBack.Visible = true;

            btnribbonSave.Visible = false;
            btnribbonCancel.Visible = false;

            btnribbonShowPassword.Visible = true;
            btnribbonRefreshPassword.Visible = true;

            btnribbonGrantRole.Visible = false;
            btnribbonGrantUnit.Visible = false;

            createNewAccount = false;

            saveStatus = "";
        }
        #endregion

        #region Title Thai Name
        private string[] TitleThaiName = new string[]
        { 
            "นาย",
            "นางสาว",
            "นาง",

            "บาทหลวง",
            "แม่ชี",
            "พระ",
            "หม่อมราชวงศ์",
            "หม่อมหลวง",
            "รองศาสตราจารย์",
            "ผู้ช่วยศาสตราจารย์",

            "พล.อ.อ.",
            "พล.อ.ท.",
            "พล.อ.ต.",
            "น.อ.",
            "น.ท.",
            "น.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "พ.อ.อ.",
            "พ.จ.ท.",
            "พ.อ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",

            "พล.อ.",
            "พล.ท.",
            "พล.ต.",
            "พ.อ.",
            "พ.ท.",
            "พ.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "จ.ส.อ.",
            "จ.ส.ท.",
            "จ.ส.ต.",
            "ส.อ.",
            "ส.ท.",
            "ส.ต.",
            "พลฯ",

            "พล.ร.อ.",
            "พล.ร.ท.",
            "พล.ร.ต.",
            "น.อ...ร.น.",
            "น.ท...ร.น.",
            "น.ต...ร.น.",
            "ร.อ...ร.น.",
            "ร.ท...ร.น.",
            "ร.ต...ร.น.",
            "พ.จ.อ.",
            "พ.จ.ท.",
            "พ.จ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",

            "พล.ต.อ.",
            "พล.ต.ท.",
            "พล.ต.ต.",
            "พ.ต.อ.",
            "พ.ต.ท.",
            "พ.ต.ต.",
            "ร.ต.อ",
            "ร.ต.ท",
            "ร.ต.ต",
            "ด.ต.",
            "จ.ส.อ.",
            "ส.ต.อ.",
            "ส.ต.ท.",
            "ส.ต.ต.",
            "พลตำรวจ",
        };
        #endregion Title Thai Name

        #region Title Eng Name
        private string[] TitleEngName = new string[]
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