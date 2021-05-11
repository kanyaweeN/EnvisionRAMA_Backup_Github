namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_EXAM()
        {
            RIS_BPVIEWMAPPING = new HashSet<RIS_BPVIEWMAPPING>();
            RIS_COMMENTSONPATIENTDTL = new HashSet<RIS_COMMENTSONPATIENTDTL>();
            RIS_CONFLICTEXAMDTL = new HashSet<RIS_CONFLICTEXAMDTL>();
            RIS_EXAMDF = new HashSet<RIS_EXAMDF>();
            RIS_EXAMINSTRUCTIONS = new HashSet<RIS_EXAMINSTRUCTIONS>();
            RIS_EXAMRESULTTEMPLATE = new HashSet<RIS_EXAMRESULTTEMPLATE>();
            RIS_EXAMRVU = new HashSet<RIS_EXAMRVU>();
            RIS_EXAMTEMPLATESHARE = new HashSet<RIS_EXAMTEMPLATESHARE>();
            RIS_LOADMEDIADTL = new HashSet<RIS_LOADMEDIADTL>();
            RIS_MODALITYEXAM_ONL = new HashSet<RIS_MODALITYEXAM_ONL>();
            RIS_MODALITYEXAM = new HashSet<RIS_MODALITYEXAM>();
            RIS_OPNOTEITEMTEMPLATE = new HashSet<RIS_OPNOTEITEMTEMPLATE>();
            RIS_ORDERDTL = new HashSet<RIS_ORDERDTL>();
            RIS_RELEASEMEDIA = new HashSet<RIS_RELEASEMEDIA>();
            RIS_TECHCONSUMPTION = new HashSet<RIS_TECHCONSUMPTION>();
            SR_TEMPLATE = new HashSet<SR_TEMPLATE>();
            SR_USERPREFERENCE = new HashSet<SR_USERPREFERENCE>();
        }

        [Key]
        public int EXAM_ID { get; set; }

        [StringLength(30)]
        public string EXAM_UID { get; set; }

        [StringLength(30)]
        public string GOVT_ID { get; set; }

        [Required]
        [StringLength(300)]
        public string EXAM_NAME { get; set; }

        [StringLength(300)]
        public string REPORT_HEADER { get; set; }

        [StringLength(20)]
        public string REQ_SAMPLE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GOVT_RATE { get; set; }

        public int? EXAM_TYPE { get; set; }

        [Required]
        [StringLength(2)]
        public string SERVICE_TYPE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CLAIMABLE_AMT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NONCLAIMABLE_AMT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FREE_AMT { get; set; }

        [StringLength(1)]
        public string SPECIAL_CLINIC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SPECIAL_RATE { get; set; }

        [StringLength(1)]
        public string VAT_APPLICABLE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VAT_RATE { get; set; }

        public int? UNIT_ID { get; set; }

        public int? REV_HEAD_ID { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AVG_REQ_HRS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MIN_REQ_HRS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? COST_PRICE { get; set; }

        public byte? RELEASE_AUTH_LEVEL { get; set; }

        public byte? FINALIZE_AUTH_LEVEL { get; set; }

        [StringLength(1)]
        public string PREPARATION_FLAG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PREPARATION_TAT { get; set; }

        [StringLength(1)]
        public string REPEAT_FLAG { get; set; }

        public int? ICD_ID { get; set; }

        public int? ACR_ID { get; set; }

        public int? CPT_ID { get; set; }

        public byte? DEF_CAPTURE { get; set; }

        public byte? DEF_IMAGES { get; set; }

        [StringLength(1)]
        public string IS_STRUCTURED_REPORT { get; set; }

        [StringLength(1)]
        public string QA_REQUIRED { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(30)]
        public string CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(30)]
        public string LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? BP_ID { get; set; }

        public bool? STAT_POSSIBLE { get; set; }

        public byte? STAT_TAT_MIN { get; set; }

        public bool? URGENT_POSSIBLE { get; set; }

        public byte? URGENT_TAT_MIN { get; set; }

        [StringLength(1)]
        public string DEFER_HIS_RECONCILE { get; set; }

        [StringLength(1)]
        public string IS_CHECKUP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VIP_RATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DF_RAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DF_TECH { get; set; }

        [StringLength(150)]
        public string EXAM_BARCODE { get; set; }

        [StringLength(1)]
        public string CAN_REQONLINE { get; set; }

        public int? AVG_REQ_MIN { get; set; }

        [StringLength(1)]
        public string IS_BIRAD_REPORT { get; set; }

        [StringLength(1)]
        public string NEED_SCHEDULE { get; set; }

        [StringLength(1)]
        public string NEED_APPROVE { get; set; }

        [StringLength(1)]
        public string NEED_SIDE { get; set; }

        [StringLength(1)]
        public string IS_CONSULT_CASE { get; set; }

        [StringLength(1)]
        public string IS_PORTABLE { get; set; }

        [StringLength(1)]
        public string IS_COMMENTS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FOREIGN_RATE { get; set; }

        public int? BPVIEW_ID { get; set; }

        [StringLength(1)]
        public string VISIBLE_REQONLINE { get; set; }

        [StringLength(300)]
        public string REQONL_DISPLAY { get; set; }

        [StringLength(30)]
        public string BILLING_CODE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FOREIGN_SPCIAL_RATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FOREIGN_VIP_RATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_BPVIEWMAPPING> RIS_BPVIEWMAPPING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENTDTL> RIS_COMMENTSONPATIENTDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CONFLICTEXAMDTL> RIS_CONFLICTEXAMDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMDF> RIS_EXAMDF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMINSTRUCTIONS> RIS_EXAMINSTRUCTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTTEMPLATE> RIS_EXAMRESULTTEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRVU> RIS_EXAMRVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMTEMPLATESHARE> RIS_EXAMTEMPLATESHARE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_LOADMEDIADTL> RIS_LOADMEDIADTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYEXAM_ONL> RIS_MODALITYEXAM_ONL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYEXAM> RIS_MODALITYEXAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_OPNOTEITEMTEMPLATE> RIS_OPNOTEITEMTEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RELEASEMEDIA> RIS_RELEASEMEDIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_TECHCONSUMPTION> RIS_TECHCONSUMPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATE> SR_TEMPLATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_USERPREFERENCE> SR_USERPREFERENCE { get; set; }
    }
}
