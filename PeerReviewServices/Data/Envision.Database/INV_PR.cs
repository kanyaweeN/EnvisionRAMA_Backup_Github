namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_PR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_PR()
        {
            INV_PRDTL = new HashSet<INV_PRDTL>();
        }

        [Key]
        public int PR_ID { get; set; }

        [StringLength(50)]
        public string PR_UID { get; set; }

        [StringLength(1)]
        public string GENERATE_MODE { get; set; }

        public int? GENERATED_BY { get; set; }

        public DateTime? GENERATED_ON { get; set; }

        [StringLength(1)]
        public string PR_STATUS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PRDTL> INV_PRDTL { get; set; }
    }
}
