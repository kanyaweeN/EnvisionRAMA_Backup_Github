namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_PO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_PO()
        {
            INV_PODTL = new HashSet<INV_PODTL>();
        }

        [Key]
        public int PO_ID { get; set; }

        [StringLength(50)]
        public string PO_UID { get; set; }

        public int? PR_ID { get; set; }

        public DateTime? GENERATED_ON { get; set; }

        public int? VENDOR_ID { get; set; }

        [StringLength(4000)]
        public string TOC { get; set; }

        [StringLength(1)]
        public string PO_STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual INV_VENDOR INV_VENDOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PODTL> INV_PODTL { get; set; }
    }
}
