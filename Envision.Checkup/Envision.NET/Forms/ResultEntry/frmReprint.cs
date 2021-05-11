using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using RIS.Common;
using RIS.Common.Common;
using RIS.Forms.GBLMessage;
using System.Globalization;
using CrystalDecisions.Shared;
using RIS.Plugin.DirectPrint;

namespace RIS.Forms.ResultEntry
{
    public partial class frmReprint : Form
    {
        DataTable dtWL = new DataTable();
        GBLEnvVariable env = new GBLEnvVariable();

        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public frmReprint(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            //LoadGrid();
            //GridEditable();
            txtFromdate.DateTime = txtTodate.DateTime = DateTime.Now;
            radioGroup1.SelectedIndex = 0;
        }
        #region LoadGrid
        //public void LoadGrid()
        //{
        //    this.UltraGrid1.DisplayLayout.Bands[0].Columns.Add("CheckBoxColumn", "Action");
        //    this.UltraGrid1.DisplayLayout.Bands[0].Columns["CheckBoxColumn"].DataType = typeof(bool);
        //    this.UltraGrid1.DisplayLayout.Bands[0].Columns["CheckBoxColumn"].Style =
        //    Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
        //    GBLEnvVariable env = new GBLEnvVariable();
        //    int org = env.OrgID;

        //    CultureInfo culture = new CultureInfo("en-US", true);
        //    //DateTime dt = Convert.ToDateTime(dateTimePicker1.Value, culture);
        //    //DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Value, culture);

        //    ResultEntryWorkList wl = new ResultEntryWorkList();
        //    wl.SpType = 3;
        //    wl.FromDate = DateTime.Now;
        //    wl.ToDate = DateTime.Now;
        //    wl.OrgID = org;

        //    ProcessGetHistory lkp = new ProcessGetHistory();
        //    lkp.ResultEntryWorkList = wl;
        //    lkp.Invoke();
        //    this.UltraGrid1.Refresh();
        //    this.UltraGrid1.Text = "";
        //    this.UltraGrid1.DataSource = lkp.ResultSet.Tables[0].Clone();
        //}
        #endregion
        #region GridEditableFalse
        //public void GridEditable()
        //{
        //    for (int i = 0; i < 6; i++)
        //    {
        //        this.UltraGrid1.DisplayLayout.Bands[0].Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        //    }

        //    this.UltraGrid1.DisplayLayout.Bands[0].Columns["Result Time"].MaskInput = "mm/dd/yyyy hh:mm";
        //    this.UltraGrid1.DisplayLayout.Bands[0].Columns["Result Time"].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
        //    this.UltraGrid1.DisplayLayout.Bands[0].Columns["Result Time"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
        //}
         #endregion

        private void UltraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (e.Row.Band.Index == 0)
            {


                string sts = e.Row.Cells["Status"].Value.ToString();
                if (sts == "F")
                {
                    e.Row.Cells["STATUS"].Value = "Finalized";
                }
                if (sts == "P")
                {
                    e.Row.Cells["STATUS"].Value = "Prelim";
                }
                if (sts == "D")
                {
                    e.Row.Cells["STATUS"].Value = "Draft";
                }
                if (sts == "")
                {
                    e.Row.Cells["STATUS"].Value = "New";
                }
                if (sts == "A")
                {
                    e.Row.Cells["STATUS"].Value = "New";
                }


                //string sts = e.Row.Cells["RESULT_STATUS"].Value.ToString();
                //if (sts == "F")
                //{
                //    e.Row.Cells["RESULT_STATUS"].Value = "Finalized";
                //}
                //if (sts == "P")
                //{
                //    e.Row.Cells["RESULT_STATUS"].Value = "Prelim";
                //}
                //if (sts == "D")
                //{
                //    e.Row.Cells["RESULT_STATUS"].Value = "Draft";
                //}
                //if (sts == "")
                //{
                //    e.Row.Cells["RESULT_STATUS"].Value = "New";
                //}
                //if (sts == "A")
                //{
                //    e.Row.Cells["RESULT_STATUS"].Value = "New";
                //}

               
            }
        }
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //int j = 0;
            //int count = 0;
            //while (j < UltraGrid1.Rows.Count)
            //{
            //    this.UltraGrid1.Rows[j].Cells[7].Selected = true;

            //    if (this.UltraGrid1.Rows[j].Cells[7].Value.ToString().Trim() == "True")
            //    {
            //        string _accno = this.UltraGrid1.Rows[j].Cells["Accession No"].Value.ToString().Trim();
            //        string _status = this.UltraGrid1.Rows[j].Cells["Status"].Value.ToString().Trim();
            //        int auth = 0;
            //        if (_status == "Draft")
            //        {
            //            auth = 2;
            //        }
            //        else if (_status == "Prelim")
            //        {
            //            auth = 3;
            //        }
            //        else
            //        {
            //            auth = 4;
            //        }
            //         DirectPrint rm = new  DirectPrint();
            //        rm.ResultEntryDirectPrint(_accno, auth);
            //        count++;
            //    }
            //    j++;
               
              
            //}
            //if (count == 0)
            //{
            //    MyMessageBox msg = new MyMessageBox();
            //    string id=msg.ShowAlert("UID018", new GBLEnvVariable().CurrentLanguageID);
            //    return;
            //}

