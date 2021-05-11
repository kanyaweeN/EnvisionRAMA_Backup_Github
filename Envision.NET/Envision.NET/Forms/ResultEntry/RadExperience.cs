using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;
using Envision.BusinessLogic;

using DevExpress.XtraEditors;
using System.IO;
using Envision.DataAccess.Select;
using DevExpress.XtraEditors.Controls;
using Envision.Common.Common;


namespace Envision.NET.Forms.ResultEntry
{
    public partial class RadExperience : Envision.NET.Forms.Main.MasterForm
    {
        private int radiologist_id;
        private GBLEnvVariable envV = new GBLEnvVariable();
        public RadExperience()
        {
            InitializeComponent();
        }

        private void RadExperienceN_Load(object sender, EventArgs e)
        {
            txtRadiologist.Text = envV.FirstName+" "+envV.LastName;
            radiologist_id = envV.UserID;
            LoadData(radiologist_id);
            LoadFilterMode(radiologist_id);
            SetHideButtom(true);
            setVisibleSave(true);
            base.CloseWaitDialog();
        }

        #region Ribbon
        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetHideButtom(false);
            setVisibleSave(false);
            setDefaultControl();
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetHideButtom(false);
            setVisibleSave(false);
        }

        private void bbiHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((Envision.NET.Forms.Main.frmMain)this.MdiParent).DisplayHome();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rdoUseTopMenubar.SelectedIndex == 0)
                envV.USED_MENUBAR = "Y";
            else
                envV.USED_MENUBAR = "N";
            ProcessGetGBLRadexperience get = new ProcessGetGBLRadexperience();
            get.GBL_RADEXPERIENCE.RADIOLOGIST_ID = radiologist_id;
            get.Invoke();
            DataTable dtCheck = get.Result.Tables[0];

            if (dtCheck.Rows.Count > 0)
            {
                updateData();
                SetHideButtom(true);
                setVisibleSave(true);
                LoadData(radiologist_id);
            }
            else
            {
                saveData();
                SetHideButtom(true);
                setVisibleSave(true);
                LoadData(radiologist_id);
            }
        }

        private void bbiCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetHideButtom(true);
            setVisibleSave(true);

        }

        #endregion

        private void SetHideButtom(bool flag)
        {
            if (flag)
            {
                //bbiNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
               bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
               bbiHome.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
               bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                bbiCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                //bbiNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiHome.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                bbiCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
        private void setVisibleSave(bool flag)
        {
            layoutControlGroup3.Enabled = !flag;
            ribbonPageGroup5.Visible = !flag;
            ribbonPageGroup6.Visible = !flag;

            ribbonPageGroup1.Visible = false;
            ribbonPageGroup2.Visible = flag;
            ribbonPageGroup3.Visible = flag;
            ribbonPageGroup4.Visible = flag;
            txtRadiologist.Enabled = flag;
            btnChange.Enabled = flag;
        }
        private void LoadFilterMode(int rad_id)
        {
            RISExamresultFilterworklistSelectData radFilter = new RISExamresultFilterworklistSelectData();
            radFilter.RIS_EXAMRESULT_FILTERWORKLIST.EMP_ID = rad_id;
            DataSet ds = radFilter.GetDataByRadId();

            cmbFilterMode.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbFilterMode.Properties.Items;
            colls.BeginUpdate();
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    colls.Add(new Filter_WLLOC_Mode(Convert.ToInt32(dr["FILTER_ID"]), dr["FILTER_NAME"].ToString(), dr["FILTER_DETAIL"].ToString()));
            }
            finally
            {
                colls.EndUpdate();
            }
            cmbFilterMode.SelectedIndex = 0;
        }
        private void LoadData(int rad_id)
        {
            ProcessGetGBLRadexperience rad = new ProcessGetGBLRadexperience();
            rad.GBL_RADEXPERIENCE.RADIOLOGIST_ID = rad_id;
            rad.Invoke();
            DataTable dt = rad.Result.Tables[0];

            if (dt.Rows.Count > 0)
            {
                txtAutoRefreshWLEvery.Value = Convert.ToDecimal(dt.Rows[0]["AUTO_REFRESH_WL_SEC"]);
                rdoDashboardDefaultSearch.SelectedIndex = dt.Rows[0]["DASHBOARD_DEF_SEARCH"].ToString() == "H" ? 0 : 1;
                rdoLoadFinalizeExams.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["LOAD_FINALIZED_EXAMS"].ToString()) ? 0 : 1;
                rdoShowAllExamOption.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["ALL_EXAM_VISIBLE"].ToString()) ? 0 : 1;
                rdoIncludeAllExamInDefSearch.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["LOAD_ALL_EXAM"].ToString()) ? 0 : 1;
                rdoAutoStartPacsImage.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["AUTO_START_PACS_IMG"].ToString()) ? 0 : 1;
                rdoAutoStartOderImage.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["AUTO_START_ORDER_IMG"].ToString()) ? 0 : 1;
                rdoIsAddendum.SelectedIndex = dt.Rows[0]["IS_ADDENDUM"].ToString() == "Y" ? 0 : 1;
                rdoUseTopMenubar.SelectedIndex = dt.Rows[0]["USED_MENUBAR"].ToString() == "Y" ? 0 : 1;
                rdoAutoAddClinicalindication.SelectedIndex = dt.Rows[0]["AUTO_CLINICALINDICATION"].ToString() == "Y" ? 0 : 1;
                rdoAutoAddExam.SelectedIndex = dt.Rows[0]["AUTO_EXAMNAME"].ToString() == "Y" ? 0 : 1;
                //rdoDashboardDataRange.SelectedIndex = Convert.ToInt32(dt.Rows[0]["DEF_DATE_RANGE"].ToString()) == 1 ? 0 : 1;
                rdoDashboardDataRange.EditValue = dt.Rows[0]["DEF_DATE_RANGE"].ToString();
                rdoRememberGridOrder.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["REMEMBER_GRID_ORDER"].ToString()) ? 0 : 1;
                rdoGridDoubleClickTo.SelectedIndex = dt.Rows[0]["GRID_DBL_CLICK_TO"].ToString() == "H" ? 0 : 1;
                rdoReconfirm.SelectedIndex = dt.Rows[0]["RECONFIRM_PASS_ON_SAVE"].ToString() == "Y" ? 0 : 1;
                switch (dt.Rows[0]["FINISH_WRITING_REFER_TO"].ToString())
                {
                    case "N": cbbWhenFinishWritingGoto.SelectedIndex = 0; break;
                    case "P": cbbWhenFinishWritingGoto.SelectedIndex = 1; break;
                    case "W": cbbWhenFinishWritingGoto.SelectedIndex = 2; break;
                    case "H": cbbWhenFinishWritingGoto.SelectedIndex = 3; break;
                    case "E": cbbWhenFinishWritingGoto.SelectedIndex = 4; break;
                    default: cbbWhenFinishWritingGoto.SelectedIndex = 0; break;
                }
                rdoAllowOtherstoFinalize.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["ALLOW_OTHERSTO_FINALIZE"].ToString()) ? 0 : 1;
                txtMinimizeCharacter.Value = Convert.ToDecimal(dt.Rows[0]["MINIMIZE_CHARACTER"]);
                switch (dt.Rows[0]["USED_SIGNATURE"].ToString())
                {
                    case "T": rdoUseSignature.SelectedIndex = 0; break;
                    case "S": rdoUseSignature.SelectedIndex = 1; break;
                    case "B": rdoUseSignature.SelectedIndex = 2; break;
                    default: rdoUseSignature.SelectedIndex = 0;
                        break;
                }
                switch (dt.Rows[0]["WHEN_GROUP_SIGN_USE"].ToString())
                {
                    case "1": rdoWhenGroupSignUseName.SelectedIndex = 0; break;
                    case "L": rdoWhenGroupSignUseName.SelectedIndex = 1; break;
                    case "F": rdoWhenGroupSignUseName.SelectedIndex = 2; break;
                    default: rdoWhenGroupSignUseName.SelectedIndex = 0;
                        break;
                }
                txtSignatureText.RTFText = dt.Rows[0]["SIGNATURE_RTF"].ToString();
                try
                {
                    if (((byte[])dt.Rows[0]["SIGNATURE_SCAN"]).Length > 0)
                        picScannedSignature.Image = ConvertByteToImage(dt.Rows[0]["SIGNATURE_SCAN"]);
                }
                catch
                {
                    picScannedSignature.Image = null;
                }
                spePercent.Value = Convert.ToDecimal(dt.Rows[0]["ZOOM_SETTING"].ToString());
                rdoAutoOpenPACSWhenMerge.SelectedIndex = dt.Rows[0]["OPEN_PACS_WHEN_MERGE"].ToString() == "Y" ? 0 : 1;
            }
            else
            {
                setDefaultControl();
            }
        }
        private Image ConvertByteToImage(object byteArrayIn)
        {
            ImageConverter imcon = new ImageConverter();
            return (Image)imcon.ConvertFrom(byteArrayIn);
        }
        private byte[] ConvertImageToByte(System.Drawing.Image imageIn)
        {
            ImageConverter imcon = new ImageConverter();
            return (byte[])imcon.ConvertTo(imageIn, typeof(byte[]));
        }
        private void setDefaultControl()
        {
            txtAutoRefreshWLEvery.Value = 120;
            rdoDashboardDefaultSearch.SelectedIndex = 0;
            rdoLoadFinalizeExams.SelectedIndex = 1;
            rdoShowAllExamOption.SelectedIndex = 1;
            rdoIncludeAllExamInDefSearch.SelectedIndex = 1;
            rdoAutoStartPacsImage.SelectedIndex = 0;
            rdoAutoStartOderImage.SelectedIndex = 1;
            rdoUseTopMenubar.SelectedIndex = 1;
            rdoAutoAddClinicalindication.SelectedIndex = 1;
            rdoAutoOpenPACSWhenMerge.SelectedIndex = 0;
            rdoAutoAddExam.SelectedIndex = 1;
            rdoDashboardDataRange.SelectedIndex = 1;
            //txtDashboardDataRange.SelectedIndex = 1;
            rdoRememberGridOrder.SelectedIndex = 1;
            rdoGridDoubleClickTo.SelectedIndex = 1;
            cbbWhenFinishWritingGoto.SelectedIndex = 0;
            rdoAllowOtherstoFinalize.SelectedIndex = 1;
            txtMinimizeCharacter.Value = 8;
            rdoUseSignature.SelectedIndex = 0;
            rdoWhenGroupSignUseName.SelectedIndex = 0;
            rdoReconfirm.SelectedIndex = 0;
            picScannedSignature.Image = null;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ProcessGetHREmp hr = new ProcessGetHREmp();
            hr.Invoke();

            LookUpSelect lvS = new LookUpSelect();

            //Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            //lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(lv_ValueUpdated);
            //lv.AddColumn("HN", "HN", true, true);
            //lv.AddColumn("REG_ID", "ID", false, true);
            //lv.AddColumn("FNAME", "First name", true, true);
            //lv.AddColumn("LNAME", "Last Name", true, true);
            //lv.Text = "HN Search";

            //lv.Data = hr.Result.Tables[0];
            //lv.Size = new Size(600, 400);
            //lv.ShowBox();
        }
        //private void lv_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        //{
        //    string[] retValue = e.NewValue.Split(new Char[] { '^' });
        //    string hn = retValue[0].ToString();
        //}
        private void saveData()
        {
            ProcessAddGBLRadexperience add = new ProcessAddGBLRadexperience();
            add.GBL_RADEXPERIENCE.AUTO_REFRESH_WL_SEC = Convert.ToByte(txtAutoRefreshWLEvery.Value);
            add.GBL_RADEXPERIENCE.DASHBOARD_DEF_SEARCH = rdoDashboardDefaultSearch.SelectedIndex == 0 ? 'H' : 'D';
            add.GBL_RADEXPERIENCE.LOAD_FINALIZED_EXAMS = rdoLoadFinalizeExams.SelectedIndex == 0 ? true : false;
            add.GBL_RADEXPERIENCE.ALL_EXAM_VISIBLE = rdoShowAllExamOption.SelectedIndex == 0 ? true : false;
            add.GBL_RADEXPERIENCE.LOAD_ALL_EXAM = rdoIncludeAllExamInDefSearch.SelectedIndex == 0 ? true : false;
            add.GBL_RADEXPERIENCE.AUTO_START_PACS_IMG = rdoAutoStartPacsImage.SelectedIndex == 0 ? true : false;
            add.GBL_RADEXPERIENCE.AUTO_START_ORDER_IMG = rdoAutoStartOderImage.SelectedIndex == 0 ? true : false;
            add.GBL_RADEXPERIENCE.USED_MENUBAR = rdoUseTopMenubar.SelectedIndex == 0 ? 'Y' : 'N';
            add.GBL_RADEXPERIENCE.AUTO_EXAMNAME = rdoAutoAddExam.SelectedIndex == 0 ? "Y" : "N";
            add.GBL_RADEXPERIENCE.AUTO_CLINICALINDICATION = rdoAutoAddClinicalindication.SelectedIndex == 0 ? "Y" : "N";
            add.GBL_RADEXPERIENCE.RECONFIRM_PASS_ON_SAVE = rdoReconfirm.SelectedIndex == 0 ? 'Y' : 'N';
            add.GBL_RADEXPERIENCE.IS_ADDENDUM = rdoIsAddendum.SelectedIndex == 0 ? "Y" : "N";
            //add.GBL_RADEXPERIENCE.DEF_DATE_RANGE = rdoDashboardDataRange.SelectedIndex == 0 ? '1' : '7';
            add.GBL_RADEXPERIENCE.DEF_DATE_RANGE = rdoDashboardDataRange.EditValue.ToString();
            add.GBL_RADEXPERIENCE.REMEMBER_GRID_ORDER = rdoRememberGridOrder.SelectedIndex == 0 ? true : false;
            add.GBL_RADEXPERIENCE.GRID_DBL_CLICK_TO = rdoGridDoubleClickTo.SelectedIndex == 0 ? 'H' : 'R';
            switch (cbbWhenFinishWritingGoto.SelectedIndex)
            {
                case 0: add.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'N'; break;
                case 1: add.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'P';break;
                case 2: add.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'W';break;
                case 3: add.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'H';break;
                case 4: add.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'E'; break;
                default : add.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'N';break;
            }
            add.GBL_RADEXPERIENCE.ALLOW_OTHERSTO_FINALIZE = rdoAllowOtherstoFinalize.SelectedIndex == 0 ? true : false;
            add.GBL_RADEXPERIENCE.MINIMIZE_CHARACTER = Convert.ToInt32(txtMinimizeCharacter.Value);
            switch (rdoUseSignature.SelectedIndex)
            {
                case 0: add.GBL_RADEXPERIENCE.USED_SIGNATURE = 'T'; break;
                case 1: add.GBL_RADEXPERIENCE.USED_SIGNATURE = 'S'; break;
                case 2: add.GBL_RADEXPERIENCE.USED_SIGNATURE = 'B'; break;
                default: add.GBL_RADEXPERIENCE.USED_SIGNATURE = 'T';break;
            }
            switch (rdoWhenGroupSignUseName.SelectedIndex)
            {
                case 0: add.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = '1'; break;
                case 1: add.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = 'L'; break;
                case 2: add.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = 'F'; break;
                default: add.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = '1';break;
            }
            add.GBL_RADEXPERIENCE.SIGNATURE_RTF = txtSignatureText.RTFText;
            add.GBL_RADEXPERIENCE.SIGNATURE_HTML = txtSignatureText.GetHtmlText();
            add.GBL_RADEXPERIENCE.SIGNATURE_TEXT = txtSignatureText.PlainText;
            byte[] ScannedSignature = ConvertImageToByte(picScannedSignature.Image);
            add.GBL_RADEXPERIENCE.Picture_Forsave = ScannedSignature;
        }
        private void updateData()
        {
            ProcessUpdateGBLRadexperience update = new ProcessUpdateGBLRadexperience();
            update.GBL_RADEXPERIENCE.RADIOLOGIST_ID = radiologist_id;
            update.GBL_RADEXPERIENCE.AUTO_REFRESH_WL_SEC = Convert.ToByte(txtAutoRefreshWLEvery.Value);
            update.GBL_RADEXPERIENCE.DASHBOARD_DEF_SEARCH = rdoDashboardDefaultSearch.SelectedIndex == 0 ? 'H' : 'D';
            update.GBL_RADEXPERIENCE.LOAD_FINALIZED_EXAMS = rdoLoadFinalizeExams.SelectedIndex == 0 ? true : false;
            update.GBL_RADEXPERIENCE.ALL_EXAM_VISIBLE = rdoShowAllExamOption.SelectedIndex == 0 ? true : false;
            update.GBL_RADEXPERIENCE.LOAD_ALL_EXAM = rdoIncludeAllExamInDefSearch.SelectedIndex == 0 ? true : false;
            update.GBL_RADEXPERIENCE.AUTO_START_PACS_IMG = rdoAutoStartPacsImage.SelectedIndex == 0 ? true : false;
            update.GBL_RADEXPERIENCE.AUTO_START_ORDER_IMG = rdoAutoStartOderImage.SelectedIndex == 0 ? true : false;
            update.GBL_RADEXPERIENCE.USED_MENUBAR = rdoUseTopMenubar.SelectedIndex == 0 ? 'Y' : 'N';
            update.GBL_RADEXPERIENCE.AUTO_EXAMNAME = rdoAutoAddExam.SelectedIndex == 0 ? "Y" : "N";
            update.GBL_RADEXPERIENCE.AUTO_CLINICALINDICATION = rdoAutoAddClinicalindication.SelectedIndex == 0 ? "Y" : "N";
            update.GBL_RADEXPERIENCE.IS_ADDENDUM = rdoIsAddendum.SelectedIndex == 0 ? "Y" : "N";
            update.GBL_RADEXPERIENCE.RECONFIRM_PASS_ON_SAVE = rdoReconfirm.SelectedIndex == 0 ? 'Y' : 'N';
            //update.GBL_RADEXPERIENCE.DEF_DATE_RANGE = rdoDashboardDataRange.SelectedIndex == 0 ? '1' : '7';
            update.GBL_RADEXPERIENCE.DEF_DATE_RANGE = rdoDashboardDataRange.EditValue.ToString();
            update.GBL_RADEXPERIENCE.REMEMBER_GRID_ORDER = rdoRememberGridOrder.SelectedIndex == 0 ? true : false;
            update.GBL_RADEXPERIENCE.GRID_DBL_CLICK_TO = rdoGridDoubleClickTo.SelectedIndex == 0 ? 'H' : 'R';
            switch (cbbWhenFinishWritingGoto.SelectedIndex)
            {
                case 0: update.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'N'; break;
                case 1: update.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'P'; break;
                case 2: update.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'W'; break;
                case 3: update.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'H'; break;
                case 4: update.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'E'; break;
                default: update.GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO = 'N'; break;
            }
            update.GBL_RADEXPERIENCE.ALLOW_OTHERSTO_FINALIZE = rdoAllowOtherstoFinalize.SelectedIndex == 0 ? true : false;
            update.GBL_RADEXPERIENCE.MINIMIZE_CHARACTER = Convert.ToInt32(txtMinimizeCharacter.Value);
            switch (rdoUseSignature.SelectedIndex)
            {
                case 0: update.GBL_RADEXPERIENCE.USED_SIGNATURE = 'T'; break;
                case 1: update.GBL_RADEXPERIENCE.USED_SIGNATURE = 'S'; break;
                case 2: update.GBL_RADEXPERIENCE.USED_SIGNATURE = 'B'; break;
                default: update.GBL_RADEXPERIENCE.USED_SIGNATURE = 'T'; break;
            }
            switch (rdoWhenGroupSignUseName.SelectedIndex)
            {
                case 0: update.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = '1'; break;
                case 1: update.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = 'L'; break;
                case 2: update.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = 'F'; break;
                default: update.GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE = '1'; break;
            }
            update.GBL_RADEXPERIENCE.SIGNATURE_RTF = txtSignatureText.RTFText;
            update.GBL_RADEXPERIENCE.SIGNATURE_HTML = txtSignatureText.GetHtmlText();
            update.GBL_RADEXPERIENCE.SIGNATURE_TEXT = txtSignatureText.PlainText;
            byte[] ScannedSignature = ConvertImageToByte(picScannedSignature.Image);
            update.GBL_RADEXPERIENCE.Picture_Forsave = ScannedSignature;
            update.GBL_RADEXPERIENCE.ZOOM_SETTING = Convert.ToInt32(spePercent.Value);
            update.GBL_RADEXPERIENCE.OPEN_PACS_WHEN_MERGE = rdoAutoOpenPACSWhenMerge.SelectedIndex == 0 ? "Y" : "N";
            update.Invoke();
            envV.ReconfirmPassword = update.GBL_RADEXPERIENCE.RECONFIRM_PASS_ON_SAVE.ToString();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Image image = null;
            txtScannedSignature.Text = "";

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open Scanned Signature Image File";
            fDialog.Filter = "Image Files|*.jpg|*.jpeg|*.bmp";
            fDialog.InitialDirectory = @"C:\";
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(fDialog.FileName);
                if (file.Exists)
                {
                    image = Image.FromFile(fDialog.FileName);
                    txtScannedSignature.Text = file.Name;
                }
                else
                {

                }
            }

            if (true)//ConvertImageToByte(image).Length < 1000)
            {
                if (image != null)
                    picScannedSignature.Image = image;
                else
                    picScannedSignature.Image = null;
            }
            else
            {
                picScannedSignature.Image = null;
                txtScannedSignature.Text = "";
                MessageBox.Show("Your picture size more than our support space. Please select new picture."
                                , "Overload Picture Size", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

        }

        private void txtSizeFont_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void picScannedSignature_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFilterMode_Click(object sender, EventArgs e)
        {
            frmPopupRadFilterMode frm = new frmPopupRadFilterMode(radiologist_id);
            frm.ShowDialog();

            LoadFilterMode(radiologist_id);
        }
    }
}