using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmSetSRDefault : Envision.NET.Forms.Main.MasterForm
    {
        private DataTable dttExam;
        private DataTable dttTemplate;
        private DataTable dttUserPref;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();

        public frmSetSRDefault()
        {
            InitializeComponent();
        }

        private void initExamTemplate()
        {
            ProcessGetSRUserPreference proc = new ProcessGetSRUserPreference();
            dttExam = proc.GetExamData();
        }
        private void initStructuredTemplate() {
            ProcessGetSRTemplate proc = new ProcessGetSRTemplate();
            DataView dv = new DataView(proc.GetTemplate());
            dv.RowFilter = "IS_ACTIVE='Y'";
            dttTemplate = dv.ToTable();

            dttTemplate.Columns.Add("STATUS", typeof(string));
            dttTemplate.Columns.Add("IS_DEFAULT", typeof(string));
            foreach (DataRow rowHandle in dttTemplate.Rows)
            {
                rowHandle["STATUS"] = "N";
                rowHandle["IS_DEFAULT"] = "N";
            }
            dttTemplate.AcceptChanges();
        }
        private void initUserPreference() {
            ProcessGetSRUserPreference proc = new ProcessGetSRUserPreference();
            proc.SR_USERPREFERENCE.EMP_ID = env.UserID;
            dttUserPref = proc.GetByEmpId();
        }

        private void initData() {
            initUserPreference();
            initExamTemplate();
            initStructuredTemplate();
            bindDataGrid();
        }
        
        private void bindDataGrid() {
            grdExam.DataSource = dttExam;
            viewExam.OptionsCustomization.AllowSort = false;
            for (int i = 0; i < dttExam.Columns.Count; i++)
                viewExam.Columns[i].Visible = false;

            viewExam.Columns["EXAM_UID"].Visible = true;
            viewExam.Columns["EXAM_UID"].Caption = "Exam Code";
            viewExam.Columns["EXAM_UID"].Width = 80;

            viewExam.Columns["EXAM_NAME"].Visible = true;
            viewExam.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewExam.Columns["EXAM_NAME"].Width = 130;

            grdTemplate.DataSource = dttTemplate;
            viewTemplate.OptionsCustomization.AllowSort = false;
            for (int i = 0; i < dttTemplate.Columns.Count; i++)
                viewTemplate.Columns[i].Visible = false;
            viewTemplate.Columns["TEMPLATE_NAME"].Visible = true;
            viewTemplate.Columns["TEMPLATE_NAME"].ColVIndex = 1;
            viewTemplate.Columns["TEMPLATE_NAME"].Caption = "Template Name";
            viewTemplate.Columns["TEMPLATE_NAME"].Width = 200;
            viewTemplate.Columns["TEMPLATE_NAME"].OptionsColumn.ReadOnly = true;

            viewTemplate.Columns["DESCRIPTION"].Visible = true;
            viewTemplate.Columns["DESCRIPTION"].ColVIndex = 2;
            viewTemplate.Columns["DESCRIPTION"].Caption = "Description";
            viewTemplate.Columns["DESCRIPTION"].Width = 250;
            viewTemplate.Columns["DESCRIPTION"].OptionsColumn.ReadOnly = true;

            viewTemplate.Columns["STATUS"].Visible = true;
            viewTemplate.Columns["STATUS"].ColVIndex = 3;
            viewTemplate.Columns["STATUS"].Caption = "Use";
            RepositoryItemCheckEdit chkStatus = new RepositoryItemCheckEdit();
            chkStatus.ValueChecked = "Y";
            chkStatus.ValueUnchecked = "N";
            chkStatus.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkStatus.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkStatus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkStatus.CheckedChanged += new EventHandler(chkStatus_CheckedChanged);
            viewTemplate.Columns["STATUS"].ColumnEdit = chkStatus;
            viewTemplate.Columns["STATUS"].BestFit();

            viewTemplate.Columns["IS_DEFAULT"].Visible = true;
            viewTemplate.Columns["IS_DEFAULT"].ColVIndex = 4;
            viewTemplate.Columns["IS_DEFAULT"].Caption = "Default";
            RepositoryItemCheckEdit chkDefault = new RepositoryItemCheckEdit();
            chkDefault.ValueChecked = "Y";
            chkDefault.ValueUnchecked = "N";
            chkDefault.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkDefault.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkDefault.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkDefault.CheckedChanged += new EventHandler(chkDefault_CheckedChanged);
            viewTemplate.Columns["IS_DEFAULT"].ColumnEdit = chkDefault;
            viewTemplate.Columns["IS_DEFAULT"].BestFit();
            if (dttExam.Rows.Count > 0)
            {
                viewExam.FocusedRowHandle = -9999;
                viewExam.FocusedRowHandle = 0;
            }
        }


        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (viewTemplate.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle);
            if (rowHandle == null) return;

            CheckEdit chk = sender as CheckEdit;
            if (chk == null) return;
            if (chk.Checked)
            {
                DataRow[] rows=dttUserPref.Select("TEMPLATE_ID=" + rowHandle["TEMPLATE_ID"].ToString());
                if(rows.Length>0)
                {
                    //update
                    rowHandle["STATUS"] = "Y";
                    rows[0]["STATUS"]="Y";
                }
                else
                {
                    //add
                    DataRow rowAdd=dttUserPref.NewRow();
                    rowAdd["TEMPLATE_ID"] = rowHandle["TEMPLATE_ID"];
                    rowAdd["EXAM_ID"] = rowHandle["EXAM_ID"];
                    rowAdd["IS_DEFAULT"] = "N";
                    rowAdd["STATUS"]="Y";
                    dttUserPref.Rows.Add(rowAdd);

                    rowHandle["STATUS"] = "Y";
                }
                dttUserPref.AcceptChanges();
                //bindDataGrid();
                viewTemplate.RefreshData();
            }
            else
            { 
                //delete
                int index = 0;
                bool flag = false;
                for (; index < dttUserPref.Rows.Count; index++) {
                    if (dttUserPref.Rows[index]["TEMPLATE_ID"].ToString() == rowHandle["TEMPLATE_ID"].ToString())
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    dttUserPref.Rows[index].Delete();
                    rowHandle["STATUS"] = "N";
                    rowHandle["IS_DEFAULT"] = "N";
                }
                dttUserPref.AcceptChanges();
               // bindDataGrid();
                viewTemplate.RefreshData();
            }
        }
        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (viewTemplate.FocusedRowHandle < 0) return;
            CheckEdit chk = sender as CheckEdit;
            if (chk == null) return;
            DataRow rowHandle = viewTemplate.GetDataRow(viewTemplate.FocusedRowHandle);
            if (rowHandle != null) {
                DataRow[] rows =dttUserPref.Select("TEMPLATE_ID=" + rowHandle["TEMPLATE_ID"].ToString());
                if (chk.Checked)
                {
                    //DataTable dtt =(DataTable) viewTemplate.DataSource;
                    //foreach (DataRow rowClear in dtt.Rows) rowClear["IS_DEFAULT"] = "N";
                    
                    DataView dv = (DataView)viewTemplate.DataSource;
                    foreach (DataRow rowClear in dv.Table.Rows) rowClear["IS_DEFAULT"] = "N";

                    DataRow[] rowsDelete = dttUserPref.Select("EXAM_ID=" + rowHandle["EXAM_ID"].ToString());
                    foreach (DataRow rowClear in rowsDelete) rowClear["IS_DEFAULT"] = "N";

                    if (rows.Length > 0)
                    {
                        rows[0]["IS_DEFAULT"] = "Y";
                        rowHandle["IS_DEFAULT"] = "Y";
                    }
                    else
                    {
                        DataRow rowAdd = dttUserPref.NewRow();
                        rowAdd["TEMPLATE_ID"] = rowHandle["TEMPLATE_ID"];
                        rowAdd["EXAM_ID"] = rowHandle["EXAM_ID"];
                        rowAdd["IS_DEFAULT"] = "Y";
                        rowAdd["STATUS"] = "Y";
                        dttUserPref.Rows.Add(rowAdd);
                        dttUserPref.AcceptChanges();

                        rowHandle["STATUS"] = "Y";
                        rowHandle["IS_DEFAULT"] = "Y";
                        viewTemplate.RefreshData();
                    }
                }
                else {
                    rows[0]["IS_DEFAULT"] = "N";
                    rowHandle["IS_DEFAULT"] = "N";
                }
                dttUserPref.AcceptChanges();
            }
        }

        private void frmSetSRDefault_Load(object sender, EventArgs e)
        {
            initData();
            base.CloseWaitDialog();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if(MessageBox.Show("Do you want to save ?","Save preference",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes){
            if("2"==msg.ShowAlert("UID1019",env.CurrentLanguageID)){
                ProcessDeleteSRUserpreference proc = new ProcessDeleteSRUserpreference();
                proc.SR_USERPREFERENCE.EMP_ID = env.UserID;
                proc.Invoke();

                ProcessAddSRUserPreference procUsr = new ProcessAddSRUserPreference();
                foreach (DataRow rowHandle in dttUserPref.Rows) {
                    procUsr.SR_USERPREFERENCE.EMP_ID = env.UserID;
                    procUsr.SR_USERPREFERENCE.EXAM_ID = Convert.ToInt32(rowHandle["EXAM_ID"].ToString());
                    procUsr.SR_USERPREFERENCE.IS_DEFAULT = rowHandle["IS_DEFAULT"].ToString();
                    procUsr.SR_USERPREFERENCE.STATUS = rowHandle["STATUS"].ToString();
                    procUsr.SR_USERPREFERENCE.TEMPLATE_ID = Convert.ToInt32(rowHandle["TEMPLATE_ID"].ToString());
                    procUsr.Invoke();
                }
            }
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bindViewTemplateByExamClick() {
            if (viewExam.FocusedRowHandle < 0) return;
            DataRow rowHandle = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            if (rowHandle != null)
            {
                int examId = Convert.ToInt32(rowHandle["EXAM_ID"].ToString());
                DataView dv = new DataView(dttTemplate);
                dv.RowFilter = "EXAM_ID=" + examId;
                DataTable dtt = dv.ToTable();
                foreach (DataRow row in dtt.Rows)
                {
                    DataRow[] rows = dttUserPref.Select("TEMPLATE_ID=" + row["TEMPLATE_ID"].ToString());
                    if (rows.Length > 0)
                    {
                        if (rows[0]["STATUS"].ToString() == "Y")
                            row["STATUS"] = "Y";
                        if (rows[0]["IS_DEFAULT"].ToString() == "Y")
                            row["IS_DEFAULT"] = "Y";
                    }

                }
                grdTemplate.DataSource = dtt;
            }
        }
        private void viewExam_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bindViewTemplateByExamClick();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            initData();
        }
    }
}

