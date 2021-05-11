using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;

namespace RIS.Forms.Admin
{
    public partial class ExamresultLog : Form
    {
        DataTable dtRad = new DataTable();
        DataTable dtWL = new DataTable();

        public ExamresultLog(UUL.ControlFrame.Controls.TabControl tabcontrol)
        {
            InitializeComponent();
            txtFrom.DateTime = txtTo.DateTime = DateTime.Now;
            layoutControlGroup2.Expanded = false;
            Reload();
        }

        private void LoadTable()
        {
            ProcessGetRISExamresultlog bg = new ProcessGetRISExamresultlog();
            DateTime fd = new DateTime(txtFrom.DateTime.Year, txtFrom.DateTime.Month, txtFrom.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtTo.DateTime.Year, txtTo.DateTime.Month, txtTo.DateTime.Day, 11, 59, 59);
            bg.RISExamresultlog.FROMDATE = fd;
            bg.RISExamresultlog.TODATE = td;
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
                        Query += " EMP_ID=" + empid[i];
                        if (i + 1 < empid.Length)
                            Query += " or ";
                    }
                    DataRow[] drs = bg.Result.Tables[0].Select(Query);
                    foreach (DataRow dr in drs)
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

            if (chkUpdate.Checked && chkDelete.Checked)
            {
                DataRow[] drs = bg.Result.Tables[0].Select("OPERATION=1 OR OPERATION=3 OR OPERATION=4");
                if (drs.Length > 0)
                    foreach (DataRow dr in drs)
                        dt.Rows.Add(dr.ItemArray);
            }
            else if (chkDelete.Checked)
            {
                DataRow[] drs = bg.Result.Tables[0].Select("OPERATION=1");
                if (drs.Length > 0)
                    foreach (DataRow dr in drs)
                        dt.Rows.Add(dr.ItemArray);
            }
            else if (chkUpdate.Checked)
            {
                DataRow[] drs = bg.Result.Tables[0].Select("OPERATION=3 OR OPERATION=4");
                if (drs.Length > 0)
                    foreach (DataRow dr in drs)
                        dt.Rows.Add(dr.ItemArray);
            }
            else
            {
                dt = bg.Result.Tables[0];
            }

            #endregion

            dt.AcceptChanges();
            dtWL = dt.Copy();
        }

