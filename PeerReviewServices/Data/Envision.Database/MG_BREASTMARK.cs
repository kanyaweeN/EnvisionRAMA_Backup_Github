namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MG_BREASTMARK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MG_BREASTMARK()
        {
            MG_BREASTMARKDTL = new HashSet<MG_BREASTMARKDTL>();
        }

        [Key]
        public int BREAST_MARK_ID { get; set; }

        [StringLength(30)]
        public string ACCESSION_NO { get; set; }

        public int? BREAST_SCREEN_WIDTH { get; set; }

        public int? BREAST_SCREEN_HIGHT { get; set; }

        [Column(TypeName = "image")]
        public byte[] BREAST_SCREEN_IMG { get; set; }

        public int? BREAST_SCREEN_SCALE { get; set; }

        public int? NO_OF_MASS { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_BREASTMARKDTL> MG_BREASTMARKDTL { get; set; }
    }
}
