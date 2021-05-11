using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using CrystalDecisions.Shared;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Envision.Plugin.ReportManager;
using Envision.Plugin.CRFile;
using Envision.NET.Reports.ReportViewer;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmReprint : Envision.NET.Forms.Main.MasterForm
    {
        DataTable dtWL = new DataTable();
        GBLEnvVariable env = new GBLEnvVariable();
        private string accession;

        public frmReprint()
        {
            InitializeComponent();

            txtFromdate.DateTime = txtTodate.DateTime = DateTime.Now;
            gpHNDateSelection.SelectedIndex = 0;
            //radioGroup1.SelectedIndex = 1;
        }
        private void frmReprint_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }

        private void LoadTable()
        {
            if (gpHNDateSelection.SelectedIndex == 0)
            {
                ResultEntryWorkList wl = new ResultEntryWorkList();
                wl.SpType = 10;
                wl.PatientID = txtHN.Text;
                wl.FromDate = DateTime.Now;
                wl.ToDate = DateTime.Now;

                ProcessGetHistory lkp = new ProcessGetHistory();
                lkp.ResultEntryWorkList = wl;
                lkp.Invoke();

                dtWL = lkp.ResultSet.Tables[0].Copy();
                dtWL.Columns.Add("PREVIEW");
                dtWL.Columns.Add("CHECK");
                foreach (DataRow dr in dtWL.Rows)
                    dr["CHECK"] = "N";
            }
            else if (gpHNDateSelection.SelectedIndex == 1)
            {

                GBLEnvVariable env = new GBLEnvVariable();
                int org = env.OrgID;

                CultureInfo culture = new CultureInfo("en-US", true);
                DateTime dt = new DateTime(txtFromdate.DateTime.Year, txtFromdate.DateTime.Month, txtFromdate.DateTime.Day, 0, 0, 0);
                DateTime dt2 = new DateTime(txtTodate.DateTime.Year, txtTodate.DateTime.Month, txtTodate.DateTime.Day, 23, 59, 59);

                ResultEntryWorkList wl = new ResultEntryWorkList();
                wl.SpType = 11;
                wl.FromDate = dt;
                wl.ToDate = dt2;
                wl.OrgID = org;

                ProcessGetHistory lkp = new ProcessGetHistory();
                lkp.ResultEntryWorkList = wl;
                lkp.Invoke();

                dtWL = lkp.ResultSet.Tables[0].Copy();
                dtWL.Columns.Add("PREVIEW");
                dtWL.Columns.Add("CHECK");
                foreach (DataRow dr in dtWL.Rows)
                    dr["CHECK"] = "N";
            }
        }
        private void LoadGrid()
        {
            gcReprint.DataSource = dtWL;

            for (int i = 0; i < gvReprint.Columns.Count; i++)
            {
                gvReprint.Columns[i].Visible = false;
                gvReprint.Columns[i].OptionsColumn.AllowEdit = false;
            }

            gvReprint.Columns["CHECK"].ColVIndex = 1;
            gvReprint.Columns["CHECK"].Caption = " ";
            gvReprint.Columns["CHECK"].OptionsColumn.FixedWidth = true;
            gvReprint.Columns["CHECK"].Width = 10;
            gvReprint.Columns["CHECK"].OptionsColumn.AllowEdit = true;

            //gridView1.Columns["PREVIEW"].ColVIndex = 2;
            //gridView1.Columns["PREVIEW"].Caption = "Preview";
            //gridView1.Columns["PREVIEW"].Width = 75;
            //gridView1.Columns["PREVIEW"].OptionsColumn.AllowEdit = true;

            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkPrintPreview 
                = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            linkPrintPreview.Image = imageIcon.Images[0];
            linkPrintPreview.TextEditStyle = TextEditStyles.DisableTextEditor;
            linkPrintPreview.ImageAlignment = HorzAlignment.Center;
            linkPrintPreview.Click += new EventHandler(linkPrintPreview_Click);
            gvReprint.Columns["PREVIEW"].ColVIndex = 2;
            gvReprint.Columns["PREVIEW"].ColumnEdit = linkPrintPreview;
            gvReprint.Columns["PREVIEW"].Caption = " ";
            gvReprint.Columns["PREVIEW"].OptionsColumn.FixedWidth = true;
            gvReprint.Columns["PREVIEW"].Width = 10;
            gvReprint.Columns["PREVIEW"].OptionsColumn.AllowEdit = true;


            gvReprint.Columns["HN"].ColVIndex = 3;
            gvReprint.Columns["HN"].Caption = "HN";
            gvReprint.Columns["HN"].Width = 75;

            gvReprint.Columns["NAME"].ColVIndex = 4;
            gvReprint.Columns["NAME"].Caption = "Patient";
            gvReprint.Columns["NAME"].Width = 100;

            gvReprint.Columns["ORDER_DT"].ColVIndex = 5;
            gvReprint.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvReprint.Columns["ORDER_DT"].DisplayFormat.FormatString = "g";
            gvReprint.Columns["ORDER_DT"].Caption = "Study Time";
            gvReprint.Columns["ORDER_DT"].Width = 100;

            gvReprint.Columns["ACCESSION NO"].ColVIndex = 6;
            gvReprint.Columns["ACCESSION NO"].Caption = "Accession No.";
            gvReprint.Columns["ACCESSION NO"].Width = 100;

            gvReprint.Columns["EXAM CODE"].ColVIndex = 7;
            gvReprint.Columns["EXAM CODE"].Caption = "Exam Code";
            gvReprint.Columns["EXAM CODE"].Width = 75;

            gvReprint.Columns["EXAM_NAME"].ColVIndex = 8;
            gvReprint.Columns["EXAM_NAME"].Caption = "Exam Name";
            gvReprint.Columns["EXAM_NAME"].Width = 150;

            gvReprint.Columns["RESULT_STATUS"].ColVIndex = 9;
            gvReprint.Columns["RESULT_STATUS"].Caption = "Result Status";
            gvReprint.Columns["RESULT_STATUS"].Width = 125;

            gvReprint.Columns["PRIORITY"].ColVIndex = 10;
            gvReprint.Columns["PRIORITY"].Caption = "Priority";
            gvReprint.Columns["PRIORITY"].Width = 75;

            gvReprint.Columns["RADIOLOGIST"].ColVIndex = 11;
            gvReprint.Columns["RADIOLOGIST"].Caption = "Radiologist";
            gvReprint.Columns["RADIOLOGIST"].Width = 100;

            gvReprint.Columns["RESULT TIME"].ColVIndex = 12;
            gvReprint.Columns["RESULT TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvReprint.Columns["RESULT TIME"].DisplayFormat.FormatString = "g";
            gvReprint.Columns["RESULT TIME"].Caption = "Result Time";
            gvReprint.Columns["RESULT TIME"].Width = 125;


            #region setRepoItem

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueGrayed = null;
            chk.ValueUnchecked = "N";
            chk.Caption = "";
            gvReprint.Columns["CHECK"].ColumnEdit = chk;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ic = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ic.AutoHeight = false;
            ic.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)});
            ic.SmallImages = imgWL;
            ic.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gvReprint.Columns["PRIORITY"].ColumnEdit = ic;

            #endregion

            #region setStyleCon

            ////Alive
            //DevExpress.XtraGrid.StyleFormatCondition stylCon1
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvReprint.Columns["RESULT_STATUS"], null, "New");
            //stylCon1.ApplyToRow = true;
            //stylCon1.Appearance.ForeColor = Color.Red;

            ////Complete
            //DevExpress.XtraGrid.StyleFormatCondition stylCon2
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvReprint.Columns["RESULT_STATUS"], null, "Complete");
            //stylCon2.ApplyToRow = true;
            //stylCon2.Appearance.ForeColor = Color.Red;

            ////Prelim
            //DevExpress.XtraGrid.StyleFormatCondition stylCon3
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvReprint.Columns["RESULT_STATUS"], null, "Prelim");
            //stylCon3.ApplyToRow = true;
            //stylCon3.Appearance.ForeColor = Color.Goldenrod;

            ////Draft
            //DevExpress.XtraGrid.StyleFormatCondition stylCon4
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvReprint.Columns["RESULT_STATUS"], null, "Draft");
            //stylCon4.ApplyToRow = true;
            //stylCon4.Appearance.ForeColor = Color.Goldenrod;

            ////Finalize
            //DevExpress.XtraGrid.StyleFormatCondition stylCon5
            //    = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gvReprint.Columns["RESULT_STATUS"], null, "Finalized");
            //stylCon5.ApplyToRow = true;
            //stylCon5.Appearance.ForeColor = Color.Green;

            //gvReprint.FormatConditions.Clear();
            //gvReprint.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });

            #endregion

            //gridView1.BestFitColumns();
        }
        private void Reload()
        {
            LoadTable();
            LoadGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
        }
        private void gpHNDateSelection_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gpHNDateSelection.SelectedIndex == 0)
            {
                panelHN.Visible = true;
                panelDate.Visible = false;
            }
            else
            {
                panelHN.Visible = false;
                panelDate.Visible = true;
            }

            Reload();
        }
        private void frmReprint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Reload();
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }
        private void PrintReport()
        {
            DataTable dt = (DataTable)gcReprint.DataSource;

            DataRow[] drs = dt.Select(" CHECK='Y' ");
            if (drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {

                    #region Biopsy

                    ProcessGetMISBiopsyresult geMIS = new ProcessGetMISBiopsyresult();
                    geMIS.MIS_BIOPSYRESULT.ACCESSION_NO = dr["ACCESSION NO"].ToString();
                    geMIS.Invoke();

                    if (geMIS.Result.Tables[0].Rows.Count > 0)
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

                        ProcessGetRptBiopsyResult lkp = new ProcessGetRptBiopsyResult(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                        lkp.Invoke();
                        DataTable dtRptMIS = lkp.Result.Tables[0];
                        if (dtMIS.Rows.Count > 0)
                        {


                            if (dtMIS.Rows[0]["PROCEDURE_TYPE"].ToString() == "L")
                            {
                                Envision.Plugin.DirectPrint.DirectPrint dpBioL = new Envision.Plugin.DirectPrint.DirectPrint();
                                dpBioL.BiopsyLocalizeResultDirectPrint(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                            }
                            else
                            {

                                Envision.Plugin.DirectPrint.DirectPrint dpBioL = new Envision.Plugin.DirectPrint.DirectPrint();
                                dpBioL.BiopsyResultDirectPrint(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                            }
                        }
                    }

                    #endregion
                    else
                    {
                        string _accno = dr["ACCESSION NO"].ToString();
                        accession = dr["ACCESSION NO"].ToString();
                        string _status = dr["RESULT_STATUS"].ToString();
                        int auth = 0;
                        if (_status == "Draft")
                        {
                            auth = 2;
                        }
                        else if (_status == "Prelim")
                        {
                            auth = 3;
                        }
                        else
                        {
                            auth = 4;
                        }

                        #region old code
                        //ProcessGetRISExam geExam = new ProcessGetRISExam();
                        //geExam.Invoke();
                        //DataRow[] drChechUnit = geExam.Result.Tables[0].Select("EXAM_UID='" + dr["EXAM CODE"].ToString() + "'");
                        //if (drChechUnit.Length <= 0)
                        //{
                        //    return;
                        //}
                        //switch (Convert.ToInt32(drChechUnit[0]["UNIT_ID"].ToString()))
                        //{
                        //    case 1:
                        //        Envision.Plugin.DirectPrint.DirectPrint rmDIAG = new Envision.Plugin.DirectPrint.DirectPrint();
                        //        rmDIAG.ResultEntryDirectPrintA4(_accno, auth);
                        //        break;
                        //    case 2:
                        //        Envision.Plugin.DirectPrint.DirectPrint rmAIMC = new Envision.Plugin.DirectPrint.DirectPrint();
                        //        rmAIMC.ResultEntryDirectPrintA4AIMC(_accno, auth);
                        //        break;
                        //    case 3:
                        //        Envision.Plugin.DirectPrint.DirectPrint rmMAMMO = new Envision.Plugin.DirectPrint.DirectPrint();
                        //        rmMAMMO.ResultEntryDirectPrint(_accno, auth);
                        //        break;
                        //    default:
                        //        Envision.Plugin.DirectPrint.DirectPrint rmDefault = new Envision.Plugin.DirectPrint.DirectPrint();
                        //        rmDefault.ResultEntryDirectPrintA4(_accno, auth);
                        //        break;
                        //}
                        #endregion

                        //Considering from Patient Destination Label
                        switch (dr["PAT_DEST"].ToString()) //Considering from Patient Destination Label
                        {
                            case "DIAG":
                                Envision.Plugin.DirectPrint.DirectPrint rmDIAG = new Envision.Plugin.DirectPrint.DirectPrint();
                                rmDIAG.ResultEntryDirectPrintA4(_accno, auth);
                                break;
                            case "AIMC":
                                Envision.Plugin.DirectPrint.DirectPrint rmAIMC = new Envision.Plugin.DirectPrint.DirectPrint();
                                rmAIMC.ResultEntryDirectPrintA4AIMC(_accno, auth);
                                break;
                            case "MAMMO":
                                Envision.Plugin.DirectPrint.DirectPrint rmMAMMO = new Envision.Plugin.DirectPrint.DirectPrint();
                                rmMAMMO.ResultEntryDirectPrint(_accno, auth);
                                break;
                            case "SDMC":
                                Envision.Plugin.DirectPrint.DirectPrint rmSDMC = new Envision.Plugin.DirectPrint.DirectPrint();
                                rmSDMC.ResultEntryDirectPrintA4SDMC(_accno, auth);
                                break;
                            case "ER":
                                Envision.Plugin.DirectPrint.DirectPrint rmER = new Envision.Plugin.DirectPrint.DirectPrint();
                                rmER.ResultEntryDirectPrintA4(_accno, auth);
                                break;
                            default:
                                Envision.Plugin.DirectPrint.DirectPrint rmDefault = new Envision.Plugin.DirectPrint.DirectPrint();
                                rmDefault.ResultEntryDirectPrintA4(_accno, auth);
                                break;
                        }
                    }
                }

                Reload();
            }
            else
            {
                MyMessageBox msg = new MyMessageBox();
                string id = msg.ShowAlert("UID018", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
        }

        private void linkPrintPreview_Click(object sender, EventArgs e)
        {
            PrintPreview();
        }
        private void PrintPreview()
        {
            DataRow dr = gvReprint.GetDataRow(gvReprint.FocusedRowHandle);

            string _accno = dr["ACCESSION NO"].ToString();
            accession = dr["ACCESSION NO"].ToString();
            string _status = dr["RESULT_STATUS"].ToString();
            int auth = 0;
            if (_status == "Draft")
            {
                auth = 2;
            }
            else if (_status == "Prelim")
            {
                auth = 3;
            }
            else
            {
                auth = 4;
            }

            ReportMangager rptMng = new ReportMangager();

            switch (dr["PAT_DEST"].ToString()) //Considering from Patient Destination Label
            {
                case "DIAG":
                    rptMng.ResultEntryDirectPrintA4(_accno);
                    break;
                case "AIMC":
                    rptMng.ResultEntryDirectPrintA4AIMC(_accno);
                    break;
                case "MAMMO":
                    #region Biopsy

                    ProcessGetMISBiopsyresult geMIS = new ProcessGetMISBiopsyresult();
                    geMIS.MIS_BIOPSYRESULT.ACCESSION_NO = dr["ACCESSION NO"].ToString();
                    geMIS.Invoke();

                    if (geMIS.Result.Tables[0].Rows.Count > 0)
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

                        ProcessGetRptBiopsyResult lkp = new ProcessGetRptBiopsyResult(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                        lkp.Invoke();
                        DataTable dtRptMIS = lkp.Result.Tables[0];
                        if (dtMIS.Rows.Count > 0)
                        {

                            ReportMangager reportprovider = new ReportMangager();
                            if (dtMIS.Rows[0]["PROCEDURE_TYPE"].ToString() == "L")
                            {
                                frmReportViewer RForm = new frmReportViewer(reportprovider.BiopsyLocalizeResultPreview(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13));
                                RForm.ShowDialog();
                            }
                            else
                            {
                                frmReportViewer RForm = new frmReportViewer(reportprovider.BiopsyResultPreview(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13));
                                RForm.ShowDialog();
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        rptMng.ResultEntryDirectPrintA4(_accno);
                    }
                    break;
                case "SDMC":
                    rptMng.ResultEntryDirectPrintA4SDMC(_accno);
                    break;
                case "ER":
                    rptMng.ResultEntryDirectPrintA4(_accno);
                    break;
                default:
                    rptMng.ResultEntryDirectPrintA4(_accno);
                    break;
            }
        }
        //private void PrintPreview()
        //{
        //    DataTable dtCheck = (DataTable)gcReprint.DataSource;
        //    if (dtCheck.Rows.Count > 0)
        //    {
        //        DataRow dr = gvReprint.GetDataRow(gvReprint.FocusedRowHandle);

        //        string examName;
        //        string bpView = "";
        //        DataTable dttMerge = new DataTable();

        //        ReportParameters para = new ReportParameters();
        //        para.SpType = 1;
        //        para.AccessionNo = dr["ACCESSION NO"].ToString();
        //        ProcessResultEntryReport lkp = new ProcessResultEntryReport();
        //        lkp.ReportParameters = para;
        //        lkp.Invoke();
        //        DataTable dt = lkp.ResultSet.Tables[0];

        //        string IS_ER = "";

        //        if (dt.Rows.Count > 0)
        //        {
        //            dt.Rows[0]["ResultDoctor"] = arrangeGroup(dr["ACCESSION NO"].ToString());
        //            if (!string.IsNullOrEmpty(dt.Rows[0]["BPVIEW_DESC"].ToString()))
        //                bpView = " [ " + dt.Rows[0]["BPVIEW_DESC"].ToString() + " ] ";

        //            Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
        //            result.RISExamresult.ACCESSION_NO = dt.Rows[0]["ACCESSION_NO"].ToString();
        //            result.RISExamresult.MERGE = dt.Rows[0]["MERGE"].ToString();
        //            result.RISExamresult.MERGE_WITH = dt.Rows[0]["MERGE_WITH"].ToString();
        //            dttMerge = result.GetMergeData();

        //            IS_ER = dt.Rows[0]["IS_ER"].ToString();
        //        }
        //        examName = dr["EXAM_NAME"].ToString() + bpView + "  :   " + dr["EXAM CODE"].ToString();
        //        if (dttMerge.Rows.Count > 0)
        //        {
        //            foreach (DataRow drMerge in dttMerge.Rows)
        //            {
        //                if (drMerge["ACCESSION_NO"].ToString() != dr["ACCESSION NO"].ToString())
        //                {
        //                    if (!string.IsNullOrEmpty(drMerge["BPVIEW_DESC"].ToString()))
        //                        bpView = " [ " + drMerge["BPVIEW_DESC"].ToString() + " ] ";
        //                    else
        //                        bpView = "";
        //                    examName = examName + " \r\n" + drMerge["EXAM_NAME"].ToString() + bpView + "  :   " + drMerge["EXAM_UID"].ToString();
        //                }
        //            }
        //        }

        //        string nameUser = env.FirstName + " " + env.LastName;

        //        ProcessGetRISExam geExam = new ProcessGetRISExam();
        //        geExam.Invoke();
        //        DataRow[] drChechUnit = geExam.Result.Tables[0].Select("EXAM_UID='" + dr["EXAM CODE"].ToString() + "'");
        //        if (drChechUnit.Length <= 0)
        //        {
        //            return;
        //        }

        //        if (drChechUnit[0]["UNIT_ID"].ToString() == "2")
        //        {
        //            Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionAIMC xrpt = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionAIMC(dt, nameUser, examName);
        //            xrpt.DataSource = dt;
        //            xrpt.ShowPreviewMarginLines = false;
        //            xrpt.ShowPreview();
        //        }
        //        else
        //        {
        //            Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision xrpt = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision(dt, nameUser, examName);
        //            xrpt.DataSource = dt;
        //            xrpt.ShowPreviewMarginLines = false;
        //            xrpt.ShowPreview();
        //        }
        //    }
        //}
        //private string arrangeGroup(string accession_no)
        //{
        //    ProcessGetHREmp geHr = new ProcessGetHREmp();
        //    geHr.HR_EMP.MODE = "select_All_Active";
        //    geHr.Invoke();
        //    DataTable dtHr = new DataTable();
        //    dtHr = geHr.Result.Tables[0];
        //    string finalName = "";
        //    string ResultDoctor = "";
        //    ProcessGetRISExamresultrads rad = new ProcessGetRISExamresultrads();
        //    rad.RIS_EXAMRESULTRADS.ACCESSION_NO = accession_no;
        //    rad.Invoke();
        //    DataTable dtSetGroup = rad.Result.Tables[0];

        //    if (dtSetGroup.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dtSetGroup.Rows)
        //        {
        //            DataTable dtAuthe = selectCheckAuthen(Convert.ToInt32(dr["RAD_ID"]));
        //            if (dtAuthe.Rows.Count > 0)
        //            {
        //                string resultDoc = "";
        //                if (dtAuthe.Rows[0]["AUTH_LEVEL_ID"].ToString() == "3")
        //                {
        //                    DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
        //                    finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
        //                    finalName += " ";
        //                    finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
        //                    finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";

        //                    if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "RAD001")
        //                        ResultDoctor += finalName + " Radiologist\r\n";
        //                    else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL001")
        //                        ResultDoctor += finalName + " Radiologist\r\n";
        //                    else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL002")
        //                        ResultDoctor += finalName + " Radiologist\r\n";
        //                    else
        //                        ResultDoctor += finalName + "\r\n";


        //                }
        //                else
        //                {
        //                    DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
        //                    finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
        //                    finalName += " ";
        //                    finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
        //                    finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";
        //                    ResultDoctor += finalName + "\r\n";
        //                }

        //            }
        //        }
        //    }
        //    return ResultDoctor;
        //}
        //private DataTable selectCheckAuthen(int EMP_ID)
        //{
        //    ProcessGetHREmp hr = new ProcessGetHREmp();
        //    hr.HR_EMP.MODE = "check_Auther";
        //    hr.HR_EMP.EMP_ID = EMP_ID;
        //    hr.Invoke();
        //    DataTable dtAuth = hr.Result.Tables[0];
        //    dtAuth.AcceptChanges();
        //    return dtAuth;
        //}

        private void gvReprint_DoubleClick(object sender, EventArgs e)
        {
            if (gvReprint.FocusedRowHandle > -1)
            {
                DataRow dr = gvReprint.GetDataRow(gvReprint.FocusedRowHandle);
                if (dr["CHECK"].ToString() == "N")
                {
                    int rowHandle = gvReprint.FocusedRowHandle;
                    string fieldName = "CHECK";
                    object value = "Y";

                    gvReprint.SetRowCellValue(rowHandle, fieldName, value);
                }
                else
                {
                    int rowHandle = gvReprint.FocusedRowHandle;
                    string fieldName = "CHECK";
                    object value = "N";

                    gvReprint.SetRowCellValue(rowHandle, fieldName, value);
                }
            }
        }
        private void EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == "S")
            {
                DataTable dt = (DataTable)gcReprint.DataSource;
                foreach (DataRow dr in dt.Rows)
                    dr["CHECK"] = "Y";
            }
            else if (e.Button.Tag == "U")
            {
                DataTable dt = (DataTable)gcReprint.DataSource;
                foreach (DataRow dr in dt.Rows)
                    dr["CHECK"] = "N";
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gcReprint.DataSource;
            foreach (DataRow dr in dt.Rows)
                dr["CHECK"] = "Y";
        }
        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gcReprint.DataSource;
            foreach (DataRow dr in dt.Rows)
                dr["CHECK"] = "N";
        }

    }
}