namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_CLINICTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_CLINICTYPE()
        {
            RIS_CLINICSESSION = new HashSet<RIS_CLINICSESSION>();
            RIS_CLINICSESSIONONLINE = new HashSet<RIS_CLINICSESSIONONLINE>();
            RIS_EXAMRVU = new HashSet<RIS_EXAMRVU>();
            RIS_ORDERDTL = new HashSet<RIS_ORDERDTL>();
        }

        [Key]
        public int CLINIC_TYPE_ID { get; set; }

        [StringLength(30)]
        public string CLINIC_TYPE_UID { get; set; }

        [StringLength(200)]
        public string CLINIC_TYPE_TEXT { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RATE_INCREASE { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? ORG_ID { get; set; }

        public int? SL_NO { get; set; }

        [StringLength(10)]
        public string CLINIC_TYPE_ALIAS { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICSESSION> RIS_CLINICSESSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICSESSIONONLINE> RIS_CLINICSESSIONONLINE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRVU> RIS_EXAMRVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }
    }
}
