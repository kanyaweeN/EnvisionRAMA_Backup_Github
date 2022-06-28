using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.Operational.PACS;

namespace Envision.NET.Forms.ResultEntry.ResultDialog
{
    public partial class dlgPeerReview : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataRow rowData;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        public dlgPeerReview(DataRow peerData)
        {
            InitializeComponent();
            rowData = peerData;
        }

        private void dlgPeerReview_Load(object sender, EventArgs e)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            setPROpinion();
            setLangOfReport();
            setPRSignificant();
            setEditorText();
            openPACS(rowData["ACCESSION_NO"].ToString());

            dlg.Close();
        }
        private void setPROpinion()
        {

            chkLike.Enabled = false;
            chkUnlike.Enabled = false;
            chkUnlike.Checked = false;
            chkLike.Checked = false;

            ProcessGetRISPRGrade getGrade = new ProcessGetRISPRGrade();
            getGrade.Invoke();
            DataTable dtGrade = getGrade.ResultSet.Tables[0];
            if (!dtGrade.Columns.Contains("CHK"))
                dtGrade.Columns.Add("CHK");


            foreach (DataRow dr in dtGrade.Rows)
            {
                dr["CHK"] = "N";
            }

            string strGradeID = string.IsNullOrEmpty(rowData["RAD_OPINION"].ToString()) ? "0" : rowData["RAD_OPINION"].ToString();
            DataRow[] chkGrade = dtGrade.Select("GRADE_ID=" + strGradeID);
            if (chkGrade.Length > 0)
                chkGrade[0]["CHK"] = "Y";


            grdOpinion.DataSource = dtGrade;

            for (int i = 0; i < viewOpinion.Columns.Count; i++)
                viewOpinion.Columns[i].Visible = false;

            viewOpinion.OptionsSelection.EnableAppearanceFocusedCell = false;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.Click += new EventHandler(chk_Click);

            //viewOpinion.OptionsView.ColumnAutoWidth = true;

            viewOpinion.Columns["CHK"].Caption = " ";
            viewOpinion.Columns["CHK"].ColVIndex = 1;
            viewOpinion.Columns["CHK"].OptionsColumn.ReadOnly = false;
            viewOpinion.Columns["CHK"].OptionsColumn.AllowEdit = true;
            viewOpinion.Columns["CHK"].OptionsFilter.AllowFilter = false;
            viewOpinion.Columns["CHK"].ColumnEdit = chk;
            viewOpinion.Columns["CHK"].Width = -1;

            viewOpinion.Columns["GRADE_LABEL"].ColVIndex = 2;
            viewOpinion.Columns["GRADE_LABEL"].Caption = "Opinion of Clinical Report";
            viewOpinion.Columns["GRADE_LABEL"].OptionsColumn.ReadOnly = true;
            viewOpinion.Columns["GRADE_LABEL"].OptionsColumn.AllowEdit = false;
            viewOpinion.Columns["GRADE_LABEL"].Width = 333;

        }

        private void setLangOfReport()
        {
            // Get Reporting Language info.
            DataTable dtLangOfReport = new DataTable();
            ProcessGetACReportingLanguage _processGetACReportingLanaguage = new ProcessGetACReportingLanguage();
            _processGetACReportingLanaguage.ORG_ID = env.OrgID;
            _processGetACReportingLanaguage.Invoke();
            dtLangOfReport = _processGetACReportingLanaguage.Result.Tables[0];
            if (!dtLangOfReport.Columns.Contains("CHK"))
                dtLangOfReport.Columns.Add("CHK");

            foreach (DataRow dr in dtLangOfReport.Rows)
            {
                dr["CHK"] = "N";
            }

            string strLangID = string.IsNullOrEmpty(rowData["REPORT_LANG_ID"].ToString()) ? "0" : rowData["REPORT_LANG_ID"].ToString();
            DataRow[] chkLangID = dtLangOfReport.Select("REPORT_LANG_ID=" + strLangID);
            if (chkLangID.Length > 0)
                chkLangID[0]["CHK"] = "Y";

            this.gridLangOfReport.DataSource = dtLangOfReport;

            for (int i = 0; i < viewLangOfReport.Columns.Count; i++)
                viewLangOfReport.Columns[i].Visible = false;

            viewLangOfReport.OptionsSelection.EnableAppearanceFocusedCell = false;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkLangOfReport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkLangOfReport.ValueChecked = "Y";
            chkLangOfReport.ValueUnchecked = "N";
            chkLangOfReport.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkLangOfReport.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chkLangOfReport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkLangOfReport.Click += new EventHandler(chkLangOfReport_Click);

            //viewLangOfReport.OptionsView.ColumnAutoWidth = true;

            viewLangOfReport.Columns["CHK"].Caption = " ";
            viewLangOfReport.Columns["CHK"].ColVIndex = 1;
            viewLangOfReport.Columns["CHK"].OptionsColumn.ReadOnly = false;
            viewLangOfReport.Columns["CHK"].OptionsColumn.AllowEdit = true;
            viewLangOfReport.Columns["CHK"].OptionsFilter.AllowFilter = false;
            viewLangOfReport.Columns["CHK"].ColumnEdit = chkLangOfReport;
            viewLangOfReport.Columns["CHK"].Width = -1;

            viewLangOfReport.Columns["REPORT_LANG_LABEL"].ColVIndex = 2;
            viewLangOfReport.Columns["REPORT_LANG_LABEL"].Caption = "Language of Report";
            viewLangOfReport.Columns["REPORT_LANG_LABEL"].OptionsColumn.ReadOnly = true;
            viewLangOfReport.Columns["REPORT_LANG_LABEL"].OptionsColumn.AllowEdit = false;
            viewLangOfReport.Columns["REPORT_LANG_LABEL"].Width = 361;
        }


        private void chkLangOfReport_Click(object sender, EventArgs e)
        {
            if (viewLangOfReport.FocusedRowHandle > -1)
            {
                for (int i = 0; i < viewLangOfReport.RowCount; i++)
                {
                    DataRow drClearChk = viewLangOfReport.GetDataRow(i);
                    drClearChk["CHK"] = "N";
                    drClearChk.AcceptChanges();
                }

                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;

                DataRow drChk = viewLangOfReport.GetDataRow(viewLangOfReport.FocusedRowHandle);
                if (chk.Checked == false)
                {
                    drChk["CHK"] = "Y";
                }
                else
                    drChk["CHK"] = "N";

                drChk.AcceptChanges();
            }
        }

        private void chk_Click(object sender, EventArgs e)
        {
            if (viewOpinion.FocusedRowHandle > -1)
            {
                for (int i = 0; i < viewOpinion.RowCount; i++)
                {
                    DataRow drClearChk = viewOpinion.GetDataRow(i);
                    drClearChk["CHK"] = "N";
                    drClearChk.AcceptChanges();
                }

                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
              
                DataRow drChk = viewOpinion.GetDataRow(viewOpinion.FocusedRowHandle);
                if (chk.Checked == false)
                {
                    drChk["CHK"] = "Y";
                    if (drChk["IS_DISAGREE"].ToString() == "Y")
                    {
                        chkLike.Enabled = true;
                        chkUnlike.Enabled = true;
                    }
                    else
                    {
                        chkLike.Enabled = false;
                        chkUnlike.Enabled = false;
                        chkUnlike.Checked = false;
                        chkLike.Checked = false;
                    }
                   
                }
                else
                {
                    drChk["CHK"] = "N";
                    chkLike.Enabled = false;
                    chkUnlike.Enabled = false;
                    chkUnlike.Checked = false;
                    chkLike.Checked = false;
                }

                drChk.AcceptChanges();
            }
        }


        private void setPRSignificant()
        {
            if (rowData["IS_CLINICALLY_SIGNIFICANT"].ToString() == "Y")
            {
                chkLike.Checked = true;
            }
            else if (rowData["IS_CLINICALLY_SIGNIFICANT"].ToString() == "N")
            {
                chkUnlike.Checked = true;
            }

            //rdoSignificant.SelectedIndex = rowData["IS_CLINICALLY_SIGNIFICANT"].ToString() == "N" ? 1 : 0;
            memComment.Text = rowData["RAD_COMMENTS"].ToString();
            memoLangOfReportComment.Text = rowData["REPORT_LANG_COMMENTS"].ToString();
        }
        private void setEditorText()
        {
            ProcessGetRISPRStudies getResultText = new ProcessGetRISPRStudies();
            rtResult.Document.RtfText = getResultText.getResultText(rowData["ACCESSION_NO"].ToString());

        }
        private string openPACS(string AccessionNumber)
        {
            //string str = env.PacsUrl + AccessionNumber;
            ////Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
            ////ieCom.OpenSynapseAccession(AccessionNumber);
            //if (env.LoginType == "W")
            //{
            //    str = env.PacsUrl;
            //    str = str.Replace("http://", string.Empty);
            //    str = "http://radiology%5C" + env.UserName + ":" + env.PasswordAD + "@" + str + AccessionNumber;
            //}


            //Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
            //if (!ieCom.OpenSynapseLink(str))
            //    msg.ShowAlert("UID4053", env.CurrentLanguageID);

            //return str;


            // UpdatePacs
            return new OpenPACS(env.PacsUrl).OpenIEAccession(AccessionNumber, env.UserName, env.PasswordAD, "", env.LoginType);

        }

        private void barbtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool chkNullOpinion = true;
            bool chkNullLangOfReport = true;
            for (int i = 0; i < viewOpinion.DataRowCount; i++)
            {
                DataRow row = viewOpinion.GetDataRow(i);
                if (row["CHK"] == "Y")
                {
                    chkNullOpinion = false;
                    break;
                }
            }

            if (chkNullOpinion == false)
            {
                MyMessageBox msg = new MyMessageBox();
                string buttion_id = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);

                if (buttion_id == "2")
                {
                    int radOpinionId = 0;
                    int langOfReportId = 0;
                    for (int i = 0; i < viewOpinion.DataRowCount; i++)
                    {
                        DataRow row = viewOpinion.GetDataRow(i);
                        if (row["CHK"] == "Y")
                        {
                            radOpinionId = Convert.ToInt32(row["GRADE_ID"].ToString());
                            break;
                        }
                    }

                    for (int i = 0; i < viewLangOfReport.DataRowCount; i++)
                    {
                        DataRow row = viewLangOfReport.GetDataRow(i);
                        if (row["CHK"] == "Y")
                        {
                            chkNullLangOfReport = false;
                            langOfReportId = Convert.ToInt32(row["REPORT_LANG_ID"].ToString());
                            break;
                        }
                    }

                    string Significant = string.Empty;
                    if (chkLike.Checked == true)
                    {
                        Significant = chkLike.Properties.ValueChecked.ToString();
                    }
                    else if (chkUnlike.Checked == true)
                    {
                        Significant = chkUnlike.Properties.ValueChecked.ToString();
                    }

                    ProcessRisPrStudies prc = new ProcessRisPrStudies();
                    prc.RIS_PRSTUDIES.STUDY_ID = Convert.ToInt32(rowData["STUDY_ID"].ToString());
                    prc.RIS_PRSTUDIES.RAD_OPINION = radOpinionId;
                    prc.RIS_PRSTUDIES.IS_CLINICALLY_SIGNIFICANT = Significant;
                    prc.RIS_PRSTUDIES.RAD_COMMENTS = memComment.Text;
                    prc.RIS_PRSTUDIES.PR_STATUS = "R";
                    prc.RIS_PRSTUDIES.ORG_ID = env.OrgID;
                    prc.RIS_PRSTUDIES.REPORT_LANG_ID = langOfReportId;
                    prc.RIS_PRSTUDIES.REPORT_LANG_COMMENTS = memoLangOfReportComment.Text;
                    prc.RIS_PRSTUDIES.LAST_MODIFIED_BY = env.UserID;
                    prc.update();

                    if (chkNullLangOfReport == true)
                    {
                        msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID, "ไม่มีการเลือก Language of Report");
                    }

                    this.Close();
                }
            }
            else
            {
                msg.ShowAlert("UID1024", new GBLEnvVariable().CurrentLanguageID, "กรุณาเลือก Opinion");
            }
        }

        private void barbtnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }


        private void chkLike_Click(object sender, EventArgs e)
        {
            chkUnlike.Checked = false;
        }

        private void chkUnlike_Click(object sender, EventArgs e)
        {
            chkLike.Checked = false; 
        }
    }
}