        private void LoadGrid()
        {
            gridControl1.DataSource = dtWL.Copy();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            //gridView1.Columns["EFFECTIVE_DT"].VisibleIndex = 1;
            //gridView1.Columns["EFFECTIVE_DT"].Caption = "Effective Date";
            //gridView1.Columns["EFFECTIVE_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //gridView1.Columns["EFFECTIVE_DT"].DisplayFormat.FormatString = "g";
            //gridView1.Columns["EFFECTIVE_DT"].Width = 75;

            gridView1.Columns["ACCESSION_NO"].VisibleIndex = 1;
            gridView1.Columns["ACCESSION_NO"].Caption = "Accession No.";
            gridView1.Columns["ACCESSION_NO"].Width = 75;

            gridView1.Columns["HN"].VisibleIndex = 2;
            gridView1.Columns["HN"].Caption = "HN";
            gridView1.Columns["HN"].Width = 75;

            gridView1.Columns["PATIENTNAME"].VisibleIndex = 2;
            gridView1.Columns["PATIENTNAME"].Caption = "Patient Name";
            gridView1.Columns["PATIENTNAME"].Width = 100;

            gridView1.Columns["ORDER_ID"].VisibleIndex = 3;
            gridView1.Columns["ORDER_ID"].Caption = "Order Code";
            gridView1.Columns["ORDER_ID"].Width = 50;

            gridView1.Columns["EXAM_UID"].VisibleIndex = 4;
            gridView1.Columns["EXAM_UID"].Caption = "Exam Code";
            gridView1.Columns["EXAM_UID"].Width = 50;

            gridView1.Columns["EXAM_NAME"].VisibleIndex = 5;
            gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView1.Columns["EXAM_NAME"].Width = 75;

            gridView1.Columns["RESULT_STATUS"].VisibleIndex = 6;
            gridView1.Columns["RESULT_STATUS"].Caption = "Result Status";
            gridView1.Columns["RESULT_STATUS"].Width = 75;

            gridView1.Columns["HL7_SEND"].VisibleIndex = 7;
            gridView1.Columns["HL7_SEND"].Caption = "HL7 Status";
            gridView1.Columns["HL7_SEND"].Width = 50;

            gridView1.Columns["OPERATION_STATUS"].VisibleIndex = 7;
            gridView1.Columns["OPERATION_STATUS"].Caption = "Operation Status";
            gridView1.Columns["OPERATION_STATUS"].Width = 50;

            gridView1.Columns["ICD_UID"].VisibleIndex = 8;
            gridView1.Columns["ICD_UID"].Caption = "ICD Code";
            gridView1.Columns["ICD_UID"].Width = 50;

            gridView1.Columns["SEVERITY_UID"].VisibleIndex = 9;
            gridView1.Columns["SEVERITY_UID"].Caption = "Severity Code";
            gridView1.Columns["SEVERITY_UID"].Width = 50;

            gridView1.Columns["SEVERITY_NAME"].VisibleIndex = 10;
            gridView1.Columns["SEVERITY_NAME"].Caption = "Severity Name";
            gridView1.Columns["SEVERITY_NAME"].Width = 75;

            //gridView1.Columns["HL7_TEXT"].VisibleIndex = 11;
            //gridView1.Columns["HL7_TEXT"].Caption = "Log ID";
            //gridView1.Columns["HL7_TEXT"].Width = 75;

            gridView1.Columns["RELEASED_BY"].VisibleIndex = 13;
            gridView1.Columns["RELEASED_BY"].Caption = "Released by";
            gridView1.Columns["RELEASED_BY"].Width = 100;

            gridView1.Columns["RELEASED_ON"].VisibleIndex = 14;
            gridView1.Columns["RELEASED_ON"].Caption = "Released on";
            gridView1.Columns["RELEASED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["RELEASED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["RELEASED_ON"].Width = 75;

            gridView1.Columns["FINALIZED_BY"].VisibleIndex = 15;
            gridView1.Columns["FINALIZED_BY"].Caption = "Finalized by";
            gridView1.Columns["FINALIZED_BY"].Width = 100;

            gridView1.Columns["FINALIZED_ON"].VisibleIndex = 16;
            gridView1.Columns["FINALIZED_ON"].Caption = "Finalized on";
            gridView1.Columns["FINALIZED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["FINALIZED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["FINALIZED_ON"].Width = 75;

            gridView1.Columns["CREATED_BY"].VisibleIndex = 17;
            gridView1.Columns["CREATED_BY"].Caption = "Created by";
            gridView1.Columns["CREATED_BY"].Width = 100;

            gridView1.Columns["CREATED_ON"].VisibleIndex = 18;
            gridView1.Columns["CREATED_ON"].Caption = "Created on";
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CREATED_ON"].Width = 75;

            //gridView1.Columns["LAST_MODIFIED_BY"].VisibleIndex = 19;
            //gridView1.Columns["LAST_MODIFIED_BY"].Caption = "Log ID";
            //gridView1.Columns["LAST_MODIFIED_BY"].Width = 75;

            //gridView1.Columns["LAST_MODIFIED_ON"].VisibleIndex = 20;
            //gridView1.Columns["LAST_MODIFIED_ON"].Caption = "Log ID";
            //gridView1.Columns["LAST_MODIFIED_ON"].Width = 75;

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

        }

        private void Reload()
        {
            LoadTable();
            LoadGrid();
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtResultReport.Rtf = dr["RESULT_TEXT_RTF"].ToString();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtResultReport.Rtf = dr["RESULT_TEXT_RTF"].ToString();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void txtRadiologist_Click(object sender, EventArgs e)
        {
            ExamresultLog_Radiologist frm = new ExamresultLog_Radiologist(txtRadiologist);
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Location = new Point(txtRadiologist.Location.X, txtRadiologist.Location.Y + txtRadiologist.Size.Height);
            //frm.Size = new Size(txtRadiologist.Size.Width, 400);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Reload();
            }
            else
            { 
            
            }
        }

    }
}