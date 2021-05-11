namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_ENV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GBL_ENV()
        {
            AC_ASSIGNMENT = new HashSet<AC_ASSIGNMENT>();
            AC_CLASS = new HashSet<AC_CLASS>();
            AC_ENROLLMENT = new HashSet<AC_ENROLLMENT>();
            AC_EVALUATION = new HashSet<AC_EVALUATION>();
            AC_EVALUATIONLOGIC = new HashSet<AC_EVALUATIONLOGIC>();
            AC_GRADE = new HashSet<AC_GRADE>();
            AC_REPORTINGLANGUAGE = new HashSet<AC_REPORTINGLANGUAGE>();
            AC_YEAR = new HashSet<AC_YEAR>();
            FIN_INVOICE = new HashSet<FIN_INVOICE>();
            FIN_INVOICEDTL = new HashSet<FIN_INVOICEDTL>();
            FIN_PAYMENT = new HashSet<FIN_PAYMENT>();
            FIN_PAYMENTDTL = new HashSet<FIN_PAYMENTDTL>();
            GBL_ALERT = new HashSet<GBL_ALERT>();
            GBL_ALERTDTL = new HashSet<GBL_ALERTDTL>();
            GBL_EMPSCHEDULECATEGORY = new HashSet<GBL_EMPSCHEDULECATEGORY>();
            GBL_EXCEPTIONLOG = new HashSet<GBL_EXCEPTIONLOG>();
            GBL_GENERAL = new HashSet<GBL_GENERAL>();
            GBL_GENERALDTL = new HashSet<GBL_GENERALDTL>();
            GBL_GRANTOBJECT = new HashSet<GBL_GRANTOBJECT>();
            GBL_GRANTROLE = new HashSet<GBL_GRANTROLE>();
            GBL_GROUP = new HashSet<GBL_GROUP>();
            GBL_GROUPDTL = new HashSet<GBL_GROUPDTL>();
            GBL_HOSPITAL = new HashSet<GBL_HOSPITAL>();
            GBL_LANGUAGE = new HashSet<GBL_LANGUAGE>();
            GBL_MENU = new HashSet<GBL_MENU>();
            GBL_MYMENU = new HashSet<GBL_MYMENU>();
            GBL_MYMENU1 = new HashSet<GBL_MYMENU>();
            GBL_MYMENU2 = new HashSet<GBL_MYMENU>();
            GBL_PRODUCT = new HashSet<GBL_PRODUCT>();
            GBL_ROLE = new HashSet<GBL_ROLE>();
            GBL_ROLEDTL = new HashSet<GBL_ROLEDTL>();
            GBL_SEQUENCES = new HashSet<GBL_SEQUENCES>();
            GBL_SESSION = new HashSet<GBL_SESSION>();
            GBL_SESSIONLOG = new HashSet<GBL_SESSIONLOG>();
            GBL_SUBMENU = new HashSet<GBL_SUBMENU>();
            GBL_SUBMENUOBJECTLABEL = new HashSet<GBL_SUBMENUOBJECTLABEL>();
            GBL_SUBMENUOBJECTS = new HashSet<GBL_SUBMENUOBJECTS>();
            GBL_SUPPORT = new HashSet<GBL_SUPPORT>();
            GBL_USERGROUP = new HashSet<GBL_USERGROUP>();
            GBL_USERGROUPDTL = new HashSet<GBL_USERGROUPDTL>();
            HR_EMP = new HashSet<HR_EMP>();
            HR_EMPTITLE = new HashSet<HR_EMPTITLE>();
            HR_ROOM = new HashSet<HR_ROOM>();
            HR_UNIT = new HashSet<HR_UNIT>();
            INV_AUTHORIZATION = new HashSet<INV_AUTHORIZATION>();
            INV_AUTHORISER = new HashSet<INV_AUTHORISER>();
            INV_CATEGORY = new HashSet<INV_CATEGORY>();
            INV_ITEM = new HashSet<INV_ITEM>();
            INV_ITEMSTATUS = new HashSet<INV_ITEMSTATUS>();
            INV_ITEMTYPE = new HashSet<INV_ITEMTYPE>();
            INV_PO = new HashSet<INV_PO>();
            INV_PODTL = new HashSet<INV_PODTL>();
            INV_PR = new HashSet<INV_PR>();
            INV_REQUISITION = new HashSet<INV_REQUISITION>();
            INV_REQUISITIONDTL = new HashSet<INV_REQUISITIONDTL>();
            INV_ROOMSTOCKREDUCE = new HashSet<INV_ROOMSTOCKREDUCE>();
            INV_SETTINGS = new HashSet<INV_SETTINGS>();
            INV_TXNUNIT = new HashSet<INV_TXNUNIT>();
            INV_UNIT = new HashSet<INV_UNIT>();
            INV_UNITREORDERLEVEL = new HashSet<INV_UNITREORDERLEVEL>();
            INV_VENDOR = new HashSet<INV_VENDOR>();
            MG_BREASTEXAMRESULT = new HashSet<MG_BREASTEXAMRESULT>();
            MG_BREASTMARK = new HashSet<MG_BREASTMARK>();
            MG_BREASTMARKDTL = new HashSet<MG_BREASTMARKDTL>();
            MG_BREASTMARKTEMPLATE = new HashSet<MG_BREASTMARKTEMPLATE>();
            MG_BREASTMASSDETAILS = new HashSet<MG_BREASTMASSDETAILS>();
            MG_DOMINANT = new HashSet<MG_DOMINANT>();
            MG_MADOMINANT = new HashSet<MG_MADOMINANT>();
            MG_MARKSHAPE = new HashSet<MG_MARKSHAPE>();
            MG_MARKSTYLE = new HashSet<MG_MARKSTYLE>();
            MG_MASSDOMINANTCYST = new HashSet<MG_MASSDOMINANTCYST>();
            MG_PATIENTHISTORYCOMPARISON = new HashSet<MG_PATIENTHISTORYCOMPARISON>();
            MIS_ASESSMENTTYPE = new HashSet<MIS_ASESSMENTTYPE>();
            MIS_BIOPSYRESULT = new HashSet<MIS_BIOPSYRESULT>();
            MIS_LESIONTYPE = new HashSet<MIS_LESIONTYPE>();
            MIS_TECHNIQUETYPE = new HashSet<MIS_TECHNIQUETYPE>();
            RIS_ASSESSMENT = new HashSet<RIS_ASSESSMENT>();
            RIS_BODYPART = new HashSet<RIS_BODYPART>();
            RIS_BPVIEW = new HashSet<RIS_BPVIEW>();
            RIS_CLINICALINDICATIONCHECKUPLIST = new HashSet<RIS_CLINICALINDICATIONCHECKUPLIST>();
            RIS_CLINICALINDICATIONTYPEFAVORITES = new HashSet<RIS_CLINICALINDICATIONTYPEFAVORITES>();
            RIS_CLINICALINDICATIONTYPE = new HashSet<RIS_CLINICALINDICATIONTYPE>();
            RIS_CLINICSESSION = new HashSet<RIS_CLINICSESSION>();
            RIS_CLINICSESSIONONLINE = new HashSet<RIS_CLINICSESSIONONLINE>();
            RIS_CLINICTYPE = new HashSet<RIS_CLINICTYPE>();
            RIS_COMMENTSONPATIENT = new HashSet<RIS_COMMENTSONPATIENT>();
            RIS_COMMENTSONPATIENTDTL = new HashSet<RIS_COMMENTSONPATIENTDTL>();
            RIS_CONFLICTEXAMDTL = new HashSet<RIS_CONFLICTEXAMDTL>();
            RIS_CONFLICTEXAMGROUP = new HashSet<RIS_CONFLICTEXAMGROUP>();
            RIS_CONSUMABLETYPE = new HashSet<RIS_CONSUMABLETYPE>();
            RIS_ENVISIONONLINEPARAMETERSLOG = new HashSet<RIS_ENVISIONONLINEPARAMETERSLOG>();
            RIS_EXAMINSTRUCTIONS = new HashSet<RIS_EXAMINSTRUCTIONS>();
            RIS_EXAMRESULT = new HashSet<RIS_EXAMRESULT>();
            RIS_EXAMRESULTACCESS = new HashSet<RIS_EXAMRESULTACCESS>();
            RIS_EXAMRESULTNOTE = new HashSet<RIS_EXAMRESULTNOTE>();
            RIS_EXAMRESULTSEVERITY = new HashSet<RIS_EXAMRESULTSEVERITY>();
            RIS_EXAMRESULTSTATREPORT = new HashSet<RIS_EXAMRESULTSTATREPORT>();
            RIS_EXAMRESULTTEMPLATE = new HashSet<RIS_EXAMRESULTTEMPLATE>();
            RIS_EXAMSKILL = new HashSet<RIS_EXAMSKILL>();
            RIS_EXAMSKILLMAPPING = new HashSet<RIS_EXAMSKILLMAPPING>();
            RIS_EXAMSKILLTYPE = new HashSet<RIS_EXAMSKILLTYPE>();
            RIS_EXAMTEMPLATESHARE = new HashSet<RIS_EXAMTEMPLATESHARE>();
            RIS_EXAMTYPE = new HashSet<RIS_EXAMTYPE>();
            RIS_HL7TRANSACTIONLOG = new HashSet<RIS_HL7TRANSACTIONLOG>();
            RIS_HOSPITAL_MAP_DOCTOR = new HashSet<RIS_HOSPITAL_MAP_DOCTOR>();
            RIS_RISKINCIDENTUSERS = new HashSet<RIS_RISKINCIDENTUSERS>();
            RIS_MODALITY = new HashSet<RIS_MODALITY>();
            RIS_MODALITYEXAM = new HashSet<RIS_MODALITYEXAM>();
            RIS_MODALITYEXAM_ONL = new HashSet<RIS_MODALITYEXAM_ONL>();
            RIS_MODALITYTYPE = new HashSet<RIS_MODALITYTYPE>();
            RIS_MODALITYUNIT = new HashSet<RIS_MODALITYUNIT>();
            RIS_ORDER = new HashSet<RIS_ORDER>();
            RIS_ORDERDTL = new HashSet<RIS_ORDERDTL>();
            RIS_ORDERIMAGES = new HashSet<RIS_ORDERIMAGES>();
            RIS_PATSTATUS = new HashSet<RIS_PATSTATUS>();
            RIS_PATICD = new HashSet<RIS_PATICD>();
            RIS_PATSTATUS1 = new HashSet<RIS_PATSTATUS>();
            RIS_QAWORKS = new HashSet<RIS_QAWORKS>();
            RIS_QUESTIONS = new HashSet<RIS_QUESTIONS>();
            RIS_RADSTUDYGROUP = new HashSet<RIS_RADSTUDYGROUP>();
            RIS_RESULTSTATUSCHANGELOG = new HashSet<RIS_RESULTSTATUSCHANGELOG>();
            RIS_RISKCATEGORIES = new HashSet<RIS_RISKCATEGORIES>();
            RIS_SCHEDULE_RESERVATION = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULECONFIG = new HashSet<RIS_SCHEDULECONFIG>();
            RIS_SCHEDULEDEFAULTDESTINATION = new HashSet<RIS_SCHEDULEDEFAULTDESTINATION>();
            RIS_SCHEDULEDEFAULTMODALITY = new HashSet<RIS_SCHEDULEDEFAULTMODALITY>();
            RIS_SCHEDULE = new HashSet<RIS_SCHEDULE>();
            RIS_SCHEDULEDTL = new HashSet<RIS_SCHEDULEDTL>();
            RIS_SERVICETYPE = new HashSet<RIS_SERVICETYPE>();
            RIS_SESSIONAPPCOUNT = new HashSet<RIS_SESSIONAPPCOUNT>();
            RIS_SESSIONMAXAPP = new HashSet<RIS_SESSIONMAXAPP>();
            RIS_TECHCONSUMPTION = new HashSet<RIS_TECHCONSUMPTION>();
            RIS_TECHWORKS = new HashSet<RIS_TECHWORKS>();
            SR_QUESTIONS = new HashSet<SR_QUESTIONS>();
            SR_QUESTIONSANSWERS = new HashSet<SR_QUESTIONSANSWERS>();
            SR_QUESTIONSANSWERSDTL = new HashSet<SR_QUESTIONSANSWERSDTL>();
            SR_QUESTIONSANSWERSDTLCHILD = new HashSet<SR_QUESTIONSANSWERSDTLCHILD>();
            SR_QUESTIONSDTL = new HashSet<SR_QUESTIONSDTL>();
            SR_QUESTIONSDTLCHILD = new HashSet<SR_QUESTIONSDTLCHILD>();
            SR_QUESTIONTYPE = new HashSet<SR_QUESTIONTYPE>();
            SR_TEMPLATE = new HashSet<SR_TEMPLATE>();
            SR_TEMPLATEANSWERSPART = new HashSet<SR_TEMPLATEANSWERSPART>();
            SR_TEMPLATEPART = new HashSet<SR_TEMPLATEPART>();
            RIS_CLINICALINDICATION = new HashSet<RIS_CLINICALINDICATION>();
            RIS_CLINICALINDICATION_WITH_UNIT = new HashSet<RIS_CLINICALINDICATION_WITH_UNIT>();
            RIS_CLINICALINDICATIONFAVORITES = new HashSet<RIS_CLINICALINDICATIONFAVORITES>();
            RIS_CLINICALINDICATIONLASTVISIT = new HashSet<RIS_CLINICALINDICATIONLASTVISIT>();
            RIS_EXAMFAVORITES = new HashSet<RIS_EXAMFAVORITES>();
            RIS_ORDERCLINICALINDICATION = new HashSet<RIS_ORDERCLINICALINDICATION>();
            RIS_ORDERCLINICALINDICATIONTYPE = new HashSet<RIS_ORDERCLINICALINDICATIONTYPE>();
            RIS_ORDERCPT = new HashSet<RIS_ORDERCPT>();
            RIS_ORDERICD = new HashSet<RIS_ORDERICD>();
            RIS_PATIENTDESTINATION = new HashSet<RIS_PATIENTDESTINATION>();
            RIS_PRSTUDIES = new HashSet<RIS_PRSTUDIES>();
            RIS_PRGRADE = new HashSet<RIS_PRGRADE>();
            RIS_PRGROUP = new HashSet<RIS_PRGROUP>();
            RIS_PRGROUPDTL = new HashSet<RIS_PRGROUPDTL>();
            RIS_PRREPORTINGLANGUAGE = new HashSet<RIS_PRREPORTINGLANGUAGE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORG_ID { get; set; }

        [StringLength(30)]
        public string ORG_UID { get; set; }

        [StringLength(100)]
        public string ORG_NAME { get; set; }

        [StringLength(30)]
        public string ORG_ALIAS { get; set; }

        [StringLength(100)]
        public string ORG_SLOGAN1 { get; set; }

        [StringLength(100)]
        public string ORG_SLOGAN2 { get; set; }

        [StringLength(100)]
        public string ORG_ADDR1 { get; set; }

        [StringLength(100)]
        public string ORG_ADDR2 { get; set; }

        [StringLength(100)]
        public string ORG_ADDR3 { get; set; }

        [StringLength(100)]
        public string ORG_ADDR4 { get; set; }

        [StringLength(100)]
        public string ORG_TEL1 { get; set; }

        [StringLength(100)]
        public string ORG_TEL2 { get; set; }

        [StringLength(100)]
        public string ORG_TEL3 { get; set; }

        [StringLength(100)]
        public string ORG_FAX { get; set; }

        [StringLength(100)]
        public string ORG_EMAIL1 { get; set; }

        [StringLength(100)]
        public string ORG_EMAIL2 { get; set; }

        [StringLength(100)]
        public string ORG_EMAIL3 { get; set; }

        [StringLength(100)]
        public string ORG_WEBSITE { get; set; }

        [Column(TypeName = "image")]
        public byte[] ORG_IMG { get; set; }

        [StringLength(500)]
        public string WELCOME_DIALOG1 { get; set; }

        [StringLength(500)]
        public string WELCOME_DIALOG2 { get; set; }

        [StringLength(200)]
        public string DEFAULT_FONT_FACE { get; set; }

        public byte? DEFAULT_FONT_SIZE { get; set; }

        [StringLength(50)]
        public string REP_SERVER { get; set; }

        [StringLength(30)]
        public string REP_FORMAT { get; set; }

        [StringLength(500)]
        public string REP_FOOTER1 { get; set; }

        [StringLength(500)]
        public string REP_FOOTER2 { get; set; }

        [StringLength(4)]
        public string EMP_IMG_TYPE { get; set; }

        [StringLength(4)]
        public string EMP_IMG_MAX_SIZE { get; set; }

        public int? OTHER_MAX_FILE_SIZE { get; set; }

        [StringLength(30)]
        public string DT_FMT { get; set; }

        [StringLength(30)]
        public string TIME_FMT { get; set; }

        [StringLength(15)]
        public string LOCAL_CURRENCY_NAME { get; set; }

        [StringLength(2)]
        public string LOCAL_CURRENCY_SYMBOL { get; set; }

        [StringLength(30)]
        public string CURRENCY_FMT { get; set; }

        [StringLength(300)]
        public string RESOURCE_IMAGE_PATH { get; set; }

        [StringLength(300)]
        public string SCANNED_IMAGE_PATH { get; set; }

        [StringLength(500)]
        public string DOCUMENT_PATH { get; set; }

        [StringLength(500)]
        public string BACKUP_PATH { get; set; }

        [StringLength(300)]
        public string OTHER_FILE_PATH { get; set; }

        [StringLength(300)]
        public string EMP_IMG_PATH { get; set; }

        [StringLength(300)]
        public string LAB_DATA_PATH { get; set; }

        [StringLength(10)]
        public string USER_DISPLAY_FMT { get; set; }

        [StringLength(300)]
        public string VENDOR_H1 { get; set; }

        [StringLength(300)]
        public string VENDOR_H2 { get; set; }

        [StringLength(300)]
        public string VENDOR_LOGO_PATH { get; set; }

        [StringLength(300)]
        public string PARTNER1_H1 { get; set; }

        [StringLength(300)]
        public string PARTNER1_H2 { get; set; }

        [StringLength(300)]
        public string PARTNER1_LOGO_PATH { get; set; }

        [StringLength(300)]
        public string PARTNER2_H1 { get; set; }

        [StringLength(300)]
        public string PARTNER2_H2 { get; set; }

        [StringLength(300)]
        public string PARTNER2_LOGO_PATH { get; set; }

        [StringLength(300)]
        public string RIS_IP { get; set; }

        [StringLength(300)]
        public string RIS_PORT { get; set; }

        [StringLength(300)]
        public string RIS_USER { get; set; }

        [StringLength(300)]
        public string RIS_PASS { get; set; }

        [StringLength(300)]
        public string RIS_URL { get; set; }

        [StringLength(300)]
        public string PACS_IP { get; set; }

        [StringLength(300)]
        public string PACS_PORT { get; set; }

        [StringLength(300)]
        public string PACS_URL1 { get; set; }

        [StringLength(300)]
        public string PACS_URL2 { get; set; }

        [StringLength(300)]
        public string PACS_URL3 { get; set; }

        [StringLength(300)]
        public string PACS_DOMAIN { get; set; }

        [StringLength(300)]
        public string HIS_IP { get; set; }

        [StringLength(300)]
        public string HIS_PORT { get; set; }

        [StringLength(300)]
        public string HIS_DB_NAME { get; set; }

        [StringLength(300)]
        public string HIS_USER_NAME { get; set; }

        [StringLength(300)]
        public string HIS_USER_PASS { get; set; }

        [StringLength(300)]
        public string HIS_FIN_FLAG { get; set; }

        [StringLength(300)]
        public string WS_IP { get; set; }

        [StringLength(300)]
        public string WS_IP_PICTURE { get; set; }

        [StringLength(300)]
        public string WS_VERSION { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(15)]
        public string ORM_SYNC_IP { get; set; }

        [StringLength(8)]
        public string ORM_SYNC_PORT { get; set; }

        [StringLength(15)]
        public string ORU_SYNC_IP { get; set; }

        [StringLength(8)]
        public string ORU_SYNC_PORT { get; set; }

        [StringLength(15)]
        public string HIS_SYNC_IP { get; set; }

        [StringLength(8)]
        public string HIS_SYNC_PORT { get; set; }

        [StringLength(1)]
        public string EDIT_ORDER_UNTIL { get; set; }

        public byte? SCHEDULE_CONFIRM_TIME { get; set; }

        public byte? SCHEDULE_APPROVAL_TIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_ASSIGNMENT> AC_ASSIGNMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_CLASS> AC_CLASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_ENROLLMENT> AC_ENROLLMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_EVALUATION> AC_EVALUATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_EVALUATIONLOGIC> AC_EVALUATIONLOGIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_GRADE> AC_GRADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_REPORTINGLANGUAGE> AC_REPORTINGLANGUAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_YEAR> AC_YEAR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_INVOICE> FIN_INVOICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_INVOICEDTL> FIN_INVOICEDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_PAYMENT> FIN_PAYMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_PAYMENTDTL> FIN_PAYMENTDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_ALERT> GBL_ALERT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_ALERTDTL> GBL_ALERTDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_EMPSCHEDULECATEGORY> GBL_EMPSCHEDULECATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_EXCEPTIONLOG> GBL_EXCEPTIONLOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GENERAL> GBL_GENERAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GENERALDTL> GBL_GENERALDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GRANTOBJECT> GBL_GRANTOBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GRANTROLE> GBL_GRANTROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GROUP> GBL_GROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GROUPDTL> GBL_GROUPDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_HOSPITAL> GBL_HOSPITAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_LANGUAGE> GBL_LANGUAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_MENU> GBL_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_MYMENU> GBL_MYMENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_MYMENU> GBL_MYMENU1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_MYMENU> GBL_MYMENU2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_PRODUCT> GBL_PRODUCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_ROLE> GBL_ROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_ROLEDTL> GBL_ROLEDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SEQUENCES> GBL_SEQUENCES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SESSION> GBL_SESSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SESSIONLOG> GBL_SESSIONLOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUBMENU> GBL_SUBMENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUBMENUOBJECTLABEL> GBL_SUBMENUOBJECTLABEL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUBMENUOBJECTS> GBL_SUBMENUOBJECTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUPPORT> GBL_SUPPORT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_USERGROUP> GBL_USERGROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_USERGROUPDTL> GBL_USERGROUPDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_EMP> HR_EMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_EMPTITLE> HR_EMPTITLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_ROOM> HR_ROOM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_UNIT> HR_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_AUTHORIZATION> INV_AUTHORIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_AUTHORISER> INV_AUTHORISER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_CATEGORY> INV_CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_ITEM> INV_ITEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_ITEMSTATUS> INV_ITEMSTATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_ITEMTYPE> INV_ITEMTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PO> INV_PO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PODTL> INV_PODTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PR> INV_PR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_REQUISITION> INV_REQUISITION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_REQUISITIONDTL> INV_REQUISITIONDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_ROOMSTOCKREDUCE> INV_ROOMSTOCKREDUCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_SETTINGS> INV_SETTINGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_TXNUNIT> INV_TXNUNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_UNIT> INV_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_UNITREORDERLEVEL> INV_UNITREORDERLEVEL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_VENDOR> INV_VENDOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_BREASTEXAMRESULT> MG_BREASTEXAMRESULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_BREASTMARK> MG_BREASTMARK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_BREASTMARKDTL> MG_BREASTMARKDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_BREASTMARKTEMPLATE> MG_BREASTMARKTEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_BREASTMASSDETAILS> MG_BREASTMASSDETAILS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_DOMINANT> MG_DOMINANT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_MADOMINANT> MG_MADOMINANT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_MARKSHAPE> MG_MARKSHAPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_MARKSTYLE> MG_MARKSTYLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_MASSDOMINANTCYST> MG_MASSDOMINANTCYST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_PATIENTHISTORYCOMPARISON> MG_PATIENTHISTORYCOMPARISON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIS_ASESSMENTTYPE> MIS_ASESSMENTTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIS_BIOPSYRESULT> MIS_BIOPSYRESULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIS_LESIONTYPE> MIS_LESIONTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIS_TECHNIQUETYPE> MIS_TECHNIQUETYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ASSESSMENT> RIS_ASSESSMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_BODYPART> RIS_BODYPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_BPVIEW> RIS_BPVIEW { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONCHECKUPLIST> RIS_CLINICALINDICATIONCHECKUPLIST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONTYPEFAVORITES> RIS_CLINICALINDICATIONTYPEFAVORITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONTYPE> RIS_CLINICALINDICATIONTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICSESSION> RIS_CLINICSESSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICSESSIONONLINE> RIS_CLINICSESSIONONLINE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICTYPE> RIS_CLINICTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENT> RIS_COMMENTSONPATIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENTDTL> RIS_COMMENTSONPATIENTDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CONFLICTEXAMDTL> RIS_CONFLICTEXAMDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CONFLICTEXAMGROUP> RIS_CONFLICTEXAMGROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CONSUMABLETYPE> RIS_CONSUMABLETYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ENVISIONONLINEPARAMETERSLOG> RIS_ENVISIONONLINEPARAMETERSLOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMINSTRUCTIONS> RIS_EXAMINSTRUCTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULT> RIS_EXAMRESULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTACCESS> RIS_EXAMRESULTACCESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTNOTE> RIS_EXAMRESULTNOTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTSEVERITY> RIS_EXAMRESULTSEVERITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTSTATREPORT> RIS_EXAMRESULTSTATREPORT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTTEMPLATE> RIS_EXAMRESULTTEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMSKILL> RIS_EXAMSKILL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMSKILLMAPPING> RIS_EXAMSKILLMAPPING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMSKILLTYPE> RIS_EXAMSKILLTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMTEMPLATESHARE> RIS_EXAMTEMPLATESHARE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMTYPE> RIS_EXAMTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_HL7TRANSACTIONLOG> RIS_HL7TRANSACTIONLOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_HOSPITAL_MAP_DOCTOR> RIS_HOSPITAL_MAP_DOCTOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RISKINCIDENTUSERS> RIS_RISKINCIDENTUSERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITY> RIS_MODALITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYEXAM> RIS_MODALITYEXAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYEXAM_ONL> RIS_MODALITYEXAM_ONL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYTYPE> RIS_MODALITYTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYUNIT> RIS_MODALITYUNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDER> RIS_ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERIMAGES> RIS_ORDERIMAGES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PATSTATUS> RIS_PATSTATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PATICD> RIS_PATICD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PATSTATUS> RIS_PATSTATUS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_QAWORKS> RIS_QAWORKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_QUESTIONS> RIS_QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RADSTUDYGROUP> RIS_RADSTUDYGROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RESULTSTATUSCHANGELOG> RIS_RESULTSTATUSCHANGELOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RISKCATEGORIES> RIS_RISKCATEGORIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULECONFIG> RIS_SCHEDULECONFIG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTDESTINATION> RIS_SCHEDULEDEFAULTDESTINATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTMODALITY> RIS_SCHEDULEDEFAULTMODALITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SERVICETYPE> RIS_SERVICETYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SESSIONAPPCOUNT> RIS_SESSIONAPPCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SESSIONMAXAPP> RIS_SESSIONMAXAPP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_TECHCONSUMPTION> RIS_TECHCONSUMPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_TECHWORKS> RIS_TECHWORKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONS> SR_QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERS> SR_QUESTIONSANSWERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERSDTL> SR_QUESTIONSANSWERSDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERSDTLCHILD> SR_QUESTIONSANSWERSDTLCHILD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTL> SR_QUESTIONSDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTLCHILD> SR_QUESTIONSDTLCHILD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONTYPE> SR_QUESTIONTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATE> SR_TEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEANSWERSPART> SR_TEMPLATEANSWERSPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEPART> SR_TEMPLATEPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATION> RIS_CLINICALINDICATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATION_WITH_UNIT> RIS_CLINICALINDICATION_WITH_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONFAVORITES> RIS_CLINICALINDICATIONFAVORITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONLASTVISIT> RIS_CLINICALINDICATIONLASTVISIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMFAVORITES> RIS_EXAMFAVORITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERCLINICALINDICATION> RIS_ORDERCLINICALINDICATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERCLINICALINDICATIONTYPE> RIS_ORDERCLINICALINDICATIONTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERCPT> RIS_ORDERCPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERICD> RIS_ORDERICD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PATIENTDESTINATION> RIS_PATIENTDESTINATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRSTUDIES> RIS_PRSTUDIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRGRADE> RIS_PRGRADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRGROUP> RIS_PRGROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRGROUPDTL> RIS_PRGROUPDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRREPORTINGLANGUAGE> RIS_PRREPORTINGLANGUAGE { get; set; }
    }
}
