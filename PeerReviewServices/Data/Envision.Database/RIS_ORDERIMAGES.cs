namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_ORDERIMAGES
    {
        [Key]
        public int ORDER_IMAGE_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string HN { get; set; }

        public int? ORDER_ID { get; set; }

        public byte? SL_NO { get; set; }

        [StringLength(200)]
        public string IMAGE_NAME { get; set; }

        public int? ORG_ID { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public int? SCHEDULE_ID { get; set; }

        [StringLength(200)]
        public string IMAGE_NAME_OLD { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual RIS_ORDER RIS_ORDER { get; set; }
    }
}
