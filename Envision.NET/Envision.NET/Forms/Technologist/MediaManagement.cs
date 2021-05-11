using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessDelete;


namespace Envision.NET.Forms.Technologist
{
    public partial class MediaManagement : Envision.NET.Forms.Main.MasterForm
    {
        private int a = 0;//for grid
        private string examUID, examname, examid, examAccession,orderid;
        private string loadID, examidEdit; //for Edit 
        private string ReleaseID, hisID;
        private int unitRe, empidRe;
        private string unit, empid, checkstatus;
        MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();

        private DataTable dtReleaseHistory;

        public MediaManagement()
        {
            InitializeComponent();
            setDefaultRelease();
            layoutControlGroup1.Enabled = false;
            layoutControlGroup2.Enabled = false;
            layoutControlGroup3.Enabled = false;
        }

        #region BarControl

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((Envision.NET.Forms.Main.frmMain)this.MdiParent).DisplayHome();
        }


        #endregion


        private struct MyItem
        {
            public string Key;
            public string Value;
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
        }

        #region Release New Version

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
                    get.RIS_RELEASEMEDIA.SELECTCASE = 0;
                    get.RIS_RELEASEMEDIA.HN = txtHN.Text.Trim();
                    get.Invoke();
                    DataTable dt = get.Result.Tables[0];
                    DataTable dt1 = get.Result.Tables[1];
                    if (!dt1.Columns.Contains("CHK"))
                        dt1.Columns.Add("CHK");
                    grcData.DataSource = dt1;
                    setGridData("CHK");

