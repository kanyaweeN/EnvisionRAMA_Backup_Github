namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_RELEASEMEDIA
    {
        [Key]
        public int RELEASE_ID { get; set; }

        public int ORDER_ID { get; set; }

        public int EXAM_ID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        public DateTime RELEASE_DATE { get; set; }

        [Required]
        [StringLength(1)]
        public string REQUEST_BY { get; set; }

        public int REQUEST_BY_ID { get; set; }

        [StringLength(50)]
        public string RECEIVED_BY { get; set; }

        [Required]
        [StringLength(1)]
        public string REASON { get; set; }

        [StringLength(1000)]
        public string COMMENT { get; set; }

        public int? UNIT_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public byte? QTY { get; set; }

        [StringLength(1)]
        public string MEDIA_TYPE { get; set; }

        public virtual RIS_EXAM RIS_EXAM { get; set; }

        public virtual RIS_ORDER RIS_ORDER { get; set; }
    }
}
