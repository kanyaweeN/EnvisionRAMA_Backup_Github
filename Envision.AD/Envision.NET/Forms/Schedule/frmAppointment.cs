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

using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.Operational;
using Envision.NET.Forms.Dialog;
using Miracle.NationalIDCard;
using Miracle.Scanner;
using Envision.NET.Forms.Schedule.Common;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Xml;
using Envision.NET.Forms.EMR;
using Envision.Operational.Translator;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using Envision.Common.Common;
using Miracle.Util;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmAppointment : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SchedulerControl control;
        //private Appointment apt;
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
        private DataTable dttExam;
        private DataTable dataExam;
        private DataTable dttExamPanel;
        private DataTable dttExamFlag, dtExamFlagDTL;
        private int pat_id, insurance_id, clinictype;
        private string HN;
        private int avg_inv_time;
        private DataView dv_scan_image = null;
        private MyAppointmentFormController controller;

        private int _mode; /* mode : 1 (Normal Data form schedule), mode : 2 (Data change to appointment) */
        private DataRow rowChangeToAppoint;

        private int modalityID, scheduleID, xrayreqID;
        private DateTime dateStart, dateEnd;
        public frmAppointment(SchedulerControl control, Appointment apt)
        {
            this.control = control;
            controller = new MyAppointmentFormController(control, apt);
            InitializeComponent();
            _mode = 1;
            modalityID = string.IsNullOrEmpty(apt.ResourceId.ToString()) ? 0 : Convert.ToInt32(apt.ResourceId.ToString().Trim());
            dateStart = apt.Start;
            dateEnd = apt.End;
            scheduleID = string.IsNullOrEmpty(apt.Location.Trim()) ? 0 : Convert.ToInt32(apt.Location.Trim());
        }
        public frmAppointment(DataRow rowData)
        {
            InitializeComponent();
            rowChangeToAppoint = rowData;
            _mode = 2;
            modalityID = Convert.ToInt32(rowChangeToAppoint["MODALITY_ID"].ToString());
            dateStart = Convert.ToDateTime(rowChangeToAppoint["START_DATETIME"]);
            dateEnd = Convert.ToDateTime(rowChangeToAppoint["START_DATETIME"]).AddMinutes(5);
            xrayreqID = Convert.ToInt32(rowChangeToAppoint["SCHEDULE_ID"].ToString());
            scheduleID = 0;
        }
        private void frmAppointment_Load(object sender, EventArgs e)
        {
            initControlFirst();
            setLookupAllGrid();
            layoutPatient.Focus();
            this._summary = new frmPopupOrderOrScheduleSummary();

            switch (_mode)
            {
                case 1: txtHN.Focus(); break;
                case 2: setBindingData_ChangeToAppointment(); break;
            }

        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.SCHEDULE_ID = -1;
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

        private void setBindingData_ChangeToAppointment()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            rbbPageRecurrence.Visible = false;
            txtHN.Text = HN = rowChangeToAppoint["HN"].ToString();
            patient = new Patient(txtHN.Text.Trim());
            fillDemographic();

            DataRow[] drs;
            try
            {
                drs = dttDepartment.Select("UNIT_ID=" + rowChangeToAppoint["REF_UNIT"].ToString());
                if (drs.Length > 0)
                {
                    txtOrderDept.Tag = drs[0]["UNIT_ID"].ToString();
                    txtOrderDept.Text = drs[0]["UNIT_UID"].ToString() + ":" + drs[0]["UNIT_NAME"].ToString();
                }
            }
            catch { txtOrderDept.Text = ""; }
            try
            {
                drs = dttDoctor.Select("EMP_ID=" + rowChangeToAppoint["REF_DOC_ID"].ToString());

                if (drs.Length > 0)
                {
                    txtOrderDoc.Tag = drs[0]["EMP_ID"].ToString();
                    txtOrderDoc.Text = drs[0]["EMP_UID"].ToString() + ":" + drs[0]["RadioName"].ToString();
                }
            }
            catch { txtOrderDoc.Text = ""; }

            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            dttExam = new DataTable();
            dttExam = proc.getXrayreqData(xrayreqID, modalityID);
            initGridExam();
            viewExam.OptionsBehavior.Editable = false;
            chkAllDay.Enabled = false;
            chkBlock.Enabled = false;
            chkComments.Enabled = false;

            dlg.Close();
            grdLvPatStatus.Focus();
        }
        private void setModalityClinicType()
        {
            //ProcessGetRISModalityclinictype process = new ProcessGetRISModalityclinictype();
            //process.RIS_MODALITYCLINICTYPE.MODE = 2;
            //process.RIS_MODALITYCLINICTYPE.MODALITY_ID = modalityID;
            //process.Invoke();
            //dttModalityClinic = process.Result.Tables[0].Copy();
        }
        private void initDefaultSession()
        {

            dttSession = new DataTable();
            ProcessGetRISClinicsession proc = new ProcessGetRISClinicsession();
            dttSession = proc.GetDefaultClinicSessionByModality(modalityID).Copy();
            DateTime dtStart = dateStart;
            foreach (DataRow dr in dttSession.Rows)
            {
                DateTime tmp = Convert.ToDateTime(dr["START_TIME"].ToString());
                DateTime sessionFrom = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, tmp.Hour, tmp.Minute, tmp.Second);
                tmp = Convert.ToDateTime(dr["END_TIME"].ToString());
                DateTime sessionTo = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, tmp.Hour, tmp.Minute, tmp.Second);
                if ((dateStart >= sessionFrom) && (dateStart <= sessionTo))
                {
                    txtSession.Tag = dr["SESSION_ID"].ToString();
                    txtSession.Text = dr["SESSION_NAME"].ToString();
                    clinictype = Convert.ToInt32(dr["CLINIC_TYPE_ID"]);
                    break;
                }
            }
            if (txtSession.Text == string.Empty)
            {
                if ((dateStart.Hour < 12))
                {
                    DataRow[] rows = dttSession.Select("SESSION_UID='RM'");
                    txtSession.Tag = rows[0]["SESSION_ID"].ToString();
                    txtSession.Text = rows[0]["SESSION_NAME"].ToString();
                    clinictype = Convert.ToInt32(rows[0]["CLINIC_TYPE_ID"]);
                }
                else
                {
                    DataRow[] rows = dttSession.Select("SESSION_UID='RA'");
                    txtSession.Tag = rows[0]["SESSION_ID"].ToString();
                    txtSession.Text = rows[0]["SESSION_NAME"].ToString();
                    clinictype = Convert.ToInt32(rows[0]["CLINIC_TYPE_ID"]);
                }
            }
        }
        private void setAutoComplete()
        {
            txtOrderDept.AutoCompleteCustomSource.Clear();
            txtOrderDoc.AutoCompleteCustomSource.Clear();
            int id = modalityID;
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
        private string ModalityName(string ID)
        {
            string name = string.Empty;
            ProcessGetRISModality process = new ProcessGetRISModality(true);
            process.Invoke();
            DataTable dttModaltiy = new DataTable();
            dttModaltiy = process.Result.Tables[0].Copy();
            DataRow[] dr = dttModaltiy.Select("MODALITY_ID =" + ID);
            if (dr.Length > 0)
            {
                name = dr[0]["MODALITY_NAME"].ToString();
                avg_inv_time = Convert.ToInt32(dr[0]["AVG_INV_TIME"].ToString());
            }
            else
                avg_inv_time = 5;

            ProcessGetRISModalityexam processExam = new ProcessGetRISModalityexam(Convert.ToInt32(ID));
            processExam.Invoke();
            dataExam = new DataTable();
            dataExam = processExam.Result.Tables[0].Copy();
            initiateExamPanel();
            return name;
        }
        private void clearContextControl()
        {
            //txtHN.Text = string.Empty;

            txtFName.Text = string.Empty;
            //txtMName.Text = string.Empty;
            txtLName.Text = string.Empty;

            txtFName_Eng.Text = string.Empty;
            //txtMName_Eng.Text = string.Empty;
            txtLName_Eng.Text = string.Empty;

            txtID.Text = string.Empty;
            //dtDOB.DateTime = DateTime.Now;
            cboGender.SelectedIndex = 0;
            txtPhone.Text = string.Empty;
            //txtMobile.Text = string.Empty;
            dtLastVisit.DateTime = DateTime.Now;
            dtNextVisit.DateTime = DateTime.Now;
            txtOrderDept.Tag = null;
            txtOrderDept.Text = string.Empty;
            txtOrderDoc.Tag = null;
            txtOrderDoc.Text = string.Empty;
            //txtExamUID.Tag = null;
            //txtExamUID.Text = string.Empty;
            //txtExamName.Text = string.Empty;
            //txtPrepation.Tag = null;
            //txtPrepation.Text = string.Empty;
            //txtRate.Text = "0.00";
            deLMP.ResetText();
            deLMP.Text = string.Empty;

            //txtClinicType.Tag = null;
            //txtClinicType.Text = string.Empty;
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

            setTrauma();
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
        private void enableDisableControl()
        {
            layoutPatient.Enabled = true;
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
            //txtMName.Enabled = flag;
            txtLName.Enabled = flag;
            txtFName_Eng.Enabled = flag;
            //txtMName_Eng.Enabled = flag;
            txtLName_Eng.Enabled = flag;
            txtID.Enabled = flag;
            //dtDOB.Enabled = flag;
            cboGender.Enabled = flag;
            txtPhone.Enabled = flag;
            //txtMobile.Enabled = flag;
            deLMP.Enabled = flag;
        }
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
        private void initControlFirst()
        {
            try
            {
                initDefaultControlStart();
                enableDisableControl();
                initGridAppointment("000");
                setModalityClinicType();

                txtModality.Text = ModalityName(modalityID.ToString());
                dtStart.DateTime = dateStart;
                dtEnd.DateTime = dateEnd;
                //dtRequestResult.DateTime = dateStart;
                setAutoComplete();
                initDefaultSession();
                if (scheduleID == 0)
                {
                    timeStart.Time = dateStart;
                    timeEnd.Time = dateStart.AddMinutes(avg_inv_time);
                    timeReqeustResult.Time = dateStart;
                    groupTiming.Enabled = true;

                }
                initEmptyRows();
                initGridExam();
                dv_scan_image = new ScanImages().GetData(scheduleID, 0);
            }
            catch (Exception ecp) { }
        }
        private void fillDemographic()
        {
            if (patient != null)
            {
                initDefaultSession();

                txtFName.Text = patient.FirstName;
                txtLName.Text = patient.LastName;
                txtFName_Eng.Text = patient.FirstName_ENG;
                txtLName_Eng.Text = patient.LastName_ENG;
                txtID.Text = patient.SocialNumber;

                LookUpSelect lu = new LookUpSelect();
                if (!string.IsNullOrEmpty(patient.DateOfBirth.ToString()))
                {
                    if (patient.DateOfBirth == DateTime.MinValue)
                    {
                        txtAGE.Text = "ไม่ทราบอายุ";
                        txtAGE.Visible = true;
                        txtDOB.Visible = false;
                    }
                    else
                    {
                        txtDOB.DateTime = patient.DateOfBirth;
                        txtDOB.Visible = false;
                        txtAGE.Text = lu.SelectAGE(patient.DateOfBirth).Tables[0].Rows[0][0].ToString();
                        txtAGE.Visible = true;
                    }
                }
                else
                {
                    txtAGE.Text = "ไม่ทราบอายุ";
                    txtAGE.Visible = true;
                    txtDOB.Visible = false;
                }

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

                if (!string.IsNullOrEmpty(patient.HL7_Format) && patient.HL7_Format.Trim().Length > 0)
                    layoutPatient.Text = "Patient : " + patient.HL7_Format.Trim();
                else
                    layoutPatient.Text = "Patient";

                txtPatientIdDetail.Text = string.IsNullOrEmpty(patient.PATIENT_ID_LABEL) ? "-" : "[" + patient.PATIENT_ID_LABEL + "] " + patient.PATIENT_ID_DETAIL;
                LoadInsuranceDetail();

                //ProcessGetRISInsurancetype getIn = new ProcessGetRISInsurancetype();
                //getIn.Invoke();
                //DataRow[] drIn = getIn.Result.Tables[0].Select("INSURANCE_TYPE_UID='" + patient.Insurance_Type + "'");
                //if (drIn != null)
                //{
                //    if (drIn.Length > 0)
                //    {
                //        if (string.IsNullOrEmpty(drIn[0]["INSURANCE_TYPE_ID"].ToString()))
                //            grdLvInsurance.EditValue = 122;//เงินสด
                //        else
                //            grdLvInsurance.EditValue = Convert.ToInt32(drIn[0]["INSURANCE_TYPE_ID"]);
                //    }
                //    else
                //    {
                //        grdLvInsurance.EditValue = 122;//เงินสด
                //    }
                //}
                //else
                //    grdLvInsurance.EditValue = 122;//เงินสด

                dtLastVisit.DateTime = patient.Last_Modified_ON == DateTime.MinValue ? DateTime.Now : patient.Last_Modified_ON;
                //dtNextVisit.DateTime = DateTime.Today;
                dtNextVisit.DateTime = DateTime.Now.AddDays(1);

                enableDisableGroupPatient(true);
                groupVisit.Enabled = true;
                groupExam.Enabled = true;
                groupTiming.Enabled = true;
                grdLvPatStatus.Enabled = true;
                grdLvInsurance.Enabled = true;
                txtOrderDept.BackColor = Color.White;
                txtOrderDoc.BackColor = Color.White;
                txtOrderDept.ReadOnly = false;
                txtOrderDoc.ReadOnly = false;

                initGridAppointment();
                DataRow[] drExam;

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
                            txtOrderDept.Text = drExam[0]["UNIT_UID"].ToString() + ":" + drExam[0]["UNIT_NAME"].ToString();
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

                layoutPatient.Enabled = true;
                DataRow[] drs = dttDepartment.Select("UNIT_ID=" + patient.REF_UNIT);
                if (drs.Length > 0)
                {
                    txtOrderDept.Tag = drs[0]["UNIT_ID"].ToString();
                    txtOrderDept.Text = drs[0]["UNIT_UID"].ToString() + ":" + drs[0]["UNIT_NAME"].ToString();
                    //txtOrderDept.Text = drs[0]["UNIT_NAME"].ToString();
                }

                drs = dttRadiologist.Select("EMP_ID=" + patient.REF_DOC);
                if (drs.Length > 0)
                {
                    txtOrderDoc.Tag = patient.REF_DOC;
                    txtOrderDoc.Text = drs[0]["EMP_UID"].ToString() + ":" + drs[0]["RadioName"].ToString();
                }
                chkNonResident.Checked = patient.NON_RESIDENCE == "Y" ? true : false;
            }
            else
            {
                txtHN.Text = string.Empty;
                txtOrderDept.BackColor = txtModality.BackColor;
                txtOrderDoc.BackColor = txtModality.BackColor;
                txtOrderDept.ReadOnly = true;
                txtOrderDoc.ReadOnly = true;

                groupExam.Enabled = false;
                groupVisit.Enabled = false;
                layoutPatient.Enabled = true;
                grdData.DataSource = null;
                txtHN.Enabled = true;

                chkNonResident.Checked = false;
            }
            popupAppointmentCase();
            checkAllergies();
        }
        private void popupAppointmentCase()
        {
            ProcessGetRISSchedule sche = new ProcessGetRISSchedule();
            DataTable dtCheckAppointCase = sche.GetAppointmentDuration(txtHN.Text.Trim(), dateStart);
            if (dtCheckAppointCase.Rows.Count > 0)
            {
                LookUpSelect lvS = new LookUpSelect();
                LookupData lv = new LookupData();
                lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(appointmentCase_ValueUpdated);
                lv.AddColumn("START_DATETIME", "Appointment Date", true, true);
                lv.AddColumn("MODALITY_NAME", "Modality", true, true);
                lv.AddColumn("EXAM_NAME", "Detail", true, true);
                lv.AddColumn("UNIT_NAME", "Department", true, true);
                lv.Text = "Appointment";

                lv.Data = dtCheckAppointCase;
                lv.Size = new Size(600, 400);
                lv.ShowBox();
            }
        }
        private void checkAllergies()
        {
            if (!string.IsNullOrEmpty(patient.Allergies))
            {
                frmAllergy2 Allergy = new frmAllergy2();
                Allergy.ShowDialog();
            }
        }
        private void appointmentCase_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        { }
        private bool requireCheckFreeTime()
        {

            if (chkBlock.Checked == false && chkComments.Checked == false)
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
                            process.RIS_CLINICSESSION.MODALITY_ID = modalityID;
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
                            curr_app = dtmp.Rows.Count > 0 ? Convert.ToInt32(dtmp.Rows[0]["AMT"]) : 0;
                            if (curr_app >= max_app)
                            {
                                ScheduleInfo sch = new ScheduleInfo();
                                if (sch.CanExceedSchedule(env.UserID))
                                {
                                    if (msg.ShowAlert("UID1113", env.CurrentLanguageID) == "1")
                                        return false;
                                    else
                                    {

                                        if (string.IsNullOrEmpty(txtReason.Text.Trim()))
                                        {
                                            if (msg.ShowAlert("UID1110", env.CurrentLanguageID) == "2")
                                                return false;
                                        }
                                        else
                                        {
                                            frmConfirmPassword frm = new frmConfirmPassword();
                                            if (frm.ShowDialog() != DialogResult.OK)
                                                return false;
                                        }

                                    }
                                }
                                else
                                {
                                    if (msg.ShowAlert("UID1421", env.CurrentLanguageID) == "2")
                                        return false;
                                }
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        private bool requireCheck()
        {
            #region require check.
            xtraTabControl1.SelectedTabPageIndex = 0;

            if (patient != null)
            {
                if (patient.LinkDown)
                {
                    #region เช็ค Demographic
                    if (txtFName.Text.Trim() == string.Empty)
                    {
                        msg.ShowAlert("UID1026", env.CurrentLanguageID);
                        txtFName.Focus();
                        return false;
                    }
                    if (txtLName.Text.Trim() == string.Empty)
                    {
                        msg.ShowAlert("UID1026", env.CurrentLanguageID);
                        txtLName.Focus();
                        return false;
                    }
                    if (txtFName_Eng.Text.Trim() == string.Empty)
                    {
                        msg.ShowAlert("UID1027", env.CurrentLanguageID);
                        txtFName_Eng.Focus();
                        return false;
                    }
                    if (txtLName_Eng.Text.Trim() == string.Empty)
                    {
                        msg.ShowAlert("UID1027", env.CurrentLanguageID);
                        txtLName_Eng.Focus();
                        return false;
                    }
                    #endregion
                }
            }
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
            if (dxErrorProvider1.HasErrors) return false;
            if (chkBlock.Checked == false && chkComments.Checked == false)
            {
                ProcessGetRISModality getModUnit
                    = new ProcessGetRISModality();
                getModUnit.RIS_MODALITY.MODALITY_ID = modalityID;
                getModUnit.Invoke_forIntervention();

                string modality_type
                    = getModUnit.Result.Tables[0].Rows[0]["TYPE_NAME"].ToString();

                if (modality_type != "Intervention")
                {
                    #region Check Order department and Doctor.
                    if (txtOrderDept.Text.Trim().Length == 0)
                    {
                        msg.ShowAlert("UID101", env.CurrentLanguageID);
                        txtOrderDept.Focus();
                        return false;
                    }
                    if (txtOrderDoc.Text.Trim().Length == 0)
                    {
                        msg.ShowAlert("UID102", env.CurrentLanguageID);
                        txtOrderDoc.Focus();
                        return false;
                    }
                    #endregion
                }

                if (checkHaveExamData() == false)
                {
                    msg.ShowAlert("UID0046", env.CurrentLanguageID);
                    grdExam.Focus();
                    return false;
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

            #endregion
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
        private bool insertBlockData()
        {
            ProcessAddRISSchedule process = new ProcessAddRISSchedule();
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            end = end.Subtract(ts);
            string schedule_data = "";
            if (chkBlock.Checked)
                schedule_data = "BLOCK - " + txtReason.Text;
            else if (chkComments.Checked)
                schedule_data = "COMMENTS - " + txtReason.Text;

            process.RIS_SCHEDULE.SCHEDULE_DT = start;
            process.RIS_SCHEDULE.START_DATETIME = start;
            process.RIS_SCHEDULE.END_DATETIME = end;
            process.RIS_SCHEDULE.MODALITY_ID = modalityID;
            process.RIS_SCHEDULE.ORG_ID = env.OrgID;
            process.RIS_SCHEDULE.REASON = txtReason.Text;
            process.RIS_SCHEDULE.SCHEDULE_DATA = schedule_data;
            process.RIS_SCHEDULE.SCHEDULE_ID = 0;
            process.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
            process.RIS_SCHEDULE.CREATED_BY = env.UserID;
            if (controller.EditedAppointmentCopy.RecurrenceInfo != null)
            {
                RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(controller.EditedAppointmentCopy.RecurrenceInfo, DateSavingType.LocalTime);
                process.RIS_SCHEDULE.RECURRENCEINFO = helper.ToXml();
            }
            process.RIS_SCHEDULE.ALLDAY = chkAllDay.Checked;
            process.RIS_SCHEDULE.LABEL = controller.LabelId;
            process.RIS_SCHEDULE.STATUS = Convert.ToInt32(controller.EditedAppointmentCopy.StatusId.ToString());
            process.RIS_SCHEDULE.EVENTTYPE = Convert.ToInt32(controller.EditedAppointmentCopy.Type);

            if (chkBlock.Checked)
                process.InvokeBlock();
            if (chkComments.Checked)
                process.InvokeComments();
            if (process.RIS_SCHEDULE.SCHEDULE_ID > 0)
            {
                process.RIS_SCHEDULE.HN = chkComments.Checked ? "Comments" : "Block";
                process.RIS_SCHEDULE.SESSION_ID = 0;
                process.RIS_SCHEDULE.REG_ID = 0;
                process.RIS_SCHEDULE.REF_DOC = 0;
                process.RIS_SCHEDULE.REF_UNIT = 0;
                process.RIS_SCHEDULE.PAT_STATUS = 0;
                process.RIS_SCHEDULE.LMP_DT = DateTime.Now;
                process.RIS_SCHEDULE.INSURANCE_TYPE_ID = 0;
                process.RIS_SCHEDULE.IS_BLOCKED = chkComments.Checked ? 'N' : 'Y';

                #region insert schedule logs
                ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
                schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
                schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'C';
                schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Create Envision";
                schLogs.Invoke();
                #endregion

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
        private bool insertAppointmentData()
        {
            ProcessAddRISSchedule process = new ProcessAddRISSchedule();
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            DateTime requestResult = new DateTime(dtRequestResult.DateTime.Year, dtRequestResult.DateTime.Month, dtRequestResult.DateTime.Day, timeReqeustResult.Time.Hour, timeReqeustResult.Time.Minute, 0);

            RIS_SCHEDULE data = new RIS_SCHEDULE();
            data.SCHEDULE_ID = 0;
            data.MODALITY_ID = modalityID;
            data.START_DATETIME = start;// apt.Start;
            data.END_DATETIME = end;// apt.End;
            data.HN = txtHN.Text.Trim();

            #region his_registration.
            int regID = txtHN.Tag == null ? 0 : Convert.ToInt32(txtHN.Tag.ToString());

            if (patient.DataFromHIS)
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
                pAddHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text.Trim().Length == 0 ? patient.FirstName_ENG : txtFName_Eng.Text;
                pAddHIS.HIS_REGISTRATION.GENDER = cboGender.SelectedIndex == 0 ? 'M' : 'F';
                pAddHIS.HIS_REGISTRATION.HN = patient.Reg_UID;
                pAddHIS.HIS_REGISTRATION.LNAME = patient.LastName;
                pAddHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text.Trim().Length == 0 ? patient.LastName_ENG : txtLName_Eng.Text;
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
            else if (patient.LinkDown)
            {
                ProcessAddHISRegistration pHIS = new ProcessAddHISRegistration(true);
                pHIS.HIS_REGISTRATION.ADDR1 = string.Empty;
                pHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                pHIS.HIS_REGISTRATION.FNAME = txtFName.Text;
                pHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text;
                pHIS.HIS_REGISTRATION.GENDER = cboGender.SelectedIndex == 0 ? 'M' : 'F';
                pHIS.HIS_REGISTRATION.HN = txtHN.Text;
                pHIS.HIS_REGISTRATION.LNAME = txtLName.Text;
                pHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text;
                pHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                pHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
                pHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
                pHIS.HIS_REGISTRATION.SSN = txtID.Text;
                pHIS.HIS_REGISTRATION.TITLE = string.Empty;
                pHIS.HIS_REGISTRATION.TITLE_ENG = string.Empty;
                pHIS.HIS_REGISTRATION.LINK_DOWN = Convert.ToChar("Y");
                pHIS.HIS_REGISTRATION.INSURANCE_TYPE = string.Empty;
                pHIS.Invoke();
                regID = pHIS.HIS_REGISTRATION.REG_ID;
                patient.Reg_UID = txtHN.Text;
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
                pAddHIS.HIS_REGISTRATION.FNAME = txtFName.Text;
                pAddHIS.HIS_REGISTRATION.FNAME_ENG = txtFName_Eng.Text.Trim().Length == 0 ? patient.FirstName_ENG : txtFName_Eng.Text;
                pAddHIS.HIS_REGISTRATION.GENDER = cboGender.SelectedIndex == 0 ? 'M' : 'F';
                pAddHIS.HIS_REGISTRATION.HN = txtHN.Text.Trim();
                pAddHIS.HIS_REGISTRATION.LNAME = txtLName.Text;
                pAddHIS.HIS_REGISTRATION.LNAME_ENG = txtLName_Eng.Text.Trim().Length == 0 ? patient.LastName_ENG : txtLName_Eng.Text;
                pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                pAddHIS.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
                pAddHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;//txtMobile.Text;
                pAddHIS.HIS_REGISTRATION.PHONE3 = patient.Phone3;
                pAddHIS.HIS_REGISTRATION.SSN = patient.SocialNumber;
                pAddHIS.HIS_REGISTRATION.TITLE = patient.Title;
                pAddHIS.HIS_REGISTRATION.TITLE_ENG = patient.Title_ENG;
                pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = patient.InsuranceID.ToString();
                pAddHIS.HIS_REGISTRATION.REG_ID = regID;
                pAddHIS.Invoke();
                regID = pAddHIS.HIS_REGISTRATION.REG_ID;
                patient.Reg_UID = txtHN.Text;
            }
            #endregion

            #region insert normal.
            DateTime dtApp = new DateTime(start.Year, start.Month, start.Day);
            process.RIS_SCHEDULE.SCHEDULE_ID = 0;
            process.RIS_SCHEDULE.REG_ID = regID;
            process.RIS_SCHEDULE.SCHEDULE_DT = start;
            process.RIS_SCHEDULE.MODALITY_ID = modalityID;
            process.RIS_SCHEDULE.SCHEDULE_DATA = generateScheduleDataText();
            process.RIS_SCHEDULE.BLOCK_REASON = null;
            process.RIS_SCHEDULE.LABEL = null;
            process.RIS_SCHEDULE.LOCATION = string.Empty;
            process.RIS_SCHEDULE.EVENTTYPE = null;
            process.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(txtSession.Tag);
            process.RIS_SCHEDULE.START_DATETIME = start;
            DateTime edt = (DateTime)timeEnd.EditValue;
            edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute, edt.Second);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            edt = edt.Subtract(ts);
            process.RIS_SCHEDULE.END_DATETIME = edt;
            if (txtOrderDept.Tag != null)
                if (!string.IsNullOrEmpty(txtOrderDept.Tag.ToString()))
                    process.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(txtOrderDept.Tag.ToString());
            if (txtOrderDoc.Tag != null)
                if (!string.IsNullOrEmpty(txtOrderDoc.Tag.ToString()))
                    process.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(txtOrderDoc.Tag.ToString());
            process.RIS_SCHEDULE.PAT_STATUS = pat_id;
            process.RIS_SCHEDULE.LMP_DT = deLMP.DateTime;
            process.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
            process.RIS_SCHEDULE.CREATED_BY = env.UserID;
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
            process.RIS_SCHEDULE.ALLDAY = chkAllDay.Checked;
            process.RIS_SCHEDULE.LABEL = _label;
            process.RIS_SCHEDULE.STATUS = _status;
            process.RIS_SCHEDULE.EVENTTYPE = _eventype;
            process.RIS_SCHEDULE.REASON = txtReason.Text.Trim();

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

            process.Invoke();

            if (process.RIS_SCHEDULE.SCHEDULE_ID > 0)
            {
                process.RIS_SCHEDULE.REG_ID = regID;
                scheduleID = process.RIS_SCHEDULE.SCHEDULE_ID;

                #region Insert schedule-details.
                DataTable desExam = RISBaseData.Ris_Exam();
                ProcessAddRISScheduleDtl procDtl = new ProcessAddRISScheduleDtl();
                foreach (DataRow row in dttExam.Rows)
                {
                    procDtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = Convert.ToInt32(row["AVG_REQ_MIN"].ToString());
                    procDtl.RIS_SCHEDULEDTL.BPVIEW_ID = string.IsNullOrEmpty(row["BPVIEW_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(row["BPVIEW_ID"].ToString());
                    procDtl.RIS_SCHEDULEDTL.CREATED_BY = env.UserID;
                    procDtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(row["EXAM_ID"].ToString());
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
                }
                #endregion
                #region Update Request Result Datetime
                if (chkRequestResult.Checked)
                {
                    ProcessUpdateRISSchedule updateRequestResult = new ProcessUpdateRISSchedule();
                    updateRequestResult.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
                    updateRequestResult.RIS_SCHEDULE.REQUEST_RESULT_DATETIME = requestResult;
                    updateRequestResult.UpdateRequestResult();
                }
                #endregion
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (process.RIS_SCHEDULE.SCHEDULE_ID == -2)
                {
                    string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);
                    dtStart.Focus();
                    return false;
                }
                else
                {
                    string s = msg.ShowAlert("UID1101", env.CurrentLanguageID);
                    dtStart.Focus();
                    return false;
                }

            }
            #endregion

            #region Scan Image
            ScanImage save = new ScanImage(txtHN.Text.Trim(), process.RIS_SCHEDULE.SCHEDULE_ID, "Schedule");
            env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
            #endregion

            #region insert schedule logs
            ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
            schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
            schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
            schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'C';
            schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Create Envision";
            schLogs.Invoke();
            #endregion

            #region Mode Change Xray Request to Appointment
            if (_mode == 2)
            {
                ProcessUpdateRISSchedule upClinical = new ProcessUpdateRISSchedule();
                upClinical.TransferClincalIndication(process.RIS_SCHEDULE.SCHEDULE_ID, xrayreqID);

                ProcessGetRISSchedule getRequestData = new ProcessGetRISSchedule();
                DataTable dtXrayreq = getRequestData.getXrayreqData(xrayreqID);
                if (dttExam.Rows.Count == dtXrayreq.Rows.Count)
                {
                    ProcessUpdateXRAYREQ upCancel = new ProcessUpdateXRAYREQ();
                    upCancel.updateCancel(xrayreqID);
                }
                else
                {
                    ProcessUpdateXRAYREQ upDelete = new ProcessUpdateXRAYREQ();
                    upDelete.updateDeleteWithModality(xrayreqID, modalityID);
                }
            }
            #endregion

            #region Check Insert Exam Flag
            if (Utilities.IsHaveData(dttExamFlag))
            {
                foreach (DataRow rowFlag in dttExamFlag.Rows)
                {
                    ProcessAddRISOrderexamflag addExamFlag = new ProcessAddRISOrderexamflag();
                    addExamFlag.RIS_ORDEREXAMFLAG.ORDER_ID = 0;
                    addExamFlag.RIS_ORDEREXAMFLAG.XRAYREQ_ID = 0;
                    addExamFlag.RIS_ORDEREXAMFLAG.SCHEDULE_ID = process.RIS_SCHEDULE.SCHEDULE_ID;
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAM_ID = Convert.ToInt32(rowFlag["EXAM_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.EXAMFLAG_ID = Convert.ToInt32(rowFlag["EXAMFLAG_ID"]);
                    addExamFlag.RIS_ORDEREXAMFLAG.REASON = rowFlag["REASON"].ToString();
                    addExamFlag.RIS_ORDEREXAMFLAG.CREATED_BY = env.UserID;
                    addExamFlag.Invoke();
                }
            }
            #endregion

            new ScanImages().Invoke(patient.Reg_UID, scheduleID, 0, dv_scan_image);
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

            if (txtReason.Text.Trim().Length != 0)
            {
                string log_msg = txtReason.Text.Trim();
                log_msg = " (" + log_msg + ") ";

                result += log_msg;
            }

            return result;
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
            catch(Exception ex) { }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                if (chkBlock.Checked || chkComments.Checked)
                    insertBlockData();
                else if (requireCheckFreeTime())
                {
                    deleteEmptyRow();
                    insertAppointmentData();
                }
            }
        }
        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                if (requireCheckFreeTime())
                {
                    deleteEmptyRow();
                    bool flag = insertAppointmentData();

                    ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                    process.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
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
                        print.AppointmentDirectPrint(scheduleID, dts.Rows[0]["PAT_DEST_LABEL"].ToString());
                    }
                    else
                    {
                        if (dttExam.Rows.Count == 1)
                        {
                            if (flag)
                            {
                                #region Single Exam New.

                                if (dts.Rows.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(dts.Rows[0]["PAT_DEST_LABEL"].ToString()))
                                    {
                                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                        print.AppointmentDirectPrint(scheduleID, dts.Rows[0]["PAT_DEST_LABEL"].ToString());
                                    }
                                }
                                #endregion
                            }
                        }
                        else if (flag)
                        {
                            #region Multiprint.
                            frmMultiplePrint frm = new frmMultiplePrint(scheduleID);
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog();
                            #endregion
                        }
                    }
                }
            }
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
                    Miracle.Scanner.NewScan frm = new Miracle.Scanner.NewScan(env.PixPicture);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                        env.PixPicture = frm.PictureStruct;
                }
            }
        }

        private void chkBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlock.Checked)
            {
                chkComments.Checked = false;
                #region Clear Context.
                layoutPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;

                txtOrderDept.BackColor = txtModality.BackColor;
                txtOrderDoc.BackColor = txtModality.BackColor;
                txtOrderDept.ReadOnly = true;
                txtOrderDoc.ReadOnly = true;

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
                btnSavePrint.Enabled = false;
                btnScan.Enabled = false;
                grdExam.DataSource = null;
                grdData.DataSource = null;
                #endregion
            }
            else
            {
                fillDemographic();
                txtHN.Text = HN;
                grdExam.DataSource = dttExam;
                btnSavePrint.Enabled = true;
                btnScan.Enabled = true;
                calculateTime();
                calTotal();
            }
        }
        private void chkComments_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComments.Checked)
            {
                chkBlock.Checked = false;
                #region Clear Context.
                layoutPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;

                txtOrderDept.BackColor = txtModality.BackColor;
                txtOrderDoc.BackColor = txtModality.BackColor;
                txtOrderDept.ReadOnly = true;
                txtOrderDoc.ReadOnly = true;

                txtOrderDept.Text = string.Empty;
                txtOrderDoc.Text = string.Empty;

                txtHN.Text = "COMMENTS";
                txtFName.Text = string.Empty;
                txtLName.Text = string.Empty;
                txtFName_Eng.Text = string.Empty;
                txtLName_Eng.Text = string.Empty;
                txtID.Text = string.Empty;
                cboGender.SelectedIndex = 0;
                txtPhone.Text = string.Empty;
                //txtMobile.Text = string.Empty;
                btnSavePrint.Enabled = false;
                btnScan.Enabled = false;
                grdExam.DataSource = null;
                grdData.DataSource = null;
                #endregion
            }
            else
            {
                fillDemographic();
                txtHN.Text = HN;
                grdExam.DataSource = dttExam;
                btnSavePrint.Enabled = true;
                btnScan.Enabled = true;
                calculateTime();
                calTotal();
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
            //DataTable dtG = (DataTable)grdLvInsurance.Properties.DataSource;
            //if (dtG.Rows.Count > 0)
            //{
            //    insurance_id = Convert.ToInt32(dtG.Rows[viewInsu.FocusedRowHandle]["INSURANCE_TYPE_ID"]);
            //}
        }

        #region Lookup data.
        private void btnLookupHN_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(hnLookup_ValueUpdated);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("REG_ID", "Code", false, true);
            lv.AddColumn("FULLNAME", "NAME", true, true);
            lv.Text = "HN Search";

            lv.Data = lvS.ScheduleNotParameter("HN").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void hnLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            HN = retValue[0].ToString();
            patient = new Patient(HN, true);
            fillDemographic();
            //try
            //{
            //    HIS_Patient proxy = new HIS_Patient();
            //    DataSet ds = proxy.GetPatientAllergy(HN);
            //    if (Miracle.Util.Utilities.IsHaveData(ds))
            //    {
            //        btnPatientAllergy.Enabled = true;
            //        patient.AllergyData = ds.Tables[0].Copy();
            //    }
            //    else
            //        btnPatientAllergy.Enabled = false;
            //}
            //catch { }


            txtHN.Text = HN;
            txtHN.Tag = retValue[1];
            SendKeys.Send("{Tab}");

            //LoadInsurnaceType();
            LoadInsuranceDetail();
        }

        private void btnOrderDept_Click(object sender, EventArgs e)
        {

            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(departmentLookup_ValueUpdated);
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
                txtOrderDept.Text = retValue[0] + ":" + retValue[2];
                //LoadInsurnaceType();
                LoadInsuranceDetail();
            }
        }

        private void btnOrderDoc_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(doctorLookup_ValueUpdated);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.AddColumn("EMP_UID", "CODE", true, true);
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
            txtOrderDoc.Text = retValue[1] + ":" + retValue[2];

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

            lv.Data = lvS.ScheduleHaveParameter("Exam", modalityID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void examLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            //txtExamUID.Tag = retValue[0];
            //txtExamUID.Text = retValue[1];
            //txtExamName.Text = retValue[2];
            //txtRate.Tag = null;
            if (txtSession.Tag != null)
            {
                DataTable dtClinic = RISBaseData.RIS_ClinicType();
                DataTable dtExam = RISBaseData.Ris_Exam();
                DataRow[] rows = dttSession.Select("SESSION_ID=" + txtSession.Tag.ToString());
                if (rows.Length == 0) return;
                DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + rows[0]["CLINIC_TYPE_ID"].ToString());
                //DataRow[] drExam = Order.Ris_Exam().Select("EXAM_UID = '" + txtExamUID.Text + "'");
                //switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                //{
                //    case "Special":
                //        double rate = Convert.ToDouble(drExam[0]["SPECIAL_RATE"].ToString());
                //        txtRate.Text = rate.ToString("#,##0.00");
                //        break;
                //    case "VIP":
                //        rate = Convert.ToDouble(drExam[0]["VIP_RATE"].ToString());
                //        txtRate.Text = rate.ToString("#,##0.00");
                //        break;
                //    default:
                //        rate = Convert.ToDouble(drExam[0]["RATE"].ToString());
                //        txtRate.Text = rate.ToString("#,##0.00");
                //        break;
                //}


                #region OLDCODE. 11/06/2009
                //switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                //{
                //    case "Normal":
                //        txtRate.Text = drExam[0]["RATE"].ToString();
                //        break;
                //    case "Special":
                //        txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString();
                //        break;
                //    case "VIP":
                //        txtRate.Text = drExam[0]["VIP_RATE"].ToString();
                //        break;
                //    default:
                //        break;
                //} 
                #endregion
            }
            else
            {
                //txtRate.Text = retValue[3];
            }

        }

        private void btnClinic_Click(object sender, EventArgs e)
        {
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
            //DataTable dataExam = RISBaseData.Ris_Exam().Copy();
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

            txtSession_Validated();
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
            try
            {
                if (txtHN.Text.Length > 0)
                {
                    if (Miracle.Util.Utilities.IsHaveData(patient.AllergyData))
                    {
                        LookupData lv = new LookupData();
                        lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Adr_Clicks);
                        lv.Text = "Alergy Detail List";
                        lv.Data = patient.AllergyData;

                        Size ss = new Size(500, 200);
                        lv.Size = ss;
                        lv.ShowBox();
                    }
                    else
                    {
                        //   btnPatientAllergy.Enabled = false;
                        msg.ShowAlert("UID1134", env.CurrentLanguageID);
                    }
                }
            }
            catch
            {
                msg.ShowAlert("UID1134", env.CurrentLanguageID);
            }
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
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 47) e.Handled = true;
        }
        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHN.Text.Trim().Length == 0)
                    return;
                if (txtHN.Properties.ReadOnly == true)
                    return;
                if (txtHN.Text.Trim().Length == 0)
                    return;
                HN = txtHN.Text.Trim();
                patient = new Patient(txtHN.Text.Trim());
                if (!patient.LinkDown)
                {
                    if (patient.HasHN)
                    {
                        updateRegistrationAllergies();
                        fillDemographic();
                        txtHN.Text = HN;
                        grdLvPatStatus.Focus();
                        return;
                    }
                    else
                    {
                        msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                        clearContextControl();
                        enableDisableControl();
                        return;
                    }
                }
                patient = new Patient(txtHN.Text, true);

                if (patient.HasHN)
                {
                    string s = msg.ShowAlert("UID1016", env.CurrentLanguageID);
                    if (s == "1")
                    {
                        //wait
                        clearContextControl();
                        return;
                    }
                    else if (s == "2")
                    {
                        //create new
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

                        txtAGE.Visible = false;
                        txtDOB.Visible = true;
                        txtDOB.DateTime = DateTime.Today;
                        txtID.Focus();
                        cboGender.SelectedIndex = 0;
                        grdLvInsurance.Properties.ReadOnly = false;
                        grdLvInsurance.EditValue = 122;
                        return;
                    }
                    else
                    {
                        //used data
                        fillDemographic();
                        txtHN.Text = HN;
                        grdLvPatStatus.Focus();

                        return;
                    }
                }
                else
                {
                    string s = msg.ShowAlert("UID1015", env.CurrentLanguageID);
                    if (s == "1")
                    {
                        clearContextControl();
                        return;
                    }
                    else
                    {
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

                        txtAGE.Visible = false;
                        txtDOB.Visible = true;
                        txtDOB.DateTime = DateTime.Today;
                        txtID.Focus();
                        cboGender.SelectedIndex = 0;
                        grdLvInsurance.Properties.ReadOnly = false;
                        grdLvInsurance.EditValue = 122;
                        return;
                    }
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
        private void txtOrderDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //SendKeys.Send("{Tab}");
                txtOrderDoc.Focus();
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
        private void txtPrepation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }

        private void txtExamUID_Validating(object sender, CancelEventArgs e)
        {
            //if (txtExamUID.Text.Trim().Length == 0) {

            //    txtExamUID.Tag = null;
            //    txtExamName.Tag = null;

            //    txtExamUID.Text = string.Empty;
            //    txtExamName.Text = string.Empty;
            //    txtRate.Tag = null;
            //    txtRate.Text = "0.0";

            //    return;
            //}
            //DataRow[] dr = dttExamModality.Select("EXAM_UID='" + txtExamUID.Text.Trim() + "'");
            //if (dr.Length > 0)
            //{
            //    //txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
            //    //txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
            //    //txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
            //    //txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
            //    if (txtClinicType.Tag != null)
            //    {
            //        DataTable dtClinic = Order.RIS_ClinicType();
            //        DataTable dtExam = Order.Ris_Exam();
            //        DataRow[] rows = dttSession.Select("SESSION_ID=" + txtClinicType.Tag.ToString());
            //        if (rows.Length == 0) return;

            //        DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + rows[0]["CLINIC_TYPE_ID"].ToString());
            //        DataRow[] drExam = dtExam.Select("EXAM_UID = '" + txtExamUID.Text.Trim() + "'");
            //        if (drExam.Length == 0) {
            //            //txtExamUID.Tag = null;
            //            //txtExamUID.Text = string.Empty;
            //            //txtExamName.Tag = null;
            //            //txtExamName.Text = string.Empty;
            //            e.Cancel = true;
            //        }
            //        try
            //        {
            //            switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
            //            {
            //                case "Special":
            //                    double rate = Convert.ToDouble(drExam[0]["SPECIAL_RATE"].ToString());
            //                    //txtRate.Text = rate.ToString("#,##0.00");
            //                    break;
            //                case "VIP":
            //                    rate = Convert.ToDouble(drExam[0]["VIP_RATE"].ToString());
            //                    //txtRate.Text = rate.ToString("#,##0.00"); 
            //                    break;
            //                default:
            //                    rate = Convert.ToDouble(drExam[0]["RATE"].ToString());
            //                    //txtRate.Text = rate.ToString("#,##0.00");
            //                    break;
            //            }
            //        }
            //        catch {
            //            //txtExamUID.Tag = null;
            //            //txtExamUID.Text = string.Empty;
            //            //txtExamName.Tag = null;
            //            //txtExamName.Text = string.Empty;
            //            e.Cancel = true;
            //        }
            //    }
            //}
            //else
            //{
            //    //txtExamUID.Tag = null;
            //    //txtExamUID.Text = string.Empty;
            //    //txtExamName.Tag = null;
            //    //txtExamName.Text = string.Empty;
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
            //    txtRate.Tag = null;
            //    txtRate.Text = "0.00";
            //    return;
            //}
            #region OLD.
            //DataRow[] dr = dttExamModality.Select("EXAM_NAME='" + txtExamName.Text.Trim() + "'");
            //if (dr.Length > 0)
            //{
            //    txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
            //    txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
            //    txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
            //    txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
            //    if (txtClinicType.Tag != null)
            //    {
            //        DataTable dtClinic = Order.RIS_ClinicType();
            //        DataTable dtExam = Order.Ris_Exam();
            //        DataRow[] rows = dttSession.Select("SESSION_ID=" + txtClinicType.Tag.ToString());
            //        if (rows.Length == 0) return;

            //        DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + rows[0]["CLINIC_TYPE_ID"].ToString());
            //        DataRow[] drExam = Order.Ris_Exam().Select("EXAM_UID = '" + txtExamUID.Text + "'");
            //        switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
            //        {
            //            case "Special":
            //                txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString();
            //                break;
            //            case "VIP":
            //                txtRate.Text = drExam[0]["VIP_RATE"].ToString();
            //                break;
            //            default:
            //                txtRate.Text = drExam[0]["RATE"].ToString();
            //                break;
            //        }
            //    }
            //}
            //else
            //{
            //    txtExamUID.Tag = null;
            //    txtExamUID.SelectAll();
            //    txtExamName.Tag = null;
            //    txtExamName.Text = string.Empty;
            //    e.Cancel = true;
            //} 
            #endregion
        }
        private void txtFName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFName_Eng.Text.Trim().Length == 0 && txtFName.Text.Trim().Length > 0)
                txtFName_Eng.Text = TransToEnglish.Trans(txtFName.Text);
            if (txtFName.Text.Trim().Length == 0)
                txtFName_Eng.Text = string.Empty;

        }
        private void txtMName_Validating(object sender, CancelEventArgs e)
        {
            //if (txtMName_Eng.Text.Trim().Length == 0 && txtMName.Text.Trim().Length > 0)
            //    txtMName_Eng.Text = Miracle.Translator.TransToEnglish.Trans(txtMName.Text);
            //if (txtMName.Text.Trim().Length == 0)
            //    txtMName_Eng.Text = string.Empty;
        }
        private void txtLName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLName_Eng.Text.Trim().Length == 0 && txtLName.Text.Trim().Length > 0)
                txtLName_Eng.Text = TransToEnglish.Trans(txtLName.Text);
            if (txtLName.Text.Trim().Length == 0)
                txtLName_Eng.Text = string.Empty;
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
                    {
                        txtOrderDept.Tag = dr["UNIT_ID"].ToString();
                        txtOrderDept.Text = dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString();
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
                    //txtOrderDoc.Text = string.Empty;
                    //txtOrderDoc.Tag = null;
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
        private void txtPrepation_Validating(object sender, CancelEventArgs e)
        {
            //if (txtPrepation.Text.Trim() == string.Empty)
            //{
            //    txtPrepation.Tag = null;
            //}
            //else
            //{
            //    bool flag = true;
            //    LookUpSelect lvS = new LookUpSelect();
            //    DataTable dtt = lvS.ScheduleNotParameter("Prepation").Tables[0];
            //    DataRow d = null;
            //    foreach (DataRow dr in dtt.Rows)
            //    {
            //        if (txtPrepation.Text.Trim().ToUpper() == dr["PREPARATION_DESC"].ToString().Trim().ToUpper())
            //        {
            //            txtPrepation.Tag = dr["PREPARATION_ID"].ToString();
            //            txtPrepation.Text = dr["PREPARATION_DESC"].ToString();
            //            flag = false;
            //            d = dr;
            //            break;
            //        }
            //    }
            //    if (flag)
            //    {
            //        msg.ShowAlert("UID4023", env.CurrentLanguageID);
            //        txtPrepation.SelectAll();
            //        txtPrepation.Focus();
            //        e.Cancel = true;//ไม่ยอมให้ไป
            //    }
            //    else
            //    {
            //        e.Cancel = false;
            //    }
            //}
        }
        private void txtHN_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(HN))
            {
                if (txtHN.Text.Trim().ToUpper() == HN.Trim().ToUpper()) return;
                Patient p = new Patient(txtHN.Text, true);
                if (p.HasHN)
                {
                    patient = new Patient(txtHN.Text, true);
                    HN = txtHN.Text.Trim();
                    fillDemographic();
                    txtHN.Text = HN;
                    SendKeys.Send("{Tab}");
                }
                else
                {
                    txtHN.Text = HN.Trim();
                    SendKeys.Send("{Tab}");
                }
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
        #endregion

        #region Grid Appointment.
        private void initGridAppointment()
        {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RIS_SCHEDULE.HN = patient.Reg_UID;
            process.RIS_SCHEDULE.SCHEDULE_DT = DateTime.Today;
            DataTable dtt = process.GetAppointment();
            grdData.DataSource = dtt;

            setColumnShow();
        }
        private void initGridAppointment(string HN)
        {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RIS_SCHEDULE.HN = HN;
            process.RIS_SCHEDULE.SCHEDULE_DT = DateTime.Today;
            DataTable dtt = process.GetAppointment();
            grdData.DataSource = dtt;
            setColumnShow();

        }
        private void setColumnShow()
        {
            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["START_DATETIME"].Visible = true;
            view1.Columns["START_DATETIME"].Caption = "Appoint Date";
            view1.Columns["START_DATETIME"].ColVIndex = 0;
            view1.Columns["START_DATETIME"].Width = 100;

            view1.Columns["START_DATETIME"].Visible = true;
            view1.Columns["START_DATETIME"].Caption = "Start";
            view1.Columns["START_DATETIME"].ColVIndex = 1;
            view1.Columns["START_DATETIME"].DisplayFormat.FormatString = "T";
            view1.Columns["START_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view1.Columns["START_DATETIME"].Width = 80;

            view1.Columns["END_DATETIME"].Visible = true;
            view1.Columns["END_DATETIME"].Caption = "End";
            view1.Columns["END_DATETIME"].DisplayFormat.FormatString = "T";
            view1.Columns["END_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view1.Columns["END_DATETIME"].ColVIndex = 2;
            view1.Columns["END_DATETIME"].Width = 80;

            view1.Columns["MODALITY_NAME"].Visible = true;
            view1.Columns["MODALITY_NAME"].Caption = "Modality";
            view1.Columns["MODALITY_NAME"].ColVIndex = 3;
            view1.Columns["MODALITY_NAME"].Width = 150;


            view1.Columns["EXAM_NAME"].Visible = true;
            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            view1.Columns["EXAM_NAME"].ColVIndex = 4;
            view1.Columns["EXAM_NAME"].Width = 250;


            view1.Columns["APPBY"].Visible = true;
            view1.Columns["APPBY"].Caption = "By";
            view1.Columns["APPBY"].ColVIndex = 5;
            view1.Columns["APPBY"].Width = 120;


        }
        #endregion

        #region Grid Exam.
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
        private void initEmptyRows()
        {
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule(0);
            proc.Invoke();
            DataTable dt = proc.Result.Tables[0].Copy();
            dttExam = new DataTable();
            dttExam = proc.Result.Tables[1].Copy();

            addEmptyRow();
        }
        private void initGridExam()
        {
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
            viewExam.Columns["FLAG_ICON"].VisibleIndex = 2;

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
            viewExam.Columns["EXAM_UID"].VisibleIndex = 3;

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
            viewExam.Columns["EXAM_NAME"].VisibleIndex = 4;

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
            rleBPView.DataSource = dttBpview;
            rleBPView.NullText = string.Empty;
            rleBPView.KeyUp += new KeyEventHandler(BPView_KeyUp);
            rleBPView.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(BPView_CloseUp);
            rleBPView.BestFit();
            rleBPView.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["BPVIEW_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["BPVIEW_ID"].ColumnEdit = rleBPView;
            viewExam.Columns["BPVIEW_ID"].Caption = "Sides";
            viewExam.Columns["BPVIEW_ID"].VisibleIndex = 5;

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
            viewExam.Columns["QTY"].VisibleIndex = 6;
            viewExam.Columns["QTY"].OptionsColumn.ReadOnly = true;

            viewExam.Columns["RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["RATE"].Caption = "Rate";
            viewExam.Columns["RATE"].Width = 80;
            viewExam.Columns["RATE"].VisibleIndex = 7;
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
            viewExam.Columns["AVG_REQ_MIN"].ColumnEdit = rpsReq;
            viewExam.Columns["AVG_REQ_MIN"].VisibleIndex = 8;

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
            viewExam.Columns["PREPATION_ID"].VisibleIndex = 9;

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
            rpsRadio.DataSource = dttRadiologist;
            rpsRadio.BestFit();
            rpsRadio.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EMP_ID"].ColumnEdit = rpsRadio;
            viewExam.Columns["EMP_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EMP_ID"].Caption = "Radiologist";
            viewExam.Columns["EMP_ID"].Width = 150;
            viewExam.Columns["EMP_ID"].VisibleIndex = 10;

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
            viewExam.Columns["DELETE"].Visible = true;
            viewExam.Columns["DELETE"].Caption = " ";
            viewExam.Columns["DELETE"].Width = 30;
            viewExam.Columns["DELETE"].VisibleIndex = 11;
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

                DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype);
                string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL": dr["RATE"] = chkNonResident.Checked ? rows[0]["FOREIGN_SPCIAL_RATE"].ToString() : rows[0]["SPECIAL_RATE"].ToString(); break;
                    case "VIP": dr["RATE"] = chkNonResident.Checked ? rows[0]["FOREIGN_VIP_RATE"].ToString() : rows[0]["VIP_RATE"].ToString(); break;
                    default: dr["RATE"] = chkNonResident.Checked ? rows[0]["FOREIGN_RATE"].ToString() : rows[0]["RATE"].ToString(); break;
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
                //DataRow dr = dttExam.Rows[viewExam.FocusedRowHandle];
                //dr["PREPATION_ID"] = rows[0]["PREPARATION_ID"];
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

                        layoutPatient.Enabled = true;
                        groupVisit.Enabled = true;
                        groupTiming.Enabled = true;


                    }
                    else
                    {
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
        private void viewExam_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
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
                            string _bpview_id = string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString()) ? "0" : dr["BPVIEW_ID"].ToString();
                            DataRow[] drbp = RISBaseData.BP_View().Select("BPVIEW_ID =" + _bpview_id);
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
            ugentToolStripMenuItem.Image = null;
            statToolStripMenuItem.Image = null;
            rountineToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            dr["SCHEDULE_PRIORITY"] = "R";
            dr["PRIORITY_TEXT"] = "Routine";
            viewExam.RefreshData();
        }
        private void ugentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rountineToolStripMenuItem.Image = null;
            statToolStripMenuItem.Image = null;
            ugentToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            dr["SCHEDULE_PRIORITY"] = "U";
            dr["PRIORITY_TEXT"] = "Urgent";
            viewExam.RefreshData();
        }
        private void statToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rountineToolStripMenuItem.Image = null;
            ugentToolStripMenuItem.Image = null;
            statToolStripMenuItem.Image = Envision.NET.Properties.Resources.QA;
            DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
            dr["SCHEDULE_PRIORITY"] = "S";
            dr["PRIORITY_TEXT"] = "Stat";
            viewExam.RefreshData();
        }
        #endregion

        #region Start/End DateTime.
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
                            case "SPECIAL": dr["RATE"] = chkNonResident.Checked ? rowsExam[0]["FOREIGN_SPCIAL_RATE"].ToString() : rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                            case "VIP": dr["RATE"] = chkNonResident.Checked ? rowsExam[0]["FOREIGN_VIP_RATE"].ToString() : rowsExam[0]["VIP_RATE"].ToString(); break;
                            default: dr["RATE"] = chkNonResident.Checked ? rowsExam[0]["FOREIGN_RATE"].ToString() : rowsExam[0]["RATE"].ToString(); break;
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
        private void btnRecurrence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHN.Text.Trim())) return;
            if (chkBlock.Checked == false && chkComments.Checked == false)
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
                    //if (controller.EditedAppointmentCopy != editedAptCopy)
                    //{
                    dtStart.DateTime = controller.DisplayStart.Date;
                    dtEnd.DateTime = controller.DisplayEnd.Date;
                    timeStart.Time = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                    timeEnd.Time = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);
                    chkAllDay.Checked = controller.AllDay;
                    //}
                }
        }

        #region Insurance Webservice Process
        private void LoadInsuranceDetail()
        {
            //FinancialBilling fnBill = new FinancialBilling();
            //string strUNIT_UID = " ";
            //string strUNIT_NAME = " ";

            //fnBill.LoadHRUnit(patient.REF_UNIT, ref strUNIT_UID, ref strUNIT_NAME);
            //String strEnc_id = "";
            //String strEnc_type = "";
            //string perfDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            //fnBill.LoadEncounter(txtHN.Text, strUNIT_UID, ref strEnc_id, ref strEnc_type);

            //if (strEnc_id == "") strEnc_id = " ";
            //if (strEnc_type == "") strEnc_type = " ";

            //string insu_uid = fnBill.LoadGetEligibilityInsuranceDetail(txtHN.Text, strEnc_id, strEnc_type, strUNIT_UID, perfDate, "RGL");

            //int insu_id = 0;
            //string insu_name = "";
            //fnBill.LoadInsuranceType(insu_uid, ref insu_id, ref insu_name);
            DataTable dtInsu = RISBaseData.Ris_InsuranceType();
            grdLvInsurance.Properties.DataSource = dtInsu;
            grdLvInsurance.Properties.DisplayMember = "INSURANCE_TYPE_DESC";
            grdLvInsurance.Properties.ValueMember = "INSURANCE_TYPE_ID";

            grdLvInsurance.EditValue = patient.InsuranceID;
        }
        #endregion
        private void txtOrderDept_Validated(object sender, EventArgs e)
        {
            //LoadInsurnaceType();
            LoadInsuranceDetail();
        }
        private void txtSession_Validated()
        {
            //LoadInsurnaceType();
            LoadInsuranceDetail();
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
            //frmScheduleSummary frm = new frmScheduleSummary(txtHN.Text);
            //frm.ShowDialog();
            //frm.Dispose();
            //int regID = txtHN.Tag == null ? 0 : Convert.ToInt32(txtHN.Tag.ToString());
            switch (_mode)
            {
                case 1: _summary.ShowDialog(true, txtHN.Text, 0, 0, frmPopupOrderOrScheduleSummary.PagesModes.Schedule, false); break;
                case 2:
                    int exam_id = string.IsNullOrEmpty(dttExam.Rows[0]["EXAM_ID"].ToString()) ? 0 : Convert.ToInt32(dttExam.Rows[0]["EXAM_ID"]);
                    _summary.ShowDialog(true, txtHN.Text, xrayreqID, exam_id, frmPopupOrderOrScheduleSummary.PagesModes.Order, false); break;
            }

        }

        private void chkNonResident_EditValueChanged(object sender, EventArgs e)
        {
            dttExam = (DataTable)grdExam.DataSource;

            chkNonResident.ForeColor = chkNonResident.Checked ? Color.Red : Color.Black;

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
                            drExam["RATE"] = chkNonResident.Checked ? rows[0]["FOREIGN_SPCIAL_RATE"].ToString() : rows[0]["SPECIAL_RATE"].ToString();
                            break;
                        case "VIP":
                            drExam["RATE"] = chkNonResident.Checked ? rows[0]["FOREIGN_VIP_RATE"].ToString() : rows[0]["VIP_RATE"].ToString();
                            break;
                        default:
                            drExam["RATE"] = chkNonResident.Checked ? rows[0]["FOREIGN_RATE"].ToString() : rows[0]["RATE"].ToString();
                            break;
                    }
                }
            }
            calTotal();
            calculateTime();
            viewExam.RefreshData();
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
                dtRequestResult.DateTime = dateStart;
            }
            else
            {
                dtRequestResult.Enabled = false;
                timeReqeustResult.Enabled = false;
                dtRequestResult.Text = "";
            }
        }

        private void pictureEdit1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmCheckFreeSlots frm = new frmCheckFreeSlots(modalityID);
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