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
namespace Envision.NET.Forms.Schedule
{
    public partial class frmAppointmentEdit :DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SchedulerControl control;
        private Appointment apt;

        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private Patient patient;
        private DataTable dttExamModality;
        private DataTable dttModalityClinic;
        private DataTable dttSession;
        private DataTable dtImageScan;
        private DataTable dttAppointment;
        private DataTable dttExamPanel;
        private DataTable dataExam;
        private DataTable dttExam;
        private List<int> delExamItem;
        private int avg_inv_time;

        private int pat_id,schedule_id,clinictype;
        private string HN;
        private bool is_block;
        private MyAppointmentFormController controller;

        public frmAppointmentEdit(SchedulerControl control, Appointment apt,DataTable Data)
        {
            this.apt = apt;
            this.control = control;
            controller = new MyAppointmentFormController(control, apt);
            InitializeComponent();
            initControlFirst();
            delExamItem = new List<int>();
            dttAppointment = Data;
            txtID.Focus();
        }
        public frmAppointmentEdit(SchedulerControl control, Appointment apt,string mode)
        {
            if (mode == "Past")
            {

                this.apt = apt;
                this.control = control;
                controller = new MyAppointmentFormController(control, apt);
                InitializeComponent();
                initControlFirst();

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
        }

        private void frmAppointmentEdit_Load(object sender, EventArgs e)
        {
            txtHN.Focus();
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
            deLMP.DateTime = DateTime.Now;
        }
        private void doTimerValidated()
        {

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
            DataTable dtt = new DataTable();
            dtt = RISBaseData.His_Department();
            for (int i = 0; i < dtt.Rows.Count; i++)
                Dep.Add(dtt.Rows[i]["UNIT_UID"].ToString() + ":" + dtt.Rows[i]["UNIT_NAME"].ToString());
            dtt = new DataTable();
            dtt = RISBaseData.His_Doctor();
            for (int i = 0; i < dtt.Rows.Count; i++)
                Doc.Add(dtt.Rows[i]["EMP_UID"].ToString() + ":" + dtt.Rows[i]["RadioName"].ToString());

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
                    deLMP.DateTime = DateTime.Today;
                    lblLMP.Visible = true;
                    deLMP.Visible = true;
                }
                if (string.IsNullOrEmpty(patient.Phone1))
                    txtPhone.Text = patient.Phone2;
                else
                    txtPhone.Text = patient.Phone1 + "," + patient.Phone2;

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
                        unit.Invoke();
                        dtt = unit.Result.Tables[0].Copy();
                        drExam = dtt.Select("UNIT_ID=" + id.ToString());
                        if (drExam.Length > 0)
                        {
                            txtOrderDept.Tag = drExam[0]["UNIT_ID"].ToString();
                            txtOrderDept.Text = drExam[0]["UNIT_UID"].ToString()+":"+drExam[0]["UNIT_NAME"].ToString();
                        }
                    }
                }
                if (txtOrderDoc.Tag != null)
                {
                    if (int.TryParse(txtOrderDoc.Tag.ToString(), out id))
                    {
                        ProcessGetHISDoctor doc = new ProcessGetHISDoctor();
                        doc.Invoke();
                        dtt = doc.Result.Tables[0].Copy();
                        drExam = dtt.Select("EMP_ID=" + id.ToString());
                        if (drExam.Length > 0)
                        {
                            txtOrderDoc.Tag = drExam[0]["EMP_ID"].ToString();
                            txtOrderDoc.Text = drExam[0]["EMP_UID"].ToString() + ":" + drExam[0]["RadioName"].ToString();
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
            }
            else
            {
                txtHN.Text = string.Empty;
                clearContextControl();
                enableDisableControl();
                groupPatient.Enabled = true;
                groupTiming.Enabled = true;
                initGridAppointment("00");
            }
        }
        private void fillDataToCtrl(DataRow dr)
        {
            DataRow[] drExam = null;
            fillDemographic();

            #region Group Timing.
            DateTime start = Convert.ToDateTime(dr["START_DATETIME"].ToString());
            DateTime end = Convert.ToDateTime(dr["END_DATETIME"].ToString());
            dtStart.DateTime = start;
            dtEnd.DateTime = end;
            timeStart.Time = start;
            timeEnd.Time = end;
            txtReason.Text = dr["REASON"].ToString();
            #endregion

            #region Group Visit.
            int id = 0;
            DataTable dtt = new DataTable();
            if (!string.IsNullOrEmpty(dr["REF_UNIT"].ToString()))
            {
                if (int.TryParse(dr["REF_UNIT"].ToString(), out id))
                {
                    ProcessGetHRUnit unit = new ProcessGetHRUnit();
                    unit.Invoke();
                    dtt = unit.Result.Tables[0].Copy();
                    drExam = dtt.Select("UNIT_ID=" + id.ToString());
                    if (drExam.Length > 0)
                    {
                        txtOrderDept.Tag = drExam[0]["UNIT_ID"].ToString();
                        txtOrderDept.Text =  drExam[0]["UNIT_NAME"].ToString();//drExam[0]["UNIT_UID"].ToString() + ":" +
                    }
                }

            }
            id = 0;
            if (!string.IsNullOrEmpty(dr["REF_DOC"].ToString()))
            {
                if (int.TryParse(dr["REF_DOC"].ToString(), out id))
                {
                    ProcessGetHISDoctor doc = new ProcessGetHISDoctor();
                    doc.Invoke();
                    dtt = doc.Result.Tables[0].Copy();
                    drExam = dtt.Select("EMP_ID=" + id.ToString());
                    if (drExam.Length > 0)
                    {
                        txtOrderDoc.Tag = drExam[0]["EMP_ID"].ToString();
                        txtOrderDoc.Text = drExam[0]["EMP_UID"].ToString() + ":" + drExam[0]["RadioName"].ToString();
                    }
                }
            }
            #endregion

            if ((dr["SCHEDULE_STATUS"].ToString().ToUpper() == "O") || (dr["IS_BLOCKED"].ToString() == "Y"))
            {
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                groupTiming.Enabled = false;
                groupReason.Enabled = false;

                chkBlock.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnScan.Enabled = false;
                btnSavePrint.Enabled = false;


                if (dr["IS_BLOCKED"].ToString() == "Y")
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
                    txtHN.Text = "BLOCK";
                    txtFName.Text = string.Empty;
                    txtLName.Text = string.Empty;
                    txtFName_Eng.Text = string.Empty;
                    txtLName_Eng.Text = string.Empty;
                    txtID.Text = string.Empty;
                    cboGender.SelectedIndex = 0;
                    txtPhone.Text = string.Empty;
                    //txtMobile.Text = string.Empty;
                    #endregion

                    chkBlock.Checked = true;
                    groupTiming.Enabled = true;
                    chkBlock.Enabled = true;
                    groupReason.Enabled = true;
                    txtAGE.Text = string.Empty;
                    is_block = true;
                }
            }

            DataTable data = RISBaseData.His_Department();
            DataRow[] drs;
            try
            {
                drs = data.Select("UNIT_ID=" + dr["REF_UNIT"].ToString());
                if (drs.Length > 0)
                {
                    txtOrderDept.Tag = drs[0]["UNIT_ID"].ToString();
                    txtOrderDept.Text =drs[0]["UNIT_UID"].ToString() + ":" +  drs[0]["UNIT_NAME"].ToString();
                }
            }
            catch { txtOrderDept.Text = ""; }
            data = RISBaseData.Ris_Radiologist();
            try
            {
                drs = data.Select("EMP_ID=" + dr["REF_DOC"].ToString());

                if (drs.Length > 0)
                {
                    txtOrderDoc.Tag = patient.REF_DOC;
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

                    proc = new ProcessGetRISSchedule(schedule_id);
                    proc.Invoke();
                    DataTable dt = proc.Result.Tables[0].Copy();
                    dttExam = new DataTable();
                    dttExam = proc.Result.Tables[1].Copy();
                 
                    HN = dt.Rows[0]["HN"].ToString();

                    patient = new Envision.BusinessLogic.Patient(HN, true);
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
                    DataTable dttOrder = RISBaseData.His_Doctor();
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
                            deLMP.DateTime = DateTime.Now;
                        else if (Convert.ToDateTime(dt.Rows[0]["LMP_DT"]) == DateTime.MinValue)
                            deLMP.DateTime = DateTime.Now;
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
                    env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
                    //env.CountImg = string.Empty;
                    //env.PixPic = IntPtr.Zero;
                    //env.PixPic2 = IntPtr.Zero;
                    //env.PixPic3 = IntPtr.Zero;
                    //env.BmpPic = IntPtr.Zero;
                    //env.BmpPic2 = IntPtr.Zero;
                    //env.BmpPic3 = IntPtr.Zero;
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
                        row["RATE"] = rs[0]["SPECIAL_RATE"].ToString();
                        break;
                    case "VIP":
                        row["RATE"] = rs[0]["VIP_RATE"].ToString();
                        break;
                    default:
                        row["RATE"] = rs[0]["RATE"].ToString();
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
            lv.Text = "Prepation Search";

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
            DataTable dtRadio = RISBaseData.Ris_Radiologist();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(RadiologistLookup_ValueUpdated);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.AddColumn("EMP_UID", "Code", true, true);
            lv.AddColumn("RadioName", "Radiologist Name", true, true);
            lv.AddColumn("AUTH_LEVEL_ID", "LEVEL", false, true);
            lv.Text = "Radiologist Detail List";

            lv.Data = dtRadio;
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


            DataRow[] drDoc = RISBaseData.His_Doctor().Select("EMP_UID='" + retValue[3].Trim() + "'");
            txtOrderDoc.Tag = drDoc[0]["EMP_ID"].ToString();
            DataRow[] drDept = RISBaseData.His_Department().Select("UNIT_UID='" + retValue[5].Trim() + "'");
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
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHN.Text.Trim().Length == 0)
                {
                  txtHN.Text = apt.Subject;
                        return;
                }
                
                if (txtHN.Text.Trim().Length == 0)
                {
                    txtHN.Text = apt.Subject;
                    return;
                }
                Patient  p = new Patient(txtHN.Text);
                if (!p.LinkDown)
                {
                    if (p.HasHN)
                    {
                        #region Fill patient data to Control.
                        patient = new Patient(txtHN.Text);
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
                        #endregion
                    }
                    else
                    {
                        #region Patient Not found.
                        msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                        clearContextControl();
                        enableDisableControl(); 
                        #endregion
                    }
                }
                patient = new Patient(txtHN.Text, true);

                if (patient.HasHN)
                {
                    string s = msg.ShowAlert("UID1016", env.CurrentLanguageID);
                    if (s == "1")
                        waitConnectionHIS();
                    else if (s == "2")
                        createPatientDemographic();
                    else
                    {
                        fillDemographic();
                        txtHN.Text = HN;
                        grdLvPatStatus.Focus();
                    }
                }
                else
                {
                    string s = msg.ShowAlert("UID1015", env.CurrentLanguageID);
                    if (s == "1")
                        waitConnectionHIS();
                    else
                        createPatientDemographic();
                }
            }
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
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
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
                DataTable dtt = RISBaseData.His_Department();
                foreach (DataRow dr in dtt.Rows)
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
                DataTable dtt = RISBaseData.His_Doctor();// myOrder.HIS_Doctor();
                foreach (DataRow dr in dtt.Rows)
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
                txtFName_Eng.Text = Miracle.Translator.TransToEnglish.Trans(txtFName.Text);
            if (txtFName.Text.Trim().Length == 0)
                txtFName_Eng.Text = string.Empty;
        }
        private void txtLName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLName_Eng.Text.Trim().Length == 0 && txtLName.Text.Trim().Length > 0)
                txtLName_Eng.Text = Miracle.Translator.TransToEnglish.Trans(txtLName.Text);
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
                if (txtReason.Text.Trim().Length == 0)
                {
                    msg.ShowAlert("UID1109", env.CurrentLanguageID);
                    txtReason.Focus();
                    return false;
                }
            }
            #endregion

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
                pAddHIS.HIS_REGISTRATION.LNAME_ENG =  txtLName_Eng.Text;
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
            else if (patient.DataFromHIS)
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
                pAddHIS.Invoke();
                regID = pAddHIS.HIS_REGISTRATION.REG_ID;
            }
            else
            { 
                //Data from local
                ProcessAddHISRegistration pHIS = new ProcessAddHISRegistration(true);
                pHIS.HIS_REGISTRATION.ADDR1 = string.Empty;
                pHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                pHIS.HIS_REGISTRATION.FNAME = txtFName.Text;
                pHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text;
                pHIS.HIS_REGISTRATION.GENDER = cboGender.SelectedIndex == 0 ? Convert.ToChar("M") : Convert.ToChar("F");
                pHIS.HIS_REGISTRATION.HN = txtHN.Text;
                pHIS.HIS_REGISTRATION.LNAME = txtLName.Text;
                pHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text;
                pHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                pHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
                pHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
                pHIS.HIS_REGISTRATION.SSN = txtID.Text;
                pHIS.HIS_REGISTRATION.TITLE = string.Empty;
                pHIS.HIS_REGISTRATION.TITLE_ENG = string.Empty;
                pHIS.HIS_REGISTRATION.LINK_DOWN = 'Y';
                pHIS.HIS_REGISTRATION.INSURANCE_TYPE = string.Empty;
                pHIS.Invoke();
                regID = pHIS.HIS_REGISTRATION.REG_ID;
                patient.Reg_UID = txtHN.Text;
            }
           
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
            process.RIS_SCHEDULE.LMP_DT = deLMP.DateTime;
            process.RIS_SCHEDULE.LOCATION = string.Empty;
            process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId);
            process.RIS_SCHEDULE.ORG_ID = env.OrgID;
            process.RIS_SCHEDULE.PAT_STATUS = pat_id;
            process.RIS_SCHEDULE.REASON = txtReason.Text.Trim();
            process.RIS_SCHEDULE.REASON_CHANGE = txtInputReason.Text.Trim();
            process.RIS_SCHEDULE.REF_DOC = txtOrderDoc.Tag == null ? 0 : Convert.ToInt32(txtOrderDoc.Tag.ToString()); 
            process.RIS_SCHEDULE.REF_DOC_INSTRUCTION = string.Empty;
            process.RIS_SCHEDULE.REF_UNIT=txtOrderDept.Tag == null ? 0 : Convert.ToInt32(txtOrderDept.Tag.ToString());
            process.RIS_SCHEDULE.SCHEDULE_DT = dtApp;
            process.RIS_SCHEDULE.SCHEDULE_ID = schedule_id;
            process.RIS_SCHEDULE.REG_ID = regID;
            process.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
            process.RIS_SCHEDULE.SESSION_ID = txtSession.Tag == null ? 0 : Convert.ToInt32(txtSession.Tag.ToString());
            if (dttExam.Rows.Count == 1)
            {
                process.RIS_SCHEDULE.SCHEDULE_DATA = "HN : " + txtHN.Text + " " + patient.Title + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                DataRow[] rs = dataExam.Select("EXAM_ID=" + dttExam.Rows[0]["EXAM_ID"].ToString());
                process.RIS_SCHEDULE.SCHEDULE_DATA += "  " + rs[0]["EXAM_NAME"].ToString().Trim();
                if (!string.IsNullOrEmpty(dttExam.Rows[0]["EMP_ID"].ToString()))
                    process.RIS_SCHEDULE.SCHEDULE_DATA += " (" + getRadilogyName(dttExam.Rows[0]["EMP_ID"].ToString()) + ") ";
            }
            else
            {
                process.RIS_SCHEDULE.SCHEDULE_DATA = "HN : " + txtHN.Text + " " + patient.Title + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                process.RIS_SCHEDULE.SCHEDULE_DATA += "\r\n";
                foreach (DataRow dr in dttExam.Rows)
                {
                    DataRow[] rs = dataExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                    process.RIS_SCHEDULE.SCHEDULE_DATA += rs[0]["EXAM_NAME"].ToString().Trim();// +"; ";
                    if (!string.IsNullOrEmpty(dr["EMP_ID"].ToString()))
                        process.RIS_SCHEDULE.SCHEDULE_DATA += " (" + getRadilogyName(dr["EMP_ID"].ToString()) + ") ; ";
                    else
                        process.RIS_SCHEDULE.SCHEDULE_DATA += "; ";
                }
                process.RIS_SCHEDULE.SCHEDULE_DATA = process.RIS_SCHEDULE.SCHEDULE_DATA.Remove(process.RIS_SCHEDULE.SCHEDULE_DATA.LastIndexOf(';'), 1);
            }
            process.RIS_SCHEDULE.START_DATETIME = start;
            DateTime edt = (DateTime)timeEnd.EditValue;
            edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute,0);
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
                foreach (DataRow dr in dttExam.Rows) {
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
                        procDtl.Invoke();
                        #endregion
                    }
                    else {
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
                        procUp.Invoke();
                        #endregion
                    }
                
                }
                #endregion

                #region Update AppointmentData.
                //for (int i = 0; i < dttAppointment.Rows.Count; i++) {
                //    if (dttAppointment.Rows[i]["SCHEDULE_ID"].ToString() == schedule_id.ToString()) {
                //        DataRow nw = dttAppointment.Rows[i];
                //        nw["SCHEDULE_ID"] = process.RIS_SCHEDULE.SCHEDULE_ID;
                //        nw["REG_ID"] = regID;
                //        nw["SCHEDULE_DT"] = process.RIS_SCHEDULE.SCHEDULE_DT;
                //        nw["MODALITY_ID"] = process.RIS_SCHEDULE.MODALITY_ID;
                //        nw["SCHEDULE_DATA"] = process.RIS_SCHEDULE.SCHEDULE_DATA;
                //        nw["SESSION_ID"] = process.RIS_SCHEDULE.SESSION_ID;
                //        nw["START_DATETIME"] = process.RIS_SCHEDULE.START_DATETIME;
                //        nw["END_DATETIME"] = process.RIS_SCHEDULE.END_DATETIME;
                //        nw["PAT_STATUS"] = process.RIS_SCHEDULE.PAT_STATUS;
                //        nw["SCHEDULE_STATUS"] = process.RIS_SCHEDULE.SCHEDULE_STATUS;
                //        nw["IS_BLOCKED"] = 'N';
                //        nw["CommandType"] = "N";
                //        dttAppointment.AcceptChanges();
                //        break;
                //    }
                //}
                //updateSourceSchedule(process.RIS_SCHEDULE);
                SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
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
            //Envision.Operational.Scanner.SaveScannedImage save = null;
            //if (dtImageScan == null)
            //{
            //    save = new Envision.Operational.Scanner.SaveScannedImage(patient.Reg_UID, process.RISSchedule.SCHEDULE_ID, "Schedule");
            //}
            //else
            //{
            //    save = new Envision.Operational.Scanner.SaveScannedImage(patient.Reg_UID, process.RISSchedule.SCHEDULE_ID, dtImageScan, "Schedule");
            //}
            ScanImage save = null;
            //ProcessGetRISOrderimages img = new ProcessGetRISOrderimages();
            //img.RIS_ORDERIMAGE.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
            //img.Invoke();
            //dtImageScan = new DataTable();
            //dtImageScan = img.Result.Tables[0];

            


            if (dtImageScan == null)
                save = new ScanImage(patient.Reg_UID, process.RIS_SCHEDULE.SCHEDULE_ID, "Schedule");
            else
                save = new ScanImage(patient.Reg_UID, process.RIS_SCHEDULE.SCHEDULE_ID, dtImageScan, "Schedule");
                        #endregion
            env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
            //new GBLEnvVariable().CountImg = "";
            //new GBLEnvVariable().PixPic = IntPtr.Zero;
            //new GBLEnvVariable().PixPic2 = IntPtr.Zero;
            //new GBLEnvVariable().PixPic3 = IntPtr.Zero;
            //new GBLEnvVariable().BmpPic = IntPtr.Zero;
            //new GBLEnvVariable().BmpPic2 = IntPtr.Zero;
            //new GBLEnvVariable().BmpPic3 = IntPtr.Zero;
            return true;
        }
        private bool updateBlockData() {
            ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            end = end.Subtract(ts);

            process.RIS_SCHEDULE.START_DATETIME = start;
            process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
            process.RIS_SCHEDULE.END_DATETIME = end;
            process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
            process.RIS_SCHEDULE.ORG_ID = env.OrgID;
            process.RIS_SCHEDULE.REASON = txtReason.Text;
            process.RIS_SCHEDULE.SCHEDULE_DATA = "BLOCK - " + txtReason.Text;
            process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(apt.Location);
            process.UpdateBlock();
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

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            if (chkBlock.Checked)
            {
                if (txtReason.Text.Trim().Length == 0)
                {
                    msg.ShowAlert("UID1109", env.CurrentLanguageID);
                    txtReason.Focus();
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
                deleteEmptyRow();
                updateAppointmentData();
            }
           
        }
        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                deleteEmptyRow();
                if (updateAppointmentData())
                {
                    if (dttExam.Rows.Count == 1)
                    {
                            #region Single Exam.
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

                            ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                            geExam.Invoke();
                            DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_UID='" + dts.Rows[0]["EXAM_UID"].ToString() + "'");
                            if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                            {
                                if (drExam[0]["UNIT_ID"].ToString() == "2")
                                {
                                    //if (txtOrderDept.Text.Contains("OER101"))
                                    if (txtModality.Text.Trim() == "CTER")
                                    {
                                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                        print.ScheduleDirectPrintMultiER(dts);
                                    }
                                    else
                                    {
                                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                        print.ScheduleDirectPrintMultiAIMC(dts);
                                    }
                                }
                                else
                                {
                                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                    print.ScheduleDirectPrintMulti(dts);
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
                    //ProcessGetRISSchedule geSch = new ProcessGetRISSchedule(schedule_id);
                    //geSch.Invoke();
                    //DataTable dtt = geSch.Result.Tables[0];
                    //ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                    //geExam.Invoke();
                    //DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_ID=" + dtt.Rows[0]["EXAM_ID"].ToString());
                    //if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                    //{
                    //    if (drExam[0]["UNIT_ID"].ToString() == "2")
                    //    {

                    //        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    //        print.ScheduleDirectPrintAIMC(patient.Reg_UID, dtStart.DateTime, Convert.ToInt32(apt.ResourceId.ToString()), schedule_id);
                    //    }
                    //    else
                    //    {
                    //        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    //        print.ScheduleDirectPrint(patient.Reg_UID, dtStart.DateTime, Convert.ToInt32(apt.ResourceId.ToString()), schedule_id);
                    //    }
                    //}
                }
            }
        }
        private void btnScan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHN.Text))
            {
                //Miracle.Scanner.PointerStruct[] p = PointerStruct.GetPointerStruct();
                PointerStruct.ImageUrl = env.PacsUrl2;

                Order thisOrder = new Order();
                ProcessGetRISOrderimages geImage = new ProcessGetRISOrderimages();
                geImage.RIS_ORDERIMAGE.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                geImage.Invoke();
                DataTable dttIm = geImage.Result.Tables[0];
                DataView dvv = new DataView(dttIm.Copy());

                if (dttIm.Rows.Count > 0)
                {
                    //p[0].Bmp = IntPtr.Zero;
                    //p[1].Bmp = IntPtr.Zero;
                    //p[2].Bmp = IntPtr.Zero;
                    //p[0].Pix = IntPtr.Zero;
                    //p[1].Pix = IntPtr.Zero;
                    //p[2].Pix = IntPtr.Zero;

                    //p[0].Bmp = env.BmpPic;
                    //p[1].Bmp = env.BmpPic2;
                    //p[2].Bmp = env.BmpPic3;

                    //p[0].Pix = env.PixPic;
                    //p[1].Pix = env.PixPic2;
                    //p[2].Pix = env.PixPic3;

                    //Miracle.Scanner.EditImageOrder editFrm = new Miracle.Scanner.EditImageOrder(dttIm, p);
                    Miracle.Scanner.EditImageOrder editFrm = new Miracle.Scanner.EditImageOrder(dttIm, env.PixPicture);
                    editFrm.StartPosition = FormStartPosition.CenterParent;
                    editFrm.ShowDialog();
                    if (editFrm.DialogResult == DialogResult.Yes)
                    {
                        thisOrder.Ris_OrderImage = editFrm.Data.Copy();
                        //env.PixPic = editFrm.PictureStruct[0].Pix;
                        //env.PixPic2 = editFrm.PictureStruct[1].Pix;
                        //env.PixPic3 = editFrm.PictureStruct[2].Pix;

                        //env.BmpPic = editFrm.PictureStruct[0].Bmp;
                        //env.BmpPic2 = editFrm.PictureStruct[1].Bmp;
                        //env.BmpPic3 = editFrm.PictureStruct[2].Bmp;

                        //env.CountImg = editFrm.ImageCount.ToString();
                        env.PixPicture = editFrm.PictureStruct;
                        dtImageScan = editFrm.Data;
                    }

                }
                else
                {

                    //p[0].Bmp = IntPtr.Zero;
                    //p[1].Bmp = IntPtr.Zero;
                    //p[2].Bmp = IntPtr.Zero;
                    //p[0].Pix = IntPtr.Zero;
                    //p[1].Pix = IntPtr.Zero;
                    //p[2].Pix = IntPtr.Zero;

                    //p[0].Bmp = env.BmpPic;
                    //p[1].Bmp = env.BmpPic2;
                    //p[2].Bmp = env.BmpPic3;

                    //p[0].Pix = env.PixPic;
                    //p[1].Pix = env.PixPic2;
                    //p[2].Pix = env.PixPic3;

                    Miracle.Scanner.NewScan frm = new Miracle.Scanner.NewScan(env.PixPicture);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        //env.PixPic = frm.PictureStruct[0].Pix;
                        //env.PixPic2 = frm.PictureStruct[1].Pix;
                        //env.PixPic3 = frm.PictureStruct[2].Pix;

                        //env.BmpPic = frm.PictureStruct[0].Bmp;
                        //env.BmpPic2 = frm.PictureStruct[1].Bmp;
                        //env.BmpPic3 = frm.PictureStruct[2].Bmp;

                        //env.CountImg = frm.ImageCount.ToString();
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
                initDataGridColumns();
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
            txtExamNameInfo.Text = string.Empty;
            txtStartInfo.Text = string.Empty;
            txtEndInfo.Text = string.Empty;
            txtDepartmentInfo.Text = string.Empty;
            txtDoctorInfo.Text = string.Empty;
        }
        private void initGridHistory()
        {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            DataSet ds = process.GetLogSchedule(Convert.ToInt32(apt.Location));
            grdData.DataSource = ds.Tables[0];

            int i = 0;
            for (; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["DATEEDIT"].Visible = true;
            view1.Columns["DATEEDIT"].Caption = "วันที่แก้ไข";
            view1.Columns["DATEEDIT"].Width = 100;

            view1.Columns["EDITBY"].Visible = true;
            view1.Columns["EDITBY"].Caption = "ผู้แก้ไข";
            view1.Columns["EDITBY"].Width = 200;

            view1.Columns["REASON"].Visible = true;
            view1.Columns["REASON"].Caption = "เหตุผล";
            view1.Columns["REASON"].Width = 380;

            view1.Columns["STATUS"].Visible = true;
            view1.Columns["STATUS"].Caption = "สถานะ";
            view1.Columns["STATUS"].Width = 80;
        }
        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null)
            {
                txtHNInfo.Text = dr["HN"].ToString();
                txtPatientNameInfo.Text = dr["PATIENTNAME"].ToString();
                txtModalityInfo.Text = dr["MODALITY_NAME"].ToString();
                txtExamNameInfo.Text = dr["EXAM_NAME"].ToString();
                txtStartInfo.Text = dr["START_DATETIME"].ToString();
                txtEndInfo.Text = dr["END_DATETIME"].ToString();
                txtDepartmentInfo.Text = dr["UNIT_NAME"].ToString();
                txtDoctorInfo.Text = dr["DOCTORNAME"].ToString();
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
            viewApp.Columns["SCHEDULE_DT"].Visible = true;
            viewApp.Columns["SCHEDULE_DT"].Caption = "Appoint Date";
            viewApp.Columns["SCHEDULE_DT"].ColVIndex = 0;
            viewApp.Columns["SCHEDULE_DT"].Width = 100;

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
        private void initEmptyRows() {
            bool flag = true;
            foreach(DataRow row in dttExam.Rows)
                if (string.IsNullOrEmpty(row["EXAM_ID"].ToString().Trim())) {
                    flag = false;
                    break;
                }
            if (flag) {
                DataRow row = dttExam.NewRow();
                row["QTY"] = 1;
                row["RATE"] = 0.0;
                dttExam.Rows.Add(row);
                dttExam.AcceptChanges();
            }
        }
        private void initGridExam()
        {
            initEmptyRows();
            grdExam.DataSource = dttExam;
            viewExam.Columns["EXAM_ID"].Visible = false;
            viewExam.Columns["EXAM_ID"].Caption = "Exam ID";
            viewExam.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;

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
            repositoryItemLookUpEdit1.DataSource = dataExam;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examCode_KeyUp);
            repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode_CloseUp);
            repositoryItemLookUpEdit1.BestFit();
            repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EXAM_UID"].ColumnEdit = repositoryItemLookUpEdit1;
            viewExam.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EXAM_UID"].Visible = true;
            viewExam.Columns["EXAM_UID"].Caption = "Exam Code";
            viewExam.Columns["EXAM_UID"].Width = 80;
            viewExam.Columns["EXAM_UID"].VisibleIndex = 1;

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
            repositoryItemLookUpEdit2.DataSource = dataExam;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            repositoryItemLookUpEdit2.BestFit();
            repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            viewExam.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EXAM_NAME"].Visible = true;
            viewExam.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewExam.Columns["EXAM_NAME"].Width = 150;
            viewExam.Columns["EXAM_NAME"].VisibleIndex = 2;

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
            rleBPView.DataSource = RISBaseData.BP_View();
            rleBPView.NullText = string.Empty;
            rleBPView.KeyUp += new KeyEventHandler(BPView_KeyUp);
            rleBPView.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(BPView_CloseUp);
            rleBPView.BestFit();
            rleBPView.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["BPVIEW_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["BPVIEW_ID"].ColumnEdit = rleBPView;
            viewExam.Columns["BPVIEW_ID"].Visible = false;
            viewExam.Columns["BPVIEW_ID"].Caption = "Sides";
            viewExam.Columns["BPVIEW_ID"].VisibleIndex = 3;

            viewExam.Columns["QTY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["QTY"].Visible = true;
            viewExam.Columns["QTY"].Caption = "Qty";
            viewExam.Columns["QTY"].Width = 50;
            viewExam.Columns["QTY"].VisibleIndex = 4;
            viewExam.Columns["QTY"].OptionsColumn.ReadOnly = true;

            viewExam.Columns["RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["RATE"].Visible = true;
            viewExam.Columns["RATE"].Caption = "Rate";
            viewExam.Columns["RATE"].Width = 80;
            viewExam.Columns["RATE"].VisibleIndex = 5;
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
            viewExam.Columns["AVG_REQ_MIN"].Visible = true;
            viewExam.Columns["AVG_REQ_MIN"].Caption = "Avg(Minute)";
            viewExam.Columns["AVG_REQ_MIN"].Width = 90;
            viewExam.Columns["AVG_REQ_MIN"].VisibleIndex = 6;
            viewExam.Columns["AVG_REQ_MIN"].ColumnEdit = rpsReq;

            viewExam.Columns["TOTAL"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["TOTAL"].Visible = false;
            viewExam.Columns["TOTAL"].Caption = "Total";
            viewExam.Columns["TOTAL"].Width = 90;
            viewExam.Columns["TOTAL"].VisibleIndex = 9;
            viewExam.Columns["TOTAL"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewExam.Columns["TOTAL"].SummaryItem.DisplayFormat = "{0:N0}";
            viewExam.Columns["TOTAL"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["TOTAL"].DisplayFormat.FormatString = "#,##0";
            viewExam.Columns["TOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

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
            viewExam.Columns["PREPATION_ID"].Visible = false;
            viewExam.Columns["PREPATION_ID"].Caption = "Prepation";
            viewExam.Columns["PREPATION_ID"].Width = 100;
            viewExam.Columns["PREPATION_ID"].VisibleIndex = 7;

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
            rpsRadio.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(rpsRadio_CloseUp);
            rpsRadio.DataSource = RISBaseData.Ris_Radiologist();
            rpsRadio.BestFit();
            rpsRadio.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EMP_ID"].ColumnEdit = rpsRadio;
            viewExam.Columns["EMP_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EMP_ID"].Visible = true;
            viewExam.Columns["EMP_ID"].Caption = "Radiologist";
            viewExam.Columns["EMP_ID"].Width = 150;
            viewExam.Columns["EMP_ID"].VisibleIndex = 8;

            viewExam.Columns["GEN_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["GEN_ID"].Visible = false;
            viewExam.Columns["GEN_ID"].Caption = "Gen";
            viewExam.Columns["GEN_ID"].OptionsColumn.ReadOnly = true;

            #region Repository Delete
            RepositoryItemButtonEdit btnDel = new RepositoryItemButtonEdit();
            btnDel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btnDel.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnDel_ButtonClick);
            #endregion
            viewExam.Columns["DELETE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["DELETE"].Visible = true;
            viewExam.Columns["DELETE"].Caption = " ";
            viewExam.Columns["DELETE"].Width = 30;
            viewExam.Columns["DELETE"].VisibleIndex = 10;
            viewExam.Columns["DELETE"].ColumnEdit = btnDel;

            viewExam.Columns["COMMENTS"].Visible = false;
            viewExam.Columns["OLD_EXAM_ID"].Visible = false;
            viewExam.Columns["SCHEDULE_ID"].Visible = false;
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
        private bool checkConflict(string ExamID)
        {
            bool flag = false;
            DataRow[] rows = dttExam.Select("EXAM_ID=" + ExamID);
            flag = rows.Length > 0 ? true : false;
            return flag;
        }
        private bool updateExam(string strSearch)
        {
            bool flag = false;
            dttExam = (DataTable)grdExam.DataSource;
            DataRow[] rows = dataExam.Select("EXAM_ID=" + strSearch);
            if (rows.Length > 0)
            {
                flag = true;
                if (checkConflict(strSearch)) return false;
                DataRow dr = dttExam.Rows[viewExam.FocusedRowHandle];
                dr["EXAM_ID"] = rows[0]["EXAM_ID"];
                dr["EXAM_UID"] = rows[0]["EXAM_ID"];
                dr["EXAM_NAME"] = rows[0]["EXAM_ID"];
               // dr["RATE"] = rows[0]["RATE"];

                DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype);
                string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL":
                        dr["RATE"] = rows[0]["SPECIAL_RATE"].ToString();
                        break;
                    case "VIP":
                        dr["RATE"] = rows[0]["VIP_RATE"].ToString();
                        break;
                    default:
                        dr["RATE"] = rows[0]["RATE"].ToString();
                        break;
                }



                dr["QTY"] = 1;
                dr["BPVIEW_ID"] = 0;
                if (rows[0]["AVG_REQ_MIN"].ToString().Trim().Length > 0)
                    dr["AVG_REQ_MIN"] = rows[0]["AVG_REQ_MIN"];
                else
                    dr["AVG_REQ_MIN"] = avg_inv_time;
                calExamPanel(strSearch);
                calTotal();
                calculateTime();
                if (canAddRow())
                {
                    DataRow row = dttExam.NewRow();
                    row["RATE"] = 0;
                    row["TOTAL"] = 0;
                    row["QTY"] = 1;
                    dttExam.Rows.Add(row);
                    dttExam.AcceptChanges();
                }
                viewExam.RefreshData();
            }
            return flag;
        }
        private void updateBPView(string strSearch)
        {
            dttExam = (DataTable)grdExam.DataSource;
            DataTable dtBP_View = RISBaseData.BP_View();
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
            dttExam = (DataTable)grdExam.DataSource;
            DataTable dtRad = RISBaseData.Ris_Radiologist();
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
                DataRow dr = dttExam.Rows[viewExam.FocusedRowHandle];
                dr["PREPATION_ID"] = rows[0]["PREPARATION_ID"];
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
                    bool flag = updateExam(e.Value.ToString());
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
                        msg.ShowAlert("UID1014", env.CurrentLanguageID);
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
                    bool flag = updateExam(e.Value.ToString());
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
                        msg.ShowAlert("UID1014", env.CurrentLanguageID);
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
                        if (min == 0)
                        {
                            min = avg_inv_time;
                            sp.EditValue = min;
                        }
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
            }
            else
                e.Cancel = true;
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
                        dr["RATE"] = rowsExam[0]["RATE"];
                        dr["QTY"] = 1;
                        dr["BPVIEW_ID"] = 0;
                        if (rowsExam[0]["AVG_REQ_MIN"].ToString().Trim().Length > 0)
                            dr["AVG_REQ_MIN"] = rowsExam[0]["AVG_REQ_MIN"];
                        else
                            dr["AVG_REQ_MIN"] = avg_inv_time;
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

        //private void LoadInsurnaceType()
        //{
        //    #region Load Insurance Type from HIS WS

        //    FinancialBilling fb = new FinancialBilling();
        //    string enc_id = "";
        //    string enc_type = "";
        //    string unit_uid = "";
        //    string unit_name = "";
        //    string insurance_type_uid = "UNK";

        //    string date_now = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        //    string clinic_type = "";

        //    int insurance_id = 122; // เงินสด
        //    string insurance_name = "UNK"; //เงินสด

        //    fb.LoadHRUnit(patient.REF_UNIT, ref unit_uid, ref unit_name);
        //    fb.LoadEncounter(patient.Reg_UID, unit_uid, ref enc_id, ref enc_type);
        //    if (enc_id != "" && enc_type != "")
        //    {
        //        switch (txtSession.Tag.ToString())
        //        {
        //            case "1":
        //                clinic_type = "SPC";
        //                break;
        //            case "2":
        //                clinic_type = "RGL";
        //                break;
        //            case "3":
        //                clinic_type = "RGL";
        //                break;
        //            case "4":
        //                clinic_type = "SPC";
        //                break;
        //        }

        //        insurance_type_uid = fb.LoadGetEligibilityInsuranceDetail(patient.Reg_UID, enc_id, enc_type, unit_uid, date_now, clinic_type);
        //        fb.LoadInsuranceType(insurance_type_uid, ref insurance_id, ref insurance_name);

        //        grdLvInsurance.EditValue = insurance_id;
        //    }
        //    else
        //    {
        //        fb.LoadUNKInsuranceType(ref insurance_id, ref insurance_type_uid, ref insurance_name);
        //        grdLvInsurance.EditValue = insurance_id;
        //    }

        //    #endregion
        //}
        //private void txtOrderDept_Validated(object sender, EventArgs e)
        //{
        //    LoadInsurnaceType();
        //}
        //private void txtSession_Validated()
        //{
        //    LoadInsurnaceType();
        //}
        private string getRadilogyName(string EMP_ID)
        {
            string name = string.Empty;
            DataTable dtt = RISBaseData.His_Doctor();
            DataRow[] rs = dtt.Select("EMP_ID=" + EMP_ID);
            if (rs.Length > 0)
                name = rs[0]["FNAME"].ToString() + " " + rs[0]["LNAME"].ToString();
            return name;
        }
    }
}   