using System;
using System.Collections.Generic;
using System.ComponentModel;
using RIS.Common.Common;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using RIS.BusinessLogic;
using RIS.Common;
using RIS.Operational;
using RIS.Operational.PACS;
using RIS.Forms.GBLMessage;
using RIS.Forms.ResultEntry.Common;
using DevExpress.XtraSpellChecker;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraSpellChecker.Rules;
using DevExpress.XtraBars;
using RIS.Plugin.DirectPrint;
using Miracle.HL7.ORU;
using RIS.Plugin.CRFile;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit;

namespace RIS.Forms.ResultEntry
{
    public partial class frmResultEntry : Form
    {
        //use global
        private UUL.ControlFrame.Controls.TabControl ctrlPage;
        private RIS.BusinessLogic.ResultEntry result;

        private GBLRadexperience rad;
        private GBLEnvVariable env;
        private DataRow drData;
        private MyMessageBox msg;
        private string accession_no, accession_noMamo;
        private bool notOpen;
        private bool FormClose = false;
        private bool FirstDatabind = true;
        //work list
        private DataTable dttWL;

        //demographic page
        private DataTable dttHis;
        private DataTable dttDemo;

        //edit member page
        private ColorPopupRichText cpFontColor;
        private ColorPopupRichText cpBGFontColor;
        private bool update = true;
        private DataTable dttICD;

        //Text XML
        private string XMLWorklist = "";
        private string XMLHistory = "";

        //SL_NO
        private int SL_NO = 0;

        string[] retValue;

        //checkFirstGridBind
        bool chkFirstSetGridWL = true;
        bool chkFirstSetGridHIS = true;
        bool ViewLockCase = false;

        //Biopsy report
        private string BioText = "";  //gen text,send to pacs
        private string Serverity = "";

        private bool firstLoad = true;

        public frmResultEntry(UUL.ControlFrame.Controls.TabControl page)
        {
            InitializeComponent();
            //this.defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Blue");
            ctrlPage = page;
            ctrlPage.ClosePressed += new EventHandler(CloseControl_ClosePressed);
            initFirst();
        }
        public frmResultEntry()
        {
            InitializeComponent();
            //this.defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Blue");
            initFirst();
        }
        void CloseControl_ClosePressed(object sender, EventArgs e)
        {
            this.Close();
        }
        private void initFirst()
        {
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
            result = new RIS.BusinessLogic.ResultEntry();
            rad = result.GetRadiologistConfig(new GBLEnvVariable().UserID);

            FirstDatabind = true;
            accession_no = string.Empty;
            rtPad.Text = string.Empty;
            rdNote.Text = string.Empty;
            logNote.Expanded = false;
            initDashBoard();
            initDemoGraphic();
            initEntryPane();
            notOpen = true;

            if (drData == null)
            {
                ribbonControl1.SelectedPage = pageDashBoard;
                xtraTabControl1.SelectedTabPage = pageWL;
                btnRefreshWL.Enabled = true;

                grpSearch.Expanded = false;
                chkAllExam.Visible = rad.ALL_EXAM_VISIBLE;
                //chkAllExam.Checked = rad.LOAD_ALL_EXAM;
                //chkFinalize.Checked = rad.LOAD_FINALIZED_EXAMS;

                if (rad.AUTO_REFRESH_WL_SEC > 0)
                {
                    tmWL.Interval = rad.AUTO_REFRESH_WL_SEC * 1000;
                    tmWL.Enabled = true;
                }
                else
                {
                    tmWL.Enabled = false;
                }

                switch (rad.DEF_DATE_RANGE)
                {
                    case "7":
                        txtFromDT.DateTime = DateTime.Now.AddDays(-7);
                        break;
                    case "1":
                        //txtToDT.DateTime.AddDays(0 - Convert.ToDouble(rad.DEF_DATE_RANGE));
                        break;
                    default:
                        txtFromDT.DateTime = DateTime.Now.AddDays(-7);
                        break;
                }
                switch (rad.DASHBOARD_DEF_SEARCH)
                {
                    case "D":
                        rdoDashDate.Checked = true;
                        rdoDashHN.Checked = false;
                        panelDate.Visible = true;
                        panelHN.Visible = false;
                        grpSearch.Expanded = true;
                        break;
                    case "H":
                        //txtDashHN.Text = "";
                        txtDashHN.Focus();
                        rdoDashDate.Checked = false;
                        rdoDashHN.Checked = true;
                        panelDate.Visible = false;
                        panelHN.Visible = true;
                        tmWL.Enabled = false;
                        grpSearch.Expanded = true;
                        break;
                    default:
                        rdoDashDate.Checked = true;
                        rdoDashHN.Checked = false;
                        panelDate.Visible = true;
                        panelHN.Visible = false;
                        break;
                }

                FirstDatabind = false;
                CheckDataBind();
                if (rad.DASHBOARD_DEF_SEARCH == "H")
                {
                    //txtDashHN.Text = "";
                    txtDashHN.Focus();
                }
            }
            if (FormClose == true)
            {
                int index = ctrlPage.SelectedIndex;
                ctrlPage.TabPages.RemoveAt(index);
            }

        }

        private void orderImage()
        {
            if (drData != null)
            {
                RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(txtDemo_AccNo.Text.Trim());
                ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                ordimg.StartPosition = FormStartPosition.CenterScreen;
                ordimg.MaximizeBox = false;
                ordimg.MinimizeBox = false;
                ordimg.ShowDialog();
            }
            else if (view1.FocusedRowHandle > -1)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(dr["ACCESSION_NO"].ToString());
                ordimg.Text = "Order Summary";
                ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                ordimg.StartPosition = FormStartPosition.CenterScreen;
                ordimg.MaximizeBox = false;
                ordimg.MinimizeBox = false;
                ordimg.ShowDialog();
            }
            else
                msg.ShowAlert("UID006", env.CurrentLanguageID);
        }
        private void merge()
        {

            #region Require Check.
            DataView dv = (DataView)viewHis.DataSource;
            bool flag = true;
            foreach (DataRow dr in dv.Table.Rows)
            {
                if (dr["chkCol"].ToString() == "Y")
                {
                    flag = false;
                    if (dr["S"].ToString() == "F" || dr["S"].ToString() == "P" || dr["S"].ToString() == "D" || dr["STATUS"].ToString() == "Locked")
                    {

                        msg.ShowAlert("UID5001", env.CurrentLanguageID);
                        return;
                    }
                    if (CheckIsLock(dr["ACCESSION_NO"].ToString()) == -1)
                    {
                        msg.ShowAlert("UID5005", env.CurrentLanguageID);

                        return;
                    }
                }
            }

            if (flag)
            {
                msg.ShowAlert("UID018", env.CurrentLanguageID);
                return;
            }

            #endregion
            if (msg.ShowAlert("UID1125", env.CurrentLanguageID) == "2")
            {
                //set merger
                LookUpSelect ls = new LookUpSelect();
                result.RISExamresult.MERGE = "MRR";
                result.RISExamresult.MERGE_WITH = string.Empty;
                result.RISExamresult.ACCESSION_NO = txtDemo_AccNo.Text;
                result.MergeSplit();
                drData["MERGE"] = "MRR";
                //set mergee
                foreach (DataRow dr in dv.Table.Rows)
                {
                    if (dr["chkCol"].ToString() == "Y")
                    {
                        result.RISExamresult.MERGE = "MGR";
                        result.RISExamresult.MERGE_WITH = txtDemo_AccNo.Text;
                        result.RISExamresult.ACCESSION_NO = dr["ACCESSION_NO"].ToString();

                        //if (ls.SelectExamResultLock(result.RISExamresult.ACCESSION_NO, env.UserID).Tables[1].Rows[0]["WORKING_RAD"].ToString() != env.UserID.ToString())
                        if (CheckIsLock(result.RISExamresult.ACCESSION_NO) == -1)
                        {
                            result.RISExamresult.MERGE = "SPT";
                            result.MergeSplit();
                            msg.ShowAlert("UID5005", env.CurrentLanguageID);
                            foreach (DataRow drchk in dv.Table.Rows) drchk["chkCol"] = "N";
                            return;
                        }
                        else
                        {
                            result.MergeSplit();
                        }
                    }
                }
                foreach (DataRow dr in dv.Table.Rows) dr["chkCol"] = "N";

            }
        }
        private void split(DataRow data)
        {
            #region Required Check.
            //if (data["STATUS"].ToString().ToLower() != "new")
            //{
            //    msg.ShowAlert("UID1123", env.CurrentLanguageID);
            //    return;
            //}
            //DataView dv = (DataView)viewHis.DataSource;
            //DataRow[] dr = dv.Table.Select(@"MERGE_WITH = '" + drData["ACCESSION_NO"].ToString() + @"' AND (S = 'F' OR S = 'P')");
            //if (dr.Length > 0)
            //{
            //    msg.ShowAlert("UID1123", env.CurrentLanguageID);
            //    return;
            //}
            if (string.IsNullOrEmpty(data["MERGE"].ToString()))
            {
                msg.ShowAlert("UID1123", env.CurrentLanguageID);
                return;
            }
            #endregion

            if (msg.ShowAlert("UID1124", env.CurrentLanguageID) == "2")
            {
                result.RISExamresult.ACCESSION_NO = data["ACCESSION_NO"].ToString();
                result.RISExamresult.MERGE = "SPT";
                result.RISExamresult.MERGE_WITH = string.Empty;
                result.MergeSplit();
            }
        }
        private void initAutoApplyTemplate(string ExamID)
        {
            DataTable dtt = result.GetTemplate().Tables[2];
            DataRow[] drs = dtt.Select("AUTO_APPLY='Y' and EXAM_ID=" + ExamID + " and CREATED_BY=" + env.UserID);
            if (drs.Length > 0)
            {
                rtPad.Document.RtfText = drs[0]["TEMPLATE_TEXT_RTF"].ToString();
            }
        }

