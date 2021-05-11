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
using RIS.Forms.GBLMessage;
using RIS.Common.Common;
using RIS.BusinessLogic;
using DevExpress.XtraEditors.Repository;
using RIS.Operational;

namespace RIS.Forms.Schedule
{
    public partial class frmAppointment : Form
    {
        private SchedulerControl control;
        private Appointment apt;

        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private Patient patient;
        private DataTable dttExamModality;
        private DataTable dttModalityClinic;
        private DataTable dttSession;

        private int pat_id,schedule_id,clinictype;

        public frmAppointment(SchedulerControl control, Appointment apt)
        {
            this.apt = apt;
            this.control = control;
            InitializeComponent();
            initControlFirst();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");
            SetLookupAllGrid();
        }

        private void initControlFirst()
        {
            try
            {
                initDefaultControlStart();
                enableDisableControl();
                initGridAppointment("000");
                setModalityClinicType();
                
                txtModality.Text = ModalityName(apt.ResourceId.ToString());
                dtStart.DateTime = apt.Start;
                dtEnd.DateTime = apt.End;
                setAutoComplete();
                initDefaultSession();
                if (apt.Location.Trim().Length == 0)
                {
                    timeStart.Time = apt.Start;
                    timeEnd.Time = apt.End;
                    groupTiming.Enabled = true;

                }
            }
            catch (Exception ecp) { }
        }

