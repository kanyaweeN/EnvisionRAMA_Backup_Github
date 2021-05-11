namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MG_BREASTMARKDTL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MG_BREASTMARKDTL()
        {
            MG_MASSDOMINANTCYST = new HashSet<MG_MASSDOMINANTCYST>();
        }

        [Key]
        public int BREAST_MARKDTL_ID { get; set; }

        public int? BREAST_MARK_ID { get; set; }

        [StringLength(50)]
        public string MARK_ID { get; set; }

        public byte? MASS_NO { get; set; }

        [StringLength(1)]
        public string IS_US_FINDING { get; set; }

        [StringLength(1)]
        public string BREAST_VIEW { get; set; }

        [StringLength(1)]
        public string SHAPE { get; set; }

        [StringLength(1)]
        public string STYLE { get; set; }

        public int? ORIGIN_X { get; set; }

        public int? ORIGIN_Y { get; set; }

        [StringLength(50)]
        public string FILL_COLOR { get; set; }

        [StringLength(50)]
        public string STROKE_COLOR { get; set; }

        public int? DIMENSION { get; set; }

        public int? THICKNESS { get; set; }

        public int? START_COOR_X { get; set; }

        public int? START_COOR_Y { get; set; }

        public int? END_COOR_X { get; set; }

        public int? END_COOR_Y { get; set; }

        public float? ANGLE { get; set; }

        public int? CLOCK_NO { get; set; }

        public int? LOCATION_X { get; set; }

        public int? LOCATION_Y { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual MG_BREASTMARK MG_BREASTMARK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MG_MASSDOMINANTCYST> MG_MASSDOMINANTCYST { get; set; }
    }
}