/*
 *  public partial class frmSetSRDefault : Envision.NET.Forms.Main.MasterForm
    {
        private DataTable dttExam;
        private DataTable dttUserPref;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private RepositoryItemLookUpEdit repoTemplate;

        public frmSetSRDefault()
        {
            InitializeComponent();
            repoTemplate = new RepositoryItemLookUpEdit();
        }

        private void addEmptyRow() {
            DataRow row = dttUserPref.NewRow();
            dttUserPref.Rows.Add(row);
            dttUserPref.AcceptChanges();
        }
        private void initiateUserPreference() { 
            ProcessGetSRUserPreference procUserPreference = new ProcessGetSRUserPreference();
            procUserPreference.SR_USERPREFERENCE.EMP_ID = env.UserID;
            dttUserPref = procUserPreference.GetByEmpId();
            dttUserPref.Columns.Add("EXAM_UID", typeof(int));
            dttUserPref.Columns.Add("DEL", typeof(string));
            foreach (DataRow row in dttUserPref.Rows)
            {
                row["EXAM_UID"] = row["EXAM_ID"];
                row["DEL"] = "N";
            }
            dttUserPref.AcceptChanges();
            addEmptyRow();
        }
        private void initiateGrid() {
            initiateUserPreference();
            dttExam = RISBaseData.Ris_Exam();

            view1.OptionsView.ShowBands = false;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            view1.OptionsView.ShowColumnHeaders = true;
            view1.OptionsCustomization.AllowSort = false;
            grdData.DataSource = dttUserPref;
            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["EXAM_ID"].Caption = "Exam Code";
            view1.Columns["EXAM_ID"].ColVIndex = 1;
            view1.Columns["EXAM_ID"].Visible = true;
            RepositoryItemLookUpEdit repoCode = new RepositoryItemLookUpEdit();
            repoCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repoCode.ImmediatePopup = true;
            repoCode.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repoCode.AutoHeight = false;
            repoCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repoCode.DisplayMember = "EXAM_UID";
            repoCode.ValueMember = "EXAM_ID";
            repoCode.DropDownRows = 5;
            repoCode.DataSource = dttExam;
            repoCode.NullText = string.Empty;
            repoCode.KeyUp += new KeyEventHandler(examCode);
            repoCode.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode);
            repoCode.BestFit();
            repoCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            view1.Columns["EXAM_ID"].ColumnEdit = repoCode;
            view1.Columns["EXAM_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

           
            view1.Columns["EXAM_UID"].Caption = "Exam Name";
            view1.Columns["EXAM_UID"].ColVIndex = 2;
            view1.Columns["EXAM_UID"].Visible = true;
            RepositoryItemLookUpEdit repoExamName = new RepositoryItemLookUpEdit();
            repoExamName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repoExamName.ImmediatePopup = true;
            repoExamName.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repoExamName.AutoHeight = false;
            repoExamName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repoExamName.DisplayMember = "EXAM_NAME";
            repoExamName.ValueMember = "EXAM_ID";
            repoExamName.DropDownRows = 5;
            repoExamName.DataSource = dttExam;
            repoExamName.NullText = string.Empty;
            repoExamName.KeyUp += new KeyEventHandler(examName);
            repoExamName.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName);
            repoExamName.BestFit();
            repoExamName.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            view1.Columns["EXAM_UID"].ColumnEdit = repoExamName;
            view1.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            view1.Columns["TEMPLATE_ID"].Caption = "Structured Name"; 
            view1.Columns["TEMPLATE_ID"].ColVIndex = 3;
            view1.Columns["TEMPLATE_ID"].Visible = true;
            //RepositoryItemButtonEdit rep = new RepositoryItemButtonEdit();
            //rep.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(rep_ButtonClick);
            //rep.ReadOnly = true;
            //view1.Columns["TEMPLATE_ID"].ColumnEdit = rep;

            repoTemplate = new RepositoryItemLookUpEdit();
            populateTemplate(-1);
            repoTemplate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repoTemplate.ImmediatePopup = true;
            repoTemplate.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repoTemplate.AutoHeight = false;
            repoTemplate.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repoTemplate.DisplayMember = "TEMPLATE_NAME";
            repoTemplate.ValueMember = "TEMPLATE_ID";
            repoTemplate.DropDownRows = 5;
            repoTemplate.NullText = string.Empty;
            repoTemplate.KeyUp += new KeyEventHandler(template);
            repoTemplate.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(template);
            repoTemplate.BestFit();
            repoTemplate.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            view1.Columns["TEMPLATE_ID"].ColumnEdit = repoTemplate;
            view1.Columns["TEMPLATE_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            view1.Columns["IS_DEFAULT"].Caption = "Default";
            view1.Columns["IS_DEFAULT"].ColVIndex = 4;
            view1.Columns["IS_DEFAULT"].Visible = true;
            RepositoryItemCheckEdit chkDefault = new RepositoryItemCheckEdit();
            chkDefault.ValueChecked = "Y";
            chkDefault.ValueUnchecked = "N";
            chkDefault.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkDefault.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkDefault.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkDefault.CheckedChanged += new EventHandler(chkDefault_CheckedChanged);
            view1.Columns["IS_DEFAULT"].ColumnEdit = chkDefault;

            view1.Columns["DEL"].Caption = " ";
            view1.Columns["DEL"].ColVIndex = 5;
            view1.Columns["DEL"].Visible = true;
            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnDelete);
            view1.Columns["DEL"].ColumnEdit = btn;
            view1.Columns["DEL"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            view1.Columns["DEL"].BestFit();

            view1.Columns["EXAM_ID"].Width = 80;
            view1.Columns["EXAM_UID"].Width = 180;
            view1.Columns["TEMPLATE_ID"].Width = 430;
            view1.Columns["IS_DEFAULT"].Width = 55;
        }

        void rep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("Click Me!!");
        }

        private void updateExamInGrid(int examId) {
            if (view1.FocusedRowHandle < 0) return;
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            if (rowHandle != null) {
                rowHandle["EXAM_ID"] = examId;
                rowHandle["EXAM_UID"] = examId;
                populateTemplate(examId);
                addEmptyRow();
            }
        }
        private void updateExamInGrid(string examCode)
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            if (rowHandle != null)
            {
                DataRow[] rows = dttExam.Select("EXAM_UID='" + examCode + "'");
                int examId = Convert.ToInt32(rows[0]["EXAM_ID"].ToString());

                rowHandle["EXAM_ID"] = examId;
                rowHandle["EXAM_UID"] = examId;
                populateTemplate(examId);
                addEmptyRow();
            }
        }
       
        private void examCode(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 2];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        private void examCode(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue) {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    updateExamInGrid(Convert.ToInt32(e.Value.ToString()));
                    view1.FocusedColumn = view1.VisibleColumns[2];
                }
            }
        }

        private void examName(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        private void examName(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    //updateExamInGrid(e.Value.ToString());
                    updateExamInGrid(Convert.ToInt32(e.Value.ToString()));
                    view1.MoveNext();
                }
            }
        }

        private void populateTemplate(int ExamId)
        {
            ProcessGetSRTemplate proc = new ProcessGetSRTemplate();
            DataTable dtt = null;
            if (ExamId == -1)
            {
                proc.Invoke();
                dtt = proc.Result;
            }
            else
            {
                proc.SR_TEMPLATE.EXAM_ID = ExamId;
                dtt = proc.GetByExam();
            }
            repoTemplate.DataSource = dtt;
        }
        private void template(object sender, KeyEventArgs e)
        {
        }
        private void template(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
        }

        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnDelete(object sender, EventArgs e)
        {
        }

        private void frmSetSRDefault_Load(object sender, EventArgs e)
        {
            initiateGrid();
            base.CloseWaitDialog();
            view1.FocusedColumn = view1.VisibleColumns[0];
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
*/