        private string ModalityName(string ID) {
            string name=string.Empty;
            RIS.BusinessLogic.ProcessGetRISModality process = new RIS.BusinessLogic.ProcessGetRISModality(true);
            process.Invoke();
            DataTable dttModaltiy = new DataTable();
            dttModaltiy = process.Result.Tables[0].Copy();
            DataRow[] dr = dttModaltiy.Select("MODALITY_ID =" + ID);
            if (dr.Length > 0)
                name = dr[0]["MODALITY_NAME"].ToString();
            return name;
        }
        private void clearContextControl() {
            txtHN.Text = string.Empty;
            
            txtFName.Text = string.Empty;
            txtMName.Text = string.Empty;
            txtLName.Text = string.Empty;
            
            txtFName_Eng.Text = string.Empty;
            txtMName_Eng.Text = string.Empty;
            txtLName_Eng.Text = string.Empty;

            txtID.Text = string.Empty;
            dtDOB.DateTime = DateTime.Now;
            cboGender.SelectedIndex = 0;
            txtPhone.Text = string.Empty;
            txtMobile.Text = string.Empty;
            dtLastVisit.DateTime = DateTime.Now;
            dtNextVisit.DateTime = DateTime.Now;
            txtOrderDept.Tag = null;
            txtOrderDept.Text = string.Empty;
            txtOrderDoc.Tag = null;
            txtOrderDoc.Text = string.Empty;
            txtExamUID.Tag = null;
            txtExamUID.Text = string.Empty;
            txtExamName.Text = string.Empty;

            txtRate.Text = "0.00";

            deLMP.DateTime = DateTime.Now;

            //txtClinicType.Tag = null;
            //txtClinicType.Text = string.Empty;
        }
        private void initDefaultControlStart() {

            dtLastVisit.DateTime = DateTime.Today;
            dtNextVisit.DateTime = DateTime.Today;
            dtLastVisit.Text = DateTime.Today.ToString("dddd dd/MM/yyyy");
            dtNextVisit.Text = DateTime.Today.ToString("dddd dd/MM/yyyy");

            dtDOB.DateTime = DateTime.Today;
            dtDOB.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cboGender.Properties.Items.Clear();
            cboGender.Properties.Items.Add("Male");
            cboGender.Properties.Items.Add("Female");
            cboGender.SelectedIndex = 0;
        }
        private void doTimerValidated() {
            if ((timeStart.Time > timeEnd.Time) || (timeEnd.Time < timeStart.Time))
            {
                dxErrorProvider1.SetError(timeStart, "more than end time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(timeEnd, "less than start time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
                dxErrorProvider1.ClearErrors();
        }
        private void doDateValidated() {
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

            DateTime start = dtStart.DateTime;
            DateTime end = dtEnd.DateTime;
            if (start > end)
            {
                dxErrorProvider1.SetError(dtStart, "date start more than end date", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
                dtEnd.ErrorText = string.Empty;

        }
        private void enableDisableControl() {
            groupPatient.Enabled = true;
            enableDisableGroupPatient(false);
            groupVisit.Enabled = false;
            groupExam.Enabled = false;
            groupTiming.Enabled = false;
            txtHN.Enabled = true;

            txtExamUID.BackColor = txtModality.BackColor;
            txtExamName.BackColor = txtModality.BackColor;
            txtExamUID.ReadOnly = true;
            txtExamName.ReadOnly = true;

            txtOrderDept.BackColor = txtModality.BackColor;
            txtOrderDoc.BackColor = txtModality.BackColor;
            txtOrderDept.ReadOnly = true;
            txtOrderDoc.ReadOnly = true;
           

        }
        private void enableDisableGroupPatient(bool flag) {
            txtHN.Enabled = flag;
            txtFName.Enabled = flag;
            txtMName.Enabled = flag;
            txtLName.Enabled = flag;
            txtFName_Eng.Enabled = flag;
            txtMName_Eng.Enabled = flag;
            txtLName_Eng.Enabled = flag;
            txtID.Enabled = flag;
            dtDOB.Enabled = flag;
            cboGender.Enabled = flag;
            txtPhone.Enabled = flag;
            txtMobile.Enabled = flag;
            deLMP.Enabled = flag;
        }

        private bool insertData()
        {
            ProcessAddRISSchedule process = new RIS.BusinessLogic.ProcessAddRISSchedule();
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            if (chkBlock.Checked)
            {
                #region insert block.
                process.RISSchedule.APPOINT_DT = start;
                process.RISSchedule.CREATED_BY = env.UserID;
                process.RISSchedule.END_DATETIME = end;
                process.RISSchedule.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                process.RISSchedule.ORG_ID = env.OrgID;
                process.RISSchedule.REASON = txtReason.Text;
                process.RISSchedule.SCHEDULE_DATA ="BLOCK - " +  txtReason.Text;
                process.RISSchedule.SCHEDULE_ID = 0;
                process.RISSchedule.SCHEDULE_STATUS = "S";
                process.InvokeBlock();
                if (process.RISSchedule.SCHEDULE_ID > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string s = msg.ShowAlert("UID1102", env.CurrentLanguageID);
                    dtStart.Focus();
                    return false;
                } 
	            #endregion
            }
            else 
            {
                #region his_registration.
                int regID = 0;
                if (patient.DataFromHIS)
                {
                    ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                    pAddHIS.HISRegistration.ADDR1 = patient.Address1;
                    pAddHIS.HISRegistration.ADDR2 = patient.Address2;
                    pAddHIS.HISRegistration.ADDR3 = patient.Address3;
                    pAddHIS.HISRegistration.ADDR4 = patient.Address4;
                    pAddHIS.HISRegistration.EM_CONTACT_PERSON = patient.Em_Contact_Person;
                    pAddHIS.HISRegistration.EMAIL = patient.Email;
                    pAddHIS.HISRegistration.NATIONALITY = patient.Nationality;
                    pAddHIS.HISRegistration.CREATED_BY = env.UserID;
                    pAddHIS.HISRegistration.DOB = patient.DateOfBirth;
                    pAddHIS.HISRegistration.FNAME = patient.FirstName;
                    pAddHIS.HISRegistration.FNAME_ENG = txtFName_Eng.Text.Trim().Length == 0 ? patient.FirstName_ENG   : txtFName_Eng.Text;
                    pAddHIS.HISRegistration.MNAME_ENG = txtMName_Eng.Text.Trim().Length == 0 ? patient.MiddleName_ENG  : txtMName_Eng.Text;
                    pAddHIS.HISRegistration.GENDER = cboGender.SelectedIndex == 0 ? "M" : "F";
                    pAddHIS.HISRegistration.HN = patient.Reg_UID;
                    pAddHIS.HISRegistration.LNAME = patient.LastName;
                    pAddHIS.HISRegistration.LNAME_ENG = txtLName_Eng.Text.Trim().Length == 0 ? patient.LastName_ENG    : txtLName_Eng.Text;
                    pAddHIS.HISRegistration.ORG_ID = env.OrgID;
                    pAddHIS.HISRegistration.PHONE1 = txtPhone.Text;
                    pAddHIS.HISRegistration.PHONE2 = txtMobile.Text;
                    pAddHIS.HISRegistration.PHONE3 = patient.Phone3;
                    pAddHIS.HISRegistration.SSN = patient.SocialNumber;
                    pAddHIS.HISRegistration.TITLE = patient.Title;
                    pAddHIS.HISRegistration.TITLE_ENG = patient.Title_ENG;
                    pAddHIS.HISRegistration.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    pAddHIS.Invoke();
                    regID = pAddHIS.HISRegistration.REG_ID;
                }
                else if (patient.LinkDown) {
                    ProcessAddHISRegistration pHIS = new ProcessAddHISRegistration(true);
                    pHIS.HISRegistration.ADDR1 = string.Empty;
                    pHIS.HISRegistration.CREATED_BY = env.UserID;
                    pHIS.HISRegistration.DOB = dtDOB.DateTime;
                    pHIS.HISRegistration.FNAME = txtFName.Text;
                    pHIS.HISRegistration.FNAME_ENG = txtFName_Eng.Text;
                    pHIS.HISRegistration.GENDER = cboGender.SelectedIndex == 0 ? "M" : "F";
                    pHIS.HISRegistration.HN = txtHN.Text;
                    pHIS.HISRegistration.LNAME = txtLName.Text;
                    pHIS.HISRegistration.LNAME_ENG = txtLName_Eng.Text;
                    pHIS.HISRegistration.ORG_ID = env.OrgID;
                    pHIS.HISRegistration.PHONE1 = txtPhone.Text;
                    pHIS.HISRegistration.PHONE2 = txtMobile.Text;
                    pHIS.HISRegistration.SSN = txtID.Text;
                    pHIS.HISRegistration.TITLE = string.Empty;
                    pHIS.HISRegistration.TITLE_ENG = string.Empty;
                    pHIS.HISRegistration.LINK_DOWN = "Y";
                    pHIS.HISRegistration.INSURANCE_TYPE = string.Empty;
                    pHIS.Invoke();
                    regID = pHIS.HISRegistration.REG_ID;
                    patient.Reg_UID = txtHN.Text;
                }
                else
                {
                    ProcessUpdateHISRegistration pUpdateHIS = new ProcessUpdateHISRegistration();
                    pUpdateHIS.HISRegistration.ADDR1 = patient.Address1;
                    pUpdateHIS.HISRegistration.LAST_MODIFIED_BY = env.UserID;
                    pUpdateHIS.HISRegistration.DOB = patient.DateOfBirth;
                    pUpdateHIS.HISRegistration.FNAME = patient.FirstName;
                    pUpdateHIS.HISRegistration.FNAME_ENG = patient.FirstName_ENG;
                    pUpdateHIS.HISRegistration.GENDER = patient.Gender;
                    pUpdateHIS.HISRegistration.HN = patient.Reg_UID;
                    pUpdateHIS.HISRegistration.LNAME = patient.LastName;
                    pUpdateHIS.HISRegistration.LNAME_ENG = patient.LastName_ENG;
                    pUpdateHIS.HISRegistration.ORG_ID = env.OrgID;
                    pUpdateHIS.HISRegistration.PHONE1 = patient.Phone1;
                    pUpdateHIS.HISRegistration.SSN = patient.SocialNumber;
                    pUpdateHIS.HISRegistration.TITLE = patient.Title;
                    pUpdateHIS.HISRegistration.TITLE_ENG = patient.Title_ENG;
                    pUpdateHIS.HISRegistration.REG_ID = patient.Reg_ID;
                    pUpdateHIS.HISRegistration.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    pUpdateHIS.Invoke();
                    regID = patient.Reg_ID;
                } 
                #endregion

                #region insert normal.
               
                process.RISSchedule.APPOINT_DT = start;
                process.RISSchedule.BLOCK_REASON = null;
                process.RISSchedule.CLINIC_TYPE = clinictype;//Convert.ToInt32(txtClinicType.Tag.ToString());
                process.RISSchedule.CREATED_BY = env.UserID;
                process.RISSchedule.END_DATETIME = end;
                process.RISSchedule.EXAM_ID = Convert.ToInt32(txtExamUID.Tag.ToString());
                process.RISSchedule.HN = patient.Reg_UID;
                process.RISSchedule.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                process.RISSchedule.ORG_ID = env.OrgID;
                process.RISSchedule.RATE = Convert.ToDecimal(txtRate.Text);
                process.RISSchedule.REASON = txtReason.Text;
                if (txtOrderDept.Tag != null)
                    if (!string.IsNullOrEmpty(txtOrderDept.Tag.ToString()))
                        process.RISSchedule.REF_UNIT = Convert.ToInt32(txtOrderDept.Tag.ToString());
                if (txtOrderDoc.Tag != null)
                    if (!string.IsNullOrEmpty(txtOrderDoc.Tag.ToString()))
                        process.RISSchedule.REF_DOC = Convert.ToInt32(txtOrderDoc.Tag.ToString());
                process.RISSchedule.REG_ID = regID;
                process.RISSchedule.SCHEDULE_DATA = patient.Reg_UID + "," + patient.FirstName + " " + patient.MiddleName + " " + patient.LastName + "," + txtExamName.Text;
                process.RISSchedule.SCHEDULE_DT = start;
                process.RISSchedule.SCHEDULE_ID = 0;
                process.RISSchedule.SCHEDULE_STATUS = "S";
                process.RISSchedule.RATE = Convert.ToDecimal(txtRate.Text);
                if (txtRate.Tag != null)
                    process.RISSchedule.GEN_DTL_ID = Convert.ToInt32(txtRate.Tag);
                else
                    process.RISSchedule.GEN_DTL_ID = 0;
                if (txtRadiologist.Tag != null)
                {
                    process.RISSchedule.RAD_ID = Convert.ToInt32(txtRadiologist.Tag);
                }
                else
                {
                    process.RISSchedule.RAD_ID = 0;
                }
                process.RISSchedule.PATSTATUS_ID = pat_id;
                process.RISSchedule.LMP_DT = deLMP.DateTime;
                process.RISSchedule.QTY = (byte)speQTY.Value;
                process.RISSchedule.SESSION_ID = Convert.ToInt32(txtClinicType.Tag);

                process.Invoke();
                if (process.RISSchedule.SCHEDULE_ID > 0)
                {
                    schedule_id = process.RISSchedule.SCHEDULE_ID;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (process.RISSchedule.SCHEDULE_ID == -2)
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

                RIS.Operational.Scanner.SaveScannedImage save = null;

                save = new RIS.Operational.Scanner.SaveScannedImage(patient.Reg_UID, process.RISSchedule.SCHEDULE_ID, "Schedule");

                #endregion
            }
            return true;
            
        }

        private void fillDemographic()
        {
            if (patient != null)
            {
                initDefaultSession();
                txtHN.Text = patient.Reg_UID;
                txtFName.Text = patient.FirstName;
                txtMName.Text = patient.MiddleName;
                txtLName.Text = patient.LastName;
                txtFName_Eng.Text = patient.FirstName_ENG;
                txtMName_Eng.Text = patient.MiddleName_ENG;
                txtLName_Eng.Text = patient.LastName_ENG;
                txtID.Text = patient.SocialNumber;

                dtDOB.DateTime = string.IsNullOrEmpty(patient.DateOfBirth.ToString()) ? DateTime.Now : patient.DateOfBirth;
                LookUpSelect lu = new LookUpSelect();
                txtAGE.Text = lu.SelectAGE(dtDOB.DateTime).Tables[0].Rows[0]["AGE"].ToString();

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
                txtPhone.Text = patient.Phone1;
                txtMobile.Text = patient.Phone2;
                dtLastVisit.DateTime = string.IsNullOrEmpty(patient.Last_Modified_ON.ToString()) ? DateTime.Now : patient.Last_Modified_ON;
                dtNextVisit.DateTime = DateTime.Now.AddDays(1);

                enableDisableGroupPatient(true);
                groupVisit.Enabled = true;
                groupExam.Enabled = true;
                groupTiming.Enabled = true;
                grdLvPatStatus.Enabled = true;
                
                txtExamUID.BackColor = Color.White;
                txtExamName.BackColor = Color.White;
                txtExamUID.ReadOnly = false;
                txtExamName.ReadOnly = false;

                txtOrderDept.BackColor = Color.White;
                txtOrderDoc.BackColor = Color.White;
                txtOrderDept.ReadOnly = false;
                txtOrderDoc.ReadOnly = false;

                initGridAppointment();

                #region Group Exam.
                DataRow[] drExam;
                if (txtExamUID.Tag != null)
                {
                    int exam_id = Convert.ToInt32(txtExamUID.Tag.ToString());
                    RIS.BusinessLogic.ProcessGetRISExam process = new RIS.BusinessLogic.ProcessGetRISExam(true);
                    process.Invoke();

                    DataTable dttExam = process.Result.Tables[0].Copy();
                    drExam = dttExam.Select("EXAM_ID=" + exam_id.ToString());
                    txtExamUID.Tag = drExam[0]["EXAM_ID"].ToString();
                    txtExamUID.Text = drExam[0]["EXAM_UID"].ToString();
                    txtExamName.Text = drExam[0]["EXAM_NAME"].ToString();
                    txtRate.Text = drExam[0]["RATE"].ToString();
                }
                #endregion

                if (txtRate.Tag!=null)
                    if(txtRate.Tag.ToString().Trim().Length>0)
                        txtRate.Text = "0.00";


                #region Group Visit.
                int id = 0;
                DataTable dtt = new DataTable();
                if (txtOrderDept.Tag != null)
                {
                    if (int.TryParse(txtOrderDept.Tag.ToString(), out id))
                    {
                        RIS.BusinessLogic.ProcessGetHRUnit unit = new RIS.BusinessLogic.ProcessGetHRUnit();
                        unit.Invoke();
                        dtt = unit.Result.Tables[0].Copy();
                        drExam = dtt.Select("UNIT_ID=" + id.ToString());
                        if (drExam.Length > 0)
                        {
                            txtOrderDept.Tag = drExam[0]["UNIT_ID"].ToString();
                            txtOrderDept.Text = drExam[0]["UNIT_NAME"].ToString();
                        }
                    }
                }
                if (txtOrderDoc.Tag != null)
                {
                    if (int.TryParse(txtOrderDoc.Tag.ToString(), out id))
                    {
                        RIS.BusinessLogic.ProcessGetHISDoctor doc = new RIS.BusinessLogic.ProcessGetHISDoctor();
                        doc.Invoke();
                        dtt = doc.Result.Tables[0].Copy();
                        drExam = dtt.Select("EMP_ID=" + id.ToString());
                        if (drExam.Length > 0)
                        {
                            txtOrderDoc.Tag = drExam[0]["EMP_ID"].ToString();
                            txtOrderDoc.Text = drExam[0]["RadioName"].ToString();
                        }
                    }
                }
                #endregion

                groupPatient.Enabled = true;
                DataTable data = order.His_Department();
                DataRow[] drs = data.Select("UNIT_ID=" + patient.REF_UNIT);
                if (drs.Length > 0)
                {
                    txtOrderDept.Tag = drs[0]["UNIT_ID"].ToString();
                    txtOrderDept.Text = drs[0]["UNIT_NAME"].ToString();
                }
                data = order.Ris_Radiologist();
                drs = data.Select("EMP_ID=" + patient.REF_DOC);
                if (drs.Length > 0)
                {
                    txtOrderDoc.Tag = patient.REF_DOC;
                    txtOrderDoc.Text = drs[0]["RadioName"].ToString();

                }
            }
            else
            {
                txtHN.Text = string.Empty;
                txtExamUID.BackColor = txtModality.BackColor;
                txtExamName.BackColor = txtModality.BackColor;
                txtExamUID.ReadOnly = true;
                txtExamName.ReadOnly = true;

                txtOrderDept.BackColor = txtModality.BackColor;
                txtOrderDoc.BackColor = txtModality.BackColor;
                txtOrderDept.ReadOnly = true;
                txtOrderDoc.ReadOnly = true;

                groupExam.Enabled = false;
                groupVisit.Enabled = false;
                groupPatient.Enabled = true;
                grdData.DataSource = null;
                txtHN.Enabled = true;
            }
        }

        private void dtStart_EditValueChanged(object sender, System.EventArgs e)
        {
            doDateValidated();
        }
        private void dtEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            doDateValidated();
        }
        private void dtEnd_Enter(object sender, EventArgs e)
        {
            doDateValidated();
        }
        private void dtStart_Enter(object sender, EventArgs e)
        {
            doDateValidated();
        }

        private void timeStart_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
        }
        private void timeEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
        }
        private void timeStart_Enter(object sender, EventArgs e)
        {
            doTimerValidated();
        }
        private void timeEnd_Enter(object sender, EventArgs e)
        {
            doTimerValidated();
        }

        private bool requireCheck11111() {
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
            if (txtOrderDept.Text.Trim().Length == 0)
            {
                if (chkBlock.Checked)
                {
                    txtOrderDept.Focus();
                    return true;
                }
                else
                {
                    txtOrderDept.Focus();
                    return false;
                }

            }
            if (txtOrderDoc.Text.Trim().Length == 0)
            {
                if (chkBlock.Checked)
                {
                    txtOrderDoc.Focus();
                    return true;
                }
                else
                {
                    txtOrderDoc.Focus();
                    return false;
                }

            }
            if (chkBlock.Checked == false)
            {
                if (txtExamUID.Text.Trim().Length == 0)
                {
                    msg.ShowAlert("UID0046", env.CurrentLanguageID);
                    btnExam.Focus();
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
            
            #endregion

            if (chkBlock.Checked == false)
            {

                #region ตรวจสอบ ว่าช่วงเวลาที่เลือกอยู่ในประเภทคลีนิคหรือไม่.
                DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
                DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
                DataRow[] drs = dttModalityClinic.Select("CLINIC_TYPE_ID=" + txtClinicType.Tag.ToString() + " AND MODALITY_ID=" + apt.ResourceId.ToString());
                int max_app = 0;
                int curr_app = 0;
                DateTime dtsTmp = DateTime.Today;
                DateTime dteTmp = DateTime.Today;
                if (drs.Length > 0)
                {

                    dtsTmp = Convert.ToDateTime(drs[0]["START_DATETIME"]);
                    dtsTmp = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, dtsTmp.Hour, dtsTmp.Minute, 0);
                    dteTmp = Convert.ToDateTime(drs[0]["END_DATETIME"]);
                    dteTmp = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, dteTmp.Hour, dteTmp.Minute, 0);
                    if (!((start >= dtsTmp && start <= dteTmp) && (end >= dtsTmp && end <= dteTmp)))
                    {
                        string s = msg.ShowAlert("UID1112", env.CurrentLanguageID);
                        if (s == "1")
                            return false;
                    }

                }
                #endregion

                #region เช็คดูว่าช่วงเวลาที่เลือกเกิน Max ที่รับได้หรือยัง.
                ProcessGetRISModalityclinictype process = new ProcessGetRISModalityclinictype();
                if (drs.Length > 0)
                {
                    process.RISSchedule.SCHEDULE_ID = 0;
                    process.RISSchedule.APPOINT_DT = dtsTmp;
                    process.RISSchedule.END_DATETIME = dteTmp;
                    process.RISSchedule.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                    DataTable dtt = process.GetCheckMax();

                    if (dtt.Rows.Count > 0)
                    {
                        max_app = Convert.ToInt32(drs[0]["MAX_APP"]);
                        curr_app = Convert.ToInt32(dtt.Rows[0][0]);
                        curr_app++;
                    }
                }
                else
                {
                    ProcessGetRISModality processmol = new ProcessGetRISModality(true);
                    processmol.Invoke();
                    DataTable dttMol = processmol.Result.Tables[0].Copy();
                    drs = dttMol.Select("MODALITY_ID=" + apt.ResourceId.ToString());
                    if (drs.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(drs[0]["CASE_PER_DAY"].ToString()))
                            max_app = Convert.ToInt32(drs[0]["CASE_PER_DAY"]);
                    }
                    start   = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, 1,0, 0);
                    end     = new DateTime(dtEnd.DateTime.Year  , dtEnd.DateTime.Month  , dtEnd.DateTime.Day, 23,59,59);
                    process.RISSchedule.SCHEDULE_ID = 0;
                    process.RISSchedule.APPOINT_DT = start;
                    process.RISSchedule.END_DATETIME = end;
                    process.RISSchedule.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                    DataTable dtt = process.GetCheckMax();
                    if (dtt.Rows.Count > 0)
                    {
                        curr_app = Convert.ToInt32(dtt.Rows[0][0]);
                        curr_app++;
                    }
                }
                #endregion

                if (curr_app > max_app)
                {
                    string ms = msg.ShowAlert("UID1113", env.CurrentLanguageID);
                    if (ms == "1")
                        return false;
                }
            }
            return true;
        }
        private bool requireCheck() {
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
            if (txtClinicType.Text.Trim().Length == 0)
            {
                txtClinicType.Focus();
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
            if (txtOrderDept.Text.Trim().Length == 0)
            {
                if (chkBlock.Checked)
                {
                    txtOrderDept.Focus();
                    return true;
                }
                else
                {
                    txtOrderDept.Focus();
                    return false;
                }

            }
            if (txtOrderDoc.Text.Trim().Length == 0)
            {
                if (chkBlock.Checked)
                {
                    txtOrderDoc.Focus();
                    return true;
                }
                else
                {
                    txtOrderDoc.Focus();
                    return false;
                }

            }
            if (chkBlock.Checked == false)
            {
                if (txtExamUID.Text.Trim().Length == 0)
                {
                    msg.ShowAlert("UID0046", env.CurrentLanguageID);
                    btnExam.Focus();
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
            
            #endregion

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
                if (txtClinicType.Tag != null)
                {
                    if(!string.IsNullOrEmpty(txtClinicType.Tag.ToString()))
                    {
                        drs = dttSession.Select("SESSION_ID=" + txtClinicType.Tag.ToString());
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
                            process.RISClinicsession.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                            process.RISClinicsession.ORG_ID = env.OrgID;
                            process.RISClinicsession.WEEKDAYS = Convert.ToInt32(start.DayOfWeek);
                            process.Invoke();
                            DataTable dtmp = process.GetClinicSession();
                            drs = dtmp.Select("SESSION_ID=" + txtClinicType.Tag.ToString());
                            max_app = Convert.ToInt32(drs[0]["MAX_APP"].ToString());
                            DateTime dtStartApp = Convert.ToDateTime(drs[0]["START_TIME"].ToString());
                            DateTime dtEndApp = Convert.ToDateTime(drs[0]["END_TIME"].ToString());

                            DateTime dtSt = new DateTime(start.Year, start.Month, start.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                            DateTime dtEn = new DateTime(start.Year, start.Month, start.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);
                                                     
                            ProcessGetRISSchedule procSC = new ProcessGetRISSchedule();
                            procSC.RISSchedule.MODALITY_ID = process.RISClinicsession.MODALITY_ID;
                            procSC.RISSchedule.APPOINT_DT = dtSt;
                            procSC.RISSchedule.END_DATETIME = dtEn;
                            dtmp = new DataTable();
                            dtmp = procSC.GetSessionCount();
                            curr_app = 0;
                            if (dtmp != null)
                            {
                                if (dtmp.Rows.Count > 0)
                                    curr_app = Convert.ToInt32(dtmp.Rows[0]["AMT"].ToString());
                            }
                            if (curr_app > max_app) {
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
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(requireCheck())
                insertData();
           
        }
        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
                if (insertData())
                {
                    RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
                    print.ScheduleDirectPrint(patient.Reg_UID, dtStart.DateTime, Convert.ToInt32(apt.ResourceId.ToString()),schedule_id);
                }
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnScan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtHN.Text != "")
            {
                RIS.Operational.MainFrame frm = new MainFrame();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
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
                txtExamUID.BackColor = txtModality.BackColor;
                txtExamName.BackColor = txtModality.BackColor;
                txtExamUID.ReadOnly = true;
                txtExamName.ReadOnly = true;

                txtOrderDept.BackColor = txtModality.BackColor;
                txtOrderDoc.BackColor = txtModality.BackColor;
                txtOrderDept.ReadOnly = true;
                txtOrderDoc.ReadOnly = true;

                txtOrderDept.Text = string.Empty;
                txtOrderDoc.Text = string.Empty;

                txtExamUID.Text = string.Empty;
                txtExamName.Text = string.Empty;
                txtRate.Text = "0.00";

                txtHN.Text = "BLOCK";
                txtFName.Text = string.Empty;
                txtMName.Text = string.Empty;
                txtLName.Text = string.Empty;
                txtFName_Eng.Text = string.Empty;
                txtMName_Eng.Text = string.Empty;
                txtLName_Eng.Text = string.Empty;
                txtID.Text = string.Empty;
                dtDOB.Reset();
                cboGender.SelectedIndex = 0;
                txtPhone.Text = string.Empty;
                txtMobile.Text = string.Empty;
                grdData.DataSource = null;
                #endregion
            }
            else
            {
                fillDemographic();
               
            }
        }

        #region Lookup data.
        private void btnLookupHN_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(hnLookup_ValueUpdated);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("REG_ID", "Code", false, true);
            lv.AddColumn("FULLNAME", "NAME", true, true);
            lv.Text = "HN Search";

            lv.Data = lvS.ScheduleNotParameter("HN").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void hnLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string hn = retValue[0].ToString();
            patient = new RIS.BusinessLogic.Patient(hn, true);
            fillDemographic();
            SendKeys.Send("{Tab}");
        }

        private void btnOrderDept_Click(object sender, EventArgs e)
        {

            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(departmentLookup_ValueUpdated);
            lv.AddColumn("UNIT_UID", "Unit Code", true, true);
            lv.AddColumn("UNIT_ID", "ID", false, true);
            lv.AddColumn("UNIT_NAME", "Unit Name", true, true);
            lv.AddColumn("PHONE_NO", "Phone", true, true);
            lv.Text = "Department Search";

            lv.Data = lvS.ScheduleNotParameter("OrderDept").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void departmentLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string s = txtOrderDept.Tag == null ? string.Empty : txtOrderDept.Tag.ToString();
            if (retValue[1] != s)
            {

                txtOrderDept.Tag = retValue[1];
                txtOrderDept.Text = retValue[0]+":"+ retValue[2];
            }
        }

        private void btnOrderDoc_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(doctorLookup_ValueUpdated);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.AddColumn("EMP_UID", "CODE", true, true);
            lv.AddColumn("RadioName", "RadioName", true, true);
            lv.Text = "Doctor Search";

            lv.Data = lvS.ScheduleNotParameter("OrderDoc").Tables[0];//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();                                         
        }
        private void doctorLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            //doctor lookup
             string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtOrderDoc.Tag = retValue[0];
            txtOrderDoc.Text = retValue[1]+":"+ retValue[2];

        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            DataTable dtExam = order.Ris_Exam();
            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(examLookup_ValueUpdated);
            lv.AddColumn("EXAM_ID", "ID", false, true);
            lv.AddColumn("EXAM_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_NAME", "Exam Name", true, true);
            lv.AddColumn("RATE", "Rate", false, true);
            lv.Text = "Exam Search";

            lv.Data = lvS.ScheduleHaveParameter("Exam", Convert.ToInt32(apt.ResourceId)).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void examLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtExamUID.Tag = retValue[0];
            txtExamUID.Text = retValue[1];
            txtExamName.Text = retValue[2];
            txtRate.Tag = null;
            if (txtClinicType.Tag != null)
            {
                DataTable dtClinic = order.RIS_ClinicType();
                DataTable dtExam = order.Ris_Exam();
                DataRow[] rows = dttSession.Select("SESSION_ID=" + txtClinicType.Tag.ToString());
                if (rows.Length == 0) return;
                DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + rows[0]["CLINIC_TYPE_ID"].ToString());
                DataRow[] drExam = order.Ris_Exam().Select("EXAM_UID = '" + txtExamUID.Text + "'");
                switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                {
                    case "Special":
                        txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString();
                        break;
                    case "VIP":
                        txtRate.Text = drExam[0]["VIP_RATE"].ToString();
                        break;
                    default:
                        txtRate.Text = drExam[0]["RATE"].ToString();
                        break;
                }


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
                txtRate.Text = retValue[3];
            }
            
        }

        private void btnClinic_Click(object sender, EventArgs e)
        {
            #region OLD CODE.
            //LookUpSelect lvS = new LookUpSelect();
            //RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            //lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(clicnicLookup_ValueUpdated);
            //lv.AddColumn("CLINIC_TYPE_ID", "ID", false, true);
            //lv.AddColumn("CLINIC_TYPE_UID", "Code", false, true);
            //lv.AddColumn("CLINIC_TYPE_TEXT", "Clinic", true, true);
            //lv.Text = "Clinic Search";

            //lv.Data = lvS.ScheduleNotParameter("Clinic").Tables[0];
            //lv.Size = new Size(600, 400);
            //lv.ShowBox(); 
            #endregion

            LookUpSelect lvS = new LookUpSelect();
            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(clicnicLookup_ValueUpdated);
            lv.AddColumn("SESSION_ID", "SESSION_ID", false, true);
            lv.AddColumn("SESSION_UID", "Code", true, true);
            lv.AddColumn("SESSION_NAME", "Session Name", true, true);
            lv.AddColumn("CLINIC_TYPE_ID", "CLINIC_TYPE_ID", false, true);
            lv.Text = "Session Search";

            lv.Data = lvS.SelectSession().Tables[0].Copy();
            lv.Size = new Size(600, 400);
            lv.ShowBox();
            
        }
        private void clicnicLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtClinicType.Tag = retValue[0];
            txtClinicType.Text = retValue[2];
            clinictype = Convert.ToInt32(retValue[3]);

            object obj = txtClinicType.Tag;
            if (obj == null) return;
            obj = txtExamUID.Tag;
            if (obj == null) return;

            if (!string.IsNullOrEmpty(txtClinicType.Tag.ToString())) 
            {
                if (string.IsNullOrEmpty(txtExamUID.Tag.ToString())) return;
                DataRow[] drClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype);
                DataRow[] drExam = order.Ris_Exam().Select("EXAM_ID = " + txtExamUID.Tag);
                switch (drClinic[0]["CLINIC_TYPE_UID"].ToString()) {
                    case "Special":
                        txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString();
                        break;
                    case "VIP":
                        txtRate.Text = drExam[0]["VIP_RATE"].ToString();
                        break;
                    default:
                        txtRate.Text = drExam[0]["RATE"].ToString();
                        break;
                }
            }

