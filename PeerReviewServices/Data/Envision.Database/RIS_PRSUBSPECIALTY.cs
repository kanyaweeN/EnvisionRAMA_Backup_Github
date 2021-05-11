namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_PRSUBSPECIALTY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_PRSUBSPECIALTY()
        {
            RIS_PREXAMMAPPING = new HashSet<RIS_PREXAMMAPPING>();
            RIS_PRRADMAPPING = new HashSet<RIS_PRRADMAPPING>();
        }

        [Key]
        public int SUB_SPECIALTY_ID { get; set; }

        [StringLength(50)]
        public string SUB_SPECIALTY_TEXT { get; set; }

        [StringLength(1)]
        public string ALLOW_PEER_REVIEW { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PREXAMMAPPING> RIS_PREXAMMAPPING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_PRRADMAPPING> RIS_PRRADMAPPING { get; set; }
    }
}
