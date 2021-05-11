namespace Envision.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnvisionDataModel : DbContext
    {
        public EnvisionDataModel()
            : base("name=EnvisionDataModel")
        {
            
        }

        public virtual DbSet<AC_ASSIGNMENT> AC_ASSIGNMENT { get; set; }
        public virtual DbSet<AC_CLASS> AC_CLASS { get; set; }
        public virtual DbSet<AC_ENROLLMENT> AC_ENROLLMENT { get; set; }
        public virtual DbSet<AC_EVALUATION> AC_EVALUATION { get; set; }
        public virtual DbSet<AC_EVALUATIONLOGIC> AC_EVALUATIONLOGIC { get; set; }
        public virtual DbSet<AC_FINALIZEPRIVILEGE> AC_FINALIZEPRIVILEGE { get; set; }
        public virtual DbSet<AC_GRADE> AC_GRADE { get; set; }
        public virtual DbSet<AC_REPORTINGLANGUAGE> AC_REPORTINGLANGUAGE { get; set; }
        public virtual DbSet<AC_YEAR> AC_YEAR { get; set; }
        public virtual DbSet<FIN_INVOICE> FIN_INVOICE { get; set; }
        public virtual DbSet<FIN_INVOICEDTL> FIN_INVOICEDTL { get; set; }
        public virtual DbSet<FIN_PAYMENT> FIN_PAYMENT { get; set; }
        public virtual DbSet<FIN_PAYMENTDTL> FIN_PAYMENTDTL { get; set; }
        public virtual DbSet<GBL_ALERT> GBL_ALERT { get; set; }
        public virtual DbSet<GBL_ALERTDTL> GBL_ALERTDTL { get; set; }
        public virtual DbSet<GBL_BIREPORTS> GBL_BIREPORTS { get; set; }
        public virtual DbSet<GBL_BISETTINGS> GBL_BISETTINGS { get; set; }
        public virtual DbSet<GBL_EMPSCHEDULE> GBL_EMPSCHEDULE { get; set; }
        public virtual DbSet<GBL_EMPSCHEDULECATEGORY> GBL_EMPSCHEDULECATEGORY { get; set; }
        public virtual DbSet<GBL_ENV> GBL_ENV { get; set; }
        public virtual DbSet<GBL_ERRORLOGS> GBL_ERRORLOGS { get; set; }
        public virtual DbSet<GBL_EXCEPTIONLOG> GBL_EXCEPTIONLOG { get; set; }
        public virtual DbSet<GBL_GENERAL> GBL_GENERAL { get; set; }
        public virtual DbSet<GBL_GENERALDTL> GBL_GENERALDTL { get; set; }
        public virtual DbSet<GBL_GRANTOBJECT> GBL_GRANTOBJECT { get; set; }
        public virtual DbSet<GBL_GRANTROLE> GBL_GRANTROLE { get; set; }
        public virtual DbSet<GBL_GROUP> GBL_GROUP { get; set; }
        public virtual DbSet<GBL_GROUPDTL> GBL_GROUPDTL { get; set; }
        public virtual DbSet<GBL_HOSPITAL> GBL_HOSPITAL { get; set; }
        public virtual DbSet<GBL_LANGUAGE> GBL_LANGUAGE { get; set; }
        public virtual DbSet<GBL_MENU> GBL_MENU { get; set; }
        public virtual DbSet<GBL_MESSAGE> GBL_MESSAGE { get; set; }
        public virtual DbSet<GBL_MESSAGERECIPIENT> GBL_MESSAGERECIPIENT { get; set; }
        public virtual DbSet<GBL_MYMENU> GBL_MYMENU { get; set; }
        public virtual DbSet<GBL_NOTIFICATION> GBL_NOTIFICATION { get; set; }
        public virtual DbSet<GBL_PRODUCT> GBL_PRODUCT { get; set; }
        public virtual DbSet<GBL_QUICKTEXT> GBL_QUICKTEXT { get; set; }
        public virtual DbSet<GBL_RADEXPERIENCE> GBL_RADEXPERIENCE { get; set; }
        public virtual DbSet<GBL_ROLE> GBL_ROLE { get; set; }
        public virtual DbSet<GBL_ROLEDTL> GBL_ROLEDTL { get; set; }
        public virtual DbSet<GBL_SEQUENCES> GBL_SEQUENCES { get; set; }
        public virtual DbSet<GBL_SESSION> GBL_SESSION { get; set; }
        public virtual DbSet<GBL_SESSIONLOG> GBL_SESSIONLOG { get; set; }
        public virtual DbSet<GBL_SUBMENU> GBL_SUBMENU { get; set; }
        public virtual DbSet<GBL_SUBMENUOBJECTLABEL> GBL_SUBMENUOBJECTLABEL { get; set; }
        public virtual DbSet<GBL_SUBMENUOBJECTS> GBL_SUBMENUOBJECTS { get; set; }
        public virtual DbSet<GBL_SUPPORT> GBL_SUPPORT { get; set; }
        public virtual DbSet<GBL_USERGROUP> GBL_USERGROUP { get; set; }
        public virtual DbSet<GBL_USERGROUPDTL> GBL_USERGROUPDTL { get; set; }
        public virtual DbSet<HIS_ACR> HIS_ACR { get; set; }
        public virtual DbSet<HIS_CPT> HIS_CPT { get; set; }
        public virtual DbSet<HIS_ICD> HIS_ICD { get; set; }
        public virtual DbSet<HIS_REGISTRATION> HIS_REGISTRATION { get; set; }
        public virtual DbSet<HR_EMP> HR_EMP { get; set; }
        public virtual DbSet<HR_EMPTITLE> HR_EMPTITLE { get; set; }
        public virtual DbSet<HR_JOBTITLE> HR_JOBTITLE { get; set; }
        public virtual DbSet<HR_OCCUPATION> HR_OCCUPATION { get; set; }
        public virtual DbSet<HR_ROOM> HR_ROOM { get; set; }
        public virtual DbSet<HR_UNIT> HR_UNIT { get; set; }
        public virtual DbSet<INV_AUTHORISER> INV_AUTHORISER { get; set; }
        public virtual DbSet<INV_AUTHORIZATION> INV_AUTHORIZATION { get; set; }
        public virtual DbSet<INV_CATEGORY> INV_CATEGORY { get; set; }
        public virtual DbSet<INV_ITEM> INV_ITEM { get; set; }
        public virtual DbSet<INV_ITEMSTATUS> INV_ITEMSTATUS { get; set; }
        public virtual DbSet<INV_ITEMSTOCK> INV_ITEMSTOCK { get; set; }
        public virtual DbSet<INV_ITEMTYPE> INV_ITEMTYPE { get; set; }
        public virtual DbSet<INV_PO> INV_PO { get; set; }
        public virtual DbSet<INV_PODTL> INV_PODTL { get; set; }
        public virtual DbSet<INV_PR> INV_PR { get; set; }
        public virtual DbSet<INV_PRDTL> INV_PRDTL { get; set; }
        public virtual DbSet<INV_REQUISITION> INV_REQUISITION { get; set; }
        public virtual DbSet<INV_REQUISITIONDTL> INV_REQUISITIONDTL { get; set; }
        public virtual DbSet<INV_ROOMSTOCKREDUCE> INV_ROOMSTOCKREDUCE { get; set; }
        public virtual DbSet<INV_SETTINGS> INV_SETTINGS { get; set; }
        public virtual DbSet<INV_TRANSACTION> INV_TRANSACTION { get; set; }
        public virtual DbSet<INV_TRANSACTIONDTL> INV_TRANSACTIONDTL { get; set; }
        public virtual DbSet<INV_TRANSACTIONTYPE> INV_TRANSACTIONTYPE { get; set; }
        public virtual DbSet<INV_TXNUNIT> INV_TXNUNIT { get; set; }
        public virtual DbSet<INV_UNIT> INV_UNIT { get; set; }
        public virtual DbSet<INV_UNITREORDERLEVEL> INV_UNITREORDERLEVEL { get; set; }
        public virtual DbSet<INV_VENDOR> INV_VENDOR { get; set; }
        public virtual DbSet<MG_BREASTEXAMRESULT> MG_BREASTEXAMRESULT { get; set; }
        public virtual DbSet<MG_BREASTMARK> MG_BREASTMARK { get; set; }
        public virtual DbSet<MG_BREASTMARKDTL> MG_BREASTMARKDTL { get; set; }
        public virtual DbSet<MG_BREASTMARKTEMPLATE> MG_BREASTMARKTEMPLATE { get; set; }
        public virtual DbSet<MG_BREASTMASSDETAILS> MG_BREASTMASSDETAILS { get; set; }
        public virtual DbSet<MG_DOMINANT> MG_DOMINANT { get; set; }
        public virtual DbSet<MG_MADOMINANT> MG_MADOMINANT { get; set; }
        public virtual DbSet<MG_MARKSHAPE> MG_MARKSHAPE { get; set; }
        public virtual DbSet<MG_MARKSTYLE> MG_MARKSTYLE { get; set; }
        public virtual DbSet<MG_MASSDOMINANTCYST> MG_MASSDOMINANTCYST { get; set; }
        public virtual DbSet<MG_PATIENTHISTORYCOMPARISON> MG_PATIENTHISTORYCOMPARISON { get; set; }
        public virtual DbSet<MIS_ASESSMENTTYPE> MIS_ASESSMENTTYPE { get; set; }
        public virtual DbSet<MIS_BIOPSYRESULT> MIS_BIOPSYRESULT { get; set; }
        public virtual DbSet<MIS_LESIONTYPE> MIS_LESIONTYPE { get; set; }
        public virtual DbSet<MIS_TECHNIQUETYPE> MIS_TECHNIQUETYPE { get; set; }
        public virtual DbSet<OLAP_ORDER> OLAP_ORDER { get; set; }
        public virtual DbSet<OLAP_ORDER_DELETED> OLAP_ORDER_DELETED { get; set; }
        public virtual DbSet<OLAP_ORDER_TEMP> OLAP_ORDER_TEMP { get; set; }
        public virtual DbSet<ONL_FILTERDESTINATION> ONL_FILTERDESTINATION { get; set; }
        public virtual DbSet<ONL_HISLINKLOG> ONL_HISLINKLOG { get; set; }
        public virtual DbSet<ONL_SEARCHMATCH> ONL_SEARCHMATCH { get; set; }
        public virtual DbSet<RIS_ASSESSMENT> RIS_ASSESSMENT { get; set; }
        public virtual DbSet<RIS_AUTHLEVEL> RIS_AUTHLEVEL { get; set; }
        public virtual DbSet<RIS_AUTOMERGECONFIG> RIS_AUTOMERGECONFIG { get; set; }
        public virtual DbSet<RIS_BILLINGLOG> RIS_BILLINGLOG { get; set; }
        public virtual DbSet<RIS_BILLINGTRANSACTIONLOG> RIS_BILLINGTRANSACTIONLOG { get; set; }
        public virtual DbSet<RIS_BILLINGTRANSACTIONLOGDTL> RIS_BILLINGTRANSACTIONLOGDTL { get; set; }
        public virtual DbSet<RIS_BODYPART> RIS_BODYPART { get; set; }
        public virtual DbSet<RIS_BPVIEW> RIS_BPVIEW { get; set; }
        public virtual DbSet<RIS_BPVIEWMAPPING> RIS_BPVIEWMAPPING { get; set; }
        public virtual DbSet<RIS_CLINICALINDICATION> RIS_CLINICALINDICATION { get; set; }
        public virtual DbSet<RIS_CLINICALINDICATION_WITH_UNIT> RIS_CLINICALINDICATION_WITH_UNIT { get; set; }
        public virtual DbSet<RIS_CLINICALINDICATIONCHECKUPLIST> RIS_CLINICALINDICATIONCHECKUPLIST { get; set; }
        public virtual DbSet<RIS_CLINICALINDICATIONFAVORITES> RIS_CLINICALINDICATIONFAVORITES { get; set; }
        public virtual DbSet<RIS_CLINICALINDICATIONLASTVISIT> RIS_CLINICALINDICATIONLASTVISIT { get; set; }
        public virtual DbSet<RIS_CLINICALINDICATIONTYPE> RIS_CLINICALINDICATIONTYPE { get; set; }
        public virtual DbSet<RIS_CLINICALINDICATIONTYPEFAVORITES> RIS_CLINICALINDICATIONTYPEFAVORITES { get; set; }
        public virtual DbSet<RIS_CLINICSESSION> RIS_CLINICSESSION { get; set; }
        public virtual DbSet<RIS_CLINICSESSIONONLINE> RIS_CLINICSESSIONONLINE { get; set; }
        public virtual DbSet<RIS_CLINICTYPE> RIS_CLINICTYPE { get; set; }
        public virtual DbSet<RIS_COMMENTSONPATIENT> RIS_COMMENTSONPATIENT { get; set; }
        public virtual DbSet<RIS_COMMENTSONPATIENTDTL> RIS_COMMENTSONPATIENTDTL { get; set; }
        public virtual DbSet<RIS_COMMENTSYSTEM> RIS_COMMENTSYSTEM { get; set; }
        public virtual DbSet<RIS_COMMENTSYSTEM_GROUP> RIS_COMMENTSYSTEM_GROUP { get; set; }
        public virtual DbSet<RIS_COMMENTSYSTEM_GROUPDTL> RIS_COMMENTSYSTEM_GROUPDTL { get; set; }
        public virtual DbSet<RIS_COMMENTSYSTEMALERT> RIS_COMMENTSYSTEMALERT { get; set; }
        public virtual DbSet<RIS_COMMENTSYSTEMDTL> RIS_COMMENTSYSTEMDTL { get; set; }
        public virtual DbSet<RIS_CONFLICTEXAMDTL> RIS_CONFLICTEXAMDTL { get; set; }
        public virtual DbSet<RIS_CONFLICTEXAMGROUP> RIS_CONFLICTEXAMGROUP { get; set; }
        public virtual DbSet<RIS_CONSUMABLETYPE> RIS_CONSUMABLETYPE { get; set; }
        public virtual DbSet<RIS_ENVISIONONLINEPARAMETERSLOG> RIS_ENVISIONONLINEPARAMETERSLOG { get; set; }
        public virtual DbSet<RIS_EXAM> RIS_EXAM { get; set; }
        public virtual DbSet<RIS_EXAMDF> RIS_EXAMDF { get; set; }
        public virtual DbSet<RIS_EXAMFAVORITES> RIS_EXAMFAVORITES { get; set; }
        public virtual DbSet<RIS_EXAMINSTRUCTIONCLINICSESSION> RIS_EXAMINSTRUCTIONCLINICSESSION { get; set; }
        public virtual DbSet<RIS_EXAMINSTRUCTIONS> RIS_EXAMINSTRUCTIONS { get; set; }
        public virtual DbSet<RIS_EXAMPANEL> RIS_EXAMPANEL { get; set; }
        public virtual DbSet<RIS_EXAMPANELPORTABLE> RIS_EXAMPANELPORTABLE { get; set; }
        public virtual DbSet<RIS_EXAMRESULT> RIS_EXAMRESULT { get; set; }
        public virtual DbSet<RIS_EXAMRESULT_FILTERRAD> RIS_EXAMRESULT_FILTERRAD { get; set; }
        public virtual DbSet<RIS_EXAMRESULT_FILTERWORKLIST> RIS_EXAMRESULT_FILTERWORKLIST { get; set; }
        public virtual DbSet<RIS_EXAMRESULTACCESS> RIS_EXAMRESULTACCESS { get; set; }
        public virtual DbSet<RIS_EXAMRESULTAUTOSAVE> RIS_EXAMRESULTAUTOSAVE { get; set; }
        public virtual DbSet<RIS_EXAMRESULTCONSULT> RIS_EXAMRESULTCONSULT { get; set; }
        public virtual DbSet<RIS_EXAMRESULTKEYIMAGES> RIS_EXAMRESULTKEYIMAGES { get; set; }
        public virtual DbSet<RIS_EXAMRESULTLEGACY> RIS_EXAMRESULTLEGACY { get; set; }
        public virtual DbSet<RIS_EXAMRESULTLOCKS> RIS_EXAMRESULTLOCKS { get; set; }
        public virtual DbSet<RIS_EXAMRESULTNOTE> RIS_EXAMRESULTNOTE { get; set; }
        public virtual DbSet<RIS_EXAMRESULTRADS> RIS_EXAMRESULTRADS { get; set; }
        public virtual DbSet<RIS_EXAMRESULTSEVERITY> RIS_EXAMRESULTSEVERITY { get; set; }
        public virtual DbSet<RIS_EXAMRESULTSEVERITY_LOG> RIS_EXAMRESULTSEVERITY_LOG { get; set; }
        public virtual DbSet<RIS_EXAMRESULTSTATREPORT> RIS_EXAMRESULTSTATREPORT { get; set; }
        public virtual DbSet<RIS_EXAMRESULTTEMPLATE> RIS_EXAMRESULTTEMPLATE { get; set; }
        public virtual DbSet<RIS_EXAMRESULTTIME> RIS_EXAMRESULTTIME { get; set; }
        public virtual DbSet<RIS_EXAMRVU> RIS_EXAMRVU { get; set; }
        public virtual DbSet<RIS_EXAMSKILL> RIS_EXAMSKILL { get; set; }
        public virtual DbSet<RIS_EXAMSKILLMAPPING> RIS_EXAMSKILLMAPPING { get; set; }
        public virtual DbSet<RIS_EXAMSKILLTYPE> RIS_EXAMSKILLTYPE { get; set; }
        public virtual DbSet<RIS_EXAMTEMPLATESHARE> RIS_EXAMTEMPLATESHARE { get; set; }
        public virtual DbSet<RIS_EXAMTRANSFERLOG> RIS_EXAMTRANSFERLOG { get; set; }
        public virtual DbSet<RIS_EXAMTYPE> RIS_EXAMTYPE { get; set; }
        public virtual DbSet<RIS_EXTERNALHL7TRANSLOG> RIS_EXTERNALHL7TRANSLOG { get; set; }
        public virtual DbSet<RIS_HL7IELOG> RIS_HL7IELOG { get; set; }
        public virtual DbSet<RIS_HL7TRANSACTIONLOG> RIS_HL7TRANSACTIONLOG { get; set; }
        public virtual DbSet<RIS_HOSPITAL_MAP_DOCTOR> RIS_HOSPITAL_MAP_DOCTOR { get; set; }
        public virtual DbSet<RIS_INSURANCETYPE> RIS_INSURANCETYPE { get; set; }
        public virtual DbSet<RIS_INTEGRATIONCONFIG> RIS_INTEGRATIONCONFIG { get; set; }
        public virtual DbSet<RIS_INTEGRATIONSERVERS> RIS_INTEGRATIONSERVERS { get; set; }
        public virtual DbSet<RIS_LOADMEDIA> RIS_LOADMEDIA { get; set; }
        public virtual DbSet<RIS_LOADMEDIADTL> RIS_LOADMEDIADTL { get; set; }
        public virtual DbSet<RIS_LOCATIONMAPPING> RIS_LOCATIONMAPPING { get; set; }
        public virtual DbSet<RIS_MERGELOG> RIS_MERGELOG { get; set; }
        public virtual DbSet<RIS_MESSAGE> RIS_MESSAGE { get; set; }
        public virtual DbSet<RIS_MESSAGEDTL> RIS_MESSAGEDTL { get; set; }
        public virtual DbSet<RIS_MODALITY> RIS_MODALITY { get; set; }
        public virtual DbSet<RIS_MODALITYAETITLE> RIS_MODALITYAETITLE { get; set; }
        public virtual DbSet<RIS_MODALITYCLINICTYPE> RIS_MODALITYCLINICTYPE { get; set; }
        public virtual DbSet<RIS_MODALITYCONFIG> RIS_MODALITYCONFIG { get; set; }
        public virtual DbSet<RIS_MODALITYEXAM> RIS_MODALITYEXAM { get; set; }
        public virtual DbSet<RIS_MODALITYEXAM_ONL> RIS_MODALITYEXAM_ONL { get; set; }
        public virtual DbSet<RIS_MODALITYLOG> RIS_MODALITYLOG { get; set; }
        public virtual DbSet<RIS_MODALITYLOGCAPTURE> RIS_MODALITYLOGCAPTURE { get; set; }
        public virtual DbSet<RIS_MODALITYTYPE> RIS_MODALITYTYPE { get; set; }
        public virtual DbSet<RIS_MODALITYUNIT> RIS_MODALITYUNIT { get; set; }
        public virtual DbSet<RIS_NURSESDATA> RIS_NURSESDATA { get; set; }
        public virtual DbSet<RIS_NURSESDATADTL> RIS_NURSESDATADTL { get; set; }
        public virtual DbSet<RIS_OPNOTEITEM> RIS_OPNOTEITEM { get; set; }
        public virtual DbSet<RIS_OPNOTEITEMTEMPLATE> RIS_OPNOTEITEMTEMPLATE { get; set; }
        public virtual DbSet<RIS_ORDER> RIS_ORDER { get; set; }
        public virtual DbSet<RIS_ORDERCLINICALINDICATION> RIS_ORDERCLINICALINDICATION { get; set; }
        public virtual DbSet<RIS_ORDERCLINICALINDICATIONTYPE> RIS_ORDERCLINICALINDICATIONTYPE { get; set; }
        public virtual DbSet<RIS_ORDERCPT> RIS_ORDERCPT { get; set; }
        public virtual DbSet<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }
        public virtual DbSet<RIS_ORDEREXAMFLAG> RIS_ORDEREXAMFLAG { get; set; }
        public virtual DbSet<RIS_ORDERICD> RIS_ORDERICD { get; set; }
        public virtual DbSet<RIS_ORDERIMAGES> RIS_ORDERIMAGES { get; set; }
        public virtual DbSet<RIS_PATICD> RIS_PATICD { get; set; }
        public virtual DbSet<RIS_PATIENTDESTINATION> RIS_PATIENTDESTINATION { get; set; }
        public virtual DbSet<RIS_PATIENTPREPARATION> RIS_PATIENTPREPARATION { get; set; }
        public virtual DbSet<RIS_PATSTATUS> RIS_PATSTATUS { get; set; }
        public virtual DbSet<RIS_PRALGORITHM> RIS_PRALGORITHM { get; set; }
        public virtual DbSet<RIS_PRGRADE> RIS_PRGRADE { get; set; }
        public virtual DbSet<RIS_PRGROUP> RIS_PRGROUP { get; set; }
        public virtual DbSet<RIS_PRGROUPDTL> RIS_PRGROUPDTL { get; set; }
        public virtual DbSet<RIS_PRREPORTINGLANGUAGE> RIS_PRREPORTINGLANGUAGE { get; set; }
        public virtual DbSet<RIS_PRSTUDIES> RIS_PRSTUDIES { get; set; }
        public virtual DbSet<RIS_QAREASON> RIS_QAREASON { get; set; }
        public virtual DbSet<RIS_QAWORKS> RIS_QAWORKS { get; set; }
        public virtual DbSet<RIS_QUESTIONS> RIS_QUESTIONS { get; set; }
        public virtual DbSet<RIS_RADSTUDYGROUP> RIS_RADSTUDYGROUP { get; set; }
        public virtual DbSet<RIS_RELEASEMEDIA> RIS_RELEASEMEDIA { get; set; }
        public virtual DbSet<RIS_RESULTSTATUSCHANGELOG> RIS_RESULTSTATUSCHANGELOG { get; set; }
        public virtual DbSet<RIS_RISKCATEGORIES> RIS_RISKCATEGORIES { get; set; }
        public virtual DbSet<RIS_RISKINCIDENTS> RIS_RISKINCIDENTS { get; set; }
        public virtual DbSet<RIS_RISKINCIDENTSLOGS> RIS_RISKINCIDENTSLOGS { get; set; }
        public virtual DbSet<RIS_RISKINCIDENTUSERS> RIS_RISKINCIDENTUSERS { get; set; }
        public virtual DbSet<RIS_SCHEDULE> RIS_SCHEDULE { get; set; }
        public virtual DbSet<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION { get; set; }
        public virtual DbSet<RIS_SCHEDULECONFIG> RIS_SCHEDULECONFIG { get; set; }
        public virtual DbSet<RIS_SCHEDULEDEFAULTDESTINATION> RIS_SCHEDULEDEFAULTDESTINATION { get; set; }
        public virtual DbSet<RIS_SCHEDULEDEFAULTMODALITY> RIS_SCHEDULEDEFAULTMODALITY { get; set; }
        public virtual DbSet<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL { get; set; }
        public virtual DbSet<RIS_SEARCH> RIS_SEARCH { get; set; }
        public virtual DbSet<RIS_SEARCH_DTL> RIS_SEARCH_DTL { get; set; }
        public virtual DbSet<RIS_SERVICETYPE> RIS_SERVICETYPE { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARY> RIS_STUDYLIBRARY { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARYACR> RIS_STUDYLIBRARYACR { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARYBODYPART> RIS_STUDYLIBRARYBODYPART { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARYCONFERENCE> RIS_STUDYLIBRARYCONFERENCE { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARYCPT> RIS_STUDYLIBRARYCPT { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARYICD> RIS_STUDYLIBRARYICD { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARYSHAREWITH> RIS_STUDYLIBRARYSHAREWITH { get; set; }
        public virtual DbSet<RIS_STUDYLIBRARYTAGS> RIS_STUDYLIBRARYTAGS { get; set; }
        public virtual DbSet<RIS_TECHCONSUMPTION> RIS_TECHCONSUMPTION { get; set; }
        public virtual DbSet<RIS_TECHNOTES> RIS_TECHNOTES { get; set; }
        public virtual DbSet<RIS_TECHWORKS> RIS_TECHWORKS { get; set; }
        public virtual DbSet<RIS_TECHWORKSDTL> RIS_TECHWORKSDTL { get; set; }
        public virtual DbSet<RIS_TIME> RIS_TIME { get; set; }
        public virtual DbSet<RIS_TIMELEVEL> RIS_TIMELEVEL { get; set; }
        public virtual DbSet<RIS_USERORGMAP> RIS_USERORGMAP { get; set; }
        public virtual DbSet<SR_QUESTIONS> SR_QUESTIONS { get; set; }
        public virtual DbSet<SR_QUESTIONSANSWERS> SR_QUESTIONSANSWERS { get; set; }
        public virtual DbSet<SR_QUESTIONSANSWERSDTL> SR_QUESTIONSANSWERSDTL { get; set; }
        public virtual DbSet<SR_QUESTIONSANSWERSDTLCHILD> SR_QUESTIONSANSWERSDTLCHILD { get; set; }
        public virtual DbSet<SR_QUESTIONSDTL> SR_QUESTIONSDTL { get; set; }
        public virtual DbSet<SR_QUESTIONSDTLCHILD> SR_QUESTIONSDTLCHILD { get; set; }
        public virtual DbSet<SR_QUESTIONTYPE> SR_QUESTIONTYPE { get; set; }
        public virtual DbSet<SR_TEMPLATE> SR_TEMPLATE { get; set; }
        public virtual DbSet<SR_TEMPLATEANSWERSPART> SR_TEMPLATEANSWERSPART { get; set; }
        public virtual DbSet<SR_TEMPLATEPART> SR_TEMPLATEPART { get; set; }
        public virtual DbSet<SR_USERPREFERENCE> SR_USERPREFERENCE { get; set; }
        public virtual DbSet<MG_BREASTUSMASSDETAILS> MG_BREASTUSMASSDETAILS { get; set; }
        public virtual DbSet<RIS_BILLINGTRANSACTIONLOG_AUDIT> RIS_BILLINGTRANSACTIONLOG_AUDIT { get; set; }
        public virtual DbSet<RIS_SCHEDULE_LOG> RIS_SCHEDULE_LOG { get; set; }
        public virtual DbSet<RIS_SEARCH_AUDIT> RIS_SEARCH_AUDIT { get; set; }
        public virtual DbSet<RIS_SESSIONAPPCOUNT> RIS_SESSIONAPPCOUNT { get; set; }
        public virtual DbSet<RIS_SESSIONMAXAPP> RIS_SESSIONMAXAPP { get; set; }

        public virtual DbSet<RIS_PRASSIGNMENT> RIS_PRASSIGNMENT { get; set; }
        public virtual DbSet<RIS_PREXAMMAPPING> RIS_PREXAMMAPPING { get; set; }
        public virtual DbSet<RIS_PRRADMAPPING> RIS_PRRADMAPPING { get; set; }
        public virtual DbSet<RIS_PRREPORTING> RIS_PRREPORTING { get; set; }
        public virtual DbSet<RIS_PRREVIEW> RIS_PRREVIEW { get; set; }
        public virtual DbSet<RIS_PRSUBSPECIALTY> RIS_PRSUBSPECIALTY { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AC_REPORTINGLANGUAGE>()
                .HasMany(e => e.AC_EVALUATION)
                .WithOptional(e => e.AC_REPORTINGLANGUAGE)
                .HasForeignKey(e => e.LANGUAGE_OF_REPORT);

            modelBuilder.Entity<FIN_INVOICEDTL>()
                .Property(e => e.RATE)
                .HasPrecision(11, 2);

            modelBuilder.Entity<FIN_INVOICEDTL>()
                .Property(e => e.DISCOUNT)
                .HasPrecision(11, 2);

            modelBuilder.Entity<FIN_INVOICEDTL>()
                .Property(e => e.PAYABLE)
                .HasPrecision(11, 2);

            modelBuilder.Entity<FIN_PAYMENTDTL>()
                .Property(e => e.RATE)
                .HasPrecision(11, 2);

            modelBuilder.Entity<FIN_PAYMENTDTL>()
                .Property(e => e.DISCOUNT)
                .HasPrecision(11, 2);

            modelBuilder.Entity<FIN_PAYMENTDTL>()
                .Property(e => e.PAYABLE)
                .HasPrecision(11, 2);

            modelBuilder.Entity<FIN_PAYMENTDTL>()
                .Property(e => e.PAID)
                .HasPrecision(11, 2);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.GBL_MYMENU)
                .WithOptional(e => e.GBL_ENV)
                .HasForeignKey(e => e.ORG_ID);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.GBL_MYMENU1)
                .WithOptional(e => e.GBL_ENV1)
                .HasForeignKey(e => e.ORG_ID);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.GBL_MYMENU2)
                .WithOptional(e => e.GBL_ENV2)
                .HasForeignKey(e => e.ORG_ID);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_CLINICALINDICATIONTYPEFAVORITES)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_PATSTATUS)
                .WithOptional(e => e.GBL_ENV)
                .HasForeignKey(e => e.ORG_ID);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_PATSTATUS1)
                .WithOptional(e => e.GBL_ENV1)
                .HasForeignKey(e => e.ORG_ID);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTDESTINATION)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_SESSIONAPPCOUNT)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_SESSIONMAXAPP)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_CLINICALINDICATION)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_CLINICALINDICATION_WITH_UNIT)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_CLINICALINDICATIONFAVORITES)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_CLINICALINDICATIONLASTVISIT)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ENV>()
                .HasMany(e => e.RIS_PATIENTDESTINATION)
                .WithRequired(e => e.GBL_ENV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_LANGUAGE>()
                .HasMany(e => e.GBL_ALERTDTL)
                .WithRequired(e => e.GBL_LANGUAGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_LANGUAGE>()
                .HasMany(e => e.GBL_GENERALDTL)
                .WithRequired(e => e.GBL_LANGUAGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_LANGUAGE>()
                .HasMany(e => e.GBL_SUBMENUOBJECTLABEL)
                .WithRequired(e => e.GBL_LANGUAGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_ROLE>()
                .HasMany(e => e.GBL_GRANTROLE)
                .WithRequired(e => e.GBL_ROLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_SUBMENU>()
                .HasMany(e => e.GBL_GRANTOBJECT)
                .WithRequired(e => e.GBL_SUBMENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GBL_SUBMENU>()
                .HasMany(e => e.GBL_SUPPORT)
                .WithOptional(e => e.GBL_SUBMENU)
                .HasForeignKey(e => e.CURRENT_OBJECT);

            modelBuilder.Entity<GBL_SUBMENUOBJECTLABEL>()
                .Property(e => e.LABEL)
                .IsFixedLength();

            modelBuilder.Entity<GBL_SUBMENUOBJECTS>()
                .Property(e => e.OBJECT_TYPE)
                .IsFixedLength();

            modelBuilder.Entity<GBL_SUBMENUOBJECTS>()
                .Property(e => e.OBJECT_NAME)
                .IsFixedLength();

            modelBuilder.Entity<HIS_REGISTRATION>()
                .HasMany(e => e.MG_PATIENTHISTORYCOMPARISON)
                .WithRequired(e => e.HIS_REGISTRATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HIS_REGISTRATION>()
                .HasMany(e => e.RIS_COMMENTSONPATIENT)
                .WithRequired(e => e.HIS_REGISTRATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HIS_REGISTRATION>()
                .HasMany(e => e.RIS_ORDER)
                .WithRequired(e => e.HIS_REGISTRATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HIS_REGISTRATION>()
                .HasMany(e => e.RIS_SCHEDULE_RESERVATION)
                .WithRequired(e => e.HIS_REGISTRATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HIS_REGISTRATION>()
                .HasMany(e => e.RIS_SCHEDULE)
                .WithRequired(e => e.HIS_REGISTRATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.AC_ASSIGNMENT)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.ASSIGNED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.AC_ENROLLMENT)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.AC_EVALUATION)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.EVALUATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.AC_EVALUATIONLOGIC)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_GRANTOBJECT)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_GRANTROLE)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_GROUP)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.GROUP_HEAD);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_GROUPDTL)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.MEMBER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_MYMENU)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.EMP_ID);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_MYMENU1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.EMP_ID);

            modelBuilder.Entity<HR_EMP>()
                .HasOptional(e => e.GBL_RADEXPERIENCE)
                .WithRequired(e => e.HR_EMP);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_SUPPORT)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_USERGROUP)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.GROUP_HEAD);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.GBL_USERGROUPDTL)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.MEMBER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMDF)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMDF1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_UPDATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.INV_REQUISITION)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.GENERATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.MIS_BIOPSYRESULT)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.RADIOLOGIST_ID);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_ORDER)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.REF_DOC);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_CLINICALINDICATIONTYPEFAVORITES)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_COMMENTSONPATIENT)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.COMMENT_FROM);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_COMMENTSONPATIENTDTL)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.COMMENT_TO);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMRESULT_FILTERRAD)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMRESULT)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.RELEASED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMRESULT1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.FINALIZED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMRESULTACCESS)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.ACCESS_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMRESULTNOTE)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.NOTE_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMRESULTRADS)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.RAD_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMRESULTSTATREPORT)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.NOTE_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMTEMPLATESHARE)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.SHARE_WITH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_RISKINCIDENTUSERS)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_MODALITYCONFIG)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_MODALITYCONFIG1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_RADSTUDYGROUP)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.RADIOLOGIST_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE_RESERVATION)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CONFIRMED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE_RESERVATION1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE_RESERVATION2)
                .WithOptional(e => e.HR_EMP2)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE_RESERVATION3)
                .WithOptional(e => e.HR_EMP3)
                .HasForeignKey(e => e.REF_DOC);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULECONFIG)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULECONFIG1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTDESTINATION)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.EMP_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTDESTINATION1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTDESTINATION2)
                .WithOptional(e => e.HR_EMP2)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTMODALITY)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTMODALITY1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CONFIRMED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE2)
                .WithOptional(e => e.HR_EMP2)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULE3)
                .WithOptional(e => e.HR_EMP3)
                .HasForeignKey(e => e.REF_DOC);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDTL)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDTL1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_SCHEDULEDTL2)
                .WithOptional(e => e.HR_EMP2)
                .HasForeignKey(e => e.RAD_ID);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_TECHWORKSDTL)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.TECHNOLOGIST_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONS)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONS1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSANSWERS)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSANSWERS1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSANSWERSDTL)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSANSWERSDTL1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSANSWERSDTLCHILD)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSANSWERSDTLCHILD1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSDTL)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSDTL1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSDTLCHILD)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONSDTLCHILD1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONTYPE)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_QUESTIONTYPE1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_TEMPLATE)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_TEMPLATE1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_TEMPLATEANSWERSPART)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_TEMPLATEANSWERSPART1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_TEMPLATEPART)
                .WithOptional(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_TEMPLATEPART1)
                .WithOptional(e => e.HR_EMP1)
                .HasForeignKey(e => e.LAST_MODIFIED_BY);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.SR_USERPREFERENCE)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_TECHNOTES)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.CREATED_BY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_CLINICALINDICATIONFAVORITES)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_CLINICALINDICATIONLASTVISIT)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_EXAMFAVORITES)
                .WithRequired(e => e.HR_EMP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_NURSESDATA)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.NURSE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EMP>()
                .HasMany(e => e.RIS_PRGROUPDTL)
                .WithRequired(e => e.HR_EMP)
                .HasForeignKey(e => e.RAD_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_JOBTITLE>()
                .Property(e => e.IS_ACTIVE)
                .IsFixedLength();

            modelBuilder.Entity<HR_JOBTITLE>()
                .HasMany(e => e.HR_EMP)
                .WithOptional(e => e.HR_JOBTITLE)
                .HasForeignKey(e => e.JOBTITLE_ID);

            modelBuilder.Entity<HR_ROOM>()
                .HasMany(e => e.INV_ROOMSTOCKREDUCE)
                .WithRequired(e => e.HR_ROOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.INV_UNIT)
                .WithOptional(e => e.HR_UNIT)
                .HasForeignKey(e => e.EXTERNAL_UNIT);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.RIS_EXAMRVU)
                .WithRequired(e => e.HR_UNIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.RIS_MODALITYUNIT)
                .WithRequired(e => e.HR_UNIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.RIS_LOCATIONMAPPING)
                .WithRequired(e => e.HR_UNIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.RIS_SCHEDULE_RESERVATION)
                .WithOptional(e => e.HR_UNIT)
                .HasForeignKey(e => e.REF_UNIT);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.RIS_SCHEDULE)
                .WithOptional(e => e.HR_UNIT)
                .HasForeignKey(e => e.REF_UNIT);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.RIS_CLINICALINDICATION_WITH_UNIT)
                .WithRequired(e => e.HR_UNIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_UNIT>()
                .HasMany(e => e.RIS_PATIENTDESTINATION)
                .WithOptional(e => e.HR_UNIT)
                .HasForeignKey(e => e.EXAM_UNIT);

            modelBuilder.Entity<INV_ITEM>()
                .Property(e => e.RE_ORDER_QTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_ITEM>()
                .Property(e => e.REUSE_PRICE_PERC)
                .HasPrecision(5, 2);

            modelBuilder.Entity<INV_ITEM>()
                .Property(e => e.PURCHASE_PRICE)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_ITEM>()
                .Property(e => e.SELLING_PRICE)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_ITEM>()
                .Property(e => e.WARNING_EMPTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_ITEM>()
                .Property(e => e.DANGEROUS_EMPTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_ITEMSTOCK>()
                .Property(e => e.QTY)
                .HasPrecision(11, 2);

            modelBuilder.Entity<INV_ITEMSTOCK>()
                .Property(e => e.PRICE)
                .HasPrecision(11, 2);

            modelBuilder.Entity<INV_ITEMTYPE>()
                .HasMany(e => e.INV_ITEM)
                .WithOptional(e => e.INV_ITEMTYPE)
                .HasForeignKey(e => e.TYPE_ID);

            modelBuilder.Entity<INV_PO>()
                .HasMany(e => e.INV_PODTL)
                .WithRequired(e => e.INV_PO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_PODTL>()
                .Property(e => e.QTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_PODTL>()
                .Property(e => e.UNITPRICE)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_PR>()
                .HasMany(e => e.INV_PRDTL)
                .WithRequired(e => e.INV_PR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_PRDTL>()
                .Property(e => e.QTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_PRDTL>()
                .HasOptional(e => e.INV_PRDTL1)
                .WithRequired(e => e.INV_PRDTL2);

            modelBuilder.Entity<INV_REQUISITION>()
                .HasMany(e => e.INV_AUTHORIZATION)
                .WithOptional(e => e.INV_REQUISITION)
                .HasForeignKey(e => e.PR_ID);

            modelBuilder.Entity<INV_REQUISITION>()
                .HasMany(e => e.INV_REQUISITIONDTL)
                .WithRequired(e => e.INV_REQUISITION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_REQUISITIONDTL>()
                .Property(e => e.QTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_SETTINGS>()
                .Property(e => e.GLOBAL_SELLING_MARKUP)
                .HasPrecision(5, 2);

            modelBuilder.Entity<INV_TRANSACTIONDTL>()
                .Property(e => e.QTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_TRANSACTIONDTL>()
                .Property(e => e.PRICE)
                .HasPrecision(9, 2);

            modelBuilder.Entity<INV_TXNUNIT>()
                .HasMany(e => e.INV_TRANSACTIONDTL)
                .WithOptional(e => e.INV_TXNUNIT)
                .HasForeignKey(e => e.TXN_UNIT);

            modelBuilder.Entity<INV_TXNUNIT>()
                .HasOptional(e => e.INV_TXNUNIT1)
                .WithRequired(e => e.INV_TXNUNIT2);

            modelBuilder.Entity<INV_UNIT>()
                .HasMany(e => e.INV_REQUISITION)
                .WithOptional(e => e.INV_UNIT)
                .HasForeignKey(e => e.FROM_UNIT);

            modelBuilder.Entity<INV_UNIT>()
                .HasMany(e => e.INV_REQUISITION1)
                .WithOptional(e => e.INV_UNIT1)
                .HasForeignKey(e => e.TO_UNIT);

            modelBuilder.Entity<INV_UNIT>()
                .HasMany(e => e.INV_ROOMSTOCKREDUCE)
                .WithRequired(e => e.INV_UNIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_UNIT>()
                .HasMany(e => e.INV_TRANSACTION)
                .WithOptional(e => e.INV_UNIT)
                .HasForeignKey(e => e.TO_UNIT);

            modelBuilder.Entity<INV_UNIT>()
                .HasMany(e => e.INV_TRANSACTION1)
                .WithOptional(e => e.INV_UNIT1)
                .HasForeignKey(e => e.FROM_UNIT);

            modelBuilder.Entity<INV_UNIT>()
                .HasMany(e => e.INV_UNITREORDERLEVEL)
                .WithRequired(e => e.INV_UNIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_UNITREORDERLEVEL>()
                .Property(e => e.REORDER_QTY)
                .HasPrecision(9, 2);

            modelBuilder.Entity<OLAP_ORDER>()
                .Property(e => e.RATE)
                .HasPrecision(30, 2);

            modelBuilder.Entity<OLAP_ORDER>()
                .Property(e => e.GROSS_INCOME)
                .HasPrecision(30, 2);

            modelBuilder.Entity<OLAP_ORDER_DELETED>()
                .Property(e => e.RATE)
                .HasPrecision(30, 2);

            modelBuilder.Entity<OLAP_ORDER_DELETED>()
                .Property(e => e.GROSS_INCOME)
                .HasPrecision(30, 2);

            modelBuilder.Entity<OLAP_ORDER_TEMP>()
                .Property(e => e.RATE)
                .HasPrecision(30, 2);

            modelBuilder.Entity<OLAP_ORDER_TEMP>()
                .Property(e => e.GROSS_INCOME)
                .HasPrecision(30, 2);

            modelBuilder.Entity<RIS_AUTHLEVEL>()
                .HasMany(e => e.HR_EMP)
                .WithOptional(e => e.RIS_AUTHLEVEL)
                .HasForeignKey(e => e.AUTH_LEVEL_ID);

            modelBuilder.Entity<RIS_AUTHLEVEL>()
                .HasMany(e => e.HR_EMP1)
                .WithOptional(e => e.RIS_AUTHLEVEL1)
                .HasForeignKey(e => e.AUTH_LEVEL_ID);

            modelBuilder.Entity<RIS_BILLINGTRANSACTIONLOGDTL>()
                .Property(e => e.ISEQ)
                .IsFixedLength();

            modelBuilder.Entity<RIS_BILLINGTRANSACTIONLOGDTL>()
                .Property(e => e.UNIT_UID)
                .IsFixedLength();

            modelBuilder.Entity<RIS_BPVIEW>()
                .HasMany(e => e.RIS_BPVIEWMAPPING)
                .WithRequired(e => e.RIS_BPVIEW)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICALINDICATION>()
                .HasMany(e => e.RIS_CLINICALINDICATION_WITH_UNIT)
                .WithRequired(e => e.RIS_CLINICALINDICATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICALINDICATION>()
                .HasMany(e => e.RIS_CLINICALINDICATIONFAVORITES)
                .WithRequired(e => e.RIS_CLINICALINDICATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICALINDICATION>()
                .HasMany(e => e.RIS_CLINICALINDICATIONLASTVISIT)
                .WithRequired(e => e.RIS_CLINICALINDICATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICALINDICATIONTYPE>()
                .HasMany(e => e.RIS_CLINICALINDICATIONLASTVISIT)
                .WithRequired(e => e.RIS_CLINICALINDICATIONTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICALINDICATIONTYPE>()
                .HasMany(e => e.RIS_CLINICALINDICATIONTYPEFAVORITES)
                .WithRequired(e => e.RIS_CLINICALINDICATIONTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICSESSION>()
                .HasMany(e => e.RIS_MODALITYCONFIG)
                .WithRequired(e => e.RIS_CLINICSESSION)
                .HasForeignKey(e => e.CLINIC_SESSION_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICSESSION>()
                .HasMany(e => e.RIS_SESSIONAPPCOUNT)
                .WithRequired(e => e.RIS_CLINICSESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICSESSION>()
                .HasMany(e => e.RIS_SESSIONMAXAPP)
                .WithRequired(e => e.RIS_CLINICSESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICTYPE>()
                .Property(e => e.RATE_INCREASE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RIS_CLINICTYPE>()
                .HasMany(e => e.RIS_EXAMRVU)
                .WithRequired(e => e.RIS_CLINICTYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_CLINICTYPE>()
                .HasMany(e => e.RIS_ORDERDTL)
                .WithOptional(e => e.RIS_CLINICTYPE)
                .HasForeignKey(e => e.CLINIC_TYPE);

            modelBuilder.Entity<RIS_COMMENTSONPATIENT>()
                .HasMany(e => e.RIS_COMMENTSONPATIENTDTL)
                .WithRequired(e => e.RIS_COMMENTSONPATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_COMMENTSYSTEM_GROUP>()
                .HasMany(e => e.RIS_COMMENTSYSTEM_GROUPDTL)
                .WithRequired(e => e.RIS_COMMENTSYSTEM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.RATE)
                .HasPrecision(13, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.GOVT_RATE)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.CLAIMABLE_AMT)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.NONCLAIMABLE_AMT)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.FREE_AMT)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.VAT_RATE)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.AVG_REQ_HRS)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.MIN_REQ_HRS)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.COST_PRICE)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.PREPARATION_TAT)
                .HasPrecision(7, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.DF_RAD)
                .HasPrecision(15, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .Property(e => e.DF_TECH)
                .HasPrecision(15, 2);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_BPVIEWMAPPING)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_CONFLICTEXAMDTL)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_EXAMRESULTTEMPLATE)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_EXAMRVU)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_EXAMTEMPLATESHARE)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_LOADMEDIADTL)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_MODALITYEXAM_ONL)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_MODALITYEXAM)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_OPNOTEITEMTEMPLATE)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_ORDERDTL)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_RELEASEMEDIA)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.RIS_TECHCONSUMPTION)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAM>()
                .HasMany(e => e.SR_USERPREFERENCE)
                .WithRequired(e => e.RIS_EXAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAMDF>()
                .Property(e => e.DF)
                .HasPrecision(11, 2);

            modelBuilder.Entity<RIS_EXAMRESULT>()
                .Property(e => e.RESULT_BINARY)
                .IsFixedLength();

            modelBuilder.Entity<RIS_EXAMRESULT>()
                .HasMany(e => e.RIS_EXAMRESULTNOTE)
                .WithRequired(e => e.RIS_EXAMRESULT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAMRESULT>()
                .HasMany(e => e.RIS_PRSTUDIES)
                .WithRequired(e => e.RIS_EXAMRESULT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAMRESULT>()
                .HasMany(e => e.RIS_SEARCH_DTL)
                .WithRequired(e => e.RIS_EXAMRESULT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAMRESULT_FILTERWORKLIST>()
                .HasMany(e => e.RIS_EXAMRESULT_FILTERRAD)
                .WithRequired(e => e.RIS_EXAMRESULT_FILTERWORKLIST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_EXAMRESULTTEMPLATE>()
                .Property(e => e.TEMPLATE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<RIS_LOADMEDIA>()
                .HasMany(e => e.RIS_LOADMEDIADTL)
                .WithRequired(e => e.RIS_LOADMEDIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITY>()
                .HasMany(e => e.RIS_MODALITYEXAM_ONL)
                .WithRequired(e => e.RIS_MODALITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITY>()
                .HasMany(e => e.RIS_MODALITYEXAM)
                .WithRequired(e => e.RIS_MODALITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITY>()
                .HasMany(e => e.RIS_MODALITYUNIT)
                .WithRequired(e => e.RIS_MODALITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITY>()
                .HasMany(e => e.RIS_ORDERDTL)
                .WithRequired(e => e.RIS_MODALITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITY>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTMODALITY)
                .WithRequired(e => e.RIS_MODALITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITY>()
                .HasMany(e => e.RIS_SESSIONAPPCOUNT)
                .WithRequired(e => e.RIS_MODALITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITY>()
                .HasMany(e => e.RIS_SESSIONMAXAPP)
                .WithRequired(e => e.RIS_MODALITY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_MODALITYLOG>()
                .Property(e => e.START_LSN)
                .IsFixedLength();

            modelBuilder.Entity<RIS_MODALITYLOG>()
                .Property(e => e.SEQVAL)
                .IsFixedLength();

            modelBuilder.Entity<RIS_MODALITYLOGCAPTURE>()
                .Property(e => e.MIN_LSN)
                .IsFixedLength();

            modelBuilder.Entity<RIS_MODALITYLOGCAPTURE>()
                .Property(e => e.MAX_LSN)
                .IsFixedLength();

            modelBuilder.Entity<RIS_MODALITYTYPE>()
                .HasMany(e => e.RIS_MODALITY)
                .WithOptional(e => e.RIS_MODALITYTYPE)
                .HasForeignKey(e => e.MODALITY_TYPE);

            modelBuilder.Entity<RIS_NURSESDATA>()
                .HasMany(e => e.RIS_NURSESDATADTL)
                .WithRequired(e => e.RIS_NURSESDATA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_OPNOTEITEM>()
                .HasMany(e => e.RIS_OPNOTEITEMTEMPLATE)
                .WithRequired(e => e.RIS_OPNOTEITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_ORDER>()
                .HasMany(e => e.RIS_ORDERDTL)
                .WithRequired(e => e.RIS_ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_ORDER>()
                .HasMany(e => e.RIS_RELEASEMEDIA)
                .WithRequired(e => e.RIS_ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_ORDERDTL>()
                .Property(e => e.RATE)
                .HasPrecision(13, 2);

            modelBuilder.Entity<RIS_PATIENTDESTINATION>()
                .HasMany(e => e.RIS_LOCATIONMAPPING)
                .WithRequired(e => e.RIS_PATIENTDESTINATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_PATIENTDESTINATION>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTDESTINATION)
                .WithRequired(e => e.RIS_PATIENTDESTINATION)
                .WillCascadeOnDelete(false);
                        
            modelBuilder.Entity<RIS_PRGROUP>()
                .HasMany(e => e.RIS_PRSTUDIES)
                .WithRequired(e => e.RIS_PRGROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_PRGROUP>()
                .HasMany(e => e.RIS_PRGROUPDTL)
                .WithRequired(e => e.RIS_PRGROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_QAWORKS>()
                .HasOptional(e => e.RIS_QAWORKS1)
                .WithRequired(e => e.RIS_QAWORKS2);

            modelBuilder.Entity<RIS_RISKINCIDENTS>()
                .HasMany(e => e.RIS_RISKINCIDENTUSERS)
                .WithRequired(e => e.RIS_RISKINCIDENTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_SCHEDULE>()
                .HasMany(e => e.RIS_ORDERCLINICALINDICATION)
                .WithOptional(e => e.RIS_SCHEDULE)
                .HasForeignKey(e => e.SCHEDULE_ID);

            modelBuilder.Entity<RIS_SCHEDULE>()
                .HasMany(e => e.RIS_ORDERCLINICALINDICATION1)
                .WithOptional(e => e.RIS_SCHEDULE1)
                .HasForeignKey(e => e.SCHEDULE_ID);

            modelBuilder.Entity<RIS_SCHEDULEDEFAULTDESTINATION>()
                .HasMany(e => e.RIS_SCHEDULEDEFAULTMODALITY)
                .WithRequired(e => e.RIS_SCHEDULEDEFAULTDESTINATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_SCHEDULEDTL>()
                .Property(e => e.RATE)
                .HasPrecision(13, 2);

            modelBuilder.Entity<RIS_TECHCONSUMPTION>()
                .Property(e => e.QTY)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RIS_TECHCONSUMPTION>()
                .Property(e => e.RATE)
                .HasPrecision(11, 2);

            modelBuilder.Entity<RIS_TECHWORKS>()
                .HasOptional(e => e.RIS_TECHWORKS1)
                .WithRequired(e => e.RIS_TECHWORKS2);

            modelBuilder.Entity<SR_QUESTIONS>()
                .Property(e => e.QUESTION_TEXT)
                .IsUnicode(false);

            modelBuilder.Entity<SR_QUESTIONS>()
                .HasMany(e => e.SR_QUESTIONSDTL)
                .WithRequired(e => e.SR_QUESTIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SR_TEMPLATE>()
                .HasMany(e => e.SR_USERPREFERENCE)
                .WithRequired(e => e.SR_TEMPLATE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RIS_PRASSIGNMENT>()
               .Property(e => e.STATUS)
               .IsUnicode(false);

            modelBuilder.Entity<RIS_PRSUBSPECIALTY>()
                .Property(e => e.ALLOW_PEER_REVIEW)
                .IsFixedLength();
        }
    }
}
