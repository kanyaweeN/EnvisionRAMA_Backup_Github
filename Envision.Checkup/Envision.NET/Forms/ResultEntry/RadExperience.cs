using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;

namespace RIS.Forms.ResultEntry
{
    public partial class RadExperience : Form
    {
        private int radiologist_id;
        private DataTable getDataTable;
        private UUL.ControlFrame.Controls.TabControl tabControl;
        private bool hasData;

        public RadExperience(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();

            tabControl = clsCtl;

            #region can click btnChange or not?
            RIS.BusinessLogic.ProcessGetHREmp gh = new RIS.BusinessLogic.ProcessGetHREmp();
            gh.HREmp.MODE = "EmpId";
            gh.HREmp.EMP_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
            gh.Invoke();
            if (gh.Result.Tables[0].Rows.Count > 0)
            {
                if (gh.Result.Tables[0].Rows[0]["SUPPORT_USER"].ToString() == "Y")
                {
                    btnChange.Enabled = true;
                    btnChange.Visible = true;
                }
                else
                {
                    btnChange.Enabled = false;
                    btnChange.Visible = false;
                }
            }
            else
            {
                btnChange.Enabled = false;
                btnChange.Visible = false;
            }
            #endregion
        }

        private void LoadData()
        {
            RIS.BusinessLogic.ProcessGetGBLRadexperience getGBLRadexperience
                = new RIS.BusinessLogic.ProcessGetGBLRadexperience();
            getGBLRadexperience.GBLRadexperience.RADIOLOGIST_ID = radiologist_id;
            getGBLRadexperience.Invoke();

            getDataTable = getGBLRadexperience.Result.Tables[0];

            if (getDataTable.Rows.Count > 0)
            {
                hasData = true;
                FillData();
            }
            else
            {
                hasData = false;
                EmptyData();
            }
        }

