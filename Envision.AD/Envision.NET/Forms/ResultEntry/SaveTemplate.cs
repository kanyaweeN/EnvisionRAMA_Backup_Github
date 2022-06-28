using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraRichEdit;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class SaveTemplate : DevExpress.XtraBars.Ribbon.RibbonForm//Form
    {
        private DataTable dttExam;
        //private RichTextBox rtPad;
        private RichEditControl rtPad;
        private DataTable dttRadio;
        private DataTable dttTemplate;
        private DataTable dttCritical;
        private Envision.BusinessLogic.ResultEntry result;
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private DataSet dsTemp;

        public SaveTemplate(RichEditControl editor)
        {
            InitializeComponent();
            rtPad = editor;
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
            result = new Envision.BusinessLogic.ResultEntry();
            initTemplate();
            initAutoComplete();
            initLookUp();
            initGrid();
            //grdData.Enabled = false;
        }

        public SaveTemplate(RichEditControl editor, int ExamID)
        {
            InitializeComponent();
            rtPad = editor;
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
            result = new Envision.BusinessLogic.ResultEntry();
            initTemplate();
            initAutoComplete();
            initLookUp();
            initExam(ExamID);
            initGrid();
            //grdData.Enabled = false;
        }

        private void txtTemplateName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void txtExamCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void txtExamName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(lv_ValueUpdated);
            lv.AddColumn("EXAM_ID", "Exam ID", false, true);
            lv.AddColumn("EXAM_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_NAME", "Exam Name", true, true);
            lv.AddColumn("RATE", "Rate", true, true);
            lv.Text = "Exam Search";

            lv.Data = lvS.SelectExamSaveTemp().Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }

        private void lv_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtExamCode.Tag = retValue[0];
            txtExamCode.Text = retValue[1];
            txtExamName.Text = retValue[3];
        }

        private void initAutoComplete() {
            AutoCompleteStringCollection ExamCode = new AutoCompleteStringCollection();
            AutoCompleteStringCollection ExamName = new AutoCompleteStringCollection();

            ProcessGetRISExam processExam = new ProcessGetRISExam();
            processExam.Invoke();
            dttExam = processExam.Result.Tables[0];

            for (int i = 0; i < dttExam.Rows.Count; i++)
            {
                ExamName.Add(dttExam.Rows[i]["EXAM_NAME"].ToString());
                ExamCode.Add(dttExam.Rows[i]["EXAM_UID"].ToString());
            }

            txtExamCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtExamCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtExamCode.AutoCompleteCustomSource = ExamCode;

            
            txtExamName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtExamName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtExamName.AutoCompleteCustomSource = ExamName;
        }
        private void initLookUp()
        {
            //result.RISExamresultseverity.UNIT_ID = env.UnitID;
            dttCritical = new DataTable();
            try
            {
                result.RISExamresultseverity.UNIT_ID = env.UnitID;
            }
            catch { result.RISExamresultseverity.UNIT_ID = 1; }
            dttCritical = result.GetExamresultSeverity();
            lkupCritical.Properties.DataSource = dttCritical;
            lkupCritical.Properties.ValueMember = "SEVERITY_ID";
            lkupCritical.Properties.DisplayMember = "SEVERITY_NAME";
        }
        private void initExam(int ExamID) {
            DataRow[] drs = dttExam.Select("EXAM_ID=" + ExamID);
            if (drs.Length > 0) 
            {
                txtExamCode.Tag = drs[0]["EXAM_ID"].ToString();
                txtExamCode.Text = drs[0]["EXAM_UID"].ToString();
                txtExamName.Text = drs[0]["EXAM_NAME"].ToString();
            }
        }
        private void initGrid()
        {
            dttRadio = new DataTable();
            dttRadio = result.GetRadiologist();
            switch (radGroup.EditValue.ToString())
            {
                case "S":
                    chkSelectAll.Visible = true;
                    chkSelectAll.Checked = false;
                    tabRad.PageVisible = true;
                    initGridTemplate(dsTemp.Tables[0]);
                    initGridRadiologist();
                    break;
                default:
                    chkSelectAll.Visible = false;
                    chkSelectAll.Checked = false;
                    tabRad.PageVisible = false;
                    initGridTemplate(dsTemp.Tables[0]);
                    break;
            }
        }
        private void initGridRadiologist() {
            if (!dttRadio.Columns.Contains("colChk"))
            {
                dttRadio.Columns.Add("colChk", typeof(string));
                foreach (DataRow dr in dttRadio.Rows)
                    dr["colChk"] = "N";
                dttRadio.AcceptChanges();
            }
            viewRad.Columns.Clear();
            grdRad.DataSource = null;
            grdRad.DataSource = dttRadio;
            for (int i = 0; i < dttRadio.Columns.Count; i++)
                viewRad.Columns[i].Visible = false;

            viewRad.Columns["EMP_UID"].Caption = "Code";
            viewRad.Columns["EMP_UID"].Visible = true;
            viewRad.Columns["EMP_UID"].Width = 120;
            viewRad.Columns["EMP_UID"].ColVIndex = 1;

            viewRad.Columns["RadioName"].Caption = "Radilogist Name";
            viewRad.Columns["RadioName"].Visible = true;
            viewRad.Columns["RadioName"].Width = 250;
            viewRad.Columns["RadioName"].ColVIndex = 2;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewRad.Columns["colChk"].Caption = "";
            viewRad.Columns["colChk"].Visible = true;
            viewRad.Columns["colChk"].Width = 50;
            viewRad.Columns["colChk"].ColVIndex = 3;
            viewRad.Columns["colChk"].ColumnEdit = chk;
        }
        private void initGridTemplate(DataTable dt)
        {
            //DataTable dtTemp = new DataTable();
            //dtTemp = dttTemplate.Clone();
            //DataRow[] drTemp = dttTemplate.Select("CREATED_BY = " + env.UserID.ToString());

            //if (drTemp.Length > 0) 
            //{
            //    for (int i = 0; i < drTemp.Length; i++)
            //    {
            //        dtTemp.NewRow();
            //        dtTemp.Rows.Add(drTemp[i].ItemArray);
            //        dtTemp.AcceptChanges();
            //    }
            //}

            view1.Columns.Clear();
            grdData.DataSource = null;
            grdData.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["TEMPLATE_NAME"].Caption = "Template Name";
            view1.Columns["TEMPLATE_NAME"].Visible = true;
            view1.Columns["TEMPLATE_NAME"].Width = 222;
            view1.Columns["TEMPLATE_NAME"].ColVIndex = 1;

            view1.Columns["EXAM_UID"].Caption = "Exam Code";
            view1.Columns["EXAM_UID"].Visible = true;
            view1.Columns["EXAM_UID"].Width = 50;
            view1.Columns["EXAM_UID"].ColVIndex = 2;

            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            view1.Columns["EXAM_NAME"].Visible = true;
            view1.Columns["EXAM_NAME"].Width = 222;
            view1.Columns["EXAM_NAME"].ColVIndex = 3;

        }
        private void initTemplate()
        {
            result.RISExamresult.EMP_ID = env.UserID;
            result.RISExamresult.TEMPMODE = radGroup.EditValue.ToString();
            dsTemp = result.GetTemplate();
        }
        private DataTable getDataTemp()
        {
            result.RISExamresult.EMP_ID = env.UserID;
            result.RISExamresult.TEMPMODE = radGroup.EditValue.ToString();
            return result.GetTemplate().Tables[0];
        }
        private void txtExamCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtExamCode.Text.Trim().Length == 0)
            {

                txtExamCode.Tag = null;
                txtExamName.Tag = null;

                txtExamCode.Text = string.Empty;
                txtExamName.Text = string.Empty;

                return;
            }
            DataRow[] dr = dttExam.Select("EXAM_UID='" + txtExamCode.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                txtExamCode.Tag  =  dr[0]["EXAM_ID"].ToString();
                txtExamCode.Text =  dr[0]["EXAM_UID"].ToString();
                txtExamName.Tag  =  dr[0]["EXAM_ID"].ToString();
                txtExamName.Text =  dr[0]["EXAM_NAME"].ToString();
            }
            else
            {
                txtExamCode.Tag = null;
                txtExamCode.SelectAll();
                txtExamName.Tag = null;
                txtExamName.Text = string.Empty;
                e.Cancel = true;
            }
        }
        private void txtExamName_Validating(object sender, CancelEventArgs e)
        {
            if (txtExamName.Text.Trim().Length == 0)
            {

                txtExamCode.Tag = null;
                txtExamName.Tag = null;

                txtExamCode.Text = string.Empty;
                txtExamName.Text = string.Empty;

                return;
            }
            DataRow[] dr = dttExam.Select("EXAM_NAME='" + txtExamName.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                txtExamCode.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamCode.Text = dr[0]["EXAM_UID"].ToString();
                txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
            }
            else
            {
                txtExamCode.Tag = null;
                txtExamCode.SelectAll();
                txtExamName.Tag = null;
                txtExamName.Text = string.Empty;
                e.Cancel = true;
            }
        }
        private void radGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            initTemplate();
            initGrid();
            //if (view1.FocusedRowHandle > -1)
            //{
            //    if (view1.FocusedColumn != null)
            //    {
            //        DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            //        txtTemplateName.Text = dr["TEMPLATE_NAME"].ToString();
            //        txtExamCode.Tag = dr["EXAM_ID"].ToString();
            //        txtExamCode.Text = dr["EXAM_UID"].ToString();
            //        txtExamName.Text = dr["EXAM_NAME"].ToString();
            //        if (dr["SEVERITY_ID"].ToString() != string.Empty)
            //            lkupCritical.EditValue = dr["SEVERITY_ID"];
            //        else
            //            lkupCritical.EditValue = "";
            //    }
            //}
        }
        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            string str = chkSelectAll.Checked ? "Y" : "N";
            foreach (DataRow dr in dttRadio.Rows)
                dr["colChk"] = str;
        }
        private void view1_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle > -1)
            {
                if (view1.FocusedColumn != null)
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    txtTemplateName.Text = dr["TEMPLATE_NAME"].ToString();
                    txtExamCode.Tag = dr["EXAM_ID"].ToString();
                    txtExamCode.Text = dr["EXAM_UID"].ToString();
                    txtExamName.Text = dr["EXAM_NAME"].ToString();
                    if (dr["SEVERITY_ID"].ToString() != string.Empty)
                        lkupCritical.EditValue = dr["SEVERITY_ID"];
                    else
                        lkupCritical.EditValue = "";
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow[] drRad = null;
            #region Require check.
            string str = "";
            if (txtTemplateName.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1120", env.CurrentLanguageID);
                txtTemplateName.Focus();
                return;
            }
            if (txtExamCode.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID0046", env.CurrentLanguageID);
                txtExamCode.Focus();
                return;
            }

            //DataRow[] drs = dttTemplate.Select("TEMPLATE_NAME='" + txtTemplateName.Text + "' AND CREATED_BY=" + env.UserID);
            dttTemplate = (DataTable)grdData.DataSource;
            DataRow[] drs = dttTemplate.Select("TEMPLATE_NAME='" + txtTemplateName.Text + "' AND CREATED_BY=" + env.UserID);
            if (drs.Length > 0)
            {
                if (msg.ShowAlert("UID1118", env.CurrentLanguageID) == "1")
                {
                    txtTemplateName.Focus();
                    return;
                }
                else
                {
                    str = "2";
                }
            }
            if (chkAuto.Checked)
            {
                drs = dttTemplate.Select(" AUTO_APPLY='Y' and EXAM_ID=" + txtExamCode.Tag.ToString() + " and CREATED_BY=" + env.UserID);
                if (drs.Length > 0)
                {
                    if (msg.ShowAlert("UID1119", env.CurrentLanguageID) == "1")
                    {
                        chkAuto.Focus();
                        return;
                    }
                }
            }
            if (radGroup.EditValue.ToString() == "S")
            {
                bool flag = true;
                drRad = dttRadio.Select("colChk = 'Y'");
                if (drRad.Length > 0)
                {
                    flag = false;
                }
                if (flag)
                {
                    msg.ShowAlert("UID018", env.CurrentLanguageID);
                    xtraTabControl1.SelectedTabPage = tabRad;
                    return;
                }
            } 
            #endregion

            //save template
            if (str != "2")
            {
                str = msg.ShowAlert("UID1019", env.CurrentLanguageID);
            }
            if (str == "2")
            {
                switch (radGroup.EditValue.ToString())
                {
                    case "S":
                        result.RISExamresulttemplate.TEMPLATE_TYPE = Convert.ToChar("S");
                        result.Shared = true;
                        for (int i = 0; i < drRad.Length; i++)
                        {
                            if (drRad[i]["colChk"].ToString() == "Y")
                            {
                                RIS_EXAMTEMPLATESHARE data = new RIS_EXAMTEMPLATESHARE();
                                data.EXAM_ID = result.RISExamresulttemplate.EXAM_ID;
                                data.SHARE_WITH = Convert.ToInt32(drRad[i]["EMP_ID"].ToString());
                                data.ORG_ID = env.OrgID;
                                data.CREATED_BY = env.UserID;
                                result.AddTemplateShare(data);
                            }
                        }
                        break;
                    default:
                        result.RISExamresulttemplate.TEMPLATE_TYPE = Convert.ToChar(radGroup.EditValue);
                        break;
                }
                result.RISExamresulttemplate.TEMPLATE_ID = 0;
                result.RISExamresulttemplate.TEMPLATE_UID = string.Empty;
                result.RISExamresulttemplate.TEMPLATE_NAME = txtTemplateName.Text;
                result.RISExamresulttemplate.AUTO_APPLY = chkAuto.Checked ? Convert.ToChar("Y") : Convert.ToChar("N");
                result.RISExamresulttemplate.EXAM_ID = Convert.ToInt32(txtExamCode.Tag.ToString());
                result.RISExamresulttemplate.TEMPLATE_TEXT = rtPad.Text;
                result.RISExamresulttemplate.TEMPLATE_TEXT_RTF = rtPad.Document.RtfText;
                try
                {
                    result.RISExamresulttemplate.SEVERITY_ID = Convert.ToInt32(lkupCritical.EditValue.ToString());
                }
                catch
                {
                    result.RISExamresulttemplate.SEVERITY_ID = 1;
                }
                result.RISExamresulttemplate.ORG_ID = env.OrgID;
                result.RISExamresulttemplate.CREATED_BY = env.UserID;
                result.SaveTemplate();
                this.Close();
            }
        }

        private void SaveTemplate_Load(object sender, EventArgs e)
        {

        }

        private void rdoPrivate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lkupCritical_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lkupCritical_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }

        private void rdoGlobal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void viewRad_Click(object sender, EventArgs e)
        {
            if (radGroup.EditValue.ToString() == "S")
            {
                if (viewRad.FocusedRowHandle > -1)
                {
                    if (viewRad.FocusedColumn != null)
                    {
                        if (viewRad.FocusedColumn.FieldName == "colChk")
                        {
                            DataRow dr = viewRad.GetDataRow(viewRad.FocusedRowHandle);
                            dr["colChk"] = dr["colChk"].ToString() == "N" ? "Y" : "N";
                        }
                    }
                }
            }
            else
            {
                if (viewRad.FocusedRowHandle > -1)
                {
                    if (viewRad.FocusedColumn != null)
                    {
                        DataRow dr = viewRad.GetDataRow(viewRad.FocusedRowHandle);
                        txtTemplateName.Text = dr["TEMPLATE_NAME"].ToString();
                        txtExamCode.Tag = dr["EXAM_ID"].ToString();
                        txtExamCode.Text = dr["EXAM_UID"].ToString();
                        txtExamName.Text = dr["EXAM_NAME"].ToString();
                        if (dr["SEVERITY_ID"].ToString() != string.Empty)
                            lkupCritical.EditValue = dr["SEVERITY_ID"];
                        else
                            lkupCritical.EditValue = "";
                    }
                }
            }
        }

//
    }
}