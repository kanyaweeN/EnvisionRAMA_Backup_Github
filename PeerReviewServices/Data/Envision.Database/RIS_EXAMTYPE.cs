namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_EXAMTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_EXAMTYPE()
        {
            RIS_EXAMINSTRUCTIONS = new HashSet<RIS_EXAMINSTRUCTIONS>();
        }

        [Key]
        public int EXAM_TYPE_ID { get; set; }

        [StringLength(30)]
        public string EXAM_TYPE_UID { get; set; }

        [StringLength(30)]
        public string EXAM_TYPE_TEXT { get; set; }

        [StringLength(50)]
        public string EXAM_TYPE_ABBR { get; set; }

        [StringLength(4000)]
        public string EXAM_TYPE_INS { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [StringLength(4000)]
        public string EXAM_TYPE_INS_KID { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_EXAMINSTRUCTIONS> RIS_EXAMINSTRUCTIONS { get; set; }
    }
}