        private void FillData()
        {
            DataRow row = getDataTable.Rows[0];
            //FirstData(row);

            try
            {
                //txtAutoRefreshWLEvery.Value = Convert.ToDecimal(row["AUTO_REFRESH_WL_SEC"]);
                //rdoDashboardDefaultSearch.SelectedIndex = Convert.ToInt32(row["DASHBOARD_DEF_SEARCH"]);
                //rdoLoadFinalizeExams.SelectedIndex = Convert.ToInt32(row["LOAD_FINALIZED_EXAMS"]);
                //rdoShowAllExamOption.SelectedIndex = Convert.ToInt32(row["ALL_EXAM_VISIBLE"]);
                //rdoIncludeAllExamInDefSearch.SelectedIndex = Convert.ToInt32(row["LOAD_ALL_EXAM"]);
                //rdoAutoStartPacsImage.SelectedIndex = Convert.ToInt32(row["AUTO_START_PACS_IMG"]);
                //rdoAutoStartOderImage.SelectedIndex = Convert.ToInt32(row["AUTO_START_ORDER_IMG"]);

                //rdoDashboardDataRange.SelectedIndex = Convert.ToInt32(row["DEF_DATE_RANGE"]);
                //rdoRememberGridOrder.SelectedIndex = Convert.ToInt32(row["REMEMBER_GRID_ORDER"]);
                //rdoGridDoubleClickTo.SelectedIndex = Convert.ToInt32(row["GRID_DBL_CLICK_TO"]);
                //cbbWhenFinishWritingGoto.SelectedIndex = Convert.ToInt32(row["FINISH_WRITING_REFER_TO"]);
                //rdoAllowOtherstoFinalize.SelectedIndex = Convert.ToInt32(row["ALLOW_OTHERSTO_FINALIZE"]);
                //cbbFontType.Text = row["FONT_FACE"].ToString();
                //cbbFontSize.Text = row["FONT_SIZE"].ToString();
                //rdoUseSignature.SelectedIndex = Convert.ToInt32(row["USED_SIGNATURE"]);
                //rdoWhenGroupSignUseName.SelectedIndex = Convert.ToInt32(row["WHEN_GROUP_SIGN_USE"]);

                ////txtSignatureText.Clear();
                ////txtSignatureText.AddHTML(row["SIGNATURE_TEXT"].ToString());
                //txtSignatureText.RTFText = row["SIGNATURE_RTF"].ToString();
                //txtMinimizeCharacter.Value = Convert.ToInt32(row["MINIMIZE_CHARACTER"]);

                txtAutoRefreshWLEvery.Value = Convert.ToDecimal(row["AUTO_REFRESH_WL_SEC"]);
                rdoDashboardDefaultSearch.SelectedIndex = row["DASHBOARD_DEF_SEARCH"].ToString() == "H" ? 0 : 1;
                rdoLoadFinalizeExams.SelectedIndex = Convert.ToBoolean(row["LOAD_FINALIZED_EXAMS"]) ? 0 : 1;
                rdoShowAllExamOption.SelectedIndex = Convert.ToBoolean(row["ALL_EXAM_VISIBLE"]) ? 0 : 1;
                rdoIncludeAllExamInDefSearch.SelectedIndex = Convert.ToBoolean(row["LOAD_ALL_EXAM"]) ? 0 : 1;
                rdoAutoStartPacsImage.SelectedIndex = Convert.ToBoolean(row["AUTO_START_PACS_IMG"]) ? 0 : 1;
                rdoAutoStartOderImage.SelectedIndex = Convert.ToBoolean(row["AUTO_START_ORDER_IMG"]) ? 0 : 1;

                rdoDashboardDataRange.SelectedIndex = row["DEF_DATE_RANGE"].ToString() == "1" ? 0 : 1;
                rdoRememberGridOrder.SelectedIndex = Convert.ToBoolean(row["REMEMBER_GRID_ORDER"]) ? 0 : 1;
                rdoGridDoubleClickTo.SelectedIndex = row["GRID_DBL_CLICK_TO"].ToString() == "H" ? 0 : 1;
                int selIndex;
                switch (row["FINISH_WRITING_REFER_TO"].ToString())
                {
                    case "N": selIndex = 0; break;
                    case "P": selIndex = 1; break;
                    case "W": selIndex = 2; break;
                    case "H": selIndex = 3; break;
                    case "E": selIndex = 4; break;
                    default: throw new Exception();
                } cbbWhenFinishWritingGoto.SelectedIndex = selIndex;
                rdoAllowOtherstoFinalize.SelectedIndex = Convert.ToBoolean(row["ALLOW_OTHERSTO_FINALIZE"]) ? 0 : 1;
                cbbFontType.Text = row["FONT_FACE"].ToString();
                cbbFontSize.Text = row["FONT_SIZE"].ToString();
                switch (row["USED_SIGNATURE"].ToString())
                {
                    case "T": selIndex = 0; break;
                    case "S": selIndex = 1; break;
                    case "B": selIndex = 2; break;
                    default: throw new Exception();
                } rdoUseSignature.SelectedIndex = selIndex;
                switch (row["WHEN_GROUP_SIGN_USE"].ToString())
                {
                    case "1": selIndex = 0; break;
                    case "L": selIndex = 1; break;
                    case "F": selIndex = 2; break;
                    default: throw new Exception();
                } rdoWhenGroupSignUseName.SelectedIndex = selIndex;

                //txtSignatureText.Clear();
                //txtSignatureText.AddHTML(row["SIGNATURE_TEXT"].ToString());

                txtSignatureText.Rtf = row["SIGNATURE_RTF"].ToString();
                txtMinimizeCharacter.Value = Convert.ToInt32(row["MINIMIZE_CHARACTER"]);

                txtScannedSignature.Text = "";

                try
                {
                    if (((byte[])row["SIGNATURE_SCAN"]).Length > 0)
                        picScannedSignature.Image = ConvertByteToImage(row["SIGNATURE_SCAN"]);
                }
                catch
                {
                    picScannedSignature.Image = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FirstData(DataRow dr)
        {
            //dr["DASHBOARD_DEF_SEARCH"] = dr["DASHBOARD_DEF_SEARCH"].ToString() == "H" ? 0 : 1;
            //dr["LOAD_FINALIZED_EXAMS"] = Convert.ToBoolean(dr["LOAD_FINALIZED_EXAMS"]) ? 0 : 1;
            //dr["ALL_EXAM_VISIBLE"] = Convert.ToBoolean(dr["ALL_EXAM_VISIBLE"]) ? 0 : 1;
            //dr["LOAD_ALL_EXAM"] = Convert.ToBoolean(dr["LOAD_ALL_EXAM"]) ? 0 : 1;
            //dr["AUTO_START_PACS_IMG"] = Convert.ToBoolean(dr["AUTO_START_PACS_IMG"]) ? 0 : 1;
            //dr["AUTO_START_ORDER_IMG"] = Convert.ToBoolean(dr["AUTO_START_ORDER_IMG"]) ? 0 : 1;

            //dr["DEF_DATE_RANGE"] = dr["DEF_DATE_RANGE"].ToString() == "1" ? 0 : 1;
            //dr["REMEMBER_GRID_ORDER"] = Convert.ToBoolean(dr["REMEMBER_GRID_ORDER"]) ? 0 : 1;
            //dr["GRID_DBL_CLICK_TO"] = dr["GRID_DBL_CLICK_TO"].ToString() == "H" ? 0 : 1;
            //int selIndex;
            //switch (dr["FINISH_WRITING_REFER_TO"].ToString()) {
            //    case "N": selIndex = 0; break;
            //    case "P": selIndex = 1; break;
            //    case "W": selIndex = 2; break;
            //    case "H": selIndex = 3; break;
            //    case "E": selIndex = 4; break;
            //    default: throw new Exception();
            //} dr["FINISH_WRITING_REFER_TO"] = selIndex;
            //dr["ALLOW_OTHERSTO_FINALIZE"] = Convert.ToBoolean(dr["ALLOW_OTHERSTO_FINALIZE"]) ? 0 : 1;

            //switch (dr["USED_SIGNATURE"].ToString()) {
            //    case "T": selIndex = 0; break;
            //    case "S": selIndex = 1; break;
            //    case "B": selIndex = 2; break;
            //    default: throw new Exception();
            //} dr["USED_SIGNATURE"] = selIndex;
            //switch (dr["WHEN_GROUP_SIGN_USE"].ToString())
            //{
            //    case "1": selIndex = 0; break;
            //    case "L": selIndex = 1; break;
            //    case "F": selIndex = 2; break;
            //    default: throw new Exception();
            //} dr["WHEN_GROUP_SIGN_USE"] = selIndex;
        }

        private void EmptyData()
        {
            try
            {
                txtAutoRefreshWLEvery.Value = 120;
                rdoDashboardDefaultSearch.SelectedIndex = 0;
                rdoLoadFinalizeExams.SelectedIndex = 1;
                rdoShowAllExamOption.SelectedIndex = 1;
                rdoIncludeAllExamInDefSearch.SelectedIndex = 1;
                rdoAutoStartPacsImage.SelectedIndex = 1;
                rdoAutoStartOderImage.SelectedIndex = 1;

                rdoDashboardDataRange.SelectedIndex = 0;
                rdoRememberGridOrder.SelectedIndex = 1;
                rdoGridDoubleClickTo.SelectedIndex = 1;
                cbbWhenFinishWritingGoto.SelectedIndex = 0;
                rdoAllowOtherstoFinalize.SelectedIndex = 0;
                cbbFontType.Text = "Tahoma";
                cbbFontSize.Text = "14";
                rdoUseSignature.SelectedIndex = 0;
                rdoWhenGroupSignUseName.SelectedIndex = 0;

                //txtSignatureText.Clear();
                txtSignatureText.Text = "";
                txtScannedSignature.Text = "";
                picScannedSignature.Image = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EnableControl(bool flag)
        {
            btnChange.Enabled = !flag;

            txtAutoRefreshWLEvery.Enabled = flag;
            rdoDashboardDefaultSearch.Enabled = flag;
            rdoLoadFinalizeExams.Enabled = flag;
            rdoShowAllExamOption.Enabled = flag;
            rdoIncludeAllExamInDefSearch.Enabled = flag;
            rdoAutoStartPacsImage.Enabled = flag;
            rdoAutoStartOderImage.Enabled = flag;

            rdoDashboardDataRange.Enabled = flag;
            rdoRememberGridOrder.Enabled = flag;
            rdoGridDoubleClickTo.Enabled = flag;
            cbbWhenFinishWritingGoto.Enabled = flag;
            rdoAllowOtherstoFinalize.Enabled = flag;
            //cbbFontType.Enabled = flag;
            cbbFontSize.Enabled = flag;
            rdoUseSignature.Enabled = flag;
            rdoWhenGroupSignUseName.Enabled = flag;

            txtSignatureText.Enabled = flag;
            //txtScannedSignature.Text = "";
            btnBrowse.Enabled = flag;
            //picScannedSignature.Image = null;
            txtMinimizeCharacter.Enabled = flag;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnChange_ValueUpdated);

            string qry = @"
                            select emp_id,emp_uid,user_name
                                ,isnull(salutation,'')+' '+isnull(fname,'')+' '+isnull(mname,'')+' '+isnull(lname,'') as fullname
                            from hr_emp
                            where 
                                is_radiologist = 'Y' and is_active = 'Y'
                                and 
                                (emp_id like '%%' 
                                or emp_uid like '%%'
                                or user_name like '%%'
                                or salutation like '%%'
                                or fname like '%%'
                                or mname like '%%'
                                or lname like '%%')
                          ";

            string fields = "ID, Code, Username, Radiologist name";
            string con = "";
            lv.getData(qry, fields, con, "Radiologist List");
            lv.Show();
        }

        private void btnChange_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            
            txtRadiologist.Text = retValue[3];
            radiologist_id = Convert.ToInt32(retValue[0]);

            LoadData();

            btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                btnEdit.Text = "Save";
                EnableControl(true);
                btnCancel.Visible = true;
            }
            else
            {  
                RIS.Forms.GBLMessage.MyMessageBox msBox = new RIS.Forms.GBLMessage.MyMessageBox();

                if (txtAutoRefreshWLEvery.Value > 32767)
                    txtAutoRefreshWLEvery.Value = 32767;

                if (txtAutoRefreshWLEvery.Value < 0)
                    txtAutoRefreshWLEvery.Value = 0;

                if (msBox.ShowAlert("UID1020", 2) == "2")
                {
                    if (hasData)
                    {
                        #region Update

                        RIS.BusinessLogic.ProcessUpdateGBLRadexperience updateGBLRadexperience
                           = new RIS.BusinessLogic.ProcessUpdateGBLRadexperience();
                        try
                        {
                            updateGBLRadexperience.GBLRadexperience.RADIOLOGIST_ID
                                = radiologist_id;

                            updateGBLRadexperience.GBLRadexperience.AUTO_REFRESH_WL_SEC
                                = Convert.ToInt16(txtAutoRefreshWLEvery.Value);

                            updateGBLRadexperience.GBLRadexperience.DASHBOARD_DEF_SEARCH
                                = rdoDashboardDefaultSearch.SelectedIndex == 0 ? "H" : "D";

                            updateGBLRadexperience.GBLRadexperience.LOAD_FINALIZED_EXAMS
                                = rdoLoadFinalizeExams.SelectedIndex == 0 ? true : false;

                            updateGBLRadexperience.GBLRadexperience.ALL_EXAM_VISIBLE
                                = rdoShowAllExamOption.SelectedIndex == 0 ? true : false;

                            updateGBLRadexperience.GBLRadexperience.LOAD_ALL_EXAM
                                = rdoIncludeAllExamInDefSearch.SelectedIndex == 0 ? true : false;

                            updateGBLRadexperience.GBLRadexperience.AUTO_START_ORDER_IMG
                                = rdoAutoStartOderImage.SelectedIndex == 0 ? true : false;

                            updateGBLRadexperience.GBLRadexperience.AUTO_START_PACS_IMG
                                = rdoAutoStartPacsImage.SelectedIndex == 0 ? true : false;

                            updateGBLRadexperience.GBLRadexperience.DEF_DATE_RANGE
                                = rdoDashboardDataRange.SelectedIndex == 0 ? "1" : "7";

                            updateGBLRadexperience.GBLRadexperience.REMEMBER_GRID_ORDER
                                = rdoRememberGridOrder.SelectedIndex == 0 ? true : false;

                            updateGBLRadexperience.GBLRadexperience.GRID_DBL_CLICK_TO
                                = rdoGridDoubleClickTo.SelectedIndex == 0 ? "H" : "R";

                            string WhenFinishWritingGoto = "";
                            switch (cbbWhenFinishWritingGoto.SelectedIndex)
                            {
                                case 0: WhenFinishWritingGoto = "N"; break;
                                case 1: WhenFinishWritingGoto = "P"; break;
                                case 2: WhenFinishWritingGoto = "W"; break;
                                case 3: WhenFinishWritingGoto = "H"; break;
                                case 4: WhenFinishWritingGoto = "E"; break;
                                default: WhenFinishWritingGoto = ""; break;
                            }
                            updateGBLRadexperience.GBLRadexperience.FINISH_WRITING_REFER_TO = WhenFinishWritingGoto;

                            updateGBLRadexperience.GBLRadexperience.ALLOW_OTHERSTO_FINALIZE
                                = rdoAllowOtherstoFinalize.SelectedIndex == 0 ? true : false;

                            updateGBLRadexperience.GBLRadexperience.FONT_FACE = cbbFontType.Text;

                            updateGBLRadexperience.GBLRadexperience.FONT_SIZE = Convert.ToByte(cbbFontSize.Text);

                            string UseSignature = "";
                            switch (rdoUseSignature.SelectedIndex)
                            {
                                case 0: UseSignature = "T"; break;
                                case 1: UseSignature = "S"; break;
                                case 2: UseSignature = "B"; break;
                                default: UseSignature = ""; break;
                            }
                            updateGBLRadexperience.GBLRadexperience.USED_SIGNATURE = UseSignature;

                            string WhenGroupSignUseName = "";
                            switch (rdoWhenGroupSignUseName.SelectedIndex)
                            {
                                case 0: WhenGroupSignUseName = "1"; break;
                                case 1: WhenGroupSignUseName = "L"; break;
                                case 2: WhenGroupSignUseName = "F"; break;
                                default: WhenGroupSignUseName = ""; break;
                            }
                            updateGBLRadexperience.GBLRadexperience.WHEN_GROUP_SIGN_USE = WhenGroupSignUseName;

                            string TEXT = txtSignatureText.Text;
                            updateGBLRadexperience.GBLRadexperience.SIGNATURE_TEXT = TEXT;

                            string RTF = txtSignatureText.Rtf;
                            updateGBLRadexperience.GBLRadexperience.SIGNATURE_RTF = RTF;

                            string HTML = txtSignatureText.Text;
                            updateGBLRadexperience.GBLRadexperience.SIGNATURE_HTML = HTML;

                            byte[] ScannedSignature = ConvertImageToByte(picScannedSignature.Image);
                            updateGBLRadexperience.GBLRadexperience.SIGNATURE_SCAN
                                = ScannedSignature;

                            updateGBLRadexperience.GBLRadexperience.ORG_ID
                                = new RIS.Common.Common.GBLEnvVariable().OrgID;

                            updateGBLRadexperience.GBLRadexperience.LAST_MODIFIED_BY
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            updateGBLRadexperience.GBLRadexperience.MINIMIZE_CHARACTER
                                = Convert.ToInt32(txtMinimizeCharacter.Value);

                            updateGBLRadexperience.Invoke();

                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        #endregion Update
                    }
                    else
                    {
                        #region Add

                        RIS.BusinessLogic.ProcessAddGBLRadexperience addGBLRadexperience
                               = new RIS.BusinessLogic.ProcessAddGBLRadexperience();
                        try
                        {
                            addGBLRadexperience.GBLRadexperience.RADIOLOGIST_ID
                                = radiologist_id;

                            addGBLRadexperience.GBLRadexperience.AUTO_REFRESH_WL_SEC
                                = Convert.ToInt16(txtAutoRefreshWLEvery.Value);

                            addGBLRadexperience.GBLRadexperience.DASHBOARD_DEF_SEARCH
                                = rdoDashboardDefaultSearch.SelectedIndex == 0 ? "H" : "D";

                            addGBLRadexperience.GBLRadexperience.LOAD_FINALIZED_EXAMS
                                = rdoLoadFinalizeExams.SelectedIndex == 0 ? true : false;

                            addGBLRadexperience.GBLRadexperience.ALL_EXAM_VISIBLE
                                = rdoShowAllExamOption.SelectedIndex == 0 ? true : false;

                            addGBLRadexperience.GBLRadexperience.LOAD_ALL_EXAM
                                = rdoIncludeAllExamInDefSearch.SelectedIndex == 0 ? true : false;

                            addGBLRadexperience.GBLRadexperience.AUTO_START_ORDER_IMG
                                = rdoAutoStartOderImage.SelectedIndex == 0 ? true : false;

                            addGBLRadexperience.GBLRadexperience.AUTO_START_PACS_IMG
                                = rdoAutoStartPacsImage.SelectedIndex == 0 ? true : false;

                            addGBLRadexperience.GBLRadexperience.DEF_DATE_RANGE
                                = rdoDashboardDataRange.SelectedIndex == 0 ? "1" : "7";

                            addGBLRadexperience.GBLRadexperience.REMEMBER_GRID_ORDER
                                = rdoRememberGridOrder.SelectedIndex == 0 ? true : false;

                            addGBLRadexperience.GBLRadexperience.GRID_DBL_CLICK_TO
                                = rdoGridDoubleClickTo.SelectedIndex == 0 ? "R" : "W";

                            string WhenFinishWritingGoto = "";
                            switch (cbbWhenFinishWritingGoto.SelectedIndex)
                            {
                                case 0: WhenFinishWritingGoto = "N"; break;
                                case 1: WhenFinishWritingGoto = "P"; break;
                                case 2: WhenFinishWritingGoto = "W"; break;
                                case 3: WhenFinishWritingGoto = "H"; break;
                                case 4: WhenFinishWritingGoto = "E"; break;
                                default: WhenFinishWritingGoto = ""; break;
                            }
                            addGBLRadexperience.GBLRadexperience.FINISH_WRITING_REFER_TO = WhenFinishWritingGoto;

                            addGBLRadexperience.GBLRadexperience.ALLOW_OTHERSTO_FINALIZE
                                = rdoAllowOtherstoFinalize.SelectedIndex == 0 ? true : false;

                            addGBLRadexperience.GBLRadexperience.FONT_FACE = cbbFontType.Text;

                            addGBLRadexperience.GBLRadexperience.FONT_SIZE = Convert.ToByte(cbbFontSize.Text);

                            string UseSignature = "";
                            switch (rdoUseSignature.SelectedIndex)
                            {
                                case 0: UseSignature = "T"; break;
                                case 1: UseSignature = "S"; break;
                                case 2: UseSignature = "B"; break;
                                default: UseSignature = ""; break;
                            }
                            addGBLRadexperience.GBLRadexperience.USED_SIGNATURE = UseSignature;

                            string WhenGroupSignUseName = "";
                            switch (rdoWhenGroupSignUseName.SelectedIndex)
                            {
                                case 0: WhenGroupSignUseName = "1"; break;
                                case 1: WhenGroupSignUseName = "L"; break;
                                case 2: WhenGroupSignUseName = "F"; break;
                                default: WhenGroupSignUseName = ""; break;
                            }
                            addGBLRadexperience.GBLRadexperience.WHEN_GROUP_SIGN_USE = WhenGroupSignUseName;

                            string TEXT = txtSignatureText.Text;
                            addGBLRadexperience.GBLRadexperience.SIGNATURE_TEXT = TEXT;

                            string RTF = txtSignatureText.Rtf;
                            addGBLRadexperience.GBLRadexperience.SIGNATURE_RTF = RTF;

                            string HTML = txtSignatureText.Text;
                            addGBLRadexperience.GBLRadexperience.SIGNATURE_HTML = HTML;

                            byte[] ScannedSignature = ConvertImageToByte(picScannedSignature.Image);
                            addGBLRadexperience.GBLRadexperience.SIGNATURE_SCAN
                                = ScannedSignature;

                            addGBLRadexperience.GBLRadexperience.ORG_ID
                                = new RIS.Common.Common.GBLEnvVariable().OrgID;

                            addGBLRadexperience.GBLRadexperience.CREATED_BY
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            addGBLRadexperience.GBLRadexperience.MINIMIZE_CHARACTER
                                = Convert.ToInt32(txtMinimizeCharacter.Value);

                            addGBLRadexperience.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        #endregion Add
                    }

                    msBox.ShowAlert("UID005", 2);

                    btnEdit.Text = "Edit";
                    EnableControl(false);
                    btnCancel.Visible = false;
                    hasData = true;
                    LoadData();
                }
                else
                { 
                
                }
                
            }
        }

        private byte[] ConvertImageToByte(System.Drawing.Image imageIn)
        {
            ImageConverter imcon = new ImageConverter();
            return (byte[])imcon.ConvertTo(imageIn, typeof(byte[]));
        }

        public Image ConvertByteToImage(object byteArrayIn)
        {
            ImageConverter imcon = new ImageConverter();
            return (Image)imcon.ConvertFrom(byteArrayIn);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = tabControl.SelectedIndex;
            tabControl.TabPages.RemoveAt(index);
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
                                ,"Overload Picture Size",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnEdit.Text = "Edit";
            EnableControl(false);
            btnCancel.Visible = false;

            LoadData();
        }

        private void RadExperience_Load(object sender, EventArgs e)
        {
            cbbFontSize.Properties.Items.AddRange(
                new object[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 }
                );

            EnableControl(false);

            #region Pre-Load
            radiologist_id = new RIS.Common.Common.GBLEnvVariable().UserID;
            LoadData();
            string FULLNAME = new RIS.Common.Common.GBLEnvVariable().FirstName + " " +
                                new RIS.Common.Common.GBLEnvVariable().LastName;
            txtRadiologist.Text = FULLNAME;
            btnEdit.Enabled = true;
            #endregion Pre-Load
        }
    }
}