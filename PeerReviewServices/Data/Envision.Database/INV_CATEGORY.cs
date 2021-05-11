namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_CATEGORY()
        {
            INV_ITEM = new HashSet<INV_ITEM>();
        }

        [Key]
        public int CATEGORY_ID { get; set; }

        [StringLength(30)]
        public string CATEGORY_UID { get; set; }

        [StringLength(100)]
        public string CATEGORY_NAME { get; set; }

        [StringLength(250)]
        public string CATEGORY_DESC { get; set; }

        public int? PARENT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_ITEM> INV_ITEM { get; set; }
    }
}