            DataTable dt = (DataTable)gridControl1.DataSource;

            DataRow[] drs = dt.Select(" CHECK='Y' ");
            if(drs.Length>0)
            {
                foreach (DataRow dr in drs)
                {

                    #region Biopsy


                    ProcessGetMISBiopsyresult geMIS = new ProcessGetMISBiopsyresult();
                    geMIS.MISBiopsyresult.ACCESSION_NO = dr["ACCESSION NO"].ToString();
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
                                DirectPrint dpBioL = new DirectPrint();
                                dpBioL.BiopsyLocalizeResultDirectPrint(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                            }
                            else
                            {

                                DirectPrint dpBioL = new DirectPrint();
                                dpBioL.BiopsyResultDirectPrint(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                            }
                        }
                    }

                    #endregion
                    else
                    {

                        this.Enabled = false;
                        //foreach (DataRow dr in drs)
                        //{
                        string _accno = dr["ACCESSION NO"].ToString();
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
                        DirectPrint rm = new DirectPrint();
                        rm.ResultEntryDirectPrintA4(_accno, auth);
                    }
                }
            }
            else
            {
                MyMessageBox msg = new MyMessageBox();
                string id = msg.ShowAlert("UID018", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            this.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //GBLEnvVariable env = new GBLEnvVariable();
            //int org = env.OrgID;

            //CultureInfo culture = new CultureInfo("en-US", true);
            //DateTime dt = Convert.ToDateTime(dateTimePicker1.Value, culture);
            //DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Value, culture);

            //ResultEntryWorkList wl = new ResultEntryWorkList();
            //wl.SpType = 3;
            //wl.FromDate = dt;
            //wl.ToDate = dt2;
            //wl.OrgID = org;

            //ProcessGetHistory lkp = new ProcessGetHistory();
            //lkp.ResultEntryWorkList = wl;
            //lkp.Invoke();
            //this.UltraGrid1.Refresh();
            //this.UltraGrid1.Text = "";
            //this.UltraGrid1.DataSource = lkp.ResultSet.Tables[0];

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //GBLEnvVariable env = new GBLEnvVariable();
            //int org = env.OrgID;

            //CultureInfo culture = new CultureInfo("en-US", true);
            //DateTime dt = Convert.ToDateTime(dateTimePicker1.Value, culture);
            //DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Value, culture);

            //ResultEntryWorkList wl = new ResultEntryWorkList();
            //wl.SpType = 3;
            //wl.FromDate = dt;
            //wl.ToDate = dt2;
            //wl.OrgID = org;

            //ProcessGetHistory lkp = new ProcessGetHistory();
            //lkp.ResultEntryWorkList = wl;
            //lkp.Invoke();
            //this.UltraGrid1.Refresh();
            //this.UltraGrid1.Text = "";
            //this.UltraGrid1.DataSource = lkp.ResultSet.Tables[0];
        }

        private void LoadTable()
        {
            if (radioGroup1.SelectedIndex == 0)
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
                dtWL.Columns.Add("CHECK");
                foreach (DataRow dr in dtWL.Rows)
                    dr["CHECK"] = "N";
            }
            else if (radioGroup1.SelectedIndex == 1)
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
                dtWL.Columns.Add("CHECK");
                foreach (DataRow dr in dtWL.Rows)
                    dr["CHECK"] = "N";
            }
        }
        private void LoadGrid()
        {
            gridControl1.DataSource = dtWL;

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            gridView1.Columns["CHECK"].ColVIndex = 0;
            gridView1.Columns["CHECK"].Caption = "";
            gridView1.Columns["CHECK"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["CHECK"].Width = 50;
            gridView1.Columns["CHECK"].OptionsColumn.AllowEdit = true;

            gridView1.Columns["HN"].ColVIndex = 1;
            gridView1.Columns["HN"].Caption = "HN";
            gridView1.Columns["HN"].Width = 75;

            gridView1.Columns["NAME"].ColVIndex = 2;
            gridView1.Columns["NAME"].Caption = "Patient";
            gridView1.Columns["NAME"].Width = 100;

            gridView1.Columns["ORDER_DT"].ColVIndex = 3;
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatString = "g";
            gridView1.Columns["ORDER_DT"].Caption = "Study Time";
            gridView1.Columns["ORDER_DT"].Width = 100;

            gridView1.Columns["ACCESSION NO"].ColVIndex = 4;
            gridView1.Columns["ACCESSION NO"].Caption = "Accession No.";
            gridView1.Columns["ACCESSION NO"].Width = 100;

            gridView1.Columns["EXAM CODE"].ColVIndex = 5;
            gridView1.Columns["EXAM CODE"].Caption = "Exam Code";
            gridView1.Columns["EXAM CODE"].Width = 75;

            gridView1.Columns["EXAM_NAME"].ColVIndex = 6;
            gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView1.Columns["EXAM_NAME"].Width = 150;

            gridView1.Columns["RESULT_STATUS"].ColVIndex = 7;
            gridView1.Columns["RESULT_STATUS"].Caption = "Result Status";
            gridView1.Columns["RESULT_STATUS"].Width = 125;

            gridView1.Columns["PRIORITY"].ColVIndex = 8;
            gridView1.Columns["PRIORITY"].Caption = "Priority";
            gridView1.Columns["PRIORITY"].Width = 75;

            gridView1.Columns["RADIOLOGIST"].ColVIndex = 9;
            gridView1.Columns["RADIOLOGIST"].Caption = "Radiologist";
            gridView1.Columns["RADIOLOGIST"].Width = 100;

            gridView1.Columns["RESULT TIME"].ColVIndex = 10;
            gridView1.Columns["RESULT TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["RESULT TIME"].DisplayFormat.FormatString = "g";
            gridView1.Columns["RESULT TIME"].Caption = "Result Time";
            gridView1.Columns["RESULT TIME"].Width = 125;


            #region setRepoItem

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueGrayed = null;
            chk.ValueUnchecked = "N";
            chk.Caption = "";
            gridView1.Columns["CHECK"].ColumnEdit = chk;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ic = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ic.AutoHeight = false;
            ic.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 3, 8)});
            ic.SmallImages = imgWL;
            ic.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridView1.Columns["PRIORITY"].ColumnEdit = ic;

            #endregion

            #region setStyleCon

            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["RESULT_STATUS"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["RESULT_STATUS"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["RESULT_STATUS"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["RESULT_STATUS"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["RESULT_STATUS"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            gridView1.FormatConditions.Clear();
            gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });

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

        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            Reload();
        }

        private void radioGroup1_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
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

        private void txtHN_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Reload();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr["CHECK"].ToString() == "N")
                {
                    int rowHandle = gridView1.FocusedRowHandle;
                    string fieldName = "CHECK";
                    object value = "Y";

                    gridView1.SetRowCellValue(rowHandle, fieldName, value);
                }
                else
                {
                    int rowHandle = gridView1.FocusedRowHandle;
                    string fieldName = "CHECK";
                    object value = "N";

                    gridView1.SetRowCellValue(rowHandle, fieldName, value);
                }
            }
        }

        private void EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == "S")
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                foreach (DataRow dr in dt.Rows)
                    dr["CHECK"] = "Y";
            }
            else if (e.Button.Tag == "U")
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                foreach (DataRow dr in dt.Rows)
                    dr["CHECK"] = "N";
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            foreach (DataRow dr in dt.Rows)
                dr["CHECK"] = "Y";
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            foreach (DataRow dr in dt.Rows)
                dr["CHECK"] = "N";
        }

        private void btnPrintA5_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;

            DataRow[] drs = dt.Select(" CHECK='Y' ");
            if (drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {

                    #region Biopsy


                    ProcessGetMISBiopsyresult geMIS = new ProcessGetMISBiopsyresult();
                    geMIS.MISBiopsyresult.ACCESSION_NO = dr["ACCESSION NO"].ToString();
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
                                 DirectPrint dpBioL = new  DirectPrint();
                                dpBioL.BiopsyLocalizeResultDirectPrint(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                            }
                            else
                            {

                                 DirectPrint dpBioL = new  DirectPrint();
                                dpBioL.BiopsyResultDirectPrint(dr["ACCESSION NO"].ToString(), env.UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
                            }
                        }
                    }

                    #endregion
                    else
                    {

                        this.Enabled = false;
                        //foreach (DataRow dr in drs)
                        //{
                        string _accno = dr["ACCESSION NO"].ToString();
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
                        ProcessGetRISExam geExam = new ProcessGetRISExam();
                        geExam.Invoke();
                        //DataTable dtExam = 
                        DataRow[] drChechUnit = geExam.Result.Tables[0].Select("EXAM_UID='" + dr["EXAM CODE"].ToString() + "'");
                        if (drChechUnit.Length <= 0)
                        {
                            return;
                        }
                        //if (Convert.ToInt32(drChechUnit[0]["UNIT_ID"].ToString()) == 2)
                        //{
                        //     DirectPrint rm = new  DirectPrint();
                        //    rm.ResultEntryDirectPrintA4(_accno, auth);
                        //}
                        //else
                        //{
                        //     DirectPrint rm = new  DirectPrint();
                        //    rm.ResultEntryDirectPrint(_accno, auth);
                        //}

                         DirectPrint rm = new  DirectPrint();
                        rm.ResultEntryDirectPrint(_accno, auth);

                    }
                }
            }
            else
            {
                MyMessageBox msg = new MyMessageBox();
                string id = msg.ShowAlert("UID018", new GBLEnvVariable().CurrentLanguageID);
                return;
            }
            this.Enabled = true;
        }
    }
}