            #region OLDCODE 11/06/2009
            //DataRow[] drClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + retValue[0]);
            //DataRow[] drExam = order.Ris_Exam().Select("EXAM_ID = " + txtExamUID.Tag);
            //switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
            //{
            //    case "Normal":
            //        txtRate.Text = drExam[0]["RATE"].ToString();
            //        break;
            //    case "Special":
            //        txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString() ;
            //        break;
            //    case "VIP":
            //        txtRate.Text = drExam[0]["VIP_RATE"].ToString() ;
            //        break;
            //    default:
            //        break;
            //} 
            #endregion


        } 
        
        private void btnProject_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(projectLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";

            lv.Data = lvS.ScheduleHaveParameter("General", env.CurrentLanguageID).Tables[0] ;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void projectLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e) {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtRate.Text = retValue[2];
            txtRate.Tag = retValue[0];
        }
        private void btnRadiologist_Click(object sender, EventArgs e)
        {
            DataTable dtRadio = order.Ris_Radiologist();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(RadiologistLookup_ValueUpdated);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.AddColumn("EMP_UID", "Code", true, true);
            lv.AddColumn("RadioName", "Radiologist Name", true, true);
            lv.AddColumn("AUTH_LEVEL_ID", "LEVEL", false, true);
            lv.Text = "Radiologist Detail List";

            lv.Data = dtRadio;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void RadiologistLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtRadiologist.Text = retValue[2];
            txtRadiologist.Tag = retValue[0];
        }
        private void btnAppoint_Click(object sender, EventArgs e)
        {
            HIS_Patient hisPat = new HIS_Patient();
            DataSet dttP = null;// hisPat.Get_appointment_detail(patient.Reg_UID);


            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnAppoint_Clicks);
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
        private void btnAppoint_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtOrderDept.Text = retValue[6];
            txtOrderDoc.Text = retValue[4];


