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
using RIS.Operational;
namespace RIS.Forms.Schedule
{
    public partial class frmAppointmentEdit : Form
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
        private int pat_id,schedule_id,clinictype;

        public frmAppointmentEdit(SchedulerControl control, Appointment apt)
        {
            this.apt = apt;
            this.control = control;
            InitializeComponent();
            initControlFirst();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");

            
        }
        public frmAppointmentEdit(SchedulerControl control, Appointment apt,string mode)
        {
            if (mode == "Past")
            {

                this.apt = apt;
                this.control = control;
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
                txtExamUID.BackColor = txtModality.BackColor;
                txtExamName.BackColor = txtModality.BackColor;
                txtExamUID.ReadOnly = true;
                txtExamName.ReadOnly = true;
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue"); 
            }


        }
        
        private void initControlFirst()
        {
            try
            {
                initDefaultControlStart();
                txtModality.Text = ModalityName(apt.ResourceId.ToString());
                dtStart.DateTime = apt.Start;
                dtEnd.DateTime = apt.End;
                setAutoComplete();
                setModalityClinicType();
                dttSession = new DataTable();
                ProcessGetRISClinicsession prcCln = new ProcessGetRISClinicsession();
                dttSession = prcCln.GetClinicSession().Copy();

                ProcessGetRISClinictype process = new RIS.BusinessLogic.ProcessGetRISClinictype();
                process.Invoke();
                DataTable dtt = process.Result.Tables[0];
                DataRow[] dr = dtt.Select("IS_DEFAULT='Y'");
               
                RIS.BusinessLogic.ProcessGetRISSchedule proc;
                try
                {
                    proc = new RIS.BusinessLogic.ProcessGetRISSchedule();
                    DataTable dt = proc.GetScheduleData();
                    DataRow[] drSchedule = dt.Select("SCHEDULE_ID = " + apt.Location);
                    string hn = drSchedule[0]["HN"].ToString();
                    patient = new RIS.BusinessLogic.Patient(hn, true);
                    fillDataToCtrl(drSchedule[0]);
                    int session;
                    if (string.IsNullOrEmpty(drSchedule[0]["SESSION_ID"].ToString()))
                    {
                        initDefaultSession();
                    }
                    else
                    {
                        session = Convert.ToInt32(drSchedule[0]["SESSION_ID"]);
                        DataRow[] drr = dttSession.Select("SESSION_ID=" + session);
                        if (drr.Length > 0)
                        {
                            txtClinicType.Tag = drr[0]["SESSION_ID"].ToString();
                            txtClinicType.Text = drr[0]["SESSION_NAME"].ToString();
                            clinictype = Convert.ToInt32(drr[0]["CLINIC_TYPE_ID"]);
                        }
                    }
                    DataTable dttOrder = order.His_Doctor();
                    if (string.IsNullOrEmpty(drSchedule[0]["RAD_ID"].ToString()))
                    {
                        txtRadiologist.Text = "";
                    }
                    else if (drSchedule[0]["RAD_ID"].ToString() == "0")
                    {
                        txtRadiologist.Text = "";
                    }
                    else
                    {
                        DataRow[] drOrderSelect = dttOrder.Select("EMP_ID=" + drSchedule[0]["RAD_ID"].ToString());
                        txtRadiologist.Tag = drSchedule[0]["RAD_ID"].ToString();
                        txtRadiologist.Text = drOrderSelect[0]["RadioName"].ToString();
                    }
                    if (string.IsNullOrEmpty(drSchedule[0]["PAT_STATUS"].ToString()))
                    {
                        pat_id = 1;
                    }
                    else
                    {
                        pat_id = Convert.ToInt32(drSchedule[0]["PAT_STATUS"]);
                    }

                    if (string.IsNullOrEmpty(drSchedule[0]["RATE"].ToString()))
                    {
                        txtRate.Text = "0";
                    }
                    else
                    {
                        txtRate.Text = drSchedule[0]["RATE"].ToString();
                    }
                    if (string.IsNullOrEmpty(drSchedule[0]["QTY"].ToString()))
                    {
                        speQTY.Value = 1;
                    }
                    else
                    {
                        speQTY.Value = Convert.ToInt32(drSchedule[0]["QTY"]);
                    }
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
                        if (string.IsNullOrEmpty(drSchedule[0]["LMP_DT"].ToString()))
                        {
                            deLMP.DateTime = DateTime.Now;
                        }
                        else if (Convert.ToDateTime(drSchedule[0]["LMP_DT"]) == DateTime.MinValue)
                        {
                            deLMP.DateTime = DateTime.Now;
                        }
                        else
                        {
                            deLMP.DateTime = Convert.ToDateTime(drSchedule[0]["LMP_DT"]);
                        }

                    }

                    SetLookupAllGrid();
                    SetGridLookupPat();
                    grdLvPatStatus.EditValue = drSchedule[0]["PAT_STATUS"];

                    initGridHistory();
                    txtUserName.Text = env.FirstName + " " + env.LastName;
                }
                catch (Exception ex)
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    groupPatient.Enabled = false;
                    groupVisit.Enabled = false;
                    groupExam.Enabled = false;
                    groupTiming.Enabled = false;
                    txtExamUID.BackColor = txtModality.BackColor;
                    txtExamName.BackColor = txtModality.BackColor;
                    txtExamUID.ReadOnly = true;
                    txtExamName.ReadOnly = true;
                }
            }
            catch (Exception ecp) { }
        }
        private void initDefaultSession()
        {
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
                    txtClinicType.Tag = dr["SESSION_ID"].ToString();
                    txtClinicType.Text = dr["SESSION_NAME"].ToString();
                    clinictype = Convert.ToInt32(dr["CLINIC_TYPE_ID"]);
                    break;
                }
            }
        }

        private string ModalityName(string ID)
        {
            string name = string.Empty;
            RIS.BusinessLogic.ProcessGetRISModality process = new RIS.BusinessLogic.ProcessGetRISModality(true);
            process.Invoke();
            DataTable dttModaltiy = new DataTable();
            dttModaltiy = process.Result.Tables[0].Copy();
            DataRow[] dr = dttModaltiy.Select("MODALITY_ID =" + ID);
            if (dr.Length > 0)
                name = dr[0]["MODALITY_NAME"].ToString();
            return name;
        }
        private void initDefaultControlStart()
        {

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
        private void setAutoComplete()
        {
            int id = Convert.ToInt32(apt.ResourceId.ToString());
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(id);
            process.Invoke();
            dttExamModality = new DataTable();
            dttExamModality = process.Result.Tables[0].Copy();

            AutoCompleteStringCollection examCode = new AutoCompleteStringCollection();
            AutoCompleteStringCollection examName = new AutoCompleteStringCollection();

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
        }

        private void fillDemographic()
        {
            if (patient != null)
            {
                //ProcessGetRISSchedule geSc = new ProcessGetRISSchedule(apt.Location);
                //geSc.Invoke();
                //DataTable dtSc = geSc.Result.Tables[0];
                txtHN.Text = patient.Reg_UID;
                //txtFName.Text = dtSc.Rows[0]["FNAME"].ToString();

                txtFName.Text = patient.FirstName;
                txtMName.Text = patient.MiddleName;
                txtLName.Text = patient.LastName;
                txtFName_Eng.Text = patient.FirstName_ENG;
                txtMName_Eng.Text = patient.MiddleName_ENG;
                txtLName_Eng.Text = patient.LastName_ENG;
                txtID.Text = patient.SocialNumber;
                dtDOB.DateTime = string.IsNullOrEmpty(patient.DateOfBirth.ToString()) ? DateTime.Now : patient.DateOfBirth;
                LookUpSelect lu = new LookUpSelect();
                if (patient.DateOfBirth == DateTime.MinValue)
                {
                    dtDOB.DateTime = DateTime.Now;
                }
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

                txtRadiologist.Text = patient.Doctor_Name;

                groupVisit.Enabled = true;
                groupExam.Enabled = true;
                groupTiming.Enabled = true;
                grdLvPatStatus.Enabled = true;

                txtExamUID.BackColor = Color.White;
                txtExamName.BackColor = Color.White;
                txtExamUID.ReadOnly = false;
                txtExamName.ReadOnly = false;


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

                if (txtRate.Tag != null)
                    if (txtRate.Tag.ToString().Trim().Length > 0)
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
                            txtOrderDept.Text = drExam[0]["UNIT_UID"].ToString()+":"+ drExam[0]["UNIT_NAME"].ToString();
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
                            txtOrderDoc.Text = drExam[0]["EMP_UID"].ToString()+":"+ drExam[0]["RadioName"].ToString();
                        }
                    }
                }
                #endregion

                groupPatient.Enabled = true;
                groupVisit.Enabled = true;
                groupExam.Enabled = true;
                grdLvPatStatus.Enabled = true;

                txtExamUID.BackColor = Color.White;
                txtExamName.BackColor = Color.White;
                txtExamUID.ReadOnly = false;
                txtExamName.ReadOnly = false;

                initGridAppointment(txtHN.Text);
                
            }
            else
            {
                txtHN.Text = string.Empty;
                initGridAppointment("00");
            }
        }
        private void fillDataToCtrl(DataRow dr)
        {
            fillDemographic();

            #region Group Exam.
            DataRow[] drExam;
            if (!string.IsNullOrEmpty(dr["EXAM_ID"].ToString()))
            {
                int exam_id = Convert.ToInt32(dr["EXAM_ID"].ToString());
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

            if (!string.IsNullOrEmpty(dr["GEN_DTL_ID"].ToString()))
            {
                txtRate.Tag = dr["GEN_DTL_ID"].ToString();
                txtRate.Text = "0.00";
            }

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
                    RIS.BusinessLogic.ProcessGetHRUnit unit = new RIS.BusinessLogic.ProcessGetHRUnit();
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
            id = 0;
            if (!string.IsNullOrEmpty(dr["REF_DOC"].ToString()))
            {
                if (int.TryParse(dr["REF_DOC"].ToString(), out id))
                {
                    RIS.BusinessLogic.ProcessGetHISDoctor doc = new RIS.BusinessLogic.ProcessGetHISDoctor();
                    doc.Invoke();
                    dtt = doc.Result.Tables[0].Copy();
                    drExam = dtt.Select("EMP_ID=" + id.ToString());
                    if (drExam.Length > 0)
                    {
                        txtOrderDoc.Tag = drExam[0]["EMP_ID"].ToString();
                        txtOrderDoc.Text = drExam[0]["EMP_UID"].ToString()+":"+ drExam[0]["RadioName"].ToString();
                    }
                }
            }
            #endregion

            if ((dr["SCHEDULE_STATUS"].ToString().ToUpper() == "O") || (dr["IS_BLOCK"].ToString() == "Y"))
            {
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                txtExamUID.BackColor = txtModality.BackColor;
                txtExamName.BackColor = txtModality.BackColor;
                txtExamUID.ReadOnly = true;
                txtExamName.ReadOnly = true;
                groupTiming.Enabled = false;

                chkBlock.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnScan.Enabled = false;
                btnSavePrint.Enabled = false;

                
                if (dr["IS_BLOCK"].ToString() == "Y")
                {
                    btnSave.Enabled = true;
                    btnSavePrint.Enabled = true;
                    btnDelete.Enabled = true;

                    #region Clear Context.
                        groupPatient.Enabled = false;
                        groupVisit.Enabled = false;
                        groupExam.Enabled = false;
                        txtExamUID.BackColor = txtModality.BackColor;
                        txtExamName.BackColor = txtModality.BackColor;
                        txtExamUID.ReadOnly = true;
                        txtExamName.ReadOnly = true;

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
                    #endregion

                }
            }

            DataTable data = order.His_Department();
            DataRow[] drs;
            try
            {
                drs = data.Select("UNIT_ID=" + dr["REF_UNIT"].ToString());
                if (drs.Length > 0)
                {
                    txtOrderDept.Tag = drs[0]["UNIT_ID"].ToString();
                    txtOrderDept.Text = drs[0]["UNIT_UID"].ToString() + ":" + drs[0]["UNIT_NAME"].ToString();
                }
            }
            catch { txtOrderDept.Text = ""; }
            data = order.Ris_Radiologist();
            try
            {
                drs = data.Select("EMP_ID=" + dr["REF_DOC"].ToString());

                if (drs.Length > 0)
                {
                    txtOrderDoc.Tag = patient.REF_DOC;
                    txtOrderDoc.Text = drs[0]["EMP_UID"].ToString()+":"+ drs[0]["RadioName"].ToString();
                }
            }
            catch { txtOrderDoc.Text = ""; }
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
              
                #endregion
            }
            else
            {
                fillDemographic();

               

            }
        }

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
            view1.Columns["REASON"].Width = 280;

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
            lv.AddColumn("EMP_UID","CODE",true,true);
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
            txtOrderDoc.Text = retValue[2];

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
            txtRate.Text = retValue[3];
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
            #region Old
            //string[] retValue = e.NewValue.Split(new Char[] { '^' });
            //txtClinicType.Tag = retValue[0];
            //txtClinicType.Text = retValue[2];

            //DataRow[] drClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + retValue[0]);
            //DataRow[] drExam = order.Ris_Exam().Select("EXAM_ID = " + txtExamUID.Tag);
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

        private void btnProject_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(projectLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";

            lv.Data = lvS.ScheduleHaveParameter("General", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void projectLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
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

                
            DataRow[] drDoc = order.His_Doctor().Select("EMP_UID='" + retValue[3].Trim()+"'");
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
            if (dtPat.Rows.Count > 0)
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
                {
                  txtHN.Text = apt.Subject;
                        return;
                }
                Patient  p = new Patient(txtHN.Text);
                if (p.HasHN)
                {
                    patient = new Patient(txtHN.Text);
                    fillDemographic();
                    SendKeys.Send("{Tab}");
                }
                else
                {
                    msg.ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                    fillDemographic();
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

                if (txtClinicType.Tag != null)
                {
                    DataTable dtClinic = order.RIS_ClinicType();

                    DataRow[] drClinic = dtClinic.Select("CLINIC_TYPE_ID = " + txtClinicType.Tag);//order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + retValue[0]);
                    DataRow[] drExam = order.Ris_Exam().Select("EXAM_UID = '" + txtExamUID.Text +"'");
                    switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Normal":
                            txtRate.Text = drExam[0]["RATE"].ToString();
                            break;
                        case "Special":
                            txtRate.Text = drExam[0]["SPECIAL_RATE"].ToString();
                            break;
                        case "VIP":
                            txtRate.Text = drExam[0]["VIP_RATE"].ToString();
                            break;
                        default:
                            break;
                    }
                }
                //else
                //{
                //    txtRate.Text = retValue[3];
                //}
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


        private void txtExamUID_Validating(object sender, CancelEventArgs e)
        {
            if (txtExamUID.Text.Trim().Length == 0)
            {

                txtExamUID.Tag = null;
                txtExamName.Tag = null;

                txtExamUID.Text = string.Empty;
                txtExamName.Text = string.Empty;

                return;
            }
            DataRow[] dr = dttExamModality.Select("EXAM_UID='" + txtExamUID.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
                txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
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

                return;
            }
            DataRow[] dr = dttExamModality.Select("EXAM_NAME='" + txtExamName.Text.Trim() + "'");
            if (dr.Length > 0)
            {
                txtExamUID.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamUID.Text = dr[0]["EXAM_UID"].ToString();
                txtExamName.Tag = dr[0]["EXAM_ID"].ToString();
                txtExamName.Text = dr[0]["EXAM_NAME"].ToString();
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
        #endregion

        private bool updateData()
        {
            BusinessLogic.ProcessUpdateRISSchedule process = new RIS.BusinessLogic.ProcessUpdateRISSchedule();
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            if (chkBlock.Checked)
            {
                #region update block.
                process.RISSchedule.APPOINT_DT = start;
                process.RISSchedule.LAST_MODIFIED_BY = env.UserID;
                process.RISSchedule.END_DATETIME = end;
                process.RISSchedule.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                process.RISSchedule.ORG_ID = env.OrgID;
                process.RISSchedule.REASON = txtReason.Text;
                process.RISSchedule.SCHEDULE_DATA = "BLOCK - " + txtReason.Text;
                process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                process.UpdateBlock();
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
                pAddHIS.HISRegistration.FNAME_ENG = txtFName_Eng.Text; //patient.FirstName_ENG;
                pAddHIS.HISRegistration.MNAME_ENG = txtMName_Eng.Text;//patient.MiddleName_ENG;
                pAddHIS.HISRegistration.GENDER = patient.Gender;
                pAddHIS.HISRegistration.HN = patient.Reg_UID;
                pAddHIS.HISRegistration.LNAME = patient.LastName;
                pAddHIS.HISRegistration.LNAME_ENG = txtLName_Eng.Text;//patient.LastName_ENG;
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
                #endregion

                #region update normal.
                process.RISSchedule.APPOINT_DT = start;
                process.RISSchedule.BLOCK_REASON = null;
                process.RISSchedule.CLINIC_TYPE = clinictype;//Convert.ToInt32(txtClinicType.Tag.ToString());
                process.RISSchedule.LAST_MODIFIED_BY = env.UserID;
                process.RISSchedule.END_DATETIME = end;
                process.RISSchedule.EXAM_ID = Convert.ToInt32(txtExamUID.Tag.ToString());
                process.RISSchedule.HN = patient.Reg_UID;
                process.RISSchedule.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                process.RISSchedule.ORG_ID = env.OrgID;
                process.RISSchedule.REASON_CHANGE = txtInputReason.Text.Trim();
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
                process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(apt.Location);
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

                process.Update();
                if (process.RISSchedule.SCHEDULE_ID > 0)
                {
                    schedule_id = process.RISSchedule.SCHEDULE_ID;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (process.RISSchedule.SCHEDULE_ID == -2)
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
                #endregion

                #region Scan Image
                RIS.Operational.Scanner.SaveScannedImage save = null;
                if (dtImageScan == null)
                {
                    save = new RIS.Operational.Scanner.SaveScannedImage(patient.Reg_UID, process.RISSchedule.SCHEDULE_ID, "Schedule");
                }
                else
                {
                    save = new RIS.Operational.Scanner.SaveScannedImage(patient.Reg_UID, process.RISSchedule.SCHEDULE_ID, dtImageScan, "Schedule");
                }
                            #endregion
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
                RIS.BusinessLogic.ProcessDeleteRISSchedule process = new RIS.BusinessLogic.ProcessDeleteRISSchedule();
                process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                process.RISSchedule.REASON_CHANGE = txtInputReason.Text.Trim();
                process.RISSchedule.LAST_MODIFIED_BY = env.UserID;
                process.Invoke();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private bool requireCheck() { 
            xtraTabControl1.SelectedTabPageIndex = 0;
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
                txtOrderDept.Focus();
                return false;
            }
            if (txtOrderDoc.Text.Trim().Length == 0)
            {
                txtOrderDoc.Focus();
                return false;
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
                    if (!string.IsNullOrEmpty(txtClinicType.Tag.ToString()))
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

                #region เช็คเวลานัดว่า เกินเวลาปัจจุบัน
                if (end<start)//dtEnd.DateTime < dtStart.DateTime)
                {
                    msg.ShowAlert("UID4012", new GBLEnvVariable().CurrentLanguageID);
                    return false;
                }
                if (dtStart.DateTime < DateTime.Now || dtEnd.DateTime < DateTime.Now)
                {
                    msg.ShowAlert("UID4011", new GBLEnvVariable().CurrentLanguageID);
                    return false ;
                }

                #endregion
            }
            return true;
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if(requireCheck())
                updateData();
        }
        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (requireCheck())
            {
                if (updateData())
                {
                    RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
                    print.ScheduleDirectPrint(patient.Reg_UID, dtStart.DateTime, Convert.ToInt32(apt.ResourceId.ToString()),schedule_id);
                }
            }
        }
        private void btnScan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtHN.Text != "")
            {

                order thisOrder = new order();
                ProcessGetRISOrderimages geImage = new ProcessGetRISOrderimages();
                geImage.RISOrderimages.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                geImage.Invoke();
                DataTable dttIm = geImage.Result.Tables[0];
                DataView dvv = new DataView(dttIm.Copy());

                if (dttIm.Rows.Count > 0)
                {
                    string a = "C";

                    RIS.Operational.Scanner.EditImageOrder editFrm = new RIS.Operational.Scanner.EditImageOrder(dvv);
                    editFrm.StartPosition = FormStartPosition.CenterParent;
                    editFrm.ShowDialog();
                    if (editFrm.DialogResult == DialogResult.Yes)
                    {
                        dvv = editFrm.Data;
                        dtImageScan = dvv.Table.Copy();
                    }
                }
                else
                {
                    RIS.Operational.MainFrame frm = new MainFrame();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
        }
        private void initGridAppointment(string HN)
        {

            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RISSchedule.HN = HN;
            process.RISSchedule.APPOINT_DT = DateTime.Today;
            viewApp.Columns.Clear();
            
            DataTable dtt = process.GetAppointment();
            grdApp.DataSource = dtt;
            for (int i = 0; i < dtt.Columns.Count; i++)
                viewApp.Columns[i].Visible = false;
            setColumnShow();

        }
        private void setColumnShow()
        {
            viewApp.Columns["APPOINT_DT"].Visible = true;
            viewApp.Columns["APPOINT_DT"].Caption = "Appoint Date";
            viewApp.Columns["APPOINT_DT"].ColVIndex = 0;
            viewApp.Columns["APPOINT_DT"].Width = 100;

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

        private void btnReason_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(reasonLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";

            lv.Data = lvS.ScheduleHaveParameter("General2", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void reasonLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInputReason.Tag = retValue[0];
            txtInputReason.Text = retValue[2];
        }

        private void setModalityClinicType()
        {
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
            double SumRate = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(speQTY.Value);
            txtTotal.Text = SumRate.ToString("#,##0.00");
        }

        private void txtRate_EditValueChanged(object sender, EventArgs e)
        {
            double SumRate = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(speQTY.Value);
            txtTotal.Text = SumRate.ToString("#,##0.00");
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
    }
}   