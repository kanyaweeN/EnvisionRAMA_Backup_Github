namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_BPVIEW
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_BPVIEW()
        {
            RIS_BPVIEWMAPPING = new HashSet<RIS_BPVIEWMAPPING>();
            RIS_SCHEDULEDTL = new HashSet<RIS_SCHEDULEDTL>();
        }

        [Key]
        public int BPVIEW_ID { get; set; }

        [StringLength(30)]
        public string BPVIEW_UID { get; set; }

        [StringLength(30)]
        public string BPVIEW_NAME { get; set; }

        [StringLength(50)]
        public string BPVIEW_DESC { get; set; }

        public byte? NO_OF_EXAM { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_BPVIEWMAPPING> RIS_BPVIEWMAPPING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL { get; set; }
    }
}
