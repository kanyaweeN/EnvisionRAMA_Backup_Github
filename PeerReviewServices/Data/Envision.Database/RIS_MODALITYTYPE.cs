namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MODALITYTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_MODALITYTYPE()
        {
            RIS_MODALITY = new HashSet<RIS_MODALITY>();
        }

        [Key]
        public int TYPE_ID { get; set; }

        [StringLength(30)]
        public string TYPE_UID { get; set; }

        [StringLength(100)]
        public string TYPE_NAME { get; set; }

        [StringLength(100)]
        public string TYPE_NAME_ALIAS { get; set; }

        [StringLength(500)]
        public string DESCR { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? ORG_ID { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_MODALITY> RIS_MODALITY { get; set; }
    }
}
