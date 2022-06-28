using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Threading;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessUpdate;
using System.Data.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic;
using Envision.Operational.PACS;

namespace Envision.NET.Forms.Orders
{
    public partial class frmConfirmArrivalWorkList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int _selectedOrderId = 0;
        private int _selectedScheduleId = 0;
        private int _selectedOrgId = 1;
        private int _insuranceId = 0;
        private string _admissionNo = string.Empty;
        private ProcessGetXrayOrderInfo _processGetXrayOrderInfo;
        private ProcessGetRISScheduleInfo _processGetRISScheduleInfo;
        // static dataset (dataTable)
        private DataTable dtPatientDemographic;
        private DataTable dtCasesInfo;
        private SendToPacs sendToPacs;
        private Thread thread1;
        private Thread thread2;

        //colr backup
        private Color bkBackColor = Color.Empty;

        private MyMessageBox messageBox;
        private Envision.Common.GBLEnvVariable gblenv;

        #region Title Name DataSource
        // Thai Title name
        public string[] TitleThaiName = new string[]
        { 
            "นาย",
            "นางสาว",
            "นาง",
            "ด.ช.",
            "ด.ญ.",
            "บาทหลวง",
            "แม่ชี",
            "พระ",
            "หม่อมราชวงศ์",
            "หม่อมหลวง",
            "รองศาสตราจารย์",
            "ผู้ช่วยศาสตราจารย์",
            "พล.อ.อ.",
            "พล.อ.ท.",
            "พล.อ.ต.",
            "น.อ.",
            "น.ท.",
            "น.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "พ.อ.อ.",
            "พ.จ.ท.",
            "พ.อ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",
            "พล.อ.",
            "พล.ท.",
            "พล.ต.",
            "พ.อ.",
            "พ.ท.",
            "พ.ต.",
            "ร.อ.",
            "ร.ท.",
            "ร.ต.",
            "จ.ส.อ.",
            "จ.ส.ท.",
            "จ.ส.ต.",
            "ส.อ.",
            "ส.ท.",
            "ส.ต.",
            "พลฯ",
            "พล.ร.อ.",
            "พล.ร.ท.",
            "พล.ร.ต.",
            "น.อ...ร.น.",
            "น.ท...ร.น.",
            "น.ต...ร.น.",
            "ร.อ...ร.น.",
            "ร.ท...ร.น.",
            "ร.ต...ร.น.",
            "พ.จ.อ.",
            "พ.จ.ท.",
            "พ.จ.ต.",
            "จ.อ.",
            "จ.ท.",
            "จ.ต.",
            "พลฯ",
            "พล.ต.อ.",
            "พล.ต.ท.",
            "พล.ต.ต.",
            "พ.ต.อ.",
            "พ.ต.ท.",
            "พ.ต.ต.",
            "ร.ต.อ",
            "ร.ต.ท",
            "ร.ต.ต",
            "ด.ต.",
            "จ.ส.อ.",
            "ส.ต.อ.",
            "ส.ต.ท.",
            "ส.ต.ต.",
            "พลตำรวจ",
        };
        // Eng Title name
        public string[] TitleEngName = new string[]
        { 
            "Mr.",
            "Ms.",
            "Mrs.",
            "Boy",
            "Girl",
            "Fr.",
            "Sis.",
            "Monk",
            "M R",
            "M L", 
            "Assoc P.",
            "Assist Pro.",
            "ACM",
            "AM", 
            "AVM", 
            "GP CAPT",
            "WG CDR",
            "SON LDR",
            "FLT LT",
            "FLG OFF",
            "PLT OFF",
            "FS 1",
            "FS 2",
            "FS 3",
            "SGT",
            "CPL", 
            "LAC",
            "AMN",
            "GEN", 
            "LT GEN", 
            "MAJ GEN",
            "COL", 
            "LT COL", 
            "MAJ",
            "CAPT",
            "LT",
            "SUB KT",
            "SM 1",
            "SM 2",
            "SM 3",
            "PFC",
            "CPL",
            "PFC",
            "PVT",
            "ADM", 
            "V ADM",
            "R AVM",
            "CAPT",
            "CDR",
            "L CDR",
            "LT",
            "LT JG", 
            "SUB LT",
            "CPO 1",
            "CPO 2",
            "CPO 3",
            "PO 1",
            "PO 2",
            "PO 3",
            "SEA-MAN",
            "POL GEN",
            "POL LT GEN", 
            "POL MAL GEN",
            "POL COL",
            "POL LT COL", 
            "POL MAL",
            "POL CAPT",
            "POL LT",
            "POL SUB LT",
            "POL SEN SGT MAJ", 
            "POL SM",
            "POL SGT",
            "POL CPL",
            "POL PFC",
            "POL PVT",         
        };
        #endregion
        /// <summary>
        /// Default costructor
        /// </summary>
        public frmConfirmArrivalWorkList()
        {
            InitializeComponent();
            this._processGetXrayOrderInfo = new ProcessGetXrayOrderInfo();
            this._processGetRISScheduleInfo = new ProcessGetRISScheduleInfo();
            this.messageBox = new MyMessageBox();
            this.gblenv = new Envision.Common.GBLEnvVariable();
            this.sendToPacs = new SendToPacs();
            this.SetupEditor();
        }
        /// <summary>
        /// This method use to set up editor
        /// </summary>
        private void SetupEditor()
        {
            //Title name 
            for (int i = 0; i < this.TitleThaiName.Length; i++)
            {
                this.cbThaiTitleName.Properties.Items.Add(this.TitleThaiName[i]);
                this.cbEngTitleName.Properties.Items.Add(this.TitleEngName[i]);
            }

            //Patient Status
            DataTable dtPatientStatus = Envision.BusinessLogic.RISBaseData.RIS_PatStatus();
            btePatientStatus.Properties.DataSource = dtPatientStatus;
            btePatientStatus.Properties.DisplayMember = "STATUS_TEXT";
            btePatientStatus.Properties.ValueMember = "STATUS_ID";
            btePatientStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS_TEXT", "Status"));

            //Preparation Data
            ProcessGetRISPatientPreparation _processGetRISPatientPreparation = new ProcessGetRISPatientPreparation();
            _processGetRISPatientPreparation.Invoke();
            if (_processGetRISPatientPreparation.Result != null)
            {
                DataTable dtPreparation = _processGetRISPatientPreparation.Result.Tables[0];
                btePreparation.Properties.DataSource = dtPreparation;
                btePreparation.Properties.DisplayMember = "PREPARATION_DESC";
                btePreparation.Properties.ValueMember = "PREPARATION_ID";
                btePreparation.Properties.NullText = "";
                btePreparation.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PREPARATION_DESC", "Preparation"));
            }

            //Exam DataGrid
            // priority
            GridColumn gc_priority = new GridColumn();
            gc_priority.Caption = "Priority";
            gc_priority.FieldName = "PRIORITY";
            gc_priority.VisibleIndex = 1;
            gc_priority.Width = 60;
            DataTable dtPriority = Envision.BusinessLogic.RISBaseData.Ris_Priority();
            RepositoryItemLookUpEdit _repPriority = new RepositoryItemLookUpEdit();
            _repPriority.Buttons.Clear();
            _repPriority.DataSource = dtPriority;
            _repPriority.DisplayMember = "PRIORITY";
            _repPriority.ValueMember = "PRI_ID";
            _repPriority.ReadOnly = true;
            _repPriority.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRIORITY", "Priority"));
            gc_priority.ColumnEdit = _repPriority;
            this.gridView1.Columns.Add(gc_priority);
            // exam code
            GridColumn gc_examCode = new GridColumn();
            gc_examCode.Caption = "Exam Code";
            gc_examCode.FieldName = "EXAM_UID";
            gc_examCode.VisibleIndex = 2;
            gc_examCode.Width = 75;
            gc_examCode.OptionsColumn.AllowEdit = false;
            this.gridView1.Columns.Add(gc_examCode);

            //exam name
            GridColumn gc_examName = new GridColumn();
            gc_examName.Caption = "Exam Name";
            gc_examName.FieldName = "EXAM_NAME";
            gc_examName.VisibleIndex = 3;
            gc_examName.Width = 125;
            gc_examName.OptionsColumn.AllowEdit = false;
            this.gridView1.Columns.Add(gc_examName);

            // modality
            GridColumn gc_modality = new GridColumn();
            gc_modality.Caption = "Modality";
            gc_modality.FieldName = "MODALITY_ID";
            gc_modality.VisibleIndex = 4;
            gc_modality.Width = 95;
            DataTable dtModality = Envision.BusinessLogic.RISBaseData.Ris_Modality();
            RepositoryItemLookUpEdit _repModality = new RepositoryItemLookUpEdit();
            _repModality.DataSource = dtModality;
            _repModality.DisplayMember = "MODALITY_NAME";
            _repModality.ValueMember = "MODALITY_ID";
            _repModality.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(_repModality_CloseUp);
            _repModality.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODALITY_NAME", "Modality"));
            gc_modality.ColumnEdit = _repModality;
            this.gridView1.Columns.Add(gc_modality);

            // Bp view
            GridColumn gc_bpView = new GridColumn();
            gc_bpView.Caption = "Side View";
            gc_bpView.FieldName = "BP_VIEW";
            gc_bpView.VisibleIndex = 5;
            gc_bpView.Width = 65;
            gc_bpView.OptionsColumn.AllowEdit = false;
            this.gridView1.Columns.Add(gc_bpView);

            //Rate
            GridColumn gc_rate = new GridColumn();
            gc_rate.Caption = "Rate";
            gc_rate.FieldName = "EXAM_RATE";
            gc_rate.VisibleIndex = 6;
            gc_rate.Width = 70;
            gc_rate.OptionsColumn.AllowEdit = false;
            this.gridView1.Columns.Add(gc_rate);

            // exam datetime
            GridColumn gc_ExamDateTime = new GridColumn();
            gc_ExamDateTime.Caption = "Exam DateTime";
            gc_ExamDateTime.FieldName = "EXAM_DT";
            gc_ExamDateTime.VisibleIndex = 7;
            gc_ExamDateTime.Width = 110;
            gc_ExamDateTime.OptionsColumn.AllowEdit = true;
            gc_ExamDateTime.DisplayFormat.FormatString = "d";
            RepositoryItemDateEdit _repDateEdit = new RepositoryItemDateEdit();
            _repDateEdit.MinValue = DateTime.Today;
            _repDateEdit.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(_repDateEdit_CloseUp);
            gc_ExamDateTime.ColumnEdit = _repDateEdit;
            this.gridView1.Columns.Add(gc_ExamDateTime);

            // clinic
            GridColumn gc_clinic = new GridColumn();
            gc_clinic.Caption = "Clinic";
            gc_clinic.FieldName = "CLINIC_TYPE_ID";
            gc_clinic.VisibleIndex = 8;
            gc_clinic.Width = 70;
            RepositoryItemLookUpEdit _repClinic = new RepositoryItemLookUpEdit();
            _repClinic.DataSource = Envision.BusinessLogic.RISBaseData.RIS_ClinicType();
            _repClinic.DisplayMember = "CLINIC_TYPE_TEXT";
            _repClinic.ValueMember = "CLINIC_TYPE_ID";
            _repClinic.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLINIC_TYPE_TEXT", "Clinic Type"));
            _repClinic.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(_repClinic_EditValueChanging);
            gc_clinic.ColumnEdit = _repClinic;
            this.gridView1.Columns.Add(gc_clinic);

            // assign to
            GridColumn gc_radiologist = new GridColumn();
            gc_radiologist.Caption = "Radiologist";
            gc_radiologist.FieldName = "ASSIGN_TO";
            gc_radiologist.VisibleIndex = 9;
            gc_radiologist.Width = 100;
            RepositoryItemGridLookUpEdit cmbGRa = new RepositoryItemGridLookUpEdit();
            cmbGRa.DataSource = Envision.BusinessLogic.RISBaseData.Ris_Radiologist();
            cmbGRa.DisplayMember = "UIDAndRadioName";
            cmbGRa.ValueMember = "EMP_ID";
            cmbGRa.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(cmbGRa_CloseUp);
            cmbGRa.NullText = "";
            cmbGRa.View.Columns["EMP_ID"].Visible = false;
            cmbGRa.View.Columns["EMP_UID"].Visible = false;
            cmbGRa.View.Columns["RadioName"].Visible = false;
            cmbGRa.View.Columns["AUTH_LEVEL_ID"].Visible = false;
            cmbGRa.View.Columns["ALLOW_OTHERS_TO_FINALIZE"].Visible = false;
            cmbGRa.View.Columns["RadioNameEng"].Visible = false;
            cmbGRa.View.Columns["UIDAndRadioName"].Visible = true;
            cmbGRa.View.Columns["UIDAndRadioName"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cmbGRa.View.Columns["UIDAndRadioName"].Caption = "Radiologist";
            gc_radiologist.ColumnEdit = cmbGRa;
            this.gridView1.Columns.Add(gc_radiologist);
            // Ref Dept data
            DataTable dttRefDept = Envision.BusinessLogic.RISBaseData.His_Department();
            this.glkOrderingDept.Properties.DisplayMember = "UNIT_NAME";
            this.glkOrderingDept.Properties.ValueMember = "UNIT_ID";
            this.glkOrderingDept.Properties.AutoComplete = true;
            this.glkOrderingDept.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.glkOrderingDept.Properties.View.Columns.Clear();
            this.glkOrderingDept.Properties.View.Columns.Add(new GridColumn() { Caption = "Code", FieldName = "UNIT_UID", Width = 80, VisibleIndex = 0 });
            this.glkOrderingDept.Properties.View.Columns.Add(new GridColumn() { Caption = "Name", FieldName = "UNIT_NAME", Width = 300, VisibleIndex = 1 });
            this.glkOrderingDept.Properties.DataSource = dttRefDept;
            // Ref Doctor data
            DataTable dttRefDoc = Envision.BusinessLogic.RISBaseData.His_Doctor();
            this.glkOrderingDoc.Properties.DisplayMember = "RadioName";
            this.glkOrderingDoc.Properties.ValueMember = "EMP_ID";
            this.glkOrderingDoc.Properties.AutoComplete = true;
            this.glkOrderingDoc.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.glkOrderingDoc.Properties.View.Columns.Clear();
            this.glkOrderingDoc.Properties.View.Columns.Add(new GridColumn() { Caption = "Code", FieldName = "EMP_UID", Width = 80, VisibleIndex = 0 });
            this.glkOrderingDoc.Properties.View.Columns.Add(new GridColumn() { Caption = "Name", FieldName = "RadioName", Width = 300, VisibleIndex = 1 });
            this.glkOrderingDoc.Properties.DataSource = dttRefDoc;
        }
        /// <summary>
        /// This method use to binding all data
        /// </summary>
        private void BindingData(DataTable dtDemographic, DataTable dtOrderInfo)
        {
            //Binding Demographic
            if (dtDemographic.Rows.Count > 0)
            {
                this.btePreparation.EditValue = null; // clear value
                this.tbHN.Text = dtDemographic.Rows[0]["HN"].ToString();
                this.tbHN.Tag = dtDemographic.Rows[0]["REG_ID"]; //Keep Tag Reg Id
                this.tbThaiFName.Text = dtDemographic.Rows[0]["FNAME"].ToString();
                this.tbThaiLName.Text = dtDemographic.Rows[0]["LNAME"].ToString();
                if (!string.IsNullOrEmpty(dtDemographic.Rows[0]["FNAME_ENG"].ToString()))
                    this.tbEngFName.Text = dtDemographic.Rows[0]["FNAME_ENG"].ToString();
                else
                    this.tbEngFName.Text = Miracle.Translator.TransToEnglish.Trans(this.tbThaiFName.Text); //Tran
                if (!string.IsNullOrEmpty(dtDemographic.Rows[0]["LNAME_ENG"].ToString()))
                    this.tbEngLName.Text = dtDemographic.Rows[0]["LNAME_ENG"].ToString();
                else
                    tbEngLName.Text = Miracle.Translator.TransToEnglish.Trans(this.tbThaiLName.Text); // Tran
                this.tbGender.Text = dtDemographic.Rows[0]["GENDER"].ToString() == "F" ? "หญิง" : "ชาย";
                // Active or inactive by gender 
                if (dtDemographic.Rows[0]["GENDER"].ToString() == "M")
                    this.dtLMP.Properties.ReadOnly = true;
                else
                    this.dtLMP.Properties.ReadOnly = false;
                this.dtLMP.EditValue = string.IsNullOrEmpty(dtOrderInfo.Rows[0]["LMP_DT"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dtOrderInfo.Rows[0]["LMP_DT"]);
                this.dtDOB.EditValue = Convert.ToDateTime(dtDemographic.Rows[0]["DOB"]);
                this.btePatientStatus.EditValue = dtDemographic.Rows[0]["PAT_STATUS"].ToString();
                
                this.glkOrderingDept.EditValue = dtDemographic.Rows[0]["REF_UNIT"].ToString();
                this.glkOrderingDoc.EditValue = dtDemographic.Rows[0]["REF_DOC_ID"].ToString();
                this.tbInsuranceType.Text = string.IsNullOrEmpty(dtDemographic.Rows[0]["INSURANCE_TYPE_DESC"].ToString()) ? "เงินสด" : dtDemographic.Rows[0]["INSURANCE_TYPE_DESC"].ToString();
                //set insurance type id
                this._insuranceId = string.IsNullOrEmpty(dtDemographic.Rows[0]["INSURANCE_TYPE_ID"].ToString()) ? 11 : Convert.ToInt32(dtDemographic.Rows[0]["INSURANCE_TYPE_ID"]);
                this.cbThaiTitleName.EditValue = dtDemographic.Rows[0]["TITLE"].ToString();
                this.cbEngTitleName.EditValue = dtDemographic.Rows[0]["TITLE_ENG"].ToString();

                // ####### UPDATE INSURANCE TYPE BY THREAD #######
                // #### BECAUSE HIS WEBSERVICE IS TOO SLOW
                this.thread1 = new Thread(new ThreadStart(this.UpdateInsuranceType)); //create thread for preparing update insurance type
                this.thread1.Start(); //start update insurance type
                // ####### UPDATE ADMISSION NO BY THREAD ######
                this.thread2 = new Thread(new ThreadStart(this.UpdateAdmissionNumber));
                this.thread2.Start(); //start update admission no
            }
            // Binding Exam List
            this.gridControl1.DataSource = dtOrderInfo;
        }

        /// <summary>
        /// This method use to update insurance type from HIS webservice
        /// </summary>
        public void UpdateInsuranceType()
        {
            #region [ Update Insurance Tpye From HIS ]
            //update current info.
            //string encType = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString()) ? "" : this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString();
            //string encId = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_ID"].ToString()) ? "0" : this.dtCasesInfo.Rows[0]["ENC_ID"].ToString();
            string encType = string.Empty;
            string encId = string.Empty;
            EncounterManagement.LoadEncounter(this.dtPatientDemographic.Rows[0]["HN"].ToString()
                , this.dtPatientDemographic.Rows[0]["UNIT_UID"].ToString()
                , ref encId
                , ref encType);

            this.dtCasesInfo.Rows[0]["ENC_TYPE"] = encType;
            int intEncId = 0;
            this.dtCasesInfo.Rows[0]["ENC_ID"] = int.TryParse(encId.Trim(), out intEncId) ? int.Parse(encId.Trim()) : 0;
            string sdloc = this.dtPatientDemographic.Rows[0]["UNIT_UID"].ToString();
            string prefDate = DateTime.Today.ToShortDateString();
            string insuranceTypeUid = string.Empty;
            if (this.tbInsuranceType.InvokeRequired)
                this.tbInsuranceType.Invoke(new MethodInvoker(delegate {
                    this.bkBackColor = this.tbInsuranceType.BackColor;
                    this.tbInsuranceType.Text = "กำลังอัพเดต..."; //set waiting message
                    this.tbInsuranceType.BackColor = Color.Orange;
                }));
            string encounterClinicType = string.Empty;
            int clinicTypeId = dtCasesInfo.Rows[0]["CLINIC_TYPE_ID"].ToString() != string.Empty ? Convert.ToInt32(dtCasesInfo.Rows[0]["CLINIC_TYPE_ID"]) : 1;
            // GET ENCOUNTER CLINIC TYPE
            switch (clinicTypeId)
            {
                case 1: encounterClinicType = "RGL"; break;
                case 7: encounterClinicType = "SPC"; break;
                case 8: encounterClinicType = "SPC"; break;
                case 6: encounterClinicType = "PRM"; break;
                default: encounterClinicType = "RGL"; break;
            }
            try
            {
                insuranceTypeUid = Envision.BusinessLogic.InsuranceManagement.LoadInsuranceCodeFromHIS(this.tbHN.Text, encId, encType, sdloc, prefDate, encounterClinicType);
                DataTable dtInsuranceType = Envision.BusinessLogic.RISBaseData.Ris_InsuranceType();
                DataRow[] drRows = dtInsuranceType.Select("INSURANCE_TYPE_UID='" + insuranceTypeUid + "'");
                if (drRows.Length > 0)
                {
                    if (this.tbInsuranceType.InvokeRequired)
                    {
                        this.tbInsuranceType.Invoke(new MethodInvoker(delegate 
                            {
                                this._insuranceId = Convert.ToInt32(drRows[0]["INSURANCE_TYPE_ID"].ToString());
                                this.tbInsuranceType.Text = drRows[0]["INSURANCE_TYPE_DESC"].ToString();
                                this.tbInsuranceType.BackColor = this.bkBackColor;
                            }));
                    }
                }

                dtInsuranceType = null;
                drRows = null;
            }
            catch
            {
                // Set to UNK
                if (this.tbInsuranceType.InvokeRequired)
                {
                    this.tbInsuranceType.Invoke(new MethodInvoker(delegate
                    {
                        this._insuranceId = 11;
                        this.tbInsuranceType.Text = "เงินสด";
                        this.tbInsuranceType.BackColor = this.bkBackColor;
                    }));
                }
            }
            finally
            {
                encType = string.Empty;
                encId = string.Empty;
                sdloc = string.Empty;
                prefDate = string.Empty;
                bkBackColor = Color.Empty;
                thread1.Abort(); //terminate thread
            }
            #endregion
        }

        /// <summary>
        /// This method use to update admission number
        /// </summary>
        public void UpdateAdmissionNumber()
        {
            try
            {
                string admissionNo = EncounterManagement.LoadAdmissinNo(this.tbHN.Text);
                _admissionNo = string.IsNullOrEmpty(admissionNo) ? string.Empty : admissionNo;
            }
            catch { _admissionNo = string.Empty; }
            finally
            {
                this.thread2.Abort();
            }
        }

        /// <summary>
        /// This method use to build order to RIS_ORDER and RIS_ORDERDTL
        /// </summary>
        private int BuildOrder()
        {
            int orderId = 0;
            // ## Local Parameter
            List<string> accessionList = new List<string>(); //create accession list for keep acession
            bool isSchedule = false;
            int portable_exam_id = 1067;

            if (this._selectedScheduleId != 0)
                isSchedule = true; // set is schedule

            DbConnection connection = null;
            DbTransaction transaction = null;

            ProcessUpdateHISRegistrationByConfirmArrival _processUpdateHISRegistrationByConfirmArrival = null;
            ProcessAddRISOrderV2 _processAddRISOrder = null;
            ProcessAddRISOrderDtlV2 _processAddRISOrderDtl = null;
            ProcessUpdateRISOrderdtl _processUpdateRISOrderDtl = null;
            ProcessUpdateRISScheduleSentToOrder _processUpdateRISScheduleSentToOrder = null;
            ProcessUpdateXrayReqSendToOrder _processUpdateXrayReqSendToOrder = null;
            ProcessGetRISOrderGenAccessionNo _processGetRISOrderGenAccessionNo = null;
            try
            {
                // #### add exam portable when patient status = Portable (status id = 7) ####
                // exam id 1067 -> Portable service exam
                DataRow[] drExamPortables = RISBaseData.Ris_Exam().Select("EXAM_ID=" + portable_exam_id);
                if (drExamPortables.Length > 0
                    && Convert.ToInt32(btePatientStatus.EditValue) == 7)
                {
                    DataRow drAddExam = this.dtCasesInfo.NewRow();
                    drAddExam["EXAM_ID"] = portable_exam_id; // hard code
                    drAddExam["EXAM_UID"] = drExamPortables[0]["EXAM_UID"]; // hard code
                    drAddExam["EXAM_NAME"] = drExamPortables[0]["EXAM_NAME"]; // hard code
                    drAddExam["PRIORITY"] = this.dtCasesInfo.Rows[0]["PRIORITY"];
                    drAddExam["MODALITY_ID"] = 56; //hard code
                    drAddExam["EXAM_RATE"] = drExamPortables[0]["RATE"]; //hard code
                    drAddExam["CLINIC_TYPE_ID"] = this.dtCasesInfo.Rows[0]["CLINIC_TYPE_ID"];
                    //drAddExam["ACCESSION_NO"] = this.GenarateAccession();
                    drAddExam["ASSIGN_TO"] = this.dtCasesInfo.Rows[0]["ASSIGN_TO"];
                    drAddExam["EXAM_DT"] = this.dtCasesInfo.Rows[0]["EXAM_DT"];
                    if (isSchedule)
                        drAddExam["SCHEDULE_DT"] = this.dtCasesInfo.Rows[0]["SCHEDULE_DT"];
                    else
                        drAddExam["ORDER_DT"] = this.dtCasesInfo.Rows[0]["ORDER_DT"];
                    drAddExam["QTY"] = this.dtCasesInfo.Rows[0]["QTY"];
                    this.dtCasesInfo.Rows.Add(drAddExam);
                    this.dtCasesInfo.AcceptChanges();
                }
                // #### UPDATE HIS REGISTRATION ####
                _processUpdateHISRegistrationByConfirmArrival = new ProcessUpdateHISRegistrationByConfirmArrival();
                _processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.TITLE = this.cbThaiTitleName.Text;
                _processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.TITLE_ENG = this.cbEngTitleName.Text;
                _processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.REG_ID = Convert.ToInt32(this.dtPatientDemographic.Rows[0]["REG_ID"]);
                _processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.FNAME_ENG = this.tbEngFName.Text;
                _processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.LNAME_ENG = this.tbEngLName.Text;
                _processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.LAST_MODIFIED_BY = this.gblenv.UserID;
                _processUpdateHISRegistrationByConfirmArrival.HIS_REGISTRATION.ORG_ID = this.gblenv.OrgID;
                _processUpdateHISRegistrationByConfirmArrival.Invoke();

                // #### INSERT DATA TO TABLE RIS_ORDER AND RIS_ORDERDTL ####
                connection = BusinessLogic.RISBaseData.ConnectionDataBase();
                connection.Open();
                transaction = connection.BeginTransaction();

                // Create Business Logic
                _processAddRISOrder = new ProcessAddRISOrderV2();
                _processAddRISOrderDtl = new ProcessAddRISOrderDtlV2();
                _processUpdateRISOrderDtl = new ProcessUpdateRISOrderdtl();
                _processUpdateRISScheduleSentToOrder = new ProcessUpdateRISScheduleSentToOrder();
                _processUpdateXrayReqSendToOrder = new ProcessUpdateXrayReqSendToOrder();
                _processGetRISOrderGenAccessionNo = new ProcessGetRISOrderGenAccessionNo();
                // Use Transaction
                _processAddRISOrder.Transaction = transaction;
                _processAddRISOrderDtl.UseTransaction = transaction;
                _processUpdateRISOrderDtl.Transaction = transaction;
                _processUpdateRISScheduleSentToOrder.Transaction = transaction;
                _processUpdateXrayReqSendToOrder.Transaction = transaction;
                _processGetRISOrderGenAccessionNo.Transaction = transaction;

                // Insert to RIS_ORDER
                _processAddRISOrder.RIS_ORDER.REG_ID = Convert.ToInt32(this.dtPatientDemographic.Rows[0]["REG_ID"]);
                _processAddRISOrder.RIS_ORDER.HN = this.dtPatientDemographic.Rows[0]["HN"].ToString();
                _processAddRISOrder.RIS_ORDER.ORG_ID = gblenv.OrgID;
                _processAddRISOrder.RIS_ORDER.ARRIVAL_BY = gblenv.UserID;
                _processAddRISOrder.RIS_ORDER.ARRIVAL_ON = DateTime.Now;
                _processAddRISOrder.RIS_ORDER.CREATED_BY = gblenv.UserID;
                _processAddRISOrder.RIS_ORDER.ADMISSION_NO = _admissionNo;
                if (isSchedule)
                {
                    if (this.dtCasesInfo.Rows[0]["IS_REQONLINE"].ToString() == "Y")
                        _processAddRISOrder.RIS_ORDER.IS_REQONLINE = "Y";
                    _processAddRISOrder.RIS_ORDER.ORDER_START_TIME = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["START_DATETIME"]);
                    _processAddRISOrder.RIS_ORDER.ORDER_DT = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["SCHEDULE_DT"]);
                    _processAddRISOrder.RIS_ORDER.REF_DOC = Convert.ToInt32(this.glkOrderingDoc.EditValue);
                    _processAddRISOrder.RIS_ORDER.SCHEDULE_ID = _selectedScheduleId;
                }
                else
                {
                    _processAddRISOrder.RIS_ORDER.IS_REQONLINE = "Y";
                    _processAddRISOrder.RIS_ORDER.ORDER_DT = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["ORDER_DT"]);
                    _processAddRISOrder.RIS_ORDER.ORDER_START_TIME = Convert.ToDateTime(this.dtCasesInfo.Rows[0]["ORDER_START_TIME"]);
                    _processAddRISOrder.RIS_ORDER.REF_DOC = Convert.ToInt32(this.glkOrderingDoc.EditValue);
                }
                _processAddRISOrder.RIS_ORDER.REF_UNIT = Convert.ToInt32(this.glkOrderingDept.EditValue);
                _processAddRISOrder.RIS_ORDER.INSURANCE_TYPE_ID = _insuranceId;
                _processAddRISOrder.RIS_ORDER.PAT_STATUS = this.btePatientStatus.EditValue.ToString();
                _processAddRISOrder.RIS_ORDER.CLINICAL_INSTRUCTION = this.dtCasesInfo.Rows[0]["CLINICAL_INSTRUCTION"].ToString();
                _processAddRISOrder.RIS_ORDER.REF_DOC_INSTRUCTION = this.dtCasesInfo.Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                _processAddRISOrder.RIS_ORDER.ENC_ID = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_ID"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["ENC_ID"].ToString();
                _processAddRISOrder.RIS_ORDER.ENC_TYPE = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["ENC_TYPE"].ToString();
                _processAddRISOrder.RIS_ORDER.ENC_CLINIC = string.IsNullOrEmpty(this.dtCasesInfo.Rows[0]["ENC_CLINIC"].ToString()) ? string.Empty : this.dtCasesInfo.Rows[0]["ENC_CLINIC"].ToString();
                if (_selectedScheduleId != 0)
                    _processAddRISOrder.RIS_ORDER.SCHEDULE_ID = _selectedScheduleId;
                _processAddRISOrder.Invoke();

                // set order id 
                orderId = _processAddRISOrder.RIS_ORDER.ORDER_ID;

                // Insert to RIS_ORDERDTL
                foreach (DataRow eachExamRow in this.dtCasesInfo.Rows)
                {
                    _processAddRISOrderDtl.RIS_ORDERDTL.ORDER_ID = _processAddRISOrder.RIS_ORDER.ORDER_ID;
                    _processAddRISOrderDtl.RIS_ORDERDTL.EXAM_DT = Convert.ToDateTime(eachExamRow["EXAM_DT"]);
                    _processAddRISOrderDtl.RIS_ORDERDTL.ORG_ID = gblenv.OrgID;
                    _processAddRISOrderDtl.RIS_ORDERDTL.CREATED_BY = gblenv.UserID;
                    if (isSchedule)
                    {
                        _processAddRISOrderDtl.RIS_ORDERDTL.EST_START_TIME = Convert.ToDateTime(eachExamRow["SCHEDULE_DT"]);
                    }
                    else
                    {
                        _processAddRISOrderDtl.RIS_ORDERDTL.EST_START_TIME = Convert.ToDateTime(eachExamRow["ORDER_DT"]);
                    }
                    _processAddRISOrderDtl.RIS_ORDERDTL.QTY = Convert.ToByte(eachExamRow["QTY"].ToString());
                    _processAddRISOrderDtl.RIS_ORDERDTL.ASSIGNED_TO = eachExamRow["ASSIGN_TO"].ToString() == string.Empty ? 0 : Convert.ToInt32(eachExamRow["ASSIGN_TO"]);
                    _processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID = Convert.ToInt32(eachExamRow["MODALITY_ID"]);
                    _processAddRISOrderDtl.RIS_ORDERDTL.PRIORITY = Convert.ToChar(eachExamRow["PRIORITY"].ToString());
                    _processAddRISOrderDtl.RIS_ORDERDTL.EXAM_ID = Convert.ToInt32(eachExamRow["EXAM_ID"]);
                    _processAddRISOrderDtl.RIS_ORDERDTL.RATE = (decimal)eachExamRow["EXAM_RATE"];
                    _processAddRISOrderDtl.RIS_ORDERDTL.CLINIC_TYPE = eachExamRow["CLINIC_TYPE_ID"].ToString().Trim() == string.Empty || eachExamRow["CLINIC_TYPE_ID"].ToString().Trim() == null ? 0 : (int)eachExamRow["CLINIC_TYPE_ID"];
                    if (_processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID > 0)
                    {
                        //Get acession no
                        _processGetRISOrderGenAccessionNo.MODALITY_ID = _processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID;
                        _processGetRISOrderGenAccessionNo.REF_UNIT_ID = Convert.ToInt32(this.glkOrderingDept.EditValue);
                        _processGetRISOrderGenAccessionNo.Invoke();
                        _processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO = _processGetRISOrderGenAccessionNo.ACCESSION_ON;
                    }
                    else
                    {
                        _processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID = 86;
                        _processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO = Envision.BusinessLogic.Order.GenHN();
                    }
                    _processAddRISOrderDtl.RIS_ORDERDTL.BPVIEW_ID = string.IsNullOrEmpty(eachExamRow["BPVIEW_ID"].ToString()) ? 0 : Convert.ToInt32(eachExamRow["BPVIEW_ID"]);
                    _processAddRISOrderDtl.RIS_ORDERDTL.HIS_SYNC = string.IsNullOrEmpty(eachExamRow["HIS_SYNC"].ToString()) ? 'N' : Convert.ToChar(eachExamRow["HIS_SYNC"].ToString());
                    _processAddRISOrderDtl.RIS_ORDERDTL.HIS_ACK = eachExamRow["HIS_ACK"].ToString();
                    _processAddRISOrderDtl.RIS_ORDERDTL.PREPARATION_ID = btePreparation.EditValue == null ? 0 : (int)btePreparation.EditValue;
                    _processAddRISOrderDtl.RIS_ORDERDTL.COMMENTS_ONLINE = eachExamRow["COMMENTS"].ToString();
                    _processAddRISOrderDtl.RIS_ORDERDTL.PAT_DEST_ID = eachExamRow["PAT_DEST_ID"].ToString() != string.Empty ? Convert.ToInt32(eachExamRow["PAT_DEST_ID"].ToString()) : 0;
                    _processAddRISOrderDtl.Invoke();

                    // #### UPDATE SCHEDULE SEND TO ORDER
                    if (isSchedule)
                    {
                        _processUpdateRISScheduleSentToOrder.SCHEDULE_ID = _selectedScheduleId;
                        _processUpdateRISScheduleSentToOrder.ORG_ID = gblenv.OrgID;
                        _processUpdateRISScheduleSentToOrder.LAST_MODIFIED_BY = gblenv.UserID;
                        _processUpdateRISScheduleSentToOrder.ORDER_ID = _processAddRISOrder.RIS_ORDER.ORDER_ID;
                        _processUpdateRISScheduleSentToOrder.Invoke();
                    }
                    // #### UPDATE XRAYREQ SEND TO ORDER
                    else
                    {
                        _processUpdateXrayReqSendToOrder.ORDER_ID = _processAddRISOrder.RIS_ORDER.ORDER_ID;
                        _processUpdateXrayReqSendToOrder.LAST_MODIFIED_BY = gblenv.UserID;
                        _processUpdateXrayReqSendToOrder.ORG_ID = gblenv.OrgID;
                        _processUpdateXrayReqSendToOrder.XRAY_ID = _selectedOrderId;
                        _processUpdateXrayReqSendToOrder.Invoke();
                    }
                    // add accession for set billing
                    accessionList.Add(_processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO);
                }

                transaction.Commit();
                //connection.Close();

                //Send To Pasc
                try
                {
                    sendToPacs.SendHL7Queue(_processAddRISOrder.RIS_ORDER.ORDER_ID);
                }
                catch { messageBox.ShowAlert("UID6122", gblenv.CurrentLanguageID); }

                //Send Billing
                foreach (string eachAccession in accessionList)
                {
                    string ackMessage = BillingManagement.SUCCESS_SEND_BILLING;
                    if (!BillingManagement.SendBilling(eachAccession, gblenv.UserName, true))
                    {
                        ackMessage = BillingManagement.FAIL_SEND_BILLING;
                        messageBox.ShowAlert("UID6121", gblenv.CurrentLanguageID);
                    }
                    OrderManagement.UpdateOrderHISSync(eachAccession, 
                        ackMessage == BillingManagement.FAIL_SEND_BILLING ? "N" : "Y", ackMessage, gblenv.OrgID);
                    Thread.Sleep(100); //set thread sleep 100 msec
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch 
            { 
                transaction.Rollback();
                connection.Close();
                return orderId;
            }
            finally
            {
                portable_exam_id = 0;
                _processUpdateHISRegistrationByConfirmArrival = null;
                _processAddRISOrder = null;
                _processAddRISOrderDtl = null;
                _processUpdateRISOrderDtl = null;
                accessionList = null;
                connection.Close();
            }
            return orderId;
        }

        #region :: Show Dialog ::
        /// <summary>
        /// Override method show dialog with initial by order and org
        /// </summary>
        /// <param name="order_Id">order id</param>
        /// <param name="org_Id">org id</param>
        /// <returns>dialog result(OK, Cancel)</returns>
        public DialogResult ShowConfirmOrderDialog(int order_Id, int org_id)
        {
            this.txtHN.Focus();
            this._selectedOrderId = order_Id; // back up order id
            this._selectedOrgId = org_id; // back up org id
            // Get Xray order info.
            DataSet dsSource = null;
            DataTable dtDemographic = null;
            DataTable dtOrderInfo = null;
            try
            {
                _processGetXrayOrderInfo.ORDER_ID = order_Id;
                _processGetXrayOrderInfo.ORG_ID = org_id;
                _processGetXrayOrderInfo.Invoke();
                dsSource = _processGetXrayOrderInfo.Result;
                if(dsSource != null)
                    if (dsSource.Tables.Count > 1)
                    {
                        dtDemographic = dsSource.Tables[0]; // demographic table
                        dtOrderInfo = dsSource.Tables[1]; // order info table
                        this.dtPatientDemographic = dtDemographic.Copy(); // copy to gbl datatable
                        this.dtCasesInfo = dtOrderInfo.Copy();
                        this.BindingData(dtDemographic, dtOrderInfo);
                    }
            }
            finally 
            {
                // clear memory
                dsSource = null;
                dtDemographic = null;
                dtOrderInfo = null;
            }
            return this.ShowDialog();
        }
        /// <summary>
        /// Override method show dialog with initial by schedule id and org
        /// </summary>
        /// <param name="schedule_id">schedule id</param>
        /// <param name="org_id">org id</param>
        /// <returns></returns>
        public DialogResult ShowConfirmScheduleDialog(int schedule_id, int org_id)
        {
            this.txtHN.Focus();
            this._selectedScheduleId = schedule_id; // back up order id
            this._selectedOrgId = org_id; // back up org id
            // Get Xray order info.
            DataSet dsSource = null;
            DataTable dtDemographic = null;
            DataTable dtOrderInfo = null;
            try
            {
                _processGetRISScheduleInfo.SCHEDULE_ID = schedule_id;
                _processGetRISScheduleInfo.ORG_ID = org_id;
                _processGetRISScheduleInfo.Invoke();
                dsSource = _processGetRISScheduleInfo.Result;
                if (dsSource != null)
                    if (dsSource.Tables.Count > 1)
                    {
                        dtDemographic = dsSource.Tables[0]; // demographic table
                        dtOrderInfo = dsSource.Tables[1]; // schedule info table
                        this.dtPatientDemographic = dtDemographic.Copy(); // copy to gbl datatable
                        this.dtCasesInfo = dtOrderInfo.Copy();
                        this.BindingData(dtDemographic, dtOrderInfo);
                    }
            }
            finally
            {
                // clear memory
                dsSource = null;
                dtDemographic = null;
                dtOrderInfo = null;
            }
            return this.ShowDialog();
        }
        #endregion

        #region :: Editor Event ::
        /// <summary>
        /// LMP Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtLMP_EditValueChanged(object sender, EventArgs e)
        {
            if (dtLMP.EditValue != null)
            {
                if ((DateTime)dtLMP.EditValue == DateTime.MinValue)
                    this.dtLMP.EditValue = null;
            }
        }
        /// <summary>
        /// Radiologist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGRa_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
                this.dtCasesInfo.Rows[this.gridView1.FocusedRowHandle]["ASSIGN_TO"] = Convert.ToInt32(e.Value);
        }
        /// <summary>
        /// Exam Date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _repDateEdit_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
                this.dtCasesInfo.Rows[this.gridView1.FocusedRowHandle]["EXAM_DT"] = Convert.ToDateTime(e.Value);
        }
        /// <summary>
        /// Modality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _repModality_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;
            if (this.gridView1.FocusedRowHandle >= 0)
                this.dtCasesInfo.Rows[this.gridView1.FocusedRowHandle]["MODALITY_ID"] = Convert.ToInt32(e.Value);
        }
        /// <summary>
        /// Set Rate by clinic type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _repClinic_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                DataRow drSelectedRow = this.gridView1.GetFocusedDataRow();
                //int clinicTypeId = drSelectedRow["CLINIC_TYPE_ID"].ToString() != string.Empty ? Convert.ToInt32(drSelectedRow["CLINIC_TYPE_ID"]) : 1;
                if (Convert.ToInt32(e.NewValue) == 7 || Convert.ToInt32(e.NewValue) == 8)
                    drSelectedRow["EXAM_RATE"] = drSelectedRow["SPC_RATE"];
                else
                    drSelectedRow["EXAM_RATE"] = drSelectedRow["RGL_RATE"];
            }
        }

        #endregion

        #region :: Tools Bar ::
        /// <summary>
        /// Open Lab Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barLabData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_lab_data(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                        //lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Lab_Clicks);
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
            catch { messageBox.ShowAlert("UID4022", gblenv.CurrentLanguageID); }
        }
        /// <summary>
        /// Open patient allergy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barPatientAllergy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                if (txtHN.Text.Length > 0)
                {
                    DataSet dsHIS = HIS_p.Get_Adr(txtHN.Text);
                    if (dsHIS.Tables[0].Rows.Count > 0)
                    {
                        Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                        //lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Adr_Clicks);
                        lv.Text = "Alergy Detail List";
                        lv.Data = dsHIS.Tables[0];

                        Size ss = new Size(800, 600);
                        lv.Size = ss;
                        lv.ShowBox();
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.thread1.IsAlive)
                this.thread1.Abort(); //terminate thread
            if (this.thread2.IsAlive)
                this.thread2.Abort(); //terminate thread
            this.tbInsuranceType.BackColor = this.bkBackColor; //restore back color
            this.Close();
        }
        /// <summary>
        /// Save order 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.thread1.IsAlive || this.thread2.IsAlive)
            {
                // MESSAGE : กรุณารอสักครู่ ระบบกำลังเตรียมพร้อมข้อมูล
                this.messageBox.ShowAlert("UID6120", gblenv.CurrentLanguageID);
                return;
            }
            if (this.glkOrderingDept.EditValue == null || this.glkOrderingDoc.EditValue == null)
            {
                if (string.IsNullOrEmpty(this.glkOrderingDept.EditValue.ToString()) || string.IsNullOrEmpty(this.glkOrderingDoc.EditValue.ToString()))
                {
                    this.messageBox.ShowAlert("UID6123", gblenv.CurrentLanguageID);
                    return;
                }
            }

            this.BuildOrder(); // create order
        }
        /// <summary>
        /// Save order with print
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barSaveAndPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.thread1.IsAlive || this.thread2.IsAlive)
            {
                // MESSAGE : กรุณารอสักครู่ ระบบกำลังเตรียมพร้อมข้อมูล
                this.messageBox.ShowAlert("UID6120", gblenv.CurrentLanguageID);
                return;
            }
            if (this.glkOrderingDept.EditValue == null || this.glkOrderingDoc.EditValue == null)
            {
                if (string.IsNullOrEmpty(this.glkOrderingDept.EditValue.ToString()) || string.IsNullOrEmpty(this.glkOrderingDoc.EditValue.ToString()))
                {
                    this.messageBox.ShowAlert("UID6123", gblenv.CurrentLanguageID);
                    return;
                }
            }

            Envision.Plugin.XtraFile.xtraReports.xrptOrderReport report = new Envision.Plugin.XtraFile.xtraReports.xrptOrderReport(this.BuildOrder());
            report.Print(); //print
        }
        /// <summary>
        /// Scan form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmScanImage frm = new frmScanImage();
            frm.ShowDialog();
            frm.Dispose();
        }
        #endregion       

    }
}