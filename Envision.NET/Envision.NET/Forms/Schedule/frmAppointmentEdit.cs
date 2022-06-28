using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Xml;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.Operational;
using Envision.NET.Forms.Schedule.Common;
using Envision.NET.Forms.Dialog;
using Miracle.Scanner;
using Envision.NET.Forms.EMR;
using Envision.Operational.Translator;
using DevExpress.XtraEditors.Controls;
using Envision.Common.Common;
using Miracle.Util;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmAppointmentEdit :DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SchedulerControl control;
        private Appointment apt;
        private frmPopupOrderOrScheduleSummary _summary;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        public DataTable dttBpview { get; set; }
        public DataTable dttDepartment { get; set; }
        public DataTable dttDoctor { get; set; }
        public DataTable dttRadiologist { get; set; }
        private Patient patient;
        private DataTable dttExamModality;
        private DataTable dttModalityClinic;
        private DataTable dttSession;
        private DataTable dtImageScan;
        private DataTable dttAppointment;
        private DataTable dttExamPanel;
        private DataTable dataExam;
        private DataTable dttExam;
        private DataSet dsHistorySchedule;
        private DataTable dttExamFlag, dtExamFlagDTL;
        private List<int> delExamItem;
        private int avg_inv_time;
        private DataView dv_scan_image = null;

        private int pat_id,schedule_id,clinictype;
        private string HN,_mode;
        private bool is_block;
        private MyAppointmentFormController controller;
        public string SCHEDULE_STATUS { get; set; }
        private string strMsgChangeRad = string.Empty;

        public frmAppointmentEdit(SchedulerControl control, Appointment apt,DataTable Data)
        {
            this.apt = apt;
            this.control = control;
            controller = new MyAppointmentFormController(control, apt);
            InitializeComponent();
            dttAppointment = Data;
        }
        public frmAppointmentEdit(SchedulerControl control, Appointment apt,string mode)
        {
            this.apt = apt;
            this.control = control;
            controller = new MyAppointmentFormController(control, apt);
            InitializeComponent();
            _mode = mode;
        }

        private void frmAppointmentEdit_Load(object sender, EventArgs e)
        {
            initControlFirst();
            if (_mode == "Past")
            {

                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnSavePrint.Enabled = false;
                btnScan.Enabled = false;
                groupReason.Enabled = false;
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                groupTiming.Enabled = false;
            }
            delExamItem = new List<int>();
            txtID.Focus();
            this._summary = new frmPopupOrderOrScheduleSummary();

            txtHN.Focus();
        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.SCHEDULE_ID = schedule_id == 0 ? -1 : schedule_id;
            prc.InvokeSchedule();
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();

            contextcmb.Items.Clear();
            System.Windows.Forms.ComboBox.ObjectCollection colls = contextcmb.Items;
            try
            {
                foreach (DataRow row in dtExamFlagDTL.Rows)
                    colls.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
            }
            finally
            {
            }
            contextcmb.SelectedIndex = 0;
        }
        
        private void waitConnectionHIS() {
            clearContextControl();
            enableDisableControl();
            groupTiming.Enabled = true;
            initDataGridColumns();
            initGridExam();
            txtAGE.Text = string.Empty;
            txtHN.Text = string.Empty;
            patient = null;
        }
        private void createPatientDemographic() {
            HN = txtHN.Text;
            clearContextControl();
            fillDemographic();
            txtHN.Enabled = false;
            txtFName.Enabled = true;
            txtFName.Properties.ReadOnly = false;
            txtLName.Properties.ReadOnly = false;
            txtLName.Enabled = true;
            cboGender.Enabled = true;
            cboGender.Properties.ReadOnly = false;
            cboGender.BackColor = Color.White;

            txtID.Enabled = true;
            txtID.Properties.ReadOnly = false;
            txtID.BackColor = Color.White;
            cboGender.SelectedIndex = 0;
            deLMP.Enabled = false;
            btnSavePrint.Enabled = btnScan.Enabled = true;
            patient = null;
            txtAGE.Text = string.Empty;

            txtHN.Text = HN.Trim();
            txtID.Focus();
        }
        private void clearContextControl()
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtFName_Eng.Text = string.Empty;
            txtLName_Eng.Text = string.Empty;
            txtID.Text = string.Empty;
            cboGender.SelectedIndex = 0;
            txtPhone.Text = string.Empty;
            //txtMobile.Text = string.Empty;
            dtLastVisit.DateTime = DateTime.Now;
            dtNextVisit.DateTime = DateTime.Now;
            txtOrderDept.Tag = null;
            txtOrderDept.Text = string.Empty;
            txtOrderDoc.Tag = null;
            txtOrderDoc.Text = string.Empty;
            deLMP.Text = string.Empty;
        }
        private void doTimerValidated()
        {
            if (is_block) return;
            DateTime tsStart = (DateTime)timeStart.EditValue;
            tsStart = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, tsStart.Hour, tsStart.Minute, tsStart.Second);

            DateTime tsEnd = (DateTime)timeEnd.EditValue;
            tsEnd = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, tsEnd.Hour, tsEnd.Minute, tsEnd.Second);

            timeStart.EditValue = tsStart;
            timeEnd.EditValue = tsEnd;
            if ((timeStart.Time > timeEnd.Time) || (timeEnd.Time < timeStart.Time))
            {
                dxErrorProvider1.SetError(timeStart, "more than end time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(timeEnd, "less than start time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
                dxErrorProvider1.ClearErrors();
        }
        private void doDateValidated()
        {
            if (is_block) return;
            if (string.IsNullOrEmpty(dtStart.Text))
            {
                dxErrorProvider1.SetError(dtStart, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
                dtStart.ErrorText = string.Empty;
            if (string.IsNullOrEmpty(dtEnd.Text))
            {
                dxErrorProvider1.SetError(dtEnd, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
                dtEnd.ErrorText = string.Empty;

            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day);  //dtStart.DateTime;
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day);    //dtEnd.DateTime;
            if (start > end)
            {
                dxErrorProvider1.SetError(dtStart, "date start more than end date", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(dtEnd, "less than start time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
                dxErrorProvider1.ClearErrors();

        }
        private string ModalityName(string ID)
        {
            string name = string.Empty;
            ProcessGetRISModality process = new ProcessGetRISModality(true);
            process.Invoke();
            DataTable dttModaltiy = new DataTable();
            dttModaltiy = process.Result.Tables[0].Copy();
            DataRow[] dr = dttModaltiy.Select("MODALITY_ID =" + ID);
            avg_inv_time = 5;
            if (dr.Length > 0)
            {
                name = dr[0]["MODALITY_NAME"].ToString();
                avg_inv_time = Convert.ToInt32(dr[0]["AVG_INV_TIME"].ToString());
            }
            ProcessGetRISModalityexam processExam = new ProcessGetRISModalityexam(Convert.ToInt32(ID));
            processExam.Invoke();
            dataExam = new DataTable();
            dataExam = processExam.Result.Tables[0].Copy();
            initiateExamPanel();
            return name;
        }
        private void initDefaultControlStart()
        {

            dtLastVisit.DateTime = DateTime.Today;
            dtNextVisit.DateTime = DateTime.Today;
            dtLastVisit.Text = DateTime.Today.ToString("dddd dd/MM/yyyy");
            dtNextVisit.Text = DateTime.Today.ToString("dddd dd/MM/yyyy");
            
            cboGender.Properties.Items.Clear();
            cboGender.Properties.Items.Add("Male");
            cboGender.Properties.Items.Add("Female");
            cboGender.SelectedIndex = 0;

        }
        private void setAutoComplete()
        {
            int id = Convert.ToInt32(apt.ResourceId.ToString());
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(id);
            process.Invoke();
            dttExamModality = new DataTable();
            dttExamModality = process.Result.Tables[0].Copy();

            AutoCompleteStringCollection Dep = new AutoCompleteStringCollection();
            AutoCompleteStringCollection Doc = new AutoCompleteStringCollection();
            AutoCompleteStringCollection Prep = new AutoCompleteStringCollection();

            for (int i = 0; i < dttDepartment.Rows.Count; i++)
                Dep.Add(dttDepartment.Rows[i]["UNIT_UID"].ToString() + ":" + dttDepartment.Rows[i]["UNIT_NAME"].ToString());

            for (int i = 0; i < dttDoctor.Rows.Count; i++)
                Doc.Add(dttDoctor.Rows[i]["EMP_UID"].ToString() + ":" + dttDoctor.Rows[i]["RadioName"].ToString());

            txtOrderDept.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtOrderDept.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrderDept.AutoCompleteCustomSource = Dep;

            txtOrderDoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtOrderDoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrderDoc.AutoCompleteCustomSource = Doc;
        }
        private void setModalityClinicType()
        {
            ProcessGetRISModalityclinictype process = new ProcessGetRISModalityclinictype();
            process.Invoke();
            dttModalityClinic = process.Result.Tables[0].Copy();
        }
        private void enableDisableControl()
        {
            groupPatient.Enabled = true;
            enableDisableGroupPatient(false);
            groupVisit.Enabled = false;
            groupExam.Enabled = false;
            groupTiming.Enabled = false;
            txtHN.Enabled = true;
            txtOrderDept.BackColor = txtModality.BackColor;
            txtOrderDoc.BackColor = txtModality.BackColor;
            txtOrderDept.ReadOnly = true;
            txtOrderDoc.ReadOnly = true;
        }
        private void enableDisableGroupPatient(bool flag)
        {
            txtHN.Enabled = flag;
            txtFName.Enabled = flag;
            txtLName.Enabled = flag;
            txtFName_Eng.Enabled = flag;
            txtLName_Eng.Enabled = flag;
            txtID.Enabled = flag;
            cboGender.Enabled = flag;
            txtPhone.Enabled = flag;
            //txtMobile.Enabled = flag;
            deLMP.Enabled = flag;
            grdLvPatStatus.Enabled = flag;
        }
        private void fillDemographic()
        {
            if (is_block)
            {
                patient = new Patient();
                clearContextControl();
                enableDisableControl();
                txtHN.Text = string.Empty;
                groupTiming.Enabled = true;
                initDataGridColumns();
                initGridExam();
            }
            else if (patient != null)
            {
                txtHN.Text = patient.Reg_UID;
                txtFName.Text = patient.FirstName;
                txtLName.Text = patient.LastName;
                txtFName_Eng.Text = patient.FirstName_ENG;
                txtLName_Eng.Text = patient.LastName_ENG;
                txtID.Text = patient.SocialNumber;
                DateTime dtDOB = string.IsNullOrEmpty(patient.DateOfBirth.ToString()) ? DateTime.Now : patient.DateOfBirth;
                LookUpSelect lu = new LookUpSelect();
                if (patient.DateOfBirth == DateTime.MinValue)
                    dtDOB = DateTime.Now;
                txtAGE.Text = lu.SelectAGE(dtDOB).Tables[0].Rows[0]["AGE"].ToString();


                cboGender.SelectedIndex = patient.Gender == "M" ? 0 : 1;
                deLMP.ResetText();
                if (cboGender.SelectedIndex == 0)
                {
                    deLMP.BackColor = Color.FromArgb(227, 239, 255);
                    lblLMP.Visible = false;
                    deLMP.Visible = false;
                }
                else
                {
                    deLMP.BackColor = Color.White;
                    deLMP.Text = string.Empty;
                    lblLMP.Visible = true;
                    deLMP.Visible = true;
                }
                if (string.IsNullOrEmpty(patient.Phone1))
                    txtPhone.Text = patient.Phone2;
                else
                    txtPhone.Text = patient.Phone1 + "," + patient.Phone2;
                
                txtPatientIdDetail.Text = string.IsNullOrEmpty(patient.PATIENT_ID_LABEL) ? "-" : "[" + patient.PATIENT_ID_LABEL + "] " + patient.PATIENT_ID_DETAIL;

                dtLastVisit.DateTime = string.IsNullOrEmpty(patient.Last_Modified_ON.ToString()) ? DateTime.Now : patient.Last_Modified_ON;
                dtNextVisit.DateTime = DateTime.Now.AddDays(1);

                groupVisit.Enabled = true;
                groupExam.Enabled = true;
                groupTiming.Enabled = true;
                grdLvPatStatus.Enabled = true;
                grdLvInsurance.Enabled = true;
                DataRow[] drExam = null;
                #region Group Visit.
                int id = 0;
                DataTable dtt = new DataTable();
                if (txtOrderDept.Tag != null)
                {
                    if (int.TryParse(txtOrderDept.Tag.ToString(), out id))
                    {
                        ProcessGetHRUnit unit = new ProcessGetHRUnit();
                        unit.GetDataByID(id);
                        if (Utilities.IsHaveData(unit.Result))
                        {
                            txtOrderDept.Tag = unit.Result.Tables[0].Rows[0]["UNIT_ID"].ToString();
                            txtOrderDept.Text = unit.Result.Tables[0].Rows[0]["UNIT_UID"].ToString() + ":" + unit.Result.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                        }
                    }
                }
                if (txtOrderDoc.Tag != null)
                {
                    if (int.TryParse(txtOrderDoc.Tag.ToString(), out id))
                    {
                        ProcessGetHISDoctor doc = new ProcessGetHISDoctor();
                        doc.getDataByID(id);
                        if (Utilities.IsHaveData(doc.Result))
                        {
                            txtOrderDoc.Tag = doc.Result.Tables[0].Rows[0]["EMP_ID"].ToString();
                            txtOrderDoc.Text = doc.Result.Tables[0].Rows[0]["EMP_UID"].ToString() + ":" + doc.Result.Tables[0].Rows[0]["RadioName"].ToString();
                        }
                    }
                }
                #endregion

                groupPatient.Enabled = true;
                groupVisit.Enabled = true;
                groupExam.Enabled = true;
                grdLvPatStatus.Enabled = true;

                initGridExam();
                initGridAppointment(txtHN.Text);
                enableDisableGroupPatient(true);
                if (txtFName.Text.Trim().Length > 0)
                {
                    txtOrderDept.BackColor = txtHN.BackColor;
                    txtOrderDoc.BackColor = txtHN.BackColor;
                    deLMP.BackColor = deLMP.Visible ? txtHN.BackColor : txtFName.BackColor;
                }
                btnSavePrint.Enabled = btnScan.Enabled = patient.HasHN;
               chkNonResident.Checked = patient.NON_RESIDENCE == "Y" ? true : false;
               checkAllergies();
            }
            else
            {
                txtHN.Text = string.Empty;
                clearContextControl();
                enableDisableControl();
                groupPatient.Enabled = true;
                groupTiming.Enabled = true;
                initGridAppointment("00");
                chkNonResident.Checked = false;
            }
        }
        private void fillDataToCtrl(DataRow dr)
        {
            DataRow[] drExam = null;
            fillDemographic();
            setTrauma();


            #region Group Timing.
            DateTime start = Convert.ToDateTime(dr["START_DATETIME"].ToString());
            DateTime end = Convert.ToDateTime(dr["END_DATETIME"].ToString());
            dtStart.DateTime = start;
            dtEnd.DateTime = end;
            timeStart.Time = start;
            timeEnd.Time = end;
            txtAddTextInBlock.Text = dr["TEXT_SHOW"].ToString();
            #endregion

            #region Group Visit.
            int id = 0;
            DataTable dtt = new DataTable();
            if (!string.IsNullOrEmpty(dr["REF_UNIT"].ToString()))
            {
                if (int.TryParse(dr["REF_UNIT"].ToString(), out id))
                {
                    ProcessGetHRUnit unit = new ProcessGetHRUnit();
                    unit.GetDataByID(id);
                    if (Utilities.IsHaveData(unit.Result))
                    {
                        txtOrderDept.Tag = unit.Result.Tables[0].Rows[0]["UNIT_ID"].ToString();
                        txtOrderDept.Text = unit.Result.Tables[0].Rows[0]["UNIT_NAME"].ToString();//drExam[0]["UNIT_UID"].ToString() + ":" +
                    }
                }

            }
            id = 0;
            if (!string.IsNullOrEmpty(dr["REF_DOC"].ToString()))
            {
                if (int.TryParse(dr["REF_DOC"].ToString(), out id))
                {
                    ProcessGetHISDoctor doc = new ProcessGetHISDoctor();
                    doc.getDataByID(id);
                    if (Utilities.IsHaveData(doc.Result))
                    {
                        txtOrderDoc.Tag = doc.Result.Tables[0].Rows[0]["EMP_ID"].ToString();
                        txtOrderDoc.Text = doc.Result.Tables[0].Rows[0]["EMP_UID"].ToString() + ":" + doc.Result.Tables[0].Rows[0]["RadioName"].ToString();
                    }
                }
            }
            #endregion

            #region Request Result Datetime
            if (!string.IsNullOrEmpty(dr["REQUEST_RESULT_DATETIME"].ToString()))
            {
                chkRequestResult.Checked = true;
                dtRequestResult.DateTime = Convert.ToDateTime(dr["REQUEST_RESULT_DATETIME"]);
                timeReqeustResult.Time = Convert.ToDateTime(dr["REQUEST_RESULT_DATETIME"]);
            }
            #endregion

            chkBlock.Enabled = false;
            chkComments.Enabled = false;

            if ((dr["SCHEDULE_STATUS"].ToString().ToUpper() == "O") || (dr["IS_BLOCKED"].ToString() == "Y") || (dr["IS_COMMENTS"].ToString() == "Y"))
            {
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                groupTiming.Enabled = false;
                groupReason.Enabled = false;

                chkBlock.Enabled = false;
                chkComments.Enabled = false;

                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnScan.Enabled = false;
                btnSavePrint.Enabled = false;


                if (dr["IS_BLOCKED"].ToString() == "Y" || (dr["IS_COMMENTS"].ToString() == "Y"))
                {
                    btnSave.Enabled = true;
                    btnSavePrint.Enabled = false;
                    btnDelete.Enabled = true;

                    #region Clear Context.
                    groupPatient.Enabled = false;
                    groupVisit.Enabled = false;
                    groupExam.Enabled = false;
                    txtOrderDept.Text = string.Empty;
                    txtOrderDoc.Text = string.Empty;
                    txtHN.Text = dr["IS_BLOCKED"].ToString() == "Y" ? "BLOCK" : "COMMENTS";
                    txtFName.Text = string.Empty;
                    txtLName.Text = string.Empty;
                    txtFName_Eng.Text = string.Empty;
                    txtLName_Eng.Text = string.Empty;
                    txtID.Text = string.Empty;
                    cboGender.SelectedIndex = 0;
                    txtPhone.Text = string.Empty;
                    //txtMobile.Text = string.Empty;
                    #endregion

                    if (dr["IS_BLOCKED"].ToString() == "Y")
                        chkBlock.Checked = true;
                    if (dr["IS_COMMENTS"].ToString() == "Y")
                        chkComments.Checked = true;
                    
                    groupTiming.Enabled = true;
                    groupReason.Enabled = true;
                    txtAGE.Text = string.Empty;
                    is_block = true;
                }
            }

            DataRow[] drs;
            try
            {
                drs = dttDepartment.Select("UNIT_ID=" + dr["REF_UNIT"].ToString());
                if (drs.Length > 0)
                {
                    txtOrderDept.Tag = drs[0]["UNIT_ID"].ToString();
                    txtOrderDept.Text =drs[0]["UNIT_UID"].ToString() + ":" +  drs[0]["UNIT_NAME"].ToString();
                }
            }
            catch { txtOrderDept.Text = ""; }
            try
            {
                drs = dttRadiologist.Select("EMP_ID=" + dr["REF_DOC"].ToString());

                if (drs.Length > 0)
                {
                    txtOrderDoc.Tag = dr["REF_DOC"].ToString();
                    txtOrderDoc.Text = drs[0]["EMP_UID"].ToString() + ":" + drs[0]["RadioName"].ToString();
                }
            }
            catch { txtOrderDoc.Text = ""; }
        }
        private void initDefaultSession()
        {
            dttSession = new DataTable();
            ProcessGetRISClinicsession proc = new ProcessGetRISClinicsession();
            dttSession = proc.GetClinicSession().Copy();
            DateTime dtStart = apt.Start;
            foreach (DataRow dr in dttSession.Rows)
            {
                DateTime tmp = Convert.ToDateTime(dr["START_TIME"].ToString());
                DateTime sessionFrom = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, tmp.Hour, tmp.Minute, tmp.Second);
                tmp = Convert.ToDateTime(dr["END_TIME"].ToString());
                DateTime sessionTo = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, tmp.Hour, tmp.Minute, tmp.Second);
                if ((apt.Start >= sessionFrom) && (apt.Start <= sessionTo))
                {
                    txtSession.Tag = dr["SESSION_ID"].ToString();
                    txtSession.Text = dr["SESSION_NAME"].ToString();
                    clinictype = Convert.ToInt32(dr["CLINIC_TYPE_ID"]);
                    break;
                }
            }
        }
        private void setLookupAllGrid()
        {
            DataTable dtPat = RISBaseData.RIS_PatStatus();
            grdLvPatStatus.Properties.DataSource = dtPat;
            grdLvPatStatus.Properties.DisplayMember = "STATUS_TEXT";
            grdLvPatStatus.Properties.ValueMember = "STATUS_ID";
            if (dtPat.Rows.Count > 0)
            {
                grdLvPatStatus.EditValue = dtPat.Rows[0]["STATUS_ID"].ToString();
            }
            setGridLookupPat();

            DataTable dtInsu = RISBaseData.Ris_InsuranceType();
            grdLvInsurance.Properties.DataSource = dtInsu;
            grdLvInsurance.Properties.DisplayMember = "INSURANCE_TYPE_DESC";
            grdLvInsurance.Properties.ValueMember = "INSURANCE_TYPE_ID";
            setGridLookupInsu();
        }
        private void setGridLookupPat()
        {
            viewPat.OptionsView.ShowAutoFilterRow = true;

            viewPat.Columns["STATUS_ID"].Visible = false;
            viewPat.Columns["STATUS_UID"].Visible = false;
            viewPat.Columns["STATUS_TEXT"].Visible = true;
            viewPat.Columns["IS_ACTIVE"].Visible = false;
            viewPat.Columns["ORG_ID"].Visible = false;
            viewPat.Columns["CREATED_BY"].Visible = false;
            viewPat.Columns["CREATED_ON"].Visible = false;
            viewPat.Columns["LAST_MODIFIED_BY"].Visible = false;
            viewPat.Columns["LAST_MODIFIED_ON"].Visible = false;
            viewPat.Columns["IS_DEFAULT"].Visible = false;


            viewPat.Columns["STATUS_TEXT"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewPat.Columns["STATUS_TEXT"].Caption = "Status";

        }
        private void setGridLookupInsu()
        {
            viewInsu.OptionsView.ShowAutoFilterRow = true;

            viewInsu.Columns["INSURANCE_TYPE_ID"].Visible = false;
            viewInsu.Columns["INSURANCE_TYPE_UID"].Visible = false;
            viewInsu.Columns["INSURANCE_TYPE_DESC"].Visible = true;
            viewInsu.Columns["ORG_ID"].Visible = false;
            viewInsu.Columns["CREATED_BY"].Visible = false;
            viewInsu.Columns["CREATED_ON"].Visible = false;
            viewInsu.Columns["LAST_MODIFIED_BY"].Visible = false;
            viewInsu.Columns["LAST_MODIFIED_ON"].Visible = false;

            viewInsu.Columns["INSURANCE_TYPE_DESC"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewInsu.Columns["INSURANCE_TYPE_DESC"].Caption = "Insurance";
        }
        private void initControlFirst()
        {
            try
            {
                initDefaultControlStart();
                txtModality.Text = ModalityName(apt.ResourceId.ToString());
                dtStart.DateTime = apt.Start;
                dtEnd.DateTime = apt.End;
                DateTime dte = apt.End;
                dte = dte.AddSeconds(1);
                dtEnd.EditValue = dte;
                setAutoComplete();
                setModalityClinicType();
                dttSession = new DataTable();
                ProcessGetRISClinicsession prcCln = new ProcessGetRISClinicsession();
                dttSession = prcCln.GetClinicSession().Copy();
                is_block = false;
                ProcessGetRISClinictype process = new ProcessGetRISClinictype();
                process.Invoke();
                DataTable dtt = process.Result.Tables[0];
                DataRow[] dr = dtt.Select("IS_DEFAULT='Y'");
                schedule_id = Convert.ToInt32(apt.Location);
                ProcessGetRISSchedule proc;
                try
                {
                    dv_scan_image = new ScanImages().GetData(schedule_id, 0);

                    proc = new ProcessGetRISSchedule(schedule_id);
                    proc.Invoke();
                    DataTable dt = proc.Result.Tables[0].Copy();
                    dttExam = new DataTable();
                    dttExam = proc.Result.Tables[1].Copy();
                 
                    HN = dt.Rows[0]["HN"].ToString();

                    patient = new Envision.BusinessLogic.Patient(HN, false);
                    if (patient.HasHN)
                        updateRegistrationAllergies();
                    
                    fillDataToCtrl(dt.Rows[0]);
                    int session;
                    if (string.IsNullOrEmpty(dt.Rows[0]["SESSION_ID"].ToString()))
                        initDefaultSession();
                    else
                    {
                        session = Convert.ToInt32(dt.Rows[0]["SESSION_ID"]);
                        DataRow[] drr = dttSession.Select("SESSION_ID=" + session);
                        if (drr.Length > 0)
                        {
                            txtSession.Tag = drr[0]["SESSION_ID"].ToString();
                            txtSession.Text = drr[0]["SESSION_NAME"].ToString();
                            clinictype = Convert.ToInt32(drr[0]["CLINIC_TYPE_ID"]);
                        }
                    }
                    pat_id = string.IsNullOrEmpty(dt.Rows[0]["PAT_STATUS"].ToString()) ? 1 : pat_id = Convert.ToInt32(dt.Rows[0]["PAT_STATUS"]);
                    if (cboGender.SelectedIndex == 0)
                    {
                        lblLMP.Visible = false;
                        deLMP.Visible = false;
                        deLMP.BackColor = Color.FromArgb(227, 239, 255);
                    }
                    else
                    {
                        lblLMP.Visible = true;
                        deLMP.Visible = true;
                        deLMP.BackColor = Color.White;
                        if (string.IsNullOrEmpty(dt.Rows[0]["LMP_DT"].ToString()))
                            deLMP.Text = string.Empty;
                        else if (Convert.ToDateTime(dt.Rows[0]["LMP_DT"]) == DateTime.MinValue)
                            deLMP.Text = string.Empty;
                        else
                            deLMP.DateTime = Convert.ToDateTime(dt.Rows[0]["LMP_DT"]);
                    }
                    setLookupAllGrid();
                   // setGridLookupPat();
                    grdLvPatStatus.EditValue = dt.Rows[0]["PAT_STATUS"];
                    if (string.IsNullOrEmpty(dt.Rows[0]["INSURANCE_TYPE_ID"].ToString()) || dt.Rows[0]["INSURANCE_TYPE_ID"].ToString() == "0" || dt.Rows[0]["INSURANCE_TYPE_ID"].ToString() == "UNK")
                        grdLvInsurance.EditValue =11;//เงินสด
                    else
                        grdLvInsurance.EditValue = Convert.ToInt32(dt.Rows[0]["INSURANCE_TYPE_ID"]);
                    initGridHistory();
                    txtUserName.Text = env.FirstName + " " + env.LastName;

                    
                    timeEnd.EditValue = dte;
                }
                catch (Exception ex)
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    groupPatient.Enabled = false;
                    groupVisit.Enabled = false;
                    groupExam.Enabled = false;
                    groupTiming.Enabled = false;
                }
            }
            catch (Exception ecp) { }
        }

        #region Lookup data.
        private void btnLookupHN_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(hnLookup_ValueUpdated);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("REG_ID", "Code", false, true);
            lv.AddColumn("FULLNAME", "NAME", true, true);
            lv.Text = "HN Search";

            lv.Data = lvS.ScheduleNotParameter("HN").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }
        private void hnLookup_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string hn = retValue[0].ToString();
            patient = new Envision.BusinessLogic.Patient(hn, true);
            is_block = false;
            fillDemographic();
            txtOrderDept.ReadOnly = false;
            txtOrderDoc.ReadOnly = false;
            txtOrderDept.BackColor = txtHN.BackColor;
            txtOrderDoc.BackColor = txtHN.BackColor;
            btnSavePrint.Enabled = true;
            btnScan.Enabled = true;
            grdLvPatStatus.EditValue = pat_id;
            SendKeys.Send("{Tab}");

            //LoadInsurnaceType();
        }

        private void btnOrderDept_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(departmentLookup_ValueUpdated);
            lv.AddColumn("UNIT_UID", "Unit Code", true, true);
            lv.AddColumn("UNIT_ID", "ID", false, true);
            lv.AddColumn("UNIT_NAME", "Unit Name", true, true);
            lv.AddColumn("PHONE_NO", "Phone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.ScheduleNotParameter("OrderDept").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void departmentLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string s = txtOrderDept.Tag == null ? string.Empty : txtOrderDept.Tag.ToString();
            if (retValue[1] != s)
            {
                txtOrderDept.Tag = retValue[1];
                txtOrderDept.Text =retValue[0]+":"+retValue[2];
                //LoadInsurnaceType();
            }
        }

        private void btnOrderDoc_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(doctorLookup_ValueUpdated);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.AddColumn("EMP_UID","CODE",true,true);
            lv.AddColumn("RadioName", "RadioName", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.ScheduleNotParameter("OrderDoc").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void doctorLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            //doctor lookup
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtOrderDoc.Tag = retValue[0];
            txtOrderDoc.Text = retValue[1] + ":" + retValue[2];  //retValue[2];

        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();


            DataTable dtExam = RISBaseData.Ris_Exam();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(examLookup_ValueUpdated);
            lv.AddColumn("EXAM_ID", "ID", false, true);
            lv.AddColumn("EXAM_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_NAME", "Exam Name", true, true);
            lv.AddColumn("RATE", "Rate", false, true);
            lv.Text = "Exam Search";

            lv.Data = lvS.ScheduleHaveParameter("Exam", Convert.ToInt32(apt.ResourceId)).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }
        private void examLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            //txtExamUID.Tag = retValue[0];
            //txtExamUID.Text = retValue[1];
            //txtExamName.Text = retValue[2];
            //double rate = Convert.ToDouble(retValue[3].ToString());
            //txtRate.Text = rate.ToString("#,##0.00");
        }

        private void btnClinic_Click(object sender, EventArgs e)
        {
            #region Old
            //LookUpSelect lvS = new LookUpSelect();
            ////DataTable dtClinic = order.RIS_ClinicType();;
            //RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            //lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(clicnicLookup_ValueUpdated);
            //lv.AddColumn("CLINIC_TYPE_ID", "ID", false, true);
            //lv.AddColumn("CLINIC_TYPE_UID", "Code", false, true);
            //lv.AddColumn("CLINIC_TYPE_TEXT", "Clinic", true, true);
            //lv.Text = "Clinic Search";

            //lv.Data = lvS.ScheduleNotParameter("Clinic").Tables[0];//dtClinic;
            //lv.Size = new Size(600, 400);
            //lv.ShowBox(); 
            #endregion

            LookUpSelect lvS = new LookUpSelect();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(clicnicLookup_ValueUpdated);
            lv.AddColumn("SESSION_ID", "SESSION_ID", false, true);
            lv.AddColumn("SESSION_UID", "Code", true, true);
            lv.AddColumn("SESSION_NAME", "Session Name", true, true);
            lv.AddColumn("CLINIC_TYPE_ID", "CLINIC_TYPE_ID", false, true);
            lv.Text = "Session Search";

            lv.Data = lvS.SelectSession().Tables[0].Copy();
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void clicnicLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtSession.Tag = retValue[0];
            txtSession.Text = retValue[2];
            clinictype = Convert.ToInt32(retValue[3]);

            object obj = txtSession.Tag;
            if (obj == null) return;
            DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype);
            string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
            foreach (DataRow row in dttExam.Rows)
            {
                if (string.IsNullOrEmpty(row["EXAM_ID"].ToString())) continue;
                DataRow[] rs = dataExam.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL":
                        row["RATE"] = chkNonResident.Checked ? rs[0]["FOREIGN_SPCIAL_RATE"].ToString() : rs[0]["SPECIAL_RATE"].ToString();
                        break;
                    case "VIP":
                        row["RATE"] = chkNonResident.Checked ? rs[0]["FOREIGN_VIP_RATE"].ToString() : rs[0]["VIP_RATE"].ToString();
                        break;
                    default:
                        row["RATE"] = chkNonResident.Checked ? rs[0]["FOREIGN_RATE"].ToString() : rs[0]["RATE"].ToString();
                        break;
                }

            }
            dttExam.AcceptChanges();
            calTotal();
        }


        private void btnPrepation_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(btnPrepation_Clicks);
            lv.AddColumn("PREPARATION_ID", "ID", true, true);
            lv.AddColumn("PREPARATION_UID", "ID", false, true);
            lv.AddColumn("PREPARATION_DESC", "Prepation", true, true);
            lv.Text = "Preparation Search";

            lv.Data = lvS.ScheduleNotParameter("Prepation").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnPrepation_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            //txtPrepation.Tag = Convert.ToInt32(retValue[0]);
            //txtPrepation.Text = retValue[2];
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(projectLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";

            lv.Data = lvS.ScheduleHaveParameter("General", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
      
        private void btnRadiologist_Click(object sender, EventArgs e)
        {
            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(RadiologistLookup_ValueUpdated);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.AddColumn("EMP_UID", "Code", true, true);
            lv.AddColumn("RadioName", "Radiologist Name", true, true);
            lv.AddColumn("AUTH_LEVEL_ID", "LEVEL", false, true);
            lv.Text = "Radiologist Detail List";

            lv.Data = dttRadiologist;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void RadiologistLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            //txtRadiologist.Text = retValue[2];
            //txtRadiologist.Tag = retValue[0];
        }
        private void btnAppoint_Click(object sender, EventArgs e)
        {
            HIS_Patient hisPat = new HIS_Patient();
            DataSet dttP = hisPat.Get_appointment_detail(patient.Reg_UID);


            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(btnAppoint_Clicks);
            lv.AddColumn("hn", "HN", true, true);
            lv.AddColumn("appt_date", "Appoint Date", true, true);
            lv.AddColumn("appt_time", "Appoint Time", true, true);
            lv.AddColumn("appt_doc_code", "EMP_CODE", true, true);
            lv.AddColumn("appt_doc_name", "Doctor Name", true, true);
            lv.AddColumn("appt_doc_dept_code", "Unit UID", false, true);
            lv.AddColumn("appt_doc_dept_name", "Unit", true, true);
            lv.AddColumn("appt_doc_dept_tel", "Tel.", true, true);
            lv.Text = "Appointment  List";

            lv.Data = dttP.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnAppoint_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtOrderDept.Text = retValue[6];
            txtOrderDoc.Text = retValue[4];


            DataRow[] drDoc = dttDoctor.Select("EMP_UID='" + retValue[3].Trim() + "'");
            txtOrderDoc.Tag = drDoc[0]["EMP_ID"].ToString();
            DataRow[] drDept = dttDepartment.Select("UNIT_UID='" + retValue[5].Trim() + "'");
            txtOrderDept.Tag = drDept[0]["UNIT_ID"].ToString();
        }

        private void btnLabData_Click(object sender, EventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_lab_data(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        LookupData lv = new LookupData();
                        lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Lab_Clicks);
                        lv.Text = "Lab Detail List";

                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.PreviewFieldName = "report";
                        lv.SortFieldName = "lab_date";
                        lv.ShowDescription = true;
                        lv.ShowBox();
                    }
                }
            }
            catch { msg.ShowAlert("UID4022", new GBLEnvVariable().CurrentLanguageID); }
        }
        private void Lab_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
        }


        private void btnPatientAllergy_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("อ๊อดๆๆ ", "ยังไม่โค๊ด", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Get_Adr
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_Adr(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        LookupData lv = new LookupData();
                        lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Adr_Clicks);
                        lv.Text = "Alergy Detail List";
                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.ShowBox();
                    }
                    else
                        msg.ShowAlert("UID1134", env.CurrentLanguageID);
                }
            }
            catch { msg.ShowAlert("UID1134", env.CurrentLanguageID); }
        }
        private void Adr_Clicks(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {

        }

        private void btnStaffSchedule_Click(object sender, EventArgs e)
        {
            Envision.NET.Forms.ScheduleEmployee.frmSchedule staff = new Envision.NET.Forms.ScheduleEmployee.frmSchedule(env.UserID);
            staff.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            staff.ShowDialog();
        }

        private void btnNextAppoint_Click(object sender, EventArgs e)
        {
            if (txtHN.Text.Trim().Length == 0) return;

            frmNextAppointment frmNextAppt = new frmNextAppointment(txtHN.Text);
            frmNextAppt.ShowDialog();
        }
        #endregion

        #region KeyDown.
        private void txtHN_Validating(object sender, CancelEventArgs e)
        {
           
        }
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 47) e.Handled = true;
        }
        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtHN.Text.Trim().Length == 0)
            //    {
            //      txtHN.Text = apt.Subject;
            //            return;
            //    }
                
            //    if (txtHN.Text.Trim().Length == 0)
            //    {
            //        txtHN.Text = apt.Subject;
            //        return;
            //    }
            //    Patient  p = new Patient(txtHN.Text);
            //    if (!p.LinkDown)
            //    {
            //        if (p.HasHN)
            //        {
            //            #region Fill patient data to Control.
            //            patient = new Patient(txtHN.Text);
            //            is_block = false;
            //            fillDemographic();

            //            txtOrderDept.ReadOnly = false;
            //            txtOrderDoc.ReadOnly = false;
            //            txtOrderDept.BackColor = txtHN.BackColor;
            //            txtOrderDoc.BackColor = txtHN.BackColor;
            //            btnSavePrint.Enabled = true;
            //            btnScan.Enabled = true;
            //            grdLvPatStatus.EditValue = pat_id;
            //            SendKeys.Send("{Tab}"); 
            //            #endregion
            //        }
            //        else
            //        {
            //            #region Patient Not found.
            //            msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
            //            clearContextControl();
            //            enableDisableControl(); 
            //            #endregion
            //        }
            //    }
            //    patient = new Patient(txtHN.Text, true);

            //    if (patient.HasHN)
            //    {
            //        string s = msg.ShowAlert("UID1016", env.CurrentLanguageID);
            //        if (s == "1")
            //            waitConnectionHIS();
            //        else if (s == "2")
            //            createPatientDemographic();
            //        else
            //        {
            //            fillDemographic();
            //            txtHN.Text = HN;
            //            grdLvPatStatus.Focus();
            //        }
            //    }
            //    else
            //    {
            //        string s = msg.ShowAlert("UID1015", env.CurrentLanguageID);
            //        if (s == "1")
            //            waitConnectionHIS();
            //        else
            //            createPatientDemographic();
            //    }
            //}
        }
        private void txtFName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtMName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtLName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtFName_Eng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtMName_Eng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtLName_Eng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void dtDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void dtLastVisit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void dtNextVisit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtOrderDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtOrderDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtModality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtExamUID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtSession.Tag != null)
                {
                    DataTable dtClinic = RISBaseData.RIS_ClinicType();

                    //DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + txtClinicType.Tag);//order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + retValue[0]);
                    //DataRow[] drExam = Order.Ris_Exam().Select("") ("EXAM_UID = '" + txtExamUID.Text + "'");
                    //switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    //{
                    //    case "Normal":
                    //        double rate = Convert.ToDouble(drExam[0]["RATE"].ToString());
                    //        txtRate.Text = rate.ToString("#,##0.00");
                    //        break;
                    //    case "Special":
                    //        rate = Convert.ToDouble(drExam[0]["SPECIAL_RATE"].ToString());
                    //        txtRate.Text = rate.ToString("#,##0.00");
                    //        break;
                    //    case "VIP":
                    //        rate = Convert.ToDouble(drExam[0]["VIP_RATE"].ToString());
                    //        txtRate.Text = rate.ToString("#,##0.00");
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtExamName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtClinicType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void dtStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }

        }
        private void dtEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void cboTimeStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void cboTimeEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void timeStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void timeEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtAGE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void deLMP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void grdLvPatStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void grdLvInsurance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtModality_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtRadiologist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void speQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }

        private void txtExamUID_Validating(object sender, CancelEventArgs e)
        {
            //if (txtExamUID.Text.Trim().Length == 0)
            //{

            //    txtExamUID.Tag = null;
            //    txtExamName.Tag = null;

            //    txtExamUID.Text = string.Empty;
            //    txtExamName.Text = string.Empty;

            //    return;
            //}
            //DataRow[] dr = dttExamModality.Select("EXAM_UID='" + txtExamUID.Text.Trim() + "'");
            //if (dr.Length > 0)
            //{
            //    txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
            //    txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
            //    txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
            //    txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
            //}
            //else
            //{
            //    txtExamUID.Tag = null;
            //    txtExamUID.SelectAll();
            //    txtExamName.Tag = null;
            //    txtExamName.Text = string.Empty;
            //    e.Cancel = true;
            //}
        }
        private void txtExamName_Validating(object sender, CancelEventArgs e)
        {
            //if (txtExamName.Text.Trim().Length == 0)
            //{

            //    txtExamUID.Tag = null;
            //    txtExamName.Tag = null;

            //    txtExamUID.Text = string.Empty;
            //    txtExamName.Text = string.Empty;

            //    return;
            //}
            //DataRow[] dr = dttExamModality.Select("EXAM_NAME='" + txtExamName.Text.Trim() + "'");
            //if (dr.Length > 0)
            //{
            //    txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
            //    txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
            //    txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
            //    txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
            //}
            //else
            //{
            //    txtExamUID.Tag = null;
            //    txtExamUID.SelectAll();
            //    txtExamName.Tag = null;
            //    txtExamName.Text = string.Empty;
            //    e.Cancel = true;
            //}
        }

        private void txtOrderDept_Validating(object sender, CancelEventArgs e)
        {
            if (txtOrderDept.Text.Trim() == string.Empty)
            {
                txtOrderDept.Tag = null;
                txtOrderDept.Text = string.Empty;
            }
            else
            {
                bool flag = true;
                foreach (DataRow dr in dttDepartment.Rows)
                {
                    if (txtOrderDept.Text.Trim().ToUpper() == dr["UNIT_UID"].ToString().Trim().ToUpper() + ":" + dr["UNIT_NAME"].ToString().Trim().ToUpper())
                   // if (txtOrderDept.Text.Trim().ToUpper() == dr["UNIT_NAME"].ToString().Trim().ToUpper())
                    {
                        txtOrderDept.Tag = dr["UNIT_ID"].ToString();
                        txtOrderDept.Text = dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString();
                        //txtOrderDept.Text = dr["UNIT_NAME"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1012", env.CurrentLanguageID);
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;
                    setAutoComplete();
                    btnOrderDept.Focus();
                }
            }
        }
        private void txtOrderDoc_Validating(object sender, CancelEventArgs e)
        {
            if (txtOrderDoc.Text.Trim() != string.Empty)
            {
                bool flag = true;
                foreach (DataRow dr in dttDoctor.Rows)
                {
                    if (txtOrderDoc.Text.Trim().ToUpper() == dr["EMP_UID"].ToString() + ":" + dr["RadioName"].ToString().Trim().ToUpper())
                    {
                        txtOrderDoc.Tag = dr["EMP_ID"].ToString();
                        txtOrderDoc.Text = dr["EMP_UID"].ToString() + ":" + dr["RadioName"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID5000", env.CurrentLanguageID);
                    txtOrderDoc.Focus();
                    e.Cancel = true;//ไม่ยอมให้ไป
                }
                else
                {
                    e.Cancel = false;

                }
            }
            else
            {
                txtOrderDoc.Text = string.Empty;
                txtOrderDoc.Tag = null;
            }
        }

        private void txtOrderDept_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtOrderDoc_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }

        private void txtFName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFName_Eng.Text.Trim().Length == 0 && txtFName.Text.Trim().Length > 0)
                txtFName_Eng.Text = TransToEnglish.Trans(txtFName.Text);
            if (txtFName.Text.Trim().Length == 0)
                txtFName_Eng.Text = string.Empty;
        }
        private void txtLName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLName_Eng.Text.Trim().Length == 0 && txtLName.Text.Trim().Length > 0)
                txtLName_Eng.Text = TransToEnglish.Trans(txtLName.Text);
            if (txtLName.Text.Trim().Length == 0)
                txtLName_Eng.Text = string.Empty;
        }
        #endregion

        private void deleteEmptyRow()
        {
            for (int i = 0; i < dttExam.Rows.Count; i++)
                if (dttExam.Rows[i]["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    dttExam.Rows[i].Delete();
                    dttExam.AcceptChanges();
                    break;
                }
        }
        private bool checkHaveExamData()
        {
            bool flag = false;
            for (int i = 0; i < dttExam.Rows.Count; i++)
                if (dttExam.Rows[i]["EXAM_ID"].ToString().Trim() != string.Empty)
                {
                    flag = true;
                    break;
                }
            return flag;
        }
        private bool requireCheckFreeTime()
        {
            if (chkBlock.Checked == false)
            {

                DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
                DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
                int max_app = 0;
                int curr_app = 0;
                DateTime dtsTmp = DateTime.Today;
                DateTime dteTmp = DateTime.Today;
                DataRow[] drs;
                #region ตรวจสอบว่าช่วงเวลาที่เลือกตรงกับ Session หรือไม่
                if (txtSession.Tag != null)
                {
                    if (!string.IsNullOrEmpty(txtSession.Tag.ToString()))
                    {
                        drs = dttSession.Select("SESSION_ID=" + txtSession.Tag.ToString());
                        if (drs.Length > 0)
                        {
                            dtsTmp = Convert.ToDateTime(drs[0]["START_TIME"]);
                            dtsTmp = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, dtsTmp.Hour, dtsTmp.Minute, 0);
                            dteTmp = Convert.ToDateTime(drs[0]["END_TIME"]);
                            dteTmp = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, dteTmp.Hour, dteTmp.Minute, 0);
                            if (!((start >= dtsTmp && start <= dteTmp) && (end >= dtsTmp && end <= dteTmp)))
                            {
                                string s = msg.ShowAlert("UID1112", env.CurrentLanguageID);
                                if (s == "1")
                                    return false;
                            }
                            #region ตรวจสอบดูว่าช่วงเวลาที่เลือกเกิน Max appointment หรือยัง

                            ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
                            process.RIS_CLINICSESSION.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                            process.RIS_CLINICSESSION.ORG_ID = env.OrgID;
                            process.RIS_CLINICSESSION.WEEKDAYS = Convert.ToInt32(start.DayOfWeek);
                            process.Invoke();
                            DataTable dtmp = process.GetClinicSession();
                            drs = dtmp.Select("SESSION_ID=" + txtSession.Tag.ToString());
                            max_app = Convert.ToInt32(drs[0]["MAX_APP"].ToString());
                            DateTime dtStartApp = Convert.ToDateTime(drs[0]["START_TIME"].ToString());
                            DateTime dtEndApp = Convert.ToDateTime(drs[0]["END_TIME"].ToString());

                            DateTime dtSt = new DateTime(start.Year, start.Month, start.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                            DateTime dtEn = new DateTime(start.Year, start.Month, start.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);

                            ProcessGetRISSchedule procSC = new ProcessGetRISSchedule();
                            procSC.RIS_SCHEDULE.MODALITY_ID = process.RIS_CLINICSESSION.MODALITY_ID;
                            procSC.RIS_SCHEDULE.START_DATETIME = dtSt;
                            procSC.RIS_SCHEDULE.END_DATETIME = dtEn;
                            dtmp = new DataTable();
                            dtmp = procSC.GetSessionCount();
                            curr_app = 0;
                            if (curr_app > max_app)
                            {
                                if (msg.ShowAlert("UID1113", env.CurrentLanguageID) == "1")
                                    return false;
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        private bool isDuplicateAppointment(RIS_SCHEDULE dataSchedule)
        {
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            proc.RIS_SCHEDULE = dataSchedule;
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            DateTime edt = (DateTime)timeEnd.EditValue;
            edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute, edt.Second);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            edt = edt.Subtract(ts);
            proc.RIS_SCHEDULE.START_DATETIME = start;
            proc.RIS_SCHEDULE.END_DATETIME = edt;
            if (proc.CheckFreeTime())
                return false;
            else
                return true;
        }
        private bool requireCheck() {
            if (txtHN.Text == "BLOCK")
            {
                return false; ;
            }
            xtraTabControl1.SelectedTabPageIndex = 0;
            if (dxErrorProvider1.HasErrors) return false;
            if (txtInputReason.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                txtInputReason.Focus();
                return false;
            }
            #region require check.
            if (txtHN.Text.Trim().Length == 0)
            {
                txtHN.Focus();
                return false;
            }
            if (txtSession.Text.Trim().Length == 0)
            {
                txtSession.Focus();
                return false;
            }
            if (dtStart.DateTime == DateTime.MinValue)
            {
                dtStart.Focus();
                return false;
            }
            if (dtEnd.DateTime == DateTime.MinValue)
            {
                dtEnd.Focus();
                return false;
            }

            if (timeStart.ErrorText.Trim().Length > 0)
            {
                timeStart.Focus();
                return false;
            }
            if (timeEnd.ErrorText.Trim().Length > 0)
            {
                timeEnd.Focus();
                return false;
            }

            ProcessGetRISModality getModUnit
                    = new ProcessGetRISModality();
            getModUnit.RIS_MODALITY.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
            getModUnit.Invoke_forIntervention();

            string modality_type
                = getModUnit.Result.Tables[0].Rows[0]["TYPE_NAME"].ToString();

            if (modality_type != "Intervention")
            {
                #region Order department.
                if (txtOrderDept.Text.Trim().Length == 0)
                {
                    if (txtHN.Text != "BLOCK")
                    {
                        txtOrderDept.Focus();
                        return false;
                    }
                }
                #endregion

                #region Physician.
                if (txtOrderDoc.Text.Trim().Length == 0)
                {
                    if (txtHN.Text != "BLOCK")
                    {
                        txtOrderDoc.Focus();
                        return false;
                    }

                }
                #endregion
            }

            //#region Order department.
            //if (txtOrderDept.Text.Trim().Length == 0)
            //{
            //    if (txtHN.Text != "BLOCK")
            //    {
            //        txtOrderDept.Focus();
            //        return false;
            //    }
            //}
            //#endregion

            //#region Physician.
            //if (txtOrderDoc.Text.Trim().Length == 0)
            //{
            //    if (txtHN.Text != "BLOCK")
            //    {
            //        txtOrderDoc.Focus();
            //        return false;
            //    }

            //} 
            //#endregion
            
            if (chkBlock.Checked == false)
            {
                if (txtHN.Text != "BLOCK")
                {
                    if (checkHaveExamData() == false)
                    {
                        msg.ShowAlert("UID0046", env.CurrentLanguageID);
                        grdExam.Focus();
                        return false;
                    }
                }
            }
            else
            {
                if (txtAddTextInBlock.Text.Trim().Length == 0)
                {
                    msg.ShowAlert("UID1109", env.CurrentLanguageID);
                    txtAddTextInBlock.Focus();
                    return false;
                }
            }
            #endregion

            DateTime dtst = new DateTime
                (
                    dtStart.DateTime.Year
                    , dtStart.DateTime.Month
                    , dtStart.DateTime.Day
                    , timeStart.Time.Hour
                    , timeStart.Time.Minute
                    , timeStart.Time.Second
                );
            if (dtst < DateTime.Now.AddMinutes(-30))
            {
                msg.ShowAlert("UID4009", new GBLEnvVariable().CurrentLanguageID);
                return false;
            }

            if (chkBlock.Checked == false)
            {
                #region Check Duplicate Appointment.
                //RIS_SCHEDULE sc = new RIS_SCHEDULE();
                //sc.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                //sc.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                //sc.HN = txtHN.Text.Trim();
                //if (isDuplicateAppointment(sc))
                //{
                //    msg.ShowAlert("UID1111", env.CurrentLanguageID);
                //    return false;
                //}
                #endregion

                return requireCheckFreeTime();
            }

            return true;
        }
        private bool updateAppointmentData()
        {
            ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

            #region his_registration.
            int regID = 0;
            if (patient == null)
            {
                //Manual
                ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                pAddHIS.HIS_REGISTRATION.ADDR1 = string.Empty;
                pAddHIS.HIS_REGISTRATION.ADDR2 = string.Empty;
                pAddHIS.HIS_REGISTRATION.ADDR3 = string.Empty;
                pAddHIS.HIS_REGISTRATION.ADDR4 = string.Empty;
                pAddHIS.HIS_REGISTRATION.EM_CONTACT_PERSON = string.Empty;
                pAddHIS.HIS_REGISTRATION.EMAIL = string.Empty;
                pAddHIS.HIS_REGISTRATION.NATIONALITY = string.Empty;
                pAddHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                pAddHIS.HIS_REGISTRATION.DOB = DateTime.MinValue;
                pAddHIS.HIS_REGISTRATION.FNAME = txtFName.Text;
                pAddHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text;
                pAddHIS.HIS_REGISTRATION.GENDER = cboGender.SelectedIndex == 0 ? 'M' : 'F';
                pAddHIS.HIS_REGISTRATION.HN = txtHN.Text.Trim();
                pAddHIS.HIS_REGISTRATION.LNAME = txtLName.Text;
                pAddHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text;
                pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                pAddHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
                pAddHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
                pAddHIS.HIS_REGISTRATION.PHONE3 = patient.Phone3;//txtMobile.Text;
                pAddHIS.HIS_REGISTRATION.SSN = txtID.Text;
                pAddHIS.HIS_REGISTRATION.TITLE = string.Empty;
                pAddHIS.HIS_REGISTRATION.TITLE_ENG = string.Empty;
                pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = string.Empty;
                pAddHIS.Invoke();
                regID = pAddHIS.HIS_REGISTRATION.REG_ID;
                patient = new Patient();
            }
            else
            {
                ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                pAddHIS.HIS_REGISTRATION.ADDR1 = patient.Address1;
                pAddHIS.HIS_REGISTRATION.ADDR2 = patient.Address2;
                pAddHIS.HIS_REGISTRATION.ADDR3 = patient.Address3;
                pAddHIS.HIS_REGISTRATION.ADDR4 = patient.Address4;
                pAddHIS.HIS_REGISTRATION.EM_CONTACT_PERSON = patient.Em_Contact_Person;
                pAddHIS.HIS_REGISTRATION.EMAIL = patient.Email;
                pAddHIS.HIS_REGISTRATION.NATIONALITY = patient.Nationality;
                pAddHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                pAddHIS.HIS_REGISTRATION.DOB = patient.DateOfBirth;
                pAddHIS.HIS_REGISTRATION.FNAME = patient.FirstName;
                pAddHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text; //patient.FirstName_ENG;
                pAddHIS.HIS_REGISTRATION.GENDER = Convert.ToChar(patient.Gender);
                pAddHIS.HIS_REGISTRATION.HN = patient.Reg_UID;
                pAddHIS.HIS_REGISTRATION.LNAME = patient.LastName;
                pAddHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text;//patient.LastName_ENG;
                pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                pAddHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
                pAddHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
                pAddHIS.HIS_REGISTRATION.PHONE3 = patient.Phone3;
                pAddHIS.HIS_REGISTRATION.SSN = patient.SocialNumber;
                pAddHIS.HIS_REGISTRATION.TITLE = patient.Title;
                pAddHIS.HIS_REGISTRATION.TITLE_ENG = patient.Title_ENG;
                pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = patient.InsuranceID.ToString();
                pAddHIS.HIS_REGISTRATION.IS_FOREIGNER = chkNonResident.Checked ? "Y" : "N";
                pAddHIS.HIS_REGISTRATION.PATIENT_ID_DETAIL = patient.PATIENT_ID_DETAIL;
                pAddHIS.HIS_REGISTRATION.PATIENT_ID_LABEL = patient.PATIENT_ID_LABEL;
                pAddHIS.Invoke();
                regID = pAddHIS.HIS_REGISTRATION.REG_ID;
            }
            //else
            //{ 
            //    //Data from local
            //    ProcessAddHISRegistration pHIS = new ProcessAddHISRegistration(true);
            //    pHIS.HIS_REGISTRATION.ADDR1 = string.Empty;
            //    pHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
            //    pHIS.HIS_REGISTRATION.FNAME = txtFName.Text;
            //    pHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text;
            //    pHIS.HIS_REGISTRATION.GENDER = cboGender.SelectedIndex == 0 ? Convert.ToChar("M") : Convert.ToChar("F");
            //    pHIS.HIS_REGISTRATION.HN = txtHN.Text;
            //    pHIS.HIS_REGISTRATION.LNAME = txtLName.Text;
            //    pHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text;
            //    pHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
            //    pHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
            //    pHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
            //    pHIS.HIS_REGISTRATION.SSN = txtID.Text;
            //    pHIS.HIS_REGISTRATION.TITLE = string.Empty;
            //    pHIS.HIS_REGISTRATION.TITLE_ENG = string.Empty;
            //    pHIS.HIS_REGISTRATION.LINK_DOWN = 'Y';
            //    pHIS.HIS_REGISTRATION.INSURANCE_TYPE = string.Empty;
            //    pHIS.Invoke();
            //    regID = pHIS.HIS_REGISTRATION.REG_ID;
            //    patient.Reg_UID = txtHN.Text;
            //}

            #endregion

            #region update RIS_SCHEDULE.
            DateTime dtApp = new DateTime(start.Year, start.Month, start.Day);
            process.RIS_SCHEDULE.BLOCK_REASON = null;
            process.RIS_SCHEDULE.CLINICAL_INSTRUCTION = string.Empty;
            process.RIS_SCHEDULE.COMMENTS = string.Empty;
            process.RIS_SCHEDULE.CONFIRMED_BY = null;
            process.RIS_SCHEDULE.CREATED_BY = null;
            process.RIS_SCHEDULE.DIAGNOSIS = string.Empty;
            process.RIS_SCHEDULE.EVENTTYPE = null;
            process.RIS_SCHEDULE.HN = txtHN.Text.Trim();
            process.RIS_SCHEDULE.ICD_ID = null;
            process.RIS_SCHEDULE.IS_BLOCKED = 'N';
            process.RIS_SCHEDULE.LABEL = null;
            process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
            if (!string.IsNullOrEmpty(deLMP.Text))
                process.RIS_SCHEDULE.LMP_DT = deLMP.DateTime;
            process.RIS_SCHEDULE.LOCATION = string.Empty;
            process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId);
            process.RIS_SCHEDULE.ORG_ID = env.OrgID;
            process.RIS_SCHEDULE.PAT_STATUS = pat_id;
            process.RIS_SCHEDULE.REASON = txtInputReason.Text.Trim();
            process.RIS_SCHEDULE.REASON_CHANGE = txtAddTextInBlock.Text.Trim();
            process.RIS_SCHEDULE.REF_DOC = txtOrderDoc.Tag == null ? 0 : Convert.ToInt32(txtOrderDoc.Tag.ToString());
            process.RIS_SCHEDULE.REF_DOC_INSTRUCTION = string.Empty;
            process.RIS_SCHEDULE.REF_UNIT = txtOrderDept.Tag == null ? 0 : Convert.ToInt32(txtOrderDept.Tag.ToString());
            process.RIS_SCHEDULE.SCHEDULE_DT = dtApp;
            process.RIS_SCHEDULE.SCHEDULE_ID = schedule_id;
            process.RIS_SCHEDULE.REG_ID = regID;
            process.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
            process.RIS_SCHEDULE.SESSION_ID = txtSession.Tag == null ? 0 : Convert.ToInt32(txtSession.Tag.ToString());
            process.RIS_SCHEDULE.SCHEDULE_DATA = generateScheduleDataText();
            process.RIS_SCHEDULE.START_DATETIME = start;
            DateTime edt = (DateTime)timeEnd.EditValue;
            edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute, 0);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            edt = edt.Subtract(ts);
            process.RIS_SCHEDULE.END_DATETIME = edt;
            process.RIS_SCHEDULE.INSURANCE_TYPE_ID = Convert.ToInt32(grdLvInsurance.EditValue);
            if (controller.EditedAppointmentCopy.RecurrenceInfo != null)
            {
                RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(controller.EditedAppointmentCopy.RecurrenceInfo, DateSavingType.LocalTime);
                process.RIS_SCHEDULE.RECURRENCEINFO = helper.ToXml();
            }
            //process.RIS_SCHEDULE.ALLDAY = chkAllDay.Checked;
            process.RIS_SCHEDULE.LABEL = controller.LabelId;
            process.RIS_SCHEDULE.STATUS = Convert.ToInt32(controller.EditedAppointmentCopy.StatusId.ToString());
            process.RIS_SCHEDULE.EVENTTYPE = Convert.ToInt32(controller.EditedAppointmentCopy.Type);

            FinancialBilling fnBill = new FinancialBilling();
            String strEnc_id = "";
            String strEnc_type = "";
            String strEnc_clinic = "";

            if (txtOrderDept.Tag == null || txtOrderDept.Tag.ToString().Trim().Length == 0)
            {
                process.RIS_SCHEDULE.ENC_ID = 0;
                process.RIS_SCHEDULE.ENC_TYPE = "";
                process.RIS_SCHEDULE.ENC_CLINIC = "";
            }
            else
            {
                DataRow[] rowsUnit = dttDepartment.Select("UNIT_ID=" + txtOrderDept.Tag.ToString());
                string REF_UNIT = rowsUnit[0]["UNIT_UID"].ToString();
                fnBill.LoadEncounter(txtHN.Text, REF_UNIT, ref strEnc_id, ref strEnc_type);
                process.RIS_SCHEDULE.ENC_ID = string.IsNullOrEmpty(strEnc_id.Trim()) ? 0 : Convert.ToInt32(strEnc_id);
                process.RIS_SCHEDULE.ENC_TYPE = strEnc_type;
                process.RIS_SCHEDULE.ENC_CLINIC = strEnc_clinic;
            }

            process.Update();
            if (process.RIS_SCHEDULE.SCHEDULE_ID > 0)
            {
                #region Delete Exam.
                foreach (int del in delExamItem)
                {
                    ProcessDeleteRISScheduleDtl procDtl = new ProcessDeleteRISScheduleDtl();
                    procDtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                    procDtl.RIS_SCHEDULEDTL.EXAM_ID = del;
                    procDtl.RIS_SCHEDULEDTL.REASON = txtInputReason.Text.Trim();
                    procDtl.RIS_SCHEDULEDTL.LAST_MODIFIED_BY = env.UserID;
                    procDtl.Invoke();
                }
                #endregion

                #region Update RIS_SCHEDULEDTL
                DataTable desExam = RISBaseData.Ris_Exam();
                foreach (DataRow dr in dttExam.Rows)
                {
                    if (string.IsNullOrEmpty(dr["SCHEDULE_ID"].ToString()))
                    {
                        #region New Exam.
                        ProcessAddRISScheduleDtl procDtl = new ProcessAddRISScheduleDtl();
                        procDtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = Convert.ToInt32(dr["AVG_REQ_MIN"].ToString());
                        procDtl.RIS_SCHEDULEDTL.BPVIEW_ID = string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["BPVIEW_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.CREATED_BY = env.UserID;
                        procDtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.GEN_DTL_ID = string.IsNullOrEmpty(dr["GEN_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["GEN_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                        procDtl.RIS_SCHEDULEDTL.PREPARATION_ID = string.IsNullOrEmpty(dr["PREPATION_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["PREPATION_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.QTY = Convert.ToInt32(dr["QTY"].ToString());
                        procDtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(dr["EMP_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["EMP_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(dr["RATE"].ToString());
                        procDtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                        procDtl.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = string.IsNullOrEmpty(dr["SCHEDULE_PRIORITY"].ToString().Trim()) ? "R" : dr["SCHEDULE_PRIORITY"].ToString().Trim();
                        //rowsUnit = desExam.Select("EXAM_ID=" + procDtl.RIS_SCHEDULEDTL.EXAM_ID);
                        //int UNIT_ID = 0;
                        //if (rowsUnit.Length > 0)
                        //    UNIT_ID = Convert.ToInt32(rowsUnit[0]["UNIT_ID"].ToString());
                        //procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = PatientDestinationInfo.GetDestination(txtHN.Text.Trim(), UNIT_ID, clinictype, REF_UNIT);

                        DataRow[] drUnitExam = desExam.Select("EXAM_ID=" + procDtl.RIS_SCHEDULEDTL.EXAM_ID);
                        int UNIT_ID = 0;
                        if (drUnitExam.Length > 0)
                            UNIT_ID = Convert.ToInt32(drUnitExam[0]["UNIT_ID"].ToString());

                        if (txtOrderDept.Tag == null || txtOrderDept.Tag.ToString().Trim().Length == 0)
                        {
                            procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = PatientDestinationInfo.GetDestination(txtHN.Text.Trim(), UNIT_ID, clinictype, "");
                        }
                        else
                        {
                            DataRow[] rowsUnit = dttDepartment.Select("UNIT_ID=" + txtOrderDept.Tag.ToString());
                            string REF_UNIT = rowsUnit[0]["UNIT_UID"].ToString();
                            procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = PatientDestinationInfo.GetDestination(txtHN.Text.Trim(), UNIT_ID, clinictype, REF_UNIT);
                        }

                        procDtl.Invoke();
                        #endregion
                    }
                    else
                    {
                        #region Update Exam.
                        ProcessUpdateRISScheduledtl procUp = new ProcessUpdateRISScheduledtl();
                        procUp.RIS_SCHEDULEDTL.AVG_REQ_MIN = Convert.ToInt32(dr["AVG_REQ_MIN"].ToString());
                        procUp.RIS_SCHEDULEDTL.BPVIEW_ID = string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["BPVIEW_ID"].ToString());
                        procUp.RIS_SCHEDULEDTL.LAST_MODIFIED_BY = env.UserID;
                        procUp.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                        procUp.RIS_SCHEDULEDTL.GEN_DTL_ID = string.IsNullOrEmpty(dr["GEN_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["GEN_ID"].ToString());
                        procUp.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                        procUp.RIS_SCHEDULEDTL.PREPARATION_ID = string.IsNullOrEmpty(dr["PREPATION_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["PREPATION_ID"].ToString());
                        procUp.RIS_SCHEDULEDTL.QTY = Convert.ToInt32(dr["QTY"].ToString());
                        procUp.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(dr["EMP_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["EMP_ID"].ToString());
                        procUp.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(dr["RATE"].ToString());
                        procUp.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                        procUp.RIS_SCHEDULEDTL.OLD_EXAM_ID = Convert.ToInt32(dr["OLD_EXAM_ID"].ToString());
                        procUp.RIS_SCHEDULEDTL.REASON = txtInputReason.Text.Trim();
                        procUp.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = string.IsNullOrEmpty(dr["SCHEDULE_PRIORITY"].ToString().Trim()) ? "R" : dr["SCHEDULE_PRIORITY"].ToString().Trim();
                        procUp.Invoke();
                        #endregion
                    }

                }
                #endregion

                #region Update AppointmentData.
                SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                #endregion

                #region Update WatingList.
                if (SCHEDULE_STATUS == "W")
                {
                    ProcessUpdateRISSchedule procWL = new ProcessUpdateRISSchedule();
                    procWL.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
                    procWL.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    procWL.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                    procWL.RIS_SCHEDULE.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                    procWL.UpdateWatingList();
                }
                #endregion

                #region Update Request Result Datetime
                if (chkRequestResult.Checked)
                {
                    ProcessUpdateRISSchedule updateRequestResult = new ProcessUpdateRISSchedule();
                    updateRequestResult.RIS_SCHEDULE.SCHEDULE_ID = SCHEDULE_ID;
                    updateRequestResult.RIS_SCHEDULE.REQUEST_RESULT_DATETIME = requestResult;
                    updateRequestResult.UpdateRequestResult();
                }
                #endregion

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (process.RIS_SCHEDULE.SCHEDULE_ID == -2)
            {
                string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);//Check double Exam
                dtStart.Focus();
                return false;
            }
            else
            {
                string s = msg.ShowAlert("UID1101", env.CurrentLanguageID);//Check block
                dtStart.Focus();
                return false;
            }
            #endregion

            #region Scan Image.
            ScanImage save = null;

            if (dtImageScan == null)
                save = new ScanImage(patient.Reg_UID, process.RIS_SCHEDULE.SCHEDULE_ID, "Schedule");
            else
                save = new ScanImage(patient.Reg_UID, process.RIS_SCHEDULE.SCHEDULE_ID, dtImageScan, "Schedule");
            #endregion

            #region Update Exam Flag
            if (Utilities.IsHaveData(dttExamFlag))
            {
                foreach (DataRow rowExamFlag in dttExamFlag.Rows)
                {
                    if (Convert.ToInt32(rowExamFlag["FLAG_ID"].ToString()) == 0)
                    {
                        ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                        addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = 0;
                        addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = 0;
                        addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                        addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                        addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                        addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                        addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                        addExamFlag.Invoke();
                    }
                    else
                    {
                        ProcessUpdateRISOrderexamflag updateExamFlag = new ProcessUpdateRISOrderexamflag();
                        updateExamFlag.RIS_ORDEREXAMFLAG.FLAG_ID = Convert.ToInt32(rowExamFlag["FLAG_ID"]);
                        updateExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = string.IsNullOrEmpty(rowExamFlag["ORDER_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["ORDER_ID"]);
                        updateExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = string.IsNullOrEmpty(rowExamFlag["XRAYREQ_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["XRAYREQ_ID"]);
                        updateExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = string.IsNullOrEmpty(rowExamFlag["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowExamFlag["SCHEDULE_ID"]);
                        updateExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowExamFlag["EXAM_ID"]);
                        updateExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowExamFlag["EXAMFLAG_ID"]);
                        updateExamFlag.RIS_ORDEREXAMFLAG.REASON = rowExamFlag["REASON"].ToString();
                        updateExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                        updateExamFlag.Invoke();
                    }
                }
            }
            #endregion

            #region insert schedule logs
            ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
            schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
            schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
            schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'U';
            schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Update Envision";
            schLogs.Invoke();
            #endregion

            new ScanImages().Invoke(patient.Reg_UID, schedule_id, 0, dv_scan_image);

            #region cnmi
            //try
            //{
            //    updateAppointmentDataToCNMI();
            //}
            //catch(Exception ex) { }
            #endregion

            return true;
        }
        private void updateAppointmentDataToCNMI()
        {
            ProcessGetRISModality processModality = new ProcessGetRISModality();
            processModality.Invoke();
            DataTable dttModaltiy = processModality.Result.Tables[0].Copy();
            int modalityID = Convert.ToInt32(apt.ResourceId);
            DataRow[] drModaltiy = dttModaltiy.Select("MODALITY_ID =" + modalityID);

            if (drModaltiy.Length == 0) return;

            if (drModaltiy[0]["LABEL"].ToString().ToLower() == "cnmi" || drModaltiy[0]["PAT_DEST_ID"].ToString().ToLower() == "10")
            {
                ProcessGetRISModality processModalityCNMI = new ProcessGetRISModality();
                processModalityCNMI.InvokeCNMI();
                DataTable dttModaltiyCNMI = processModalityCNMI.Result.Tables[0].Copy();
                DataRow[] drModaltiyCNMI = dttModaltiyCNMI.Select("TYPE_NAME = '" + drModaltiy[0]["TYPE_NAME"].ToString() + "'");

                if (drModaltiyCNMI.Length == 0) return;

                #region his_registration.
                int regID = 0;
                if (patient == null)
                {
                    ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                    pAddHIS.HIS_REGISTRATION.ADDR1 = string.Empty;
                    pAddHIS.HIS_REGISTRATION.ADDR2 = string.Empty;
                    pAddHIS.HIS_REGISTRATION.ADDR3 = string.Empty;
                    pAddHIS.HIS_REGISTRATION.ADDR4 = string.Empty;
                    pAddHIS.HIS_REGISTRATION.EM_CONTACT_PERSON = string.Empty;
                    pAddHIS.HIS_REGISTRATION.EMAIL = string.Empty;
                    pAddHIS.HIS_REGISTRATION.NATIONALITY = string.Empty;
                    pAddHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                    pAddHIS.HIS_REGISTRATION.DOB = DateTime.MinValue;
                    pAddHIS.HIS_REGISTRATION.FNAME = txtFName.Text;
                    pAddHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text;
                    pAddHIS.HIS_REGISTRATION.GENDER = cboGender.SelectedIndex == 0 ? 'M' : 'F';
                    pAddHIS.HIS_REGISTRATION.HN = txtHN.Text.Trim();
                    pAddHIS.HIS_REGISTRATION.LNAME = txtLName.Text;
                    pAddHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text;
                    pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                    pAddHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
                    pAddHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
                    pAddHIS.HIS_REGISTRATION.PHONE3 = patient.Phone3;//txtMobile.Text;
                    pAddHIS.HIS_REGISTRATION.SSN = txtID.Text;
                    pAddHIS.HIS_REGISTRATION.TITLE = string.Empty;
                    pAddHIS.HIS_REGISTRATION.TITLE_ENG = string.Empty;
                    pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = string.Empty;
                    pAddHIS.InvokeCNMI();
                    regID = pAddHIS.HIS_REGISTRATION.REG_ID;
                    patient = new Patient();
                }
                else
                {
                    ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                    pAddHIS.HIS_REGISTRATION.ADDR1 = patient.Address1;
                    pAddHIS.HIS_REGISTRATION.ADDR2 = patient.Address2;
                    pAddHIS.HIS_REGISTRATION.ADDR3 = patient.Address3;
                    pAddHIS.HIS_REGISTRATION.ADDR4 = patient.Address4;
                    pAddHIS.HIS_REGISTRATION.EM_CONTACT_PERSON = patient.Em_Contact_Person;
                    pAddHIS.HIS_REGISTRATION.EMAIL = patient.Email;
                    pAddHIS.HIS_REGISTRATION.NATIONALITY = patient.Nationality;
                    pAddHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                    pAddHIS.HIS_REGISTRATION.DOB = patient.DateOfBirth;
                    pAddHIS.HIS_REGISTRATION.FNAME = patient.FirstName;
                    pAddHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text; //patient.FirstName_ENG;
                    pAddHIS.HIS_REGISTRATION.GENDER = Convert.ToChar(patient.Gender);
                    pAddHIS.HIS_REGISTRATION.HN = patient.Reg_UID;
                    pAddHIS.HIS_REGISTRATION.LNAME = patient.LastName;
                    pAddHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text;//patient.LastName_ENG;
                    pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                    pAddHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
                    pAddHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
                    pAddHIS.HIS_REGISTRATION.PHONE3 = patient.Phone3;
                    pAddHIS.HIS_REGISTRATION.SSN = patient.SocialNumber;
                    pAddHIS.HIS_REGISTRATION.TITLE = patient.Title;
                    pAddHIS.HIS_REGISTRATION.TITLE_ENG = patient.Title_ENG;
                    pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    pAddHIS.HIS_REGISTRATION.IS_FOREIGNER = chkNonResident.Checked ? "Y" : "N";
                    pAddHIS.HIS_REGISTRATION.PATIENT_ID_DETAIL = patient.PATIENT_ID_DETAIL;
                    pAddHIS.HIS_REGISTRATION.PATIENT_ID_LABEL = patient.PATIENT_ID_LABEL;
                    pAddHIS.HIS_REGISTRATION.IS_JOHNDOE = 'Y';
                    pAddHIS.InvokeCNMI();
                    regID = pAddHIS.HIS_REGISTRATION.REG_ID;
                }
                #endregion

                #region insert normal.
                ProcessAddRISSchedule process = new ProcessAddRISSchedule();
                DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
                DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
                DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

                DataTable dttSessionCNMI = new DataTable();
                ProcessGetRISClinicsession proc = new ProcessGetRISClinicsession();
                proc.InvokeCNMI();
                dttSessionCNMI = proc.Result.Tables[0];

                string strSession = txtSession.Text.Replace("CNMI ", "");
                DataRow[] drSessionCNMI = dttSessionCNMI.Select("SESSION_NAME = '" + strSession +"'");
                
                //RIS_SCHEDULE data = new RIS_SCHEDULE();
                //data.SCHEDULE_ID = 0;
                //data.MODALITY_ID = modalityID;
                //data.START_DATETIME = start;// apt.Start;
                //data.END_DATETIME = end;// apt.End;
                //data.HN = txtHN.Text.Trim();

                DateTime dtApp = new DateTime(start.Year, start.Month, start.Day);
                process.RIS_SCHEDULE.SCHEDULE_ID = 0;
                process.RIS_SCHEDULE.REG_ID = regID;
                process.RIS_SCHEDULE.SCHEDULE_DT = start;
                process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(drModaltiyCNMI[0]["MODALITY_ID"].ToString()); //
                process.RIS_SCHEDULE.SCHEDULE_DATA = generateScheduleDataText();
                process.RIS_SCHEDULE.BLOCK_REASON = null;
                process.RIS_SCHEDULE.LABEL = null;
                process.RIS_SCHEDULE.LOCATION = string.Empty;
                process.RIS_SCHEDULE.EVENTTYPE = null;
                process.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(drSessionCNMI[0]["SESSION_ID"].ToString());
                process.RIS_SCHEDULE.START_DATETIME = start;
                DateTime edt = (DateTime)timeEnd.EditValue;
                edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute, edt.Second);
                TimeSpan ts = new TimeSpan(0, 0, 0, 1);
                edt = edt.Subtract(ts);
                process.RIS_SCHEDULE.END_DATETIME = edt;
                //if (txtOrderDept.Tag != null)
                //    if (!string.IsNullOrEmpty(txtOrderDept.Tag.ToString()))
                //        process.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(txtOrderDept.Tag.ToString());
                //if (txtOrderDoc.Tag != null)
                //    if (!string.IsNullOrEmpty(txtOrderDoc.Tag.ToString()))
                //        process.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(txtOrderDoc.Tag.ToString());
             
                process.RIS_SCHEDULE.PAT_STATUS = 1;    //
                process.RIS_SCHEDULE.LMP_DT = deLMP.DateTime;
                process.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
                process.RIS_SCHEDULE.CREATED_BY = 1;    //
                process.RIS_SCHEDULE.IS_BLOCKED = 'N';
                process.RIS_SCHEDULE.ORG_ID = env.OrgID;
                process.RIS_SCHEDULE.INSURANCE_TYPE_ID = Convert.ToInt32(grdLvInsurance.EditValue);

                int _label = 0;
                int _status = 0;
                int _eventype = 0;
                if (controller != null)
                {
                    if (controller.EditedAppointmentCopy.RecurrenceInfo != null)
                    {
                        RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(controller.EditedAppointmentCopy.RecurrenceInfo, DateSavingType.LocalTime);
                        process.RIS_SCHEDULE.RECURRENCEINFO = helper.ToXml();
                    }
                    _label = controller.LabelId;
                    _status = Convert.ToInt32(controller.EditedAppointmentCopy.StatusId.ToString());
                    _eventype = Convert.ToInt32(controller.EditedAppointmentCopy.Type);
                }
                process.RIS_SCHEDULE.ALLDAY = false; //
                process.RIS_SCHEDULE.LABEL = _label;
                process.RIS_SCHEDULE.STATUS = _status;
                process.RIS_SCHEDULE.EVENTTYPE = _eventype;
                process.RIS_SCHEDULE.REASON = "";   //

                FinancialBilling fnBill = new FinancialBilling();
                String strEnc_id = "";
                String strEnc_type = "";
                String strEnc_clinic = "";

                //if (txtOrderDept.Tag == null || txtOrderDept.Tag.ToString().Trim().Length == 0)
                //{
                    process.RIS_SCHEDULE.ENC_ID = 0;
                    process.RIS_SCHEDULE.ENC_TYPE = "";
                    process.RIS_SCHEDULE.ENC_CLINIC = "";
                //}
                //else
                //{
                //    DataTable dttDepartmentCNMI = RISBaseData.His_DepartmentCNMI();
                //    DataRow[] rowsUnit = dttDepartmentCNMI.Select("UNIT_ID=" + txtOrderDept.Tag.ToString());
                //    string REF_UNIT = rowsUnit[0]["UNIT_UID"].ToString();
                //    fnBill.LoadEncounter(txtHN.Text, REF_UNIT, ref strEnc_id, ref strEnc_type);
                //    process.RIS_SCHEDULE.ENC_ID = string.IsNullOrEmpty(strEnc_id.Trim()) ? 0 : Convert.ToInt32(strEnc_id);
                //    process.RIS_SCHEDULE.ENC_TYPE = strEnc_type;
                //    process.RIS_SCHEDULE.ENC_CLINIC = strEnc_clinic;
                //}

                process.InvokeCNMI();

                if (process.RIS_SCHEDULE.SCHEDULE_ID > 0)
                {
                    process.RIS_SCHEDULE.REG_ID = regID;
                    int scheduleID = process.RIS_SCHEDULE.SCHEDULE_ID;

                    #region Insert schedule-details.
                    DataTable desExamCNMI = RISBaseData.Ris_ExamCNMI();
                    DataTable desExam = RISBaseData.Ris_Exam();
                    ProcessAddRISScheduleDtl procDtl = new ProcessAddRISScheduleDtl();
                    foreach (DataRow row in dttExam.Rows)
                    {
                        DataRow[] drSelExam = desExam.Select("EXAM_ID=" + Convert.ToInt32(row["EXAM_ID"].ToString()) + "");
                        DataRow[] drSelExamCnmi = desExamCNMI.Select("EXAM_UID='" + drSelExam[0]["EXAM_UID"].ToString() + "'");

                        procDtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = Convert.ToInt32(row["AVG_REQ_MIN"].ToString());
                        procDtl.RIS_SCHEDULEDTL.BPVIEW_ID = string.IsNullOrEmpty(row["BPVIEW_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(row["BPVIEW_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.CREATED_BY = 1;
                        procDtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drSelExamCnmi[0]["EXAM_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.GEN_DTL_ID = string.IsNullOrEmpty(row["GEN_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(row["GEN_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                        procDtl.RIS_SCHEDULEDTL.PREPARATION_ID = string.IsNullOrEmpty(row["PREPATION_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(row["PREPATION_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.QTY = Convert.ToInt32(row["QTY"].ToString());
                        procDtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(row["EMP_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(row["EMP_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(row["RATE"].ToString());
                        procDtl.RIS_SCHEDULEDTL.SCHEDULE_ID = scheduleID;
                        procDtl.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = string.IsNullOrEmpty(row["SCHEDULE_PRIORITY"].ToString().Trim()) ? "R" : row["SCHEDULE_PRIORITY"].ToString().Trim();
                        DataRow[] drUnitExam = desExam.Select("EXAM_ID=" + procDtl.RIS_SCHEDULEDTL.EXAM_ID);
                        int UNIT_ID = 0;
                        if (drUnitExam.Length > 0)
                            UNIT_ID = Convert.ToInt32(drUnitExam[0]["UNIT_ID"].ToString());
                        procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = 1;
                        //if (txtOrderDept.Tag == null || txtOrderDept.Tag.ToString().Trim().Length == 0)
                        //{
                        //    procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = PatientDestinationInfo.GetDestination(txtHN.Text.Trim(), UNIT_ID, clinictype, "");
                            
                        //}
                        //else
                        //{
                        //    DataRow[] rowsUnit = dttDepartment.Select("UNIT_ID=" + txtOrderDept.Tag.ToString());
                        //    string REF_UNIT = rowsUnit[0]["UNIT_UID"].ToString();
                        //    procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = PatientDestinationInfo.GetDestination(txtHN.Text.Trim(), UNIT_ID, clinictype, REF_UNIT);
                        //    //procDtl.RIS_SCHEDULEDTL.PAT_DEST_ID = 1;
                        //}

                        procDtl.InvokeCNMI();
                    }
                    #endregion
                    #region Update Request Result Datetime
                    if (chkRequestResult.Checked)
                    {
                        ProcessUpdateRISSchedule updateRequestResult = new ProcessUpdateRISSchedule();
                        updateRequestResult.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
                        updateRequestResult.RIS_SCHEDULE.REQUEST_RESULT_DATETIME = requestResult;
                        updateRequestResult.UpdateRequestResultCNMI();
                    }
                    #endregion
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                //else
                //{
                //    if (process.RIS_SCHEDULE.SCHEDULE_ID == -2)
                //    {
                //        string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);
                //        dtStart.Focus();
                //        return false;
                //    }
                //    else
                //    {
                //        string s = msg.ShowAlert("UID1101", env.CurrentLanguageID);
                //        dtStart.Focus();
                //        return false;
                //    }

                //}
                #endregion

                if (process.RIS_SCHEDULE.SCHEDULE_ID > 0)
                {
                    //process.RIS_SCHEDULE.HN = txtHN.Text.Trim();
                    //process.RIS_SCHEDULE.SESSION_ID = 0;
                    //process.RIS_SCHEDULE.REG_ID = 0;
                    //process.RIS_SCHEDULE.REF_DOC = 0;
                    //process.RIS_SCHEDULE.REF_UNIT = 0;
                    //process.RIS_SCHEDULE.PAT_STATUS = 0;
                    //process.RIS_SCHEDULE.LMP_DT = DateTime.Now;
                    //process.RIS_SCHEDULE.INSURANCE_TYPE_ID = 0;
                    //process.RIS_SCHEDULE.IS_BLOCKED = 'Y';

                    #region insert schedule logs
                    ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
                    schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                    schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = 1;
                    schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'C';
                    schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Create EnvisionRama";
                    schLogs.InvokeCNMI();
                    #endregion

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                //else
                //{
                //    string s = msg.ShowAlert("UID1102", env.CurrentLanguageID);
                //    dtStart.Focus();
                //    //return false;
                //}
                this.Close();
            }
        }
        private bool updateBlockData() {
            ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            end = end.Subtract(ts);
            string schedule_data = "";
            if (chkBlock.Checked)
                schedule_data = "BLOCK - " + txtAddTextInBlock.Text;
            else if (chkComments.Checked)
                schedule_data = "COMMENTS - " + txtAddTextInBlock.Text;

            process.RIS_SCHEDULE.START_DATETIME = start;
            process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
            process.RIS_SCHEDULE.END_DATETIME = end;
            process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
            process.RIS_SCHEDULE.ORG_ID = env.OrgID;
            process.RIS_SCHEDULE.REASON = txtInputReason.Text.Trim();
            process.RIS_SCHEDULE.REASON_CHANGE = txtAddTextInBlock.Text.Trim();
            process.RIS_SCHEDULE.SCHEDULE_DATA = schedule_data;
            process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(apt.Location);
            if (chkBlock.Checked)
                process.UpdateBlock();
            if (chkComments.Checked)
                process.UpdateComments();

            if (process.RIS_SCHEDULE.SCHEDULE_ID > 0)
            {
                #region Update AppointmentData.
                //for (int i = 0; i < dttAppointment.Rows.Count; i++)
                //{
                //    if (dttAppointment.Rows[i]["SCHEDULE_ID"].ToString() == schedule_id.ToString())
                //    {
                //        DataRow nw = dttAppointment.Rows[i];
                //        nw["SCHEDULE_ID"] = process.RIS_SCHEDULE.SCHEDULE_ID;
                //        nw["MODALITY_ID"] = process.RIS_SCHEDULE.MODALITY_ID;
                //        nw["SCHEDULE_DATA"] = process.RIS_SCHEDULE.SCHEDULE_DATA;
                //        nw["START_DATETIME"] = process.RIS_SCHEDULE.START_DATETIME;
                //        nw["END_DATETIME"] = process.RIS_SCHEDULE.END_DATETIME;
                //        nw["IS_BLOCKED"] = 'Y';
                //        nw["CommandType"] = "N";
                //        dttAppointment.AcceptChanges();
                //        break;
                //    }
                //}
                #endregion
                SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string s = msg.ShowAlert("UID1102", env.CurrentLanguageID);
                dtStart.Focus();
                return false;
            }
            return true;
        }
        private string generateScheduleDataText()
        {
            string result = "";
            string patient_id_label = string.IsNullOrEmpty(patient.PATIENT_ID_LABEL) ? "" : "[" + patient.PATIENT_ID_LABEL + "]";
            if (dttExam.Rows.Count == 1)
            {
                result = "HN : " + patient.Reg_UID + patient_id_label + " " + patient.Title + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                DataRow[] rs = dataExam.Select("EXAM_ID=" + dttExam.Rows[0]["EXAM_ID"].ToString());
                result += "; " + rs[0]["EXAM_NAME"].ToString().Trim();
                if (!string.IsNullOrEmpty(dttExam.Rows[0]["EMP_ID"].ToString()))
                    result += " (" + getRadilogyName(dttExam.Rows[0]["EMP_ID"].ToString()) + ") ";
            }
            else
            {
                result = "HN : " + patient.Reg_UID + patient_id_label + " " + patient.Title + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                result += "; ";
                foreach (DataRow dr in dttExam.Rows)
                {
                    DataRow[] rs = dataExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                    result += rs[0]["EXAM_NAME"].ToString().Trim();// +"; ";
                    if (!string.IsNullOrEmpty(dr["EMP_ID"].ToString()))
                        result += " (" + getRadilogyName(dr["EMP_ID"].ToString()) + ") ; ";
                    else
                        result += "; ";
                }
                result = result.Remove(result.LastIndexOf(';'), 1);
            }

            if (txtAddTextInBlock.Text.Trim().Length != 0)
            {
                string log_msg = txtAddTextInBlock.Text.Trim();
                log_msg = " (" + log_msg + ") ";

                result += log_msg;
            }

            return result;
        }
        private void checkAllergies()
        {
            if (!string.IsNullOrEmpty(patient.Allergies))
            {
                frmAllergy2 Allergy = new frmAllergy2(patient.Reg_UID);
                Allergy.TopLevel = true;
                Allergy.StartPosition = FormStartPosition.CenterScreen;
                Allergy.ShowDialog();
            }
        }
        private void updateRegistrationAllergies()
        {
            try
            {
                GBLEnvVariable env = new GBLEnvVariable();
                ProcessUpdateHISRegistration proUpdateAllergies = new ProcessUpdateHISRegistration();
                proUpdateAllergies.HIS_REGISTRATION.HN = patient.Reg_UID;
                proUpdateAllergies.HIS_REGISTRATION.LAST_MODIFIED_BY = env.UserID;
                proUpdateAllergies.HIS_REGISTRATION.ALLERGIES = string.IsNullOrEmpty(patient.Allergies.ToString().Trim()) ? "" : "Y";
                proUpdateAllergies.UpdateAllergies();
            }
            catch (Exception ex) { }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SCHEDULE_STATUS == "W")
            {
                msg.ShowAlert("UID1416", env.CurrentLanguageID);
                return;
            }
            if (txtInputReason.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                txtInputReason.Focus();
                return;
            }
            string s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
            if (s == "2")
            {
                ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                process.RIS_SCHEDULE.REASON = txtInputReason.Text.Trim();
                process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                process.Invoke();
                #region Delete in Appontment.
                //for (int i = 0; i < dttAppointment.Rows.Count; i++) {
                //    if (dttAppointment.Rows[i]["SCHEDULE_ID"].ToString().Trim() == apt.Location.Trim()) {
                //        dttAppointment.Rows[i].Delete();
                //        dttAppointment.AcceptChanges();
                //        break;
                //    }                
                //}
                #endregion
                this.DialogResult = DialogResult.OK;
                SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                this.Close();
            }
        }
        
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chkBlock.Checked || chkComments.Checked)
            {
                if (txtAddTextInBlock.Text.Trim().Length == 0)
                {
                    msg.ShowAlert("UID1109", env.CurrentLanguageID);
                    txtAddTextInBlock.Focus();
                    return ;
                }
                if (txtInputReason.Text.Trim().Length == 0)
                {
                    msg.ShowAlert("UID1110", env.CurrentLanguageID);
                    txtInputReason.Focus();
                    return;
                }
                updateBlockData();
            }
            else if (requireCheck())
            {
                if (!checkConflict(dttExam, dtStart.DateTime))
                {
                    deleteEmptyRow();
                    updateAppointmentData();
                }
            }
           
        }
        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                deleteEmptyRow();
                if (updateAppointmentData())
                {
                    ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                    process.RIS_SCHEDULE.SCHEDULE_ID = schedule_id;
                    DataTable dtData = process.GetMultiPrint();
                    DataTable dts = new DataTable();
                    foreach (DataRow row in dtData.Rows)
                    {
                        ReportParameters spara = new ReportParameters();
                        spara.ScheduleID = Convert.ToInt32(row["SCHEDULE_ID"].ToString());
                        spara.PatientId = row["HN"].ToString();
                        spara.AppointDate = Convert.ToDateTime(row["START_DATETIME"].ToString());
                        spara.ModalityId = Convert.ToInt32(row["MODALITY_ID"].ToString());
                        ProcessScheduleReport slkp = new ProcessScheduleReport();
                        slkp.ReportParameters = spara;
                        slkp.Invoke();
                        dts = slkp.ResultSet.Tables[0];
                    }
                    if (dts.Rows[0]["PAT_DEST_LABEL"].ToString() == "AIMC")
                    {
                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                        print.AppointmentDirectPrint(schedule_id, dts.Rows[0]["PAT_DEST_LABEL"].ToString());
                    }
                    else
                    {
                        if (dttExam.Rows.Count == 1)
                        {
                            #region Single Exam.

                            if (dts.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dts.Rows[0]["PAT_DEST_LABEL"].ToString()))
                                {
                                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                    print.AppointmentDirectPrint(schedule_id, dts.Rows[0]["PAT_DEST_LABEL"].ToString());
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region Multiprint.
                            frmMultiplePrint frm = new frmMultiplePrint(schedule_id);
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog();
                            #endregion
                        }
                    }
                }
            }
        }
        private void btnScan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHN.Text))
            {
                diagUploadFile diag = new diagUploadFile(dv_scan_image, false);
                diag.Height = Height;
                diag.Width = Width;

                if (diag.ShowDialog() == DialogResult.OK)
                    dv_scan_image = diag.OrderImages;
                else if (diag.ShowDialog() == DialogResult.Abort)
                {
                    PointerStruct.ImageUrl = env.PacsUrl2;

                    Order thisOrder = new Order();
                    ProcessGetRISOrderimages geImage = new ProcessGetRISOrderimages();
                    geImage.RIS_ORDERIMAGE.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                    geImage.Invoke();
                    DataTable dttIm = geImage.Result.Tables[0];
                    DataView dvv = new DataView(dttIm.Copy());

                    if (dttIm.Rows.Count > 0)
                    {
                        Miracle.Scanner.EditImageOrder editFrm = new Miracle.Scanner.EditImageOrder(dttIm, env.PixPicture);
                        editFrm.StartPosition = FormStartPosition.CenterParent;
                        editFrm.ShowDialog();
                        if (editFrm.DialogResult == DialogResult.Yes)
                        {
                            thisOrder.Ris_OrderImage = editFrm.Data.Copy().DefaultView;
                            env.PixPicture = editFrm.PictureStruct;
                            dtImageScan = editFrm.Data;
                        }
                    }
                    else
                    {
                        Miracle.Scanner.NewScan frm = new Miracle.Scanner.NewScan(env.PixPicture);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            env.PixPicture = frm.PictureStruct;
                    }
                }
            }
        }

        private void chkBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlock.Checked)
            {
                #region Clear Context.
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                txtOrderDept.Text = string.Empty;
                txtOrderDoc.Text = string.Empty;
                txtHN.Text = "BLOCK";
                txtFName.Text = string.Empty;
                txtLName.Text = string.Empty;
                txtFName_Eng.Text = string.Empty;
                txtLName_Eng.Text = string.Empty;
                txtID.Text = string.Empty;
                cboGender.SelectedIndex = 0;
                txtPhone.Text = string.Empty;
                //txtMobile.Text = string.Empty;

                txtOrderDoc.BackColor = txtFName.BackColor;
                txtOrderDept.BackColor = txtFName.BackColor;
                txtID.BackColor = txtFName.BackColor;
                deLMP.BackColor = deLMP.Visible ? txtHN.BackColor : txtFName.BackColor;
                txtAGE.Text = string.Empty;
                txtAGE.BackColor = txtFName.BackColor;

                initGridAppointment("00");
                setTextInfo();
                initGridHistory();

                DataTable dtt = dttExam.Copy();
                //initDataGridColumns();
                initGridExam();
                dttExam = dtt.Copy();
                btnScan.Enabled = false;
                btnSavePrint.Enabled = false;
                #endregion
            }
            else
            {
                fillDemographic();
                btnSavePrint.Enabled = btnScan.Enabled = txtFName.Text.Trim().Length > 0 ? true : false;
            }
        }
        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGender.SelectedIndex == 0)
                deLMP.Enabled = false;
            else
                deLMP.Enabled = true;
        }

        private void grdLvPatStatus_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtG = (DataTable)grdLvPatStatus.Properties.DataSource;
            if (dtG.Rows.Count > 0)
            {
                pat_id = Convert.ToInt32(dtG.Rows[viewPat.FocusedRowHandle]["STATUS_ID"]);
            }
        }
        private void grdLvInsurance_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void btnReason_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(reasonLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";

            lv.Data = lvS.ScheduleHaveParameter("General2", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void reasonLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInputReason.Tag = retValue[0];
            txtInputReason.Text = retValue[2];
        }

        #region Grid History
        private void setTextInfo()
        {
            txtHNInfo.Text = string.Empty;
            txtPatientNameInfo.Text = string.Empty;
            txtModalityInfo.Text = string.Empty;
            txtStartInfo.Text = string.Empty;
            txtEndInfo.Text = string.Empty;
            txtDepartmentInfo.Text = string.Empty;
            txtDoctorInfo.Text = string.Empty;
            cmbExam.Enabled = false;
        }
        private void initGridHistory()
        {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            dsHistorySchedule = process.GetLogSchedule(Convert.ToInt32(apt.Location));

            grdData.DataSource = dsHistorySchedule.Tables[0];

            int i = 0;
            for (; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["LOGS_MODIFIED_ON"].ColVIndex = 1;
            view1.Columns["LOGS_MODIFIED_ON"].Caption = "วันที่แก้ไข";
            view1.Columns["LOGS_MODIFIED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            view1.Columns["LOGS_MODIFIED_ON"].Width = 120;

            view1.Columns["LOGS_MODIFIED_NAME"].ColVIndex = 2;
            view1.Columns["LOGS_MODIFIED_NAME"].Caption = "ผู้แก้ไข";
            view1.Columns["LOGS_MODIFIED_NAME"].Width = 200;

            view1.Columns["REASON"].ColVIndex = 3;
            view1.Columns["REASON"].Caption = "เหตุผล";
            view1.Columns["REASON"].Width = 120;

            view1.Columns["COMMENTS"].ColVIndex = 4;
            view1.Columns["COMMENTS"].Caption = "Comments";
            view1.Columns["COMMENTS"].Width = 120;

            view1.Columns["PENDING_COMMENTS"].ColVIndex = 5;
            view1.Columns["PENDING_COMMENTS"].Caption = "Comments with Process";
            view1.Columns["PENDING_COMMENTS"].Width = 120;

            view1.Columns["LOGS_DESC"].ColVIndex = 6;
            view1.Columns["LOGS_DESC"].Caption = "สถานะ";
            view1.Columns["LOGS_DESC"].Width = 120;
        }
        private void cmbExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null)
            {
                Exam_items examItem = cmbExam.SelectedItem as Exam_items;
                DataView dvHistory = dsHistorySchedule.Tables[1].DefaultView;
                dvHistory.RowFilter = "SCHEDULELOG_ID=" + dr["SCHEDULELOG_ID"].ToString()+ " and EXAM_ID=" + examItem.Exam_id().ToString();

                DataTable dtHistory = dvHistory.ToTable();
                //if (dtHistory.Rows.Count <= 0)
                //    dtHistory = dttScheduleHistory.Copy();

                //grdData.DataSource = dtHistory;

                //foreach (DataRow dr in dtHistory.Rows)
                //{
                //    txtHNInfo.Text = dr["HN"].ToString();
                //    txtPatientNameInfo.Text = dr["PATIENTNAME"].ToString();
                //    txtModalityInfo.Text = dr["MODALITY_NAME"].ToString();
                //    //txtExamNameInfo.Text = dr["EXAM_NAME"].ToString();
                //    txtStartInfo.Text = dr["START_DATETIME"].ToString();
                //    txtEndInfo.Text = dr["END_DATETIME"].ToString();
                //    txtDepartmentInfo.Text = dr["UNIT_NAME"].ToString();
                //    txtDoctorInfo.Text = dr["DOCTORNAME"].ToString();
                //}
                if (dtHistory.Rows.Count > 0)
                {
                    textRadiologist.Text = string.IsNullOrEmpty(dtHistory.Rows[0]["EMP_NAME"].ToString()) ? "-" : dtHistory.Rows[0]["EMP_NAME"].ToString();
                }
            }
        }
        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                txtHNInfo.Text = dr["HN"].ToString();
                txtPatientNameInfo.Text = dr["PATIENT_NAME"].ToString();
                txtModalityInfo.Text = dr["MODALITY_NAME"].ToString();
                //txtExamNameInfo.Text = dr["EXAM_NAME"].ToString();
                txtStartInfo.Text = dr["START_DATETIME"].ToString();
                txtEndInfo.Text = dr["END_DATETIME"].ToString();
                txtDepartmentInfo.Text = dr["REF_UNIT_NAME"].ToString();
                txtDoctorInfo.Text = dr["REF_DOC_NAME"].ToString();
                txtComments.Text = string.IsNullOrEmpty(dr["COMMENTS"].ToString()) ? "-" : dr["COMMENTS"].ToString();
                //textRadiologist.Text = string.IsNullOrEmpty(dr["REF_DOC_NAME"].ToString()) ? "-" : dr["REF_DOC_NAME"].ToString();
                cmbExam.Properties.Items.Clear();
                ComboBoxItemCollection colls = cmbExam.Properties.Items;
                colls.BeginUpdate();
                try
                {
                    DataRow[] rowsExam = dsHistorySchedule.Tables[1].Select("SCHEDULELOG_ID=" + dr["SCHEDULELOG_ID"].ToString());
                    foreach (DataRow drr in rowsExam)
                        colls.Add(new Exam_items(string.IsNullOrEmpty(drr["EXAM_ID"].ToString()) ? 0 : Convert.ToInt32(drr["EXAM_ID"])
                            , string.IsNullOrEmpty(drr["EXAM_UID"].ToString()) ? "" : drr["EXAM_UID"].ToString()
                            , string.IsNullOrEmpty(drr["EXAM_NAME"].ToString()) ? "" : drr["EXAM_NAME"].ToString()));
                }
                finally
                {
                    colls.EndUpdate();
                }
                cmbExam.SelectedIndex = 0;
           

            }
        }
        #endregion

        #region Grid Appointment
        private void initGridAppointment(string HN)
        {

            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RIS_SCHEDULE.HN = HN;
            process.RIS_SCHEDULE.SCHEDULE_DT = DateTime.Today;
            DataTable dtt = process.GetAppointment();
            viewApp.Columns.Clear();
            grdApp.DataSource = dtt;
            for (int i = 0; i < dtt.Columns.Count; i++)
                viewApp.Columns[i].Visible = false;
            setColumnShow();

        }
        private void setColumnShow()
        {
            viewApp.Columns["START_DATETIME"].Visible = true;
            viewApp.Columns["START_DATETIME"].Caption = "Appoint Date";
            viewApp.Columns["START_DATETIME"].ColVIndex = 0;
            viewApp.Columns["START_DATETIME"].Width = 100;

            viewApp.Columns["START_DATETIME"].Visible = true;
            viewApp.Columns["START_DATETIME"].Caption = "Start";
            viewApp.Columns["START_DATETIME"].ColVIndex = 1;
            viewApp.Columns["START_DATETIME"].DisplayFormat.FormatString = "T";
            viewApp.Columns["START_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewApp.Columns["START_DATETIME"].Width = 80;

            viewApp.Columns["END_DATETIME"].Visible = true;
            viewApp.Columns["END_DATETIME"].Caption = "End";
            viewApp.Columns["END_DATETIME"].DisplayFormat.FormatString = "T";
            viewApp.Columns["END_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewApp.Columns["END_DATETIME"].ColVIndex = 2;
            viewApp.Columns["END_DATETIME"].Width = 80;

            viewApp.Columns["MODALITY_NAME"].Visible = true;
            viewApp.Columns["MODALITY_NAME"].Caption = "Modality";
            viewApp.Columns["MODALITY_NAME"].ColVIndex = 3;
            viewApp.Columns["MODALITY_NAME"].Width = 150;


            viewApp.Columns["EXAM_NAME"].Visible = true;
            viewApp.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewApp.Columns["EXAM_NAME"].ColVIndex = 4;
            viewApp.Columns["EXAM_NAME"].Width = 250;


            viewApp.Columns["APPBY"].Visible = true;
            viewApp.Columns["APPBY"].Caption = "By";
            viewApp.Columns["APPBY"].ColVIndex = 5;
            viewApp.Columns["APPBY"].Width = 120;
        }
        #endregion

        #region Grid Exam
        private void initDataGridColumns() {
            dttExam = new DataTable();
            dttExam.Columns.Add("SCHEDULE_ID", typeof(int));
            dttExam.Columns.Add("OLD_EXAM_ID", typeof(int));
            dttExam.Columns.Add("EXAM_ID", typeof(int));
            dttExam.Columns.Add("EXAM_UID", typeof(string));
            dttExam.Columns.Add("EXAM_NAME", typeof(string));
            dttExam.Columns.Add("BPVIEW_ID", typeof(int));
            dttExam.Columns.Add("QTY", typeof(int));
            dttExam.Columns.Add("RATE", typeof(double));
            dttExam.Columns.Add("AVG_REQ_MIN", typeof(int));
            dttExam.Columns.Add("PREPATION_ID", typeof(int));
            dttExam.Columns.Add("EMP_ID", typeof(int));
            dttExam.Columns.Add("GEN_ID", typeof(int));
            dttExam.Columns.Add("TOTAL", typeof(double));
            dttExam.Columns.Add("DELETE", typeof(string));
            dttExam.Columns.Add("COMMENTS", typeof(string));
            dttExam.AcceptChanges();
        }
        private void addEmptyRow()
        {
            DataRow row = dttExam.NewRow();
            row["SCHEDULE_PRIORITY"] = "R";
            row["QTY"] = 1;
            row["RATE"] = 0.0;
            row["TOTAL"] = 0;
            dttExam.Rows.Add(row);
            dttExam.AcceptChanges();
        }
        private void initEmptyRows() {
            bool flag = true;
            foreach(DataRow row in dttExam.Rows)
                if (string.IsNullOrEmpty(row["EXAM_ID"].ToString().Trim())) {
                    flag = false;
                    break;
                }
            if (flag) {
                addEmptyRow();
            }
        }
        private void initGridExam()
        {
            initEmptyRows();
            grdExam.DataSource = dttExam;

            for (int i = 0; i < viewExam.Columns.Count; i++)
            {
                viewExam.Columns[i].Visible = false;
            }
            #region Reposity Priority
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rpPriority = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            rpPriority.AutoHeight = false;
            rpPriority.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)
            });
            rpPriority.Name = "rImcbBPView";
            rpPriority.SmallImages = imgWL;
            rpPriority.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rpPriority.Buttons[0].Visible = false;
            #endregion
            viewExam.Columns["SCHEDULE_PRIORITY"].ColumnEdit = rpPriority;
            viewExam.Columns["SCHEDULE_PRIORITY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["SCHEDULE_PRIORITY"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["SCHEDULE_PRIORITY"].OptionsFilter.AllowFilter = false;
            viewExam.Columns["SCHEDULE_PRIORITY"].Caption = " ";
            viewExam.Columns["SCHEDULE_PRIORITY"].Width = -1;
            viewExam.Columns["SCHEDULE_PRIORITY"].VisibleIndex = 1;

            #region Reposity Exam Flag
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repExamFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repExamFlag.AutoHeight = false;
            repExamFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",2,1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",3,2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",4,3),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",5,4)
            });
            repExamFlag.Name = "repExamFlag";
            repExamFlag.SmallImages = img16;
            repExamFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repExamFlag.Buttons[0].Visible = false;
            #endregion
            viewExam.Columns["FLAG_ICON"].ColumnEdit = repExamFlag;
            viewExam.Columns["FLAG_ICON"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;
            viewExam.Columns["FLAG_ICON"].Caption = " ";
            viewExam.Columns["FLAG_ICON"].Width = -1;
            viewExam.Columns["FLAG_ICON"].VisibleIndex = 1;

            #region Reposity ExamCode.
            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            repositoryItemLookUpEdit1.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = sortDataTable(dataExam, "EXAM_UID");
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examCode_KeyUp);
            repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode_CloseUp);
            repositoryItemLookUpEdit1.BestFit();
            repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EXAM_UID"].ColumnEdit = repositoryItemLookUpEdit1;
            viewExam.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EXAM_UID"].Caption = "Exam Code";
            viewExam.Columns["EXAM_UID"].Width = 80;
            viewExam.Columns["EXAM_UID"].VisibleIndex = 2;

            #region Reposity ExamName.
            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = sortDataTable(dataExam, "EXAM_NAME");
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            repositoryItemLookUpEdit2.BestFit();
            repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            viewExam.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewExam.Columns["EXAM_NAME"].Width = 180;
            viewExam.Columns["EXAM_NAME"].VisibleIndex = 3;

            #region Reposity BodyPartView.
            RepositoryItemLookUpEdit rleBPView = new RepositoryItemLookUpEdit();
            rleBPView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rleBPView.ImmediatePopup = true;
            rleBPView.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            rleBPView.AutoHeight = false;
            rleBPView.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BPVIEW_NAME", "Sides", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            rleBPView.DisplayMember = "BPVIEW_NAME";
            rleBPView.ValueMember = "BPVIEW_ID";
            rleBPView.DropDownRows = 5;
            rleBPView.DataSource = dttBpview.Copy();
            rleBPView.NullText = string.Empty;
            rleBPView.KeyUp += new KeyEventHandler(BPView_KeyUp);
            rleBPView.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(BPView_CloseUp);
            rleBPView.BestFit();
            rleBPView.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["BPVIEW_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["BPVIEW_ID"].ColumnEdit = rleBPView;
            viewExam.Columns["BPVIEW_ID"].Caption = "Sides";
            viewExam.Columns["BPVIEW_ID"].VisibleIndex = 4;

            #region Reposity QTY
            RepositoryItemSpinEdit spe = new RepositoryItemSpinEdit();
            spe.Increment = 1;
            spe.MinValue = 1;
            spe.MaxValue = 100;
            spe.MaxLength = 100;
            spe.ValueChanged += new EventHandler(spe_ValueChanged);
            #endregion
            viewExam.Columns["QTY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["QTY"].ColumnEdit = spe;
            viewExam.Columns["QTY"].Caption = "Qty";
            viewExam.Columns["QTY"].Width = 50;
            viewExam.Columns["QTY"].VisibleIndex = 5;
            viewExam.Columns["QTY"].OptionsColumn.ReadOnly = true;

            viewExam.Columns["RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["RATE"].Caption = "Rate";
            viewExam.Columns["RATE"].Width = 80;
            viewExam.Columns["RATE"].VisibleIndex = 6;
            viewExam.Columns["RATE"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["RATE"].DisplayFormat.FormatString = "#,##0";
            viewExam.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            #region Repository Avg req min
            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rpsReq = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            rpsReq.AutoHeight = false;
            rpsReq.IsFloatValue = false;
            rpsReq.Mask.EditMask = "N00";
            rpsReq.MinValue = 0;
            rpsReq.MaxValue = 2000;
            rpsReq.KeyUp += new KeyEventHandler(rpsReq_KeyUp);
            rpsReq.ValueChanged += new EventHandler(rpsReq_ValueChanged);
            #endregion
            viewExam.Columns["AVG_REQ_MIN"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["AVG_REQ_MIN"].Caption = "Avg(Minute)";
            viewExam.Columns["AVG_REQ_MIN"].Width = 90;
            viewExam.Columns["AVG_REQ_MIN"].VisibleIndex = 7;
            viewExam.Columns["AVG_REQ_MIN"].ColumnEdit = rpsReq;

            //viewExam.Columns["TOTAL"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //viewExam.Columns["TOTAL"].Visible = false;
            //viewExam.Columns["TOTAL"].Caption = "Total";
            //viewExam.Columns["TOTAL"].Width = 90;
            //viewExam.Columns["TOTAL"].VisibleIndex = 9;
            //viewExam.Columns["TOTAL"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //viewExam.Columns["TOTAL"].SummaryItem.DisplayFormat = "{0:N0}";
            //viewExam.Columns["TOTAL"].OptionsColumn.ReadOnly = true;
            //viewExam.Columns["TOTAL"].DisplayFormat.FormatString = "#,##0";
            //viewExam.Columns["TOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            #region Reposity Prepation
            LookUpSelect lvS = new LookUpSelect();
            DataTable dttPre = lvS.ScheduleNotParameter("Prepation").Tables[0];
            RepositoryItemLookUpEdit rlePre = new RepositoryItemLookUpEdit();
            rlePre.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rlePre.ImmediatePopup = true;
            rlePre.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            rlePre.AutoHeight = false;
            rlePre.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PREPARATION_UID", "Prepation", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            rlePre.DisplayMember = "PREPARATION_UID";
            rlePre.ValueMember = "PREPARATION_ID";
            rlePre.DropDownRows = 5;
            rlePre.DataSource = dttPre;
            rlePre.NullText = string.Empty;
            rlePre.KeyUp += new KeyEventHandler(rlePre_KeyUp);
            rlePre.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(rlePre_CloseUp);
            rlePre.BestFit();
            rlePre.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["PREPATION_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["PREPATION_ID"].ColumnEdit = rlePre;
            viewExam.Columns["PREPATION_ID"].Caption = "Preparation";
            viewExam.Columns["PREPATION_ID"].Width = 100;
            viewExam.Columns["PREPATION_ID"].VisibleIndex = 8;

            #region Repository Radiologist
            RepositoryItemLookUpEdit rpsRadio = new RepositoryItemLookUpEdit();
            rpsRadio.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rpsRadio.ImmediatePopup = true;
            rpsRadio.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            rpsRadio.AutoHeight = false;
            rpsRadio.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UIDAndRadioName", "Radiologist", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            rpsRadio.DisplayMember = "UIDAndRadioName";
            rpsRadio.ValueMember = "EMP_ID";
            rpsRadio.DropDownRows = 5;
            rpsRadio.NullText = string.Empty;
            rpsRadio.KeyUp += new KeyEventHandler(rpsRadio_KeyUp);
            rpsRadio.EditValueChanged += new EventHandler(rpsRadio_EditValueChanged);
            //rpsRadio.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(rpsRadio_CloseUp);
            DataTable dtRadiologist = dttRadiologist;
            rpsRadio.DataSource = dtRadiologist;
            rpsRadio.BestFit();
            rpsRadio.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EMP_ID"].ColumnEdit = rpsRadio;
            viewExam.Columns["EMP_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EMP_ID"].Caption = "Radiologist";
            viewExam.Columns["EMP_ID"].Width = 150;
            viewExam.Columns["EMP_ID"].VisibleIndex = 9;

            viewExam.Columns["EMP_ID"].SummaryItem.FieldName = "TOTAL";
            viewExam.Columns["EMP_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewExam.Columns["EMP_ID"].SummaryItem.DisplayFormat = "Total : {0}";


            #region Repository Delete
            RepositoryItemButtonEdit btnDel = new RepositoryItemButtonEdit();
            btnDel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btnDel.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnDel_ButtonClick);
            #endregion
            viewExam.Columns["DELETE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["DELETE"].Caption = " ";
            viewExam.Columns["DELETE"].Width = 30;
            viewExam.Columns["DELETE"].VisibleIndex = 10;
            viewExam.Columns["DELETE"].ColumnEdit = btnDel;
        }
        private DataTable sortDataTable(DataTable data, string strSorting)
        {
            DataView view = data.DefaultView;
            view.Sort = strSorting;
            DataTable dt = view.ToTable().Copy();
            return dt;
        }
        private void spe_ValueChanged(object sender, EventArgs e)
        {
            SpinEdit spe = new SpinEdit();
            spe = (SpinEdit)sender;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            int sp = Convert.ToInt32(spe.Value.ToString());
            if (sp > 0)
            {
                dr["QTY"] = sp;
                dr.AcceptChanges();
                calTotal();
            }
            else
            {
                dr["QTY"] = 0;
                dr.AcceptChanges();
                calTotal();
            }
        }
        private bool canAddRow()
        {
            bool flag = true;
            foreach (DataRow dr in dttExam.Rows)
            {
                if (dr["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        private void calTotal()
        {
            decimal total = 0.0M;
            DataTable dtt = (DataTable)grdExam.DataSource;
            foreach (DataRow dr in dtt.Rows)
            {
                decimal taxTemp = dr["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["RATE"]);
                int qty = dr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["QTY"]);
                total = taxTemp * qty;
                dr["TOTAL"] = total;
            }
        }
        private int calculateTime()
        {
            if (dttExam == null) return 0;
            int result = 0;
            foreach (DataRow row in dttExam.Rows)
            {
                if (row["AVG_REQ_MIN"].ToString().Trim().Length > 0)
                    result += Convert.ToInt32(row["AVG_REQ_MIN"].ToString());
            }
            DateTime tm = (DateTime)timeStart.EditValue;
            tm = tm.AddMinutes(result);
            timeEnd.EditValue = tm;
            return result;
        }
        private bool checkConflict(int ExamID, DateTime datetime_start)
        {
            bool flag = false;
            ScheduleInfo schCheckConflictTime = new ScheduleInfo();
            DataTable dataConflictTime = new DataTable();

            DataRow[] rows = dttExam.Select("EXAM_ID=" + ExamID.ToString());
            if (rows.Length > 0)
            {
                msg.ShowAlert("UID1014", env.CurrentLanguageID);
                return true;
            }
            if (!flag)
            {
                flag = schCheckConflictTime.IsHaveAppointment(patient.Reg_UID, ExamID, datetime_start, out dataConflictTime);
                // popup Conflict form
                if (dataConflictTime.Rows.Count > 0)
                {
                    frmScheduleConflictDetail frmConflictDetail = new frmScheduleConflictDetail(dataConflictTime);
                    frmConflictDetail.ShowDialog();
                }
            }
            return flag;
        }
        private bool checkConflict(DataTable all_Exam, DateTime datetime_start)
        {
            bool flag = false;
            ScheduleInfo schCheckConflictTime = new ScheduleInfo();
            DataTable dataConflictTime = new DataTable();
            DataTable dataConflictAll = new DataTable();
            foreach (DataRow row in all_Exam.Rows)
            {
                if (row["EXAM_ID"].ToString().Trim() != string.Empty)
                {
                    if (row["SCHEDULE_ID"].ToString() != schedule_id.ToString())
                    {
                        schCheckConflictTime.IsHaveAppointment(patient.Reg_UID, Convert.ToInt32(row["EXAM_ID"]), datetime_start, out dataConflictTime);
                        dataConflictAll.Merge(dataConflictTime);
                    }
                }
            }
            // popup Conflict form
            if (dataConflictTime.Rows.Count > 0)
            {
                flag = true;
                frmScheduleConflictDetail frmConflictDetail = new frmScheduleConflictDetail(dataConflictTime);
                frmConflictDetail.ShowDialog();
            }
            return flag;
        }
        private bool updateExam(int exam_id)
        {
            bool flag = false;
            dttExam = (DataTable)grdExam.DataSource;
            DataRow[] rows = dataExam.Select("EXAM_ID=" + exam_id);
            if (rows.Length > 0)
            {
                flag = true;
                if (checkConflict(exam_id, dtStart.DateTime)) return false;
                DataRow dr = dttExam.Rows[viewExam.FocusedRowHandle];
                dr["EXAM_ID"] = rows[0]["EXAM_ID"];
                dr["EXAM_UID"] = rows[0]["EXAM_ID"];
                dr["EXAM_NAME"] = rows[0]["EXAM_ID"];
               // dr["RATE"] = rows[0]["RATE"];

                DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype);
                string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL": dr["RATE"] = patient.NON_RESIDENCE == "Y" ? rows[0]["FOREIGN_SPCIAL_RATE"].ToString() : rows[0]["SPECIAL_RATE"].ToString(); break;
                    case "VIP": dr["RATE"] = patient.NON_RESIDENCE == "Y" ? rows[0]["FOREIGN_VIP_RATE"].ToString() : rows[0]["VIP_RATE"].ToString(); break;
                    default: dr["RATE"] = patient.NON_RESIDENCE == "Y" ? rows[0]["FOREIGN_RATE"].ToString() : rows[0]["RATE"].ToString(); break;
                }

                dr["QTY"] = 1;
                dr["BPVIEW_ID"] = 0;
                if (rows[0]["AVG_REQ_MIN"].ToString().Trim().Length > 0)
                    dr["AVG_REQ_MIN"] = rows[0]["AVG_REQ_MIN"];
                else
                    dr["AVG_REQ_MIN"] = avg_inv_time;
                calExamPanel(exam_id.ToString());
                calTotal();
                calculateTime();
                if (canAddRow())
                    addEmptyRow();
                viewExam.RefreshData();
            }
            return flag;
        }
        private void updateBPView(string strSearch)
        {
            dttExam = (DataTable)grdExam.DataSource;
            DataTable dtBP_View = dttBpview.Copy();
            DataRow[] rows = dtBP_View.Select("BPVIEW_ID = " + strSearch);
            if (rows.Length > 0)
            {
                DataRow dr = dttExam.Rows[viewExam.FocusedRowHandle];
                dr["BPVIEW_ID"] = rows[0]["BPVIEW_ID"];
                dr["QTY"] = rows[0]["NO_OF_EXAM"];
                calTotal();
                dttExam.AcceptChanges();
                viewExam.RefreshData();
            }
        }
        private void updateRadiologist(string strSearch)
        {
            if (string.IsNullOrEmpty(strSearch)) return;
            dttExam = (DataTable)grdExam.DataSource;
            DataTable dtRad = dttRadiologist.Copy();
            DataRow[] rows = dtRad.Select("EMP_ID = " + strSearch);
            if (rows.Length > 0)
            {
                DataRow dr = dttExam.Rows[viewExam.FocusedRowHandle];
                dr["EMP_ID"] = rows[0]["EMP_ID"];
                dttExam.AcceptChanges();
                viewExam.RefreshData();
            }
        }
        private void updatePreparation(string strSearch)
        {
            dttExam = (DataTable)grdExam.DataSource;
            LookUpSelect lvS = new LookUpSelect();
            DataTable dttPre = lvS.ScheduleNotParameter("Prepation").Tables[0];
            DataRow[] rows = dttPre.Select("PREPARATION_ID = " + strSearch);
            if (rows.Length > 0)
            {
                foreach (DataRow row in dttExam.Rows)
                {
                    if (!string.IsNullOrEmpty(row["EXAM_ID"].ToString()))
                        row["PREPATION_ID"] = rows[0]["PREPARATION_ID"];
                }
                dttExam.AcceptChanges();
                viewExam.RefreshData();
            }
        }

        private void examCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                    viewExam.FocusedColumn = viewExam.VisibleColumns[viewExam.FocusedColumn.VisibleIndex + 1];
                else
                {
                    viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                    viewExam.MoveNext();
                }
            }
        }
        private void examCode_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (e.Value == null) return;
                DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                int row = viewExam.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updateExam(Convert.ToInt32(e.Value));
                    if (flag)
                    {
                        if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                        {
                            viewExam.FocusedRowHandle = row;
                            viewExam.FocusedColumn = viewExam.VisibleColumns[2];
                        }
                        else
                        {
                            viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                            viewExam.MoveNext();
                        }
                    }
                    else
                    {
                        e.AcceptValue = false;
                    }
                }
            }
        }

        private void examName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                    viewExam.FocusedColumn = viewExam.VisibleColumns[viewExam.FocusedColumn.VisibleIndex + 1];
                else
                {
                    viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                    viewExam.MoveNext();
                }
            }
        }
        private void examName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (e.Value == null) return;
                DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                int row = viewExam.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updateExam(Convert.ToInt32(e.Value));
                    if (flag)
                    {
                        if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                        {
                            viewExam.FocusedRowHandle = row;
                            viewExam.FocusedColumn = viewExam.VisibleColumns[2];
                        }
                        else
                        {
                            viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                            viewExam.MoveNext();
                        }
                    }
                    else
                    {
                        e.AcceptValue = false;
                    }
                }
            }
        }

        private void BPView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                    viewExam.FocusedColumn = viewExam.VisibleColumns[viewExam.FocusedColumn.VisibleIndex + 3];
                else
                {
                    viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                    viewExam.MoveNext();
                }
            }
        }
        private void BPView_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                int row = viewExam.FocusedRowHandle;
                if (e.Value == null) return;
                if (e.Value.ToString() != string.Empty)
                {
                    updateBPView(e.Value.ToString());

                    if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                    {
                        viewExam.FocusedRowHandle = row;
                        viewExam.FocusedColumn = viewExam.VisibleColumns[5];
                    }
                    else
                    {
                        viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                        viewExam.MoveNext();
                    }
                }

            }
        }

        private void rlePre_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                int row = viewExam.FocusedRowHandle;
                if (e.Value == null) return;
                if (e.Value.ToString() != string.Empty)
                {
                    updatePreparation(e.Value.ToString());

                    if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                        viewExam.FocusedColumn = viewExam.VisibleColumns[viewExam.FocusedColumn.VisibleIndex + 1];
                    else
                    {
                        viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                        viewExam.MoveNext();
                    }
                }
            }
        }
        private void rlePre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                    viewExam.FocusedColumn = viewExam.VisibleColumns[viewExam.FocusedColumn.VisibleIndex + 1];
                else
                {
                    viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                    viewExam.MoveNext();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                dr["PREPATION_ID"] = DBNull.Value;
                viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                viewExam.MoveNext();
            }
        }

        private void rpsRadio_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                int row = viewExam.FocusedRowHandle;
                if (e.Value == null) return;
                if (e.Value.ToString() != string.Empty)
                {
                    updateRadiologist(e.Value.ToString());
                    viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                    viewExam.MoveNext();
                }
            }
        }
        private void rpsRadio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                viewExam.MoveNext();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                dr["EMP_ID"] = DBNull.Value;
                viewExam.FocusedColumn = viewExam.VisibleColumns[1];
                viewExam.MoveNext();
            }
            if (e.KeyCode == Keys.Delete)
            {
                //DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                //dr["EMP_ID"] = DBNull.Value;
                //LookUpEdit edit = sender as LookUpEdit;
                //edit.EditValue = null;
                rpsRadio_Popup(sender, "delete");
            }
        }
        private void rpsRadio_EditValueChanged(object sender, EventArgs e)
        {
            
            rpsRadio_Popup(sender, "");
        }

        private void rpsRadio_Popup(object sender, string key)
        {
            if (viewExam.FocusedRowHandle < 0) return;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            if (dr["EXAM_ID"] == null) return;
            if (dr == null) return;
            if (!string.IsNullOrEmpty(strMsgChangeRad)) return;

            bool flag = true;
            bool delete = false;
            DataView dvHistory = dsHistorySchedule.Tables[0].Copy().DefaultView;
            DataView dvHistoryDtl = dsHistorySchedule.Tables[1].Copy().DefaultView;
            if (dvHistory.Count == 0)
            {
                if (key == "delete")
                    delete = true;
                else
                    return;
            }
            if (dvHistoryDtl.Count == 0)
            {
                if (key == "delete")
                    delete = true;
                else
                    return;
            } 

            DevExpress.XtraEditors.LookUpEdit empEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (empEdit.EditValue == null) return;

            dvHistory.Sort = "SCHEDULELOG_ID";
            if (dvHistory[dvHistory.Count - 1]["LOGS_DESC"].ToString().ToLower().Contains("online"))
            {
                dvHistoryDtl.RowFilter = "SCHEDULELOG_ID=" + dvHistory[dvHistory.Count - 1]["SCHEDULELOG_ID"].ToString() + " and EXAM_ID=" + dr["EXAM_ID"].ToString();
                DataTable dtHistoryDtl = dvHistoryDtl.ToTable();

                if (dtHistoryDtl.Rows.Count == 0)
                {
                    if (key == "delete")
                        delete = true;
                    else
                        return;
                }

                if (!delete)
                {
                    if (string.IsNullOrEmpty(dtHistoryDtl.Rows[0]["RAD_ID"].ToString()))
                    {
                        if (key == "delete")
                            delete = true;
                        else
                            return;
                    }

                    string value = key == "delete" ? "" : (empEdit.EditValue == null ? "" : empEdit.EditValue.ToString());
                    MyMessageBox msg = new MyMessageBox();

                    if (value != dtHistoryDtl.Rows[0]["RAD_ID"].ToString())
                    {
                        flag = false;
                        strMsgChangeRad = msg.ShowAlert("UID1048", new GBLEnvVariable().CurrentLanguageID);

                        if (strMsgChangeRad == "1")
                        {
                            //if (string.IsNullOrEmpty(dr["EMP_ID"].ToString()))
                            //    empEdit.EditValue = string.IsNullOrEmpty(dtHistoryDtl.Rows[0]["RAD_ID"].ToString()) ? 0 : Convert.ToInt32(dtHistoryDtl.Rows[0]["RAD_ID"].ToString());
                            //else
                            try
                            {
                                empEdit.EditValue = string.IsNullOrEmpty(dr["EMP_ID"].ToString()) ? 0 : Convert.ToInt32(dr["EMP_ID"]);
                            }
                            catch
                            {
                                empEdit.EditValue = string.IsNullOrEmpty(dtHistoryDtl.Rows[0]["RAD_ID"].ToString()) ? 0 : Convert.ToInt32(dtHistoryDtl.Rows[0]["RAD_ID"].ToString());
                            }
                        }
                        else if (strMsgChangeRad == "2")
                        {
                            if (key == "delete")
                                delete = true;
                            else
                                flag = true;
                        }
                    }
                }
            }
            else if (key == "delete")
                delete = true;

            if (flag)
            {
                if (empEdit.EditValue != null)
                {
                    updateRadiologist(empEdit.EditValue == null ? "0" : empEdit.EditValue.ToString());
                    viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                    viewExam.MoveNext();
                }
            }

            if (delete)
            {
                dr["EMP_ID"] = DBNull.Value;
                empEdit.EditValue = null;
            }

            delete = false;
            strMsgChangeRad = string.Empty;
        }

        private void rpsReq_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (viewExam.FocusedColumn.VisibleIndex != viewExam.VisibleColumns.Count - 1)
                    viewExam.FocusedColumn = viewExam.VisibleColumns[viewExam.FocusedColumn.VisibleIndex + 1];
                else
                {
                    viewExam.FocusedColumn = viewExam.VisibleColumns[0];
                    viewExam.MoveNext();
                }
            }
        }
        private void rpsReq_ValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SpinEdit sp = sender as DevExpress.XtraEditors.SpinEdit;
            if (sp != null)
            {
                int idx = viewExam.FocusedRowHandle;
                if (idx > -1)
                {
                    try
                    {
                        if (dttExam.Rows[idx]["EXAM_ID"].ToString().Trim().Length == 0)
                        {
                            sp.EditValue = 0;
                            return;
                        }

                        int min = Convert.ToInt32(sp.EditValue);
                        //if (min == 0)
                        //{
                        //    min = avg_inv_time;
                        //    sp.EditValue = min;
                        //}
                        dttExam.Rows[idx]["AVG_REQ_MIN"] = min;
                        calculateTime();
                    }
                    catch { }
                }

            }
        }

        private void btnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dttExam = (DataTable)grdExam.DataSource;
            if (dttExam.Rows[viewExam.FocusedRowHandle]["EXAM_ID"].ToString() == string.Empty) return;
            if (!string.IsNullOrEmpty(dttExam.Rows[0]["EXAM_ID"].ToString()))
            {
                string textMsg = msg.ShowAlert("UID1025", env.CurrentLanguageID);
                if (textMsg == "2")
                {
                    if (dttExam.Rows.Count <= 1)
                    {
                        viewExam.DeleteSelectedRows();
                        dttExam = (DataTable)grdExam.DataSource;
                        dttExam.AcceptChanges();
                        dttExam = null;
                        initGridExam();

                        groupPatient.Enabled = true;
                        groupVisit.Enabled = true;
                        groupTiming.Enabled = true;


                    }
                    else
                    {
                        DataRow row = dttExam.Rows[viewExam.FocusedRowHandle];
                        if (!string.IsNullOrEmpty(row["SCHEDULE_ID"].ToString().Trim()))
                            delExamItem.Add(Convert.ToInt32(row["EXAM_ID"].ToString().Trim()));
                        viewExam.DeleteSelectedRows();
                        dttExam = (DataTable)grdExam.DataSource;
                        dttExam.AcceptChanges();
                        calculateTime();
                        DateTime tmS = (DateTime)timeStart.EditValue;
                        DateTime tmE = (DateTime)timeEnd.EditValue;
                        if (tmS == tmE)
                        {
                            tmE = tmE.AddMinutes(avg_inv_time);
                            timeEnd.EditValue = tmE;
                        }
                    }
                }
            }
            else
            {
                dttExam = null;
            }
        }

        private void ctmSubFree_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(projectLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";
            lv.Data = lvS.ScheduleHaveParameter("General", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void projectLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            dr["GEN_ID"] = retValue[0];
            dr["RATE"] = retValue[2];
            dr["COMMENTS"] = retValue[1];
            calTotal();
        }

        private void ctmSubNormal_Click(object sender, EventArgs e)
        {
            DataRow dr = dttExam.Rows[viewExam.FocusedRowHandle];
            DataRow[] rows = dataExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
            dr["RATE"] = rows[0]["RATE"];
            dr["GEN_ID"] = 0;
            calTotal();
        }
        private void ctmGen_Opening(object sender, CancelEventArgs e)
        {
            if (viewExam.FocusedRowHandle > -1)
            {
                DataRow row = dttExam.Rows[viewExam.FocusedRowHandle];
                if (row == null) { e.Cancel = true; return; }
                if (row["EXAM_ID"].ToString().Trim() == string.Empty) { e.Cancel = true; return; }
                e.Cancel = false;
                string setRate = dttExam.Rows[viewExam.FocusedRowHandle]["GEN_ID"].ToString().Trim();
                int gen_id = setRate == string.Empty ? 0 : Convert.ToInt32(setRate);
                if (gen_id > 0)
                {
                    NormalRateToolStripMenuItem.Image = null;
                    FreeRateToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                }
                else
                {
                    NormalRateToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
                    FreeRateToolStripMenuItem.Image = null;
                }

                DataRow[] rowExamFlag = dttExamFlag.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                if (rowExamFlag.Length > 0)
                {
                    DataRow[] rowSelected = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowExamFlag[0]["EXAMFLAG_ID"].ToString());
                    contextcmb.SelectedIndex = dtExamFlagDTL.Rows.IndexOf(rowSelected[0]);
                }
                else
                    contextcmb.SelectedIndex = 0;
            }
            else
                e.Cancel = true;
        }

        private void viewExam_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                string strqty = viewExam.FocusedColumn.FieldName;
                if (viewExam.FocusedRowHandle > -1)
                {
                    DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                    if (dr["EXAM_UID"].ToString() != string.Empty)
                    {
                        if (strqty == "QTY")
                        {
                            DataRow[] drbp = dttBpview.Copy().Select("BPVIEW_ID =" + dr["BPVIEW_ID"].ToString());
                            if (drbp[0]["BPVIEW_NAME"].ToString() == "Other")
                            {
                                viewExam.Columns["QTY"].OptionsColumn.ReadOnly = false;
                            }
                            else
                            {
                                viewExam.Columns["QTY"].OptionsColumn.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void viewExam_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                string strqty = e.FocusedColumn.FieldName;
                if (viewExam.FocusedRowHandle > -1)
                {
                    DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                    if (dr["EXAM_UID"].ToString() != string.Empty)
                    {
                        if (strqty == "QTY")
                        {
                            string _bpview_id = string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString()) ? "5" : dr["BPVIEW_ID"].ToString();
                            DataRow[] drbp = dttBpview.Copy().Select("BPVIEW_ID =" + _bpview_id);
                            if (drbp[0]["BPVIEW_NAME"].ToString() == "Other")
                            {
                                viewExam.Columns["QTY"].OptionsColumn.ReadOnly = false;
                            }
                            else
                            {
                                viewExam.Columns["QTY"].OptionsColumn.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void rountineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urgentToolStripMenuItem.Image = null;
            statToolStripMenuItem.Image = null;
            rountineToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            dr["SCHEDULE_PRIORITY"] = "R";
            dr["PRIORITY_TEXT"] = "Routine";
            viewExam.RefreshData();
        }
        private void urgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rountineToolStripMenuItem.Image = null;
            statToolStripMenuItem.Image = null;
            urgentToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            dr["SCHEDULE_PRIORITY"] = "U";
            dr["PRIORITY_TEXT"] = "Urgent";
            viewExam.RefreshData();
        }
        private void statToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rountineToolStripMenuItem.Image = null;
            urgentToolStripMenuItem.Image = null;
            statToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            dr["SCHEDULE_PRIORITY"] = "S";
            dr["PRIORITY_TEXT"] = "Stat";
            viewExam.RefreshData();
        }
        #endregion

        #region Start/End DateTime
        private void dtStart_Enter(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }
        private void dtStart_EditValueChanged(object sender, System.EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }
        private void dtEnd_Enter(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }
        private void dtEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }

        private void timeStart_Enter(object sender, EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false) doDateValidated();
        }
        private void timeStart_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false) doDateValidated();
        }
        private void timeEnd_Enter(object sender, EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false) doDateValidated();
        }
        private void timeEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false) doDateValidated();
        }
        #endregion

        #region ExamPanel.
        private void initiateExamPanel()
        {
            ProcessGetRISExam proc = new ProcessGetRISExam();
            dttExamPanel = new DataTable();
            dttExamPanel = proc.GetExamPanel();
        }
        private bool haveExamData(DataTable dtt, string ExamID)
        {
            DataRow[] rows = dtt.Select("EXAM_ID=" + ExamID);
            return rows.Length == 0 ? false : true;
        }
        private void calExamPanel(string ExamID)
        {
            DataRow[] rows = dttExamPanel.Select("EXAM_ID=" + ExamID);
            if (rows.Length > 0)
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow[] rowsExam = dataExam.Select("EXAM_ID=" + rows[i]["AUTO_EXAM_ID"].ToString());
                    if (!haveExamData(dttExam, rowsExam[0]["EXAM_ID"].ToString()))
                    {
                        DataRow dr = dttExam.NewRow();
                        dr["EXAM_ID"] = rowsExam[0]["EXAM_ID"];
                        dr["EXAM_UID"] = rowsExam[0]["EXAM_ID"];
                        dr["EXAM_NAME"] = rowsExam[0]["EXAM_ID"];
                        DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype);
                        string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                        switch (clinictypeName.ToUpper())
                        {
                            case "SPECIAL": dr["RATE"] = patient.NON_RESIDENCE == "Y" ? rowsExam[0]["FOREIGN_SPCIAL_RATE"].ToString() : rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                            case "VIP": dr["RATE"] = patient.NON_RESIDENCE == "Y" ? rowsExam[0]["FOREIGN_VIP_RATE"].ToString() : rowsExam[0]["VIP_RATE"].ToString(); break;
                            default: dr["RATE"] = patient.NON_RESIDENCE == "Y" ? rowsExam[0]["FOREIGN_RATE"].ToString() : rowsExam[0]["RATE"].ToString(); break;
                        }
                        dr["QTY"] = 1;
                        dr["BPVIEW_ID"] = 0;
                        if (rowsExam[0]["AVG_REQ_MIN"].ToString().Trim().Length > 0)
                            dr["AVG_REQ_MIN"] = rowsExam[0]["AVG_REQ_MIN"];
                        else
                            dr["AVG_REQ_MIN"] = avg_inv_time;
                        dr["SCHEDULE_PRIORITY"] = dttExam.Select("EXAM_ID=" + ExamID)[0]["SCHEDULE_PRIORITY"];
                        dttExam.Rows.Add(dr);
                    }
                }
                dttExam.AcceptChanges();
            }
        }
        #endregion

        public DataRow RowAppointment
        {
            get;
            set;
        }
        public int SCHEDULE_ID
        {
            get;
            set;
        }
        public void updateSourceSchedule(RIS_SCHEDULE process)
        {
            DataTable dtt = dttAppointment.Clone();
            RowAppointment = dtt.NewRow();
            DataRow[] rows = dttAppointment.Select("SCHEDULE_ID=" + process.SCHEDULE_ID);
            RowAppointment["SCHEDULE_ID"] = process.SCHEDULE_ID;
            RowAppointment["REG_ID"] = process.REG_ID;
            RowAppointment["SCHEDULE_DT"] = process.SCHEDULE_DT;
            RowAppointment["MODALITY_ID"] = process.MODALITY_ID;
            RowAppointment["SCHEDULE_DATA"] = process.SCHEDULE_DATA;
            RowAppointment["SESSION_ID"] = process.SESSION_ID;
            RowAppointment["START_DATETIME"] = process.START_DATETIME;
            RowAppointment["END_DATETIME"] = process.END_DATETIME;
            RowAppointment["REF_UNIT"] = process.REF_UNIT;
            RowAppointment["REF_DOC"] = process.REF_DOC;
            RowAppointment["PAT_STATUS"] = process.PAT_STATUS;
            RowAppointment["LMP_DT"] = process.LMP_DT;
            RowAppointment["SCHEDULE_STATUS"] = "S";
            RowAppointment["IS_BLOCKED"] = process.IS_BLOCKED.ToString();
            RowAppointment["ORG_ID"] = env.OrgID;
            RowAppointment["INSURANCE_TYPE_ID"] = process.INSURANCE_TYPE_ID;
            RowAppointment["HN"] = txtHN.Text;
            RowAppointment["CommandType"] = "N";
            SCHEDULE_ID = process.SCHEDULE_ID;
        }

        private void barRecurrence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chkBlock.Checked == false)
            {
                if (checkHaveExamData() == false)
                {
                    msg.ShowAlert("UID0046", env.CurrentLanguageID);
                    grdExam.Focus();
                    return;
                }
            }
            if (msg.ShowAlert("UID1135", env.CurrentLanguageID) == "1")
                return;
            Appointment editedAptCopy = controller.EditedAppointmentCopy;
            Appointment editedPattern = controller.EditedPattern;
            Appointment patternCopy = controller.PrepareToRecurrenceEdit();
            AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek, controller);
            dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
            DialogResult result = dlg.ShowDialog(this);
            dlg.Dispose();
            if (result == DialogResult.Abort)
                controller.RemoveRecurrence();
            else
                if (result == DialogResult.OK)
                {
                    controller.ApplyRecurrence(patternCopy);
                    
                    dtStart.DateTime = controller.DisplayStart.Date;
                    dtEnd.DateTime = controller.DisplayEnd.Date;
                    timeStart.Time = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                    timeEnd.Time = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);
                    //chkAllDay.Checked = controller.AllDay;
                }
        }

        private string getRadilogyName(string EMP_ID)
        {
            string name = string.Empty;
            DataRow[] rs = dttDoctor.Select("EMP_ID=" + EMP_ID);
            if (rs.Length > 0)
                name = rs[0]["FNAME"].ToString() + " " + rs[0]["LNAME"].ToString();
            return name;
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            //frmScheduleSummary frm = new frmScheduleSummary(txtHN.Text, schedule_id);
            //frm.ShowDialog();
            //frm.Dispose();
            //int regID = txtHN.Tag == null ? 0 : Convert.ToInt32(txtHN.Tag.ToString());
            this._summary.ShowDialog(true, txtHN.Text, schedule_id, 0, frmPopupOrderOrScheduleSummary.PagesModes.Schedule, false);
        }

        private void chkNonResident_EditValueChanged(object sender, EventArgs e)
        {
            dttExam = (DataTable)grdExam.DataSource;
            if (chkNonResident.Checked)
            {
                chkNonResident.ForeColor = Color.Red;
                foreach (DataRow drExam in dttExam.Rows)
                {
                    if (string.IsNullOrEmpty(drExam["EXAM_ID"].ToString())) break;
                    DataRow[] rows = dataExam.Select("EXAM_ID=" + drExam["EXAM_ID"].ToString());
                    if (rows.Length > 0)
                    {
                        if (chkNonResident.Checked)
                            drExam["RATE"] = rows[0]["FOREIGN_RATE"].ToString();
                    }
                }
            }
            else
            {
                chkNonResident.ForeColor = Color.Black;

                foreach (DataRow drExam in dttExam.Rows)
                {
                    if (string.IsNullOrEmpty(drExam["EXAM_ID"].ToString())) break;
                    DataRow[] rows = dataExam.Select("EXAM_ID=" + drExam["EXAM_ID"].ToString());
                    if (rows.Length > 0)
                    {
                        DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype);
                        string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                        switch (clinictypeName.ToUpper())
                        {
                            case "SPECIAL":
                                drExam["RATE"] = rows[0]["SPECIAL_RATE"].ToString();
                                break;
                            case "VIP":
                                drExam["RATE"] = rows[0]["VIP_RATE"].ToString();
                                break;
                            default:
                                drExam["RATE"] = rows[0]["RATE"].ToString();
                                break;
                        }
                    }
                }
            }
            calTotal();
            calculateTime();
            viewExam.RefreshData();
        }

        private void txtSession_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == grdExam)
                {
                    GridView view = grdExam.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "FLAG_ICON":
                                    if (!string.IsNullOrEmpty(rowDetail["FLAG_ICON"].ToString()))
                                        if (rowDetail["FLAG_ICON"].ToString() != "0")
                                        {
                                            DataRow[] rowFlag = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowDetail["EXAMFLAG_ID"].ToString());
                                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowFlag[0]["GEN_TEXT"].ToString());
                                            return;
                                        }
                                    break;
                                case "SCHEDULE_PRIORITY":
                                    if (!string.IsNullOrEmpty(rowDetail["PRIORITY_TEXT"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["PRIORITY_TEXT"].ToString());
                                        return;
                                    }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.GroupPanel)
                    {
                        info = new ToolTipControlInfo(hi.HitTest, "Group panel");
                        return;
                    }

                    if (hi.HitTest == GridHitTest.RowIndicator)
                    {
                        info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                        return;
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                            case "SCHEDULE_PRIORITY": info = new ToolTipControlInfo(hi.HitTest, "Priority"); break;
                        }
                    }
                }
            }
            finally
            {
                e.Info = info;
            }
        }

        private void contextcmb_DropDownClosed(object sender, EventArgs e)
        {
            if (viewExam.FocusedRowHandle >= 0)
            {
                DataRow rowDtl = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                DataRow[] rowCheck = dttExamFlag.Select("EXAM_ID=" + rowDtl["EXAM_ID"].ToString());
                int flag_id = 0;
                int order_id = 0;
                int schedule_id = 0;
                int xrayreq_id = 0;
                if (rowCheck.Length > 0)
                {
                    order_id = string.IsNullOrEmpty(rowCheck[0]["ORDER_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["ORDER_ID"]);
                    schedule_id = string.IsNullOrEmpty(rowCheck[0]["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["SCHEDULE_ID"]);
                    xrayreq_id = string.IsNullOrEmpty(rowCheck[0]["XRAYREQ_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["XRAYREQ_ID"]);
                    flag_id = string.IsNullOrEmpty(rowCheck[0]["FLAG_ID"].ToString()) ? 0 : Convert.ToInt32(rowCheck[0]["FLAG_ID"]);
                    dttExamFlag.Rows.Remove(rowCheck[0]);
                }
                dttExamFlag.AcceptChanges();

                TraumaItems trauma = contextcmb.SelectedItem as TraumaItems;
                DataRow rowAdd = dttExamFlag.NewRow();
                rowAdd["FLAG_ID"] = flag_id;
                rowAdd["ORDER_ID"] = order_id;
                rowAdd["SCHEDULE_ID"] = schedule_id;
                rowAdd["XRAYREQ_ID"] = xrayreq_id;
                rowAdd["EXAM_ID"] = rowDtl["EXAM_ID"].ToString();
                rowAdd["EXAMFLAG_ID"] = trauma.Trauma_id();
                rowAdd["REASON"] = "";
                dttExamFlag.Rows.Add(rowAdd);
                dttExamFlag.AcceptChanges();

                DataRow rowData = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                rowData["FLAG_ICON"] = trauma.Trauma_id() == 72 ? 0 : trauma.Trauma_Seq();
                rowData["EXAMFLAG_ID"] = trauma.Trauma_id();
                viewExam.RefreshData();
            }
        }

        private void chkRequestResult_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRequestResult.Checked)
            {
                dtRequestResult.Enabled = true;
                timeReqeustResult.Enabled = true;
            }
            else
            {
                dtRequestResult.Enabled = false;
                timeReqeustResult.Enabled = false;
            }
        }

        private void pictureEdit1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmCheckFreeSlots frm = new frmCheckFreeSlots(Convert.ToInt32(apt.ResourceId));
            frm.dateNavSelected = dtStart.DateTime;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DateTime resultDate = frm.dateNavSelected;
                dtStart.DateTime = new DateTime(resultDate.Year, resultDate.Month, resultDate.Day, dtStart.DateTime.Hour, dtStart.DateTime.Minute, dtStart.DateTime.Second);
                dtEnd.DateTime = new DateTime(resultDate.Year, resultDate.Month, resultDate.Day, dtEnd.DateTime.Hour, dtEnd.DateTime.Minute, dtEnd.DateTime.Second);
            }
        }



    }
}   