namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_GENERALDTL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GBL_GENERALDTL()
        {
            RIS_SCHEDULEDTL = new HashSet<RIS_SCHEDULEDTL>();
        }

        [Key]
        public int GEN_DTL_ID { get; set; }

        public int GEN_ID { get; set; }

        public int LANG_ID { get; set; }

        [StringLength(300)]
        public string GEN_TEXT { get; set; }

        [StringLength(50)]
        public string GEN_TITLE { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(1)]
        public string IS_UPDATED { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public byte? SL_NO { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual GBL_LANGUAGE GBL_LANGUAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_SCHEDULEDTL> RIS_SCHEDULEDTL { get; set; }
    }
}