                    if (dt1 != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (dt1.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt1.Rows[0]["ACCESSION_NO"].ToString()))
                                {
                                    forGridRelease(dt1.Rows[0]["ACCESSION_NO"].ToString());

                                    txtPatientName.Text = dt.Rows[0]["PATIENTNAME"].ToString();
                                    txtAge.Text = dt.Rows[0]["AGE"].ToString();
                                }
                            }
                            else
                            {
                                msg.ShowAlert("UID009", env.CurrentLanguageID);
                                txtHN.SelectionStart = 0;
                                txtHN.SelectionLength = txtHN.Text.Length;
                                txtHN.Focus();
                            }
                        }
                        else
                        {
                            msg.ShowAlert("UID4024", env.CurrentLanguageID);
                            txtHN.SelectionStart = 0;
                            txtHN.SelectionLength = txtHN.Text.Length;
                            txtHN.Focus();
                        }
                    }
                    ReleaseHistoryReload();
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
            get.RIS_RELEASEMEDIA.SELECTCASE = 0;
            get.RIS_RELEASEMEDIA.HN = "-1";
            get.Invoke();
            DataTable dtData = get.Result.Tables[1];
            if (!dtData.Columns.Contains("CHK"))
                dtData.Columns.Add("CHK");
            grcData.DataSource = dtData;
            setGridData("CHK");

            get.RIS_RELEASEMEDIA.SELECTCASE = 2;
            get.RIS_RELEASEMEDIA.ACCESSION_NO = "-1";
            get.Invoke();
            DataTable dtRelease = get.Result.Tables[0];
            if (!dtRelease.Columns.Contains("colDelete"))
                dtRelease.Columns.Add("colDelete");
            grcRelease.DataSource = dtRelease;
            setGridRelease();
        }
        private void setGridData(string chk)
        {
            for (int i = 0; i < viewData.Columns.Count; i++)
            {
                viewData.Columns[i].Visible = false;
            }
            if (chk == "CHK")
            {
                DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
     chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                chkTemplate.ValueChecked = "Y";
                chkTemplate.ValueUnchecked = "N";
                chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
                chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
                chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                chkTemplate.Click += new EventHandler(chk_Click);


                viewData.Columns["CHK"].Width = -1;
                viewData.Columns["CHK"].ColVIndex = 1;
                viewData.Columns["CHK"].Caption = " ";
                viewData.Columns["CHK"].ColumnEdit = chkTemplate;
            }

            viewData.Columns["ACCESSION_NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ACCESSION_NO"].ColVIndex = 2;
            viewData.Columns["ACCESSION_NO"].Caption = "Accession No.";
            viewData.Columns["ACCESSION_NO"].OptionsColumn.AllowEdit = false;
            viewData.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
            //viewData.Columns["ACCESSION_NO"].Width = 90;

            viewData.Columns["EXAM_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_ID"].Visible = false;
            viewData.Columns["EXAM_ID"].Caption = "Exam ID";
            viewData.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["EXAM_CODE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_CODE"].ColVIndex = 2;
            viewData.Columns["EXAM_CODE"].Caption = "Exam Code";
            viewData.Columns["EXAM_CODE"].OptionsColumn.AllowEdit = false;
            viewData.Columns["EXAM_CODE"].OptionsColumn.ReadOnly = true;
            //viewData.Columns["EXAM_CODE"].Width = 30;

            viewData.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM_NAME"].ColVIndex = 3;
            viewData.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewData.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;
            viewData.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            //viewData.Columns["EXAM_NAME"].Width = 70;

            RepositoryItemTextEdit txt = new RepositoryItemTextEdit();
            viewData.Columns["STUDY_DATETIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["STUDY_DATETIME"].ColVIndex = 4;
            viewData.Columns["STUDY_DATETIME"].ColumnEdit = txt;
            viewData.Columns["STUDY_DATETIME"].Caption = "Study data-time";
            viewData.Columns["STUDY_DATETIME"].OptionsColumn.AllowEdit = false;
            viewData.Columns["STUDY_DATETIME"].OptionsColumn.ReadOnly = true;
            //viewData.Columns["STUDY_DATETIME"].Width = 100;

            viewData.Columns["PATIENTNAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["PATIENTNAME"].ColVIndex = 5;
            viewData.Columns["PATIENTNAME"].Caption = "Patient";
            viewData.Columns["ACCESSION_NO"].OptionsColumn.AllowEdit = false;
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
        private void chk_Click(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (viewData.FocusedRowHandle > -1)
                {
                    viewData.OptionsBehavior.Editable = false;

                    DataRow drChk = viewData.GetDataRow(viewData.FocusedRowHandle);
                    if (chk.Checked == false)
                        drChk["CHK"] = "Y";
                    else
                        drChk["CHK"] = "N";

                    drChk.AcceptChanges();

                    viewData.OptionsBehavior.Editable = true;
                }
            }
        }
        
        private void setGridRelease()
        {
            viewRelease.Columns["RELEASE_ID"].Visible = false;

            viewRelease.Columns["RequestDept"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["RequestDept"].Visible = true;
            viewRelease.Columns["RequestDept"].Caption = "Request Dept.";
            viewRelease.Columns["RequestDept"].OptionsColumn.AllowEdit = false;
            viewRelease.Columns["RequestDept"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["RequestDept"].BestFit();

            viewRelease.Columns["RequestBy"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["RequestBy"].Visible = true;
            viewRelease.Columns["RequestBy"].Caption = "Requested By";
            viewRelease.Columns["RequestBy"].OptionsColumn.AllowEdit = false;
            viewRelease.Columns["RequestBy"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["RequestBy"].BestFit();

            viewRelease.Columns["MEDIA_TYPE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["MEDIA_TYPE"].Visible = true;
            viewRelease.Columns["MEDIA_TYPE"].Caption = "Media Type";
            viewRelease.Columns["MEDIA_TYPE"].OptionsColumn.AllowEdit = false;
            viewRelease.Columns["MEDIA_TYPE"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["MEDIA_TYPE"].BestFit();

            viewRelease.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["QTY"].Visible = true;
            viewRelease.Columns["QTY"].Caption = "Qty";
            viewRelease.Columns["QTY"].OptionsColumn.AllowEdit = false;
            viewRelease.Columns["QTY"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["QTY"].BestFit();

            viewRelease.Columns["PRINTBY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["PRINTBY"].Visible = true;
            viewRelease.Columns["PRINTBY"].Caption = "Printed By";
            viewRelease.Columns["PRINTBY"].OptionsColumn.AllowEdit = false;
            viewRelease.Columns["PRINTBY"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["PRINTBY"].BestFit();

            RepositoryItemTextEdit txt = new RepositoryItemTextEdit();
            viewRelease.Columns["CREATED_ON"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["CREATED_ON"].Visible = true;
            viewRelease.Columns["CREATED_ON"].ColumnEdit = txt;
            viewRelease.Columns["CREATED_ON"].Caption = "Printed Timestamp";
            viewRelease.Columns["CREATED_ON"].OptionsColumn.AllowEdit = false;
            viewRelease.Columns["CREATED_ON"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["CREATED_ON"].BestFit();

            RepositoryItemMemoEdit mem = new RepositoryItemMemoEdit();
            viewRelease.Columns["COMMENT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewRelease.Columns["COMMENT"].Visible = true;
            viewRelease.Columns["COMMENT"].ColumnEdit = mem;
            viewRelease.Columns["COMMENT"].Caption = "Comment";
            viewRelease.Columns["COMMENT"].OptionsColumn.AllowEdit = false;
            viewRelease.Columns["COMMENT"].OptionsColumn.ReadOnly = true;
            viewRelease.Columns["COMMENT"].BestFit();

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.BestFitWidth = 9;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnDeleteRow_Click);
            viewRelease.Columns["colDelete"].Caption = " ";
            viewRelease.Columns["colDelete"].ColumnEdit = btn;
            viewRelease.Columns["colDelete"].OptionsColumn.AllowEdit = true;
            viewRelease.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            viewRelease.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewRelease.Columns["colDelete"].BestFit();
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (viewRelease.FocusedRowHandle >= 0)
            {
                DataRow row = viewRelease.GetDataRow(viewRelease.FocusedRowHandle);
                ProcessDeleteRISReleasemedia del = new ProcessDeleteRISReleasemedia();
                del.RIS_RELEASEMEDIA.RELEASE_ID = Convert.ToInt32(row["RELEASE_ID"]);
                del.Invoke();

                DataRow rowData = viewData.GetDataRow(viewData.FocusedRowHandle);
                forGridRelease(rowData["ACCESSION_NO"].ToString());
            }
        }
        
        private void txtAccession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtAccession.Text))
                {
                    ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
                    get.RIS_RELEASEMEDIA.SELECTCASE = 1;
                    get.RIS_RELEASEMEDIA.ACCESSION_NO = txtAccession.Text.Trim();
                    get.Invoke();
                    DataTable dt = get.Result.Tables[0];
                    grcData.DataSource = dt;
                    setGridData("");

                    if (dt.Rows.Count > 0)
                    {
                        txtPatientName.Text = dt.Rows[0]["PATIENTNAME"].ToString();
                        txtAge.Text = dt.Rows[0]["AGE"].ToString();
                        txtHN.Text = dt.Rows[0]["HN"].ToString();
                    }
                    else
                    {
                        msg.ShowAlert("UID4027", env.CurrentLanguageID);
                        txtAccession.SelectionStart = 0;
                        txtAccession.SelectionLength = txtAccession.Text.Length;
                        txtAccession.Focus();
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
                if (dr != null)
                {
                    forGridRelease(dr["ACCESSION_NO"].ToString());
                }
            }
        }
        private void forGridRelease(string accession)
        {
            ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
            get.RIS_RELEASEMEDIA.SELECTCASE = 2;
            get.RIS_RELEASEMEDIA.ACCESSION_NO = accession;
            get.Invoke();
            DataTable dtRelease = get.Result.Tables[0];
            if (!dtRelease.Columns.Contains("colDelete"))
                dtRelease.Columns.Add("colDelete");
            grcRelease.DataSource = dtRelease;
            setGridRelease();
        }

        private void viewData_DoubleClick(object sender, EventArgs e)
        {
            DataTable dtData = (DataTable)grcData.DataSource;
            if (dtData.Rows.Count > 0)
            {
                DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);
                DataRow[] drr = dr.Table.Select("CHK = 'Y'");
                if (drr.Length == 0)
                    drr = dr.Table.Select("ACCESSION_NO = '" + dr["ACCESSION_NO"].ToString() + "'");
                frmPopupReleaseMedia frm = new frmPopupReleaseMedia(drr);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
                    get.RIS_RELEASEMEDIA.SELECTCASE = 2;
                    get.RIS_RELEASEMEDIA.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                    get.Invoke();
                    DataTable dtRelease = get.Result.Tables[0];
                    grcRelease.DataSource = dtRelease;
                }
            }
        } 
        #endregion

        private void MediaManagement_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
            ReleaseHistoryReload();

            setDefaultRelease();
            txtHN.Focus();
        }

        private void ReleaseHistoryLoadData()
        {
            string HN = txtHN.Text.Trim();

            ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
            get.RIS_RELEASEMEDIA.HN = HN;
            get.Invoke_History();
            dtReleaseHistory = get.Result.Tables[0];
        }
        private void ReleaseHistoryLoadFilter()
        { 
        }
        private void ReleaseHistoryLoadGrid()
        {
            gridControl1.DataSource = dtReleaseHistory;

            foreach (GridColumn colDev in gridView1.Columns)
            {
                //colDev.OptionsColumn.AllowEdit = false;
                colDev.OptionsColumn.ReadOnly = true;
            }

            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();
        }
        private void ReleaseHistoryReload()
        {
            ReleaseHistoryLoadData();
            ReleaseHistoryLoadFilter();
            ReleaseHistoryLoadGrid();
        }

        private void contextViewData_Opening(object sender, CancelEventArgs e)
        {
            DataTable dt = grcData.DataSource as DataTable;
            if (dt.Columns.Contains("CHK"))
            {
                DataRow[] rows = dt.Select("CHK='Y'");
                if (rows.Length > 1)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void multipleReleaseMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle >= 0)
            {
                DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);

                DataTable dt = grcData.DataSource as DataTable;
                DataRow[] rows = dt.Select("CHK='Y'");
                frmPopupReleaseMedia frm = new frmPopupReleaseMedia(rows);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ProcessGetRISReleasemediaNew get = new ProcessGetRISReleasemediaNew();
                    get.RIS_RELEASEMEDIA.SELECTCASE = 2;
                    get.RIS_RELEASEMEDIA.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                    get.Invoke();
                    DataTable dtRelease = get.Result.Tables[0];
                    grcRelease.DataSource = dtRelease;
                }
            }
        }
    }
}