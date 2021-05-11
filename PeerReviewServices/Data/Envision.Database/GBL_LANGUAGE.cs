namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GBL_LANGUAGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GBL_LANGUAGE()
        {
            GBL_ALERTDTL = new HashSet<GBL_ALERTDTL>();
            GBL_GENERALDTL = new HashSet<GBL_GENERALDTL>();
            GBL_SUBMENUOBJECTLABEL = new HashSet<GBL_SUBMENUOBJECTLABEL>();
            SR_TEMPLATE = new HashSet<SR_TEMPLATE>();
        }

        [Key]
        public int LANG_ID { get; set; }

        [StringLength(30)]
        public string LANG_UID { get; set; }

        [StringLength(100)]
        public string LANG_NAME { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_ALERTDTL> GBL_ALERTDTL { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_GENERALDTL> GBL_GENERALDTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GBL_SUBMENUOBJECTLABEL> GBL_SUBMENUOBJECTLABEL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SR_TEMPLATE> SR_TEMPLATE { get; set; }
    }
}
