namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_COMMENTSYSTEM_GROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_COMMENTSYSTEM_GROUP()
        {
            RIS_COMMENTSYSTEM_GROUPDTL = new HashSet<RIS_COMMENTSYSTEM_GROUPDTL>();
        }

        [Key]
        public int GROUP_ID { get; set; }

        [StringLength(200)]
        public string GROUP_NAME { get; set; }

        [StringLength(500)]
        public string GROUP_DESC { get; set; }

        [StringLength(50)]
        public string GROUP_TAG { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFEID_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_COMMENTSYSTEM_GROUPDTL> RIS_COMMENTSYSTEM_GROUPDTL { get; set; }
    }
}
