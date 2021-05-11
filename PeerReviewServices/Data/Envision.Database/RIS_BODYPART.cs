namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_BODYPART
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_BODYPART()
        {
            SR_TEMPLATE = new HashSet<SR_TEMPLATE>();
        }

        [Key]
        public int BP_ID { get; set; }

        [StringLength(30)]
        public string BP_UID { get; set; }

        [StringLength(50)]
        public string BP_DESC { get; set; }

        [StringLength(6)]
        public string SHORT_NAME { get; set; }

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
        public virtual ICollection<SR_TEMPLATE> SR_TEMPLATE { get; set; }
    }
}
