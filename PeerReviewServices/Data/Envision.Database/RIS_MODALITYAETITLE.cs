namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_MODALITYAETITLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_MODALITYAETITLE()
        {
            RIS_ORDERDTL = new HashSet<RIS_ORDERDTL>();
        }

        [Key]
        public int AE_TITLE_ID { get; set; }

        [StringLength(300)]
        public string AE_TITLE_NAME { get; set; }

        public int? MODALITY_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual RIS_MODALITY RIS_MODALITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_ORDERDTL> RIS_ORDERDTL { get; set; }
    }
}
