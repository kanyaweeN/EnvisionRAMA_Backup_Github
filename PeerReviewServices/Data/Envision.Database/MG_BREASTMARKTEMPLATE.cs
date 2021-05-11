namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MG_BREASTMARKTEMPLATE
    {
        [Key]
        public int TPL_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string TPL_NAME { get; set; }

        public int? EMP_ID { get; set; }

        [StringLength(1)]
        public string SHAPE { get; set; }

        [StringLength(1)]
        public string STYLE { get; set; }

        [StringLength(50)]
        public string FILL_COLOR { get; set; }

        [StringLength(50)]
        public string STROKE_COLOR { get; set; }

        [StringLength(50)]
        public string BORDER_COLOR { get; set; }

        [StringLength(50)]
        public string FONT_COLOR { get; set; }

        [StringLength(50)]
        public string FONT_FAMILY { get; set; }

        public int? FONT_SIZE { get; set; }

        public int? DIMENSION { get; set; }

        public int? THICKNESS { get; set; }

        [StringLength(1)]
        public string UNIT { get; set; }

        [StringLength(1)]
        public string SHOW_BORDER { get; set; }

        [StringLength(1)]
        public string CAN_RESIZE { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual GBL_ENV GBL_ENV { get; set; }

        public virtual HR_EMP HR_EMP { get; set; }
    }
}
