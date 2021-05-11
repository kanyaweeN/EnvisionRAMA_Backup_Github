using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;

namespace Envision.NET.Forms.Academic
{
    public partial class frmAcadermicSetup : Envision.NET.Forms.Main.MasterForm
    {
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private GuiMode _mode;
        List<string> listYear = new List<string>();
        List<string> listClass = new List<string>();
        List<string> listEmp = new List<string>();

        private int _YearID = 0;
        private int _AC_YEAR_RowHandle = 0;
        private DataSet _dsAC_YEAR;

        private int _ClassID = 0;
        private int _AC_CLASS_RowHandle = 0;
        private DataSet _dsAC_CLASS;

        private int _GradeID = 0;
        private int _AC_GRADE_RowHandle = 0;
        private DataSet _dsAC_GRADE;

        private int _ReportLangId = 0;
        private int _ReportLange_RowHandle = 0;
        private DataSet _dsAC_REPORTINGLANG;

        private int _EnrollID = 0;
        private int _AC_ENROLL_RowHandle = 0;
        private DataSet _dsAC_ENROLL;

        private DataSet _dsAC_FINALIZEJobTitle;
        private DataSet _dsAC_FINALIZEExamType;
        //private int _jobTitleID;
        private int _HrEmpID;
        private List<string> IsExpanded;

        public frmAcadermicSetup()
        {
            InitializeComponent();
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void frmAcadermicSetup_Load(object sender, EventArgs e)
        {
            InitializeData();
            InitializeCombobox();
            base.CloseWaitDialog();
        }
        private void InitializeData()
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    InitializeACYearData();
                    setFormAC_YEAR(GuiMode.Normal);
                    if (((DataTable)grdACYear.DataSource).Rows.Count > 0)
                    {
                        advbgAC_YEAR.FocusedRowHandle = 0;
                        DataRow dr = advbgAC_YEAR.GetDataRow(0);
                        _YearID = Convert.ToInt32(dr["YEAR_ID"].ToString());
                        SelectACYearData(_YearID);
                    }
                    else
                    {
                        SelectACYearData(-1);
                    }
                    break;
                case 1:
                    InitializeACClassData();
                    setFormAC_CLASS(GuiMode.Normal);
                    if (((DataTable)grdAC_Class.DataSource).Rows.Count > 0)
                    {
                        advgbAC_CLASS.FocusedRowHandle = 0;
                        DataRow dr = advgbAC_CLASS.GetDataRow(0);
                        _ClassID = Convert.ToInt32(dr["CLASS_ID"].ToString());
                        SelectACClassData(_ClassID);
                    }
                    else
                    {
                        SelectACClassData(-1);
                    }
                    break;
                case 2:
                    InitializeACGradeData();
                    setFormAC_GRADE(GuiMode.Normal);
                    if (((DataTable)grdAC_GRADE.DataSource).Rows.Count > 0)
                    {
                        advbgAC_GRADE.FocusedRowHandle = 0;
                        DataRow dr = advbgAC_GRADE.GetDataRow(0);
                        _GradeID = Convert.ToInt32(dr["GRADE_ID"].ToString());
                        SelectACGradeData(_GradeID);
                    }
                    else
                    {
                        SelectACGradeData(-1);
                    }
                    break;
                case 3:
                    InitializeACReportLangData();
                    setFormAC_REPORTLANG(GuiMode.Normal);
                    if (((DataTable)gridControlReportingLang.DataSource).Rows.Count > 0)
                    {
                        gridviewReportingLanaguage.FocusedRowHandle = 0;
                        DataRow dr = gridviewReportingLanaguage.GetDataRow(0);
                        _ReportLangId = Convert.ToInt32(dr["REPORT_LANG_ID"].ToString());
                        SelectACReportLangData(dr);
                    }
                    else
                    {
                        SelectACReportLangData(null);
                    }
                    break;
                case 4:
                    InitializeCombobox();
                    InitializeACEnrollmentData();
                    setFormAC_ENROLLMENT(GuiMode.Normal);
                    if (((DataTable)grdAC_ENROLLMENT.DataSource).Rows.Count > 0)
                    {
                        advbgAC_ENROLLMENT.FocusedRowHandle = 0;
                        DataRow dr = advbgAC_ENROLLMENT.GetDataRow(0);
                        _EnrollID = Convert.ToInt32(dr["ENROLL_ID"].ToString());
                        SelectACEnrollmentData(_EnrollID);
                    }
                    else
                    {
                        SelectACEnrollmentData(-1);
                    }
                    break;
                case 5:
                    InitializeAcFinalizePrivilege();
                    setFormAC_FINALIZEPRIVILEGE(GuiMode.Normal);
                    break;
            }
        }

