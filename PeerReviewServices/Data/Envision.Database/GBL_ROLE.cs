namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_ROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GBL_ROLE()
        {
            GBL_GRANTROLE = new HashSet<GBL_GRANTROLE>();
        }

        [Key]
        public int ROLE_ID { get; set; }

        [StringLength(50)]
        public string ROLE_UID { get; set; }

        [StringLength(50)]
        public string ROLE_NAME { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(100)]
        public string DESCR { get; set; }

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
        public virtual ICollection<GBL_GRANTROLE> GBL_GRANTROLE { get; set; }
    }
}
