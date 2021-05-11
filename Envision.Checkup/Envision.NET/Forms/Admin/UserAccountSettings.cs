using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.BusinessLogic;
using RIS.Operational;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Admin
{
    public partial class UserAccountSettings : Form
    {
        #region gridlayout1 variable
        DataTable dtWL = new DataTable();
        List<string> lstUnit = new List<string>();
        List<string> lstAuth = new List<string>();
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

        public UserAccountSettings(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
        }
        private void GBL_SF04_Load(object sender, EventArgs e)
        {
            preLoad = true;
            layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.SingleRecord;
            LoadUnit();
            LoadAulthLV();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            layoutControlGroup3.Expanded = true;
            txtUnit.SelectedIndex = 0;
            txtAuthLV.SelectedIndex = 0;
            Reload();
            layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;
            preLoad = false;

            txtSearch.Focus();
            this.KeyDown +=new KeyEventHandler(UserAccountSettings_KeyDown);
        }

        private void UserAccountSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageView2)
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
            txtUnit.Properties.Items.Clear();
            lstUnit.Add("ALL");
            txtUnit.Properties.Items.Add("All Departments");
            foreach (DataRow dr in drs)
            {
                lstUnit.Add(dr["UNIT_ID"].ToString());
                txtUnit.Properties.Items.Add(dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString());
            }
            lstUnit.Add("Other");
            txtUnit.Properties.Items.Add("Other Departments");
        }
        private void LoadAulthLV()
        {
            ProcessGetRISAuthlevel bg = new ProcessGetRISAuthlevel();
            bg.Invoke();
            DataTable dt = bg.Result.Tables[0];
            lstAuth.Clear();
            txtAuthLV.Properties.Items.Clear();
            lstAuth.Add("ALL");
            txtAuthLV.Properties.Items.Add("All Authority Level");
            foreach (DataRow dr in dt.Rows)
            {
                lstAuth.Add(dr["AUTH_LEVEL_ID"].ToString());
                txtAuthLV.Properties.Items.Add(dr["AUTH_LEVEL_ID"].ToString() + ":" + dr["AUTH_LEVEL_DESC"].ToString());
            }
        }

        private void LoadTableLayout()
        {
            if (txtUnit.SelectedIndex == 0 && txtAuthLV.SelectedIndex == 0)
            {
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HREmp.MODE = "All";
                bg.HREmp.EMP_ID = 0;
                bg.HREmp.USER_NAME = "";
                bg.HREmp.UNIT_ID = 0;
                bg.HREmp.AUTH_LEVEL_ID = 0;
                bg.Invoke();
                dtWL = bg.Result.Tables[0];
            }
            else if (txtUnit.SelectedIndex == txtUnit.Properties.Items.Count - 1 && txtAuthLV.SelectedIndex == 0)
            {
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HREmp.MODE = "OtherUnit+AuthAll";
                bg.HREmp.EMP_ID = 0;
                bg.HREmp.USER_NAME = "";
                bg.HREmp.UNIT_ID = 0;
                bg.HREmp.AUTH_LEVEL_ID = 0;
                bg.Invoke();
                dtWL = bg.Result.Tables[0];
            }
            else if (txtUnit.SelectedIndex == txtUnit.Properties.Items.Count - 1 && txtAuthLV.SelectedIndex != 0)
            {
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HREmp.MODE = "OtherUnit+!AuthAll";
                bg.HREmp.EMP_ID = 0;
                bg.HREmp.USER_NAME = "";
                bg.HREmp.UNIT_ID = 0;
                bg.HREmp.AUTH_LEVEL_ID = Convert.ToInt32(lstAuth[txtAuthLV.SelectedIndex]);
                bg.Invoke();
                dtWL = bg.Result.Tables[0];
            }
            else if (txtUnit.SelectedIndex == 0)
            {
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HREmp.MODE = "AuthLv";
                bg.HREmp.EMP_ID = 0;
                bg.HREmp.USER_NAME = "";
                bg.HREmp.UNIT_ID = 0;
                bg.HREmp.AUTH_LEVEL_ID = Convert.ToInt32(lstAuth[txtAuthLV.SelectedIndex]);
                bg.Invoke();
                dtWL = bg.Result.Tables[0];
            }
            else if (txtAuthLV.SelectedIndex == 0)
            {
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HREmp.MODE = "UnitId";
                bg.HREmp.EMP_ID = 0;
                bg.HREmp.USER_NAME = "";
                bg.HREmp.UNIT_ID = Convert.ToInt32(lstUnit[txtUnit.SelectedIndex]);
                bg.HREmp.AUTH_LEVEL_ID = 0;
                bg.Invoke();
                dtWL = bg.Result.Tables[0];
            }
            else
            {
                ProcessGetHREmp bg = new ProcessGetHREmp();
                bg.HREmp.MODE = "UnitId+AuthLv";
                bg.HREmp.EMP_ID = 0;
                bg.HREmp.USER_NAME = "";
                bg.HREmp.UNIT_ID = Convert.ToInt32(lstUnit[txtUnit.SelectedIndex]);
                bg.HREmp.AUTH_LEVEL_ID = Convert.ToInt32(lstAuth[txtAuthLV.SelectedIndex]);
                bg.Invoke();
                dtWL = bg.Result.Tables[0];
            }
        }
        private void LoadFilterLayout()
        {
            DataTable dt = dtWL.Clone();
            string ts = txtSearch.Text;
            string query = "(EMP_UID like '%" + ts + "%' OR USER_NAME like '%" + ts + "%' OR FullName like '%" + ts + "%')";
            if (chkShowInactivationUser.Checked == false)
                query += " AND IS_ACTIVE='Y' ";
            else
                query += " AND (IS_ACTIVE='N' OR IS_ACTIVE is null) ";
            DataRow[] drs = dtWL.Select(query);
            foreach (DataRow dr in drs)
                dt.Rows.Add(dr.ItemArray);
            dtWL = dt;
        }
        private void LoadGridLayout()
        {
            gridControl1.DataSource = dtWL.Copy();
            layoutView1.ClearSorting();

        }
        private void Reload()
        {
            layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.SingleRecord;
            LoadTableLayout();
            LoadFilterLayout();
            LoadGridLayout();
            LoadGridList();
            layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;
        }

        private void txtUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!preLoad)
                Reload();
        }
        private void txtAuthLV_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!preLoad)
                Reload();
        }

        #region gridList
        private void LoadGridList()
        {
            gridControl2.DataSource = dtWL.Copy();
        }
        private void gridView2_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1 && !preLoad)
            {
                if (Math.Abs((decimal)(gridView2.FocusedRowHandle - layoutView1.FocusedRowHandle)) > 99)
                {
                    DevExpress.XtraGrid.Views.Layout.LayoutViewMode mode;
                    mode = layoutView1.OptionsView.ViewMode;
                    layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
                    layoutView1.FocusedRowHandle = gridView2.FocusedRowHandle;
                    layoutView1.OptionsView.ViewMode = mode;
                }
                else
                {
                    layoutView1.OptionsCarouselMode.FrameDelay = 10000;
                    layoutView1.FocusedRowHandle = gridView2.FocusedRowHandle;
                    layoutView1.OptionsCarouselMode.FrameDelay = 40000;
                }
            }
        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1 && !preLoad)
            {
                if (Math.Abs((decimal)(gridView2.FocusedRowHandle - layoutView1.FocusedRowHandle)) > 99)
                {
                    DevExpress.XtraGrid.Views.Layout.LayoutViewMode mode;
                    mode = layoutView1.OptionsView.ViewMode;
                    layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
                    layoutView1.FocusedRowHandle = gridView2.FocusedRowHandle;
                    layoutView1.OptionsView.ViewMode = mode;
                }
                else
                {
                    layoutView1.OptionsCarouselMode.FrameDelay = 10000;
                    layoutView1.FocusedRowHandle = gridView2.FocusedRowHandle;
                    layoutView1.OptionsCarouselMode.FrameDelay = 40000;
                }
            }
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                xtraTabControl1.SelectedTabPage = pageView2;
                drLayout2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                LoadGridLayout2();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
            if (gridView2.RowCount == 0)
                createNewAccount_inittal();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Reload();
                if (gridView2.RowCount == 0)
                    createNewAccount_inittal();
                else
                    gridView2.Focus();
            }
        }
        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
                createNewAccount_inittal();
        }
        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (gridView2.FocusedRowHandle > -1)
                {
                    xtraTabControl1.SelectedTabPage = pageView2;
                    drLayout2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                    LoadGridLayout2();
                }
            }
        }
        private void chkShowUser_CheckedChanged(object sender, EventArgs e)
        {
            Reload();
        }
        #endregion

        #region gridLayout
        private void layoutView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (layoutView1.FocusedRowHandle > -1)
            {
                preLoad = true;
                gridView2.FocusedRowHandle = layoutView1.FocusedRowHandle;
                preLoad = false;
            }
        }
        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {
            if (layoutView1.FocusedRowHandle > -1)
            {
                xtraTabControl1.SelectedTabPage = pageView2;
                drLayout2 = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                LoadGridLayout2();
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
                createNewAccount_inittal();
        }
        #endregion

        #region gridlayout2
        private void LoadGridLayout2()
        {
            if (drLayout2["EMP_ID"].ToString() == "" || drLayout2["EMP_ID"] == null)
                return;

            #region LoadButton
            ProcessGetHREmp bg = new ProcessGetHREmp();
            bg.HREmp.MODE = "EmpId";
            bg.HREmp.EMP_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
            bg.HREmp.USER_NAME = "";
            bg.HREmp.UNIT_ID = 0;
            bg.HREmp.AUTH_LEVEL_ID = 0;
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

                #region fillTextBox
                DataRow row = drLayout2;

                txtEmpUid.Tag = Convert.ToInt32(row["EMP_ID"]);
                txtEmpUid.Text = row["EMP_UID"].ToString();

                txtUserName.Text = row["USER_NAME"].ToString();
                try {
                    txtPassword.Text = Secure.Decrypt(row["PWD"].ToString());
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

                if (row["CAN_KILL_SESSION"].ToString() == "Y")
                    chkCanKillSession.Checked = true;
                else chkCanKillSession.Checked = false;

                if (row["IS_RESIDENT"].ToString() == "Y")
                    chkIsResident.Checked = true;
                else chkIsResident.Checked = false;

                txtCreatedOn.Text = row["CREATED_ON"].ToString() == "" ? "" : Convert.ToDateTime(row["CREATED_ON"]).ToString("G");
                txtLastModifiedOn.Text = row["LAST_MODIFIED_ON"].ToString() == "" ? "" : Convert.ToDateTime(row["LAST_MODIFIED_ON"]).ToString("G");
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Load layout2 Error"+ex.Message);
            }

            if (gridView2.RowCount > -1)
                gridView2.Focus();
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
            chkAllowOtherstoFinalize.Enabled = enable;
            chkCanKillSession.Enabled = enable;

            txtAuthLV.Enabled = !enable;
            txtUnit.Enabled = !enable;

            txtSearch.Enabled = !enable;
            btnSearch.Enabled = !enable;

            chkIsResident.Enabled = enable;
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
            if (txtFname.Text.Trim() != "")
            {
                txtFnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtFname.Text).Trim();
                if (txtFnameEng.Text.Length > 0)
                {
                    string firstLetter = txtFnameEng.Text.Substring(0, 1);
                    string firstUpper = firstLetter.ToUpper();
                    string firstDelete = txtFnameEng.Text.Remove(0, 1);
                    txtFnameEng.Text = firstUpper + firstDelete;
                }
            }
        }
        private void txtMname_TextChanged(object sender, EventArgs e)
        {
            if (txtMname.Text.Trim() != "")
            {
                txtMnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtMname.Text).Trim();
                if (txtMnameEng.Text.Length > 0)
                {
                    string firstLetter = txtMnameEng.Text.Substring(0, 1);
                    string firstUpper = firstLetter.ToUpper();
                    string firstDelete = txtMnameEng.Text.Remove(0, 1);
                    txtMnameEng.Text = firstUpper + firstDelete;
                }
            }
        }
        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            if (txtLname.Text.Trim() != "")
            {
                txtLnameEng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtLname.Text).Trim();
                if (txtLnameEng.Text.Length > 0)
                {
                    string firstLetter = txtLnameEng.Text.Substring(0, 1);
                    string firstUpper = firstLetter.ToUpper();
                    string firstDelete = txtLnameEng.Text.Remove(0, 1);
                    txtLnameEng.Text = firstUpper + firstDelete;
                }
            }
        }
        #endregion

        #region ribbon control
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
                mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (txtUserName.Text == "")
            {
                mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                return;
            }

            #endregion

            string str = mm.ShowAlert("UID2112", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                ProcessUpdateHREmp bu = new ProcessUpdateHREmp();
                try
                {
                    bu.HREmp.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                    bu.HREmp.EMP_UID = txtEmpUid.Text;

                    bu.HREmp.USER_NAME = txtUserName.Text;
                    //bu.HREmp.PWD = txtPassword.Text == "" ? Secure.Encrypt("envision") : Secure.Encrypt(txtPassword.Text);
                    bu.HREmp.PWD = Secure.Encrypt("envision");

                    bu.HREmp.SECURITY_QUESTION = txtSecurityQuestion.Text;
                    bu.HREmp.SECURITY_ANSWER = txtSecurityAnswer.Text;

                    bu.HREmp.SALUTATION = txtTitle.Text;
                    bu.HREmp.FNAME = txtFname.Text;
                    bu.HREmp.MNAME = txtMname.Text;
                    bu.HREmp.LNAME = txtLname.Text;

                    bu.HREmp.TITLE_ENG = txtTitleEng.Text;
                    bu.HREmp.FNAME_ENG = txtFnameEng.Text;
                    bu.HREmp.MNAME_ENG = txtMnameEng.Text;
                    bu.HREmp.LNAME_ENG = txtLnameEng.Text;

                    bu.HREmp.GENDER = txtGender.Text;
                    bu.HREmp.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                    bu.HREmp.JOB_TYPE = txtJobType.Text;
                    bu.HREmp.AUTH_LEVEL_ID = txtAuthorityLevel.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstAuthLvLayout2[txtAuthorityLevel.SelectedIndex]);
                    bu.HREmp.DEFAULT_LANG = txtDefaultLanguage.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstDefaultLangLayout2[txtDefaultLanguage.SelectedIndex]);

                    bu.HREmp.IS_ACTIVE = chkIsActive.Checked ? "Y" : "N";
                    bu.HREmp.IS_RADIOLOGIST = chkRadiologist.Checked ? "Y" : "N";
                    bu.HREmp.SUPPORT_USER = chkSupportUser.Checked ? "Y" : "N";
                    bu.HREmp.ALLOW_OTHERS_TO_FINALIZE = chkAllowOtherstoFinalize.Checked ? "Y" : "N";
                    bu.HREmp.CAN_KILL_SESSION = chkCanKillSession.Checked ? "Y" : "N";

                    bu.HREmp.EMP_REPORT_FOOTER1 = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
                    bu.HREmp.EMP_REPORT_FOOTER2 = txtFnameEng.Text + " " + txtMnameEng.Text + " " + txtLnameEng.Text;

                    bu.HREmp.LAST_MODIFIED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;

                    bu.HREmp.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                    bu.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    return;
                }

                mm.ShowAlert("UID2113", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);

                int focusAt = gridView2.FocusedRowHandle;
                Reload();
                gridView2.FocusedRowHandle = focusAt;
                drLayout2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
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

            gridControl2.Enabled = false;

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
            txtUnitName.SelectedIndex = txtUnit.SelectedIndex == 0 ? 0 : txtUnit.SelectedIndex - 1;
            txtJobType.SelectedIndex = 0;
            txtAuthorityLevel.SelectedIndex = txtAuthLV.SelectedIndex == 0 ? 0 : txtAuthLV.SelectedIndex - 1;
            txtDefaultLanguage.SelectedIndex = 1;

            chkIsActive.Checked = false;
            chkRadiologist.Checked = false;
            chkSupportUser.Checked = false;
            chkAllowOtherstoFinalize.Checked = false;
            chkCanKillSession.Checked = false;

            txtCreatedOn.Text = "";
            txtLastModifiedOn.Text = "";

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

            gridControl2.Enabled = false;

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
                mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                return;
            }
            if (mm.ShowAlert("UID4003", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID) == "2")
            {
                try
                {
                    ProcessDeleteHREmp bd = new ProcessDeleteHREmp();
                    bd.HREmp.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                    bd.Invoke();

                    int focusAt = gridView2.FocusedRowHandle;
                    Reload();
                    gridView2.FocusedRowHandle = focusAt;
                    if (gridView2.FocusedRowHandle > -1)
                    {
                        drLayout2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                        LoadGridLayout2();
                    }
                    else
                    {
                        xtraTabControl1.SelectedTabPage = pageView1;
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
            string str = mm.ShowAlert("UID4001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);

            if (str == "2")
            {
                if (saveStatus == "Add")
                {
                    #region checkAdd

                    if (txtUserName.Text == "")
                    {
                        mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        txtUserName.Focus();
                        return;
                    }
                    if (txtFname.Text == "")
                    {
                        mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        txtFname.Focus();
                        return;
                    }
                    if (txtLname.Text == "")
                    {
                        mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        txtLname.Focus();
                        return;
                    }

                    ProcessGetHREmp bgUN = new ProcessGetHREmp();
                    bgUN.HREmp.MODE = "UserName";
                    bgUN.HREmp.USER_NAME = txtUserName.Text;
                    bgUN.Invoke();
                    if (bgUN.Result.Tables[0].Rows.Count > 0)
                    {
                        mm.ShowAlert("UID2120", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        mm.ShowAlert("UID2121", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        txtUserName.Focus();
                        return;
                    }

                    #endregion

                    #region Add
                    ProcessAddHREmp ba = new ProcessAddHREmp();
                    try
                    {
                        //ba.HREmp.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                        ba.HREmp.EMP_UID = txtEmpUid.Text;

                        ba.HREmp.USER_NAME = txtUserName.Text;
                        ba.HREmp.PWD = txtPassword.Text == "" ? Secure.Encrypt("envision") : Secure.Encrypt(txtPassword.Text);

                        ba.HREmp.SECURITY_QUESTION = txtSecurityQuestion.Text;
                        ba.HREmp.SECURITY_ANSWER = txtSecurityAnswer.Text;

                        ba.HREmp.SALUTATION = txtTitle.Text;
                        ba.HREmp.FNAME = txtFname.Text;
                        ba.HREmp.MNAME = txtMname.Text;
                        ba.HREmp.LNAME = txtLname.Text;

                        ba.HREmp.TITLE_ENG = txtTitleEng.Text;
                        ba.HREmp.FNAME_ENG = txtFnameEng.Text;
                        ba.HREmp.MNAME_ENG = txtMnameEng.Text;
                        ba.HREmp.LNAME_ENG = txtLnameEng.Text;

                        ba.HREmp.GENDER = txtGender.Text;
                        ba.HREmp.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                        ba.HREmp.JOB_TYPE = txtJobType.Text;
                        ba.HREmp.AUTH_LEVEL_ID = txtAuthorityLevel.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstAuthLvLayout2[txtAuthorityLevel.SelectedIndex]);
                        ba.HREmp.DEFAULT_LANG = txtDefaultLanguage.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstDefaultLangLayout2[txtDefaultLanguage.SelectedIndex]);

                        ba.HREmp.IS_ACTIVE = chkIsActive.Checked ? "Y" : "N";
                        ba.HREmp.IS_RADIOLOGIST = chkRadiologist.Checked ? "Y" : "N";
                        ba.HREmp.SUPPORT_USER = chkSupportUser.Checked ? "Y" : "N";
                        ba.HREmp.ALLOW_OTHERS_TO_FINALIZE = chkAllowOtherstoFinalize.Checked ? "Y" : "N";
                        ba.HREmp.CAN_KILL_SESSION = chkCanKillSession.Checked ? "Y" : "N";

                        ba.HREmp.EMP_REPORT_FOOTER1 = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
                        ba.HREmp.EMP_REPORT_FOOTER2 = txtFnameEng.Text + " " + txtMnameEng.Text + " " + txtLnameEng.Text;

                        ba.HREmp.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;

                        ba.HREmp.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                        ba.HREmp.IS_RESIDENT = chkIsResident.Checked ? "Y" : "N";

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
                        bg.RISUserorgmap.MODE = 2;
                        bg.Invoke();
                        string query = "EMP_ID=" + Convert.ToInt32(txtEmpUid.Tag).ToString() + " and UNIT_ID=" + (txtUnitName.SelectedIndex == -1 ? "0" : lstUnitLayout2[txtUnitName.SelectedIndex]);
                        DataRow[] drs = bg.Result.Tables[0].Select(query);
                        if (drs.Length == 0)
                        {
                            ProcessGetHREmp bgg = new ProcessGetHREmp();
                            bgg.HREmp.MODE = "UserName";
                            bgg.HREmp.USER_NAME = txtUserName.Text;
                            bgg.Invoke();

                            ProcessAddRISUserorgmap baa = new ProcessAddRISUserorgmap();
                            baa.RISUserorgmap.EMP_ID = Convert.ToInt32(bgg.Result.Tables[0].Rows[0]["EMP_ID"]);
                            baa.RISUserorgmap.ACCESS_ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                            baa.RISUserorgmap.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                            baa.RISUserorgmap.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                            baa.RISUserorgmap.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
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

                        mm.ShowAlert("UID2002", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);

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

                        gridControl2.Enabled = true;

                        chkShowInactivationUser.Checked = !chkIsActive.Checked;

                        int focusAt = gridView2.FocusedRowHandle;
                        txtSearch.Text = txtUserName.Text.Trim();
                        Reload();
                        gridView2.FocusedRowHandle = focusAt;
                        drLayout2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                        if (drLayout2 != null)
                            LoadGridLayout2();
                        else
                        {
                            xtraTabControl1.SelectedTabPage = pageView1;
                            if (gridView2.RowCount > 0)
                                gridView2.Focus();
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
                        mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        return;
                    }
                    if (txtUserName.Text == "")
                    {
                        mm.ShowAlert("UID2001", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        return;
                    }

                    ProcessGetHREmp bgUN = new ProcessGetHREmp();
                    bgUN.HREmp.MODE = "Username+!EmpId";
                    bgUN.HREmp.USER_NAME = txtUserName.Text;
                    bgUN.HREmp.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                    bgUN.Invoke();
                    if (bgUN.Result.Tables[0].Rows.Count > 0)
                    {
                        mm.ShowAlert("UID2120", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        mm.ShowAlert("UID2121", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                        txtUserName.Focus();
                        return;
                    }

                    #endregion

                    #region update
                    ProcessUpdateHREmp bu = new ProcessUpdateHREmp();

                    try
                    {
                        bu.HREmp.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                        bu.HREmp.EMP_UID = txtEmpUid.Text;

                        bu.HREmp.USER_NAME = txtUserName.Text;
                        bu.HREmp.PWD = txtPassword.Text == "" ? Secure.Encrypt("envision") : Secure.Encrypt(txtPassword.Text);

                        bu.HREmp.SECURITY_QUESTION = txtSecurityQuestion.Text;
                        bu.HREmp.SECURITY_ANSWER = txtSecurityAnswer.Text;

                        bu.HREmp.SALUTATION = txtTitle.Text;
                        bu.HREmp.FNAME = txtFname.Text;
                        bu.HREmp.MNAME = txtMname.Text;
                        bu.HREmp.LNAME = txtLname.Text;

                        bu.HREmp.TITLE_ENG = txtTitleEng.Text;
                        bu.HREmp.FNAME_ENG = txtFnameEng.Text;
                        bu.HREmp.MNAME_ENG = txtMnameEng.Text;
                        bu.HREmp.LNAME_ENG = txtLnameEng.Text;

                        bu.HREmp.GENDER = txtGender.Text;
                        bu.HREmp.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                        bu.HREmp.JOB_TYPE = txtJobType.Text;
                        bu.HREmp.AUTH_LEVEL_ID = txtAuthorityLevel.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstAuthLvLayout2[txtAuthorityLevel.SelectedIndex]);
                        bu.HREmp.DEFAULT_LANG = txtDefaultLanguage.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstDefaultLangLayout2[txtDefaultLanguage.SelectedIndex]);

                        bu.HREmp.IS_ACTIVE = chkIsActive.Checked ? "Y" : "N";
                        bu.HREmp.IS_RADIOLOGIST = chkRadiologist.Checked ? "Y" : "N";
                        bu.HREmp.SUPPORT_USER = chkSupportUser.Checked ? "Y" : "N";
                        bu.HREmp.ALLOW_OTHERS_TO_FINALIZE = chkAllowOtherstoFinalize.Checked ? "Y" : "N";
                        bu.HREmp.CAN_KILL_SESSION = chkCanKillSession.Checked ? "Y" : "N";

                        bu.HREmp.EMP_REPORT_FOOTER1 = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
                        bu.HREmp.EMP_REPORT_FOOTER2 = txtFnameEng.Text + " " + txtMnameEng.Text + " " + txtLnameEng.Text;

                        bu.HREmp.LAST_MODIFIED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;

                        bu.HREmp.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                        bu.HREmp.IS_RESIDENT = chkIsResident.Checked ? "Y" : "N";

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
                        bg.RISUserorgmap.MODE = 2;
                        bg.Invoke();
                        string query = "EMP_ID=" + txtEmpUid.Tag.ToString() + " and UNIT_ID=" + (txtUnitName.SelectedIndex == -1 ? "0" : lstUnitLayout2[txtUnitName.SelectedIndex]);
                        DataRow[] drs = bg.Result.Tables[0].Select(query);
                        if (drs.Length == 0)
                        {
                            ProcessAddRISUserorgmap ba = new ProcessAddRISUserorgmap();
                            ba.RISUserorgmap.EMP_ID = Convert.ToInt32(txtEmpUid.Tag);
                            ba.RISUserorgmap.ACCESS_ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                            ba.RISUserorgmap.UNIT_ID = txtUnitName.SelectedIndex == -1 ? 0 : Convert.ToInt32(lstUnitLayout2[txtUnitName.SelectedIndex]);
                            ba.RISUserorgmap.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                            ba.RISUserorgmap.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
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

                    mm.ShowAlert("UID2002", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);

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

                    gridControl2.Enabled = true;
                    
                    chkShowInactivationUser.Checked = !chkIsActive.Checked;

                    int focusAt = gridView2.FocusedRowHandle;
                    //txtSearch.Text = txtUserName.Text.Trim();
                    Reload();
                    gridView2.FocusedRowHandle = focusAt;
                    drLayout2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                    if (drLayout2 != null)
                        LoadGridLayout2();
                    else
                    {
                        xtraTabControl1.SelectedTabPage = pageView1;
                        if (gridView2.RowCount > 0)
                            gridView2.Focus();
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

                gridControl2.Enabled = true;

                LoadGridLayout2();

                if (gridView2.RowCount > 0)
                    gridView2.Focus();
                else
                    txtSearch.Focus();

                saveStatus = "";
            }
            else
                createNewAccount_afterCancel();
        }
        private void LoadbtnBack()
        {
            xtraTabControl1.SelectedTabPage = pageView1;

            btnribbonAdd.Visible = true;
            btnribbonUpdate.Visible = true;
            //btnribbonDelete.Visible = true;

            btnribbonSave.Visible = false;
            btnribbonCancel.Visible = false;

            btnribbonGrantUnit.Visible = false;
            btnribbonGrantRole.Visible = false;

            gridControl2.Enabled = true;

            if (gridView2.RowCount > 0)
                gridView2.Focus();
            else
                txtSearch.Focus();

            saveStatus = "";
        }
        #endregion

        #region create new user account
        private void createNewAccount_inittal()
        {
            MyMessageBox mm = new MyMessageBox();
            if (mm.ShowAlert("UID2119", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID) == "2")
            {
                createNewAccount = true;

                xtraTabControl1.SelectedTabPage = pageView2;

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
                txtUnitName.SelectedIndex = txtUnit.SelectedIndex == 0 ? 0 : txtUnit.SelectedIndex - 1;
                txtJobType.SelectedIndex = 0;
                txtAuthorityLevel.SelectedIndex = txtAuthLV.SelectedIndex == 0 ? 0 : txtAuthLV.SelectedIndex - 1;
                txtDefaultLanguage.SelectedIndex = 1;

                chkIsActive.Checked = false;
                chkRadiologist.Checked = false;
                chkSupportUser.Checked = false;
                chkAllowOtherstoFinalize.Checked = false;
                chkCanKillSession.Checked = false;

                txtCreatedOn.Text = "";
                txtLastModifiedOn.Text = "";

                #endregion

                txtUserName.Focus();
            }
        }
        private void createNewAccount_afterAdd()
        {
            MyMessageBox mm = new MyMessageBox();

            txtSearch.Text = txtUserName.Text;

            EnableTextControl(false);

            mm.ShowAlert("UID2002", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);

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

            int focusAt = gridView2.FocusedRowHandle;
            Reload();
            gridView2.FocusedRowHandle = focusAt;
            drLayout2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            xtraTabControl1.SelectedTabPage = pageView1;

            createNewAccount = false;

            saveStatus = "";
        }
        private void createNewAccount_afterCancel()
        {
            xtraTabControl1.SelectedTabPage = pageView1;

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