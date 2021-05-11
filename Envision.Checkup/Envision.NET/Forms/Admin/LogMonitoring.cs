using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RIS.BusinessLogic;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Admin
{
    public partial class LogMonitoring : Form
    {
        DataTable dtRad = new DataTable();

        DataTable dtGblEnv = new DataTable();
        DataTable dtExam = new DataTable();
        DataTable dtExamresult = new DataTable();
        DataTable dtExamresultTemplate = new DataTable();
        DataTable dtSchedule = new DataTable();

        private bool needtoload = true;

        public LogMonitoring(UUL.ControlFrame.Controls.TabControl tabcontrol)
        {
            InitializeComponent();

        }
        private void LogMonitoring_Load(object sender, EventArgs e)
        {
            txtFrom.DateTime = txtTo.DateTime = DateTime.Now;
            chkAll.Checked = chkInsert.Checked = chkUpdate.Checked = chkDelete.Checked = true;
            Reload();
        }

        private void LoadTableGblEnv()
        {
            ProcessGetGBLEnvlog bg = new ProcessGetGBLEnvlog();
            DateTime fd = new DateTime(txtFrom.DateTime.Year, txtFrom.DateTime.Month, txtFrom.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtTo.DateTime.Year, txtTo.DateTime.Month, txtTo.DateTime.Day, 23, 59, 59);
            bg.GBLEnvlog.FROMDATE = fd;
            bg.GBLEnvlog.TODATE = td;
            bg.Invoke();
            dtGblEnv = bg.Result.Tables[0];
        }
        private void LoadFilterGblEnv()
        {
            DataTable dt = dtGblEnv.Copy();

            #region filterCheck
            DataTable dtc = dt.Clone();
            DataRow[] drs;
            if (chkInsert.Checked && chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked && chkUpdate.Checked)
                drs = dt.Select("OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=3 OR OPERATION=4");
            else if (chkDelete.Checked && chkInsert.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2");
            else if (chkDelete.Checked)
                drs = dt.Select("OPERATION=1");
            else if (chkUpdate.Checked)
                drs = dt.Select("OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked)
                drs = dt.Select("OPERATION=2");
            else
                drs = dt.Clone().Select();
            foreach (DataRow dr in drs)
                dtc.Rows.Add(dr.ItemArray);

            #endregion

            dt = dtc.Copy();
            dt.AcceptChanges();
            gridControl1.DataSource = dt;
            gridView1.RefreshData();
        }
        private void LoadGridGblEnv()
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                //gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridView1.Columns["LOG_ID"].Visible = false;
            gridView1.Columns["OPERATION"].Visible = false;
            gridView1.Columns["START_LSN"].Visible = false;
            gridView1.Columns["SEQVAL"].Visible = false;
            gridView1.Columns["UPDATE_MASK"].Visible = false;
            gridView1.Columns["ORG_IMG"].Visible = false;
            gridView1.Columns["WS_IP_PICTURE"].Visible = false;
            gridView1.Columns["EFFECTIVE_DT"].Visible = false;

            gridView1.Columns["OPERATION_STATUS"].ColVIndex = 0;
            gridView1.Columns["OPERATION_STATUS"].Caption = "Operation";

            gridView1.Columns["CREATED_BY"].Caption = "Created by";

            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CREATED_ON"].Caption = "Created on";

            gridView1.Columns["LAST_MODIFIED_BY"].Caption = "Last Modified by";

            gridView1.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["LAST_MODIFIED_ON"].Caption = "Last Modified on";

            #endregion

            #region setStyleCon

            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Deleted");
            stylCon1.Appearance.ForeColor = Color.Red;

            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Added");
            stylCon2.Appearance.ForeColor = Color.Green;

            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Edited(before)");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Edited(after)");
            stylCon4.Appearance.ForeColor = Color.DarkGoldenrod;

            gridView1.FormatConditions.Clear();
            gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4 });


            #endregion

        }

        private void LoadTableRisExam()
        {
            ProcessGetRISExamlog bg = new ProcessGetRISExamlog();
            DateTime fd = new DateTime(txtFrom.DateTime.Year, txtFrom.DateTime.Month, txtFrom.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtTo.DateTime.Year, txtTo.DateTime.Month, txtTo.DateTime.Day, 23, 59, 59);
            bg.RISExamlog.FROMDATE = fd;
            bg.RISExamlog.TODATE = td;
            bg.Invoke();
            dtExam = bg.Result.Tables[0];
        }
        private void LoadFilterRisExam()
        {
            DataTable dt = dtExam.Copy();

            #region filterCheck

            DataTable dtc = dt.Clone();
            DataRow[] drs;
            if (chkInsert.Checked && chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked && chkUpdate.Checked)
                drs = dt.Select("OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=3 OR OPERATION=4");
            else if (chkDelete.Checked && chkInsert.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2");
            else if (chkDelete.Checked)
                drs = dt.Select("OPERATION=1");
            else if (chkUpdate.Checked)
                drs = dt.Select("OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked)
                drs = dt.Select("OPERATION=2");
            else
                drs = dt.Clone().Select();
            foreach (DataRow dr in drs)
                dtc.Rows.Add(dr.ItemArray);

            #endregion

            dt = dtc.Copy();
            dt.AcceptChanges();
            gridControl2.DataSource = dt;
            gridView2.RefreshData();
        }
        private void LoadGridRisExam()
        {
            for (int i = 0; i < gridView2.Columns.Count; i++)
            {
                //gridView2.Columns[i].Visible = false;
                gridView2.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridView2.Columns["LOG_ID"].Visible = false;
            gridView2.Columns["START_LSN"].Visible = false;
            gridView2.Columns["SEQVAL"].Visible = false;
            gridView2.Columns["UPDATE_MASK"].Visible = false;
            gridView2.Columns["OPERATION"].Visible = false;

            gridView2.Columns["OPERATION_STATUS"].ColVIndex = 0;
            gridView2.Columns["OPERATION_STATUS"].Caption = "Operation";

            gridView2.Columns["CREATED_BY"].Caption = "Created by";

            gridView2.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView2.Columns["CREATED_ON"].Caption = "Created on";

            gridView2.Columns["LAST_MODIFIED_BY"].Caption = "Last Modified by";

            gridView2.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatString = "g";
            gridView2.Columns["LAST_MODIFIED_ON"].Caption = "Last Modified on";

            #endregion

            #region setStyleCon

            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["OPERATION_STATUS"], null, "Deleted");
            stylCon1.Appearance.ForeColor = Color.Red;

            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["OPERATION_STATUS"], null, "Added");
            stylCon2.Appearance.ForeColor = Color.Green;

            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["OPERATION_STATUS"], null, "Edited(before)");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["OPERATION_STATUS"], null, "Edited(after)");
            stylCon4.Appearance.ForeColor = Color.DarkGoldenrod;

            gridView2.FormatConditions.Clear();
            gridView2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4 });

            #endregion

        }

        private void LoadTableRisExamresult()
        {
            ProcessGetRISExamresultlog bg = new ProcessGetRISExamresultlog();
            DateTime fd = new DateTime(txtFrom.DateTime.Year, txtFrom.DateTime.Month, txtFrom.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtTo.DateTime.Year, txtTo.DateTime.Month, txtTo.DateTime.Day, 23, 59, 59);
            bg.RISExamresultlog.FROMDATE = fd;
            bg.RISExamresultlog.TODATE = td;
            bg.Invoke();
            dtExamresult = bg.Result.Tables[0];
        }
        private void LoadFilterRisExamresult()
        {
            DataTable dt = dtExamresult.Copy();

            #region filterRadiologist

            if (!chkAll.Checked)
            {
                if (txtRadiologist.Tag != null)
                {
                    DataTable dtr = dt.Clone();
                    string Query = "";
                    string[] empid = txtRadiologist.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < empid.Length; i++)
                    {
                        Query += " RAD_ID = " + empid[i].ToString();
                        if (i + 1 < empid.Length)
                            Query += " or ";
                    }
                    DataRow[] drr = dt.Select(Query);
                    foreach (DataRow dr in drr)
                        dtr.Rows.Add(dr.ItemArray);

                    dt = dtr;
                }
                else
                {
                    dt.Rows.Clear();
                }
            }

            #endregion

            #region filterCheck
            DataTable dtc = dt.Clone();
            DataRow[] drs;
            if (chkInsert.Checked && chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked && chkUpdate.Checked)
                drs = dt.Select("OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=3 OR OPERATION=4");
            else if (chkDelete.Checked && chkInsert.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2");
            else if (chkDelete.Checked)
                drs = dt.Select("OPERATION=1");
            else if (chkUpdate.Checked)
                drs = dt.Select("OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked)
                drs = dt.Select("OPERATION=2");
            else
                drs = dt.Clone().Select();
            foreach (DataRow dr in drs)
                dtc.Rows.Add(dr.ItemArray);

            #endregion

            dt = dtc.Copy();
            dt.AcceptChanges();
            gridControl3.DataSource = dt;
            gridView3.RefreshData();
        }
        private void LoadGridRisExamresult()
        {
            for (int i = 0; i < gridView3.Columns.Count; i++)
            {
                gridView3.Columns[i].Visible = false;
                gridView3.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            //gridView1.Columns["EFFECTIVE_DT"].ColVIndex = 1;
            //gridView1.Columns["EFFECTIVE_DT"].Caption = "Effective Date";
            //gridView1.Columns["EFFECTIVE_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //gridView1.Columns["EFFECTIVE_DT"].DisplayFormat.FormatString = "g";
            //gridView1.Columns["EFFECTIVE_DT"].Width = 75;

            gridView3.Columns["ACCESSION_NO"].ColVIndex = 1;
            gridView3.Columns["ACCESSION_NO"].Caption = "Accession No.";
            gridView3.Columns["ACCESSION_NO"].Width = 75;

            gridView3.Columns["HN"].ColVIndex = 2;
            gridView3.Columns["HN"].Caption = "HN";
            gridView3.Columns["HN"].Width = 75;

            gridView3.Columns["PATIENTNAME"].ColVIndex = 2;
            gridView3.Columns["PATIENTNAME"].Caption = "Patient Name";
            gridView3.Columns["PATIENTNAME"].Width = 100;

            gridView3.Columns["ORDER_ID"].ColVIndex = 3;
            gridView3.Columns["ORDER_ID"].Caption = "Order Code";
            gridView3.Columns["ORDER_ID"].Width = 50;

            gridView3.Columns["EXAM_UID"].ColVIndex = 4;
            gridView3.Columns["EXAM_UID"].Caption = "Exam Code";
            gridView3.Columns["EXAM_UID"].Width = 50;

            gridView3.Columns["EXAM_NAME"].ColVIndex = 5;
            gridView3.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView3.Columns["EXAM_NAME"].Width = 75;

            gridView3.Columns["RESULT_STATUS"].ColVIndex = 6;
            gridView3.Columns["RESULT_STATUS"].Caption = "Result Status";
            gridView3.Columns["RESULT_STATUS"].Width = 75;

            gridView3.Columns["HL7_SEND"].ColVIndex = 7;
            gridView3.Columns["HL7_SEND"].Caption = "HL7 Status";
            gridView3.Columns["HL7_SEND"].Width = 50;

            gridView3.Columns["OPERATION_STATUS"].ColVIndex = 0;
            gridView3.Columns["OPERATION_STATUS"].Caption = "Operation";
            gridView3.Columns["OPERATION_STATUS"].Width = 100;

            gridView3.Columns["ICD_UID"].ColVIndex = 8;
            gridView3.Columns["ICD_UID"].Caption = "ICD Code";
            gridView3.Columns["ICD_UID"].Width = 50;

            gridView3.Columns["SEVERITY_UID"].ColVIndex = 9;
            gridView3.Columns["SEVERITY_UID"].Caption = "Severity Code";
            gridView3.Columns["SEVERITY_UID"].Width = 50;

            gridView3.Columns["SEVERITY_NAME"].ColVIndex = 10;
            gridView3.Columns["SEVERITY_NAME"].Caption = "Severity Name";
            gridView3.Columns["SEVERITY_NAME"].Width = 75;

            //gridView3.Columns["HL7_TEXT"].ColVIndex = 11;
            //gridView3.Columns["HL7_TEXT"].Caption = "Log ID";
            //gridView3.Columns["HL7_TEXT"].Width = 75;

            gridView3.Columns["RELEASED_BY"].ColVIndex = 13;
            gridView3.Columns["RELEASED_BY"].Caption = "Released by";
            gridView3.Columns["RELEASED_BY"].Width = 100;

            gridView3.Columns["RELEASED_ON"].ColVIndex = 14;
            gridView3.Columns["RELEASED_ON"].Caption = "Released on";
            gridView3.Columns["RELEASED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView3.Columns["RELEASED_ON"].DisplayFormat.FormatString = "g";
            gridView3.Columns["RELEASED_ON"].Width = 75;

            gridView3.Columns["FINALIZED_BY"].ColVIndex = 15;
            gridView3.Columns["FINALIZED_BY"].Caption = "Finalized by";
            gridView3.Columns["FINALIZED_BY"].Width = 100;

            gridView3.Columns["FINALIZED_ON"].ColVIndex = 16;
            gridView3.Columns["FINALIZED_ON"].Caption = "Finalized on";
            gridView3.Columns["FINALIZED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView3.Columns["FINALIZED_ON"].DisplayFormat.FormatString = "g";
            gridView3.Columns["FINALIZED_ON"].Width = 75;

            gridView3.Columns["CREATED_BY"].ColVIndex = 17;
            gridView3.Columns["CREATED_BY"].Caption = "Created by";
            gridView3.Columns["CREATED_BY"].Width = 100;

            gridView3.Columns["CREATED_ON"].ColVIndex = 18;
            gridView3.Columns["CREATED_ON"].Caption = "Created on";
            gridView3.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView3.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView3.Columns["CREATED_ON"].Width = 100;

            gridView3.Columns["LAST_MODIFIED_BY"].ColVIndex = 19;
            gridView3.Columns["LAST_MODIFIED_BY"].Caption = "Last Modify on";
            gridView3.Columns["LAST_MODIFIED_BY"].Width = 100;

            gridView3.Columns["LAST_MODIFIED_ON"].ColVIndex = 20;
            gridView3.Columns["LAST_MODIFIED_ON"].Caption = "Last Modify on";
            gridView3.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView3.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatString = "g";
            gridView3.Columns["LAST_MODIFIED_ON"].Width = 100;

            //gridView3.BestFitColumns();

            #endregion 

            #region setStyleCon

            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["RESULT_STATUS"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["RESULT_STATUS"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["RESULT_STATUS"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["RESULT_STATUS"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["RESULT_STATUS"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            gridView3.FormatConditions.Clear();
            gridView3.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });



            DevExpress.XtraGrid.StyleFormatCondition stylCon11
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Deleted");
            stylCon11.Appearance.ForeColor = Color.Red;

            DevExpress.XtraGrid.StyleFormatCondition stylCon22
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Added");
            stylCon22.Appearance.ForeColor = Color.Green;

            DevExpress.XtraGrid.StyleFormatCondition stylCon33
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Edited(before)");
            stylCon33.Appearance.ForeColor = Color.Goldenrod;

            DevExpress.XtraGrid.StyleFormatCondition stylCon44
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView3.Columns["OPERATION_STATUS"], null, "Edited(after)");
            stylCon44.Appearance.ForeColor = Color.DarkGoldenrod;

            gridView3.FormatConditions.Clear();
            gridView3.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon11, stylCon22, stylCon33, stylCon44 });


            #endregion

        }

        private void LoadTableRisExamresultTemplate()
        {
            ProcessGetRISExamresulttemplatelog bg = new ProcessGetRISExamresulttemplatelog();
            DateTime fd = new DateTime(txtFrom.DateTime.Year, txtFrom.DateTime.Month, txtFrom.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtTo.DateTime.Year, txtTo.DateTime.Month, txtTo.DateTime.Day, 23, 59, 59);
            bg.RISExamresulttemplatelog.FROMDATE = fd;
            bg.RISExamresulttemplatelog.TODATE = td;
            bg.Invoke();
            dtExamresultTemplate = bg.Result.Tables[0];
        }
        private void LoadFilterRisExamresultTemplate()
        {
            DataTable dt = dtExamresultTemplate.Copy();

            #region filterRadiologist

            if (!chkAll.Checked)
            {
                if (txtRadiologist.Tag != null)
                {
                    DataTable dtr = dt.Clone();
                    string Query = "";
                    string[] empid = txtRadiologist.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < empid.Length; i++)
                    {
                        Query += " RAD_ID = " + empid[i].ToString();
                        if (i + 1 < empid.Length)
                            Query += " or ";
                    }
                    DataRow[] drr = dt.Select(Query);
                    foreach (DataRow dr in drr)
                        dtr.Rows.Add(dr.ItemArray);

                    dt = dtr;
                }
                else
                {
                    dt.Rows.Clear();
                }
            }

            #endregion

            #region filterCheck
            DataTable dtc = dt.Clone();
            DataRow[] drs;
            if (chkInsert.Checked && chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked && chkUpdate.Checked)
                drs = dt.Select("OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=3 OR OPERATION=4");
            else if (chkDelete.Checked && chkInsert.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2");
            else if (chkDelete.Checked)
                drs = dt.Select("OPERATION=1");
            else if (chkUpdate.Checked)
                drs = dt.Select("OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked)
                drs = dt.Select("OPERATION=2");
            else
                drs = dt.Clone().Select();
            foreach (DataRow dr in drs)
                dtc.Rows.Add(dr.ItemArray);

            #endregion

            dt = dtc.Copy();
            dt.AcceptChanges();
            gridControl4.DataSource = dt;
            gridView4.RefreshData();
        }
        private void LoadGridRisExamresultTemplate()
        {
            for (int i = 0; i < gridView4.Columns.Count; i++)
            {
                gridView4.Columns[i].Visible = false;
                gridView4.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridView4.Columns["OPERATION_STATUS"].ColVIndex = 0;
            gridView4.Columns["OPERATION_STATUS"].Caption = "Operation";

            gridView4.Columns["EXAM_UID"].ColVIndex = 1;
            gridView4.Columns["EXAM_UID"].Caption = "Exam Code";

            gridView4.Columns["EXAM_NAME"].ColVIndex = 2;
            gridView4.Columns["EXAM_NAME"].Caption = "Exam Name";

            gridView4.Columns["TEMPLATE_NAME"].ColVIndex = 3;
            gridView4.Columns["TEMPLATE_NAME"].Caption = "Template Name";

            gridView4.Columns["TEMPLATE_TYPE"].ColVIndex = 4;
            gridView4.Columns["TEMPLATE_TYPE"].Caption = "Template Type";

            gridView4.Columns["SEVERITY_UID"].ColVIndex = 5;
            gridView4.Columns["SEVERITY_UID"].Caption = "Severity Code";

            gridView4.Columns["SEVERITY_NAME"].ColVIndex = 6;
            gridView4.Columns["SEVERITY_NAME"].Caption = "Severity Name";

            gridView4.Columns["AUTO_APPLY"].ColVIndex = 7;
            gridView4.Columns["AUTO_APPLY"].Caption = "Auto Apply";

            gridView4.Columns["CREATED_BY"].ColVIndex = 8;
            gridView4.Columns["CREATED_BY"].Caption = "Created by";

            gridView4.Columns["CREATED_ON"].ColVIndex = 9;
            gridView4.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView4.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView4.Columns["CREATED_ON"].Caption = "Created on";

            gridView4.Columns["LAST_MODIFIED_BY"].ColVIndex = 10;
            gridView4.Columns["LAST_MODIFIED_BY"].Caption = "Last Modified by";

            gridView4.Columns["LAST_MODIFIED_ON"].ColVIndex = 11;
            gridView4.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView4.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatString = "g";
            gridView4.Columns["LAST_MODIFIED_ON"].Caption = "Last Modified on";

            #endregion

            #region setStyleCon

            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["OPERATION_STATUS"], null, "Deleted");
            stylCon1.Appearance.ForeColor = Color.Red;

            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["OPERATION_STATUS"], null, "Added");
            stylCon2.Appearance.ForeColor = Color.Green;

            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["OPERATION_STATUS"], null, "Edited(before)");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView4.Columns["OPERATION_STATUS"], null, "Edited(after)");
            stylCon4.Appearance.ForeColor = Color.DarkGoldenrod;

            gridView4.FormatConditions.Clear();
            gridView4.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4 });

            #endregion

        }

        private void LoadTableRisSchedule()
        {
            ProcessGetRISSchedulelog bg = new ProcessGetRISSchedulelog();
            DateTime fd = new DateTime(txtFrom.DateTime.Year, txtFrom.DateTime.Month, txtFrom.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtTo.DateTime.Year, txtTo.DateTime.Month, txtTo.DateTime.Day, 23, 59, 59);
            bg.RISSchedulelog.FROMDATE = fd;
            bg.RISSchedulelog.TODATE = td;
            bg.Invoke();
            DataTable dt = bg.Result.Tables[0].Clone();

            #region filterRadiologist

            if (!chkAll.Checked)
            {
                if (txtRadiologist.Tag != null)
                {
                    string Query = "";
                    string[] empid = txtRadiologist.Tag.ToString().Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < empid.Length; i++)
                    {
                        Query += " CREATED_BY=" + empid[i];
                        if (i + 1 < empid.Length)
                            Query += " or ";
                    }
                    DataRow[] drr = bg.Result.Tables[0].Select(Query);
                    foreach (DataRow dr in drr)
                        dt.Rows.Add(dr.ItemArray);
                    bg.Result.Tables.Clear();
                    bg.Result.Tables.Add(dt.Copy());
                    dt = bg.Result.Tables[0].Clone();
                }
                else
                {
                    bg.Result.Tables.Clear();
                    bg.Result.Tables.Add(dt.Copy());
                }
            }

            #endregion

            #region filterCheck

            DataRow[] drs;
            if (chkInsert.Checked && chkUpdate.Checked && chkDelete.Checked)
                drs = bg.Result.Tables[0].Select("OPERATION=1 OR OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked && chkUpdate.Checked)
                drs = bg.Result.Tables[0].Select("OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkUpdate.Checked && chkDelete.Checked)
                drs = bg.Result.Tables[0].Select("OPERATION=1 OR OPERATION=3 OR OPERATION=4");
            else if (chkDelete.Checked && chkInsert.Checked)
                drs = bg.Result.Tables[0].Select("OPERATION=1 OR OPERATION=2");
            else if (chkDelete.Checked)
                drs = bg.Result.Tables[0].Select("OPERATION=1");
            else if (chkUpdate.Checked)
                drs = bg.Result.Tables[0].Select("OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked)
                drs = bg.Result.Tables[0].Select("OPERATION=2");
            else
                drs = bg.Result.Tables[0].Clone().Select();
            if (drs.Length > 0)
                foreach (DataRow dr in drs)
                    dt.Rows.Add(dr.ItemArray);

            #endregion

            dt.AcceptChanges();
            dtSchedule = dt.Copy();
        }
        private void LoadFilterRisSchedule()
        {
            DataTable dt = dtSchedule.Copy();

            #region filterCheck

            DataTable dtc = dt.Clone();
            DataRow[] drs;
            if (chkInsert.Checked && chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked && chkUpdate.Checked)
                drs = dt.Select("OPERATION=2 OR OPERATION=3 OR OPERATION=4");
            else if (chkUpdate.Checked && chkDelete.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=3 OR OPERATION=4");
            else if (chkDelete.Checked && chkInsert.Checked)
                drs = dt.Select("OPERATION=1 OR OPERATION=2");
            else if (chkDelete.Checked)
                drs = dt.Select("OPERATION=1");
            else if (chkUpdate.Checked)
                drs = dt.Select("OPERATION=3 OR OPERATION=4");
            else if (chkInsert.Checked)
                drs = dt.Select("OPERATION=2");
            else
                drs = dt.Clone().Select();
            foreach (DataRow dr in drs)
                dtc.Rows.Add(dr.ItemArray);

            #endregion

            dt = dtc.Copy();
            dt.AcceptChanges();
            gridControl5.DataSource = dt;
            gridView5.RefreshData();
        }
        private void LoadGridRisSchedule()
        {
            for (int i = 0; i < gridView5.Columns.Count; i++)
            {
                gridView5.Columns[i].Visible = false;
                gridView5.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridView5.Columns["HN"].ColVIndex = 1;
            gridView5.Columns["HN"].Caption = "HN";

            gridView5.Columns["PATIENTNAME"].ColVIndex = 2;
            gridView5.Columns["PATIENTNAME"].Caption = "Patient Name";

            gridView5.Columns["OPERATION_STATUS"].ColVIndex = 0;
            gridView5.Columns["OPERATION_STATUS"].Caption = "Operation";

            gridView5.Columns["EXAM_UID"].ColVIndex = 3;
            gridView5.Columns["EXAM_UID"].Caption = "Exam Code";

            gridView5.Columns["EXAM_NAME"].ColVIndex = 4;
            gridView5.Columns["EXAM_NAME"].Caption = "Exam Name";

            gridView5.Columns["APPOINT_DT"].ColVIndex = 5;
            gridView5.Columns["APPOINT_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView5.Columns["APPOINT_DT"].DisplayFormat.FormatString = "g";
            gridView5.Columns["APPOINT_DT"].Caption = "Apoint Time";

            gridView5.Columns["QTY"].ColVIndex = 6;
            gridView5.Columns["QTY"].Caption = "Quantity";

            gridView5.Columns["SPECIAL_CLINIC"].ColVIndex = 7;
            gridView5.Columns["SPECIAL_CLINIC"].Caption = "Comments";

            gridView5.Columns["ALLPROPERTIES"].ColVIndex = 8;
            gridView5.Columns["ALLPROPERTIES"].Caption = "All Property";

            gridView5.Columns["SCHEDULE_DATA"].ColVIndex = 9;
            gridView5.Columns["SCHEDULE_DATA"].Caption = "Schedule Data";

            gridView5.Columns["BLOCK_REASON"].ColVIndex = 10;
            gridView5.Columns["BLOCK_REASON"].Caption = "Block Reason";

            gridView5.Columns["ADMISSION_NO"].ColVIndex = 11;
            gridView5.Columns["ADMISSION_NO"].Caption = "Admission no.";

            gridView5.Columns["SCHEDULE_DT"].ColVIndex = 12;
            gridView5.Columns["SCHEDULE_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView5.Columns["SCHEDULE_DT"].DisplayFormat.FormatString = "g";
            gridView5.Columns["SCHEDULE_DT"].Caption = "Schedule Time";

            gridView5.Columns["UNIT_UID"].ColVIndex = 13;
            gridView5.Columns["UNIT_UID"].Caption = "Unit Code";

            gridView5.Columns["UNIT_NAME"].ColVIndex = 14;
            gridView5.Columns["UNIT_NAME"].Caption = "Unit Name";

            gridView5.Columns["DOCNAME"].ColVIndex = 15;
            gridView5.Columns["DOCNAME"].Caption = "Doctor Name";

            gridView5.Columns["RADNAME"].ColVIndex = 16;
            gridView5.Columns["RADNAME"].Caption = "Radiologist Name";

            gridView5.Columns["REASON"].ColVIndex = 17;
            gridView5.Columns["REASON"].Caption = "";

            gridView5.Columns["SCHEDULE_STATUS"].ColVIndex = 18;
            gridView5.Columns["SCHEDULE_STATUS"].Caption = "Schedule Status";

            gridView5.Columns["CONFIRMED_BY"].ColVIndex = 19;
            gridView5.Columns["CONFIRMED_BY"].Caption = "Confirmed by";

            gridView5.Columns["CONFIRMED_ON"].ColVIndex = 20;
            gridView5.Columns["CONFIRMED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView5.Columns["CONFIRMED_ON"].DisplayFormat.FormatString = "g";
            gridView5.Columns["CONFIRMED_ON"].Caption = "Confirmed on";

            gridView5.Columns["CLINIC_TYPE_UID"].ColVIndex = 21;
            gridView5.Columns["CLINIC_TYPE_UID"].Caption = "Clinic Type Code";

            gridView5.Columns["RATE"].ColVIndex = 22;
            gridView5.Columns["RATE"].Caption = "Rate";

            gridView5.Columns["IS_BLOCK"].ColVIndex = 23;
            gridView5.Columns["IS_BLOCK"].Caption = "Is Blocked";

            gridView5.Columns["CREATED_BY"].ColVIndex = 24;
            gridView5.Columns["CREATED_BY"].Caption = "Created by";

            gridView5.Columns["CREATED_ON"].ColVIndex = 25;
            gridView5.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView5.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView5.Columns["CREATED_ON"].Caption = "Created on";

            gridView5.Columns["LAST_MODIFIED_BY"].ColVIndex = 26;
            gridView5.Columns["LAST_MODIFIED_BY"].Caption = "Modified by";

            gridView5.Columns["LAST_MODIFIED_ON"].ColVIndex = 27;
            gridView5.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView5.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatString = "g";
            gridView5.Columns["LAST_MODIFIED_ON"].Caption = "Modified on";

            #endregion

            #region setStyleCon

            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView5.Columns["OPERATION_STATUS"], null, "Deleted");
            stylCon1.Appearance.ForeColor = Color.Red;

            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView5.Columns["OPERATION_STATUS"], null, "Added");
            stylCon2.Appearance.ForeColor = Color.Green;

            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView5.Columns["OPERATION_STATUS"], null, "Edited(before)");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView5.Columns["OPERATION_STATUS"], null, "Edited(after)");
            stylCon4.Appearance.ForeColor = Color.DarkGoldenrod;

            gridView5.FormatConditions.Clear();
            gridView5.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4 });

            #endregion

        }

        private void Reload()
        {
            string Query = "";
            this.Enabled = false;
            layoutControlGroup3.Text = rdoInstance.Properties.Items[rdoInstance.SelectedIndex].Description;

            if (rdoInstance.SelectedIndex == 0)
            {
                txtRadiologist.Enabled = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
                if (needtoload)
                    LoadTableGblEnv();
                LoadFilterGblEnv();
                LoadGridGblEnv();
                Query = "select START_TIME from dbo.GBL_ENVLOGCAPTURE order by START_TIME desc";
            }
            else if (rdoInstance.SelectedIndex == 1)
            {
                txtRadiologist.Enabled = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
                if (needtoload)
                    LoadTableRisExam();
                LoadFilterRisExam();
                LoadGridRisExam();
                Query = "select START_TIME from dbo.RIS_EXAMLOGCAPTURE order by START_TIME desc";
            }
            else if (rdoInstance.SelectedIndex == 2)
            {
                txtRadiologist.Enabled = true;
                chkAll.Checked = chkAll.Checked;
                chkAll.Enabled = true;
                if (needtoload)
                    LoadTableRisExamresult();
                LoadFilterRisExamresult();
                LoadGridRisExamresult();
                Query = "select START_TIME from dbo.RIS_EXAMRESULTLOGCAPTURE order by START_TIME desc";
            }
            else if (rdoInstance.SelectedIndex == 3)
            {
                txtRadiologist.Enabled = true;
                chkAll.Checked = chkAll.Checked;
                chkAll.Enabled = true;
                if (needtoload)
                    LoadTableRisExamresultTemplate();
                LoadFilterRisExamresultTemplate();
                LoadGridRisExamresultTemplate();
                Query = "select START_TIME from dbo.RIS_EXAMRESULTTEMPLATELOGCAPTURE order by START_TIME desc";
            }
            else if (rdoInstance.SelectedIndex == 4)
            {
                txtRadiologist.Enabled = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
                if (needtoload)
                    LoadTableRisSchedule();
                LoadFilterRisSchedule();
                LoadGridRisSchedule();
                Query = "select START_TIME from dbo.RIS_SCHEDULELOGCAPTURE order by START_TIME desc";
            }

            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = Query;
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
            }

            txtAuditTime.Text = "";
            int k = 1;
            foreach (DataRow dr in dt.Rows)
            {
                txtAuditTime.Text += k + "#" + Convert.ToDateTime(dr["START_TIME"]).ToString("g") + "  ";
                ++k;
            }

            this.Enabled = true;
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            //needtoload = false;
            //Reload();
            //needtoload = true;
        }
        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            //needtoload = false;
            //Reload();
            //needtoload = true;
        }
        private void chkInsert_CheckedChanged(object sender, EventArgs e)
        {
            //needtoload = false;
            //Reload();
            //needtoload = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
        }
        private void btnAuditData_Click(object sender, EventArgs e)
        {
            MyMessageBox mms = new MyMessageBox();
            if (mms.ShowAlert("UID2117", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID) == "2")
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                DataTable dt = new DataTable();
                string Query = "";

                if (rdoInstance.SelectedIndex == 0)
                    Query = "EXEC dbo.Prc_GBL_ENVLOG_Migrate";
                else if (rdoInstance.SelectedIndex == 1)
                    Query = "EXEC dbo.Prc_RIS_EXAMLOG_Migrate";
                else if (rdoInstance.SelectedIndex == 2)
                    Query = "EXEC dbo.Prc_RIS_EXAMRESULTLOG_Migrate";
                else if (rdoInstance.SelectedIndex == 3)
                    Query = "EXEC dbo.Prc_RIS_EXAMRESULTTEMPLATELOG_Migrate";
                else if (rdoInstance.SelectedIndex == 4)
                    Query = "EXEC dbo.Prc_RIS_SCHEDULELOG_Migrate";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = Query;
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(dt);
                }

                Reload();
            }
        }
        private void txtRadiologist_Click(object sender, EventArgs e)
        {
            LogMonitoringRad frm = new LogMonitoringRad(txtRadiologist);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                chkAll.Checked = false;
                Reload();
            }
        }

        private void rdoInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = rdoInstance.SelectedIndex;
            Reload();         
        }

    }
}