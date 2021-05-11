namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_ORDER()
        {
            RIS_COMMENTSONPATIENT = new HashSet<RIS_COMMENTSONPATIENT>();
            RIS_ORDERDTL = new HashSet<RIS_ORDERDTL>();
            RIS_ORDERIMAGES = new HashSet<RIS_ORDERIMAGES>();
            RIS_RELEASEMEDIA = new HashSet<RIS_RELEASEMEDIA>();
        }

        [Key]
        public int ORDER_ID { get; set; }

        public int REG_ID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        [StringLength(30)]
        public string VISIT_NO { get; set; }

        [StringLength(30)]
        public string ADMISSION_NO { get; set; }

        public DateTime ORDER_DT { get; set; }

        public int? SCHEDULE_ID { get; set; }

        public int? INSURANCE_TYPE_ID { get; set; }

        public DateTime? ORDER_START_TIME { get; set; }

        public int? REF_UNIT { get; set; }

        public int? REF_DOC { get; set; }

        [StringLength(3)]
        public string PAT_STATUS { get; set; }

        [StringLength(500)]
        public string REF_DOC_INSTRUCTION { get; set; }

        [StringLength(2000)]
        public string CLINICAL_INSTRUCTION { get; set; }

        [StringLength(1000)]
        public string REASON { get; set; }

        [StringLength(1000)]
        public string DIAGNOSIS { get; set; }

        public int? ICD_ID { get; set; }

        public int? ARRIVAL_BY { get; set; }

        public DateTime? ARRIVAL_ON { get; set; }

        [StringLength(1)]
        public string IS_CANCELED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public DateTime? LMP_DT { get; set; }

        [StringLength(1)]
        public string IS_REQONLINE { get; set; }

        [StringLength(30)]
        public string XRAY_NO { get; set; }

        [StringLength(50)]
        public string REQUESTNO { get; set; }

        [StringLength(100)]
        public string ENC_ID { get; set; }

        [StringLength(10)]
        public string ENC_TYPE { get; set; }

        [StringLength(30)]
        public string ENC_CLINIC { get; set; }

        [StringLength(1)]
        public string IS_PRINTED { get; set; }

        public DateTime? REQUEST_RESULT_DATETIME { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HIS_REGISTRATION HIS_REGISTRATION { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSONPATIENT> RIS_COMMENTSONPATIENT { get; set; }

        public virtual RIS_INSURANCETYPE RIS_INSURANCETYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERIMAGES> RIS_ORDERIMAGES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_RELEASEMEDIA> RIS_RELEASEMEDIA { get; set; }
    }
}