        #region DashBoard.
        private void initDashBoard()
        {
            txtDash_RadioName.EditValue = env.FirstName + " " + env.LastName;

            lblPatientName.Text = string.Empty;
            lblExam.Text = string.Empty;
            lblAge.Text = string.Empty;
            lblGender.Text = string.Empty;
            lblStatus.Text = "New";
            lblSaveBy.Text = string.Empty;
            lblSaveOn.Text = string.Empty;
            txtRadioName.Text = txtDash_RadioName.EditValue.ToString();

            ProcessGetHRUnit process = new ProcessGetHRUnit();
            process.Invoke();
            DataTable dtt = process.Result.Tables[0];
            DataRow[] drs = dtt.Select("UNIT_ID=" + env.UnitID);
            if (drs.Length > 0)
            {
                txtDash_Dept.EditValue = drs[0]["UNIT_NAME"].ToString();

            }

            result.RISExamresult.EMP_ID = env.UserID;
            DataSet ds = result.GetCaseAmount();
            if (ds != null)
            {
                if (ds.Tables.Count == 2)
                {
                    //txtDash_TotalCase.EditValue = ds.Tables[0].Rows[0][0].ToString();
                    txtDash_Assg.EditValue = "Today : " + ds.Tables[1].Rows[0][0].ToString() + " | All : " + ds.Tables[0].Rows[0][0].ToString();

                }
            }
            initWorkList();
        }
        private void btnWorkList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drData != null)
            {
                if (rtPad.Text.Trim() != string.Empty)
                {
                    string str = msg.ShowAlert("UID1114", env.CurrentLanguageID);
                    if (str == "2")
                    {
                        UnLockCase(true);
                        drData = null;
                        initFirst();
                        ribbonControl1.SelectedPage = pageDashBoard;
                        xtraTabControl1.SelectedTabPage = pageWL;
                    }
                }
                else
                {
                    UnLockCase(true);
                    drData = null;
                    initFirst();
                }
            }
        }
        private void btnEntryPane_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drData != null)
            {
                ribbonControl1.SelectedPage = pageEdit;
                xtraTabControl1.SelectedTabPage = pageEntry;
            }
            else
            {
                if (view1.FocusedRowHandle > -1)
                {
                    drData = view1.GetDataRow(view1.FocusedRowHandle);
                    SelectThisCase(drData, true);
                }
            }
        }
        private void btnAddendum_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ribbonControl1.SelectedPage != null)
            {
                frmAddendum frm;
                if (ribbonControl1.SelectedPage == pageDashBoard)
                {
                    int orderID = Convert.ToInt32(view1.GetDataRow(view1.FocusedRowHandle)["ORDER_ID"].ToString());
                    string hn = view1.GetDataRow(view1.FocusedRowHandle)["HN"].ToString();
                    string exam_name = view1.GetDataRow(view1.FocusedRowHandle)["EXAM_NAME"].ToString() + " (" + view1.GetDataRow(view1.FocusedRowHandle)["EXAM_UID"].ToString() + ") ";
                    string accno = view1.GetDataRow(view1.FocusedRowHandle)["ACCESSION_NO"].ToString();
                    //System.Diagnostics.Process.Start(env.PacsUrl + accno);
                    ShowPacsImage(accno);
                    frm = new frmAddendum(accno, exam_name, orderID, hn);
                    frm.ShowDialog();
                }
                else
                {
                    int orderID = Convert.ToInt32(drData["ORDER_ID"]);
                    string hn = drData["HN"].ToString();
                    string exam_name = drData["EXAM_NAME"].ToString() + " (" + drData["EXAM_UID"].ToString() + ") ";
                    string accno = drData["ACCESSION_NO"].ToString();
                    ShowPacsImage(accno);
                    frm = new frmAddendum(accno, exam_name, orderID, hn);
                    frm.ShowDialog();

                    initDemoGraphic();
                }
            }
        }
        private void btnMerge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (xtraTabControl1.SelectedTabPage != null)
            //{
            //    if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "worklist")
            //    {
            //        if (view1.FocusedRowHandle > -1)
            //        {
            //            DataTable dtW = (DataTable)grdWL.DataSource;
            //            DataRow[] drS = dtW.Select(" CHK = 'Y' AND (STATUS = 'New' OR STATUS = 'New(T)')");

            //            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            //            if (dr["S"].ToString().ToLower() == "f" || dr["S"].ToString().ToLower() == "p" || dr["S"].ToString().ToLower() == "d" || dr["STATUS"].ToString().ToLower() == "locked")
            //            {
            //                msg.ShowAlert("UID1116", env.CurrentLanguageID);
            //                return;
            //            }
            //            if (CheckIsLock(dr["ACCESSION_NO"].ToString()) == -1)
            //            {
            //                msg.ShowAlert("UID5005", env.CurrentLanguageID);
            //                return;
            //            }
            //            Merge frm;
            //            if (drS.Length > 0)
            //                frm = new Merge(dr, drS);
            //            else
            //                frm = new Merge(dr);
            //            frm.ShowDialog();

            //            if (frm.DialogResult == DialogResult.OK)
            //            {
            //                drData = view1.GetDataRow(view1.FocusedRowHandle);
            //                DataTable _dtt = new DataTable();
            //                _dtt = result.GetWorkList();

            //                DataRow[] drAcc = _dtt.Select("ACCESSION_NO = '" + drData["ACCESSION_NO"].ToString() + "'");
            //                if (drAcc.Length > 0)
            //                {
            //                    SelectThisCase(drAcc[0], false);
            //                }
            //                if (drData != null)
            //                {
            //                    string str = drData["ASSIGNED_TO"].ToString();
            //                    if (string.IsNullOrEmpty(str))
            //                    {
            //                        str = msg.ShowAlert("UID014", env.CurrentLanguageID);
            //                    }
            //                    else
            //                    {
            //                        if (str.Trim() == env.UserID.ToString())
            //                            str = "2";
            //                        else
            //                            str = msg.ShowAlert("UID015", env.CurrentLanguageID);
            //                    }
            //                    if (str == "2")
            //                    {


            //                        //LookUpSelect ls = new LookUpSelect();

            //                        //if (ls.SelectExamResultLock(drData["ACCESSION_NO"].ToString(), env.UserID).Tables[1].Rows[0]["WORKING_RAD"].ToString() != env.UserID.ToString())
            //                        if (CheckIsLock(drData["ACCESSION_NO"].ToString()) == -1)
            //                        {
            //                            msg.ShowAlert("UID5005", env.CurrentLanguageID);
            //                            return;
            //                        }

            //                        if (rad.AUTO_START_PACS_IMG)
            //                            System.Diagnostics.Process.Start(env.PacsUrl + drData["ACCESSION_NO"].ToString().Trim(), "_blank");
            //                        if (rad.AUTO_START_ORDER_IMG)
            //                        {
            //                            RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(drData["ACCESSION_NO"].ToString());
            //                            ordimg.Text = "Order Summary";
            //                            ordimg.FormBorderStyle = FormBorderStyle.Sizable;
            //                            ordimg.StartPosition = FormStartPosition.CenterScreen;
            //                            ordimg.MaximizeBox = false;
            //                            ordimg.MinimizeBox = false;
            //                            ordimg.ShowDialog();
            //                        }
            //                        initDemoGraphic();

            //                        switch (rad.GRID_DBL_CLICK_TO)
            //                        {
            //                            case "H":
            //                                ribbonControl1.SelectedPage = pageDemographic;
            //                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
            //                                break;
            //                            case "R":
            //                                ribbonControl1.SelectedPage = pageEdit;
            //                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageEntry;
            //                                break;
            //                            default:
            //                                ribbonControl1.SelectedPage = pageDemographic;
            //                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
            //                                break;
            //                        }
            //                        if (rad.REMEMBER_GRID_ORDER)
            //                        {
            //                            ProcessUpdateGBLRadexperience prc = new ProcessUpdateGBLRadexperience();
            //                            getXMLGridWorklist();
            //                            prc.UpdateGridWorklist(new GBLEnvVariable().UserID, XMLWorklist);
            //                        }
            //                        try
            //                        {
            //                            FontFamily fontFamily = new FontFamily(rad.FONT_FACE);
            //                            float size = Convert.ToSingle(rad.MINIMIZE_CHARACTER);
            //                            Font font = new Font(fontFamily, size);

            //                            iBarFont.EditValue = rad.FONT_FACE;
            //                            iFontSize.EditValue = rad.FONT_SIZE;

            //                            rtPad.SelectionFont = font;
            //                        }
            //                        catch
            //                        {
            //                            FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
            //                            float size = 11;
            //                            Font font = new Font(fontFamily, size);

            //                            iBarFont.EditValue = rad.FONT_FACE;
            //                            iFontSize.EditValue = rad.FONT_SIZE;

            //                            rtPad.SelectionFont = font;
            //                        }
            //                    }
            //                }
            //            }
            //            //CheckDataBind();
            //        }
            //        else
            //        {
            //            msg.ShowAlert("UID018", env.CurrentLanguageID);
            //            return;
            //        }
            //    }
            //    else if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "history")
            //    {
            //        merge();
            //    }
            //}
        }
        private void btnSplit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != null)
            {
                if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "worklist")
                {
                    if (view1.FocusedRowHandle > -1)
                    {
                        DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                        split(dr);
                        CheckDataBind();
                        //UnLockCase(true);
                    }
                    else
                    {
                        msg.ShowAlert("UID018", env.CurrentLanguageID);
                        return;
                    }
                }
                else if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "history")
                {
                    if (viewHis.FocusedRowHandle > -1)
                    {
                        if (drData == null)
                        {
                            msg.ShowAlert("UID018", env.CurrentLanguageID);
                            return;
                        }
                        if (string.IsNullOrEmpty(drData["MERGE"].ToString()))
                        {
                            msg.ShowAlert("UID1123", env.CurrentLanguageID);
                            return;
                        }
                        split(drData);
                    }
                    else
                    {
                        msg.ShowAlert("UID018", env.CurrentLanguageID);
                        return;
                    }
                }
            }
        }
        private void btnTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transfer frm;
            if (xtraTabControl1.SelectedTabPage != null)
            {
                if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "worklist")
                {
                    DataTable dtW = (DataTable)grdWL.DataSource;
                    DataRow[] dr = dtW.Select(" CHK = 'Y'");
                    DataTable dtNew = new DataTable();
                    if (dr.Length > 0)
                    {
                        dtNew.Columns.Add("ACCESSION_NO");
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dtNew.NewRow();
                            dtNew.Rows.Add(dr[i]["ACCESSION_NO"].ToString());
                            dtNew.AcceptChanges();
                        }
                        frm = new Transfer(dtNew);
                    }
                    else
                    {
                        if (view1.FocusedRowHandle >= 0)
                        {
                            DataRow drThis = view1.GetDataRow(view1.FocusedRowHandle);
                            dtNew.Columns.Add("ACCESSION_NO");
                            dtNew.NewRow();
                            dtNew.Rows.Add(drThis["ACCESSION_NO"].ToString());
                            dtNew.AcceptChanges();
                            frm = new Transfer(dtNew);
                        }
                        else
                        {
                            frm = new Transfer();
                        }
                    }

                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        initWorkList();
                    }

                }
                else if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "history")
                {
                    //ไม่แสดงข้อมูลที่กำลังอ่านอยู่ใน worklist.
                    frm = new Transfer(txtDemo_AccNo.Text);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        initWorkList();
                    }
                }
            }
        }
        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                string hn = dr["HN"].ToString();
                BrowseArchive frm = new BrowseArchive(hn);
                frm.ShowDialog();
            }
            else
            {
                BrowseArchive frm = new BrowseArchive("");
                frm.ShowDialog();
            }
        }
        private void btnBrowseArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BrowseArchive frm = new BrowseArchive();
            frm.ShowDialog();
        }
        private void btnRefreshWL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != null)
            {
                if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "worklist")
                {
                    tmWL.Enabled = false;
                    CheckDataBind();
                    tmWL.Enabled = true;
                }
            }
        }
        private void iDashImageOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            orderImage();
        }
        private void toolsOrderImg_Click(object sender, EventArgs e)
        {
            orderImage();
        }
        private void toolsMerge_Click(object sender, EventArgs e)
        {
            //if (xtraTabControl1.SelectedTabPage != null)
            //{
            //    if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "worklist")
            //    {
            //        if (view1.FocusedRowHandle > -1)
            //        {
            //            DataTable dtW = (DataTable)grdWL.DataSource;
            //            DataRow[] drS = dtW.Select(" CHK = 'Y' AND (STATUS = 'New' OR STATUS = 'New(T)')");

            //            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            //            if (dr["S"].ToString().ToLower() == "f" || dr["S"].ToString().ToLower() == "p" || dr["S"].ToString().ToLower() == "d" || dr["STATUS"].ToString().ToLower() == "locked")
            //            {
            //                msg.ShowAlert("UID1116", env.CurrentLanguageID);
            //                return;
            //            }
            //            if (CheckIsLock(dr["ACCESSION_NO"].ToString()) == -1)
            //            {
            //                msg.ShowAlert("UID5005", env.CurrentLanguageID);
            //                return;
            //            }
            //            Merge frm;
            //            if (drS.Length > 0)
            //                frm = new Merge(dr, drS);
            //            else
            //                frm = new Merge(dr);
            //            frm.ShowDialog();

            //            if (frm.DialogResult == DialogResult.OK)
            //            {
            //                drData = view1.GetDataRow(view1.FocusedRowHandle);
            //                DataTable _dtt = new DataTable();
            //                _dtt = result.GetWorkList();

            //                DataRow[] drAcc = _dtt.Select("ACCESSION_NO = '" + drData["ACCESSION_NO"].ToString() + "'");
            //                if (drAcc.Length > 0)
            //                {
            //                    SelectThisCase(drAcc[0], false);
            //                }
            //                if (drData != null)
            //                {
            //                    string str = drData["ASSIGNED_TO"].ToString();
            //                    if (string.IsNullOrEmpty(str))
            //                    {
            //                        str = msg.ShowAlert("UID014", env.CurrentLanguageID);
            //                    }
            //                    else
            //                    {
            //                        if (str.Trim() == env.UserID.ToString())
            //                            str = "2";
            //                        else
            //                            str = msg.ShowAlert("UID015", env.CurrentLanguageID);
            //                    }
            //                    if (str == "2")
            //                    {


            //                        //LookUpSelect ls = new LookUpSelect();

            //                        //if (ls.SelectExamResultLock(drData["ACCESSION_NO"].ToString(), env.UserID).Tables[1].Rows[0]["WORKING_RAD"].ToString() != env.UserID.ToString())
            //                        if (CheckIsLock(drData["ACCESSION_NO"].ToString()) == -1)
            //                        {
            //                            msg.ShowAlert("UID5005", env.CurrentLanguageID);
            //                            return;
            //                        }

            //                        if (rad.AUTO_START_PACS_IMG)
            //                        {
            //                            //System.Diagnostics.Process.Start(env.PacsUrl + drData["ACCESSION_NO"].ToString().Trim());
            //                            ShowPacsImage(drData["ACCESSION_NO"].ToString().Trim());
            //                        }
            //                        if (rad.AUTO_START_ORDER_IMG)
            //                        {
            //                            RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(drData["ACCESSION_NO"].ToString());
            //                            ordimg.Text = "Order Summary";
            //                            ordimg.FormBorderStyle = FormBorderStyle.Sizable;
            //                            ordimg.StartPosition = FormStartPosition.CenterScreen;
            //                            ordimg.MaximizeBox = false;
            //                            ordimg.MinimizeBox = false;
            //                            ordimg.ShowDialog();
            //                        }
            //                        initDemoGraphic();

            //                        switch (rad.GRID_DBL_CLICK_TO)
            //                        {
            //                            case "H":
            //                                ribbonControl1.SelectedPage = pageDemographic;
            //                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
            //                                break;
            //                            case "R":
            //                                ribbonControl1.SelectedPage = pageEdit;
            //                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageEntry;
            //                                break;
            //                            default:
            //                                ribbonControl1.SelectedPage = pageDemographic;
            //                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
            //                                break;
            //                        }
            //                        if (rad.REMEMBER_GRID_ORDER)
            //                        {
            //                            ProcessUpdateGBLRadexperience prc = new ProcessUpdateGBLRadexperience();
            //                            getXMLGridWorklist();
            //                            prc.UpdateGridWorklist(new GBLEnvVariable().UserID, XMLWorklist);
            //                        }
            //                        try
            //                        {
            //                            FontFamily fontFamily = new FontFamily(rad.FONT_FACE);
            //                            float size = Convert.ToSingle(rad.MINIMIZE_CHARACTER);
            //                            Font font = new Font(fontFamily, size);

            //                            iBarFont.EditValue = rad.FONT_FACE;
            //                            iFontSize.EditValue = rad.FONT_SIZE;

            //                            rtPad.SelectionFont = font;
            //                        }
            //                        catch
            //                        {
            //                            FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
            //                            float size = 11;
            //                            Font font = new Font(fontFamily, size);

            //                            iBarFont.EditValue = rad.FONT_FACE;
            //                            iFontSize.EditValue = rad.FONT_SIZE;

            //                            rtPad.SelectionFont = font;
            //                        }
            //                    }
            //                }
            //            }
            //            //CheckDataBind();
            //        }
            //        else
            //        {
            //            msg.ShowAlert("UID018", env.CurrentLanguageID);
            //            return;
            //        }
            //    }
            //    else if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "history")
            //    {
            //        merge();
            //    }
            //}
        }
        private void toolsTransFer_Click(object sender, EventArgs e)
        {
            Transfer frm;
            if (xtraTabControl1.SelectedTabPage != null)
            {
                if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "worklist")
                {
                    DataTable dtW = (DataTable)grdWL.DataSource;
                    DataRow[] dr = dtW.Select(" CHK = 'Y'");
                    DataTable dtNew = new DataTable();
                    if (dr.Length > 0)
                    {
                        dtNew.Columns.Add("ACCESSION_NO");
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dtNew.NewRow();
                            dtNew.Rows.Add(dr[i]["ACCESSION_NO"].ToString());
                            dtNew.AcceptChanges();
                        }
                        frm = new Transfer(dtNew);
                    }
                    else
                    {
                        if (view1.FocusedRowHandle >= 0)
                        {
                            DataRow drThis = view1.GetDataRow(view1.FocusedRowHandle);
                            dtNew.Columns.Add("ACCESSION_NO");
                            dtNew.NewRow();
                            dtNew.Rows.Add(drThis["ACCESSION_NO"].ToString());
                            dtNew.AcceptChanges();
                            frm = new Transfer(dtNew);
                        }
                        else
                        {
                            frm = new Transfer();
                        }
                    }

                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        initWorkList();
                    }

                }
                else if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "history")
                {
                    //ไม่แสดงข้อมูลที่กำลังอ่านอยู่ใน worklist.
                    frm = new Transfer(txtDemo_AccNo.Text);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        initWorkList();
                    }
                }
            }
        }
        private void toolsHistory_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {

                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                string hn = dr["HN"].ToString();
                BrowseArchive frm = new BrowseArchive(hn);
                frm.ShowDialog();

            }
        }
        private void toolsBrowse_Click(object sender, EventArgs e)
        {
            BrowseArchive frm = new BrowseArchive();
            frm.ShowDialog();
        }

        #region WorkList.
        private void initWorkList()
        {
            if (firstLoad)
            {
                txtFromDT.DateTime = DateTime.Today;
                txtToDT.DateTime = DateTime.Today;
                chkFinalize.Checked = false;
                firstLoad = false;
            }
            else
            {
            }
            if (drData != null)
            {
                switch (rad.FINISH_WRITING_REFER_TO)
                {
                    case "N":
                        DataTable dtNext = result.GetNextCase(drData["ACCESSION_NO"].ToString());
                        if (dtNext.Rows.Count > 0)
                        {
                            drData = dtNext.Rows[0];
                            if (rad.AUTO_START_PACS_IMG)
                            {
                                //System.Diagnostics.Process.Start(env.PacsUrl + drData["ACCESSION_NO"].ToString().Trim());
                                ShowPacsImage(drData["ACCESSION_NO"].ToString().Trim());
                            }
                            if (rad.AUTO_START_ORDER_IMG)
                            {
                                RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(drData["ACCESSION_NO"].ToString());
                                ordimg.Text = "Order Summary";
                                ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                                ordimg.StartPosition = FormStartPosition.CenterScreen;
                                ordimg.MaximizeBox = false;
                                ordimg.MinimizeBox = false;
                                ordimg.ShowDialog();
                            }
                        }
                        else
                        {
                            drData = null;
                        }
                        break;
                    case "P":
                        DataTable dtPrevious = result.GetPreviousCase(drData["ORDER_ID"].ToString());
                        if (dtPrevious.Rows.Count > 0)
                        {
                            drData = dtPrevious.Rows[0];
                            if (rad.AUTO_START_PACS_IMG)
                            {
                                //System.Diagnostics.Process.Start(env.PacsUrl + drData["ACCESSION_NO"].ToString().Trim());
                                ShowPacsImage(drData["ACCESSION_NO"].ToString().Trim());
                            }
                            if (rad.AUTO_START_ORDER_IMG)
                            {
                                RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(drData["ACCESSION_NO"].ToString());
                                ordimg.Text = "Order Summary";
                                ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                                ordimg.StartPosition = FormStartPosition.CenterScreen;
                                ordimg.MaximizeBox = false;
                                ordimg.MinimizeBox = false;
                                ordimg.ShowDialog();
                            }
                        }
                        else
                        {
                            drData = null;
                        }
                        break;
                    case "W":
                        //LoadData(1);
                        drData = null;
                        break;
                    case "H":
                        ribbonControl1.SelectedPage = pageDemographic;
                        xtraTabControl1.SelectedTabPage = pageHistory;
                        break;
                    case "E":
                        drData = null;
                        FormClose = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void getDataTable()
        {
            dttWL = new DataTable();
            if (chkFinalize.Checked)
                result.RISExamresult.STATUS = "F";
            else
                result.RISExamresult.STATUS = "N";
            dttWL = result.GetWorkList();

            dttWL.Columns.Add("colPacs");
            dttWL.Columns.Add("colPrelim");
            dttWL.Columns.Add("colFinalize");
            dttWL.Columns.Add("colReport");

            grdWL.DataSource = dttWL;
        }
        private void LoadData(int mode)
        {
            rdoDashHN.Enabled = false;
            rdoDashDate.Enabled = false;
            panelHN.Enabled = false;
            panelDate.Enabled = false;
            chkFinalize.Enabled = false;
            grdHis.Enabled = false;


            result.RISExamresult.EMP_ID = env.UserID;
            result.RISExamresult.DATETIME_FROM = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
            result.RISExamresult.DATETIME_END = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);

            if (mode == 1)
                result.RISExamresult.MODE = 1;
            else if (mode == 2)
                result.RISExamresult.MODE = 2;
            else if (mode == 3)
            {
                result.RISExamresult.MODE = 3;
                result.RISExamresult.HN = txtDashHN.Text;
            }
            getDataTable();
            setGridColumnWL();
            if (mode == 3)
            {
                //if (dttWL.Rows.Count == 0) 
                //    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                //else 
                if (dttWL.Rows.Count == 1)
                {
                    drData = dttWL.Rows[0];
                    initDemoGraphic();
                }
            }
            if (dttWL.Rows.Count == 0)
            {
                btnAddendum.Enabled = false;
                btnAddendumSmall.Enabled = false;
            }
            rdoDashHN.Enabled = true;
            rdoDashDate.Enabled = true;
            panelHN.Enabled = true;
            panelDate.Enabled = true;
            chkFinalize.Enabled = true;
            grdHis.Enabled = true;
        }

        private void setGridColumnWL()
        {
            #region Columns Addition
            //DataTable tb = (DataTable)grdWL.DataSource;

            //grdWL.RefreshDataSource();
            //view1.LayoutChanged();
            //dttWL = tb.Copy();
            #endregion

            #region column edit
            if (chkFirstSetGridWL == true)
            {
                for (int i = 0; i < dttWL.Columns.Count; i++)
                    view1.Columns[i].Visible = false;

                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repositoryItemImageComboBox2.AutoHeight = false;
                repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)});
                repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
                repositoryItemImageComboBox2.SmallImages = imgWL;
                repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                chkTemplate.ValueChecked = "Y";
                chkTemplate.ValueUnchecked = "N";
                chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
                chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                chkTemplate.Click += new EventHandler(chk_Click);

                DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit link = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                link.Image = imgHIS.Images[3];
                link.Click += new EventHandler(link_Click);

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPacs = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                btnPacs.Buttons.Clear();
                btnPacs.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton());
                btnPacs.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btnPacs.Buttons[0].Caption = "Pacs Image";
                btnPacs.Buttons[0].ImageLocation = ImageLocation.MiddleCenter;
                btnPacs.Buttons[0].Image = imgHIS.Images[1];
                btnPacs.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btnPacs.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnPacs_ButtonClick);

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnReport = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                btnReport.Buttons.Clear();
                btnReport.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton());
                btnReport.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btnReport.Buttons[0].Caption = "Reporting";
                btnReport.Buttons[0].ImageLocation = ImageLocation.MiddleCenter;
                btnReport.Buttons[0].Image = imgSmall.Images[46];
                btnReport.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btnReport.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnReport_ButtonClick);

            #endregion column edit

                view1.Columns["CHK"].ColumnEdit = chkTemplate;
                view1.Columns["CHK"].Caption = "";
                view1.Columns["CHK"].Visible = true;
                view1.Columns["CHK"].BestFit();
                view1.Columns["CHK"].ColVIndex = 0;

                view1.Columns["PRIORITY_ID"].ColumnEdit = repositoryItemImageComboBox2;
                view1.Columns["PRIORITY_ID"].Caption = "Priority";
                view1.Columns["PRIORITY_ID"].Visible = true;
                view1.Columns["PRIORITY_ID"].BestFit();
                view1.Columns["PRIORITY_ID"].ColVIndex = 1;
                view1.Columns["PRIORITY_ID"].OptionsColumn.ReadOnly = true;
                view1.Columns["PRIORITY_ID"].OptionsColumn.AllowEdit = false;

                view1.Columns["STATUS"].Caption = "Status";
                view1.Columns["STATUS"].Visible = true;
                view1.Columns["STATUS"].BestFit();
                view1.Columns["STATUS"].ColVIndex = 2;
                view1.Columns["STATUS"].OptionsColumn.ReadOnly = true;
                view1.Columns["STATUS"].OptionsColumn.AllowEdit = false;

                view1.Columns["TIMEDIFF"].Caption = "Waiting Time";
                view1.Columns["TIMEDIFF"].Visible = true;
                view1.Columns["TIMEDIFF"].BestFit();
                view1.Columns["TIMEDIFF"].ColVIndex = 3;
                view1.Columns["TIMEDIFF"].OptionsColumn.ReadOnly = true;
                view1.Columns["TIMEDIFF"].OptionsColumn.AllowEdit = false;

                view1.Columns["ORDER_DT"].Caption = "Order Time";
                view1.Columns["ORDER_DT"].Visible = true;
                view1.Columns["ORDER_DT"].ColVIndex = 4;
                view1.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
                view1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view1.Columns["ORDER_DT"].Width = 73;
                view1.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
                view1.Columns["ORDER_DT"].OptionsColumn.AllowEdit = false;

                view1.Columns["HN"].Caption = "HN";
                view1.Columns["HN"].Visible = true;
                view1.Columns["HN"].Width = 100;
                view1.Columns["HN"].ColVIndex = 5;
                view1.Columns["HN"].OptionsColumn.ReadOnly = true;
                view1.Columns["HN"].OptionsColumn.AllowEdit = false;

                view1.Columns["colPacs"].Caption = "Pacs Image";
                view1.Columns["colPacs"].Visible = true;
                view1.Columns["colPacs"].Width = 50;
                view1.Columns["colPacs"].ColVIndex = 6;
                view1.Columns["colPacs"].OptionsColumn.ReadOnly = false;
                view1.Columns["colPacs"].OptionsColumn.AllowEdit = true;
                view1.Columns["colPacs"].ColumnEdit = btnPacs;

                view1.Columns["colReport"].Caption = "Reporting";
                view1.Columns["colReport"].Visible = true;
                view1.Columns["colReport"].Width = 50;
                view1.Columns["colReport"].ColVIndex = 7;
                view1.Columns["colReport"].OptionsColumn.ReadOnly = false;
                view1.Columns["colReport"].OptionsColumn.AllowEdit = true;
                view1.Columns["colReport"].ColumnEdit = btnReport;

                view1.Columns["PatientName"].Caption = "Patient Name";
                view1.Columns["PatientName"].Visible = true;
                view1.Columns["PatientName"].BestFit();
                view1.Columns["PatientName"].ColVIndex = 8;
                view1.Columns["PatientName"].OptionsColumn.ReadOnly = true;
                view1.Columns["PatientName"].OptionsColumn.AllowEdit = false;

                view1.Columns["AGE"].Caption = "Age";
                view1.Columns["AGE"].Visible = true;
                view1.Columns["AGE"].BestFit();
                view1.Columns["AGE"].ColVIndex = 9;
                view1.Columns["AGE"].OptionsColumn.ReadOnly = true;
                view1.Columns["AGE"].OptionsColumn.AllowEdit = false;

                view1.Columns["ACCESSION_NO"].Caption = "Accession No";
                view1.Columns["ACCESSION_NO"].Visible = true;
                view1.Columns["ACCESSION_NO"].BestFit();
                view1.Columns["ACCESSION_NO"].ColVIndex = 10;
                view1.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
                view1.Columns["ACCESSION_NO"].OptionsColumn.AllowEdit = false;

                view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                view1.Columns["EXAM_NAME"].Visible = true;
                view1.Columns["EXAM_NAME"].BestFit();
                view1.Columns["EXAM_NAME"].ColVIndex = 11;
                view1.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
                view1.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;

                view1.Columns["Radiologist"].Caption = "Radiologist";
                view1.Columns["Radiologist"].Visible = true;
                view1.Columns["Radiologist"].BestFit();
                view1.Columns["Radiologist"].ColVIndex = 12;
                view1.Columns["Radiologist"].OptionsColumn.ReadOnly = true;
                view1.Columns["Radiologist"].OptionsColumn.AllowEdit = false;

                view1.Columns["Unit"].Caption = "Ordering Dept.";
                view1.Columns["Unit"].Visible = true;
                view1.Columns["Unit"].BestFit();
                view1.Columns["Unit"].ColVIndex = 13;
                view1.Columns["Unit"].OptionsColumn.ReadOnly = true;
                view1.Columns["Unit"].OptionsColumn.AllowEdit = false;

                view1.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
                view1.Columns["CLINIC_TYPE_TEXT"].Visible = true;
                view1.Columns["CLINIC_TYPE_TEXT"].BestFit();
                view1.Columns["CLINIC_TYPE_TEXT"].ColVIndex = 14;
                view1.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.ReadOnly = true;
                view1.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.AllowEdit = false;

                view1.Columns["EXAM_UID"].Caption = "Exam Code";
                view1.Columns["EXAM_UID"].Visible = true;
                view1.Columns["EXAM_UID"].BestFit();
                view1.Columns["EXAM_UID"].ColVIndex = 15;
                view1.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
                view1.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;

                view1.Columns["ORDER_ID"].Caption = "Order No";
                view1.Columns["ORDER_ID"].Visible = true;
                view1.Columns["ORDER_ID"].BestFit();
                view1.Columns["ORDER_ID"].ColVIndex = 16;
                view1.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
                view1.Columns["ORDER_ID"].OptionsColumn.AllowEdit = false;

                #region Set font style.
                //Alive
                DevExpress.XtraGrid.StyleFormatCondition stylCon1
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "New");
                stylCon1.Appearance.ForeColor = Color.Red;

                //Complete
                DevExpress.XtraGrid.StyleFormatCondition stylCon2
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Complete");
                stylCon2.Appearance.ForeColor = Color.Red;

                //Prelim
                DevExpress.XtraGrid.StyleFormatCondition stylCon3
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim");
                stylCon3.Appearance.ForeColor = Color.Goldenrod;

                //Draft
                DevExpress.XtraGrid.StyleFormatCondition stylCon4
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft");
                stylCon4.Appearance.ForeColor = Color.Goldenrod;

                //Finalize
                DevExpress.XtraGrid.StyleFormatCondition stylCon5
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized");
                stylCon5.Appearance.ForeColor = Color.Green;

                //Prelim(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon6
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim(T)");
                stylCon6.Appearance.ForeColor = Color.Goldenrod;

                //Draft(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon7
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft(T)");
                stylCon7.Appearance.ForeColor = Color.Goldenrod;

                //Finalize(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon8
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized(T)");
                stylCon8.Appearance.ForeColor = Color.Green;

                //Locked
                DevExpress.XtraGrid.StyleFormatCondition stylCon9
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Locked");
                stylCon9.Appearance.ForeColor = Color.Blue;

                view1.FormatConditions.Clear();
                view1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5, stylCon6, stylCon7, stylCon8, stylCon9 });
                #endregion

                if (rad.WORKLIST_GRID_ORDER.Length > 0 && rad.REMEMBER_GRID_ORDER == true)
                {
                    DataSet getXML = new DataSet();
                    System.IO.MemoryStream mem = null;
                    try
                    {
                        char[] chr = rad.WORKLIST_GRID_ORDER.ToCharArray();
                        byte[] data = new byte[chr.Length];
                        for (int i = 0; i < chr.Length; i++)
                            data[i] = (byte)chr[i];
                        mem = new System.IO.MemoryStream(data);

                        getXML.ReadXml(mem);
                        for (int j = 0; j < getXML.Tables[0].Rows.Count; j++)
                        {
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Width = Convert.ToInt32(getXML.Tables[0].Rows[j][1]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Visible = Convert.ToBoolean(getXML.Tables[0].Rows[j][2]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].ColVIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][3]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].GroupIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][4]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].AbsoluteIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][5]);
                            view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].VisibleIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][6]);
                        }
                        mem.Dispose();
                    }
                    catch
                    { }
                }
                else
                {
                    getXMLGridWorklist();
                    rad.WORKLIST_GRID_ORDER = XMLWorklist;
                }
                chkFirstSetGridWL = false;
            }
        }

        void btnReport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                drData = view1.GetDataRow(view1.FocusedRowHandle);

                if (drData != null)
                {
                    SelectThisCase(drData, true);
                    if (drData == null) return;
                    ribbonControl1.SelectedPage = pageEdit;
                    xtraTabControl1.SelectedTabPage = pageEntry;
                    rtPad.ActiveView.ZoomFactor = 0.9F;
                    rtPad.ActiveView.ZoomFactor = Convert.ToSingle(Convert.ToDouble(barZoom.EditValue.ToString().Replace("%", "")) * 0.01);
                }
            }
        }
        void btnPacs_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                drData = view1.GetDataRow(view1.FocusedRowHandle);
                if (drData != null)
                    ShowPacsImage(drData["ACCESSION_NO"].ToString().Trim());
            }
        }

        private void chkAllExam_Click(object sender, EventArgs e)
        {
            if (!FirstDatabind)
            {
                if (chkAllExam.Checked == true)
                {
                    LoadData(2);
                }
                else
                {
                    LoadData(1);
                }
            }
        }
        private void view1_DoubleClick(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                //rdNote.Visible = false;
                drData = view1.GetDataRow(view1.FocusedRowHandle);
                SelectThisCase(drData, true);
                rtPad.ActiveView.ZoomFactor = 0.9F;
                rtPad.ActiveView.ZoomFactor = Convert.ToSingle(Convert.ToDouble(barZoom.EditValue.ToString().Replace("%", "")) * 0.01);
            }
        }
        private void txtDashHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (!FirstDatabind)
            {
                if (txtDashHN.Text.Trim().Length > 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtDashHN.Text.Trim().Length == 0)
                        {
                            txtDashHN.Focus();
                            return;
                        }
                        LoadData(3);
                    }
                }
            }
        }

        private void rdoDashDate_Click(object sender, EventArgs e)
        {
            if (rdoDashDate.Checked)
            {
                panelDate.Visible = true;
                panelHN.Visible = false;
                rdoDashHN.Checked = false;
            }
            else
            {
                panelDate.Visible = false;
                panelHN.Visible = true;
                rdoDashHN.Checked = true;
            }
        }
        private void rdoDashHN_Click(object sender, EventArgs e)
        {
            if (rdoDashHN.Checked)
            {
                panelDate.Visible = false;
                panelHN.Visible = true;
                rdoDashDate.Checked = false;
            }
            else
            {
                panelDate.Visible = false;
                panelHN.Visible = true;
                rdoDashDate.Checked = true;
            }
        }
        private void rdoDashDate_Validating(object sender, CancelEventArgs e)
        {
            //btnSearch.Focus();
        }
        private void rdoDashHN_Validating(object sender, CancelEventArgs e)
        {
            if (txtDashHN.Text.Trim().Length == 0)
                txtDashHN.Focus();
            //else
            //    btnSearchHN.Focus();
        }

        private void menuWL_Opening(object sender, CancelEventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void tmWL_Tick(object sender, EventArgs e)
        {
            //if (grpSearch.Expanded == true)
            //{
            //    tmWL.Enabled = false;
            //}
            //else
            //{
            //    tmWL.Enabled = true;
            //    CheckDataBind();
            //}

            if (grpSearch.Expanded == false && rad.AUTO_REFRESH_WL_SEC != 0)
            {
                tmWL.Enabled = true;
                CheckDataBind();
            }
            else
            {
                tmWL.Enabled = false;
            }
        }
        private void CheckDataBind()
        {
            if (rdoDashDate.Checked)
            {
                if (chkAllExam.Checked)
                    LoadData(2);
                else
                    LoadData(1);
            }
            else if (rdoDashHN.Checked)
            {
                LoadData(3);
            }
        }
        private void chkFinalize_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstDatabind)
            {
                if (rdoDashDate.Checked)
                {
                    if (chkAllExam.Checked)
                        LoadData(2);
                    else
                        LoadData(1);
                }
                else if (rdoDashHN.Checked)
                {
                    LoadData(3);
                }
            }
        }
        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                if (view1.GetDataRow(view1.FocusedRowHandle)["STATUS"].ToString().Trim() == "Finalized")
                {

                    btnAddendum.Enabled = true;
                    btnAddendumSmall.Enabled = true;
                }
                else
                {
                    btnAddendum.Enabled = false;
                    btnAddendumSmall.Enabled = false;
                }
            }
        }
        #endregion.

        #endregion

        #region Demographic.
        private void clearDemoGraphic()
        {
            txtDemo_HN.EditValue = string.Empty;
            txtDemo_AN.EditValue = string.Empty;
            txtDemo_ID.EditValue = string.Empty;
            txtDemo_ThName.EditValue = string.Empty;
            txtDemo_EngName.EditValue = string.Empty;
            txtDemo_Addr.EditValue = string.Empty;
            txtDemo_Gender.EditValue = string.Empty;
            txtDemo_Age.EditValue = string.Empty;
            txtDemo_DOB.EditValue = string.Empty;
            txtDemo_Doctor.EditValue = string.Empty;
            txtDemo_Dept.EditValue = string.Empty;
            txtDemo_Phone.EditValue = string.Empty;
            rtPad.Text = string.Empty;
            rdNote.Text = string.Empty;
            dttHis = null;
        }
        private void initDemoGraphic()
        {
            //rdNote.ReadOnly = false;
            enableDisableEntryPage(true);
            clearDemoGraphic();
            if (drData != null)
            {
                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                result.RISExamresult.ORDER_ID = Convert.ToInt32(drData["ORDER_ID"].ToString());
                result.RISExamresult.HN = drData["HN"].ToString();
                result.RISExamresult.EMP_ID = env.UserID;
                if ((bool)drData["Favorite"] == true)
                    barFavorite.Enabled = false;
                else
                    barFavorite.Enabled = true;

                if ((bool)drData["Teaching"] == true)
                    barTeaching.Enabled = false;
                else
                    barTeaching.Enabled = true;

                DataSet ds = result.GetHistory();
                if (ds != null)
                    if (ds.Tables.Count == 3)
                    {

                        #region Demographic.
                        string name = string.Empty;
                        txtDemo_HN.EditValue = ds.Tables[0].Rows[0]["HN"].ToString();
                        txtDemo_AN.EditValue = ds.Tables[0].Rows[0]["AN"].ToString();
                        txtDemo_ID.EditValue = ds.Tables[0].Rows[0]["SSN"].ToString();
                        name = ds.Tables[0].Rows[0]["FNAME"].ToString() + " ";
                        name += ds.Tables[0].Rows[0]["MNAME"].ToString() + " ";
                        name += ds.Tables[0].Rows[0]["LNAME"].ToString();
                        txtDemo_ThName.EditValue = name;
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["FNAME_ENG"].ToString()))
                        {
                            name = RIS.Operational.Translator.TransToEnglish.Trans(ds.Tables[0].Rows[0]["FNAME_ENG"].ToString()) + " ";
                            name += RIS.Operational.Translator.TransToEnglish.Trans(ds.Tables[0].Rows[0]["MNAME_ENG"].ToString()) + " ";
                            name += RIS.Operational.Translator.TransToEnglish.Trans(ds.Tables[0].Rows[0]["LNAME_ENG"].ToString());

                        }
                        else
                        {
                            name = ds.Tables[0].Rows[0]["FNAME_ENG"].ToString() + " ";
                            name += ds.Tables[0].Rows[0]["MNAME_ENG"].ToString() + " ";
                            name += ds.Tables[0].Rows[0]["LNAME_ENG"].ToString();
                        }
                        txtDemo_EngName.EditValue = name;
                        txtDemo_Addr.EditValue = ds.Tables[0].Rows[0]["ADDR"].ToString();
                        txtDemo_Gender.EditValue = ds.Tables[0].Rows[0]["GENDER"].ToString();
                        txtDemo_DOB.EditValue = ds.Tables[0].Rows[0]["DOB"].ToString();
                        txtDemo_Age.EditValue = ds.Tables[0].Rows[0]["AGE"].ToString();
                        txtDemo_Dept.EditValue = ds.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                        txtDemo_Doctor.EditValue = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
                        txtDemo_Phone.EditValue = ds.Tables[0].Rows[0]["UNIT_TEL"].ToString();
                        dttDemo = new DataTable();
                        dttDemo = ds.Tables[0].Copy();

                        #endregion

                        #region Select Case.
                        name = ds.Tables[1].Rows[0]["STATUS"].ToString();
                        switch (name)
                        {
                            case "A": name = "New"; break;
                            case "D": name = "Draft"; break;
                            case "P": name = "Prelim"; break;
                            case "F": name = "Finalized"; break;
                            case "C": name = "Complete"; break;
                            case "G": name = "New"; break;
                        }
                        if (ds.Tables[1].Rows[0]["STATUS"].ToString() == "A")
                        {
                            lblStatus.Text = "New";
                            lblSaveBy.Text = string.Empty;
                            lblSaveOn.Text = string.Empty;
                            rtPad.Text = string.Empty;
                            rtPad.ReadOnly = false;
                            initAutoApplyTemplate(ds.Tables[1].Rows[0]["EXAM_ID"].ToString());
                        }
                        else if (ds.Tables[1].Rows[0]["STATUS"].ToString() == "C")
                        {
                            lblStatus.Text = "Complete";
                            lblSaveBy.Text = string.Empty;
                            lblSaveOn.Text = string.Empty;
                            rtPad.Text = string.Empty;
                            rtPad.ReadOnly = false;
                            initAutoApplyTemplate(ds.Tables[1].Rows[0]["EXAM_ID"].ToString());
                        }
                        else
                        {
                            lblStatus.Text = name;
                            lblSaveBy.Text = ds.Tables[1].Rows[0]["LASTBY"].ToString();
                            lblSaveOn.Text = ds.Tables[1].Rows[0]["LASTON"].ToString();

                            if (name == "Finalized")
                            {
                                iSaveResultDraft.Enabled = false;
                                iSaveResultPrelim.Enabled = false;
                                iSaveResultFinal.Enabled = false;

                                btnAddendum.Enabled = true;
                                btnAddendumSmall.Enabled = true;
                                rtPad.ReadOnly = true;
                                enableDisableEntryPage(false);

                                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                                DataSet dsNote = result.GetExamNote();
                                if (dsNote.Tables[0].Rows.Count > 0)
                                {
                                    //foreach (DataRow dr in dsNote.Tables[0].Rows)
                                    //{
                                    //    rdNote.Text += "Addendum\r\n\r\n";
                                    //    rdNote.Text += dr["TXT"].ToString();
                                    //    rdNote.Text += "\r\n\r\nWritten By\r\n";
                                    //    rdNote.Text += dr["RadioNameEng"].ToString();
                                    //    rdNote.Text += "\r\nDate\r\n";
                                    //    DateTime dt = Convert.ToDateTime(dr["NOTE_ON"]);
                                    //    rdNote.Text += dt.ToShortDateString() + "\r\n";
                                    //    logNote.Expanded = true;
                                    //    //rdNote.ReadOnly = true;
                                    //}
                                    int dr_i = dsNote.Tables[0].Rows.Count;
                                    foreach (DataRow dr in dsNote.Tables[0].Rows)
                                    {
                                        rdNote.Text += "Addendum : " + dr_i.ToString() + ", ";
                                        rdNote.Text += "Written By : ";
                                        rdNote.Text += dr["RadioNameEng"].ToString();
                                        rdNote.Text += ", Date : ";
                                        DateTime dt = Convert.ToDateTime(dr["NOTE_ON"]);
                                        rdNote.Text += dt.ToString() + "\r\n";
                                        rdNote.Text += dr["TXT"].ToString();
                                        rdNote.Text += "\r\n\r\n";
                                        dr_i--;
                                    }
                                    logNote.Expanded = true;
                                }
                                else
                                {
                                    logNote.Expanded = false;
                                }
                            }
                            else if (name == "Prelim")
                            {
                                iSaveResultDraft.Enabled = false;
                                iSaveResultPrelim.Enabled = true;
                                iSaveResultFinal.Enabled = true;
                                rtPad.ReadOnly = false;
                                btnAddendum.Enabled = false;
                                btnAddendumSmall.Enabled = false;
                                rtPad.ReadOnly = false;
                            }
                            else
                            {
                                iSaveResultDraft.Enabled = true;
                                iSaveResultPrelim.Enabled = true;
                                iSaveResultFinal.Enabled = true;
                                rtPad.ReadOnly = false;
                                btnAddendum.Enabled = false;
                                btnAddendumSmall.Enabled = false;
                            }

                            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[0]["RTF"].ToString()))
                            {
                                rtPad.Document.RtfText = ds.Tables[1].Rows[0]["RTF"].ToString();
                            }
                        }
                        txtDemo_Status.Text = name;
                        name = ds.Tables[1].Rows[0]["PRIORITY"].ToString();
                        switch (name)
                        {
                            case "R": name = "Routine"; break;
                            case "S": name = "Stat"; break;
                            case "U": name = "Urgent"; break;
                        }
                        txtDemo_AccNo.Text = drData["ACCESSION_NO"].ToString();
                        txtDemo_Priority.Text = name;
                        txtDemo_ExamCode.Text = ds.Tables[1].Rows[0]["EXAM_UID"].ToString();
                        txtDemo_ExamName.Text = ds.Tables[1].Rows[0]["EXAM_NAME"].ToString();

                        dttICD = result.GetICD(Convert.ToInt32(ds.Tables[1].Rows[0]["ORDER_ID"].ToString()));
                        lblPatientName.Text = System.Text.RegularExpressions.Regex.Replace(txtDemo_ThName.EditValue.ToString(), " {1,}", " ") + " (" + txtDemo_HN.EditValue.ToString().Trim() + ") ";
                        lblExam.Text = txtDemo_ExamName.Text + " (" + txtDemo_ExamCode.Text + ")";
                        lbOrderDoc.Text = txtDemo_Doctor.EditValue.ToString();

                        lblAge.Text = txtDemo_Age.EditValue.ToString();
                        lblGender.Text = txtDemo_Gender.EditValue.ToString();
                        txtRadioName.Text = txtDash_RadioName.EditValue.ToString();
                        accession_no = txtDemo_AccNo.Text.Trim();

                        result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                        result.RISExamresult.MERGE = drData["MERGE"].ToString();
                        result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();

                        DataTable dttMerge = result.GetMergeData();
                        if (dttMerge.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dttMerge.Rows)
                            {
                                if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                                {
                                    lblExam.Text = lblExam.Text + " + " + dr["EXAM_NAME"].ToString() + " (" + dr["EXAM_UID"].ToString() + ")";
                                }
                            }
                        }
                        #endregion

                        #region History.
                        dttHis = ds.Tables[2].Copy();
                        setGridHistory();
                        #endregion
                    }
                tmWL.Enabled = false;
            }
        }
        private void setGridHistory()
        {
            DataRow[] drs = dttHis.Select("ACCESSION_NO ='" + txtDemo_AccNo.Text + "' ");

            if (drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {
                    dttHis.Rows.Remove(dr);
                }
                dttHis.AcceptChanges();
            }
            grdHis.DataSource = dttHis;
            initColumnHistory();
        }
        private void initColumnHistory()
        {
            if (chkFirstSetGridHIS == true)
            {
                for (int i = 0; i < dttHis.Columns.Count; i++)
                {
                    viewHis.Columns[i].Visible = false;
                    viewHis.Columns[i].OptionsColumn.ReadOnly = true;
                }

                #region column edit
                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                repositoryItemImageComboBox2.AutoHeight = false;
                repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)});
                repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
                repositoryItemImageComboBox2.SmallImages = imgWL;
                repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit link = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                link.Image = imgHIS.Images[3];
                link.Click += new EventHandler(link_Click);

                //DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnlink = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                //btnlink. = imgHIS.Images[3];
                //btnlink.Click += new EventHandler(link_Click);

                DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkOrder = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                linkOrder.Image = imgHIS.Images[4];
                linkOrder.Click += new EventHandler(linkOrder_Click);
                //linkOrder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                #endregion column edit

                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                chk.ValueChecked = "Y";
                chk.ValueUnchecked = "N";
                chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
                chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                chk.Click += new EventHandler(chk_Click);

                viewHis.Columns["chkCol"].ColumnEdit = chk;
                viewHis.Columns["chkCol"].Caption = "";
                viewHis.Columns["chkCol"].Visible = true;
                viewHis.Columns["chkCol"].BestFit();
                viewHis.Columns["chkCol"].ColVIndex = 0;

                viewHis.Columns["PRIORITY_ID"].ColumnEdit = repositoryItemImageComboBox2;
                viewHis.Columns["PRIORITY_ID"].Caption = "Priority";
                viewHis.Columns["PRIORITY_ID"].Visible = true;
                viewHis.Columns["PRIORITY_ID"].BestFit();
                viewHis.Columns["PRIORITY_ID"].ColVIndex = 1;
                viewHis.Columns["PRIORITY_ID"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["STATUS"].Caption = "Status";
                viewHis.Columns["STATUS"].Visible = true;
                viewHis.Columns["STATUS"].BestFit();
                viewHis.Columns["STATUS"].ColVIndex = 2;
                viewHis.Columns["STATUS"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["TIMEDIFF"].Caption = "Waiting Time";
                viewHis.Columns["TIMEDIFF"].Visible = true;
                viewHis.Columns["TIMEDIFF"].BestFit();
                viewHis.Columns["TIMEDIFF"].ColVIndex = 3;
                viewHis.Columns["TIMEDIFF"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["ORDER_DT"].Caption = "Order Time";
                viewHis.Columns["ORDER_DT"].Visible = true;
                viewHis.Columns["ORDER_DT"].ColVIndex = 4;
                viewHis.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
                viewHis.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                viewHis.Columns["ORDER_DT"].Width = 73;
                //viewHis.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["PacsImg"].Caption = "PACS Image";
                viewHis.Columns["PacsImg"].Visible = true;
                viewHis.Columns["PacsImg"].BestFit();
                viewHis.Columns["PacsImg"].ColVIndex = 5;
                viewHis.Columns["PacsImg"].ColumnEdit = link;
                viewHis.Columns["PacsImg"].OptionsColumn.ReadOnly = false;

                viewHis.Columns["OrderImg"].Caption = "Order Sum.";
                viewHis.Columns["OrderImg"].Visible = true;
                viewHis.Columns["OrderImg"].ColumnEdit = linkOrder;
                viewHis.Columns["OrderImg"].BestFit();
                viewHis.Columns["OrderImg"].ColVIndex = 6;
                viewHis.Columns["OrderImg"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                viewHis.Columns["OrderImg"].OptionsColumn.ReadOnly = false;

                viewHis.Columns["ACCESSION_NO"].Caption = "Accession No";
                viewHis.Columns["ACCESSION_NO"].Visible = true;
                viewHis.Columns["ACCESSION_NO"].BestFit();
                viewHis.Columns["ACCESSION_NO"].ColVIndex = 7;
                viewHis.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["EXAM_NAME"].Caption = "Exam Name";
                viewHis.Columns["EXAM_NAME"].Visible = true;
                viewHis.Columns["EXAM_NAME"].BestFit();
                viewHis.Columns["EXAM_NAME"].ColVIndex = 8;
                viewHis.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["Radiologist"].Caption = "Radiologist";
                viewHis.Columns["Radiologist"].Visible = true;
                viewHis.Columns["Radiologist"].BestFit();
                viewHis.Columns["Radiologist"].ColVIndex = 9;
                viewHis.Columns["Radiologist"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["Unit"].Caption = "Ordering Dept.";
                viewHis.Columns["Unit"].Visible = true;
                viewHis.Columns["Unit"].BestFit();
                viewHis.Columns["Unit"].ColVIndex = 10;
                viewHis.Columns["Unit"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
                viewHis.Columns["CLINIC_TYPE_TEXT"].Visible = true;
                viewHis.Columns["CLINIC_TYPE_TEXT"].BestFit();
                viewHis.Columns["CLINIC_TYPE_TEXT"].ColVIndex = 11;
                viewHis.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.ReadOnly = true;
                viewHis.Columns["CLINIC_TYPE_TEXT"].OptionsColumn.AllowEdit = false;

                viewHis.Columns["EXAM_UID"].Caption = "Exam Code";
                viewHis.Columns["EXAM_UID"].Visible = true;
                viewHis.Columns["EXAM_UID"].BestFit();
                viewHis.Columns["EXAM_UID"].ColVIndex = 12;
                viewHis.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;

                viewHis.Columns["ORDER_ID"].Caption = "Order No";
                viewHis.Columns["ORDER_ID"].Visible = true;
                viewHis.Columns["ORDER_ID"].BestFit();
                viewHis.Columns["ORDER_ID"].ColVIndex = 13;
                viewHis.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;


                #region Set font style.
                //Alive
                DevExpress.XtraGrid.StyleFormatCondition stylCon1
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "New");
                stylCon1.Appearance.ForeColor = Color.Red;

                //Complete
                DevExpress.XtraGrid.StyleFormatCondition stylCon2
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Complete");
                stylCon2.Appearance.ForeColor = Color.Red;

                //Prelim
                DevExpress.XtraGrid.StyleFormatCondition stylCon3
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Prelim");
                stylCon3.Appearance.ForeColor = Color.Goldenrod;

                //Draft
                DevExpress.XtraGrid.StyleFormatCondition stylCon4
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Draft");
                stylCon4.Appearance.ForeColor = Color.Goldenrod;

                //Finalize
                DevExpress.XtraGrid.StyleFormatCondition stylCon5
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, viewHis.Columns["Status"], null, "Finalized");
                stylCon5.Appearance.ForeColor = Color.Green;

                //Prelim(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon6
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Prelim(T)");
                stylCon6.Appearance.ForeColor = Color.Goldenrod;

                //Draft(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon7
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Draft(T)");
                stylCon7.Appearance.ForeColor = Color.Goldenrod;

                //Finalize(T)
                DevExpress.XtraGrid.StyleFormatCondition stylCon8
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Finalized(T)");
                stylCon8.Appearance.ForeColor = Color.Green;

                //Locked
                DevExpress.XtraGrid.StyleFormatCondition stylCon9
                    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, view1.Columns["Status"], null, "Locked");
                stylCon9.Appearance.ForeColor = Color.Blue;

                viewHis.FormatConditions.Clear();
                viewHis.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5, stylCon6, stylCon7, stylCon8, stylCon9 });

                #endregion

                if (rad.HISTORY_GRID_ORDER.Length > 0)
                {
                    DataSet getXML = new DataSet();
                    System.IO.MemoryStream mem = null;
                    try
                    {
                        char[] chr = rad.HISTORY_GRID_ORDER.ToCharArray();
                        byte[] data = new byte[chr.Length];
                        for (int i = 0; i < chr.Length; i++)
                            data[i] = (byte)chr[i];
                        mem = new System.IO.MemoryStream(data);

                        getXML.ReadXml(mem);
                        for (int j = 0; j < getXML.Tables[0].Rows.Count; j++)
                        {
                            viewHis.Columns[getXML.Tables[0].Rows[j][0].ToString()].Width = Convert.ToInt32(getXML.Tables[0].Rows[j][1]);
                            viewHis.Columns[getXML.Tables[0].Rows[j][0].ToString()].Visible = Convert.ToBoolean(getXML.Tables[0].Rows[j][2]);
                            viewHis.Columns[getXML.Tables[0].Rows[j][0].ToString()].ColVIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][3]);
                            viewHis.Columns[getXML.Tables[0].Rows[j][0].ToString()].GroupIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][4]);
                            viewHis.Columns[getXML.Tables[0].Rows[j][0].ToString()].AbsoluteIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][5]);
                            viewHis.Columns[getXML.Tables[0].Rows[j][0].ToString()].VisibleIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][6]);
                        }
                        mem.Dispose();
                    }
                    catch
                    { }
                }
                else
                {
                    getXMLGridHistory();
                    rad.HISTORY_GRID_ORDER = XMLHistory;
                }
                chkFirstSetGridHIS = false;
            }
        }
        void chk_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                //DataTable dtWL = (DataTable)grdWL.DataSource;
                if (view1.FocusedRowHandle > 0)
                {
                    DataRow drChk = view1.GetDataRow(view1.FocusedRowHandle);
                    if (chk.Checked == false)
                        drChk["CHK"] = "Y";
                    else
                        drChk["CHK"] = "N";
                    //dtWL.Rows[view1.FocusedRowHandle]["CHK"] = chk.Checked ? "N" : "Y";
                    //dtWL.AcceptChanges();
                    //grdWL.DataSource = dtWL;
                    // PreTemplateFlag = false;
                }
            }
        }

        void linkOrder_Click(object sender, EventArgs e)
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(dr["ACCESSION_NO"].ToString());
                ordimg.Text = "Order Summary";
                ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                ordimg.StartPosition = FormStartPosition.CenterScreen;
                ordimg.MaximizeBox = false;
                ordimg.MinimizeBox = false;
                ordimg.ShowDialog();
            }
        }
        void link_Click(object sender, EventArgs e)
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                //System.Diagnostics.Process.Start(env.PacsUrl + dr["ACCESSION_NO"].ToString().Trim());
                ShowPacsImage(dr["ACCESSION_NO"].ToString().Trim());
            }
        }

        private void viewHis_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                if (dttHis != null)
                {
                    if (dttHis.Rows.Count > 0)
                    {
                        txtDemo_Result.Text = dttHis.Rows[viewHis.FocusedRowHandle]["RTEXT"].ToString();
                        //if (viewHis == null) return;
                        //if (viewHis.FocusedColumn == null) return;
                        //if (viewHis.FocusedColumn.FieldName == "chkCol")
                        //{
                        //    //DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                        //    //string chk = dr["chkCol"].ToString();
                        //    //dr["chkCol"] = chk == "N" ? "Y" : "N";
                        //}
                    }
                }
            }
        }
        private void viewHis_DoubleClick(object sender, EventArgs e)
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                if (viewHis.FocusedColumn != null)
                {
                    DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                    if (viewHis.FocusedColumn.FieldName == "PacsImg")
                    {
                        if (viewHis.FocusedRowHandle > -1)
                        {
                            //System.Diagnostics.Process.Start(env.PacsUrl + dr["ACCESSION_NO"].ToString().Trim());
                            ShowPacsImage(dr["ACCESSION_NO"].ToString().Trim());
                        }
                    }
                    if (viewHis.FocusedColumn.FieldName == "OrderImg")
                    {
                        if (viewHis.FocusedRowHandle > -1)
                        {
                            RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(dr["ACCESSION_NO"].ToString());
                            ordimg.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                            ordimg.StartPosition = FormStartPosition.CenterParent;
                            ordimg.ShowDialog();
                            return;
                        }
                    }
                    if (txtDemo_AccNo.Text.Trim() == dr["ACCESSION_NO"].ToString().Trim()) return;
                    string str = msg.ShowAlert("UID1117", env.CurrentLanguageID);
                    if (str == "2")
                    {
                        DataRow chkMerge = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                        if (chkMerge["MERGE_WITH"].ToString() == txtDemo_AccNo.Text)
                        {
                            drData = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                            notOpen = true;
                            initDemoGraphic();
                        }
                        else
                        {
                            UnLockCase(true);
                            drData = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                            if (CheckIsLock(drData["ACCESSION_NO"].ToString()) == -1)
                            {
                                msg.ShowAlert("UID5005", env.CurrentLanguageID);
                                return;
                            }
                            result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                            result.RISExamresult.MERGE = drData["MERGE"].ToString();
                            result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();

                            DataTable dtMerge = result.GetMergeData();
                            foreach (DataRow drChk in dtMerge.Rows)
                            {
                                if (drChk["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                                {
                                    CheckIsLock(drChk["ACCESSION_NO"].ToString());
                                }
                            }
                            initDemoGraphic();
                        }
                    }
                }
            }
        }
        private void viewHis_Click(object sender, EventArgs e)
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                if (viewHis.FocusedColumn != null)
                {
                    if (viewHis.FocusedColumn.FieldName == "chkCol")
                    {
                        DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                        string chk = dr["S"].ToString();
                        if (chk != "P" && chk != "F")
                        {
                            chk = dr["ACCESSION_NO"].ToString();
                            if (chk == txtDemo_AccNo.Text) return;
                            chk = dr["chkCol"].ToString();
                            dr["chkCol"] = chk == "N" ? "Y" : "N";
                        }
                    }
                    if (viewHis.FocusedColumn.FieldName == "PacsImg")
                    {
                        DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                        //System.Diagnostics.Process.Start(env.PacsUrl + dr["ACCESSION_NO"].ToString().Trim());
                        ShowPacsImage(dr["ACCESSION_NO"].ToString().Trim());
                    }
                    if (viewHis.FocusedColumn.FieldName == "OrderImg")
                    {
                        DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                        RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(dr["ACCESSION_NO"].ToString());
                        ordimg.Text = "Order Summary";
                        ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                        ordimg.StartPosition = FormStartPosition.CenterScreen;
                        ordimg.MaximizeBox = false;
                        ordimg.MinimizeBox = false;
                        ordimg.ShowDialog();
                    }
                }

            }
        }

        private void btnDemo_Merge_Click(object sender, EventArgs e)
        {
            if (drData["S"].ToString() == "D" || drData["S"].ToString() == "P" || drData["S"].ToString() == "F" || drData["STATUS"].ToString() == "Locked")
            {
                msg.ShowAlert("UID5001", env.CurrentLanguageID);
                return;
            }
            merge();
            DataSet ds = result.GetHistory();
            dttHis = ds.Tables[2].Copy();
            setGridHistory();
        }
        private void btnDemo_Split_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(drData["MERGE"].ToString()))
            {
                msg.ShowAlert("UID1123", env.CurrentLanguageID);
                return;
            }
            split(drData);
            UnLockCase(false);
            DataSet ds = result.GetHistory();
            dttHis = ds.Tables[2].Copy();
            setGridHistory();
        }
        private void btnDemo_EntryPane_Click(object sender, EventArgs e)
        {

            ribbonControl1.SelectedPage = pageEdit;
            xtraTabControl1.SelectedTabPage = pageEntry;
            rtPad.Focus();
            initFormat();
            if (notOpen)
            {
                //System.Diagnostics.Process.Start(env.PacsUrl + txtDemo_AccNo.Text.Trim());
                notOpen = false;
            }
            if (rad.REMEMBER_GRID_ORDER)
            {
                ProcessUpdateGBLRadexperience prc = new ProcessUpdateGBLRadexperience();
                getXMLGridHistory();
                prc.UpdateGridHistory(new GBLEnvVariable().UserID, XMLHistory);
            }
        }
        #endregion

        #region Edit.
        private void initEntryPane()
        {
            createPopupMenuFontColor();
            createPopupMenuBGFontColor();
            initFormat();
            SetDefaultFont(rtPad);
        }
        private void enableDisableEntryPage(bool flag)
        {

            //Group Format.
            ibarSpell.Enabled = flag;
            iBarFont.Enabled = flag;
            iFontSize.Enabled = flag;

            //Group Template.
            iOpenTemplate.Enabled = flag;
            iSaveTemplate.Enabled = flag;

            //iICD.Enabled = flag;
            //iOrderImage.Enabled = flag;
            iFavorite.Enabled = flag;
            iTechFile.Enabled = flag;

            //Save result
            iSaveResultDraft.Enabled = flag;
            iSaveResultPrelim.Enabled = flag;
            iSaveResultFinal.Enabled = flag;
        }
        private void createPopupMenuFontColor()
        {
            //cpFontColor = new ColorPopupRichText(popupControlContainer1, iBarFontColor, rtPad);
        }
        private void createPopupMenuBGFontColor()
        {
            //cpBGFontColor = new ColorPopupRichText(popupControlContainer2, iBarFontBGColor, rtPad, true);
        }
        private void initFormat()
        {

            if (lblStatus.Text.Trim() == "Finalized")
            {
                enableDisableEntryPage(false);
                return;
            }
            update = false;

            if (rtPad.Document.Selection.Length == 0)
            {
                SetDefaultFont(rtPad);
            }
            update = true;
        }
        private void initFontSize()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbo = (DevExpress.XtraEditors.Repository.RepositoryItemComboBox)iFontSize.Edit;
            for (int i = 8; i < 74; i += 2)
            {
                cbo.Items.Add(i);

            }
        }
        private void SetDefaultFont(RichEditControl rtTemp)
        {
            Document doc = rtTemp.Document;

            DocumentRange sel = rtTemp.Document.Range;
            CharacterProperties charProperties = rtTemp.Document.BeginUpdateCharacters(sel);
            charProperties.FontName = rad.FONT_FACE;//"Microsoft Sans Serif";
            charProperties.FontSize = rad.FONT_SIZE;
            rtTemp.Document.EndUpdateCharacters(charProperties);

            ParagraphProperties pp = doc.BeginUpdateParagraphs(sel);
            // Set triple spacing
            pp.LineSpacingType = ParagraphLineSpacing.Multiple;
            pp.LineSpacingMultiplier = (float)1.3;
            doc.EndUpdateParagraphs(pp);
        }

        public RichEditControl CurrentRichTextBox
        {
            get
            {
                return rtPad;
            }
        }

        private void rtPad_SelectionChanged(object sender, EventArgs e)
        {
            if (lblStatus.Text.Trim() == "Finalized")
            {
                enableDisableEntryPage(false);
                return;
            }
            initFormat();
        }

        #region Group Edit.
        private void iPicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.RestoreDirectory = true;
            dlg.Multiselect = false;
            dlg.Filter = "All Picture(*.jpg)|*.jpg";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                Bitmap bmp = new Bitmap(dlg.FileName);
                Clipboard.SetDataObject(bmp);
                rtPad.Document.Paste();
            }
            dlg.Dispose();
        }
        #endregion

        #region Group Format.
        private void ibarSpell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ibarSpell.Down == true)
            {
                spellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;
                spellChecker1.Check(rtPad);
                // barManager1.SetPopupContextMenu(richTextBox1, popupMenu1);

            }
            else
            {
                spellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.OnDemand;
            }
            //spellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;
            //spellChecker1.Check(rtPad);
        }
        #endregion

        #region Group Template.
        private void iOpenTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenTemplate open = null;
            if (drData != null)
                open = new OpenTemplate(rtPad, Convert.ToInt32(drData["EXAM_ID"].ToString()));
            else
                open = new OpenTemplate(this.rtPad);
            open.ShowDialog();

            rtPad.ActiveView.ZoomFactor = 0.9F;
            rtPad.ActiveView.ZoomFactor = Convert.ToSingle(Convert.ToDouble(barZoom.EditValue.ToString().Replace("%", "")) * 0.01);
        }
        private void iSaveTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rtPad.Text.Trim().Length < 9)
            {
                string id = msg.ShowAlert("UID1126", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            SaveTemplate save;
            if (drData == null)
                save = new SaveTemplate(rtPad);
            else
            {
                int i = Convert.ToInt32(drData["EXAM_ID"].ToString());
                save = new SaveTemplate(rtPad, i);
            }
            save.ShowDialog();
        }
        #endregion

        private void iOrderImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(txtDemo_AccNo.Text.Trim());
            ordimg.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ordimg.StartPosition = FormStartPosition.CenterParent;
            ordimg.ShowDialog();
        }

        private void iICD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.WaitDialog.frmICD icd = new RIS.Forms.Order.WaitDialog.frmICD();
            icd.StartPosition = FormStartPosition.CenterParent;
            icd.ICDTable = dttICD;
            icd.ShowDialog();
        }

        private void rdoFinal_Click(object sender, EventArgs e)
        {
            //if (rdoFinal.Checked)
            //{
            //    cboFinalize.Visible = true;
            //    cboFinalize.Enabled = true;
            //    cboFinalize.BackColor = Color.White;
            //    if(cboFinalize.SelectedIndex==-1)
            //        cboFinalize.SelectedIndex = 0;
            //}
        }
        private void rdo_Click(object sender, EventArgs e)
        {
            //RadioButton rd = (RadioButton)sender;
            //if (rd.Checked)
            //{
            //    cboFinalize.Visible = false;
            //    cboFinalize.Enabled = false;
            //    cboFinalize.BackColor = panelDetail.BackColor;

            //    cboFinalize.SelectedIndex = -1;
            //}
        }
        private void menuOrderImages_Click(object sender, EventArgs e)
        {
            RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(txtDemo_AccNo.Text.Trim());
            ordimg.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ordimg.StartPosition = FormStartPosition.CenterParent;
            ordimg.ShowDialog();
        }
        private void menuICD_Click(object sender, EventArgs e)
        {
            RIS.Forms.Order.WaitDialog.frmICD icd = new RIS.Forms.Order.WaitDialog.frmICD();
            icd.StartPosition = FormStartPosition.CenterParent;
            icd.ICDTable = dttICD;
            icd.ShowDialog();
        }
        private void Severity_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            retValue = e.NewValue.Split(new Char[] { '^' });
        }
        private void iSaveResultDraft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
            //prc.Invoke();
            // DataSet dsSeverity = prc.Result;
            // RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            // lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Severity_Clicks);
            // lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
            // lv.AddColumn("SEVERITY_NAME", "SEVERITY_NAME", true, true);
            // lv.AddColumn("SEVERITY_DESC", "SEVERITY_DESC", true, true);
            // lv.Text = "Severity List";
            // lv.Data = dsSeverity.Tables[0];

            // Size ss = new Size(510, 225);
            // lv.Size = ss;
            // lv.StartPosition = FormStartPosition.CenterScreen;
            //// lv.PreviewFieldName = "report";
            //// lv.ShowDescription = true;
            // retValue = null;
            // lv.ShowBox();

            // if (retValue == null)
            //     return;
            #region Biopsy
            if (xtraTabControl1.SelectedTabPage == pageBiopsy)
            {

                if (CheckSpaceMamo())
                {
                    return;
                }
                ProcessGetMISBiopsyresult geBio = new ProcessGetMISBiopsyresult();
                geBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                geBio.Invoke();
                if (geBio.Result.Tables[0].Rows.Count > 0)
                {
                    string _id = msg.ShowAlert("UID4002", new GBLEnvVariable().CurrentLanguageID);
                    if (_id == "2")
                    {
                        UpdateDataBiopsy("D");
                    }
                    else
                    {
                        return;
                    }
                    GenText();

                    rtPad.Text = BioText;
                    //return;
                }
                else
                {

                    if (CheckSpaceMamo())
                    {
                        return;
                    }
                    string _id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);
                    if (_id == "2")
                    {
                        SaveDataBiopsy("D");
                    }
                    else
                    {
                        return;
                    }
                    GenText();
                    rtPad.Text = BioText;
                }
            }
            #endregion
            if (rtPad.Text.Length < rad.MINIMIZE_CHARACTER)
            {

                msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID, rad.MINIMIZE_CHARACTER);
                return;
            }
            string uid = "2";
            if (drData["S"].ToString() != "D")
            {
                uid = string.IsNullOrEmpty(drData["MERGE"].ToString()) ? "UID1128" : drData["MERGE"].ToString().ToLower() == "spt" ? "UID1128" : "UID1131";
                uid = msg.ShowAlert(uid, env.CurrentLanguageID);
            }
            if (uid == "2" || uid == "3")
            {
                #region Save Report.
                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                result.RISExamresult.ORDER_ID = Convert.ToInt32(drData["ORDER_ID"].ToString());
                result.RISExamresult.EXAM_ID = Convert.ToInt32(drData["EXAM_ID"].ToString());
                result.RISExamresult.RESULT_TEXT_HTML = "";
                result.RISExamresult.RESULT_TEXT_PLAIN = rtPad.Document.Text;
                result.RISExamresult.RESULT_TEXT_RTF = rtPad.Document.RtfText;
                result.RISExamresult.RESULT_STATUS = "D";
                result.RISExamresult.RELEASED_BY = 0;
                result.RISExamresult.FINALIZED_BY = 0;
                result.RISExamresult.CREATED_BY = env.UserID;
                result.RISExamresult.ORG_ID = env.OrgID;
                result.RISExamresult.SEVERITY_ID = 1;
                result.Reporting();
                if (!string.IsNullOrEmpty(drData["MERGE"].ToString()))
                {
                    if (drData["MERGE"].ToString().ToLower() != "spt")
                    {
                        string html = result.RISExamresult.RESULT_TEXT_HTML;
                        string text = result.RISExamresult.RESULT_TEXT_PLAIN;
                        string rtf = result.RISExamresult.RESULT_TEXT_RTF;
                        result.RISExamresult.MERGE = drData["MERGE"].ToString();
                        result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                        result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();

                        DataTable dtt = result.GetMergeData();
                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                            {
                                result.RISExamresult.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                result.RISExamresult.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"].ToString());
                                result.RISExamresult.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                                result.RISExamresult.RESULT_TEXT_HTML = html;
                                result.RISExamresult.RESULT_TEXT_PLAIN = text;
                                result.RISExamresult.RESULT_TEXT_RTF = rtf;
                                result.RISExamresult.RESULT_STATUS = "D";
                                result.RISExamresult.RELEASED_BY = 0;
                                result.RISExamresult.FINALIZED_BY = 0;
                                result.RISExamresult.CREATED_BY = env.UserID;
                                result.RISExamresult.ORG_ID = env.OrgID;
                                result.RISExamresult.SEVERITY_ID = 1;
                                result.Reporting();
                            }
                        }
                    }
                }
                #endregion

                if (uid == "3")
                {
                    int id = 0;
                    int.TryParse(env.AuthLevelID, out id);
                    DirectPrint rpt = new DirectPrint();
                    rpt.ResultEntryDirectPrint(drData["ACCESSION_NO"].ToString(), id);
                }
                //initFirst();
                result.RISExamresult.EMP_ID = env.UserID;
                result.RISExamresult.DATETIME_FROM = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
                result.RISExamresult.DATETIME_END = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
                result.RISExamresult.MODE = 3;
                result.RISExamresult.HN = txtDemo_HN.EditValue.ToString();
                result.RISExamresult.STATUS = "N";

                DataTable _dtt = new DataTable();
                _dtt = result.GetWorkList();

                DataRow[] drAcc = _dtt.Select("ACCESSION_NO = '" + txtDemo_AccNo.Text + "'");
                if (drAcc.Length > 0)
                {
                    SelectThisCase(drAcc[0], false);
                }

                btnReprint.Enabled = true;
            }
        }
        private void iSaveResultPrelim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Biopsy
            if (xtraTabControl1.SelectedTabPage == pageBiopsy)
            {
                if (CheckSpaceMamo())
                {
                    return;
                }
                ProcessGetMISBiopsyresult geBio = new ProcessGetMISBiopsyresult();
                geBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                geBio.Invoke();
                if (geBio.Result.Tables[0].Rows.Count > 0)
                {
                    string _id = msg.ShowAlert("UID4002", new GBLEnvVariable().CurrentLanguageID);
                    if (_id == "2")
                    {
                        UpdateDataBiopsy("P");
                    }
                    else
                    {
                        return;
                    }
                    GenText();
                    rtPad.Text = BioText;
                }
                else
                {
                    if (CheckSpaceMamo())
                    {
                        return;
                    }
                    string _id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);
                    if (_id == "2")
                    {
                        SaveDataBiopsy("P");
                    }
                    else
                    {
                        return;
                    }
                    GenText();
                    rtPad.Text = BioText;
                }
            }
            #endregion
            int unit_id = 1;
            DataRow[] drEx = order.Ris_Exam().Select("EXAM_ID=" + drData["EXAM_ID"].ToString());
            if (drEx.Length > 0)
            {
                unit_id = Convert.ToInt32(drEx[0]["UNIT_ID"].ToString());
            }
            string uid = "";
            if (xtraTabControl1.SelectedTabPage == pageBiopsy)
            {

                Serverity = txtAssessment.Tag.ToString();
                uid = "2";
            }
            else
            {
                ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
                prc.RISExamresultseverity.UNIT_ID = unit_id;
                prc.Invoke();
                DataSet dsSeverity = prc.Result;
                RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Severity_Clicks);
                lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
                lv.AddColumn("SEVERITY_NAME", "SEVERITY_NAME", true, true);
                lv.AddColumn("SEVERITY_LABEL", "SEVERITY_LABEL", true, true);
                lv.Text = "Severity List";
                lv.Data = dsSeverity.Tables[0];

                Size ss = new Size(510, 300);
                lv.Size = ss;
                lv.StartPosition = FormStartPosition.CenterScreen;
                // lv.PreviewFieldName = "report";
                // lv.ShowDescription = true;
                retValue = null;
                //lv.ShowBox();

                //if (retValue == null)
                //    return;


                if (rtPad.Text.Length < rad.MINIMIZE_CHARACTER)
                {
                    msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID, rad.MINIMIZE_CHARACTER);
                    return;
                }
                uid = string.IsNullOrEmpty(drData["MERGE"].ToString()) ? "UID1129" : drData["MERGE"].ToString().ToLower() == "spt" ? "UID1129" : "UID1132";
                uid = msg.ShowAlert(uid, env.CurrentLanguageID);
                //Serverity = retValue[0].ToString();
            }
            if (uid == "2" || uid == "3")
            {
                //FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
                //float size = 10;
                //Font font = new Font(fontFamily, size);
                //rtPad.SelectAll();
                //rtPad.SelectionFont = font;
                //rtPad.DeselectAll();

                string prelimName = env.FirstNameEng + " " + env.LastNameEng + ",M.D.(" + env.UserUID + ")";
                if (env.AuthLevelID == "3")
                {
                    prelimName = prelimName + "\r\n Radiologist";
                }

                string rtf = rtPad.Document.RtfText;
                string txt = rtPad.Document.Text;
                string html = "";

                //RichTextBox rt = new RichTextBox();
                //rt.Rtf = rtPad.Rtf;
                //rt.AppendText("\r\n\r\n" + prelimName);
                //rt.Font = new Font(rad.FONT_FACE, rad.FONT_SIZE);
                //RIS.Operational.Translator.TransRtf tran = new RIS.Operational.Translator.TransRtf(rt.Rtf);
                //html = tran.Translator();

                #region สร้าง DataTable เพื่อสร้าง HL7 Message.
                DataTable dtMSGF = new DataTable();
                dtMSGF.Columns.Add("HN");
                dtMSGF.Columns.Add("FNAME");
                dtMSGF.Columns.Add("MNAME");
                dtMSGF.Columns.Add("LNAME");
                dtMSGF.Columns.Add("THFNAME");
                dtMSGF.Columns.Add("THMNAME");
                dtMSGF.Columns.Add("GENDER");
                dtMSGF.Columns.Add("DOB");
                dtMSGF.Columns.Add("PHONE");
                dtMSGF.Columns.Add("ADDRESS");
                dtMSGF.Columns.Add("ACCESSION_NO");
                dtMSGF.Columns.Add("STATUS");
                dtMSGF.Columns.Add("EXAM_ID");
                dtMSGF.Columns.Add("EXAM_NAME");
                dtMSGF.Columns.Add("HL7TXT");
                dtMSGF.Columns.Add("ORDNO");
                #endregion

                DataTable tmpMSG = dtMSGF.Clone();

                #region Insert MainReport.
                DataRow row = tmpMSG.NewRow();
                row["HN"] = txtDemo_HN.EditValue.ToString();
                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                row["DOB"] = dttDemo.Rows[0]["DOB"];
                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                row["ADDRESS"] = txtDemo_Addr.EditValue.ToString();
                row["ACCESSION_NO"] = drData["ACCESSION_NO"].ToString();
                row["STATUS"] = "P";
                row["EXAM_ID"] = drData["EXAM_UID"].ToString();
                row["EXAM_NAME"] = drData["EXAM_NAME"].ToString();
                row["HL7TXT"] = html;
                row["ORDNO"] = drData["ORDER_ID"].ToString();
                tmpMSG.Rows.Add(row);
                tmpMSG.AcceptChanges();

                GenerateORU oru = new GenerateORU();
                DataTable dttPACS = oru.createMessage(tmpMSG);
                string hl7 = string.Empty;
                if (dttPACS.Rows.Count > 0)
                    hl7 = dttPACS.Rows[0]["HL7_TXT"].ToString();
                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                result.RISExamresult.ORDER_ID = Convert.ToInt32(drData["ORDER_ID"].ToString());
                result.RISExamresult.EXAM_ID = Convert.ToInt32(drData["EXAM_ID"].ToString());
                result.RISExamresult.RESULT_TEXT_HTML = html;
                result.RISExamresult.RESULT_TEXT_PLAIN = txt;
                result.RISExamresult.RESULT_TEXT_RTF = rtf;
                result.RISExamresult.RESULT_STATUS = "P";
                result.RISExamresult.HL7_TEXT = hl7;
                result.RISExamresult.HL7_SEND = "N";
                result.RISExamresult.RELEASED_BY = env.UserID;
                result.RISExamresult.FINALIZED_BY = 0;
                result.RISExamresult.CREATED_BY = env.UserID;
                result.RISExamresult.ORG_ID = env.OrgID;
                result.RISExamresult.SEVERITY_ID = 1; //Convert.ToInt32(Serverity);
                result.Reporting();
                #endregion

                #region Merege Data.
                if (!string.IsNullOrEmpty(drData["MERGE"].ToString()))
                {
                    if (drData["MERGE"].ToString().ToLower() != "spt")
                    {

                        result.RISExamresult.MERGE = drData["MERGE"].ToString();
                        result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                        result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();
                        DataTable dtt = result.GetMergeData();

                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                            {

                                tmpMSG = new DataTable();
                                tmpMSG = dtMSGF.Clone();
                                row = tmpMSG.NewRow();
                                row["HN"] = txtDemo_HN.EditValue.ToString();
                                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                                row["DOB"] = dttDemo.Rows[0]["DOB"];
                                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                                row["ADDRESS"] = txtDemo_Addr.EditValue.ToString();
                                row["ACCESSION_NO"] = dr["ACCESSION_NO"].ToString();
                                row["STATUS"] = "P";
                                row["EXAM_ID"] = dr["EXAM_UID"].ToString();
                                row["EXAM_NAME"] = dr["EXAM_NAME"].ToString();
                                row["HL7TXT"] = html;
                                row["ORDNO"] = drData["ORDER_ID"].ToString();
                                tmpMSG.Rows.Add(row);
                                tmpMSG.AcceptChanges();

                                DataTable tmpPACS = oru.createMessage(tmpMSG);
                                if (tmpPACS.Rows.Count > 0)
                                    hl7 = tmpPACS.Rows[0]["HL7_TXT"].ToString();
                                result.RISExamresult.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                result.RISExamresult.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"].ToString());
                                result.RISExamresult.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                                result.RISExamresult.HL7_SEND = "N";
                                result.RISExamresult.HL7_TEXT = hl7;
                                result.RISExamresult.SEVERITY_ID = Convert.ToInt32(retValue[0].ToString());
                                result.Reporting();

                                row = dttPACS.NewRow();
                                row["ACCESSION_NO"] = result.RISExamresult.ACCESSION_NO;
                                row["HL7_TXT"] = hl7;
                                dttPACS.Rows.Add(row);
                                dttPACS.AcceptChanges();
                            }
                        }//end looping
                    }//end if check 'spt'
                }//end if check mere null 
                #endregion

                SendToPacs send = new SendToPacs();
                send.Set_ORUByAccessionNoQueue(accession_no);

                if (uid == "3")
                {
                    int id = 0;
                    int.TryParse(env.AuthLevelID, out id);
                    DirectPrint rpt = new DirectPrint();
                    rpt.ResultEntryDirectPrint(drData["ACCESSION_NO"].ToString(), id);
                }
                UnLockCase(true);
                initFirst();

                btnReprint.Enabled = true;
            }
        }
        private void iSaveResultFinal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Biopsy
            if (xtraTabControl1.SelectedTabPage == pageBiopsy)
            {
                ProcessGetMISBiopsyresult geBio = new ProcessGetMISBiopsyresult();
                geBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                geBio.Invoke();
                if (geBio.Result.Tables[0].Rows.Count > 0)
                {
                    if (CheckSpaceMamo())
                    {
                        return;
                    }
                    string _id = msg.ShowAlert("UID4002", new GBLEnvVariable().CurrentLanguageID);
                    if (_id == "2")
                    {
                        UpdateDataBiopsy("F");
                    }
                    else
                    {
                        return;
                    }
                    GenText();
                    rtPad.Text = BioText;
                }
                else
                {
                    if (CheckSpaceMamo())
                    {
                        return;
                    }
                    string _id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);
                    if (_id == "2")
                    {
                        SaveDataBiopsy("F");
                    }
                    else
                    {
                        return;
                    }
                    GenText();
                    rtPad.Text = BioText;
                }
            }
            #endregion

            int unit_id = 1;
            DataRow[] drEx = order.Ris_Exam().Select("EXAM_ID=" + drData["EXAM_ID"].ToString());
            if (drEx.Length > 0)
            {
                unit_id = Convert.ToInt32(drEx[0]["UNIT_ID"].ToString());
            }
            string uid = "";
            if (xtraTabControl1.SelectedTabPage == pageBiopsy)
            {

                Serverity = txtAssessment.Tag.ToString();
                uid = "2";

            }
            else
            {
                ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
                prc.RISExamresultseverity.UNIT_ID = unit_id;
                prc.Invoke();
                DataSet dsSeverity = prc.Result;
                RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
                lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Severity_Clicks);
                lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
                lv.AddColumn("SEVERITY_NAME", "SEVERITY_NAME", true, true);
                lv.AddColumn("SEVERITY_LABEL", "SEVERITY_LABEL", true, true);
                lv.Text = "Severity List";
                lv.Data = dsSeverity.Tables[0];

                Size ss = new Size(510, 300);
                lv.Size = ss;
                lv.StartPosition = FormStartPosition.CenterScreen;
                // lv.PreviewFieldName = "report";
                // lv.ShowDescription = true;
                retValue = null;
                //lv.ShowBox();

                //if (retValue == null)
                //    return;

                if (rtPad.Text.Length < rad.MINIMIZE_CHARACTER)
                {
                    msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID);
                    return;
                }
                uid = string.IsNullOrEmpty(drData["MERGE"].ToString()) ? "UID1130" : drData["MERGE"].ToString().ToLower() == "spt" ? "UID1130" : "UID1133";
                uid = msg.ShowAlert(uid, env.CurrentLanguageID);
                //Serverity = retValue[0].ToString();
            }
            if (uid == "2" || uid == "3")
            {

                string rtf = rtPad.Document.RtfText;
                string txt = rtPad.Document.Text;
                string html = "";

                string finalName = env.FirstNameEng + " " + env.LastNameEng + ",M.D.(" + env.UserUID + ")";
                int finalID = env.UserID;
                if (env.AuthLevelID != "3")
                {
                    RadioFinal radio = new RadioFinal();
                    if (DialogResult.Cancel == radio.ShowDialog())
                        return;
                    finalID = radio.FinalizeID;
                    finalName = radio.FinalizedName;
                    finalName = radio.FinalizedName + ",M.D.(" + radio.Finalized_UID + ")";
                    radio.Dispose();
                }
                //RichTextBox rt = new RichTextBox();
                //rt.Rtf = rtPad.Rtf;
                //rt.AppendText("\r\n\r\n" + finalName);
                //if (env.AuthLevelID == "3")
                //    rt.AppendText("\r\n Radiologist");
                //rt.Font = new Font(rad.FONT_FACE, rad.FONT_SIZE);
                //RIS.Operational.Translator.TransRtf tran = new RIS.Operational.Translator.TransRtf(rt.Rtf);
                //string html = tran.Translator();

                #region สร้าง DataTable เพื่อสร้าง HL7 Message.
                DataTable dtMSGF = new DataTable();
                dtMSGF.Columns.Add("HN");
                dtMSGF.Columns.Add("FNAME");
                dtMSGF.Columns.Add("MNAME");
                dtMSGF.Columns.Add("LNAME");
                dtMSGF.Columns.Add("THFNAME");
                dtMSGF.Columns.Add("THMNAME");
                dtMSGF.Columns.Add("GENDER");
                dtMSGF.Columns.Add("DOB");
                dtMSGF.Columns.Add("PHONE");
                dtMSGF.Columns.Add("ADDRESS");
                dtMSGF.Columns.Add("ACCESSION_NO");
                dtMSGF.Columns.Add("STATUS");
                dtMSGF.Columns.Add("EXAM_ID");
                dtMSGF.Columns.Add("EXAM_NAME");
                dtMSGF.Columns.Add("HL7TXT");
                dtMSGF.Columns.Add("ORDNO");
                #endregion

                DataTable tmpMSG = dtMSGF.Clone();

                #region Insert MainReport.
                DataRow row = tmpMSG.NewRow();
                row["HN"] = txtDemo_HN.EditValue.ToString();
                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                row["DOB"] = dttDemo.Rows[0]["DOB"];
                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                row["ADDRESS"] = txtDemo_Addr.EditValue.ToString();
                row["ACCESSION_NO"] = drData["ACCESSION_NO"].ToString();
                row["STATUS"] = "F";
                row["EXAM_ID"] = drData["EXAM_UID"].ToString();
                row["EXAM_NAME"] = drData["EXAM_NAME"].ToString();
                row["HL7TXT"] = html;
                row["ORDNO"] = drData["ORDER_ID"].ToString();
                tmpMSG.Rows.Add(row);
                tmpMSG.AcceptChanges();

                GenerateORU oru = new GenerateORU();
                DataTable dttPACS = oru.createMessage(tmpMSG);
                string hl7 = string.Empty;
                if (dttPACS.Rows.Count > 0)
                    hl7 = dttPACS.Rows[0]["HL7_TXT"].ToString();
                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                result.RISExamresult.ORDER_ID = Convert.ToInt32(drData["ORDER_ID"].ToString());
                result.RISExamresult.EXAM_ID = Convert.ToInt32(drData["EXAM_ID"].ToString());
                result.RISExamresult.RESULT_TEXT_HTML = html;
                result.RISExamresult.RESULT_TEXT_PLAIN = txt;
                result.RISExamresult.RESULT_TEXT_RTF = rtf;
                result.RISExamresult.RESULT_STATUS = "F";
                result.RISExamresult.HL7_TEXT = hl7;
                result.RISExamresult.HL7_SEND = "N";
                result.RISExamresult.RELEASED_BY = 0;
                result.RISExamresult.FINALIZED_BY = finalID;
                result.RISExamresult.CREATED_BY = env.UserID;
                result.RISExamresult.ORG_ID = env.OrgID;
                result.RISExamresult.SEVERITY_ID = 1; //Convert.ToInt32(Serverity);
                result.Reporting();
                #endregion

                #region Merege Data.
                if (!string.IsNullOrEmpty(drData["MERGE"].ToString()))
                {
                    if (drData["MERGE"].ToString().ToLower() != "spt")
                    {

                        // result.RISExamresult.ACCESSION_NO = drData["MERGE"].ToString().ToLower() == "mrr" ? drData["ACCESSION_NO"].ToString() : drData["MERGE_WITH"].ToString();
                        result.RISExamresult.MERGE = drData["MERGE"].ToString();
                        result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                        result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();
                        DataTable dtt = result.GetMergeData();

                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                            {

                                tmpMSG = new DataTable();
                                tmpMSG = dtMSGF.Clone();
                                row = tmpMSG.NewRow();
                                row["HN"] = txtDemo_HN.EditValue.ToString();
                                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                                row["DOB"] = dttDemo.Rows[0]["DOB"];
                                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                                row["ADDRESS"] = txtDemo_Addr.EditValue.ToString();
                                row["ACCESSION_NO"] = dr["ACCESSION_NO"].ToString();
                                row["STATUS"] = "F";
                                row["EXAM_ID"] = dr["EXAM_UID"].ToString();
                                row["EXAM_NAME"] = dr["EXAM_NAME"].ToString();
                                row["HL7TXT"] = html;
                                row["ORDNO"] = drData["ORDER_ID"].ToString();
                                tmpMSG.Rows.Add(row);
                                tmpMSG.AcceptChanges();

                                DataTable tmpPACS = oru.createMessage(tmpMSG);
                                if (tmpPACS.Rows.Count > 0)
                                    hl7 = tmpPACS.Rows[0]["HL7_TXT"].ToString();
                                result.RISExamresult.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                result.RISExamresult.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"].ToString());
                                result.RISExamresult.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                                result.RISExamresult.HL7_SEND = "N";
                                result.RISExamresult.HL7_TEXT = hl7;
                                result.Reporting();

                                row = dttPACS.NewRow();
                                row["ACCESSION_NO"] = result.RISExamresult.ACCESSION_NO;
                                row["HL7_TXT"] = hl7;
                                dttPACS.Rows.Add(row);
                                dttPACS.AcceptChanges();
                            }
                        }//end looping
                    }//end if check 'spt'
                }//end if check mere null 
                #endregion

                SendToPacs send = new SendToPacs();
                send.Set_ORUByAccessionNoQueue(accession_no);

                if (uid == "3")
                {
                    int id = 0;
                    int.TryParse(env.AuthLevelID, out id);
                    DirectPrint rpt = new DirectPrint();
                    rpt.ResultEntryDirectPrint(drData["ACCESSION_NO"].ToString(), id);
                }
                UnLockCase(true);
                initFirst();
                btnReprint.Enabled = true;
            }
        }

        private void printResultEntry(string AccNO, int ID)
        {
            DirectPrint rpt = new DirectPrint();
            rpt.ResultEntryDirectPrint(AccNO, ID);
        }
        #endregion

        #region Structure
        private DataTable dtTempMamo;
        private string pointRL = "";

        private void iBiopsy_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (drData == null)
            {
                EnableItem(false);
                return;
            }
            DataRow[] drEx = order.Ris_Exam().Select("EXAM_ID=" + drData["EXAM_ID"].ToString());
            if (drEx.Length < 0)
            {
                return;
            }
            if (Convert.ToInt32(drEx[0]["UNIT_ID"]) != 3)
            {
                msg.ShowAlert("UID4019", env.CurrentLanguageID);
                //initFirst();
                ribbonControl1.SelectedPage = pageEdit;
                return;
            }
            accession_noMamo = drData["ACCESSION_NO"].ToString();
            btnLABData.Focus();
            xtraTabControl1.SelectedTabPage = pageBiopsy;
            initDefaultControlStart();
            initDefaultLocation();

            EnableItem(true);
            BindData();
        }

        #region Look UP

        private void btnLABData_Click(object sender, EventArgs e)
        {
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
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            rtbLAB2.Text = retValue[3];
        }
        private void btnLesion_Click(object sender, EventArgs e)
        {
            ProcessGetMISLesiontype geLe = new ProcessGetMISLesiontype();
            geLe.Invoke();


            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnLesion_Clicks);
            lv.AddColumn("LESION_TYPE_ID", "Lesion ID", false, true);
            lv.AddColumn("LESION_TYPE_UID", "Lesion Code", false, true);
            lv.AddColumn("LESION_TYPE_DESC", "Lesion", true, true);
            lv.Text = "Lesion Search";

            lv.Data = geLe.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnLesion_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtLesion.Tag = retValue[0];
            txtLesion.Text = retValue[2];
        }

        private void btnAssessment_Click(object sender, EventArgs e)
        {
            ProcessGetMISAsessmenttype geAs = new ProcessGetMISAsessmenttype();
            geAs.Invoke();

            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnAssessment_Clicks);
            lv.AddColumn("ASESSMENT_TYPE_ID", "Assessment ID", false, true);
            lv.AddColumn("ASESSMENT_TYPE_UID", "Assessment Code", false, true);
            lv.AddColumn("ASESSMENT_TYPE_DESC", "Assessment", true, true);
            lv.Text = "Assessment Search";

            lv.Data = geAs.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnAssessment_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtAssessment.Tag = retValue[0];
            txtAssessment.Text = retValue[2];
        }

        private void btnTech_Click(object sender, EventArgs e)
        {
            ProcessGetMISTechniquetype geTe = new ProcessGetMISTechniquetype();
            geTe.Invoke();

            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnTech_Clicks);
            lv.AddColumn("TECHNIQUE_TYPE_ID", "Technique ID", false, true);
            lv.AddColumn("TECHNIQUE_TYPE_UID", "Technique Code", false, true);
            lv.AddColumn("TECHNIQUE_TYPE_DESC", "Technique", true, true);
            lv.Text = "Technique Search";

            lv.Data = geTe.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnTech_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtTechnique.Tag = retValue[0];
            txtTechnique.Text = retValue[2];
        }

        #endregion
        private void BindData()
        {
            ProcessGetHISRegistration his = new ProcessGetHISRegistration(drData["HN"].ToString());
            his.Invoke();
            DataSet ds = new DataSet();
            ds = his.Result;
            foreach (DataRow drHis in his.Result.Tables[0].Rows)
            {
                txtHN.Text = drHis["HN"].ToString();
                cmbGender.SelectedIndex = drHis["GENDER"].ToString() == "M" ? 0 : 1;
                int dt = DateTime.Today.Year - Convert.ToDateTime(drHis["DOB"]).Year;
                txtAGE.Text = dt.ToString();
                txtPhone.Text = drHis["PHONE1"].ToString();
                txtName.Text = drHis["FNAME"].ToString() + " " + drHis["LNAME"].ToString();
            }
            ProcessGetMISAsessmenttype geAs = new ProcessGetMISAsessmenttype();
            geAs.Invoke();
            ProcessGetMISLesiontype geLe = new ProcessGetMISLesiontype();
            geLe.Invoke();
            ProcessGetMISTechniquetype geTech = new ProcessGetMISTechniquetype();
            geTech.Invoke();


            ProcessGetMISBiopsyresult geBio = new ProcessGetMISBiopsyresult();
            geBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
            geBio.Invoke();
            if (drData["Status"].ToString() != "F")
            {
                if (geBio.Result.Tables[0].Rows.Count > 0)
                {
                    dtTempMamo = new DataTable();
                    dtTempMamo.Columns.Add("LOC_NO_R");
                    dtTempMamo.Columns.Add("LOC_NO_L");
                    dtTempMamo.Columns.Add("DEPTH_TYPE_R");
                    dtTempMamo.Columns.Add("DEPTH_TYPE_L");
                    dtTempMamo.Columns.Add("TISSUE");
                    dtTempMamo.Columns.Add("WIDTH");
                    dtTempMamo.Columns.Add("LENGTH");
                    dtTempMamo.Columns.Add("DEPTH");

                    dtTempMamo.AcceptChanges();

                    DataTable dtt = geBio.Result.Tables[0];
                    foreach (DataRow drBind in dtt.Rows)
                    {

                        DataRow DrNew = dtTempMamo.NewRow();
                        DrNew["LOC_NO_R"] = drBind["LOC_NO_R"];
                        DrNew["LOC_NO_L"] = drBind["LOC_NO_L"];
                        DrNew["DEPTH_TYPE_R"] = drBind["DEPTH_TYPE_R"];
                        DrNew["DEPTH_TYPE_L"] = drBind["DEPTH_TYPE_L"];
                        DrNew["TISSUE"] = drBind["TISSUE_TYPE"];
                        DrNew["WIDTH"] = drBind["WIDTH"];
                        DrNew["LENGTH"] = drBind["LENGTH"];
                        DrNew["DEPTH"] = drBind["DEPTH"];

                        dtTempMamo.Rows.Add(DrNew);

                        switch (drBind["PROCEDURE_TYPE"].ToString())
                        {
                            case "B": rdgProceduce.SelectedIndex = 0; break;
                            case "F": rdgProceduce.SelectedIndex = 1; break;
                            case "L": rdgProceduce.SelectedIndex = 2; break;
                            case "N": rdgProceduce.SelectedIndex = 3; break;
                        }
                        speOncore.Value = Convert.ToInt32(drBind["NO_OF_CORE"]);
                        speCalcium.Value = Convert.ToInt32(drBind["CALCIUM_PCS"]);
                        switch (drBind["IS_SATISFACTORY"].ToString())
                        {
                            case "Y": rdgSatisfact.SelectedIndex = 0; break;
                            case "N": rdgSatisfact.SelectedIndex = 1; break;
                        }
                        switch (drBind["IS_SURGERY"].ToString())
                        {
                            case "Y": rdgSurgery.SelectedIndex = 0; break;
                            case "N": rdgSurgery.SelectedIndex = 1; break;
                        }
                        memComment.Text = drBind["COMMENTS"].ToString();
                        rtbLAB2.Text = drBind["LAB_DATA"].ToString();
                        switch (drBind["IS_PALPABLE"].ToString())
                        {
                            case "Y": rdgPalpable.SelectedIndex = 0; break;
                            case "N": rdgPalpable.SelectedIndex = 1; break;
                        }
                        DataRow[] drAS = geAs.Result.Tables[0].Select("ASESSMENT_TYPE_ID=" + drBind["ASESSMENT_TYPE_ID"].ToString());
                        if (drAS.Length > 0)
                        {
                            txtAssessment.Tag = drAS[0]["ASESSMENT_TYPE_ID"].ToString();
                            txtAssessment.Text = drAS[0]["ASESSMENT_TYPE_DESC"].ToString();
                        }
                        DataRow[] drTech = geTech.Result.Tables[0].Select("TECHNIQUE_TYPE_ID=" + drBind["TECHNIQUE_TYPE_ID"].ToString());
                        if (drTech.Length > 0)
                        {
                            txtTechnique.Tag = drTech[0]["TECHNIQUE_TYPE_ID"].ToString();
                            txtTechnique.Text = drTech[0]["TECHNIQUE_TYPE_DESC"].ToString();
                        }
                        DataRow[] drLe = geLe.Result.Tables[0].Select("LESION_TYPE_ID=" + drBind["LESION_TYPE_ID"].ToString());
                        if (drLe.Length > 0)
                        {
                            txtLesion.Tag = drLe[0]["LESION_TYPE_ID"].ToString();
                            txtLesion.Text = drLe[0]["LESION_TYPE_DESC"].ToString();
                        }

                    }
                    grdMamo.DataSource = dtTempMamo;
                }
                DataTable dtShow = (DataTable)grdMamo.DataSource;
                if (dtShow == null)
                {
                    return;
                }
                if (dtShow.Rows.Count > 0)
                {
                    BindGridMamo();
                }
            }
        }
        private void initDefaultControlStart()
        {

            cmbGender.Properties.Items.Clear();
            cmbGender.Properties.Items.Add("Male");
            cmbGender.Properties.Items.Add("Female");
            cmbGender.SelectedIndex = 0;

            rdgTissue.SelectedIndex = 2;
            rdgProceduce.SelectedIndex = 3;
            rdgDeptLeft.SelectedIndex = 3;
            rdgDeptRight.SelectedIndex = 3;

            rtbLAB2.Text = "";
            speOncore.Text = "";
            speCalcium.Text = "";
            memComment.Text = "";
            txtLesion.Text = "";
            txtAssessment.Text = "";
            txtTechnique.Text = "";
            rdgSatisfact.SelectedIndex = 0;
            rdgSurgery.SelectedIndex = 0;
            rdgPalpable.SelectedIndex = 0;

            rdgDeptRight.Enabled = false;
            rdgDeptLeft.Enabled = false;

            dtTempMamo = new DataTable();
            dtTempMamo.Columns.Add("LOC_NO_R");
            dtTempMamo.Columns.Add("LOC_NO_L");
            dtTempMamo.Columns.Add("DEPTH_TYPE_R");
            dtTempMamo.Columns.Add("DEPTH_TYPE_L");
            dtTempMamo.Columns.Add("TISSUE");
            dtTempMamo.Columns.Add("WIDTH");
            dtTempMamo.Columns.Add("LENGTH");
            dtTempMamo.Columns.Add("DEPTH");

            dtTempMamo.AcceptChanges();
            grdMamo.DataSource = dtTempMamo;

        }
        private void initDefaultLocation()
        {
            #region LOC_NO_R
            rdR0.Checked = false;
            rdR1.Checked = false;
            rdR2.Checked = false;
            rdR3.Checked = false;
            rdR4.Checked = false;
            rdR5.Checked = false;
            rdR6.Checked = false;
            rdR7.Checked = false;
            rdR8.Checked = false;
            rdR9.Checked = false;
            rdR10.Checked = false;
            rdR11.Checked = false;
            rdR12.Checked = false;
            rdR13.Checked = false;
            #endregion
            #region LOC_NO_L
            rdL0.Checked = false;
            rdL1.Checked = false;
            rdL2.Checked = false;
            rdL3.Checked = false;
            rdL4.Checked = false;
            rdL5.Checked = false;
            rdL6.Checked = false;
            rdL7.Checked = false;
            rdL8.Checked = false;
            rdL9.Checked = false;
            rdL10.Checked = false;
            rdL11.Checked = false;
            rdL12.Checked = false;
            rdL13.Checked = false;
            #endregion

            rdgDeptLeft.SelectedIndex = 3;
            rdgDeptRight.SelectedIndex = 3;
            rdgTissue.SelectedIndex = 2;

            speWidth.Value = 0;
            speLength.Value = 0;
            speDepth.Value = 0;
        }
        private bool CheckSpaceMamo()
        {
            DataTable dtCheck = (DataTable)grdMamo.DataSource;
            if (txtLesion.Text == string.Empty)
            {
                msg.ShowAlert("UID4013", env.CurrentLanguageID);
                return true;
            }
            else if (txtAssessment.Text == string.Empty)
            {
                msg.ShowAlert("UID4014", env.CurrentLanguageID);
                return true;
            }
            else if (txtTechnique.Text == string.Empty)
            {
                msg.ShowAlert("UID4015", env.CurrentLanguageID);
                return true;
            }
            else if (dtCheck.Rows.Count <= 0)
            {
                msg.ShowAlert("UID4020", env.CurrentLanguageID);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EnableItem(bool flag)
        {
            lcgDetail.Enabled = flag;
            lcgLession.Enabled = flag;
            lcgLocation.Enabled = flag;
            lcgProceduce.Enabled = flag;

            txtHN.Enabled = false;
            txtName.Enabled = false;
            txtAGE.Enabled = false;
            cmbGender.Enabled = false;
            txtPhone.Enabled = false;

            rtbLAB2.ReadOnly = true;

        }
        private void GetLapData()
        {

        }
        private void SaveDataBiopsy(string status)
        {
            CheckSpaceMamo();

            #region MIS_BIOPSYRESULT
            /*---------------Table MIS_BIOPSYRESULT-----------*/
            ProcessAddMISBiopsyresult addBi0 = new ProcessAddMISBiopsyresult();

            ProcessGetMISBiopsyresult geBio = new ProcessGetMISBiopsyresult();
            geBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
            geBio.Invoke();

            DataTable dtSM = (DataTable)grdMamo.DataSource;
            for (int i = 0; i < dtSM.Rows.Count; i++)
            {
                int BID = i + 1;
                addBi0.MISBiopsyresult.BIOPSY_RESULT_ID = (byte)BID;
                addBi0.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                addBi0.MISBiopsyresult.RESULT_DT = DateTime.Now;
                addBi0.MISBiopsyresult.RADIOLOGIST_ID = env.UserID;

                if (string.IsNullOrEmpty(dtSM.Rows[i]["LOC_NO_L"].ToString()))
                    addBi0.MISBiopsyresult.LOC_NO_L = "N";
                else
                    addBi0.MISBiopsyresult.LOC_NO_L = dtSM.Rows[i]["LOC_NO_L"].ToString();
                if (string.IsNullOrEmpty(dtSM.Rows[i]["LOC_NO_R"].ToString()))
                    addBi0.MISBiopsyresult.LOC_NO_R = "N";
                else
                    addBi0.MISBiopsyresult.LOC_NO_R = dtSM.Rows[i]["LOC_NO_R"].ToString();
                if (string.IsNullOrEmpty(dtSM.Rows[i]["DEPTH_TYPE_L"].ToString()))
                    addBi0.MISBiopsyresult.DEPTH_TYPE_L = "N";
                else
                    addBi0.MISBiopsyresult.DEPTH_TYPE_L = dtSM.Rows[i]["DEPTH_TYPE_L"].ToString();
                if (string.IsNullOrEmpty(dtSM.Rows[i]["DEPTH_TYPE_R"].ToString()))
                    addBi0.MISBiopsyresult.DEPTH_TYPE_R = "N";
                else
                    addBi0.MISBiopsyresult.DEPTH_TYPE_R = dtSM.Rows[i]["DEPTH_TYPE_R"].ToString();

                addBi0.MISBiopsyresult.TISSUE_TYPE = dtSM.Rows[i]["TISSUE"].ToString();
                addBi0.MISBiopsyresult.WIDTH = dtSM.Rows[i]["WIDTH"].ToString();
                addBi0.MISBiopsyresult.LENGTH = dtSM.Rows[i]["LENGTH"].ToString();
                addBi0.MISBiopsyresult.DEPTH = dtSM.Rows[i]["DEPTH"].ToString();


                switch (rdgProceduce.SelectedIndex)
                {
                    case 0: addBi0.MISBiopsyresult.PROCEDURE_TYPE = "B"; break;
                    case 1: addBi0.MISBiopsyresult.PROCEDURE_TYPE = "F"; break;
                    case 2: addBi0.MISBiopsyresult.PROCEDURE_TYPE = "L"; break;
                    case 3: addBi0.MISBiopsyresult.PROCEDURE_TYPE = "N"; break;
                }
                addBi0.MISBiopsyresult.NO_OF_CORE = (byte)speOncore.Value;
                addBi0.MISBiopsyresult.CALCIUM_PCS = (byte)speCalcium.Value;
                switch (rdgSatisfact.SelectedIndex)
                {
                    case 0: addBi0.MISBiopsyresult.IS_SATISFACTORY = "Y"; break;
                    case 1: addBi0.MISBiopsyresult.IS_SATISFACTORY = "N"; break; ;
                }
                switch (rdgSurgery.SelectedIndex)
                {
                    case 0: addBi0.MISBiopsyresult.IS_SURGERY = "Y"; break;
                    case 1: addBi0.MISBiopsyresult.IS_SURGERY = "N"; break; ;
                }
                addBi0.MISBiopsyresult.COMMENTS = memComment.Text;
                switch (rdgPalpable.SelectedIndex)
                {
                    case 0: addBi0.MISBiopsyresult.IS_PALPABLE = "Y"; break;
                    case 1: addBi0.MISBiopsyresult.IS_PALPABLE = "N"; break; ;
                }

                addBi0.MISBiopsyresult.LESION_TYPE_ID = Convert.ToInt32(txtLesion.Tag);
                addBi0.MISBiopsyresult.ASESSMENT_TYPE_ID = Convert.ToInt32(txtAssessment.Tag);
                addBi0.MISBiopsyresult.TECHNIQUE_TYPE_ID = Convert.ToInt32(txtTechnique.Tag);
                addBi0.MISBiopsyresult.LAB_DATA = rtbLAB2.Text;
                addBi0.MISBiopsyresult.ORG_ID = env.OrgID;
                addBi0.MISBiopsyresult.CREATED_BY = env.UserID;
                addBi0.MISBiopsyresult.LAST_MODIFIED_BY = env.UserID;
                addBi0.MISBiopsyresult.STATUS = status;
                addBi0.Invoke();
            }

            /*----------------------orderdtl--------------------------*/
            //addBi0.MISBiopsyresult.STATUS = status;
            //addBi0.MISBiopsyresult.ASSINGED_TO = env.UserID;
            ///*------------------------------------------------*/

            //addBi0.Invoke();
            #endregion
        }
        private void UpdateDataBiopsy(string status)
        {
            CheckSpaceMamo();
            ProcessUpdateMISBiopsyresult upBio = new ProcessUpdateMISBiopsyresult();
            ProcessDeleteMISBiopsyresult deBio = new ProcessDeleteMISBiopsyresult();
            ProcessGetMISBiopsyresult geBio = new ProcessGetMISBiopsyresult();
            geBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
            geBio.Invoke();
            DataTable dtgeBio2 = geBio.Result.Tables[0];

            DataTable dtSM = (DataTable)grdMamo.DataSource;

            for (int a = 0; a < dtgeBio2.Rows.Count; a++)
            {
                if (dtgeBio2.Rows.Count > dtSM.Rows.Count)
                {
                    deBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                    deBio.Invoke();
                }
            }
            geBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
            geBio.Invoke();
            DataTable dtgeBio = geBio.Result.Tables[0];
            for (int i = 0; i < dtSM.Rows.Count; i++)
            {

                int BID = i + 1;

                if (BID > dtgeBio.Rows.Count)
                {
                    #region SaveDataAdd

                    ProcessAddMISBiopsyresult adMIS = new ProcessAddMISBiopsyresult();
                    adMIS.MISBiopsyresult.BIOPSY_RESULT_ID = (byte)BID;
                    adMIS.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                    adMIS.MISBiopsyresult.RESULT_DT = DateTime.Now;
                    adMIS.MISBiopsyresult.RADIOLOGIST_ID = env.UserID;

                    if (string.IsNullOrEmpty(dtSM.Rows[i]["LOC_NO_L"].ToString()))
                        adMIS.MISBiopsyresult.LOC_NO_L = "N";
                    else
                        adMIS.MISBiopsyresult.LOC_NO_L = dtSM.Rows[i]["LOC_NO_L"].ToString();
                    if (string.IsNullOrEmpty(dtSM.Rows[i]["LOC_NO_R"].ToString()))
                        adMIS.MISBiopsyresult.LOC_NO_R = "N";
                    else
                        adMIS.MISBiopsyresult.LOC_NO_R = dtSM.Rows[i]["LOC_NO_R"].ToString();
                    if (string.IsNullOrEmpty(dtSM.Rows[i]["DEPTH_TYPE_L"].ToString()))
                        adMIS.MISBiopsyresult.DEPTH_TYPE_L = "N";
                    else
                        adMIS.MISBiopsyresult.DEPTH_TYPE_L = dtSM.Rows[i]["DEPTH_TYPE_L"].ToString();
                    if (string.IsNullOrEmpty(dtSM.Rows[i]["DEPTH_TYPE_R"].ToString()))
                        adMIS.MISBiopsyresult.DEPTH_TYPE_R = "N";
                    else
                        adMIS.MISBiopsyresult.DEPTH_TYPE_R = dtSM.Rows[i]["DEPTH_TYPE_R"].ToString();

                    adMIS.MISBiopsyresult.TISSUE_TYPE = dtSM.Rows[i]["TISSUE"].ToString();
                    adMIS.MISBiopsyresult.WIDTH = dtSM.Rows[i]["WIDTH"].ToString();
                    adMIS.MISBiopsyresult.LENGTH = dtSM.Rows[i]["LENGTH"].ToString();
                    adMIS.MISBiopsyresult.DEPTH = dtSM.Rows[i]["DEPTH"].ToString();

                    switch (rdgProceduce.SelectedIndex)
                    {
                        case 0: adMIS.MISBiopsyresult.PROCEDURE_TYPE = "B"; break;
                        case 1: adMIS.MISBiopsyresult.PROCEDURE_TYPE = "F"; break;
                        case 2: adMIS.MISBiopsyresult.PROCEDURE_TYPE = "L"; break;
                        case 3: adMIS.MISBiopsyresult.PROCEDURE_TYPE = "N"; break;
                    }
                    adMIS.MISBiopsyresult.NO_OF_CORE = (byte)speOncore.Value;
                    adMIS.MISBiopsyresult.CALCIUM_PCS = (byte)speCalcium.Value;
                    switch (rdgSatisfact.SelectedIndex)
                    {
                        case 0: adMIS.MISBiopsyresult.IS_SATISFACTORY = "Y"; break;
                        case 1: adMIS.MISBiopsyresult.IS_SATISFACTORY = "N"; break;
                    }
                    switch (rdgSurgery.SelectedIndex)
                    {
                        case 0: adMIS.MISBiopsyresult.IS_SURGERY = "Y"; break;
                        case 1: adMIS.MISBiopsyresult.IS_SURGERY = "N"; break;
                    }
                    adMIS.MISBiopsyresult.COMMENTS = memComment.Text;
                    switch (rdgPalpable.SelectedIndex)
                    {
                        case 0: adMIS.MISBiopsyresult.IS_PALPABLE = "Y"; break;
                        case 1: adMIS.MISBiopsyresult.IS_PALPABLE = "N"; break;
                    }

                    adMIS.MISBiopsyresult.LESION_TYPE_ID = Convert.ToInt32(txtLesion.Tag);
                    adMIS.MISBiopsyresult.ASESSMENT_TYPE_ID = Convert.ToInt32(txtAssessment.Tag);
                    adMIS.MISBiopsyresult.TECHNIQUE_TYPE_ID = Convert.ToInt32(txtTechnique.Tag);
                    adMIS.MISBiopsyresult.LAB_DATA = rtbLAB2.Text;
                    adMIS.MISBiopsyresult.ORG_ID = env.OrgID;
                    adMIS.MISBiopsyresult.CREATED_BY = env.UserID;
                    adMIS.MISBiopsyresult.LAST_MODIFIED_BY = env.UserID;

                    adMIS.MISBiopsyresult.STATUS = status;

                    adMIS.Invoke();

                    #endregion
                }
                else
                {
                    upBio.MISBiopsyresult.BIOPSY_RESULT_ID = (byte)BID;
                    upBio.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                    upBio.MISBiopsyresult.RESULT_DT = DateTime.Now;
                    upBio.MISBiopsyresult.RADIOLOGIST_ID = env.UserID;

                    #region Group Grid
                    if (string.IsNullOrEmpty(dtSM.Rows[i]["LOC_NO_L"].ToString()))
                        upBio.MISBiopsyresult.LOC_NO_L = "N";
                    else
                        upBio.MISBiopsyresult.LOC_NO_L = dtSM.Rows[i]["LOC_NO_L"].ToString();
                    if (string.IsNullOrEmpty(dtSM.Rows[i]["LOC_NO_R"].ToString()))
                        upBio.MISBiopsyresult.LOC_NO_R = "N";
                    else
                        upBio.MISBiopsyresult.LOC_NO_R = dtSM.Rows[i]["LOC_NO_R"].ToString();
                    if (string.IsNullOrEmpty(dtSM.Rows[i]["DEPTH_TYPE_L"].ToString()))
                        upBio.MISBiopsyresult.DEPTH_TYPE_L = "N";
                    else
                        upBio.MISBiopsyresult.DEPTH_TYPE_L = dtSM.Rows[i]["DEPTH_TYPE_L"].ToString();
                    if (string.IsNullOrEmpty(dtSM.Rows[i]["DEPTH_TYPE_R"].ToString()))
                        upBio.MISBiopsyresult.DEPTH_TYPE_R = "N";
                    else
                        upBio.MISBiopsyresult.DEPTH_TYPE_R = dtSM.Rows[i]["DEPTH_TYPE_R"].ToString();

                    upBio.MISBiopsyresult.TISSUE_TYPE = dtSM.Rows[i]["TISSUE"].ToString();
                    upBio.MISBiopsyresult.WIDTH = dtSM.Rows[i]["WIDTH"].ToString();
                    upBio.MISBiopsyresult.LENGTH = dtSM.Rows[i]["LENGTH"].ToString();
                    upBio.MISBiopsyresult.DEPTH = dtSM.Rows[i]["DEPTH"].ToString();
                    #endregion

                    switch (rdgProceduce.SelectedIndex)
                    {
                        case 0: upBio.MISBiopsyresult.PROCEDURE_TYPE = "B"; break;
                        case 1: upBio.MISBiopsyresult.PROCEDURE_TYPE = "F"; break;
                        case 2: upBio.MISBiopsyresult.PROCEDURE_TYPE = "L"; break;
                        case 3: upBio.MISBiopsyresult.PROCEDURE_TYPE = "N"; break;
                    }
                    upBio.MISBiopsyresult.NO_OF_CORE = (byte)speOncore.Value;
                    upBio.MISBiopsyresult.CALCIUM_PCS = (byte)speCalcium.Value;
                    switch (rdgSatisfact.SelectedIndex)
                    {
                        case 0: upBio.MISBiopsyresult.IS_SATISFACTORY = "Y"; break;
                        case 1: upBio.MISBiopsyresult.IS_SATISFACTORY = "N"; break;
                    }
                    switch (rdgSurgery.SelectedIndex)
                    {
                        case 0: upBio.MISBiopsyresult.IS_SURGERY = "Y"; break;
                        case 1: upBio.MISBiopsyresult.IS_SURGERY = "N"; break;
                    }
                    upBio.MISBiopsyresult.COMMENTS = memComment.Text;
                    switch (rdgPalpable.SelectedIndex)
                    {
                        case 0: upBio.MISBiopsyresult.IS_PALPABLE = "Y"; break;
                        case 1: upBio.MISBiopsyresult.IS_PALPABLE = "N"; break;
                    }

                    upBio.MISBiopsyresult.LESION_TYPE_ID = Convert.ToInt32(txtLesion.Tag);
                    upBio.MISBiopsyresult.ASESSMENT_TYPE_ID = Convert.ToInt32(txtAssessment.Tag);
                    upBio.MISBiopsyresult.TECHNIQUE_TYPE_ID = Convert.ToInt32(txtTechnique.Tag);
                    upBio.MISBiopsyresult.LAB_DATA = rtbLAB2.Text;
                    upBio.MISBiopsyresult.ORG_ID = env.OrgID;
                    upBio.MISBiopsyresult.LAST_MODIFIED_BY = env.UserID;

                    upBio.MISBiopsyresult.STATUS = status;

                    upBio.Invoke();
                }
            }

            ///*-----------------------orderdtl-------------------------*/
            //upBio.MISBiopsyresult.STATUS = status;
            //upBio.MISBiopsyresult.ASSINGED_TO = env.UserID;

            ///*-------------------------------------------------------*/
            //upBio.Invoke();
        }

        private void speOncore_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (speOncore.Value < 0)
            {
                speOncore.Value = 0;
                return;
            }
        }
        private void speCalcium_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (speCalcium.Value < 0)
            {
                speCalcium.Value = 0;
                return;
            }
        }
        private void speWidth_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (speWidth.Value < 0)
            {
                speWidth.Value = 0;
                return;
            }
        }
        private void speLength_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (speLength.Value < 0)
            {
                speLength.Value = 0;
                return;
            }
        }
        private void speDepth_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (speDepth.Value < 0)
            {
                speDepth.Value = 0;
                return;
            }
        }
        private void rdR0_CheckedChanged(object sender, EventArgs e)
        {
            if (rdR0.Checked == true)
            {
                setNullLocation();
                pointRL = "RC";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR1.Checked == true)
            {
                setNullLocation();
                pointRL = "R1";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR2.Checked == true)
            {
                setNullLocation();
                pointRL = "R2";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR3.Checked == true)
            {
                setNullLocation();
                pointRL = "R3";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR4.Checked == true)
            {
                setNullLocation();
                pointRL = "R4";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR5.Checked == true)
            {
                setNullLocation();
                pointRL = "R5";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR6.Checked == true)
            {
                setNullLocation();
                pointRL = "R6";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR7.Checked == true)
            {
                setNullLocation();
                pointRL = "R7";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR8.Checked == true)
            {
                setNullLocation();
                pointRL = "R8";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR9.Checked == true)
            {
                setNullLocation();
                pointRL = "R9";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR10.Checked == true)
            {
                setNullLocation();
                pointRL = "R10";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR11.Checked == true)
            {
                setNullLocation();
                pointRL = "R11";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR12.Checked == true)
            {
                setNullLocation();
                pointRL = "R12";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else if (rdR13.Checked == true)
            {
                setNullLocation();
                pointRL = "RO";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptRight.Enabled = true;
                rdgDeptRight.BackColor = Color.White;
            }
            else
            {
                setNullLocation();
                pointRL = "";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptRight.Enabled = false;
                rdgDeptRight.BackColor = Color.Transparent;
            }

        }
        private void rdL0_CheckedChanged(object sender, EventArgs e)
        {
            if (rdL0.Checked == true)
            {
                setNullLocation();
                pointRL = "LC";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL1.Checked == true)
            {
                setNullLocation();
                pointRL = "L1";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL2.Checked == true)
            {
                setNullLocation();
                pointRL = "L2";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL3.Checked == true)
            {
                setNullLocation();
                pointRL = "L3";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL4.Checked == true)
            {
                setNullLocation();
                pointRL = "L4";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL5.Checked == true)
            {
                setNullLocation();
                pointRL = "L5";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL6.Checked == true)
            {
                setNullLocation();
                pointRL = "L6";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL7.Checked == true)
            {
                setNullLocation();
                pointRL = "L7";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL8.Checked == true)
            {
                setNullLocation();
                pointRL = "L8";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL9.Checked == true)
            {
                setNullLocation();
                pointRL = "L9";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL10.Checked == true)
            {
                setNullLocation();
                pointRL = "L10";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL11.Checked == true)
            {
                setNullLocation();
                pointRL = "L11";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL12.Checked == true)
            {
                setNullLocation();
                pointRL = "L12";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else if (rdL13.Checked == true)
            {
                setNullLocation();
                pointRL = "LO";
                rdgDeptRight.SelectedIndex = 3;
                rdgDeptLeft.Enabled = true;
                rdgDeptLeft.BackColor = Color.White;
            }
            else
            {
                setNullLocation();
                pointRL = "";
                rdgDeptLeft.SelectedIndex = 3;
                rdgDeptLeft.Enabled = false;
                rdgDeptLeft.BackColor = Color.Transparent;
            }

        }

        #region Show Point Right
        private void rdR13_MouseHover(object sender, EventArgs e)
        {
            lblR13.Visible = true;
            lblR13.Text = "RA";
        }

        private void rdR13_MouseLeave(object sender, EventArgs e)
        {
            lblR13.Visible = false;
            lblR13.Text = "";
        }

        private void rdR0_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "RC";
        }

        private void rdR0_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR12_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R12";
        }

        private void rdR12_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR1_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R1";
        }

        private void rdR1_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR2_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R2";
        }
        private void rdR2_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR3_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R3";
        }

        private void rdR3_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR4_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R4";
        }

        private void rdR4_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR5_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R5";
        }

        private void rdR5_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR6_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R6";
        }

        private void rdR6_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR7_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R7";
        }

        private void rdR7_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR8_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R8";
        }

        private void rdR8_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR9_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R9";
        }

        private void rdR9_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR10_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R10";
        }

        private void rdR10_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }

        private void rdR11_MouseHover(object sender, EventArgs e)
        {
            lblR0.Visible = true;
            lblR0.Text = "R11";
        }

        private void rdR11_MouseLeave(object sender, EventArgs e)
        {
            lblR0.Visible = false;
            lblR0.Text = "";
        }
        #endregion

        #region Show Point Left
        private void rdL0_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "LC";
        }

        private void rdL0_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL12_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L12";
        }

        private void rdL12_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL1_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L1";
        }

        private void rdL1_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL2_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L2";
        }

        private void rdL2_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL3_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L3";
        }

        private void rdL3_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL4_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L4";

        }

        private void rdL4_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL5_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L5";
        }

        private void rdL5_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL6_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L6";
        }

        private void rdL6_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL7_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L7";
        }

        private void rdL7_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL8_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L8";
        }

        private void rdL8_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL9_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L9";
        }

        private void rdL9_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL10_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L10";
        }

        private void rdL10_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL11_MouseHover(object sender, EventArgs e)
        {
            lblL0.Visible = true;
            lblL0.Text = "L11";
        }

        private void rdL11_MouseLeave(object sender, EventArgs e)
        {
            lblL0.Visible = false;
            lblL0.Text = "";
        }

        private void rdL13_MouseHover(object sender, EventArgs e)
        {
            lblL13.Visible = true;
            lblL13.Text = "LA";
        }

        private void rdL13_MouseLeave(object sender, EventArgs e)
        {
            lblL13.Visible = false; ;
            lblL13.Text = "";
        }
        #endregion

        private void setNullLocation()
        {
            rdgTissue.SelectedIndex = 3;
            speWidth.Text = "";
            speLength.Text = "";
            speDepth.Text = "";
        }
        private void btnAddMamo_Click(object sender, EventArgs e)
        {

            DataTable dtTemp = new DataTable();

            dtTemp = (DataTable)grdMamo.DataSource;

            #region Check point
            if (rdR0.Checked == false
                       && rdR1.Checked == false
                       && rdR2.Checked == false
                       && rdR3.Checked == false
                       && rdR4.Checked == false
                       && rdR5.Checked == false
                       && rdR6.Checked == false
                       && rdR7.Checked == false
                       && rdR8.Checked == false
                       && rdR9.Checked == false
                       && rdR10.Checked == false
                       && rdR11.Checked == false
                       && rdR12.Checked == false
                       && rdR13.Checked == false
                       && rdL0.Checked == false
                       && rdL1.Checked == false
                       && rdL2.Checked == false
                       && rdL3.Checked == false
                       && rdL4.Checked == false
                       && rdL5.Checked == false
                       && rdL6.Checked == false
                       && rdL7.Checked == false
                       && rdL8.Checked == false
                       && rdL9.Checked == false
                       && rdL10.Checked == false
                       && rdL11.Checked == false
                       && rdL12.Checked == false
                       && rdL13.Checked == false
                       )
            {
                msg.ShowAlert("UID4016", env.CurrentLanguageID);
                return;
            }
            else if (rdL0.Checked == false
                       && rdL1.Checked == false
                       && rdL2.Checked == false
                       && rdL3.Checked == false
                       && rdL4.Checked == false
                       && rdL5.Checked == false
                       && rdL6.Checked == false
                       && rdL7.Checked == false
                       && rdL8.Checked == false
                       && rdL9.Checked == false
                       && rdL10.Checked == false
                       && rdL11.Checked == false
                       && rdL12.Checked == false
                       && rdL13.Checked == false)
            {
                if (rdgDeptRight.SelectedIndex == 3)
                {
                    msg.ShowAlert("UID4017", env.CurrentLanguageID);
                    return;
                }
            }
            else if (rdR0.Checked == false
                && rdR1.Checked == false
                && rdR2.Checked == false
                && rdR3.Checked == false
                && rdR4.Checked == false
                && rdR5.Checked == false
                && rdR6.Checked == false
                && rdR7.Checked == false
                && rdR8.Checked == false
                && rdR9.Checked == false
                && rdR10.Checked == false
                && rdR11.Checked == false
                && rdR12.Checked == false
                && rdR13.Checked == false)
            {
                if (rdgDeptLeft.SelectedIndex == 3)
                {
                    msg.ShowAlert("UID4017", env.CurrentLanguageID);
                    return;
                }
            }


            if (dtTemp != null)
            {


                foreach (DataRow drCheck in dtTemp.Rows)
                {
                    if (pointRL == drCheck["LOC_NO_L"].ToString())
                    {
                        msg.ShowAlert("UID4018", env.CurrentLanguageID);
                        return;
                    }
                    else if (pointRL == drCheck["LOC_NO_R"].ToString())
                    {
                        msg.ShowAlert("UID4018", env.CurrentLanguageID);
                        return;
                    }
                }
            }

            #endregion


            string LNL = "";
            string LNR = "";
            string DTL = "";
            string DTR = "";
            string TIS = "";

            #region LOC_NO_L
            if (rdL0.Checked)
                LNL = "LC";
            else if (rdL1.Checked)
                LNL = "L1";
            else if (rdL2.Checked)
                LNL = "L2";
            else if (rdL3.Checked)
                LNL = "L3";
            else if (rdL4.Checked)
                LNL = "L4";
            else if (rdL5.Checked)
                LNL = "L5";
            else if (rdL6.Checked)
                LNL = "L6";
            else if (rdL7.Checked)
                LNL = "L7";
            else if (rdL8.Checked)
                LNL = "L8";
            else if (rdL9.Checked)
                LNL = "L9";
            else if (rdL10.Checked)
                LNL = "L10";
            else if (rdL11.Checked)
                LNL = "L11";
            else if (rdL12.Checked)
                LNL = "L12";
            else if (rdL13.Checked)
                LNL = "LO";
            #endregion
            #region LOC_NO_R
            if (rdR0.Checked)
                LNR = "RC";
            else if (rdR1.Checked)
                LNR = "R1";
            else if (rdR2.Checked)
                LNR = "R2";
            else if (rdR3.Checked)
                LNR = "R3";
            else if (rdR4.Checked)
                LNR = "R4";
            else if (rdR5.Checked)
                LNR = "R5";
            else if (rdR6.Checked)
                LNR = "R6";
            else if (rdR7.Checked)
                LNR = "R7";
            else if (rdR8.Checked)
                LNR = "R8";
            else if (rdR9.Checked)
                LNR = "R9";
            else if (rdR10.Checked)
                LNR = "R10";
            else if (rdR11.Checked)
                LNR = "R11";
            else if (rdR12.Checked)
                LNR = "R12";
            else if (rdR13.Checked)
                LNR = "RO";
            #endregion

            switch (rdgTissue.SelectedIndex)
            {
                case 0: TIS = "F"; break;
                case 1: TIS = "C"; break;
                case 2: TIS = "N"; break;
            }
            switch (rdgDeptLeft.SelectedIndex)
            {
                case 0: DTL = "A"; break;
                case 1: DTL = "M"; break;
                case 2: DTL = "P"; break;
                case 3: DTL = "N"; break;
            }
            switch (rdgDeptRight.SelectedIndex)
            {
                case 0: DTR = "A"; break;
                case 1: DTR = "M"; break;
                case 2: DTR = "P"; break;
                case 3: DTR = "N"; break;
            }
            DataRow Newdr = dtTemp.NewRow();
            Newdr["LOC_NO_R"] = LNR;
            Newdr["LOC_NO_L"] = LNL;
            Newdr["DEPTH_TYPE_R"] = DTR;
            Newdr["DEPTH_TYPE_L"] = DTL;
            Newdr["TISSUE"] = TIS;
            Newdr["WIDTH"] = speWidth.Value;
            Newdr["LENGTH"] = speLength.Value;
            Newdr["DEPTH"] = speDepth.Value;

            dtTempMamo.Rows.Add(Newdr);
            grdMamo.DataSource = dtTempMamo;
        }
        private void btnRemoveMamo_Click(object sender, EventArgs e)
        {
            DataTable dtt = (DataTable)grdMamo.DataSource;
            if (dtt.Rows.Count == 0)
            {
                //initDefaultControlStart();
                initDefaultLocation();
            }
            else
            {
                BindGridMamo();
                viewMamo.DeleteRow(viewMamo.FocusedRowHandle);
                if (dtt.Rows.Count == 0)
                {
                    initDefaultControlStart();
                    initDefaultLocation();
                }
            }

        }

        private void GenText()
        {
            string procedure = "";
            string onofcore = "";
            string calcium = "";
            string surgery = "";
            string satisfactory = "";
            string technique = "";
            string location = "";
            string comment = "";
            string assessment = "";

            ProcessGetMISBiopsyresult geMIS = new ProcessGetMISBiopsyresult();
            geMIS.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
            geMIS.Invoke();
            DataTable dtGen = geMIS.Result.Tables[0];
            switch (dtGen.Rows[0]["PROCEDURE_TYPE"].ToString())
            {
                case "F": procedure = "FNA"; break;
                case "B": procedure = "Biopsy"; break;
                case "L": procedure = "Localization"; break;
                case "N": procedure = "None"; break;
            }
            onofcore = dtGen.Rows[0]["NO_OF_CORE"].ToString();
            calcium = dtGen.Rows[0]["CALCIUM_PCS"].ToString();
            surgery = dtGen.Rows[0]["IS_SURGERY"].ToString();
            satisfactory = dtGen.Rows[0]["IS_SATISFACTORY"].ToString();
            ProcessGetMISTechniquetype geTech = new ProcessGetMISTechniquetype();
            geTech.Invoke();
            DataRow[] drTech = geTech.Result.Tables[0].Select("TECHNIQUE_TYPE_ID=" + dtGen.Rows[0]["TECHNIQUE_TYPE_ID"].ToString());
            technique = drTech[0]["TECHNIQUE_TYPE_DESC"].ToString();
            for (int i = 0; i < dtGen.Rows.Count; i++)
            {
                location += dtGen.Rows[i]["LOC_NO_R"].ToString() + dtGen.Rows[i]["LOC_NO_L"].ToString() + ", Depth of Location : " + dtGen.Rows[i]["DEPTH_TYPE_R"].ToString() + dtGen.Rows[i]["DEPTH_TYPE_L"].ToString() + ", Tissue : " + dtGen.Rows[i]["TISSUE_TYPE"].ToString() + ", Dimension : " + dtGen.Rows[i]["WIDTH"].ToString() + "X" + dtGen.Rows[i]["LENGTH"].ToString() + "X" + dtGen.Rows[i]["DEPTH"].ToString() + " mm.\r\n\t\t";

            }
            comment = dtGen.Rows[0]["COMMENTS"].ToString();
            ProcessGetMISAsessmenttype geAss = new ProcessGetMISAsessmenttype();
            geAss.Invoke();
            DataRow[] drAss = geAss.Result.Tables[0].Select("ASESSMENT_TYPE_ID=" + dtGen.Rows[0]["ASESSMENT_TYPE_ID"].ToString());
            assessment = drAss[0]["ASESSMENT_TYPE_DESC"].ToString();



            BioText = "Procedure : \t" + procedure + "\r\n No of core : \t" + onofcore + " pcs. \r\n Calcium : \t" + calcium + " pcs.\r\n Back from Surgery : \t" + surgery + "\r\n Satisfactory : \t" + satisfactory + "\r\n Technique : \t" + technique + "\r\n Location : \t" + location + "\r\n Comment : \t" + comment + "\r\n Assessment : \t" + assessment;
        }
        private void BindGridMamo()
        {
            DataRow dr = viewMamo.GetDataRow(viewMamo.FocusedRowHandle);
            if (dr == null)
            {
                return;
            }
            switch (dr["LOC_NO_R"].ToString())
            {
                case "RC": rdR0.Checked = true; break;
                case "R1": rdR1.Checked = true; break;
                case "R2": rdR2.Checked = true; break;
                case "R3": rdR3.Checked = true; break;
                case "R4": rdR4.Checked = true; break;
                case "R5": rdR5.Checked = true; break;
                case "R6": rdR6.Checked = true; break;
                case "R7": rdR7.Checked = true; break;
                case "R8": rdR8.Checked = true; break;
                case "R9": rdR9.Checked = true; break;
                case "R10": rdR10.Checked = true; break;
                case "R11": rdR11.Checked = true; break;
                case "R12": rdR12.Checked = true; break;
                case "RO": rdR13.Checked = true; break;
                case "": rdR0.Checked = false;
                    rdR1.Checked = false;
                    rdR2.Checked = false;
                    rdR3.Checked = false;
                    rdR4.Checked = false;
                    rdR5.Checked = false;
                    rdR6.Checked = false;
                    rdR7.Checked = false;
                    rdR8.Checked = false;
                    rdR9.Checked = false;
                    rdR10.Checked = false;
                    rdR11.Checked = false;
                    rdR12.Checked = false;
                    rdR13.Checked = false; break;
            }
            switch (dr["LOC_NO_L"].ToString())
            {
                case "LC": rdL0.Checked = true; break;
                case "L1": rdL1.Checked = true; break;
                case "L2": rdL2.Checked = true; break;
                case "L3": rdL3.Checked = true; break;
                case "L4": rdL4.Checked = true; break;
                case "L5": rdL5.Checked = true; break;
                case "L6": rdL6.Checked = true; break;
                case "L7": rdL7.Checked = true; break;
                case "L8": rdL8.Checked = true; break;
                case "L9": rdL9.Checked = true; break;
                case "L10": rdL10.Checked = true; break;
                case "L11": rdL11.Checked = true; break;
                case "L12": rdL12.Checked = true; break;
                case "LO": rdL13.Checked = true; break;
                case "": rdL0.Checked = false;
                    rdL1.Checked = false;
                    rdL2.Checked = false;
                    rdL3.Checked = false;
                    rdL4.Checked = false;
                    rdL5.Checked = false;
                    rdL6.Checked = false;
                    rdL7.Checked = false;
                    rdL8.Checked = false;
                    rdL9.Checked = false;
                    rdL10.Checked = false;
                    rdL11.Checked = false;
                    rdL12.Checked = false;
                    rdL13.Checked = false; break;
            }
            switch (dr["TISSUE"].ToString())
            {
                case "F": rdgTissue.SelectedIndex = 0; break;
                case "C": rdgTissue.SelectedIndex = 1; break;
                case "N": rdgTissue.SelectedIndex = 2; break;
            }
            switch (dr["DEPTH_TYPE_R"].ToString())
            {
                case "A": rdgDeptRight.SelectedIndex = 0; break;
                case "M": rdgDeptRight.SelectedIndex = 1; break;
                case "P": rdgDeptRight.SelectedIndex = 2; break;
                case "N": rdgDeptRight.SelectedIndex = 3; break;
                case "": rdgDeptRight.SelectedIndex = 3; break;
            }
            switch (dr["DEPTH_TYPE_L"].ToString())
            {
                case "A": rdgDeptLeft.SelectedIndex = 0; break;
                case "M": rdgDeptLeft.SelectedIndex = 1; break;
                case "P": rdgDeptLeft.SelectedIndex = 2; break;
                case "N": rdgDeptLeft.SelectedIndex = 3; break;
                case "": rdgDeptLeft.SelectedIndex = 3; break;
            }
            speWidth.Text = dr["WIDTH"].ToString();
            speLength.Text = dr["LENGTH"].ToString();
            speDepth.Text = dr["DEPTH"].ToString();
        }

        private void viewMamo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindGridMamo();
        }

        private void LayoutLeft_ShowContextMenu(object sender, DevExpress.XtraLayout.LayoutMenuEventArgs e)
        {
            e.Allow = false;
        }

        private void layoutControl4_ShowContextMenu(object sender, DevExpress.XtraLayout.LayoutMenuEventArgs e)
        {
            e.Allow = false;
        }

        #endregion

        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ribbonControl1.SelectedPage != null)
            {
                if (ribbonControl1.SelectedPage.Text.ToLower().Trim() == "dashboard")
                {
                    #region DashBoard.
                    if (drData == null)
                    {
                        xtraTabControl1.SelectedTabPage = pageWL;
                        btnRefreshWL.Enabled = true;
                    }
                    else
                    {
                        btnRefreshWL.Enabled = false;
                    }
                    #endregion
                }
                else if (ribbonControl1.SelectedPage.Text.ToLower().Trim() == "demographic")
                {
                    xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
                }
                else if (ribbonControl1.SelectedPage == pageStructure)
                {
                    if (drData != null)
                    {
                        if (drData["S"].ToString() == "F")
                        {
                            enableDisableEntryPage(false);
                            iSaveResultDraft.Enabled = false;
                            iSaveResultPrelim.Enabled = false;
                            iSaveResultFinal.Enabled = false;
                            rtbLAB2.ReadOnly = true;
                        }
                        if (drData["ACCESSION_NO"].ToString() == accession_noMamo)
                        {
                            xtraTabControl1.SelectedTabPage = pageBiopsy;
                        }


                    }
                    else
                    {
                        iFavorite.Enabled = false;
                        iTechFile.Enabled = false;

                        barFavorite.Enabled = false;
                        barTeaching.Enabled = false;
                        barPreview.Enabled = false;

                        iSaveResultDraft.Enabled = false;
                        iSaveResultPrelim.Enabled = false;
                        iSaveResultFinal.Enabled = false;

                    }
                }
                else
                {
                    #region Reporting.
                    enableDisableEntryPage(true);
                    if (drData != null)
                    {
                        barPreview.Enabled = true;
                        if (notOpen)
                        {
                            //System.Diagnostics.Process.Start(env.PacsUrl + txtDemo_AccNo.Text.Trim());
                            notOpen = false;
                        }
                        if (drData["S"].ToString() == "F")
                        {
                            enableDisableEntryPage(false);
                            iSaveResultDraft.Enabled = false;
                            iSaveResultPrelim.Enabled = false;
                            iSaveResultFinal.Enabled = false;

                            btnAddendum.Enabled = true;
                            btnAddendumSmall.Enabled = true;
                            rtPad.ReadOnly = true;
                        }
                        if (drData["S"].ToString() == "P")
                        {
                            iSaveResultDraft.Enabled = false;
                        }
                        if (drData["ACCESSION_NO"].ToString() == accession_noMamo)
                        {
                            rtPad.ReadOnly = true;
                        }
                        if (rad.REMEMBER_GRID_ORDER)
                        {
                            ProcessUpdateGBLRadexperience prc = new ProcessUpdateGBLRadexperience();
                            getXMLGridHistory();
                            prc.UpdateGridHistory(new GBLEnvVariable().UserID, XMLHistory);
                        }
                    }
                    else
                    {
                        iFavorite.Enabled = false;
                        iTechFile.Enabled = false;

                        barFavorite.Enabled = false;
                        barTeaching.Enabled = false;
                        barPreview.Enabled = false;

                        iSaveResultDraft.Enabled = false;
                        iSaveResultPrelim.Enabled = false;
                        iSaveResultFinal.Enabled = false;

                    }

                    xtraTabControl1.SelectedTabPage = pageEntry;
                    rtPad.Focus();
                    #endregion
                }

            }
        }

        private void grpSearch_Click(object sender, EventArgs e)
        {
            if (grpSearch.Expanded == true)
            {
                tmWL.Enabled = false;
            }
            else
            {
                tmWL.Enabled = true;
            }
        }

        private void txtFromDT_DateTimeChanged(object sender, EventArgs e)
        {
            //if (!FirstDatabind)
            //{
            //    if (chkAllExam.Checked == true)
            //    {
            //        LoadData(2);
            //    }
            //    else
            //    {
            //        LoadData(1);
            //    }
            //}
        }

        private void txtToDT_DateTimeChanged(object sender, EventArgs e)
        {
            //if (!FirstDatabind)
            //{
            //    if (chkAllExam.Checked == true)
            //    {
            //        LoadData(2);
            //    }
            //    else
            //    {
            //        LoadData(1);
            //    }
            //}
        }

        private void grpSearch_DoubleClick(object sender, EventArgs e)
        {
            if (grpSearch.Expanded == true)
            {
                tmWL.Enabled = true;
                grpSearch.Expanded = false;
            }
            else
            {
                tmWL.Enabled = false;
                grpSearch.Expanded = true;
            }
        }
        private void getXMLGridWorklist()
        {
            DataTable dttt = (DataTable)grdWL.DataSource;

            if (dttt.Rows.Count > 0)
            {
                string s = "";
                DataTable dtColumn = new DataTable();
                dtColumn.TableName = "Column";
                dtColumn.Columns.Add("Name");
                dtColumn.Columns.Add("Size");
                dtColumn.Columns.Add("Visible");
                dtColumn.Columns.Add("ColVIndex");
                dtColumn.Columns.Add("GroupIndex");
                dtColumn.Columns.Add("AbsoluteIndex");
                dtColumn.Columns.Add("VisibleIndex");

                for (int i = 0; i < view1.Columns.Count; i++)
                {
                    dtColumn.Rows.Add(view1.Columns[i].FieldName.ToString(), view1.Columns[i].Width, view1.Columns[i].Visible,
                    view1.Columns[i].ColVIndex, view1.Columns[i].GroupIndex, view1.Columns[i].AbsoluteIndex, view1.Columns[i].VisibleIndex);
                }
                dtColumn.AcceptChanges();
                DataSet dsGrdWL = new DataSet();
                dsGrdWL.DataSetName = "Worklist";
                dsGrdWL.Tables.Add(dtColumn);

                XMLWorklist = dsGrdWL.GetXml();
            }
        }
        private void getXMLGridHistory()
        {
            return;
            DataTable dttt = (DataTable)grdHis.DataSource;

            if (dttt.Rows.Count > 0)
            {
                string s = "";
                DataTable dtColumn = new DataTable();
                dtColumn.TableName = "Column";
                dtColumn.Columns.Add("Name");
                dtColumn.Columns.Add("Size");
                dtColumn.Columns.Add("Visible");
                dtColumn.Columns.Add("ColVIndex");
                dtColumn.Columns.Add("GroupIndex");
                dtColumn.Columns.Add("AbsoluteIndex");
                dtColumn.Columns.Add("VisibleIndex");

                for (int i = 0; i < viewHis.Columns.Count; i++)
                {
                    dtColumn.Rows.Add(viewHis.Columns[i].FieldName.ToString(), viewHis.Columns[i].Width, viewHis.Columns[i].Visible,
                    viewHis.Columns[i].ColVIndex, viewHis.Columns[i].GroupIndex, viewHis.Columns[i].AbsoluteIndex, viewHis.Columns[i].VisibleIndex);
                }
                dtColumn.AcceptChanges();
                DataSet dsGrdHistory = new DataSet();
                dsGrdHistory.DataSetName = "History";
                dsGrdHistory.Tables.Add(dtColumn);

                XMLHistory = dsGrdHistory.GetXml();
            }
        }
        private void view1_DragObjectDrop(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e)
        {
            //int i = e.DropInfo.Index;
            if (e.DropInfo.Index == -100)
            {
                DataSet getXML = new DataSet();
                System.IO.MemoryStream mem = null;
                try
                {
                    char[] chr = XMLWorklist.ToCharArray();
                    byte[] data = new byte[chr.Length];
                    for (int i = 0; i < chr.Length; i++)
                        data[i] = (byte)chr[i];
                    mem = new System.IO.MemoryStream(data);

                    getXML.ReadXml(mem);
                    for (int j = 0; j < getXML.Tables[0].Rows.Count; j++)
                    {
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Width = Convert.ToInt32(getXML.Tables[0].Rows[j][1]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Visible = Convert.ToBoolean(getXML.Tables[0].Rows[j][2]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].ColVIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][3]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].GroupIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][4]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].AbsoluteIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][5]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].VisibleIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][6]);
                    }
                    mem.Dispose();
                }
                catch
                { }
            }
            else
            {
                getXMLGridWorklist();
            }
        }

        private void viewHis_DragObjectDrop(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e)
        {
            if (e.DropInfo.Index == -100)
            {
                DataSet getXML = new DataSet();
                System.IO.MemoryStream mem = null;
                try
                {
                    char[] chr = XMLHistory.ToCharArray();
                    byte[] data = new byte[chr.Length];
                    for (int i = 0; i < chr.Length; i++)
                        data[i] = (byte)chr[i];
                    mem = new System.IO.MemoryStream(data);

                    getXML.ReadXml(mem);
                    for (int j = 0; j < getXML.Tables[0].Rows.Count; j++)
                    {
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Width = Convert.ToInt32(getXML.Tables[0].Rows[j][1]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].Visible = Convert.ToBoolean(getXML.Tables[0].Rows[j][2]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].ColVIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][3]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].GroupIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][4]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].AbsoluteIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][5]);
                        view1.Columns[getXML.Tables[0].Rows[j][0].ToString()].VisibleIndex = Convert.ToInt32(getXML.Tables[0].Rows[j][6]);
                    }
                    mem.Dispose();
                }
                catch
                { }
            }
            else
            {
                getXMLGridHistory();
            }
        }

        private void viewHis_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = viewHis.GetDataRow(e.RowHandle);

                if (dr["MERGE_WITH"].ToString() == drData["ACCESSION_NO"].ToString())
                {
                    e.Appearance.BackColor = Color.LightPink;
                }
                else
                {
                    if (dr["ACCESSION_NO"].ToString() == drData["MERGE_WITH"].ToString())
                    {
                        e.Appearance.BackColor = Color.LightPink;
                    }
                    else
                    {
                        e.Appearance.BackColor = SystemColors.Window;
                    }
                }
            }
        }

        private void barZoom_EditValueChanged(object sender, EventArgs e)
        {
            rtPad.ActiveView.ZoomFactor = Convert.ToSingle(Convert.ToDouble(barZoom.EditValue.ToString().Replace("%", "")) * 0.01);
        }

        private void frmResultEntry_Load(object sender, EventArgs e)
        {
            rtPad.ActiveView.ZoomFactor = (float)1.5;
            barZoom.EditValue = "150%";
            rtPad.Font = new Font(rad.FONT_FACE, rad.FONT_SIZE);

            try
            {
                CultureInfo engCulture = new CultureInfo("En-us");
                spellChecker1.Culture = engCulture;

                sharedDictionaryStorage1.Dictionaries.Clear();
                SpellCheckerISpellDictionary dictionary = new SpellCheckerISpellDictionary(@"C:\Program Files\DictionaryStorage\american.xlg", @"C:\Program Files\DictionaryStorage\english.aff", engCulture);
                dictionary.AlphabetPath = @"C:\Program Files\DictionaryStorage\EnglishAlphabet.txt";
                sharedDictionaryStorage1.Dictionaries.Add(dictionary);
                //sharedDictionaryStorage1.Dictionaries.Add(new SpellCheckerDictionary(DemoUtils.GetRelativePath("English.0"), engCulture));
                SpellCheckerCustomDictionary customDictionary = new SpellCheckerCustomDictionary(@"C:\Program Files\DictionaryStorage\CustomEnglish.dic", engCulture);
                sharedDictionaryStorage1.Dictionaries.Add(customDictionary);
            }
            catch { }
        }

        private void barFavourite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drData != null)
            {
                if (msg.ShowAlert("UID5003", new GBLEnvVariable().CurrentLanguageID) == "2")
                {
                    LookUpSelect ls = new LookUpSelect();
                    ls.SelectRIS_RADSTUDYGROUP(new GBLEnvVariable().UserID, drData["ACCESSION_NO"].ToString(), true, false, false, "F");
                    barFavorite.Enabled = false;
                }
            }
        }

        private void barTeaching_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drData != null)
            {
                if (msg.ShowAlert("UID5004", new GBLEnvVariable().CurrentLanguageID) == "2")
                {
                    LookUpSelect ls = new LookUpSelect();
                    ls.SelectRIS_RADSTUDYGROUP(new GBLEnvVariable().UserID, drData["ACCESSION_NO"].ToString(), false, true, false, "T");
                    barTeaching.Enabled = false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!FirstDatabind)
            {
                if (chkAllExam.Checked == true)
                {
                    LoadData(2);
                }
                else
                {
                    LoadData(1);
                }
            }
        }

        private void view1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = view1.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr["MERGE"].ToString() != string.Empty)
                    {
                        if (dr["MERGE_WITH"].ToString() != string.Empty)
                        {
                            e.Appearance.BackColor = Color.LightPink;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.LightPink;
                        }
                    }
                    else
                    {
                        e.Appearance.BackColor = SystemColors.Window;
                    }
                }
            }
        }

        private void toolsSplit_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != null)
            {
                if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "worklist")
                {

                    if (view1.FocusedRowHandle > -1)
                    {
                        DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                        switch (dr["S"].ToString())
                        {
                            case "D":
                                return;
                                break;
                            case "P":
                                return;
                                break;
                            case "F":
                                return;
                                break;
                            default:
                                break;
                        }
                        split(dr);

                        CheckDataBind();
                    }
                    else
                    {
                        msg.ShowAlert("UID018", env.CurrentLanguageID);
                        return;
                    }
                }
                else if (xtraTabControl1.SelectedTabPage.Text.ToLower() == "history")
                {
                    if (viewHis.FocusedRowHandle > -1)
                    {
                        if (drData == null)
                        {
                            msg.ShowAlert("UID018", env.CurrentLanguageID);
                            return;
                        }
                        if (string.IsNullOrEmpty(drData["MERGE"].ToString()))
                        {
                            msg.ShowAlert("UID1123", env.CurrentLanguageID);
                            return;
                        }
                        split(drData);
                    }
                    else
                    {
                        msg.ShowAlert("UID018", env.CurrentLanguageID);
                        return;
                    }
                }
            }
        }

        private void frmResultEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnLockCase(true);
            if (rad.REMEMBER_GRID_ORDER)
            {
                ProcessUpdateGBLRadexperience prcwl = new ProcessUpdateGBLRadexperience();
                getXMLGridWorklist();
                if (XMLWorklist != "")
                    prcwl.UpdateGridWorklist(new GBLEnvVariable().UserID, XMLWorklist);
            }
        }
        private void UnLockCase(bool UnlockAllCase)
        {
            if (ViewLockCase == true)
            {
                ViewLockCase = false;
                return;
            }
            LookUpSelect ls = new LookUpSelect();
            ProcessUpdateRISExamresultlocks prc;
            if (drData != null)
            {
                if (UnlockAllCase == true)
                {
                    //dtEx = ls.SelectExamResultLock(drData["ACCESSION_NO"].ToString(), env.UserID);
                    if (CheckIsLock(drData["ACCESSION_NO"].ToString()) == env.UserID)
                    {
                        prc = new ProcessUpdateRISExamresultlocks();
                        prc.RISExamresultlocks.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                        prc.RISExamresultlocks.SL_NO = (byte)SL_NO;
                        prc.RISExamresultlocks.IS_LOCKED = "N";
                        prc.RISExamresultlocks.UNLOCKED_BY = env.UserID;
                        prc.RISExamresultlocks.ORG_ID = 1;
                        prc.RISExamresultlocks.LAST_MODIFIED_BY = env.UserID;

                        prc.Invoke();
                    }
                }
                if (!string.IsNullOrEmpty(drData["MERGE"].ToString()))
                {
                    if (drData["MERGE"].ToString().ToLower() != "spt")
                    {
                        result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                        result.RISExamresult.MERGE = drData["MERGE"].ToString();
                        result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();

                        DataTable dtt = result.GetMergeData();
                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                            {
                                CheckIsLock(dr["ACCESSION_NO"].ToString());
                                if (SL_NO > 0)
                                {
                                    prc = new ProcessUpdateRISExamresultlocks();
                                    prc.RISExamresultlocks.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                    prc.RISExamresultlocks.SL_NO = (byte)SL_NO;
                                    prc.RISExamresultlocks.IS_LOCKED = "N";
                                    prc.RISExamresultlocks.UNLOCKED_BY = env.UserID;
                                    prc.RISExamresultlocks.ORG_ID = 1;
                                    prc.RISExamresultlocks.LAST_MODIFIED_BY = env.UserID;

                                    prc.Invoke();
                                }
                            }
                        }
                    }
                }
            }
            else
            {

            }
        }
        private int CheckIsLock(string AccessionNO)
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
            return -1; // false,This case can't select
        }
        private void SelectThisCase(DataRow drCase, bool LoadConfig)
        {
            drData = drCase;
            if (drData != null)
            {
                rtPad.Text = string.Empty;
                rdNote.Text = string.Empty;
                string str = drData["ASSIGNED_TO"].ToString();
                if (string.IsNullOrEmpty(str))
                {
                    str = msg.ShowAlert("UID014", env.CurrentLanguageID);
                }
                else
                {
                    if (str.Trim() == env.UserID.ToString())
                        str = "2";
                    else
                        str = msg.ShowAlert("UID015", env.CurrentLanguageID);
                }
                if (str == "2")
                {
                    if (CheckIsLock(drData["ACCESSION_NO"].ToString()) == -1)
                    {
                        //msg.ShowAlert("UID5005", env.CurrentLanguageID);
                        //return;
                        ribbonPageGroup4.Visible = false;
                        ribbonPageGroup5.Visible = false;
                        ribbonPageGroup8.Visible = false;
                        ribbonPageGroup6.Visible = false;

                        //ribbonPageGroup9.Visible = true;

                        initDemoGraphic();
                        if (LoadConfig == true)
                        {
                            if (rad.AUTO_START_PACS_IMG)
                            {
                                //System.Diagnostics.Process.Start(env.PacsUrl + drData["ACCESSION_NO"].ToString().Trim());
                                ShowPacsImage(drData["ACCESSION_NO"].ToString().Trim());
                            }
                            if (rad.AUTO_START_ORDER_IMG)
                            {
                                RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(drData["ACCESSION_NO"].ToString());
                                ordimg.Text = "Order Summary";
                                ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                                ordimg.StartPosition = FormStartPosition.CenterScreen;
                                ordimg.MaximizeBox = false;
                                ordimg.MinimizeBox = false;
                                ordimg.ShowDialog();
                            }
                            switch (rad.GRID_DBL_CLICK_TO)
                            {
                                case "H":
                                    ribbonControl1.SelectedPage = pageDemographic;
                                    xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
                                    break;
                                case "R":
                                    ribbonControl1.SelectedPage = pageEdit;
                                    xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageEntry;
                                    break;
                                default:
                                    ribbonControl1.SelectedPage = pageDemographic;
                                    xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
                                    break;
                            }
                            if (rad.REMEMBER_GRID_ORDER)
                            {
                                ProcessUpdateGBLRadexperience prc = new ProcessUpdateGBLRadexperience();
                                getXMLGridWorklist();
                                prc.UpdateGridWorklist(new GBLEnvVariable().UserID, XMLWorklist);
                            }
                        }
                        ViewLockCase = true;
                        return;
                    }
                    else
                    {
                        ribbonPageGroup4.Visible = true;
                        ribbonPageGroup5.Visible = true;
                        ribbonPageGroup8.Visible = false;
                        ribbonPageGroup6.Visible = true;

                        //ribbonPageGroup9.Visible = false;
                    }

                    result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                    result.RISExamresult.MERGE = drData["MERGE"].ToString();
                    result.RISExamresult.MERGE_WITH = drData["MERGE_WITH"].ToString();

                    DataTable dtt = result.GetMergeData();
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr["ACCESSION_NO"].ToString() != drData["ACCESSION_NO"].ToString())
                        {
                            CheckIsLock(dr["ACCESSION_NO"].ToString());
                        }
                    }

                    initDemoGraphic();
                    if (LoadConfig == true)
                    {
                        if (rad.AUTO_START_PACS_IMG)
                        {
                            //System.Diagnostics.Process.Start(env.PacsUrl + drData["ACCESSION_NO"].ToString().Trim());
                            ShowPacsImage(drData["ACCESSION_NO"].ToString().Trim());
                        }
                        if (rad.AUTO_START_ORDER_IMG)
                        {
                            RIS.Forms.Technologist.frmPatientData ordimg = new RIS.Forms.Technologist.frmPatientData(drData["ACCESSION_NO"].ToString());
                            ordimg.Text = "Order Summary";
                            ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                            ordimg.StartPosition = FormStartPosition.CenterScreen;
                            ordimg.MaximizeBox = false;
                            ordimg.MinimizeBox = false;
                            ordimg.ShowDialog();
                        }
                        switch (rad.GRID_DBL_CLICK_TO)
                        {
                            case "H":
                                ribbonControl1.SelectedPage = pageDemographic;
                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
                                break;
                            case "R":
                                ribbonControl1.SelectedPage = pageEdit;
                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageEntry;
                                break;
                            default:
                                ribbonControl1.SelectedPage = pageDemographic;
                                xtraTabControl1.SelectedTabPage = drData == null ? pageWL : pageHistory;
                                break;
                        }
                        if (rad.REMEMBER_GRID_ORDER)
                        {
                            ProcessUpdateGBLRadexperience prc = new ProcessUpdateGBLRadexperience();
                            getXMLGridWorklist();
                            prc.UpdateGridWorklist(new GBLEnvVariable().UserID, XMLWorklist);
                        }
                    }
                    try
                    {
                        SetDefaultFont(rtPad);
                    }
                    catch
                    {
                        DocumentRange sel = rtPad.Document.Selection;

                        CharacterProperties charProperties = rtPad.Document.BeginUpdateCharacters(sel);
                        charProperties.FontName = "Microsoft Sans Serif";
                        charProperties.FontSize = 10;
                        rtPad.Document.EndUpdateCharacters(charProperties);
                    }
                }
                else
                {
                    drData = null;
                }
            }
        }

        private void barPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageBiopsy)
            {
                string rc = "";
                string r1 = "";
                string r2 = "";
                string r3 = "";
                string r4 = "";
                string r5 = "";
                string r6 = "";
                string r7 = "";
                string r8 = "";
                string r9 = "";
                string r10 = "";
                string r11 = "";
                string r12 = "";
                string r13 = "";
                string lc = "";
                string l1 = "";
                string l2 = "";
                string l3 = "";
                string l4 = "";
                string l5 = "";
                string l6 = "";
                string l7 = "";
                string l8 = "";
                string l9 = "";
                string l10 = "";
                string l11 = "";
                string l12 = "";
                string l13 = "";
                #region ดึงตำแหน่ง จุด

                ProcessGetMISBiopsyresult geMIS = new ProcessGetMISBiopsyresult();
                geMIS.MISBiopsyresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                geMIS.Invoke();
                DataTable dtMIS = geMIS.Result.Tables[0];
                foreach (DataRow drMIS in dtMIS.Rows)
                {
                    switch (drMIS["LOC_NO_R"].ToString())
                    {
                        case "RC": rc = "RC"; break;
                        case "R1": r1 = "R1"; break;
                        case "R2": r2 = "R2"; break;
                        case "R3": r3 = "R3"; break;
                        case "R4": r4 = "R4"; break;
                        case "R5": r5 = "R5"; break;
                        case "R6": r6 = "R6"; break;
                        case "R7": r7 = "R7"; break;
                        case "R8": r8 = "R8"; break;
                        case "R9": r9 = "R9"; break;
                        case "R10": r10 = "R10"; break;
                        case "R11": r11 = "R11"; break;
                        case "R12": r12 = "R12"; break;
                        case "RO": r13 = "RO"; break;
                    }
                    switch (drMIS["LOC_NO_L"].ToString())
                    {
                        case "LC": lc = "LC"; break;
                        case "L1": l1 = "L1"; break;
                        case "L2": l2 = "L2"; break;
                        case "L3": l3 = "L3"; break;
                        case "L4": l4 = "L4"; break;
                        case "L5": l5 = "L5"; break;
                        case "L6": l6 = "L6"; break;
                        case "L7": l7 = "L7"; break;
                        case "L8": l8 = "L8"; break;
                        case "L9": l9 = "L9"; break;
                        case "L10": l10 = "L10"; break;
                        case "L11": l11 = "L11"; break;
                        case "L12": l12 = "L12"; break;
                        case "LO": l13 = "LO"; break;
                    }
                }

                #endregion

                ProcessGetRptBiopsyResult lkp = new ProcessGetRptBiopsyResult(drData["ACCESSION_NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                lkp.Invoke();
                DataTable dt = lkp.Result.Tables[0];
                if (dtMIS.Rows.Count > 0)
                {


                    if (dtMIS.Rows[0]["PROCEDURE_TYPE"].ToString() == "L")
                    {
                        rptBiopsyLoca vReport = new rptBiopsyLoca();
                        vReport.SetDataSource(dt);

                        //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                        //vReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;

                        vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        vReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;

                        Reports.ReportViewer.frmReportViewer frmReport = new RIS.Reports.ReportViewer.frmReportViewer(vReport, ctrlPage);
                        frmReport.Size = new Size(800, 600);
                        frmReport.StartPosition = FormStartPosition.CenterScreen;
                        frmReport.ShowDialog();
                    }
                    else
                    {
                        rptBiospy vReport = new rptBiospy();
                        vReport.SetDataSource(dt);

                        //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                        //vReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;

                        vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        vReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;

                        Reports.ReportViewer.frmReportViewer frmReport = new RIS.Reports.ReportViewer.frmReportViewer(vReport, ctrlPage);
                        frmReport.Size = new Size(800, 600);
                        frmReport.StartPosition = FormStartPosition.CenterScreen;
                        frmReport.ShowDialog();
                    }
                }
            }
            else
            {
                rptResultEntry vReport = new rptResultEntry();

                ReportParameters para = new ReportParameters();
                para.SpType = 1;
                para.AccessionNo = txtDemo_AccNo.Text;
                ProcessResultEntryReport lkp = new ProcessResultEntryReport();
                lkp.ReportParameters = para;
                lkp.Invoke();
                DataTable dt = lkp.ResultSet.Tables[0];

                dt.Rows[0]["RESULT_TEXT_PLAIN"] = rtPad.Document.RtfText;
                dt.AcceptChanges();
                vReport.SetDataSource(dt);

                //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                //vReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;

                vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                vReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;

                Reports.ReportViewer.frmReportViewer frmReport = new RIS.Reports.ReportViewer.frmReportViewer(vReport);
                frmReport.Size = new Size(800, 600);
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.ShowDialog();
            }
        }

        private void printResultReport()
        {
            string _accno = drData["ACCESSION_NO"].ToString();

            DirectPrint rm = new DirectPrint();
            rm.ResultEntryDirectPrint(_accno, 3);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageHistory)
            {
                xtraTabControl1.SelectedTabPage = pageEntry;
                ribbonControl1.SelectedPage = pageEdit;
            }
            if (xtraTabControl1.SelectedTabPage == pageEntry)
            {
                if (drData != null)
                {
                    if (drData["STATUS"].ToString().StartsWith("D") || drData["STATUS"].ToString().StartsWith("P") || drData["STATUS"].ToString().StartsWith("F"))
                        btnReprint.Enabled = true;
                    else
                        btnReprint.Enabled = false;
                }
                else
                {
                    btnReprint.Enabled = false;
                }
            }
            else
            {
                btnReprint.Enabled = false;
            }
        }

        private void toolsPrelim_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            drData = view1.GetDataRow(view1.FocusedRowHandle);
            if (drData == null) return;

            int unit_id = 1;
            DataRow[] drEx = order.Ris_Exam().Select("EXAM_ID=" + drData["EXAM_ID"].ToString());
            if (drEx.Length > 0)
            {
                unit_id = Convert.ToInt32(drEx[0]["UNIT_ID"].ToString());
            }
            string uid = "";
            ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
            prc.RISExamresultseverity.UNIT_ID = unit_id;
            prc.Invoke();
            DataSet dsSeverity = prc.Result;
            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Severity_Clicks);
            lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
            lv.AddColumn("SEVERITY_NAME", "SEVERITY_NAME", true, true);
            lv.AddColumn("SEVERITY_LABEL", "SEVERITY_LABEL", true, true);
            lv.Text = "Severity List";
            lv.Data = dsSeverity.Tables[0];

            Size ss = new Size(510, 300);
            lv.Size = ss;
            lv.StartPosition = FormStartPosition.CenterScreen;
            // lv.PreviewFieldName = "report";
            // lv.ShowDescription = true;
            retValue = null;

            addText("Chest PA:", "Negative.");

            if (rtPad.Text.Length < rad.MINIMIZE_CHARACTER)
            {
                msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID, rad.MINIMIZE_CHARACTER);
                return;
            }
            uid = string.IsNullOrEmpty(drData["MERGE"].ToString()) ? "UID1129" : drData["MERGE"].ToString().ToLower() == "spt" ? "UID1129" : "UID1132";
            uid = msg.ShowAlert(uid, env.CurrentLanguageID);
            //Serverity = retValue[0].ToString();

            if (uid == "2" || uid == "3")
            {
                string prelimName = env.FirstNameEng + " " + env.LastNameEng + ",M.D.(" + env.UserUID + ")";
                if (env.AuthLevelID == "3")
                {
                    prelimName = prelimName + "\r\n Radiologist";
                }

                string rtf = rtPad.Document.RtfText;
                string txt = rtPad.Document.Text;
                string html = "";

                #region สร้าง DataTable เพื่อสร้าง HL7 Message.
                DataTable dtMSGF = new DataTable();
                dtMSGF.Columns.Add("HN");
                dtMSGF.Columns.Add("FNAME");
                dtMSGF.Columns.Add("MNAME");
                dtMSGF.Columns.Add("LNAME");
                dtMSGF.Columns.Add("THFNAME");
                dtMSGF.Columns.Add("THMNAME");
                dtMSGF.Columns.Add("GENDER");
                dtMSGF.Columns.Add("DOB");
                dtMSGF.Columns.Add("PHONE");
                dtMSGF.Columns.Add("ADDRESS");
                dtMSGF.Columns.Add("ACCESSION_NO");
                dtMSGF.Columns.Add("STATUS");
                dtMSGF.Columns.Add("EXAM_ID");
                dtMSGF.Columns.Add("EXAM_NAME");
                dtMSGF.Columns.Add("HL7TXT");
                dtMSGF.Columns.Add("ORDNO");
                #endregion

                DataTable tmpMSG = dtMSGF.Clone();

                #region Insert MainReport.
                DataRow row = tmpMSG.NewRow();
                row["HN"] = txtDemo_HN.EditValue.ToString();
                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                row["DOB"] = dttDemo.Rows[0]["DOB"];
                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                row["ADDRESS"] = txtDemo_Addr.EditValue.ToString();
                row["ACCESSION_NO"] = drData["ACCESSION_NO"].ToString();
                row["STATUS"] = "P";
                row["EXAM_ID"] = drData["EXAM_UID"].ToString();
                row["EXAM_NAME"] = drData["EXAM_NAME"].ToString();
                row["HL7TXT"] = html;
                row["ORDNO"] = drData["ORDER_ID"].ToString();
                tmpMSG.Rows.Add(row);
                tmpMSG.AcceptChanges();

                GenerateORU oru = new GenerateORU();
                DataTable dttPACS = oru.createMessage(tmpMSG);
                string hl7 = string.Empty;
                if (dttPACS.Rows.Count > 0)
                    hl7 = dttPACS.Rows[0]["HL7_TXT"].ToString();
                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                result.RISExamresult.ORDER_ID = Convert.ToInt32(drData["ORDER_ID"].ToString());
                result.RISExamresult.EXAM_ID = Convert.ToInt32(drData["EXAM_ID"].ToString());
                result.RISExamresult.RESULT_TEXT_HTML = html;
                result.RISExamresult.RESULT_TEXT_PLAIN = txt;
                result.RISExamresult.RESULT_TEXT_RTF = rtf;
                result.RISExamresult.RESULT_STATUS = "P";
                result.RISExamresult.HL7_TEXT = hl7;
                result.RISExamresult.HL7_SEND = "N";
                result.RISExamresult.RELEASED_BY = env.UserID;
                result.RISExamresult.FINALIZED_BY = 0;
                result.RISExamresult.CREATED_BY = env.UserID;
                result.RISExamresult.ORG_ID = env.OrgID;
                result.RISExamresult.SEVERITY_ID = 1;//Convert.ToInt32(Serverity);
                result.Reporting();
                #endregion

                SendToPacs pacs = new SendToPacs();
                pacs.Set_ORUByAccessionNoQueue(row["ACCESSION_NO"].ToString().Trim());
                if (true)//uid == "3")
                {
                    int id = 0;
                    int.TryParse(env.AuthLevelID, out id);
                    DirectPrint rpt = new DirectPrint();
                    rpt.ResultEntryDirectPrint(drData["ACCESSION_NO"].ToString(), id);
                }
                UnLockCase(true);
                initFirst();
            }
        }

        private void toolsFinalize_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            drData = view1.GetDataRow(view1.FocusedRowHandle);
            if (drData == null) return;

            int unit_id = 1;
            DataRow[] drEx = order.Ris_Exam().Select("EXAM_ID=" + drData["EXAM_ID"].ToString());
            if (drEx.Length > 0)
            {
                unit_id = Convert.ToInt32(drEx[0]["UNIT_ID"].ToString());
            }

            string uid = "";
            ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
            prc.RISExamresultseverity.UNIT_ID = unit_id;
            prc.Invoke();
            DataSet dsSeverity = prc.Result;
            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Severity_Clicks);
            lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
            lv.AddColumn("SEVERITY_NAME", "SEVERITY_NAME", true, true);
            lv.AddColumn("SEVERITY_LABEL", "SEVERITY_LABEL", true, true);
            lv.Text = "Severity List";
            lv.Data = dsSeverity.Tables[0];

            Size ss = new Size(510, 300);
            lv.Size = ss;
            lv.StartPosition = FormStartPosition.CenterScreen;
            // lv.PreviewFieldName = "report";
            // lv.ShowDescription = true;
            retValue = null;
            //lv.ShowBox();

            //if (retValue == null)
            //    return;
            addText("Chest PA:", "Negative.");

            if (rtPad.Text.Length < rad.MINIMIZE_CHARACTER)
            {
                msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            uid = string.IsNullOrEmpty(drData["MERGE"].ToString()) ? "UID1130" : drData["MERGE"].ToString().ToLower() == "spt" ? "UID1130" : "UID1133";
            uid = msg.ShowAlert(uid, env.CurrentLanguageID);
            //Serverity = retValue[0].ToString();

            if (uid == "2" || uid == "3")
            {
                rtPad.Font = new Font(rad.FONT_FACE, rad.FONT_SIZE);

                string rtf = rtPad.Document.RtfText;
                string txt = rtPad.Document.Text;
                string html = "";

                string finalName = env.FirstNameEng + " " + env.LastNameEng + ",M.D.(" + env.UserUID + ")";
                int finalID = env.UserID;
                if (env.AuthLevelID != "3")
                {
                    RadioFinal radio = new RadioFinal();
                    if (DialogResult.Cancel == radio.ShowDialog())
                        return;
                    finalID = radio.FinalizeID;
                    finalName = radio.FinalizedName;
                    finalName = radio.FinalizedName + ",M.D.(" + radio.Finalized_UID + ")";
                    radio.Dispose();
                }
                
                #region สร้าง DataTable เพื่อสร้าง HL7 Message.
                DataTable dtMSGF = new DataTable();
                dtMSGF.Columns.Add("HN");
                dtMSGF.Columns.Add("FNAME");
                dtMSGF.Columns.Add("MNAME");
                dtMSGF.Columns.Add("LNAME");
                dtMSGF.Columns.Add("THFNAME");
                dtMSGF.Columns.Add("THMNAME");
                dtMSGF.Columns.Add("GENDER");
                dtMSGF.Columns.Add("DOB");
                dtMSGF.Columns.Add("PHONE");
                dtMSGF.Columns.Add("ADDRESS");
                dtMSGF.Columns.Add("ACCESSION_NO");
                dtMSGF.Columns.Add("STATUS");
                dtMSGF.Columns.Add("EXAM_ID");
                dtMSGF.Columns.Add("EXAM_NAME");
                dtMSGF.Columns.Add("HL7TXT");
                dtMSGF.Columns.Add("ORDNO");
                #endregion

                DataTable tmpMSG = dtMSGF.Clone();

                #region Insert MainReport.
                DataRow row = tmpMSG.NewRow();
                row["HN"] = txtDemo_HN.EditValue.ToString();
                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                row["DOB"] = dttDemo.Rows[0]["DOB"];
                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                row["ADDRESS"] = txtDemo_Addr.EditValue.ToString();
                row["ACCESSION_NO"] = drData["ACCESSION_NO"].ToString();
                row["STATUS"] = "F";
                row["EXAM_ID"] = drData["EXAM_UID"].ToString();
                row["EXAM_NAME"] = drData["EXAM_NAME"].ToString();
                row["HL7TXT"] = html;
                row["ORDNO"] = drData["ORDER_ID"].ToString();
                tmpMSG.Rows.Add(row);
                tmpMSG.AcceptChanges();

                GenerateORU oru = new GenerateORU();
                DataTable dttPACS = oru.createMessage(tmpMSG);
                string hl7 = string.Empty;
                if (dttPACS.Rows.Count > 0)
                    hl7 = dttPACS.Rows[0]["HL7_TXT"].ToString();
                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                result.RISExamresult.ORDER_ID = Convert.ToInt32(drData["ORDER_ID"].ToString());
                result.RISExamresult.EXAM_ID = Convert.ToInt32(drData["EXAM_ID"].ToString());
                result.RISExamresult.RESULT_TEXT_HTML = html;
                result.RISExamresult.RESULT_TEXT_PLAIN = txt;
                result.RISExamresult.RESULT_TEXT_RTF = rtf;
                result.RISExamresult.RESULT_STATUS = "F";
                result.RISExamresult.HL7_TEXT = hl7;
                result.RISExamresult.HL7_SEND = "N";
                result.RISExamresult.RELEASED_BY = 0;
                result.RISExamresult.FINALIZED_BY = finalID;
                result.RISExamresult.CREATED_BY = env.UserID;
                result.RISExamresult.ORG_ID = env.OrgID;
                result.RISExamresult.SEVERITY_ID = 1; //Convert.ToInt32(Serverity);
                result.Reporting();
                #endregion

                SendToPacs pacs = new SendToPacs();
                pacs.Set_ORUByAccessionNoQueue(row["ACCESSION_NO"].ToString().Trim());
                if (true)//uid == "3")
                {
                    int id = 0;
                    int.TryParse(env.AuthLevelID, out id);
                    DirectPrint rpt = new DirectPrint();
                    rpt.ResultEntryDirectPrint(drData["ACCESSION_NO"].ToString(), id);
                }
                UnLockCase(true);
                initFirst();
            }
        }
        private void addText(string subject,string detail)
        {
            rtPad.BeginUpdate();
            try
            {
                DevExpress.XtraRichEdit.API.Native.DocumentPosition pos = rtPad.Document.CaretPosition;

                DocumentRange insertedTextRange = rtPad.Document.InsertText(pos, subject);
                CharacterProperties cp = rtPad.Document.BeginUpdateCharacters(insertedTextRange);
                cp.Italic = false;
                cp.Bold = true;
                cp.FontName = rad.FONT_FACE;//"Microsoft Sans Serif";
                cp.FontSize = rad.FONT_SIZE;
                rtPad.Document.EndUpdateCharacters(cp);

                insertedTextRange = rtPad.Document.InsertText(pos, detail);

                cp = rtPad.Document.BeginUpdateCharacters(insertedTextRange);
                cp.Italic = false;
                cp.Bold = false;
                cp.FontName = rad.FONT_FACE;//"Microsoft Sans Serif";
                cp.FontSize = rad.FONT_SIZE;
                rtPad.Document.EndUpdateCharacters(cp);

                rtPad.Document.InsertParagraph(pos);
                rtPad.Focus();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                rtPad.EndUpdate();
            }
        }
        private void addText(string detail)
        {
            rtPad.BeginUpdate();
            try
            {
                DevExpress.XtraRichEdit.API.Native.DocumentPosition pos = rtPad.Document.CaretPosition;

                DocumentRange insertedTextRange = rtPad.Document.InsertText(pos, detail);
                CharacterProperties cp = rtPad.Document.BeginUpdateCharacters(insertedTextRange);
                cp.Italic = false;
                cp.Bold = false;
                cp.FontName = rad.FONT_FACE;//"Microsoft Sans Serif";
                cp.FontSize = rad.FONT_SIZE;
                rtPad.Document.EndUpdateCharacters(cp);

                rtPad.Document.InsertParagraph(pos);
                rtPad.Focus();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                rtPad.EndUpdate();
            }
        }
        private void newLine()
        {
            DocumentPosition pos = rtPad.Document.Range.End;
            rtPad.Document.InsertParagraph(pos);
        }
        
        private void btnReprint_ItemClick(object sender, ItemClickEventArgs e)
        {
            int id = 0;
            int.TryParse(env.AuthLevelID, out id);
            DirectPrint rpt = new DirectPrint();
            rpt.ResultEntryDirectPrint(drData["ACCESSION_NO"].ToString(), id);
        }

        private void toolsNormal_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            drData = view1.GetDataRow(view1.FocusedRowHandle);
            if (drData == null) return;
            if (drData["S"].ToString() == "F") return;

            SelectThisCase(drData, false);
            ribbonControl1.SelectedPage = pageDashBoard;
            xtraTabControl1.SelectedTabPage = pageWL;

            if (drData == null) return;

            int unit_id = 1;
            DataRow[] drEx = order.Ris_Exam().Select("EXAM_ID=" + drData["EXAM_ID"].ToString());
            if (drEx.Length > 0)
            {
                unit_id = Convert.ToInt32(drEx[0]["UNIT_ID"].ToString());
            }

            string uid = "";
            ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
            prc.RISExamresultseverity.UNIT_ID = unit_id;
            prc.Invoke();
            DataSet dsSeverity = prc.Result;
            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(Severity_Clicks);
            lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
            lv.AddColumn("SEVERITY_NAME", "SEVERITY_NAME", true, true);
            lv.AddColumn("SEVERITY_LABEL", "SEVERITY_LABEL", true, true);
            lv.Text = "Severity List";
            lv.Data = dsSeverity.Tables[0];

            Size ss = new Size(510, 300);
            lv.Size = ss;
            lv.StartPosition = FormStartPosition.CenterScreen;
            // lv.PreviewFieldName = "report";
            // lv.ShowDescription = true;
            retValue = null;
            //lv.ShowBox();

            //if (retValue == null)
            //    return;

            //            rtPad.Text = "Chest PA:\n\nNegative.";
            //            rtPad.Rtf = @"{\rtf1\ansi\ansicpg874\deff0\deflang1054{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}{\f1\fnil Microsoft Sans Serif;}}
            //\viewkind4\uc1\pard\lang1033\f0\fs20 Chest PA:\f1\par
            //\par
            //\f0 Negative.\lang1054\fs20\par
            //}";

            addText(" CHEST:"," PA, UPRIGHT");
            newLine();
            addText("FINDINGS:"," The heart and mediastinum appear normal. There is no evidence of pulmonary or pleural abnormality. The visualized soft tissue and bony structures are unremarkable.");
            newLine();
            addText("IMPRESSION:"," - Normal chest.");

            //if (rtPad.Text.Length < rad.MINIMIZE_CHARACTER)
            //{
            //    msg.ShowAlert("UID1127", new GBLEnvVariable().CurrentLanguageID);
            //    return;
            //}
            uid = string.IsNullOrEmpty(drData["MERGE"].ToString()) ? "UID1130" : drData["MERGE"].ToString().ToLower() == "spt" ? "UID1130" : "UID1133";
            uid = msg.ShowAlert(uid, env.CurrentLanguageID);
            //Serverity = retValue[0].ToString();

            if (uid == "2" || uid == "3")
            {
                string rtf = rtPad.Document.RtfText;
                string txt = rtPad.Document.Text;
                string html = "";

                string finalName = env.FirstNameEng + " " + env.LastNameEng + ",M.D.(" + env.UserUID + ")";
                int finalID = env.UserID;
                if (env.AuthLevelID != "3")
                {
                    RadioFinal radio = new RadioFinal();
                    if (DialogResult.Cancel == radio.ShowDialog())
                        return;
                    finalID = radio.FinalizeID;
                    finalName = radio.FinalizedName;
                    finalName = radio.FinalizedName + ",M.D.(" + radio.Finalized_UID + ")";
                    radio.Dispose();
                }

                #region สร้าง DataTable เพื่อสร้าง HL7 Message.
                DataTable dtMSGF = new DataTable();
                dtMSGF.Columns.Add("HN");
                dtMSGF.Columns.Add("FNAME");
                dtMSGF.Columns.Add("MNAME");
                dtMSGF.Columns.Add("LNAME");
                dtMSGF.Columns.Add("THFNAME");
                dtMSGF.Columns.Add("THMNAME");
                dtMSGF.Columns.Add("GENDER");
                dtMSGF.Columns.Add("DOB");
                dtMSGF.Columns.Add("PHONE");
                dtMSGF.Columns.Add("ADDRESS");
                dtMSGF.Columns.Add("ACCESSION_NO");
                dtMSGF.Columns.Add("STATUS");
                dtMSGF.Columns.Add("EXAM_ID");
                dtMSGF.Columns.Add("EXAM_NAME");
                dtMSGF.Columns.Add("HL7TXT");
                dtMSGF.Columns.Add("ORDNO");
                #endregion

                DataTable tmpMSG = dtMSGF.Clone();

                #region Insert MainReport.
                DataRow row = tmpMSG.NewRow();
                row["HN"] = txtDemo_HN.EditValue.ToString();
                row["FNAME"] = dttDemo.Rows[0]["FNAME_ENG"].ToString();
                row["MNAME"] = dttDemo.Rows[0]["MNAME_ENG"].ToString();
                row["LNAME"] = dttDemo.Rows[0]["LNAME_ENG"].ToString();
                row["THFNAME"] = dttDemo.Rows[0]["FNAME"].ToString();
                row["THMNAME"] = dttDemo.Rows[0]["LNAME"].ToString();
                row["GENDER"] = dttDemo.Rows[0]["GENDER_ID"].ToString();
                row["DOB"] = dttDemo.Rows[0]["DOB"];
                row["PHONE"] = dttDemo.Rows[0]["PHONE"].ToString();
                row["ADDRESS"] = txtDemo_Addr.EditValue.ToString();
                row["ACCESSION_NO"] = drData["ACCESSION_NO"].ToString();
                row["STATUS"] = "F";
                row["EXAM_ID"] = drData["EXAM_UID"].ToString();
                row["EXAM_NAME"] = drData["EXAM_NAME"].ToString();
                row["HL7TXT"] = html;
                row["ORDNO"] = drData["ORDER_ID"].ToString();
                tmpMSG.Rows.Add(row);
                tmpMSG.AcceptChanges();

                GenerateORU oru = new GenerateORU();
                DataTable dttPACS = oru.createMessage(tmpMSG);
                string hl7 = string.Empty;
                if (dttPACS.Rows.Count > 0)
                    hl7 = dttPACS.Rows[0]["HL7_TXT"].ToString();
                result.RISExamresult.ACCESSION_NO = drData["ACCESSION_NO"].ToString();
                result.RISExamresult.ORDER_ID = Convert.ToInt32(drData["ORDER_ID"].ToString());
                result.RISExamresult.EXAM_ID = Convert.ToInt32(drData["EXAM_ID"].ToString());
                result.RISExamresult.RESULT_TEXT_HTML = html;
                result.RISExamresult.RESULT_TEXT_PLAIN = txt;
                result.RISExamresult.RESULT_TEXT_RTF = rtf;
                result.RISExamresult.RESULT_STATUS = "F";
                result.RISExamresult.HL7_TEXT = hl7;
                result.RISExamresult.HL7_SEND = "N";
                result.RISExamresult.RELEASED_BY = 0;
                result.RISExamresult.FINALIZED_BY = finalID;
                result.RISExamresult.CREATED_BY = env.UserID;
                result.RISExamresult.ORG_ID = env.OrgID;
                result.RISExamresult.SEVERITY_ID = 1; //Convert.ToInt32(Serverity);
                result.Reporting();
                #endregion

                SendToPacs pacs = new SendToPacs();
                pacs.Set_ORUByAccessionNoQueue(row["ACCESSION_NO"].ToString().Trim());
                if (uid == "3")
                {
                    int id = 0;
                    int.TryParse(env.AuthLevelID, out id);
                    DirectPrint rpt = new DirectPrint();
                    rpt.ResultEntryDirectPrint(drData["ACCESSION_NO"].ToString(), id);
                }
                UnLockCase(true);
                drData = null;
                initFirst();

                ribbonControl1.SelectedPage = pageDashBoard;
                xtraTabControl1.SelectedTabPage = pageWL;
            }
        }

        private void toolsAbnormal_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                drData = view1.GetDataRow(view1.FocusedRowHandle);

                if (drData != null)
                {
                    SelectThisCase(drData, true);
                    if (drData == null) return;
                    ribbonControl1.SelectedPage = pageEdit;
                    xtraTabControl1.SelectedTabPage = pageEntry;
                    rtPad.ActiveView.ZoomFactor = 0.9F;
                    rtPad.ActiveView.ZoomFactor = Convert.ToSingle(Convert.ToDouble(barZoom.EditValue.ToString().Replace("%", "")) * 0.01);
                }
            }
        }

        private void btnWorklistBar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (drData != null)
            {
                if (rtPad.Text.Trim() != string.Empty)
                {
                    string str = msg.ShowAlert("UID1114", env.CurrentLanguageID);
                    if (str == "2")
                    {
                        UnLockCase(true);
                        drData = null;
                        initFirst();

                        ribbonControl1.SelectedPage = pageDashBoard;
                        xtraTabControl1.SelectedTabPage = pageWL;
                    }
                }
                else
                {
                    UnLockCase(true);
                    drData = null;
                    initFirst();
                }
            }
        }

        private void ShowPacsImage(string accno)
        {
            if (env.LoginType == "E")
            {
                // UpdatePacs
                new OpenPACS(env.PacsUrl).OpenIEAccession(accno, env.UserName, env.PasswordAD, "", env.LoginType);
            }
            else
            {
                string str = env.PacsUrl + accno;

                Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
                if (!ieCom.OpenSynapseLink(str))
                    msg.ShowAlert("UID4053", env.CurrentLanguageID);
            }
        }
        private bool checkHaveThaiWords(string words)
        {
            bool flag = false;
            foreach (char ch in words.ToCharArray())
            {
                int x = (int)ch;
                if (x >= 63 && x <= 126)
                {
                    //this is english letter, i.e.- A, B, C, a, b, c...
                    flag = false;
                }
                else if (x >= 48 && x <= 57)
                {
                    //this is number
                    flag = false;
                }
                else
                {
                    //this is something diffrent
                    flag = true;
                }

            }
            return flag;
        }

    }
}