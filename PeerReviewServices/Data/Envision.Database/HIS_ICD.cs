namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HIS_ICD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HIS_ICD()
        {
            RIS_SCHEDULE_RESERVATION = new HashSet<RIS_SCHEDULE_RESERVATION>();
            RIS_SCHEDULE = new HashSet<RIS_SCHEDULE>();
            RIS_ORDERICD = new HashSet<RIS_ORDERICD>();
        }

        [Key]
        public int ICD_ID { get; set; }

        [StringLength(30)]
        public string ICD_UID { get; set; }

        [StringLength(200)]
        public string ICD_DESC { get; set; }

        [StringLength(50)]
        public string ICD_VERSION { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE_RESERVATION> RIS_SCHEDULE_RESERVATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULE> RIS_SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERICD> RIS_ORDERICD { get; set; }
    }
}
