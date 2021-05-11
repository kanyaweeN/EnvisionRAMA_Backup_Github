namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_LOADMEDIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RIS_LOADMEDIA()
        {
            RIS_LOADMEDIADTL = new HashSet<RIS_LOADMEDIADTL>();
        }

        [Key]
        public int LOAD_ID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        [StringLength(30)]
        public string VISIT_NO { get; set; }

        [StringLength(30)]
        public string ADMISSION_NO { get; set; }

        public DateTime LOAD_DT { get; set; }

        public DateTime? LOAD_START_TIME { get; set; }

        [Required]
        [StringLength(1)]
        public string REQ_BY { get; set; }

        public int? REQ_UNIT { get; set; }

        public int? REQ_DOC { get; set; }

        [Required]
        [StringLength(1)]
        public string MEDIA_TYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string REASON { get; set; }

        [StringLength(1000)]
        public string COMMENT { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIS_LOADMEDIADTL> RIS_LOADMEDIADTL { get; set; }
    }
}
