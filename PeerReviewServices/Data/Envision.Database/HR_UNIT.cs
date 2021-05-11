namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_UNIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HR_UNIT()
        {
            FIN_INVOICE = new HashSet<FIN_INVOICE>();
            FIN_PAYMENT = new HashSet<FIN_PAYMENT>();
            INV_UNIT = new HashSet<INV_UNIT>();
            RIS_EXAMRESULTSEVERITY = new HashSet<RIS_EXAMRESULTSEVERITY>();
            RIS_EXAMRVU = new HashSet<RIS_EXAMRVU>();
            RIS_MODALITYUNIT = new HashSet<RIS_MODALITYUNIT>();
            RIS_OPNOTEITEM = new HashSet<RIS_OPNOTEITEM>();
            RIS_LOCATIONMAPPING = new HashSet<RIS_LOCATIONMAPPING>();
            RIS_SCHEDULE_RESERVATION = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULE = new HashSet<RIS_SCHEDULE>();
            RIS_CLINICALINDICATION_WITH_UNIT = new HashSet<RIS_CLINICALINDICATION_WITH_UNIT>();
            RIS_PATIENTDESTINATION = new HashSet<RIS_PATIENTDESTINATION>();
        }

        [Key]
        public int UNIT_ID { get; set; }

        [StringLength(30)]
        public string UNIT_UID { get; set; }

        public int? UNIT_ID_PARENT { get; set; }

        [StringLength(100)]
        public string UNIT_NAME { get; set; }

        [StringLength(100)]
        public string UNIT_NAME_ALIAS { get; set; }

        [StringLength(50)]
        public string PHONE_NO { get; set; }

        [StringLength(500)]
        public string DESCR { get; set; }

        [StringLength(30)]
        public string UNIT_ALIAS { get; set; }

        [StringLength(1)]
        public string UNIT_TYPE { get; set; }

        [StringLength(4000)]
        public string UNIT_INS { get; set; }

        [StringLength(1)]
        public string IS_EXTERNAL { get; set; }

        [StringLength(100)]
        public string LOC { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(30)]
        public string LOC_ALIAS { get; set; }

        [StringLength(300)]
        public string UNIT_PARENT_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_INVOICE> FIN_INVOICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIN_PAYMENT> FIN_PAYMENT { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_UNIT> INV_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRESULTSEVERITY> RIS_EXAMRESULTSEVERITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMRVU> RIS_EXAMRVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITYUNIT> RIS_MODALITYUNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_OPNOTEITEM> RIS_OPNOTEITEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_LOCATIONMAPPING> RIS_LOCATIONMAPPING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_CLINICALINDICATION_WITH_UNIT> RIS_CLINICALINDICATION_WITH_UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PATIENTDESTINATION> RIS_PATIENTDESTINATION { get; set; }
    }
}
