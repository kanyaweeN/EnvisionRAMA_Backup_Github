namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EMP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HR_EMP()
        {
            AC_ASSIGNMENT = new HashSet<AC_ASSIGNMENT>();
            AC_ENROLLMENT = new HashSet<AC_ENROLLMENT>();
            AC_EVALUATION = new HashSet<AC_EVALUATION>();
            AC_EVALUATIONLOGIC = new HashSet<AC_EVALUATIONLOGIC>();
            GBL_GRANTOBJECT = new HashSet<GBL_GRANTOBJECT>();
            GBL_GRANTROLE = new HashSet<GBL_GRANTROLE>();
            GBL_GROUP = new HashSet<GBL_GROUP>();
            GBL_GROUPDTL = new HashSet<GBL_GROUPDTL>();
            GBL_MYMENU = new HashSet<GBL_MYMENU>();
            GBL_MYMENU1 = new HashSet<GBL_MYMENU>();
            GBL_SESSION = new HashSet<GBL_SESSION>();
            GBL_SUPPORT = new HashSet<GBL_SUPPORT>();
            GBL_USERGROUP = new HashSet<GBL_USERGROUP>();
            GBL_USERGROUPDTL = new HashSet<GBL_USERGROUPDTL>();
            RIS_EXAMDF = new HashSet<RIS_EXAMDF>();
            RIS_EXAMDF1 = new HashSet<RIS_EXAMDF>();
            INV_AUTHORIZATION = new HashSet<INV_AUTHORIZATION>();
            INV_AUTHORISER = new HashSet<INV_AUTHORISER>();
            INV_REQUISITION = new HashSet<INV_REQUISITION>();
            MG_BREASTMARKTEMPLATE = new HashSet<MG_BREASTMARKTEMPLATE>();
            MIS_BIOPSYRESULT = new HashSet<MIS_BIOPSYRESULT>();
            RIS_ORDER = new HashSet<RIS_ORDER>();
            RIS_CLINICALINDICATIONTYPEFAVORITES = new HashSet<RIS_CLINICALINDICATIONTYPEFAVORITES>();
            RIS_COMMENTSONPATIENT = new HashSet<RIS_COMMENTSONPATIENT>();
            RIS_COMMENTSONPATIENTDTL = new HashSet<RIS_COMMENTSONPATIENTDTL>();
            RIS_EXAMRESULT_FILTERRAD = new HashSet<RIS_EXAMRESULT_FILTERRAD>();
            RIS_EXAMRESULT = new HashSet<RIS_EXAMRESULT>();
            RIS_EXAMRESULT1 = new HashSet<RIS_EXAMRESULT>();
            RIS_EXAMRESULTACCESS = new HashSet<RIS_EXAMRESULTACCESS>();
            RIS_EXAMRESULTNOTE = new HashSet<RIS_EXAMRESULTNOTE>();
            RIS_EXAMRESULTRADS = new HashSet<RIS_EXAMRESULTRADS>();
            RIS_EXAMRESULTSTATREPORT = new HashSet<RIS_EXAMRESULTSTATREPORT>();
            RIS_EXAMTEMPLATESHARE = new HashSet<RIS_EXAMTEMPLATESHARE>();
            RIS_RISKINCIDENTUSERS = new HashSet<RIS_RISKINCIDENTUSERS>();
            RIS_MODALITYCONFIG = new HashSet<RIS_MODALITYCONFIG>();
            RIS_MODALITYCONFIG1 = new HashSet<RIS_MODALITYCONFIG>();
            RIS_RADSTUDYGROUP = new HashSet<RIS_RADSTUDYGROUP>();
            RIS_SCHEDULE_RESERVATION = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULE_RESERVATION1 = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULE_RESERVATION2 = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULE_RESERVATION3 = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULECONFIG = new HashSet<RIS_SCHEDULECONFIG>();
            RIS_SCHEDULECONFIG1 = new HashSet<RIS_SCHEDULECONFIG>();
            RIS_SCHEDULEDEFAULTDESTINATION = new HashSet<RIS_SCHEDULEDEFAULTDESTINATION>();
            RIS_SCHEDULEDEFAULTDESTINATION1 = new HashSet<RIS_SCHEDULEDEFAULTDESTINATION>();
            RIS_SCHEDULEDEFAULTDESTINATION2 = new HashSet<RIS_SCHEDULEDEFAULTDESTINATION>();
            RIS_SCHEDULEDEFAULTMODALITY = new HashSet<RIS_SCHEDULEDEFAULTMODALITY>();
            RIS_SCHEDULEDEFAULTMODALITY1 = new HashSet<RIS_SCHEDULEDEFAULTMODALITY>();
            RIS_SCHEDULE = new HashSet<RIS_SCHEDULE>();
            RIS_SCHEDULE1 = new HashSet<RIS_SCHEDULE>();
            RIS_SCHEDULE2 = new HashSet<RIS_SCHEDULE>();
            RIS_SCHEDULE3 = new HashSet<RIS_SCHEDULE>();
            RIS_SCHEDULEDTL = new HashSet<RIS_SCHEDULEDTL>();
            RIS_SCHEDULEDTL1 = new HashSet<RIS_SCHEDULEDTL>();
            RIS_SCHEDULEDTL2 = new HashSet<RIS_SCHEDULEDTL>();
            RIS_TECHWORKSDTL = new HashSet<RIS_TECHWORKSDTL>();
            SR_QUESTIONS = new HashSet<SR_QUESTIONS>();
            SR_QUESTIONS1 = new HashSet<SR_QUESTIONS>();
            SR_QUESTIONSANSWERS = new HashSet<SR_QUESTIONSANSWERS>();
            SR_QUESTIONSANSWERS1 = new HashSet<SR_QUESTIONSANSWERS>();
            SR_QUESTIONSANSWERSDTL = new HashSet<SR_QUESTIONSANSWERSDTL>();
            SR_QUESTIONSANSWERSDTL1 = new HashSet<SR_QUESTIONSANSWERSDTL>();
            SR_QUESTIONSANSWERSDTLCHILD = new HashSet<SR_QUESTIONSANSWERSDTLCHILD>();
            SR_QUESTIONSANSWERSDTLCHILD1 = new HashSet<SR_QUESTIONSANSWERSDTLCHILD>();
            SR_QUESTIONSDTL = new HashSet<SR_QUESTIONSDTL>();
            SR_QUESTIONSDTL1 = new HashSet<SR_QUESTIONSDTL>();
            SR_QUESTIONSDTLCHILD = new HashSet<SR_QUESTIONSDTLCHILD>();
            SR_QUESTIONSDTLCHILD1 = new HashSet<SR_QUESTIONSDTLCHILD>();
            SR_QUESTIONTYPE = new HashSet<SR_QUESTIONTYPE>();
            SR_QUESTIONTYPE1 = new HashSet<SR_QUESTIONTYPE>();
            SR_TEMPLATE = new HashSet<SR_TEMPLATE>();
            SR_TEMPLATE1 = new HashSet<SR_TEMPLATE>();
            SR_TEMPLATEANSWERSPART = new HashSet<SR_TEMPLATEANSWERSPART>();
            SR_TEMPLATEANSWERSPART1 = new HashSet<SR_TEMPLATEANSWERSPART>();
            SR_TEMPLATEPART = new HashSet<SR_TEMPLATEPART>();
            SR_TEMPLATEPART1 = new HashSet<SR_TEMPLATEPART>();
            SR_USERPREFERENCE = new HashSet<SR_USERPREFERENCE>();
            RIS_TECHNOTES = new HashSet<RIS_TECHNOTES>();
            RIS_CLINICALINDICATIONFAVORITES = new HashSet<RIS_CLINICALINDICATIONFAVORITES>();
            RIS_CLINICALINDICATIONLASTVISIT = new HashSet<RIS_CLINICALINDICATIONLASTVISIT>();
            RIS_EXAMFAVORITES = new HashSet<RIS_EXAMFAVORITES>();
            RIS_NURSESDATA = new HashSet<RIS_NURSESDATA>();
            RIS_PRGROUPDTL = new HashSet<RIS_PRGROUPDTL>();
        }

        [Key]
        public int EMP_ID { get; set; }

        [StringLength(50)]
        public string EMP_UID { get; set; }

        [StringLength(50)]
        public string USER_NAME { get; set; }

        [StringLength(300)]
        public string SECURITY_QUESTION { get; set; }

        [StringLength(300)]
        public string SECURITY_ANSWER { get; set; }

        [StringLength(40)]
        public string PWD { get; set; }

        public int? UNIT_ID { get; set; }

        public int? JOBTITLE_ID { get; set; }

        [StringLength(1)]
        public string JOB_TYPE { get; set; }

        [StringLength(1)]
        public string IS_RADIOLOGIST { get; set; }

        [StringLength(20)]
        public string SALUTATION { get; set; }

        [StringLength(50)]
        public string FNAME { get; set; }

        [StringLength(50)]
        public string MNAME { get; set; }

        [StringLength(50)]
        public string LNAME { get; set; }

        [StringLength(20)]
        public string TITLE_ENG { get; set; }

        [StringLength(50)]
        public string FNAME_ENG { get; set; }

        [StringLength(50)]
        public string MNAME_ENG { get; set; }

        [StringLength(50)]
        public string LNAME_ENG { get; set; }

        [StringLength(1)]
        public string GENDER { get; set; }

        [StringLength(100)]
        public string EMAIL_PERSONAL { get; set; }

        [StringLength(100)]
        public string EMAIL_OFFICIAL { get; set; }

        [StringLength(30)]
        public string PHONE_HOME { get; set; }

        [StringLength(30)]
        public string PHONE_MOBILE { get; set; }

        [StringLength(30)]
        public string PHONE_OFFICE { get; set; }

        [StringLength(1)]
        public string PREFERRED_PHONE { get; set; }

        public int? PABX_EXT { get; set; }

        [StringLength(25)]
        public string FAX_NO { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(3)]
        public string BLOOD_GROUP { get; set; }

        public int? DEFAULT_LANG { get; set; }

        public int? RELIGION { get; set; }

        [StringLength(100)]
        public string PE_ADDR1 { get; set; }

        [StringLength(100)]
        public string PE_ADDR2 { get; set; }

        [StringLength(100)]
        public string PE_ADDR3 { get; set; }

        [StringLength(100)]
        public string PE_ADDR4 { get; set; }

        public int? AUTH_LEVEL_ID { get; set; }

        public int? REPORTING_TO { get; set; }

        [StringLength(1)]
        public string ALLOW_OTHERS_TO_FINALIZE { get; set; }

        public DateTime? LAST_PWD_MODIFIED { get; set; }

        public DateTime? LAST_LOGIN { get; set; }

        [StringLength(50)]
        public string CARD_NO { get; set; }

        [StringLength(10)]
        public string PLACE_OF_BIRTH { get; set; }

        [StringLength(50)]
        public string NATIONALITY { get; set; }

        [StringLength(1)]
        public string M_STATUS { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(1)]
        public string SUPPORT_USER { get; set; }

        [StringLength(1)]
        public string CAN_KILL_SESSION { get; set; }

        public int? DEFAULT_SHIFT_NO { get; set; }

        [StringLength(100)]
        public string IMG_FILE_NAME { get; set; }

        [StringLength(100)]
        public string EMP_REPORT_FOOTER1 { get; set; }

        [StringLength(100)]
        public string EMP_REPORT_FOOTER2 { get; set; }

        [MaxLength(256)]
        public byte[] ALLPROPERTIES { get; set; }

        public bool? VISIBLE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_RESIDENT { get; set; }

        [StringLength(1)]
        public string CAN_EXCEED_SCHEDULE { get; set; }

        [StringLength(1)]
        public string IS_FELLOW { get; set; }

        [StringLength(1)]
        public string IS_NURSE { get; set; }

        [StringLength(1)]
        public string IS_TECHNOLOGIST { get; set; }

        [StringLength(100)]
        public string ALIAS_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_ASSIGNMENT> AC_ASSIGNMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_ENROLLMENT> AC_ENROLLMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_EVALUATION> AC_EVALUATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_EVALUATIONLOGIC> AC_EVALUATIONLOGIC { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GRANTOBJECT> GBL_GRANTOBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GRANTROLE> GBL_GRANTROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GROUP> GBL_GROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GROUPDTL> GBL_GROUPDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_MYMENU> GBL_MYMENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_MYMENU> GBL_MYMENU1 { get; set; }

        public virtual GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SESSION> GBL_SESSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUPPORT> GBL_SUPPORT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_USERGROUP> GBL_USERGROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_USERGROUPDTL> GBL_USERGROUPDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMDF> RIS_EXAMDF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMDF> RIS_EXAMDF1 { get; set; }

        public virtual RIS_AUTHLEVEL RIS_AUTHLEVEL { get; set; }

        public virtual HR_JOBTITLE HR_JOBTITLE { get; set; }

        public virtual RIS_AUTHLEVEL RIS_AUTHLEVEL1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_AUTHORIZATION> INV_AUTHORIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_AUTHORISER> INV_AUTHORISER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_REQUISITION> INV_REQUISITION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_BREASTMARKTEMPLATE> MG_BREASTMARKTEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIS_BIOPSYRESULT> MIS_BIOPSYRESULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDER> RIS_ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONTYPEFAVORITES> RIS_CLINICALINDICATIONTYPEFAVORITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENT> RIS_COMMENTSONPATIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENTDTL> RIS_COMMENTSONPATIENTDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULT_FILTERRAD> RIS_EXAMRESULT_FILTERRAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULT> RIS_EXAMRESULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULT> RIS_EXAMRESULT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTACCESS> RIS_EXAMRESULTACCESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTNOTE> RIS_EXAMRESULTNOTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTRADS> RIS_EXAMRESULTRADS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTSTATREPORT> RIS_EXAMRESULTSTATREPORT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMTEMPLATESHARE> RIS_EXAMTEMPLATESHARE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RISKINCIDENTUSERS> RIS_RISKINCIDENTUSERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYCONFIG> RIS_MODALITYCONFIG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYCONFIG> RIS_MODALITYCONFIG1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RADSTUDYGROUP> RIS_RADSTUDYGROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULECONFIG> RIS_SCHEDULECONFIG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULECONFIG> RIS_SCHEDULECONFIG1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTDESTINATION> RIS_SCHEDULEDEFAULTDESTINATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTDESTINATION> RIS_SCHEDULEDEFAULTDESTINATION1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTDESTINATION> RIS_SCHEDULEDEFAULTDESTINATION2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTMODALITY> RIS_SCHEDULEDEFAULTMODALITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDEFAULTMODALITY> RIS_SCHEDULEDEFAULTMODALITY1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_TECHWORKSDTL> RIS_TECHWORKSDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONS> SR_QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONS> SR_QUESTIONS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERS> SR_QUESTIONSANSWERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERS> SR_QUESTIONSANSWERS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERSDTL> SR_QUESTIONSANSWERSDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERSDTL> SR_QUESTIONSANSWERSDTL1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERSDTLCHILD> SR_QUESTIONSANSWERSDTLCHILD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSANSWERSDTLCHILD> SR_QUESTIONSANSWERSDTLCHILD1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTL> SR_QUESTIONSDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTL> SR_QUESTIONSDTL1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTLCHILD> SR_QUESTIONSDTLCHILD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONSDTLCHILD> SR_QUESTIONSDTLCHILD1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONTYPE> SR_QUESTIONTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_QUESTIONTYPE> SR_QUESTIONTYPE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATE> SR_TEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATE> SR_TEMPLATE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEANSWERSPART> SR_TEMPLATEANSWERSPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEANSWERSPART> SR_TEMPLATEANSWERSPART1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEPART> SR_TEMPLATEPART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATEPART> SR_TEMPLATEPART1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_USERPREFERENCE> SR_USERPREFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_TECHNOTES> RIS_TECHNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONFAVORITES> RIS_CLINICALINDICATIONFAVORITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATIONLASTVISIT> RIS_CLINICALINDICATIONLASTVISIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMFAVORITES> RIS_EXAMFAVORITES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_NURSESDATA> RIS_NURSESDATA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRGROUPDTL> RIS_PRGROUPDTL { get; set; }
    }
}