            DataRow[] drDoc = order.His_Doctor().Select("EMP_UID='" + retValue[3].Trim() + "'");
            txtOrderDoc.Tag = drDoc[0]["EMP_ID"].ToString();
            DataRow[] drDept = order.His_Department().Select("UNIT_UID='" + retValue[5].Trim() + "'");
            txtOrderDept.Tag = drDept[0]["UNIT_ID"].ToString();
        }
        private void SetLookupAllGrid()
        {
            DataTable dtPat = order.RIS_PatStatus();
            grdLvPatStatus.Properties.DataSource = dtPat;
            grdLvPatStatus.Properties.DisplayMember = "STATUS_TEXT";
            grdLvPatStatus.Properties.ValueMember = "STATUS_ID";
            if (dtPat.Rows.Count>0)
            {
                grdLvPatStatus.EditValue = dtPat.Rows[0]["STATUS_ID"].ToString();
            }
            SetGridLookupPat();
        }
        private void SetGridLookupPat()
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

        #endregion

        #region KeyDown.
        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHN.Text.Trim().Length == 0)
                    return;
                if (txtHN.Properties.ReadOnly == true)
                    return;
                if (!RIS.Operational.Translator.ConvertHNtoKKU.IsUseHn(txtHN.Text))
                {
                    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                    clearContextControl();
                    enableDisableControl();
                    return;
                }
                patient = new RIS.BusinessLogic.Patient(txtHN.Text);
                if (patient.HasHN)
                {
                    fillDemographic();
                    //SendKeys.Send("{Tab}");
                    grdLvPatStatus.Focus();
                }
                else if(patient.LinkDown){
                    string s = msg.ShowAlert("UID1015", env.CurrentLanguageID);
                    if (s == "1") {
                        clearContextControl();
                        enableDisableControl();
                        return;
                    }
                    groupPatient.Enabled = true;
                    groupVisit.Enabled = true;
                    groupExam.Enabled = true;
                    groupTiming.Enabled = true;
                    txtFName.Properties.ReadOnly = false;
                    txtMName.Properties.ReadOnly = false;
                    txtLName.Properties.ReadOnly = false;
                    enableDisableGroupPatient(true);
                    txtHN.Properties.ReadOnly = true;
                    btnLookupHN.Enabled = false;
                    txtExamUID.Enabled = true;
                    txtExamName.Enabled = true;
                    txtExamUID.BackColor = Color.White;
                    txtExamName.BackColor = Color.White;
                    txtExamUID.ReadOnly = false;
                    txtExamName.ReadOnly = false;
                    txtOrderDept.Enabled = true;
                    txtOrderDoc.Enabled = true;
                    txtOrderDept.BackColor = Color.White;
                    txtOrderDoc.BackColor = Color.White;
                    txtOrderDept.ReadOnly = false;
                    txtOrderDoc.ReadOnly = false;

                    txtFName.Focus();
                }
                else {
                    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                    clearContextControl();
                    enableDisableControl();
                    return;
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

        private void txtExamUID_Validating(object sender, CancelEventArgs e)
        {
            if (txtExamUID.Text.Trim().Length == 0) {
                
                txtExamUID.Tag = null;
                txtExamName.Tag = null;

                txtExamUID.Text = string.Empty;
                txtExamName.Text = string.Empty;
                txtRate.Tag = null;
                txtRate.Text = "0.0";
                
                return;
            }
            DataRow[] dr = dttExamModality.Select("EXAM_UID='" + txtExamUID.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
                txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
                if (txtClinicType.Tag != null)
                {
                    DataTable dtClinic = order.RIS_ClinicType();
                    DataTable dtExam = order.Ris_Exam();
                    DataRow[] rows = dttSession.Select("SESSION_ID=" + txtClinicType.Tag.ToString());
                    if (rows.Length == 0) return;

                    DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + rows[0]["CLINIC_TYPE_ID"].ToString());
                    DataRow[] drExam = order.Ris_Exam().Select("EXAM_UID = '" + txtExamUID.Text + "'");
                    switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Special":
                            txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString();
                            break;
                        case "VIP":
                            txtRate.Text = drExam[0]["VIP_RATE"].ToString();
                            break;
                        default:
                            txtRate.Text = drExam[0]["RATE"].ToString();
                            break;
                    }
                }
            }
            else
            {
                txtExamUID.Tag = null;
                txtExamUID.SelectAll();
                txtExamName.Tag = null;
                txtExamName.Text = string.Empty;
                e.Cancel = true;
            } 
        }
        private void txtExamName_Validating(object sender, CancelEventArgs e)
        {
            if (txtExamName.Text.Trim().Length == 0)
            {

                txtExamUID.Tag = null;
                txtExamName.Tag = null;

                txtExamUID.Text = string.Empty;
                txtExamName.Text = string.Empty;
                txtRate.Tag = null;
                txtRate.Text = "0.0";
                return;
            }
            #region OLD.
            DataRow[] dr = dttExamModality.Select("EXAM_NAME='" + txtExamName.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
                txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
                if (txtClinicType.Tag != null)
                {
                    DataTable dtClinic = order.RIS_ClinicType();
                    DataTable dtExam = order.Ris_Exam();
                    DataRow[] rows = dttSession.Select("SESSION_ID=" + txtClinicType.Tag.ToString());
                    if (rows.Length == 0) return;

                    DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + rows[0]["CLINIC_TYPE_ID"].ToString());
                    DataRow[] drExam = order.Ris_Exam().Select("EXAM_UID = '" + txtExamUID.Text + "'");
                    switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Special":
                            txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString();
                            break;
                        case "VIP":
                            txtRate.Text = drExam[0]["VIP_RATE"].ToString();
                            break;
                        default:
                            txtRate.Text = drExam[0]["RATE"].ToString();
                            break;
                    }
                }
            }
            else
            {
                txtExamUID.Tag = null;
                txtExamUID.SelectAll();
                txtExamName.Tag = null;
                txtExamName.Text = string.Empty;
                e.Cancel = true;
            } 
            #endregion
        }
        private void txtFName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFName_Eng.Text.Trim().Length == 0 && txtFName.Text.Trim().Length > 0)
                txtFName_Eng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtFName.Text);
            if (txtFName.Text.Trim().Length == 0)
                txtFName_Eng.Text = string.Empty;

        }
        private void txtMName_Validating(object sender, CancelEventArgs e)
        {
            if (txtMName_Eng.Text.Trim().Length == 0 && txtMName.Text.Trim().Length > 0)
                txtMName_Eng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtMName.Text);
            if (txtMName.Text.Trim().Length == 0)
                txtMName_Eng.Text = string.Empty;
        }
        private void txtLName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLName_Eng.Text.Trim().Length == 0 && txtLName.Text.Trim().Length > 0)
                txtLName_Eng.Text = RIS.Operational.Translator.TransToEnglish.Trans(txtLName.Text);
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
                DataTable dtt = order.His_Department();// myOrder.HIS_Department();
                foreach (DataRow dr in dtt.Rows)//UNIT_NAME
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
                DataTable dtt = order.His_Doctor();// myOrder.HIS_Doctor();
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
                    txtOrderDoc.Text = string.Empty;
                    txtOrderDoc.Tag = null;
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
        private void txtRadiologist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        #endregion
        
        private void setAutoComplete() {
            txtExamName.AutoCompleteCustomSource.Clear();
            txtExamUID.AutoCompleteCustomSource.Clear();
            txtOrderDept.AutoCompleteCustomSource.Clear();
            txtOrderDoc.AutoCompleteCustomSource.Clear();

            int id = Convert.ToInt32(apt.ResourceId.ToString());
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(id);
            process.Invoke();
            dttExamModality = new DataTable();
            dttExamModality = process.Result.Tables[0].Copy();

            AutoCompleteStringCollection examCode = new AutoCompleteStringCollection();
            AutoCompleteStringCollection examName = new AutoCompleteStringCollection();
            AutoCompleteStringCollection Dep = new AutoCompleteStringCollection();
            AutoCompleteStringCollection Doc = new AutoCompleteStringCollection();

            for (int i = 0; i < dttExamModality.Rows.Count; i++)
            {
                examCode.Add(dttExamModality.Rows[i]["EXAM_UID"].ToString());
                examName.Add(dttExamModality.Rows[i]["EXAM_NAME"].ToString());
            }


            txtExamUID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtExamUID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtExamUID.AutoCompleteCustomSource = examCode;

            txtExamName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtExamName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtExamName.AutoCompleteCustomSource = examName;

         


            DataTable dtt = new DataTable();
            dtt = order.His_Department();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                Dep.Add(dtt.Rows[i]["UNIT_UID"].ToString() + ":" + dtt.Rows[i]["UNIT_NAME"].ToString());
            }
            dtt = new DataTable();
            dtt = order.His_Doctor();
            for (int i = 0; i < dtt.Rows.Count; i++)
                Doc.Add(dtt.Rows[i]["EMP_UID"].ToString() + ":" + dtt.Rows[i]["RadioName"].ToString());

            txtOrderDept.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtOrderDept.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrderDept.AutoCompleteCustomSource = Dep;

            txtOrderDoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtOrderDoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrderDoc.AutoCompleteCustomSource = Doc;
        }
        private void initGridAppointment() {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RISSchedule.HN = patient.Reg_UID;
            process.RISSchedule.APPOINT_DT = DateTime.Today;
            DataTable dtt = process.GetAppointment();
            grdData.DataSource = dtt;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            setColumnShow();
        }
        private void initGridAppointment(string HN)
        {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RISSchedule.HN = HN;
            process.RISSchedule.APPOINT_DT = DateTime.Today;
            DataTable dtt = process.GetAppointment();
            grdData.DataSource = dtt;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;
            setColumnShow();
            
        }
        private void initDefaultSession() {
            #region OLD_CODE.
            //ProcessGetRISClinictype process = new RIS.BusinessLogic.ProcessGetRISClinictype();
            //process.Invoke();
            //DataTable dtt = process.Result.Tables[0];
            //DataRow[] dr = dtt.Select("IS_DEFAULT='Y'");
            //if (dr.Length > 0)
            //{
            //    txtClinicType.Tag = dr[0]["CLINIC_TYPE_ID"].ToString();
            //    txtClinicType.Text = dr[0]["CLINIC_TYPE_TEXT"].ToString();
            //} 
            #endregion

            dttSession = new DataTable();
            ProcessGetRISClinicsession proc = new ProcessGetRISClinicsession();
            dttSession=proc.GetClinicSession().Copy();
            DateTime dtStart = apt.Start;
            foreach (DataRow dr in dttSession.Rows) {
                DateTime tmp = Convert.ToDateTime(dr["START_TIME"].ToString());
                DateTime sessionFrom = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, tmp.Hour, tmp.Minute, tmp.Second);
                tmp = Convert.ToDateTime(dr["END_TIME"].ToString());
                DateTime sessionTo = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, tmp.Hour, tmp.Minute, tmp.Second);
                if ((apt.Start >= sessionFrom) && (apt.Start <= sessionTo)) {
                    txtClinicType.Tag = dr["SESSION_ID"].ToString();
                    txtClinicType.Text = dr["SESSION_NAME"].ToString();
                    clinictype = Convert.ToInt32(dr["CLINIC_TYPE_ID"]);
                    break;
                }
            }
        }
        private void setColumnShow() { 
            view1.Columns["APPOINT_DT"].Visible = true;
            view1.Columns["APPOINT_DT"].Caption = "Appoint Date";
            view1.Columns["APPOINT_DT"].ColVIndex = 0;
            view1.Columns["APPOINT_DT"].Width = 100;

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

        private void setModalityClinicType() {
            ProcessGetRISModalityclinictype process = new ProcessGetRISModalityclinictype();
            process.Invoke();
            dttModalityClinic = process.Result.Tables[0].Copy();
        }

        private void grdLvPatStatus_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtG = (DataTable)grdLvPatStatus.Properties.DataSource;
            if (dtG.Rows.Count > 0)
            {
                    pat_id = Convert.ToInt32(dtG.Rows[viewPat.FocusedRowHandle]["STATUS_ID"]);
            }
        }

        private void speQTY_EditValueChanged(object sender, EventArgs e)
        {
            double SumRate = Convert.ToDouble(txtRate.Text) *Convert.ToDouble(speQTY.Value);
            txtTotal.Text = SumRate.ToString("#,##0.00");
        }

        private void txtRate_EditValueChanged(object sender, EventArgs e)
        {
            double SumRate = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(speQTY.Value);
            txtTotal.Text = SumRate.ToString("#,##0.00");
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

     
    }
}