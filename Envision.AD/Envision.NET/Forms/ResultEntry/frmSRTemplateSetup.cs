using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;

using Miracle.Scanner;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Dialog;
using Envision.NET.Forms.ResultEntry.Common;
using Envision.NET.Forms.ResultEntry.StructuredReport;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup;
using Envision.NET.Forms.Technologist;
using Envision.Plugin.CRFile;
using Envision.Operational.PACS;

using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSpellChecker;
using DevExpress.XtraSpellChecker.Rules;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmSRTemplateSetup : Envision.NET.Forms.Main.MasterForm
    {
        private DataTable dttTemplate;
        private MyMessageBox msg;
        private GBLEnvVariable env;

        public frmSRTemplateSetup()
        {
            InitializeComponent();
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
            dttTemplate = null;
        }
     
        #region Setup Template.
        private void initAllDataTemplate()
        {
            dttTemplate = new DataTable();
            ProcessGetSRTemplate proc = new ProcessGetSRTemplate();
            dttTemplate = proc.GetTemplate();
        }
        private void initDataTemplate() {
            dttTemplate = new DataTable();
            ProcessGetSRTemplate proc = new ProcessGetSRTemplate();
            DataView dv = new DataView(proc.GetTemplate());
            dv.RowFilter = "CREATED_BY=" + env.UserID;
            dttTemplate = dv.ToTable();
        }
        private void bindTemplateSetup()
        {
            grdTemplate.DataSource = dttTemplate;
            for (int i = 0; i < dttTemplate.Columns.Count; i++)
                viewTemplate.Columns[i].Visible = false;

            viewTemplate.Columns["EXAM_UID"].Caption = "Exam Code";
            viewTemplate.Columns["EXAM_UID"].Width = 74;
            viewTemplate.Columns["EXAM_UID"].Visible = true;
            viewTemplate.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            viewTemplate.Columns["EXAM_NAME"].Caption = "Exam name";
            viewTemplate.Columns["EXAM_NAME"].Width = 120;
            viewTemplate.Columns["EXAM_NAME"].Visible = true;
            viewTemplate.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            viewTemplate.Columns["TEMPLATE_NAME"].Caption = "Template name";
            viewTemplate.Columns["TEMPLATE_NAME"].Width = 150;
            viewTemplate.Columns["TEMPLATE_NAME"].Visible = true;
            viewTemplate.Columns["TEMPLATE_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            viewTemplate.Columns["BP_DESC"].Caption = "Body part";
            viewTemplate.Columns["BP_DESC"].Width = 100;
            viewTemplate.Columns["BP_DESC"].Visible = true;
            viewTemplate.Columns["BP_DESC"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            viewTemplate.Columns["DESCRIPTION"].Caption = "Description";
            viewTemplate.Columns["DESCRIPTION"].Width = 200;
            viewTemplate.Columns["DESCRIPTION"].Visible = true;
            viewTemplate.Columns["DESCRIPTION"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            viewTemplate.Columns["CREATED_NAME"].Caption = "Created By";
            viewTemplate.Columns["CREATED_NAME"].Width = 100;
            viewTemplate.Columns["CREATED_NAME"].Visible = true;
            viewTemplate.Columns["CREATED_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            viewTemplate.Columns["IS_ACTIVE"].Caption = "Active";
            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewTemplate.Columns["IS_ACTIVE"].ColumnEdit = chk;
            viewTemplate.Columns["IS_ACTIVE"].BestFit();
            viewTemplate.Columns["IS_ACTIVE"].Visible = true;
            viewTemplate.Columns["IS_ACTIVE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewTemplate.Columns["IS_ACTIVE"].Width = 50;
        }
        private void editTempalte() {
            if (viewTemplate.FocusedRowHandle < 0) return;
            int createId = Convert.ToInt32(viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["CREATED_BY"].ToString());
            //if (createId != env.UserID)
            //{
            //    msg.ShowAlert("UID1413", env.CurrentLanguageID);
            //    return;
            //}

            if ("2" == msg.ShowAlert("UID1401", env.CurrentLanguageID))
            {

                int Id = Convert.ToInt32(viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["TEMPLATE_ID"].ToString());
                //ProcessGetSRQuestionsAnswers proc = new ProcessGetSRQuestionsAnswers();
                //DataTable dtt = proc.GetTemplateById(Id);
                //if (Miracle.Util.Utilities.IsHaveData(dtt))
                //{
                //    msg.ShowAlert("UID1414", env.CurrentLanguageID);
                //    return;
                //}
                SRSetUpForm frm = new SRSetUpForm(Id);
                frm.ShowDialog();
                frm.Dispose();
                if (chkAll.Checked)
                    initAllDataTemplate();
                else
                    initDataTemplate();
                bindTemplateSetup();
            }
        }

        private void btnNewTempalte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SRSetUpForm frm = new SRSetUpForm();
            frm.ShowDialog();
            frm.Dispose();
            if (chkAll.Checked)
                initAllDataTemplate();
            else
                initDataTemplate();
            bindTemplateSetup();
        }
        private void barEditTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editTempalte();
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (viewTemplate.FocusedRowHandle < 0) return;
            int Id = Convert.ToInt32(viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["TEMPLATE_ID"].ToString());
            int createId = Convert.ToInt32(viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["CREATED_BY"].ToString());
            if(env.UserID != createId)
            {
                msg.ShowAlert("UID1412", env.CurrentLanguageID);
                return;
            }
            if ("2" == msg.ShowAlert("UID1025", env.CurrentLanguageID))
            {
                ProcessGetSRQuestionsAnswers procAns = new ProcessGetSRQuestionsAnswers();
                if (Miracle.Util.Utilities.IsHaveData(procAns.GetTemplateById(Id))) {
                    msg.ShowAlert("UID1408", env.CurrentLanguageID);
                    return;
                }
                ProcessDeleteSRUserpreference procPre = new ProcessDeleteSRUserpreference();
                procPre.SR_USERPREFERENCE.TEMPLATE_ID=Id;
                procPre.SR_USERPREFERENCE.EMP_ID=env.UserID;
                procPre.DeleteByTemplateId();

                ProcessDeleteSRTemplate proc = new ProcessDeleteSRTemplate();
                proc.SR_TEMPLATE.TEMPLATE_ID = Id;
                proc.SR_TEMPLATE.ORG_ID = env.OrgID;
                proc.Invoke();

                if (chkAll.Checked)
                    initAllDataTemplate();
                else
                    initDataTemplate();
                bindTemplateSetup();

            }
        }
        private void viewTemplate_DoubleClick(object sender, EventArgs e)
        {
            editTempalte();
        }
        #endregion

        private void frmSRTemplateSetup_Load(object sender, EventArgs e)
        {
            initDataTemplate();
            bindTemplateSetup();
            base.CloseWaitDialog();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (viewTemplate.FocusedRowHandle > -1) {
                DataRow rowHandle = viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle);
                int templateId = Convert.ToInt32(rowHandle["TEMPLATE_ID"].ToString());
                ResultEntry.StructuredReport.QuesitonnairePreview prv = new QuesitonnairePreview(templateId);
                prv.ShowDialog();
                prv.Dispose();
            }
        }

        private void btnMessage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (viewTemplate.FocusedRowHandle > -1)
            {
                DataRow rowHandle = viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle);
                int createId = Convert.ToInt32(viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["CREATED_BY"].ToString());
                string name=viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["CREATED_NAME"].ToString();
                Envision.NET.Forms.InternalMessage.frmSend frm = new Envision.NET.Forms.InternalMessage.frmSend();
                frm.SendMessage(createId, name);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                initAllDataTemplate();
            else
                initDataTemplate();
            bindTemplateSetup();
        }
        private void btnDuplicate_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (viewTemplate.FocusedRowHandle < 0) return;
            //int TemplateID = Convert.ToInt32(viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["TEMPLATE_ID"].ToString());
            duplicateTempalte();
        }
        private void duplicateTempalte()
        {
            if (viewTemplate.FocusedRowHandle < 0) return;

            if ("2" == msg.ShowAlert("UID2128", env.CurrentLanguageID))
            {

                int Id = Convert.ToInt32(viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle)["TEMPLATE_ID"].ToString());
                
                SRSetUpForm frm = new SRSetUpForm(Id);
                frm.IsDuplicateMode = true;
                frm.ShowDialog();
                frm.Dispose();
                if (chkAll.Checked)
                    initAllDataTemplate();
                else
                    initDataTemplate();
                bindTemplateSetup();
            }
        }
    }
}