        private void InitializeCombobox()
        {
            listYear.Clear();
            cmbEnrollYear.Properties.Items.Clear();
            ProcessGetACYear prc = new ProcessGetACYear();
            prc.Invoke();
            DataTable dtYear = prc.ResultSet.Tables[0].Copy();
            foreach (DataRow dr in dtYear.Rows)
            {
                listYear.Add(dr["YEAR_ID"].ToString());
                cmbEnrollYear.Properties.Items.Add(dr["YEAR_UID"].ToString());
            }
            cmbEnrollYear.SelectedIndex = 0;

            listClass.Clear();
            cmbEnrollClass.Properties.Items.Clear();
            ProcessGetACClass prcClass = new ProcessGetACClass();
            prcClass.Invoke();
            DataTable dtClass = prcClass.ResultSet.Tables[0].Copy();
            foreach (DataRow dr in dtClass.Rows)
            {
                listClass.Add(dr["CLASS_ID"].ToString());
                cmbEnrollClass.Properties.Items.Add(dr["CLASS_LABEL"].ToString());
            }
            cmbEnrollClass.SelectedIndex = 0;

            if (listEmp.Count > 0)
            {
                //cmbEnrollEmp.SelectedIndex = 0;
            }
            else
            {
                listEmp.Clear();
                //cmbEnrollEmp.Properties.Items.Clear();
                ProcessGetACEnrollment _prc = new ProcessGetACEnrollment();
                _prc.SelectEnrollmentResident();
                DataTable dtEmp = _prc.ResultSet.Tables[0].Copy();
                this.cmbEnrollEmp.Properties.AutoComplete = true;
                //this.cmbEnrollEmp.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.Default;
                this.cmbEnrollEmp.Properties.View.OptionsView.ShowAutoFilterRow = true;
                this.cmbEnrollEmp.Properties.View.Columns.Clear();
                this.cmbEnrollEmp.Properties.View.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Caption = "Emp Code", FieldName = "EMP_UID", Width = 80, VisibleIndex = 0 });
                this.cmbEnrollEmp.Properties.View.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Caption = "Name", FieldName = "RadioName", Width = 150, VisibleIndex = 1 });
                this.cmbEnrollEmp.Properties.ValueMember = "EMP_ID";
                this.cmbEnrollEmp.Properties.DisplayMember = "RadioName";
                this.cmbEnrollEmp.Properties.DataSource = dtEmp;
                
                //foreach (DataRow dr in dtEmp.Rows)
                //{
                //    listEmp.Add(dr["EMP_ID"].ToString());
                //    cmbEnrollEmp.Properties.Items.Add(dr["RadioName"].ToString());
                //}
                //cmbEnrollEmp.SelectedIndex = 0;
            }
        }
        private void InitializeACYearData()
        {
            ProcessGetACYear prc = new ProcessGetACYear();
            prc.Invoke();
            grdACYear.DataSource = prc.ResultSet.Tables[0].Copy();
        }
        private void InitializeACClassData()
        {
            ProcessGetACClass prc = new ProcessGetACClass();
            prc.Invoke();
            grdAC_Class.DataSource = prc.ResultSet.Tables[0].Copy();
        }
        private void InitializeACGradeData()
        {
            ProcessGetACGrade prc = new ProcessGetACGrade();
            prc.Invoke();
            grdAC_GRADE.DataSource = prc.ResultSet.Tables[0].Copy();
        }
        private void InitializeAcFinalizePrivilege()
        {
            ReloadJobtitle();
            ReloadExamType();
        }

        private void InitializeACReportLangData()
        {
            ProcessGetACReportingLanguage _processGetACReportingLang = new ProcessGetACReportingLanguage();
            _processGetACReportingLang.ORG_ID = env.OrgID;
            _processGetACReportingLang.Invoke();
            this._dsAC_REPORTINGLANG = _processGetACReportingLang.Result;
            gridControlReportingLang.DataSource = this._dsAC_REPORTINGLANG.Tables[0].Copy();
        }
        private void InitializeACEnrollmentData()
        {
            ProcessGetACEnrollment prc = new ProcessGetACEnrollment();
            prc.Invoke();
            grdAC_ENROLLMENT.DataSource = prc.ResultSet.Tables[0].Copy();
        }
        private void SelectACYearData(int _id)
        {
            if (_id >= 0)
            {
                ProcessGetACYear prc = new ProcessGetACYear();
                prc.Invoke(_id);

                _dsAC_YEAR = new DataSet();
                _dsAC_YEAR = prc.ResultSet;

                txtYearUID.Text = _dsAC_YEAR.Tables[0].Rows[0]["YEAR_UID"].ToString();
                dtStartDate.DateTime = Convert.ToDateTime(_dsAC_YEAR.Tables[0].Rows[0]["START_DATE"].ToString());
                dtEndDate.DateTime = Convert.ToDateTime(_dsAC_YEAR.Tables[0].Rows[0]["END_DATE"].ToString());
                txtCreatedBy.Text = _dsAC_YEAR.Tables[0].Rows[0]["CREATED_BY_TEXT"].ToString();
                txtCreatedOn.Text = _dsAC_YEAR.Tables[0].Rows[0]["CREATED_ON"].ToString();
                txtLastModifiedBy.Text = _dsAC_YEAR.Tables[0].Rows[0]["LAST_MODIFIED_BY_TEXT"].ToString();
                txtLastModifiedOn.Text = _dsAC_YEAR.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString();
                if (Convert.ToInt32(_dsAC_YEAR.Tables[0].Rows[0]["CAN_DELETE"].ToString()) > 0)
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                txtYearUID.Text = "";
                dtStartDate.DateTime = DateTime.Now;
                dtEndDate.DateTime = DateTime.Now;
                txtCreatedBy.Text = "";
                txtCreatedOn.Text = "";
                txtLastModifiedBy.Text = "";
                txtLastModifiedOn.Text = "";
            }

        }
        private void SelectACClassData(int _id)
        {
            if (_id >= 0)
            {
                ProcessGetACClass prc = new ProcessGetACClass();
                prc.Invoke(_id);

                _dsAC_CLASS = new DataSet();
                _dsAC_CLASS = prc.ResultSet;

                txtClassAlias.Text = _dsAC_CLASS.Tables[0].Rows[0]["CLASS_ALIAS"].ToString();
                txtClassLabel.Text = _dsAC_CLASS.Tables[0].Rows[0]["CLASS_LABEL"].ToString();
                txtClassCreated_By.Text = _dsAC_CLASS.Tables[0].Rows[0]["CREATED_BY_TEXT"].ToString();
                txtClassCreated_On.Text = _dsAC_CLASS.Tables[0].Rows[0]["CREATED_ON"].ToString();
                txtClassLastModifiedBy.Text = _dsAC_CLASS.Tables[0].Rows[0]["LAST_MODIFIED_BY_TEXT"].ToString();
                txtClassLastModifiedOn.Text = _dsAC_CLASS.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString();
                if (Convert.ToInt32(_dsAC_CLASS.Tables[0].Rows[0]["CAN_DELETE"].ToString()) > 0)
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                txtClassLabel.Text = "";
                txtClassAlias.Text = "";
                txtClassCreated_By.Text = "";
                txtClassCreated_On.Text = "";
                txtClassLastModifiedBy.Text = "";
                txtClassLastModifiedOn.Text = "";
            }
        }
        private void SelectACGradeData(int _id)
        {
            if (_id >= 0)
            {
                ProcessGetACGrade prc = new ProcessGetACGrade();
                prc.Invoke(_id);

                _dsAC_GRADE = new DataSet();
                _dsAC_GRADE = prc.ResultSet;

                txtGradeLabel.Text = _dsAC_GRADE.Tables[0].Rows[0]["GRADE_LABEL"].ToString();
                txtGradeValue.Text = _dsAC_GRADE.Tables[0].Rows[0]["GRADE_VALUE"].ToString();
                txtGradeCreatedBy.Text = _dsAC_GRADE.Tables[0].Rows[0]["CREATED_BY_TEXT"].ToString();
                txtGradeCreatedOn.Text = _dsAC_GRADE.Tables[0].Rows[0]["CREATED_ON"].ToString();
                txtGradeLastModifiedBy.Text = _dsAC_GRADE.Tables[0].Rows[0]["LAST_MODIFIED_BY_TEXT"].ToString();
                txtGradeLastModifiedOn.Text = _dsAC_GRADE.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString();
                chkSendMessage.Checked = _dsAC_GRADE.Tables[0].Rows[0]["SEND_MESSAGE"].ToString() == "Y" ? true : false; 
                btnDelete.Enabled = true;
            }
            else
            {
                txtGradeLabel.Text = "";
                txtGradeValue.Text = "";
                txtGradeCreatedBy.Text = "";
                txtGradeCreatedOn.Text = "";
                txtGradeLastModifiedBy.Text = "";
                txtGradeLastModifiedOn.Text = "";
                chkSendMessage.Checked = false;
            }
        }

        private void SelectACReportLangData(DataRow focusdRow)
        {
            if (focusdRow != null)
            {
                tbReportLangLabel.Text = focusdRow["REPORT_LANG_LABEL"].ToString();
                tbReportLangValue.Text = focusdRow["REPORT_LANG_VALUE"].ToString();
                tbReportLangCreatedBy.Text = focusdRow["CREATED_BY_TEXT"].ToString();
                tbReportLangCreatedOn.Text = focusdRow["CREATED_ON"].ToString();
                tbReportLangLastModifiedBy.Text = focusdRow["LAST_MODIFIED_BY_TEXT"].ToString();
                tbReportLangLastModifiedOn.Text = focusdRow["LAST_MODIFIED_ON"].ToString();
                chkSendMessage2.Checked = focusdRow["SEND_MESSAGE"].ToString() == "Y" ? true : false;                 
                btnDelete.Enabled = true;
            }
            else
            {
                tbReportLangLabel.Text = "";
                tbReportLangValue.Text = "";
                tbReportLangCreatedBy.Text = "";
                tbReportLangCreatedOn.Text = "";
                tbReportLangLastModifiedBy.Text = "";
                tbReportLangLastModifiedOn.Text = "";
                chkSendMessage2.Checked = false;
            }
        }

        private void SelectACEnrollmentData(int _id)
        {
            if (_id >= 0)
            {
                ProcessGetACEnrollment prc = new ProcessGetACEnrollment();
                prc.Invoke(_id);

                _dsAC_ENROLL = new DataSet();
                _dsAC_ENROLL = prc.ResultSet;

                txtEnrollUID.Text = _dsAC_ENROLL.Tables[0].Rows[0]["ENROLL_UID"].ToString();
                cmbEnrollYear.SelectedIndex = listYear.IndexOf(_dsAC_ENROLL.Tables[0].Rows[0]["YEAR_ID"].ToString());
                cmbEnrollClass.SelectedIndex = listClass.IndexOf(_dsAC_ENROLL.Tables[0].Rows[0]["CLASS_ID"].ToString());
                cmbEnrollEmp.EditValue = Convert.ToInt32(_dsAC_ENROLL.Tables[0].Rows[0]["EMP_ID"].ToString());
                txtEnrollCreatedBy.Text = _dsAC_ENROLL.Tables[0].Rows[0]["CREATED_BY_TEXT"].ToString();
                txtEnrollCreatedOn.Text = _dsAC_ENROLL.Tables[0].Rows[0]["CREATED_ON"].ToString();
                txtEnrollLastModifiedBy.Text = _dsAC_ENROLL.Tables[0].Rows[0]["LAST_MODIFIED_BY_TEXT"].ToString();
                txtEnrollLastModifiedOn.Text = _dsAC_ENROLL.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString();
                if (_dsAC_ENROLL.Tables[0].Rows[0]["IS_ACTIVE"].ToString() == "Y")
                    chkEnrollActive.Checked = true;
                else
                    chkEnrollActive.Checked = false;

                btnDelete.Enabled = true;
            }
            else
            {
                txtEnrollUID.Text = "";
                cmbEnrollYear.SelectedIndex = 0;
                cmbEnrollClass.SelectedIndex = 0;
                cmbEnrollEmp.EditValue = 0;
                txtEnrollCreatedBy.Text = "";
                txtEnrollCreatedOn.Text = "";
                txtEnrollLastModifiedBy.Text = "";
                txtEnrollLastModifiedOn.Text = "";
                chkEnrollActive.Checked = false;
            }
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    setFormAC_YEAR(GuiMode.Add);
                    break;
                case 1:
                    setFormAC_CLASS(GuiMode.Add);
                    break;
                case 2:
                    setFormAC_GRADE(GuiMode.Add);
                    break;
                case 3:
                    setFormAC_REPORTLANG(GuiMode.Add);
                    break;
                case 4:
                    setFormAC_ENROLLMENT(GuiMode.Add);
                    break;
                default:
                    break;
            }
            _mode = GuiMode.Add;
        }
        private void setFormAC_YEAR(GuiMode Mode)
        {
            layoutStart.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            layoutEnd.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            layoutYear.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;

            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:
                    txtYearUID.Properties.ReadOnly = true;
                    txtCreatedBy.Properties.ReadOnly = true;
                    txtCreatedOn.Properties.ReadOnly = true;
                    txtLastModifiedBy.Properties.ReadOnly = true;
                    txtLastModifiedOn.Properties.ReadOnly = true;

                    dtStartDate.Properties.ReadOnly = true;
                    dtEndDate.Properties.ReadOnly = true;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonAdd.Visible = true;
                    btnribbonUpdate.Visible = true;
                    btnribDelete.Visible = true;
                    btnribClose.Visible = true;

                    grdACYear.Enabled = true;
                    break;
                case GuiMode.Add:
                    txtYearUID.Properties.ReadOnly = false;
                    txtCreatedBy.Properties.ReadOnly = true;
                    txtCreatedOn.Properties.ReadOnly = true;
                    txtLastModifiedBy.Properties.ReadOnly = true;
                    txtLastModifiedOn.Properties.ReadOnly = true;

                    dtStartDate.Properties.ReadOnly = false;
                    dtEndDate.Properties.ReadOnly = false;

                    txtYearUID.Text = "";
                    dtStartDate.DateTime = DateTime.Now;
                    dtEndDate.DateTime = DateTime.Now;
                    txtCreatedBy.Text = "Waiting...";
                    txtCreatedOn.Text = "Waiting...";
                    txtLastModifiedBy.Text = "Waiting...";
                    txtLastModifiedOn.Text = "Waiting...";

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdACYear.Enabled = false;
                    break;
                case GuiMode.Edit:
                    txtYearUID.Properties.ReadOnly = false;
                    txtCreatedBy.Properties.ReadOnly = true;
                    txtCreatedOn.Properties.ReadOnly = true;
                    txtLastModifiedBy.Properties.ReadOnly = true;
                    txtLastModifiedOn.Properties.ReadOnly = true;

                    dtStartDate.Properties.ReadOnly = false;
                    dtEndDate.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdACYear.Enabled = false;
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }
        }
        private void setFormAC_CLASS(GuiMode Mode)
        {
            layoutAlias.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            layoutClass.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:
                    txtClassLabel.Properties.ReadOnly = true;
                    txtClassAlias.Properties.ReadOnly = true;
                    txtClassCreated_By.Properties.ReadOnly = true;
                    txtClassCreated_On.Properties.ReadOnly = true;
                    txtClassLastModifiedBy.Properties.ReadOnly = true;
                    txtClassLastModifiedOn.Properties.ReadOnly = true;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonAdd.Visible = true;
                    btnribbonUpdate.Visible = true;
                    btnribDelete.Visible = true;
                    btnribClose.Visible = true;

                    grdAC_Class.Enabled = true;
                    break;
                case GuiMode.Add:
                    txtClassLabel.Properties.ReadOnly = false;
                    txtClassAlias.Properties.ReadOnly = false;
                    txtClassCreated_By.Properties.ReadOnly = true;
                    txtClassCreated_On.Properties.ReadOnly = true;
                    txtClassLastModifiedBy.Properties.ReadOnly = true;
                    txtClassLastModifiedOn.Properties.ReadOnly = true;

                    txtClassLabel.Text = "";
                    txtClassAlias.Text = "";
                    txtClassCreated_By.Text = "Waiting...";
                    txtClassCreated_On.Text = "Waiting...";
                    txtClassLastModifiedBy.Text = "Waiting...";
                    txtClassLastModifiedOn.Text = "Waiting...";

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdAC_Class.Enabled = false;
                    break;
                case GuiMode.Edit:
                    txtClassLabel.Properties.ReadOnly = false;
                    txtClassAlias.Properties.ReadOnly = false;
                    txtClassCreated_By.Properties.ReadOnly = true;
                    txtClassCreated_On.Properties.ReadOnly = true;
                    txtClassLastModifiedBy.Properties.ReadOnly = true;
                    txtClassLastModifiedOn.Properties.ReadOnly = true;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdAC_Class.Enabled = false;
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }
        }
        private void setFormAC_GRADE(GuiMode Mode)
        {
            layoutValue.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            layoutGrade.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:
                    txtGradeLabel.Properties.ReadOnly = true;
                    txtGradeValue.Properties.ReadOnly = true;
                    txtGradeCreatedBy.Properties.ReadOnly = true;
                    txtGradeCreatedOn.Properties.ReadOnly = true;
                    txtGradeLastModifiedBy.Properties.ReadOnly = true;
                    txtGradeLastModifiedOn.Properties.ReadOnly = true;
                    chkSendMessage.Properties.ReadOnly = true;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonAdd.Visible = true;
                    btnribbonUpdate.Visible = true;
                    btnribDelete.Visible = true;
                    btnribClose.Visible = true;

                    grdAC_GRADE.Enabled = true;
                    break;
                case GuiMode.Add:
                    txtGradeLabel.Properties.ReadOnly = false;
                    txtGradeValue.Properties.ReadOnly = false;
                    txtGradeCreatedBy.Properties.ReadOnly = true;
                    txtGradeCreatedOn.Properties.ReadOnly = true;
                    txtGradeLastModifiedBy.Properties.ReadOnly = true;
                    txtGradeLastModifiedOn.Properties.ReadOnly = true;
                    chkSendMessage.Properties.ReadOnly = false;

                    txtGradeLabel.Text = "";
                    txtGradeValue.Text = "";
                    txtGradeCreatedBy.Text = "Waiting...";
                    txtGradeCreatedOn.Text = "Waiting...";
                    txtGradeLastModifiedBy.Text = "Waiting...";
                    txtGradeLastModifiedOn.Text = "Waiting...";

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdAC_GRADE.Enabled = false;
                    break;
                case GuiMode.Edit:
                    txtGradeLabel.Properties.ReadOnly = false;
                    txtGradeValue.Properties.ReadOnly = false;
                    txtGradeCreatedBy.Properties.ReadOnly = true;
                    txtGradeCreatedOn.Properties.ReadOnly = true;
                    txtGradeLastModifiedBy.Properties.ReadOnly = true;
                    txtGradeLastModifiedOn.Properties.ReadOnly = true;
                    chkSendMessage.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdAC_GRADE.Enabled = false;
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }
        }
        private void setFormAC_REPORTLANG(GuiMode Mode)
        {
            layoutReportLangValue.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            layoutReportLangLabel.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:

                    tbReportLangLabel.Properties.ReadOnly = true;
                    tbReportLangValue.Properties.ReadOnly = true;
                    tbReportLangCreatedBy.Properties.ReadOnly = true;
                    tbReportLangCreatedOn.Properties.ReadOnly = true;
                    tbReportLangLastModifiedBy.Properties.ReadOnly = true;
                    tbReportLangLastModifiedOn.Properties.ReadOnly = true;
                    chkSendMessage2.Properties.ReadOnly = true;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonAdd.Visible = true;
                    btnribbonUpdate.Visible = true;
                    btnribDelete.Visible = true;
                    btnribClose.Visible = true;

                    gridControlReportingLang.Enabled = true;
                    break;
                case GuiMode.Add:
                    tbReportLangLabel.Properties.ReadOnly = false;
                    tbReportLangValue.Properties.ReadOnly = false;
                    tbReportLangCreatedBy.Properties.ReadOnly = true;
                    tbReportLangCreatedOn.Properties.ReadOnly = true;
                    tbReportLangLastModifiedBy.Properties.ReadOnly = true;
                    tbReportLangLastModifiedOn.Properties.ReadOnly = true;
                    chkSendMessage2.Properties.ReadOnly = false;

                    tbReportLangLabel.Text = "";
                    tbReportLangValue.Text = "";
                    tbReportLangCreatedBy.Text = "Waiting...";
                    tbReportLangCreatedOn.Text = "Waiting...";
                    tbReportLangLastModifiedBy.Text = "Waiting...";
                    tbReportLangLastModifiedOn.Text = "Waiting...";

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    gridControlReportingLang.Enabled = false;
                    break;
                case GuiMode.Edit:
                    tbReportLangLabel.Properties.ReadOnly = false;
                    tbReportLangValue.Properties.ReadOnly = false;
                    tbReportLangCreatedBy.Properties.ReadOnly = true;
                    tbReportLangCreatedOn.Properties.ReadOnly = true;
                    tbReportLangLastModifiedBy.Properties.ReadOnly = true;
                    tbReportLangLastModifiedOn.Properties.ReadOnly = true;
                    chkSendMessage2.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    gridControlReportingLang.Enabled = false;
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }
        }

        private void setFormAC_ENROLLMENT(GuiMode Mode)
        {
            layoutEnroll.AppearanceItemCaption.ForeColor = layoutControlItem5.AppearanceItemCaption.ForeColor;
            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:
                    txtEnrollUID.Properties.ReadOnly = true;
                    txtEnrollCreatedBy.Properties.ReadOnly = true;
                    txtEnrollCreatedOn.Properties.ReadOnly = true;
                    txtEnrollLastModifiedBy.Properties.ReadOnly = true;
                    txtEnrollLastModifiedOn.Properties.ReadOnly = true;

                    cmbEnrollYear.Properties.ReadOnly = true;
                    cmbEnrollClass.Properties.ReadOnly = true;
                    cmbEnrollEmp.Properties.ReadOnly = true;

                    chkEnrollActive.Properties.ReadOnly = true;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonAdd.Visible = true;
                    btnribbonUpdate.Visible = true;
                    btnribDelete.Visible = true;
                    btnribClose.Visible = true;

                    grdAC_ENROLLMENT.Enabled = true;
                    break;
                case GuiMode.Add:
                    txtEnrollUID.Properties.ReadOnly = true;
                    txtEnrollCreatedBy.Properties.ReadOnly = true;
                    txtEnrollCreatedOn.Properties.ReadOnly = true;
                    txtEnrollLastModifiedBy.Properties.ReadOnly = true;
                    txtEnrollLastModifiedOn.Properties.ReadOnly = true;

                    cmbEnrollYear.Properties.ReadOnly = false;
                    cmbEnrollClass.Properties.ReadOnly = false;
                    cmbEnrollEmp.Properties.ReadOnly = false;

                    chkEnrollActive.Properties.ReadOnly = false;

                    txtEnrollUID.Text = "Auto";
                    txtEnrollCreatedBy.Text = "Waiting...";
                    txtEnrollCreatedOn.Text = "Waiting...";
                    txtEnrollLastModifiedBy.Text = "Waiting...";
                    txtEnrollLastModifiedOn.Text = "Waiting...";

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdAC_ENROLLMENT.Enabled = false;
                    break;
                case GuiMode.Edit:
                    txtEnrollUID.Properties.ReadOnly = true;
                    txtEnrollCreatedBy.Properties.ReadOnly = true;
                    txtEnrollCreatedOn.Properties.ReadOnly = true;
                    txtEnrollLastModifiedBy.Properties.ReadOnly = true;
                    txtEnrollLastModifiedOn.Properties.ReadOnly = true;

                    cmbEnrollYear.Properties.ReadOnly = false;
                    cmbEnrollClass.Properties.ReadOnly = false;
                    cmbEnrollEmp.Properties.ReadOnly = false;

                    chkEnrollActive.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribDelete.Visible = false;
                    btnribClose.Visible = true;

                    grdAC_ENROLLMENT.Enabled = false;
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }
        }
        private void setFormAC_FINALIZEPRIVILEGE(GuiMode Mode)
        {
            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:
                    btnribbonAdd.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonSave.Visible = false;
                    btnribbonUpdate.Visible = true;
                    btnribClose.Visible = true;
                    btnribDelete.Visible = false;
                    btnribbonCancel.Visible = false;
                    gcJobTitle.Enabled = false;
                    gcExamType.Enabled = false;

                    break;
                case GuiMode.Add:
                    btnribbonAdd.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonSave.Visible = false;
                    btnribbonUpdate.Visible = true;
                    btnribClose.Visible = true;
                    btnribDelete.Visible = false;
                    btnribbonCancel.Visible = false;
                    gcJobTitle.Enabled = false;
                    gcExamType.Enabled = false;

                    break;
                case GuiMode.Edit:
                    btnribbonAdd.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribbonSave.Visible = true;
                    btnribbonUpdate.Visible = false;
                    btnribClose.Visible = true;
                    btnribDelete.Visible = false;
                    btnribbonCancel.Visible = true;
                    gcJobTitle.Enabled = true;
                    gcExamType.Enabled = true;
                    
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    InitializeACYearData();
                    setFormAC_YEAR(GuiMode.Normal);

                    if (advbgAC_YEAR.SelectedRowsCount > 0)
                    {
                        advbgAC_YEAR.FocusedRowHandle = _AC_YEAR_RowHandle;
                        SelectACYearData(_YearID);
                    }
                    else
                    {
                        SelectACYearData(-1);
                    }
                    break;
                case 1:
                    InitializeACClassData();
                    setFormAC_CLASS(GuiMode.Normal);

                    if (advgbAC_CLASS.SelectedRowsCount > 0)
                    {
                        advgbAC_CLASS.FocusedRowHandle = _AC_CLASS_RowHandle;
                        SelectACClassData(_ClassID);
                    }
                    else
                    {
                        SelectACClassData(-1);
                    }
                    break;
                case 2:
                    InitializeACGradeData();
                    setFormAC_GRADE(GuiMode.Normal);

                    if (advbgAC_GRADE.SelectedRowsCount > 0)
                    {
                        advbgAC_GRADE.FocusedRowHandle = _AC_GRADE_RowHandle;
                        SelectACGradeData(_GradeID);
                    }
                    else
                    {
                        SelectACGradeData(-1);
                    }
                    break;
                case 3:
                    InitializeACReportLangData();
                    setFormAC_REPORTLANG(GuiMode.Normal);
                    if (gridviewReportingLanaguage.SelectedRowsCount > 0)
                    {
                        gridviewReportingLanaguage.FocusedRowHandle = _ReportLange_RowHandle;
                        DataRow dr = this.gridviewReportingLanaguage.GetDataRow(_ReportLangId);
                        SelectACReportLangData(dr);
                    }
                    else
                    {
                        SelectACReportLangData(null);
                    }
                    break;
                case 4:
                    InitializeACEnrollmentData();
                    setFormAC_ENROLLMENT(GuiMode.Normal);

                    if (advbgAC_ENROLLMENT.SelectedRowsCount > 0)
                    {
                        advbgAC_ENROLLMENT.FocusedRowHandle = _AC_ENROLL_RowHandle;
                        SelectACEnrollmentData(_EnrollID);
                    }
                    else
                    {
                        SelectACEnrollmentData(-1);
                    }
                    break;
                case 5:
                    setFormAC_FINALIZEPRIVILEGE(GuiMode.Normal);
                    ReloadJobtitle();
                    ReloadExamType();
                    break;
                default:
                    break;
            }
            _mode = GuiMode.Normal;
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string s = "";
            switch (_mode)
            {
                case GuiMode.Normal:
                    break;
                case GuiMode.Add:
                    s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        switch (xtraTabControl1.SelectedTabPageIndex)
                        {
                            case 0:
                                if (txtYearUID.Text.Length <= 0)
                                {
                                    layoutYear.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                if (dtStartDate.DateTime > dtEndDate.DateTime)
                                {
                                    layoutStart.AppearanceItemCaption.ForeColor = Color.Red;
                                    layoutEnd.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                ProcessAddACYear prcAdd = new ProcessAddACYear();
                                prcAdd.AC_YEAR.YEAR_UID = txtYearUID.Text;
                                prcAdd.AC_YEAR.START_DATE = dtStartDate.DateTime;
                                prcAdd.AC_YEAR.END_DATE = dtEndDate.DateTime;
                                prcAdd.AC_YEAR.ORG_ID = 1;
                                prcAdd.AC_YEAR.CREATED_BY = new GBLEnvVariable().UserID;
                                prcAdd.AC_YEAR.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                prcAdd.Invoke();

                                InitializeACYearData();
                                setFormAC_YEAR(GuiMode.Normal);

                                advbgAC_YEAR.FocusedRowHandle = ((DataTable)grdACYear.DataSource).Rows.Count - 1;
                                SelectACYearData(prcAdd.AC_YEAR.YEAR_ID);
                                _YearID = prcAdd.AC_YEAR.YEAR_ID;
                                _mode = GuiMode.Normal;
                                break;
                            case 1:
                                if (txtClassAlias.Text.Length <= 0)
                                {
                                    layoutAlias.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                if (txtClassLabel.Text.Length <= 0)
                                {
                                    layoutClass.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                ProcessAddACClass prcClassAdd = new ProcessAddACClass();
                                prcClassAdd.AC_CLASS.CLASS_ALIAS = txtClassAlias.Text;
                                prcClassAdd.AC_CLASS.CLASS_LABEL = txtClassLabel.Text;
                                prcClassAdd.AC_CLASS.ORG_ID = 1;
                                prcClassAdd.AC_CLASS.CREATED_BY = new GBLEnvVariable().UserID;
                                prcClassAdd.AC_CLASS.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                prcClassAdd.Invoke();

                                InitializeACClassData();
                                setFormAC_CLASS(GuiMode.Normal);

                                advgbAC_CLASS.FocusedRowHandle = ((DataTable)grdAC_Class.DataSource).Rows.Count - 1;
                                SelectACClassData(prcClassAdd.AC_CLASS.CLASS_ID);
                                _ClassID = prcClassAdd.AC_CLASS.CLASS_ID;
                                _mode = GuiMode.Normal;
                                break;
                            case 2:
                                if (txtGradeLabel.Text.Length <= 0)
                                {
                                    layoutGrade.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                if (txtGradeValue.Text.Length <= 0)
                                {
                                    layoutValue.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                ProcessAddACGrade prcGradeAdd = new ProcessAddACGrade();
                                prcGradeAdd.AC_GRADE.GRADE_LABEL = txtGradeLabel.Text;
                                prcGradeAdd.AC_GRADE.GRADE_VALUE = txtGradeValue.Text;
                                prcGradeAdd.AC_GRADE.ORG_ID = 1;
                                prcGradeAdd.AC_GRADE.CREATED_BY = new GBLEnvVariable().UserID;
                                prcGradeAdd.AC_GRADE.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                prcGradeAdd.AC_GRADE.SEND_MESSAGE = chkSendMessage.Checked == true ? "Y" : "N";
                                prcGradeAdd.Invoke();

                                InitializeACGradeData();
                                setFormAC_GRADE(GuiMode.Normal);

                                advbgAC_GRADE.FocusedRowHandle = ((DataTable)grdAC_GRADE.DataSource).Rows.Count - 1;
                                SelectACGradeData(prcGradeAdd.AC_GRADE.GRADE_ID);
                                _GradeID = prcGradeAdd.AC_GRADE.GRADE_ID;
                                _mode = GuiMode.Normal;
                                break;
                            case 3:
                                if (tbReportLangLabel.Text.Length <= 0)
                                {
                                    layoutReportLangLabel.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                if (tbReportLangValue.Text.Length <= 0)
                                {
                                    layoutReportLangValue.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                Envision.BusinessLogic.ProcessCreate.ProcessAddACReportingLanguage _processAddAcReportingLanguage = new Envision.BusinessLogic.ProcessCreate.ProcessAddACReportingLanguage();
                                _processAddAcReportingLanguage.AC_REPORTINGLANGUAGE.ORG_ID = env.OrgID;
                                _processAddAcReportingLanguage.AC_REPORTINGLANGUAGE.CREATED_BY = env.UserID;
                                _processAddAcReportingLanguage.AC_REPORTINGLANGUAGE.REPORT_LANG_LABEL = this.tbReportLangLabel.Text;
                                _processAddAcReportingLanguage.AC_REPORTINGLANGUAGE.REPORT_LANG_VALUE = this.tbReportLangValue.Text;
                                _processAddAcReportingLanguage.AC_REPORTINGLANGUAGE.SEND_MESSAGE = chkSendMessage2.Checked == true ? "Y" : "N";

                                _processAddAcReportingLanguage.Invoke();

                                this.InitializeACReportLangData();
                                this.setFormAC_REPORTLANG(GuiMode.Normal);
                                gridviewReportingLanaguage.FocusedRowHandle = ((DataTable)gridControlReportingLang.DataSource).Rows.Count - 1;
                                _ReportLangId = _processAddAcReportingLanguage.AC_REPORTINGLANGUAGE.REPORT_LANG_ID;
                                DataRow[] newRow = _dsAC_REPORTINGLANG.Tables[0].Select("REPORT_LANG_ID=" + _ReportLangId);
                                if (newRow.Length > 0)
                                {
                                    this.SelectACReportLangData(newRow[0]);
                                }
                                else
                                {
                                    this.SelectACReportLangData(null);
                                }
                                break;
                            case 4:
                                if (txtEnrollUID.Text.Length <= 0)
                                {
                                    layoutEnroll.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                ProcessAddACEnrollment prcEnrollAdd = new ProcessAddACEnrollment();
                                prcEnrollAdd.AC_ENROLLMENT.ENROLL_UID = txtEnrollUID.Text;
                                prcEnrollAdd.AC_ENROLLMENT.YEAR_ID = Convert.ToInt32(listYear[cmbEnrollYear.SelectedIndex]);
                                prcEnrollAdd.AC_ENROLLMENT.CLASS_ID = Convert.ToInt32(listClass[cmbEnrollClass.SelectedIndex]);
                                prcEnrollAdd.AC_ENROLLMENT.EMP_ID = Convert.ToInt32(cmbEnrollEmp.EditValue);
                                prcEnrollAdd.AC_ENROLLMENT.ORG_ID = 1;
                                prcEnrollAdd.AC_ENROLLMENT.CREATED_BY = new GBLEnvVariable().UserID;
                                prcEnrollAdd.AC_ENROLLMENT.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                if (chkEnrollActive.Checked)
                                    prcEnrollAdd.AC_ENROLLMENT.IS_ACTIVE = "Y";
                                else
                                    prcEnrollAdd.AC_ENROLLMENT.IS_ACTIVE = "N";

                                prcEnrollAdd.Invoke();

                                InitializeACEnrollmentData();
                                setFormAC_ENROLLMENT(GuiMode.Normal);

                                advbgAC_ENROLLMENT.FocusedRowHandle = ((DataTable)grdAC_ENROLLMENT.DataSource).Rows.Count - 1;
                                SelectACEnrollmentData(prcEnrollAdd.AC_ENROLLMENT.ENROLL_ID);
                                _EnrollID = prcEnrollAdd.AC_ENROLLMENT.ENROLL_ID;
                                _mode = GuiMode.Normal;
                                break;
                            case 5 :
                                SaveFinalizePrivilege();
                                setFormAC_FINALIZEPRIVILEGE(GuiMode.Add);

                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case GuiMode.Edit:
                    s = msg.ShowAlert("UID4002", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        switch (xtraTabControl1.SelectedTabPageIndex)
                        {
                            case 0:
                                if (dtStartDate.DateTime > dtEndDate.DateTime)
                                {
                                    layoutStart.AppearanceItemCaption.ForeColor = Color.Red;
                                    layoutEnd.AppearanceItemCaption.ForeColor = Color.Red;
                                    return;
                                }
                                ProcessUpdateACYear prcUpdate = new ProcessUpdateACYear();
                                prcUpdate.AC_YEAR.YEAR_ID = _YearID;
                                prcUpdate.AC_YEAR.YEAR_UID = txtYearUID.Text;
                                prcUpdate.AC_YEAR.START_DATE = dtStartDate.DateTime;
                                prcUpdate.AC_YEAR.END_DATE = dtEndDate.DateTime;
                                prcUpdate.AC_YEAR.ORG_ID = 1;
                                prcUpdate.AC_YEAR.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                prcUpdate.Invoke();

                                InitializeACYearData();
                                setFormAC_YEAR(GuiMode.Normal);

                                advbgAC_YEAR.FocusedRowHandle = _AC_YEAR_RowHandle;
                                SelectACYearData(_YearID);
                                _mode = GuiMode.Normal;
                                break;
                            case 1:
                                ProcessUpdateACClass prcACClassUpdate = new ProcessUpdateACClass();
                                prcACClassUpdate.AC_CLASS.CLASS_ALIAS = txtClassAlias.Text;
                                prcACClassUpdate.AC_CLASS.CLASS_ID = _ClassID;
                                prcACClassUpdate.AC_CLASS.CLASS_LABEL = txtClassLabel.Text;
                                prcACClassUpdate.AC_CLASS.ORG_ID = 1;
                                prcACClassUpdate.AC_CLASS.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                prcACClassUpdate.Invoke();

                                InitializeACClassData();
                                setFormAC_CLASS(GuiMode.Normal);

                                advgbAC_CLASS.FocusedRowHandle = _AC_CLASS_RowHandle;
                                SelectACClassData(_ClassID);
                                _mode = GuiMode.Normal;
                                break;
                            case 2:
                                ProcessUpdateACGrade prcACGradeUpdate = new ProcessUpdateACGrade();
                                prcACGradeUpdate.AC_GRADE.GRADE_ID = _GradeID;
                                prcACGradeUpdate.AC_GRADE.GRADE_LABEL = txtGradeLabel.Text;
                                prcACGradeUpdate.AC_GRADE.GRADE_VALUE = txtGradeValue.Text;
                                prcACGradeUpdate.AC_GRADE.ORG_ID = 1;
                                prcACGradeUpdate.AC_GRADE.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                prcACGradeUpdate.AC_GRADE.SEND_MESSAGE = chkSendMessage.Checked == true ? "Y" : "N";
                                prcACGradeUpdate.Invoke();

                                InitializeACGradeData();
                                setFormAC_GRADE(GuiMode.Normal);

                                advbgAC_GRADE.FocusedRowHandle = _AC_GRADE_RowHandle;
                                SelectACGradeData(_GradeID);
                                _mode = GuiMode.Normal;
                                break;
                            case 3:
                                Envision.BusinessLogic.ProcessUpdate.ProcessUpdateACReportingLanguage _processUpdateACReportingLanguage = new Envision.BusinessLogic.ProcessUpdate.ProcessUpdateACReportingLanguage();
                                _processUpdateACReportingLanguage.AC_REPORTINGLANGUAGE.REPORT_LANG_ID = _ReportLangId;
                                _processUpdateACReportingLanguage.AC_REPORTINGLANGUAGE.REPORT_LANG_LABEL = this.tbReportLangLabel.Text;
                                _processUpdateACReportingLanguage.AC_REPORTINGLANGUAGE.REPORT_LANG_VALUE = this.tbReportLangValue.Text;
                                _processUpdateACReportingLanguage.AC_REPORTINGLANGUAGE.ORG_ID = env.OrgID;
                                _processUpdateACReportingLanguage.AC_REPORTINGLANGUAGE.LAST_MODIFIED_BY = env.UserID;
                                _processUpdateACReportingLanguage.AC_REPORTINGLANGUAGE.SEND_MESSAGE = chkSendMessage2.Checked == true ? "Y" : "N";
                                _processUpdateACReportingLanguage.Invoke();

                                this.InitializeACReportLangData();
                                this.setFormAC_REPORTLANG(GuiMode.Normal);

                                gridviewReportingLanaguage.FocusedRowHandle = _ReportLange_RowHandle;
                                this.SelectACReportLangData(gridviewReportingLanaguage.GetFocusedDataRow());
                                _mode = GuiMode.Normal;
                                break;
                            case 4:
                                ProcessUpdateACEnrollment prcACEnrollUpdate = new ProcessUpdateACEnrollment();
                                prcACEnrollUpdate.AC_ENROLLMENT.ENROLL_ID = _EnrollID;
                                prcACEnrollUpdate.AC_ENROLLMENT.ENROLL_UID = txtEnrollUID.Text;
                                prcACEnrollUpdate.AC_ENROLLMENT.YEAR_ID = Convert.ToInt32(listYear[cmbEnrollYear.SelectedIndex]);
                                prcACEnrollUpdate.AC_ENROLLMENT.CLASS_ID = Convert.ToInt32(listClass[cmbEnrollClass.SelectedIndex]);
                                prcACEnrollUpdate.AC_ENROLLMENT.EMP_ID = Convert.ToInt32(cmbEnrollEmp.EditValue);
                                prcACEnrollUpdate.AC_ENROLLMENT.ORG_ID = 1;
                                prcACEnrollUpdate.AC_ENROLLMENT.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                if (chkEnrollActive.Checked)
                                    prcACEnrollUpdate.AC_ENROLLMENT.IS_ACTIVE = "Y";
                                else
                                    prcACEnrollUpdate.AC_ENROLLMENT.IS_ACTIVE = "N";

                                prcACEnrollUpdate.Invoke();

                                InitializeACEnrollmentData();
                                setFormAC_ENROLLMENT(GuiMode.Normal);

                                advbgAC_ENROLLMENT.FocusedRowHandle = _AC_ENROLL_RowHandle;
                                SelectACEnrollmentData(_EnrollID);
                                _mode = GuiMode.Normal;
                                break;
                            case 5:

                                bool foundSelected = false;
                                foreach (DataRow drEmp in _dsAC_FINALIZEJobTitle.Tables[1].Rows)
                                    if (drEmp["IS_ACTIVE"].ToString() == "Y")
                                    {
                                        foundSelected = true;
                                        break;
                                    }

                                if (!foundSelected)
                                {
                                    msg.ShowAlert("UID2101", env.CurrentLanguageID);
                                    return;
                                }

                                SaveFinalizePrivilege();
                                setFormAC_FINALIZEPRIVILEGE(GuiMode.Add);

                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }

        }
        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    if (advbgAC_YEAR.SelectedRowsCount == 0)
                        return;
                    setFormAC_YEAR(GuiMode.Edit);
                    break;
                case 1:
                    if (advgbAC_CLASS.SelectedRowsCount == 0)
                        return;
                    setFormAC_CLASS(GuiMode.Edit);
                    break;
                case 2:
                    if (advbgAC_GRADE.SelectedRowsCount == 0)
                        return;
                    setFormAC_GRADE(GuiMode.Edit);
                    break;
                case 3:
                    if (gridviewReportingLanaguage.SelectedRowsCount == 0)
                        return;
                    setFormAC_REPORTLANG(GuiMode.Edit);
                    break;
                case 4:
                    if (advbgAC_ENROLLMENT.SelectedRowsCount == 0)
                        return;
                    setFormAC_ENROLLMENT(GuiMode.Edit);
                    break;
                case 5:
                    setFormAC_FINALIZEPRIVILEGE(GuiMode.Edit);
                    break;
                default:
                    break;
            }
            _mode = GuiMode.Edit;
        }
        private void advbgAC_YEAR_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = advbgAC_YEAR.GetDataRow(e.RowHandle);
                _YearID = Convert.ToInt32(dr["YEAR_ID"].ToString());
                SelectACYearData(_YearID);
                _AC_YEAR_RowHandle = e.RowHandle;
            }
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string s;
           
                switch (xtraTabControl1.SelectedTabPageIndex)
                {
                    case 0:
                        if (advbgAC_YEAR.SelectedRowsCount == 0)
                            return;
                        if (advbgAC_YEAR.FocusedRowHandle >= 0)
                        {
                             s = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                             if (s == "2")
                             {
                                 DataRow dr = advbgAC_YEAR.GetDataRow(advbgAC_YEAR.FocusedRowHandle);
                                 _YearID = Convert.ToInt32(dr["YEAR_ID"].ToString());
                                 ProcessDeleteACYear del = new ProcessDeleteACYear();
                                 del.AC_YEAR.YEAR_ID = _YearID;
                                 del.Invoke();
                                 InitializeData();
                             }
                        }
                        break;
                    case 1:
                        if (advgbAC_CLASS.SelectedRowsCount == 0)
                            return;
                        if (advgbAC_CLASS.FocusedRowHandle >= 0)
                        {
                             s = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                             if (s == "2")
                             {
                                 DataRow dr = advgbAC_CLASS.GetDataRow(advgbAC_CLASS.FocusedRowHandle);
                                 _ClassID = Convert.ToInt32(dr["CLASS_ID"].ToString());
                                 ProcessDeleteACClass del = new ProcessDeleteACClass();
                                 del.AC_CLASS.CLASS_ID = _ClassID;
                                 del.Invoke();
                                 InitializeData();
                             }
                        }
                        break;
                    case 2:
                        if (advbgAC_GRADE.SelectedRowsCount == 0)
                            return;
                        if (advbgAC_GRADE.FocusedRowHandle >= 0)
                        {
                             s = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                             if (s == "2")
                             {
                                 DataRow dr = advbgAC_GRADE.GetDataRow(advbgAC_GRADE.FocusedRowHandle);
                                 _GradeID = Convert.ToInt32(dr["GRADE_ID"].ToString());
                                 ProcessDeleteACGrade del = new ProcessDeleteACGrade();
                                 del.AC_GRADE.GRADE_ID = _GradeID;
                                 del.Invoke();
                                 InitializeData();
                             }
                        }
                        break;
                    case 3:
                        if (gridviewReportingLanaguage.SelectedRowsCount == 0)
                            return;
                        if (gridviewReportingLanaguage.FocusedRowHandle >= 0)
                        {
                            s = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                            if (s == "2")
                            {
                                DataRow dr = this.gridviewReportingLanaguage.GetFocusedDataRow();
                                _ReportLangId = Convert.ToInt32(dr["REPORT_LANG_ID"]);
                                Envision.BusinessLogic.ProcessDelete.ProcessDeleteACReportingLanguage _processDeleteACReportingLanguage = new Envision.BusinessLogic.ProcessDelete.ProcessDeleteACReportingLanguage();
                                _processDeleteACReportingLanguage.AC_REPORTINGLANGUAGE.REPORT_LANG_ID = _ReportLangId;
                                _processDeleteACReportingLanguage.AC_REPORTINGLANGUAGE.ORG_ID = env.OrgID;
                                _processDeleteACReportingLanguage.Invoke();
                                InitializeData();
                            }
                        }
                        break;
                    case 4:
                        if (advbgAC_ENROLLMENT.SelectedRowsCount == 0)
                            return;
                        if (advbgAC_ENROLLMENT.FocusedRowHandle >= 0)
                        {
                             s = msg.ShowAlert("UID6004", env.CurrentLanguageID);
                             if (s == "2")
                             {
                                 DataRow dr = advbgAC_ENROLLMENT.GetDataRow(advbgAC_ENROLLMENT.FocusedRowHandle);
                                 _EnrollID = Convert.ToInt32(dr["ENROLL_ID"].ToString());
                                 ProcessDeleteACEnrollment del = new ProcessDeleteACEnrollment();
                                 del.AC_ENROLLMENT.ENROLL_ID = _EnrollID;
                                 del.Invoke();
                                 InitializeData();
                             }
                        }
                        break;
                    default:
                        break;
                }
            
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitializeData();
        }
        private void advgbAC_CLASS_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = advgbAC_CLASS.GetDataRow(e.RowHandle);
                _ClassID = Convert.ToInt32(dr["CLASS_ID"].ToString());
                SelectACClassData(_ClassID);
                _AC_CLASS_RowHandle = e.RowHandle;
            }
        }
        private void advbgAC_GRADE_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = advbgAC_GRADE.GetDataRow(e.RowHandle);
                _GradeID = Convert.ToInt32(dr["GRADE_ID"].ToString());
                SelectACGradeData(_GradeID);
                _AC_GRADE_RowHandle = e.RowHandle;
            }
        }
        private void advbgAC_ENROLLMENT_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = advbgAC_ENROLLMENT.GetDataRow(e.RowHandle);
                _EnrollID = Convert.ToInt32(dr["ENROLL_ID"].ToString());
                SelectACEnrollmentData(_EnrollID);
                _AC_ENROLL_RowHandle = e.RowHandle;
            }
        }

        private void gridviewReportingLanaguage_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = gridviewReportingLanaguage.GetDataRow(e.RowHandle);
                _ReportLangId = Convert.ToInt32(dr["REPORT_LANG_ID"].ToString());
                this.SelectACReportLangData(dr);
                _ReportLange_RowHandle = e.RowHandle;
            }
        }

        private void LoadJobtitleData()
        {
            ProcessGetACFinalizePrivilege get = new ProcessGetACFinalizePrivilege();
            get.SelectJobTitle();
            //_dsAC_FINALIZEJobTitle = get.ResultSet;

            DataSet dsJob = new DataSet("Job");
            DataTable dtJT = get.ResultSet.Tables[0];
            DataTable dtHE = get.ResultSet.Tables[1];
            dtJT.TableName = "JobTitle";
            dtHE.TableName = "HrEmp";
            dsJob = new DataSet();
            dsJob.Tables.Add(dtJT.Copy());
            dsJob.Tables.Add(dtHE.Copy());
            dsJob.AcceptChanges();
            dsJob.Relations.Add("FK_JOBTITLE_ID", dsJob.Tables["JobTitle"].Columns["JOB_TITLE_ID"], dsJob.Tables["HrEmp"].Columns["JOBTITLE_ID"]);
            dsJob.AcceptChanges();
            _dsAC_FINALIZEJobTitle = dsJob.Copy();
        }
        private void LoadJobtitleFilter()
        {

        }
        private void LoadJobtitleGrid()
        {
            gcJobTitle.DataSource = _dsAC_FINALIZEJobTitle.Tables[0];

            gvJobTitle.OptionsDetail.ShowDetailTabs = false;
            gcJobTitle.ForceInitialize();
            GridView gvSubJobTitle = new GridView(gcJobTitle);
            gcJobTitle.LevelTree.Nodes.Add("FK_JOBTITLE_ID", gvSubJobTitle);
            gvSubJobTitle.PopulateColumns(_dsAC_FINALIZEJobTitle.Tables["HrEmp"]);
            //gvSubJobTitle.OptionsView.ColumnAutoWidth = false;
            gvSubJobTitle.OptionsView.ShowGroupPanel = false;
            gvSubJobTitle.OptionsView.ShowIndicator = false;
            gvSubJobTitle.OptionsView.ShowAutoFilterRow = true;
            gvSubJobTitle.OptionsView.ShowFooter = false;
            gvSubJobTitle.FocusedRowChanged += new FocusedRowChangedEventHandler(gvSubJobTitle_FocusedRowChanged);

            foreach (GridColumn col in gvJobTitle.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.AllowEdit = false;
            }

            foreach (GridColumn col in gvSubJobTitle.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.AllowEdit = false;
            }

            //Master Grid Setting
            gvJobTitle.Columns["JOB_TITLE_UID"].VisibleIndex = 1;
            gvJobTitle.Columns["JOB_TITLE_UID"].Caption = "Code";

            gvJobTitle.Columns["JOB_TITLE_DESC"].VisibleIndex = 2;
            gvJobTitle.Columns["JOB_TITLE_DESC"].Caption = "Name";

            gvJobTitle.Columns["IS_ACTIVE"].VisibleIndex = 3;
            gvJobTitle.Columns["IS_ACTIVE"].OptionsColumn.AllowEdit = true;
            gvJobTitle.Columns["IS_ACTIVE"].Caption = "Select";

            RepositoryItemCheckEdit Chk = new RepositoryItemCheckEdit();
            Chk.AllowGrayed = true;
            Chk.ValueChecked = "Y";
            Chk.ValueUnchecked = "N";
            Chk.ValueGrayed = "YN";
            Chk.CheckedChanged += new EventHandler(gvJobTitleIsActive_CheckedChanged);
            gvJobTitle.Columns["IS_ACTIVE"].ColumnEdit = Chk;

            //Detail Grid
            gvSubJobTitle.Columns["USER_NAME"].VisibleIndex = 1;
            gvSubJobTitle.Columns["USER_NAME"].Caption = "Code";

            gvSubJobTitle.Columns["FULL_NAME"].VisibleIndex = 2;
            gvSubJobTitle.Columns["FULL_NAME"].Caption = "Name";

            gvSubJobTitle.Columns["IS_ACTIVE"].VisibleIndex = 3;
            gvSubJobTitle.Columns["IS_ACTIVE"].OptionsColumn.AllowEdit = true;
            gvSubJobTitle.Columns["IS_ACTIVE"].Caption = "Select";

            RepositoryItemCheckEdit subChk = new RepositoryItemCheckEdit();
            subChk.AllowGrayed = false;
            subChk.ValueChecked = "Y";
            subChk.ValueUnchecked = "N";
            subChk.CheckedChanged += new EventHandler(gvSubJobTitle_CheckedChanged);
            gvSubJobTitle.Columns["IS_ACTIVE"].ColumnEdit = subChk;
        }
        private void ReloadJobtitle()
        {
            LoadJobtitleData();
            LoadJobtitleFilter();
            LoadJobtitleGrid();
        }

        private void LoadExamTypeData()
        {
            DataRow rowJob = ((GridView)gcJobTitle.FocusedView).GetFocusedDataRow();//gvJobTitle.GetFocusedDataRow();
            if (rowJob == null || rowJob.Table.Columns["EMP_ID"] == null || rowJob["EMP_ID"] == null)
            {
                _HrEmpID = 0;
                //((GridView)gvJobTitle.GetDetailView(gvJobTitle.FocusedRowHandle, 0)).FocusedRowHandle = 0;
            }
            else
            {
                _HrEmpID = Convert.ToInt32(rowJob["EMP_ID"]);
            }

            ProcessGetACFinalizePrivilege get = new ProcessGetACFinalizePrivilege();
            get.SelectExamTypeWithIsActive(_HrEmpID);
            //_dsAC_FINALIZEExamType = get.ResultSet;

            DataSet dsType = new DataSet("Type");
            DataTable dtJT = get.ResultSet.Tables[0];
            DataTable dtHE = get.ResultSet.Tables[1];
            dtJT.TableName = "ExamType";
            dtHE.TableName = "Exam";
            dsType = new DataSet();
            dsType.Tables.Add(dtJT.Copy());
            dsType.Tables.Add(dtHE.Copy());
            dsType.AcceptChanges();
            dsType.Relations.Add("FK_EXAM_TYPE", dsType.Tables["ExamType"].Columns["EXAM_TYPE_ID"], dsType.Tables["Exam"].Columns["EXAM_TYPE"]);
            dsType.AcceptChanges();
            _dsAC_FINALIZEExamType = dsType.Copy();
        }
        private void LoadExamTypeFilter()
        {

        }
        private void LoadExamTypeGrid()
        {
            gcExamType.DataSource = _dsAC_FINALIZEExamType.Tables[0];

            gvExamType.OptionsDetail.ShowDetailTabs = false;
            gcExamType.ForceInitialize();
            GridView gvSubExamType = new GridView(gcExamType);
            gcExamType.LevelTree.Nodes.Add("FK_EXAM_TYPE", gvSubExamType);
            gvSubExamType.PopulateColumns(_dsAC_FINALIZEExamType.Tables["Exam"]);
            //gvSubExamType.OptionsView.ColumnAutoWidth = false;
            gvSubExamType.OptionsView.ShowGroupPanel = false;
            gvSubExamType.OptionsView.ShowIndicator = false;
            gvSubExamType.OptionsView.ShowAutoFilterRow = true;
            gvSubExamType.OptionsView.ShowFooter = false;

            foreach (GridColumn col in gvExamType.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.AllowEdit = false;
            }

            foreach (GridColumn col in gvSubExamType.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.AllowEdit = false;
            }


            //Master Grid Setting
            gvExamType.Columns["EXAM_TYPE_UID"].VisibleIndex = 1;
            gvExamType.Columns["EXAM_TYPE_UID"].Caption = "Code";

            gvExamType.Columns["EXAM_TYPE_TEXT"].VisibleIndex = 2;
            gvExamType.Columns["EXAM_TYPE_TEXT"].Caption = "Name";

            gvExamType.Columns["IS_ACTIVE"].VisibleIndex = 3;
            gvExamType.Columns["IS_ACTIVE"].OptionsColumn.AllowEdit = true;
            gvExamType.Columns["IS_ACTIVE"].Caption = "Active";

            RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();
            chk.AllowGrayed = false;
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.ValueGrayed = "YN";
            chk.CheckedChanged += new EventHandler(gvExamTypeIsActive_CheckedChanged);
            gvExamType.Columns["IS_ACTIVE"].ColumnEdit = chk;

            //Detail Grid Setting
            gvSubExamType.Columns["FULL_NAME"].VisibleIndex = 1;
            gvSubExamType.Columns["FULL_NAME"].Caption = "Exam Name";

            gvSubExamType.Columns["IS_ACTIVE"].VisibleIndex = 2;
            gvSubExamType.Columns["IS_ACTIVE"].OptionsColumn.AllowEdit = true;
            gvSubExamType.Columns["IS_ACTIVE"].Caption = "Active";

            RepositoryItemCheckEdit chkSub = new RepositoryItemCheckEdit();
            chkSub.AllowGrayed = false;
            chkSub.ValueChecked = "Y";
            chkSub.ValueUnchecked = "N";
            chkSub.CheckedChanged += new EventHandler(gvSubExamType_CheckedChanged);
            gvSubExamType.Columns["IS_ACTIVE"].ColumnEdit = chkSub;
        }
        private void ReloadExamType()
        {
            if (gvJobTitle.FocusedRowHandle < 0) return;

            IsExpanded = new List<string>();
            for (int i = 0; i < gvExamType.RowCount; i++)
            {
                GridView gv = (GridView)gvExamType.GetDetailView(i, 0);
                if (gv != null)
                    IsExpanded.Add("Y");
                else
                    IsExpanded.Add("N");
            }

            LoadExamTypeData();
            LoadExamTypeFilter();
            LoadExamTypeGrid();

            int fs = 0;
            foreach (string strChecked in IsExpanded)
            {
                if (strChecked == "Y")
                {
                    gvExamType.ExpandMasterRow(fs, 0);
                }
                fs++;
            }

            CheckSelectAllConditionExamType();
        }

        private void gvJobTitle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ReloadExamType();
        }
        private void gcJobTitle_Click(object sender, EventArgs e)
        {
            ReloadExamType();
        }
        private void gvJobTitleIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (gvJobTitle.GetFocusedDataRow() == null) return;

            CheckEdit chk = (CheckEdit)sender;

            string jobTitleID = gvJobTitle.GetFocusedDataRow()["JOB_TITLE_ID"].ToString();
            DataRow[] selRow = _dsAC_FINALIZEJobTitle.Tables[1].Select("JOBTITLE_ID=" + jobTitleID);

            foreach (DataRow row in selRow)
            {
                if (chk.Checked == true)
                    row["IS_ACTIVE"] = "Y";
                else
                    row["IS_ACTIVE"] = "N";
            }
        }
        private void gvExamTypeIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (gvExamType.GetFocusedDataRow() == null) return;

            CheckEdit chk = (CheckEdit)sender;

            string examTypeID = gvExamType.GetFocusedDataRow()["EXAM_TYPE_ID"].ToString();
            DataRow[] selRow = _dsAC_FINALIZEExamType.Tables[1].Select("EXAM_TYPE=" + examTypeID);

            foreach (DataRow row in selRow)
            {
                if (chk.Checked == true)
                    row["IS_ACTIVE"] = "Y";
                else
                    row["IS_ACTIVE"] = "N";
            }
        }

        private void gvSubJobTitle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ReloadExamType();
        }
        private void gvSubExamType_CheckedChanged(object sender, EventArgs e)
        {
            if (((GridView)gcExamType.FocusedView).GetFocusedDataRow() == null) return;

            CheckEdit chkParam = (CheckEdit)sender;

            string strExamID = ((GridView)gcExamType.FocusedView).GetFocusedDataRow()["EXAM_ID"].ToString();

            DataRow[] rows = _dsAC_FINALIZEExamType.Tables[1].Select("EXAM_ID=" + strExamID);
            if (chkParam.Checked)
                rows[0]["IS_ACTIVE"] = "Y";
            else
                rows[0]["IS_ACTIVE"] = "N";

            CheckSelectAllConditionExamType();
        }
        private void gvSubJobTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (((GridView)gcJobTitle.FocusedView).GetFocusedDataRow() == null) return;

            CheckEdit chkParam = (CheckEdit)sender;

            string strEmpID = ((GridView)gcJobTitle.FocusedView).GetFocusedDataRow()["EMP_ID"].ToString();

            DataRow[] rows = _dsAC_FINALIZEJobTitle.Tables[1].Select("EMP_ID=" + strEmpID);
            if (chkParam.Checked)
                rows[0]["IS_ACTIVE"] = "Y";
            else
                rows[0]["IS_ACTIVE"] = "N";
        }
       
        private void SaveFinalizePrivilege()
        {
            //GridView gv = (GridView)gvExamType.GetDetailView(gvExamType.FocusedRowHandle, 0);
            //int idx = gv.FocusedRowHandle;

            foreach (DataRow drEmp in _dsAC_FINALIZEJobTitle.Tables[1].Rows)
            {
                if (drEmp["IS_ACTIVE"].ToString() != "Y") continue;
                
                foreach (DataRow drExam in _dsAC_FINALIZEExamType.Tables[1].Rows)
                {
                    if (drExam["IS_ACTIVE"].ToString() == "Y")
                    {
                        ProcessAddACFinalizePrivilege prcAcFinalizePrivilege = new ProcessAddACFinalizePrivilege();
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.FINALIZEPRIVILEGE_ID
                            = drExam["FINALIZEPRIVILEGE_ID"].ToString().Trim() == "0" ? 0 : Convert.ToInt32(drExam["FINALIZEPRIVILEGE_ID"].ToString().Trim());
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.EMP_ID = Convert.ToInt32(drEmp["EMP_ID"]);
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.EXAM_ID = Convert.ToInt32(drExam["EXAM_ID"]);
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.IS_ACTIVE = 'Y';
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.ORG_ID = 1;
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.CREATED_BY = env.UserID;
                        prcAcFinalizePrivilege.Invoke();
                    }
                    else
                    {
                        ProcessAddACFinalizePrivilege prcAcFinalizePrivilege = new ProcessAddACFinalizePrivilege();
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.FINALIZEPRIVILEGE_ID 
                            = drExam["FINALIZEPRIVILEGE_ID"].ToString().Trim() == "0" ? 0 : Convert.ToInt32(drExam["FINALIZEPRIVILEGE_ID"].ToString().Trim());
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.EMP_ID = Convert.ToInt32(drEmp["EMP_ID"]);
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.EXAM_ID = Convert.ToInt32(drExam["EXAM_ID"]);
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.IS_ACTIVE = 'N';
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.ORG_ID = 1;
                        prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.CREATED_BY = env.UserID;
                        prcAcFinalizePrivilege.Invoke();
                    }
                }
            }

            ReloadJobtitle();
            ReloadExamType();

            //foreach (DataRow row in _dsAC_FINALIZEExamType.Tables[0].Rows)
            //{
            //    if (row["IS_ACTIVE"].ToString() != "Y") return;

            //    ProcessAddACFinalizePrivilege prcAcFinalizePrivilege = new ProcessAddACFinalizePrivilege();
            //    prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.FINALIZEPRIVILEGE_ID = 0;
            //    prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.EXAM_ID = 0;
            //    prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.JOBTITLE_ID = _jobTitleID;
            //    prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.EXAM_TYPE = Convert.ToInt32(row["EXAM_TYPE_ID"]);
            //    prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.IS_ACTIVE = 'Y';
            //    prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.ORG_ID = 1;
            //    prcAcFinalizePrivilege.AC_FINALIZEPRIVILEGE.CREATED_BY = env.UserID;
            //    prcAcFinalizePrivilege.Invoke();
            //}
        }
        private void CheckSelectAllConditionJobTitle()
        {
            //foreach (DataRow row in _dsAC_FINALIZEJobTitle.Tables[0].Rows)
            //{
            //    string JOBTITLE_ID = row["JOB_TITLE_ID"].ToString();
            //    DataRow[] rows = _dsAC_FINALIZEJobTitle.Tables[1].Select("JOBTITLE_ID=" + JOBTITLE_ID + " AND IS_ACTIVE='Y'");
            //    DataRow[] rowsTotal = _dsAC_FINALIZEJobTitle.Tables[1].Select("JOBTITLE_ID=" + JOBTITLE_ID);
            //    if (rows.Length == rowsTotal.Length)
            //        row["IS_ACTIVE"] = "Y";
            //    else if (rows.Length > 0)
            //        row["IS_ACTIVE"] = "YN";
            //    else
            //        row["IS_ACTIVE"] = "N";
            //}
        }
        private void CheckSelectAllConditionExamType()
        {
            foreach (DataRow row in _dsAC_FINALIZEExamType.Tables[0].Rows)
            {
                string EXAM_TYPE_ID = row["EXAM_TYPE_ID"].ToString();
                DataRow[] rows = _dsAC_FINALIZEExamType.Tables[1].Select("EXAM_TYPE=" + EXAM_TYPE_ID + " AND IS_ACTIVE='Y'");
                DataRow[] rowsTotal = _dsAC_FINALIZEExamType.Tables[1].Select("EXAM_TYPE=" + EXAM_TYPE_ID);
                if ((rows.Length == rowsTotal.Length) && rows.Length != 0)
                    row["IS_ACTIVE"] = "Y";
                else if (rows.Length > 0)
                    row["IS_ACTIVE"] = "YN";
                else
                    row["IS_ACTIVE"] = "N";
            }
        }
    }
}
